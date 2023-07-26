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
    public class MJPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public MJPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("MJPrintPDF")]
        public List<MyCountry> BLPrintPDF(MyCountry Data)
        {
            string id = "69";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//mj/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            string FileHidpath = "ClientApp//src//assets//pdfFiles//mj/Multiple-BL.pdf";

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
            //Top1
            cb.MoveTo(330, 848);
            cb.LineTo(330, 464);

            cb.MoveTo(10, 768);
            cb.LineTo(330, 768);

            cb.MoveTo(10, 688);
            cb.LineTo(330, 688);

            cb.MoveTo(10, 608);
            cb.LineTo(330, 608);

            cb.MoveTo(10, 528);
            cb.LineTo(660, 528);

            cb.MoveTo(10, 496);
            cb.LineTo(330, 496);

            cb.MoveTo(10, 464);
            cb.LineTo(660, 464);

            cb.MoveTo(10, 444);
            cb.LineTo(660, 444);

            cb.MoveTo(10, 220);
            cb.LineTo(660, 220);

            cb.MoveTo(250, 220);
            cb.LineTo(250, 160);

            cb.MoveTo(370, 220);
            cb.LineTo(370, 160);

            cb.MoveTo(470, 220);
            cb.LineTo(470, 160);

            cb.MoveTo(10, 160);
            cb.LineTo(660, 160);

            cb.MoveTo(300, 160);
            cb.LineTo(300, 40);

            cb.MoveTo(180, 160);
            cb.LineTo(180, 40);

            cb.MoveTo(10, 120);
            cb.LineTo(300, 120);
            cb.MoveTo(10, 80);
            cb.LineTo(300, 80);
            cb.MoveTo(10, 40);
            cb.LineTo(300, 40);

            cb.MoveTo(330, 20);
            cb.LineTo(650, 20);

            cb.MoveTo(330, 758);
            cb.LineTo(660, 758);

            cb.MoveTo(330, 714);
            cb.LineTo(460, 714);

            cb.MoveTo(460, 714);
            cb.LineTo(460, 694);

            cb.MoveTo(330,694);
            cb.LineTo(660, 694);

            cb.MoveTo(330, 598);
            cb.LineTo(660, 598);
            cb.MoveTo(330, 578);
            cb.LineTo(660, 578);


            cb.Stroke();
            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/mj.png"));
            png1.SetAbsolutePosition(15, 730);
            png1.ScalePercent(70f);
            doc.Add(png1);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader2 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PARTICULAR FURNISHED BY SHIPPER-CARRIER NOT RESPONSIBLE", 200, 450, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader6 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader6, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 15, 758, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee(negotiable if consigned 'to order' .'to order of' a named person or 'to order of beared')", 15, 678, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Party", 15, 598, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel", 15, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Voyage No", 155, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 15, 486, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Discharge", 155, 486, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BILL OF LADING FOR OCEAN", 335, 828, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TRANSPORT OR MULTIMODAL", 335, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TRANSPORT", 335, 808, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B/l No", 530, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "MNJNSABND2021099", 530, 800, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Booking No", 335, 748, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Export Reference", 335, 736, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Service Contract", 335, 724, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Delivery agent at place of delivery", 335, 704, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "onward inland routing", 335, 588, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt Applicable Only when document used as Multimodel Transport B/L", 335, 568, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NHAVA SHEVA, INDIA", 335, 556, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Delivery Applicable Only when document used as Multimodel Transport B/L", 335, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BANDAR ABBAS", 335, 506, 0);
            cb.EndText();


            cb.BeginText();
            BaseFont bfheader3 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader3, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No./Seal No Kind of packages; description of goods;marks and number;", 15, 434, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SHIPPER'S LOAD,STOW,COUNT,SEAL and WEIGHT'", 230, 420, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross Weight", 500, 434, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Measurement", 590, 434, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BELKRAS/KRASNODAR/RUSSI", 15, 420, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "42", 180, 420, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 310, 420, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "17333.000", 500, 420, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 595, 420, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Details Continued on attached Sheet......", 255, 250, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "above particulars as declared by shipper ,but without responsibility of or representation by Carrier", 15, 230, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rate", 150, 210, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Unit", 255, 210, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Currency", 375, 210, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Prepaid", 475, 210, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Collect", 575, 210, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Carriers receipt Total Number of", 15, 150, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "containers", 15, 140, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 130, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number & Sequence of Original", 15, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Seaway Bill", 15, 100, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Carriers receipt Total Number of", 15, 70, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 60, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "MNJ Shipping LLC", 450, 30, 0);
            cb.EndText();

            int ColumnRows = 150;
            int RowsColumn = 0;
            cb.BeginText();
            BaseFont bfheader8 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader8, 5);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);


            string text = @"Shipped as far as ascertained by reasonable means of checking,in apparant good order and condition unless otherwise stated 
herein,the total number or quantity of container of other packages or units indicated in the box entitled carriers always subject to 
as terms and conditions here of(INCLUDE ALL THOSE TERMS AND CONDITIONS ON THE REVERSE HEREOF AND THOSE 
TERMS AND CONDITIONS CONTAINED IN THE CARRIER APPLICABLE TARIFF)from the place of receipt of the port of 
loading,which ever is applicable, to the port of board loaded on board or words to like effect, shall be deemed to be on board the
means or transportaion performing the carriage from the place of receipt to the port of loading, where the bill of lading is nonnegotiable.
the carrier may give delivery of goods to the named consigned upon reasonable proof of identity and without requiring
surrender of an original bill of lading. where the bill of lading is negotiable.the merchant is obliged to surrender on a original, duly
endorsed , in exchchange for the goods, the carrier accepts a duty of reasonable care to check that any such document which the
merchant surrenders as a bill of lading is genuine and original if the carrier companies with this duly it will be entitled to deliver
the goods against what it reasonable belivers to be a genuine and original bill of lading,such delivery discharging the carrier's 
deliver obligation, in accepting this bill of lading, any local customer privileges to the country notwithstanding, the merchant
 agrees to be bound by all terms and condition stated herein wheather written, printed, stamped or incorporated on the face or
reverse side hereof. as fully as if they were all signed by the merchant, INWITNESS WHEREOF the number of original bills of
lading stated on the side have been signed and whereover one original bill of lading has been surrendered any other shall be void";
            string[] Arrayterms = Regex.Split(text, char.ConvertFromUtf32(13));
            string[] Addsplit1;

            for (int x = 0; x < Arrayterms.Length; x++)
            {
                Addsplit1 = Arrayterms[x].Split('\n');

                for (int k = 0; k < Addsplit1.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Addsplit1[k].ToString(), 305, ColumnRows, 0);
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
                mjFilename = FileNamev
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
