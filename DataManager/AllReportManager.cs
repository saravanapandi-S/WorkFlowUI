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
   public class AllReportManager
    {
        List<AllReportData> ReportList = new List<AllReportData>();
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public AllReportManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

       

        #region Muthu
        public List<AllReportData> MISReportView(AllReportData Data)
        {
            List<AllReportData> ReportList = new List<AllReportData>();
            DataTable dt = GetMISReportview(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new AllReportData
                {
                    AgentID = Int32.Parse(dt.Rows[i]["AgentID"].ToString()),
                    Agency = dt.Rows[i]["AgencyName"].ToString(),
                    NoofCntr20 = dt.Rows[i]["Numbercntr20"].ToString(),
                    NoofCntr40 = dt.Rows[i]["Numbercntr40"].ToString(),
                    NoofShipment = dt.Rows[i]["NoofShipment"].ToString(),
                    RevenuAmt = dt.Rows[i]["TotalRevenue"].ToString(),
                    CostAmt = dt.Rows[i]["TotalCost"].ToString(),
                    ProfitAmt = dt.Rows[i]["Profit"].ToString()

                });
            }
            return ReportList;
        }


        public DataTable GetMISReportview(AllReportData Data)
        {
            string strWhere = "";
            string _Query = " select distinct AgentID,AgencyName,NoofShipment,sum(Size20) as Numbercntr20,sum(size40) as Numbercntr40, " +
                            " sum(OFTt) + sum(BAFt) + sum(SURCHARGESt) + sum(LOADTHCt) + sum(DESTTHCt) + sum(HLDTPTt) + sum(MISCt) as TotalRevenue, " +
                            " sum(SlotAmtt) + sum(TSCOSTt) + sum(EXCOMMt) + sum(ICOMMt) + sum(TSCOMMt) + sum(LOADPHCt) + sum(DESTPHCt) + sum(MISCCOSTt) as TotalCost, " +
                            " (sum(OFTt) + sum(BAFt) + sum(SURCHARGESt) + sum(LOADTHCt) + sum(DESTTHCt) + sum(HLDTPTt) + sum(MISCt)) - (sum(SlotAmtt) + sum(TSCOSTt) + sum(EXCOMMt) + sum(ICOMMt) + sum(TSCOMMt) + sum(LOADPHCt) + sum(DESTPHCt) + sum(MISCCOSTt)) as Profit " +
                            " from NVO_v_MISReportCustomerTotal ";

            if (Data.AgentID.ToString() != null && Data.AgentID.ToString() != "0")
            {
                if (strWhere == "")
                    strWhere += _Query + " where AgentID=" + Data.AgentID;
                else
                    strWhere += " and AgentID=" + Data.AgentID;
            }

            if (Data.FromDate != "" && Data.FromDate != "undefined" || Data.ToDate != "" && Data.ToDate != "undefined")
                if (strWhere == "")
                    strWhere += _Query + " Where ConfirmDate between '" + Data.FromDate + "' and '" + Data.ToDate + "'";
                else
                    strWhere += "  and ConfirmDate between '" + Data.FromDate + "' and '" + Data.ToDate + "'";
           

            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere + " group by AgentID,AgencyName,NoofShipment", "");
        }



        public List<AllReportData> MISReportViewALL(AllReportData Data)
        {
            List<AllReportData> ReportList = new List<AllReportData>();
            DataTable dt = GetMISReportviewALL(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal RevenusAmt = decimal.Parse(dt.Rows[i]["OFTt"].ToString()) + decimal.Parse(dt.Rows[i]["BAFt"].ToString()) + decimal.Parse(dt.Rows[i]["SURCHARGESt"].ToString()) + decimal.Parse(dt.Rows[i]["LOADTHCt"].ToString()) + decimal.Parse(dt.Rows[i]["HLDTPTt"].ToString()) + decimal.Parse(dt.Rows[i]["MISCt"].ToString()) + decimal.Parse(dt.Rows[i]["DESTTHCt"].ToString());
                decimal CostAmt = 5 + decimal.Parse(dt.Rows[i]["SlotAmtt"].ToString()) + decimal.Parse(dt.Rows[i]["TSCOSTt"].ToString()) + decimal.Parse(dt.Rows[i]["EXCOMMt"].ToString()) + decimal.Parse(dt.Rows[i]["ICOMMt"].ToString()) + decimal.Parse(dt.Rows[i]["TSCOMMt"].ToString()) + decimal.Parse(dt.Rows[i]["LOADPHCt"].ToString()) + decimal.Parse(dt.Rows[i]["DESTPHCt"].ToString()) + decimal.Parse(dt.Rows[i]["MISCCOSTt"].ToString());



                ReportList.Add(new AllReportData
                {
                    AgentID = Int32.Parse(dt.Rows[i]["AgentID"].ToString()),
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RRID = dt.Rows[i]["RRID"].ToString(),
                    RRNo = dt.Rows[i]["RRNO"].ToString(),
                    // BLID= dt.Rows[i]["BLID"].ToString(),
                    //BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    TypeSize = dt.Rows[i]["TypeSize"].ToString(),
                    TerminalName = dt.Rows[i]["Terminal"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    TSPORT = dt.Rows[i]["TSPORT"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOperator"].ToString(),
                    Size20 = dt.Rows[i]["Size20"].ToString(),
                    Size40 = dt.Rows[i]["Size40"].ToString(),
                    SizeRF40 = dt.Rows[i]["SizeRF40"].ToString(),
                    SizeOT40 = dt.Rows[i]["SizeOT40"].ToString(),
                    LeasTerms = dt.Rows[i]["LeasTerms"].ToString(),

                    OFT = dt.Rows[i]["OFTt"].ToString(),
                    BAF = dt.Rows[i]["BAFt"].ToString(),
                    SURCHARGES = dt.Rows[i]["SURCHARGESt"].ToString(),
                    LOADTHC = dt.Rows[i]["LOADTHCt"].ToString(),
                    DESTTHC = dt.Rows[i]["DESTTHCt"].ToString(),
                    HLDTPT = dt.Rows[i]["HLDTPTt"].ToString(),
                    MISC = dt.Rows[i]["MISCt"].ToString(),

                    RevenuAmt = RevenusAmt.ToString(),

                    SlotAmt = dt.Rows[i]["SlotAmtt"].ToString(),
                    TSCOST = dt.Rows[i]["TSCOSTt"].ToString(),
                    EXCOMM = dt.Rows[i]["EXCOMMt"].ToString(),
                    ICOMM = dt.Rows[i]["ICOMMt"].ToString(),
                    TSCOMM = dt.Rows[i]["TSCOMMt"].ToString(),

                    LOADPHC = dt.Rows[i]["LOADPHCt"].ToString(),
                    DESTPHC = dt.Rows[i]["DESTPHCt"].ToString(),
                    MISCCOST = dt.Rows[i]["MISCCOSTt"].ToString(),
                    LOGCOST = "5",

                    COSTAmt = CostAmt.ToString(),
                    ProfitAmt = (RevenusAmt - CostAmt).ToString(),

                    ETDDate = dt.Rows[i]["ETDDate"].ToString()


                });
            }
            return ReportList;
        }


        public DataTable GetMISReportviewALL(AllReportData Data)
        {
            string strWhere = "";
            //string _Query = " select AgentID,Id,RRID,RRNO,BookingNo,POL,POD,FPOD,TSPORT,CntrNo,VesVoy,Terminal,SlotOperator,TypeSize,ETDDate,	" +
            //                " Size20,Size40,SizeRF40,SizeOT40,LeasTerms,OFT,OFTCURR,BAF,LOADTHC,LOADTHCCURR,DESTTHC,DESTTHCCURR,HLDTPT,MISC,MISCCCURR,SlotAmt,SlotCURR,	" +
            //                " DESPORTTHC,LOADPORTTHC,MISCCOST,OFTCURR,BAFCURR,SURCHARGES,SURCHARGESCURR,(OFT + BAF + SURCHARGES + LOADTHC + DESTTHC + HLDTPT + MISC ) as RevenuAmt, " +
            //                " TSCOST,TSCOSTCURR,EXCOMM,EXCOMMCURR,ICOMM,ICOMMCURR,TSCOMM,TSCOMMCURR ,LOADPHC,LOADPHCCURR,DESTPHC,DESTPHCCURR,MISCCOST,MISCCOSTCURR, " +
            //                " (TSCOST+EXCOMM+ICOMM+TSCOMM+LOADPHC+DESTPHC+MISCCOST) as COSTAmt, " +
            //                " ((OFT + BAF + SURCHARGES + LOADTHC + DESTTHC + HLDTPT + MISC ) - (TSCOST+EXCOMM+ICOMM+TSCOMM+LOADPHC+DESTPHC+MISCCOST)) as ProfitAmt,Commodity from NVO_V_MiSViewALLDataReport";

            string _Query = " select AgentID,Id,RRID,RRNO,BookingNo,POL,POD,FPOD,TSPORT,CntrNo,VesVoy,Terminal,SlotOperator,TypeSize,ETDDate,	 " +
                            " Size20,Size40,SizeRF40,SizeOT40,LeasTerms,OFT,OFTCURR,BAF,LOADTHC,LOADTHCCURR,DESTTHC,DESTTHCCURR,HLDTPT,MISC,MISCCCURR,SlotAmt,SlotCURR,	 " +
                            " DESPORTTHC,LOADPORTTHC,MISCCOST,OFTCURR,BAFCURR,SURCHARGES,SURCHARGESCURR, " +
                            " (OFT + BAF + SURCHARGES + LOADTHC + DESTTHC + HLDTPT + MISC) as RevenuAmt, TSCOST,TSCOSTCURR,EXCOMM,EXCOMMCURR,ICOMM,ICOMMCURR,TSCOMM,TSCOMMCURR ,LOADPHC,LOADPHCCURR,DESTPHC,DESTPHCCURR,MISCCOST,MISCCOSTCURR, " +
                            " (TSCOST + EXCOMM + ICOMM + TSCOMM + LOADPHC + DESTPHC + MISCCOST) as COSTAmt, ((OFT + BAF + SURCHARGES + LOADTHC + DESTTHC + HLDTPT + MISC) - (TSCOST + EXCOMM + ICOMM + TSCOMM + LOADPHC + DESTPHC + MISCCOST)) as ProfitAmt," +
                            " Commodity,OFTCurrId,BAFCurrId,SURCHARGESCurrId,LOADTHCCurrId,DESTTHCCurrId,HLDTPTCCurrId,MISCCcurrId, " +
                            " TSCOSTCurrId,EXCOMMCurrId,ICOMMCurrId,TSCOMMCurrId,LOADPHCCurrId,DESTPHCCurrId,MISCCOSTCurrId, " +
                            " cast(isnull((OFT / (case when OFTCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.OFTCurrId)  end)),0) as decimal(10,2)) as OFTt," +
                            " cast(isnull((BAF / (case when BAFCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.BAFCurrId)  end)),0) as decimal(10,2)) as BAFt, " +
                            " cast(isnull((SURCHARGES / (case when SURCHARGESCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.SURCHARGESCurrId)  end)),0) as decimal(10,2))  as SURCHARGESt, " +
                            " cast(isnull((LOADTHC/ (case when LOADTHCCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.LOADTHCCurrId)  end)),0) as decimal(10,2))  as LOADTHCt, " +
                            " cast(isnull((DESTTHC / (case when DESTTHCCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.DESTTHCCurrId)  end)),0) as decimal(10,2))  as DESTTHCt, " +
                            " cast(isnull((HLDTPT / (case when HLDTPTCCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.HLDTPTCCurrId)  end)),0) as decimal(10,2))  as HLDTPTt, " +
                            " cast(isnull((MISC / (case when MISCCcurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.MISCCcurrId)  end)),0) as decimal(10,2)) as MISCt1, " +

                            " cast(isnull((SUV_MISC / (case when SUV_MISCCCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.SUV_MISCCCurrId)  end)),0)  + " +
                            " isnull((LOLO_MISC / (case when LOLO_MISCCCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.LOLO_MISCCCurrId)  end)),0)  + " +
                            " isnull((WASH_MISC / (case when WASH_MISCCCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.WASH_MISCCCurrId)  end)),0)  + " +
                            " isnull((CMC_MISC / (case when CMC_MISCCCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.CMC_MISCCCurrId)  end)),0) as decimal(10,2)) as MISCt, " +

                            " cast(isnull((SlotAmt / (case when SlotCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.SlotCurrId)  end)),0) as decimal(10,2)) as SlotAmtt," +
                            " cast(isnull((TSCOST / (case when TSCOSTCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.TSCOSTCurrId)  end)),0)  as decimal(10,2)) as TSCOSTt, " +
                            " cast(isnull((EXCOMM / (case when EXCOMMCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.EXCOMMCurrId)  end)),0) as decimal(10,2)) as EXCOMMt, " +
                            " cast(isnull((ICOMM / (case when ICOMMCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.ICOMMCurrId)  end)),0) as decimal(10,2)) as ICOMMt, " +
                            " cast(isnull((TSCOMM / (case when TSCOMMCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.TSCOMMCurrId)  end)),0) as decimal(10,2)) as TSCOMMt, " +
                            " cast(isnull((LOADPHC / (case when LOADPHCCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.LOADPHCCurrId)  end)),0)  as decimal(10,2)) as LOADPHCt, " +
                            " cast(isnull((DESTPHC / (case when DESTPHCCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.DESTPHCCurrId)  end)),0)  as decimal(10,2)) as DESTPHCt, " +
                            " cast(isnull((MISCCOST / (case when MISCCOSTCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.MISCCOSTCurrId)  end)),0)  as decimal(10,2)) as MISCCOSTt1, " +

                            " cast(isnull((SUV_MISCCOST / (case when SUV_MISCCOSTCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.SUV_MISCCOSTCurrId)  end)),0)  + " +
                            " isnull((LOLO_MISCCOST / (case when LOLO_MISCCOSTCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.LOLO_MISCCOSTCurrId)  end)),0)  + " +
                            " isnull((WASH_MISCCOST / (case when WASH_MISCCOSTCurrId = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_V_MiSViewALLDataReport.WASH_MISCCOSTCurrId)  end)),0) as decimal(10, 2)) as MISCCOSTt " +
                            " from NVO_V_MiSViewALLDataReport";







            if (Data.AgentID.ToString() != null && Data.AgentID.ToString() != "0")
            {
                if (strWhere == "")
                    strWhere += _Query + " where AgentID=" + Data.AgentID;
                else
                    strWhere += " and AgentID=" + Data.AgentID;
            }

            if (Data.SlotOperatorID.ToString() != null && Data.SlotOperatorID.ToString() != "?")
            {
                if (strWhere == "")
                    strWhere += _Query + " where SlotOperatorID=" + Data.SlotOperatorID;
                else
                    strWhere += " and SlotOperatorID=" + Data.SlotOperatorID;
            }


            if (Data.VesVoyID.ToString() != null && Data.VesVoyID.ToString() != "?")
            {
                if (strWhere == "")
                    strWhere += _Query + " where VesVoyID=" + Data.VesVoyID;
                else
                    strWhere += " and VesVoyID=" + Data.VesVoyID;
            }

            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere, "");
        }


        public List<AllReportData> MISReportSurcharge(AllReportData Data)
        {
            List<AllReportData> ReportList = new List<AllReportData>();
            DataTable dt = GetMISReportSurcharges(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new AllReportData
                {
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString(),
                    ManifRate = dt.Rows[i]["ManifRate"].ToString(),




                });
            }
            return ReportList;
        }

        public DataTable GetMISReportSurcharges(AllReportData Data)
        {
            string _Query = " select (select top(1) ChgCode from NVO_ChargeTB where NVO_ChargeTB.ID =NVO_BLCharges.ChargeCodeID) as ChargeCode, " +
                            " cast(isnull((ManifRate / (case when CurrencyID = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise where NVO_MISExRateCountrywise.Id = NVO_BLCharges.CurrencyID)  end)),0) as decimal(10, 2))  as ManifRate " +
                            " from NVO_BLCharges where ChargeCodeID in (select ID from NVO_ChargeTB where  ChargeGroupID = 233) and RRID = " + Data.RRID;
            return GetViewData(_Query, "");
        }


        public List<AllReportData> MIS_Misc_RevenuReport(AllReportData Data)
        {
            List<AllReportData> ReportList = new List<AllReportData>();
            DataTable dt = GetMIS_MISC_ChargesRevenus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new AllReportData
                {
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString(),
                    ManifRate = dt.Rows[i]["ManifRate"].ToString(),
                });
            }
            return ReportList;
        }


        public DataTable GetMIS_MISC_ChargesRevenus(AllReportData Data)
        {
            string _Query = " select distinct(select top(1) ChgCode from NVO_ChargeTB where NVO_ChargeTB.ID = NVO_BLCharges.ChargeCodeID) as ChargeCode, " +
                            " cast(isnull((ManifRate / (case when CurrencyID = 146  then 1 else (select top(1) ExRate from NVO_MISExRateCountrywise " +
                            " where NVO_MISExRateCountrywise.Id = NVO_BLCharges.CurrencyID)  end)),0) as decimal(10, 2))  as  ManifRate " +
                            " from NVO_BLCharges where ChargeCodeID in (select ID from NVO_ChargeTB where  ChargeCodeID in (17, 25, 13, 11)) and RRID =" + Data.RRID;
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
