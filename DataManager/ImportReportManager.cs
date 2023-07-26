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
    public class ImportReportManager
    {
        List<MyImportReport> ListExReport = new List<MyImportReport>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public ImportReportManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region

        public List<MyImportReport> DoReportViewValues(MyImportReport Data)
        {

            DataTable dt = GETDoReportViewValues();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListExReport.Add(new MyImportReport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DONo = dt.Rows[i]["DONo"].ToString(),
                    IssueDate = dt.Rows[i]["IssueDate"].ToString()
                });
            }
            return ListExReport;
        }
        public DataTable GETDoReportViewValues()
        {
            string _Query = "select * from NVO_ImpDeliveryOrder ";
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
