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
using MimeMapping;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using System.Drawing;


namespace nvocc.Controllers
{
    public class NavioPDF2Controller : Controller
    {
        DocumentManager Manag = new DocumentManager();
        public static class MimeMapping
        {
            internal static string GetMimeMapping(string fileHidpath)
            {
                throw new NotImplementedException();
            }
        }
      
        public IActionResult Index()
        {
            return View();
        }

        
        

        public FileResult BLPrintNew(string id)
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

            //PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            PdfWriter writer = PdfWriter.GetInstance(doc, workStream);
            doc.Open();
            PdfContentByte cb = writer.DirectContent;
            cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);



            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/aquatic.png"));
            png1.SetAbsolutePosition(15, 815);
            png1.ScalePercent(25f);
            doc.Add(png1);

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

            public List<MyCountry> BLPrintPDF1(MyCountry Data)
        {
            string id = "69";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            var pdfpath = Path.Combine("ClientApp//dist//assets//pdfFiles//acl/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            string FileHidpath = "ClientApp//dist//assets//pdfFiles//acl/Multiple-BL.pdf";

            string _FileName = "test";
            var FileNamev = "";
            Random rd = new Random();
            FileNamev += rd.Next(1000).ToString();
            FileNamev += "_" + _FileName;
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath + FileNamev + ".pdf", FileMode.Create));

            //DataTable _dt = GetBkgCustomer(Data.id);

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
            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BILL OF LADING FOR OCEAN TRANSPORT", 335, 838, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "OR MULTI MODALTRANSPORT", 365, 828, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PARTICULARS FURNISHED BY SHIPPER - CARRIER NOT RESPONSIBLE", 200, 550, 0);
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
            cb.SetFontAndSize(bfheader3, 6);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B/L No.", 535, 838, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Booking No", 335, 800, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Export Reference ", 335, 780, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Service Contract ", 335, 760, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Delivery Agent at place of Delivery", 335, 735, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Onward inland routing (Not part of Carriage as defined in clause 1. for account and risk of Merchant)", 335, 670, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt, Applicable only when document used as Multimodal Transport B/L (see clause 1)", 335, 645, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Delivery, Applicable only when document used as Multimodal Transport B/L (see clause 1)", 335, 605, 0);
            cb.EndText();

            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/aquatic.png"));
            png1.SetAbsolutePosition(15, 815);
            png1.ScalePercent(25f);
            doc.Add(png1);

            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 6);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 15, 800, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 806, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee (negotiable if consigned 'to order', or 'to order of' a named person or 'to order of bearer' )", 15, 735, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 706, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Party (see clause 22)", 15, 670, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 606, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel (see clause 1+19)", 15, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 472, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Voyage No.", 205, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 205, 472, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 15, 580, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 438, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Discharge", 205, 580, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 205, 438, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No./Seal No. Kind of Packages; Description of Goods; Marks and Number;", 15, 535, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross Weight", 510, 535, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Measurement", 590, 535, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Above particulars as mentioned by shipper, but without responsibility of or representation by Carrier (see clause 14)", 15, 305, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight & Charges", 15, 285, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rate", 205, 285, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Unit", 297, 285, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Currency", 389, 285, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Prepaid", 481, 285, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Collect", 573, 285, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Carrier's receipt (see clause 1 & 14) Total number of", 15, 205, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Containers or packages received by carrier", 15, 195, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of issue of B/L", 205, 205, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number & Sequence of Original B(s)/L", 15, 165, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Date of issue of B/L", 205, 165, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Declared Value (see clause 7.3)", 15, 125, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipped on Board Date", 205, 125, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Signed for the carrier AQUATIC LINE", 420, 40, 0);
            cb.EndText();



            int ColumnRows1 = 205;
            int RowsColumn1 = 0;

            cb.BeginText();
            BaseFont bfheader8 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader8, 5);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);


            string text = @"SHIPPED as far as ascertained by reasonable means of checking , In apparent good order and condition unless otherwise stated herein, the 
