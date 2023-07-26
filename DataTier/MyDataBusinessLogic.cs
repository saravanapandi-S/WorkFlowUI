using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyDataBusinessLogic
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private int _IsAgency;
        public int IsAgency { get { return _IsAgency; } set { _IsAgency = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _Name = string.Empty;
        public string Name { get { return _Name; } set { _Name = value; } }

        private string _Designation = string.Empty;
        public string Designation { get { return _Designation; } set { _Designation = value; } }

        private DateTime _CurrentDate = DateTime.MinValue;
        public DateTime CurrentDate { get { return _CurrentDate; } set { _CurrentDate = value; } }

        private string _Branch = string.Empty;
        public string Branch { get { return _Branch; } set { _Branch = value; } }

        private int _Location;
        public int Location { get { return _Location; } set { _Location = value; } }

        private string _Email = string.Empty;
        public string Email { get { return _Email; } set { _Email = value; } }

        private string _UserName = string.Empty;
        public string UserName { get { return _UserName; } set { _UserName = value; } }

        private string _UserCode = string.Empty;
        public string UserCode { get { return _UserCode; } set { _UserCode = value; } }

        private string _Module = string.Empty;
        public string Module { get { return _Module; } set { _Module = value; } }


        private string _user = string.Empty;
        public string user { get { return _user; } set { _user = value; } }


        private string _Password = string.Empty;
        public string Password { get { return _Password; } set { _Password = value; } }

     

        private string _MobileNo = string.Empty;
        public string MobileNo { get { return _MobileNo; } set { _MobileNo = value; } }

     

        private string _Address = string.Empty;
        public string Address { get { return _Address; } set { _Address = value; } }

      

        private string _LocationName = string.Empty;
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        private string _Agency = string.Empty;
        public string Agency { get { return _Agency; } set { _Agency = value; } }
        private string _Country = string.Empty;
        public string Country { get { return _Country; } set { _Country = value; } }
        private string _City = string.Empty;
        public string City { get { return _City; } set { _City = value; } }
        private int _UserID;
        public int UserID { get { return _UserID; } set { _UserID = value; } }
        private int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }
        private int _CountryID;
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }
        private int _LocationID;
        public int LocationID { get { return _LocationID; } set { _LocationID = value; } }
        private string _YearID = string.Empty;
        public string YearID { get { return _YearID; } set { _YearID = value; } }
        private string _FinancialYear = string.Empty;
        public string FinancialYear { get { return _FinancialYear; } set { _FinancialYear = value; } }


        private string _AgencyName;
        public string AgencyName { get { return _AgencyName; } set { _AgencyName = value; } }
        private string _DocumentSuffix;
        public string DocumentSuffix { get { return _DocumentSuffix; } set { _DocumentSuffix = value; } }
        
        private string _GeoLocation;
        public string GeoLocation { get { return _GeoLocation; } set { _GeoLocation = value; } }

        private string _Depot;
        public string Depot { get { return _Depot; } set { _Depot = value; } }

        private int _VendorID;
        public int VendorID { get { return _VendorID; } set { _VendorID = value; } }

        private int _DepotID;
        public int DepotID { get { return _DepotID; } set { _DepotID = value; } }
        private int _ModuleID;
        public int ModuleID { get { return _ModuleID; } set { _ModuleID = value; } }

        private string _Parameter = string.Empty;
        public string Parameter { get { return _Parameter; } set { _Parameter = value; } }

        private string _Value = string.Empty;
        public string Value { get { return _Value; } set { _Value = value; } }

        private string _GLCode = string.Empty;
        public string GLCode { get { return _GLCode; } set { _GLCode = value; } }

        private int _StatusID;
        public int StatusID { get { return _StatusID; } set { _StatusID = value; } }

        private string _StatusResult = string.Empty;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }

        private string _GLCodeID = string.Empty;
        public string GLCodeID { get { return _GLCodeID; } set { _GLCodeID = value; } }


        public string LocationIDv = "";
        public string AgencyIDv = "";
        public string TaxGST = "";
        public string Token = "";

    }

    public class MyMenu
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _File = string.Empty;
        public string File { get { return _File; } set { _File = value; } }

        private string _Url = string.Empty;
        public string Url { get { return _Url; } set { _Url = value; } }

        private int _MenuID;
        public int MenuID { get { return _MenuID; } set { _MenuID = value; } }

        private int _MenuType;
        public int MenuType { get { return _MenuType; } set { _MenuType = value; } }

        private int _UserID;
        public int UserID { get { return _UserID; } set { _UserID = value; } }


    }

}
