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
    public class AquaticPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();

        public static class MimeMapping
        {
            internal static string GetMimeMapping(string FileHidpath)
            {
                throw new NotImplementedException();
            }
        }


        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        //public object MimeMapping { get; private set; }

        public AquaticPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }




        [HttpGet, DisableRequestSizeLimit]
        [Route("NavioPrintPDF")]
        public async Task<FileResult> NavioPrintPDF([FromQuery] string BLID)
        {

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 900);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            string printvalue = "1";
            DataTable _dt = GetBkgCustomer(BLID);
            var pdfpath = Path.Combine("UploadFolder/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-" + "BL.pdf";
            string FileHidpath = pdfpath + "Multiple-" + "BL.pdf";

            string _FileName = BLID + 1;
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath + _FileName + ".pdf", FileMode.Create));
            //PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();

            PdfContentByte cb = writer.DirectContent;
            cb.SetColorStroke(new iTextSharp.text.BaseColor(0, 0, 208));
           
            int _Xp = 10, _Yp = 785, YDiff = 10;

            cb.BeginText();
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

            BaseFont Crossbfheader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(iTextSharp.text.BaseColor.LIGHT_GRAY);
            cb.SetFontAndSize(Crossbfheader, 70);
            

      
            BaseFont Crossbfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(iTextSharp.text.BaseColor.LIGHT_GRAY);
            cb.SetFontAndSize(Crossbfheader1, 40);






           

            //BaseFont bfheader2 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //cb.SetFontAndSize(bfheader2, 9);
            //cb.SetColorFill(new iTextSharp.text.BaseColor(255, 200, 200));
            ////center

            



            //////Top//
            //cb.MoveTo(15, 825);
            //cb.LineTo(650, 825);

            ////left//
            //cb.MoveTo(325, 825);
            //cb.LineTo(325, 510);
            ////left off
            //cb.MoveTo(475, 825);
            //cb.LineTo(475, 782);

            //////Top One off//
            //cb.MoveTo(325, 782);
            //cb.LineTo(650, 782);


            //////Top One//
            //cb.MoveTo(15, 745);
            //cb.LineTo(650, 745);

            //////Top Tow//
            //cb.MoveTo(15, 665);
            //cb.LineTo(650, 665);


            //////Top Three//
            //cb.MoveTo(15, 580);
            //cb.LineTo(650, 580);


            //////Top Four//
            //cb.MoveTo(15, 545);
            //cb.LineTo(650, 545);

            ////left off
            //cb.MoveTo(170, 580);
            //cb.LineTo(170, 510);

            ////left off Two
            //cb.MoveTo(490, 580);
            //cb.LineTo(490, 510);

            //////Top five//
            //cb.MoveTo(15, 510);
            //cb.LineTo(650, 510);

            //////Top five//
            //cb.MoveTo(15, 485);
            //cb.LineTo(650, 485);


            //////Top six//
            //cb.MoveTo(15, 225);
            //cb.LineTo(650, 225);

            //////Top Seven//
            //cb.MoveTo(15, 30);
            //cb.LineTo(650, 30);


            ////left off Marks
            //cb.MoveTo(190, 510);
            //cb.LineTo(190, 260);


            //cb.MoveTo(15, 260);
            //cb.LineTo(260, 260);


            ////left off Pakage
            //cb.MoveTo(260, 510);
            //cb.LineTo(260, 225);

            ////left off Description
            //cb.MoveTo(490, 510);
            //cb.LineTo(490, 225);

            //////left off Description
            ////cb.MoveTo(490, 485);
            ////cb.LineTo(490, 225);


            ////left off Mesu
            //cb.MoveTo(560, 510);
            //cb.LineTo(560, 225);



            //cb.MoveTo(350, 225);
            //cb.LineTo(350, 30);



            //cb.SetFontAndSize(bfheader2, 11);
            //cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

           

            BaseFont bfheader23 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader23, 8);
            cb.SetColorFill(new iTextSharp.text.BaseColor(0, 0, 128));
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 15, 815, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee (if 'To Order So Indicate')", 15, 733, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Party (No claim shall attach for failure to notify)", 15, 650, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Delivery Agent", 345, 733, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Party(2)", 345, 650, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Booking No.", 345, 810, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Bill of Lading No", 535, 810, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper's Ref:", 345, 760, 0);

            if (printvalue == "12")
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, " NON NEGOTIABLE   ", 420, 760, 0);
            }


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt", 25, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 180, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Delivery", 340, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Paid at", 500, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel & Voyage No.", 25, 535, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Discharge", 180, 535, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Final Destination", 340, 535, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "No.of Original Bill of Lading", 500, 535, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marks & Numbers", 25, 495, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "No of Pkgs. or", 195, 500, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipping Units", 195, 490, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Description of Goods & Pkgs", 300, 495, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Cargo Weight", 500, 495, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Measurement", 570, 495, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, " SHIPPERS STOW, COUNT, LOAD & SEALED", 270, 470, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, " Gross Weight", 497, 460, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, " Net Weight", 497, 410, 0);

            BaseFont bfheader24 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader24, 8);
            cb.SetColorFill(new iTextSharp.text.BaseColor(0, 0, 128));

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BLNo"].ToString().Trim().ToUpper(), 345, 795, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["BLNo"].ToString().Trim().ToUpper(), 535, 795, 0);

            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Valuesv, 420, 760, 0);

            var POOIDv = _dt.Rows[0]["POO"].ToString().Trim().ToUpper().Split(',');
            if (_dt.Rows[0]["POO"].ToString().Length > 25)
            {
                int xRow = 560;
                for (int i = 0; i < POOIDv.Length; i++)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, POOIDv[i], 25, xRow, 0);
                    xRow -= 11;
                }
            }
            else
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["POO"].ToString().Trim().ToUpper(), 25, 560, 0);
            }

            var POLIDv = _dt.Rows[0]["POL"].ToString().Trim().ToUpper().Split(',');
            if (_dt.Rows[0]["POO"].ToString().Length > 25)
            {
                int xRow = 560;
                for (int i = 0; i < POLIDv.Length; i++)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, POLIDv[i], 180, xRow, 0);
                    xRow -= 11;
                }
            }
            else
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["POL"].ToString().Trim().ToUpper(), 180, 560, 0);
            }

            var FPODv = _dt.Rows[0]["FPOD"].ToString().Trim().ToUpper().Split(',');
            if (_dt.Rows[0]["FPOD"].ToString().Length > 25)
            {
                int xRow = 560;
                for (int i = 0; i < FPODv.Length; i++)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, FPODv[i], 340, xRow, 0);
                    xRow -= 11;
                }
            }
            else
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["FPOD"].ToString().Trim().ToUpper(), 340, 560, 0);
            }




            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["IssuedAt"].ToString().Trim().ToUpper(), 500, 560, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["FreightPaidAt"].ToString().Trim().ToUpper(), 500, 560, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["VesVoy"].ToString().Trim().ToUpper(), 25, 525, 0);


            var PODv = _dt.Rows[0]["POD"].ToString().Trim().ToUpper().Split(',');
            if (_dt.Rows[0]["POD"].ToString().Length > 25)
            {
                int xRow = 525;
                for (int i = 0; i < PODv.Length; i++)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, PODv[i], 180, xRow, 0);
                    xRow -= 11;
                }
            }
            else
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["POD"].ToString().Trim().ToUpper(), 180, 525, 0);
            }


            var FPODvv = _dt.Rows[0]["FPOD"].ToString().Trim().ToUpper().Split(',');
            if (_dt.Rows[0]["FPOD"].ToString().Length > 25)
            {
                int xRow = 525;
                for (int i = 0; i < FPODvv.Length; i++)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, FPODvv[i], 340, xRow, 0);
                    xRow -= 11;
                }
            }
            else
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["FPOD"].ToString().Trim().ToUpper(), 340, 525, 0);
            }






            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["NoofOriginal"].ToString().Trim().ToUpper(), 520, 525, 0);



            int ColumnRows = 800; int RowsColumn = 0;
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

            ColumnRows = 720;
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

            ColumnRows = 640;
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


            ColumnRows = 720;
            RowsColumn = 0;

            string[] ArrayAddress3 = Regex.Split(_dt.Rows[0]["Agent"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["AgentAddress"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
            string[] Aaddsplit3;

            for (int x = 0; x < ArrayAddress3.Length; x++)
            {
                Aaddsplit3 = ArrayAddress3[x].Split('\n');

                for (int k = 0; k < Aaddsplit3.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Aaddsplit3[k].ToString(), 345, ColumnRows, 0);
                    ColumnRows -= 9;
                    RowsColumn++;
                }
            }


            ColumnRows = 640;
            RowsColumn = 0;

            string[] ArrayAddress4 = Regex.Split(_dt.Rows[0]["Notify2"].ToString().Trim().ToUpper() + "\r" + _dt.Rows[0]["Notify2Address"].ToString().ToUpper().Trim(), char.ConvertFromUtf32(13));
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



            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["Packages"].ToString().Trim().ToUpper(), 195, 450, 0);
            var Cargosplitcar = _dt.Rows[0]["CargoPakage"].ToString().Split(' ');
            int CRRow = 430;
            for (int k = 0; k < Cargosplitcar.Length; k++)
            {
                var Cargosplit = SplitByLenght(Cargosplitcar[k], 9);

                for (int z = 0; z < Cargosplit.Length; z++)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Cargosplit[z].ToUpper(), 195, CRRow, 0);
                    CRRow -= 15;
                }
            }
            // cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["CargoPakage"].ToString().Trim().ToUpper(), 195, 430, 0);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["GRWT"].ToString().Trim().ToUpper() + " " + _dt.Rows[0]["GrsWtType"].ToString().Trim().ToUpper(), 493, 440, 0);
            if (_dt.Rows[0]["NTWT"].ToString().Trim().ToUpper() != "0.000")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["NTWT"].ToString().Trim().ToUpper() + " " + _dt.Rows[0]["NtWtType"].ToString().Trim().ToUpper(), 493, 380, 0);

            if (_dt.Rows[0]["CBM"].ToString().Trim().ToUpper() != "0.0000")
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["CBM"].ToString().Trim().ToUpper() + " M3", 570, 450, 0);

            string[] arrayMarks = new string[] { };
            string[] arrayDescription = new string[] { };
            string[] arrayCntrNo = new string[] { };


            List<string> ArrayMarksV = new List<string>();
            arrayMarks = _dt.Rows[0]["Marks"].ToString().Split('\n');
            int intMarkCount = arrayMarks.Length + 7;
            arrayDescription = _dt.Rows[0]["Description"].ToString().Split('\n');
            int intDescCount = arrayDescription.Length;





            int RowMx = 470;

            int TotalLine = 0;
            int ColumnCountMrks = 8;
            ColumnCountMrks = arrayMarks.Length;
            TotalLine = 8;
            for (int LineX = 0; LineX < TotalLine; LineX++)
            {
                if (arrayMarks.Length >= LineX + 1)

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayMarks[LineX].ToUpper(), 25, RowMx, 0);
                RowMx -= 10;
            }

            RowMx -= 20;

            TotalLine = 4;
            DataTable _dtCntr = GetContainerDetails(BLID);
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




            int RowDec = 460;

            TotalLine = 15;

            for (int LineX = 0; LineX < TotalLine; LineX++)
            {
                if (arrayDescription.Length >= LineX + 1)

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayDescription[LineX], 270, RowDec, 0);
                RowDec -= 10;
            }

            BaseFont bfheader25 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader25, 8);
            cb.SetColorFill(new iTextSharp.text.BaseColor(0, 0, 128));
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Excess Value Declaration Refer to Clause 6 (3) (B) + (C)", 15, 245, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "on reverse side", 15, 235, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FREIGHT: " + _dt.Rows[0]["FreightPayment"].ToString(), 270, 265, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["intFreedays"].ToString() + '-' + _dt.Rows[0]["ddlFreeday"].ToString(), 270, 250, 0);
            if (_dt.Rows[0]["ddlFreeday"].ToString() != "")
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["intFreedays"].ToString() + '-' + _dt.Rows[0]["ddlFreeday"].ToString(), 270, 250, 0);
            }
            else
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 270, 250, 0);
            }
            if (arrayDescription.Length > 16)
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Continuity as Per Annexure Attached", 270, 235, 0);
            }

            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 6);
            cb.SetColorFill(new iTextSharp.text.BaseColor(0, 0, 128));
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "The term carriage by sea by defenition being the transport of goods, merchandise or their", 15, 210, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "packing inclusive of containers and/or goods of any type between one port and another port,", 15, 201, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "the carrier is not and shall not be responsible for:", 15, 192, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "a)     Any damage occasioned to the goods arising out of or in relation to the loading", 15, 172, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "       and unloading of containers and/or goods on or off the vessel; and/or", 15, 163, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "b)     Any damage to containers and/or goods before the loading and after the", 15, 154, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "       unloading of the said containers and/or goods from the vessel.", 15, 145, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "c)     Any damage caused to containers and/or goods of board the vessel by the other", 15, 136, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "       container in the course of loading or unloading of those other containers and/or", 15, 127, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "       goods on board the vessel by stevedores. And/or", 15, 118, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "d)     Any damage caused to containers and/or goods prior to the loading and", 15, 109, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "       subsequent to the unloading of other containers and/or goods arising out of the", 15, 100, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "       vessel’s ancillary equipment (or any part thereof) coming into contact with the", 15, 91, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "       said Containers and/or goods lying on the quayside should the said containers", 15, 82, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "       and/or goods to be stacked one on top of the other or improperly arranged on the", 15, 73, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "       quayside.", 15, 64, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "e)     Any mis-information on the import General Manifest and re-export of import", 15, 55, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "       containers and/or goods and where appropriate, the merchant shall furnish", 15, 46, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "       guarantees to the Carrier’s agent if there is any breach.", 15, 37, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Received by the carrier the Goods as specified above in apparent good order and conditions", 355, 210, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "unless otherwise stated, to be trnspoted to such place agreed, authoried or permitted", 355, 201, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "herein and subject to all the terms and conditions appearing on the front and reverse of this", 355, 192, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Bill of Lading to which the Merchant agrees by accepting this Bill of Lading, any local", 355, 183, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "privilages and customs notwithstanding. The particulars given above are as stated by the", 355, 174, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "shipper and the weight, measure, quantity, condition, contents and value of the Goods are", 355, 165, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "unknown to the carrier.", 355, 156, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "In WITNESS whereof one (1) original Bill of Lading has been signed if not otherwise stated", 355, 147, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "above, the same being accomplished, the other(s), if any, to be void. One (1) original Bill of", 355, 138, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Lading must be surrendered duly endorsed in exchange for the Goods or delivery order", 355, 130, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipped on Board Date", 355, 115, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place and Date of issue", 355, 95, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Signed on behalf of the Carrier - Oceanus Container Lines Pte. Ltd.   :", 355, 80, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "By", 355, 60, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "As Agent", 355, 40, 0);
            //cb.MoveTo(450, 110);
            //cb.LineTo(650, 110);

            //cb.MoveTo(450, 90);
            //cb.LineTo(650, 90);


            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["SOBDatev"].ToString(), 460, 120, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dt.Rows[0]["IssuedAt"].ToString() + "   &  " + _dt.Rows[0]["BlDatev"].ToString(), 460, 100, 0);



            cb.EndText();
            //cb.Stroke();
            
            doc.Close();
            writer.Close();
            pdfmp.AddFile(_FileName + ".pdf");

            //Largest  array number
            int[] arr = { arrayDescription.Length, intMarkCount, _dtCntrValues.Length + 10 };
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }

            // int TotalColumn = (_dt.Rows.Count < arrayDescription.Length) ? intMarkCount : intMarkCount;
            int TotalColumn = max;
            int WriteLine = TotalColumn - TotalLine;
            int AttachedsheetNo = int.Parse(Math.Ceiling((WriteLine / 80.00)).ToString());
            int Cot = 0;
            //int LineCount = 15 + Cot;
            int LineCount = Cot;
            int SheetNo = 1;
            string Filesv = "Attach" + BLID;
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

                Attcb.BeginText();
                BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bfheader, 14);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 300, 820, 0);
                //iTextSharp.text.Image png11 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/assets/img/pdfhead.jpg"));
                //png11.SetAbsolutePosition(15, 837);
                //png11.ScalePercent(60f);
                //Attdocument.Add(png11);

                //iTextSharp.text.Image png21 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/assets/img/oclheader.jpg"));
                //png21.SetAbsolutePosition(320, 835);
                //png21.ScalePercent(52f);
                //Attdocument.Add(png21);

                BaseFont bfheader211 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Attcb.SetFontAndSize(bfheader211, 23);
                Attcb.SetColorFill(new iTextSharp.text.BaseColor(0, 0, 128));
                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Oceanus Container Lines Pvt.Ltd", 280, 870, 0);


                BaseFont bfheader222 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Attcb.SetFontAndSize(bfheader222, 8);
                Attcb.SetColorFill(new iTextSharp.text.BaseColor(0, 0, 128));
                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BILL OF LADING FOR COMBINED TRANSPORT SHIPMENT OR", 280, 850, 0);
                //Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PORT TO PORT SHIPMENT NOT NEGOTIABLE UNLESS CONSIGNED 'TO ORDER''", 280, 835, 0);
                //Attcb.SetColorStroke(new iTextSharp.text.BaseColor(0, 0, 128));


                //#region Border
                //Attcb.MoveTo(15, 825);
                //Attcb.LineTo(650, 825);
                //Attcb.MoveTo(15, 805);
                //Attcb.LineTo(650, 805);

                //Attcb.Stroke();
                //#endregion

                

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

                if (LineX <= 70)
                {

                    for (int Lines = LCntrindex; Lines < _dtCntrValues.Length; Lines++)
                    {
                        //var arrayCntrNov = _dtCntr.Rows[Lines]["CntrDtls"].ToString().Split('\n');
                        if (_dtCntrValues.Length >= LCntrindex + 1)
                        {
                            var arrayCntrNov = SplitByLenght(_dtCntrValues[Lines].ToString(), 30);
                            for (int d = 0; d < arrayCntrNov.Length; d++)
                            {
                                Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayCntrNov[d].ToUpper(), 230, 780 - deffcntr, 0);
                                deffcntr += 10;
                            }
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

                            Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayMarks[Lines], 20, 780 - deffMark, 0);

                        deffMark += 10;
                        Cot++;
                        LineMark++;
                        if (LineMark == 70)
                        {
                            LMarkindex += LineMark;
                            break;
                        }
                    }



                    for (int Lines = LIndex; Lines < arrayDescription.Length; Lines++)
                    {
                        if (arrayDescription.Length >= TotalLine + 1)

                            Attcb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, arrayDescription[Lines], 400, 780 - DeffLine, 0);

                        DeffLine += 10;
                        Cot++;
                        LineX++;
                        if (LineX == 70)
                        {
                            /// LIndex += LineX - 13;
                            LIndex += LineX;
                            break;
                        }
                    }

                    int DeferentLine = (DeffLine < deffMark) ? deffcntr : deffcntr;
                    DataTable _dtns = GetNotes(BLID);
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
                //Attcb.Stroke();
                int RowColm = 770 - DeffLine;

                LineCount += Cot;


                Attcb.EndText();
                Attdocument.Close();
                Attwriter.Close();
                pdfmp.AddFile(_AttFileName + SheetNo + ".pdf");
                SheetNo++;
            }



            pdfmp.Execute();
            string str = FileHidpath;
            //string mime = MimeMapping.GetMimeMapping(FileHidpath);
            WebClient client = new WebClient();
            byte[] thePdf = client.DownloadData(FileHidpath);
            return File(thePdf, "application/pdf");
            //return File(FileHidpath, mime);

        }




        [HttpGet, DisableRequestSizeLimit]
        [Route("AquaticPrintPDF")]
        public async Task<FileResult> CROPrintPDF([FromQuery] string AqID)
        {
            MemoryStream workStream = new MemoryStream();
            string id = "69";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            string strPDFFileName = string.Format("CustomerDetailPdf" + "-" + ".pdf");
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
           
            MergeEx pdfmp = new MergeEx();


            PdfWriter writer = PdfWriter.GetInstance(doc, workStream);



            doc.Open();

            PdfContentByte cb = writer.DirectContent;
            cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
            int _Xp = 10, _Yp = 785, YDiff = 10;

            BaseFont bfheader = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader, 14);


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

            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("UploadFolder/BLLogos/aquatic.png"));
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
       



            writer.CloseStream = false;
            doc.Close();
            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return File(workStream, "application/pdf", strPDFFileName);
        }





        //        [HttpPost("AquaticPrintPDF")]
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



        //            doc.Open();

        //            PdfContentByte cb = writer.DirectContent;
        //            cb.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
        //            int _Xp = 10, _Yp = 785, YDiff = 10;

        //            BaseFont bfheader = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //            cb.SetFontAndSize(bfheader, 14);


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
            string _Query = " Select(select top(1) CntrNo from NVO_Containers where Id = NVO_BOLCntrDetails.CntrID) + '/ ' + size + '/ ' + SealNo + '/ \n/' + convert(varchar, convert(decimal(8, 3), GrsWt)) + ' - ' + (case when GrsWtType = 1 then 'KGS' else 'MT' end) + '/' + convert(varchar, convert(decimal(8, 3), NtWt))  + '- ' + (case when NtWtType = 1 then 'KGS' else 'MT' end) + '/' + convert(varchar, convert(decimal(8, 3), CBM)) + 'CBM' as CntrDtls from NVO_BOLCntrDetails where BLID = 260";

            return Manag.GetViewData(_Query, "");
        }

        public DataTable GetNotes(string BLID)
        {
            string _Query = "select Notes from NVO_BLNotesClauses inner join NVO_BOL on NVO_BOL.PODID=NVO_BLNotesClauses.PortID where Id=260";

            return Manag.GetViewData(_Query, "");
        }



        //public DataTable GetBkgCustomer(string BLID)
        //{
        //    string _Query = " select convert(varchar,BlDate, 103) as BlDatev,convert(varchar,SOBDate, 103) as SOBDatev,(SELECT top(1) NoofOriginal FROM NVO_BOL  where Id = NVO_BLRelease.BLID) as NoofOriginal,(select top(1) Notes from NVO_BLNotesClauses where DocID= 264 and NID=11) as ddlFreeday," +
        //        " (select top (1) case when GrsWtType=1 then 'KGS' else case when GrsWtType=2 then 'MT' end end from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID= NVO_BLRelease.BLID)  as GrsWtType, " +
        //        " (select top(1) case when NtWtType = 1 then 'KGS' else case when NtWtType = 2 then 'MT' end end  from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID = NVO_BLRelease.BLID) as NtWtType, " +
        //        " (select top(1) (select top(1) PkgDescription from NVO_CargoPkgMaster where NVO_CargoPkgMaster.Id = PakgType) from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID= NVO_BLRelease.BLID) as CargoPakage, * from NVO_BLRelease  where BLID=69";
        //    return Manag.GetViewData(_Query, "");
        //}


        //public DataTable GetContainerDetails(string BLID)
        //{
        //    string _Query = " Select(select top(1) CntrNo from NVO_Containers where Id = NVO_BOLCntrDetails.CntrID) + '/ ' + size + '/ ' + SealNo + '/ \n/' + convert(varchar, convert(decimal(8, 3), GrsWt)) + ' - ' + (case when GrsWtType = 1 then 'KGS' else 'MT' end) + '/' + convert(varchar, convert(decimal(8, 3), NtWt))  + '- ' + (case when NtWtType = 1 then 'KGS' else 'MT' end) + '/' + convert(varchar, convert(decimal(8, 3), CBM)) + 'CBM' as CntrDtls from NVO_BOLCntrDetails where BLID = 69";

        //    return Manag.GetViewData(_Query, "");
        //}

        //public DataTable GetNotes(string BLID)
        //{
        //    string _Query = "select Notes from NVO_BLNotesClauses inner join NVO_BOL on NVO_BOL.PODID=NVO_BLNotesClauses.PortID where Id=69";

        //    return Manag.GetViewData(_Query, "");
        //}
    }
}
