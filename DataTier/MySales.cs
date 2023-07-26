using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MySales
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }
    }

    public class MyMRG
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


    public class MySLOT
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


    public class MYPortTariffMaster
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
        public string ItemsSlab;
        public string ItemsSlabImp;
        public string ItemsIHC;
        public string ItemsDOCharges;
        public string ItemsTHCCharges;
        public string ItemsIHCBrackupCharges;
        public string ItemsStorage;


        public string Module;
        public string Locations;
        public string CustomerName;
        public string AgencyName;
        public string ShipmentType = "";
        public string CollectionMode = "";
        public string LinerName = "";
        public string EquipmentType = "";
        public string portName = "";




        public int TID;
        public int ChargeTypeID;
        public int ChargeCodeID;
        public int BasisID;
        public int CntrID;
        public int CurrencyID;
        public decimal Amount;
        public decimal RevenueAmount;
        public decimal CostAmount;
        public decimal LineAmount;
        public int DestCountryID;
        public int CommodityID;
        public int TariffTypeID;

        public string ChargeType = "";
        public string ChargeCode = "";
        public string Basis = "";
        public string Cntr = "";
        public string Currency = "";
        public string DestCountry = "";

        public string StrPortLocID = "";
        public string StrShipmentID = string.Empty;
        public string StrPrincibleID = string.Empty;
        public string PrincibleID = "";
        public string PortID = "";
        public string EquipmentTypeID = "";

        public string TariffType = string.Empty;
        public string TariffModeID = string.Empty;
        public string StrTariffMode = string.Empty;
        public string TraiffRegular = string.Empty;
        public int TariffChID = 0;
        public string CntrTypeID = "";
        public string PaymentTo = "";
        public string HandlingChargeID = "";
        public string HandlingCharge = "";
        public string ServiceTypeID = "";
        public string GroupID = "";
        public string ServiceType = "";
        public string Groups = "";
        public string CommodityType = "";

        public string PortTariffTypeID = "";

        public string EffectiveDate = "";

        public string TerminalID = "";
        public string ChargeID = "";
        public string ExpChargeID = "";
        public string ImpChargeID = "";
        public string StartMoveID = "";
        public string EndMove = "";
        public string AlertMessage = "";
        public string AlertMegId = "";
        public string Commodity = "";
        public string Basic = "";
        public string SlabFrom = "";
        public string SlabTo = "";
        public int SLID = 0;
        public string SlabUpto = "";
        public string ISSlab = "";

        public string ShipmentID = "";
        public string CntrType = "";
        public decimal ExRate;
        public decimal LocalAmount;
        public int TCID = 0;
        public string EqTypeID = "";
        public string TypeID = "";

        public int Status;
        public string StatusV = "";


    }

    public class MyRatesheet
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
        public string ExtRRID = "";


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
        public string SingleUser = "";
        public string ValidTillStatus = "";

        #region GANESH

        public string PORName = "";
        public string DestTHCRate = "";
        public string LoadTHCRate = "";
        public string ExportIHCRate = "";
        public string ImportIHCRate = "";
        public string Size = "";
        public string Commodity = "";
        public string FRT = "";
        public string BAF = "";
        public string DGS = "";
        public string ECRS = "";
        public string CAF = "";
        public string EWRS = "";
        public string LSS = "";
        public string FRTCurr = "";
        public string BAFCurr = "";
        public string DGSCurr = "";
        public string ECRSCurr = "";
        public string CAFCurr = "";
        public string EWRSCurr = "";
        public string LSSCurr = "";
        public string Curr1 = "";
        public string Curr2 = "";
        public string Curr3 = "";
        public string Curr4 = "";
        #endregion
    }

    public class MyCommContract
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }


        private int _CurrencyID;
        public int CurrencyID { get { return _CurrencyID; } set { _CurrencyID = value; } }

        private string _ValidFrom = string.Empty;
        public string ValidFrom { get { return _ValidFrom; } set { _ValidFrom = value; } }

        private string _ValidTill = string.Empty;
        public string ValidTill { get { return _ValidTill; } set { _ValidTill = value; } }

        private int _UserID;
        public int UserID { get { return _UserID; } set { _UserID = value; } }

        private int _ShipmentType;
        public int ShipmentType { get { return _ShipmentType; } set { _ShipmentType = value; } }

        private int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }

        private int _ComChargeID;
        public int ComChargeID { get { return _ComChargeID; } set { _ComChargeID = value; } }

        private string _FixedRate = string.Empty;
        public string FixedRate { get { return _FixedRate; } set { _FixedRate = value; } }

        private string _CommissionPercentage = string.Empty;
        public string CommissionPercentage { get { return _CommissionPercentage; } set { _CommissionPercentage = value; } }

        private int _StatusID;
        public int StatusID { get { return _StatusID; } set { _StatusID = value; } }

        private int _FreightChargeID;
        public int FreightChargeID { get { return _FreightChargeID; } set { _FreightChargeID = value; } }

        private int _LoginAgencyID;
        public int LoginAgencyID { get { return _LoginAgencyID; } set { _LoginAgencyID = value; } }

        private int _GeoLocID;
        public int GeoLocID { get { return _GeoLocID; } set { _GeoLocID = value; } }

        private string _StatusResult = string.Empty;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }

        private string _Agency = string.Empty;
        public string Agency { get { return _Agency; } set { _Agency = value; } }

        private string _ShipmentTypes = string.Empty;
        public string ShipmentTypes { get { return _ShipmentTypes; } set { _ShipmentTypes = value; } }

        private string _ChargeCode = string.Empty;
        public string ChargeCode { get { return _ChargeCode; } set { _ChargeCode = value; } }

        private string _CommissionCharge = string.Empty;
        public string CommissionCharge { get { return _CommissionCharge; } set { _CommissionCharge = value; } }

        private string _ChargeCommTypes;
        public string ChargeCommTypes { get { return _ChargeCommTypes; } set { _ChargeCommTypes = value; } }
    }

    public class MyRatesheetRates
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


    public class MyRRMRG
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

    public class MyRRRate
    {
        public int ID = 0;
        public string POD = "";
        public string POL = "";
        public string TraiffRegular = "";
        public string PortTariffID = "";
        public int RCID = 0;
        public string CntrTypes = "";
        public string ChargeCodeID = "";
        public string PaymentModeID = "";
        public string CurrencyID = "";
        public string ReqRate = "";
        public string ManifRate = "";
        public string CustomerRate = "";
        public string RateDiff = "";
        public string Qty = "";
        public string BillAmt = "";
        public string VendorName = "";
        public string VendorID = "";

        public string Currency = "";
        public string Amount = "";
        public string SalesPersion = "";
        public string ExportIHC = "";
        public string ImportIHC = "";
        public string CommodityTypeID = "";
        public string PortID = "";
        public string CollectionModeID = "";
        public string RRID = "";
        public string ChargeTypeID = "";
        public string UserName = "";
        public string ValidTo = "";
        public string ItemsSlotv = "";
        public string ItemsTermainalv = "";
        public string ItemsLocalCostv = "";
        public string ItemsCommissionv = "";
        public int SlabValue = 0;
        public string POO = "0";
        public string FPOD = "0";
        public string GroupID = "";
        public string InvoiceNo = "";
        public string InvID = "";
        public string BkgID = "";
        public string AlertMessage = "";
        public string BLID = "";

    }

    public class MyIHCTariff
    {
        public int ID;
        public string ContainerTypeID = "";
        public string ChargeTypeID = "";
        public string ChargesID = "";
        public string CommodityTypeID = "";
        public string ICDName = "";
        public string ICDLocID = "";
        public string PortID = "";
        public string Port = "";
        public string ValidFrom = "";
        public string ValidTill = "";
        public string Status = "";
        public string THCIncluded = "";
        public string UserID = "";
        public string TariffTypeV = "";
        public string CustomerV = "";
        public string Size = "";
        public string ShipmentTypeV = "";
        public string ChargeOwnerIDV = "";
        public string CommodityType = "";
        public string ContainerType = "";
        public string ChargeType = "";


        public int TID;
        public int IHCTariffID;
        public string SlabFrom = "";
        public string SlabTo = "";
        public int CurrencyID;
        public string Currency;
        public string Amount = "";
        public string Itemsv1 = "";

    }
    public class MyEmptyYard
    {
        public int ID;
        public string GeoLocID = "";
        public string CountryID = "";
        public string GeoLocations = "";
        public string Country = "";
        public string EmptyYard = "";
        public string EmptyYardID = "";
        public string CostPerCurrID = "";
        public string CostPerManHr = "";
        public string UnitsPerID = "";
        public string FreeUnits = "";
        public string SlabFrom = "";
        public string SlabTo = "";
        public int CurrencyID;
        public int ChargeID;
        public string ValidFrom = "";
        public string ValidTill = "";
        public string UserID = "";
        public string Status = "";
        public string Itemsv1 = "";
        public string Itemsv2 = "";
        public int TID;
        public int EID;
        public string CT20 = "";
        public string CT40 = "";
        public string HQCT = "";
        public string PCT20 = "";
        public string PCT40 = "";
        public string PHQCT = "";
    }
}