total number or quantity of Containers or other packages or units indicated in the box entitled ' Carrier's always subject to all terms 
and Conditons hereof (INCLUDING ALL THOSE TERMS AND CONDITIONS ON THE REVERSE HEREOF AND THOSE TERMS AND 
CONDITIONS CONTAINED IN THE CARRIER'S APPLICABLE TARIFF) from the place of receipt or the port of loading, whichever is 
applicable, to the Port of Discharge or place of Delivery, whichever is applicable, When the Place of Receipt box has been completed, 
any notation on this Bill of Lading of  'on board' 'loaded on board' or words to like effect, shall be deemed to be on board the means 
of transportation performing the Carriage from the place of Receipt to the Port of Loading, where the bill of lading is non - negotiable, 
the carrier may give delivery of the goods to the named consigned upon reasonable proof of identity and without requiring surrender 
of an original bill of lading, Where the bill of lading is negotiable, the Merchant is obliged to surender one original, duly endorsed, 
in exchange for the Goods. The Camier accepts a duty of reasonable care to check that any such document which the Merchant surrenders as 
a bill of lading is genuine and original. If the Carrier complies with this duty, it will be entitled to deliver the Goods against what 
it reasonable believes to be genuine and original bill of lading, such deliver discharging the Camiers delivery obligations, In accepting 
this bill of lading, any local customer or privileges to the contrary notwithstanding, the Merchant agree to be bound by all Terms and 
Conditions stated herein whether written, printed, stamped or incorporated on the face or reverse side hereof, as tully as is they were 
all signed by the merchant IN WITNESS WHEREOF the number of original Bills of Lading stated on this side have been signed and wherever 
one original Bill of Lading has been surrendered any others shall be void.";

            string[] Arrayterms = Regex.Split(text, char.ConvertFromUtf32(13));
            string[] Addsplit1;

            for (int x = 0; x < Arrayterms.Length; x++)
            {
                Addsplit1 = Arrayterms[x].Split('\n');

                for (int k = 0; k < Addsplit1.Length; k++)
                {

                    cb.ShowTextAligned(Element.ALIGN_JUSTIFIED, Addsplit1[k].ToString(), 335, ColumnRows1, 0);
                    ColumnRows1 -= 4;
                    RowsColumn1++;
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
                aclFilename = FileNamev
            });

            return ViewList;
        }


        public FileResult BLPrintPDF(string id,MyCountry Data)
        {

            id = "25";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            // var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//bss/");
            var pdfpath = Path.Combine("UploadFolder\\");

            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            //string FileHidpath = "ClientApp//src//assets//pdfFiles//bss/Multiple-BL.pdf";
            string FileHidpath = Path.Combine("UploadFolder\\", "Multiple-BL.pdf");
            string _FileName = "test";
            var FileNamev = "";
            Random rd = new Random();
            FileNamev += rd.Next(1000).ToString();
            FileNamev += "_" + _FileName;
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath + FileNamev + ".pdf", FileMode.Create));

            DataTable _dt = GetBkgCustomer(id.ToString());

            doc.Open();

            PdfContentByte cb = writer.DirectContent;
            cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
            int _Xp = 10, _Yp = 785, YDiff = 10;

            BaseFont bfheader = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader, 14);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 300, 820, 0);
            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/bss.png"));
            png1.SetAbsolutePosition(380, 760);
            png1.ScalePercent(77f);
            doc.Add(png1);

            BaseFont Crossbfheader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.SetFontAndSize(Crossbfheader, 90);
            cb.MoveTo(10, 900);
            cb.LineTo(695, 900);


            //cb.MoveTo(10, 836);
            //cb.LineTo(10, 700);

            //Top//
            //cb.MoveTo(10, 836);
            //cb.LineTo(660, 836);
            //Bottom//
            //cb.MoveTo(10, 170);
            //cb.LineTo(660, 170);
            //left//
            //cb.MoveTo(10, 836);
            //cb.LineTo(10, 40);
            //right//      
            //cb.MoveTo(660, 836);
            //cb.LineTo(660, 40);

            //center
            //cb.MoveTo(330, 836);
            //cb.LineTo(330, 506);


            cb.MoveTo(330, 805);
            cb.LineTo(660, 805);
            cb.Stroke();
            cb.BeginText();
            BaseFont bfheader22 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader22, 10);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Combined Transportation Bill Of Lading", 260, 848, 0);
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


            //center
            //cb.MoveTo(345, 835);
            //cb.LineTo(345, 600);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "NON NEGOTIABLE", 320, 848, 0);
            //if (Data.printvalue == "1")
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   D R A F T   ", 320, 840, 0);
            //if (Data.printvalue == "2")
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   FIRST ORIGINAL   ", 320, 840, 0);
            //if (Data.printvalue == "3")
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   SECOND ORIGINAL   ", 320, 840, 0);
            //if (Data.printvalue == "4")
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   THIRD ORIGINAL   ", 320, 840, 405);

            //if (Data.printvalue == "5")
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   SEAWAY BL-NON NEGOTIABLE   ", 320, 840, 0);
            //if (Data.printvalue == "6")
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   EXPRESS RELEASE   ", 320, 840, 0);
            //if (Data.printvalue == "7")
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   SURRENDER BL   ", 320, 840, 0);
            //if (Data.printvalue == "8")
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   RFS 1ST ORIGINAL   ", 320, 840, 0);
            //if (Data.printvalue == "9")
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   RFS 2ND ORIGINAL   ", 320, 840, 0);
            //if (Data.printvalue == "10")
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "  RFS 3RD ORIGINAL    ", 320, 840, 0);
            //if (Data.printvalue == "11")
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "  BACK PAGE    ", 320, 840, 0);


            //Border - Top//




            cb.EndText();
            cb.BeginText();
            BaseFont bfheader26 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader26, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Received By The Carrier the goods as specified in apprent good order and condition ", 336, 745, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "unless otherwise stated,to be transported to such place as agreed,authorised or", 336, 735, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "permitted herein and subject to all the terms and conditon appearing on the front and", 336, 725, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "reverse of this bill of lading to which the merchant agrees by accepting this bill of ", 336, 715, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "lading,any local privilages and customs not withstanding.", 336, 705, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "the particular given above as stated by the shipper and weight ,measure,quantity and ", 336, 695, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "condition,contents and value of the goods are unknown to the carrier.", 336, 685, 0);

            cb.EndText();


            cb.BeginText();

            cb.SetFontAndSize(bfheader2, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PAYMENT VOUCHER", 275, 888, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 15, 820, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee", 15, 743, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 6);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "(negotiable if consigned 'to order' .'to order of' a named person or 'to order of beared')", 70, 743, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Booking Ref No", 335, 825, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 545, 815, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "No of Bills of Lading", 545, 825, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BLNo"].ToString().Trim().ToUpper(), 545, 815, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Party", 15, 668, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt", 15, 566, 0);
            cb.EndText();


            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 552, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port Of Loading", 250, 566, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 250, 552, 0);
            cb.EndText();



            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel", 15, 530, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Voyage No", 150, 530, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port Of Discharge", 250, 530, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port Of Delvery", 345, 530, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "For Delivery of Goods Apply to", 335, 668, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PARTICULAR FURNISHED BY SHIPPER-CARRIER NOT RESPONSIBLE", 200, 497, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No./Seal No Kind of packages; description of goods;marks and number;", 15, 482, 0);
            cb.EndText();


            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number and kind", 200, 482, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "of Packages", 200, 482, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "'SHIPPER'S LOAD,STOW,COUNT,SEAL and WEIGHT'", 290, 467, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "1X40HC FCL/FCL CY/CY CONTAINERS STC:", 290, 455, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Commodity:PHYLON SPORTS SHOE, PVC SLIPPERS,", 290, 435, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "EVA SPORTS SHOES & SANDLE", 290, 425, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Invoice No: EXP003", 290, 405, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DT: 01.08.2022", 390, 405, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SB No: 3282557", 290, 385, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DT: 03.08.2022", 390, 385, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "No of Packages: 389 BOX", 290, 365, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "HS CODE: 64041990, 64029990, 64022090", 290, 345, 0);
            cb.EndText();


            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross Weight", 510, 482, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Measurement", 600, 482, 0);
            cb.EndText();


            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "KGS", 510, 460, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NET WT", 510, 430, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "KGS", 510, 410, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FREIGHT", 510, 390, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["FreightPayment"].ToString(), 550, 390, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "14 DAYS FREE DETENTION AT DESTINATION", 290, 325, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CONTAINER", 15, 305, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TYPE", 100, 305, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SEAL#1", 150, 305, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PACKAGES", 250, 305, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NET WT(KGS)", 310, 305, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "GR WT(KGS)", 380, 305, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CBM", 460, 305, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "HDMU6310284", 15, 290, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "40HC", 100, 290, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0006728", 150, 290, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "389 BOX", 250, 290, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "5896.000", 310, 290, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "6790.000", 380, 290, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 460, 290, 0);
            cb.EndText();


            cb.MoveTo(10, 755);
            cb.LineTo(660, 755);
            //horizontal line2 big
            cb.MoveTo(10, 680);
            cb.LineTo(660, 680);

            //horizontal line3 big
            cb.MoveTo(10, 610);
            cb.LineTo(330, 610);


            //horizontal line4 big
            cb.MoveTo(10, 578);
            cb.LineTo(330, 578);


            //horizontal line5 big
            cb.MoveTo(10, 542);
            cb.LineTo(660, 542);

            cb.MoveTo(10, 506);
            cb.LineTo(660, 506);

            //horizontal line6 big
            cb.MoveTo(10, 492);
            cb.LineTo(660, 492);
            //Center line6 Small
            cb.MoveTo(195, 506);
            cb.LineTo(195, 318);
            cb.MoveTo(280, 506);
            cb.LineTo(280, 318);
            cb.MoveTo(470, 506);
            cb.LineTo(470, 318);
            cb.MoveTo(565, 506);
            cb.LineTo(565, 318);

            cb.MoveTo(10, 318);
            cb.LineTo(660, 318);

            cb.MoveTo(10, 255);
            cb.LineTo(660, 255);
            cb.MoveTo(10, 180);
            cb.LineTo(660, 180);

            //Center line7 
            cb.MoveTo(150, 255);
            cb.LineTo(150, 180);

            cb.MoveTo(230, 255);
            cb.LineTo(230, 180);

            cb.MoveTo(280, 255);
            cb.LineTo(280, 180);

            cb.MoveTo(330, 255);
            cb.LineTo(330, 180);

            cb.MoveTo(425, 255);
            cb.LineTo(425, 180);

            cb.MoveTo(520, 255);
            cb.LineTo(520, 180);

            cb.MoveTo(10, 146);
            cb.LineTo(660, 146);

            cb.MoveTo(190, 200);
            cb.LineTo(190, 164);

            cb.MoveTo(490, 200);
            cb.LineTo(490, 164);

            cb.MoveTo(10, 126);
            cb.LineTo(660, 126);

            cb.MoveTo(10, 70);
            cb.LineTo(660, 70);

            cb.MoveTo(10, 35);
            cb.LineTo(660, 35);

            cb.MoveTo(175, 180);
            cb.LineTo(175, 70);

            cb.MoveTo(330, 180);
            cb.LineTo(330, 126);

            cb.MoveTo(475, 180);
            cb.LineTo(475, 126);

            cb.MoveTo(575, 126);
            cb.LineTo(575, 126);

            cb.MoveTo(90, 146);
            cb.LineTo(90, 126);



            cb.BeginText();


            BaseFont bfheader3 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader3, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            int ColumnRows = 805; int RowsColumn = 0;
            RowsColumn = 0;
            string[] ArrayAddress = Regex.Split(_dt.Rows[0]["Shipper"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["ShipperAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit;

            for (int x = 0; x < ArrayAddress.Length; x++)
            {
                Aaddsplit = ArrayAddress[x].Split('\n');

                for (int k = 0; k < Aaddsplit.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit[k].ToString(), 15, ColumnRows, 0);
                    ColumnRows -= 9;
                    RowsColumn++;
                }
            }

            ColumnRows = 731;
            RowsColumn = 0;
            string[] ArrayAddress1 = Regex.Split(_dt.Rows[0]["Consignee"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["ConsigneeAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit1;

            for (int x = 0; x < ArrayAddress1.Length; x++)
            {
                Aaddsplit1 = ArrayAddress1[x].Split('\n');

                for (int k = 0; k < Aaddsplit1.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit1[k].ToString(), 15, ColumnRows, 0);
                    ColumnRows -= 9;
                    RowsColumn++;
                }
            }

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ANCA INTERNATIONAL LLP", 15, 750, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B - 210A, PHASE - II, NOIDA U.P.INDIA", 15, 741, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ANCA INTERNATIONAL LLP", 15, 732, 0);

            ColumnRows = 656;
            RowsColumn = 0;
            string[] ArrayAddress2 = Regex.Split(_dt.Rows[0]["Notify1"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["Notify1Address"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit2;

            for (int x = 0; x < ArrayAddress2.Length; x++)
            {
                Aaddsplit2 = ArrayAddress2[x].Split('\n');

                for (int k = 0; k < Aaddsplit2.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit2[k].ToString(), 15, ColumnRows, 0);
                    ColumnRows -= 9;
                    RowsColumn++;
                }
            }

            ColumnRows = 658;
            RowsColumn = 0;

            string[] ArrayAddress3 = Regex.Split(_dt.Rows[0]["Agent"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["AgentAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit3;

            for (int x = 0; x < ArrayAddress3.Length; x++)
            {
                Aaddsplit3 = ArrayAddress3[x].Split('\n');

                for (int k = 0; k < Aaddsplit3.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit3[k].ToString(), 335, ColumnRows, 0);
                    ColumnRows -= 9;
                    RowsColumn++;
                }
            }
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ANCA INTERNATIONAL LLP", 345, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B - 210A, PHASE - II, NOIDA U.P.INDIA", 345, 691, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ANCA INTERNATIONAL LLP", 345, 682, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ANCA INTERNATIONAL LLP", 15, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B - 210A, PHASE - II, NOIDA U.P.INDIA", 15, 691, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ANCA INTERNATIONAL LLP", 15, 682, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 586, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 200, 586, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["POL"].ToString().Trim().ToUpper(), 15, 554, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 200, 554, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 345, 554, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 500, 554, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["POL"].ToString().Trim().ToUpper(), 15, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["POD"].ToString().Trim().ToUpper(), 150, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["FPOD"].ToString().Trim().ToUpper(), 345, 518, 0);


            string[] arrayMarks = new string[] { };
            string[] arrayDescription = new string[] { };
            string[] arrayCntrNo = new string[] { };


            List<string> ArrayMarksV = new List<string>();
            arrayMarks = _dt.Rows[0]["Marks"].ToString().Split('\n');
            int intMarkCount = arrayMarks.Length + 7;
            arrayDescription = _dt.Rows[0]["Description"].ToString().Split('\n');


            int RowMx = 467;

            int TotalLine = 0;
            int ColumnCountMrks = 8;


            ColumnCountMrks = arrayMarks.Length;
            TotalLine = 8;
            for (int LineX = 0; LineX < TotalLine; LineX++)
            {
                if (arrayMarks.Length >= LineX + 1)

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayMarks[LineX].ToUpper(), 15, RowMx, 0);
                RowMx -= 10;
            }

            RowMx -= 20;
            int Rowcntr = 410;
            TotalLine = 4;
            DataTable _dtCntr = GetContainerDetails(id.ToString());
            var _dtCntrValues = _dtCntr.Rows[0]["CntrDtls"].ToString().Split('\n');
            int TotalColumnCntr = (_dtCntrValues.Length < TotalLine) ? _dtCntrValues.Length : TotalLine;
            if (_dtCntr.Rows.Count > 0)
            {
                TotalLine = TotalColumnCntr;
                for (int LineX = 0; LineX < TotalLine; LineX++)
                {
                    var arrayCntrNov = SplitByLenght(_dtCntrValues[LineX].ToString(), 30);
                    for (int d = 0; d < arrayCntrNov.Length; d++)
                    {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayCntrNov[d].ToUpper(), 25, RowMx, 0);
                        RowMx -= 10;
                    }
                }
            }



            int RowDec = 467;

            TotalLine = 15;

            for (int LineX = 0; LineX < TotalLine; LineX++)
            {
                if (arrayDescription.Length >= LineX + 1)

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayDescription[LineX].ToUpper(), 290, RowDec, 0);
                RowDec -= 10;
            }

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayMarks.ToString(), 15, 574, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Packages"].ToString().Trim().ToUpper(), 200, 455, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PACKAGES", 200, 467, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayDescription.ToString(), 290, 574, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "01 X 40' FCL CONTAINER ONLY CONTAINING:", 290, 565, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["GRWT"].ToString().Trim().ToUpper() + " " + _dt.Rows[0]["GrsWtType"].ToString().Trim().ToUpper(), 510, 467, 0);
            if (_dt.Rows[0]["NTWT"].ToString().Trim().ToUpper() != "0.000")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["NTWT"].ToString().Trim().ToUpper() + " " + _dt.Rows[0]["NtWtType"].ToString().Trim().ToUpper(), 510, 420, 0);

            if (_dt.Rows[0]["CBM"].ToString().Trim().ToUpper() != "0.000")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["CBM"].ToString().Trim().ToUpper() + " M3", 600, 506, 0);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FREIGHT: " + _dt.Rows[0]["FreightPayment"].ToString(), 285, 340, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total Number of packages or units(in words)", 15, 285, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Details Continued on attached Sheet....", 300, 285, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight and Charges", 15, 245, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Revenue Unit", 155, 245, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Basic", 235, 245, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rate", 285, 245, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Unit", 335, 245, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Currency", 430, 245, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Prepaid", 525, 245, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Collect", 555, 245, 0);

            BaseFont bfheader31 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader31, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Laden on Board Vessel", 15, 170, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["FreightPayment"].ToString(), 15, 158, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number of Original Bill of Lading", 180, 170, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 180, 158, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Bills of Lading Issue", 335, 170, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 335, 158, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Prepaid at", 480, 170, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 480, 158, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Collect At", 580, 170, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 580, 158, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Date", 15, 136, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "At", 95, 136, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 180, 136, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 330, 136, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 480, 136, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 580, 136, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Terms of this bill of lading continued on reverside hereof", 185, 116, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "IN WITNESS WHEREOF the carrier by its agent has signed the number of Bills of lading all out this tenor and", 180, 106, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "date, one of which being accomplished, the other stand void", 180, 96, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Date of Bill of Lading Issue", 15, 60, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "MUMBAI", 15, 45, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "08-Aug-2022", 80, 45, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Signed By", 450, 60, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BSS CONTAINER LINE", 500, 20, 0);



            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["CargoPakage"].ToString(), 150, 294, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FREIGHT AND CHARGES:", 334, 300, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["FreightPayment"].ToString(), 480, 300, 0);
            string nnn = _dt.Rows[0]["FreightPayment"].ToString();




            BaseFont bfheader71 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader71, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipped On Board: " + _dt.Rows[0]["SOBDatev"].ToString(), 15, 90, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SIGNED AT", 334, 100, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DATE OF ISSUE", 580, 100, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BlDatev"].ToString(), 334, 90, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["IssuedAt"].ToString(), 580, 90, 0);




            cb.EndText();
            cb.Stroke();
            doc.Close();
            pdfmp.AddFile(FileNamev + ".pdf");


     
            //int[] arr = { _dt.Rows.Count, arrayDescription.Length, intMarkCount, _dtCntrValues.Length + 10 };
            //int max = arr[0];
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    if (arr[i] > max)
            //        max = arr[i];
            //}

            //int TotalColumn = (_dt.Rows.Count < arrayDescription.Length) ? intMarkCount : intMarkCount;
           
            //int WriteLine = TotalColumn - TotalLine;
            //int AttachedsheetNo = int.Parse(Math.Ceiling((WriteLine / 80.00)).ToString());
            //int Cot = 0;
            //int LineCount = 15 + Cot;
            //int SheetNo = 1;
            //string Filesv = "Attach" + id;
            //string _AttFileName = Filesv;
            //int LIndex = 15;
            //int LMarkindex = 8;
            //int LCntrindex = 4;

            //for (int k = 0; k < AttachedsheetNo; k++)
            //{

            //    Document Attdocument = new Document(rec);
            //    PdfWriter Attwriter = PdfWriter.GetInstance(Attdocument, new FileStream(pdfpath + (_AttFileName + SheetNo) + ".pdf", FileMode.Create));
            //    Attdocument.Open();
            //    PdfContentByte Attcb = Attwriter.DirectContent;
            //    Attcb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);


            //    #region Border
            //    Attcb.MoveTo(15, 825);
            //    Attcb.LineTo(650, 825);
            //    Attcb.MoveTo(15, 805);
            //    Attcb.LineTo(650, 805);

            //    Attcb.Stroke();
            //    #endregion

            //    Attcb.BeginText();
            //    BaseFont bfheader21 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //    Attcb.SetFontAndSize(bfheader21, 8);
            //    Attcb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marks and Nos.", 55, 815, 0);
            //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Containers", 270, 815, 0);
            //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Description of Goods", 450, 815, 0);
            //    int yy = _Yp - YDiff * 6;
            //    int DeffLine = 0;
            //    int deffMark = 0;
            //    int LineX = 0;
            //    int LineMark = 0;
            //    int deffcntr = 0;
            //    int LineCntr = 0;
            //    DeffLine = 0;

            //    BaseFont bfheader23 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //    Attcb.SetFontAndSize(bfheader23, 8);
            //    Attcb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            //    if (LineX <= 70)
            //    {

            //        for (int Lines = LCntrindex; Lines < _dtCntrValues.Length; Lines++)
            //        {
            //            var arrayCntrNov = _dtCntr.Rows[Lines]["CntrDtls"].ToString().Split('\n');
            //            if (_dtCntrValues.Length >= LCntrindex + 1)
            //            {
            //                // var arrayCntrNov = SplitByLenght(_dtCntrValues[LIndex].ToString(), 30);
            //                Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayCntrNov[0].ToUpper(), 230, 780 - deffcntr, 0);
            //                deffcntr += 10;
            //                Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayCntrNov[1].ToUpper(), 230, 780 - deffcntr, 0);
            //                deffcntr += 10;
            //                Cot++;
            //                LineCntr++;
            //                if (LineCntr == 70)
            //                {
            //                    deffcntr += LineCntr - 13;
            //                    break;
            //                }
            //            }
            //        }

            //        for (int Lines = LMarkindex; Lines < arrayMarks.Length; Lines++)
            //        {
            //            if (arrayMarks.Length >= LMarkindex + 1)

            //                Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayMarks[Lines].Replace("#", ""), 20, 780 - deffMark, 0);

            //            deffMark += 10;
            //            Cot++;
            //            LineMark++;
            //            if (LineMark == 70)
            //            {
            //                deffMark += LineMark - 13;
            //                break;
            //            }
            //        }



            //        for (int Lines = LIndex; Lines < arrayDescription.Length; Lines++)
            //        {
            //            if (arrayDescription.Length >= TotalLine + 1)

            //                Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayDescription[Lines].Replace("#", ""), 400, 780 - DeffLine, 0);

            //            DeffLine += 10;
            //            Cot++;
            //            LineX++;
            //            if (LineX == 70)
            //            {
            //                LIndex += LineX - 13;
            //                break;
            //            }
            //        }

            //        int DeferentLine = (DeffLine < deffMark) ? deffcntr : deffcntr;
            //        DataTable _dtns = GetNotes(id.ToString());
            //        if (_dtns.Rows.Count > 0)
            //        {
            //            Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BL CLAUSES", 30, 700 - DeferentLine, 0);
            //            DeferentLine += 20;
            //            var Notes = _dtns.Rows[0]["Notes"].ToString().Split('\n'); ;
            //            for (int t = 0; t < Notes.Length; t++)
            //            {
            //                Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Notes[t].ToString(), 30, 700 - DeferentLine, 0);
            //                DeferentLine += 10;
            //            }
            //        }

            //    }


            //    DeffLine += 10;

            //    int RowColm = 770 - DeffLine;

            //    LineCount += Cot;


            //    Attcb.EndText();
            //    Attcb.Stroke();
            //    Attdocument.Close();


            //    pdfmp.AddFile(_AttFileName + SheetNo + ".pdf");
            //    SheetNo++;
            //}



            pdfmp.Execute();
            string str = FileHidpath;
            string mime = pdfpath;

            ViewList.Add(new MyCountry
            {
                navioFilename = FileNamev
            });



            byte[] pdfBytes = System.IO.File.ReadAllBytes(str);
            MemoryStream ms = new MemoryStream(pdfBytes);
            return  new FileStreamResult(ms, "application/pdf");
        }
