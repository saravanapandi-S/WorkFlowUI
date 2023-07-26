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
    public class CargoPlanPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public CargoPlanPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("CargoPlanPrintPDF")]
        public List<MyCountry> BLPrintPDF(MyCountry Data)
        {
            string id = "69";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//cargoplan/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            string FileHidpath = "ClientApp//src//assets//pdfFiles//cargoplan/Multiple-BL.pdf";

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
            //iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/bss.png"));
            //png1.SetAbsolutePosition(380, 760);
            //png1.ScalePercent(77f);
            //doc.Add(png1);

            BaseFont Crossbfheader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.SetFontAndSize(Crossbfheader, 90);
            //Top1
            cb.MoveTo(10, 848);
            cb.LineTo(660, 848);
            //Top2
            cb.MoveTo(10, 828);
            cb.LineTo(660, 828);

            //Center
            cb.MoveTo(330, 828);
            cb.LineTo(330, 528);

            //LeftLine1
            cb.MoveTo(10, 700);
            cb.LineTo(330, 700);

            //RightLine1
            cb.MoveTo(330, 728);
            cb.LineTo(660, 728);

            //RightLine2
            cb.MoveTo(330, 628);
            cb.LineTo(660, 628);


            //HorizontalLine2
            cb.MoveTo(10, 528);
            cb.LineTo(660, 528);

            //HorizontalLine3
            cb.MoveTo(10, 488);
            cb.LineTo(660, 488);

            //HorizontalLine4
            cb.MoveTo(10, 448);
            cb.LineTo(660, 448);

            //HorizontalLine5
            cb.MoveTo(10, 428);
            cb.LineTo(660, 428);

            //HorizontalLine6
            cb.MoveTo(10, 228);
            cb.LineTo(660, 228);

            //HorizontalLine7
            cb.MoveTo(10, 208);
            cb.LineTo(660, 208);

            //HorizontalLine8
            cb.MoveTo(10, 188);
            cb.LineTo(660, 188);


            //HorizontalLine10
            cb.MoveTo(10, 8);
            cb.LineTo(660, 8);

            //dividline1
            cb.MoveTo(160, 528);
            cb.LineTo(160, 448);

            //dividline2
            cb.MoveTo(490, 528);
            cb.LineTo(490, 448);

            //desdivide1
            cb.MoveTo(160, 428);
            cb.LineTo(160, 228);

            cb.MoveTo(460, 428);
            cb.LineTo(460, 228);

            cb.MoveTo(560, 428);
            cb.LineTo(560, 228);

            cb.MoveTo(430, 188);
            cb.LineTo(430, 8);

            cb.MoveTo(435, 28);
            cb.LineTo(655, 28);


            cb.Stroke();
            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BILL OF LADING NO", 15, 834, 0);
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
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Bill/Lading Number", 15, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CPNSAHMD1904002", 150, 818, 0);
            cb.EndText();

            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/cargoplan.jpg"));
            png1.SetAbsolutePosition(50, 730);
            png1.ScalePercent(70f);
            doc.Add(png1);

            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Delivery Agent Address:", 15, 690, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 678, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper", 335, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 335, 806, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee (or order)", 335, 718, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 335, 706, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Party", 335, 618, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 335, 606, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Vessel Voyage", 15, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 506, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Terms", 165, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 165, 506, 0);          
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt", 15, 478, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 466, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 165, 478, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 466, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "No of Original B/L", 335, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 335, 506, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place and Date of Issue", 495, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 495, 506, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Discharge", 335, 478, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 335, 466, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Final Delivery", 495, 478, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 495, 466, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PARTICULAR FURNISHED BY SHIPPER(CARGO NOT CHECKED BY CARRIER)", 15, 434, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No./Seal No.", 15, 418, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Marks & Numbers", 15, 408, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Description of goods", 165, 418, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "No of Packages", 465, 418, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Measurement", 465, 408, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FREIGHT", 465, 328, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SHIPPED ON BOARD", 465, 308, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "17-Apr-2019", 465, 298, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross. Weight", 565, 418, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 565, 398, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "KGS", 565, 388, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NET WT", 565, 368, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 565, 358, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "KGS", 565, 348, 0);

            
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Details Continued on attached Sheet......", 200, 238, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader6 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader6, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Combined Transport Bill of Lading Not Negotiable Unless Consigned To OFF", 15, 218, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "** Applicable In case the bill of lading issued as combined transport Bill of Lading", 15, 198, 0);
            cb.EndText();
           int ColumnRows = 178;
           int RowsColumn = 0;

            int ColumnRows1 = 100;
            int RowsColumn1 = 0;

            cb.BeginText();
            BaseFont bfheader7 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader7, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);


            string text = @"Received by the carrier the goods as specified above in apparent good order and condition unless otherwise stated, 
