using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
   public class MasterData
    {
       

      
    }
    #region anand
    public class MyCountry
    {
        public string AlertMegId;
        public string AlertMessage;
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _CountryCode = string.Empty;
        public string CountryCode { get { return _CountryCode; } set { _CountryCode = value; } }

        private string _CountryName = string.Empty;
        public string CountryName { get { return _CountryName; } set { _CountryName = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _StatusV = string.Empty;
        public string StatusV { get { return _StatusV; } set { _StatusV = value; } }

        public string aclFilename = "";
        public string printvalue = "";
        public string id = "";
        public string bssFilename = "";
        public string cargoplanFilename = "";
        public string hawkFilename = "";
        public string mjFilename = "";
        public string merchantFilename = "";
        public string navioFilename = "";
        public string seahorseFilename = "";
        public string shipnerFilename = "";
        public string tarusFilename = "";
        public string aquaticFilename = "";
        public string uslFilename = "";
        public string sbeFilename = "";
        public string srsFilename = "";
        public string lmtFilename = "";
        public string sealloydFilename = "";
        public string tetraFilename = "";
        public string imlFilename = "";
        public string croFilename = "";
        public int BLID;
        public int PrintID;

    } 

    public class MyDepot
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _DepName = string.Empty;
        public string DepName { get { return _DepName; } set { _DepName = value; } }

        private string _DepAddress = string.Empty;
        public string DepAddress { get { return _DepAddress; } set { _DepAddress = value; } }

        private int _DepCountry;
        public int DepCountry { get { return _DepCountry; } set { _DepCountry = value; } }

        private int _DepCity;
        public int DepCity { get { return _DepCity; } set { _DepCity = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _DepCountryName = string.Empty;
        public string DepCountryName { get { return _DepCountryName; } set { _DepCountryName = value; } }

        private string _DepCityName = string.Empty;
        public string DepCityName { get { return _DepCityName; } set { _DepCityName = value; } }

        private string _StatusName = string.Empty;
        public string StatusName { get { return _StatusName; } set { _StatusName = value; } }

        private string _PortName = string.Empty;
        public string PortName { get { return _PortName; } set { _PortName = value; } }

        private int _ApplicablePortID;
        public int ApplicablePortID { get { return _ApplicablePortID; } set { _ApplicablePortID = value; } }

        private int _PortID;
        public int PortID { get { return _PortID; } set { _PortID = value; } }

        private string _Port = string.Empty;
        public string Port { get { return _Port; } set { _Port = value; } }
        
        private int _PID;
        public int PID { get { return _PID; } set { _PID = value; } }

        public string Itemsv;
    }


    public class MyTerminal
    {

        public string AlertMegId;
        public string AlertMessage;
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _TerminalCode = string.Empty;
        public string TerminalCode { get { return _TerminalCode; } set { _TerminalCode = value; } }

        private string _TerminalName = string.Empty;
        public string TerminalName { get { return _TerminalName; } set { _TerminalName = value; } }

        private int _PortID;
        public int PortID { get { return _PortID; } set { _PortID = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _PortName = string.Empty;
        public string PortName { get { return _PortName; } set { _PortName = value; } }

        private string _StatusName = string.Empty;
        public string StatusName { get { return _StatusName; } set { _StatusName = value; } }



    }


    public class MyState
    {

        public string AlertMegId;
        public string AlertMessage;
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _StateCode = string.Empty;
        public string StateCode { get { return _StateCode; } set { _StateCode = value; } }

        private string _StateName = string.Empty;
        public string StateName { get { return _StateName; } set { _StateName = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _StatusResult = string.Empty;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }

        private string _Country = string.Empty;
        public string Country { get { return _Country; } set { _Country = value; } }

        private int _CountryID;
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }

    }
    public class MyVessel
    {
        public string AlertMegId;
        public string AlertMessage;
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _VesselCode = string.Empty;
        public string VesselCode { get { return _VesselCode; } set { _VesselCode = value; } }
        private string _VesselCallSign = string.Empty;
        public string VesselCallSign { get { return _VesselCallSign; } set { _VesselCallSign = value; } }
        private string _VesselName = string.Empty;
        public string VesselName { get { return _VesselName; } set { _VesselName = value; } }
        private string _IMONumber = string.Empty;
        public string IMONumber { get { return _IMONumber; } set { _IMONumber = value; } }
        private string _MMSI = string.Empty;
        public string MMSI { get { return _MMSI; } set { _MMSI = value; } }
        private string _Flag = string.Empty;
        public string Flag { get { return _Flag; } set { _Flag = value; } }
        private string _VesselID = string.Empty;
        public string VesselID { get { return _VesselID; } set { _VesselID = value; } }
        private string _VesselOwner = string.Empty;
        public string VesselOwner { get { return _VesselOwner; } set { _VesselOwner = value; } }

        private DateTime _CurrentDate;
        public DateTime CurrentDate { get { return _CurrentDate; } set { _CurrentDate = value; } }
        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }
        private string _StatusResult = string.Empty;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }
    }
    public class MyVoyage
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private int _VesID;
        public int VesID { get { return _VesID; } set { _VesID = value; } }

        private string _Voyage = string.Empty;
        public string Voyage { get { return _Voyage; } set { _Voyage = value; } }

        private string _RotationNo = string.Empty;
        public string RotationNo { get { return _RotationNo; } set { _RotationNo = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private DateTime _CurrentDate;
        public DateTime CurrentDate { get { return _CurrentDate; } set { _CurrentDate = value; } }

        private string _VesselName = string.Empty;
        public string VesselName { get { return _VesselName; } set { _VesselName = value; } }

        private string _StatusV = string.Empty;
        public string StatusV { get { return _StatusV; } set { _StatusV = value; } }

        private int _RotID;
        public int RotID { get { return _RotID; } set { _RotID = value; } }

    }

    public class MyVoyageDetails
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private int _PID;
        public int PID { get { return _PID; } set { _PID = value; } }


        private int _VoyDtID;
        public int VoyDtID { get { return _VoyDtID; } set { _VoyDtID = value; } }

        private int _VesID;
        public int VesID { get { return _VesID; } set { _VesID = value; } }

        private int _VoyID;
        public int VoyID { get { return _VoyID; } set { _VoyID = value; } }

        private int _VesVID;
        public int VesVID { get { return _VesVID; } set { _VesVID = value; } }

        private string _VoyageNo = string.Empty;
        public string VoyageNo { get { return _VoyageNo; } set { _VoyageNo = value; } }

        private string _Name = string.Empty;
        public string Name { get { return _Name; } set { _Name = value; } }

        private string _RotationNo = string.Empty;
        public string RotationNo { get { return _RotationNo; } set { _RotationNo = value; } }

        private string _VesOperator = string.Empty;
        public string VesOperator { get { return _VesOperator; } set { _VesOperator = value; } }

        private string _NextPort = string.Empty;
        public string NextPort { get { return _NextPort; } set { _NextPort = value; } }

        private string _Terminal = string.Empty;
        public string Terminal { get { return _Terminal; } set { _Terminal = value; } }

        private string _ETA = string.Empty;
        public string ETA { get { return _ETA; } set { _ETA = value; } }

        private string _ETD = string.Empty;
        public string ETD { get { return _ETD; } set { _ETD = value; } }

        private string _ATA = string.Empty;
        public string ATA { get { return _ATA; } set { _ATA = value; } }

        private string _ATD = string.Empty;
        public string ATD { get { return _ATD; } set { _ATD = value; } }

        private string _CutOff = string.Empty;
        public string CutOff { get { return _CutOff; } set { _CutOff = value; } }

        private string _Remarks = string.Empty;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }

        private string _CurrentDate = string.Empty;
        public string CurrentDate { get { return _CurrentDate; } set { _CurrentDate = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }
        private int _CurrentPortID;
        public int CurrentPortID { get { return _CurrentPortID; } set { _CurrentPortID = value; } }
        private int _LoadingTerminalID;
        public int LoadingTerminalID { get { return _LoadingTerminalID; } set { _LoadingTerminalID = value; } }

        private string _SCNNo = string.Empty;
        public string SCNNo { get { return _SCNNo; } set { _SCNNo = value; } }

        private string _NextPortETA = string.Empty;
        public string NextPortETA { get { return _NextPortETA; } set { _NextPortETA = value; } }
        private int _FinalPortID;
        public int FinalPortID { get { return _FinalPortID; } set { _FinalPortID = value; } }

        public int _ServiceID;
        public int ServiceID { get { return _ServiceID; } set { _ServiceID = value; } }

        public int _VesselID;
        public int VesselID { get { return _VesselID; } set { _VesselID = value; } }

        public string Itemsv;
        public string ItemsSchedule;
        public string VesselName = "";
        public string Voyage = "";
        public int VdId;
        public int VID;
        public int VesOpID;
        public int NextPortID;
        public int TerminalID;
        public int _UserID;
        public string ItemsOpr;
        public int UserID { get { return _UserID; } set { _UserID = value; } }

        public int _GeoLocID;
        public int GeoLocID { get { return _GeoLocID; } set { _GeoLocID = value; } }

        public int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }

        private string _Service = string.Empty;
        public string Service { get { return _Service; } set { _Service = value; } }

        private string _OBVoyNo = string.Empty;
        public string OBVoyNo { get { return _OBVoyNo; } set { _OBVoyNo = value; } }
        private string _ExportVoyageCd = string.Empty;
        public string ExportVoyageCd { get { return _ExportVoyageCd; } set { _ExportVoyageCd = value; } }
        private string _ImportVoyageCd = string.Empty;
        public string ImportVoyageCd { get { return _ImportVoyageCd; } set { _ImportVoyageCd = value; } }

        public int _PortID;
        public int PortID { get { return _PortID; } set { _PortID = value; } }

        public int _RID;
        public int RID { get { return _RID; } set { _RID = value; } }

        public int _DayETA;
        public int DayETA { get { return _DayETA; } set { _DayETA = value; } }

        public int _DayETD;
        public int DayETD { get { return _DayETD; } set { _DayETD = value; } }

        public int _TmETA;
        public int TmETA { get { return _TmETA; } set { _TmETA = value; } }

        public int _TmETD;
        public int TmETD { get { return _TmETD; } set { _TmETD = value; } }

        public int _TmATA;
        public int TmATA { get { return _TmATA; } set { _TmATA = value; } }

        public int _TmATD;
        public int TmATD { get { return _TmATD; } set { _TmATD = value; } }

        private string _ArrivalETA = string.Empty;
        public string ArrivalETA { get { return _ArrivalETA; } set { _ArrivalETA = value; } }

        private string _DepETD = string.Empty;
        public string DepETD { get { return _DepETD; } set { _DepETD = value; } }

        public int _VoyageRouteID;
        public int VoyageRouteID { get { return _VoyageRouteID; } set { _VoyageRouteID = value; } }

        private string _DtArrival = string.Empty;
        public string DtArrival { get { return _DtArrival; } set { _DtArrival = value; } }

        private string _DtDeparture = string.Empty;
        public string DtDeparture { get { return _DtDeparture; } set { _DtDeparture = value; } }

        private string _DtPilotOnBoard1 = string.Empty;
        public string DtPilotOnBoard1 { get { return _DtPilotOnBoard1; } set { _DtPilotOnBoard1 = value; } }

        private string _DtVesselBerth = string.Empty;
        public string DtVesselBerth { get { return _DtVesselBerth; } set { _DtVesselBerth = value; } }

        private string _DtDischargedCommenced = string.Empty;
        public string DtDischargedCommenced { get { return _DtDischargedCommenced; } set { _DtDischargedCommenced = value; } }

        private string _DtDischargedCompleted = string.Empty;
        public string DtDischargedCompleted { get { return _DtDischargedCompleted; } set { _DtDischargedCompleted = value; } }

        private string _DtLoadingCommenced = string.Empty;
        public string DtLoadingCommenced { get { return _DtLoadingCommenced; } set { _DtLoadingCommenced = value; } }

        private string _DtLoadingCompleted = string.Empty;
        public string DtLoadingCompleted { get { return _DtLoadingCompleted; } set { _DtLoadingCompleted = value; } }

        private string _DtPilotOnBoard2 = string.Empty;
        public string DtPilotOnBoard2 { get { return _DtPilotOnBoard2; } set { _DtPilotOnBoard2 = value; } }

        private string _DtGeneralCutOff = string.Empty;
        public string DtGeneralCutOff { get { return _DtGeneralCutOff; } set { _DtGeneralCutOff = value; } }

        private string _VCNNumber = string.Empty;
        public string VCNNumber { get { return _VCNNumber; } set { _VCNNumber = value; } }

        private string _PortClearance = string.Empty;
        public string PortClearance { get { return _PortClearance; } set { _PortClearance = value; } }

        private string _EGMNo = string.Empty;
        public string EGMNo { get { return _EGMNo; } set { _EGMNo = value; } }

        private string _IGMNo = string.Empty;
        public string IGMNo { get { return _IGMNo; } set { _IGMNo = value; } }

        private string _IGMDate = string.Empty;
        public string IGMDate { get { return _IGMDate; } set { _IGMDate = value; } }

        private string _EGMDate = string.Empty;
        public string EGMDate { get { return _EGMDate; } set { _EGMDate = value; } }

        public int _MID;
        public int MID { get { return _MID; } set { _MID = value; } }

        private string _BookingNo = string.Empty;
        public string BookingNo { get { return _BookingNo; } set { _BookingNo = value; } }
        private string _BkgParty = string.Empty;
        public string BkgParty { get { return _BkgParty; } set { _BkgParty = value; } }
        private string _Email = string.Empty;
        public string Email { get { return _Email; } set { _Email = value; } }

        public int _NID;
        public int NID { get { return _NID; } set { _NID = value; } }

        public int _VoyageTypeID;
        public int VoyageTypeID { get { return _VoyageTypeID; } set { _VoyageTypeID = value; } }

        private string _Notes = string.Empty;
        public string Notes { get { return _Notes; } set { _Notes = value; } }

        private string _VoyageType = string.Empty;
        public string VoyageType { get { return _VoyageType; } set { _VoyageType = value; } }
    }

    public class MyNotes
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _Notes = string.Empty;
        public string Notes { get { return _Notes; } set { _Notes = value; } }

        private string _Itemsv = string.Empty;
        public string Itemsv { get { return _Itemsv; } set { _Itemsv = value; } }

        private string _GeneralName = string.Empty;
        public string GeneralName { get { return _GeneralName; } set { _GeneralName = value; } }

        private string _DocID = string.Empty;
        public string DocID { get { return _DocID; } set { _DocID = value; } }
    }
    #endregion


    #region ganesh city,port,carge,commodity,ExRate,Geoloc
    public class countryDD
    {
        public int CountryID;
        public string CountryName;
    }

    public class cityDD
    {
        public int ID;
        public int CityID;
        //public string CountryID;
        //public string CityName;


        private int _CountryID;
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }

        private string _CityIDV = string.Empty;
        public string CityIDV { get { return _CityIDV; } set { _CityIDV = value; } }

        private string _CityName = string.Empty;
        public string CityName { get { return _CityName; } set { _CityName = value; } }
    }

    public class StateDD
    {
        //public string CountryID;
        public int StateID;
        public string StateName;
        public string AlertMegId;
        public string AlertMessage;
    }

    public class MyCity
    {
        public string AlertMegId;
        public string AlertMessage;

        public int ID;
        private string _CityName = string.Empty;
        public string CityName { get { return _CityName; } set { _CityName = value; } }

        private string _CityCode = string.Empty;
        public string CityCode { get { return _CityCode; } set { _CityCode = value; } }

        private string _StateName = string.Empty;
        public string StateName { get { return _StateName; } set { _StateName = value; } }
        private string _CountryID;
        public string CountryID { get { return _CountryID; } set { _CountryID = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _StatusResult;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }

        private string _CountryCode;
        public string CountryCode { get { return _CountryCode; } set { _CountryCode = value; } }
        private string _StateID;
        public string StateID { get { return _StateID; } set { _StateID = value; } }
    }
    public class MyPort
    {
        public string AlertMegId;
        public string AlertMessage;
        public int ID;
        private string _PortName = string.Empty;
        public string PortName { get { return _PortName; } set { _PortName = value; } }

        private string _PortCode = string.Empty;
        public string PortCode { get { return _PortCode; } set { _PortCode = value; } }

        private int _CountryID;
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }

        private int _GeoLocID;
        public int GeoLocID { get { return _GeoLocID; } set { _GeoLocID = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }
        private string _StatusResult;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }

        private string _CountryCode;
        public string CountryCode { get { return _CountryCode; } set { _CountryCode = value; } }

        private string _SeaPort;
        public string SeaPort { get { return _SeaPort; } set { _SeaPort = value; } }

        private string _AirPort;
        public string AirPort { get { return _AirPort; } set { _AirPort = value; } }

        private string _ICDPort;
        public string ICDPort { get { return _ICDPort; } set { _ICDPort = value; } }
        
        private int _IsSeaPort;
        public int IsSeaPort { get { return _IsSeaPort; } set { _IsSeaPort = value; } }

        private int _IsAirPort;
        public int IsAirPort { get { return _IsAirPort; } set { _IsAirPort = value; } }

        private int _IsICDPort;
        public int IsICDPort { get { return _IsICDPort; } set { _IsICDPort = value; } }
        private int _MainPortID;
        public int MainPortID { get { return _MainPortID; } set { _MainPortID = value; } }
        private string _MainPort;
        public string MainPort { get { return _MainPort; } set { _MainPort = value; } }
        private string _GeoLocation;
        public string GeoLocation { get { return _GeoLocation; } set { _GeoLocation = value; } }
        
    }

    public class MyCargo
    {
        public string AlertMegId;
        public string AlertMessage;

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _PkgCode = string.Empty;
        public string PkgCode { get { return _PkgCode; } set { _PkgCode = value; } }

        private string _PkgDescriptionc = string.Empty;
        public string PkgDescription { get { return _PkgDescriptionc; } set { _PkgDescriptionc = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _StatusResult;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }
    }

    public class MyCommodity
    {

        public string AlertMegId;
        public string AlertMessage;

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _CommodityUnCode = string.Empty;
        public string CommodityUnCode { get { return _CommodityUnCode; } set { _CommodityUnCode = value; } }

        private string _CommodityName = string.Empty;
        public string CommodityName { get { return _CommodityName; } set { _CommodityName = value; } }

        private string _HSCode = string.Empty;
        public string HSCode { get { return _HSCode; } set { _HSCode = value; } }

        private string _Remarks = string.Empty;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }

        private string _DangerousFlag;
        public string DangerousFlag { get { return _DangerousFlag; } set { _DangerousFlag = value; } }

        private string _GeneralName;
        public string GeneralName { get { return _GeneralName; } set { _GeneralName = value; } }

        private string _CommodityType;
        public string CommodityType { get { return _CommodityType; } set { _CommodityType = value; } }

        private int _CommodityTypeID;
        public int CommodityTypeID { get { return _CommodityTypeID; } set { _CommodityTypeID = value; } }

        private string _Status;
        public string Status { get { return _Status; } set { _Status = value; } }

        public string StatusResult;



    }

    public class MyCommodityTypes
    {
        private int _CommodityType;
        public int CommodityType { get { return _CommodityType; } set { _CommodityType = value; } }


        private string _GeneralName = string.Empty;
        public string GeneralName { get { return _GeneralName; } set { _GeneralName = value; } }


    }
    public class MyExRate
    {


        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _CurrencyIDV = string.Empty;
        public string CurrencyIDV { get { return _CurrencyIDV; } set { _CurrencyIDV = value; } }

        private string _FromCurrency = string.Empty;
        public string FromCurrency { get { return _FromCurrency; } set { _FromCurrency = value; } }

        private string _ToCurrency = string.Empty;
        public string ToCurrency { get { return _ToCurrency; } set { _ToCurrency = value; } }

        private string _Rate = string.Empty;
        public string Rate { get { return _Rate; } set { _Rate = value; } }

        private string _Date = string.Empty;
        public string Date { get { return _Date; } set { _Date = value; } }

        private string _UserID = string.Empty;
        public string UserID { get { return _UserID; } set { _UserID = value; } }
        
        private string _AgencyID = string.Empty;
        public string AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }

    }

    public class CurrencyDD
    {
        public int FromCurrency;
        public int ToCurrency;
        public string CurrencyCode;
        public int CurrencyID;
    }

    public class MyVoyageAllocation
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _VoyageTypes = string.Empty;
        public string VoyageTypes { get { return _VoyageTypes; } set { _VoyageTypes = value; } }

        private string _LegInformation = string.Empty;
        public string LegInformation { get { return _LegInformation; } set { _LegInformation = value; } }

        private int _VesVoyID;
        public int VesVoyID { get { return _VesVoyID; } set { _VesVoyID = value; } }

        private int _BLID;
        public int BLID { get { return _BLID; } set { _BLID = value; } }

        private int _VoyageTypeID;
        public int VoyageTypeID { get { return _VoyageTypeID; } set { _VoyageTypeID = value; } }

        private int _LegInformationID;
        public int LegInformationID { get { return _LegInformationID; } set { _LegInformationID = value; } }

        public string Itemsv;
        public int VID;

        private string _BLNumber = string.Empty;
        public string BLNumber { get { return _BLNumber; } set { _BLNumber = value; } }

        private string _POL = string.Empty;
        public string POL { get { return _POL; } set { _POL = value; } }
        private string _POD = string.Empty;
        public string POD { get { return _POD; } set { _POD = value; } }
        private string _TSPORT = string.Empty;
        public string TSPORT { get { return _TSPORT; } set { _TSPORT = value; } }

        private string _VesVoy1 = string.Empty;
        public string VesVoy1 { get { return _VesVoy1; } set { _VesVoy1 = value; } }

        private string _VesVoy2 = string.Empty;
        public string VesVoy2 { get { return _VesVoy2; } set { _VesVoy2 = value; } }


        private string _VesVoyAlloc = string.Empty;
        public string VesVoyAlloc { get { return _VesVoyAlloc; } set { _VesVoyAlloc = value; } }

        private string _Transhipment = string.Empty;
        public string Transhipment { get { return _Transhipment; } set { _Transhipment = value; } }
        public int BkgID;
        public string Booking;

        public int AgencyID;
        public int UserID;
    }

    public class MyGeoLocation
    {
        public int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }
        private string _GeoLocation = string.Empty;
        public string GeoLocation { get { return _GeoLocation; } set { _GeoLocation = value; } }

        private string _Country = string.Empty;
        public string Country { get { return _Country; } set { _Country = value; } }


        private int _CountryID;
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _StatusResult;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }

        private string _CountryCode;
        public string CountryCode { get { return _CountryCode; } set { _CountryCode = value; } }

        public string Itemsv;

        public int _DID;
        public int DID { get { return _DID; } set { _DID = value; } }

        public int _DepotID;
        public int DepotID { get { return _DepotID; } set { _DepotID = value; } }

        private string _Depot;
        public string Depot { get { return _Depot; } set { _Depot = value; } }
    }

    public class MyServiceSetup
    {
        public string AlertMegId;
        public string AlertMessage;
        public int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _SlotRefCode = string.Empty;
        public string SlotRefCode { get { return _SlotRefCode; } set { _SlotRefCode = value; } }

        private string _ServiceName = string.Empty;
        public string ServiceName { get { return _ServiceName; } set { _ServiceName = value; } }

        private string _DtEffective = string.Empty;
        public string DtEffective { get { return _DtEffective; } set { _DtEffective = value; } }
        
        public int _UserID;
        public int UserID { get { return _UserID; } set { _UserID = value; } }

        public int _GeoLocID;
        public int GeoLocID { get { return _GeoLocID; } set { _GeoLocID = value; } }

        public int _OffLocID;
        public int OffLocID { get { return _OffLocID; } set { _OffLocID = value; } }

        public int _OID;
        public int OID { get { return _OID; } set { _OID = value; } }

        public int _OperatorID;
        public int OperatorID { get { return _OperatorID; } set { _OperatorID = value; } }

        public int _SlotRefID;
        public int SlotRefID { get { return _SlotRefID; } set { _SlotRefID = value; } }

        private string _Operator = string.Empty;
        public string Operator { get { return _Operator; } set { _Operator = value; } }

        private string _SlotRef = string.Empty;
        public string SlotRef { get { return _SlotRef; } set { _SlotRef = value; } }

        public string ItemsRoute;
        public string ItemsOpr;

        public int _RID;
        public int RID { get { return _RID; } set { _RID = value; } }

        public int _PortID;
        public int PortID { get { return _PortID; } set { _PortID = value; } }

        public int _TTHH;
        public int TTHH { get { return _TTHH; } set { _TTHH = value; } }

        public int _TTMM;
        public int TTMM { get { return _TTMM; } set { _TTMM = value; } }

        public int _DayWindowCommence;
        public int DayWindowCommence { get { return _DayWindowCommence; } set { _DayWindowCommence = value; } }

        public int _WComHH;
        public int WComHH { get { return _WComHH; } set { _WComHH = value; } }

        public int _WComMM;
        public int WComMM { get { return _WComMM; } set { _WComMM = value; } }

        public int _DayWindowClose;
        public int DayWindowClose { get { return _DayWindowClose; } set { _DayWindowClose = value; } }
        public int _WCloseMM;
        public int WCloseMM { get { return _WCloseMM; } set { _WCloseMM = value; } }

        public int _WCloseHH;
        public int WCloseHH { get { return _WCloseHH; } set { _WCloseHH = value; } }

        public int _DayPortStay;
        public int DayPortStay { get { return _DayPortStay; } set { _DayPortStay = value; } }
        public int _PortStayHH;
        public int PortStayHH { get { return _PortStayHH; } set { _PortStayHH = value; } }

        public int _PortStayMM;
        public int PortStayMM { get { return _PortStayMM; } set { _PortStayMM = value; } }

        public int _ServiceID;
        public int ServiceID { get { return _ServiceID; } set { _ServiceID = value; } }

        private string _ETA = string.Empty;
        public string ETA { get { return _ETA; } set { _ETA = value; } }

        private string _GeoLoc = string.Empty;
        public string GeoLoc { get { return _GeoLoc; } set { _GeoLoc = value; } }

        public int _StatusID;
        public int StatusID { get { return _StatusID; } set { _StatusID = value; } }

    }

    public class MyVoyageOpening
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }


        private int _VesselID;
        public int VesselID { get { return _VesselID; } set { _VesselID = value; } }
        private int _BLID;
        public int BLID { get { return _BLID; } set { _BLID = value; } }
        
        private string _VoyageNo = string.Empty;
        public string VoyageNo { get { return _VoyageNo; } set { _VoyageNo = value; } }

        private string _BLNumber = string.Empty;
        public string BLNumber { get { return _BLNumber; } set { _BLNumber = value; } }

        private string _CntrStatusCode = string.Empty;
        public string CntrStatusCode { get { return _CntrStatusCode; } set { _CntrStatusCode = value; } }

        public string CntrStatusCodev = "";

        private string _CntrNo = string.Empty;
        public string CntrNo { get { return _CntrNo; } set { _CntrNo = value; } }
        
        private string _POD = string.Empty;
        public string POD { get { return _POD; } set { _POD = value; } }

        private string _TSPort = string.Empty;
        public string TSPort { get { return _TSPort; } set { _TSPort = value; } }

        private string _POL = string.Empty;
        public string POL { get { return _POL; } set { _POL = value; } }

        private string _LoadPort = string.Empty;
        public string LoadPort { get { return _LoadPort; } set { _LoadPort = value; } }


        private string _Terminal = string.Empty;
        public string Terminal { get { return _Terminal; } set { _Terminal = value; } }

        private string _ETA = string.Empty;
        public string ETA { get { return _ETA; } set { _ETA = value; } }

        private string _ETD = string.Empty;
        public string ETD { get { return _ETD; } set { _ETD = value; } }

        private string _ATA = string.Empty;
        public string ATA { get { return _ATA; } set { _ATA = value; } }

        private string _ATD = string.Empty;
        public string ATD { get { return _ATD; } set { _ATD = value; } }


        private string _Remarks = string.Empty;
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }

        private string _PortName = string.Empty;
        public string PortName { get { return _PortName; } set { _PortName = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }
        private int _CurrentPortID;
        public int CurrentPortID { get { return _CurrentPortID; } set { _CurrentPortID = value; } }
        private int _LoadingTerminalID;
        public int LoadingTerminalID { get { return _LoadingTerminalID; } set { _LoadingTerminalID = value; } }

        private string _SCNNo = string.Empty;
        public string SCNNo { get { return _SCNNo; } set { _SCNNo = value; } }

        private string _NextPortETA = string.Empty;
        public string NextPortETA { get { return _NextPortETA; } set { _NextPortETA = value; } }
        private int _FinalPortID;
        public int FinalPortID { get { return _FinalPortID; } set { _FinalPortID = value; } }
        private string _VesVoy = string.Empty;
        public string VesVoy { get { return _VesVoy; } set { _VesVoy = value; } }
        
        public string Itemsv;
        public string ItemPortIDs;
        public string VesselName = "";
        public string Voyage = "";
        public int VdId;
        public int VID;
        public int VesOpID;
        public int NextPortID;
        public int TerminalID;
        public int _UserID;
        public int UserID { get { return _UserID; } set { _UserID = value; } }

        public int _GeoLocID;
        public int GeoLocID { get { return _GeoLocID; } set { _GeoLocID = value; } }

        public int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }

        private string _CurrentPort = string.Empty;
        public string CurrentPort { get { return _CurrentPort; } set { _CurrentPort = value; } }

        private string _NextPort = string.Empty;
        public string NextPort { get { return _NextPort; } set { _NextPort = value; } }

        private string _StatusV = string.Empty;
        public string StatusV { get { return _StatusV; } set { _StatusV = value; } }

        public string GridBLID { get { return _GridBLID; } set { _GridBLID = value; } }

        private string _GridBLID = string.Empty;

        public string OpenStatus { get { return _OpenStatus; } set { _OpenStatus = value; } }

        private string _OpenStatus = string.Empty;
        
        public int _OpenID;
        public int OpenID { get { return _OpenID; } set { _OpenID = value; } }

        public int _OpenedVoyID;
        public int OpenedVoyID { get { return _OpenedVoyID; } set { _OpenedVoyID = value; } }
        public string OpenedETA { get { return _OpenedETA; } set { _OpenedETA = value; } }

        private string _OpenedETA = string.Empty;
        public string DisChargeVoyNo { get { return _DisChargeVoyNo; } set { _DisChargeVoyNo = value; } }

        private string _DisChargeVoyNo = string.Empty;

        public int _DiscTerminalID;
        public int DiscTerminalID { get { return _DiscTerminalID; } set { _DiscTerminalID = value; } }
        

    }
    #endregion

    public class MyUOM
    {
        
        public string AlertMegId;
        public string AlertMessage;
        //public int UOMType;

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _UOMCode = string.Empty;
        public string UOMCode { get { return _UOMCode; } set { _UOMCode = value; } }

        private string _UOMDesc = string.Empty;
        public string UOMDesc { get { return _UOMDesc; } set { _UOMDesc = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private int _UOMType;
        public int UOMType { get { return _UOMType; } set { _UOMType = value; } }

        private string _StatusResult;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }

        private string _UOMTypeResult;
        public string UOMTypeResult { get { return _UOMTypeResult; } set { _UOMTypeResult = value; } }

        public string UOMTypes;

        public string UOMActions;
        
    }
    
    public class MyContType
    {

        public string AlertMegId;
        public string AlertMessage;

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        public string Size;
        public string Type;
        public int EQTypeID;
        public string CustomsCode;
        public string Height;
        public string Width;
        public string Length;
        public string TareWeight;
        public string MaxPayload;
        public int TEUS;       
        public string SeqNo;
        public string Remarks;

        private int _TypeID;
        public int TypeID { get { return _TypeID; } set { _TypeID = value; } }

        private string _ISOCode = string.Empty;
        public string ISOCode { get { return _ISOCode; } set { _ISOCode = value; } }

        private int _SizeID;
        public int SizeID { get { return _SizeID; } set { _SizeID = value; } }

        public int groupID;
        public int status;
        public string StatusResult;
        public string CntrTypeDesc;
        


    }

    public class ContainerType
    {
        public int ID;
        public string GeneralName;
    }

    public class ContainerSizes
    {
        public int ID;
        public string GeneralName;
    }

    #region shipments locations,Hazardous Classes
    public class myshipmentlocation
    {
        public int ID;
        public string LocationCode;
        public string Location;
        public int CityID;
        public int CountryID;
        public int status;
        public string AlertMegId;
        public string AlertMessage;
        public string StatusResult;


    }

    public class myHazardous
    {
        public int ID;
        public string ClassDesc;
        public string DivisionDesc;
        public int Status;
        public string AlertMegId;
        public string AlertMessage;
        public string StatusResult;
    }

    public class myUOMConversions
    {
        public int ID;
        public string UOMFrom;
        public string UOMTo;
        public string Factor;
        public int Status;
        public int Action;
        public string AlertMegId;
        public string AlertMessage;
        public string StatusResult;
        public string ActionResult;
        public string UOMCode;
        
    }
    #endregion

    public class MyCurrency
    {
        public int ID;
        public string CurrencyCode;
        public string CurrencyName;
        public string Country;
        public string Symbol;
        public string Factor;
        public int Status;       
        public int CountryID;       
        public string AlertMegId;
        public string AlertMessage;
        public string StatusResult;
        public string ActionResult;
      

    }
}