//        public List<MyCountry> BLPrintPDF(MyCountry Data)
//        {
//            string id = "69";
//            string printvalue = "1";
//            List<MyCountry> ViewList = new List<MyCountry>();

//            Document doc = new Document();
//            Rectangle rec = new Rectangle(670, 870);
//            doc = new Document(rec);
//            Paragraph para = new Paragraph();
//            var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//aquatic/");
//            MergeEx pdfmp = new MergeEx();
//            pdfmp.SourceFolder = pdfpath;

//            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
//            string FileHidpath = "ClientApp//src//assets//pdfFiles//aquatic/Multiple-BL.pdf";

//            string _FileName = "test";
//            var FileNamev = "";
//            Random rd = new Random();
//            FileNamev += rd.Next(1000).ToString();
//            FileNamev += "_" + _FileName;
//            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath + FileNamev + ".pdf", FileMode.Create));

//            //DataTable _dt = GetBkgCustomer(Data.id);

//            doc.Open();

//            PdfContentByte cb = writer.DirectContent;
//            cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
//            int _Xp = 10, _Yp = 785, YDiff = 10;

//            BaseFont bfheader = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
//            cb.SetFontAndSize(bfheader, 14);
//            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 300, 820, 0);
//            //iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/bss.png"));
//            //png1.SetAbsolutePosition(380, 760);
//            //png1.ScalePercent(77f);
//            //doc.Add(png1);

