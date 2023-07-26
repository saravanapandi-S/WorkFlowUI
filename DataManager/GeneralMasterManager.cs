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
   public class GeneralMasterManager
    {

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public GeneralMasterManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        public List<MyGeneralMaster> InsertGeneralMaster(MyGeneralMaster Data)
        {
            List<MyGeneralMaster> ListGeneralMaster = new List<MyGeneralMaster>();

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

                    Cmd.CommandText = " IF((select count(*) from NVO_GeneralMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_GeneralMaster(RefCode,GeneralName,Status,SeqNo) " +
                                     " values (@RefCode,@GeneralName,@Status,@SeqNo) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_GeneralMaster SET RefCode=@RefCode,GeneralName=@GeneralName,Status=@Status,SeqNo=@SeqNo where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RefCode", Data.RefCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GeneralName", Data.GeneralName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.StatusN));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SeqNo", Data.SeqNo));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_GeneralMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ListGeneralMaster;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListGeneralMaster;
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

        public List<MyGeneralMaster> GeneralMasterView(MyGeneralMaster Data)
        {
            List<MyGeneralMaster> ListGeneralMaster = new List<MyGeneralMaster>();
            DataTable dt = GetGeneralMasterValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListGeneralMaster.Add(new MyGeneralMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RefCode = dt.Rows[i]["RefCode"].ToString(),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString(),
                    StatusV = dt.Rows[i]["StatusV"].ToString(),
                    SeqNo = dt.Rows[i]["SeqNo"].ToString()
                });

            }
            return ListGeneralMaster;
        }
        public DataTable GetGeneralMasterValues(MyGeneralMaster Data)
        {
            string strWhere = "";

            string _Query = " select case when Status=1 then 'Active' else 'Inactive' end as StatusV, * from NVO_GeneralMaster";

            if (Data.RefCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where RefCode like '%" + Data.RefCode + "%'";
                else
                    strWhere += " and RefCode like '%" + Data.RefCode + "%'";

            if (Data.GeneralName != "")
                if (strWhere == "")
                    strWhere += _Query + " where GeneralName like '%" + Data.GeneralName + "%'";
                else
                    strWhere += " and GeneralName like '%" + Data.GeneralName + "%'";

            if (Data.Status.ToString() == "1")
                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();


            if (strWhere == "")
                strWhere = _Query + " Order By SeqNo ";

            return GetViewData(strWhere, "");

        }

        public List<MyGeneralMaster> GetGeneralMasterEditRecord(MyGeneralMaster Data)
        {
            List<MyGeneralMaster> ListGeneralMaster = new List<MyGeneralMaster>();
            DataTable dt = GetGeneralMasterRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (bool.Parse(dt.Rows[i]["Status"].ToString()) != true)
                {
                    St = 0;
                }
                else
                {
                    St = 1;
                }

                ListGeneralMaster.Add(new MyGeneralMaster
                {


                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RefCode = dt.Rows[i]["RefCode"].ToString(),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString(),
                    SeqNo = dt.Rows[i]["SeqNo"].ToString(),
                    StatusN = St
                });
            }


            return ListGeneralMaster;
        }
        public DataTable GetGeneralMasterRecord(MyGeneralMaster Data)
        {
            string _Query = "Select * from NVO_GeneralMaster where ID=" + Data.ID;
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
