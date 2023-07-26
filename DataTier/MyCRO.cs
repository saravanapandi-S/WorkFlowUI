using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyCRO
    {
        public int ID = 0;
        public int SurveyorID = 0;
        public int ReleaseToID = 0;
        public string CRONo = "";
        public string ValidTill = "";
        public string YardRemarks = "";
        public string CusRemarks = "";
        public int PickUpDepotID = 0;
        public int StuffID = 0;
        public string StuffName = "";
        public string Depot = "";
        public string SessionFinYear = "";
        public string AlertMegId;
        public string AlertMessage;
        public string Items = "";
        public int BkgID = 0;
        public string CROStatus;
        public string ReleaseTo;
        public int CheckCRO = 0;
        
    }

    public class MyCROCntrTypes
    {
        public int ID = 0;
        public int BkgID = 0;
        public int BID = 0;
        public int CntrTypeID = 0;
        public string BookingQty;
        public string RequiredQty = "";
    
    }
}