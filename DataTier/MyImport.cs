using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
   public class MyImport
    {
        public int ID = 0;
        public string BookingNo = "";
        public string StatusV = "";
        public string POO = "";
        public string POL = "";
        public string POD = "";
        public string FPOD = "";
        public string VesVoy = "";
        public string CommodityType = "";
        public int BookingNoID = 0;
        public int BkgPartyID = 0;
        public string BkgParty = "";
        public string POOID = "";
        public string POLID = "";
        public string PODID = "";
        public string FPODID = "";
        public string  CommodityTypeID = "";
        public string DestinationAgentID = "";
        public string SurrenderStatusV = "";
        public string PartyID = "";
        public string VoyTypesV = "";
        public string LegV = "";
        public string LoadPortv = "";
        public string NextPortv = "";
        public string ETA = "";
        public string ETD = "";
        public string FreeDays = "";
        public int BCNID = 0;
        public string CntrNo = "";
        public string Size = "";
        public string ISOCode = "";
        public string SealNo = "";
        public string NoOfPkg = "";
        public string PakgType = "";
        public string PakgTypeName = "";
        public string GrsWt = "";
        public string NtWt = "";
        public string VGM = "";
        public string CBM = "";
        public string Shipper = "";
        public string Consignee = "";
        public string Notify= "";
        public string GeneralName = "";
        public string HBLNo = "";
        public string HBLDate = "";
        public string IGMNo = "";
        public string IGMDate = "";
        public string LineNumber = "";
        public string DirectImport = "";
        public string AgencyID = "";
        public string RRNo = "";
        public string VesVoyID = "";
        public string ImpID = "";
        public string CustomerName = "";
        public string ReleaseTo = "";
        public string DeliveryType = "";
        public string CFS = "";
        public string ImportIHC = "";
      
        public string NominationCFS = "";
        public string SurrenderID = "";
        public string Freedays = "";
        public string BLNumber = "";
        public string Mode = "";
        public string BLDirectImport = "";
        public string BkgID = "";
        public string SignAsAgent = "";
        public string BLType = "";
        public string BLDirect = "";
        public string ParentBLID = "";
        public string MBLNumber = "";
        public string BLVesVoyID = "";
        public string BLVesVoy = "";
        public string ValidityDate = "";
        public string PrincipalID = "";

    }
    public class MyImpBooking
    {
        public int ID = 0;
        public int ExpID = 0;
        public string HBLNo = "";
        public string HBLDate = "";
        public int DeliveryType = 0;
        public string CFS = "";
        public string ImportIHC = "";
        public string LineNumber = "";
        public string NominationCFS = "";
        public string SurrenderID = "";
        public string DONumber = "";
        public string BookingNo = "";
        public string ReleaseTo = "";
        public string VesVoy = "";
        public string ETA = "";
        public string IssueDate = "";
        public string ValidityDate = "";
        public string Status = "";
        public string UserName = "";
        public string BkgDate = "";
        public string BkgPartyID = "";
        public string BkgParty = "";
        public string ShipmentTypeID = "";
        public string ShipmentType = "";
        public string POOID = "";
        public string POO = "";
        public string POLID = "";
        public string POL = "";
        public string FPODID = "";
        public string FPOD = "";
        public string ServiceTypeID = "";
        public string ServiceType = "";
        public string CommodityTypeID = "";
        public string CommodityType = "";
        public string VesVoyID = "";
        public string ShipperID = "";
        public string Shipper = "";
        public string AgentID = "";
        public string UserID = "";
        public string PODID = "";
        public string POD = "";
        public string DestinationAgent = "";
        public string DestinationAgentID = "";
        public string NotifyID = "";
        public string ConsigneeID = "";
        public string Freedays = "";
        public string CurPortID = "";
        public string NextPortID = "";
        public string ETD = "";
        public string VoyageTypes = "";
        public string LegInformation = "";
        public string DirectImport = "";
        public string ItemsCntr = "";
        public string RecordStatus = "";
        public string ItemsVS = "";
        public int BkgID = 0;
        public string BLTypes = "";
        public string MotherBL = "";
        public string ParentBLID = "";
        public string BLVesVoy = "";
        public string BLVesVoyID = "";
        public string PrincipalID = "";




    }
    public class MyImpCAN
    {
        public int ID;
        public int ExpID;
        public string IGMNo;
        public string IGMDate;
        public string SignAsAgent;
        public string ReleaseTo;
        public string ContainerNos;
        public string LineNumber;
        public string CntrNo = "";
        public string CntrType = "";
        public string VesVoyID = "";
        public string BkgID = "";
        public string BLID = "";
        public string IsTrue = "";
        public string IsFinal = "";
        public string DONumber = "";
        public string DOID = "";
        public string Message = "";
        public string ValidityDate = "";
    }
    public class MYImpDeliveryOrder
    {
        public int ID;
        public int ExpID;
        public string DONo;
        public string IssueDate;
        public string ValidityDate;
        public string CHAImport;
        public string ReturnDepo;
        public string Remarks;
        public string ATA;
        public string ReleaseTo;
        public string ConsigneeID;
        public string SurveyorID;
        public string ForwarderID;
        public string StatusID;
        public string ETA;
        public string StatusAlery;
        public string SessionFinYear = "";
        public string AgentCode = "";
        public string AgentId = "";
        public string BLID = "";
        public string BkgID = "";
        public string Items = "";
        public string DoStatus = "";
        public string CntrID = "";
        public string DOID = "0";
    }

    public class MYImpDDG
    {
        public int ID = 0;
        public string BkgID = "";
        public string CntrIDs = "";


        public int ExpID;
        public string DONo;
        public string IssueDate;
        public string ValidityDate;
        public string CHAImport;
        public string ReturnDepo;
        public string Remarks;
        public string ATA;
        public string ReleaseTo;
        public string ConsigneeID;
        public string SurveyorID;
        public string ForwarderID;
        public string StatusID;
        public string ETA;
        public string StatusAlery;

        public string BLID = "";
        public string InclHolidays = "";
        public string DtCalFrom = "";
        public string DtPaidUpto = "";
        public string DtPaidUptoDtn = "";
        public string DtPaidUptoDem = "";
        public string DtPaidUptoGrd = "";
        public string DtnAmtx = "";
        public string DemAmtx = "";
        public string GrdAmtx = "";
        public string InvDtnAmtx = "";
        public string InvDemAmtx = "";
        public string InvGrdAmtx = "";
        public string ExRatex = "";
        public string AdvDtnx = "";
        public string AdvDemx = "";
        public string AdvGrdx = "";
        public string Items = "";
        public string UserID = "";
        public string AgentId = "";
        public string CntrCount = "";
        public string InvoiceNo = "";
        public string ESTNo = "";
        public string TillDate = "";
        public string ChargeID = "";
        public bool IsTrue;
        public string ShipmentTypeID = "";
        public string AgencyID = "";




    }
}
