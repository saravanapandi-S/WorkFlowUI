using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyFinance
    {


    }
    #region GANESH (finance- chargecode,taxdecl,taxengine)
    public class MyChargeCode
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _ChgCode = string.Empty;
        public string ChgCode { get { return _ChgCode; } set { _ChgCode = value; } }

        private string _ChgDesc = string.Empty;
        public string ChgDesc { get { return _ChgDesc; } set { _ChgDesc = value; } }

        private string _SACCode = string.Empty;
        public string SACCode { get { return _SACCode; } set { _SACCode = value; } }

        private string _ChgSacCode = string.Empty;
        public string ChgSacCode { get { return _ChgSacCode; } set { _ChgSacCode = value; } }

        private string _ShipmentType = string.Empty;
        public string ShipmentType { get { return _ShipmentType; } set { _ShipmentType = value; } }

        private string _DtValidFrom = string.Empty;
        public string DtValidFrom { get { return _DtValidFrom; } set { _DtValidFrom = value; } }


        private string _DtValidTill = string.Empty;
        public string DtValidTill { get { return _DtValidTill; } set { _DtValidTill = value; } }
        private int _IsRevenue;
        public int IsRevenue { get { return _IsRevenue; } set { _IsRevenue = value; } }

        private int _BasisID;
        public int BasisID { get { return _BasisID; } set { _BasisID = value; } }
        private int _ChargeGroupID;
        public int ChargeGroupID { get { return _ChargeGroupID; } set { _ChargeGroupID = value; } }
        private int _OwnershipID;
        public int OwnershipID { get { return _OwnershipID; } set { _OwnershipID = value; } }

        private int _ShipmentTypeID;
        public int ShipmentTypeID { get { return _ShipmentTypeID; } set { _ShipmentTypeID = value; } }

        private int _StateID;
        public int StateID { get { return _StateID; } set { _StateID = value; } }
        public string GeneralName;
        public string StateName;
        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private int _IsNVOCC;
        public int IsNVOCC { get { return _IsNVOCC; } set { _IsNVOCC = value; } }
        private int _IsForwarding;
        public int IsForwarding { get { return _IsForwarding; } set { _IsForwarding = value; } }
        private int _IsDeposit;
        public int IsDeposit { get { return _IsDeposit; } set { _IsDeposit = value; } }
        private string _ChargeGroup = string.Empty;
        public string ChargeGroup { get { return _ChargeGroup; } set { _ChargeGroup = value; } }

        private string _Basis = string.Empty;
        public string Basis { get { return _Basis; } set { _Basis = value; } }

        private string _Ownership = string.Empty;
        public string Ownership { get { return _Ownership; } set { _Ownership = value; } }
        private string _StatusResult = string.Empty;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }

        private string _Remarks = string.Empty;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }
        private string _DtModified = string.Empty;
        public string DtModified { get { return _DtModified; } set { _DtModified = value; } }

        private string _DtCreated = string.Empty;
        public string DtCreated { get { return _DtCreated; } set { _DtCreated = value; } }

        private string _TaxCode1 = string.Empty;
        public string TaxCode1 { get { return _TaxCode1; } set { _TaxCode1 = value; } }

        private string _TaxCode2 = string.Empty;
        public string TaxCode2 { get { return _TaxCode2; } set { _TaxCode2 = value; } }

        private string _TaxPercentage = string.Empty;
        public string TaxPercentage { get { return _TaxPercentage; } set { _TaxPercentage = value; } }

        private string _CountryName = string.Empty;
        public string CountryName { get { return _CountryName; } set { _CountryName = value; } }


        private string _StatusV = string.Empty;
        public string StatusV { get { return _StatusV; } set { _StatusV = value; } }

        private int _TaxPercentageID;
        public int TaxPercentageID { get { return _TaxPercentageID; } set { _TaxPercentageID = value; } }

        private decimal _TaxCodePercentage1;
        public decimal TaxCodePercentage1 { get { return _TaxCodePercentage1; } set { _TaxCodePercentage1 = value; } }

        private decimal _TaxCodePercentage2;
        public decimal TaxCodePercentage2 { get { return _TaxCodePercentage2; } set { _TaxCodePercentage2 = value; } }


        private string _TaxGL1 = string.Empty;
        public string TaxGL1 { get { return _TaxGL1; } set { _TaxGL1 = value; } }
        private int _ChargeTBID;
        public int ChargeTBID { get { return _ChargeTBID; } set { _ChargeTBID = value; } }


        private string _TaxGL2 = string.Empty;
        public string TaxGL2 { get { return _TaxGL2; } set { _TaxGL2 = value; } }


        private int _CountryID;
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }

        private int _StatusID;
        public int StatusID { get { return _StatusID; } set { _StatusID = value; } }

        public string Itemsv;
        private string _TaxGL = string.Empty;
        public string TaxGL { get { return _TaxGL; } set { _TaxGL = value; } }

        private int _TaxGLID;
        public int TaxGLID { get { return _TaxGLID; } set { _TaxGLID = value; } }
        private string _TaxCode = string.Empty;
        public string TaxCode { get { return _TaxCode; } set { _TaxCode = value; } }

        private int _TaxCodeID;
        public int TaxCodeID { get { return _TaxCodeID; } set { _TaxCodeID = value; } }
        private string _TaxDescription = string.Empty;
        public string TaxDescription { get { return _TaxDescription; } set { _TaxDescription = value; } }
        private string _Percentage = string.Empty;
        public string Percentage { get { return _Percentage; } set { _Percentage = value; } }

        private string _GLCode = string.Empty;
        public string GLCode { get { return _GLCode; } set { _GLCode = value; } }
        private int _TID;
        public int TID { get { return _TID; } set { _TID = value; } }
        private string _TaxName = string.Empty;
        public string TaxName { get { return _TaxName; } set { _TaxName = value; } }

        private string _TaxDescrption = string.Empty;
        public string TaxDescrption { get { return _TaxDescrption; } set { _TaxDescrption = value; } }
        private int _UserID;
        public int UserID { get { return _UserID; } set { _UserID = value; } }

        private int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }
        private int _IsBreakUp;
        public int IsBreakUp { get { return _IsBreakUp; } set { _IsBreakUp = value; } }

    }

    public class MyCreditControl
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _CustomerName = string.Empty;
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }

        private int _PartyID;
        public int PartyID { get { return _PartyID; } set { _PartyID = value; } }
        private int _PartyType;
        public int PartyType { get { return _PartyType; } set { _PartyType = value; } }
        private int _ExemptFromTax;
        public int ExemptFromTax { get { return _ExemptFromTax; } set { _ExemptFromTax = value; } }

        private string _Remarks = string.Empty;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }
        private string _CusCreditDays = string.Empty;
        public string CusCreditDays { get { return _CusCreditDays; } set { _CusCreditDays = value; } }
        private string _CusCreditLimit = string.Empty;
        public string CusCreditLimit { get { return _CusCreditLimit; } set { _CusCreditLimit = value; } }
        private int _CusEmailAlert;
        public int CusEmailAlert { get { return _CusEmailAlert; } set { _CusEmailAlert = value; } }

        private string _VendorCreditDays = string.Empty;
        public string VendorCreditDays { get { return _VendorCreditDays; } set { _VendorCreditDays = value; } }
        private string _VendorCreditLimit = string.Empty;
        public string VendorCreditLimit { get { return _VendorCreditLimit; } set { _VendorCreditLimit = value; } }

        private int _VendorEmailAlert;
        public int VendorEmailAlert { get { return _VendorEmailAlert; } set { _VendorEmailAlert = value; } }
        private int _VendorInvApproval;
        public int VendorInvApproval { get { return _VendorInvApproval; } set { _VendorInvApproval = value; } }
        private int _VendorPaymentApproval;
        public int VendorPaymentApproval { get { return _VendorPaymentApproval; } set { _VendorPaymentApproval = value; } }
        private string _PartyTypes = string.Empty;
        public string PartyTypes { get { return _PartyTypes; } set { _PartyTypes = value; } }

        private string _TaxExempt = string.Empty;
        public string TaxExempt { get { return _TaxExempt; } set { _TaxExempt = value; } }
        private string _Currency = string.Empty;
        public string Currency { get { return _Currency; } set { _Currency = value; } }
        private int _CCID;
        public int CCID { get { return _CCID; } set { _CCID = value; } }
        private string _Status = string.Empty;
        public string Status { get { return _Status; } set { _Status = value; } }

        private string _DefaultC = string.Empty;
        public string DefaultC { get { return _DefaultC; } set { _DefaultC = value; } }

        private int _CurrencyID;
        public int CurrencyID { get { return _CurrencyID; } set { _CurrencyID = value; } }
        private int _DefaultID;
        public int DefaultID { get { return _DefaultID; } set { _DefaultID = value; } }
        private int _StatusID;
        public int StatusID { get { return _StatusID; } set { _StatusID = value; } }

        private int _VCID;
        public int VCID { get { return _VCID; } set { _VCID = value; } }
        private string _StatusV = string.Empty;
        public string StatusV { get { return _StatusV; } set { _StatusV = value; } }
        private string _CurrencyV = string.Empty;
        public string CurrencyV { get { return _CurrencyV; } set { _CurrencyV = value; } }
        private string _DefaultV = string.Empty;
        public string DefaultV { get { return _DefaultV; } set { _DefaultV = value; } }

        private int _CurrencyVID;
        public int CurrencyVID { get { return _CurrencyVID; } set { _CurrencyVID = value; } }
        private int _DefaultVID;
        public int DefaultVID { get { return _DefaultVID; } set { _DefaultVID = value; } }
        private int _StatusVID;
        public int StatusVID { get { return _StatusVID; } set { _StatusVID = value; } }

        private string _GeneralName = string.Empty;
        public string GeneralName { get { return _GeneralName; } set { _GeneralName = value; } }

        private string _UserID = string.Empty;
        public string UserID { get { return _UserID; } set { _UserID = value; } }

        private string _AgencyID = string.Empty;
        public string AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }

        public string ItemsC;
        public string ItemsV;

        private string _SunDryAcc = string.Empty;
        public string SunDryAcc { get { return _SunDryAcc; } set { _SunDryAcc = value; } }

        private string _CusSunDryAcc = string.Empty;
        public string CusSunDryAcc { get { return _CusSunDryAcc; } set { _CusSunDryAcc = value; } }

        private string _VenSunDryAcc = string.Empty;
        public string VenSunDryAcc { get { return _VenSunDryAcc; } set { _VenSunDryAcc = value; } }
        
    }

    public class MyBankMaster
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _BankMasterMode = string.Empty;
        public string BankMasterMode { get { return _BankMasterMode; } set { _BankMasterMode = value; } }
        public string Itemsv;
        public string ItemsDoc;
        
        private int _ModeID;
        public int ModeID { get { return _ModeID; } set { _ModeID = value; } }

        private int _CurrencyID;
        public int CurrencyID { get { return _CurrencyID; } set { _CurrencyID = value; } }

        private int _GLCodeID;
        public int GLCodeID { get { return _GLCodeID; } set { _GLCodeID = value; } }

        private int _StatusID;
        public int StatusID { get { return _StatusID; } set { _StatusID = value; } }

        private int _UserID;
        public int UserID { get { return _UserID; } set { _UserID = value; } }

        private string _BankCode = string.Empty;
        public string BankCode { get { return _BankCode; } set { _BankCode = value; } }

        private string _BankName = string.Empty;
        public string BankName { get { return _BankName; } set { _BankName = value; } }

        private string _AccountNo = string.Empty;
        public string AccountNo { get { return _AccountNo; } set { _AccountNo = value; } }

        private string _Status = string.Empty;
        public string Status { get { return _Status; } set { _Status = value; } }

        private string _Agency = string.Empty;
        public string Agency { get { return _Agency; } set { _Agency = value; } }

        private int _BID;
        public int BID { get { return _BID; } set { _BID = value; } }

        private int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }

        private int _AID;
        public int AID { get { return _AID; } set { _AID = value; } }

        private string _File = string.Empty;
        public string File { get { return _File; } set { _File = value; } }

        private string _FileName = string.Empty;
        public string FileName { get { return _FileName; } set { _FileName = value; } }

        private string _BranchAddress = string.Empty;
        public string BranchAddress { get { return _BranchAddress; } set { _BranchAddress = value; } }

        private string _IFSCCode = string.Empty;
        public string IFSCCode { get { return _IFSCCode; } set { _IFSCCode = value; } }

        private string _BranchName = string.Empty;
        public string BranchName { get { return _BranchName; } set { _BranchName = value; } }

        private string _SwiftCode = string.Empty;
        public string SwiftCode { get { return _SwiftCode; } set { _SwiftCode = value; } }

        
    }
    #endregion

    #region anand
    public class MyGLMapping
    {
        public int ID;
        public int GLMapID;
        public int ChargeCodeID;
        public int ProductTypeID;
        public int ShipmentTypeID;
        public int PrincipalRevGL;
        public int PrincipalExpGL;
        public int AgencyRevGL;
        public int AgencyExpGL;
        public string ValidFrom;
        public int UserID;
        public int LocID;
        public int AgencyID;
        public DateTime CurrentDate;
        public string ChargeCodeV;
        public string ProductTypeV;
        public string ShipmentTypeV;
        public string PrincipalRevGLV;
        public string PrincipalExpGLV;
        public string Agency;
        public string CreatedOn;
        public string CreatedBy;
        public string ModifiedOn;
        public string ModifiedBy;
    }

    public class MYGLMaster
    {
        public int ID;
        public int GLID;
        public string GLCode;
        public int CompanyID;
        public int MainAccType;
        public int GLNature;
        public int Category;
        public int GLMatching;
        public int ProductType;
        public string GLDesc;
        public string CurrentDate;
        public string AgencyName;
        public string CategoryV;
        public string MainAccTypeV;
        public string ProductTypeV;
        public string StatusID;
        public string Status;
        public string UserID;
        public string AgencyID;
        public string GLNatureV;
        public string GLMatchingV;
        public string Company;
        public string CreatedOn;
        public string CreatedBy;
        public string ModifiedOn;
        public string ModifiedBy;
    }
    #endregion

}
