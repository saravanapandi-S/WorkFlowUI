using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
   public class MyCommonAccess
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _PortName;
        public string PortName { get { return _PortName; } set { _PortName = value; } }

        private string _CntrTypes;
        public string CntrTypes { get { return _CntrTypes; } set { _CntrTypes = value; } }


        private string _CommodityName;
        public string CommodityName { get { return _CommodityName; } set { _CommodityName = value; } }

        private string _ServiceTypesName;
        public string ServiceTypesName { get { return _ServiceTypesName; } set { _ServiceTypesName = value; } }

        private string _Currency;
        public string Currency { get { return _Currency; } set { _Currency = value; } }

        private string _ChargeCode;
        public string ChargeCode { get { return _ChargeCode; } set { _ChargeCode = value; } }

        private string _GeneralName;
        public string GeneralName { get { return _GeneralName; } set { _GeneralName = value; } }

        private string _AgencyName;
        public string AgencyName { get { return _AgencyName; } set { _AgencyName = value; } }

        private string _AgencyID;
        public string AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }

        private string _CustomerName;
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }

        private string _CountryName;
        public string CountryName { get { return _CountryName; } set { _CountryName = value; } }

        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; } }

        private string _RatesheetNo;
        public string RatesheetNo { get { return _RatesheetNo; } set { _RatesheetNo = value; } }

        private string _DepName;
        public string DepName { get { return _DepName; } set { _DepName = value; } }

        private string _TerminalName;
        public string TerminalName { get { return _TerminalName; } set { _TerminalName = value; } }

        private string _VesselName;
        public string VesselName { get { return _VesselName; } set { _VesselName = value; } }

        private string _VesVoy;
        public string VesVoy { get { return _VesVoy; } set { _VesVoy = value; } }

        private string _BookingNo;
        public string BookingNo { get { return _BookingNo; } set { _BookingNo = value; } }

        private string _BLNumber;
        public string BLNumber { get { return _BLNumber; } set { _BLNumber = value; } }


        private string _CntrNo;
        public string CntrNo { get { return _CntrNo; } set { _CntrNo = value; } }

        private string _BusinessTypes;
        public string BusinessTypes { get { return _BusinessTypes; } set { _BusinessTypes = value; } }


        private string _CustomerAddress;
        public string CustomerAddress { get { return _CustomerAddress; } set { _CustomerAddress = value; } }


        private string _CargoName;
        public string CargoName { get { return _CargoName; } set { _CargoName = value; } }

        private int  _SlotTermID;
        public int SlotTermID { get { return _SlotTermID; } set { _SlotTermID = value; } }

        private string _SlotTerm;
        public string SlotTerm { get { return _SlotTerm; } set { _SlotTerm = value; } }


        private string _CntrStatus;
        public string CntrStatus { get { return _CntrStatus; } set { _CntrStatus = value; } }

        private string _BussTypes;
        public string BussTypes { get { return _BussTypes; } set { _BussTypes = value; } }

        private string _Basic;
        public string Basic { get { return _Basic; } set { _Basic = value; } }

        private string _PortID;
        public string PortID { get { return _PortID; } set { _PortID = value; } }

        private string _BkgID;
        public string BkgID { get { return _BkgID; } set { _BkgID = value; } }

        public string Qty = "";

        public string VendorName = "";

        public string Status = "";

        public string Months = "";

        public string Years = "";

        public string MainPort = "";
        public string DocID = "";
        public string Notes = "";

        private int _PortIDv;
        public int PortIDv { get { return _PortIDv; } set { _PortIDv = value; } }
        public string VoyageName = "";

    }

    public class MyCommonAccessNew
    {

        public int ID = 0;
        public string CustomerName = "";
    }
}
