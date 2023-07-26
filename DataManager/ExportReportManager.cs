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
   public class ExportReportManager
    {
        List<MyExportReport> ListExReport = new List<MyExportReport>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public ExportReportManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        public List<MyExportReport> BLNoDropdownMaster(MyExportReport Data)
        {
           
            DataTable dt = GetBLNo();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListExReport.Add(new MyExportReport
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNo = dt.Rows[i]["BLNumber"].ToString()
                });
            }
            return ListExReport;
        }
        public DataTable GetBLNo()
        {
            string _Query = "select ID,BLNumber from NVO_BOL";
            return GetViewData(_Query, "");
        }

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

        #region anand
        #region Terminal Departure Report
        public List<MyExportReport> TerminalDepReportMaster(MyExportReport Data)
        {
            DataTable dt = GetTerminalDepPdfValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                ListExReport.Add(new MyExportReport
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    POL = dt.Rows[i]["POL"].ToString(),
                    VesselName = dt.Rows[i]["VeslName"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    ETAPOL = dt.Rows[i]["ETA"].ToString(),
                    ETDPOL = dt.Rows[i]["ETD"].ToString(),
                    NextPort = dt.Rows[i]["NextPort"].ToString(),
                    ETANextPort = dt.Rows[i]["NextPortETA"].ToString(),
                    VesselOperator = dt.Rows[i]["VesOperator"].ToString(),
                    ContOperator = dt.Rows[i]["ContainerOperator"].ToString(),

                });
            }
            return ListExReport;
        }

        public DataTable GetTerminalDepPdfValues(MyExportReport Data)
        {
            string _Query = "Select top(1) " +
                            " NVO_BOL.ID,POL,vesname.VesVoy as VeslName,NVO_VoyageDetails.VoyageNo,convert(varchar, ETA, 106) as ETA,convert(varchar, ETD, 106) as ETD,NVO_PortMaster.PortName as NextPort, convert(varchar, NextPortETA, 106) as NextPortETA,NVO_VoyPortDtls.VesOperator, " +
                            " (select(select top(1) CustomerName from NVO_CustomerMaster where ID = NVO_RatesheetSLOT.SlotOperator) from NVO_RatesheetSLOT where NVO_RatesheetSLOT.RRID = NVO_Booking.RRID)as SlotOper, " +
                            " (select(select top(1) CustomerName from NVO_CustomerMaster where NVO_CustomerMaster.ID = NVO_Containers.BoxOwnerID)from NVO_Containers where NVO_Containers.ID = NVO_Booking.RRID)as ContainerOperator, " +
                            " CntrNo,ServiceType,TSPORT,POD,FPOD,convert(varchar, PickupDate, 106) as PickupDate,BLNumber,Shipper " +
                            " from NVO_BOL " +
                            " inner join NVO_Booking on NVO_Booking.Id = NVO_BOL.BkgId " +
                            " left outer join NVO_BOLCntrPickup ON NVO_BOLCntrPickup.ID = NVO_BOL.BkgID " +
                            " inner join NVO_VoyageDetails On NVO_VoyageDetails.ID = NVO_Booking.VesVoyID " +
                            " inner join NVO_VoyPortDtls On NVO_VoyPortDtls.VoydtID = NVO_VoyageDetails.ID " +
                            " inner join NVO_PortMaster On NVO_PortMaster.ID = NVO_VoyPortDtls.NextPortID " +
                            " outer apply(select ID, (select top(1) VesselName from NVO_VesselMaster where ID = NVO_VoyageDetails.VesID)  as VesVoy from NVO_VoyageDetails " +
                            " where NVO_VoyageDetails.ID = NVO_Booking.VesVoyID )vesname ";
            return GetViewData(_Query, "");
        }
        #endregion
        #endregion
    }
}
