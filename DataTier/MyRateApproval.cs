using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyRateApproval
    {

        public int ID = 0;
        public int AID = 0;
        public string LineName = "";
        public string RouteType = "";
        public string PartyID = "";
        public string AlertMegId;
        public string AlertMessage;
        public int PrincipleID = 0;
        public string RequestDate = "";
        public string RequestNo = "";
        public string RequestFrom = "";
        public string RequestTo = "";
        public int EnquiryID = 0;
        public int SalesPersonID = 0;
        public string ValidTill = "";
        public int DischargePortID = 0;
        public int DestinationID = 0;
        public int OriginID = 0;
        public int LoadPortID = 0;
        public int RouteTypeID = 0;
        public int DeliveryTermID = 0;
        public string SessionFinYear = "";
        public string DeliveryTerms = "";
        public string Status = "";
        public string ValidStatus = "";
        public int StatusID = 0;
        public string Principle = "";
        public string POL = "";
        public string POD = "";
        public string FPOD = "";
        public string SalesPerson = "";
        public string EnquiryNo = "";
        public string CargoTypes = "";
        public string Items = "";
        public string ItemsAttach = "";
        public string Remarks = "";
        public int FreeDaysOrigin = 0;
        public string FreeDaysOrgValue = "";
        public int FreeDaysDest = 0;
        public string FreeDaysDestValue = "";
        public int SecurityDeposit = 0;
        public string SecurityDepositDesc = "";
        public int BOLReq = 0;
        public string BOLReqDesc = "";
        public int DamageScheme = 0;
        public string DamageSchemeValue = "";
        public string CancelRemarks = "";
        public string PrincipleN = "";
        public string PODN = "";
        public string FPODN = "";
        public string POLN = "";
        public int RejectReasonID = 0;
        public int CancelReasonID = 0;
        public string GeneralName = "";
        public string RejectRemarks = "";
        public string Reason = "";
        public int ValidStatusID;
        public int OfficeLocID;
        public int OpenCount;

    }

    public class MyRateApprovalCharges
    {
        public int ID = 0;
        public int PID = 0;
        public int CntrTypeID = 0;
        public string Nos = "";
        public int CargoTypeID = 0;
        public string FrieghtAmount = "";
        public int FrtCurrID = 0;
        public string SlotAmount = "";
        public int SlotCurrID = 0;
        public int StdSplID = 0;
        public string StdSplAmount = "";
        public int StdSplCurrID = 0;
        public int StdSplVID = 0;
        public string StdSplVAmount = "";
        public int StdSplVCurrID = 0;
        public int EnquiryID = 0;
        public string AttachName = "";
        public int AID = 0;
        public string AttachFile = "";

    }
}
