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
    public class SOAManager
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public SOAManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        public List<MySOAData> SOAExportReportView(MySOAData Data)
        {
            List<MySOAData> ReportList = new List<MySOAData>();
            DataTable dt = GetSOAExportReportView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var RevenueTotal = decimal.Parse(dt.Rows[i]["OFTPreAmt"].ToString()) + decimal.Parse(dt.Rows[i]["OFTCollAmt"].ToString()) +
                    decimal.Parse(dt.Rows[i]["BAFPreAmt"].ToString()) + decimal.Parse(dt.Rows[i]["BAFCollAmt"].ToString()) + decimal.Parse(dt.Rows[i]["PCSISPSAmt"].ToString()) + decimal.Parse(dt.Rows[i]["DOFAmt"].ToString()) + decimal.Parse(dt.Rows[i]["THCPreAmt"].ToString()) + decimal.Parse(dt.Rows[i]["THCCollAmt"].ToString());
                var CostTotal = decimal.Parse(dt.Rows[i]["ExCommAmt"].ToString()) + decimal.Parse(dt.Rows[i]["THCCostAmt"].ToString()) +
                    decimal.Parse(dt.Rows[i]["FeederCostAmt"].ToString());
                var Total = RevenueTotal - CostTotal;
                // RevenueTotal = ;
                ReportList.Add(new MySOAData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOperator"].ToString(),
                    ETDDate = dt.Rows[i]["SailingDate"].ToString(),
                    BLNumber = dt.Rows[i]["BookingNo"].ToString(),
                    RevenuAmt = RevenueTotal.ToString(),
                    CostAmt = CostTotal.ToString(),
                    Total = Total.ToString()
                });
            }
            return ReportList;
        }
        public DataTable GetSOAExportReportView(MySOAData Data)
        {
            string strWhere = "";
            string _Query = "select *,cast(isnull((OFTPREPAID / (case when OFTPRECURR = 146 then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
            " = NVO_V_SOAExportALLDataReport.OFTPRECURR)  end)),0) as decimal(10, 2)) as OFTPreAmt ,cast(isnull((OFTCOLLECT / (case when OFTCOLLCURR = 146  then 1 else (select top(1) ExRate from  " +
            " NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_SOAExportALLDataReport.OFTCOLLCURR)  end)),0) as decimal(10, 2)) as OFTCollAmt, " +
          " cast(isnull((BAFPrepaid / (case when BAFPreCurrID = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
           " = NVO_V_SOAExportALLDataReport.BAFPreCurrID)  end)),0) as decimal(10, 2)) as BAFPreAmt , cast(isnull((BAFCollect / (case when BAFCollCurrID = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
          " = NVO_V_SOAExportALLDataReport.BAFCollCurrID)  end)),0) as decimal(10, 2)) as BAFCollAmt, cast(isnull((SURChargesColl / (case when SURChargesCurr = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
         " = NVO_V_SOAExportALLDataReport.SURChargesCurr)  end)),0) as decimal(10, 2)) as PCSISPSAmt, cast(isnull((DOFCharge / (case when DOFCurr = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
         " = NVO_V_SOAExportALLDataReport.THCPreCurr)  end)),0) as decimal(10, 2)) as DOFAmt, cast(isnull((THCPrepid / (case when DOFCurr = 146  then 1 else (select top(1) ExRate from  " +
         " NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_SOAExportALLDataReport.THCCollCurr)  end)),0) as decimal(10, 2)) as THCPreAmt, " +
      " cast(isnull((THCColl / (case when DOFCurr = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_SOAExportALLDataReport.THCCollCurr)  end)),0) as decimal(10, 2)) as THCCollAmt, " +
      " cast(isnull((EXCOMM / (case when EXCOMMCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_SOAExportALLDataReport.EXCOMMCurrId)  end)),0) as decimal(10, 2)) as ExCommAmt, " +
      " cast(isnull((THCCost / (case when THCCostCurr = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
     " = NVO_V_SOAExportALLDataReport.THCCostCurr)  end)),0) as decimal(10, 2)) as THCCostAmt, cast(isnull((FeederCost / (case when FeederCostCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
     " = NVO_V_SOAExportALLDataReport.FeederCostCurrId)  end)),0) as decimal(10, 2)) as FeederCostAmt from NVO_V_SOAExportALLDataReport ";

            if (Data.DtFrom != "" && Data.DtFrom != "undefined" || Data.DtTo != "" && Data.DtTo != "undefined")
                if (strWhere == "")
                    strWhere += _Query + " WHERE ConfirmDate between '" + Data.DtFrom + "' and '" + Data.DtTo + "'";
                else
                    strWhere += "  and ConfirmDate between '" + Data.DtFrom + "' and '" + Data.DtTo + "'";

            if (Data.AgencyID != "" && Data.AgencyID != "0" && Data.AgencyID != null && Data.AgencyID != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where AgentID=" + Data.AgencyID;
                else
                    strWhere += " and AgentID =" + Data.AgencyID;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }

        public List<MySOAData> SOAImportReportView(MySOAData Data)
        {
            List<MySOAData> ReportList = new List<MySOAData>();
            DataTable dt = GetSOAImportReportView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var RevenueTotal = decimal.Parse(dt.Rows[i]["OFTPreAmt"].ToString()) + decimal.Parse(dt.Rows[i]["OFTCollAmt"].ToString()) +
                    decimal.Parse(dt.Rows[i]["BAFPreAmt"].ToString()) + decimal.Parse(dt.Rows[i]["BAFCollAmt"].ToString()) + decimal.Parse(dt.Rows[i]["PCSISPSAmt"].ToString()) + decimal.Parse(dt.Rows[i]["DOFAmt"].ToString()) + decimal.Parse(dt.Rows[i]["THCPreAmt"].ToString()) + decimal.Parse(dt.Rows[i]["THCCollAmt"].ToString());
                var CostTotal = decimal.Parse(dt.Rows[i]["ICommAmt"].ToString()) + decimal.Parse(dt.Rows[i]["THCCostAmt"].ToString()) +
                    decimal.Parse(dt.Rows[i]["FeederCostAmt"].ToString());
                var Total = RevenueTotal - CostTotal;
                // RevenueTotal = ;
                ReportList.Add(new MySOAData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOperator"].ToString(),
                    ETA = dt.Rows[i]["ArrivalDate"].ToString(),
                    BLNumber = dt.Rows[i]["BookingNo"].ToString(),
                    RevenuAmt = RevenueTotal.ToString(),
                    CostAmt = CostTotal.ToString(),
                    Total = Total.ToString()
                });
            }
            return ReportList;
        }
        public DataTable GetSOAImportReportView(MySOAData Data)
        {
            string strWhere = "";
            string _Query = "select *,cast(isnull((OFTPREPAID / (case when OFTPRECURR = 146 then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
            " = NVO_V_SOAImportALLDataReport.OFTPRECURR)  end)),0) as decimal(10, 2)) as OFTPreAmt ,cast(isnull((OFTCOLLECT / (case when OFTCOLLCURR = 146  then 1 else (select top(1) ExRate from  " +
            " NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_SOAImportALLDataReport.OFTCOLLCURR)  end)),0) as decimal(10, 2)) as OFTCollAmt, " +
          " cast(isnull((BAFPrepaid / (case when BAFPreCurrID = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
           " = NVO_V_SOAImportALLDataReport.BAFPreCurrID)  end)),0) as decimal(10, 2)) as BAFPreAmt , cast(isnull((BAFCollect / (case when BAFCollCurrID = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
          " = NVO_V_SOAImportALLDataReport.BAFCollCurrID)  end)),0) as decimal(10, 2)) as BAFCollAmt, cast(isnull((SURChargesColl / (case when SURChargesCurr = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
         " = NVO_V_SOAImportALLDataReport.SURChargesCurr)  end)),0) as decimal(10, 2)) as PCSISPSAmt, cast(isnull((DOFCharge / (case when DOFCurr = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
         " = NVO_V_SOAImportALLDataReport.THCPreCurr)  end)),0) as decimal(10, 2)) as DOFAmt, cast(isnull((THCPrepid / (case when DOFCurr = 146  then 1 else (select top(1) ExRate from  " +
         " NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_SOAImportALLDataReport.THCCollCurr)  end)),0) as decimal(10, 2)) as THCPreAmt, " +
      " cast(isnull((THCColl / (case when DOFCurr = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_SOAImportALLDataReport.THCCollCurr)  end)),0) as decimal(10, 2)) as THCCollAmt, " +
      " cast(isnull((ICOMM / (case when ICOMMCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_SOAImportALLDataReport.ICOMMCurrId)  end)),0) as decimal(10, 2)) as ICommAmt, " +
      " cast(isnull((THCCost / (case when THCCostCurr = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
     " = NVO_V_SOAImportALLDataReport.THCCostCurr)  end)),0) as decimal(10, 2)) as THCCostAmt, cast(isnull((FeederCost / (case when FeederCostCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id " +
     " = NVO_V_SOAImportALLDataReport.FeederCostCurrId)  end)),0) as decimal(10, 2)) as FeederCostAmt from NVO_V_SOAImportALLDataReport ";

            if (Data.DtFrom != "" && Data.DtFrom != "undefined" || Data.DtTo != "" && Data.DtTo != "undefined")
                if (strWhere == "")
                    strWhere += _Query + " WHERE ConfirmDate between '" + Data.DtFrom + "' and '" + Data.DtTo + "'";
                else
                    strWhere += "  and ConfirmDate between '" + Data.DtFrom + "' and '" + Data.DtTo + "'";

            if (Data.AgencyID != "" && Data.AgencyID != "0" && Data.AgencyID != null && Data.AgencyID != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where AgentID=" + Data.AgencyID;
                else
                    strWhere += " and AgentID =" + Data.AgencyID;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
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
