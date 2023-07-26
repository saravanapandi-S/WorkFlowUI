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
    public class MerchantPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public MerchantPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("MerchantPrintPDF")]
        public List<MyCountry> BLPrintPDF(MyCountry Data)
        {
            string id = "69";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//merchant/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            string FileHidpath = "ClientApp//src//assets//pdfFiles//merchant/Multiple-BL.pdf";

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
            //Top1
            cb.MoveTo(10, 828);
            cb.LineTo(330, 828);

            cb.MoveTo(520, 828);
            cb.LineTo(520, 798);

            cb.MoveTo(520, 828);
            cb.LineTo(660, 828);

            //Top2
            //cb.MoveTo(10, 728);
            //cb.LineTo(660, 728);

            //Center
            cb.MoveTo(330, 828);
            cb.LineTo(330, 428);

            //LeftLine1
            cb.MoveTo(10, 628);
            cb.LineTo(330, 628);

            //LeftLine2
            cb.MoveTo(10, 528);
            cb.LineTo(330, 528);

            //Horizontal3
            cb.MoveTo(10, 428);
            cb.LineTo(660, 428);

            //LeftLine4
            cb.MoveTo(10, 460);
            cb.LineTo(330, 460);

            //LeftLine5
            cb.MoveTo(10, 494);
            cb.LineTo(330, 494);

            //RightLine1
            //cb.MoveTo(330, 808);
            //cb.LineTo(660, 808);

           

            //Horizontal4
            //cb.MoveTo(420, 828);
            //cb.LineTo(420, 808);

            //Horizontal5
            cb.MoveTo(10, 230);
            cb.LineTo(660, 230);

           

            //leftborder1
           

            //Horizontal7
            cb.MoveTo(15, 8);
            cb.LineTo(330, 8);

            //Horizontal8
            cb.MoveTo(330, 70);
            cb.LineTo(500, 70);

            cb.MoveTo(330, 30);
            cb.LineTo(500, 30);

            //cb.MoveTo(330, 30);
            //cb.LineTo(330, 30);

           

            cb.MoveTo(10, 120);
            cb.LineTo(660, 120);

            cb.MoveTo(330, 90);
            cb.LineTo(660, 90);

            cb.MoveTo(330, 60);
            cb.LineTo(660, 60);

            cb.MoveTo(10, 30);
            cb.LineTo(660, 30);

            cb.MoveTo(330, 120);
            cb.LineTo(330, 30);




            cb.Stroke();
            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BILL OF LADING", 335, 818, 0);
            

            cb.EndText();
            cb.BeginText();
            BaseFont bfheader41 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader41, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FOR COMBINED TRANSPORT", 335, 808, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SHIPMENT OR PORT TO PORT", 335, 798, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SHIPMENT NOT NEGOTIABLE ", 335, 788, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "UNLESS CONSIGNED 'TO ORDER'", 335, 778, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Bill of lading Number", 525, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Bill of lading Number", 525, 808, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 10);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NON-NEGOTIABLE", 450, 438, 0);
          
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
            //cb.BeginText();
            //BaseFont bfheader3 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //cb.SetFontAndSize(bfheader3, 9);
            //cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BOOKING NO", 335, 818, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CPNSAHMD1904002", 425, 818, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "EXPORT Reference ", 385, 798, 0);
            //cb.EndText();

            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/merchant.png"));
            png1.SetAbsolutePosition(335, 560);
            png1.ScalePercent(70f);
            doc.Add(png1);

            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SHIPPER/EXPORTER", 15, 818, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 806, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consigned To", 15, 718, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 706, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NOTIFY PARTY/INTERMEDIATE CONSIGNEE", 15, 618, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 606, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PRE-CARRIAGE BY", 15, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 506, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt", 205, 518, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 205, 506, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CARRIAGE/VYAGE NO", 15, 484, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 472, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PORT OF LOADING", 205, 484, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 205, 472, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PORT OF DISCHARGE", 15, 450, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 15, 438, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FINAL DESTINATION", 205, 450, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 205, 438, 0);

            
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "MARKS AND NUMBERS", 15, 408, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NO.OF.PKGS", 150, 408, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DESCRIPTION OF PACKAGES AND GOODS", 260, 408, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "GROSS WEIGHT", 480, 408, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "MEASUREMENT", 580, 408, 0);



            cb.EndText();

            cb.BeginText();
            BaseFont bfheader51 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader51, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DETAILS CONTINUED ON ATTACHED SHEET", 250, 250, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader6 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader6, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ABOVE PARTICULARS AS DECLARED BY SHIPPER-CARRIER NOT RESPONSIBLE - SUBJECT TO OTHER TERMS & CONDITIONS AS ON REVERSE", 40, 240, 0);

            cb.EndText();
            cb.BeginText();
            BaseFont bfheader7 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader7, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Destination/Delivery Agent", 15, 220, 0);

            cb.EndText();
            int ColumnRows = 220;
            int RowsColumn = 0;

   
            cb.BeginText();
            BaseFont bfheader8 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader8, 5);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);


            string text = @"Received in good order and condition, unless otherwise noted herein, at the place of receipt for transport and delivery as mentioned above. The Particulars as stated above by shipper and the weight, measure, quantity, condition, contents and value of Goods are unknown to the Carrier. Quality, 
quantity and nature of the cargo stuffed inside the container by the shipper is unknown to the carrier. One of these Combined Transport Bill of Lading must be surrendered duly endorsed in exchange for the goods. IN WITNESS whereof the original Combined Transport Bills of Lading 
all of this tenor and date have been signed in the number stated below one of which being accomplished and the other (s) to be void. The contract evidenced by or contained in this bill of lading is governed by the law of pakistan and any claim dispute arising hereunder or in connection
herewith shall be determined by the courts in pakistan and no other courts. Cargo insurance not provided by the Carriers. In case subject shipment is not loaded on vessel named aforesaid for any reason / is not cleared / claimed by the consignee and cargo is abandonded at destination or 
cargo is mis -declared by the shipper subject to any seizure of the shipment at port of loading or port of discharges all charges / penalties / fines / legal fee pertaining to this shipment will be for shipper's account and carrier hold shipper fully responsible for the same. All charges 
with regard to losses and / or damages to container (s) while empty container(s) is/are returned to lines custody at destination will be on consignee account. Destination THC, Container Destination charges and all other applicable ancillaries are payable at destination by consignee. The shipment
will be held back by carrier /carrier's agent if shipper or consignee owes any money without any responsibility of claims on their part. In case shipment has been rejected by the authorities at the discharging port, re -shipment expenses, demurrage, detention etc. and all freight charges will be
on shipper's account. Carrier is not responsible for the condition of cargo. Consignee to pay aforesaid charges including Delivery Order Charges, Ins., Gate Pass, House B/L, Bank Guarantee, Container Service Charges, Washing, Damage, Dirty, Oily, Lift on /off, Empty delivery Charges and any other 
charges in addition to those indicated that the Line may levy from time to time as per Lines's tariff available on";
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
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader9 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader9, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Agent to contact for release of goods", 15, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Payable at", 335, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight & Charges", 485, 110, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number of Original B/Ls", 335, 80, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place and date of issue", 485, 80, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Total Freight Amount", 335, 50, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "For and on behalf of ", 485, 50, 0);
            cb.EndText();

            cb.Stroke();
            doc.Close();
            pdfmp.AddFile(FileNamev + ".pdf");



            pdfmp.Execute();
            string str = FileHidpath;
            string mime = pdfpath;
            ViewList.Add(new MyCountry
            {
                merchantFilename = FileNamev
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
