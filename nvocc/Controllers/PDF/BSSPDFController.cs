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
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Cors;
using Microsoft.Net.Http.Server;
using MimeKit;
using System.Net.Mime;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.Extensions.FileProviders;

namespace nvocc.Controllers
{
    [Route("api/PDF/[controller]")]
    [ApiController]
    //[EnableCors("CORS")]
    public class BSSPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public BSSPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("TestPrintPDF/{id}")]
        [Obsolete]
        public async Task<IActionResult> Download1([FromQuery] int id)
        {
            MemoryStream FinalStream = new MemoryStream();
            PdfCopyFields copy = new PdfCopyFields(FinalStream);
      

            

            MemoryStream workStream = new MemoryStream();
            string strPDFFileName = string.Format("CustomerDetailPdf" + "-" + ".pdf");
            StringBuilder status = new StringBuilder("");
            MergeEx pdfmp = new MergeEx();
            DateTime dTime = DateTime.Now;
            
            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            doc.SetMargins(0, 0, 0, 0);
            PdfPTable tableLayout = new PdfPTable(4);
            doc.SetMargins(10, 10, 10, 0);


            PdfWriter writer = PdfWriter.GetInstance(doc, workStream);
            doc.Open();
            PdfContentByte cb = writer.DirectContent;
            cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);



            //iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/aquatic.png"));
            //png1.SetAbsolutePosition(15, 815);
            //png1.ScalePercent(25f);
            //doc.Add(png1);

            //Center
            cb.MoveTo(330, 848);
            cb.LineTo(330, 565);

            //Line1
            cb.MoveTo(10, 810);
            cb.LineTo(660, 810);

            //Line2
            cb.MoveTo(10, 745);
            cb.LineTo(660, 745);

            //Line3
            cb.MoveTo(10, 680);
            cb.LineTo(660, 680);

            //Line4
            cb.MoveTo(10, 615);
            cb.LineTo(660, 615);

            //Line5
            cb.MoveTo(10, 565);
            cb.LineTo(660, 565);

            //Line6
            cb.MoveTo(10, 545);
            cb.LineTo(660, 545);

            //Line7
            cb.MoveTo(10, 295);
            cb.LineTo(660, 295);

            //Line8
            cb.MoveTo(10, 215);
            cb.LineTo(660, 215);

            ////Line9
            //cb.MoveTo(10, 95);
            //cb.LineTo(660, 95);

            ////Line10
            //cb.MoveTo(10, 10);
            //cb.LineTo(660, 10);

            //HorizontalLine1
            cb.MoveTo(330, 730);
            cb.LineTo(660, 730);

            //HorizontalLine2
            cb.MoveTo(330, 655);
            cb.LineTo(660, 655);

            //HorizontalLine3
            cb.MoveTo(10, 590);
            cb.LineTo(330, 590);

            //HorizontalLine4
            cb.MoveTo(10, 175);
            cb.LineTo(330, 175);

            //HorizontalLine5
            cb.MoveTo(10, 135);
            cb.LineTo(330, 135);

            //HorizontalLine6
            cb.MoveTo(10, 95);
            cb.LineTo(330, 95);

            //HorizontalLine6
            cb.MoveTo(380, 20);
            cb.LineTo(610, 20);

            //VerticalLine1
            cb.MoveTo(530, 848);
            cb.LineTo(530, 810);

            //VerticalLine2
            cb.MoveTo(440, 745);
            cb.LineTo(440, 730);

            //VerticalLine3
            cb.MoveTo(200, 615);
            cb.LineTo(200, 565);

            //VerticalLine4
            cb.MoveTo(495, 545);
            cb.LineTo(495, 295);

            //VerticalLine5
            cb.MoveTo(575, 545);
            cb.LineTo(575, 295);

            //VerticalLine6
            cb.MoveTo(200, 295);
            cb.LineTo(200, 95);

            //VerticalLine7
            cb.MoveTo(292, 295);
            cb.LineTo(292, 215);

            //VerticalLine8
            cb.MoveTo(384, 295);
            cb.LineTo(384, 215);

            //VerticalLine9
            cb.MoveTo(476, 295);
            cb.LineTo(476, 215);

            //VerticalLine10
            cb.MoveTo(568, 295);
            cb.LineTo(568, 215);

            //VerticalLine11
            cb.MoveTo(330, 215);
            cb.LineTo(330, 95);

            cb.Stroke();

            writer.CloseStream = false;
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;
            copy.AddDocument(new PdfReader(workStream));
            
            //return File(workStream, "application/pdf", strPDFFileName);




            MemoryStream workStream1 = new MemoryStream();
            string strPDFFileName1 = string.Format("CustomerDetailPdf" + "-" + ".pdf");
          
            
            Document doc1 = new Document();
            Rectangle rec1 = new Rectangle(670, 870);
            doc1 = new Document(rec1);
            
            doc1.SetMargins(10, 10, 10, 0);


            PdfWriter writer1 = PdfWriter.GetInstance(doc1, workStream1);
            doc1.Open();
            PdfContentByte cb1 = writer1.DirectContent;
            cb1.SetColorStroke(iTextSharp.text.BaseColor.BLACK);



            //iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/aquatic.png"));
            //png1.SetAbsolutePosition(15, 815);
            //png1.ScalePercent(25f);
            //doc.Add(png1);

            //Center
            cb1.MoveTo(330, 848);
            cb1.LineTo(330, 565);

            //Line1
            cb1.MoveTo(10, 810);
            cb1.LineTo(660, 810);

            //Line2
            cb1.MoveTo(10, 745);
            cb1.LineTo(660, 745);

            //Line3
            cb1.MoveTo(10, 680);
            cb1.LineTo(660, 680);

            //Line4
            cb1.MoveTo(10, 615);
            cb1.LineTo(660, 615);

            //Line5
            cb1.MoveTo(10, 565);
            cb1.LineTo(660, 565);

            //Line6
            cb1.MoveTo(10, 545);
            cb1.LineTo(660, 545);

            //Line7
            cb1.MoveTo(10, 295);
            cb1.LineTo(660, 295);

            //Line8
            cb1.MoveTo(10, 215);
            cb1.LineTo(660, 215);


            cb1.Stroke();

            writer1.CloseStream = false;
            doc1.Close();

            byte[] byteInfo1 = workStream1.ToArray();
            workStream1.Write(byteInfo1, 0, byteInfo1.Length);
            workStream1.Position = 0;
            copy.AddDocument(new PdfReader(workStream1));
          
            return File(workStream, "application/pdf", strPDFFileName);


        }


        //[HttpGet("BSSPrintPDF/{id}")]
        //public async Task<IActionResult> GetOrderAsPDF([FromRoute] int id)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    PdfWriter writer = new PdfWriter(ms);
        //    PdfDocument pdf = new PdfDocument(writer);
        //    writer.SetCloseStream(false);
        //    Document document = new Document(pdf);
        //    Paragraph header = new Paragraph("HEADER")
        //       .SetTextAlignment(TextAlignment.CENTER)
        //       .SetFontSize(20);

        //    document.Add(header);
        //    document.Close();
        //    ms.Position = 0;

        //    return File(ms, "application/pdf", "test.pdf");
        //}

        [HttpGet("BSSPrintPDF/{id}")]
        public async Task<IActionResult> Download([FromQuery] int id)
        {


            //MemoryStream workStream = new MemoryStream();
            //StringBuilder status = new StringBuilder("");
            //DateTime dTime = DateTime.Now;
            //string strPDFFileName = string.Format("CustomerDetailPdf" + dTime.ToString("yyyyMMdd") + "-" + ".pdf");
            //Document doc = new Document();
            //Rectangle rec = new Rectangle(670, 870);
            //doc.SetMargins(0, 0, 0, 0);
            //PdfPTable tableLayout = new PdfPTable(4);
            //doc.SetMargins(10, 10, 10, 0);


            //PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            //doc.Open();




            //BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //iTextSharp.text.Font fontInvoice = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.NORMAL);
            //Paragraph paragraph = new Paragraph("Customers Detail", fontInvoice);
            //paragraph.Alignment = Element.ALIGN_CENTER;
            //doc.Add(paragraph);
            //Paragraph p3 = new Paragraph();
            //p3.SpacingAfter = 6;
            //doc.Add(p3);

            //doc.Close();
            //byte[] byteInfo = workStream.ToArray();
            //workStream.Write(byteInfo, 0, byteInfo.Length);
            //workStream.Position = 0;
            //return File(workStream, "application/pdf", strPDFFileName);






            //Document doc = new Document();
            //Rectangle rec = new Rectangle(670, 870);
            //doc = new Document(rec);
            //Paragraph para = new Paragraph();

            //string _FileName = "test";
            //var FileNamev = "";
            //Random rd = new Random();
            //FileNamev += rd.Next(1000).ToString();
            //FileNamev += "_" + _FileName;

            //var filePath = Path.Combine("UploadFolder\\");
            //PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath + FileNamev + ".pdf", FileMode.Create, FileAccess.Write));
            //// DataTable _dt = GetBkgCustomer(id.ToString());

            //doc.Open();

            //PdfContentByte cb = writer.DirectContent;
            //cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
            //int _Xp = 10, _Yp = 785, YDiff = 10;

            //BaseFont bfheader = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //cb.SetFontAndSize(bfheader, 14);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 300, 820, 0);
            //iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/bss.png"));
            //png1.SetAbsolutePosition(380, 760);
            //png1.ScalePercent(77f);
            //doc.Add(png1);

            //BaseFont Crossbfheader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            //cb.SetFontAndSize(Crossbfheader, 90);
            //cb.MoveTo(10, 900);
            //cb.LineTo(695, 900);
            //doc.Close();
            //writer.Close();
            //var filePathv = Path.Combine("UploadFolder", FileNamev + ".pdf");
            //var memory = new MemoryStream();
            //await using (var stream = new FileStream(filePathv, FileMode.Open, FileAccess.Write))
            //{
            //    await stream.CopyToAsync(memory);
            //}
            //memory.Position = 0;

            //return File(memory, GetCntType(filePathv), filePathv);



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
            PdfContentByte cb = writer.DirectContent;
            cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);



            //iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/aquatic.png"));
            //png1.SetAbsolutePosition(15, 815);
            //png1.ScalePercent(25f);
            //doc.Add(png1);

            //Center
            cb.MoveTo(330, 848);
            cb.LineTo(330, 565);

            //Line1
            cb.MoveTo(10, 810);
            cb.LineTo(660, 810);

            //Line2
            cb.MoveTo(10, 745);
            cb.LineTo(660, 745);

            //Line3
            cb.MoveTo(10, 680);
            cb.LineTo(660, 680);

            //Line4
            cb.MoveTo(10, 615);
            cb.LineTo(660, 615);

            //Line5
            cb.MoveTo(10, 565);
            cb.LineTo(660, 565);

            //Line6
            cb.MoveTo(10, 545);
            cb.LineTo(660, 545);

            //Line7
            cb.MoveTo(10, 295);
            cb.LineTo(660, 295);

            //Line8
            cb.MoveTo(10, 215);
            cb.LineTo(660, 215);

            ////Line9
            //cb.MoveTo(10, 95);
            //cb.LineTo(660, 95);

            ////Line10
            //cb.MoveTo(10, 10);
            //cb.LineTo(660, 10);

            //HorizontalLine1
            cb.MoveTo(330, 730);
            cb.LineTo(660, 730);

            //HorizontalLine2
            cb.MoveTo(330, 655);
            cb.LineTo(660, 655);

            //HorizontalLine3
            cb.MoveTo(10, 590);
            cb.LineTo(330, 590);

            //HorizontalLine4
            cb.MoveTo(10, 175);
            cb.LineTo(330, 175);

            //HorizontalLine5
            cb.MoveTo(10, 135);
            cb.LineTo(330, 135);

            //HorizontalLine6
            cb.MoveTo(10, 95);
            cb.LineTo(330, 95);

            //HorizontalLine6
            cb.MoveTo(380, 20);
            cb.LineTo(610, 20);

            //VerticalLine1
            cb.MoveTo(530, 848);
            cb.LineTo(530, 810);

            //VerticalLine2
            cb.MoveTo(440, 745);
            cb.LineTo(440, 730);

            //VerticalLine3
            cb.MoveTo(200, 615);
            cb.LineTo(200, 565);

            //VerticalLine4
            cb.MoveTo(495, 545);
            cb.LineTo(495, 295);

            //VerticalLine5
            cb.MoveTo(575, 545);
            cb.LineTo(575, 295);

            //VerticalLine6
            cb.MoveTo(200, 295);
            cb.LineTo(200, 95);

            //VerticalLine7
            cb.MoveTo(292, 295);
            cb.LineTo(292, 215);

            //VerticalLine8
            cb.MoveTo(384, 295);
            cb.LineTo(384, 215);

            //VerticalLine9
            cb.MoveTo(476, 295);
            cb.LineTo(476, 215);

            //VerticalLine10
            cb.MoveTo(568, 295);
            cb.LineTo(568, 215);

            //VerticalLine11
            cb.MoveTo(330, 215);
            cb.LineTo(330, 95);

            cb.Stroke();

            writer.CloseStream = false;
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;
            return File(workStream, "application/pdf", strPDFFileName);

        }

        private string GetCntType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;

            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";              
            }

            return contentType;
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;

            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
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
                " (select top(1) (select top(1) PkgDescription from NVO_CargoPkgMaster where NVO_CargoPkgMaster.Id = PakgType) from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID= NVO_BLRelease.BLID) as CargoPakage, * from NVO_BLRelease  where BLID=25";
            return Manag.GetViewData(_Query, "");
        }


        public DataTable GetContainerDetails(string BLID)
        {
            string _Query = " Select(select top(1) CntrNo from NVO_Containers where Id = NVO_BOLCntrDetails.CntrID) + '/ ' + size + '/ ' + SealNo + '/ \n/' + convert(varchar, convert(decimal(8, 3), GrsWt)) + ' - ' + (case when GrsWtType = 1 then 'KGS' else 'MT' end) + '/' + convert(varchar, convert(decimal(8, 3), NtWt))  + '- ' + (case when NtWtType = 1 then 'KGS' else 'MT' end) + '/' + convert(varchar, convert(decimal(8, 3), CBM)) + 'CBM' as CntrDtls from NVO_BOLCntrDetails where BLID = 25";

            return Manag.GetViewData(_Query, "");
        }

        public DataTable GetNotes(string BLID)
        {
            string _Query = "select Notes from NVO_BLNotesClauses inner join NVO_BOL on NVO_BOL.PODID=NVO_BLNotesClauses.PortID where Id=25";

            return Manag.GetViewData(_Query, "");
        }

    }
}
