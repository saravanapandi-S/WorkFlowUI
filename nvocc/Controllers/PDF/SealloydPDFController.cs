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
    [Route("api/PDF/[controller]")]
    [ApiController]
    public class SealloydPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public SealloydPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SealloydPrintPDF")]
        public List<MyCountry> BLPrintPDF(MyCountry Data)
        {
            string id = "69";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//sealloyd/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            string FileHidpath = "ClientApp//src//assets//pdfFiles//sealloyd/Multiple-BL.pdf";

            string _FileName = "test";
            var FileNamev = "";
            Random rd = new Random();
            FileNamev += rd.Next(1000).ToString();
            FileNamev += "_" + _FileName;
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath + FileNamev + ".pdf", FileMode.Create));

            DataTable _dt = GetBkgCustomer(Data.id);

            doc.Open();

            PdfContentByte cb = writer.DirectContent;
            cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
            int _Xp = 10, _Yp = 785, YDiff = 10;

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
            cb.MoveTo(10, 595);
            cb.LineTo(660, 595);

            //Line2
            cb.MoveTo(10, 565);
            cb.LineTo(660, 565);

            //Line3
            cb.MoveTo(10, 535);
            cb.LineTo(660, 535);

            //Line4
            cb.MoveTo(10, 280);
            cb.LineTo(660, 280);

            //Line5
            cb.MoveTo(10, 130);
            cb.LineTo(660, 130);


            //HorizontalLine1
            cb.MoveTo(10, 835);
            cb.LineTo(330, 835);

            //HorizontalLine2
            cb.MoveTo(10, 765);
            cb.LineTo(330, 765);

            //HorizontalLine3
            cb.MoveTo(10, 695);
            cb.LineTo(330, 695);

            //HorizontalLine4
            cb.MoveTo(10, 625);
            cb.LineTo(330, 625);

            //HorizontalLine5
            cb.MoveTo(330, 660);
            cb.LineTo(660, 660);

            //HorizontalLine6
            cb.MoveTo(140, 100);
            cb.LineTo(660, 100);

            //HorizontalLine7
            cb.MoveTo(10, 70);
            cb.LineTo(430, 70);

            //HorizontalLine8
            cb.MoveTo(220, 05);
            cb.LineTo(420, 05);

            //HorizontalLine9
            cb.MoveTo(435, 05);
            cb.LineTo(660, 05);




            //VerticalLine1
            cb.MoveTo(120, 535);
            cb.LineTo(120, 295);

            //VerticalLine2
            cb.MoveTo(195, 535);
            cb.LineTo(195, 130);

            //VerticalLine3
            cb.MoveTo(280, 535);
            cb.LineTo(280, 280);

            //VerticalLine4
            cb.MoveTo(300, 280);
            cb.LineTo(300, 130);

            //VerticalLine5
            cb.MoveTo(430, 280);
            cb.LineTo(430, 05);

            //VerticalLine6
            cb.MoveTo(530, 280);
            cb.LineTo(530, 130);

            //VerticalLine7
            cb.MoveTo(495, 535);
            cb.LineTo(495, 280);

            //VerticalLine8
            cb.MoveTo(575, 535);
            cb.LineTo(575, 280);

            //VerticalLine9
            cb.MoveTo(140, 130);
            cb.LineTo(140, 70);

            //VerticalLine10
            cb.MoveTo(257, 130);
            cb.LineTo(257, 100);



            cb.Stroke();
            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 14);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BILL OF LADING", 15, 850, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "OR MULTIMODALTRANSPORT", 15, 828, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PARTICULARS FURNISHED BY SHIPPER - CARRIER NOT RESPONSIBLE", 200, 550, 0);
            cb.EndText();
            cb.BeginText();
            BaseFont bfheader2 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader2, 70);
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
            BaseFont bfheader3 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader3, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FOR OCEAN TRANSPORT OR MULTIMODAL TRANSPORT", 15, 838, 0);
            cb.EndText();

            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/sealloyd.jpg"));
            png1.SetAbsolutePosition(390, 785);
            png1.ScalePercent(35f);
            doc.Add(png1);

            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 15, 825, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee", 15, 755, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Party", 15, 685, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, " Also Notify Party / Delivery Agent", 335, 650, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Pre-Carriage vessel", 15, 615, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Ocean vessel", 15, 585, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Discharge", 15, 555, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Voy. No.", 145, 615, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Voy. No.", 145, 585, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt", 200, 615, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Loading", 200, 585, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of delivery/Final Destination", 200, 555, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Booking Ref. No.", 335, 585, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper's Ref.", 335, 555, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B/L No.", 500, 585, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "No. of Original B(s)L", 500, 555, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No.", 15, 525, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Seal No. or", 125, 525, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marks and Number", 125, 515, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number of Containers", 200, 525, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "of Packages", 200, 515, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Kind of Packages : Description of goods", 310, 525, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross Weight", 515, 525, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Measurement", 595, 525, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total No. of Containers Packages (in words)", 15, 285, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight & Charges", 15, 270, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Revenue Tons", 200, 270, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rate", 305, 270, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Per", 365, 270, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Prepaid", 435, 270, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Collect", 535, 270, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Ex. Rate", 15, 120, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Prepaid", 145, 120, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Payable at", 262, 120, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place and Date of Issue", 435, 120, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total prepaid and local currency", 145, 90, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Signed for the carrier Sea Lloyd Shipping Lines (Hong Kong) Pvt Ltd", 435, 90, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SHIPPED ON BOARD", 15, 60, 0);

            cb.EndText();

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Date:", 15, 12, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "By", 220, 12, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "By", 435, 12, 0);
            cb.EndText();


            int ColumnRows = 220;
            int RowsColumn = 0;

            int ColumnRows1 = 100;
            int RowsColumn1 = 0;

            //            cb.BeginText();
            //            BaseFont bfheader8 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //            cb.SetFontAndSize(bfheader8, 5);
            //            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);


            //            string text = @"RECEIVED by the Carrier the Goods as specified below in apparent good order and condition unless otherwise stated to be 
            //transported to such place as agreed,authorised or permitted here in and subject to all terms and conditions appearing on the front 
            //and reverse of this Bill of Lading to which the Merchant agrees by accepting this Bill of Lading , any local privileges and customes 
            //not withstanding.The particulars given below as stated by the Shipper and the weight,measure,quantity,condition,contents and the 
            //value of Goods are unknown to the Carrier.
            //In WITNESS where of one (3) original Bill of Lading has been signed if not otherwise stated here after ,the same being 
            //accomplished the other(s).if any,to be void,if required by the Carrier one (1)original Bill of Lading must be surrendered duly 
            //endorsed in exchange for Goods or Delivery Order.
            //LIMITATION ON CARRIERS LIABILITY /SHIPPERS AD VALOREM OPTION.the carrier shall in no event be or become liable 
            //for any loss of damage to or in connection.with the transportaion of goods in an amount exceeding us$500 per package, or in the 
            //case of goods not shipped in packages per customary freight nit or the equivalent of that sum in other currency (or such other 
            //limitaion imposed by a carriage of goods by sea act,statue or law in force according to the provisions hereof )unless the nature 
            //and value of such goods have been declared by the merchant before shipment and inserted in the bill of lading such declaration 
            //of value shall not however, be conclusive on the carrier for purpuse of determining the extent of the carrier liability.if the 
            //merchant desires to be covered for a valuation in excess of said us $5500 per package or customary freight unitor any other 
            //applicable limitaion the merchant must so stipulate in this bill of lading and such additional liability only will be assumed by the 
            //carrier upon payment of the carriers ad valorem freigh charge ....................................................
            //declared cargo values if merchant enters a value carriers limitaion of liabilty shall not apply";
            //            string[] Arrayterms = Regex.Split(text, char.ConvertFromUtf32(13));
            //            string[] Addsplit1;

            //            for (int x = 0; x < Arrayterms.Length; x++)
            //            {
            //                Addsplit1 = Arrayterms[x].Split('\n');

            //                for (int k = 0; k < Addsplit1.Length; k++)
            //                {

            //                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Addsplit1[k].ToString(), 335, ColumnRows, 0);
            //                    ColumnRows -= 4;
            //                    RowsColumn++;
            //                }
            //            }
            //            cb.EndText();

            cb.Stroke();
            doc.Close();
            pdfmp.AddFile(FileNamev + ".pdf");



            pdfmp.Execute();
            string str = FileHidpath;
            string mime = pdfpath;
            ViewList.Add(new MyCountry
            {
                sealloydFilename = FileNamev
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

        public DataTable GetBkgCustomer(string BLID)
        {
            string _Query = " select convert(varchar,BlDate, 103) as BlDatev,convert(varchar,SOBDate, 103) as SOBDatev,(SELECT top(1) NoofOriginal FROM NVO_BOL  where Id = NVO_BLRelease.BLID) as NoofOriginal,(select top(1) Notes from NVO_BLNotesClauses where DocID= 264 and NID=11) as ddlFreeday," +
                " (select top (1) case when GrsWtType=1 then 'KGS' else case when GrsWtType=2 then 'MT' end end from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID= NVO_BLRelease.BLID)  as GrsWtType, " +
                " (select top(1) case when NtWtType = 1 then 'KGS' else case when NtWtType = 2 then 'MT' end end  from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID = NVO_BLRelease.BLID) as NtWtType, " +
                " (select top(1) (select top(1) PkgDescription from NVO_CargoPkgMaster where NVO_CargoPkgMaster.Id = PakgType) from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID= NVO_BLRelease.BLID) as CargoPakage, * from NVO_BLRelease  where BLID=69";
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
