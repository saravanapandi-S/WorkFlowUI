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
using System.Net;
using System.Net.Mail;
using Org.BouncyCastle.Utilities;
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
    [Route("api/[controller]")]
    [ApiController]
    public class ImpArrivalController : ControllerBase
    {

        ImpArrivalManager Manag = new ImpArrivalManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public ImpArrivalController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("ImportArrivalList")]
        public List<MyImpArrival> ImportArrivalList(MyImpArrival Data)
        {
            ImpArrivalManager cm = new ImpArrivalManager();
            List<MyImpArrival> st = cm.GetImportArrivalList(Data);
            return st;
        }

        [HttpPost("SaveArrival")]
        public List<MyImpArrival> SaveArrival(MyImpArrival Data)
        {
            ImpArrivalManager cm = new ImpArrivalManager();
            List<MyImpArrival> st = cm.GetSaveArrival(Data);
            return st;
        }

        [HttpPost("ImpArrivalEdit")]
        public List<MyImpArrival> ImpArrivalEdit(MyImpArrival Data)
        {
            ImpArrivalManager cm = new ImpArrivalManager();
            List<MyImpArrival> st = cm.GetImpArrivalEdit(Data);
            return st;
        }
        [HttpGet, DisableRequestSizeLimit]
        [Route("ArrivalPdfView")]
        public async Task<FileResult> ArrivalPdfView([FromQuery] string BLID)
        {
            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 900);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            DataTable _dt = GetBkgCustomerView(BLID);

            var pdfpath = Path.Combine("UploadFolder/ArrivalPDF");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-" + "BL.pdf";
            string FileHidpath = pdfpath + "Multiple-" + "BL.pdf";
            string _FileName = "test";
            var FileNamev = "";
            Random rd = new Random();
            FileNamev += rd.Next(1000).ToString();
            FileNamev += "_" + _FileName;
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath + FileNamev + ".pdf", FileMode.Create));
            //PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();

            PdfContentByte cb = writer.DirectContent;
            cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
            int _Xp = 10, _Yp = 785, YDiff = 10;


            BaseFont bfheader = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader, 14);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 300, 820, 0);

            //table1

            cb.MoveTo(25, 470);
            cb.LineTo(640, 470);

            cb.MoveTo(25, 450);
            cb.LineTo(640, 450);

            cb.MoveTo(25, 430);
            cb.LineTo(640, 430);

            cb.MoveTo(25, 470);
            cb.LineTo(25, 430);

            cb.MoveTo(175, 470);
            cb.LineTo(175, 430);

            cb.MoveTo(300, 470);
            cb.LineTo(300, 430);

            cb.MoveTo(400, 470);
            cb.LineTo(400, 430);

            cb.MoveTo(500, 470);
            cb.LineTo(500, 430);

            cb.MoveTo(640, 470);
            cb.LineTo(640, 430);

            //table2

            cb.MoveTo(25, 400);
            cb.LineTo(640, 400);

            cb.MoveTo(25, 360);
            cb.LineTo(640, 360);

            cb.MoveTo(25, 340);
            cb.LineTo(640, 340);

            cb.MoveTo(25, 320);
            cb.LineTo(640, 320);

            cb.MoveTo(25, 300);
            cb.LineTo(640, 300);


            cb.MoveTo(25, 400);
            cb.LineTo(25, 360);

            cb.MoveTo(25, 360);
            cb.LineTo(25, 340);

            cb.MoveTo(25, 340);
            cb.LineTo(25, 320);

            cb.MoveTo(25, 320);
            cb.LineTo(25, 300);


            cb.MoveTo(640, 400);
            cb.LineTo(640, 360);


            cb.MoveTo(640, 360);
            cb.LineTo(640, 340);

            cb.MoveTo(640, 340);
            cb.LineTo(640, 320);

            cb.MoveTo(640, 320);
            cb.LineTo(640, 300);
            //1
            cb.MoveTo(150, 400);
            cb.LineTo(150, 360);
            //2
            cb.MoveTo(180, 400);
            cb.LineTo(180, 340);
            //3
            cb.MoveTo(220, 400);
            cb.LineTo(220, 340);

            //4
            cb.MoveTo(250, 400);
            cb.LineTo(250, 340);
            //5
            cb.MoveTo(290, 400);
            cb.LineTo(290, 320);

            //6
            cb.MoveTo(340, 400);
            cb.LineTo(340, 320);
            //7
            cb.MoveTo(390, 400);
            cb.LineTo(390, 320);
            //8
            cb.MoveTo(430, 400);
            cb.LineTo(430, 320);
            //9
            cb.MoveTo(460, 400);
            cb.LineTo(460, 320);

            //10
            cb.MoveTo(560, 400);
            cb.LineTo(560, 300);
            //sub 
            cb.MoveTo(460, 380);
            cb.LineTo(560, 380);

            cb.MoveTo(510, 380);
            cb.LineTo(510, 300);

            cb.Stroke();
            cb.BeginText();
            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("UploadFolder/BLLogos/navio.png"));
            png1.SetAbsolutePosition(25, 800);
            png1.ScalePercent(50f);
            doc.Add(png1);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader3 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader3, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B3106 , 31ST FLOOR , LATIFA TOWER , NEXT TO CROWN PLAZA HOTEL , SHEIKH ZAYED ROAD , DUBAI , UAE , PIN CODE : 117067", 75, 780, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 15);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ARRIVAL NOTICE", 250, 755, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader2 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader2, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Consignee"].ToString(), 25, 730, 0);
            cb.EndText();

            BaseFont bfheaderaddress = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheaderaddress, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            int ColumnRows = 720; int RowsColumn = 0;
            RowsColumn = 0;
            string[] ArrayAddress = Regex.Split(_dt.Rows[0]["ConsigneeAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit;

            for (int x = 0; x < ArrayAddress.Length; x++)
            {
                Aaddsplit = ArrayAddress[x].Split('\n');

                for (int k = 0; k < Aaddsplit.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit[k].ToString(), 25, ColumnRows, 0);
                    ColumnRows -= 9;
                    RowsColumn++;
                }
            }


            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Date", 500, 755, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 550, 755, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Page No", 500, 740, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 550, 740, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Bill of Lading/Loading Date", 25, 650, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 650, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BLNumber"].ToString(), 175, 650, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Origin", 25, 635, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 635, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Origin"].ToString(), 175, 635, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Discharge Port", 25, 620, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 620, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["DischargePort"].ToString(), 175, 620, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee", 25, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Consignee"].ToString(), 175, 605, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marks and Number", 25, 590, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 590, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Marks"].ToString(), 175, 590, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Description ", 25, 565, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 565, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Description"].ToString(), 175, 565, 0);

            cb.EndText();

            int ColumnRow1 = 565; int RowsColumn1 = 0;
            RowsColumn1 = 0;
            string[] ArrayAddress1 = Regex.Split(_dt.Rows[0]["Description"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit1;

            for (int x = 0; x < ArrayAddress1.Length; x++)
            {
                Aaddsplit1 = ArrayAddress1[x].Split('\n');

                for (int k = 0; k < Aaddsplit1.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit1[k].ToString(), 175, ColumnRow1, 0);
                    ColumnRow1 -= 9;
                    RowsColumn1++;
                }
            }

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel/Voy", 370, 650, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 650, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["VesselName"].ToString() + "\r" + _dt.Rows[0]["VoyageNo"].ToString(), 480, 650, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Destination", 370, 635, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 635, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Destination"].ToString(), 480, 635, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ETA Date", 370, 620, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 620, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Line", 370, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Line"].ToString(), 480, 605, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "IGM No.Date", 370, 590, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 590, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Item No ", 370, 575, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 575, 0);


            cb.EndText();

            cb.BeginText();
            BaseFont bfheader6 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader6, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "You are hereby notified that the below consignment is expected to arrived ", 25, 490, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Destination"].ToString() + " per " + _dt.Rows[0]["VesselName"].ToString() + "\r" + _dt.Rows[0]["VoyageNo"].ToString(), 325, 490, 0);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "The Item No is ", 25, 480, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 85, 480, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader7 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader7, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Following charges are applicable to obtain delivery of your cargo:", 25, 405, 0);
            cb.EndText();


            cb.BeginText();
            BaseFont bfheader8 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader8, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Conditions:", 25, 290, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Contact on TDR DXB GENIO tdr.dxb@genioshipping.com", 25, 275, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Tel: +9714 3380007 | Fax : +9714 338001", 25, 260, 0);
            cb.EndText();

            //table 1
            cb.BeginText();
            BaseFont bfheader9 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader9, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No.", 30, 460, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container Size", 180, 460, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container Status", 305, 460, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "No of Packages", 405, 460, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Weight", 505, 460, 0);
            cb.EndText();


            //table 2
            cb.BeginText();
            BaseFont bfheader10 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader10, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Particulars", 30, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Qty", 155, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rate", 185, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Curr", 225, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ExchRt", 255, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FC Amt", 295, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Taxable", 395, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Value", 395, 370, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "VAT", 435, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Group", 435, 370, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "VAT", 495, 390, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rate", 470, 370, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Amount", 520, 370, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total", 575, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Amount", 575, 370, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total:", 260, 330, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Grand Total", 460, 310, 0);

            cb.EndText();

            doc.Close();
            writer.Close();
            pdfmp.AddFile(FileNamev + ".pdf");
            pdfmp.Execute();
            string str = FileHidpath;
            WebClient client = new WebClient();
            byte[] thePdf = client.DownloadData(FileHidpath);
            return File(thePdf, "application/pdf");
        }
            [HttpPost("ArrivalEmailSend")]
        public List<MyImpArrival> ArrivalEmailSend(MyImpArrival Data)
        {
            List<MyImpArrival> ViewList = new List<MyImpArrival>();
            DataTable dtv = GetArrivalEmailSendValues(Data);
            if (dtv.Rows.Count > 0)
            {
                string strHTML = "";
                strHTML += "<table border='0' cellpadding='0' cellspacing='0' width='70%' style='font-family:Arial;'>";
                strHTML += "<tbody>";
                strHTML += "<tr>";
                strHTML += "<td style='border:none!important;'>";
                strHTML += "<table cellpadding='0' cellspacing='0' width='100%'>";

                strHTML += "<tr>";
                strHTML += "<td>";
                strHTML += "<table style='width:100%;' border='0'>";
                strHTML += "<tr>";
                strHTML += "<td style='color:#535353;font-weight:600; padding-bottom:16px;'>Vessel</td>";
                strHTML += "<td style='padding-bottom:16px;'>" + dtv.Rows[0]["VesselName"].ToString() + "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style='color:#535353;font-weight:600; padding-bottom:16px;'>VoyageNo</td>";
                strHTML += "<td style='padding-bottom:16px;'>" + dtv.Rows[0]["VoyageNo"].ToString() + "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style ='color:#535353;font-weight:600;padding-bottom:16px;'> Sailed From </td>";
                strHTML += "<td style = 'padding-bottom:16px;' > " + dtv.Rows[0]["ETD"].ToString() + "</td>";
                strHTML += "</tr>";
                strHTML += "<tr>";
                strHTML += "<td style ='color:#535353;font-weight:600;padding-bottom:16px;'> Sailed On </td>";
                strHTML += "<td style ='padding-bottom:16px;'> " + dtv.Rows[0]["ATD"].ToString() + "</td>";
                strHTML += "</tr> ";
                strHTML += "<tr>";
                strHTML += "<td style ='color:#535353;font-weight:600;padding-bottom:16px;'> BOL Ref </td>";
                strHTML += "<td style ='padding-bottom:16px;'> " + dtv.Rows[0]["BLNumber"].ToString() + "</td>";
                strHTML += "</tr> ";
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";

                strHTML += "</table>";

                strHTML += "<tr>";
                strHTML += "<td style='padding-bottom:17px;padding-top:17px'>Thank You for serving your shipment through NAVIO SHIPPING PRIVATE LIMITED.</td>";
                strHTML += "</tr>";

                strHTML += "<tr>";
                strHTML += "<td style='padding-bottom:17px;'>Best Regards</td>";
                strHTML += "</tr>";

                strHTML += "<tr>";
                strHTML += "<td>";
                strHTML += "<table style='width:100%;' border='0'>";
                strHTML += "<tr>";
                strHTML += "<td style ='font-weight:600;padding-bottom:16px;'>Note:</td>";
                strHTML += "<td style ='padding-bottom:16px;'>This is a System generated e-mail. Please do not respond to this e-mail.</td>";
                strHTML += "</tr> ";
                strHTML += "</table>";
                strHTML += "</td>";
                strHTML += "</tr>";

                strHTML += "</td>";
                strHTML += "</tr>";

                strHTML += "</tbody>";
                strHTML += "</table>";



                MailMessage EmailObject = new MailMessage();
                EmailObject.From = new MailAddress("info@odaksolutions.com", "Info Odak");
                //var EmailTo = Data.EmailTo.Split(',');
                //for (int y = 0; y < EmailTo.Length; y++)
                //{
                //    if (EmailTo[y].ToString() != "")
                //    {
                //        EmailObject.To.Add(new MailAddress(EmailTo[y].ToString()));
                //    }
                //}
                //var EmailCC = Data.EmailCC.Split(',');
                //for (int y = 0; y < EmailCC.Length; y++)
                //{
                //    if (EmailCC[y].ToString() != "")
                //    {
                //        EmailObject.CC.Add(new MailAddress(EmailCC[y].ToString()));
                //    }
                //}
                //var EmailBcc = Data.EmailBcc.Split(',');
                //for (int y = 0; y < EmailBcc.Length; y++)
                //{
                //    if (EmailBcc[y].ToString() != "")
                //    {
                //        EmailObject.Bcc.Add(new MailAddress(EmailBcc[y].ToString()));
                //    }
                //}


                Document doc = new Document();
                Rectangle rec = new Rectangle(670, 900);
                doc = new Document(rec);
                Paragraph para = new Paragraph();
                DataTable _dt = GetBkgCustomer(Data);

                var pdfpath = Path.Combine("UploadFolder/ArrivalPDF");
                MergeEx pdfmp = new MergeEx();
                pdfmp.SourceFolder = pdfpath;

                pdfmp.DestinationFile = pdfpath + "Multiple-" + "BL.pdf";
                string FileHidpath = pdfpath + "Multiple-" + "BL.pdf";
                string _FileName = "test";
                var FileNamev = "";
                Random rd = new Random();
                FileNamev += rd.Next(1000).ToString();
                FileNamev += "_" + _FileName;
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath + FileNamev + ".pdf", FileMode.Create));
                //PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                doc.Open();

                PdfContentByte cb = writer.DirectContent;
                cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
                int _Xp = 10, _Yp = 785, YDiff = 10;


                BaseFont bfheader = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheader, 14);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 300, 820, 0);

                //table1

                cb.MoveTo(25, 470);
                cb.LineTo(640, 470);

                cb.MoveTo(25, 450);
                cb.LineTo(640, 450);

                cb.MoveTo(25, 430);
                cb.LineTo(640, 430);

                cb.MoveTo(25, 470);
                cb.LineTo(25, 430);

                cb.MoveTo(175, 470);
                cb.LineTo(175, 430);

                cb.MoveTo(300, 470);
                cb.LineTo(300, 430);

                cb.MoveTo(400, 470);
                cb.LineTo(400, 430);

                cb.MoveTo(500, 470);
                cb.LineTo(500, 430);

                cb.MoveTo(640, 470);
                cb.LineTo(640, 430);

                //table2

                cb.MoveTo(25, 400);
                cb.LineTo(640, 400);

                cb.MoveTo(25, 360);
                cb.LineTo(640, 360);

                cb.MoveTo(25, 340);
                cb.LineTo(640, 340);

                cb.MoveTo(25, 320);
                cb.LineTo(640, 320);

                cb.MoveTo(25, 300);
                cb.LineTo(640, 300);


                cb.MoveTo(25, 400);
                cb.LineTo(25, 360);

                cb.MoveTo(25, 360);
                cb.LineTo(25, 340);

                cb.MoveTo(25, 340);
                cb.LineTo(25, 320);

                cb.MoveTo(25, 320);
                cb.LineTo(25, 300);


                cb.MoveTo(640, 400);
                cb.LineTo(640, 360);


                cb.MoveTo(640, 360);
                cb.LineTo(640, 340);

                cb.MoveTo(640, 340);
                cb.LineTo(640, 320);

                cb.MoveTo(640, 320);
                cb.LineTo(640, 300);
                //1
                cb.MoveTo(150, 400);
                cb.LineTo(150, 360);
                //2
                cb.MoveTo(180, 400);
                cb.LineTo(180, 340);
                //3
                cb.MoveTo(220, 400);
                cb.LineTo(220, 340);

                //4
                cb.MoveTo(250, 400);
                cb.LineTo(250, 340);
                //5
                cb.MoveTo(290, 400);
                cb.LineTo(290, 320);

                //6
                cb.MoveTo(340, 400);
                cb.LineTo(340, 320);
                //7
                cb.MoveTo(390, 400);
                cb.LineTo(390, 320);
                //8
                cb.MoveTo(430, 400);
                cb.LineTo(430, 320);
                //9
                cb.MoveTo(460, 400);
                cb.LineTo(460, 320);

                //10
                cb.MoveTo(560, 400);
                cb.LineTo(560, 300);
                //sub 
                cb.MoveTo(460, 380);
                cb.LineTo(560, 380);

                cb.MoveTo(510, 380);
                cb.LineTo(510, 300);

                cb.Stroke();
                cb.BeginText();
                iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("UploadFolder/BLLogos/navio.png"));
                png1.SetAbsolutePosition(25, 800);
                png1.ScalePercent(50f);
                doc.Add(png1);
                cb.EndText();

                cb.BeginText();
                BaseFont bfheader3 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheader3, 7);
                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B3106 , 31ST FLOOR , LATIFA TOWER , NEXT TO CROWN PLAZA HOTEL , SHEIKH ZAYED ROAD , DUBAI , UAE , PIN CODE : 117067", 75, 780, 0);
                cb.EndText();

                cb.BeginText();
                BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheader1, 15);
                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ARRIVAL NOTICE", 250, 755, 0);
                cb.EndText();

                cb.BeginText();
                BaseFont bfheader2 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheader2, 9);
                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Consignee"].ToString(), 25, 730, 0);
                cb.EndText();

                BaseFont bfheaderaddress = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheaderaddress, 8);
                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

                int ColumnRows = 720; int RowsColumn = 0;
                RowsColumn = 0;
                string[] ArrayAddress = Regex.Split(_dt.Rows[0]["ConsigneeAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
                string[] Aaddsplit;

                for (int x = 0; x < ArrayAddress.Length; x++)
                {
                    Aaddsplit = ArrayAddress[x].Split('\n');

                    for (int k = 0; k < Aaddsplit.Length; k++)
                    {

                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit[k].ToString(), 25, ColumnRows, 0);
                        ColumnRows -= 9;
                        RowsColumn++;
                    }
                }


                cb.BeginText();
                BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheader4, 8);
                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Date", 500, 755, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 550, 755, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Page No", 500, 740, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 550, 740, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Bill of Lading/Loading Date", 25, 650, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 650, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BLNumber"].ToString(), 175, 650, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Origin", 25, 635, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 635, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Origin"].ToString(), 175, 635, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Discharge Port", 25, 620, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 620, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["DischargePort"].ToString(), 175, 620, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee", 25, 605, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 605, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Consignee"].ToString(), 175, 605, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marks and Number", 25, 590, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 590, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Marks"].ToString(), 175, 590, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Description ", 25, 565, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 565, 0);
                //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Description"].ToString(), 175, 565, 0);

                cb.EndText();

                int ColumnRow1 = 565; int RowsColumn1 = 0;
                RowsColumn1 = 0;
                string[] ArrayAddress1 = Regex.Split(_dt.Rows[0]["Description"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
                string[] Aaddsplit1;

                for (int x = 0; x < ArrayAddress1.Length; x++)
                {
                    Aaddsplit1 = ArrayAddress1[x].Split('\n');

                    for (int k = 0; k < Aaddsplit1.Length; k++)
                    {

                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit1[k].ToString(), 175, ColumnRow1, 0);
                        ColumnRow1 -= 9;
                        RowsColumn1++;
                    }
                }

                cb.BeginText();
                BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheader5, 8);
                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel/Voy", 370, 650, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 650, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["VesselName"].ToString() + "\r" + _dt.Rows[0]["VoyageNo"].ToString(), 480, 650, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Destination", 370, 635, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 635, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Destination"].ToString(), 480, 635, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ETA Date", 370, 620, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 620, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Line", 370, 605, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 605, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Line"].ToString(), 480, 605, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "IGM No.Date", 370, 590, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 590, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Item No ", 370, 575, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 575, 0);


                cb.EndText();

                cb.BeginText();
                BaseFont bfheader6 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheader6, 9);
                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "You are hereby notified that the below consignment is expected to arrived ", 25, 490, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Destination"].ToString() + " per " + _dt.Rows[0]["VesselName"].ToString() + "\r" + _dt.Rows[0]["VoyageNo"].ToString(), 325, 490, 0);


                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "The Item No is ", 25, 480, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 85, 480, 0);
                cb.EndText();

                cb.BeginText();
                BaseFont bfheader7 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheader7, 7);
                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Following charges are applicable to obtain delivery of your cargo:", 25, 405, 0);
                cb.EndText();


                cb.BeginText();
                BaseFont bfheader8 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheader8, 9);
                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Conditions:", 25, 290, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Contact on TDR DXB GENIO tdr.dxb@genioshipping.com", 25, 275, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Tel: +9714 3380007 | Fax : +9714 338001", 25, 260, 0);
                cb.EndText();

                //table 1
                cb.BeginText();
                BaseFont bfheader9 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheader9, 8);
                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No.", 30, 460, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container Size", 180, 460, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container Status", 305, 460, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "No of Packages", 405, 460, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Weight", 505, 460, 0);
                cb.EndText();


                //table 2
                cb.BeginText();
                BaseFont bfheader10 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheader10, 8);
                cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Particulars", 30, 380, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Qty", 155, 380, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rate", 185, 380, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Curr", 225, 380, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ExchRt", 255, 380, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FC Amt", 295, 380, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Taxable", 395, 380, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Value", 395, 370, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "VAT", 435, 380, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Group", 435, 370, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "VAT", 495, 390, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rate", 470, 370, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Amount", 520, 370, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total", 575, 380, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Amount", 575, 370, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total:", 260, 330, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Grand Total", 460, 310, 0);

                cb.EndText();

                doc.Close();
                writer.Close();
                pdfmp.AddFile(FileNamev + ".pdf");
                pdfmp.Execute();
                string str = FileHidpath;
                WebClient client = new WebClient();
                byte[] thePdf = client.DownloadData(FileHidpath);

                // EmailObject.To.Add(new MailAddress("anand@odaksolutions.com"));
                EmailObject.To.Add(new MailAddress("udayakumarkoliking99@gmail.com"));
                // EmailObject.To.Add(new MailAddress(Data.ShipperEmail));
                // EmailObject.To.Add(new MailAddress(Data.ConsigneeEmail));              
                EmailObject.Subject = "Arrival Notice Mail" + " - " + dtv.Rows[0]["VesselName"].ToString() + " & " + dtv.Rows[0]["VoyageNo"].ToString().ToUpper();
                //EmailObject.Subject = "Customer OnBoard Confirmation Mail";
                EmailObject.Body = strHTML;
                EmailObject.Attachments.Add(new Attachment(Path.Combine("UploadFolder/ArrivalPDF" + FileNamev + ".pdf")));
                EmailObject.IsBodyHtml = true;
                EmailObject.Priority = MailPriority.Normal;
                SmtpClient SMTPServer = new SmtpClient();
                SMTPServer.UseDefaultCredentials = false;
                SMTPServer.Credentials = new NetworkCredential("info@odaksolutions.com", "Focus$321");
                SMTPServer.Port = 587;
                SMTPServer.Host = "smtp.office365.com";
                SMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SMTPServer.EnableSsl = true;
                SMTPServer.Send(EmailObject);

            }

            ViewList.Add(new MyImpArrival
            {
                AlertMessage = "Email sent successfully"

            });

            return ViewList;

        }

        public DataTable GetArrivalEmailSendValues(MyImpArrival Data)
        {


            string _Query = " select BLNumber,ShipperEmail,ConsigneeEmail,NotifyEmail,Notify2Email,(select top(1) VesselName from NVO_VesselMaster  where ID =Nvo_ImpBL.VesselID) as VesselName," +
                            " (select top(1) VoyageNo from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) as VoyageNo," +
                            " (select top(1) convert(varchar, ETD, 106) from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) as ETD," +
                            " (select top(1) convert(varchar, ATD, 113) from NVO_Voyage where ID = Nvo_ImpBL.VoyageID) as ATD" +
                            " from Nvo_ImpBL  where ID =" + Data.BLID;

            return Manag.GetViewData(_Query, "");
        }

        public DataTable GetBkgCustomer(MyImpArrival Data)
        {

            string _Query = "select BLNumber,(select(PortCode + '-' + PortName) from NVO_PortMaster where NVO_PortMaster.ID = Nvo_ImpBL.POOID) as Origin, " +
                            " (select(PortCode + '-' + PortName) from NVO_PortMaster where NVO_PortMaster.ID = Nvo_ImpBL.PODID) as DischargePort, " +
                            " (select(PortCode + '-' + PortName) from NVO_PortMaster where NVO_PortMaster.ID = Nvo_ImpBL.FPODID) as Destination,Consignee, " +
                            " (select VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = Nvo_ImpBL.VesselID) as VesselName, " +
                            " (select VoyageNo from NVO_Voyage where NVO_Voyage.ID = Nvo_ImpBL.VoyageID) as VoyageNo,Marks,Description,ConsigneeAddress, " +
                            " (select LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = Nvo_ImpBL.PrincipalID) as Line " +
                            " from Nvo_ImpBL where ID=" + Data.BLID;


            return Manag.GetViewData(_Query, "");
        }

        public DataTable GetBkgCustomerView(string BLID)
        {

            string _Query = "select BLNumber,(select(PortCode + '-' + PortName) from NVO_PortMaster where NVO_PortMaster.ID = Nvo_ImpBL.POOID) as Origin, " +
                            " (select(PortCode + '-' + PortName) from NVO_PortMaster where NVO_PortMaster.ID = Nvo_ImpBL.PODID) as DischargePort, " +
                            " (select(PortCode + '-' + PortName) from NVO_PortMaster where NVO_PortMaster.ID = Nvo_ImpBL.FPODID) as Destination,Consignee, " +
                            " (select VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = Nvo_ImpBL.VesselID) as VesselName, " +
                            " (select VoyageNo from NVO_Voyage where NVO_Voyage.ID = Nvo_ImpBL.VoyageID) as VoyageNo,Marks,Description,ConsigneeAddress, " +
                            " (select LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = Nvo_ImpBL.PrincipalID) as Line " +
                            " from Nvo_ImpBL where ID=" + BLID;


            return Manag.GetViewData(_Query, "");
        }


        [HttpGet, DisableRequestSizeLimit]
        [Route("ArrivalPdf")]
        public async Task<FileResult> ArrivalPdf([FromQuery] string BLID)

        {
            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 900);
            doc = new Document(rec);
            Paragraph para = new Paragraph();

            DataTable _dt = GetArrivalPdf(BLID);
            var pdfpath = Path.Combine("UploadFolder/ArrivalPDF/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + BLID + ".pdf";
            string FileHidpath = pdfpath + BLID + ".pdf";
            string MergePdf = BLID + ".pdf";
            string _FileName = "test";
            var FileNamev = "";
            Random rd = new Random();
            FileNamev += rd.Next(1000).ToString();
            FileNamev += "_" + _FileName;
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath + FileNamev + ".pdf", FileMode.Create));
            //PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();

            PdfContentByte cb = writer.DirectContent;
            cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
            int _Xp = 10, _Yp = 785, YDiff = 10;


            BaseFont bfheader = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader, 14);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 300, 820, 0);

            //table1

            cb.MoveTo(25, 470);
            cb.LineTo(640, 470);

            cb.MoveTo(25, 450);
            cb.LineTo(640, 450);

            cb.MoveTo(25, 430);
            cb.LineTo(640, 430);

            cb.MoveTo(25, 470);
            cb.LineTo(25, 430);

            cb.MoveTo(175, 470);
            cb.LineTo(175, 430);

            cb.MoveTo(300, 470);
            cb.LineTo(300, 430);

            cb.MoveTo(400, 470);
            cb.LineTo(400, 430);

            cb.MoveTo(500, 470);
            cb.LineTo(500, 430);

            cb.MoveTo(640, 470);
            cb.LineTo(640, 430);

            //table2

            cb.MoveTo(25, 400);
            cb.LineTo(640, 400);

            cb.MoveTo(25, 360);
            cb.LineTo(640, 360);

            cb.MoveTo(25, 340);
            cb.LineTo(640, 340);

            cb.MoveTo(25, 320);
            cb.LineTo(640, 320);

            cb.MoveTo(25, 300);
            cb.LineTo(640, 300);


            cb.MoveTo(25, 400);
            cb.LineTo(25, 360);

            cb.MoveTo(25, 360);
            cb.LineTo(25, 340);

            cb.MoveTo(25, 340);
            cb.LineTo(25, 320);

            cb.MoveTo(25, 320);
            cb.LineTo(25, 300);


            cb.MoveTo(640, 400);
            cb.LineTo(640, 360);


            cb.MoveTo(640, 360);
            cb.LineTo(640, 340);

            cb.MoveTo(640, 340);
            cb.LineTo(640, 320);

            cb.MoveTo(640, 320);
            cb.LineTo(640, 300);
            //1
            cb.MoveTo(150, 400);
            cb.LineTo(150, 360);
            //2
            cb.MoveTo(180, 400);
            cb.LineTo(180, 340);
            //3
            cb.MoveTo(220, 400);
            cb.LineTo(220, 340);

            //4
            cb.MoveTo(250, 400);
            cb.LineTo(250, 340);
            //5
            cb.MoveTo(290, 400);
            cb.LineTo(290, 320);

            //6
            cb.MoveTo(340, 400);
            cb.LineTo(340, 320);
            //7
            cb.MoveTo(390, 400);
            cb.LineTo(390, 320);
            //8
            cb.MoveTo(430, 400);
            cb.LineTo(430, 320);
            //9
            cb.MoveTo(460, 400);
            cb.LineTo(460, 320);

            //10
            cb.MoveTo(560, 400);
            cb.LineTo(560, 300);
            //sub 
            cb.MoveTo(460, 380);
            cb.LineTo(560, 380);

            cb.MoveTo(510, 380);
            cb.LineTo(510, 300);

            cb.Stroke();
            cb.BeginText();
            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("UploadFolder/BLLogos/navio.png"));
            png1.SetAbsolutePosition(25, 800);
            png1.ScalePercent(50f);
            doc.Add(png1);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader3 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader3, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B3106 , 31ST FLOOR , LATIFA TOWER , NEXT TO CROWN PLAZA HOTEL , SHEIKH ZAYED ROAD , DUBAI , UAE , PIN CODE : 117067", 75, 780, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 15);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ARRIVAL NOTICE", 250, 755, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader2 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader2, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Consignee"].ToString(), 25, 730, 0);
            cb.EndText();

            BaseFont bfheaderaddress = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheaderaddress, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            int ColumnRows = 720; int RowsColumn = 0;
            RowsColumn = 0;
            string[] ArrayAddress = Regex.Split(_dt.Rows[0]["ConsigneeAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit;

            for (int x = 0; x < ArrayAddress.Length; x++)
            {
                Aaddsplit = ArrayAddress[x].Split('\n');

                for (int k = 0; k < Aaddsplit.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit[k].ToString(), 25, ColumnRows, 0);
                    ColumnRows -= 9;
                    RowsColumn++;
                }
            }


            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Date", 500, 755, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 550, 755, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Page No", 500, 740, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 550, 740, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Bill of Lading/Loading Date", 25, 650, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 650, 0);
            // cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BLNumber"].ToString(), 175, 650, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Origin", 25, 635, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 635, 0);
            // cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Origin"].ToString(), 175, 635, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Discharge Port", 25, 620, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 620, 0);
            // cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["DischargePort"].ToString(), 175, 620, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee", 25, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 605, 0);
            // cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Consignee"].ToString(), 175, 605, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marks and Number", 25, 590, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 590, 0);
            // cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Marks"].ToString(), 175, 590, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Description ", 25, 565, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 165, 565, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Description"].ToString(), 175, 565, 0);

            cb.EndText();

            cb.BeginText();
            BaseFont bfheader7 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader7, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BLNumber"].ToString(), 175, 650, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Origin"].ToString(), 175, 635, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["DischargePort"].ToString(), 175, 620, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Consignee"].ToString(), 175, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Marks"].ToString(), 175, 590, 0);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["VesselName"].ToString() + "\r" + _dt.Rows[0]["VoyageNo"].ToString(), 480, 650, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Destination"].ToString(), 480, 635, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Line"].ToString(), 480, 605, 0);

            cb.EndText();


            int ColumnRow1 = 565; int RowsColumn1 = 0;
            RowsColumn1 = 0;
            string[] ArrayAddress1 = Regex.Split(_dt.Rows[0]["Description"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit1;

            for (int x = 0; x < ArrayAddress1.Length; x++)
            {
                Aaddsplit1 = ArrayAddress1[x].Split('\n');

                for (int k = 0; k < Aaddsplit1.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit1[k].ToString(), 175, ColumnRow1, 0);
                    ColumnRow1 -= 9;
                    RowsColumn1++;
                }
            }

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel/Voy", 370, 650, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 650, 0);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Destination", 370, 635, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 635, 0);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ETA Date", 370, 620, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 620, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Line", 370, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 605, 0);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "IGM No.Date", 370, 590, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 590, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Item No ", 370, 575, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ":", 470, 575, 0);


            cb.EndText();

            cb.BeginText();
            BaseFont bfheader6 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader6, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "You are hereby notified that the below consignment is expected to arrived ", 25, 490, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Destination"].ToString() + " per " + _dt.Rows[0]["VesselName"].ToString() + "\r" + _dt.Rows[0]["VoyageNo"].ToString(), 325, 490, 0);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "The Item No is ", 25, 480, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 85, 480, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheadero = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheadero, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Following charges are applicable to obtain delivery of your cargo:", 25, 405, 0);
            cb.EndText();


            cb.BeginText();
            BaseFont bfheader8 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader8, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Conditions:", 25, 290, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Contact on TDR DXB GENIO tdr.dxb@genioshipping.com", 25, 275, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Tel: +9714 3380007 | Fax : +9714 338001", 25, 260, 0);
            cb.EndText();

            //table 1
            cb.BeginText();
            BaseFont bfheader9 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader9, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No.", 30, 460, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container Size", 180, 460, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container Status", 305, 460, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "No of Packages", 405, 460, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Weight", 505, 460, 0);
            cb.EndText();


            //table 2
            cb.BeginText();
            BaseFont bfheader10 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader10, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Particulars", 30, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Qty", 155, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rate", 185, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Curr", 225, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ExchRt", 255, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FC Amt", 295, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Taxable", 395, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Value", 395, 370, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "VAT", 435, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Group", 435, 370, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "VAT", 495, 390, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rate", 470, 370, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Amount", 520, 370, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total", 575, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Amount", 575, 370, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total:", 260, 330, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Grand Total", 460, 310, 0);

            cb.EndText();

            doc.Close();
            writer.Close();
            pdfmp.AddFile(FileNamev + ".pdf");
            pdfmp.Execute();
            string str = FileHidpath;
            //string mime = MimeMapping.GetMimeMapping(FileHidpath);
            WebClient client = new WebClient();
            byte[] thePdf = client.DownloadData(FileHidpath);


            return File(thePdf, "application/pdf");
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


        public DataTable GetArrivalPdf(string BLID)
        {
            string _Query = "select BLNumber,(select(PortCode + '-' + PortName) from NVO_PortMaster where NVO_PortMaster.ID = Nvo_ImpBL.POOID) as Origin, " +
                                       " (select(PortCode + '-' + PortName) from NVO_PortMaster where NVO_PortMaster.ID = Nvo_ImpBL.PODID) as DischargePort, " +
                                       " (select(PortCode + '-' + PortName) from NVO_PortMaster where NVO_PortMaster.ID = Nvo_ImpBL.FPODID) as Destination,Consignee, " +
                                       " (select VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = Nvo_ImpBL.VesselID) as VesselName, " +
                                       " (select VoyageNo from NVO_Voyage where NVO_Voyage.ID = Nvo_ImpBL.VoyageID) as VoyageNo,Marks,Description,ConsigneeAddress, " +
                                       " (select LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = Nvo_ImpBL.PrincipalID) as Line " +
                                       " from Nvo_ImpBL where ID=" + BLID;


            return Manag.GetViewData(_Query, "");

        }


        public DataTable GetContainerDetails(string BLID)
        {
            string _Query = "select NVO_BLContainer.CntrID,NVO_BLContainer.BLID,NVO_BLCargo.ID as CargoID, (select CntrNo from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as CntrNo, (select top(1) Size from NVO_tblCntrTypes inner join NVO_Containers  on NVO_Containers.TypeID = NVO_tblCntrTypes.ID where NVO_Containers.ID = NVO_BLContainer.CntrID ) as Size,SealNo,CustomerSeal,KGSWeight,NetWeight,NoofPkgs,CBMVolume, * from NVO_BLContainer Left Outer join NVO_BLCargo on NVO_BLCargo.CntrID = NVO_BLContainer.CntrID where NVO_BLContainer.BLID =" + BLID;

            return Manag.GetViewData(_Query, "");
        }

        public DataTable GetNotes(string BLID)
        {
            string _Query = "select Notes from NVO_ExpBLNotes where BLID=" + BLID;

            return Manag.GetViewData(_Query, "");
        }

    }
}











