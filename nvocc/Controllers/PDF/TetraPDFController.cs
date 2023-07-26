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
    public class TetraPDFController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public TetraPDFController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("TetraPrintPDF")]
        public List<MyCountry> BLPrintPDF(MyCountry Data)
        {
            string id = "69";
            string printvalue = "1";
            List<MyCountry> ViewList = new List<MyCountry>();

            Document doc = new Document();
            Rectangle rec = new Rectangle(670, 870);
            doc = new Document(rec);
            Paragraph para = new Paragraph();
            var pdfpath = Path.Combine("ClientApp//src//assets//pdfFiles//tetra/");
            MergeEx pdfmp = new MergeEx();
            pdfmp.SourceFolder = pdfpath;

            pdfmp.DestinationFile = pdfpath + "Multiple-BL.pdf";
            string FileHidpath = "ClientApp//src//assets//pdfFiles//tetra/Multiple-BL.pdf";

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
            cb.LineTo(10, 15);

            //BorderRight
            cb.MoveTo(660, 810);
            cb.LineTo(660, 15);

            //Center1
            cb.MoveTo(360, 810);
            cb.LineTo(360, 545);

            //Center2
            cb.MoveTo(360, 145);
            cb.LineTo(360, 15);

            //Line1
            cb.MoveTo(10, 810);
            cb.LineTo(660, 810);

            //Line2
            cb.MoveTo(10, 680);
            cb.LineTo(660, 680);

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
            cb.MoveTo(10, 275);
            cb.LineTo(660, 275);

            //Line9
            cb.MoveTo(10, 145);
            cb.LineTo(660, 145);

            //Line10
            cb.MoveTo(10, 125);
            cb.LineTo(660, 125);

            //Line11
            cb.MoveTo(10, 105);
            cb.LineTo(660, 105);

            //Line12
            cb.MoveTo(10, 15);
            cb.LineTo(660, 15);

            //HorizontalLine1
            cb.MoveTo(10, 745);
            cb.LineTo(360, 745);

            //HorizontalLine2
            cb.MoveTo(10, 680);
            cb.LineTo(360, 680);

            //VerticalLine1
            cb.MoveTo(180, 615);
            cb.LineTo(180, 295);

            //VerticalLine2
            cb.MoveTo(510, 615);
            cb.LineTo(510, 295);

            //VerticalLine3
            cb.MoveTo(180, 145);
            cb.LineTo(180, 105);

            //VerticalLine4
            cb.MoveTo(510, 145);
            cb.LineTo(510, 105);



            cb.Stroke();
            cb.BeginText();
            BaseFont bfheader0 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader0, 14);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "OCEAN BILL OF LADDING", 15, 820, 0);
            cb.EndText();
            cb.BeginText();
            BaseFont bfheader1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader1, 9);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Container No. Seal No. & Marks", 15, 530, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Description of Goods & Packages", 270, 530, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gross Weight", 520, 530, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Cbm", 590, 530, 0);
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
            cb.SetFontAndSize(bfheader3, 10);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FOR COMBINED OR MULTIMODAL TRANSPORT DOCUMENT", 360, 820, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "(Unless provided otherwise, a consignment 'To Order' means To Order of Shipper)", 55, 735, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "(Name/Full address-It is agreedthat no responsibility shall attach to the carrier or agent for failure to notify)", 55, 670, 0);

            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Service Contract ", 335, 760, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Delivery Agent at place of Delivery", 335, 735, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Onward inland routing (Not part of Carriage as defined in clause 1. for account and risk of Merchant)", 335, 670, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt, Applicable only when document used as Multimodal Transport B/L (see clause 1)", 335, 645, 0);
            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Delivery, Applicable only when document used as Multimodal Transport B/L (see clause 1)", 335, 605, 0);
            cb.EndText();

            iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance(Path.Combine("ClientApp//src//assets//images//bllogos/tetra.png"));
            png1.SetAbsolutePosition(420, 730);
            png1.ScalePercent(40f);
            doc.Add(png1);

            cb.BeginText();
            BaseFont bfheader4 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader4, 8);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "B/L No.:", 365, 800, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Also Notify Party:", 365, 670, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Shipper:", 15, 800, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Consignee (Or Order):", 15, 735, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Notify Party:", 15, 670, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Pre-carriage By", 15, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Receipt", 190, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Ocean Vessel/Voyage no.", 370, 605, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Loading", 520, 605, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Port of Discharge", 15, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place of Delivery", 190, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Mode/Means of Transport", 370, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Route/Place of Transhipment", 520, 570, 0);

            //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PARTICULARS FURNISHED BY THE SHIPPER/CONSIGNOR - CARRIER NOT RESPONSIBLE", 180, 280, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Charges", 15, 135, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Freight Payable at", 190, 135, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Number of Originals", 370, 135, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Place and Date of Issue", 520, 135, 0);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "For DELIVERY, PLEASE APPLY TO", 15, 90, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "For TETRA SHIPPING LLC", 420, 90, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "As AGENTS", 420, 25, 0);
            cb.EndText();

            cb.BeginText();
            BaseFont bfheader5 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader5, 7);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PARTICULARS FURNISHED BY THE SHIPPER/CONSIGNOR - CARRIER NOT RESPONSIBLE", 190, 280, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Office #806, Business Point Building", 440, 720, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "P O Box: 238527, Port Saeed, Deira, Dubai, UAE.", 420, 710, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Tel: +971 4323 1789", 470, 700, 0);
            cb.EndText();


            int ColumnRows = 255;
            int RowsColumn = 0;

            cb.BeginText();
            BaseFont bfheader8 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(bfheader8, 6);
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK);


            string text = @"Received in good order and condition, unless otherwise noted herein, at the place of receipt for transport and delivery as mentioned above. The particulars as stated above by shipper and the weight, quantity, condition, 
