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
using System.Data.SqlClient;


namespace DataManager
{
    public class BkgLevelManager
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public BkgLevelManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region GetView
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
        #endregion

        #region
        List<MyBkgLevel> ListBkgLevel = new List<MyBkgLevel>();
        List<MyBookingSource> Booking = new List<MyBookingSource>();
        public List<MyBkgLevel> BkgLevelBolListViewvalues(MyBkgLevel Data)
        {
            DataTable dt = GetBkgLevelBolListViewvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBkgLevel.Add(new MyBkgLevel
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    Vessel = dt.Rows[i]["Vessel"].ToString(),
                    Voyage = dt.Rows[i]["Voyage"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLType = dt.Rows[i]["BLType"].ToString(),
                    IssueDate = dt.Rows[i]["IssueDate"].ToString(),
                    BLStatus = dt.Rows[i]["BLStatus"].ToString(),
                    Issuedby = dt.Rows[i]["Issuedby"].ToString(),

                }); ;
            }
            return ListBkgLevel;
        }
        public DataTable GetBkgLevelBolListViewvalues(MyBkgLevel Data)
        {
            string strWhere = "";

            string _Query = " select distinct BKG.ID,BKG.BookingNo,(Select top 1 VesselName from NVO_VesselMaster WHERE ID=BKG.VesselID)  AS Vessel, " +
                             " (Select top 1 VoyageNo from NVO_Voyage WHERE ID = BKG.VoyageID)  AS Voyage, NVO_BL.BLNumber," +
                              " case when BLTypeID = 12 then 'Original' else case when BLTypeID = 5 " +
                               " then 'Seaway' else case when BLTypeID = 7 then 'Surrender' end end end as BLtype, " +
                               " convert(varchar, (select top(1) BLIssueDate from NVO_BOLNew where BLID = NVO_BL.ID), 103) as IssueDate, " +
                               " case when BLStatus = 1 then 'Submitted' else 'Confirmed' end as BLStatus, 'Admin' as Issuedby " +
                               " from NVO_Booking BKG " +
                               " inner join NVO_BL on NVO_BL.BkgId = BKG.ID  left outer join NVO_BOLNew on NVO_BOLNew.BLID = NVO_BL.ID  where intStatus = 2 ";

            if (Data.SearchID == 1)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " and BKG.BookingNo like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and BKG.BookingNo like '%" + Data.SearchValue.ToString().Trim() + "%'";

            }
            if (Data.SearchID == 2)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " and NVO_BL.BLNumber like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and NVO_BL.BLNumber like '%" + Data.SearchValue.ToString().Trim() + "%'";
            }

            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere + " order by BKG.ID Desc ", "");

        }

        public List<MyBkgLevel> ExistingBookinglevelvalues(MyBkgLevel Data)
        {
            DataTable dt = GetExistingBookinglevel(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBkgLevel.Add(new MyBkgLevel
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageName"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    BkgCount = dt.Rows[i]["BkgCount"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    BOLStatusOpenCount = dt.Rows[i]["BOLStatusOpenCount"].ToString(),
                    BOLStatusCompleteCount = dt.Rows[i]["BOLStatusCompleteCount"].ToString(),
                    PickOpen = dt.Rows[i]["PickOpen"].ToString(),
                    PickComp = dt.Rows[i]["PickComp"].ToString(),
                    GateOpen = dt.Rows[i]["GateOpen"].ToString(),
                    GateComp = dt.Rows[i]["GateComp"].ToString(),
                    DocOpen = dt.Rows[i]["DocOpen"].ToString(),
                    DocComp = dt.Rows[i]["DocComp"].ToString(),
                    BLDOpen = dt.Rows[i]["BLDOpen"].ToString(),
                    BLDComp = dt.Rows[i]["BLDComp"].ToString(),
                    BLROpen = dt.Rows[i]["BLROpen"].ToString(),
                    BLRComp = dt.Rows[i]["BLRComp"].ToString(),
                    InvoiceOpen = dt.Rows[i]["InvoiceOpen"].ToString(),
                    InvoiceComp = dt.Rows[i]["InvoiceComp"].ToString(),

                }); ;
            }
            return ListBkgLevel;
        }
        public DataTable GetExistingBookinglevel(MyBkgLevel Data)
        {
            string strWhere = "";

            string _Query = "select distinct BKG.VesselID as ID,BKG.VoyageID,(SELECT TOP 1 VesselName FROM NVO_VesselMaster where ID=BKG.VesselID) As VesselName, " +
                           "  (SELECT TOP 1 VoyageNo FROM NVO_Voyage where ID = BKG.VoyageID) as VoyageName, convert(varchar,(SELECT TOP 1 ETD FROM NVO_Voyage where ID=BKG.VoyageID),105) as ETD, " +
                           " Count(BKG.ID) As BkgCount, (select count(distinct ContainerID) from NVO_ContainerTxns inner join NVO_Booking B on B.ID " +
                           " = NVO_ContainerTxns.BLNumber and NVO_ContainerTxns.StatusCodeID !=5  and BKG.VesselID = B.VesselID AND   BKG.VoyageID = B.VoyageID) as PickOpen, " +
                           " (select count(distinct ContainerID) from NVO_ContainerTxns inner join NVO_Booking B on B.ID = NVO_ContainerTxns.BLNumber and NVO_ContainerTxns.StatusCodeID =5 " +
                           "  and BKG.VesselID = B.VesselID AND   BKG.VoyageID = B.VoyageID) as PickComp, " +
                           " (select count(distinct ContainerID) from NVO_ContainerTxns inner join NVO_Booking B on B.ID = NVO_ContainerTxns.BLNumber and " +
                           " NVO_ContainerTxns.StatusCodeID !=9  and BKG.VesselID = B.VesselID AND   BKG.VoyageID = B.VoyageID) as GateOpen," +
                           "  (select count(distinct ContainerID) from NVO_ContainerTxns inner join NVO_Booking B on B.ID = NVO_ContainerTxns.BLNumber " +
                           " and NVO_ContainerTxns.StatusCodeID =9  and BKG.VesselID = B.VesselID AND   BKG.VoyageID = B.VoyageID) as GateComp, 0 as DocOpen, 0 as DocComp, " +
                           //" ISNULL((select COUNT (BC.CntrID) from NVO_BLCargo BC WHERE BC.BkgID =BKG.ID and BC.HazarOpt =2 and (select A.CntrID FROM NVO_BkgDocAttachments A WHERE A.BkgID=BKG.ID)!=BC.CntrID) + " +
                           //" (select COUNT (BC.CntrID) from NVO_BLCargo BC  WHERE BC.BkgID =BKG.ID and BC.DoorOpenOPT =2 and (select A.CntrID FROM NVO_BkgDocAttachments A WHERE A.BkgID=BKG.ID)!=BC.CntrID ) + " +
                           //" (select COUNT (BC.CntrID) from NVO_BLCargo BC  WHERE BC.BkgID =BKG.ID and BC.OOGOpt =2 and (select A.CntrID FROM NVO_BkgDocAttachments A WHERE A.BkgID=BKG.ID)!=BC.CntrID ) + " +
                           //" (select COUNT (BC.CntrID) from NVO_BLCargo BC WHERE BC.BkgID =BKG.ID and BC.RefferOpt =2 and (select A.CntrID FROM NVO_BkgDocAttachments A WHERE A.BkgID=BKG.ID)!=BC.CntrID),0) AS DocOpen," +
                           //" ISNULL((select COUNT ( A.CntrID) from NVO_BLCargo BC INNER  join NVO_BkgDocAttachments A on A.BkgID=BC.BkgID WHERE BC.BkgID =BKG.ID and BC.HazarOpt =2) + " +
                           //" (select COUNT (A.CntrID) from NVO_BLCargo BC INNER join NVO_BkgDocAttachments A on A.BkgID=BC.BkgID WHERE BC.BkgID =BKG.ID and BC.DoorOpenOPT =2) + " +
                           //" (select COUNT (A.CntrID) from NVO_BLCargo BC INNER join NVO_BkgDocAttachments A on A.BkgID=BC.BkgID WHERE BC.BkgID =BKG.ID and BC.OOGOpt =2) + " +
                           //" (select COUNT (A.CntrID) from NVO_BLCargo BC INNER join NVO_BkgDocAttachments A on A.BkgID=BC.BkgID WHERE BC.BkgID =BKG.ID and BC.RefferOpt =2),0) AS DocComp," +
                           " 0 as BLDOpen, 0 as BLDComp, 0 as BLROpen, 0 as BLRComp, 0 as InvoiceOpen, 0 as InvoiceComp, " +
                           " (select count(NVO_BOLNew.ID) from NVO_BOLNew inner join NVO_Booking B on B.ID = NVO_BOLNew.BkgID where NVO_BOLNew.BkgID = B.ID and NVO_BOLNew.BLStatus =1 and BKG.VesselID = B.VesselID AND   BKG.VoyageID = B.VoyageID) as BOLStatusOpenCount, " +
                           "(select count(NVO_BOLNew.ID) from NVO_BOLNew inner join NVO_Booking B on B.ID = NVO_BOLNew.BkgID where NVO_BOLNew.BkgID = B.ID and NVO_BOLNew.BLStatus =2 and BKG.VesselID = B.VesselID AND   BKG.VoyageID = B.VoyageID) as BOLStatusCompleteCount, " +
                           " (select count(distinct ContainerID) from NVO_ContainerTxns inner join NVO_Booking B on B.ID = NVO_ContainerTxns.BLNumber where BKG.VesselID = B.VesselID AND   BKG.VoyageID = B.VoyageID) as CntrCount from NVO_Booking BKG where BKG.intStatus=2  ";


            if (Data.SearchID == 1)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " and BKG.BookingNo like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and BKG.BookingNo like '%" + Data.SearchValue.ToString().Trim() + "%'";

            }
            if (Data.SearchID == 2)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " and (SELECT TOP 1 VoyageNo FROM NVO_Voyage where ID = BKG.VoyageID) like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and (SELECT TOP 1 VoyageNo FROM NVO_Voyage where ID = BKG.VoyageID) like '%" + Data.SearchValue.ToString().Trim() + "%'";

            }
            if (Data.SearchID == 3)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " and (select top(1) BLNumber from NVO_BL where BkgID = BKG.ID and BLNumber  like '%" + Data.SearchValue.ToString().Trim() + "%') like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and (select top(1) BLNumber from NVO_BL where BkgID = BKG.ID and BLNumber  like '%" + Data.SearchValue.ToString().Trim() + "%') like '%" + Data.SearchValue.ToString().Trim() + "%'";

            }
            if (Data.SearchID == 4)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " and (select top(1) CntrNo from NVO_BLCargo where NVO_BLCargo.BkgID=BKG.ID and CntrNo like '%" + Data.SearchValue.ToString().Trim() + "%') like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and (select top(1) CntrNo from NVO_BLCargo where NVO_BLCargo.BkgID=BKG.ID and CntrNo like '%" + Data.SearchValue.ToString().Trim() + "%') like '%" + Data.SearchValue.ToString().Trim() + "%'";

            }

            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere + " Group By BKG.ID,BKG.VesselID,BKG.VoyageID ", "");



        }

        public List<MyBkgLevel> BkgLevelTaskSearchViewvalues(MyBkgLevel Data)
        {
            DataTable dt = GetBkgLevelTaskSearchViewvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBkgLevel.Add(new MyBkgLevel
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLNumberv = dt.Rows[i]["BLNumberN"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    BkgParty = dt.Rows[i]["BkgParty"].ToString(),
                    BkgPartyV = dt.Rows[i]["BkgPartyN"].ToString(),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageName"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["Destination"].ToString(),
                    Sailed = dt.Rows[i]["Sailed"].ToString(),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),

                });
            }
            return ListBkgLevel;
        }
        public DataTable GetBkgLevelTaskSearchViewvalues(MyBkgLevel Data)
        {
            string strWhere = "";

            string _Query = "SELECT Left(BkgParty,15) as BkgPartyN,Left(BLNumber,19) as BLNumberN,* FROM NVO_View_BookingLevelTaskSearch ";

            if (Data.OfficeCode.ToString() != "0" && Data.OfficeCode.ToString() != null)
                if (strWhere == "")
                    strWhere += _Query + " where OfficeCode = " + Data.OfficeCode;
                else
                    strWhere += " and OfficeCode = " + Data.OfficeCode;

            if (Data.ID.ToString() != "" && Data.ID.ToString() != null && Data.ID.ToString() != "0" && Data.ID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE VesselID =" + Data.ID.ToString() + "";
                else
                    strWhere += " and VesselID =" + Data.ID.ToString() + "";

            if (Data.CustomerID != "" && Data.CustomerID != null && Data.CustomerID != "0" && Data.CustomerID != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE CustomerID =" + Data.CustomerID + "";
                else
                    strWhere += " and CustomerID =" + Data.CustomerID + "";

            if (Data.BookingID.ToString() != "" && Data.BookingID.ToString() != null && Data.BookingID.ToString() != "0" && Data.BookingID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE ID =" + Data.BookingID.ToString() + "";
                else
                    strWhere += " and ID =" + Data.BookingID.ToString() + "";

            if (Data.BLID.ToString() != "" && Data.BLID.ToString() != null && Data.BLID.ToString() != "0" && Data.BLID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE (select top(1) ID  from NVO_BL where NVO_BL.BkgID = NVO_View_BookingLevelTaskSearch.ID and NVO_BL.ID = " + Data.BLID.ToString() + " ) = " + Data.BLID.ToString();
                else
                    strWhere += " and (select top(1) ID  from NVO_BL where NVO_BL.BkgID = NVO_View_BookingLevelTaskSearch.ID and NVO_BL.ID = " + Data.BLID.ToString() + " ) = " + Data.BLID.ToString();

            if (Data.CntrID.ToString() != "" && Data.CntrID.ToString() != null && Data.CntrID.ToString() != "0" && Data.CntrID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE (select top(1) CntrID  from NVO_BLCargo where NVO_BLCargo.BkgID = NVO_View_BookingLevelTaskSearch.ID and NVO_BLCargo.CntrID = " + Data.CntrID.ToString() + " ) = " + Data.CntrID.ToString();
                else
                    strWhere += " and (select top(1) CntrID  from NVO_BLCargo where NVO_BLCargo.BkgID = NVO_View_BookingLevelTaskSearch.ID and NVO_BLCargo.CntrID = " + Data.CntrID.ToString() + " ) = " + Data.CntrID.ToString();



            if (Data.VoyageID.ToString() != "" && Data.VoyageID.ToString() != null && Data.VoyageID.ToString() != "0" && Data.VoyageID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE VoyageID =" + Data.VoyageID + "";
                else
                    strWhere += " and VoyageID =" + Data.VoyageID + "";

            if (Data.LoadPortID.ToString() != "" && Data.LoadPortID.ToString() != null && Data.LoadPortID.ToString() != "0" && Data.LoadPortID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE LoadPortID =" + Data.LoadPortID.ToString() + "";
                else
                    strWhere += " and LoadPortID =" + Data.LoadPortID.ToString() + "";

            if (Data.DestinationID.ToString() != "" && Data.DestinationID.ToString() != null && Data.DestinationID.ToString() != "0" && Data.DestinationID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE DestinationID =" + Data.DestinationID.ToString() + "";
                else
                    strWhere += " and DestinationID =" + Data.DestinationID.ToString() + "";

            if (Data.SalesPersonID.ToString() != "" && Data.SalesPersonID.ToString() != null && Data.SalesPersonID.ToString() != "0" && Data.SalesPersonID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " WHERE SalesPersonID =" + Data.SalesPersonID.ToString() + "";
                else
                    strWhere += " and SalesPersonID =" + Data.SalesPersonID.ToString() + "";

            if (Data.ETDFrom != "" && Data.ETDFrom != null)
                if (strWhere == "")
                    strWhere += _Query + " where ETDv >= '" + DateTime.Parse(Data.ETDFrom).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and ETDv >= '" + DateTime.Parse(Data.ETDFrom).ToString("MM/dd/yyyy") + "'";

            if (Data.ETDTo != "" && Data.ETDTo != null)
                if (strWhere == "")
                    strWhere += _Query + " where ETDv <= '" + DateTime.Parse(Data.ETDTo).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and ETDv <= '" + DateTime.Parse(Data.ETDTo).ToString("MM/dd/yyyy") + "'";

            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere + " order by ID desc ", "");



        }

        public List<MyBkgLevel> BindBookingNoListvalues(MyBkgLevel Data)
        {
            DataTable dt = GetBindBookingNoListvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBkgLevel.Add(new MyBkgLevel
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),


                });
            }
            return ListBkgLevel;
        }
        public DataTable GetBindBookingNoListvalues(MyBkgLevel Data)
        {
            string _Query = "select * from NVO_Booking WHERE intStatus = 2 ";
            return GetViewData(_Query, "");

        }

        public List<MyBkgLevel> BindBLNoListvalues(MyBkgLevel Data)
        {
            DataTable dt = GETBindBLNoListvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBkgLevel.Add(new MyBkgLevel
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),


                });
            }
            return ListBkgLevel;
        }
        public DataTable GETBindBLNoListvalues(MyBkgLevel Data)
        {
            string _Query = "select * from NVO_BL ";
            return GetViewData(_Query, "");

        }

        public List<MyBkgLevel> BindBkgPartyListvalues(MyBkgLevel Data)
        {
            DataTable dt = GETBindBkgPartyListvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBkgLevel.Add(new MyBkgLevel
                {
                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    BkgParty = dt.Rows[i]["CustomerName"].ToString(),


                });
            }
            return ListBkgLevel;
        }
        public DataTable GETBindBkgPartyListvalues(MyBkgLevel Data)
        {
            string _Query = "select * from NVO_view_CustomerDetails ";
            return GetViewData(_Query, "");

        }
        public List<MyBkgLevel> BindVesselVoyListvalues(MyBkgLevel Data)
        {
            DataTable dt = GETBindVesselVoyListvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBkgLevel.Add(new MyBkgLevel
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VoyageName = dt.Rows[i]["VoyageName"].ToString(),


                });
            }
            return ListBkgLevel;
        }
        public DataTable GETBindVesselVoyListvalues(MyBkgLevel Data)
        {
            string _Query = "Select ID,((select top 1 VesselName  from NVO_VesselMaster where ID=NVO_Voyage.VesselID) +'-'+ (VoyageNo)) AS VoyageName  from NVO_Voyage ";
            return GetViewData(_Query, "");

        }
        public List<MyBkgLevel> BindCntrNosListvalues(MyBkgLevel Data)
        {
            DataTable dt = GETBindCntrNosListvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBkgLevel.Add(new MyBkgLevel
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),


                });
            }
            return ListBkgLevel;
        }
        public DataTable GETBindCntrNosListvalues(MyBkgLevel Data)
        {
            string _Query = "Select *  from NVO_Containers";
            return GetViewData(_Query, "");

        }

        public List<MyBkgLevel> BindUserDetailsvalues(MyBkgLevel Data)
        {
            DataTable dt = GETBindUserDetailsvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListBkgLevel.Add(new MyBkgLevel
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserName = dt.Rows[i]["UserName"].ToString(),


                });
            }
            return ListBkgLevel;
        }
        public DataTable GETBindUserDetailsvalues(MyBkgLevel Data)
        {
            string _Query = "Select *  from NVO_UserDetails";
            return GetViewData(_Query, "");

        }

        #endregion

        #region BkgdOCS
        List<MyBkgDocs> ListDocS = new List<MyBkgDocs>();
        public List<BkgDocsList> ViewDocsHazlistvalues(BkgDocsList Data)
        {
            List<BkgDocsList> ListbkgS = new List<BkgDocsList>();


            BkgDocsList bkgls = new BkgDocsList();
            List<BkgItemList> item1 = new List<BkgItemList>();

            DataTable dt = GETViewDocsHazlistvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var item = new BkgItemList();

                item.CntrType = dt.Rows[i]["CntrType"].ToString();
                item.CntrNo = dt.Rows[i]["CntrNo"].ToString();
                item.CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString());
                item.BLID = 0;
                item.BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString());
                item.ChkFlag = Int32.Parse(dt.Rows[i]["ChkFlag"].ToString());
                item.DocsType = dt.Rows[i]["DocsType"].ToString();
                var DocType = 0;
                if (dt.Rows[i]["DocsType"].ToString() == "HAZ")
                {
                    DocType = 1;
                }
                if (dt.Rows[i]["DocsType"].ToString() == "OOG")
                {
                    DocType = 2;

                }
                if (dt.Rows[i]["DocsType"].ToString() == "REEFER")
                {
                    DocType = 3;
                }
                if (dt.Rows[i]["DocsType"].ToString() == "ODO")
                {
                    DocType = 3;
                }
                item.DocsTypeID = Int32.Parse(DocType.ToString());
                DataTable dtx = GetAttachment(dt.Rows[i]["CntrID"].ToString(), dt.Rows[i]["BkgID"].ToString(), DocType.ToString());
                List<BkgAttachList> lat = new List<BkgAttachList>();
                List<BkgItemList> addlist = new List<BkgItemList>();

                for (int y = 0; y < dtx.Rows.Count; y++)
                {
                    var attrib = new BkgAttachList();
                    attrib.AttachFile = dtx.Rows[y]["AttachFileV"].ToString();
                    attrib.AttachID = Int32.Parse(dtx.Rows[y]["ID"].ToString());
                    attrib.FileName = dtx.Rows[y]["AttachFile"].ToString();
                    lat.Add(attrib);

                }




                item.BkgAttachList = lat;
                addlist.Add(item);


                item1.Add(item);
                bkgls.BkgItemList = item1;
            }
            ListbkgS.Add(bkgls);
            return ListbkgS;
        }




        public DataTable GETViewDocsHazlistvalues(BkgDocsList Data)
        {
            string _Query = " select BkgID,CntrID,CntrNO,CntrType,DocsType,FileName,AttachFile,ChkFlag  from ( select BkgID,CntrID,CntrNO,CntrType,DocsType,NVO_DocsColumn.SEQNO,0 AS ChkFlag," +
                " isnull((select top 1 FileName from NVO_BkgDocAttachments where CntrID = BLC.CntrID and DocType=1),'') As FileName , isnull((select top 1 AttachFile from NVO_BkgDocAttachments where CntrID = BLC.CntrID and DocType = 1),'NA') As AttachFile " +
                "  from NVO_DocsColumn INNER JOIN NVO_BLCargo BLC ON BLC.HazarOpt = NVO_DocsColumn.DocsTypeID AND NVO_DocsColumn.SEQNO = 1 WHERE BLC.BkgID =" + Data.ID + " AND HazarOpt = 2 " +

            " UNION " +
             " select BkgID,CntrID,CntrNO,CntrType,DocsType,NVO_DocsColumn.SEQNO,0 AS ChkFlag," +
             " isnull((select top 1 FileName from NVO_BkgDocAttachments where CntrID = BLC.CntrID and DocType = 2),'') As FileName, isnull((select top 1 AttachFile from NVO_BkgDocAttachments where CntrID = BLC.CntrID and DocType = 2),'NA') As AttachFile " +
             "  from NVO_DocsColumn INNER JOIN NVO_BLCargo BLC ON BLC.OOGOpt = NVO_DocsColumn.DocsTypeID AND NVO_DocsColumn.SEQNO = 2 WHERE BLC.BkgID =" + Data.ID + " AND OOGOpt = 2 " +

            " UNION " +
             " select BkgID,CntrID,CntrNO,CntrType,DocsType,NVO_DocsColumn.SEQNO,0 AS ChkFlag," +
               " isnull((select top 1 FileName from NVO_BkgDocAttachments where CntrID = BLC.CntrID and DocType =3),'') As FileName, isnull((select top 1 AttachFile from NVO_BkgDocAttachments where CntrID = BLC.CntrID and DocType = 3),'NA') As AttachFile " +
             "  from NVO_DocsColumn INNER JOIN NVO_BLCargo BLC ON BLC.RefferOpt = NVO_DocsColumn.DocsTypeID AND NVO_DocsColumn.SEQNO = 3 WHERE BLC.BkgID =" + Data.ID + "  AND BLC.RefferOpt = 2 " +
             " UNION " +
           " select BkgID,CntrID,CntrNO,CntrType,DocsType,NVO_DocsColumn.SEQNO,0 AS ChkFlag," +
            " isnull((select top 1 FileName from NVO_BkgDocAttachments where CntrID = BLC.CntrID and DocType =4),'') As FileName, isnull((select top 1 AttachFile from NVO_BkgDocAttachments where CntrID = BLC.CntrID and DocType = 4),'NA') As AttachFile " +
           "  from NVO_DocsColumn INNER JOIN NVO_BLCargo BLC ON BLC.DoorOpenOPT = NVO_DocsColumn.DocsTypeID AND NVO_DocsColumn.SEQNO = 4 WHERE BLC.BkgID =" + Data.ID + "  AND DoorOpenOPT = 2) dt order by DocsType ";
            return GetViewData(_Query, "");

        }


        public DataTable GetAttachment(string CntrID, string BkgID, string DocType)
        {

            string _Query = "Select ID,Left(isnull(AttachFile,'NA'),20)as AttachFileV,AttachFile  FROM NVO_BkgDocAttachments WHERE BkgID = " + BkgID + " AND CntrID=" + CntrID + " AND  DocType=" + DocType;
            return GetViewData(_Query, "");

        }

        public List<MyBkgDocs> InsertBkgDocSave(MyBkgDocs Data)
        {


            DbConnection con = null;
            DbTransaction trans;


            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    if (Data.Items != null)
                    {
                        string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                            //Cmd.CommandText = " IF((select count(*) from NVO_BkgDocAttachments where DocType=@DocType and CntrID=@CntrID and BkgID=@BkgID)<=0) " +
                            //" BEGIN " +
                            Cmd.CommandText = " INSERT INTO  NVO_BkgDocAttachments(DocType,CntrID,BkgID,BLID,AttachFile,UploadedOn,UploadedBy) " +
                            " values(@DocType,@CntrID,@BkgID,@BLID,@AttachFile,@UploadedOn,@UploadedBy)  ";

                            //" END  " +
                            //" ELSE " +
                            //" UPDATE NVO_BkgDocAttachments SET DocType=@DocType,CntrID=@CntrID,AttachFile=@AttachFile,BkgID=@BkgID,BLID=@BLID,UploadedOn=@UploadedOn,UploadedBy=@UploadedBy where DocType=@DocType and CntrID=@CntrID and BkgID=@BkgID ";

                            // Cmd.CommandText = " INSERT INTO  NVO_BkgDocMultiAttachments(DocsAttachID,FileName) " +
                            //" values(@DocsAttachID,@FileName)  ";


                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DocType", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[1]));
                            // Cmd.Parameters.Add(_dbFactory.GetParameter("@FileName", Data.AttachFile));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachFile", Data.AttachFile));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedOn", System.DateTime.Now));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedBy", 1));


                            int result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();


                        }
                    }

                    trans.Commit();
                    ListDocS.Add(new MyBkgDocs
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListDocS;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListDocS.Add(new MyBkgDocs
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListDocS;
                }

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

        public List<MyBkgDocs> ViewDocsOOGlistvalues(MyBkgDocs Data)
        {
            DataTable dt = GETViewDocsOOGlistvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListDocS.Add(new MyBkgDocs
                {
                    CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    Width = dt.Rows[i]["Width"].ToString(),
                    Length = dt.Rows[i]["Lenght"].ToString(),
                    Height = dt.Rows[i]["Height"].ToString(),
                    LoadingPhotos = dt.Rows[i]["LoadingPhotos"].ToString(),
                    Survey = dt.Rows[i]["Survey"].ToString(),
                    ChkFlag = Int32.Parse(dt.Rows[i]["ChkFlag"].ToString()),

                });
            }
            return ListDocS;
        }
        public DataTable GETViewDocsOOGlistvalues(MyBkgDocs Data)
        {
            string _Query = "Select CntrID,BLID,BkgID,0 AS ChkFlag,Width,Height,Lenght,NVO_Containers.CntrNo, (select top 1 Type from NVO_tblCntrTypes where ID = NVO_BLCargo.CntrID) As CntrType, (select top 1 AttachFile from NVO_BkgDocAttachments where CntrID = NVO_BLCargo.CntrID and DocType=2 AND OOGUploadType=1) As LoadingPhotos, (select top 1 AttachFile from NVO_BkgDocAttachments where CntrID = NVO_BLCargo.CntrID and DocType = 2 AND OOGUploadType = 2) As Survey  from NVO_BLCargo INNER jOIN NVO_Containers ON NVO_Containers.ID = NVO_BLCargo.CntrID WHERE OOGOpt = 1 and BkgID = " + Data.ID;
            return GetViewData(_Query, "");

        }

        public List<MyBkgDocs> InsertBkgDocOOGSave(MyBkgDocs Data)
        {


            DbConnection con = null;
            DbTransaction trans;


            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    if (Data.Items != null)
                    {
                        string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_BkgDocAttachments where OOGUploadType=@OOGUploadType and DocType=@DocType and CntrID=@CntrID and BkgID=@BkgID)<=0) " +
                             " BEGIN " +
                             " INSERT INTO  NVO_BkgDocAttachments(DocType,CntrID,OOGUploadType,AttachFile,BkgID,BLID,UploadedOn,UploadedBy) " +
                             " values(@DocType,@CntrID,@OOGUploadType,@AttachFile,@BkgID,@BLID,@UploadedOn,@UploadedBy)  " +
                             " END  " +
                             " ELSE " +
                             " UPDATE NVO_BkgDocAttachments SET DocType=@DocType,CntrID=@CntrID,OOGUploadType=@OOGUploadType,AttachFile=@AttachFile,BkgID=@BkgID,BLID=@BLID,UploadedOn=@UploadedOn,UploadedBy=@UploadedBy where OOGUploadType=@OOGUploadType and CntrID=@CntrID and BkgID=@BkgID and DocType=@DocType ";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DocType", 2));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@OOGUploadType", Data.AttachType));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachFile", Data.AttachFile));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedOn", System.DateTime.Now));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedBy", 1));


                            int result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    trans.Commit();
                    ListDocS.Add(new MyBkgDocs
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListDocS;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListDocS.Add(new MyBkgDocs
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListDocS;
                }

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


        public List<MyBkgDocs> ViewDocsReeferlistvalues(MyBkgDocs Data)
        {
            DataTable dt = GETViewDocsReeferlistvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListDocS.Add(new MyBkgDocs
                {
                    CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    Ventilation = dt.Rows[i]["Ventilation"].ToString(),
                    Temperature = dt.Rows[i]["Temperature"].ToString(),
                    Humidity = dt.Rows[i]["Humidity"].ToString(),

                });
            }
            return ListDocS;
        }
        public DataTable GETViewDocsReeferlistvalues(MyBkgDocs Data)
        {
            string _Query = "Select CntrID,BLID,BkgID,NVO_Containers.CntrNo,Ventilation,Temperature,Humidity, (select top 1 Type from NVO_tblCntrTypes where ID = NVO_BLCargo.CntrID) As CntrType from NVO_BLCargo INNER jOIN NVO_Containers ON NVO_Containers.ID = NVO_BLCargo.CntrID WHERE refferOpt = 1 and BkgID = " + Data.ID;
            return GetViewData(_Query, "");

        }

        public List<MyBkgDocs> ViewDocsOdolistvalues(MyBkgDocs Data)
        {
            DataTable dt = GETViewDocsOdolistvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListDocS.Add(new MyBkgDocs
                {
                    CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    FileName = dt.Rows[i]["FileName"].ToString(),
                    ChkFlag = Int32.Parse(dt.Rows[i]["ChkFlag"].ToString()),

                });
            }
            return ListDocS;
        }
        public DataTable GETViewDocsOdolistvalues(MyBkgDocs Data)
        {
            string _Query = "Select CntrID,BLID,BkgID,0 AS ChkFlag,NVO_Containers.CntrNo, (select top 1 Type from NVO_tblCntrTypes where ID = NVO_BLCargo.CntrID) As CntrType, (select top 1 FileName from NVO_BkgDocAttachments where CntrID = NVO_BLCargo.CntrID and DocType=4) As FileName from NVO_BLCargo INNER jOIN NVO_Containers ON NVO_Containers.ID = NVO_BLCargo.CntrID WHERE DoorOpenOPT = 1 and BkgID = " + Data.ID;
            return GetViewData(_Query, "");

        }
        public List<MyBkgDocs> InsertBkgDocODOSave(MyBkgDocs Data)
        {


            DbConnection con = null;
            DbTransaction trans;


            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    if (Data.Items != null)
                    {
                        string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_BkgDocAttachments where DocType=@DocType and CntrID=@CntrID and BkgID=@BkgID)<=0) " +
                             " BEGIN " +
                             " INSERT INTO  NVO_BkgDocAttachments(DocType,CntrID,FileName,AttachFile,BkgID,BLID,UploadedOn,UploadedBy) " +
                             " values(@DocType,@CntrID,@FileName,@AttachFile,@BkgID,@BLID,@UploadedOn,@UploadedBy)  " +
                             " END  " +
                             " ELSE " +
                             " UPDATE NVO_BkgDocAttachments SET DocType=@DocType,CntrID=@CntrID,FileName=@FileName,AttachFile=@AttachFile,BkgID=@BkgID,BLID=@BLID,UploadedOn=@UploadedOn,UploadedBy=@UploadedBy where DocType=@DocType and CntrID=@CntrID and BkgID=@BkgID ";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DocType", 4));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@FileName", Data.FileName));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachFile", Data.AttachFile));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedOn", System.DateTime.Now));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedBy", 1));


                            int result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    trans.Commit();
                    ListDocS.Add(new MyBkgDocs
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListDocS;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListDocS.Add(new MyBkgDocs
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListDocS;
                }

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

        public List<MyBkgDocs> ViewDocsHazAttachlistvalues(MyBkgDocs Data)
        {
            DataTable dt = GETViewDocsHazAttachlistvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListDocS.Add(new MyBkgDocs
                {

                    FileName = dt.Rows[i]["FileName"].ToString(),
                    AttachFile = dt.Rows[i]["AttachFile"].ToString(),


                });
            }
            return ListDocS;
        }
        public DataTable GETViewDocsHazAttachlistvalues(MyBkgDocs Data)
        {
            string _Query = "select Distinct FileName,AttachFile from NVO_BkgDocAttachments where BkgID = " + Data.ID + " AND DocType = 1";
            return GetViewData(_Query, "");

        }

        public List<MyBkgDocs> ViewDocsOOGAttachlistvalues(MyBkgDocs Data)
        {
            DataTable dt = GETViewDocsOOGAttachlistvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListDocS.Add(new MyBkgDocs
                {

                    FileName = dt.Rows[i]["FileName"].ToString(),
                    AttachFile = dt.Rows[i]["AttachFile"].ToString(),


                });
            }
            return ListDocS;
        }
        public DataTable GETViewDocsOOGAttachlistvalues(MyBkgDocs Data)
        {
            string _Query = "select Distinct AttachFile,case when OOGUploadType=1 then 'LOADING PHOTOS'  when OOGUploadType=2  then 'SUREVEY REPORT'  end as FileName from NVO_BkgDocAttachments where BkgID = " + Data.ID + " AND DocType = 2";
            return GetViewData(_Query, "");

        }
        public List<MyBkgDocs> ViewDocsODOAttachlistvalues(MyBkgDocs Data)
        {
            DataTable dt = GETViewDocsODOAttachlistvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListDocS.Add(new MyBkgDocs
                {

                    FileName = dt.Rows[i]["FileName"].ToString(),
                    AttachFile = dt.Rows[i]["AttachFile"].ToString(),


                });
            }
            return ListDocS;
        }
        public DataTable GETViewDocsODOAttachlistvalues(MyBkgDocs Data)
        {
            string _Query = "select Distinct AttachFile,FileName from NVO_BkgDocAttachments where BkgID = " + Data.ID + " AND DocType = 4";
            return GetViewData(_Query, "");

        }

        public List<MyBkgDocs> DocsAttachDeleteMaster(MyBkgDocs Data)
        {

            int r1 = 0;
            int r2 = 0;
            DbConnection con = null;
            DbTransaction trans;


            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = "Delete from NVO_BkgDocAttachments where BkgID=" + Data.BkgID + " AND CntrID=" + Data.CntrID + " and DocType=" + Data.DocsType;
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListDocS.Add(new MyBkgDocs
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Deleted Successfully"
                    });
                    return ListDocS;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListDocS.Add(new MyBkgDocs
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListDocS;
                }
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

        #endregion

    }
}
