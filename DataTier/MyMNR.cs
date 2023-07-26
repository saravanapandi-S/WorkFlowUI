using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyMNR
    {



    }
    public class MyDamage
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _DamageCode = string.Empty;
        public string DamageCode { get { return _DamageCode; } set { _DamageCode = value; } }

        private string _DamageDescription = string.Empty;
        public string DamageDescription { get { return _DamageDescription; } set { _DamageDescription = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _StatusResult = string.Empty;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }

        private string _DepName = string.Empty;
        public string DepName { get { return _DepName; } set { _DepName = value; } }
    }

    public class MyRepair
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _RepairCode = string.Empty;
        public string RepairCode { get { return _RepairCode; } set { _RepairCode = value; } }

        private string _RepairDescription = string.Empty;
        public string RepairDescription { get { return _RepairDescription; } set { _RepairDescription = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _StatusResult = string.Empty;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }
    }

    public class MyMNRLoc
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _LocationCode = string.Empty;
        public string LocationCode { get { return _LocationCode; } set { _LocationCode = value; } }

        private string _Description = string.Empty;
        public string Description { get { return _Description; } set { _Description = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private string _StatusResult = string.Empty;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }
    }

    public class MyComponent
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private string _ComponentCode = string.Empty;
        public string ComponentCode { get { return _ComponentCode; } set { _ComponentCode = value; } }

        private string _ComponentDescription = string.Empty;
        public string ComponentDescription { get { return _ComponentDescription; } set { _ComponentDescription = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private int _AssemblyID;
        public int AssemblyID { get { return _AssemblyID; } set { _AssemblyID = value; } }

        private string _StatusResult;
        public string StatusResult { get { return _StatusResult; } set { _StatusResult = value; } }

        private string _Assembly = string.Empty;
        public string Assembly { get { return _Assembly; } set { _Assembly = value; } }

        private string _GeneralName = string.Empty;
        public string GeneralName { get { return _GeneralName; } set { _GeneralName = value; } }
    }

    public class MyMNRTariff
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private int _VendorID;
        public int VendorID { get { return _VendorID; } set { _VendorID = value; } }

        private int _DepotID;
        public int DepotID { get { return _DepotID; } set { _DepotID = value; } }

        private int _CurrencyID;
        public int CurrencyID { get { return _CurrencyID; } set { _CurrencyID = value; } }

        private string _DtValidFrom = string.Empty;
        public string DtValidFrom { get { return _DtValidFrom; } set { _DtValidFrom = value; } }

        private string _DtValidTill= string.Empty;
        public string DtValidTill { get { return _DtValidTill; } set { _DtValidTill = value; } }

        private int _UserID;
        public int UserID { get { return _UserID; } set { _UserID = value; } }

        private string _Vendor = string.Empty;
        public string Vendor { get { return _Vendor; } set { _Vendor = value; } }

        private string _Depot = string.Empty;
        public string Depot { get { return _Depot; } set { _Depot = value; } }

        private string _Currency = string.Empty;
        public string Currency { get { return _Currency; } set { _Currency = value; } }

        public string Itemsv;


        private string _DamageDescription = string.Empty;
        public string DamageDescription { get { return _DamageDescription; } set { _DamageDescription = value; } }

        private int _TID;
        public int TID { get { return _TID; } set { _TID = value; } }

        private int _DamageID;
        public int DamageID { get { return _DamageID; } set { _DamageID = value; } }

        private int _RepairID;
        public int RepairID { get { return _RepairID; } set { _RepairID = value; } }

        private int _LocationID;
        public int LocationID { get { return _LocationID; } set { _LocationID = value; } }

        private int _ComponentID;
        public int ComponentID { get { return _ComponentID; } set { _ComponentID = value; } }

        private string _Length = string.Empty;
        public string Length { get { return _Length; } set { _Length = value; } }

        private string _LabourHrs = string.Empty;
        public string LabourHrs { get { return _LabourHrs; } set { _LabourHrs = value; } }

        private string _Width = string.Empty;
        public string Width { get { return _Width; } set { _Width = value; } }

        private string _LabourCostx100 = string.Empty;
        public string LabourCostx100 { get { return _LabourCostx100; } set { _LabourCostx100 = value; } }

        private string _MaterialCostx100 = string.Empty;
        public string MaterialCostx100 { get { return _MaterialCostx100; } set { _MaterialCostx100 = value; } }

        private string _TotalCost = string.Empty;
        public string TotalCost { get { return _TotalCost; } set { _TotalCost = value; } }

    }
    public class MyMNRRepair
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        private int _DID;
        public int DID { get { return _DID; } set { _DID = value; } }

        private int _VendorID;
        public int VendorID { get { return _VendorID; } set { _VendorID = value; } }

        private int _DepotID;
        public int DepotID { get { return _DepotID; } set { _DepotID = value; } }

        private int _CurrencyID;
        public int CurrencyID { get { return _CurrencyID; } set { _CurrencyID = value; } }

        private int _Status;
        public int Status { get { return _Status; } set { _Status = value; } }

        private int _CntrID;
        public int CntrID { get { return _CntrID; } set { _CntrID = value; } }

        private int _RequestedByID;
        public int RequestedByID { get { return _RequestedByID; } set { _RequestedByID = value; } }

        public string Itemsv;

        public string SessionFinYear = "";
        public string AgentCode = "";
        private string _RequestNo = string.Empty;
        public string RequestNo { get { return _RequestNo; } set { _RequestNo = value; } }
        private string _Location= string.Empty;
        public string Location { get { return _Location; } set { _Location = value; } }

        private string _CntrNo = string.Empty;
        public string CntrNo { get { return _CntrNo; } set { _CntrNo = value; } }

        private string _TypeSize = string.Empty;
        public string TypeSize { get { return _TypeSize; } set { _TypeSize = value; } }

        private string _MtyDate = string.Empty;
        public string MtyDate { get { return _MtyDate; } set { _MtyDate = value; } }
        private string _DtRequest = string.Empty;
        public string DtRequest { get { return _DtRequest; } set { _DtRequest = value; } }

        private string _DtApproved = string.Empty;
        public string DtApproved { get { return _DtApproved; } set { _DtApproved = value; } }

        private string _RequestedBy = string.Empty;
        public string RequestedBy { get { return _RequestedBy; } set { _RequestedBy = value; } }

        private string _MNRStatus = string.Empty;
        public string MNRStatus { get { return _MNRStatus; } set { _MNRStatus = value; } }

        private string _LabCost = string.Empty;
        public string LabCost { get { return _LabCost; } set { _LabCost = value; } }

        private string _MatCost = string.Empty;
        public string MatCost { get { return _MatCost; } set { _MatCost = value; } }

        private string _EstTotalCost = string.Empty;
        public string EstTotalCost { get { return _EstTotalCost; } set { _EstTotalCost = value; } }

        private string _ApprTotalCost = string.Empty;
        public string ApprTotalCost { get { return _ApprTotalCost; } set { _ApprTotalCost = value; } }

        private string _ReqRefNo = string.Empty;
        public string ReqRefNo { get { return _ReqRefNo; } set { _ReqRefNo = value; } }

        private string _DtFrom = string.Empty;
        public string DtFrom { get { return _DtFrom; } set { _DtFrom = value; } }

        private string _DtTo = string.Empty;
        public string DtTo { get { return _DtTo; } set { _DtTo = value; } }

        private string _Currency = string.Empty;
        public string Currency { get { return _Currency; } set { _Currency = value; } }

        private string _StatusCode = string.Empty;
        public string StatusCode { get { return _StatusCode; } set { _StatusCode = value; } }

        private string _DtModified = string.Empty;
        public string DtModified { get { return _DtModified; } set { _DtModified = value; } }
        private string _Depot = string.Empty;
        public string Depot { get { return _Depot; } set { _Depot = value; } }

        private string _DamageCode = string.Empty;
        public string DamageCode { get { return _DamageCode; } set { _DamageCode = value; } }

        private string _RepairCode = string.Empty;
        public string RepairCode { get { return _RepairCode; } set { _RepairCode = value; } }

        private string _ComponentCode = string.Empty;
        public string ComponentCode { get { return _ComponentCode; } set { _ComponentCode = value; } }

        private string _LocationCode = string.Empty;
        public string LocationCode { get { return _LocationCode; } set { _LocationCode = value; } }

        private string _DamageDescription = string.Empty;
        public string DamageDescription { get { return _DamageDescription; } set { _DamageDescription = value; } }

        private string _Measurement = string.Empty;
        public string Measurement { get { return _Measurement; } set { _Measurement = value; } }

        private string _MeasureUnit = string.Empty;
        public string MeasureUnit { get { return _MeasureUnit; } set { _MeasureUnit = value; } }

        private string _LabHrs = string.Empty;
        public string LabHrs { get { return _LabHrs; } set { _LabHrs = value; } }
        private string _TotalCost = string.Empty;
        public string TotalCost { get { return _TotalCost; } set { _TotalCost = value; } }

        private string _Qty = string.Empty;
        public string Qty { get { return _Qty; } set { _Qty = value; } }

        private string _TotalLabCost = string.Empty;
        public string TotalLabCost { get { return _TotalLabCost; } set { _TotalLabCost = value; } }

        private string _TotalMatCost = string.Empty;
        public string TotalMatCost { get { return _TotalMatCost; } set { _TotalMatCost = value; } }
        
         private string _VendorRemarks = string.Empty;
        public string VendorRemarks { get { return _VendorRemarks; } set { _VendorRemarks = value; } }

        private int _DamageID;
        public int DamageID { get { return _DamageID; } set { _DamageID = value; } }

        private int _RepairID;
        public int RepairID { get { return _RepairID; } set { _RepairID = value; } }

        private int _ComponentID;
        public int ComponentID { get { return _ComponentID; } set { _ComponentID = value; } }


        private int _LocationID;
        public int LocationID { get { return _LocationID; } set { _LocationID = value; } }


        private int _AgencyID;
        public int AgencyID { get { return _AgencyID; } set { _AgencyID = value; } }

        private string _CostTo = string.Empty;
        public string CostTo { get { return _CostTo; } set { _CostTo = value; } }

        private string _ApproveReject = string.Empty;
        public string ApproveReject { get { return _ApproveReject; } set { _ApproveReject = value; } }

        private string _MNRAttachType = string.Empty;
        public string MNRAttachType { get { return _MNRAttachType; } set { _MNRAttachType = value; } }
        private int _AttachTypeID;
        public int AttachTypeID { get { return _AttachTypeID; } set { _AttachTypeID = value; } }

        private int _UploadedBy;
        public int UploadedBy { get { return _UploadedBy; } set { _UploadedBy = value; } }
        private string _FileName = string.Empty;
        public string FileName { get { return _FileName; } set { _FileName = value; } }
        private string _AttachFile = string.Empty;
        public string AttachFile { get { return _AttachFile; } set { _AttachFile = value; } }

        private string _AppliedAt = string.Empty;
        public string AppliedAt { get { return _AppliedAt; } set { _AppliedAt = value; } }


        private string _ApprovedBy = string.Empty;
        public string ApprovedBy { get { return _ApprovedBy; } set { _ApprovedBy = value; } }

        private string _DtRepaired = string.Empty;
        public string DtRepaired { get { return _DtRepaired; } set { _DtRepaired = value; } }

        private string _ApprovalNo = string.Empty;
        public string ApprovalNo { get { return _ApprovalNo; } set { _ApprovalNo = value; } }
        private string _ApprLabHrs = string.Empty;
        public string ApprLabHrs { get { return _ApprLabHrs; } set { _ApprLabHrs = value; } }

        private string _ApprLabCost = string.Empty;
        public string ApprLabCost { get { return _ApprLabCost; } set { _ApprLabCost = value; } }
        private string _ApprMatCost = string.Empty;
        public string ApprMatCost{ get { return _ApprMatCost; } set { _ApprMatCost = value; } }

        private string _ApprTotalLabCost = string.Empty;
        public string ApprTotalLabCost { get { return _ApprTotalLabCost; } set { _ApprTotalLabCost = value; } }

        private string _ApprTotalMatCost = string.Empty;
        public string ApprTotalMatCost { get { return _ApprTotalMatCost; } set { _ApprTotalMatCost = value; } }

        private string _TotalApprCost = string.Empty;
        public string TotalApprCost { get { return _TotalApprCost; } set { _TotalApprCost = value; } }
        private string _ApproverRemarks = string.Empty;
        public string ApproverRemarks { get { return _ApproverRemarks; } set { _ApproverRemarks = value; } }

        private int _ApprovedAtID;
        public int ApprovedAtID { get { return _ApprovedAtID; } set { _ApprovedAtID = value; } }

        private int _ApprovedByID;
        public int ApprovedByID { get { return _ApprovedByID; } set { _ApprovedByID = value; } }

        private string _Commodity = string.Empty;
        public string Commodity { get { return _Commodity; } set { _Commodity = value; } }

        private string _BLNumber = string.Empty;
        public string BLNumber { get { return _BLNumber; } set { _BLNumber = value; } }

        private string _POLCode = string.Empty;
        public string POLCode { get { return _POLCode; } set { _POLCode = value; } }

        private string _PODCode = string.Empty;
        public string PODCode { get { return _PODCode; } set { _PODCode = value; } }

        private string _NoofPackages = string.Empty;
        public string NoofPackages { get { return _NoofPackages; } set { _NoofPackages = value; } }

        private string _CargoDescription = string.Empty;
        public string CargoDescription { get { return _CargoDescription; } set { _CargoDescription = value; } }

        private string _GrsWt = string.Empty;
        public string GrsWt { get { return _GrsWt; } set { _GrsWt = value; } }

        private string _PackageTypes = string.Empty;
        public string PackageTypes { get { return _PackageTypes; } set { _PackageTypes = value; } }


        private string _DtSvrReq = string.Empty;
        public string DtSvrReq { get { return _DtSvrReq; } set { _DtSvrReq = value; } }

        private string _DtSvrComplete = string.Empty;
        public string DtSvrComplete { get { return _DtSvrComplete; } set { _DtSvrComplete = value; } }

        private string _Surveyor = string.Empty;
        public string Surveyor { get { return _Surveyor; } set { _Surveyor = value; } }

        private string _ApprovedAt = string.Empty;
        public string ApprovedAt { get { return _ApprovedAt; } set { _ApprovedAt = value; } }

        private string _Vendor = string.Empty;
        public string Vendor { get { return _Vendor; } set { _Vendor = value; } }

        private string _EORCntrs = string.Empty;
        public string EORCntrs { get { return _EORCntrs; } set { _EORCntrs = value; } }

        private string _Repaired = string.Empty;
        public string Repaired { get { return _Repaired; } set { _Repaired = value; } }

        private string _Approved = string.Empty;
        public string Approved { get { return _Approved; } set { _Approved = value; } }

        private string _OpenedEOR = string.Empty;
        public string OpenedEOR { get { return _OpenedEOR; } set { _OpenedEOR = value; } }

        private string _Rejected = string.Empty;
        public string Rejected { get { return _Rejected; } set { _Rejected = value; } }

        private string _MovedToAV = string.Empty;
        public string MovedToAV { get { return _MovedToAV; } set { _MovedToAV = value; } }

        private int _CommodityID;
        public int CommodityID { get { return _CommodityID; } set { _CommodityID = value; } }

        private int _BLID;
        public int BLID { get { return _BLID; } set { _BLID = value; } }

        private int _SurveyorID;
        public int SurveyorID { get { return _SurveyorID; } set { _SurveyorID = value; } }
        private int _IsVendor;
        public int IsVendor { get { return _IsVendor; } set { _IsVendor = value; } }

        private string _DtMovement = string.Empty;
        public string DtMovement { get { return _DtMovement; } set { _DtMovement = value; } }

    }

}

