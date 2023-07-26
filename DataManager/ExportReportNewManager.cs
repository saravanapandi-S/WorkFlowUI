using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using DataBaseFactory;
using System.Data;
using System.Data.Common;
using DataTier;

namespace DataManager
{
   public class ExportReportNewManager
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public ExportReportNewManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Anand

        #region ExportReport
        public List<MyExportReportNew> NextPortByVesVoyDtls(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetNextPortValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyExportReportNew
                {
                    NextPortID = Int32.Parse(dt.Rows[i]["NextPortID"].ToString()),
                    ID = UInt16.Parse(dt.Rows[i]["VesVoyID"].ToString()),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    NextPort = dt.Rows[i]["NextPort"].ToString(),
                });
            }
            return ReportList;
        }
        public DataTable GetNextPortValues(MyExportReportNew Data)
        {
            string _Query = "select distinct VesVoyID, " +
                            " (select top(1) PortID from NVO_VoyageRoute inner join NVO_PortMaster On NVO_PortMaster.ID = NVO_VoyageRoute.PortID where NVO_VoyageRoute.VoyageID = NVO_Booking.VesVoyID order by NVO_VoyageRoute.RID DESC) NextPortID, " +
                            " (select  top(1) convert(varchar, ETD, 23) as ETD from NVO_VoyageRoute where NVO_Booking.VesVoyID = NVO_VoyageRoute.VoyageID)as ETD , " +
                            " (select top(1) PortName from NVO_VoyageRoute inner join NVO_PortMaster On NVO_PortMaster.ID = NVO_VoyageRoute.PortID where NVO_VoyageRoute.VoyageID = NVO_Booking.VesVoyID order by NVO_VoyageRoute.RID DESC) " +
                            " as NextPort from NVO_Booking where NVO_Booking.VesVoyID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyExportReportNew> TerminaDepBind(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetTerminalDepValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyExportReportNew
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    TerminalName = dt.Rows[i]["TerminalName"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    NextPort = dt.Rows[i]["NextPort"].ToString(),
                    NextPortETA = dt.Rows[i]["NextETA"].ToString()
                });
            }
            return ReportList;
        }
        public DataTable GetTerminalDepValues(MyExportReportNew Data)
        {
            string strWhere = "";
            string _Query = "select NVO_Voyage.ID, " +
                            " (select top(1) VesselName from NVO_VesselMaster where ID = NVO_Voyage.VesselID) +' -' + (select top(1)ExportVoyageCd from NVO_VoyageRoute where VoyageID = NVO_Voyage.ID) as VesVoy, " +
                            " (select top(1) PortName from NVO_VoyageRoute inner join NVO_PortMaster On NVO_PortMaster.ID = NVO_VoyageRoute.PortID where NVO_VoyageRoute.VoyageID = NVO_Voyage.id order by NVO_VoyageRoute.RID asc)  as POL, " +
                            " (select top(1)(select TerminalName from NVO_TerminalMaster where NVO_TerminalMaster.ID = NVO_VoyageRoute.TerminalID) from NVO_VoyageRoute inner join NVO_PortMaster On NVO_PortMaster.ID = NVO_VoyageRoute.PortID where NVO_VoyageRoute.VoyageID = NVO_Voyage.id " +
                            " order by NVO_VoyageRoute.RID ASC) as TerminalName,(select  top(1) Convert(varchar, ETD, 103) from NVO_VoyageRoute where NVO_Voyage.id = NVO_VoyageRoute.VoyageID order by NVO_VoyageRoute.RID ASC)as ETD ,  (select top(1) PortName from NVO_VoyageRoute " +
                            " inner join NVO_PortMaster On NVO_PortMaster.ID = NVO_VoyageRoute.PortID where NVO_VoyageRoute.VoyageID = NVO_Voyage.id order by NVO_VoyageRoute.RID DESC)  as NextPort, (select  top(1) Convert(varchar, ETA, 103) from NVO_VoyageRoute where NVO_Voyage.id = NVO_VoyageRoute.VoyageID " +
                            " order by NVO_VoyageRoute.RID ASC)as NextETA from NVO_Voyage where IsExpImp=0 ";

            if (Data.ID.ToString() != "" && Data.ID.ToString() != "0" && Data.ID.ToString() != null && Data.ID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " and NVO_Voyage.ID = " + Data.ID.ToString();
                else
                    strWhere += " and NVO_Voyage.ID = " + Data.ID.ToString();

            if (Data.AgencyID.ToString() != "" && Data.AgencyID.ToString() != "0" && Data.AgencyID.ToString() != null && Data.AgencyID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " and NVO_Voyage.AgencyID = " + Data.AgencyID.ToString();
                else
                    strWhere += " and NVO_Voyage.AgencyID = " + Data.AgencyID.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }

        public List<MyExportReportNew> DestinationAgentMaster(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetDestinationValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyExportReportNew
                {
                    ID = Int32.Parse(dt.Rows[i]["VesVoyID"].ToString()),
                    DestinationAgentID = dt.Rows[i]["DestinationAgentID"].ToString(),
                    DestinationAgent = dt.Rows[i]["DestinationAgent"].ToString(),
                });
            }
            return ReportList;
        }
        public DataTable GetDestinationValues(MyExportReportNew Data)
        {
            string _Query = "select distinct DestinationAgentID,DestinationAgent,VesVoyID from NVO_Booking where VesVoyID=" + Data.ID + " and AgentID=" + Data.AgencyID;
            return GetViewData(_Query, "");
        }

        public List<MyExportReportNew> SlotOperatorMaster(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetSlotOperatorDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyExportReportNew
                {
                    ID = Int32.Parse(dt.Rows[i]["VesVoyID"].ToString()),
                    Operator = dt.Rows[i]["Operator"].ToString(),
                    OperatorID = dt.Rows[i]["OperatorID"].ToString(),
                });
            }
            return ReportList;
        }
        public DataTable GetSlotOperatorDtls(MyExportReportNew Data)
        {
            string _Query = "select distinct VesVoyID, (select Top(1)Operator from NVO_VoyageOpertaors where NVO_VoyageOpertaors.OperatorID = SlotOperatorID) as Operator, " +
                            " (select Top(1)OperatorID from NVO_VoyageOpertaors where NVO_VoyageOpertaors.OperatorID = SlotOperatorID) as OperatorID " +
                            " from NVO_Booking where VesVoyID=" + Data.ID + " and AgentID=" + Data.AgencyID;
            return GetViewData(_Query, "");
        }

        public List<MyExportReportNew> TerminalDepReportMain(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetTerminalReportMain(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyExportReportNew
                {
                    ID = Int32.Parse(dt.Rows[i]["VesVoyID"].ToString()),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    NextPort = dt.Rows[i]["NextPort"].ToString(),
                    NextPortETA = dt.Rows[i]["NextPortETA"].ToString(),

                });
            }
            return ReportList;
        }
        public DataTable GetTerminalReportMain(MyExportReportNew Data)
        {
            string _Query = "select Top(1) POL,VesVoy,(select top(1)  ExportVoyageCd from NVO_VoyageRoute where NVO_VoyageRoute.VoyageID = NVO_Booking.VesVoyID order by NVO_VoyageRoute.RID desc)as VoyageNo, " +
                            " (select Convert(varchar, ETA, 106) from NVO_VoyageRoute where NVO_VoyageRoute.RID = NVO_Booking.ID) as ETA, (select Convert(varchar, ETD, 106) from NVO_VoyageRoute where NVO_VoyageRoute.RID = NVO_Booking.ID)as ETD, " +
                            " (select top(1) PortName from NVO_VoyageRoute inner join NVO_PortMaster On NVO_PortMaster.ID = NVO_VoyageRoute.PortID where NVO_VoyageRoute.VoyageID = NVO_Booking.VesVoyID order by NVO_VoyageRoute.RID desc)as NextPort, " +
                            " convert(varchar, (select top(1)  ETA from NVO_VoyageRoute where NVO_VoyageRoute.VoyageID = NVO_Booking.VesVoyID order by NVO_VoyageRoute.RID desc),106) as NextPortETA, " +
                            " (select top(1) Operator from NVO_VoyageOpertaors where NVO_VoyageOpertaors.VoyageID = NVO_Booking.VesVoyID) as VesselOperator, " +
                            " (select top(1) AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_Booking.DestinationAgentID) as PODAgent, " +
                            " VesVoyID from NVO_Booking where VesVoyID=" + Data.ID + " and AgentID=" + Data.AgencyID;
            return GetViewData(_Query, "");
        }

        public List<MyExportReportNew> TerminalDepReportBLMain(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetTerminalReportMainBLDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyExportReportNew
                {
                    SNo = dt.Rows[i]["SNo"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    BLNUMBER = dt.Rows[i]["BLNUMBER"].ToString(),
                    ServiceType = dt.Rows[i]["ServiceType"].ToString(),
                    TSPORT = dt.Rows[i]["TSPORT"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    Shipper = dt.Rows[i]["Shipper"].ToString(),
                    PickUpDate = dt.Rows[i]["PickUpDate"].ToString(),
                    GrsWt = dt.Rows[i]["GrsWt"].ToString(),
                    VesselOperator = dt.Rows[i]["Operator"].ToString(),
                    PODAgent = dt.Rows[i]["DestinationAgent"].ToString(),
                });
            }
            return ReportList;
        }
        public DataTable GetTerminalReportMainBLDtls(MyExportReportNew Data)
        {
            string strWhere = "";
            string _Query = "Select * from NVO_ViewTerminalDepReport WHERE  VesVoyID=" + Data.VesVoyID + "";

            if (Data.POD != "" && Data.POD != "0" && Data.POD != null && Data.POD != "?")

                if (strWhere == "")
                    strWhere += _Query + " and (select top(1) PODID   from NVO_Booking where ID = BkgId) =" + Data.POD;
                else
                    strWhere += " and (select top(1) PODID   from NVO_Booking where ID = BkgId) =" + Data.POD;


            if (Data.TSPORTID != "" && Data.TSPORTID != "0" && Data.TSPORTID != null && Data.TSPORTID != "?")

                if (strWhere == "")
                    strWhere += _Query + " and (select top(1) TSPORTID   from NVO_Booking where ID = BkgId)=" + Data.TSPORTID;
                else
                    strWhere += " and (select top(1) TSPORTID   from NVO_Booking where ID = BkgId)=" + Data.TSPORTID;

            if (Data.DestinationAgentID != "" && Data.DestinationAgentID != "0" && Data.DestinationAgentID != null && Data.DestinationAgentID != "?")

                if (strWhere == "")
                    strWhere += _Query + " and (select top(1) DestinationAgentID   from NVO_Booking where ID = BkgId)=" + Data.DestinationAgentID;
                else
                    strWhere += " and (select top(1) DestinationAgentID   from NVO_Booking where ID = BkgId)=" + Data.DestinationAgentID;


            if (Data.SlotOperator != "" && Data.SlotOperator != "0" && Data.SlotOperator != null && Data.SlotOperator != "?")

                if (strWhere == "")
                    strWhere += _Query + " and (select top(1) SlotOperatorID   from NVO_Booking where ID = BkgId)=" + Data.SlotOperator;
                else
                    strWhere += " and (select top(1) SlotOperatorID   from NVO_Booking where ID = BkgId)=" + Data.SlotOperator;


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }

        public List<MyExportReportNew> BLNumberByVesVoy(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetBLNumbers(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyExportReportNew
                {
                    ID = Int32.Parse(dt.Rows[i]["BLVesVoyID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLID = dt.Rows[i]["ID"].ToString(),
                    ChkFlag = dt.Rows[i]["ChkFlag"].ToString(),
                });
            }
            return ReportList;
        }
        public DataTable GetBLNumbers(MyExportReportNew Data)
        {
            string _Query = "Select ID,'0' as ChkFlag, BLVesVoyID,BLNumber from NVO_BOL where BLVesVoyID=" + Data.ID + " and ID in (select BLID from NVO_BLRelease)";
            return GetViewData(_Query, "");
        }
        public List<MyExportReportNew> BLNumberChange(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetBLNumbersChange(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyExportReportNew
                {
                    ID = Int32.Parse(dt.Rows[i]["BLVesVoyID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLID = dt.Rows[i]["ID"].ToString(),
                    ChkFlag = dt.Rows[i]["ChkFlag"].ToString(),
                    TSPORTID = dt.Rows[i]["TSPORTID"].ToString(),
                    TSPORT = dt.Rows[i]["TSPORT"].ToString(),
                    DestinationAgentID = dt.Rows[i]["DestinationAgentID"].ToString(),
                });
            }
            return ReportList;
        }
        public DataTable GetBLNumbersChange(MyExportReportNew Data)
        {
            string strWhere = "";
            string _Query = "Select NVO_BOL.ID,'0' as ChkFlag, BLVesVoyID,BLNumber,TSPORTID,TSPORT,DestinationAgentID from NVO_BOL" +
                            " inner join NVO_Booking On NVO_Booking.ID = NVO_BOL.BkgID where NVO_BOL.ID in (select BLID from NVO_BLRelease) and  BLVesVoyID=" + Data.ID;

            if (Data.BLID != "" && Data.BLID != "0" && Data.BLID != null && Data.BLID != "?")
            {
                if (strWhere == "")
                    strWhere += _Query + " and NVO_BOL.ID=" + Data.BLID;
                else
                    strWhere += " and NVO_BOL.ID=" + Data.BLID;
            }

            if (Data.TSPORTID != "" && Data.TSPORTID != "0" && Data.TSPORTID != null && Data.TSPORTID != "?")
            {
                if (strWhere == "")
                    strWhere += _Query + " and TSPORTID=" + Data.TSPORTID;
                else
                    strWhere += " and TSPORTID=" + Data.TSPORTID;
            }
            if (Data.DestinationAgentID != "" && Data.DestinationAgentID != "0" && Data.DestinationAgentID != null && Data.DestinationAgentID != "?")
            {
                if (strWhere == "")
                    strWhere += _Query + " and DestinationAgentID=" + Data.DestinationAgentID;
                else
                    strWhere += " and DestinationAgentID=" + Data.DestinationAgentID;
            }

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }
        public List<MyExportReportNew> TranshipmentDetails(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetTranshipmentDetails(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyExportReportNew
                {
                    TSPORTID = dt.Rows[i]["TSPORTID"].ToString(),
                    TSPORT = dt.Rows[i]["TSPORT"].ToString(),
                });
            }
            return ReportList;
        }
        public DataTable GetTranshipmentDetails(MyExportReportNew Data)
        {
            string _Query = "Select TSPORTID,TSPORT from NVO_BOL " +
                            " inner join NVO_Booking On NVO_Booking.ID = NVO_BOL.BkgID " +
                            " where BLVesVoyID=" + Data.ID + " and NVO_BOL.ID in (select BLID from NVO_BLRelease) and TSPORTID != 0";
            return GetViewData(_Query, "");
        }
        public List<MyExportReportNew> PODDropDown(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetPODDropDown(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyExportReportNew
                {
                    ID = Int32.Parse(dt.Rows[i]["PODID"].ToString()),
                    POD = dt.Rows[i]["POD"].ToString(),
                });
            }
            return ReportList;
        }
        public DataTable GetPODDropDown(MyExportReportNew Data)
        {
            string _Query = "Select Distinct NVO_Booking.PODID,NVO_Booking.POD from NVO_BOL " +
                            " inner join NVO_Booking On NVO_Booking.ID = NVO_BOL.BkgID " +
                            " where BLVesVoyID=" + Data.ID + " and NVO_BOL.ID in (select BLID from NVO_BLRelease) and NVO_Booking.PODID != 0";
            return GetViewData(_Query, "");
        }
        public List<MyExportReportNew> FreightManifestDtls(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetFreghtManifestMainDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyExportReportNew
                {
                    ID = Int32.Parse(dt.Rows[i]["BLVesVoyID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNo"].ToString(),
                    PODAgent = dt.Rows[i]["Agent"].ToString(),
                    AgentAddress = dt.Rows[i]["AgentAddress"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    LoadTerminal = dt.Rows[i]["LoadTerminal"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    RRID = dt.Rows[i]["RRID"].ToString()

                });
            }
            return ReportList;
        }
        public DataTable GetFreghtManifestMainDtls(MyExportReportNew Data)
        {
            string _Query = "select NVO_BLRelease.ID, BLNo,Agent, AgentAddress, VesVoy,NVO_Ratesheet.ID as RRID, " +
                            " (select top(1)  ExportVoyageCd from NVO_VoyageRoute Inner join NVO_BOL ON NVO_BOL.ID = NVO_VoyageRoute.RID where NVO_VoyageRoute.VoyageID = NVO_BOL.BLVesVoyID order by NVO_VoyageRoute.RID desc) as VoyageNo, " +
                            " (select Convert(varchar, ETA, 106) from NVO_VoyageRoute where NVO_VoyageRoute.RID = NVO_BLRelease.ID) as ETA, " +
                            " (select Convert(varchar, ETD, 106) from NVO_VoyageRoute where NVO_VoyageRoute.RID = NVO_BLRelease.ID)as ETD,POD,POL,NVO_BOL.BLVesVoyID, " +
                            " (select Top(1) TerminalName from NVO_TerminalMaster inner join NVO_VoyageRoute On NVO_VoyageRoute.TerminalID = NVO_TerminalMaster.ID where NVO_VoyageRoute.RID = NVO_BLRelease.ID)as LoadTerminal " +
                            " from NVO_BLRelease inner join NVO_Ratesheet On NVO_Ratesheet.ID = NVO_BLRelease.BLID inner join NVO_BOL On NVO_BOL.ID = NVO_BLRelease.BLID where NVO_BOL.BLVesVoyID = " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyExportReportNew> FreightManifestBLDtls(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetFreightManifestBLDtls(Data);
            var shpad = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var splitx = dt.Rows[i]["ShipperAddress"].ToString().Split('\n');
                for (int j = 0; j < splitx.Length; j++)
                {
                    shpad += splitx[j].ToString() + "<br/>";
                }
                ReportList.Add(new MyExportReportNew
                {
                    ID = Int32.Parse(dt.Rows[i]["BLVesVoyID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNo"].ToString(),
                    Shipper = dt.Rows[i]["Shipper"].ToString(),
                    ShipperAddress = shpad,
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    ConsigneeAddress = dt.Rows[i]["ConsigneeAddress"].ToString(),
                    Notify1 = dt.Rows[i]["Notify1"].ToString(),
                    Notify1Address = dt.Rows[i]["Notify1Address"].ToString(),
                    MarkNo = dt.Rows[i]["MarkNo"].ToString(),
                    NoOfPkg = dt.Rows[i]["NoOfPkg"].ToString(),
                    GrsWt = dt.Rows[i]["GrsWt"].ToString(),
                    CBM = dt.Rows[i]["CBM"].ToString(),
                    CargoDes = dt.Rows[i]["CagoDescription"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Seal = dt.Rows[i]["Seal"].ToString(),
                    FreightPayment = dt.Rows[i]["FreightPayment"].ToString(),
                    CntrDetails = dt.Rows[i]["cntrdetails"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    FRT = dt.Rows[i]["FRT"].ToString(),
                    ECRS = dt.Rows[i]["ECRS"].ToString(),
                    BAF = dt.Rows[i]["BAF"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                    Total = dt.Rows[i]["Total"].ToString()

                });
            }
            return ReportList;
        }
        public DataTable GetFreightManifestBLDtls(MyExportReportNew Data)
        {
            string _Query = "select NVO_BLRelease.ID,NVO_BLRelease.BLID, BLNo,BLVesVoyID, NVO_BLRelease.Shipper,ShipperAddress,Consignee,ConsigneeAddress, " +
                            " Notify1,Notify1Address,MarkNo,NoOfPkg,GrsWt,CagoDescription,  NVO_BLRelease.CBM,NVO_Containers.CntrNo,cntrdetails, " +
                            " (NVO_Containers.CntrNo + '/' + Size + '/' + SealNo) as Seal,FreightPayment, " +
                            " (select top(1) Size + '-' + Type from NVO_tblCntrTypes where ID = CntrTypeID) AS Size, " +
                            " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 1),0) as FRT, " +
                            " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 15),0) as ECRS, " +
                            " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 22),0) as BAF, " +
                            " ((isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 1),0)+isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 " +
                            " and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 15),0)))+(isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 22), 0))as Total " +
                            " from NVO_BLRelease " +
                            " inner join NVO_BOL On NVO_BOL.ID = NVO_BLRelease.BLID " +
                            " inner join NVO_BOLCntrDetails On NVO_BOLCntrDetails.BCNID = NVO_BLRelease.BLID " +
                            " inner join NVO_Containers On NVO_Containers.ID = NVO_BOLCntrDetails.CntrID " +
                            " inner join NVO_Booking On NVO_Booking.ID = NVO_BOL.BkgID " +
                            " inner join NVO_Ratesheet On NVO_Ratesheet.ID = NVO_Booking.RRID " +
                            " inner join NVO_RatesheetCntrTypes on NVO_RatesheetCntrTypes.RRID = NVO_Ratesheet.ID " +
                            " where NVO_BOL.BLVesVoyID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyExportReportNew> FreightManifestBLDtlsByBL(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetFreightManifestBLDtlsByBL(Data);
            var shpad = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var splitx = dt.Rows[i]["ShipperAddress"].ToString().Split('\n');
                for (int j = 0; j < splitx.Length; j++)
                {
                    shpad += splitx[j].ToString() + "<br/>".Replace("<br/>", Environment.NewLine);
                }
                ReportList.Add(new MyExportReportNew
                {
                    ID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNo"].ToString(),
                    Shipper = dt.Rows[i]["Shipper"].ToString(),
                    ShipperAddress = shpad.ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    ConsigneeAddress = dt.Rows[i]["ConsigneeAddress"].ToString(),
                    Notify1 = dt.Rows[i]["Notify1"].ToString(),
                    Notify1Address = dt.Rows[i]["Notify1Address"].ToString(),
                    MarkNo = dt.Rows[i]["MarkNo"].ToString(),
                    NoOfPkg = dt.Rows[i]["NoOfPkg"].ToString(),
                    GrsWt = dt.Rows[i]["GrsWt"].ToString(),
                    CBM = dt.Rows[i]["CBM"].ToString(),
                    CargoDes = dt.Rows[i]["CagoDescription"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Seal = dt.Rows[i]["Seal"].ToString(),
                    FreightPayment = dt.Rows[i]["FreightPayment"].ToString(),
                    CntrDetails = dt.Rows[i]["cntrdetails"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    FRT = dt.Rows[i]["FRT"].ToString(),
                    ECRS = dt.Rows[i]["ECRS"].ToString(),
                    BAF = dt.Rows[i]["BAF"].ToString(),
                    Total = dt.Rows[i]["Total"].ToString()
                });
            }
            return ReportList;
        }
        public DataTable GetFreightManifestBLDtlsByBL(MyExportReportNew Data)
        {
            string _Query = "select NVO_BLRelease.ID,NVO_BLRelease.BLID,BLNo,BLVesVoyID, NVO_BLRelease.Shipper,ShipperAddress,Consignee,ConsigneeAddress, " +
                            " Notify1,Notify1Address,MarkNo,NoOfPkg,GrsWt,CagoDescription,  NVO_BLRelease.CBM,NVO_Containers.CntrNo,cntrdetails, " +
                            " (NVO_Containers.CntrNo + '/' + Size + '/' + SealNo) as Seal,FreightPayment, " +
                            " (select top(1) Size + '-' + Type from NVO_tblCntrTypes where ID = CntrTypeID) AS Size, " +
                            " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 1),0) as FRT, " +
                            " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 15),0) as ECRS, " +
                            " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 22),0) as BAF, " +
                            " ((isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 1),0)+isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 " +
                            " and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 15),0)))+(isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 22), 0))as Total " +
                            " from NVO_BLRelease " +
                            " inner join NVO_BOL On NVO_BOL.ID = NVO_BLRelease.BLID " +
                            " inner join NVO_BOLCntrDetails On NVO_BOLCntrDetails.BCNID = NVO_BLRelease.BLID " +
                            " inner join NVO_Containers On NVO_Containers.ID = NVO_BOLCntrDetails.CntrID " +
                            " inner join NVO_Booking On NVO_Booking.ID = NVO_BOL.BkgID " +
                            " inner join NVO_Ratesheet On NVO_Ratesheet.ID = NVO_Booking.RRID " +
                            " inner join NVO_RatesheetCntrTypes on NVO_RatesheetCntrTypes.RRID = NVO_Ratesheet.ID " +
                            " where NVO_BLRelease.BLID in (" + Data.Items + ")";
            return GetViewData(_Query, "");
        }

        public List<MyExportReportNew> FreightManifestChargeDtls(MyExportReportNew Data)
        {
            List<MyExportReportNew> ReportList = new List<MyExportReportNew>();
            DataTable dt = GetFreightManifestChargeDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyExportReportNew
                {
                    ID = Int32.Parse(dt.Rows[i]["RRID"].ToString()),
                    CntrDetails = dt.Rows[i]["cntrdetails"].ToString(),
                    FRT = dt.Rows[i]["FRT"].ToString(),
                    ECRS = dt.Rows[i]["ECRS"].ToString(),
                    BAF = dt.Rows[i]["BAF"].ToString(),

                });
            }
            return ReportList;
        }
        public DataTable GetFreightManifestChargeDtls(MyExportReportNew Data)
        {
            string _Query = "select BLID,RatesheetNo,NVO_Ratesheet.ID as RRID,cntrdetails,BLNumber, " +
                            " (select top(1) Size + '-' + Type from NVO_tblCntrTypes where ID = CntrTypeID) AS Size, " +
                            " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 1),0) as FRT, " +
                            " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 15),0) as ECRS, " +
                            " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 22),0) as BAF " +
                            " from NVO_BLRelease " +
                            " inner join NVO_BOL On NVO_BOL.ID = NVO_BLRelease.BLID " +
                            " inner join NVO_Booking On NVO_Booking.ID = NVO_BOL.BkgID " +
                            " inner join NVO_Ratesheet On NVO_Ratesheet.ID = NVO_Booking.RRID " +
                            " inner join NVO_RatesheetCntrTypes on NVO_RatesheetCntrTypes.RRID = NVO_Ratesheet.ID";
            return GetViewData(_Query, "");
        }
        #endregion

       

        #endregion Anand

        public DataTable GetViewData(string Query, string CmdType)
        {
            DbConnection con = null;
            DataTable DT = null;
            try
            {
                if (Query != "")
                {
                    con = _dbFactory.GetConnection();
                    con.Open();

                    DbCommand cmd = _dbFactory.GetCommand();
                    cmd.Connection = con;

                    if (CmdType == "SP")
                        cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = Query;
                    DbDataAdapter adapter = _dbFactory.GetAdapter();
                    adapter.SelectCommand = cmd;
                    DT = new DataTable();
                    adapter.Fill(DT);
                }
                return DT;

            }


            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        public string Getvalue(string Query)
        {
            DbConnection con = null;
            try
            {
                string Result = "";
                if (Query != "")
                {
                    con = _dbFactory.GetConnection();
                    con.Open();
                    DbCommand cmd = _dbFactory.GetCommand();
                    cmd.Connection = con;
                    cmd.CommandText = Query;
                    object objresult = cmd.ExecuteScalar();
                    if (objresult != null)
                        Result = objresult.ToString();

                }
                return Result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }
    }
}