to be transported to such place as agreed,authorized or permitted herein and subject to all the terms and conditions 
appearing on the front and reverse of this bill of lading to which the merchant agrees by accepting the bill of 
lading,any local privileges and customs notwithstanding
The particulars given above as stated by the shipper and the weight,measure,quality,condition,contents and value 
of the goods are unknown to the carrier.
In WITNESS whereof on (1) original bill of lading has been signed if not otherwise stated above the same being 
accomplished the other(s),if any,to be void, if required by the carrier one(1) original bill of lading must be surrendered 
duly endorsed in exchange for the goods or delivery order";
            string[] Arrayterms = Regex.Split(text, char.ConvertFromUtf32(13));
            string[] Addsplit1;

            for (int x = 0; x < Arrayterms.Length; x++)
            {
                Addsplit1 = Arrayterms[x].Split('\n');

                for (int k = 0; k < Addsplit1.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Addsplit1[k].ToString(), 15, ColumnRows, 0);
                    ColumnRows -= 4;
                    RowsColumn++;
                }
            }

            string text1 = @"LIMITAION ON CARRIERS LIABILITY/SHIPPERS AD VALOREM OPTION. The Carrier shall in no event be or 
become liable for any loss or damage to or in connection with the transportaion of goods in an amount Exceeding US 
$500 per package. or in the case of goods not shipped in packages per customary freight nit or the equivalent of that 
sum in other currency (or such other limitaion imposed by a carriage of goods by a sea act, statue or law in force 
according to the provision hereof )unless the nature and value of goods have been declared by the merchant before 
shipping and inserted in the bill of lading such declaration of value shall not however, be conclusive on the carrier for 
purposes of determining the extent of the carriers liability.if the merchant desires to be covered for a valuation in 
excess of said us $5500 per package or customary freight unitor any other applicable limitaion the merchant must so 
stipulate in this bill of lading and such additional liabilty, only will be assumed by the carrier upon payment of the 
carriers ad valorem freigh charge.";
            string[] Arrayterms1 = Regex.Split(text1, char.ConvertFromUtf32(13));
            string[] Addsplit2;

            for (int x = 0; x < Arrayterms1.Length; x++)
            {
                Addsplit2 = Arrayterms1[x].Split('\n');

                for (int k = 0; k < Addsplit2.Length; k++)
                {

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Addsplit2[k].ToString(), 15, ColumnRows1, 0);
                    ColumnRows1 -= 4;
                    RowsColumn1++;
                }
            }

            cb.EndText();

            cb.BeginText();
            BaseFont bfheader8 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader8, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Signed on Behalf of Carrier", 435, 178, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "AS AGENT", 520, 18, 0);
            cb.EndText();

            cb.Stroke();
            doc.Close();
            pdfmp.AddFile(FileNamev + ".pdf");


          
            pdfmp.Execute();
            string str = FileHidpath;
            string mime = pdfpath;
            ViewList.Add(new MyCountry
            {
                cargoplanFilename = FileNamev
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
