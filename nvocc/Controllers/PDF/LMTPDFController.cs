﻿using Microsoft.AspNetCore.Mvc;
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
    public class LMTPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public LMTPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("LMTPrintPDF")]
        public List<MyCountry> BLPrintPDF(MyCountry Data)
        {
            string id = "69";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//lmt/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            string FileHidpath = "ClientApp//src//assets//pdfFiles//lmt/Multiple-BL.pdf";

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
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 300, 820, 0);
            //iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/bss.png"));
            //png1.SetAbsolutePosition(380, 760);
            //png1.ScalePercent(77f);
            //doc.Add(png1);

            BaseFont Crossbfheader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.SetFontAndSize(Crossbfheader, 90);


            //Center
            cb.MoveTo(330, 295);
            cb.LineTo(330, 120);

            //Line1
            cb.MoveTo(10, 540);
            cb.LineTo(660, 540);

            //Line2
            cb.MoveTo(10, 525);
            cb.LineTo(660, 525);

            //Line3
            cb.MoveTo(10, 295);
            cb.LineTo(660, 295);

            //Line4
            cb.MoveTo(10, 120);
            cb.LineTo(660, 120);
                       

            //HorizontalLine1
            cb.MoveTo(10, 840);
            cb.LineTo(330, 840);

            //HorizontalLine2
            cb.MoveTo(10, 770);
            cb.LineTo(330, 770);

            //HorizontalLine3
            cb.MoveTo(10, 700);
            cb.LineTo(330, 700);

            //HorizontalLine4
            cb.MoveTo(10, 630);
            cb.LineTo(330, 630);

            //HorizontalLine5
            cb.MoveTo(10, 600);
            cb.LineTo(330, 600);

            //HorizontalLine6
            cb.MoveTo(10, 570);
            cb.LineTo(330, 570);

            //HorizontalLine7
            cb.MoveTo(10, 265);
            cb.LineTo(330, 265);

            //HorizontalLine8
            cb.MoveTo(10, 150);
            cb.LineTo(330, 150);

            //HorizontalLine9
            cb.MoveTo(230, 90);
            cb.LineTo(660, 90);

            //HorizontalLine10
            cb.MoveTo(470, 40);
            cb.LineTo(660, 40);

            //HorizontalLine10
            cb.MoveTo(470, 30);
            cb.LineTo(660, 30);


            //VerticalLine1
            cb.MoveTo(165, 540);
            cb.LineTo(165, 295);

            //VerticalLine2
            cb.MoveTo(10, 295);
            cb.LineTo(10, 120);

            //VerticalLine3
            cb.MoveTo(660, 295);
            cb.LineTo(660, 120);

            //VerticalLine3
            cb.MoveTo(230, 120);
            cb.LineTo(230, 40);

            //VerticalLine3
            cb.MoveTo(430, 120);
            cb.LineTo(430, 40);




            cb.Stroke();
            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 15);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "COMBINED TRANSPORT BILL OF LADING", 15, 845, 0);
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
            cb.SetFontAndSize(bfheader3, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B/L No.", 470, 830, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Reference No", 470, 800, 0);
            cb.EndText();

            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/lmt.png"));
            png1.SetAbsolutePosition(470, 690);
            png1.ScalePercent(35f);
            doc.Add(png1);

            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 15, 830, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee", 15, 760, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Party", 15, 690, 0);            
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Pre-carriage by*", 15, 620, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt by pre-carrier*", 175, 620, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel/Voy. No.", 15, 590, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 175, 590, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Discharge", 15, 560, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Delivery by pre-carrier*", 175, 560, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marks and Nos/Container No/Seal No", 15, 515, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number and kind of packages; description of goods", 175, 515, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross weight", 505, 515, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Measurement", 585, 515, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total Number of Containers:", 20, 285, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Charges:", 20, 250, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Origin Land Haulage...................................................", 20, 235, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Origin Port Service......................................................", 20, 225, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Ocean Freight...............................................................", 20, 215, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Destination Port Service.............................................", 20, 205, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Destination Land Haulage..........................................", 20, 195, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Daily Demurrage rate (additional Clause A)", 20, 140, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "* Applicable only when document used as a Through", 15, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Bill of Ladding", 15, 100, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight payable at", 240, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place and date of issue", 440, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number of original B/Ls", 240, 80, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Signed for the Carrier LMT-Lloyds Maritime", 440, 80, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "& Trading Ltd./Hong Kong", 440, 70, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "By:", 455, 40, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "As Agents", 470, 20, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CARRIER'S RECEIPT", 15, 530, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PARTICULARS FURNISHED BY SHIPPER-CARRIER NOTE RESPONSIBLE", 175, 530, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader6 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader6, 13);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "LLOYDS MARITIME & TRADING LTD.", 390, 680, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "HONG KONG", 460, 665, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader7 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader7, 5);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "(Unless provided otherwise, a consignment 'TO ORDER' means to Order of Shipper)", 60, 760, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "(Name/Full Address-It is agreed thatno responsibility shall attach to the carrier or agent for failure to Notify)", 65, 690, 0);
            cb.EndText();


            int ColumnRows = 220;
            int RowsColumn = 0;

            int ColumnRows1 = 100;
            int RowsColumn1 = 0;

            //            cb.BeginText();
            //            BaseFont bfheader8 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //            cb.SetFontAndSize(bfheader8, 5);
            //            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);


            //            string text = @"RECEIVED by the Carrier the Goods as specified below in apparent good order and condition unless otherwise stated to be 
            //transported to such place as agreed,authorised or permitted here in and subject to all terms and conditions appearing on the front 
            //and reverse of this Bill of Lading to which the Merchant agrees by accepting this Bill of Lading , any local privileges and customes 
            //not withstanding.The particulars given below as stated by the Shipper and the weight,measure,quantity,condition,contents and the 
            //value of Goods are unknown to the Carrier.
            //In WITNESS where of one (3) original Bill of Lading has been signed if not otherwise stated here after ,the same being 
            //accomplished the other(s).if any,to be void,if required by the Carrier one (1)original Bill of Lading must be surrendered duly 
            //endorsed in exchange for Goods or Delivery Order.
            //LIMITATION ON CARRIERS LIABILITY /SHIPPERS AD VALOREM OPTION.the carrier shall in no event be or become liable 
            //for any loss of damage to or in connection.with the transportaion of goods in an amount exceeding us$500 per package, or in the 
            //case of goods not shipped in packages per customary freight nit or the equivalent of that sum in other currency (or such other 
            //limitaion imposed by a carriage of goods by sea act,statue or law in force according to the provisions hereof )unless the nature 
            //and value of such goods have been declared by the merchant before shipment and inserted in the bill of lading such declaration 
            //of value shall not however, be conclusive on the carrier for purpuse of determining the extent of the carrier liability.if the 
            //merchant desires to be covered for a valuation in excess of said us $5500 per package or customary freight unitor any other 
            //applicable limitaion the merchant must so stipulate in this bill of lading and such additional liability only will be assumed by the 
            //carrier upon payment of the carriers ad valorem freigh charge ....................................................
            //declared cargo values if merchant enters a value carriers limitaion of liabilty shall not apply";
            //            string[] Arrayterms = Regex.Split(text, char.ConvertFromUtf32(13));
            //            string[] Addsplit1;

            //            for (int x = 0; x < Arrayterms.Length; x++)
            //            {
            //                Addsplit1 = Arrayterms[x].Split('\n');

            //                for (int k = 0; k < Addsplit1.Length; k++)
            //                {

            //                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Addsplit1[k].ToString(), 335, ColumnRows, 0);
            //                    ColumnRows -= 4;
            //                    RowsColumn++;
            //                }
            //            }
            //            cb.EndText();

            cb.Stroke();
            doc.Close();
            pdfmp.AddFile(FileNamev + ".pdf");



            pdfmp.Execute();
            string str = FileHidpath;
            string mime = pdfpath;
            ViewList.Add(new MyCountry
            {
                lmtFilename = FileNamev
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
