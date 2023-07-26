using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using System.Data;
using System.Web;
using DataManager;
using System.Net;





namespace nvocc.PDFControllers
{

    public class PDFController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public FileResult BLPrintPDF(string id, string printvalue)
        {
            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 900);
            doc = new Document(rec);
            Paragraph para = new Paragraph();


            var pdfpath = Path.Combine("./pdfpath/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            string FileHidpath = "./pdfpath/Multiple-BL.pdf";
            string _FileName = "test";
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath + _FileName + ".pdf", FileMode.Create));

            doc.Open();

            PdfContentByte cb = writer.DirectContent;


            BaseFont bfheader2 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader2, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            //center

            cb.BeginText();
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 15, 815, 0);
            cb.EndText();

            doc.Close();
            pdfmp.AddFile(_FileName + ".pdf");

            //Response.Buffer = true;
            //Response.ContentType = "application/pdf";
            ////Response.AddHeader("content-disposition", "attachment;filename=BLPrintPDF.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            ////Response.Write(doc);
            //Response.End();

            pdfmp.Execute();
            string str = FileHidpath;

            //string mime = (FileHidpath);
            //return File(FileHidpath, mime);
            string mime = pdfpath;
            return File(FileHidpath, mime);
            

        }

    }
}
