using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyCntrPickDrop
    {
        public int ID = 0;
        public int AID = 0;
        public string GeneralName = "";
        public string CntrType = "";
        public string ISOCode = "";
        public string OwningType = "";
        public int CntrTypeID = 0;
        public string AlertMegId;
        public string AlertMessage;
        public string SessionFinYear;
        public string Reference;
        public string RefDate;
        public string Remarks;
        public string AttachFile;
        public int TransactionStatus = 0;
        public int OfficeLocationID = 0;
        public int PickDropTypeID = 0;
        public int OwnCustomerID = 0;
        public int PickDropLocID = 0;
        public int OwnPrincipleID = 0;
        public int OprPrincipleID = 0;
        public string PrincipleAgent = "";
        public string Items = "";
        public string TranStatus = "";
        public string PickDropType = "";
        public string OwnPrinciple = "";
        public string Loc = "";
        public string T20Count = "";
        public string T40Count = "";
        public string TotalCount = "";
        public string ReferenceTill = "";
        public string ReferenceFrom = "";
        public string CntrNo = "";
        public int ISOCodeID = 0;
        public int CID = 0;
        public int OwningTypeID = 0;
        public int CntrID = 0;
        public int UserID = 0;
        public string ItemsCntr = "";
        public string UploadStatusID = "";
        public string CustomerName = "";
        public string ItemsCntr1 = "";

    }

    public class MyCntrTrace
    {
        public int ID = 0;
        public int CntrID = 0;
        public string MoveType = "";
        public string StorageLoc = "";
        public string LoadStatus = "";
        public string DtMovement = "";
        public string ReferenceNo = "";
        public string BookingNo = "";
        public string BOLNo = "";
        public string VesVoy = "";
        public string InventoryType = "";
        public string OwningLine = "";
        public string OperatingLine = "";
        public string ContainerType = "";
        public string ISOCode = "";
        public string OwningType = "";
        public string CntrNo = "";

    }
}


