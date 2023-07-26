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
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace DataManager
{
    public class LogManager
    {
        List<MyLogData> ListLog = new List<MyLogData>();
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public LogManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        public List<MyLogData> GetLogDetails(MyLogData Data)
        {
            List<MyLogData> ListLog = new List<MyLogData>();
            DataTable dt = GetLogValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListLog.Add(new MyLogData
                {

                    UserName = dt.Rows[i]["CreatedBy"].ToString(),
                    Date = dt.Rows[i]["CreatedOn"].ToString(),
                });

            }
            return ListLog;
        }

        public DataTable GetLogValues(MyLogData Data)
        {
            //string _Query = "select ID,convert(varchar, CreatedOn, 103) as CreatedOn, (select top(1) UserName from NVO_UserDetails) as CreatedBy from NVO_LogDetails";
            string _Query = "select top(1) UserName as CreatedBy, Convert(varchar, CreatedOn, 103) as CreatedOn from NVO_LogDetails inner join NVO_UserDetails on NVO_UserDetails.Id = NVO_LogDetails.CreatedBy where PageName = '" + Data.PageName + "' and seqNo = " + Data.SeqNo + " and LoginID = " + Data.LoginID + " order by NVO_LogDetails.Id desc";
            return GetViewData(_Query, "");

        }



        public List<MyLogData> InsertLogMaster(MyLogData Data)
        {
            List<MyLogData> ListEnq = new List<MyLogData>();
            int result = 0;

            DbConnection con = null;
            DbTransaction trans;

            try
            {
                StringWriter stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(Data.GetType());
                serializer.Serialize(stringwriter, Data);
                Data.TextValues = stringwriter.ToString();

                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {
                    Cmd.CommandText = "INSERT INTO  NVO_LogDetails(PageName,CreatedOn,CreatedBy,SeqNo,LogInID,TextValues) " +
                             " values (@PageName,@CreatedOn,@CreatedBy,@SeqNo,@LogInID,@TextValues)";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PageName", Data.PageName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedBy", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedOn", (DateTime.Parse(System.DateTime.Now.Date.ToString()))));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SeqNo", Data.SeqNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LogInID", Data.LoginID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TextValues", Data.TextValues));
                    result = Cmd.ExecuteNonQuery();


                    trans.Commit();

                    return ListEnq;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListEnq.Add(new MyLogData { AlertMessage = ex.Message });
                    return ListEnq;
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





        #region get values
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
    }
}
