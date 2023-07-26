using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MySystem
    {
        public int ID = 0;
        public string Country = "";
        public string City = "";
        public string State = "";
        public string Port = "";
        public int CountryID = 0;
        public int StateID = 0;
        public string Terminal = "";
        public int PortID = 0;
        public string ShipmentLocation = "";
        public string Commodity = "";
        public string PackageType = "";
        public string ContainerType = "";
        public string HazClass = "";

    }
    public class MySACountry
    {
        public int ID = 0;
        public string CountryName = "";
        public string CountryCode = "";
        public string Country = "";
    }
    public class MySACity
    {
        public int ID = 0;
        public string City = "";
        public string CityName = "";
        public string CityCode = "";
        public int CountryID = 0;
        public int StateID = 0;
    }
    public class MySAState
    {
        public int ID = 0;
        public string StateCode = "";
        public string StateName = "";
        public string State = "";
        public int CountryID = 0;
    }

    public class MySAPort
    {
        public int ID = 0;
        public string Port = "";
        public string PortCode = "";
        public string PortName = "";
        public string PortType = "";
        public int CountryID = 0;
        public string OfficeLocation = "";
    }
    public class MySATerminal
    {
        public int ID = 0;
        public string Terminal = "";
        public string TerminalCode = "";
        public string TerminalName = "";
        public int PortID = 0;
    }
    public class MySAShipmentLocation
    {
        public int ID = 0;
        public string ShipmentLocation = "";
        public string LocationCode = "";
        public string LocationName = "";
        public int CountryID = 0;
    }
    public class MySACommodity
    {
        public int ID = 0;
        public string Commodity = "";
        public string CommodityName = "";
        public string CommodityCode = "";

    }
    public class MySAPackageType
    {
        public int ID = 0;
        public string PackageType = "";
        public string PackageCode = "";
        public string PackageDescription = "";
    }

    public class MySAContainerType
    {
        public int ID = 0;
        public string ContainerType = "";
        public string ContainerDescription = "";
        public string ContainerSize = "";


    }
    public class MySAContainerTypeDetails
    {
        public int ID = 0;
        public string ContainerType = "";
        public string ContainerDescription = "";
        public string ContainerSize = "";
        public string ISOCode = "";
        public string Height = "";
        public string Width = "";
        public string Length = "";
        public string TareWeight = "";
        public string Teus = "";
        public string MaxPayLoad = "";
        public string Group = "";
        public int ContainerTypeID = 0;
        public int GroupID = 0;

    }
    public class MySAContainerGroup
    {
        public int ID = 0;
        public string ContainerGroup = "";
    }
    public class MySAUOMTypes
    {
        public int ID = 0;
        public string UOMType = "";
    }

    public class MySACurrency
    {
        public int ID = 0;
        public string Currency = "";
        public string CurrencyCode = "";
        public string CurrencyName = "";
        public string Symbol = "";
        public int CountryID = 0;


    }
    public class MySAUOM
    {
        public int ID = 0;
        public string UOM = "";
        public string UOMCode = "";
        public string UOMDescription = "";
        public int UOMTypeID = 0;

    }
    public class MySAHazClass
    {
        public int ID = 0;
        public string HazClass = "";
        public string HazDescription = "";

    }
    public class MySAEmailConfig
    {
        public int ID = 0;
        public string HostName = "";
        public int IPPort = 0;
        public string SenderID = "";
        public string Password = "";
        public string MBSize = "";
        public string MaxNoAttachs = "";
        public string MaxSizeAllAttachs = "";
        public string Protocol = "";
        public string SecurityMode = "";
    }
    public class MyCompany
    {
        public int ID = 0;
        public string CompanyName = "";
        public string CompanyCode = "";
        public string Address = "";
        public string ContactName = "";
        public string POBox = "";
        public string ZipCode = "";
        public string Designation = "";
        public string TelePhone1 = "";
        public string TelePhone2 = "";
        public string ContactEmailID = "";
        public string EmailID = "";
        public string URL = "";
        public string MobileNo = "";
        public string LogoFileName = "";
        public string AlertMegId;
        public string AlertMessage;
        public int CountryID = 0;
        public int CityID = 0;
        public string Country;
        public string City;
    }
    public class MyConfig
    {
        public int ID = 0;
        public int CompanyID = 0;
        public int IsSMTPS = 0;
        public int IsSSLTLS;
        public string HostName = "";
        public int IPPort;
        public string SenderID = "";
        public string Password = "";
        public string MBSize = "";
        public string MaxNoAttachs = "";
        public string MaxSizeAllAttachs = "";
        public string AlertMegId;
        public string AlertMessage;

    }

}