//            BaseFont Crossbfheader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
//            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
//            cb.SetFontAndSize(Crossbfheader, 90);
            

//            //Center
//            cb.MoveTo(330, 848);
//            cb.LineTo(330, 565);

//            //Line1
//            cb.MoveTo(10, 810);
//            cb.LineTo(660, 810);

//            //Line2
//            cb.MoveTo(10, 745);
//            cb.LineTo(660, 745);

//            //Line3
//            cb.MoveTo(10, 680);
//            cb.LineTo(660, 680);

//            //Line4
//            cb.MoveTo(10, 615);
//            cb.LineTo(660, 615);

//            //Line5
//            cb.MoveTo(10, 565);
//            cb.LineTo(660, 565);

//            //Line6
//            cb.MoveTo(10, 545);
//            cb.LineTo(660, 545);

//            //Line7
//            cb.MoveTo(10, 295);
//            cb.LineTo(660, 295);

//            //Line8
//            cb.MoveTo(10, 215);
//            cb.LineTo(660, 215);

//            ////Line9
//            //cb.MoveTo(10, 95);
//            //cb.LineTo(660, 95);

//            ////Line10
//            //cb.MoveTo(10, 10);
//            //cb.LineTo(660, 10);

//            //HorizontalLine1
//            cb.MoveTo(330, 730);
//            cb.LineTo(660, 730);

