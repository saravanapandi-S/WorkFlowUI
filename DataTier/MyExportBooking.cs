using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
   public class MyExportBooking
    {
        public int ID;
        public string BookingNo = "";
        public string BookingParty = "";
        public int BookingPartyID;
        public string BookingStatus = "";
        public string BookingDate = "";
        public string BookingCommission = "";
        public string EnquiryNo = "";
        public string Source = "";
        public string SalesPerson = "";
        public string Origin = "";
        public string DischargePort = "";
        public string LoadPort = "";
        public string Destination = "";
        public string Route = "";
        public string DeliveryTerms = "";
        public string Commodity = "";
        public string CargoWeight = "";
        public string HsCode = "";
        public int HazarOpt;
        public int ReeferOpt;
        public int OOGOpt;
        public string PaymentTerms = "";
        public string VesselName = "";
        public string VoyageNo = "";
        public string POLTerminal = "";
        public string TsVesselName = "";
        public string TsVoyageNo = "";
        public string Principal = "";
        public string LinerContractNo = "";
        public string CusContractNo = "";
        public string PODAgent = "";
        public string FPODAgent = "";
        public string TSPortAgent1 = "";
        public string TSPortAgent2 = "";
        public string SlotOperator = "";
        public string Ownership = "";
        public string Fixed = "";
        public int FreeDayOrigin;
        public string FreeDaysOrignValue = "";
        public int FreeDayDestination;
        public string FreeDaysDesValue = "";
        public int DamageScheme;
        public string DamageSchemeValue = "";
        public int SecurityDeposit;
        public string SecurityDepositValue = "";
        public int BOLRequirement;
        public string BolReqValue = "";
        public string VesselID = "";
        public string BkgID = "";
        public string VoyageID = "";
        public string OfficeCode = "";
        public string Agent = "";
        public string PaymentCenter = "";
        public string SlotUpto = "";
    }
    public class MyExpBkgContainer
    {
        public int ID;
        public string CntrType = "";
        public string Nos = "";
    }
    public class MyExpBkgHaz
    {
        public int ID;
        public string CommodityName = "";
        public string HazardousClass = "";
        public string MCONumber = "";
    }

    public class MyExpBkgReefer
    {
        public int ID;
        public string CommodityName = "";
        public string Temperature = "";
        public string Ventilation = "";
        public string Humidity = "";
    }

    public class MyExpBkgOutGauge
    {
        public int ID;
        public string CommodityName = "";
        public string CargoLenght = "";
        public string CargoWidth = "";
        public string CargoHeight = "";
    }
    public class MyExpBkgOceanFrtCharges
    {
        public int ID;
        public string CommodityName = "";
        public string CntrType = "";
        public string Currency = "";
        public string FrtChargePerAmt = "";
        public string ManifestAmt = "";
        public string CommissionPerAmt = "";
        public string Nos = "";
        public string FrtChargePerAmtTotal = "";
        public string ManifestAmtTotal = "";
    }

    public class MyExpBkgShipmentTerms
    {
        public int ID;
        public string CntrType = "";
        public string Currency = "";
        public string PolCharges = "";
        public string Amount2 = "";
        public string Remarks = "";
    }
}
