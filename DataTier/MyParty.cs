using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyParty
    {

    }
    #region anand
    public class MyCustomer
    {
        #region Customer

        public int Chkbox;

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _CustomerName = string.Empty;
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }

        private int _CustomerType;
        public int CustomerType { get { return _CustomerType; } set { _CustomerType = value; } }

        public string PartyType;

        private int _CountryID;
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }

        private int _CityID;
        public int CityID { get { return _CityID; } set { _CityID = value; } }

        private int _StateID;
        public int StateID { get { return _StateID; } set { _StateID = value; } }

        private string _PinCode = string.Empty;
        public string PinCode { get { return _PinCode; } set { _PinCode = value; } }

        private string _Fax = string.Empty;
        public string Fax { get { return _Fax; } set { _Fax = value; } }

        private string _Tel = string.Empty;
        public string Tel { get { return _Tel; } set { _Tel = value; } }

        private string _TelNo = string.Empty;
        public string TelNo { get { return _TelNo; } set { _TelNo = value; } }

        private string _GSTINTax = string.Empty;
        public string GSTINTax { get { return _GSTINTax; } set { _GSTINTax = value; } }

        private string _GSTIN = string.Empty;
        public string GSTIN { get { return _GSTIN; } set { _GSTIN = value; } }

        private string _EmailID = string.Empty;
        public string EmailID { get { return _EmailID; } set { _EmailID = value; } }

        private string _Address = string.Empty;
        public string Address { get { return _Address; } set { _Address = value; } }

        private string _BusinessType = string.Empty;
        public string BusinessType { get { return _BusinessType; } set { _BusinessType = value; } }

        private DateTime _CurrentDate;
        public DateTime CurrentDate { get { return _CurrentDate; } set { _CurrentDate = value; } }

        private int _CusID;
        public int CusID { get { return _CusID; } set { _CusID = value; } }

        private int _AID;
        public int AID { get { return _AID; } set { _AID = value; } }

        private string _CustomerID;
        public string CustomerID { get { return _CustomerID; } set { _CustomerID = value; } }

        private string _CityName = string.Empty;
        public string CityName { get { return _CityName; } set { _CityName = value; } }

        private string _City = string.Empty;
        public string City { get { return _City; } set { _City = value; } }


        private string _CountryName = string.Empty;
        public string CountryName { get { return _CountryName; } set { _CountryName = value; } }

        private string _StateName = string.Empty;
        public string StateName { get { return _StateName; } set { _StateName = value; } }
        private string _State = string.Empty;
        public string State { get { return _State; } set { _State = value; } }

        private int _CusLID;
        public int CusLID { get { return _CusLID; } set { _CusLID = value; } }



        private int _CID;
        public int CID { get { return _CID; } set { _CID = value; } }


        private int _CusAltID;
        public int CusAltID { get { return _CusAltID; } set { _CusAltID = value; } }

        private int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }

        private string _AlertType = string.Empty;
        public string AlertType { get { return _AlertType; } set { _AlertType = value; } }

        private string _AgencyName = string.Empty;
        public string AgencyName { get { return _AgencyName; } set { _AgencyName = value; } }
        private string _AlertTypeV = string.Empty;
        public string AlertTypeV { get { return _AlertTypeV; } set { _AlertTypeV = value; } }

        private int _CusInfoID;
        public int CusInfoID { get { return _CusInfoID; } set { _CusInfoID = value; } }

        private int _CusInID;
        public int CusInID { get { return _CusInID; } set { _CusInID = value; } }

        private int _InfoType;
        public int InfoType { get { return _InfoType; } set { _InfoType = value; } }

        private string _InfoTypeV = string.Empty;
        public string InfoTypeV { get { return _InfoTypeV; } set { _InfoTypeV = value; } }

        private string _InfoValue = string.Empty;
        public string InfoValue { get { return _InfoValue; } set { _InfoValue = value; } }

        private int _CusLinkID;
        public int CusLinkID { get { return _CusLinkID; } set { _CusLinkID = value; } }

        private int _BranchID;
        public int BranchID { get { return _BranchID; } set { _BranchID = value; } }

        private string _SalesPerson = string.Empty;
        public string SalesPerson { get { return _SalesPerson; } set { _SalesPerson = value; } }

        private DateTime _ValidFrom;
        public DateTime ValidFrom { get { return _ValidFrom; } set { _ValidFrom = value; } }

        private string _ValidFromV;
        public string ValidFromV { get { return _ValidFromV; } set { _ValidFromV = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _StatusV = string.Empty;
        public string StatusV { get { return _StatusV; } set { _StatusV = value; } }

        private string _Validfromdt = string.Empty;
        public string Validfromdt { get { return _Validfromdt; } set { _Validfromdt = value; } }

        private int _CusAttID;
        public int CusAttID { get { return _CusAttID; } set { _CusAttID = value; } }

        private string _AttachName = string.Empty;
        public string AttachName { get { return _AttachName; } set { _AttachName = value; } }

        private string _AttachFile = string.Empty;
        public string AttachFile { get { return _AttachFile; } set { _AttachFile = value; } }

        private string _AttachID = string.Empty;
        public string AttachID { get { return _AttachID; } set { _AttachID = value; } }

        private DateTime _UploadedOn;
        public DateTime UploadedOn { get { return _UploadedOn; } set { _UploadedOn = value; } }

        private string _UploadedBy = string.Empty;
        public string UploadedBy { get { return _UploadedBy; } set { _UploadedBy = value; } }

        private string _Branch = string.Empty;
        public string Branch { get { return _Branch; } set { _Branch = value; } }

        private string _LocBranch = string.Empty;
        public string LocBranch { get { return _LocBranch; } set { _LocBranch = value; } }

        private int _Cus;
        public int Cus { get { return _Cus; } set { _Cus = value; } }

        private string _Email = string.Empty;
        public string Email { get { return _Email; } set { _Email = value; } }

        private string _Link = string.Empty;
        public string Link { get { return _Link; } set { _Link = value; } }

        private string _StatusResult = string.Empty;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }
        private int _StatusID;
        public int StatusID { get { return _StatusID; } set { _StatusID = value; } }

        public string Itemsv1;
        public string Itemsv2;
        public string ItemsAddress;
        public string UserName;
        public int SalesPicID;

        private int _UserID;
        public int UserID { get { return _UserID; } set { _UserID = value; } }

        private string _PanNo = string.Empty;
        public string PanNo { get { return _PanNo; } set { _PanNo = value; } }

        private string _TanNo = string.Empty;
        public string TanNo { get { return _TanNo; } set { _TanNo = value; } }
        public int IsNVOCC;
        public int IsFF;

        public string PIC;
        private string _GeneralName = string.Empty;
        public string GeneralName { get { return _GeneralName; } set { _GeneralName = value; } }

        private string _GSTNo = string.Empty;
        public string GSTNo { get { return _GSTNo; } set { _GSTNo = value; } }

        private string _Legalname = string.Empty;
        public string Legalname { get { return _Legalname; } set { _Legalname = value; } }

        private string _PAN = string.Empty;
        public string PAN { get { return _PAN; } set { _PAN = value; } }


        private string _TAN = string.Empty;
        public string TAN { get { return _TAN; } set { _TAN = value; } }


        private string _POS = string.Empty;
        public string POS { get { return _POS; } set { _POS = value; } }

        private string _CurrencyCode = string.Empty;
        public string CurrencyCode { get { return _CurrencyCode; } set { _CurrencyCode = value; } }
        public int GSTListID;
        public int POSID;
        public int CurrID;
        public int StatusCrID;
        public int ApprovedBy;
        public string ApprovedName;
        public string TDSType;
        public string EffectiveDate;
        public string CreditDays;
        public string CreditLimit;
        public string EmailAlertID;
        private int _AlertTypeID;
        public int AlertTypeID { get { return _AlertTypeID; } set { _AlertTypeID = value; } }

        private int _TDS;
        public int TDS { get { return _TDS; } set { _TDS = value; } }
        public string AlertMegId;
        public string AlertMessage;
        public int BID;

        private int _IsTrue;
        public int IsTrue { get { return _IsTrue; } set { _IsTrue = value; } }
        private string _Division = string.Empty;
        public string Division { get { return _Division; } set { _Division = value; } }

        public string DivisionDetails;
        #endregion
    }


    public class MYCustomerBuss
    {
        public int ID;
        public string CusID = "";
        private int _IsTrue;
        public int IsTrue { get { return _IsTrue; } set { _IsTrue = value; } }
        private string _BusinessType = string.Empty;
        public string BusinessType { get { return _BusinessType; } set { _BusinessType = value; } }
    }
    #endregion
    #region Ganesh (Agency)
    public class MyAgency
    {
        public int ID;
        public string Itemsv1;
        public int UserID;
        private string _AgencyName = string.Empty;
        public string AgencyName { get { return _AgencyName; } set { _AgencyName = value; } }

        private string _AgencyCode = string.Empty;
        public string AgencyCode { get { return _AgencyCode; } set { _AgencyCode = value; } }

        private string _CountryID = string.Empty;
        public string CountryID { get { return _CountryID; } set { _CountryID = value; } }

        private string _CityID = string.Empty;
        public string CityID { get { return _CityID; } set { _CityID = value; } }

        private string _CityName = string.Empty;
        public string CityName { get { return _CityName; } set { _CityName = value; } }

        private string _CountryName = string.Empty;
        public string CountryName { get { return _CountryName; } set { _CountryName = value; } }
        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _StateID = string.Empty;
        public string StateID { get { return _StateID; } set { _StateID = value; } }

        private string _TaxGSTNo = string.Empty;
        public string TaxGSTNo { get { return _TaxGSTNo; } set { _TaxGSTNo = value; } }


        private string _RegPanNO = string.Empty;
        public string RegPanNO { get { return _RegPanNO; } set { _RegPanNO = value; } }

        private string _Address = string.Empty;
        public string Address { get { return _Address; } set { _Address = value; } }
        private string _Notes = string.Empty;
        public string Notes { get { return _Notes; } set { _Notes = value; } }


        private string _OrganizationType;
        public string OrganizationType { get { return _OrganizationType; } set { _OrganizationType = value; } }

        private string _OwnOffice = string.Empty;
        public string OwnOffice { get { return _OwnOffice; } set { _OwnOffice = value; } }

        private string _DocumentSuffix = string.Empty;
        public string DocumentSuffix { get { return _DocumentSuffix; } set { _DocumentSuffix = value; } }

        private string _GeoLocation = string.Empty;
        public string GeoLocation { get { return _GeoLocation; } set { _GeoLocation = value; } }

        private int _GeoLocationID;
        public int GeoLocationID { get { return _GeoLocationID; } set { _GeoLocationID = value; } }
        private int _IsOceanus;
        public int IsOceanus { get { return _IsOceanus; } set { _IsOceanus = value; } }
        private int _Is3rdParty;
        public int Is3rdParty { get { return _Is3rdParty; } set { _Is3rdParty = value; } }
        private int _IsBoth;
        public int IsBoth { get { return _IsBoth; } set { _IsBoth = value; } }
        public string GeneralName;

        public string RoleName = "";

        private int _PinCode;
        public int PinCode { get { return _PinCode; } set { _PinCode = value; } }

        private string _EmailDetail = string.Empty;
        public string EmailDetail { get { return _EmailDetail; } set { _EmailDetail = value; } }

        private string _TelNo = string.Empty;
        public string TelNo { get { return _TelNo; } set { _TelNo = value; } }
        public string AlertMegId;
        public string AlertMessage;
    }

    public class MyPortAgency
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private int _CID;
        public int CID { get { return _CID; } set { _CID = value; } }
        private string _PortCode = string.Empty;
        public string PortCode { get { return _PortCode; } set { _PortCode = value; } }

        private string _PortName = string.Empty;
        public string PortName { get { return _PortName; } set { _PortName = value; } }


        private int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }

        private int _PortID;
        public int PortID { get { return _PortID; } set { _PortID = value; } }

        private string _DtAdded = string.Empty;
        public string DtAdded { get { return _DtAdded; } set { _DtAdded = value; } }

        private string _PrincipalName = string.Empty;
        public string PrincipalName { get { return _PrincipalName; } set { _PrincipalName = value; } }

        private int _PrincipalID;
        public int PrincipalID { get { return _PrincipalID; } set { _PrincipalID = value; } }

        private int _PID;
        public int PID { get { return _PID; } set { _PID = value; } }

    }

    public class MyCityAgency
    {
        public int ID;
        private string _CityName = string.Empty;
        public string CityName { get { return _CityName; } set { _CityName = value; } }

        private string _CityCode = string.Empty;
        public string CityCode { get { return _CityCode; } set { _CityCode = value; } }

        private int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }

        private string _CityID = string.Empty;
        public string CityID { get { return _CityID; } set { _CityID = value; } }

        private string _DtAdded = string.Empty;
        public string DtAdded { get { return _DtAdded; } set { _DtAdded = value; } }
    }
    public class MyAccCurrency
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }
        private string _CurrencyCode = string.Empty;
        public string CurrencyCode { get { return _CurrencyCode; } set { _CurrencyCode = value; } }

    }
    public class MyAccAgency
    {
        public int ID;
        private int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }
        private string _CurrID = string.Empty;
        public string CurrID { get { return _CurrID; } set { _CurrID = value; } }

        private string _FromMonth = string.Empty;
        public string FromMonth { get { return _FromMonth; } set { _FromMonth = value; } }

        private string _ToMonth = string.Empty;
        public string ToMonth { get { return _ToMonth; } set { _ToMonth = value; } }

        private string _AccNotes = string.Empty;
        public string AccNotes { get { return _AccNotes; } set { _AccNotes = value; } }

        private string _AccCurrency = string.Empty;
        public string AccCurrency { get { return _AccCurrency; } set { _AccCurrency = value; } }

        private string _DtAdded = string.Empty;
        public string DtAdded { get { return _DtAdded; } set { _DtAdded = value; } }
    }

    public class MyAlertEmailAgency
    {
        public int ID;
        private int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }

        private int _AgEmailDtlsID;
        public int AgEmailDtlsID { get { return _AgEmailDtlsID; } set { _AgEmailDtlsID = value; } }

        private string _AlertTypeID = string.Empty;
        public string AlertTypeID { get { return _AlertTypeID; } set { _AlertTypeID = value; } }

        private string _EmailID = string.Empty;
        public string EmailID { get { return _EmailID; } set { _EmailID = value; } }
        private string _DtAdded = string.Empty;
        public string DtAdded { get { return _DtAdded; } set { _DtAdded = value; } }
    }

    #region Online Portal Creation
    public class MyOnlinePortal
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _PartyName = string.Empty;
        public string PartyName { get { return _PartyName; } set { _PartyName = value; } }

        public string Itemsv;

        private int _RoleID;
        public int RoleID { get { return _RoleID; } set { _RoleID = value; } }

        private int _PartyID;
        public int PartyID { get { return _PartyID; } set { _PartyID = value; } }

        private int _DepotID;
        public int DepotID { get { return _DepotID; } set { _DepotID = value; } }

        private string _UserName = string.Empty;
        public string UserName { get { return _UserName; } set { _UserName = value; } }

        private string _Password = string.Empty;
        public string Password { get { return _Password; } set { _Password = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _Role = string.Empty;
        public string Role { get { return _Role; } set { _Role = value; } }

        private string _Party = string.Empty;
        public string Party { get { return _Party; } set { _Party = value; } }

        private string _Depot = string.Empty;
        public string Depot { get { return _Depot; } set { _Depot = value; } }

        private string _StatusResult = string.Empty;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }

        private int _PartyTypeID;
        public int PartyTypeID { get { return _PartyTypeID; } set { _PartyTypeID = value; } }

        private string _PartyType = string.Empty;
        public string PartyType { get { return _PartyType; } set { _PartyType = value; } }

        private int _PID;
        public int PID { get { return _PID; } set { _PID = value; } }
    }


    #endregion
}
#endregion