//            //HorizontalLine2
//            cb.MoveTo(330, 655);
//            cb.LineTo(660, 655);

//            //HorizontalLine3
//            cb.MoveTo(10, 590);
//            cb.LineTo(330, 590);

//            //HorizontalLine4
//            cb.MoveTo(10, 175);
//            cb.LineTo(330, 175);

//            //HorizontalLine5
//            cb.MoveTo(10, 135);
//            cb.LineTo(330, 135);

//            //HorizontalLine6
//            cb.MoveTo(10, 95);
//            cb.LineTo(330, 95);

//            //HorizontalLine6
//            cb.MoveTo(380, 20);
//            cb.LineTo(610, 20);

//            //VerticalLine1
//            cb.MoveTo(530, 848);
//            cb.LineTo(530, 810);

//            //VerticalLine2
//            cb.MoveTo(440, 745);
//            cb.LineTo(440, 730);

//            //VerticalLine3
//            cb.MoveTo(200, 615);
//            cb.LineTo(200, 565);

//            //VerticalLine4
//            cb.MoveTo(495, 545);
//            cb.LineTo(495, 295);

//            //VerticalLine5
//            cb.MoveTo(575, 545);
//            cb.LineTo(575, 295);

//            //VerticalLine6
//            cb.MoveTo(200, 295);
//            cb.LineTo(200, 95);

