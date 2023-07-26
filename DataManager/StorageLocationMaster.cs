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

namespace DataManager
{
    public class StorageLocationMaster
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public StorageLocationMaster()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        List<MyStoragelocation> ListPortCodeBind = new List<MyStoragelocation>();
        List<mystoragelocationsave> ListStorageLocation = new List<mystoragelocationsave>();

        public List<MyStoragelocation> GetPortCodeMasterBindView(MyStoragelocation Data)
        {
            DataTable dt = GetPortcodes(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListPortCodeBind.Add(new MyStoragelocation

                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortCode = dt.Rows[i]["PortCode"].ToString()
                });
            }
            return ListPortCodeBind;
        }
        public DataTable GetPortcodes(MyStoragelocation Data)
        {
            string _Query = "select ID,PortCode from NVO_PortMaster where Status=1 order by ID ";
            return GetViewData(_Query, "");
        }


        public List<mystoragelocationsave> GetSaveStoragealocation(mystoragelocationsave Data)
        {


            DbConnection con = null;
            DbTransaction trans;
            DataTable dtchk = GetStoragealocationValues(Data);
            if (Data.ID == 0)
            {
                if (dtchk.Rows.Count >= 1)
                {

                    ListStorageLocation.Add(new mystoragelocationsave
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "Storage Locatin Type Already Exists"
                    });
                    return ListStorageLocation;

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
                    Cmd.CommandText = " IF((select count(*) from NVO_StorageLocationMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_StorageLocationMaster(SLTypeID,OfficeID,StorageLoc,StorageCode,PortID,Remarks,StatusID,DepotID) " +
                                     " values (@SLTypeID,@OfficeID,@StorageLoc,@StorageCode,@PortID,@Remarks,@StatusID,@DepotID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_StorageLocationMaster SET SLTypeID=@SLTypeID,OfficeID=@OfficeID,StorageLoc=@StorageLoc,StorageCode=@StorageCode,PortID=@PortID,Remarks=@Remarks,StatusID=@StatusID,DepotID=@DepotID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SLTypeID", Data.SLTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeID", Data.OfficeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StorageLoc", Data.StorageLoc));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StorageCode", Data.StorageCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", Data.PortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_StorageLocationMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListStorageLocation.Add(new mystoragelocationsave
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    }
                       );
                    return ListStorageLocation;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListStorageLocation.Add(new mystoragelocationsave
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListStorageLocation;
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
        public DataTable GetStoragealocationValues(mystoragelocationsave Data)
        {


            string _Query = "select * from NVO_StorageLocationMaster where StorageLoc = '" + Data.StorageLoc + "'";
            return GetViewData(_Query, "");
        }


        public List<mystoragelocationsave> GetStorageLocationList(mystoragelocationsave Data)
        {
            DataTable dt = GetStorageLocationListValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListStorageLocation.Add(new mystoragelocationsave
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StorageLocation = dt.Rows[i]["StorageLocation"].ToString(),
                    StorageLoc = dt.Rows[i]["StorageLoc"].ToString(),
                    StorageCode = dt.Rows[i]["StorageCode"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),

                });

            }
            return ListStorageLocation;
        }
        public DataTable GetStorageLocationListValues(mystoragelocationsave Data)
        {
            string strWhere = "";

            string _Query = " select ID,case when NVO_StorageLocationMaster.SLTypeID = 1 then 'Port' when NVO_StorageLocationMaster.SLTypeID = 2 then 'Depot' when NVO_StorageLocationMaster.SLTypeID = 3  then 'Customer' ELSE '' END as StorageLocation, " +
                            " StorageLoc,StorageCode,case when NVO_StorageLocationMaster.StatusID = 1 then 'Active' when NVO_StorageLocationMaster.StatusID = 2 then 'Inactive' ELSE '' END as StatusResult,OfficeID  " +
                            " from NVO_StorageLocationMaster ";

            if (Data.OfficeID.ToString() != "" && Data.OfficeID.ToString() != null && Data.OfficeID.ToString() != "0" && Data.OfficeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where NVO_StorageLocationMaster.OfficeID = " + Data.OfficeID + "";
                else
                    strWhere += " and NVO_StorageLocationMaster.OfficeID = " + Data.OfficeID + "";

            if (Data.SLTypeID.ToString() != "" && Data.SLTypeID.ToString() != "0" && Data.SLTypeID.ToString() != null && Data.SLTypeID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_StorageLocationMaster.SLTypeID = " + Data.SLTypeID.ToString();
                else
                    strWhere += " and NVO_StorageLocationMaster.SLTypeID = " + Data.SLTypeID.ToString();

            if (Data.StorageLoc != "")
                if (strWhere == "")
                    strWhere += _Query + " where NVO_StorageLocationMaster.StorageLoc like '%" + Data.StorageLoc + "%'";
                else
                    strWhere += " and NVO_StorageLocationMaster.StorageLoc like '%" + Data.StorageLoc + "%'";

            if (Data.StorageCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where NVO_StorageLocationMaster.StorageCode like '%" + Data.StorageCode + "%'";
                else
                    strWhere += " and NVO_StorageLocationMaster.StorageCode like '%" + Data.StorageCode + "%'";

            if (Data.StatusID.ToString() != "" && Data.StatusID.ToString() != "0" && Data.StatusID.ToString() != null && Data.StatusID.ToString() != "?")

                if (strWhere == "")
                    strWhere += _Query + " where NVO_StorageLocationMaster.StatusID = " + Data.StatusID.ToString();
                else
                    strWhere += " and NVO_StorageLocationMaster.StatusID = " + Data.StatusID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<mystoragelocationsave> GetStorageLocationEdit(mystoragelocationsave Data)
        {
            DataTable dt = GetStorageLocationEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListStorageLocation.Add(new mystoragelocationsave
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    SLTypeID = Int32.Parse(dt.Rows[i]["SLTypeID"].ToString()),
                    OfficeID = Int32.Parse(dt.Rows[i]["OfficeID"].ToString()),
                    StorageLoc = dt.Rows[i]["StorageLoc"].ToString(),
                    StorageCode = dt.Rows[i]["StorageCode"].ToString(),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    Remarks = (dt.Rows[i]["Remarks"].ToString()),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),
                    DepotID = Int32.Parse(dt.Rows[i]["DepotID"].ToString()),

                });
            }


            return ListStorageLocation;
        }

        public DataTable GetStorageLocationEditValues(mystoragelocationsave Data)
        {
            string _Query = "Select * from NVO_StorageLocationMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }



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
