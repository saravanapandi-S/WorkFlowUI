using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    #region GANESH (MERGE BOOKING ,SPLIT)
    public class MyMergeBooking
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private int _BCNID;
        public int BCNID { get { return _BCNID; } set { _BCNID = value; } }

        private string _Grid1BCNID = string.Empty;
        public string Grid1BCNID { get { return _Grid1BCNID; } set { _Grid1BCNID = value; } }

        private string _Grid2BCNID = string.Empty;
        public string Grid2BCNID { get { return _Grid2BCNID; } set { _Grid2BCNID = value; } }
        private int _BLID;
        public int BLID { get { return _BLID; } set { _BLID = value; } }
        private string _BLNumber = string.Empty;
        public string BLNumber { get { return _BLNumber; } set { _BLNumber = value; } }

        private string _Size = string.Empty;
        public string Size { get { return _Size; } set { _Size = value; } }

        private string _CntrNo = string.Empty;
        public string CntrNo { get { return _CntrNo; } set { _CntrNo = value; } }

        private string _CommodityTypes = string.Empty;
        public string CommodityTypes { get { return _CommodityTypes; } set { _CommodityTypes = value; } }
        public string AlertMessage = "";
        public string AlertMessageID = "";
        public string BkgID = "";
        public int isTrue = 0;
        public string TypeID = "";
        public string Items1 = "";
        public string Items2 = "";
        public string BLID1 = "";
        public string BLID2 = "";
    }

    public class MySplitBooking
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _VesVoy = string.Empty;
        public string VesVoy { get { return _VesVoy; } set { _VesVoy = value; } }

        private int _BLID;
        public int BLID { get { return _BLID; } set { _BLID = value; } }

        private string _GridBCNID = string.Empty;
        public string GridBCNID { get { return _GridBCNID; } set { _GridBCNID = value; } }
        public string BkgID = "";
        public string AgentCode = "";
        public string SessionFinYear = "";
        public string BookingNo = "";
        public string DestinationAgentID = "";
        public string UserID = "";
    }

    #endregion

    #region Aravindh (Booking)

    public class MyBookingSource
    {
        public int ID;
        public string CustomerID;
        public int PrincipalID;
        public int SalesPersonID;
        public int OriginID;
        public int LoadPortID;
        public int DischargePortID;
        public int DestinationID;
        public int RouteID;
        public int DeliveryTermsID;
        public string Remarks;
        public int Status;
        public string UserName;
        public string CustomerName;
        public string Principal;
        public string POL;
        public string POD;
        public string FPOD;
        public int FreeDaysOriginType;
        public string FreeDaysOrigin;
        public int FreeDaysDestinationType;
        public string FreeDaysDestination;
        public int DamageSchemeType;
        public string DamageScheme;
        public int SecDepositType;
        public string SecDepost;
        public int BOLReqType;
        public string BOLReq;
        public string EnquiryNo;
        public string AlertMegId = "";
        public string AlertMessage = "";
        public string BookingNo;
        public string BookingDate;
        public string BookingSourceID;
        public string BookingCommissionID;
        public string CargoID;
        public string CargoWeight;
        public string HSCode;
        public string VesselID;
        public string VoyageID;
        public string POLTerminalID;
        public string TSVesselID;
        public string TSVoyageID;
        public string BkgParty;
        public string VesselName;
        public string VoyageName;
        public string ETD;
        public string CntrCount;
        public string BkgCount;
        public string Satusv;
        public string ControlDisplay = "";
        public string BookingDateto = "";
        public string OfficeCode = "";

    }



    #endregion


    public class MYBookingNew
    {
        public int ID = 0;
        public string PortName = "";
        public string AgencyID = "";
        public string PrincibalID = "";
        public string AgencyName = "";
        public string CntrType = "";
        public string CntrTypeID = "";
        public string Nos = "";
        public string PerAmount = "";
        public string TotalAmount = "";
        public string Currency = "";
        public string CurrencyID = "";
        public string ManifestPerAmount = "";
        public string ManifestTotalAmount = "";
        public string CommPerAmount = "";
        public string CommTotal = "";
        public string Commodity = "";
        public string CommodityID = "";
        public string UOM = "";
        public string PaymentTerms = "";
        public string PaymentTermID = "";
        public string CostAmount = "";
        public string TotalCostAmount = "";
        public string ChargeCode = "";
        public string Amount = "";
        public string AlertMegId = "";
        public string AlertMessage = "";

        public string ShipperID = "";
        public string HSCode = "";
        public string CargoWeight = "";
        public string CargoID = "";
        public string DeliveryTermsID = "";
        public string RouteID = "";
        public string DestinationID = "";
        public string DischargeID = "";
        public string DischargePortID = "";
        public string LoadPortID = "";
        public string OriginID = "";
        public string SalesPersonID = "";
        public string ValidTillDate = "";
        public string EnquiryStatusID = "";
        public string BookingCommissionID = "";
        public string EnquirySourceID = "";
        public string EnquiryDate = "";
        public string EnquiryNo = "";
        public string ShipperChk = "";
        public string BkgPartyChk = "";
        public string CustomerID = "";

        public string VesselID = "";
        public string VoyagID = "";
        public string POLTerminalID = "";
        public string TranshipmentPortID = "";
        public string ItemsCntr = "";
        public string ItemsHarz = "";
        public string ItemsOutGaugeCargo = "";
        public string ItemsReeferGrid = "";
        public string ItemShimpmentPOL = "";
        public string ItemShimpmentPOD = "";
        public string ItemFreightRate = "";
        public string ItemSlotRate = "";
        public string ItemRevenueCostRate = "";
        public string ExRate = "";
        public string CompnayName = "";
        public string Branch = "";
        public string POD = "";
        public string FPOD = "";
        public string BasicID = "";
        public string ChargeCodeID = "";
        public int HazarOpt = 1;
        public string HazarClass = "";
        public string HazarMCONo = "";
        public string Height = "";
        public string Width = "";
        public string Length = "";
        public string OutGaugeOption = "";
        public string Reffer = "";
        public string Temperature = "";
        public string Ventilation = "";
        public string Humidity = "";
        public string Amount1 = "";
        public string Amount2 = "";
        public string Amount3 = "";
        public int ChargeOPT = 0;
        public int ReeferOpt = 0;
        public int OOGOpt = 0;
        public string SessionFinYear = "";
        public string AgentCode = "";
        public string PaymentTermsID = "";
        public int FreeDayOrigin = 0;
        public int FreeDayDestination = 0;

        public string NumberOfDays = "";
        public string NumberOfDaysDestin = "";
        public int SecurityDeposit = 0;
        public string txtSecurityDeposit = "";
        public int BOLRequirement = 0;
        public string txtBOLRequirement = "";
        public int DamageScheme = 0;
        public string txtDamageScheme = "";
        public int PayTermsID = 0;
        public string BookingNo;
        public string ItemFreightBrackup = "";
        public string Type = "";
        public string PrincipalID = "";
        public string RequestNo = "";
        public string ContractNo = "";
        public string LineContractID = "";
        public string CustomerContractID = "";

        public string PODAgentID = "0";
        public string FPODAgentID = "0";
        public string TSAgentID = "";
        public string TSTwoAgentID = "";
        public string SlotOperatorID = "";
        public int OwnershipID = 0;
        public int FixedID = 0;
        public string TSVesselID = "";
        public string TSVoyageID = "";
        public string VoyageID = "";
        public string CompanyNameV = "";
        public string Remarks = "";
        public string BkgId = "0";
        public string BookingStatus = "";
        public string EnqID = "0";
        public string OfficeCode = "";
        public int NominationID = 0;
        public string GeneralName = "";
        public int PaymentCenterID = 0;
        public int SlotUptoID = 0;
        public string intStatus = "";
    }

}