//            //VerticalLine7
//            cb.MoveTo(292, 295);
//            cb.LineTo(292, 215);

//            //VerticalLine8
//            cb.MoveTo(384, 295);
//            cb.LineTo(384, 215);

//            //VerticalLine9
//            cb.MoveTo(476, 295);
//            cb.LineTo(476, 215);

//            //VerticalLine10
//            cb.MoveTo(568, 295);
//            cb.LineTo(568, 215);

//            //VerticalLine11
//            cb.MoveTo(330, 215);
//            cb.LineTo(330, 95);




//            cb.Stroke();            
//            cb.BeginText();
//            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
//            cb.SetFontAndSize(bfheader1, 9);
//            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BILL OF LADING FOR OCEAN TRANSPORT", 335, 838, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "OR MULTI MODALTRANSPORT", 365, 828, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PARTICULARS FURNISHED BY SHIPPER - CARRIER NOT RESPONSIBLE", 200, 550, 0);
//            cb.EndText();
//            cb.BeginText();
//            BaseFont bfheader2 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
//            cb.SetFontAndSize(bfheader2, 70);
//            cb.SetColorFill(iTextSharp.text.BaseColor.LIGHT_GRAY);
//            if (printvalue == "1")
//            {
//                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   D R A F T   ", 200, 400, 45);
//            }
//            else
//            {
//                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 100, 200, 45);
//            }

