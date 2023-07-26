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
    public class SlotManager
    {
        List<MyVoyage> ListVoyage = new List<MyVoyage>();
        List<MySLotManagement> ListSlot = new List<MySLotManagement>();
        List<MyVOA> ListVOA = new List<MyVOA>();
        List<MySlotRecords> ListSlotRecord = new List<MySlotRecords>();
        List<MySlotAttach> ListSlotAtt = new List<MySlotAttach>();
        List<LoadSlotInit> ListSlotinit = new List<LoadSlotInit>();
        List<MyVoyageDetails> ListVoyageDtls = new List<MyVoyageDetails>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method

        public SlotManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region Slot Master

        public List<MySLotManagement> GetSlotMaster(MySLotManagement Data)
        {
            DataTable dt = GetSlotValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListSlot.Add(new MySLotManagement
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    Voyage = dt.Rows[i]["Voyage"].ToString(),
                    // POD = dt.Rows[i][" POD"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    // Sailing =dt.Rows[i]["Sailing"].ToString(),
                    Teus = dt.Rows[i]["TEUS"].ToString(),
                    // VOA = dt.Rows[i]["VOA"].ToString(),
                    MT = dt.Rows[i]["MT"].ToString(),
                    Booking = dt.Rows[i]["Booking"].ToString(),
                    Pickup = dt.Rows[i]["Pickup"].ToString(),
                    GateIn = dt.Rows[i]["GateIn"].ToString(),
                    LoadOut = dt.Rows[i]["LoadOut"].ToString()
                });

            }
            return ListSlot;
        }
        public List<MySlotRecords> GetSpacePlanning(MySlotRecords Data)
        {
            DataTable dt = GetSlotPlanning(Data);
            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListSlotRecord.Add(new MySlotRecords
                    {
                        ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                        VOA = dt.Rows[i]["VOA"].ToString(),
                        Tues = dt.Rows[i]["TEUS"].ToString(),
                        MT = dt.Rows[i]["MT"].ToString(),
                        Notes = dt.Rows[i]["Notes"].ToString()
                        //Filenam=" "

                    });

                }
                return ListSlotRecord;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<MySLotManagement> SlotMgtDtlsRemoveValues(MySLotManagement Data)
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

                    Cmd.CommandText = "Delete from NVO_SlotMgmtDtls where SID=" + Data.SID;
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListSlot.Add(new MySLotManagement
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Deleted Successfully"
                    });
                    return ListSlot;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListSlot.Add(new MySLotManagement
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListSlot;
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

        public List<MySLotManagement> SlotMgtDtlsInsertAttachment(MySLotManagement Data)
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

                    Cmd.CommandText = "Update NVO_SlotMgmtDtls set Attachfile=@Attachfile where SID=" + Data.SID;
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Attachfile", Data.Attachfile));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListSlot.Add(new MySLotManagement
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Uploaded Successfully"
                    });
                    return ListSlot;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListSlot.Add(new MySLotManagement
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListSlot;
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

        public DataTable GetVoyageExValues(MySlotRecords Data)
        {

            string _Query = "select * from NVO_SlotMgmt WHERE VoyageID = " + Data.VoyageID;

            return GetViewData(_Query, "");

        }
        #endregion
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
                    cmd.CommandTimeout = 180;
                    //  DbDataAdapter adapter = new SqlDataAdapter(Query, con.ConnectionString);
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

        public DataTable GetViewPlanning(string Query, string CmdType)
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
                    //  int result = cmd.ExecuteNonQuery();
                    //    DbDataAdapter adapter = _dbFactory.GetAdapter();

                    DbDataAdapter adapter = new SqlDataAdapter(Query, con.ConnectionString);
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

        public DataTable GetSlotValues(MySLotManagement Data)
        {
            string strWhere = "";



            string _Query = "Select ID,(select top 1 VesselName from NVO_VesselMaster WHERE ID=SM.VesselID) as VesselName, " +
                            " (select top 1 VoyageNo from NVO_Voyage WHERE ID = SM.VoyageID) as Voyage, " +
                            " convert(varchar, (select top 1 ETA from NVO_Voyage WHERE ID = SM.VoyageID), 105) as ETA , convert(varchar, (select top 1 ETD from NVO_Voyage WHERE ID = SM.VoyageID), 105)  as ETD, " +
                            " (select top 1 sum(TEUS) from NVO_SlotMgmtDtls WHERE SlotMgmtID = SM.ID) TEUS, " +
                            " (select top 1 sum(MT) from NVO_SlotMgmtDtls WHERE SlotMgmtID = SM.ID) MT, " +
                            " case when (select top 1 ATD from NVO_Voyage WHERE ID = SM.VoyageID) > 0  then 'Sailed' else 'Pending' end as Sailing," +
                            " (select top 1 Count(ID) from NVO_Booking where VesselID= SM.VesselID and VoyageID= SM.VoyageID) as Booking," +
                            " isnull((select top 1 (select Count(ID) from NVO_ContainerTxns where StatusCodeID= 5 and BLNumber= NVO_Booking.ID) from NVO_Booking " +
                            " where  VesselID= SM.VesselID and VoyageID= SM.VoyageID),0) as  Pickup," +
                            " isnull((select top 1 (select Count(ID) from NVO_ContainerTxns where StatusCodeID= 9 and BLNumber= NVO_Booking.ID) from NVO_Booking " +
                            " where  VesselID= SM.VesselID and VoyageID= SM.VoyageID),0) as GateIn, " +
                            " isnull((select top 1 (select top 1 Count(ID) from NVO_ContainerTxns where StatusCodeID= 11 and BLNumber= NVO_Booking.ID) from NVO_Booking " +
                            " where  VesselID= SM.VesselID and VoyageID= SM.VoyageID),0) as LoadOut " +
                            " FROM NVO_SlotMgmt SM ";

            if (Data.VoyageID.ToString() != "" && Data.VoyageID.ToString() != null && Data.VoyageID.ToString() != "0" && Data.VoyageID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where SM.VoyageID =" + Data.VoyageID.ToString() + "";
                else
                    strWhere += " and SM.VoyageID =" + Data.VoyageID.ToString() + "";

            if (Data.ETAfrom != "" && Data.ETAto != "")
                if (strWhere == "")
                    strWhere += _Query + " where (select top 1 ETA from NVO_Voyage WHERE ID = SM.VoyageID) between convert(smalldatetime,'" + Data.ETAfrom + "',103) and convert(smalldatetime,'" + Data.ETAto + "',102)";
                else
                    strWhere += " and (select top 1 ETA from NVO_Voyage WHERE ID = SM.VoyageID) between convert(smalldatetime,'" + Data.ETAfrom + "',103) and convert(smalldatetime,'" + Data.ETAto + "',102)";

            if (Data.ETDfrom != "" && Data.ETDto != "")
                if (strWhere == "")
                    strWhere += _Query + " where (select top 1 ETD from NVO_Voyage WHERE ID = SM.VoyageID) between convert(smalldatetime,'" + Data.ETDfrom + "',103) and convert(smalldatetime,'" + Data.ETDto + "',102)";
                else
                    strWhere += " and (select top 1 ETD from NVO_Voyage WHERE ID = SM.VoyageID) between convert(smalldatetime,'" + Data.ETDfrom + "',102) and convert(smalldatetime,'" + Data.ETDto + "',102)";


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " Order By SM.ID Desc ", "");
        }

        public DataTable GetSlotPlanning(MySlotRecords Data)
        {
            string strWhere = "";

            string _Query = "select ID,VOA,Teus,MT,Notes from  NVO_VOADetails where vesselname='" + Data.VesselName + "' and voyage='" + Data.Voyage + "'";


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }

        public DataTable GetVoyageList(MyVoyage Data)
        {

            string _Query = "select ID,((select top 1 VesselName from NVO_VesselMaster where ID=NVO_Voyage.VesselID)+'-'+(VoyageNo)) As Voyage from NVO_Voyage WHERE VesselID = " + Data.VesID;

            return GetViewData(_Query, "");

        }
        public DataTable GetVoyageMasterList(MyVoyage Data)
        {

            string _Query = "select ID,((select top 1 VesselName from NVO_VesselMaster where ID=NVO_Voyage.VesselID)+'-'+(VoyageNo)) As Voyage from NVO_Voyage ";

            return GetViewData(_Query, "");

        }

        public DataTable GetVOAList(MyVOA Data)
        {


            string _Query = "select CID,(CustomerName +'-'+ Branch) AS VOA  from NVO_CusBranchLocation inner join NVO_CustomerMaster on NVO_CustomerMaster.ID=NVO_CusBranchLocation.CustomerID " +
                             " INNER JOIN NVO_CusBusinessTypes ON  NVO_CusBusinessTypes.CustomerID = NVO_CustomerMaster.ID " +
                             "  WHERE NVO_CusBusinessTypes.BussTypes = 8 ";


            return GetViewData(_Query, "");

        }
        public List<MyVoyage> GetVoyageMasterDropDown(MyVoyage Data)
        {
            DataTable dt = GetVoyageList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyage.Add(new MyVoyage
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Voyage = dt.Rows[i]["Voyage"].ToString()

                });
            }


            return ListVoyage;
        }

        public List<MyVoyage> GetVoyageBindMaster(MyVoyage Data)
        {
            DataTable dt = GetVoyageMasterList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyage.Add(new MyVoyage
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Voyage = dt.Rows[i]["Voyage"].ToString()

                });
            }


            return ListVoyage;
        }

        public List<MySLotManagement> GetBindVoyageETAETD(MySLotManagement Data)
        {
            DataTable dt = GetBindVoyageETAETDValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListSlot.Add(new MySLotManagement
                {

                    ETA = dt.Rows[i]["ETADt"].ToString(),
                    ETD = dt.Rows[i]["ETDDt"].ToString(),

                });
            }


            return ListSlot;
        }

        public DataTable GetBindVoyageETAETDValues(MySLotManagement Data)
        {

            string _Query = "select convert(varchar, ETA, 23) as ETADt,convert(varchar, ETD, 23) as ETDDt,* from NVO_Voyage WHERE ID = " + Data.VoyageID;

            return GetViewData(_Query, "");

        }
        public List<MyVOA> GetVOAMasterDropDown(MyVOA Data)
        {
            DataTable dt = GetVOAList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVOA.Add(new MyVOA
                {

                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    VOA = dt.Rows[i]["VOA"].ToString()

                });
            }


            return ListVOA;
        }
        public List<MySlotRecords> insertSlotRecords(MySlotRecords Data)
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

                    Cmd.CommandText = "Update_NVO_VOADetails";
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@xID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@xVesselName", Data.VesselName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@xVoyage", Data.Voyage));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@xVOA", Data.VOA));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@xTeus", Data.Tues));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@xMT", Data.MT));
                    // Cmd.Parameters.Add(_dbFactory.GetParameter("@xfilenam", "1"));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@xNotes", Data.Notes));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_VOADetails')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListSlotRecord;
                }

                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListSlotRecord.Add(new MySlotRecords
                    {
                        ID = Data.ID,

                    });
                    return ListSlotRecord;
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
        public List<MySLotManagement> GetSlotRecord(MySLotManagement Data)
        {
            DataTable dt = GetSlotValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListSlot.Add(new MySLotManagement
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    Voyage = dt.Rows[i]["Voyage"].ToString(),
                    // POD = dt.Rows[i][" POD"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString(),
                    Sailing =dt.Rows[i]["Sailing"].ToString(),
                    Teus = dt.Rows[i]["TEUS"].ToString(),
                    // VOA = dt.Rows[i]["VOA"].ToString(),
                    MT = dt.Rows[i]["MT"].ToString(),
                    Booking = dt.Rows[i]["Booking"].ToString(),
                    Pickup = dt.Rows[i]["Pickup"].ToString(),
                    GateIn = dt.Rows[i]["GateIn"].ToString(),
                    LoadOut = dt.Rows[i]["LoadOut"].ToString()
                });

            }
            return ListSlot;
        }
        public List<MySlotAttach> insertslotAttachments(MySlotAttach Data)
        {

            //int r1 = 0;
            //int r2 = 0;
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
                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);

                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from temp whereID=@ID and filenam=@filenam)<=0) " +
                         " BEGIN " +
                         " INSERT INTO  temp(ID,filenam) " +
                                      " values (@ID,@filenam) " +
                        " END  " +
                        " ELSE " +
                        " UPDATE temp SET ID=@rID,filenam=@filenam where ID=@ID  ";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@filenam", CharSplit[0]));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                    trans.Commit();
                    ListSlotAtt.Add(new MySlotAttach { ID = Data.ID });
                    return ListSlotAtt;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListSlotAtt;
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

        public List<MySlotRecords> InsertSlotdetails(MySlotRecords Data)
        {

            List<MySlotRecords> List = new List<MySlotRecords>();
            //int r1 = 0;
            //int r2 = 0;
            DbConnection con = null;
            DbTransaction trans;

            DataTable dtchk = GetVoyageExValues(Data);
            if (Data.ID == 0)
            {
                if (dtchk.Rows.Count >= 1)
                {

                    ListSlotRecord.Add(new MySlotRecords
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "Voyage Already Exists"
                    });
                    return ListSlotRecord;

                }
            }
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
                    Cmd.CommandText = " IF((select count(*) from NVO_SlotMgmt where ID=@ID)<=0) " +
                              " BEGIN " +
                              " INSERT INTO  NVO_SlotMgmt(VesselID,VoyageID,UserID,CreatedOn) " +
                              " values (@VesselID,@VoyageID,@UserID,@CreatedOn) " +
                              " END  " +
                              " ELSE " +
                              " UPDATE NVO_SlotMgmt SET VesselID=@VesselID,UserID=@UserID,VoyageID=@VoyageID,CreatedOn=@CreatedOn where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselID", Data.VesID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Data.VoyageID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedOn", System.DateTime.Now));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_SlotMgmt')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());

                    }

                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_SlotMgmtDtls where SID=@SID AND SlotMgmtID=@SlotMgmtID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_SlotMgmtDtls(SlotMgmtID,PODID,POD,VslOperatorID,VslOperator,Teus,MT,Notes) " +
                                     " values (@SlotMgmtID,@PODID,@POD,@VslOperatorID,@VslOperator,@Teus,@MT,@Notes) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_SlotMgmtDtls SET SlotMgmtID=@SlotMgmtID,PODID=@PODID,POD=@POD,VslOperatorID=@VslOperatorID,VslOperator=@VslOperator,Teus=@Teus,MT=@MT,Notes=@Notes where SID=@SID and SlotMgmtID=@SlotMgmtID ";



                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotMgmtID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VslOperatorID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VslOperator", CharSplit[2].Trim()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PODID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@POD", CharSplit[4].Trim()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Teus", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MT", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Notes", CharSplit[7]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }




                    trans.Commit();
                    ListSlotRecord.Add(new MySlotRecords
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Record Saved Sucessfully"

                    });
                    return ListSlotRecord;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    List.Add(new MySlotRecords
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = ex.Message
                    });
                    return ListSlotRecord;
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
        public DataTable GetEditSlotLoadfMaster(LoadSlotInit Data)
        {

            string _Query = "select ID,VesselName,Voyage,VOA,POD,ETA=dbo.BritDate(ETA),ETD=dbo.britdate(ETD),SailingDt=dbo.BritDate(SailingDt),Tues=Teus,MT,filenam, Notes from NVO_VOADetails where ID=" + Data.ID;
            return GetViewData(_Query, "");

        }

        public DataTable GetExistingSlotLoad(MySlotRecords Data)
        {
            string _Query = "select * from NVO_SlotMgmt where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        public DataTable GetViewExistingSlotDtls(MySLotManagement Data)
        {
            string _Query = "select * from NVO_SlotMgmtDtls where SlotMgmtID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MySlotRecords> ViewExistingSlotLoad(MySlotRecords Data)
        {
            List<MySlotRecords> ViewList = new List<MySlotRecords>();
            DataTable dt = GetExistingSlotLoad(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MySlotRecords
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageID = Int32.Parse(dt.Rows[i]["VoyageID"].ToString()),


                });

            }
            return ViewList;
        }
        public List<MySLotManagement> ViewExistingSlotDtls(MySLotManagement Data)
        {
            List<MySLotManagement> ViewList = new List<MySLotManagement>();
            DataTable dt = GetViewExistingSlotDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MySLotManagement
                {
                    SID = Int32.Parse(dt.Rows[i]["SID"].ToString()),
                    VOA = dt.Rows[i]["VslOperator"].ToString(),
                    VOAID = Int32.Parse(dt.Rows[i]["VslOperatorID"].ToString()),
                    POD = dt.Rows[i]["POD"].ToString(),
                    PODID = Int32.Parse(dt.Rows[i]["PODID"].ToString()),
                    Teus = dt.Rows[i]["Teus"].ToString(),
                    MT = dt.Rows[i]["MT"].ToString(),
                    Notes = dt.Rows[i]["Notes"].ToString(),
                    FileName = dt.Rows[i]["AttachFile"].ToString()
                });

            }
            return ViewList;
        }
        public List<MySlotRecords> InsertSlotMasterdetails(MySlotRecords Data)
        {
            List<MySlotRecords> List = new List<MySlotRecords>();
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


                    if (Data.Items != null)
                    {
                        string[] Array3 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array3.Length; i++)
                        {
                            var CharSplit = Array3[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_VOADetails where ID=@ID) <=0) " +
                             " BEGIN " +
                             " INSERT INTO  NVO_VOADetails(ID,VesselName,Voyage,VOA,Teus,MT,Notes) " +
                             " values(@ID,@VesselName,@Voyage,@VOA,@Tues,@MT,@Notes)  " +
                             " END  " +
                             " ELSE " +
                             " UPDATE NVO_VOADetails SET Teus=@Tues,MT=@MT,Notes=@Notes" +
                             "  where ID=@ID ";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                            //Cmd.Parameters.Add(_dbFactory.GetParameter("@PID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselName", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Voyage", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VOA", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Teus", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@MT", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Notes", CharSplit[6]));

                            int result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }
                    trans.Commit();
                    List.Add(new MySlotRecords
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Record Saved Sucessfully"

                    }); ;
                    return ListSlotRecord;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    List.Add(new MySlotRecords
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = ex.Message
                    });
                    return ListSlotRecord;
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


        public List<LoadSlotInit> EditSlotMaster(LoadSlotInit Data)
        {
            List<LoadSlotInit> ViewList = new List<LoadSlotInit>();
            DataTable dt = GetEditSlotLoadfMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new LoadSlotInit
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    Voyage = dt.Rows[i]["Voyage"].ToString(),
                    VOA = dt.Rows[i]["VOA"].ToString(),
                    Tues = dt.Rows[i]["Tues"].ToString(),
                    MT = dt.Rows[i]["MT"].ToString(),
                    Notes = dt.Rows[i]["Notes"].ToString(),

                });

            }
            return ListSlotinit;
        }


        public List<MySLotManagement> GetSlotMgtCountDtlsView(MySLotManagement Data)
        {
            DataTable dt = GetSlotMgtCountDtlsViewValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListSlot.Add(new MySLotManagement
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Sailing = dt.Rows[i]["Sailing"].ToString(),
                    Booking = dt.Rows[i]["Booking"].ToString(),
                    Pickup = dt.Rows[i]["Pickup"].ToString(),
                    GateIn = dt.Rows[i]["GateIn"].ToString(),
                    LoadOut = dt.Rows[i]["LoadOut"].ToString(),
                });
            }


            return ListSlot;
        }

        public DataTable GetSlotMgtCountDtlsViewValues(MySLotManagement Data)
        {

            string _Query = "Select ID,  case when (select top 1 ATD from NVO_Voyage WHERE ID = SM.VoyageID) > 0  then" +
                " 'Sailed' else 'Pending' end as Sailing, (select Count(ID) from NVO_Booking where VesselID= SM.VesselID and" +
                " VoyageID= SM.VoyageID) as Booking,isnull((select  TOP (1) (select Count(ID) from NVO_ContainerTxns where StatusCodeID= 5 and BLNumber= NVO_Booking.ID) " +
                "from NVO_Booking where  VesselID= SM.VesselID and VoyageID= SM.VoyageID),0) as  Pickup," +
                " isnull((select TOP (1) (select Count(ID) from NVO_ContainerTxns where StatusCodeID= 9 and BLNumber= NVO_Booking.ID) from NVO_Booking " +
                " where  VesselID= SM.VesselID and VoyageID= SM.VoyageID),0) as GateIn, " +
                " isnull((select TOP (1) (select Count(ID) from NVO_ContainerTxns where StatusCodeID= 11 and BLNumber= NVO_Booking.ID) from NVO_Booking  where " +
                "  VesselID= SM.VesselID and VoyageID= SM.VoyageID),0) as LoadOut  " +
                " FROM NVO_SlotMgmt SM  where SM.ID= " + Data.ID;

            return GetViewData(_Query, "");

        }



    }
}
