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

namespace nvocc.Controllers.PDF
{
    [Route("api/[controller]")]

    [ApiController]
    public class AClBlController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public AClBlController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("NavioPrintPDF")]
        public List<MyCountry> BLPrintPDF(MyCountry Data)
        {
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();
            DataTable _dt = GetBkgCustomer(Data);
            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            //var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//navio/");
            var pdfpath = Path.Combine("UploadFolder");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            //string FileHidpath = "ClientApp//src//assets//pdfFiles//navio/Multiple-BL.pdf";
            var FileHidpath = Path.Combine("UploadFolder");

            string _FileName = "test";
            var FileNamev = "";
            Random rd = new Random();
            FileNamev += rd.Next(1000).ToString();
            FileNamev += "_" + _FileName;
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath + FileNamev + ".pdf", FileMode.Create));



            doc.Open();

            PdfContentByte cb = writer.DirectContent;
            cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
            int _Xp = 10, _Yp = 785, YDiff = 10;

            BaseFont bfheader = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader, 14);
            BaseFont Crossbfheader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.SetFontAndSize(Crossbfheader, 90);
            cb.Stroke();

            //Top
            cb.MoveTo(10, 828);
            cb.LineTo(660, 828);

            cb.MoveTo(10, 828);
            cb.LineTo(10, 10);

            cb.MoveTo(660, 828);
            cb.LineTo(660, 10);

            cb.MoveTo(10, 728);
            cb.LineTo(330, 728);

            cb.MoveTo(10, 628);
            cb.LineTo(660, 628);

            cb.MoveTo(10, 528);
            cb.LineTo(660, 528);

            cb.MoveTo(10, 498);
            cb.LineTo(660, 498);

            cb.MoveTo(10, 468);
            cb.LineTo(660, 468);

            cb.MoveTo(10, 448);
            cb.LineTo(660, 448);

            cb.MoveTo(330, 828);
            cb.LineTo(330, 468);

            cb.MoveTo(150, 528);
            cb.LineTo(150, 268);

            cb.MoveTo(480, 528);
            cb.LineTo(480, 268);

            cb.MoveTo(10, 268);
            cb.LineTo(660, 268);

            cb.MoveTo(10, 248);
            cb.LineTo(660, 248);

            cb.MoveTo(10, 140);
            cb.LineTo(660, 140);

            cb.MoveTo(10, 120);
            cb.LineTo(660, 120);

            cb.MoveTo(10, 100);
            cb.LineTo(660, 100);

            cb.MoveTo(10, 10);
            cb.LineTo(660, 10);

            cb.MoveTo(150, 140);
            cb.LineTo(150, 100);

            cb.MoveTo(330, 140);
            cb.LineTo(330, 10);

            cb.MoveTo(480, 140);
            cb.LineTo(480, 100);

            cb.BeginText();
            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/navio.png"));
            png1.SetAbsolutePosition(380, 650);
            png1.ScalePercent(70f);
            doc.Add(png1);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 11);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "OCEAN BILL OF LADING", 15, 838, 0);
            cb.EndText();
            cb.BeginText();
            BaseFont bfheader2 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader2, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FOR COMBINED OR MULTIMODAL TRANSPORT DOCUMENT", 335, 838, 0);
            cb.EndText();
            cb.BeginText();
            BaseFont bfheader3 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader3, 70);
            cb.SetColorFill(iTextSharp.text.BaseColor.LIGHT_GRAY);
            if (printvalue == "1")
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   D R A F T   ", 200, 400, 45);
            }
            else
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 100, 200, 45);
            }

            if (Data.printvalue == "1")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   D R A F T   ", 320, 840, 0);
            if (Data.printvalue == "2")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   FIRST ORIGINAL   ", 320, 840, 0);
            if (Data.printvalue == "3")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   SECOND ORIGINAL   ", 320, 840, 0);
            if (Data.printvalue == "4")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   THIRD ORIGINAL   ", 320, 840, 405);

            if (Data.printvalue == "5")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   SEAWAY BL-NON NEGOTIABLE   ", 320, 840, 0);
            if (Data.printvalue == "6")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   EXPRESS RELEASE   ", 320, 840, 0);
            if (Data.printvalue == "7")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   SURRENDER BL   ", 320, 840, 0);
            if (Data.printvalue == "8")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   RFS 1ST ORIGINAL   ", 320, 840, 0);
            if (Data.printvalue == "9")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   RFS 2ND ORIGINAL   ", 320, 840, 0);
            if (Data.printvalue == "10")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "  RFS 3RD ORIGINAL    ", 320, 840, 0);
            if (Data.printvalue == "11")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "  BACK PAGE    ", 320, 840, 0);

            cb.EndText();

            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 15, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee(Or Order):", 15, 718, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Address", 15, 618, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Pre-carriage By", 15, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt", 155, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Ocean Vessel/Voyage No", 355, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 485, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Discharge", 15, 488, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Final Delivery", 155, 488, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Mode/Means of Transport", 355, 488, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Route/Place of Transhipment", 485, 488, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B/L NO:", 335, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Also Notify Party:", 335, 618, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 485, 488, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No.Seal No./& Marks", 15, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Description of Goods & Pkgs", 155, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross Weight", 485, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Cbm", 575, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ORIGINAL", 500, 278, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PARTICULAR FURNISHED BY THE SHIPPER/CONSIGNOR - CARRIER NOT RESPONSE", 155, 258, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader41 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader41, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Address", 15, 618, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Pre-carriage By", 15, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["PlaceOfReceipt"].ToString(), 155, 506, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Ocean Vessel/Voyage No", 355, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["PlaceOfReceipt"].ToString(), 485, 506, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Discharge"].ToString(), 15, 476, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Destination"].ToString(), 155, 476, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 355, 488, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 485, 488, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BLNumber"].ToString(), 400, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Also Notify Party:", 335, 618, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 485, 476, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No.Seal No./& Marks", 15, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Description of Goods & Pkgs", 155, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross Weight", 485, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Cbm", 575, 458, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["MarksNos"].ToString(), 15, 438, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Packages"].ToString(), 120, 438, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Description"].ToString(), 155, 438, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Weight"].ToString(), 485, 438, 0);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ORIGINAL", 500, 278, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PARTICULAR FURNISHED BY THE SHIPPER/CONSIGNOR - CARRIER NOT RESPONSE", 155, 258, 0);


            int ColumnShipper = 806; int RowsColumnShipper = 0;
            RowsColumnShipper = 0;
            string[] ArrayAddress = Regex.Split(_dt.Rows[0]["ShipperName"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["ShipperAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit;

            for (int x = 0; x < ArrayAddress.Length; x++)
            {
                Aaddsplit = ArrayAddress[x].Split('\n');

                for (int k = 0; k < Aaddsplit.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit[k].ToString(), 15, ColumnShipper, 0);
                    ColumnShipper -= 9;
                    RowsColumnShipper++;
                }
            }


            int ColumnConsignee = 706; int RowsColumnConsignee = 0;
            RowsColumnConsignee = 0;
            string[] ArrayAddress1 = Regex.Split(_dt.Rows[0]["Consignee"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["ConsigneeAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit1;

            for (int x = 0; x < ArrayAddress1.Length; x++)
            {
                Aaddsplit1 = ArrayAddress1[x].Split('\n');

                for (int k = 0; k < Aaddsplit1.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit1[k].ToString(), 15, ColumnConsignee, 0);
                    ColumnConsignee -= 9;
                    RowsColumnConsignee++;
                }
            }
            int ColumnNotify = 606; int RowsColumnNotify = 0;
            RowsColumnNotify = 0;
            string[] ArrayAddress2 = Regex.Split(_dt.Rows[0]["Notify"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["NotifyAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit2;

            for (int x = 0; x < ArrayAddress2.Length; x++)
            {
                Aaddsplit2 = ArrayAddress2[x].Split('\n');

                for (int k = 0; k < Aaddsplit2.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit2[k].ToString(), 15, ColumnNotify, 0);
                    ColumnNotify -= 9;
                    RowsColumnNotify++;
                }
            }

            int ColumnAlsoNotify = 606; int RowsColumnAlsoNotify = 0;
            RowsColumnAlsoNotify = 0;
            string[] ArrayAddress3 = Regex.Split(_dt.Rows[0]["Notifyalso"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["NotifyAlsoAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit3;

            for (int x = 0; x < ArrayAddress3.Length; x++)
            {
                Aaddsplit3 = ArrayAddress3[x].Split('\n');

                for (int k = 0; k < Aaddsplit3.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit3[k].ToString(), 335, ColumnAlsoNotify, 0);
                    ColumnAlsoNotify -= 9;
                    RowsColumnAlsoNotify++;
                }
            }

            cb.EndText();

            int ColumnRows = 238;
            int RowsColumn = 0;
            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 6);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            string text = @"Received in good order and condition,unless otherwise noted herein.at the place of receipt for transport and delivery as mentioned above the particulars as stated above by shipper and the weight,quantity. condition, 
            contents and value of goods are unknown to the carrier Quality, quantity and nature of the cargo stuffed inside the container by the shipper is unknown to the carrier. one of these Combined Transport Bill of Lading 
            must be surrendered duly endorsed in exchange for the goods. IN WITNESS whereof the original Combined Transport Bill of Lading all of this tendor and date have been signed in the number stated below one of 
            which being accomplished and the other(s) to be void.The contract evidenced by or contained in this bill of lading is governed by the law of UAE and any clain dispute arising hereunder or in connection herewith 
            shall be determined by the courts in UAE and no other courts. Cargo insurance not provided by the carriers in case subject shipment in not loaded on vessel named aforesaid for any reason/is not cleared/by claimed 
            by the consignee and cargo is abandoned at destination or cargo is mis-declared by the shipper subject to any seizure of the shipment at port of loading or port of discharge all charges/penalities/fines/legal fee 
            pertaining to this shipment will be for shippers account and carrier hold shipper fully responsible for the same all charges with regard to losses and / or damages to container(s),while empty container(s)is/are returnes 
            to lines custody at destination will be on consignee account ,Destination THC ,Container Detention charges and all other applicable ancilaries are payable at destination by consignee. the shipment will be held back by 
            carrier/carriers agent if shipper or consignee owes any money without any responsibilty of claims on their party.in case shipment has been rejected by the authorities at the discharge port,re shipment 
            expenses,demurage,detention etc.and all freight charges will be on shippers account. carrier is not responsible for the condition of cargo.";
            string[] Arrayterms = Regex.Split(text, char.ConvertFromUtf32(13));
            string[] Addsplit1;

            for (int x = 0; x < Arrayterms.Length; x++)
            {
                Addsplit1 = Arrayterms[x].Split('\n');

                for (int k = 0; k < Addsplit1.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Addsplit1[k].ToString(), 15, ColumnRows, 0);
                    ColumnRows -= 4;
                    RowsColumn++;
                }
            }
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Charges", 15, 130, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Payable at", 155, 130, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number of Originals", 335, 130, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place and Date of issue", 485, 130, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["PaymentTerms"].ToString(), 15, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["FreightPayableAt"].ToString(), 155, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["NoOfOriginal"].ToString(), 335, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["PlaceOfIssue"].ToString(), 485, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BLIssueDate"].ToString(), 600, 110, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "For DELIVERY, PLEASE APPLY TO", 15, 90, 0);

            int ColumnDeliveryAgent = 78; int RowsColumnDeliveryAgent = 0;
            RowsColumnDeliveryAgent = 0;
            string[] ArrayAddress4 = Regex.Split(_dt.Rows[0]["DeliveryAgent"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["DeliveryAgentAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit4;

            for (int x = 0; x < ArrayAddress4.Length; x++)
            {
                Aaddsplit4 = ArrayAddress4[x].Split('\n');

                for (int k = 0; k < Aaddsplit4.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit4[k].ToString(), 15, ColumnDeliveryAgent, 0);
                    ColumnDeliveryAgent -= 9;
                    RowsColumnDeliveryAgent++;
                }
            }
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "AS AGENTS", 400, 20, 0);

            cb.EndText();

            cb.BeginText();
            BaseFont bfheader6 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader6, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "For NAVIO SHIPPING LLC", 400, 90, 0);

            cb.EndText();
            cb.Stroke();
            doc.Close();
            pdfmp.AddFile(FileNamev + ".pdf");



            pdfmp.Execute();
            string str = FileHidpath;
            string mime = pdfpath;
            ViewList.Add(new MyCountry
            {
                navioFilename = FileNamev
            });

            return ViewList;
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

        public DataTable GetBkgCustomer(MyCountry Data)
        {
            string _Query = " select NVO_BOLNew.ID, " +
                            " (select top(1) ShipperName from NVO_PartiesDtls where NVO_PartiesDtls.ShipperType = 1 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID) as ShipperName, " +
                            " (select top(1) ShipperAddress from NVO_PartiesDtls where ShipperType = 1 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID) as ShipperAddress, " +
                            " (select top(1) Consignee from NVO_PartiesDtls where ConsigneeType = 2 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as Consignee, " +
                            " (select top(1) ConsigneeAddress from NVO_PartiesDtls where ConsigneeType = 2 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as ConsigneeAddress, " +
                            " (select top(1) Notify from NVO_PartiesDtls where NotifyType = 3 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as Notify, " +
                            " (select top(1) NotifyAddress from NVO_PartiesDtls where NotifyType = 3 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as NotifyAddress, " +
                            " (select top(1) Notifyalso from NVO_PartiesDtls where NotifyAlsoType = 4 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as Notifyalso, " +
                            " (select top(1) NotifyAlsoAddress from NVO_PartiesDtls where NotifyAlsoType = 4 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as NotifyAlsoAddress, " +
                            " (select BLNumber from NVO_BL where NVO_BL.ID = NVO_BOLNew.BLID)as BLNumber, " +
                            " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PlaceofRecID)as PlaceOfReceipt, " +
                            " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PortofLoadID)as PortofLoading, " +
                            " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PortofDischargeID)as Discharge, " +
                            " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PortofDestinationID)as Destination, " +
                            " PaymentTerms,FreightPayableAt,NoOfOriginal,PlaceOfIssue,convert(varchar,BLIssueDate,103)as BLIssueDate, " +
                            " (select AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_BOLNew.DeliveryAgent)as DeliveryAgent,DeliveryAgentAddress,MarksNos,Description,Packages,Weight from NVO_BOLNew " +
                            " where BLID =" + Data.BLID;
            return Manag.GetViewData(_Query, "");
        }


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