//            if (Data.printvalue == "1")
//                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   D R A F T   ", 320, 840, 0);
//            if (Data.printvalue == "2")
//                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   FIRST ORIGINAL   ", 320, 840, 0);
//            if (Data.printvalue == "3")
//                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   SECOND ORIGINAL   ", 320, 840, 0);
//            if (Data.printvalue == "4")
//                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   THIRD ORIGINAL   ", 320, 840, 405);

//            if (Data.printvalue == "5")
//                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   SEAWAY BL-NON NEGOTIABLE   ", 320, 840, 0);
//            if (Data.printvalue == "6")
//                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   EXPRESS RELEASE   ", 320, 840, 0);
//            if (Data.printvalue == "7")
//                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   SURRENDER BL   ", 320, 840, 0);
//            if (Data.printvalue == "8")
//                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   RFS 1ST ORIGINAL   ", 320, 840, 0);
//            if (Data.printvalue == "9")
//                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   RFS 2ND ORIGINAL   ", 320, 840, 0);
//            if (Data.printvalue == "10")
//                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "  RFS 3RD ORIGINAL    ", 320, 840, 0);
//            if (Data.printvalue == "11")
//                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "  BACK PAGE    ", 320, 840, 0);

//            cb.EndText();
//            cb.BeginText();
//            BaseFont bfheader3 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
//            cb.SetFontAndSize(bfheader3, 6);
//            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B/L No.", 535, 838, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Booking No", 335, 800, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Export Reference ", 335, 780, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Service Contract ", 335, 760, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Delivery Agent at place of Delivery", 335, 735, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Onward inland routing (Not part of Carriage as defined in clause 1. for account and risk of Merchant)", 335, 670, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt, Applicable only when document used as Multimodal Transport B/L (see clause 1)", 335, 645, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Delivery, Applicable only when document used as Multimodal Transport B/L (see clause 1)", 335, 605, 0);
//            cb.EndText();

//            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/aquatic.png"));
//            png1.SetAbsolutePosition(15, 815);
//            png1.ScalePercent(25f);
//            doc.Add(png1);

//            cb.BeginText();
//            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
//            cb.SetFontAndSize(bfheader4, 6);
//            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 15, 800, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 806, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee (negotiable if consigned 'to order', or 'to order of' a named person or 'to order of bearer' )", 15, 735, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 706, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Party (see clause 22)", 15, 670, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 606, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel (see clause 1+19)", 15, 605, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 472, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Voyage No.", 205, 605, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 205, 472, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 15, 580, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 438, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Discharge", 205, 580, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 205, 438, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No./Seal No. Kind of Packages; Description of Goods; Marks and Number;", 15, 535, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross Weight", 510, 535, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Measurement", 590, 535, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Above particulars as mentioned by shipper, but without responsibility of or representation by Carrier (see clause 14)", 15, 305, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight & Charges", 15, 285, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rate", 205, 285, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Unit", 297, 285, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Currency", 389, 285, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Prepaid", 481, 285, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Collect", 573, 285, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Carrier's receipt (see clause 1 & 14) Total number of", 15, 205, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Containers or packages received by carrier", 15, 195, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of issue of B/L", 205, 205, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number & Sequence of Original B(s)/L", 15, 165, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Date of issue of B/L", 205, 165, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Declared Value (see clause 7.3)", 15, 125, 0);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipped on Board Date", 205, 125, 0);
//            cb.EndText();

//            cb.BeginText();
//            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
//            cb.SetFontAndSize(bfheader5, 7);
//            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
//            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Signed for the carrier AQUATIC LINE", 420, 40, 0);
//            cb.EndText();


            
//            int ColumnRows1 = 205;
//            int RowsColumn1 = 0;