contents and value of goods are unknown to the carrier Quality, quantity and nature of the cargo stufed inside the container by the shipper is unknown to the carrier. One of these Combined Transport Bill of Lading must 
be surrendered duly endorsed in exchange for the goods. IN WITNESS whereof the original Combined Transport Bills of Lading all of this tenor and date have been signed in the number stated below one of which being 
accomplished and the other(s) to be void. The contract evidenced by or contained in this billof lading is governed by the law of UAE and any claim dispute arising hereunder or in connection herewith shall be determined 
by the courts in UAE and no other courts. Cargo insurance not provided by the carriers. In case subject shipment in not loaded on vessel named aforesaid for any reason /is not cleared/ claimed by the consignee and cargo 
is abandoned at destination or cargo is mis-declared by the shipper subject to any seizure of the shipment at port of loading or port of discharge all charges /penalties / fines legal fee pertaining to this shipment will be 
for shipper's acount and carier hold shipper fully responsible for the same All harges with regard to losses and/or damages to container(s) while empty containert) is/are returned to lines custody at destination will be 
on consignee account. Destination THC, Container detention charges and al other applicable ancilaries are payable at destination by consignee. The Shipment will be held back by carier/carier's aget if shipper or 
consignee owes any money without any responsiblity of claims on their part. in case shipment has been rejected by the authorities at the discharging port, re-shipment expenses, demurage, detention etc. and al freight 
charges will be on shipper's account. Carrier is not responsible for the condition of cargo.";
            string[] Arrayterms = Regex.Split(text, char.ConvertFromUtf32(13));
            string[] Addsplit1;

            for (int x = 0; x < Arrayterms.Length; x++)
            {
                Addsplit1 = Arrayterms[x].Split('\n');

                for (int k = 0; k < Addsplit1.Length; k++)
                {

                    cb.ShowTextAligned(Element.ALIGN_JUSTIFIED, Addsplit1[k].ToString(), 15, ColumnRows, 0);
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
                tetraFilename = FileNamev
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
