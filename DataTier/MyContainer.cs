using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataTier
{
    #region GANESH 
    #region Container Master

    public class MyContainerData
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }
        private int _TypeID;
        public int TypeID { get { return _TypeID; } set { _TypeID = value; } }

        private string _Size = string.Empty;
        public string Size { get { return _Size; } set { _Size = value; } }

        private int _ISOCodeID;
        public int ISOCodeID { get { return _ISOCodeID; } set { _ISOCodeID = value; } }

        private string _ISOCode = string.Empty;
        public string ISOCode { get { return _ISOCode; } set { _ISOCode = value; } }
        private int _GradeID;
        public int GradeID { get { return _GradeID; } set { _GradeID = value; } }

        private string _Grade = string.Empty;
        public string Grade { get { return _Grade; } set { _Grade = value; } }

        private string _Reference = string.Empty;
        public string Reference { get { return _Reference; } set { _Reference = value; } }

        private int _LeaseTermID;
        public int LeaseTermID { get { return _LeaseTermID; } set { _LeaseTermID = value; } }

        private string _LeaseTerm = string.Empty;
        public string LeaseTerm { get { return _LeaseTerm; } set { _LeaseTerm = value; } }

        private int _BoxOwnerID;
        public int BoxOwnerID { get { return _BoxOwnerID; } set { _BoxOwnerID = value; } }


        private string _BoxOwner = string.Empty;
        public string BoxOwner { get { return _BoxOwner; } set { _BoxOwner = value; } }
        private int _LeasingPartnerID;
        public int LeasingPartnerID { get { return _LeasingPartnerID; } set { _LeasingPartnerID = value; } }


        private string _LeasingPartner = string.Empty;
        public string LeasingPartner { get { return _LeasingPartner; } set { _LeasingPartner = value; } }

        private string _CntrNo = string.Empty;
        public string CntrNo { get { return _CntrNo; } set { _CntrNo = value; } }

        private string _DtManufacture = string.Empty;
        public string DtManufacture { get { return _DtManufacture; } set { _DtManufacture = value; } }
        private string _DtOnHire = string.Empty;
        public string DtOnHire { get { return _DtOnHire; } set { _DtOnHire = value; } }

        private string _CubicCapacity = string.Empty;
        public string CubicCapacity { get { return _CubicCapacity; } set { _CubicCapacity = value; } }

        private int _GrWtx100;
        public int GrWtx100 { get { return _GrWtx100; } set { _GrWtx100 = value; } }

        private int _NtWtx100;
        public int NtWtx100 { get { return _NtWtx100; } set { _NtWtx100 = value; } }

        private int _TareWtx100;
        public int TareWtx100 { get { return _TareWtx100; } set { _TareWtx100 = value; } }

        private int _StatusID;
        public int StatusID { get { return _StatusID; } set { _StatusID = value; } }
        private string _Status = string.Empty;
        public string Status { get { return _Status; } set { _Status = value; } }

        private int _PickUpRefID;
        public int PickUpRefID { get { return _PickUpRefID; } set { _PickUpRefID = value; } }

        private int _ApplicableAtID;
        public int ApplicableAtID { get { return _ApplicableAtID; } set { _ApplicableAtID = value; } }
        private int _UserID;
        public int UserID { get { return _UserID; } set { _UserID = value; } }

        private int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }


        private string _PickUpRef = string.Empty;
        public string PickUpRef { get { return _PickUpRef; } set { _PickUpRef = value; } }
        private string _GeneralName = string.Empty;
        public string GeneralName { get { return _GeneralName; } set { _GeneralName = value; } }

        private string _LineName = string.Empty;
        public string LineName { get { return _LineName; } set { _LineName = value; } }

        private int _ModuleID;
        public int ModuleID { get { return _ModuleID; } set { _ModuleID = value; } }

        private int _LineID;
        public int LineID { get { return _LineID; } set { _LineID = value; } }

        private string _Remarks = string.Empty;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }

        private int _IsDropOff;
        public int IsDropOff { get { return _IsDropOff; } set { _IsDropOff = value; } }

        private int _IsPickUp;
        public int IsPickUp { get { return _IsPickUp; } set { _IsPickUp = value; } }

        private int _PickUpLocID;
        public int PickUpLocID { get { return _PickUpLocID; } set { _PickUpLocID = value; } }

        private int _DropOffLocID;
        public int DropOffLocID { get { return _DropOffLocID; } set { _DropOffLocID = value; } }

        private string _PickUpDate = string.Empty;
        public string PickUpDate { get { return _PickUpDate; } set { _PickUpDate = value; } }

        private string _DropOffDate = string.Empty;
        public string DropOffDate { get { return _DropOffDate; } set { _DropOffDate = value; } }


        private string _DropOffRef = string.Empty;
        public string DropOffRef { get { return _DropOffRef; } set { _DropOffRef = value; } }

        private string _ModuleType = string.Empty;
        public string ModuleType { get { return _ModuleType; } set { _ModuleType = value; } }

        public string AlertMegId;
        public string AlertMessage;
    }
    #endregion

    #region Lease Contract
    public class MyLease
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }
        private int _PID;
        public int PID { get { return _PID; } set { _PID = value; } }
        private int _DID;
        public int DID { get { return _DID; } set { _DID = value; } }
        private string _PickupCriteria = string.Empty;

        public string PickupCriteria { get { return _PickupCriteria; } set { _PickupCriteria = value; } }

        private int _PickupCriteriaID;
        public int PickupCriteriaID { get { return _PickupCriteriaID; } set { _PickupCriteriaID = value; } }

        private string _ContractRefNo = string.Empty;
        public string ContractRefNo { get { return _ContractRefNo; } set { _ContractRefNo = value; } }
        private string _LeasingPartner = string.Empty;
        public string LeasingPartner { get { return _LeasingPartner; } set { _LeasingPartner = value; } }

        private string _LeaseTerm = string.Empty;
        public string LeaseTerm { get { return _LeaseTerm; } set { _LeaseTerm = value; } }
        private string _DtContractFrom = string.Empty;
        public string DtContractFrom { get { return _DtContractFrom; } set { _DtContractFrom = value; } }

        private string _DtContractTill = string.Empty;
        public string DtContractTill { get { return _DtContractTill; } set { _DtContractTill = value; } }

        private string _Description = string.Empty;
        public string Description { get { return _Description; } set { _Description = value; } }

        private string _CityName = string.Empty;
        public string CityName { get { return _CityName; } set { _CityName = value; } }
        private string _DepotName = string.Empty;
        public string DepotName { get { return _DepotName; } set { _DepotName = value; } }
        private string _Status = string.Empty;
        public string Status { get { return _Status; } set { _Status = value; } }
        private int _LeaseTermID;
        public int LeaseTermID { get { return _LeaseTermID; } set { _LeaseTermID = value; } }

        private int _LeasingPartnerID;
        public int LeasingPartnerID { get { return _LeasingPartnerID; } set { _LeasingPartnerID = value; } }

        private string _Remarks = string.Empty;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }
        public string Items;

        public string ItemDrUp;
        private int _LeaseContractID;
        public int LeaseContractID { get { return _LeaseContractID; } set { _LeaseContractID = value; } }
        private int _CntrTypeID;
        public int CntrTypeID { get { return _CntrTypeID; } set { _CntrTypeID = value; } }
        private int _Quantity;
        public int Quantity { get { return _Quantity; } set { _Quantity = value; } }
        private int _Cntrcount;
        public int Cntrcount { get { return _Cntrcount; } set { _Cntrcount = value; } }
        private int _FreeDays;
        public int FreeDays { get { return _FreeDays; } set { _FreeDays = value; } }

        private decimal _PerDiemAmt;
        public decimal PerDiemAmt { get { return _PerDiemAmt; } set { _PerDiemAmt = value; } }
        private int _PerDiemAmountCurr;
        public int PerDiemAmountCurr { get { return _PerDiemAmountCurr; } set { _PerDiemAmountCurr = value; } }
        private decimal _InsuranceAmt;
        public decimal InsuranceAmt { get { return _InsuranceAmt; } set { _InsuranceAmt = value; } }

        private int _InsuranceAmtCurr;
        public int InsuranceAmtCurr { get { return _InsuranceAmtCurr; } set { _InsuranceAmtCurr = value; } }

        private int _PickUpLocID;
        public int PickUpLocID { get { return _PickUpLocID; } set { _PickUpLocID = value; } }
        private decimal _PickUpTariffAmt;
        public decimal PickUpTariffAmt { get { return _PickUpTariffAmt; } set { _PickUpTariffAmt = value; } }
        private int _PickUpCurrID;
        public int PickUpCurrID { get { return _PickUpCurrID; } set { _PickUpCurrID = value; } }
        private int _DebitCredit;
        public int DebitCredit { get { return _DebitCredit; } set { _DebitCredit = value; } }
        private int _PickUpDepotID;
        public int PickUpDepotID { get { return _PickUpDepotID; } set { _PickUpDepotID = value; } }

        private int _DropUpLocID;
        public int DropUpLocID { get { return _DropUpLocID; } set { _DropUpLocID = value; } }
        private decimal _DropUpTariffAmt;
        public decimal DropUpTariffAmt { get { return _DropUpTariffAmt; } set { _DropUpTariffAmt = value; } }
        private int _DropUpCurrID;
        public int DropUpCurrID { get { return _DropUpCurrID; } set { _DropUpCurrID = value; } }
        private int _DropUpDepotID;
        public int DropUpDepotID { get { return _DropUpDepotID; } set { _DropUpDepotID = value; } }
        private string _Size = string.Empty;
        public string Size { get { return _Size; } set { _Size = value; } }

        private int _TypeID;
        public int TypeID { get { return _TypeID; } set { _TypeID = value; } }

        private string _CntrValue = string.Empty;
        public string CntrValue { get { return _CntrValue; } set { _CntrValue = value; } }

        private int _CntrValueCurrID;
        public int CntrValueCurrID { get { return _CntrValueCurrID; } set { _CntrValueCurrID = value; } }

    }

    public class MyLeaseDetails
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }
        private int _LID;
        public int LID { get { return _LID; } set { _LID = value; } }

        private int _LeaseContractID;
        public int LeaseContractID { get { return _LeaseContractID; } set { _LeaseContractID = value; } }
        private int _CntrTypeID;
        public int CntrTypeID { get { return _CntrTypeID; } set { _CntrTypeID = value; } }
        private int _Qty;
        public int Qty { get { return _Qty; } set { _Qty = value; } }
        private int _Cntrcount;
        public int Cntrcount { get { return _Cntrcount; } set { _Cntrcount = value; } }

        private int _FreeDays;
        public int FreeDays { get { return _FreeDays; } set { _FreeDays = value; } }

        private decimal _PerDiemAmt;
        public decimal PerDiemAmt { get { return _PerDiemAmt; } set { _PerDiemAmt = value; } }
        private int _PerDiemCurrID;
        public int PerDiemCurrID { get { return _PerDiemCurrID; } set { _PerDiemCurrID = value; } }
        private decimal _InsAmt;
        public decimal InsAmt { get { return _InsAmt; } set { _InsAmt = value; } }

        private int _InsCurrID;
        public int InsCurrID { get { return _InsCurrID; } set { _InsCurrID = value; } }

        private int _PickUpPortID;
        public int PickUpPortID { get { return _PickUpPortID; } set { _PickUpPortID = value; } }
        private decimal _PickUpTariffAmt;
        public decimal PickUpTariffAmt { get { return _PickUpTariffAmt; } set { _PickUpTariffAmt = value; } }
        private int _PickUpCurrID;
        public int PickUpCurrID { get { return _PickUpCurrID; } set { _PickUpCurrID = value; } }
        private int _PickUpDebitID;
        public int PickUpDebitID { get { return _PickUpDebitID; } set { _PickUpDebitID = value; } }
        private int _PickUpDepotID;
        public int PickUpDepotID { get { return _PickUpDepotID; } set { _PickUpDepotID = value; } }

        private decimal _DPPAmt;
        public decimal DPPAmt { get { return _DPPAmt; } set { _DPPAmt = value; } }
        private int _DPPCurrID;
        public int DPPCurrID { get { return _DPPCurrID; } set { _DPPCurrID = value; } }
        private int _DropOffPortID;
        public int DropOffPortID { get { return _DropOffPortID; } set { _DropOffPortID = value; } }
        private decimal _DropOffTariffAmt;
        public decimal DropOffTariffAmt { get { return _DropOffTariffAmt; } set { _DropOffTariffAmt = value; } }
        private int _DropOffCurrID;
        public int DropOffCurrID { get { return _DropOffCurrID; } set { _DropOffCurrID = value; } }
        private int _DropOffDebitID;
        public int DropOffDebitID { get { return _DropOffDebitID; } set { _DropOffDebitID = value; } }
        private string _Size = string.Empty;
        public string Size { get { return _Size; } set { _Size = value; } }
        private string _Remarks = string.Empty;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }
        private string _PickUpLoc = string.Empty;
        public string PickUpLoc { get { return _PickUpLoc; } set { _PickUpLoc = value; } }
        private string _PickUpDepot = string.Empty;
        public string PickUpDepot { get { return _PickUpDepot; } set { _PickUpDepot = value; } }
        private string _DropOffLoc = string.Empty;
        public string DropOffLoc { get { return _DropOffLoc; } set { _DropOffLoc = value; } }

        private string _CntrType = string.Empty;
        public string CntrType { get { return _CntrType; } set { _CntrType = value; } }
        private string _PickUpPort = string.Empty;
        public string PickUpPort { get { return _PickUpPort; } set { _PickUpPort = value; } }
        private string _PickUpCurr = string.Empty;
        public string PickUpCurr { get { return _PickUpCurr; } set { _PickUpCurr = value; } }

        private string _PerDiemCurr = string.Empty;
        public string PerDiemCurr { get { return _PerDiemCurr; } set { _PerDiemCurr = value; } }

        private string _InsCurr = string.Empty;
        public string InsCurr { get { return _InsCurr; } set { _InsCurr = value; } }

        private string _DPPCurr = string.Empty;
        public string DPPCurr { get { return _DPPCurr; } set { _DPPCurr = value; } }

        private string _DropOffPort = string.Empty;
        public string DropOffPort { get { return _DropOffPort; } set { _DropOffPort = value; } }

        private string _DropOffCurr = string.Empty;
        public string DropOffCurr { get { return _DropOffCurr; } set { _DropOffCurr = value; } }
        private string _PickUpDebit = string.Empty;
        public string PickUpDebit { get { return _PickUpDebit; } set { _PickUpDebit = value; } }
        private string _DropOffDebit = string.Empty;
        public string DropOffDebit { get { return _DropOffDebit; } set { _DropOffDebit = value; } }
        private string _DropOffDepot = string.Empty;
        public string DropOffDepot { get { return _DropOffDepot; } set { _DropOffDepot = value; } }

        private int _DropOffDepotID;
        public int DropOffDepotID { get { return _DropOffDepotID; } set { _DropOffDepotID = value; } }

        private decimal _HDIF;
        public decimal HDIF { get { return _HDIF; } set { _HDIF = value; } }

        private string _HDIFCurr = string.Empty;
        public string HDIFCurr { get { return _HDIFCurr; } set { _HDIFCurr = value; } }

        private int _HDIFCurrID;
        public int HDIFCurrID { get { return _HDIFCurrID; } set { _HDIFCurrID = value; } }

        private decimal _HDOF;
        public decimal HDOF { get { return _HDOF; } set { _HDOF = value; } }

        private string _HDOFCurr = string.Empty;
        public string HDOFCurr { get { return _HDOFCurr; } set { _HDOFCurr = value; } }

        private int _HDOFCurrID;
        public int HDOFCurrID { get { return _HDOFCurrID; } set { _HDOFCurrID = value; } }
    }



    #endregion

    #region 0N-HIRE
    public class MyOnHire
    {
        public string SessionFinYear = "";
        public string AgentCode = "";
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }
        private int _HID;
        public int HID { get { return _HID; } set { _HID = value; } }
        private string _ContractRefNo = string.Empty;
        public string ContractRefNo { get { return _ContractRefNo; } set { _ContractRefNo = value; } }


        private int _CntrTypeID;
        public int CntrTypeID { get { return _CntrTypeID; } set { _CntrTypeID = value; } }

        private int _LeaseContractID;
        public int LeaseContractID { get { return _LeaseContractID; } set { _LeaseContractID = value; } }

        private string _RequestNo = string.Empty;
        public string RequestNo { get { return _RequestNo; } set { _RequestNo = value; } }

        private int _PickUpRefID;
        public int PickUpRefID { get { return _PickUpRefID; } set { _PickUpRefID = value; } }

        private int _LeasingPartnerID;
        public int LeasingPartnerID { get { return _LeasingPartnerID; } set { _LeasingPartnerID = value; } }
        private int _LeasingTermID;
        public int LeasingTermID { get { return _LeasingTermID; } set { _LeasingTermID = value; } }
        private int _BoxOwnerID;
        public int BoxOwnerID { get { return _BoxOwnerID; } set { _BoxOwnerID = value; } }

        private string _DtCreated = string.Empty;
        public string DtCreated { get { return _DtCreated; } set { _DtCreated = value; } }

        private string _Remarks = string.Empty;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }
        private string _CustomerName = string.Empty;
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }
        public string ItemsCntrs;

        private int _CntrPickUpRefID;
        public int CntrPickUpRefID { get { return _CntrPickUpRefID; } set { _CntrPickUpRefID = value; } }

        private int _CntrLeasingPartnerID;
        public int CntrLeasingPartnerID { get { return _CntrLeasingPartnerID; } set { _CntrLeasingPartnerID = value; } }
        private int _CntrBoxOwnerID;
        public int CntrBoxOwnerID { get { return _CntrBoxOwnerID; } set { _CntrBoxOwnerID = value; } }

        private string _LeasingPartner = string.Empty;
        public string LeasingPartner { get { return _LeasingPartner; } set { _LeasingPartner = value; } }

        private string _LeaseTerm = string.Empty;
        public string LeaseTerm { get { return _LeaseTerm; } set { _LeaseTerm = value; } }
        private int _Isapproved;
        public int Isapproved { get { return _Isapproved; } set { _Isapproved = value; } }

        private int _CntrID;
        public int CntrID { get { return _CntrID; } set { _CntrID = value; } }
        private string _PortID = string.Empty;
        public string PortID { get { return _PortID; } set { _PortID = value; } }

        private string _DepotID = string.Empty;
        public string DepotID { get { return _DepotID; } set { _DepotID = value; } }
    }
    #endregion

    #region OFF-HIRE

    public class MyOffHire
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _CntrNo = string.Empty;
        public string CntrNo { get { return _CntrNo; } set { _CntrNo = value; } }

        private string _Size = string.Empty;
        public string Size { get { return _Size; } set { _Size = value; } }

        private string _ContractRefNo = string.Empty;
        public string ContractRefNo { get { return _ContractRefNo; } set { _ContractRefNo = value; } }
        private int _CntrID;
        public int CntrID { get { return _CntrID; } set { _CntrID = value; } }

        private int _SizeTypeID;
        public int SizeTypeID { get { return _SizeTypeID; } set { _SizeTypeID = value; } }

        private int _CusID;
        public int CusID { get { return _CusID; } set { _CusID = value; } }

        private string _CustomerName = string.Empty;
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }
        private string _LeasingTerm = string.Empty;
        public string LeasingTerm { get { return _LeasingTerm; } set { _LeasingTerm = value; } }
        private string _OffHireDepot = string.Empty;
        public string OffHireDepot { get { return _OffHireDepot; } set { _OffHireDepot = value; } }
        private string _OffHirePort = string.Empty;
        public string OffHirePort { get { return _OffHirePort; } set { _OffHirePort = value; } }
        private string _LeasingPartner = string.Empty;
        public string LeasingPartner { get { return _LeasingPartner; } set { _LeasingPartner = value; } }

        private int _LeasingTermID;
        public int LeasingTermID { get { return _LeasingTermID; } set { _LeasingTermID = value; } }
        private int _LeasingPartnerID;
        public int LeasingPartnerID { get { return _LeasingPartnerID; } set { _LeasingPartnerID = value; } }

        private int _PickUpRefID;
        public int PickUpRefID { get { return _PickUpRefID; } set { _PickUpRefID = value; } }
        private decimal _DropOffTariff;
        public decimal DropOffTariff { get { return _DropOffTariff; } set { _DropOffTariff = value; } }

        private int _DropOffTariffCurrID;
        public int DropOffTariffCurrID { get { return _DropOffTariffCurrID; } set { _DropOffTariffCurrID = value; } }

        private int _OffHirePortID;
        public int OffHirePortID { get { return _OffHirePortID; } set { _OffHirePortID = value; } }

        private int _OffHireDepotID;
        public int OffHireDepotID { get { return _OffHireDepotID; } set { _OffHireDepotID = value; } }
        private int _ResponseAgencyID;
        public int ResponseAgencyID { get { return _ResponseAgencyID; } set { _ResponseAgencyID = value; } }

        private string _DtOffHire = string.Empty;
        public string DtOffHire { get { return _DtOffHire; } set { _DtOffHire = value; } }

        private string _Remarks = string.Empty;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }
        private string _CurrencyCode = string.Empty;
        public string CurrencyCode { get { return _CurrencyCode; } set { _CurrencyCode = value; } }
    }
    #endregion

    #region Cntr Movement Entry
    public class MyCntrMoveMent
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _ToStatus = string.Empty;
        public string ToStatus { get { return _ToStatus; } set { _ToStatus = value; } }
        private string _GeneralName = string.Empty;
        public string GeneralName { get { return _GeneralName; } set { _GeneralName = value; } }
        private int _ContainerID;
        public int ContainerID { get { return _ContainerID; } set { _ContainerID = value; } }
        private int _LocationID;
        public int LocationID { get { return _LocationID; } set { _LocationID = value; } }

        private string _StatusCode = string.Empty;
        public string StatusCode { get { return _StatusCode; } set { _StatusCode = value; } }

        private string _VesVoy = string.Empty;
        public string VesVoy { get { return _VesVoy; } set { _VesVoy = value; } }

        private string _ToStatusCode = string.Empty;
        public string ToStatusCode { get { return _ToStatusCode; } set { _ToStatusCode = value; } }

        private string _DtMovement = string.Empty;
        public string DtMovement { get { return _DtMovement; } set { _DtMovement = value; } }

        private int _VesVoyID;
        public int VesVoyID { get { return _VesVoyID; } set { _VesVoyID = value; } }

        private int _NextPortID;
        public int NextPortID { get { return _NextPortID; } set { _NextPortID = value; } }

        private int _ModeOfTransportID;
        public int ModeOfTransportID { get { return _ModeOfTransportID; } set { _ModeOfTransportID = value; } }

        private int _DepotID;
        public int DepotID { get { return _DepotID; } set { _DepotID = value; } }

        private int _CustomerID;
        public int CustomerID { get { return _CustomerID; } set { _CustomerID = value; } }



        private int _UserID;
        public int UserID { get { return _UserID; } set { _UserID = value; } }

        private int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }
        private int _CntrID;
        public int CntrID { get { return _CntrID; } set { _CntrID = value; } }

        private int _CntrTypeID;
        public int CntrTypeID { get { return _CntrTypeID; } set { _CntrTypeID = value; } }

        private string _CntrNo = string.Empty;
        public string CntrNo { get { return _CntrNo; } set { _CntrNo = value; } }
        private string _Size = string.Empty;
        public string Size { get { return _Size; } set { _Size = value; } }
        private string _FromPort = string.Empty;
        public string FromPort { get { return _FromPort; } set { _FromPort = value; } }

        private string _NextPort = string.Empty;
        public string NextPort { get { return _NextPort; } set { _NextPort = value; } }
        private string _TransitMode = string.Empty;
        public string TransitMode { get { return _TransitMode; } set { _TransitMode = value; } }

        private string _Depot = string.Empty;
        public string Depot { get { return _Depot; } set { _Depot = value; } }

        private string _CustomerName = string.Empty;
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }

        private string _ToStatusCodes = string.Empty;
        public string ToStatusCodes { get { return _ToStatusCodes; } set { _ToStatusCodes = value; } }
        private string _AgencyName = string.Empty;
        public string AgencyName { get { return _AgencyName; } set { _AgencyName = value; } }

        private int _TxnsID;
        public int TxnsID { get { return _TxnsID; } set { _TxnsID = value; } }

        private int _FromPortID;
        public int FromPortID { get { return _FromPortID; } set { _FromPortID = value; } }

        private int _BLID;
        public int BLID { get { return _BLID; } set { _BLID = value; } }

        public string ItemsCntrIDs;
        public string ItemsStatusCodes;

        private string _LoginAgency = string.Empty;
        public string LoginAgency { get { return _LoginAgency; } set { _LoginAgency = value; } }

        private string _OnHireAgency = string.Empty;
        public string OnHireAgency { get { return _OnHireAgency; } set { _OnHireAgency = value; } }

        private string _BLNumber = string.Empty;
        public string BLNumber { get { return _BLNumber; } set { _BLNumber = value; } }

        private string _BookingNo = string.Empty;
        public string BookingNo { get { return _BookingNo; } set { _BookingNo = value; } }

        private string _ChkFlag = string.Empty;
        public string ChkFlag { get { return _ChkFlag; } set { _ChkFlag = value; } }

        private string _DateValidation = string.Empty;
        public string DateValidation { get { return _DateValidation; } set { _DateValidation = value; } }

        private string _StorageCode = string.Empty;
        public string StorageCode { get { return _StorageCode; } set { _StorageCode = value; } }

        private string _ContainerNos = string.Empty;
        public string ContainerNos { get { return _ContainerNos; } set { _ContainerNos = value; } }


        private string _Location = string.Empty;
        public string Location { get { return _Location; } set { _Location = value; } }

        private string _Status = string.Empty;
        public string Status { get { return _Status; } set { _Status = value; } }

        public string Message = "";
        public string Items = "";
        public string RefFNo = "";
        public string OfficeLocation = "";
        public string MovementDate = "";
        public string MovementTypeID = "";
        public string MovementType = "";
        public string CurrentLocationID = "";
        public string NewStorageLocationID = "";
        public string NewStorageLocation = "";
        public string BookingID = "";
        public string StatusCodeID = "";
        public string SessionFinYear = "";
        public string UnitCount = "";
        public string UplodStatus = "";
        public string StorageLocation = "";
        public string StatuID = "";
        public string Date = "";
        public string Dateto = "";
        public int TransationStatus;
        public int Source;
        public string TransationStatusV = "";

    }

    #endregion

    #region Statuscode inventory
    public class MyStatusCode
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private int _SID;
        public int SID { get { return _SID; } set { _SID = value; } }

        private int _ToStatusID;
        public int ToStatusID { get { return _ToStatusID; } set { _ToStatusID = value; } }

        private string _Status = string.Empty;
        public string Status { get { return _Status; } set { _Status = value; } }

        private string _StatusDescription = string.Empty;
        public string StatusDescription { get { return _StatusDescription; } set { _StatusDescription = value; } }

        private string _StatusResult = string.Empty;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }

        private int _StatusID;
        public int StatusID { get { return _StatusID; } set { _StatusID = value; } }

        private int _ValidVslVoy;
        public int ValidVslVoy { get { return _ValidVslVoy; } set { _ValidVslVoy = value; } }

        private int _ValidNextLoc;
        public int ValidNextLoc { get { return _ValidNextLoc; } set { _ValidNextLoc = value; } }

        private int _ValidTransMode;
        public int ValidTransMode { get { return _ValidTransMode; } set { _ValidTransMode = value; } }

        private int _ValidDepot;
        public int ValidDepot { get { return _ValidDepot; } set { _ValidDepot = value; } }

        private int _ValidBL;
        public int ValidBL { get { return _ValidBL; } set { _ValidBL = value; } }

        private int _ValidCustomer;
        public int ValidCustomer { get { return _ValidCustomer; } set { _ValidCustomer = value; } }

        private int _ValidTerminal;
        public int ValidTerminal { get { return _ValidTerminal; } set { _ValidTerminal = value; } }

        public string Itemsv;
        private string _GeneralName = string.Empty;
        public string GeneralName { get { return _GeneralName; } set { _GeneralName = value; } }
        private int _StatusCodeID;
        public int StatusCodeID { get { return _StatusCodeID; } set { _StatusCodeID = value; } }
        private string _ToStatusDescription = string.Empty;
        public string ToStatusDescription { get { return _ToStatusDescription; } set { _ToStatusDescription = value; } }

        private string _ToStatus = string.Empty;
        public string ToStatus { get { return _ToStatus; } set { _ToStatus = value; } }
        public string AlertMegId;
        public string AlertMessage;
    }
    #endregion

    #endregion

    #region anand
    public class MyContainerRent
    {
        public int ID;
        public int TariffTypeID;
        public int ContainerType;
        public int ChargeTypeID;
        public int ChargesID;
        public int ChargeOwnerID;
        public int ShipmentTypeID;
        public int PortID;
        public int CustomerID;
        public int TerminalID;
        public int DepotID;
        public int StartingMove;
        public int EndingMove;
        public int AutoRunTypeID;
        public string ValidFrom;
        public string ValidTill;
        public int Status;

        public string TariffTypeV;
        public string CustomerV;
        public string Size;
        public string ShipmentTypeV;
        public string ChargeOwnerIDV;
        public string UserID;
        public string AgencyID;

        public int CID;
        public int RentID;
        public int SlabFrom;
        public int SlabTo;
        public int CurrencyID;
        public string Currency;
        public string Amount;
        public string Itemsv1;
        public string Charges;
        public string ChargeType;

    }
    #endregion

    #region muthu
    public class MyContainer
    {
        public int ID = 0;
        public string CntrNo = "";
        public string Size = "";
        public string Type = "";
        public string PickupDate = "";
        public string BLNo = "";
        public string AlertMegId;
        public string AlertMessage;
        public int OPT = 0;
        public int BLID = 0;
        public int CntrID = 0;
        public int PartBL = 0;
        public int BkgID = 0;
        public string Status = "";
        public string Commodity = "";
        public string GateInDate = "";

    }


    #endregion
}




