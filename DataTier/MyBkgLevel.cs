using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyBkgLevel
    {
        public int ID;
        public string BookingNo;
        public string Vessel;
        public string Voyage;
        public string BLNumber;
        public string BLType;
        public string BLStatus;
        public string BLIssuedDate;
        public string BLIssuedBy;
        public string AlertMessage;
        public int AlertMegId;
        public string SearchValue;
        public int SearchID;
        public string Issuedby;
        public string BOLStatusCompleteCount;
        public string BOLStatusOpenCount;

        public string CustomerID;
        public int PrincipalID;
        public int SalesPersonID;
        public int OriginID;
        public int LoadPortID;
        public int DischargePortID;
        public int DestinationID;
        public int RouteID;
        public int DeliveryTermsID;
        public string Remarks;
        public int Status;
        public string UserName;
        public string CustomerName;
        public string Principal;
        public string POL;
        public string POD;
        public string FPOD;
        public int FreeDaysOriginType;
        public string FreeDaysOrigin;
        public int FreeDaysDestinationType;
        public string FreeDaysDestination;
        public int DamageSchemeType;
        public string DamageScheme;
        public int SecDepositType;
        public string SecDepost;
        public int BOLReqType;
        public string BOLReq;
        public string EnquiryNo;
        public string BookingDate;
        public string BookingSourceID;
        public string BookingCommissionID;
        public string CargoID;
        public string CargoWeight;
        public string HSCode;
        public string VesselID;
        public int VoyageID;
        public string POLTerminalID;
        public string TSVesselID;
        public string TSVoyageID;
        public string BkgParty;
        public string VesselName;
        public string VoyageName;
        public string ETD;
        public string CntrCount;
        public string BkgCount;
        public string Sailed;
        public string CntrNo;
        public int BookingID;
        public string ETDFrom;
        public string ETDTo;
        public string OfficeCode = "";
        public string IssueDate = "";
        public int BLID = 0;
        public int CntrID = 0;
        public string BLNumberv;
        public string BkgPartyV;
        public string PickOpen;
        public string PickComp;
        public string GateOpen;
        public string GateComp;
        public string DocOpen;
        public string DocComp;
        public string BLDOpen;
        public string BLDComp;
        public string BLROpen;
        public string BLRComp;
        public string InvoiceOpen;
        public string InvoiceComp;
    }

    public class MyBkgDocs
    {
        public int ID;
        public int CntrID;
        public int BkgID;
        public int BLID;
        public string HAZClass;
        public string CntrNo;
        public string CntrType;
        public string IMCOCode;
        public string Length;
        public string Width;
        public string Height;
        public string Temperature;
        public string Ventilation;
        public int ChkFlag;
        public string Humidity;
        public string FileName;
        public string Items;
        public string AlertMegId;
        public string AlertMessage;
        public string AttachFile;
        public int AttachType;
        public string LoadingPhotos;
        public string Survey;
        public string DocsType;
        public int AttachID;

    }

    public class BkgDocsList
    {
        public string Version { get; set; }
        public int ID = 0;

        public List<BkgItemList> BkgItemList { get; set; }

    }
    public class BkgItemList
    {
        public string CntrNo;
        public string CntrType;
        public int CntrID;
        public int BkgID;
        public int BLID;
        public string DocsType;
        public int ChkFlag;
        public int DocsTypeID;

        public List<BkgAttachList> BkgAttachList { get; set; }
    }

    public class BkgAttachList
    {
        public string AttachFile;
        public int AttachID;
        public string FileName;
    }

}
