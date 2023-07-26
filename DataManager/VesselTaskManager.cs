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
using System.Collections;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Asn1.X509;
using static iTextSharp.text.pdf.PdfDocument;
using Org.BouncyCastle.Utilities;
using System.ComponentModel;
using System.Reflection;

namespace DataManager
{
    public class VesselTaskManager
    {
        List<myVesselTask1> ListVesselTask = new List<myVesselTask1>();
        List<MyVesselLoadCnfrm> ListVesselCnFrm = new List<MyVesselLoadCnfrm>();
        List<MyVesselLoadCnfrm> ListVesselCnFrm1 = new List<MyVesselLoadCnfrm>();
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public VesselTaskManager()
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



        List<MyVesselTask> ListvslLevel = new List<MyVesselTask>();

        public List<MyVesselTask> BindVesselListvalues(MyVesselTask Data)
        {
            DataTable dt = GetBindVesselListvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {

                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    VoyageName = dt.Rows[i]["VoyageName"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    BLCount = dt.Rows[i]["BLCount"].ToString(),
                    VesselName = dt.Rows[i]["VessleName"].ToString(),
                    ETD = dt.Rows[i]["ETDDate"].ToString(),
                    LoadNos = dt.Rows[i]["LoadNos"].ToString(),
                    LoadDraft = dt.Rows[i]["LoadDraft"].ToString(),
                    LoadFinal = dt.Rows[i]["LoadFinal"].ToString(),
                    AlertNos = dt.Rows[i]["AlertNos"].ToString(),
                    AlertDraft = dt.Rows[i]["AlertDraft"].ToString(),
                    AlertFinal = dt.Rows[i]["AlertFinal"].ToString(),
                    LCNos = dt.Rows[i]["LCNos"].ToString(),
                    LCDraft = dt.Rows[i]["LCDraft"].ToString(),
                    LCFinal = dt.Rows[i]["LCFinal"].ToString(),
                    OnboardNos = dt.Rows[i]["OnboardNos"].ToString(),
                    OnboardDraft = dt.Rows[i]["OnboardDraft"].ToString(),
                    OnboardFinal = dt.Rows[i]["OnboardFinal"].ToString(),
                    TDRNos = dt.Rows[i]["TDRNos"].ToString(),
                    TDRDraft = dt.Rows[i]["TDRDraft"].ToString(),
                    TDRFinal = dt.Rows[i]["TDRFinal"].ToString(),

                });
            }
            return ListvslLevel;
        }
        public DataTable GetBindVesselListvalues(MyVesselTask Data)
        {

            string strWhere = "";
            //string _Query = "select NVO_Booking.ID,VesselID,VoyageID, (select top(1) VesselName from NVO_VesselMaster where ID= NVO_Booking.VesselID) as VesselName," +
            //    " (select top(1) VoyageNo from NVO_Voyage where ID= NVO_Booking.VesselID) as VoyageName, " +
            //    "(select count(CntrID) from NVO_BLContainer where BkgID = NVO_Booking.ID and BLID = NVO_BL.ID) as CntrCount, " +
            //    "(select count(BLID) from NVO_BLContainer where BkgID = NVO_Booking.ID and BLID = NVO_BL.ID) as BLCount, " +
            //    "convert(varchar,(select TOP 1 ETD from NVO_Voyage where ID = NVO_Booking.VoyageID),105) as ETD from NVO_Booking " +
            //    "inner join NVO_BL on NVO_BL.BkgID = NVO_Booking.ID where intStatus = 2";

            string _Query = " select distinct VesselID,VoyageID,VessleName,VoyageName,ETDDate,sum(BLCount) as BLCount, " +
                "sum(CntrCount) CntrCount, sum(AlertNos) as AlertNos,sum(AlertDraft) as AlertDraft,sum(AlertFinal) as AlertFinal, " +
                "sum(LCNos) as LCNos,sum(LCDraft) as LCDraft,sum(LCFinal) as LCFinal, " +
                "sum(TDRNos) as TDRNos,sum(TDRDraft) as TDRDraft,sum(TDRFinal) as TDRFinal, " +
                "sum(LoadNos) as LoadNos,sum(LoadDraft) as LoadDraft,sum(LoadFinal) as LoadFinal, " +
                "sum(OnboardNos) as OnboardNos,sum(OnboardDraft) as OnboardDraft,sum(OnboardFinal) as OnboardFinal " +
                "from NVO_View_VesselTaskBookingCount VsCount ";

            if (Data.SearchID == 1)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " where BookingNo like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and BookingNo like '%" + Data.SearchValue.ToString().Trim() + "%'";

            }
            if (Data.SearchID == 2)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " where VoyageName like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and VoyageName like '%" + Data.SearchValue.ToString().Trim() + "%'";

            }
            if (Data.SearchID == 3)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " where (select top(1) BLNumber from NVO_BL where BkgID = NVO_View_VesselTaskBookingCount.BkgId and BLNumber  like '%" + Data.SearchValue.ToString().Trim() + "%') like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and (select top(1) BLNumber from NVO_BL where BkgID = NVO_View_VesselTaskBookingCount.BkgId and BLNumber  like '%" + Data.SearchValue.ToString().Trim() + "%') like '%" + Data.SearchValue.ToString().Trim() + "%'";

            }
            if (Data.SearchID == 4)
            {
                if (Data.SearchValue != "")
                    if (strWhere == "")
                        strWhere += _Query + " where (select top(1) CntrNo from NVO_BLCargo where NVO_BLCargo.BkgID=NVO_View_VesselTaskBookingCount.BkgId and CntrNo like '%" + Data.SearchValue.ToString().Trim() + "%') like '%" + Data.SearchValue.ToString().Trim() + "%'";
                    else
                        strWhere += " and (select top(1) CntrNo from NVO_BLCargo where NVO_BLCargo.BkgID=NVO_View_VesselTaskBookingCount.BkgId and CntrNo like '%" + Data.SearchValue.ToString().Trim() + "%') like '%" + Data.SearchValue.ToString().Trim() + "%'";

            }

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " group by VesselID,VoyageID,VessleName,VoyageName,ETDDate ", "");

        }


        public List<MyVesselTask> BindPreAlertStatusvalues(MyVesselTask Data)
        {
            DataTable dt = GetBindPreAlertListvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {

                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    PrincipalID = Int32.Parse(dt.Rows[i]["PrincipalID"].ToString()),
                    PODAgentID = Int32.Parse(dt.Rows[i]["PODAgentID"].ToString()),
                    PrincipleName = dt.Rows[i]["PrincipleName"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    BLCount = dt.Rows[i]["BLCount"].ToString(),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    PrealertDate = dt.Rows[i]["PrealertDate"].ToString(),
                    VesselName = dt.Rows[i]["VessleName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageName"].ToString(),
                    ETD = dt.Rows[i]["ETDDate"].ToString(),


                });
            }
            return ListvslLevel;
        }
        public DataTable GetBindPreAlertListvalues(MyVesselTask Data)
        {

            string _Query = "select vesselID,VoyageID,PODAgentID,PrincipalID,PrincipleName,AgencyName, VessleName, VoyageName,ETDDate, " +
                "ISNULL((select top(1) Status from NVO_PrealertFinal where BkgID = NVO_View_VesselTaskBookingCount.BkgId),'NA') as Status, " +
                "(select top(1) PrealertDate from NVO_PrealertFinal where BkgID = NVO_View_VesselTaskBookingCount.BkgId) as PrealertDate, " +
                " sum(BLCount) as BLCount,sum(CntrCount) as CntrCount from NVO_View_VesselTaskBookingCount" +
                " where vesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + " group by vesselID,VoyageID,PODAgentID,PrincipalID,PrincipleName,AgencyName,BkgId,VessleName,VoyageName,ETDDate ";



            return GetViewData(_Query, "");

        }


        public List<MyVesselTask> BindPreAlertFinalizevalues(MyVesselTask Data)
        {
            DataTable dt = GetBindPreAlertFinalizevalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {

                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    PODName = dt.Rows[i]["PODName"].ToString(),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageNo"].ToString(),

                    FPODName = dt.Rows[i]["FPODName"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLStatus = dt.Rows[i]["BLStatus"].ToString(),
                    RouteName = dt.Rows[i]["RouteName"].ToString(),
                    Instructions = dt.Rows[i]["Instructions"].ToString(),
                    AttachDate = dt.Rows[i]["AttachDate"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),

                });
            }
            return ListvslLevel;
        }
        public DataTable GetBindPreAlertFinalizevalues(MyVesselTask Data)
        {

            string _Query = "select NVO_Booking.Id as BkgID,VesselID,VoyageID,PrincipalID,PODAgentID, NVO_BL.Id as BLID,BLNumber,DestinationID as PODID, DischargePortID as FPODID, " +
                "(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo," +
                "(select top(1) PortName from NVO_PortMaster where ID = DestinationID) as PODName, " +
                "(select top(1) PortName from NVO_PortMaster where ID = DischargePortID) as FPODName, " +
                "(select count(CntrID) from NVO_BLContainer where NVO_BLContainer.BLID = NVO_BL.ID) as CntrCount, " +
                "(select case when BLStatus = 1 then 'DRAFT' else  case when BLStatus = 2 then 'SUBMITTED' else case when BLStatus = 3 then 'APPROVED' else case when BLStatus = 4 then 'REJECTED' else case when BLStatus = 5 then 'ISSUED' else " +
                "case when ISNULL(BLStatus,0)= 0 THEN 'DRAFT' ELSE 'DRAFT' END END END END END END from NVO_BOLNew WHERE NVO_BOLNew.BLID = NVO_BL.ID) as BLStatus, " +
                "(SELECT TOP(1) GeneralName FROM NVO_GeneralMaster WHERE ID = NVO_Booking.RouteID) as RouteName," +
                "(SELECT TOP(1) Instructions FROM NVO_PrealertFinal WHERE BLID = NVO_BL.ID) as Instructions, " +
                "(SELECT TOP(1) AttachDate FROM NVO_PrealertFinal WHERE BLID = NVO_BL.ID) as AttachDate, " +
                "convert(varchar,(select top(1) ETD from NVO_Voyage where ID = NVO_Booking.VoyageID),105) as ETD from NVO_Booking " +
                "inner join NVO_BL on NVO_BL.BkgID = NVO_Booking.id where intStatus = 2 and VesselID = " + Data.VesselID + " " +
                "and VoyageID = " + Data.VoyageID + " and PrincipalID = " + Data.PrincipalID + " and PODAgentID = " + Data.PODAgentID + "";



            return GetViewData(_Query, "");

        }


        public List<MyVesselTask> InsertPreAlertFinalInstr(MyVesselTask Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_PrealertFinal where BLID=@BLID)<=0)" +
                        "  BEGIN " +
                        " INSERT  INTO  NVO_PrealertFinal(BLID,Instructions)  " +
                        " values (@BLID,@Instructions) " +
                        " END " +
                        " ELSE " +
                        " UPDATE NVO_PrealertFinal SET BLID=@BLID,Instructions=@Instructions where BLID=@BLID ";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Instructions", Data.Instructions));


                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_PrealertFinal')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListvslLevel.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListvslLevel;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListvslLevel.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListvslLevel;
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


        public List<MyVesselTask> InsertPreAlertMailInstr(MyVesselTask Data)
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
                    string[] Array1 = Data.Items.TrimEnd(',').Split(',');
                    for (int i = 0; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_PrealertFinal where BLID=@BLID)<=0)" +
                        "  BEGIN " +
                        " INSERT  INTO  NVO_PrealertFinal(BLID,BkgID,Status,PrealertDate)  " +
                        " values (@BLID,@BkgID,@Status,@PrealertDate) " +
                        " END " +
                        " ELSE " +
                        " UPDATE NVO_PrealertFinal SET BLID=@BLID,BkgID=@BkgID,Status=@Status,PrealertDate=@PrealertDate where BLID=@BLID ";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PrealertDate", (DateTime.Parse(System.DateTime.Now.ToString()))));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        //Cmd.CommandText = "select ident_current('NVO_PrealertFinal')";
                        //if (Data.ID == 0)
                        //    Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        //else
                        //    Data.ID = Data.ID;
                    }

                    trans.Commit();
                    ListvslLevel.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListvslLevel;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListvslLevel.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListvslLevel;
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


        public List<MyVesselTask> InsertPreAlertAttachStatus(MyVesselTask Data)
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
                    string[] Array1 = Data.AttachID.TrimEnd(',').Split(',');
                    for (int i = 0; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_PrealertFinal where BLID=@BLID)<=0)" +
                        "  BEGIN " +
                        " INSERT  INTO  NVO_PrealertFinal(BLID,AttachDate)  " +
                        " values (@BLID,@AttachDate) " +
                        " END " +
                        " ELSE " +
                        " UPDATE NVO_PrealertFinal SET BLID=@BLID,AttachDate=@AttachDate where BLID=@BLID ";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachDate", (DateTime.Parse(System.DateTime.Now.ToString()))));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        //Cmd.CommandText = "select ident_current('NVO_PrealertFinal')";
                        //if (Data.ID == 0)
                        //    Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        //else
                        //    Data.ID = Data.ID;
                    }

                    trans.Commit();
                    ListvslLevel.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListvslLevel;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListvslLevel.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListvslLevel;
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


        public List<MyVesselTask> BindPreAlertMailvalues(MyVesselTask Data)
        {
            DataTable dt = GetBindPreAlertMailvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {

                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    PODName = dt.Rows[i]["PODName"].ToString(),
                    FPODName = dt.Rows[i]["FPODName"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    POLName = dt.Rows[i]["POLName"].ToString(),
                    DirTS = dt.Rows[i]["DirTS"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOperator"].ToString(),
                    PrincipleName = dt.Rows[i]["PrincipleName"].ToString(),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageNo"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    CargoType = dt.Rows[i]["CargoType"].ToString(),
                    Temperature = dt.Rows[i]["Temperature"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),

                });
            }
            return ListvslLevel;
        }
        public DataTable GetBindPreAlertMailvalues(MyVesselTask Data)
        {

            string _Query = "select VesselID,VoyageID,SlotOperatorID,NVO_Booking.Id as BkgID,ISNULL(NVO_BL.Id,0) as BLID, BookingNo,NVO_BL.BLNumber as BLNumber," +
                "(select top(1) CntrNo from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as CntrNo," +
                "(select top(1)(select top(1) Size from NVO_tblCntrTypes where Id = NVO_Containers.TypeID) from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as CntrType, " +
                "ISNULL((select top(1) Teus from NVO_SlotMgmt inner join NVO_SlotMgmtDtls on NVO_SlotMgmtDtls.SlotMgmtID = NVO_SlotMgmt.ID " +
                " where NVO_SlotMgmtDtls.VslOperatorID = NVO_Booking.SlotOperatorID and VoyageID = NVO_Booking.VoyageID),0) as Tues, " +
                "case when intHazardous = 1 then 'GENERAL' ELSE 'HAZARDOUS' END AS CargoType, (select top(1) PortName from NVO_PortMaster where ID = DestinationID) as PODName, " +
                "(select top(1) PortName from NVO_PortMaster where ID = DischargePortID) as FPODName, " +
                "(select top(1) PortName from NVO_PortMaster where ID = LoadPortID) as POLName, case when EnquirySourceID = 1 then 'Direct' else 'TS' end as DirTS, " +
                "(select  top(1) CustomerName from NVO_view_CustomerDetails where CID = NVO_Booking.SlotOperatorID) as SlotOperator, " +
                "ISNULL((select top(1) LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = NVO_Booking.PrincipalID), 'NA') as PrincipleName, " +
                "(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo,'NA' as LoadStatus, 'NA' as LoadDate, " +
                "Temperature, convert(varchar,(select top(1) ETD from NVO_Voyage where ID = NVO_Booking.VoyageID),105) as ETD from NVO_Booking " +
                "inner join NVO_BL on NVO_BL.BkgID = NVO_Booking.ID " +
                " inner join NVO_BLContainer on NVO_BLContainer.BLID = NVO_BL.ID and NVO_BLContainer.BkgID = NVO_Booking.ID" +
                " inner join NVO_BLCargo on NVO_BLCargo.BkgID = NVO_BL.BkgID and NVO_BLCargo.BkgID = NVO_Booking.ID  and NVO_BLContainer.CntrID = NVO_BLCargo.CntrID " +
                "where NVO_Booking.intStatus = 2 and ISNULL(NVO_BL.Id,0)!=0 and VesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + "";



            return GetViewData(_Query, "");

        }

        public List<MyVesselTask> BindPreAlertMailTovalues(MyVesselTask Data)
        {
            DataTable dt = GetBindPreAlertMailTovalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {

                    PrincipalMail = dt.Rows[i]["PrincipleMail"].ToString(),
                    AgentMail = dt.Rows[i]["AgentMail"].ToString(),

                });
            }
            return ListvslLevel;
        }
        public DataTable GetBindPreAlertMailTovalues(MyVesselTask Data)
        {

            string _Query = "select NVO_Booking.Id as BkgID, " +
                "(select top(1) EmailID from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = NVO_Booking.PrincipalID) as PrincipleMail, " +
                "(select top(1) Email from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_Booking.PODAgentID) as AgentMail from NVO_Booking " +
                "where NVO_Booking.intStatus = 2 and VesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + "";

            return GetViewData(_Query, "");

        }


        //OnBoard
        public List<MyVesselTask> BindOnBoardConfirmvalues(MyVesselTask Data)
        {
            DataTable dt = GetBindOnBoardConfirmvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageNo"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    PODName = dt.Rows[i]["PODName"].ToString(),
                    FPODName = dt.Rows[i]["FPODName"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    OnboardDate = dt.Rows[i]["OnboardDate"].ToString(),
                    CusEmail = dt.Rows[i]["CusEmail"].ToString().ToLower(),
                    CusEmailV = dt.Rows[i]["CusEmailV"].ToString().ToLower(),
                    CustomerID = dt.Rows[i]["CustomerID"].ToString().ToLower(),
                    UserName = dt.Rows[i]["UserName"].ToString().ToLower(),
                    BLID = dt.Rows[i]["BLID"].ToString(),


                });
            }
            return ListvslLevel;
        }
        public DataTable GetBindOnBoardConfirmvalues(MyVesselTask Data)
        {

            string _Query = "select VesselID,VoyageID,CustomerID,SlotOperatorID,NVO_Booking.Id as BkgID,NVO_BL.Id as BLID, BookingNo,NVO_BL.BLNumber, " +
                "(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo, " +
                "convert(varchar,(select top(1) ETD from NVO_Voyage where ID = NVO_Booking.VoyageID),105) as ETD, " +
                " (select top(1) CustomerName from NVO_view_CustomerDetails where CID = NVO_Booking.CustomerID) as CustomerName, " +
                " (select top(1) count(CntrID) from NVO_BLContainer where NVO_BLContainer.BLID = NVO_BL.ID) as CntrCount, " +
                "(select top(1) UserName from NVO_UserDetails where NVO_UserDetails.ID = NVO_Booking.SalesPersonID) as UserName," +
                " (select top(1) OnboardDate from NVO_OnboardMail where NVO_OnboardMail.BLID = NVO_BL.ID) as OnboardDate, " +
                " Left(case when isnull((select top(1) BLID from NVO_OnboardMail where NVO_OnboardMail.BLID =NVO_BL.ID),0) = 0  then " +
                "(select top(1) EmailID from NVO_CusBranchLocation where CID = NVO_Booking.CustomerID)  else " +
                "(select top(1) EmailID from NVO_OnboardMail where NVO_OnboardMail.BLID = NVO_BL.ID) end, 20)  as CusEmailV, " +
                "case when isnull((select top(1) BLID from NVO_OnboardMail where NVO_OnboardMail.BLID = NVO_BL.ID),0) = 0  then " +
                "(select top(1) EmailID from NVO_CusBranchLocation where CID = NVO_Booking.CustomerID)  else " +
                "(select top(1) EmailID from NVO_OnboardMail where NVO_OnboardMail.BLID = NVO_BL.ID) end as CusEmail, " +
                "(select sum(TEUS) from NVO_BLContainer inner join NVO_Containers on NVO_Containers.ID=NVO_BLContainer.CntrID " +
                "inner join NVO_tblCntrTypes on NVO_tblCntrTypes.ID = NVO_Containers.TypeID " +
                "where NVO_BLContainer.BLID = NVO_BL.ID) as Tues, " +
                " (select top(1) PortName from NVO_PortMaster where ID = DestinationID) as PODName, " +
                " (select top(1) PortName from NVO_PortMaster where ID = DischargePortID) as FPODName from NVO_Booking " +
                " inner join NVO_BL on NVO_BL.BkgID = NVO_Booking.ID where VesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + " ";



            return GetViewData(_Query, "");

        }





        List<MyVesselTask> ListOnboard = new List<MyVesselTask>();
        public List<MyVesselTask> InsertOnboardConfirm(MyVesselTask Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_OnboardMail where BLID=@BLID)<=0)" +
                        "  BEGIN " +
                        " INSERT  INTO  NVO_OnboardMail(VesselID,VoyageID,BLID,CustomerID,BLNumber,EmailID)  " +
                        "values (@VesselID,@VoyageID,@BLID,@CustomerID,@BLNumber,@EmailID) " +
                        " END " +
                        " ELSE " +
                        " UPDATE NVO_OnboardMail SET VesselID=@VesselID,VoyageID=@VoyageID,BLID=@BLID,CustomerID=@CustomerID,BLNumber=@BLNumber,EmailID=@EmailID where BLID=@BLID ";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselID", Data.VesselID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Data.VoyageID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CustomerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLNumber));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EmailID", Data.EmailID));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_OnboardMail')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListOnboard.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListOnboard;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListOnboard.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListOnboard;
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

        public List<MyVesselTask> InsertOnboardConfirmStatus(MyVesselTask Data)
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

                    Cmd.CommandText = " UPDATE NVO_OnboardMail SET OnboardDate=@OnboardDate where BLID=@BLID ";


                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OnboardDate", (DateTime.Parse(System.DateTime.Now.ToString()))));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_OnboardMail')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListOnboard.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListOnboard;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListOnboard.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListOnboard;
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


        //OnBoard


        //TDR

        public List<MyVesselTask> BindTDRStatusvalues(MyVesselTask Data)
        {
            DataTable dt = GetBindTDRListvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {

                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    PrincipalID = Int32.Parse(dt.Rows[i]["PrincipalID"].ToString()),
                    PODAgentID = Int32.Parse(dt.Rows[i]["PODAgentID"].ToString()),
                    PrincipleName = dt.Rows[i]["PrincipleName"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    BLCount = dt.Rows[i]["BLCount"].ToString(),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    TDRDate = dt.Rows[i]["TDRDate"].ToString(),
                    VesselName = dt.Rows[i]["VessleName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageName"].ToString(),
                    ETD = dt.Rows[i]["ETDDate"].ToString(),

                });
            }
            return ListvslLevel;
        }
        public DataTable GetBindTDRListvalues(MyVesselTask Data)
        {

            string _Query = "select vesselID,VoyageID,PODAgentID,PrincipalID,PrincipleName,AgencyName, VessleName, VoyageName,ETDDate, " +
               "ISNULL((select top(1) Status from NVO_TDRFinal where BkgID = NVO_View_VesselTaskBookingCount.BkgId),'NA') as Status, " +
               "(select top(1) TDRDate from NVO_TDRFinal where BkgID = NVO_View_VesselTaskBookingCount.BkgId) as TDRDate, " +
               " sum(BLCount) as BLCount,sum(CntrCount) as CntrCount from NVO_View_VesselTaskBookingCount" +
               " where vesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + " group by vesselID,VoyageID,PODAgentID,PrincipalID,PrincipleName,AgencyName,BkgId,VessleName,VoyageName,ETDDate ";



            return GetViewData(_Query, "");

        }


        public List<MyVesselTask> BindTDRFinalizevalues(MyVesselTask Data)
        {
            DataTable dt = GetBindTDRFinalizevalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {

                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    PODName = dt.Rows[i]["PODName"].ToString(),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageNo"].ToString(),

                    FPODName = dt.Rows[i]["FPODName"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLStatus = dt.Rows[i]["BLStatus"].ToString(),
                    RouteName = dt.Rows[i]["RouteName"].ToString(),
                    Instructions = dt.Rows[i]["Instructions"].ToString(),
                    AttachDate = dt.Rows[i]["AttachDate"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),

                });
            }
            return ListvslLevel;
        }
        public DataTable GetBindTDRFinalizevalues(MyVesselTask Data)
        {

            string _Query = "select NVO_Booking.Id as BkgID,VesselID,VoyageID,PrincipalID,PODAgentID, NVO_BL.Id as BLID,BLNumber,DestinationID as PODID, DischargePortID as FPODID, " +
                "(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo," +
                "(select top(1) PortName from NVO_PortMaster where ID = DestinationID) as PODName, " +
                "(select top(1) PortName from NVO_PortMaster where ID = DischargePortID) as FPODName, " +
                "(select count(CntrID) from NVO_BLContainer where NVO_BLContainer.BLID = NVO_BL.ID) as CntrCount, " +
                "(select case when BLStatus = 1 then 'DRAFT' else  case when BLStatus = 2 then 'FINAL' else " +
                "case when ISNULL(BLStatus,0)= 0 THEN 'RR' ELSE 'MM' end END  END from NVO_BOLNew WHERE NVO_BOLNew.BLID = NVO_BL.ID) as BLStatus, " +
                "(SELECT TOP(1) GeneralName FROM NVO_GeneralMaster WHERE ID = NVO_Booking.RouteID) as RouteName," +
                "(SELECT TOP(1) Instructions FROM NVO_TDRFinal WHERE BLID = NVO_BL.ID) as Instructions, " +
                "(SELECT TOP(1) AttachDate FROM NVO_TDRFinal WHERE BLID = NVO_BL.ID) as AttachDate, " +
                "convert(varchar,(select top(1) ETD from NVO_Voyage where ID = NVO_Booking.VoyageID),105) as ETD from NVO_Booking " +
                "inner join NVO_BL on NVO_BL.BkgID = NVO_Booking.id where intStatus = 2 and VesselID = " + Data.VesselID + " " +
                "and VoyageID = " + Data.VoyageID + " and PrincipalID = " + Data.PrincipalID + " and PODAgentID = " + Data.PODAgentID + "";



            return GetViewData(_Query, "");

        }


        public List<MyVesselTask> BindTDRMailvalues(MyVesselTask Data)
        {
            DataTable dt = GetBindTDRMailvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {

                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    PODName = dt.Rows[i]["PODName"].ToString(),
                    FPODName = dt.Rows[i]["FPODName"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    POLName = dt.Rows[i]["POLName"].ToString(),
                    DirTS = dt.Rows[i]["DirTS"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOperator"].ToString(),
                    PrincipleName = dt.Rows[i]["PrincipleName"].ToString(),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageNo"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    CargoType = dt.Rows[i]["CargoType"].ToString(),
                    Temperature = dt.Rows[i]["Temperature"].ToString(),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),

                });
            }
            return ListvslLevel;
        }
        public DataTable GetBindTDRMailvalues(MyVesselTask Data)
        {

            string _Query = "select VesselID,VoyageID,SlotOperatorID,NVO_Booking.Id as BkgID,ISNULL(NVO_BL.Id,0) as BLID, BookingNo,NVO_BL.BLNumber as BLNumber," +
                "(select top(1) CntrNo from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as CntrNo," +
                "(select top(1)(select top(1) Size from NVO_tblCntrTypes where Id = NVO_Containers.TypeID) from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as CntrType, " +
                "ISNULL((select top(1) Teus from NVO_SlotMgmt inner join NVO_SlotMgmtDtls on NVO_SlotMgmtDtls.SlotMgmtID = NVO_SlotMgmt.ID " +
                " where NVO_SlotMgmtDtls.VslOperatorID = NVO_Booking.SlotOperatorID and VoyageID = NVO_Booking.VoyageID),0) as Tues, " +
                "case when intHazardous = 1 then 'GENERAL' ELSE 'HAZARDOUS' END AS CargoType, (select top(1) PortName from NVO_PortMaster where ID = DestinationID) as PODName, " +
                "(select top(1) PortName from NVO_PortMaster where ID = DischargePortID) as FPODName, " +
                "(select top(1) PortName from NVO_PortMaster where ID = LoadPortID) as POLName, case when EnquirySourceID = 1 then 'Direct' else 'TS' end as DirTS, " +
                "(select  top(1) CustomerName from NVO_view_CustomerDetails where CID = NVO_Booking.SlotOperatorID) as SlotOperator, " +
                "ISNULL((select top(1) LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = NVO_Booking.PrincipalID), 'NA') as PrincipleName, " +
                "(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo,'NA' as LoadStatus, 'NA' as LoadDate, " +
                "Temperature, convert(varchar,(select top(1) ETD from NVO_Voyage where ID = NVO_Booking.VoyageID),105) as ETD from NVO_Booking " +
                "inner join NVO_BL on NVO_BL.BkgID = NVO_Booking.ID " +
                " inner join NVO_BLContainer on NVO_BLContainer.BLID = NVO_BL.ID and NVO_BLContainer.BkgID = NVO_Booking.ID" +
                " inner join NVO_BLCargo on NVO_BLCargo.BkgID = NVO_BL.BkgID and NVO_BLCargo.BkgID = NVO_Booking.ID  and NVO_BLContainer.CntrID = NVO_BLCargo.CntrID " +
                "where NVO_Booking.intStatus = 2 and ISNULL(NVO_BL.Id,0)!=0 and VesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + "";



            return GetViewData(_Query, "");

        }


        public List<MyVesselTask> BindTDRMailTovalues(MyVesselTask Data)
        {
            DataTable dt = GetBindTDRMailTovalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {

                    PrincipalMail = dt.Rows[i]["PrincipleMail"].ToString(),
                    AgentMail = dt.Rows[i]["AgentMail"].ToString(),

                });
            }
            return ListvslLevel;
        }
        public DataTable GetBindTDRMailTovalues(MyVesselTask Data)
        {

            string _Query = "select NVO_Booking.Id as BkgID, " +
                "(select top(1) EmailID from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = NVO_Booking.PrincipalID) as PrincipleMail, " +
                "(select top(1) Email from NVO_AgencyMaster where NVO_AgencyMaster.ID = NVO_Booking.PODAgentID) as AgentMail from NVO_Booking " +
                "where NVO_Booking.intStatus = 2 and VesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + "";

            return GetViewData(_Query, "");

        }


        public List<MyVesselTask> InsertTDRFinalInstr(MyVesselTask Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_TDRFinal where BLID=@BLID)<=0)" +
                        "  BEGIN " +
                        " INSERT  INTO  NVO_TDRFinal(BLID,Instructions)  " +
                        " values (@BLID,@Instructions) " +
                        " END " +
                        " ELSE " +
                        " UPDATE NVO_TDRFinal SET BLID=@BLID,Instructions=@Instructions where BLID=@BLID ";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Instructions", Data.Instructions));


                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_TDRFinal')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListvslLevel.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListvslLevel;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListvslLevel.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListvslLevel;
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


        public List<MyVesselTask> InsertTDRMailInstr(MyVesselTask Data)
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
                    string[] Array1 = Data.Items.TrimEnd(',').Split(',');
                    for (int i = 0; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_TDRFinal where BLID=@BLID)<=0)" +
                        "  BEGIN " +
                        " INSERT  INTO  NVO_TDRFinal(BLID,BkgID,Status,TDRDate)  " +
                        " values (@BLID,@BkgID,@Status,@TDRDate) " +
                        " END " +
                        " ELSE " +
                        " UPDATE NVO_TDRFinal SET BLID=@BLID,BkgID=@BkgID,Status=@Status,TDRDate=@TDRDate where BLID=@BLID ";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TDRDate", (DateTime.Parse(System.DateTime.Now.ToString()))));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        //Cmd.CommandText = "select ident_current('NVO_PrealertFinal')";
                        //if (Data.ID == 0)
                        //    Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        //else
                        //    Data.ID = Data.ID;
                    }

                    trans.Commit();
                    ListvslLevel.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListvslLevel;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListvslLevel.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListvslLevel;
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


        public List<MyVesselTask> InsertTDRAttachStatus(MyVesselTask Data)
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
                    string[] Array1 = Data.AttachID.TrimEnd(',').Split(',');
                    for (int i = 0; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_TDRFinal where BLID=@BLID )<=0 ) " +
                        "  BEGIN " +
                        " INSERT  INTO  NVO_TDRFinal( BLID,AttachDate )  " +
                        " values (@BLID,@AttachDate) " +
                        " END " +
                        " ELSE " +
                        " UPDATE NVO_TDRFinal SET BLID=@BLID, AttachDate=@AttachDate where BLID=@BLID ";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachDate", (DateTime.Parse(System.DateTime.Now.ToString()))));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        //Cmd.CommandText = "select ident_current('NVO_PrealertFinal')";
                        //if (Data.ID == 0)
                        //    Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        //else
                        //    Data.ID = Data.ID;
                    }

                    trans.Commit();
                    ListvslLevel.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListvslLevel;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListvslLevel.Add(new MyVesselTask
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListvslLevel;
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


        //TDR

        //LoadList

        public List<MyVesselTask> GetVesselLoadListStatuslist(MyVesselTask Data)
        {
            DataTable dt = GetVesselLoadListStatuslistvalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {
                    SlotOperator = dt.Rows[i]["SlotOperator"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    MT = dt.Rows[i]["MT"].ToString(),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageNo"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    SailedStatus = dt.Rows[i]["SailedStatus"].ToString(),

                });
            }
            return ListvslLevel;
        }
        public DataTable GetVesselLoadListStatuslistvalues(MyVesselTask Data)
        {
            string strWhere = "";
            string _Query = " select NVO_Booking.SlotOperatorID,NVO_Booking.Id, " +
                "(select  top(1) CustomerName from NVO_view_CustomerDetails where CID = NVO_Booking.SlotOperatorID) as SlotOperator, " +
                "ISNULL((select top(1) Teus from NVO_SlotMgmt inner join NVO_SlotMgmtDtls on NVO_SlotMgmtDtls.SlotMgmtID = NVO_SlotMgmt.ID " +
                " where NVO_SlotMgmtDtls.VslOperatorID = NVO_Booking.SlotOperatorID and VoyageID = NVO_Booking.VoyageID),0) as Tues, " +
                " ISNULL((select top(1) MT from NVO_SlotMgmt inner join NVO_SlotMgmtDtls on NVO_SlotMgmtDtls.SlotMgmtID = NVO_SlotMgmt.ID" +
                " where NVO_SlotMgmtDtls.VslOperatorID = NVO_Booking.SlotOperatorID and VoyageID = NVO_Booking.VoyageID),0) as MT, " +
                " (select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo, " +
                "convert(varchar,(select top(1) ETD from NVO_Voyage where ID = NVO_Booking.VoyageID),105) as ETD, " +
                "'NA' as SailedStatus" +
                " from NVO_Booking  where intStatus = 2 and VesselID = " + Data.VesselID + " and VoyageID= " + Data.VoyageID + " ";


            //string _Query = " select (select top(1) CustomerName from NVO_CustomerMaster where ID = NVO_Booking.SlotOperatorID) as SlotOperator, " +
            //                " (select Count(CntrID) from NVO_BLContainer where BkgID=NVO_Booking.ID) as CntrCount, " +
            //                " (select sum(Tues) from NVO_v_BookingCntrTues where NVO_v_BookingCntrTues.BkgId =NVO_Booking.ID) as Tues  " +
            //                " from NVO_Booking  where intStatus= 2 and VesselID = " + Data.VesselID + " and VoyageID= " + Data.VoyageID + " ";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }



        public List<MyVesselTask> GetVesselLoadListFinallist(MyVesselTask Data)
        {
            DataTable dt = GetVesselLoadListFinallistvalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {
                    SlotOperatorID = Int32.Parse(dt.Rows[i]["SlotOperatorID"].ToString()),
                    SlotOperator = dt.Rows[i]["SlotOperator"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    MT = dt.Rows[i]["MT"].ToString(),
                    BMT = dt.Rows[i]["BMT"].ToString(),
                    BCntr = dt.Rows[i]["BCntr"].ToString(),
                    BTues = dt.Rows[i]["BTues"].ToString(),
                    DiffTues = (Int32.Parse(dt.Rows[i]["Tues"].ToString()) - Int32.Parse(dt.Rows[i]["BTues"].ToString())).ToString(),
                    DiffMT = (decimal.Parse(dt.Rows[i]["MT"].ToString()) - decimal.Parse(dt.Rows[i]["BMT"].ToString())).ToString(),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageNo"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    SailedStatus = dt.Rows[i]["SailedStatus"].ToString(),



                });
            }
            return ListvslLevel;
        }
        public DataTable GetVesselLoadListFinallistvalues(MyVesselTask Data)
        {
            string strWhere = "";
            string _Query = "  select NVO_Booking.SlotOperatorID,NVO_Booking.Id, " +
                "(select  top(1) CustomerName from NVO_view_CustomerDetails where CID = NVO_Booking.SlotOperatorID) as SlotOperator, " +
                "ISNULL((select top(1) Teus from NVO_SlotMgmt " +
                "inner join NVO_SlotMgmtDtls on NVO_SlotMgmtDtls.SlotMgmtID = NVO_SlotMgmt.ID " +
                "where NVO_SlotMgmtDtls.VslOperatorID = NVO_Booking.SlotOperatorID and VoyageID = NVO_Booking.VoyageID),0) as Tues, " +
                "ISNULL((select top(1) MT from NVO_SlotMgmt " +
                "inner join NVO_SlotMgmtDtls on NVO_SlotMgmtDtls.SlotMgmtID = NVO_SlotMgmt.ID " +
                "where NVO_SlotMgmtDtls.VslOperatorID = NVO_Booking.SlotOperatorID and VoyageID = NVO_Booking.VoyageID),0) as MT, " +
                "(select count(ContainerID)  from NVO_ContainerTxns where BLNumber = NVO_Booking.Id  and StatusCodeID = 5) as BCntr, " +
                "ISNULL((select sum(TEUS) from NVO_Containers " +
                "inner join NVO_ContainerTxns on NVO_ContainerTxns.ContainerID = NVO_Containers.ID " +
                "inner join NVO_tblCntrTypes on NVO_tblCntrTypes.ID = NVO_Containers.TypeID " +
                "where BLNumber = NVO_Booking.Id  and NVO_ContainerTxns.StatusCodeID = 5),0) as BTues, " +
                "ISNULL((select sum(KGSWeight/1000) from NVO_BLCargo where BkgID = NVO_Booking.ID),0) as BMT, " +
                " (select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo, " +
                "convert(varchar,(select top(1) ETD from NVO_Voyage where ID = NVO_Booking.VoyageID),105) as ETD, " +
                "'NA' as SailedStatus " +
                "from NVO_Booking  where intStatus = 2 and VesselID = " + Data.VesselID + " and VoyageID= " + Data.VoyageID + " ";


            //string _Query = " select (select top(1) CustomerName from NVO_CustomerMaster where ID = NVO_Booking.SlotOperatorID) as SlotOperator, " +
            //                " (select Count(CntrID) from NVO_BLContainer where BkgID=NVO_Booking.ID) as CntrCount, " +
            //                " (select sum(Tues) from NVO_v_BookingCntrTues where NVO_v_BookingCntrTues.BkgId =NVO_Booking.ID) as Tues  " +
            //                " from NVO_Booking  where intStatus= 2 and VesselID = " + Data.VesselID + " and VoyageID= " + Data.VoyageID + " ";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }


        public List<MyVesselTask> GetVesselLoadListFinalTablist(MyVesselTask Data)
        {
            DataTable dt = GetVesselLoadListFinalTablistvalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {

                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    BLType = dt.Rows[i]["BLType"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    CargoType = dt.Rows[i]["CargoType"].ToString(),
                    Origin = dt.Rows[i]["Origin"].ToString(),
                    PODName = dt.Rows[i]["PODName"].ToString(),
                    FPODName = dt.Rows[i]["FPODName"].ToString(),
                    PrincipleName = dt.Rows[i]["PrincipleName"].ToString(),
                    CargoWeight = dt.Rows[i]["CargoWeight"].ToString(),
                    Fixed = dt.Rows[i]["Fixed"].ToString(),

                });
            }
            return ListvslLevel;
        }
        public DataTable GetVesselLoadListFinalTablistvalues(MyVesselTask Data)
        {
            string strWhere = "";
            string _Query = " select NVO_Booking.ID,BookingNo,CargoWeight, 'Export'as BLType, " +
                "(select top(1) CntrNo from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as CntrNo, " +
                "(select top(1) PortName  from NVO_PortMaster where ID = OriginID) as Origin, " +
                "(select top(1) PortName  from NVO_PortMaster where ID = DestinationID) as PODName, " +
                "(select top(1) PortName from NVO_PortMaster where ID = DischargePortID) as FPODName, " +
                "(select top(1) LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID = NVO_Booking.PrincipalID) as PrincipleName, " +
                "(select top(1)(select top(1) Size from NVO_tblCntrTypes where Id = NVO_Containers.TypeID) " +
                "from NVO_Containers where NVO_Containers.ID = NVO_BLContainer.CntrID) as CntrType, " +
                "(select top(1)(select top(1) TEUS from NVO_tblCntrTypes where Id = NVO_Containers.TypeID) from NVO_Containers " +
                "inner join NVO_ContainerTxns on NVO_ContainerTxns.ContainerID = NVO_Containers.ID " +
                "where BLNumber = NVO_Booking.ID) as Tues, " +
                "case when HazarOpt = 1 then 'GENERAL' ELSE 'HAZARDOUS' END AS CargoType, " +
                "case when FixedID = 1 then 'NO' ELSE 'YES' END AS Fixed from NVO_Booking " +
                "inner join NVO_BLContainer on NVO_BLContainer.BkgID = NVO_Booking.ID " +
                "inner join NVO_BLCargo on  NVO_BLCargo.BkgID = NVO_Booking.ID and NVO_BLContainer.CntrID = NVO_BLCargo.CntrID " +
                "where NVO_Booking.intStatus = 2 and VesselID = " + Data.VesselID + " and VoyageID= " + Data.VoyageID + " and SlotOperatorID= " + Data.SlotOperatorID + "";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }


        public List<MyVesselTask> GetVesselLoadListMaillist(MyVesselTask Data)
        {
            DataTable dt = GetVesselLoadListMaillistvalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListvslLevel.Add(new MyVesselTask
                {

                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageNo"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    SailedStatus = dt.Rows[i]["SailedStatus"].ToString(),

                });
            }
            return ListvslLevel;
        }
        public DataTable GetVesselLoadListMaillistvalues(MyVesselTask Data)
        {
            string strWhere = "";
            string _Query = " select VesselID,VoyageID, " +
                "(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo, " +
                "convert(varchar,(select top(1) ETD from NVO_Voyage where ID = NVO_Booking.VoyageID),105) as ETD, 'NA' as SailedStatus from NVO_Booking " +
                "where NVO_Booking.intStatus = 2 and VesselID = " + Data.VesselID + " and VoyageID= " + Data.VoyageID + " ";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }


        //LoadList




        #region udhaya
        public List<myVesselTask1> GetVesselTaskViewlist(myVesselTask1 Data)
        {
            DataTable dt = GetVesselTaskViewlistvalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVesselTask.Add(new myVesselTask1
                {
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    VesselName = dt.Rows[i]["VessleName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageName"].ToString(),
                    ETD = dt.Rows[i]["ETDDate"].ToString(),
                    //Sailed = dt.Rows[i]["Sailed"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    BLCount = dt.Rows[i]["BLCount"].ToString(),

                    LoadNos = dt.Rows[i]["LoadNos"].ToString(),
                    LoadDraft = dt.Rows[i]["LoadDraft"].ToString(),
                    LoadFinal = dt.Rows[i]["LoadFinal"].ToString(),
                    AlertNos = dt.Rows[i]["AlertNos"].ToString(),
                    AlertDraft = dt.Rows[i]["AlertDraft"].ToString(),
                    AlertFinal = dt.Rows[i]["AlertFinal"].ToString(),
                    LCNos = dt.Rows[i]["LCNos"].ToString(),
                    LCDraft = dt.Rows[i]["LCDraft"].ToString(),
                    LCFinal = dt.Rows[i]["LCFinal"].ToString(),
                    OnboardNos = dt.Rows[i]["OnboardNos"].ToString(),
                    OnboardDraft = dt.Rows[i]["OnboardDraft"].ToString(),
                    OnboardFinal = dt.Rows[i]["OnboardFinal"].ToString(),
                    TDRNos = dt.Rows[i]["TDRNos"].ToString(),
                    TDRDraft = dt.Rows[i]["TDRDraft"].ToString(),
                    TDRFinal = dt.Rows[i]["TDRFinal"].ToString(),
                    ATDDate = dt.Rows[i]["ATDDate"].ToString(),

                });
            }
            return ListVesselTask;
        }
        public DataTable GetVesselTaskViewlistvalues(myVesselTask1 Data)
        {
            string ETDDateFrom = "";
            string ETDDateTo = "";

            string strWhere = "";
            string _Query = " select distinct VesselID,VoyageID,VessleName,VoyageName,ETDDate,sum(BLCount) as BLCount, ATDDate, " +
                "sum(CntrCount) CntrCount, sum(AlertNos) as AlertNos,sum(AlertDraft) as AlertDraft,sum(AlertFinal) as AlertFinal, " +
                "sum(LCNos) as LCNos,sum(LCDraft) as LCDraft,sum(LCFinal) as LCFinal, " +
                "sum(TDRNos) as TDRNos,sum(TDRDraft) as TDRDraft,sum(TDRFinal) as TDRFinal, " +
                "sum(LoadNos) as LoadNos,sum(LoadDraft) as LoadDraft,sum(LoadFinal) as LoadFinal, " +
                "sum(OnboardNos) as OnboardNos,sum(OnboardDraft) as OnboardDraft,sum(OnboardFinal) as OnboardFinal " +
                "from NVO_View_VesselTaskBookingCount VsCount ";


            if (Data.VesselID.ToString() != "" && Data.VesselID.ToString() != "0" && Data.VesselID.ToString() != null && Data.VesselID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where VesselID = " + Data.VesselID.ToString();
                else
                    strWhere += " and VesselID = " + Data.VesselID.ToString();

            if (Data.VoyageID.ToString() != "" && Data.VoyageID.ToString() != null && Data.VoyageID.ToString() != "0" && Data.VoyageID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where VoyageID = " + Data.VoyageID + "";
                else
                    strWhere += " and VoyageID = " + Data.VoyageID + "";

            if (Data.BLID.ToString() != "" && Data.BLID.ToString() != null && Data.BLID.ToString() != "0" && Data.BLID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where BLID =" + Data.BLID + "";
                else
                    strWhere += " and BLID =" + Data.BLID + "";

            if (Data.ETDDateFrom != "" && Data.ETDDateFrom != null)
                if (strWhere == "")
                    strWhere += _Query + " where ETDDate >= '" + DateTime.Parse(Data.ETDDateFrom).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and ETDDate >= '" + DateTime.Parse(Data.ETDDateFrom).ToString("MM/dd/yyyy") + "'";

            if (Data.ETDDateTo != "" && Data.ETDDateTo != null)
                if (strWhere == "")
                    strWhere += _Query + " where ETDDate <= '" + DateTime.Parse(Data.ETDDateTo).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and ETDDate <= '" + DateTime.Parse(Data.ETDDateTo).ToString("MM/dd/yyyy") + "'";


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " group by VesselID,VoyageID,VessleName,VoyageName,ETDDate,ATDDate ", "");

        }

        public List<MyVesselLoadCnfrm> GetVesselLoadCnfrmViewlist(MyVesselLoadCnfrm Data)
        {
            DataTable dt = GetVesselLoadCnfrmViewlistvalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVesselCnFrm.Add(new MyVesselLoadCnfrm
                {
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageNo"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOperator"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    BCntrCount = dt.Rows[i]["BCntrCount"].ToString(),
                    NCntrCount = dt.Rows[i]["NCntrCount"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    BTues = dt.Rows[i]["BTues"].ToString(),
                    NTues = dt.Rows[i]["NTues"].ToString(),
                    PTues = (Int32.Parse(dt.Rows[i]["Tues"].ToString()) - Int32.Parse(dt.Rows[i]["BTues"].ToString()) - Int32.Parse(dt.Rows[i]["NTues"].ToString())).ToString(),
                    PCntrCount = (Int32.Parse(dt.Rows[i]["CntrCount"].ToString()) - Int32.Parse(dt.Rows[i]["BCntrCount"].ToString()) - Int32.Parse(dt.Rows[i]["NCntrCount"].ToString())).ToString(),

                });
            }
            return ListVesselCnFrm;
        }
        public DataTable GetVesselLoadCnfrmViewlistvalues(MyVesselLoadCnfrm Data)
        {
            string strWhere = "";
            string _Query = " select (select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo, " +
                "convert(varchar,(select top(1) ETD from NVO_Voyage where ID = NVO_Booking.VoyageID),105) as ETD," +
                "(select  top(1) CustomerName from NVO_view_CustomerDetails where CID = NVO_Booking.SlotOperatorID) as SlotOperator, " +
                "(select Count(CntrID) from NVO_BLContainer where BkgID = NVO_Booking.ID) as CntrCount, " +
                "(select Count(CntrID) from NVO_BLContainer where BkgID = NVO_Booking.ID and OnboardStatus = 1) as BCntrCount, " +
                "(select Count(CntrID) from NVO_BLContainer where BkgID = NVO_Booking.ID and OnboardStatus = 2) as NCntrCount, " +
                "isnull((select sum(TEUS) from NVO_Containers inner join NVO_BLContainer on NVO_BLContainer.CntrID = NVO_Containers.ID " +
                "inner join NVO_tblCntrTypes on NVO_tblCntrTypes.ID = NVO_Containers.TypeID where BkgID = NVO_Booking.Id),0) as Tues, " +
                "isnull((select sum(TEUS) from NVO_Containers inner join NVO_BLContainer on NVO_BLContainer.CntrID = NVO_Containers.ID " +
                "inner join NVO_tblCntrTypes on NVO_tblCntrTypes.ID = NVO_Containers.TypeID " +
                "where BkgID = NVO_Booking.Id and OnboardStatus = 1),0) as BTues, " +
                "isnull((select sum(TEUS) from NVO_Containers inner join NVO_BLContainer on NVO_BLContainer.CntrID = NVO_Containers.ID " +
                "inner join NVO_tblCntrTypes on NVO_tblCntrTypes.ID = NVO_Containers.TypeID " +
                "where BkgID = NVO_Booking.Id and OnboardStatus = 2),0) as NTues from NVO_Booking  where intStatus = 2 and " +
                "VesselID = " + Data.VesselID + " and VoyageID= " + Data.VoyageID + " ";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, " ");

        }


        public List<MyVesselLoadCnfrm> GetVesselLoadCnfrmViewlist1(MyVesselLoadCnfrm Data)
        {
            DataTable dt = GetVesselLoadCnfrmViewlist1values(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVesselCnFrm1.Add(new MyVesselLoadCnfrm
                {
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageName = dt.Rows[i]["VoyageNo"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),

                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),
                    SlotOperatorID = Int32.Parse(dt.Rows[i]["SlotOperatorID"].ToString()),

                    BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    BLID = Int32.Parse(dt.Rows[i]["BLID"].ToString()),
                    CntrID = Int32.Parse(dt.Rows[i]["CntrID"].ToString()),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    CargoType = dt.Rows[i]["CargoType"].ToString(),
                    PODName = dt.Rows[i]["PODName"].ToString(),
                    FPODName = dt.Rows[i]["FPODName"].ToString(),
                    PrincipleName = dt.Rows[i]["PrincipleName"].ToString(),
                    LoadStatus = dt.Rows[i]["LoadStatus"].ToString(),
                    LoadDate = dt.Rows[i]["LoadDate"].ToString(),
                    OnboardStatus = dt.Rows[i]["OnboardStatus"].ToString(),


                });
            }
            return ListVesselCnFrm1;
        }
        public DataTable GetVesselLoadCnfrmViewlist1values(MyVesselLoadCnfrm Data)
        {
            string strWhere = "";
            string _Query = " select VesselID,VoyageID,SlotOperatorID,NVO_Booking.Id as BkgID,NVO_BL.Id as BLID, NVO_BLContainer.CntrID as CntrID, BookingNo,NVO_BL.BLNumber,CntrNo,CntrType, " +
                            "(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_Booking.VesselID) as VesselName, " +
                            "(select top(1) VoyageNo from NVO_Voyage where NVO_Voyage.ID = NVO_Booking.VoyageID) as VoyageNo, " +
                            "convert(varchar,(select top(1) ETD from NVO_Voyage where ID = NVO_Booking.VoyageID),105) as ETD," +
                            " (select(select top(1) TEUS from NVO_tblCntrTypes where Id=NVO_Containers.TypeID) from NVO_Containers where NVO_Containers.ID=NVO_BLContainer.CntrID) as Tues, " +
                            " case when HazarOpt= 1 then 'GENERAL' ELSE 'HAZARDOUS' END AS CargoType,  " +
                            " (select top(1) PortName  from NVO_PortMaster where ID = DestinationID) as PODName, " +
                            " (select top(1) PortName  from NVO_PortMaster where ID = DischargePortID) as FPODName, " +
                            " (select top(1) LineName from NVO_PrincipalMaster where NVO_PrincipalMaster.ID=NVO_Booking.PrincipalID) as PrincipleName,'NA' as LoadStatus,'NA'as LoadDate, ISNULL(OnboardStatus,0) AS OnboardStatus " +
                            " from NVO_Booking " +
                            " inner join NVO_BL on NVO_BL.BkgID=NVO_Booking.ID " +
                            "inner join NVO_BLContainer on NVO_BLContainer.BLID = NVO_BL.ID and NVO_BLContainer.BkgID = NVO_Booking.ID " +
                            "inner join NVO_BLCargo on NVO_BLCargo.BkgID = NVO_BL.BkgID  and NVO_BLContainer.CntrID = NVO_BLCargo.CntrID  " +
                            " where intStatus = 2 and VesselID = " + Data.VesselID + " and VoyageID = " + Data.VoyageID + " ";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<MyVesselLoadCnfrm> InsertOnboardStatusValue(MyVesselLoadCnfrm Data)
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
                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    //string[] Array1 = Data.Items.TrimEnd(',').Split(',');
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " UPDATE NVO_BLContainer SET OnboardStatus=@OnboardStatus where BLID=@BLID and BkgID=@BkgID and CntrID=@CntrID ";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OnboardStatus", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[2]));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                    trans.Commit();
                    ListVesselCnFrm1.Add(new MyVesselLoadCnfrm
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListVesselCnFrm1;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListVesselCnFrm1.Add(new MyVesselLoadCnfrm
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListVesselCnFrm1;
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
