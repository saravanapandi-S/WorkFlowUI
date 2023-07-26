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
using System.Net;

namespace nvocc.Controllers.PDF
{
    [Route("api/PDF/[controller]")]
    [ApiController]
    public class NavioPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public NavioPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet, DisableRequestSizeLimit]
        [Route("NavioPrintPDF")]
        public async Task<FileResult> NavioPrintPDF([FromQuery] string BLID, string printvalue)
        {

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 900);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            
            DataTable _dt = GetBkgCustomer(BLID);
            var pdfpath = Path.Combine("UploadFolder/");
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

            //iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("UploadFolder/BLLogos/navio.png"));
            //png1.SetAbsolutePosition(15, 837);
            //png1.ScalePercent(60f);
            //doc.Add(png1);

            //iTextSharp.text.Image png2 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/assets/img/oclheader.jpg"));
            //png2.SetAbsolutePosition(320, 835);
            //png2.ScalePercent(52f);
            //doc.Add(png2);



            //Top
            cb.MoveTo(10, 828);
            cb.LineTo(660, 828);

            cb.MoveTo(10, 828);
            cb.LineTo(10, 10);

            cb.MoveTo(660, 828);
            cb.LineTo(660, 10);

            cb.MoveTo(10, 728);
            cb.LineTo(330, 728);

            cb.MoveTo(10, 628);
            cb.LineTo(660, 628);

            cb.MoveTo(10, 528);
            cb.LineTo(660, 528);

            cb.MoveTo(10, 498);
            cb.LineTo(660, 498);

            cb.MoveTo(10, 468);
            cb.LineTo(660, 468);

            cb.MoveTo(10, 448);
            cb.LineTo(660, 448);

            cb.MoveTo(330, 828);
            cb.LineTo(330, 468);

            cb.MoveTo(180, 528);
            cb.LineTo(180, 268);

            cb.MoveTo(480, 528);
            cb.LineTo(480, 268);

            cb.MoveTo(10, 268);
            cb.LineTo(660, 268);

            cb.MoveTo(10, 248);
            cb.LineTo(660, 248);

            cb.MoveTo(10, 140);
            cb.LineTo(660, 140);

            cb.MoveTo(10, 120);
            cb.LineTo(660, 120);

            cb.MoveTo(10, 100);
            cb.LineTo(660, 100);

            cb.MoveTo(10, 10);
            cb.LineTo(660, 10);

            cb.MoveTo(150, 140);
            cb.LineTo(150, 100);

            cb.MoveTo(330, 140);
            cb.LineTo(330, 10);

            cb.MoveTo(480, 140);
            cb.LineTo(480, 100);

            cb.Stroke();

            cb.BeginText();
            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("UploadFolder/BLLogos/navio.png"));
            png1.SetAbsolutePosition(380, 650);
            png1.ScalePercent(70f);
            doc.Add(png1);
            cb.EndText();



            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 11);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "OCEAN BILL OF LADING", 15, 838, 0);
            cb.EndText();
            cb.BeginText();
            BaseFont bfheader2 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader2, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FOR COMBINED OR MULTIMODAL TRANSPORT DOCUMENT", 335, 838, 0);
            cb.EndText();
            cb.BeginText();
            BaseFont bfheader3 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader3, 70);
            cb.SetColorFill(iTextSharp.text.BaseColor.LIGHT_GRAY);
            if (printvalue == "1")
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   D R A F T   ", 200, 400, 45);
            }
            if (printvalue == "2")
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "   O R I G I N A L   ", 150, 350, 45);
            }
            else
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 100, 200, 45);
            }



            cb.EndText();

            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 15, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee(Or Order):", 15, 718, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Address", 15, 618, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Pre-carriage By", 15, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt", 185, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Ocean Vessel/Voyage No", 355, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 485, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Discharge", 15, 488, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Final Delivery", 185, 488, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Mode/Means of Transport", 355, 488, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Route/Place of Transhipment", 485, 488, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B/L NO:", 335, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Also Notify Party:", 335, 618, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No.Seal No./& Marks", 15, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Description of Goods & Pkgs", 185, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross Weight", 485, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Cbm", 575, 458, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ORIGINAL", 500, 278, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Particulars above furnished by consignee/consignor", 170, 258, 0);
            cb.EndText();


            cb.BeginText();
            BaseFont bfheader41 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader41, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Address", 15, 618, 0);
           
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["PlaceOfReceipt"].ToString(), 185, 506, 0);
           
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["PlaceOfReceipt"].ToString(), 485, 506, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Discharge"].ToString(), 15, 476, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Destination"].ToString(), 185, 476, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 355, 488, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BLNumber"].ToString(), 400, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Also Notify Party:", 335, 618, 0);

           
           
           
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FREIGHT :", 485, 380, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["PaymentTerms"].ToString(), 520, 380, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Packages"].ToString(), 185, 438, 0);





            int ColumnRows = 806; int RowsColumn = 0;
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

            ColumnRows = 706;
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

            ColumnRows = 606;
            RowsColumn = 0;
            string[] ArrayAddress2 = Regex.Split(_dt.Rows[0]["Notify"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["NotifyAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
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


            ColumnRows = 78;
            RowsColumn = 0;

            string[] ArrayAddress3 = Regex.Split(_dt.Rows[0]["DeliveryAgent"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["DeliveryAgentAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
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


            ColumnRows = 606;
            RowsColumn = 0;

            string[] ArrayAddress4 = Regex.Split(_dt.Rows[0]["NotifyAlso"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["NotifyAlsoAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit4;

            for (int x = 0; x < ArrayAddress4.Length; x++)
            {
                Aaddsplit4 = ArrayAddress4[x].Split('\n');

                for (int k = 0; k < Aaddsplit4.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit4[k].ToString(), 345, ColumnRows, 0);
                    ColumnRows -= 9;
                    RowsColumn++;
                }
            }



            


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Weight"].ToString().Trim().ToUpper(), 493, 440, 0);
            //if (_dt.Rows[0]["NTWT"].ToString().Trim().ToUpper() != "0.000")
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["NTWT"].ToString().Trim().ToUpper() + " " + _dt.Rows[0]["NtWtType"].ToString().Trim().ToUpper(), 493, 380, 0);

            //if (_dt.Rows[0]["CBM"].ToString().Trim().ToUpper() != "0.0000")
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["CBM"].ToString().Trim().ToUpper() + " M3", 570, 450, 0);

            string[] arrayMarks = new string[] { };
            string[] arrayDescription = new string[] { };
            string[] arrayCntrNo = new string[] { };


            List<string> ArrayMarksV = new List<string>();
            arrayMarks = _dt.Rows[0]["MarksNos"].ToString().Split('\n');
            int intMarkCount = arrayMarks.Length;
            arrayDescription = _dt.Rows[0]["Description"].ToString().Split('\n');
            int intDescCount = arrayDescription.Length;




            int LineX = 0;
            int LineMark = 0;
            int RowMx = 438;

            int TotalLine = 0;
            //int ColumnCountMrks = 15;
            //ColumnCountMrks = arrayMarks.Length;
            TotalLine = 15;
            for (LineMark = 0; LineMark < TotalLine; LineMark++)
            {
                if (arrayMarks.Length >= LineMark + 1)

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayMarks[LineMark].ToUpper(), 15, RowMx, 0);
                RowMx -= 10;
            }

            //RowMx -= 20;

            //TotalLine = 4;
            DataTable _dtCntr = GetContainerDetails(BLID);
            //var _dtCntrValues = _dtCntr.Rows[0]["CntrNo"].ToString().Split('\n');
            //int TotalColumnCntr = (_dtCntrValues.Length < TotalLine) ? _dtCntrValues.Length : TotalLine;
            //if (_dtCntr.Rows.Count > 0)
            //{
            //    TotalLine = TotalColumnCntr;
            //    for (int LineX = 0; LineX < TotalLine; LineX++)
            //    {
            //        var arrayCntrNov = SplitByLenght(_dtCntrValues[LineX].ToString(), 30);
            //        for (int d = 0; d < arrayCntrNov.Length; d++)
            //        {
            //            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayCntrNov[d].ToUpper(), 25, RowMx, 0);
            //            RowMx -= 10;
            //        }
            //    }
            //}




            int RowDec = 438;

            TotalLine = 15;

            for (LineX = 0; LineX < TotalLine; LineX++)
            {
                if (arrayDescription.Length >= LineX + 1)

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayDescription[LineX], 210, RowDec, 0);
                RowDec -= 10;
            }


            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FREIGHT: " + _dt.Rows[0]["PaymentTerms"].ToString(), 270, 265, 0);

            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["PlaceOfIssue"].ToString() + "   &  " + _dt.Rows[0]["BLIssueDate"].ToString(), 460, 100, 0);
            cb.EndText();
            int ColumnRowsA = 238;
            int RowsColumnA = 0;
            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 6);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            string text = @"Received in good order and condition,unless otherwise noted herein.at the place of receipt for transport and delivery as mentioned above the particulars as stated above by shipper and the weight,quantity. condition, 
            contents and value of goods are unknown to the carrier Quality, quantity and nature of the cargo stuffed inside the container by the shipper is unknown to the carrier. one of these Combined Transport Bill of Lading 
            must be surrendered duly endorsed in exchange for the goods. IN WITNESS whereof the original Combined Transport Bill of Lading all of this tendor and date have been signed in the number stated below one of 
            which being accomplished and the other(s) to be void.The contract evidenced by or contained in this bill of lading is governed by the law of UAE and any clain dispute arising hereunder or in connection herewith 
            shall be determined by the courts in UAE and no other courts. Cargo insurance not provided by the carriers in case subject shipment in not loaded on vessel named aforesaid for any reason/is not cleared/by claimed 
            by the consignee and cargo is abandoned at destination or cargo is mis-declared by the shipper subject to any seizure of the shipment at port of loading or port of discharge all charges/penalities/fines/legal fee 
            pertaining to this shipment will be for shippers account and carrier hold shipper fully responsible for the same all charges with regard to losses and / or damages to container(s),while empty container(s)is/are returnes 
            to lines custody at destination will be on consignee account ,Destination THC ,Container Detention charges and all other applicable ancilaries are payable at destination by consignee. the shipment will be held back by 
            carrier/carriers agent if shipper or consignee owes any money without any responsibilty of claims on their party.in case shipment has been rejected by the authorities at the discharge port,re shipment 
            expenses,demurage,detention etc.and all freight charges will be on shippers account. carrier is not responsible for the condition of cargo.";
            string[] Arrayterms = Regex.Split(text, char.ConvertFromUtf32(13));
            string[] Addsplit1;

            for (int x = 0; x < Arrayterms.Length; x++)
            {
                Addsplit1 = Arrayterms[x].Split('\n');

                for (int k = 0; k < Addsplit1.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Addsplit1[k].ToString(), 15, ColumnRowsA, 0);
                    ColumnRowsA -= 4;
                    RowsColumnA++;
                }
            }
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Charges", 15, 130, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Payable at", 155, 130, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number of Originals", 335, 130, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place and Date of issue", 485, 130, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["PaymentTerms"].ToString(), 15, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["FreightPayableAt"].ToString(), 155, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["NoOfOriginal"].ToString(), 335, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["PlaceOfIssue"].ToString(), 485, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BLIssueDate"].ToString(), 600, 110, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "For DELIVERY, PLEASE APPLY TO", 15, 90, 0);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "AS AGENTS", 400, 20, 0);


            cb.EndText();
            cb.BeginText();
            BaseFont bfheader6 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader6, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "For NAVIO SHIPPING LLC", 400, 90, 0);

            cb.EndText();

            doc.Close();
            writer.Close();
            pdfmp.AddFile(FileNamev + ".pdf");


            int[] arr = { arrayDescription.Length, arrayMarks.Length, _dtCntr.Rows.Count };
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }

            //int[] markarr = { arrayMarks.Length, _dtCntr.Rows.Count };
            //int maxmarks = markarr[0];
            //for (int i = 1; i < markarr.Length; i++)
            //{
            //    if (markarr[i] > maxmarks)
            //        maxmarks = markarr[i];
            //}


            int SheetNo = 1;
            int TotalColumn = max + _dtCntr.Rows.Count;
           
            int DesMarks = max;
            int CntrCount = _dtCntr.Rows.Count;
            int WriteLine = TotalColumn - TotalLine;
            
            int AttachedsheetNo = int.Parse(Math.Ceiling((WriteLine / 70.00)).ToString());
            
            int Cot = 0;

            int LIndex = 15;
            int LMarkindex = 15;
            
            int LCntrindex = 4;

            for (int k = 0; k < AttachedsheetNo; k++)
            {
                string _AttachFileName = "test";
                var AttachFileNamev = "";
                Random rd1 = new Random();
                AttachFileNamev += rd1.Next(1000).ToString();
                AttachFileNamev += "Attach" + "_" + _AttachFileName + BLID;


                Document Attdocument = new Document(rec);
                PdfWriter Attwriter = PdfWriter.GetInstance(Attdocument, new FileStream(pdfpath + (AttachFileNamev + SheetNo) + ".pdf", FileMode.Create));
                Attdocument.Open();
                PdfContentByte Attcb = Attwriter.DirectContent;

                Attcb.BeginText();
                BaseFont bfheader12 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheader12, 14);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 300, 820, 0);


                BaseFont bfheader211 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Attcb.SetFontAndSize(bfheader211, 23);
                Attcb.SetColorFill(iTextSharp.text.BaseColor.BLACK);



                BaseFont bfheader222 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Attcb.SetFontAndSize(bfheader222, 8);
                Attcb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
                int yy = _Yp - YDiff * 6;
                int DeffLine = 0;
                int deffMark = 0;
                
                LineMark = 0;
                int deffcntr = 0;
                int LineCntr = 0;
                LineX = 0;
                //LMarkindex = 0;
                Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DESCRIPTION OF GOODS", 400, 820 - DeffLine, 0);
                Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "MARKS AND NUMBERS", 20, 820 - DeffLine, 0);
                DeffLine = 0;
                if (arrayDescription.Length >= LIndex)
                {
                    
                    for (int Lines = LIndex; Lines < arrayDescription.Length; Lines++)
                    {
                        if (arrayDescription.Length >= TotalLine + 1)

                            Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayDescription[Lines], 400, 780 - DeffLine, 0);

                        DeffLine += 10;
                        Cot++;
                        LineX++;
                        LIndex++;
                        if (LineX == 70)
                        {
                            break;
                        }
                    }
                }
                int desline = DeffLine;
                DeffLine = 0;
                if (arrayMarks.Length >= LMarkindex)
                {
                   
                    for (int Lines1 = LMarkindex; Lines1 < arrayMarks.Length; Lines1++)
                    {
                        if (arrayMarks.Length >= TotalLine + 1)

                            Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayMarks[Lines1], 20, 780 - DeffLine, 0);

                        DeffLine += 10;
                        Cot++;
                        LineMark++;
                        LMarkindex++;
                        if (LineMark == 70)
                        {
                            
                            break;
                        }
                    }
                }

                int arrMarkLine = DeffLine;

                int[] arr1 = { desline, arrMarkLine };
                int max1 = arr1[0];
                for (int i = 1; i < arr1.Length; i++)
                {
                    if (arr1[i] > max1)
                        max1 = arr1[i];
                }


                //int[] Larr1 = { LineMark, LineX };
                //int Lmax1 = Larr1[0];
                //for (int i = 1; i < Larr1.Length; i++)
                //{
                //    if (arr1[i] > Lmax1)
                //        Lmax1 = arr1[i];
                //}


                int CntrRow = 0;
                  CntrRow = LineX;
                DeffLine = max1;
                if (max <= max1)
                {
                    DeffLine -= 10;
                    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CONTAINER", 15, 780 - DeffLine, 0);
                    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TYPE", 155, 780 - DeffLine, 0);
                    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SEAL NO", 255, 780 - DeffLine, 0);
                    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PACKAGES", 355, 780 - DeffLine, 0);
                    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NET WT(KGS)", 455, 780 - DeffLine, 0);
                    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "GR WT(KGS)", 575, 780 - DeffLine, 0);
                    DeffLine += 30;
                    //CntrRow = 780 - DeffLine;
                    for (int z = 0; z < _dtCntr.Rows.Count; z++)
                    {
                        Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dtCntr.Rows[z]["CntrNo"].ToString(), 15, 780 - DeffLine, 0);
                        Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dtCntr.Rows[z]["Size"].ToString(), 155, 780 - DeffLine, 0);
                        Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dtCntr.Rows[z]["SealNo"].ToString(), 255, 780 - DeffLine, 0);
                        Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dtCntr.Rows[z]["NoofPkgs"].ToString(), 355, 780 - DeffLine, 0);
                        Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dtCntr.Rows[z]["NetWeight"].ToString(), 455, 780 - DeffLine, 0);
                        Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dtCntr.Rows[z]["KGSWeight"].ToString(), 575, 780 - DeffLine, 0);

                        DeffLine += 10;
                        if(CntrRow == 70)
                        {
                            break;
                        }
                    }
                }








                //int LineCount = Cot;
                //int SheetNo = 1;

                //string _AttachFileName = "test";
                //var AttachFileNamev = "";
                //Random rd1 = new Random();
                //AttachFileNamev += rd1.Next(1000).ToString();
                //AttachFileNamev += "Attach" + "_" + _AttachFileName + BLID;
                //int LIndex = 15;
                //int LMarkindex = 8;
                //int LCntrindex = 4;
                //int yy = _Yp - YDiff * 6;
                //int DeffLine = 0;
                //int deffMark = 0;
                //LineX = 0;
                //int LineMark = 0;
                //int deffcntr = 0;
                //int LineCntr = 0;


                //    Document Attdocument = new Document(rec);
                //PdfWriter Attwriter = PdfWriter.GetInstance(Attdocument, new FileStream(pdfpath + (AttachFileNamev + SheetNo) + ".pdf", FileMode.Create));
                //Attdocument.Open();
                //PdfContentByte Attcb = Attwriter.DirectContent;

                //Attcb.BeginText();
                //BaseFont bfheader12 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //cb.SetFontAndSize(bfheader12, 14);
                //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 300, 820, 0);


                //BaseFont bfheader211 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //Attcb.SetFontAndSize(bfheader211, 23);
                //Attcb.SetColorFill(new iTextSharp.text.BaseColor(0, 0, 128));



                //BaseFont bfheader222 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //Attcb.SetFontAndSize(bfheader222, 8);
                //Attcb.SetColorFill(new iTextSharp.text.BaseColor(0, 0, 128));


                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "MARKS AND NUMBERS", 15, 815, 0);
                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NO OF PACKAGES,", 155, 815, 0);
                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DESCRIPTION OF GOODS", 155, 805, 0);
                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "GROSS WT", 485, 815, 0);
                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "KGS", 575, 815, 0);







                //for (int Lines = LIndex; Lines < arrayDescription.Length; Lines++)
                //{
                //    if (arrayDescription.Length >= TotalLine + 1)

                //        Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayDescription[Lines], 400, 780 - DeffLine, 0);

                //    DeffLine += 10;
                //    Cot++;
                //    LineX++;
                //    if (LineX == 70)
                //    {

                //        LIndex += LineX;
                //        break;
                //    }
                //}
                //int RowsCntr = 680;
                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CONTAINER", 15, 700, 0);
                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TYPE", 155, 700, 0);
                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SEAL NO", 155, 700, 0);
                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PACKAGES", 485, 700, 0);
                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NET WT(KGS)", 575, 700, 0);
                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "GR WT(KGS)", 575, 700, 0);


                //for (int z = 0; z < _dtCntr.Rows.Count; z++)
                //{
                //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dtCntr.Rows[z]["CntrNo"].ToString(), 15, RowsCntr, 0);
                //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dtCntr.Rows[z]["Size"].ToString(), 155, RowsCntr, 0);
                //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dtCntr.Rows[z]["SealNo"].ToString(), 270, RowsCntr, 0);
                //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dtCntr.Rows[z]["NoofPkgs"].ToString(), 485, RowsCntr, 0);
                //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dtCntr.Rows[z]["NetWeight"].ToString(), 575, RowsCntr, 0);
                //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dtCntr.Rows[z]["KGSWeight"].ToString(), 575, RowsCntr, 0);
                //    RowsCntr -= 10;
                //}

                Attcb.EndText();
                Attdocument.Close();
                Attwriter.Close();
                pdfmp.AddFile(AttachFileNamev + SheetNo + ".pdf");
                SheetNo++;
            }
            
        
            
            //for (int k = 0; k < AttachedsheetNo; k++)
            //{

            //    Document Attdocument = new Document(rec);
            //    PdfWriter Attwriter = PdfWriter.GetInstance(Attdocument, new FileStream(pdfpath + (_AttFileName + SheetNo) + ".pdf", FileMode.Create));
            //    Attdocument.Open();
            //    PdfContentByte Attcb = Attwriter.DirectContent;

            //    Attcb.BeginText();
            //    BaseFont bfheader12 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //    cb.SetFontAndSize(bfheader12, 14);
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 300, 820, 0);


            //    BaseFont bfheader211 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //    Attcb.SetFontAndSize(bfheader211, 23);
            //    Attcb.SetColorFill(new iTextSharp.text.BaseColor(0, 0, 128));



            //    BaseFont bfheader222 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //    Attcb.SetFontAndSize(bfheader222, 8);
            //    Attcb.SetColorFill(new iTextSharp.text.BaseColor(0, 0, 128));


            //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marks and Nos.", 15, 815, 0);
            //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NO OF PACKAGES,", 155, 815, 0);
            //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DESCRIPTION OF GOODS", 155, 805, 0);
            //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "GROSS WT", 485, 815, 0);
            //    Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "KGS", 575, 815, 0);
            //    int yy = _Yp - YDiff * 6;
            //    int DeffLine = 0;
            //    int deffMark = 0;
            //    int LineX = 0;
            //    int LineMark = 0;
            //    int deffcntr = 0;
            //    int LineCntr = 0;

            //    DeffLine = 0;

            //    if (LineX <= 70)
            //    {

            //        //for (int Lines = LCntrindex; Lines < _dtCntrValues.Length; Lines++)
            //        //{

            //        //    if (_dtCntrValues.Length >= LCntrindex + 1)
            //        //    {
            //        //        var arrayCntrNov = SplitByLenght(_dtCntrValues[Lines].ToString(), 30);
            //        //        for (int d = 0; d < arrayCntrNov.Length; d++)
            //        //        {
            //        //            Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayCntrNov[d].ToUpper(), 230, 780 - deffcntr, 0);
            //        //            deffcntr += 10;
            //        //        }
            //        //        Cot++;
            //        //        LineCntr++;
            //        //        if (LineCntr == 70)
            //        //        {
            //        //            deffcntr += LineCntr - 13;
            //        //            break;
            //        //        }
            //        //    }
            //        //}
            //        for (int Lines = LMarkindex; Lines < arrayMarks.Length; Lines++)
            //        {
            //            if (arrayMarks.Length >= LMarkindex + 1)

            //                Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayMarks[Lines], 20, 780 - deffMark, 0);

            //            deffMark += 10;
            //            Cot++;
            //            LineMark++;
            //            if (LineMark == 70)
            //            {
            //                LMarkindex += LineMark;
            //                break;
            //            }
            //        }



            //        for (int Lines = LIndex; Lines < arrayDescription.Length; Lines++)
            //        {
            //            if (arrayDescription.Length >= TotalLine + 1)

            //                Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayDescription[Lines], 400, 780 - DeffLine, 0);

            //            DeffLine += 10;
            //            Cot++;
            //            LineX++;
            //            if (LineX == 70)
            //            {

            //                LIndex += LineX;
            //                break;
            //            }
            //        }

            //        int DeferentLine = (DeffLine < deffMark) ? deffcntr : deffcntr;
            //        DataTable _dtns = GetNotes(BLID);
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
            //    Attdocument.Close();
            //    Attwriter.Close();
            //    pdfmp.AddFile(_AttFileName + SheetNo + ".pdf");
            //    SheetNo++;
            //}



            pdfmp.Execute();
            string str = FileHidpath;
            //string mime = MimeMapping.GetMimeMapping(FileHidpath);
            WebClient client = new WebClient();
            byte[] thePdf = client.DownloadData(FileHidpath);
            if (printvalue == "2")
            {
                BOLManger RegMng = new BOLManger();
                RegMng.UpdateBLPrintPath(BLID, MergePdf);
            }
              
            return File(thePdf, "application/pdf");
            //return File(FileHidpath, mime);

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

            string _Query = "select NVO_BOLNew.ID,Shipper,ShipperAddress,Consignee,ConsigneeAddress,Notify," +
                            " NotifyAddress,NotifyAlsoAddress,(select top(1) ShipperAddress from NVO_PartiesDtls " +
                            " where PartyTypeID = 1) as ShipperAddress,(select top(1) Consignee from NVO_PartiesDtls where " +
                            " PartyTypeID = 2)as Consignee,(select top(1) ConsigneeAddress from NVO_PartiesDtls where PartyTypeID = 2 " +
                            " and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as ConsigneeAddress,(select top(1) Notify from NVO_PartiesDtls " +
                            " where PartyTypeID = 3 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as Notify,(select top(1) NotifyAddress from NVO_PartiesDtls " +
                            " where PartyTypeID = 3 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as NotifyAddress,(select top(1) Notifyalso from NVO_PartiesDtls " +
                            " where PartyTypeID = 4 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as Notifyalso,(select top(1) NotifyAlsoAddress from NVO_PartiesDtls " +
                            " where PartyTypeID = 4 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as NotifyAlsoAddress,(select BLNumber from NVO_BL where NVO_BL.ID = NVO_BOLNew.BLID)as BLNumber, " +
                            " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PlaceofRecID)as PlaceOfReceipt,(select PortName from NVO_PortMaster " +
                            " where NVO_PortMaster.ID = NVO_BOLNew.PortofLoadID)as PortofLoading,(select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PortofDischargeID)as Discharge," +
                            " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PortofDestinationID)as Destination, Case when PaymentTermsID=1 then 'Prepaid' else 'Collect' end " +
                            " as PaymentTerms,FreightPayableAt,NoOfOriginal,PlaceOfIssue,convert(varchar,BLIssueDate,103)as BLIssueDate,(select AgencyName from NVO_AgencyMaster " +
                            " where NVO_AgencyMaster.ID = NVO_BOLNew.DeliveryAgent)as DeliveryAgent,DeliveryAgentAddress,MarksNos,Description,Packages,Weight from NVO_BOLNew " +
                            " where BLID =" + BLID;

            //string _Query = " select NVO_BOLNew.ID, " +
            //                " (select top(1) ShipperName from NVO_PartiesDtls where NVO_PartiesDtls.ShipperType = 1 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID) as ShipperName, " +
            //                " (select top(1) ShipperAddress from NVO_PartiesDtls where ShipperType = 1 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID) as ShipperAddress, " +
            //                " (select top(1) Consignee from NVO_PartiesDtls where ConsigneeType = 2 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as Consignee, " +
            //                " (select top(1) ConsigneeAddress from NVO_PartiesDtls where ConsigneeType = 2 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as ConsigneeAddress, " +
            //                " (select top(1) Notify from NVO_PartiesDtls where NotifyType = 3 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as Notify, " +
            //                " (select top(1) NotifyAddress from NVO_PartiesDtls where NotifyType = 3 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as NotifyAddress, " +
            //                " (select top(1) Notifyalso from NVO_PartiesDtls where NotifyAlsoType = 4 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as Notifyalso, " +
            //                " (select top(1) NotifyAlsoAddress from NVO_PartiesDtls where NotifyAlsoType = 4 and NVO_BOLNew.BLID = NVO_PartiesDtls.BLID)as NotifyAlsoAddress, " +
            //                " (select BLNumber from NVO_BL where NVO_BL.ID = NVO_BOLNew.BLID)as BLNumber, " +
            //                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PlaceofRecID)as PlaceOfReceipt, " +
            //                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PortofLoadID)as PortofLoading, " +
            //                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PortofDischargeID)as Discharge, " +
            //                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_BOLNew.PortofDestinationID)as Destination, " +
            //                " PaymentTerms,FreightPayableAt,NoOfOriginal,PlaceOfIssue,convert(varchar,BLIssueDate,103)as BLIssueDate, " +
            //                " (select AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_BOLNew.DeliveryAgent)as DeliveryAgent,DeliveryAgentAddress,MarksNos,Description,Packages,Weight from NVO_BOLNew " +
            //                " where BLID =" + Data.BLID;
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