//            cb.BeginText();
//            BaseFont bfheader8 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
//            cb.SetFontAndSize(bfheader8, 5);
//            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);


//            string text = @"SHIPPED as far as ascertained by reasonable means of checking , In apparent good order and condition unless otherwise stated herein, the 
//total number or quantity of Containers or other packages or units indicated in the box entitled ' Carrier's always subject to all terms 
//and Conditons hereof (INCLUDING ALL THOSE TERMS AND CONDITIONS ON THE REVERSE HEREOF AND THOSE TERMS AND 
//CONDITIONS CONTAINED IN THE CARRIER'S APPLICABLE TARIFF) from the place of receipt or the port of loading, whichever is 
//applicable, to the Port of Discharge or place of Delivery, whichever is applicable, When the Place of Receipt box has been completed, 
//any notation on this Bill of Lading of  'on board' 'loaded on board' or words to like effect, shall be deemed to be on board the means 
//of transportation performing the Carriage from the place of Receipt to the Port of Loading, where the bill of lading is non - negotiable, 
//the carrier may give delivery of the goods to the named consigned upon reasonable proof of identity and without requiring surrender 
//of an original bill of lading, Where the bill of lading is negotiable, the Merchant is obliged to surender one original, duly endorsed, 
//in exchange for the Goods. The Camier accepts a duty of reasonable care to check that any such document which the Merchant surrenders as 
//a bill of lading is genuine and original. If the Carrier complies with this duty, it will be entitled to deliver the Goods against what 
//it reasonable believes to be genuine and original bill of lading, such deliver discharging the Camiers delivery obligations, In accepting 
//this bill of lading, any local customer or privileges to the contrary notwithstanding, the Merchant agree to be bound by all Terms and 
//Conditions stated herein whether written, printed, stamped or incorporated on the face or reverse side hereof, as tully as is they were 
//all signed by the merchant IN WITNESS WHEREOF the number of original Bills of Lading stated on this side have been signed and wherever 
//one original Bill of Lading has been surrendered any others shall be void.";

//            string[] Arrayterms = Regex.Split(text, char.ConvertFromUtf32(13));
//            string[] Addsplit1;

//            for (int x = 0; x < Arrayterms.Length; x++)
//            {
//                Addsplit1 = Arrayterms[x].Split('\n');

//                for (int k = 0; k < Addsplit1.Length; k++)
//                {

//                    cb.ShowTextAligned(Element.ALIGN_JUSTIFIED, Addsplit1[k].ToString(), 335, ColumnRows1, 0);
//                    ColumnRows1 -= 4;
//                    RowsColumn1++;
//                }
//            }
//            cb.EndText();

//            cb.Stroke();
//            doc.Close();
//            pdfmp.AddFile(FileNamev + ".pdf");



//            pdfmp.Execute();
//            string str = FileHidpath;
//            string mime = pdfpath;
//            ViewList.Add(new MyCountry
//            {
//                aquaticFilename = FileNamev
//            });

//            return ViewList;
//        }

        //public DataTable GetBkgCustomer(MyCountry Data)
        //{
        //    string _Query = " select NVO_BOLNew.ID, " +
        //                    " (select top(1) ShipperName from NVO_PartiesDtls where NVO_PartiesDtls.ShipperType = 1 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID) as ShipperName, " +
        //                    " (select top(1) ShipperAddress from NVO_PartiesDtls where ShipperType = 1 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID) as ShipperAddress, " +
        //                    " (select top(1) Consignee from NVO_PartiesDtls where ConsigneeType = 2 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as Consignee, " +
        //                    " (select top(1) ConsigneeAddress from NVO_PartiesDtls where ConsigneeType = 2 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as ConsigneeAddress, " +
        //                    " (select top(1) Notify from NVO_PartiesDtls where NotifyType = 3 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as Notify, " +
        //                    " (select top(1) NotifyAddress from NVO_PartiesDtls where NotifyType = 3 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as NotifyAddress, " +
        //                    " (select top(1) Notifyalso from NVO_PartiesDtls where NotifyAlsoType = 4 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as Notifyalso, " +
        //                    " (select top(1) NotifyAlsoAddress from NVO_PartiesDtls where NotifyAlsoType = 4 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as NotifyAlsoAddress, " +
        //                    " (select BLNumber from NVO_BL where NVO_BL.ID = NVO_BOLNew.BLID)as BLNumber, " +
        //                    " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PlaceofRecID)as PlaceOfReceipt, " +
        //                    " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PortofLoadID)as PortofLoading, " +
        //                    " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PortofDischargeID)as Discharge, " +
        //                    " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PortofDestinationID)as Destination, " +
        //                    " PaymentTerms,FreightPayableAt,NoOfOriginal,PlaceOfIssue,convert(varchar,BLIssueDate,103)as BLIssueDate, " +
        //                    " (select AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_BOLNew.DeliveryAgent)as DeliveryAgent,DeliveryAgentAddress,MarksNos,Description,Packages,Weight from NVO_BOLNew " +
        //                    " where BLID =" + Data.BLID;
        //    return Manag.GetViewData(_Query, "");
        //}
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
                " (select top(1) (select top(1) PkgDescription from NVO_CargoPkgMaster where NVO_CargoPkgMaster.Id = PakgType) from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID= NVO_BLRelease.BLID) as CargoPakage, * from NVO_BLRelease  where BLID=" + BLID;
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
