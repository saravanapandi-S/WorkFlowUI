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
    public class SeaHorsePDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public SeaHorsePDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("SeaHorsePrintPDF")]
        public List<MyCountry> BLPrintPDF(MyCountry Data)
        {
            string id = "69";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//seahorse/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            string FileHidpath = "ClientApp//src//assets//pdfFiles//seahorse/Multiple-BL.pdf";

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

            cb.BeginText();
            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/seahorse.png"));
            png1.SetAbsolutePosition(400, 700);
            png1.ScalePercent(70f);
            doc.Add(png1);
            cb.EndText();

            BaseFont Crossbfheader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.SetFontAndSize(Crossbfheader, 90);
            cb.Stroke();

            cb.MoveTo(10,828);
            cb.LineTo(330,828);

            cb.MoveTo(10, 728);
            cb.LineTo(330, 728);

            cb.MoveTo(10, 628);
            cb.LineTo(660, 628);

            cb.MoveTo(10, 628);
            cb.LineTo(660, 628);

            cb.MoveTo(330, 608);
            cb.LineTo(660, 608);
            cb.MoveTo(330, 578);
            cb.LineTo(660, 578);

            cb.MoveTo(480, 608);
            cb.LineTo(480, 578);

            cb.MoveTo(10, 528);
            cb.LineTo(330, 528);

            cb.MoveTo(10, 498);
            cb.LineTo(330, 498);

            cb.MoveTo(10, 468);
            cb.LineTo(660, 468);

            cb.MoveTo(330, 828);
            cb.LineTo(330, 438);

            cb.MoveTo(10, 438);
            cb.LineTo(660, 438);

            cb.MoveTo(330, 438);
            cb.LineTo(330, 438);

            cb.MoveTo(10, 200);
            cb.LineTo(660, 200);

            cb.MoveTo(10, 170);
            cb.LineTo(330, 170);

            cb.MoveTo(10, 130);
            cb.LineTo(330, 130);

            cb.MoveTo(10, 10);
            cb.LineTo(330, 10);

            cb.MoveTo(330, 200);
            cb.LineTo(330, 10);

            cb.MoveTo(330, 80);
            cb.LineTo(660, 80);

            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Combined Transport BILL OF LADING", 15, 848, 0);
            BaseFont bfheader2 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader2, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Non Negotiable unless consigned 'To order'", 15, 838, 0);
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
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 15, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee(if 'To Order', so indicated)", 15, 718, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Address (No claim shall attach for failure to notify)", 15, 618, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Initial Carriage by", 15, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt", 155, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel/Voyage", 15, 488, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 155, 488, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of discharge", 15, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of delivery", 155, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B/L No", 335, 618, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper Reference No.", 335, 598, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "F.M.C.No.", 485, 598, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "F/Agent Name & Ref", 335, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number of original B/L's", 485, 458, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 10);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FOR DELIVERY APPLY TO:", 335, 568, 0);          
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader6 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader6, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Particulars below declared by Shipper, carrier not responsible for any misdeclaration", 180, 428, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader7 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader7, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marks and Nos", 15, 416, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "No.of Packages and shipp", 150, 416, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Quantity and Description of Goods", 260, 416, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross Weight(kg)", 480, 416, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Cube (m3)", 580, 416, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DETAILS CONTINUED ON ATTACHED SHEET", 260, 220, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PAGE 1 OF 2", 300, 210, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total No. of Containers/Packages", 15, 190, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Type of service", 15, 160, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Signed on behalf of the carrier", 335, 70, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "As agent(s) only", 450, 20, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader8 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader8, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight & charges(indicate whether prepaid or c", 15, 120, 0);
            cb.EndText();

            int ColumnRows = 190;
            int RowsColumn = 0;
            cb.BeginText();
            BaseFont bfheader9 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader9, 6);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);


            string text = @"SHIPPED in a apparent good order and condition.except as noted. market and numbered as above 
number of packages,marks and number and contents(contents and description measurement 
weight quantity and condition quality and value as declared by shipper) as above are considered 
as unknown. In using this Bill of Lading the shipper,consignee, owner or holder expressly accepts 
and agrees to all its stipulations exceptions and conditions whether written,printed stamped or 
otherwise incorporated on both pages as fully as if they were all signed by the shipper,consignee, 
owner or holder.in witness whereof the company has signed original bills of leading as mentioned 
above.all of this tenor and date, one of which Bills of lading bing accomplished the other(s).stand void";
            string[] Arrayterms = Regex.Split(text, char.ConvertFromUtf32(13));
            string[] Addsplit1;

            for (int x = 0; x < Arrayterms.Length; x++)
            {
                Addsplit1 = Arrayterms[x].Split('\n');

                for (int k = 0; k < Addsplit1.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Addsplit1[k].ToString(), 335, ColumnRows, 0);
                    ColumnRows -= 4;
                    RowsColumn++;
                }
            }
            cb.EndText();

            cb.Stroke();
            doc.Close();
            pdfmp.AddFile(FileNamev + ".pdf");



            pdfmp.Execute();
            string str = FileHidpath;
            string mime = pdfpath;
            ViewList.Add(new MyCountry
            {
                seahorseFilename = FileNamev
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
