using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyLinerAgency
    {
    }
        public class MyLinerSales
        {
            private int _ID;
            public int ID { get { return _ID; } set { _ID = value; } }
        }

        public class MyLinerMRG
        {
            private int _ID;
            public int ID { get { return _ID; } set { _ID = value; } }

            private DateTime _FromDate;
            public DateTime FromDate { get { return _FromDate; } set { _FromDate = value; } }

            private DateTime _ToDate;
            public DateTime ToDate { get { return _ToDate; } set { _ToDate = value; } }

            private int _IntPOfOrigin;
            public int IntPOfOrigin { get { return _IntPOfOrigin; } set { _IntPOfOrigin = value; } }

            private int _IntPOfLoading;
            public int IntPOfLoading { get { return _IntPOfLoading; } set { _IntPOfLoading = value; } }

            private int _IntPOfDischarge;
            public int IntPOfDischarge { get { return _IntPOfDischarge; } set { _IntPOfDischarge = value; } }

            private int _IntFinalPOD;
            public int IntFinalPOD { get { return _IntFinalPOD; } set { _IntFinalPOD = value; } }

            private int _IntCntrType;
            public int IntCntrType { get { return _IntCntrType; } set { _IntCntrType = value; } }

            private int _IntCommodityType;
            public int IntCommodityType { get { return _IntCommodityType; } set { _IntCommodityType = value; } }

            private int _IntFreightRate;
            public int IntFreightRate { get { return _IntFreightRate; } set { _IntFreightRate = value; } }

            private decimal _FreightRate;
            public decimal FreightRate { get { return _FreightRate; } set { _FreightRate = value; } }


            private int _IntServiceTypes;
            public int IntServiceTypes { get { return _IntServiceTypes; } set { _IntServiceTypes = value; } }

            private string _Remarks = string.Empty;
            public string Remarks { get { return _Remarks; } set { _Remarks = value; } }


            private string _PortName;
            public string PortName { get { return _PortName; } set { _PortName = value; } }



            private int _intCntrTypes;
            public int intCntrTypes { get { return _intCntrTypes; } set { _intCntrTypes = value; } }

            private int _intCommodity;
            public int intCommodity { get { return _intCommodity; } set { _intCommodity = value; } }

            private int _intServiceTypes;
            public int intServiceTypes { get { return _intServiceTypes; } set { _intServiceTypes = value; } }

            private int _intCurrency;
            public int intCurrency { get { return _intCurrency; } set { _intCurrency = value; } }

            private string _CntrTypes;
            public string CntrTypes { get { return _CntrTypes; } set { _CntrTypes = value; } }

            private string _CommodityName;
            public string CommodityName { get { return _CommodityName; } set { _CommodityName = value; } }

            private string _ServiceTypesName;
            public string ServiceTypesName { get { return _ServiceTypesName; } set { _ServiceTypesName = value; } }

            private string _Currency;
            public string Currency { get { return _Currency; } set { _Currency = value; } }

            private string _MRGNo;
            public string MRGNo { get { return _MRGNo; } set { _MRGNo = value; } }

            private decimal _Amount;
            public decimal Amount { get { return _Amount; } set { _Amount = value; } }


            private string _FDate;
            public string FDate { get { return _FDate; } set { _FDate = value; } }

            private string _TDate;
            public string TDate { get { return _TDate; } set { _TDate = value; } }

            private string _POOL;
            public string POOL { get { return _POOL; } set { _POOL = value; } }

            private string _POO;
            public string POO { get { return _POO; } set { _POO = value; } }

            private string _FPOD;
            public string FPOD { get { return _FPOD; } set { _FPOD = value; } }

            public string StrPOL = string.Empty;
            public string StrPOD = string.Empty;
            public string StrCommondty = string.Empty;
            public string StrCntrTypes = string.Empty;


            public int UserID = 0;
            public int AgentId = 0;
            public string SessionFinYear = string.Empty;
            public string AgentCode = string.Empty;


        }


        public class MyLinerSLOT
        {
            private int _ID;
            public int ID { get { return _ID; } set { _ID = value; } }

            private int _SID;
            public int SID { get { return _SID; } set { _SID = value; } }

            private string _SlotRef;
            public string SlotRef { get { return _SlotRef; } set { _SlotRef = value; } }

            private string _ValidFrom;
            public string ValidFrom { get { return _ValidFrom; } set { _ValidFrom = value; } }

            private string _ValidTo;
            public string ValidTo { get { return _ValidTo; } set { _ValidTo = value; } }


            private string _ServiceName = string.Empty;
            public string ServiceName { get { return _ServiceName; } set { _ServiceName = value; } }


            private string _SlotOperator = string.Empty;
            public string SlotOperator { get { return _SlotOperator; } set { _SlotOperator = value; } }

            private int _SlotTermID;
            public int SlotTermID { get { return _SlotTermID; } set { _SlotTermID = value; } }

            private int _POD;
            public int POD { get { return _POD; } set { _POD = value; } }

            private int _POL;
            public int POL { get { return _POL; } set { _POL = value; } }

            private int _TSPort;
            public int TSPort { get { return _TSPort; } set { _TSPort = value; } }

            private string _Remarks = string.Empty;
            public string Remarks { get { return _Remarks; } set { _Remarks = value; } }

            private string _Itemsv = string.Empty;
            public string Itemsv { get { return _Itemsv; } set { _Itemsv = value; } }


            private int _ChargeCodeID;
            public int ChargeCodeID { get { return _ChargeCodeID; } set { _ChargeCodeID = value; } }

            private int _Basic;
            public int Basic { get { return _Basic; } set { _Basic = value; } }



            private int _SizeID;
            public int SizeID { get { return _SizeID; } set { _SizeID = value; } }

            private int _CommodityID;
            public int CommodityID { get { return _CommodityID; } set { _CommodityID = value; } }

            private int _CurrencyID;
            public int CurrencyID { get { return _CurrencyID; } set { _CurrencyID = value; } }


            private decimal _Amount;
            public decimal Amount { get { return _Amount; } set { _Amount = value; } }


            private int _Agent;
            public int Agent { get { return _Agent; } set { _Agent = value; } }

            public string POLStr = "";
            public string PODStr = "";
            public string TSPortStr = "";
            public string StrSlotOperator = "";
            public string StrSlotTerms = "";

            public int UserID = 0;
            public int AgentId = 0;
            public string SessionFinYear = "";
            public string AgentCode = "";





        }


        public class MYLinerPortTariffMaster
        {
            public int ID;
            public int PortLocationID;
            public int ModuleID;
            public int ShipmentTypeID;
            public int CommodityTypeID;
            public int CollectionModeID;
            public int CollectionAgentID;
            public int StatusID;
            public string ValidFrom;
            public string ValidTo;
            public int CustomerID;
            public string Remarks = "";
            public string Itemsv;
            public string Module;
            public string Locations;
            public string CustomerName;
            public string AgencyName;
            public string ShipmentType = "";
            public string CollectionMode = "";


            public int TID;
            public int ChargeTypeID;
            public int ChargeCodeID;
            public int BasisID;
            public int CntrID;
            public int CurrencyID;
            public decimal Amount;
            public int DestCountryID;

            public string ChargeType = "";
            public string ChargeCode = "";
            public string Basis = "";
            public string Cntr = "";
            public string Currency = "";
            public string DestCountry = "";

            public string StrPortLocID = "";
            public string StrShipmentID = string.Empty;

            public string TariffType = string.Empty;
            public string TariffModeID = string.Empty;
            public string StrTariffMode = string.Empty;
            public string TraiffRegular = string.Empty;

        }

        public class MyLinerRatesheet
        {
            public int ID;
            public int RRID;
            public int RCID;
            public string RatesheetNo = "";
            public string Date = "";
            public int BookingPartyID;
            public int SalesPersonID;
            public int ShipmentID;
            public int PortOfOrgin;
            public int PortOfLoading;
            public int ExpHaulageID;
            public int PlaceofDischargeId;
            public int FinalPODId;
            public int ImpHaulageId;
            public int TranshimentPortID;
            public int ServiceTypeID;
            public string ValidTill = "";
            public int UserID;
            public int AgentId;
            public string Remarks = "";
            public string SessionFinYear = "";
            public string AgentCode = "";


            public string BookingParty = "";
            public string PortofOrgin = "";
            public string PortofLoading = "";
            public string Itemsv;
            public string ItemsvImp;
            public string ItemsCR;
            public string ItemsCRImp;
            public string ItemsTrans;

            public int CntrTypeID;
            public int CommodityTypeID;
            public decimal ExFreeday;
            public decimal ImFreeday;
            public decimal VGM;
            public string PortofDischarge = "";
            public string POLName = "";
            public string POLCode = "";
            public string PODName = "";
            public string PODCode = "";
            public string Status = "";
            public string BLNumber = "";
            public string LinerCode = "";
            public string DatYear = "";
            public string DatMonth = "";
            public string CheckCntr = "";
            public string CheckMRG = "";
            public string CheckSLOT = "";
            public string Notes = "";

            public string Pending = "";
            public string Rejected = "";
            public string REQuote = "";
            public string Approved = "";

            public string Tsport = "";
            public string CollectMode = "";
            public string FreeDays = "";
            public string SlotOperator = "";
            public string SalesMode = "";
            public string Validate = "";

            public string RRNumber = "";
            public string RouteType = "";
            public string ShipperID = "";
            public string ExportIHC = "";
            public string ImportIHC = "";

            public string CntrItems = "";
            public string FreightItems = "";
            public string TerminalItems = "";
            public string HaulagItems = "";
            public string ExportItems = "";
            public string ImportItems = "";
            public string TranshimentPort = "";
            public string ModeItems = "";

            public string RebateAmt = "";
            public string IsRebate = "";
            public string DGClass = "";
            public string Mode = "";

            public string ExpFreeDays = "";
            public string ImpFreeDays = "";
            public string PortID = "";
            public string OtherRemarks = "";
            public string DocumentAttached = "";

            public int LinerID;
            public int VesVoyID;
            
            public string Qty  = "";
            public string VesVoy = "";

            #region GANESH

            public string PORName = "";
            public string DestTHCRate = "";
            public string LoadTHCRate = "";
            public string ExportIHCRate = "";
            public string ImportIHCRate = "";
            public string Size = "";
            #endregion
        }
    public class MyLinerCntrPickupdtls
    {
        public int ID;
        public string BkgID = "";
        public string CntrID = "";
        public string CntrNo = "";
        public string Size = "";
        public string MSDate = "";
        public string ERDate = "";
        public string EODate = "";
        public string GIDate = "";
        public string VDDate = "";
        public string TADate = "";
        public string TDDate = "";
        public string VADate = "";
        public string GODate = "";
        public string IRDate = "";
        public string IODate = "";
        public string LIDate = "";
        public string LODate = "";
        public string MRDate = "";
        public string IsTrue = "";
        public string CurrentDepotID = "";
        public string LocationID = "";

    }
    public class MyLinerName
    {
        public int ID;
        public string LinerName;
    }

        public class MyLinerRatesheetRates
        {
            public int ID = 0;
            public int RRID = 0;
            public int RID = 0;
            public int ChargeCodeID = 0;
            public int infoChID = 0;
            public int BasicID = 0;
            public int CntrTypeID = 0;
            public int CommodityTypeID = 0;
            public int CurrencyID = 0;
            public decimal Amt = 0;
            public int CollectionModeID = 0;
            public int CollectionAgentID = 0;
            public int ChargeOwnershipID = 0;
            public string ResultSuccess = "";
            public string ShipmentType = "";
            public int RBID = 0;
            public string FRT = "";
            public string Rebate = "";
            public string Vendor = "";
            public string Remarks = "";


        }


        public class MyLinerRRMRG
        {
            public int RCID = 0;
            public int RSID = 0;
            public int CntrTypeID = 0;
            public string MRGAmt = "";
            public string QuotedAmt = "";
            public string FreightTems = "";
            public int AgentID = 0;
            public int RRID = 0;
            public int SlotTermID = 0;
            public int SlotOperator = 0;

            public int RSIDD = 0;
            public int SizeID = 0;
            public int CommodityID = 0;
            public string Amount = "";
            public int ChargeID = 0;

            public string MRGItemsv = "";
            public string SLTItemsv = "";
            public string SLTDItemsv = "";

            public int MRGID = 0;
            public string QuotedAmount = "";
            public int SLTID = 0;
            public int SLTIDD = 0;
            public string SlotRef = "";
            public string ValidDate = "";
            public string ResultSuccess = "";
            public string Size = "";

        }

        public class MyLinerRRRate
        {
            public int ID = 0;
            public string POD = "";
            public string POL = "";
            public string TraiffRegular = "";
            public int RCID = 0;
            public string CntrTypes = "";
            public string ChargeCodeID = "";
            public string PaymentModeID = "";
            public string CurrencyID = "";
            public string ReqRate = "";
            public string ManifRate = "";
            public string CustomerRate = "";
            public string RateDiff = "";

            public string Currency = "";
            public string Amount = "";
            public string SalesPersion = "";
            public string ExportIHC = "";
            public string ImportIHC = "";
            public string CommodityTypeID = "";
            public string PortID = "";
            public string CollectionModeID = "";
            public string RRID = "";
        }

    public class MYLinerBOL
    {
        public int ID;
        public int BkgID;
        public string RRNo = "";
        public string BkgParty = "";
        public string POO = "";
        public string POL = "";
        public string POD = "";
        public string FPOD = "";
        public int BkgPartyID;

        public string POOID = "";
        public string POLID = "";
        public string PODID = "";
        public string FPODID = "";

        public int PortOfOrginID;
        public int PortOfLoadingID;
        public int PlaceOfDisID;
        public int FinalPODID;
        public int ShipmentID;
        public int ServiceTypeID;
        public int SalesPersonID;
        public int AgentId;
        public int VesVoyageID;
        public int LinerID;


        public string ShipmentType = "";
        public string ServiceType = "";
        public string SalesPerson = "";
        public string VesVoy = "";
        public string CntrCount = "";
        public string Size = "";
        public string ISOCode = "";
        public string CntrID = "";
        public string BLNumber = "";
        public string DesAgentID;
        public string NoofOriginal;
        public string SurrenderStatus;
        public string MarkNo = "";
        public string CagoDescription = "";
        public string BLTypes = "";
        public string MotherBL = "";
        public string FreeDays = "";
        public string FreightPaymentID = "";
        public string Remarks = "";
        public string Items = "";
        public string ItemsCntr = "";
        public string ItemsVS = "";
        public string BookingNo = "";
        public int BCID;
        public int PartyTypeID;
        public int PartyID;
        public string Address = "";
        public int BCNID;
        public string SealNo = "";
        public string NoOfPkg = "";
        public string PakgType = "";
        public string GrsWt = "";
        public string NtWt = "";
        public string VGM = "";
        public string CBM = "";
        public string CurPortID = "";
        public string NextPortID = "";
        public string ETA = "";
        public string ETD = "";
        public string VesVoyID = "";
        public string VID = "";
        public string VoyageTypes = "";
        public string LegInformation = "";
        public int RRID;
        public string Status = "";
        public string BLID = "";

        public string Confirm = "";
        public string Cancelled = "";
        public string Draft = "";
        public string Shipper = "";

        public string LinerName = "";
     
        public string LinerBLNo = "";
        public string OtherRemarks = "";


    }

    public class MYLinerRRBooking
    {

        public int ID = 0;
        public string RatesheetNo = "";
        public string POO = "";
        public string Date = "";
        public string POL = "";
        public string POD = "";
        public string FPOD = "";
        public string BookingParty = "";
        public string ShipmentTypes = "";
        public string serviceTypes = "";
        public string ValidTill = "";
        public string BaseAmt = "";
        public string Rate = "";
        public string SlotOperator = "";

        public string SlotCntr20Rate = "";
        public string SlotCntr4Rate = "";
        public string SlotTerm = "";
        public string Oceanfr20 = "";
        public string Oceanfr40 = "";
        public string Cntr20 = "";
        public string Cntr40 = "";
        public string Commodity = "";

        public string FRT20 = "";
        public string FRT40 = "";

        public string BAF20 = "";
        public string BAF40 = "";

        public string ECRS20 = "";
        public string ECRS40 = "";

        public string LSS20 = "";
        public string LSS40 = "";

        public string Commodity40 = "";


    }

    public class MYLinerBLRelease
    {
        public int ID;
        public int BkgID;
        public int RRID;
        public string VesVoy = "";
        public string BLDate = "";
        public string Shipper = "";
        public string ShipperAddress = "";
        public string Consignee = "";
        public string ConsigneeAddress = "";
        public string Notify1 = "";
        public string Notify1Address = "";
        public string Notify2 = "";
        public string Notify2Address = "";
        public string Agent = "";
        public string AgentAddress = "";
        public string POO = "";
        public string POL = "";
        public string POD = "";
        public string FPOD = "";
        public string GrsWt = "";
        public string NtWt = "";
        public string CBM = "";
        public string Packages = "";
        public string Description = "";
        public string Marks = "";
        public string Container = "";
        public string FreightPayment = "";
        public string FreeDays = "";
        public string SOBDate = "";
        public string issuedAT = "";
        public string BkgParty = "";
        public string BLNo = "";
        public string BLStatus = "";
        public string BLLayout = "";
        public string IssuedAt = "";
        public string CntrDetails = "";
        public string BLID = "";
        public string BLNumber = "";
        public string VesVoyID = "";
        public int GeoLocID;
        public string OtherRemarks = "";
    }

    #region Ganesh
    public class MYLinerBLNoLogics
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _BLNoLogic = string.Empty;
        public string BLNoLogic { get { return _BLNoLogic; } set { _BLNoLogic = value; } }

        private string _AgentCode = string.Empty;
        public string AgentCode { get { return _AgentCode; } set { _AgentCode = value; } }

        private string _LinerCode = string.Empty;
        public string LinerCode { get { return _LinerCode; } set { _LinerCode = value; } }
        private string _LinerName = string.Empty;
        public string LinerName { get { return _LinerName; } set { _LinerName = value; } }

        private string _StatusResult = string.Empty;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }

        private int _BLNoLogicID;
        public int BLNoLogicID { get { return _BLNoLogicID; } set { _BLNoLogicID = value; } }

        private int _LinerID;
        public int LinerID { get { return _LinerID; } set { _LinerID = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

    }
    #endregion
}

