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
    public class USLPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public USLPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("USLPrintPDF")]
        public List<MyCountry> BLPrintPDF(MyCountry Data)
        {
            string id = "69";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//usl/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            string FileHidpath = "ClientApp//src//assets//pdfFiles//usl/Multiple-BL.pdf";

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

            //BorderLeft
            cb.MoveTo(10, 810);
            cb.LineTo(10, 10);

            //BorderRight
            cb.MoveTo(660,810);
            cb.LineTo(660,10);

            //Center1
            cb.MoveTo(360, 810);
            cb.LineTo(360, 545);

            //Center2
            cb.MoveTo(360, 295);
            cb.LineTo(360, 75);

            //Line1
            cb.MoveTo(10, 810);
            cb.LineTo(660, 810);

            ////Line2
            //cb.MoveTo(10, 745);
            //cb.LineTo(660, 745);

            //Line3
            cb.MoveTo(10, 615);
            cb.LineTo(660, 615);

            //Line4
            cb.MoveTo(10, 580);
            cb.LineTo(660, 580);

            //Line5
            cb.MoveTo(10, 545);
            cb.LineTo(660, 545);

            //Line6
            cb.MoveTo(10, 525);
            cb.LineTo(660, 525);

            //Line7
            cb.MoveTo(10, 295);
            cb.LineTo(660, 295);

            //Line8
            cb.MoveTo(10, 145);
            cb.LineTo(660, 145);

            //Line9
            cb.MoveTo(10, 75);
            cb.LineTo(660, 75);

            //Line10
            cb.MoveTo(10, 10);
            cb.LineTo(660, 10);

            //HorizontalLine1
            cb.MoveTo(360, 790);
            cb.LineTo(660, 790);

            //HorizontalLine2
            cb.MoveTo(10, 745);
            cb.LineTo(360, 745);

            //HorizontalLine3
            cb.MoveTo(10, 680);
            cb.LineTo(360, 680);

            //HorizontalLine4
            cb.MoveTo(360, 700);
            cb.LineTo(660, 700);

            //HorizontalLine5
            cb.MoveTo(360, 115);
            cb.LineTo(660, 115);

            //VerticalLine1
            cb.MoveTo(180, 615);
            cb.LineTo(180, 295);

            //VerticalLine2
            cb.MoveTo(510, 615);
            cb.LineTo(510, 545);



            cb.Stroke();
            cb.BeginText();
            BaseFont bfheader0 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader0, 14);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "COMBINED TRANSPORT BILL OF LADDING", 180, 820, 0);
            cb.EndText();
            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marks and Nos/Container No./Seal No.", 15, 533, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number and kind of packages;description of goods", 190, 533, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross Weight", 510, 533, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Measurement", 590, 533, 0);
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
            cb.SetFontAndSize(bfheader3, 5);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "(Unless provided otherwise, a consignment 'To Order' means To Order of Shipper)", 55, 735, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "(Name/Full address-It is agreedthat no responsibility shall attach to the carrier or agent for failure to notify)", 55, 670, 0);
            cb.EndText();

            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/usl.png"));
            png1.SetAbsolutePosition(390, 710);
            png1.ScalePercent(40f);
            doc.Add(png1);

            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B/L No.", 365, 800, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Delivery Agent's Address:", 365, 690, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 15, 800, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee", 15, 735, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Party", 15, 670, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt", 15, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 190, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Discharge", 370, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Placeof Delivery", 520, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel/Voy. No.", 15, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Terms of Shipment", 190, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number of Original Bs/L", 370, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Payable at", 520, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Particulars Furnished by Shipper-Carrier Not Responsible", 190, 515, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Details:", 15, 285, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place and Date of Issue:", 370, 135, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Signed for the Carrier UNIVERSAL STAR SHIPPING LINE LLC", 370, 105, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NOT NEGOTIABLE UNLESS CONSIGNED 'TO ORDER'", 15, 65, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "By:", 370, 65, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "As Agents", 370, 20, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Signed for the carrier AQUATIC LINE", 420, 40, 0);
            cb.EndText();


            int ColumnRows = 285;
            int RowsColumn = 0;

            cb.BeginText();
            BaseFont bfheader8 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader8, 6);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);


            string text = @"RECEIVED by the Carrier from the Shipper in apparent good order and condition (unless
otherwise noted herein) the total number quantity of containers or other packages or unit
indicated in the box opposite entitled. Total No. of containers/packages received by the carrier*
for carriage subject to all the terms and conditions hereof (INCLUDING THE TERMS AND
CONDITIONS ON THE REVERSE HEREOF AND THE TERMS AND CONDITIONS OF THE 
CARRIER'S APPLICABLE TARIFF) from the Place of Receipt or the Port of Loading,
whichever is applicable, to the Port of Discharge or the Place of Delivery, whichever is
applicable. One original Bill of Lading, duly endorsed,must be surrendered by the merchant
to the carrier in exchange for the goods or a delivery order. In accepting this Bill of Lading the
Merchant expressly accepts and agrees to all its terms and conditions whether printed,
stamped or written, or otherwise incorporated, notwithstanding the non-signing of this Bill of
lading by the Merchant.
IN WITNESS WHEREOF the number of original Bills of lading stated below all of this tenor
and date has been signed, one of which being accomplished the others to stand void.";
            string[] Arrayterms = Regex.Split(text, char.ConvertFromUtf32(13));
            string[] Addsplit1;

            for (int x = 0; x < Arrayterms.Length; x++)
            {
                Addsplit1 = Arrayterms[x].Split('\n');

                for (int k = 0; k < Addsplit1.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Addsplit1[k].ToString(), 370, ColumnRows, 0);
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
                uslFilename = FileNamev
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
