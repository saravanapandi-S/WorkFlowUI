using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
   public class MyBOLData
    {
        public int ID;
        public int MainID;
        public string CustomerName = "";
        public string PartyType = "";
        public int PartyTypeID;
        public string CustomerAddress = "";
        public string ShipperName = "";
        public string ShipperAddress = "";
        public string Consignee = "";
        public string ConsigneeAddress = "";
        public string Notify = "";
        public string NotifyAddress = "";
        public string NotifyAlso = "";
        public string NotifyAlsoAddress = "";
        public string SeqNo = "";
        public int BLID;
        public string ShipperType = "";
        public string ConsigneeType = "";
        public string NotifyType = "";
        public string NotifyAlsoType = "";
        public string Origin = "";
        public string LoadPort = "";
        public string Discharge = "";
        public string Destination = "";
        public int PaymentTermsID;
        public int OriginID;
        public int LoadPortID;
        public int DischargeID;
        public int DestinationID;
        public int BkgID;
        public int BkgId;
        public int BLNumberID;
        public string InputSourceID;
        public string BLTemplateID;
        public int DeliveryAgent;
        public string DeliveryAgentAddress;
        public string PlaceofRecID;
        public string PortofLoadPortID;
        public string PortofDischargeID;
        public string PortofDestinationID;
        public string MarksNos;
        public string Packages;
        public string Description;
        public string PaymentTerms = "";
        public string Weight;
        public string FreightTermsID;
        public string FreightPayableAt;
        public int BLTypeID;
        public string NoOfOriginal;
        public int RFLBol;
        public string BLIssueDate;
        public string PlaceOfIssue;
        public string ShipOnboardDate;
        public int PrintWt;
        public int PrintNetWt;
        public int NotPrint;
        public string CurrentDate;
        public string Itemsv1 = "";
        public string AttachShippingBill = "";
        public string AttachCustomerApproval = "";
        public int PartyID;
        public int ContID;
        public int BLStatus;
        public string BLNumber = "";
        public string BLType = "";
        public string BLStatusv = "";
        public string IssueDate = "";
        public int ChkBL;
        public int UserID;
        public string ItemsAttach = "";
        public int AID;
        public string AttachName = "";
        public string AttachFile = "";
        public int AttachCount;
        public string ItemsBLNotes = "";
        public int BLTempID;
        public string BLTemplateName = "";
        public string PartyName = "";
        public string IssuedBy = "";
        public string SOBDate = "";
        public string SurrenderDate = "";
        public string AttachSurrenderFile = "";
        public int RadBLID;
        public string Remarks = "";
        public string Items = "";
        public string BLPrintPath = "";

    }
    public class BLNo
    {
        public int ID;
        public string BLNumber = "";
        public int BkgId;
        public int BLID;
        public int MainID;
    }
    public class BLTypes
    {
        public int ID;
        public string BLType = "";
    }
    public class PortVessel
    {
        public int ID;
        public string PortName = "";
    }
    public class BLContainer
    {
        public int ID;
        public int  CargoID;
        public int BkgId;
        public int BLID;
        public int CntrID;
        public string ContainerNo = "";
        public string ContrType = "";
        public string AgentSealNo = "";
        public string CustomerSealNo = "";
        public string GrsWt = "";
        public string NetWt = "";
        public string NoOfPkgs = "";
        public string Volume = "";
    }

    public class BLNotes
    {
        public int ID;
        public string Notes = "";
        public string DocID = "";
        public int BLID;
        public int BkgId;
        public int IsTrue;
    }
}
