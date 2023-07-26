using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyRepositioning
    {
        public int ID;
        public string RequestNo;
        public int RepoType;
        public string ReqDate;
        public int RepoStatus;
        public int OriginID;
        public int POLID;
        public int PODID;
        public int PrincipleID;
        public int POLAgentID;
        public int PODAgentID;
        public string Transporter;
        public string AttachFile;
        public int VesselID;
        public int VoyageID;
        public string Remarks;
        public int UserID;
        public string CreatedOn;
        public string AlertMegId;
        public string AlertMessage;
        public int OfficeLocation;
            
        public string SessionFinYear;

        public string ReqDatev;
        public string POLName;
        public string PODName;
        public string VesselName;
        public string VoyageName;


        public string RepoStatusName;
        public string RepoTypeName;

        public string PrincipleName;
        public string OriginName;

        public string Itemsv;
        public string Itemsvc;
        
        public int RepoID;
        public int RID;
        public int CntrTypeID;
        public string CntrType;
        public int StorageLocID;
        public string StorageLoc;
        public string Nos;
        public string DtFrom;
        public string DtTo;

        public string ISOCode;


        private string _CntrNo = string.Empty;
        public string CntrNo { get { return _CntrNo; } set { _CntrNo = value; } }

        private string _StatusCode = string.Empty;
        public string StatusCode { get { return _StatusCode; } set { _StatusCode = value; } }

        private string _DtMovement = string.Empty;
        public string DtMovement { get { return _DtMovement; } set { _DtMovement = value; } }

        private string _Location = string.Empty;
        public string Location { get { return _Location; } set { _Location = value; } }


        private string _Status = string.Empty;
        public string Status { get { return _Status; } set { _Status = value; } }

        public string StatuID = "";

        private string _ContainerNos = string.Empty;
        public string ContainerNos { get { return _ContainerNos; } set { _ContainerNos = value; } }


        public string Date = "";
        public string Dateto = "";


    }

   
}
