using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyDocument
    {
    }

    public class MyBooking
    {
        public int ID = 0;
        public string BookingNo = "";
        public string BkgDate = "";
        public string RRID = "0";
        public string RRNo = "";
        public string SlotRefNo = "";
        public string BkgPartyID = "0";
        public string BkgParty = "";
        public string ShipmentTypeID = "";
        public string ShipmentType = "";
        public string POOID = "0";
        public string POO = "";
        public string POLID = "0";
        public string POL = "";
        public string PODID = "0";
        public string POD = "";
        public string FPODID = "0";
        public string FPOD = "";
        public string ServiceTypeID = "0";
        public string ServiceType = "";
        public string CommodityTypeID = "0";
        public string CommodityType = "";
        public string SalesPersonID ;
        public string SalesPerson = "";
        public string CarrierID = "0";
        public string Carrier = "";
        public string VesVoyID ;
        public string VesVoy = "";
        public string ShipperID = "0";
        public string Shipper = "";
        public string PickUpDepotID = "0";
        public string PickUpDepot = "";
        public string ValidTill = "";
        public string PortNtRef = "";
        public string Remarks = "";
        public string AgentID = "0";
        public string UserID = "0";
        public string BkgDatev = "";
        public string ValidTillv = "";
        public string PreparedBY = "";
        public string PreparedBYID = "";
        public string Itemsv = "";
        public string CntrTypeID = "";
        public string Qty = "";
        public string BID = "0";
        public string CTQ20 = "";
        public string CTQ40 = "";
        public string AgentCode = "";
        public string SessionFinYear = "";
        public string TsPortID = "";
        public string TSPort = "";
        public string DestinationAgent = "";
        public string DestinationAgentID = "";
        public string Status = "";
        public string IntStatus = "";
        public string Draft = "";
        public string Cancelled = "";
        public string Confirm = "";
        public string VesOperator = "";
        public string SlotID = "";
        public string SlotTermID = "";
        public string Cnt20 = "";
        public string Cnt40 = "";
        public string SlotOperatorID = "";
        public string TranshimentPort = "";
        public string GeneralName = "";
        public string TranshipmetAgentID = "";
        public string QtyItems = "";

    }


    public class MyCROMaster
    {
        public int ID;
        public string ReleaseOrderNo = "";
        public string Date = "";
        public int BkgID;
        public int CusID;
        public int CommodityID;
        public int VesselID;
        public string ETADate;
        public string ETDDate;
        public string CutDate;
        public int PickDepoID;
        public string Surveyor = "";
        public string LineCode = "";
        public string Remarks = "";
        public string ValidTill = "";
        public string Itemsv = "";
        public string BookingNo = "";
        public int CRORegID;
        public int CID;
        public int CntrTypeID;
        public int Qty;
        public int ReqQty;
        public int PenQty;
        public int ContainerID;

        public string BkgParty = "";
        public string VesVoy = "";
        public string AgentCode = "";
        public string SessionFinYear = "";
        public string Status = "";
        public string AgentId = "";
        public string UserID = "";
    }


    public class MYRRBooking
    {

        public int ID = 0;
        public string RatesheetNo = "";
        public string POO = "";
        public string Date = "";
        public string POL = "";
        public string POD = "";
        public string FPOD = "";
        public string BookingParty = "";
        public string ShipmentTypes = "";
        public string serviceTypes = "";
        public string ValidTill = "";
        public string BaseAmt = "";
        public string Rate = "";
        public string SlotOperator = "";

        public string SlotCntr20Rate = "";
        public string SlotCntr4Rate = "";
        public string SlotTerm = "";
        public string Oceanfr20 = "";
        public string Oceanfr40 = "";
        public string Cntr20 = "";
        public string Cntr40 = "";
        public string Commodity = "";

        public string FRT20 = "";
        public string FRT40 = "";

        public string BAF20 = "";
        public string BAF40 = "";

        public string ECRS20 = "";
        public string ECRS40 = "";

        public string LSS20 = "";
        public string LSS40 = "";

        public string Commodity40 = "";
        public string AgentID = "";

        public string LogInAgentID = "";
        public string ShipperID = "";
        public string RSStatus = "";
        public string Shipper = "";
        public string Transhipment = "";
    }


    public class MYBOL
    {
        public int ID;
        public int BkgID;
        public string RRNo = "";
        public string BkgParty = "";
        public string POO = "";
        public string POL = "";
        public string POD = "";
        public string FPOD = "";

        public string POOID = "";
        public string POLID = "";
        public string PODID = "";
        public string FPODID = "";
        public string AgentId = "";

        public string ShipmentType = "";
        public string ServiceType = "";
        public string SalesPerson = "";
        public string VesVoy = "";
        public string CntrCount = "";
        public string Size = "";
        public string ISOCode = "";
        public string CntrID = "";
        public string BLNumber = "";
        public int DesAgentID;
        public int NoofOriginal;
        public int SurrenderStatus;
        public string MarkNo = "";
        public string CagoDescription = "";
        public string BLTypes = "";
        public string MotherBL = "";
        public string FreeDays = "";
        public string FreightPaymentID = "";
        public string Remarks = "";
        public string Items = "";
        public string ItemsCntr = "";
        public string ItemsVS = "";
        public string BookingNo = "";
        public int BCID;
        public int PartyTypeID;
        public int PartyID;
        public string Address = "";
        public int BCNID;
        public string SealNo = "";
        public string NoOfPkg = "";
        public string PakgType = "";
        public string GrsWt = "";
        public string NtWt = "";
        public string VGM = "";
        public string CBM = "";
        public string CurPortID = "";
        public string NextPortID = "";
        public string ETA = "";
        public string ETD = "";
        public string VesVoyID = "";
        public string VID = "";
        public string VoyageTypes = "";
        public string LegInformation = "";
        public string RRID = "";
        public string Status = "";
        public string BLID = "";

        public string Confirm = "";
        public string Cancelled = "";
        public string Draft = "";
        public string Shipper = "";
        public string ShipmentTypeID = "";
        public string ReasonDescription = "";
        public string CargoReleaseStatus = "";
        public string UserID = "";
        public string BLLockStatus = "";
        
        public string BkgStatus = "";

        public string CommodityTypeID = "";
        public string BkgPartyID = "";
        public string SessionFinYear = "";
        public string AgentCode = "";
        public string Message = "";
        public string Alert = "";
        public string TsPortID = "";
        public string TranshipmetAgentID = "";


    }

    public class MYBLRelease
    {
        public int ID;
        public int BkgID;
        public string VesVoy = "";
        public string BLDate = "";
        public string Shipper = "";
        public string ShipperAddress = "";
        public string Consignee = "";
        public string ConsigneeAddress = "";
        public string Notify1= "";
        public string Notify1Address = "";
        public string Notify2 = "";
        public string Notify2Address = "";
        public string Agent = "";
        public string AgentAddress = "";
        public string POO = "";
        public string POL = "";
        public string POD = "";
        public string FPOD = "";
        public string GrsWt = "";
        public string NtWt = "";
        public string CBM = "";
        public string Packages = "";
        public string Description = "";
        public string Marks = "";
        public string Container = "";
        public string FreightPayment = "";
        public string FreeDays = "";
        public string SOBDate = "";
        public string issuedAT = "";
        public string BkgParty = "";
        public string BLNo = "";
        public string BLStatus = "";
        public string BLLayout = "";
        public string IssuedAt = "";
        public string CntrDetails = "";
        public string BLID = "";
        public string BLNumber = "";
        public string VesVoyID = "";

        public string ShiperEmail = "";
        public string ShiperContactNo = "";
        public string ConsigneeEmail = "";
        public string ConsigneeContactNo = "";
        public string Notify1Email = "";
        public string Notify1ContactNo = "";
        public string Notify2Email = "";
        public string Notify2ContactNo = "";
        public string AgentEmail = "";
        public string AgentContactNo = "";
        public string Message = "";
    }

    public class ChargeCorrector
    {
        public int ID = 0;
        public string BKgID = "";
        public string CntrTypes = "";
        public string Qty = "";
        public string ChargeCode = "";
        public string Currency = "";
        public string PaymentMode = "";
        public string ManifRate = "";
        public string CustomerRate = "";
        public string CurrencyID = "";
        public string PaymentModeID = "";
        public string OwnershipID = "";
        public string Ownership = "";
        public string BillAmount = "";
        public string CntrType = "";
        public string ChargeCodeID = "";
        public int RID;
        public int CMID = 0;
        public string BLNumber = "";
        public string CorrectionNo = "";
        public string NewCustomerRate = "";
        public string NewManifRate = "";
        public string NewPaymentModeID = "";
        public string NewPaymentMode = "";
        public string NewCurrencyID = "";
        public string NewCurrency = "";


        public string ChargeCodeV = "";
        public string ShipmentTypeV = "";
        public string CollectionModeV = "";
        public string OwnershipV = "";
        public string InfoChIDV = "";
        public string CntrTypeV = "";
        public string CommodityTypeV = "";
        public string CurrencyV = "";
        public string Amt = "";
        public string BookingNo = "";
        public string RRNo = "";
        public string POL = "";
        public string POD = "";
        public string RRID = "";
        public string VesVoy = "";
        public string SlotRefNo = "";
        public string SlotOperatorID = "";
        public string SlotOperatorName = "";
        public string BkgStatus = "";
        public string FreightCharges = "";
        public string SlatCharges = "";
        public string SlotID = "";
        public string SlotAmdAmt = "";
        public string Status = "";
        public string VesVoyID = "";
        public string AgentID = "";
        public string ResultSuccess = "";
        public string SlotAmt20 = "";
        public string SlotAmt40 = "";

    }

    public class ChargeCorrectorInsert
    {
        public int ID = 0;
        public int CID = 0;
        public int ChID = 0;
        public int EID = 0;
        public int ChargeCodeID = 0;
        public int infoChID = 0;
        public int BasicID = 0;
        public int CntrTypeID = 0;
        public int CommodityTypeID = 0;
        public int CurrencyID = 0;
        public int CurrencyIDV = 0;
        public decimal Amt = 0;
        public decimal AmtV = 0;
        public int CollectionModeID = 0;
        public int CollectionModeIDV = 0;
        public int CollectionAgentID = 0;
        public int ChargeOwnershipID = 0;
        public int ChargeOwnershipIDV = 0;
        public string ResultSuccess = "";
        public string ShipmentType = "";
        public string ChargeCodeV = "";
        public string infoChIDV = "";
        public string BasidIDV = "";
        public string CntryTypeIDV = "";
        public string CommodityTypeV = "";
        public string CurrencyV = "";
        public string AmtVn = "";
        public string CollectionModeV = "";
        public string ChargeOwnershipV = "";
        public DateTime CurrentDate;
        public string CurrentDatev = "";
        public string Itemsv = "";
        public string BLID = "";
        public string BLNumber = "";
        public string CorrectionNo = "";
        public string Status = "";
        public string BkgID = "";
        public string AgencyID = "";
        public string Draft = "";
        public string Cancelled = "";
        public string Confirm = "";



    }
}
