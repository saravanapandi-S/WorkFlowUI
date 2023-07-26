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
    public class TarusPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public TarusPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("TarusPrintPDF")]
        public List<MyCountry> BLPrintPDF(MyCountry Data)
        {
            string id = "69";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//tarus/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            string FileHidpath = "ClientApp//src//assets//pdfFiles//tarus/Multiple-BL.pdf";

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
            BaseFont Crossbfheader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.SetFontAndSize(Crossbfheader, 90);
            cb.Stroke();


            cb.BeginText();
            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/taruslines.jpg"));
            png1.SetAbsolutePosition(220, 778);
            png1.ScalePercent(50f);
            doc.Add(png1);
            cb.EndText();

            cb.MoveTo(10, 848);
            cb.LineTo(660, 848);          
            cb.MoveTo(10, 828);
            cb.LineTo(660, 828);
            cb.MoveTo(330, 828);
            cb.LineTo(330, 508);
            cb.MoveTo(10, 808);
            cb.LineTo(330, 808);
            cb.MoveTo(10, 788);
            cb.LineTo(330, 788);
            cb.MoveTo(10, 688);
            cb.LineTo(330, 688);
            cb.MoveTo(10, 668);
            cb.LineTo(330, 668);
            cb.MoveTo(10, 568);
            cb.LineTo(330, 568);
            cb.MoveTo(10, 538);
            cb.LineTo(330, 538);
            cb.MoveTo(10, 508);
            cb.LineTo(660, 508);
            cb.MoveTo(10, 478);
            cb.LineTo(660, 478);

            cb.MoveTo(330, 748);
            cb.LineTo(660, 748);

            cb.MoveTo(330, 648);
            cb.LineTo(660, 648);

            cb.MoveTo(180, 568);
            cb.LineTo(180, 200);
            cb.MoveTo(430, 508);
            cb.LineTo(430, 200);
            cb.MoveTo(580, 508);
            cb.LineTo(580, 200);
            cb.MoveTo(10, 200);
            cb.LineTo(660, 200);
            cb.MoveTo(10, 180);
            cb.LineTo(660, 180);

            cb.MoveTo(330, 180);
            cb.LineTo(330, 10);

            cb.MoveTo(330, 150);
            cb.LineTo(660, 150);

            cb.MoveTo(330, 120);
            cb.LineTo(660, 120);

            cb.MoveTo(330, 90);
            cb.LineTo(660, 90);

            cb.MoveTo(480, 90);
            cb.LineTo(480, 10);

            cb.MoveTo(10, 10);
            cb.LineTo(660, 10);

            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 12);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BILL OF LADING", 280, 830, 0);
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
            BaseFont bfheader6 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader6, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
           
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Tarus Lines Private Limited", 15, 778, 0);
           
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Bill of Lading No.", 15, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Booking No.", 15, 798, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Tarus Lines Private Limited", 15, 778, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "415/416, Creative Industrial Estate", 15, 768, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "N.M. Joshi Marg, Lower Parel(E)", 15, 758, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Mumbai - 400 011", 15, 748, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "91-22-23028900", 15, 738, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "91-22-23028999", 15, 728, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "customerservice@taruslines.com", 15, 718, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Delivery Agent Address", 15, 658, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 15, 558, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Discharge", 185, 558, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 15, 528, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Discharge", 185, 528, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel & Voyage No.", 335, 528, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No.Seal No./& Marks", 15, 498, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Description of Goods & Pkgs", 155, 498, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross Weight", 485, 498, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Measurement", 575, 498, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PARTICULAR FURNISHED BY THE SHIPPER/CONSIGNOR - CARRIER NOT RESPONSE", 155, 190, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Payable at", 335, 170, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number of Original B/L(s)", 335, 140, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place and date of issue", 335, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "As Carrier", 335, 80, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Signed for or on Behalf of the Carrier", 485, 80, 0);
            cb.EndText();


            cb.BeginText();
            BaseFont bfheader7 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader7, 10);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Reg.No : MTO/DGS/1261/FEB/2020", 15, 678, 0);
            cb.EndText();

            

            cb.Stroke();
            doc.Close();
            pdfmp.AddFile(FileNamev + ".pdf");



            pdfmp.Execute();
            string str = FileHidpath;
            string mime = pdfpath;
            ViewList.Add(new MyCountry
            {
                tarusFilename = FileNamev
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
