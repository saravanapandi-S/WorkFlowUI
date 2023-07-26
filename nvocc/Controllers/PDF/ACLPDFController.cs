
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

namespace nvocc.Controllers
{
    [Route("api/PDF/[controller]")]
    [ApiController]
    public class ACLPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public ACLPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("ACLPrintPDF")]
        public List<MyCountry> BLPrintPDF(MyCountry Data)
        {
            string id = "25";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//acl/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            string FileHidpath = "ClientApp//src//assets//pdfFiles//acl/Multiple-BL.pdf";

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
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 300, 820, 0);
            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/acl.png"));
            png1.SetAbsolutePosition(340, 790);
            png1.ScalePercent(30f);
            doc.Add(png1);

            BaseFont Crossbfheader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.SetFontAndSize(Crossbfheader, 90);
            cb.MoveTo(10, 900);
            cb.LineTo(695, 900);

            //left//
            cb.MoveTo(10, 836);
            cb.LineTo(10, 700);
            //right//  
            //Top//
            cb.MoveTo(10, 836);
            cb.LineTo(660, 836);
            //Bottom//
            //cb.MoveTo(10, 170);
            //cb.LineTo(660, 170);
            //left//
            cb.MoveTo(10, 836);
            cb.LineTo(10, 40);
            //right//      
            cb.MoveTo(660, 836);
            cb.LineTo(660, 40);

            //center
            cb.MoveTo(330, 836);
            cb.LineTo(330, 506);

            cb.MoveTo(500, 836);
            cb.LineTo(500, 810);
            cb.MoveTo(500, 810);
            cb.LineTo(660, 810);
            cb.Stroke();
            cb.BeginText();
            BaseFont bfheader22 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader22, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BILL OF LADING", 15, 848, 0);
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


            //Border-Top//
            
            
           
            
            cb.EndText();
            cb.BeginText();
            BaseFont bfheader25 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader25, 22);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLUE);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Allied Container Line", 336, 740, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader26 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader26, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SHIPPED in apparent good order and condition,Except as noted.Market", 336, 720, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "and numbered as above  of packages, marks number and contents", 336, 710, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "(contents and description measurement weight quantity and condition quality", 336, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "and value as declared by shipper)as above and considered as unknown. In ", 336, 690, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "using this Bill of Lading the shipper consignee, owner or Holder expressly ", 336, 680, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "accepts and agree to all its stipulations and conditions whether written,printed ", 336, 670, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "stamped or otherwise incorporated on both pages as fully if they were all signed ,", 336, 660, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "by the shipper consignee,owner or holder, in witness whereof the company has  ", 336, 650, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "signed original Bills of Lading as mentioned above. All this tenor and date, one of ", 336, 640, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "which Bills of Lading being accomplished the other(s) stand void.", 336, 630, 0);
            cb.EndText();


            cb.BeginText();
           
            cb.SetFontAndSize(bfheader2, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PAYMENT VOUCHER", 275, 888, 0);
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
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B/L No", 505, 820, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BLNo"].ToString().Trim().ToUpper(), 545, 820, 0);
            cb.EndText();

            //cb.BeginText();
            //cb.SetFontAndSize(bfheader2, 8);
            //cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "For Delivery of goods, Please apply to :", 345, 668, 0);
            //cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Party", 15, 668, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Local Vessel", 15, 598, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "From", 200, 598, 0);
            cb.EndText();


            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel/Voyage", 15, 566, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 200, 566, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Flag", 345, 566, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "For Transhipment to(if on carriage)", 500, 566, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port Of Loading", 15, 530, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port Of Discharge", 200, 530, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Final Destination(For the merchant reference only) ", 345, 530, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marks & Numbers", 15, 494, 0);
            cb.EndText();
            

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number and kind", 200, 494, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "of Packages", 200, 487, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Description of Goods", 290, 494, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross Weight", 467, 494, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Kgs.", 467, 487, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Measurement", 580, 494, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "M3", 600, 484, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "KGS", 475, 460, 0);
            cb.EndText();

            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NET WT", 475, 430, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "KGS", 475, 410, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FREIGHT", 475, 390, 0);
            cb.EndText();
            cb.BeginText();
            cb.SetFontAndSize(bfheader2, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["FreightPayment"].ToString(), 525, 390, 0);
            cb.EndText();
            cb.MoveTo(10, 755);
            cb.LineTo(330, 755);
            //horizontal line2 big
            cb.MoveTo(10, 680);
            cb.LineTo(330, 680);

            //horizontal line3 big
            cb.MoveTo(10, 610);
            cb.LineTo(330, 610);


            //horizontal line4 big
            cb.MoveTo(10, 578);
            cb.LineTo(660, 578);


            //horizontal line5 big
            cb.MoveTo(10, 542);
            cb.LineTo(660, 542);

            cb.MoveTo(10, 506);
            cb.LineTo(660, 506);

            //horizontal line6 big
            cb.MoveTo(10, 482);
            cb.LineTo(660, 482);
            //Center line6 Small
            //cb.MoveTo(195, 506);
            //cb.LineTo(195, 318);
            //cb.MoveTo(280, 506);
            //cb.LineTo(280, 318);
            //cb.MoveTo(470, 506);
            //cb.LineTo(470, 318);
            //cb.MoveTo(565, 506);
            //cb.LineTo(565, 318);

            //cb.MoveTo(10, 318);
            //cb.LineTo(660, 318);

            cb.MoveTo(10, 275);
            cb.LineTo(660, 275);
            cb.MoveTo(10, 200);
            cb.LineTo(660, 200);

            ////Center line7 
            cb.MoveTo(230, 275);
            cb.LineTo(230, 200);

            cb.MoveTo(350, 275);
            cb.LineTo(350, 200);

            cb.MoveTo(420, 275);
            cb.LineTo(420, 200);

            cb.MoveTo(455, 275);
            cb.LineTo(455, 200);

            cb.MoveTo(490, 275);
            cb.LineTo(490, 200);

            cb.MoveTo(550, 275);
            cb.LineTo(550, 200);

            cb.MoveTo(10, 164);
            cb.LineTo(660, 164);

            cb.MoveTo(190, 200);
            cb.LineTo(190, 164);

            cb.MoveTo(490, 200);
            cb.LineTo(490, 164);

            cb.MoveTo(10, 128);
            cb.LineTo(660, 128);

            cb.MoveTo(10, 40);
            cb.LineTo(660, 40);

            cb.MoveTo(15, 50);
            cb.LineTo(190, 50);

            cb.MoveTo(350, 60);
            cb.LineTo(650, 60);

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

            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ANCA INTERNATIONAL LLP", 15, 750, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B - 210A, PHASE - II, NOIDA U.P.INDIA", 15, 741, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ANCA INTERNATIONAL LLP", 15, 732, 0);

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

            ColumnRows = 250;
            RowsColumn = 0;

            string[] ArrayAddress3 = Regex.Split(_dt.Rows[0]["Agent"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["AgentAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit3;

            for (int x = 0; x < ArrayAddress3.Length; x++)
            {
                Aaddsplit3 = ArrayAddress3[x].Split('\n');

                for (int k = 0; k < Aaddsplit3.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit3[k].ToString(), 15, ColumnRows, 0);
                    ColumnRows -= 9;
                    RowsColumn++;
                }
            }
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ANCA INTERNATIONAL LLP", 345, 700, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B - 210A, PHASE - II, NOIDA U.P.INDIA", 345, 691, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ANCA INTERNATIONAL LLP", 345, 682, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ANCA INTERNATIONAL LLP", 15, 700, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B - 210A, PHASE - II, NOIDA U.P.INDIA", 15, 691, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ANCA INTERNATIONAL LLP", 15, 682, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 586, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 200, 586, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["POL"].ToString().Trim().ToUpper(), 15, 554, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 200, 554, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 345, 554, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 500, 554, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["POL"].ToString().Trim().ToUpper(), 15, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["POD"].ToString().Trim().ToUpper(), 200, 518, 0);
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

            //RowMx -= 20;
            int Rowcntr = 410;
            TotalLine = 4;
            DataTable _dtCntr = GetContainerDetails(id);
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

            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayMarks.ToString(), 15, 574, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Packages"].ToString().Trim().ToUpper(), 200, 455, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PACKAGES", 200, 467, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayDescription.ToString(), 290, 574, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "01 X 40' FCL CONTAINER ONLY CONTAINING:", 290, 565, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["GRWT"].ToString().Trim().ToUpper() + " " + _dt.Rows[0]["GrsWtType"].ToString().Trim().ToUpper(), 475, 467, 0);
            if (_dt.Rows[0]["NTWT"].ToString().Trim().ToUpper() != "0.000")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["NTWT"].ToString().Trim().ToUpper() + " " + _dt.Rows[0]["NtWtType"].ToString().Trim().ToUpper(), 475, 420, 0);

            if (_dt.Rows[0]["CBM"].ToString().Trim().ToUpper() != "0.000")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["CBM"].ToString().Trim().ToUpper() + " M3", 600, 506, 0);


            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FREIGHT: " + _dt.Rows[0]["FreightPayment"].ToString(), 285, 340, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total Number of packages or units(in words)", 15, 285, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT,"Details Continued on attached Sheet....", 300, 285, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Delivery Agent", 15, 265, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight & Charges Amount", 235, 265, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Revenue tax", 355, 265, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rate", 425, 265, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Per", 460, 265, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Prepaid", 495, 265, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Collect", 555, 265, 0);

            BaseFont bfheader31 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader31, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Prepaid at", 15, 188, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["FreightPayment"].ToString(), 15, 176, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Payable at", 195, 188, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 195, 176, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Issue", 495, 188, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 495, 176, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total Prepaid In", 15, 152, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["FreightPayment"].ToString(), 15, 140, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number of Original BL(s)", 195, 152, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 195, 140, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Date of Issue", 495, 152, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 495, 140, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Laden on board the Vessel", 150, 116, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Date", 15, 76, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "By", 15, 60, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ALLIED CONTAINER LINE", 335, 116, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "By", 350, 80, 0);


            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["CargoPakage"].ToString(), 150, 294, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FREIGHT AND CHARGES:", 334, 300, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["FreightPayment"].ToString(), 480, 300, 0);
            //string nnn = _dt.Rows[0]["FreightPayment"].ToString();




            //BaseFont bfheader71 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //cb.SetFontAndSize(bfheader71, 8);
            //cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipped On Board: " + _dt.Rows[0]["SOBDatev"].ToString(), 15, 90, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SIGNED AT", 334, 100, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DATE OF ISSUE", 580, 100, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BlDatev"].ToString(), 334, 90, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["IssuedAt"].ToString(), 580, 90, 0);




            cb.EndText();
            cb.Stroke();
            doc.Close();
            pdfmp.AddFile(FileNamev + ".pdf");


            //Largest  array number
            int[] arr = { _dt.Rows.Count, arrayDescription.Length, intMarkCount, _dtCntrValues.Length + 10 };
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }

            // int TotalColumn = (_dt.Rows.Count < arrayDescription.Length) ? intMarkCount : intMarkCount;
            //int TotalColumn = max;
            // int TotalColumn = (_dt.Rows.Count < arrayDescription.Length) ? intMarkCount : intMarkCount;
            int TotalColumn = max;
            int WriteLine = TotalColumn - TotalLine;
            int AttachedsheetNo = int.Parse(Math.Ceiling((WriteLine / 80.00)).ToString());
            int Cot = 0;
            int LineCount = 15 + Cot;
            int SheetNo = 1;
            string Filesv = "Attach" + id;
            string _AttFileName = Filesv;
            int LIndex = 15;
            int LMarkindex = 8;
            int LCntrindex = 4;

            for (int k = 0; k < AttachedsheetNo; k++)
            {

                Document Attdocument = new Document(rec);
                PdfWriter Attwriter = PdfWriter.GetInstance(Attdocument, new FileStream(pdfpath + (_AttFileName + SheetNo) + ".pdf", FileMode.Create));
                Attdocument.Open();
                PdfContentByte Attcb = Attwriter.DirectContent;
                Attcb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);


                #region Border
                Attcb.MoveTo(15, 825);
                Attcb.LineTo(650, 825);
                Attcb.MoveTo(15, 805);
                Attcb.LineTo(650, 805);

                Attcb.Stroke();
                #endregion

                Attcb.BeginText();
                BaseFont bfheader21 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Attcb.SetFontAndSize(bfheader21, 8);
                Attcb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
                Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marks and Nos.", 55, 815, 0);
                Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Containers", 270, 815, 0);
                Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Description of Goods", 450, 815, 0);
                int yy = _Yp - YDiff * 6;
                int DeffLine = 0;
                int deffMark = 0;
                int LineX = 0;
                int LineMark = 0;
                int deffcntr = 0;
                int LineCntr = 0;
                DeffLine = 0;

                BaseFont bfheader23 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Attcb.SetFontAndSize(bfheader23, 8);
                Attcb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
                if (LineX <= 70)
                {

                    for (int Lines = LCntrindex; Lines < _dtCntrValues.Length; Lines++)
                    {
                        //var arrayCntrNov = _dtCntr.Rows[Lines]["CntrDtls"].ToString().Split('\n');
                        if (_dtCntrValues.Length >= LCntrindex + 1)
                        {
                            var arrayCntrNov = SplitByLenght(_dtCntrValues[LIndex].ToString(), 30);
                            Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayCntrNov[0].ToUpper(), 230, 780 - deffcntr, 0);
                            deffcntr += 10;
                            Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayCntrNov[1].ToUpper(), 230, 780 - deffcntr, 0);
                            deffcntr += 10;
                            Cot++;
                            LineCntr++;
                            if (LineCntr == 70)
                            {
                                deffcntr += LineCntr - 13;
                                break;
                            }
                        }
                    }

                    for (int Lines = LMarkindex; Lines < arrayMarks.Length; Lines++)
                    {
                        if (arrayMarks.Length >= LMarkindex + 1)

                            Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayMarks[Lines].Replace("#", ""), 20, 780 - deffMark, 0);

                        deffMark += 10;
                        Cot++;
                        LineMark++;
                        if (LineMark == 70)
                        {
                            deffMark += LineMark - 13;
                            break;
                        }
                    }



                    for (int Lines = LIndex; Lines < arrayDescription.Length; Lines++)
                    {
                        if (arrayDescription.Length >= TotalLine + 1)

                            Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayDescription[Lines].Replace("#", ""), 400, 780 - DeffLine, 0);

                        DeffLine += 10;
                        Cot++;
                        LineX++;
                        if (LineX == 70)
                        {
                            LIndex += LineX - 13;
                            break;
                        }
                    }

                    int DeferentLine = (DeffLine < deffMark) ? deffcntr : deffcntr;
                    DataTable _dtns = GetNotes(id);
                    if (_dtns.Rows.Count > 0)
                    {
                        Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BL CLAUSES", 30, 700 - DeferentLine, 0);
                        DeferentLine += 20;
                        var Notes = _dtns.Rows[0]["Notes"].ToString().Split('\n'); ;
                        for (int t = 0; t < Notes.Length; t++)
                        {
                            Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Notes[t].ToString(), 30, 700 - DeferentLine, 0);
                            DeferentLine += 10;
                        }
                    }

                }


                DeffLine += 10;
                
                int RowColm = 770 - DeffLine;

                LineCount += Cot;

                
                Attcb.EndText();
                Attcb.Stroke();
                Attdocument.Close();
                pdfmp.AddFile(_AttFileName + SheetNo + ".pdf");
                SheetNo++;
            }



            pdfmp.Execute();
            string str = FileHidpath;
            string mime = pdfpath;
            ViewList.Add(new MyCountry
            {
                aclFilename = FileNamev
            });



            return ViewList;
        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("download")]
        public async Task<IActionResult> Download([FromQuery] string fileUrl)
        {
            var filePath = Path.Combine("UploadFolder", "BkgDocs", fileUrl);
            // var folderName = Path.Combine("UploadFolder", "BkgDocs");
            // var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), filePath);
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
