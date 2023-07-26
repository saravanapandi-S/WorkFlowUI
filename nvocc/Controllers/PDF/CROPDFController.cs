
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataManager;
using DataTier;
using Microsoft.Extensions.Configuration;
using nvocc.FunServices;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Web;
using System.Drawing;
using Rectangle = iTextSharp.text.Rectangle;
using System.Text;
using System.Security.Cryptography;

namespace nvocc.Controllers.PDF
{
    [Route("api/PDF/[controller]")]
    [ApiController]

    public class CROPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public CROPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("CROPrintPDF")]
        //[HttpGet("CROPrintPDF/{CROID}")]
        public async Task<IActionResult> CROPrintPDF([FromQuery] string CROID)
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            MergeEx pdfmp = new MergeEx();
            DateTime dTime = DateTime.Now;
            string strPDFFileName = string.Format("CustomerDetailPdf" + dTime.ToString("yyyyMMdd") + "-" + ".pdf");
            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            doc.SetMargins(0, 0, 0, 0);
            PdfPTable tableLayout = new PdfPTable(4);
            doc.SetMargins(10, 10, 10, 0);
            PdfWriter writer = PdfWriter.GetInstance(doc, workStream);
            doc.Open();

            DataTable _dt = GetBkgCustomer(CROID);

            PdfContentByte cb = writer.DirectContent;
            cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);

            BaseFont bfheader = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader, 14);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 300, 820, 0);
            //iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/bss.png"));
            //png1.SetAbsolutePosition(380, 760);
            //png1.ScalePercent(77f);
            //doc.Add(png1);

            BaseFont Crossbfheader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.SetFontAndSize(Crossbfheader, 90);


            //Line1
            cb.MoveTo(30, 740);
            cb.LineTo(655, 740);

            //Line2
            cb.MoveTo(30, 655);
            cb.LineTo(655, 655);

            //Line3
            cb.MoveTo(30, 585);
            cb.LineTo(655, 585);

            //Line4
            cb.MoveTo(30, 565);
            cb.LineTo(655, 565);

            //Line5
            cb.MoveTo(25, 40);
            cb.LineTo(660, 40);


            //VerticalLine1
            cb.MoveTo(30, 740);
            cb.LineTo(30, 565);

            //VerticalLine2
            cb.MoveTo(655, 740);
            cb.LineTo(655, 565);

            //CenterLine
            cb.MoveTo(350, 740);
            cb.LineTo(350, 565);

            cb.Stroke();
            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Branch Office :", 30, 770, 0);


            cb.EndText();
            cb.BeginText();
            BaseFont bfheader41 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader41, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "D/O No", 35, 730, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["ReleaseOrderNo"].ToString(), 105, 730, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Date", 35, 715, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["CRODate"].ToString(), 105, 715, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Validity", 35, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["validTill"].ToString(), 105, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Booking No", 35, 685, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BookingNo"].ToString(), 105, 685, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 95, 730, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 95, 715, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 95, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 95, 685, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Agent", 355, 730, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["AgencyName"].ToString(), 435, 730, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Line", 355, 715, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Line"].ToString(), 435, 715, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Load Port", 355, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["LoadPort"].ToString(), 435, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Discharge Port", 355, 685, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["DischargePort"].ToString(), 435, 685, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Final Destination", 355, 670, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Destination"].ToString(), 435, 670, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 425, 730, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 425, 715, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 425, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 425, 685, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 425, 670, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel", 35, 640, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Vessel"].ToString(), 105, 640, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ETA", 35, 625, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["ETA"].ToString(), 105, 625, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ETD", 35, 610, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["ETD"].ToString(), 105, 610, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Stuffing Point", 35, 595, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 105, 595, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Broker/CHA", 35, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["CustomerName"].ToString(), 105, 570, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 95, 640, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 95, 625, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 95, 610, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 95, 595, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 95, 570, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "VIA No", 355, 640, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Voyage"].ToString(), 435, 640, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rotation No.", 355, 625, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["RotationNo"].ToString(), 435, 625, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port Cut Off.", 355, 610, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "List Cut Off.", 355, 595, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 355, 570, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 425, 640, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 425, 625, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 425, 610, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 425, 595, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 425, 570, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 14);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "EXPORT DELIVERY ORDER", 230, 745, 0);

            cb.EndText();

            cb.BeginText();
            BaseFont bfheader3 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader3, 10);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "REGISTERED OFFICE ADDRESS :", 80, 25, 0);
            cb.EndText();

            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("UploadFolder/BLLogos/cro.png"));
            png1.SetAbsolutePosition(50, 770);
            png1.ScalePercent(50f);
            doc.Add(png1);

            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "To", 35, 550, 0);

            int ColumnRows = 540; int RowsColumn = 0;
            RowsColumn = 0;
            string[] ArrayAddress = Regex.Split(_dt.Rows[0]["depo"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["DepoAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit;

            for (int x = 0; x < ArrayAddress.Length; x++)
            {
                Aaddsplit = ArrayAddress[x].Split('\n');

                for (int k = 0; k < Aaddsplit.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit[k].ToString(), 35, ColumnRows, 0);
                    ColumnRows -= 9;
                    RowsColumn++;
                }
            }



            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Dear Sir/Madam,", 35, 470, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Kindly Deliver the following containers to ", 35, 455, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["CustomerName"].ToString(), 180, 455, 0);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container Type", 35, 440, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["ContainerType"].ToString(), 145, 440, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Commodity", 35, 425, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Commodity"].ToString(), 145, 425, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Cargo Weight(KGS)", 35, 410, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["CargoWeight"].ToString(), 145, 410, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Release Remarks", 35, 395, 0);

            int ColumnRows1 = 395;
            int RowsColumn1 = 0;
            RowsColumn1 = 0;
            string[] ArrayAddress2 = Regex.Split(_dt.Rows[0]["YardRemarks"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit2;

            for (int x = 0; x < ArrayAddress2.Length; x++)
            {
                Aaddsplit2 = ArrayAddress2[x].Split('\n');

                for (int k = 0; k < Aaddsplit2.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit2[k].ToString(), 145, ColumnRows1, 0);
                    ColumnRows1 -= 9;
                    RowsColumn1++;
                }
            }

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "IMCO Details", 35, 305, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container Details", 35, 290, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Containerdetails"].ToString(), 145, 290, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Surveyor", 35, 275, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["SurveyorName"].ToString(), 145, 275, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 135, 440, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 135, 425, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 135, 410, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 135, 395, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 135, 305, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 135, 290, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 135, 275, 0);


            cb.EndText();

            cb.BeginText();
            BaseFont bfheader51 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader51, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Note: PLEASE CHECK & TAKE THE SOUND CONDITION CONTAINER AS PER SHIPPER'S REQUIREMENT", 30, 175, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "For reefers gate will be opened 48hrs before the normal gate cutoff. -2 days Plug in Free at GTI & JNPT and 1 day plug in Free at NSICT, NSIGT & BMCT", 30, 155, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "thereafter charges will be at actualsas per port Tariff.", 30, 145, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader6 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader6, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Thanking You", 30, 125, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NAVIO SHIPPING PRIVATE LIMITED", 30, 110, 0);

            cb.EndText();

            cb.BeginText();
            BaseFont bfheader7 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader7, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "311, V-Times Square, Sec 15 CBD Belapur, Navi Mumbai - 400614, India", 250, 25, 0);

            cb.EndText();



            cb.BeginText();
            BaseFont bfheader9 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader9, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.EndText();



            cb.Stroke();

            writer.CloseStream = false;
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;
            return File(workStream, "application/pdf", strPDFFileName);
        }






        private string[] SplitByLenght(string Values, int split)
        {

            List<string> list = new List<string>();
            int SplitTheLoop = Values.Length / split;
            for (int i = 0; i < SplitTheLoop; i++)
                list.Add(Values.Substring(i * split, split));
            if (SplitTheLoop * split != Values.Length)
                list.Add(Values.Substring(SplitTheLoop * split));

            return list.ToArray();
        }


        public DataTable GetBkgCustomer(string CROID)
        {
            string _Query = " select NVO_CROMaster.ID,NVO_CROMaster.ReleaseOrderNo,NVO_CROMaster.ID,  convert(varchar,ValidTill,103) as validTill,NVO_Booking.BookingNo,NVO_Booking.CargoWeight," +
                             " convert(varchar,ETA,103) as ETA,convert(varchar,ETD,103) as ETD,convert(varchar,Date,103) as CRODate, " +
                             " (select (PortCode +'-'+ PortName) from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.LoadPortID)as LoadPort, " +
                             " (select (PortCode +'-'+ PortName) from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.DischargePortID)as DischargePort, " +
                             " (select (PortCode +'-'+ PortName) from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.DestinationID)as Destination, " +
                             " (select LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = NVO_Booking.PrincipalID) as Line, " +
                             " (select VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID)as Vessel, " +
                             " (select VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID)as Voyage, " +
                             " (select top(1) RotationNo from NVO_VoyTerminalDtls where NVO_VoyTerminalDtls.VoyID = NVO_Booking.VoyageID)as RotationNo, " +
                             " (select Size from NVO_tblCntrTypes where NVO_tblCntrTypes.ID = NVO_CRODetails.CntrTypeID)as ContainerType, " +
                             " (select Commodity from NVO_Enquiry where NVO_Enquiry.ID = NVO_Booking.EnquiryID) as Commodity, " +
                             " (select AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_Booking.PODAgentID)as AgencyName, " +
                             " (select Qty from NVO_CRODetails where NVO_CRODetails.CID = NVO_CROMaster.ID)as Containerdetails, " +
                             " (select top 1 CustomerName from NVO_view_CustomerDetails where cid = NVO_CROMaster.Surveyor)as SurveyorName,Remarks, " +
                             " (select top 1 CustomerName from NVO_view_CustomerDetails where CID = ReleaseToID) as CustomerName,YardRemarks, " +
                             " (select top 1 DepName from  NVO_DepotMaster where ID=PickDepoID) depo, " +
                             " (select top 1 DepAddress from  NVO_DepotMaster where ID=PickDepoID) DepoAddress " +
                             " from NVO_CROMaster" +
                             " inner join NVO_Booking on NVO_Booking.ID= NVO_CROMaster.BkgID " +
                             " inner join NVO_Voyage on NVO_Voyage.ID= NVO_Booking.VoyageID " +
                             " inner join NVO_CRODetails on NVO_CRODetails.CROID= NVO_CROMaster.ID " +
                             " where NVO_CROMaster.ID= " + CROID;

            return Manag.GetViewData(_Query, "");
        }


        //public DataTable GetBkgCustomer(MyCountry Data)
        //{
        //    string _Query = " select NVO_CROMaster.ID, convert(varchar,ValidTill,103) as validTill,NVO_Booking.BookingNo,convert(varchar,ETA,103) as ETA,convert(varchar,ETD,103) as ETD,convert(varchar,Date,103) as CRODate, " +
        //                     " (select (PortCode +'-'+ PortName) from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.LoadPortID)as LoadPort," +
        //                     " (select (PortCode +'-'+ PortName) from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.DischargePortID)as DischargePort," +
        //                     " (select (PortCode +'-'+ PortName) from NVO_PortMaster where NVO_PortMaster.ID = NVO_Booking.DestinationID)as Destination," +
        //                     " (select LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = NVO_Booking.PrincipalID) as Line," +
        //                     " (select VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID)as Vessel," +
        //                     " (select VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID)as Voyage," +
        //                     " (select top(1) RotationNo from NVO_VoyTerminalDtls where NVO_VoyTerminalDtls.VoyID = NVO_Booking.VoyageID)as RotationNo," +
        //                     " (select Type from NVO_tblCntrTypes where NVO_tblCntrTypes.ID = NVO_CRODetails.CntrTypeID)as ContainerType" +
        //                     " from NVO_CROMaster" +
        //                     " inner join NVO_Booking on NVO_Booking.ID= NVO_CROMaster.BkgID" +
        //                     " inner join NVO_Voyage on NVO_Voyage.ID= NVO_Booking.VoyageID" +
        //                     " inner join NVO_CRODetails on NVO_CRODetails.CROID= NVO_CROMaster.ID" +
        //                     " where NVO_CROMaster.BkgID=" + Data.ID;

        //    return Manag.GetViewData(_Query, "");
        //}


        public DataTable GetContainerDetails(string BLID)
        {
            string _Query = " Select(select top(1) CntrNo from NVO_Containers where Id = NVO_BOLCntrDetails.CntrID) + '/ ' + size + '/ ' + SealNo + '/ \n/' + convert(varchar, convert(decimal(8, 3), GrsWt)) + ' - ' + (case when GrsWtType = 1 then 'KGS' else 'MT' end) + '/' + convert(varchar, convert(decimal(8, 3), NtWt))  + '- ' + (case when NtWtType = 1 then 'KGS' else 'MT' end) + '/' + convert(varchar, convert(decimal(8, 3), CBM)) + 'CBM' as CntrDtls from NVO_BOLCntrDetails where BLID = 69";

            return Manag.GetViewData(_Query, "");
        }

        public DataTable GetNotes(string BLID)
        {
            string _Query = "select Notes from NVO_BLNotesClauses inner join NVO_BOL on NVO_BOL.PODID=NVO_BLNotesClauses.PortID where Id=69";

            return Manag.GetViewData(_Query, "");
        }
    }
}
