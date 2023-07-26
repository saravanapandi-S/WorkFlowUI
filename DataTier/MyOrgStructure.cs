using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyOrgStructure
    {
    }
    public class MyRegion
    {
        public int ID;
        public string RegionName;
        public int Status;
        public string StatusV;
        public string AlertMegId;
        public string AlertMessage;
    }

    public class MyOffice
    {
        public int ID;
        public string OfficeLoc;
        public int CountryID;
        public string CompanyName;
        public int CityID;
        public int StateID;
        public string Pincode;
        public string TaxGSTNo;
        public string TelNo;
        public string FaxNo;
        public string Address;
        public int StatusID;
        public string StatusV;
        public int OfficeLocID;
        public string AlertMegId;
        public string AlertMessage;
        public string LocationCode;
    }
    public class MySalesOffice
    {
        public int ID;
        public string SalesOffLoc;
        public int OfficeLocID;
        public int OfficeID;
        public int Status;
        public string StatusV;
        public string AlertMegId;
        public string AlertMessage;
        public string OfficeLoc;


    }

    public class MyOrg
    {
        public int ID;
        public string OrgName;
        public int CountryID;
        public int CityID;
        public int StateID;
        public string Pincode;
        public string TaxGSTNo;
        public string TelNo;
        public string FaxNo;
        public string Address;
        public int StatusID;
        public string StatusV;
        public int OfficeLocID;
        public int IsLiner;
        public int IsFF;
        public int IsTransport;
        public string Itemsv;
        public Array[] DynamicGrid;
        public string Country;
        public int RegionID;
        public string AlertMegId;
        public string AlertMessage;
        private int _IsTrue;
        public int IsTrue { get { return _IsTrue; } set { _IsTrue = value; } }
        private string _Division = string.Empty;
        public string Division { get { return _Division; } set { _Division = value; } }

        public string DivisionDetails;

    }
    public class MyOrgGrid
    {
        public int ID;
        public int SalesOffLocID;
        public int OfficeLocID;
        public int RegionID;
        public string OfficeLoc;


    }
}
