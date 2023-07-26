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
    public class IMLPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public IMLPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("IMLPrintPDF")]
        public List<MyCountry> BLPrintPDF(MyCountry Data)
        {
            string id = "69";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//iml/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            string FileHidpath = "ClientApp//src//assets//pdfFiles//iml/Multiple-BL.pdf";

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


            //Center
            cb.MoveTo(330, 830);
            cb.LineTo(330, 575);

            //Line1
            cb.MoveTo(10, 830);
            cb.LineTo(660, 830);

            //Line2
            cb.MoveTo(10, 770);
            cb.LineTo(660, 770);

            //Line3
            cb.MoveTo(10, 710);
            cb.LineTo(660, 710);

            //Line4
            cb.MoveTo(10, 650);
            cb.LineTo(660, 650);

            //Line5
            cb.MoveTo(10, 625);
            cb.LineTo(660, 625);

            //Line6
            cb.MoveTo(10, 600);
            cb.LineTo(660, 600);

            //Line7
            cb.MoveTo(10, 575);
            cb.LineTo(660, 575);

            //Line8
            cb.MoveTo(10, 560);
            cb.LineTo(660, 560);

            //Line9
            cb.MoveTo(10, 545);
            cb.LineTo(660, 545);

            //Line10
            cb.MoveTo(10, 190);
            cb.LineTo(660, 190);

            //Line11
            cb.MoveTo(10, 165);
            cb.LineTo(660, 165);

            //Line12
            cb.MoveTo(10, 150);
            cb.LineTo(660, 150);

            //Line13
            cb.MoveTo(10, 70);
            cb.LineTo(660, 70);

            //HorizontalLine1
            cb.MoveTo(330, 800);
            cb.LineTo(660, 800);

            //HorizontalLine2
            cb.MoveTo(330, 740);
            cb.LineTo(660, 740);

            //HorizontalLine3
            cb.MoveTo(400, 50);
            cb.LineTo(660, 50);

            //HorizontalLine4
            cb.MoveTo(410, 25);
            cb.LineTo(545, 25);

            //HorizontalLine5
            cb.MoveTo(560, 25);
            cb.LineTo(660, 25);

            //HorizontalLine6
            cb.MoveTo(410, 10);
            cb.LineTo(660, 10);

            //VerticalLine1
            cb.MoveTo(495, 830);
            cb.LineTo(495, 800);

            //VerticalLine2
            cb.MoveTo(165, 650);
            cb.LineTo(165, 575);

            //VerticalLine3
            cb.MoveTo(120, 560);
            cb.LineTo(120, 225);

            //VerticalLine4
            cb.MoveTo(185, 560);
            cb.LineTo(185, 225);

            //VerticalLine5
            cb.MoveTo(495, 560);
            cb.LineTo(495, 225);

            //VerticalLine6
            cb.MoveTo(575, 560);
            cb.LineTo(575, 225);

            //VerticalLine7
            cb.MoveTo(185, 165);
            cb.LineTo(185, 70);

            //VerticalLine8
            cb.MoveTo(290, 165);
            cb.LineTo(290, 70);

            //VerticalLine9
            cb.MoveTo(400, 165);
            cb.LineTo(400, 50);

            //VerticalLine10
            cb.MoveTo(550, 165);
            cb.LineTo(550, 50);




            cb.Stroke();
            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 14);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BILL OF LADING", 545, 835, 0);
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
            BaseFont bfheader3 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader3, 5);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Signed on behalh of the Carrier", 15, 10, 0);
            cb.EndText();

            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/iml.png"));
            png1.SetAbsolutePosition(15, 837);
            png1.ScalePercent(25f);
            doc.Add(png1);

            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 6);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SHIPPER", 15, 820, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CONSIGNEE (NOT NEGOTIABLE UNLESS CONSIGNED TO ORDER)", 15, 760, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NOTIFY PARTY (COMPLETE NAME AND ADDRESS)", 15, 700, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PRE-CARRIAGE BY*", 15, 640, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PLACE OF RECEIPT BY PRE-CARRIER", 175, 640, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "EXPORT CARRIER (VESSEL/VOY/FLAG)", 15, 615, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PORT OF LOADING", 175, 615, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "LOADING PIER/TERMINAL", 340, 615, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PORT OF DISCHARGE", 15, 590, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PLACE OF DELIVERY BY ON CARRIER*", 175, 590, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NUMBER OF ORIGINALS", 340, 590, 0);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BOOKING NO", 340, 820, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "EXPORT REFERENCES", 340, 790, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FORWARDING AGENT, F M C NO.", 340, 760, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "POINT AND COUNTRY OF ORIGIN OF GOODS", 340, 730, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FOR", 340, 700, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BILL OF LADING NO.", 505, 820, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DATED", 400, 35, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "AT", 400, 25, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ON", 550, 25, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BY", 400, 10, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "MRKS & NOS/CONTAINER NOS", 10, 550, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NO. OF PKGS", 130, 550, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DESCRIPTION OF PACKAGES AND GOODS", 250, 550, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "GROSS WEIGHT", 505, 550, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "MEASUREMENT", 585, 550, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FREIGHT & CHARGES", 70, 155, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BASIS", 220, 155, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "RATE", 330, 155, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PREPAID", 450, 155, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "COLLECT", 585, 155, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TOTAL", 450, 60, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TOTAL", 585, 60, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SHIPPERS DECLARED VALUE $", 15, 180, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SUBJECT TO EXTRA FREIGHT AS PER TARIFF AND CLAUSE 6 (4) (B) + (C) OF THIS B/L", 15, 170, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "These commodities, technology or software were exported from the United States in", 30, 205, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "accordance with the Export Administration Regulations. Diversion contrary to U.S. law prohibited.", 30, 195, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader6 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader6, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PARTICULARS FURNISHED BY SHIPPER", 235, 565, 0);
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
                imlFilename = FileNamev
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
