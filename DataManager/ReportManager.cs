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
   public class ReportManager
    {
        List<MyReportData> ReportList = new List<MyReportData>();
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public ReportManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region Public Method





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

        public List<MyReportData> DesAgencyByVesVoy(MyReportData Data)
        {
            List<MyReportData> ReportList = new List<MyReportData>();
            DataTable dt = GetAgencyMasterByVesVoy(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyReportData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Agency = dt.Rows[i]["AgencyName"].ToString(),
                    AgentID = Int32.Parse(dt.Rows[i]["AgentID"].ToString()),
                });
            }
            return ReportList;
        }

        public DataTable GetAgencyMasterByVesVoy(MyReportData Data)
        {
            string _Query = "select distinct NVO_AgencyMaster.ID,AgencyName,AgentID, VesVoy,VesVoyID from NVO_Booking " +
                            " inner join NVO_AgencyMaster On NVO_AgencyMaster.ID = NVO_Booking.DestinationAgentID " +
                            " where VesVoyID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyReportData> SlotOperatorByVesVoy(MyReportData Data)
        {
            List<MyReportData> ReportList = new List<MyReportData>();
            DataTable dt = GetOperatorValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyReportData
                {
                    ID = Int32.Parse(dt.Rows[i]["OperatorID"].ToString()),
                    VesOperator = dt.Rows[i]["Operator"].ToString(),
                });
            }
            return ReportList;
        }

        public DataTable GetOperatorValues(MyReportData Data)
        {
            DbConnection con = null;
            DbTransaction trans;

            con = _dbFactory.GetConnection();
            con.Open();
            trans = _dbFactory.GetTransaction(con);
            DbCommand Cmd = _dbFactory.GetCommand();
            Cmd.Connection = con;
            Cmd.Transaction = trans;
            string ServiceID = "0";
            int rowsAmount = 0;

            Cmd.CommandText = "SELECT COUNT(*) FROM  NVO_ServiceOpertaors where VoyageID = " + Data.VesVoyID;
            rowsAmount = (int)Cmd.ExecuteScalar();

            Cmd.CommandText = "SELECT ServiceID FROM  NVO_Voyage where ID = " + Data.VesVoyID;
            ServiceID = Cmd.ExecuteScalar().ToString();


            if (rowsAmount > 0)
            {
                string _Query = "select OperatorID,Operator from NVO_ServiceOpertaors where VoyageID = " + Data.VesVoyID;
                return GetViewData(_Query, "");
            }
            else
            {
                string _Query = "select OperatorID,Operator from NVO_ServiceOpertaors where ServicesID = " + ServiceID;
                return GetViewData(_Query, "");
            }

        }


        public List<MyReportData> BLNumberByVesVoy(MyReportData Data)
        {
            List<MyReportData> ReportList = new List<MyReportData>();
            DataTable dt = GetBLNumberByVesVoy(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyReportData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                });
            }
            return ReportList;
        }

        public DataTable GetBLNumberByVesVoy(MyReportData Data)
        {
            string _Query = "select BLNumber,NVO_BOL.ID  from NVO_BOL " +
                            " where AgencyID=" + Data.AgencyID + " and(select Top 1 VesvoyID from NVO_Booking where NVO_Booking.ID = NVO_BOL.BkgID) =" + Data.VesVoyID+ " and NVO_BOL.Status = 2";
            return GetViewData(_Query, "");
        }



    }
}
