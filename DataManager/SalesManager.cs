
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
using System.Net;
using System.Net.Mail;
using System.Web;
namespace DataManager
{
    public class SalesManager
    {
        List<MyMRG> MRGList = new List<MyMRG>();
        List<MySLOT> SLOTList = new List<MySLOT>();
        List<MYPortTariffMaster> PortTariffList = new List<MYPortTariffMaster>();
        List<MyRatesheet> RateList = new List<MyRatesheet>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public SalesManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region MUTHU
        #region MRG

        public List<MyMRG> InsertMRGMaster(MyMRG Data)
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


                    if (Data.ID == 0)
                    {
                        string AutoGen = GetMaxseqNumber("MRG", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'MRG' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.MRGNo = Cmd.ExecuteScalar().ToString();
                    }


                    Cmd.CommandText = " IF((select count(*) from NVO_MRGRate where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_MRGRate(MRGRate,FDate,TDate,PofOrigin,PofLoading,PofDischarge,PofFinalPOD,CntrTypes,Commodity,ServiceTypes,Currency,Amount,Remarks,CurrentDate,UserID,AgentId,SessionFinYear,AgentCode) " +
                                     " values (@MRGRate,@FDate,@TDate,@PofOrigin,@PofLoading,@PofDischarge,@PofFinalPOD,@CntrTypes,@Commodity,@ServiceTypes,@Currency,@Amount,@Remarks,@CurrentDate,@UserID,@AgentId,@SessionFinYear,@AgentCode) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MRGRate SET MRGRate=@MRGRate,FDate=@FDate,TDate=@TDate,PofOrigin=@PofOrigin,PofLoading=@PofLoading,PofDischarge=@PofDischarge,PofFinalPOD=@PofFinalPOD," +
                                     " CntrTypes=@CntrTypes,Commodity=@Commodity,ServiceTypes=@ServiceTypes,Currency=@Currency,Amount=@Amount,Remarks=@Remarks,CurrentDate=@CurrentDate,UserID=@UserID,AgentId=@AgentId,SessionFinYear=@SessionFinYear,AgentCode=@AgentCode where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MRGRate", Data.MRGNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FDate", DateTime.ParseExact(Data.FDate, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TDate", DateTime.ParseExact(Data.TDate, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PofOrigin", Data.IntPOfOrigin));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PofLoading", Data.IntPOfLoading));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PofDischarge", Data.IntPOfDischarge));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PofFinalPOD", Data.IntFinalPOD));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypes", Data.intCntrTypes));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Commodity", Data.intCommodity));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ServiceTypes", Data.intServiceTypes));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Currency", Data.intCurrency));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", Data.Amount));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentId", Data.AgentId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SessionFinYear", Data.SessionFinYear));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentCode", Data.AgentCode));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_MRGRate')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();

                    MRGList.Add(new MyMRG { ID = Data.ID, MRGNo = Data.MRGNo });
                    return MRGList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MRGList;
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


        public List<MyMRG> MRGRecordView(MyMRG Data)
        {
            List<MyMRG> ViewList = new List<MyMRG>();
            DataTable dt = GetMRGView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyMRG
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    MRGNo = dt.Rows[i]["MRGRate"].ToString(),
                    FDate = dt.Rows[i]["Fdate"].ToString(),
                    TDate = dt.Rows[i]["Fdate"].ToString(),
                    POO = dt.Rows[i]["POO"].ToString(),
                    FPOD = dt.Rows[i]["Destination"].ToString(),
                    CntrTypes = dt.Rows[i]["Cntrsize"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    CommodityName = dt.Rows[i]["Commodity"].ToString(),
                    ServiceTypesName = dt.Rows[i]["ServiceTypes"].ToString(),
                    Amount = decimal.Parse(dt.Rows[i]["Amount"].ToString())


                });
            }
            return ViewList;
        }

        public DataTable GetMRGView(MyMRG Data)
        {
            string strWhere = "";
            string _Query = " SELECT ID,MRGRate, convert(varchar,Fdate, 103) as FDate, convert(varchar,Tdate, 103) as TDate, (select top(1) PortName from NVO_PortMaster where Id = PofLoading) POO, " +
                            " (select  top(1) GeneralName from NVO_GeneralMaster where Id = Commodity) as Commodity,(select top(1) CurrencyCode from NVO_CurrencyMaster where Id = Currency) as Currency, " +
                            " (select top(1) size from NVO_tblCntrTypes where ID = CntrTypes) as Cntrsize,(select top(1) PortName from NVO_PortMaster where Id = PofDischarge) Destination, " +
                            " (select top(1) Description from NVO_tblDLValues where Id = ServiceTypes) as ServiceTypes,Amount FROM NVO_MRGRate";

            if (Data.StrPOL != null)
                if (strWhere == "")
                    strWhere += _Query + " where PofLoading=" + Data.StrPOL;
                else
                    strWhere += " and PofLoading=" + Data.StrPOL;

            if (Data.StrPOD != null)
                if (strWhere == "")
                    strWhere += _Query + " where PofDischarge=" + Data.StrPOD;
                else
                    strWhere += " and PofDischarge=" + Data.StrPOD;

            if (Data.StrCommondty != null)
                if (strWhere == "")
                    strWhere += _Query + " where Commodity=" + Data.StrCommondty;
                else
                    strWhere += " and Commodity=" + Data.StrCommondty;

            if (Data.StrCntrTypes != null)
                if (strWhere == "")
                    strWhere += _Query + " where CntrTypes=" + Data.StrCntrTypes;
                else
                    strWhere += " and CntrTypes=" + Data.StrCntrTypes;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + "  order by NVO_MRGRate.ID desc", "");
        }


        public List<MyMRG> MRGExistingMasterRecordView(string ID)
        {
            List<MyMRG> ViewList = new List<MyMRG>();
            DataTable dt = GetMRGExistingMasterView(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyMRG
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    MRGNo = dt.Rows[i]["MRGRate"].ToString(),
                    FDate = dt.Rows[i]["FDate"].ToString(),
                    TDate = dt.Rows[i]["TDate"].ToString(),
                    IntPOfOrigin = Int32.Parse(dt.Rows[i]["PofOrigin"].ToString()),
                    IntPOfLoading = Int32.Parse(dt.Rows[i]["PofLoading"].ToString()),
                    IntPOfDischarge = Int32.Parse(dt.Rows[i]["PofDischarge"].ToString()),
                    IntFinalPOD = Int32.Parse(dt.Rows[i]["PofFinalPOD"].ToString()),
                    intCntrTypes = Int32.Parse(dt.Rows[i]["CntrTypes"].ToString()),
                    intCommodity = Int32.Parse(dt.Rows[i]["Commodity"].ToString()),
                    IntServiceTypes = Int32.Parse(dt.Rows[i]["ServiceTypes"].ToString()),
                    intCurrency = Int32.Parse(dt.Rows[i]["Currency"].ToString()),
                    Amount = decimal.Parse(dt.Rows[i]["Amount"].ToString()),
                    Remarks = dt.Rows[i]["Remarks"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetMRGExistingMasterView(string ID)
        {
            string _Query = " select ID,MRGRate, convert(varchar, FDate, 103) as FDate, convert(varchar, TDate, 103) as TDate,PofOrigin,PofLoading,PofDischarge,PofFinalPOD,CntrTypes,Commodity,ServiceTypes,Currency,Amount,Remarks from NVO_MRGRate where ID=" + ID;
            return GetViewData(_Query, "");
        }

        #endregion

        #region SLOT
        public List<MySLOT> InsertSLOTMaster(MySLOT Data)
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
                    //if (Data.ID == 0)
                    //{
                    //    string AutoGen = GetMaxseqNumber("SLOTNo", "1");
                    //    Cmd.CommandText = "select 'SLT' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                    //    Data.SlotRef = Cmd.ExecuteScalar().ToString();
                    //}

                    Cmd.CommandText = " IF((select count(*) from NVO_SLOTMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_SLOTMaster(SlotRef,ValidFrom,ValidTo,ServiceName,SlotOperator,SlotTermID,POD,POL,TSPort,Remarks,CurrentDate) " +
                                     " values (@SlotRef,@ValidFrom,@ValidTo,@ServiceName,@SlotOperator,@SlotTermID,@POD,@POL,@TSPort,@Remarks,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_SLOTMaster SET SlotRef=@SlotRef,ValidFrom=@ValidFrom,ValidTo=@ValidTo,ServiceName=@ServiceName,SlotOperator=@SlotOperator,SlotTermID=@SlotTermID," +
                                     " POD=@POD,POL=@POL,TSPort=@TSPort,Remarks=@Remarks,CurrentDate=@CurrentDate where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotRef", Data.SlotRef));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidFrom", DateTime.ParseExact(Data.ValidFrom, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTo", DateTime.ParseExact(Data.ValidTo, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ServiceName", Data.ServiceName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotOperator", Data.SlotOperator));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotTermID", Data.SlotTermID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POD", Data.POD));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POL", Data.POL));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TSPort", Data.TSPort));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_SLOTMaster')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_SLOTDDtls where SLID=@SLID and SID=@SID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_SLOTDDtls(SLID,ChargeID,BasicID,SizeID,Commodity,CurrencyID,Amount,ResponsibleAgent) " +
                                     " values (@SLID,@ChargeID,@BasicID,@SizeID,@Commodity,@CurrencyID,@Amount,@ResponsibleAgent) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_SLOTDDtls SET SLID=@SLID,ChargeID=@ChargeID,BasicID=@BasicID,SizeID=@SizeID,Commodity=@Commodity,CurrencyID=@CurrencyID," +
                                     " Amount=@Amount,ResponsibleAgent=@ResponsibleAgent where SLID=@SLID and SID=@SID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SLID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SizeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Commodity", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ResponsibleAgent", CharSplit[7]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }


                    trans.Commit();

                    SLOTList.Add(new MySLOT
                    {
                        ID = Data.ID,
                        SlotRef = Data.SlotRef
                    });
                    return SLOTList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return SLOTList;
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

        public List<MySLOT> SLOTRecordView(MySLOT Data)
        {
            List<MySLOT> ViewList = new List<MySLOT>();
            DataTable dt = GetSLOTView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MySLOT
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    SlotRef = dt.Rows[i]["SlotRef"].ToString(),
                    ServiceName = dt.Rows[i]["ServiceName"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOperatorv"].ToString(),
                    POLStr = dt.Rows[i]["POL"].ToString(),
                    PODStr = dt.Rows[i]["POD"].ToString(),
                    TSPortStr = dt.Rows[i]["TsPort"].ToString(),
                    ValidFrom = dt.Rows[i]["FDate"].ToString(),
                    ValidTo = dt.Rows[i]["TDate"].ToString(),
                });
            }
            return ViewList;
        }

        public DataTable GetSLOTView(MySLOT Data)
        {
            string strWhere = "";
            string _Query = "select * from V_SlatMasterView";

            if (Data.POLStr != null)
                if (strWhere == "")
                    strWhere += _Query + " where intPOL=" + Data.POLStr;
                else
                    strWhere += " and intPOL=" + Data.POLStr;

            if (Data.PODStr != null)
                if (strWhere == "")
                    strWhere += _Query + " where intPOD=" + Data.PODStr;
                else
                    strWhere += " and intPOD=" + Data.PODStr;

            if (Data.StrSlotOperator != "")
                if (strWhere == "")
                    strWhere += _Query + " where SlotOperatorv like '%" + Data.StrSlotOperator + "%'";
                else
                    strWhere += " and SlotOperatorv like '%" + Data.StrSlotOperator + "%'";

            if (Data.StrSlotTerms != null)
                if (strWhere == "")
                    strWhere += _Query + " where SlotTermID=" + Data.StrSlotTerms;
                else
                    strWhere += " and SlotTermID=" + Data.StrSlotTerms;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + "  order by V_SlatMasterView.ID desc", "");
        }

        public List<MySLOT> SLOTExistingRecordView(string ID)
        {
            List<MySLOT> ViewList = new List<MySLOT>();
            DataTable dt = GetSLOTExistingView(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MySLOT
                {
                    SID = Int32.Parse(dt.Rows[i]["SID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeID"].ToString()),
                    Basic = Int32.Parse(dt.Rows[i]["BasicID"].ToString()),
                    SizeID = Int32.Parse(dt.Rows[i]["SizeID"].ToString()),
                    CommodityID = Int32.Parse(dt.Rows[i]["Commodity"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    Amount = decimal.Parse(dt.Rows[i]["Amount"].ToString()),
                    Agent = Int32.Parse(dt.Rows[i]["ResponsibleAgent"].ToString())
                });
            }
            return ViewList;
        }

        public DataTable GetSLOTExistingView(string ID)
        {
            string _Query = " SELECT *  FROM NVO_SLOTDDtls where SLID=" + ID;
            return GetViewData(_Query, "");
        }

        public List<MySLOT> SLOTExistingMasterRecordView(string ID)
        {
            List<MySLOT> ViewList = new List<MySLOT>();
            DataTable dt = GetSLOTExistingMasterView(ID);
            ViewList.Add(new MySLOT
            {
                ID = Int32.Parse(dt.Rows[0]["ID"].ToString()),
                SlotRef = dt.Rows[0]["SlotRef"].ToString(),
                ValidFrom = dt.Rows[0]["ValidFrom"].ToString(),
                ValidTo = dt.Rows[0]["ValidTo"].ToString(),
                ServiceName = dt.Rows[0]["ServiceName"].ToString(),
                SlotOperator = dt.Rows[0]["SlotOperator"].ToString(),
                SlotTermID = Int32.Parse(dt.Rows[0]["SlotTermID"].ToString()),
                POD = Int32.Parse(dt.Rows[0]["POD"].ToString()),
                POL = Int32.Parse(dt.Rows[0]["POL"].ToString()),
                TSPort = Int32.Parse(dt.Rows[0]["TSPort"].ToString()),
                Remarks = dt.Rows[0]["Remarks"].ToString()
            });

            return ViewList;
        }

        public DataTable GetSLOTExistingMasterView(string ID)
        {
            string _Query = " SELECT ID,SlotRef,convert(varchar,ValidFrom, 103) as ValidFrom,convert(varchar,ValidTo, 103) as ValidTo,ServiceName,SlotOperator,SlotTermID,POD,POL,TSPort,Remarks  FROM NVO_SLOTMaster where ID=" + ID;
            return GetViewData(_Query, "");
        }



        #endregion


        #region  PortTariffMaster
        public List<MYPortTariffMaster> ExistTariffValidation(MYPortTariffMaster Data)
        {
            DataTable dt = GetExistTariffValidations(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PortTariffList.Add(new MYPortTariffMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ModuleID = Int32.Parse(dt.Rows[i]["ModuleID"].ToString()),
                    TraiffRegular = dt.Rows[i]["TraiffRegular"].ToString(),
                    PortLocationID = Int32.Parse(dt.Rows[i]["PortLocationID"].ToString()),
                    TariffModeID = dt.Rows[i]["TariffModeID"].ToString(),
                    ShipmentTypeID = Int32.Parse(dt.Rows[i]["ShipmentTypeID"].ToString()),
                    CommodityTypeID = Int32.Parse(dt.Rows[i]["CommodityTypeID"].ToString()),
                    ValidTo = dt.Rows[i]["CurrDt"].ToString(),

                });
            }
            return PortTariffList;
        }

        public DataTable GetExistTariffValidations(MYPortTariffMaster Data)

        {
            string _Query = " select *, convert(varchar, ValidTo, 103) as ValidToDt,convert(varchar,  GETDATE() , 103) as CurrDt from NVO_PortTariffMaster  where ModuleID = " + Data.ModuleID + " and TraiffRegular = " + Data.TraiffRegular + " and PortLocationID = " + Data.PortLocationID + " and TariffModeID = " + Data.TariffModeID + " and ShipmentTypeID =" + Data.ShipmentTypeID + " and CommodityTypeID = " + Data.CommodityTypeID + " and CollectionModeID = " + Data.CollectionModeID + " and GroupID = " + Data.GroupID + " and ServiceTypeID = " + Data.ServiceTypeID + " ";
            return GetViewData(_Query, "");
        }
        public List<MYPortTariffMaster> InsertPortTariffMaster(MYPortTariffMaster Data)
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
                    Cmd.CommandText = " IF((select count(*) from NVO_PortTariffMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_PortTariffMaster(PrincibleID,EffectiveDate,PortID,TerminalID,EquipmentTypeID,StartMoveID,EndMove,StatusID,Remarks,CurrentDate,ExpChargeID,ImpChargeID) " +
                                     " values (@PrincibleID,@EffectiveDate,@PortID,@TerminalID,@EquipmentTypeID,@StartMoveID,@EndMove,@StatusID,@Remarks,@CurrentDate,@ExpChargeID,@ImpChargeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_PortTariffMaster SET PrincibleID=@PrincibleID,EffectiveDate=@EffectiveDate,PortID=@PortID,TerminalID=@TerminalID,EquipmentTypeID=@EquipmentTypeID," +
                                     " StartMoveID=@StartMoveID,EndMove=@EndMove,StatusID=@StatusID,Remarks=@Remarks,CurrentDate=@CurrentDate,ExpChargeID=@ExpChargeID,ImpChargeID=@ImpChargeID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincibleID", Data.PrincibleID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EffectiveDate", Data.EffectiveDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", Data.PortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalID", Data.TerminalID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EquipmentTypeID", Data.EquipmentTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeID", Data.ChargeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StartMoveID", Data.StartMoveID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EndMove", Data.EndMove));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExpChargeID", Data.ExpChargeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ImpChargeID", Data.ImpChargeID));


                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_PortTariffMaster')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;

                    if (Data.Itemsv != null)
                    {
                        string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_PortTariffdtls where PTID=@PTID and TID=@TID and PortTariffTypeID=@PortTariffTypeID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_PortTariffdtls(PTID,ShipmentTypeID,TariffTypeID,ChargeCodeID,CommodityID,BasicID,CurrencyID,ServiceTypeID,Amount,PortTariffTypeID) " +
                                         " values (@PTID,@ShipmentTypeID,@TariffTypeID,@ChargeCodeID,@CommodityID,@BasicID,@CurrencyID,@ServiceTypeID,@Amount,@PortTariffTypeID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_PortTariffdtls SET PTID=@PTID,ShipmentTypeID=@ShipmentTypeID,TariffTypeID=@TariffTypeID,ChargeCodeID=@ChargeCodeID,CommodityID=@CommodityID," +
                                         " BasicID=@BasicID,CurrencyID=@CurrencyID,ServiceTypeID=@ServiceTypeID,Amount=@Amount,PortTariffTypeID=@PortTariffTypeID where PTID=@PTID and TID=@TID and PortTariffTypeID=@PortTariffTypeID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PTID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityID", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ServiceTypeID", CharSplit[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[8]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffTypeID", Data.PortTariffTypeID));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    if (Data.ItemsSlab != null)
                    {
                        string[] Array1 = Data.ItemsSlab.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array1.Length; i++)
                        {
                            var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_PortTariffSlabdtls where PTID=@PTID and SLID=@SLID and PortTariffTypeID=@PortTariffTypeID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_PortTariffSlabdtls(PTID,PortTariffTypeID,slabFrom,slabTo,CurrencyID,Amount,ShipmentTypeID) " +
                                        " values (@PTID,@PortTariffTypeID,@slabFrom,@slabTo,@CurrencyID,@Amount,@ShipmentTypeID) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_PortTariffSlabdtls SET PTID=@PTID,PortTariffTypeID=@PortTariffTypeID,slabFrom=@slabFrom,slabTo=@slabTo,CurrencyID=@CurrencyID,Amount=@Amount,ShipmentTypeID=@ShipmentTypeID " +
                                        " where PTID=@PTID and SLID=@SLID and PortTariffTypeID=@PortTariffTypeID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SLID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PTID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@slabFrom", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@slabTo", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffTypeID", Data.PortTariffTypeID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", "1"));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }

                    if (Data.ItemsSlabImp != null)
                    {
                        string[] Array2 = Data.ItemsSlabImp.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array2.Length; i++)
                        {
                            var CharSplit = Array2[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_PortTariffSlabdtls where PTID=@PTID and SLID=@SLID and PortTariffTypeID=@PortTariffTypeID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_PortTariffSlabdtls(PTID,PortTariffTypeID,slabFrom,slabTo,CurrencyID,Amount,ShipmentTypeID) " +
                                        " values (@PTID,@PortTariffTypeID,@slabFrom,@slabTo,@CurrencyID,@Amount,@ShipmentTypeID) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_PortTariffSlabdtls SET PTID=@PTID,PortTariffTypeID=@PortTariffTypeID,slabFrom=@slabFrom,slabTo=@slabTo,CurrencyID=@CurrencyID,Amount=@Amount,ShipmentTypeID=@ShipmentTypeID " +
                                        " where PTID=@PTID and SLID=@SLID and PortTariffTypeID=@PortTariffTypeID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SLID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PTID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@slabFrom", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@slabTo", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffTypeID", Data.PortTariffTypeID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", "2"));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }

                    if (Data.ItemsIHC != null)
                    {
                        string[] Array3 = Data.ItemsIHC.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array3.Length; i++)
                        {
                            var CharSplit = Array3[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_PortTariffIHCdtls where PTID=@PTID and SLID=@SLID and PortTariffTypeID=@PortTariffTypeID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_PortTariffIHCdtls(PTID,PortTariffTypeID,slabFrom,slabTo,CurrencyID,RevenueAmount,CostAmount,LineAmount,ShipmentTypeID) " +
                                        " values (@PTID,@PortTariffTypeID,@slabFrom,@slabTo,@CurrencyID,@RevenueAmount,@CostAmount,@LineAmount,@ShipmentTypeID) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_PortTariffIHCdtls SET PTID=@PTID,PortTariffTypeID=@PortTariffTypeID,slabFrom=@slabFrom,slabTo=@slabTo,CurrencyID=@CurrencyID,RevenueAmount=@RevenueAmount,CostAmount=@CostAmount,LineAmount=@LineAmount,ShipmentTypeID=@ShipmentTypeID " +
                                        " where PTID=@PTID and SLID=@SLID and PortTariffTypeID=@PortTariffTypeID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SLID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PTID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@slabFrom", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@slabTo", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RevenueAmount", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CostAmount", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LineAmount", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffTypeID", Data.PortTariffTypeID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", "1"));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }


                    if (Data.ItemsStorage != null)
                    {
                        string[] Array1 = Data.ItemsStorage.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array1.Length; i++)
                        {
                            var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_PortTariffStoragedtls where PTID=@PTID and SLID=@SLID and EQType=@EQType and Type=@Type)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_PortTariffStoragedtls(PTID,PortTariffTypeID,slabFrom,slabTo,CurrencyID,Amount,ShipmentTypeID,EQType,Type) " +
                                        " values (@PTID,@PortTariffTypeID,@slabFrom,@slabTo,@CurrencyID,@Amount,@ShipmentTypeID,@EQType,@Type) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_PortTariffStoragedtls SET PTID=@PTID,PortTariffTypeID=@PortTariffTypeID,slabFrom=@slabFrom,slabTo=@slabTo,CurrencyID=@CurrencyID,Amount=@Amount,ShipmentTypeID=@ShipmentTypeID,EQType=@EQType,Type=@Type " +
                                        " where PTID=@PTID and SLID=@SLID and EQType=@EQType and Type=@Type";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SLID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PTID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@slabFrom", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@slabTo", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffTypeID", Data.PortTariffTypeID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", "1"));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@EQType", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Type", CharSplit[6]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }

                    trans.Commit();
                    PortTariffList.Add(new MYPortTariffMaster
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Record Saved sucessfully"
                    }); ;
                    return PortTariffList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    PortTariffList.Add(new MYPortTariffMaster { AlertMessage = ex.Message, AlertMegId = "2" });
                    return PortTariffList;
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


        public List<MYPortTariffMaster> InsertPortTariffRevenuDOChargesMaster(MYPortTariffMaster Data)
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

                    int result = 0;
                    string[] Array3 = Data.ItemsDOCharges.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array3.Length; i++)
                    {
                        var CharSplit = Array3[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_PortTariffRateDOChargesdtls where PTID=@PTID and SLID=@SLID and PortTariffTypeID=@PortTariffTypeID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_PortTariffRateDOChargesdtls(PTID,PortTariffTypeID,SlabUpto,CurrencyID,Amount) " +
                                    " values (@PTID,@PortTariffTypeID,@SlabUpto,@CurrencyID,@Amount) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_PortTariffRateDOChargesdtls SET PTID=@PTID,PortTariffTypeID=@PortTariffTypeID,SlabUpto=@SlabUpto,CurrencyID=@CurrencyID,Amount=@Amount " +
                                    " where PTID=@PTID and SLID=@SLID and PortTariffTypeID=@PortTariffTypeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SLID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PTID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlabUpto", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffTypeID", Data.PortTariffTypeID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", "1"));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                    trans.Commit();
                    PortTariffList.Add(new MYPortTariffMaster
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "DO Charges updated sucessfully"
                    }); ;
                    return PortTariffList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    PortTariffList.Add(new MYPortTariffMaster { AlertMessage = ex.Message, AlertMegId = "2" });
                    return PortTariffList;
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


        public List<MYPortTariffMaster> InsertPortTariffTHCChargesMaster(MYPortTariffMaster Data)
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

                    int result = 0;
                    string[] Array3 = Data.ItemsTHCCharges.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array3.Length; i++)
                    {
                        var CharSplit = Array3[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_PortTariffTHCChargedtls where PTID=@PTID and TCID=@TCID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_PortTariffTHCChargedtls(PTID,ChargeCodeID,ShipmetID,CommodityID,CntrTypeID,CurrencyID,Amount,ExRate,LocalAmount) " +
                                    " values (@PTID,@ChargeCodeID,@ShipmetID,@CommodityID,@CntrTypeID,@CurrencyID,@Amount,@ExRate,@LocalAmount) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_PortTariffTHCChargedtls SET PTID=@PTID,ChargeCodeID=@ChargeCodeID,ShipmetID=@ShipmetID,CommodityID=@CommodityID,CntrTypeID=@CntrTypeID,CurrencyID=@CurrencyID," +
                                    " Amount=@Amount,ExRate=@ExRate,LocalAmount=@LocalAmount " +
                                    " where PTID=@PTID and TCID=@TCID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TCID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PTID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmetID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ExRate", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LocalAmount", CharSplit[8]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                    trans.Commit();
                    PortTariffList.Add(new MYPortTariffMaster
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "THC Costings updated sucessfully"
                    }); ;
                    return PortTariffList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    PortTariffList.Add(new MYPortTariffMaster { AlertMessage = ex.Message, AlertMegId = "2" });
                    return PortTariffList;
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


        public List<MYPortTariffMaster> InsertPortTariffIHCBrackupChargesMaster(MYPortTariffMaster Data)
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

                    int result = 0;
                    string[] Array3 = Data.ItemsIHCBrackupCharges.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array3.Length; i++)
                    {
                        var CharSplit = Array3[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_PortTariffIHCChargedtls where PTID=@PTID and TCID=@TCID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_PortTariffIHCChargedtls(PTID,ChargeCodeID,Amount,PaymentTo) " +
                                    " values (@PTID,@ChargeCodeID,@Amount,@PaymentTo) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_PortTariffIHCChargedtls SET PTID=@PTID,ChargeCodeID=@ChargeCodeID, Amount=@Amount,PaymentTo=@PaymentTo where PTID=@PTID and TCID=@TCID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TCID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PTID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentTo", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[3]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                    trans.Commit();
                    PortTariffList.Add(new MYPortTariffMaster
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "IFC CHARGES updated sucessfully"
                    }); ;
                    return PortTariffList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    PortTariffList.Add(new MYPortTariffMaster { AlertMessage = ex.Message, AlertMegId = "2" });
                    return PortTariffList;
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


        public List<MYPortTariffMaster> InsertPortTariffChargeMaster(MYPortTariffMaster Data)
        {

            int result = 0;
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


                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_PortTariffChargedtls where TariffChID=@TariffChID and ChargeCodeID=@ChargeCodeID and ShipmetID=@ShipmetID and CommodityID=@CommodityID and CntrTypeID=@CntrTypeID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_PortTariffChargedtls(TariffChID,ChargeCodeID,ShipmetID,CommodityID,CntrTypeID,Amount,CurrencyID) " +
                                     " values (@TariffChID,@ChargeCodeID,@ShipmetID,@CommodityID,@CntrTypeID,@Amount,@CurrencyID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_PortTariffChargedtls SET TariffChID=@TariffChID,ChargeCodeID=@ChargeCodeID,ShipmetID=@ShipmetID,CommodityID=@CommodityID,CntrTypeID=@CntrTypeID,Amount=@Amount,CurrencyID=@CurrencyID where TariffChID=@TariffChID and ChargeCodeID=@ChargeCodeID and ShipmetID=@ShipmetID and CommodityID=@CommodityID and CntrTypeID=@CntrTypeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TCID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffChID", Data.TariffChID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmetID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[6]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    Cmd.CommandText = "Update NVO_PortTariffdtls set Amount=@Amount where TID=@TID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TID", Data.TariffChID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", Data.Amount));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    trans.Commit();
                    PortTariffList.Add(new MYPortTariffMaster { TariffChID = Data.TariffChID });
                    return PortTariffList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return PortTariffList;
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


        public List<MYPortTariffMaster> InsertPortTariffIHCChargeMaster(MYPortTariffMaster Data)
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


                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_PortTariffIHCChargedtls where TariffChID=@TariffChID and ChargeCodeID=@ChargeCodeID and PaymentTo=@PaymentTo)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_PortTariffIHCChargedtls(TariffChID,ChargeCodeID,PaymentTo,Amount) " +
                                     " values (@TariffChID,@ChargeCodeID,@PaymentTo,@Amount) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_PortTariffIHCChargedtls SET TariffChID=@TariffChID,ChargeCodeID=@ChargeCodeID,PaymentTo=@PaymentTo,Amount=@Amount where TariffChID=@TariffChID and ChargeCodeID=@ChargeCodeID and PaymentTo=@PaymentTo";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TCID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffChID", Data.TariffChID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentTo", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[3]));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();
                    PortTariffList.Add(new MYPortTariffMaster { TariffChID = Data.TariffChID });
                    return PortTariffList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return PortTariffList;
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


        public List<MYPortTariffMaster> PortTariffRecordView(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> ViewList = new List<MYPortTariffMaster>();
            DataTable dt = GetPortTariffView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYPortTariffMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LinerName = dt.Rows[i]["Liner"].ToString(),
                    EquipmentType = dt.Rows[i]["EquipmentType"].ToString(),
                    portName = dt.Rows[i]["PortName"].ToString()

                });
            }
            return ViewList;
        }


        public List<MYPortTariffMaster> PortTariffChargeExistingRecordView(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> ViewList = new List<MYPortTariffMaster>();
            DataTable dt = GetPortTariffChargeExistingView(Data.TariffChID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYPortTariffMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["TCID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeCodeID"].ToString()),
                    ShipmentTypeID = Int32.Parse(dt.Rows[i]["ShipmetID"].ToString()),
                    CommodityTypeID = Int32.Parse(dt.Rows[i]["CommodityID"].ToString()),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    Amount = decimal.Parse(dt.Rows[i]["Amount"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString())

                });
            }
            return ViewList;
        }

        public DataTable GetPortTariffChargeExistingView(int TariffChID)
        {
            string _Query = "select TCID,TariffChID,ChargeCodeID,ShipmetID,CommodityID,CntrTypeID,Amount,CurrencyID from NVO_PortTariffChargedtls where TariffChID= " + TariffChID;
            return GetViewData(_Query, "");
        }


        public List<MYPortTariffMaster> PortTariffIHCChargeExistingRecordView(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> ViewList = new List<MYPortTariffMaster>();
            DataTable dt = GetPortTariffIHCChargeExistingView(Data.TariffChID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYPortTariffMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["TCID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeCodeID"].ToString()),
                    PaymentTo = dt.Rows[i]["PaymentTo"].ToString(),
                    Amount = decimal.Parse(dt.Rows[i]["Amount"].ToString()),

                });
            }
            return ViewList;
        }

        public DataTable GetPortTariffIHCChargeExistingView(int TariffChID)
        {
            string _Query = "select TCID,TariffChID,ChargeCodeID,PaymentTo,Amount from NVO_PortTariffIHCChargedtls where TariffChID= " + TariffChID;
            return GetViewData(_Query, "");
        }



        public DataTable GetPortTariffView(MYPortTariffMaster Data)
        {
            string strWhere = "";
            string _Query = " select ID,(select top (1) CustomerName from NVO_view_CustomerDetails where CID = PrincibleID) as Liner, " +
                            " (select top(1) PortName + '-' + PortCode as PortName from NVO_PortMaster  where NVO_PortMaster.Id = NVO_PortTariffMaster.PortID) as PortName, " +
                            " (select top(1) Size from NVO_tblCntrTypes where NVO_tblCntrTypes.ID = NVO_PortTariffMaster.EquipmentTypeID) as EquipmentType " +
                            " from NVO_PortTariffMaster";

            if (Data.PortID != "0" && Data.PortID != null)
                if (strWhere == "")
                    strWhere += _Query + " where PortID=" + Data.PortID;
                else
                    strWhere += " and PortID=" + Data.PortID;

            if (Data.PrincibleID != "0" && Data.PrincibleID != null)
                if (strWhere == "")
                    strWhere += _Query + " where PrincibleID=" + Data.PrincibleID;
                else
                    strWhere += " and PrincibleID=" + Data.PrincibleID;

            if (Data.EquipmentTypeID != "0" && Data.EquipmentTypeID != null)
                if (strWhere == "")
                    strWhere += _Query + " where EquipmentTypeID=" + Data.EquipmentTypeID;
                else
                    strWhere += " and EquipmentTypeID=" + Data.EquipmentTypeID;

            //if (Data.Status.ToString() != "" && Data.Status.ToString() != null && Data.Status.ToString() != "0" && Data.Status.ToString() != "?")

            //    if (strWhere == "")
            //        strWhere += _Query + " where Status =" + Data.Status.ToString();
            //    else
            //        strWhere += " and Status =" + Data.Status.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }


        public List<MYPortTariffMaster> PortTariffExistingMasterRecordView(string ID)
        {
            List<MYPortTariffMaster> ViewList = new List<MYPortTariffMaster>();
            DataTable dt = GetPortTariffExistingMasterView(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYPortTariffMaster
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PrincibleID = dt.Rows[i]["PrincibleID"].ToString(),
                    EffectiveDate = dt.Rows[i]["EffectiveDate"].ToString(),
                    TerminalID = dt.Rows[i]["TerminalID"].ToString(),
                    EquipmentTypeID = dt.Rows[i]["EquipmentTypeID"].ToString(),
                    PortID = dt.Rows[i]["PortID"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    ExpChargeID = dt.Rows[i]["ExpChargeID"].ToString(),
                    ImpChargeID = dt.Rows[i]["ImpChargeID"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetPortTariffExistingMasterView(string ID)
        {
            string _Query = " Select ID,PrincibleID,convert(varchar,EffectiveDate, 23) as EffectiveDate,PortID,TerminalID,	EquipmentTypeID,ExpChargeID,ImpChargeID,StartMoveID,EndMove,StatusID,Remarks from NVO_PortTariffMaster where ID=" + ID;
            return GetViewData(_Query, "");
        }


        public List<MYPortTariffMaster> PortTraiffDtlsExistingView(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> ViewList = new List<MYPortTariffMaster>();
            DataTable dt = GetPortTariffDtlsExistingView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYPortTariffMaster
                {
                    TID = Int32.Parse(dt.Rows[i]["TID"].ToString()),
                    ShipmentTypeID = Int32.Parse(dt.Rows[i]["ShipmentTypeID"].ToString()),
                    TariffTypeID = Int32.Parse(dt.Rows[i]["TariffTypeID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeCodeID"].ToString()),
                    CommodityID = Int32.Parse(dt.Rows[i]["CommodityID"].ToString()),
                    BasisID = Int32.Parse(dt.Rows[i]["BasicID"].ToString()),
                    Basis = dt.Rows[i]["Basic"].ToString(),
                    ServiceTypeID = dt.Rows[i]["ServiceTypeID"].ToString(),
                    Amount = decimal.Parse(dt.Rows[i]["Amount"].ToString()),
                    ShipmentType = dt.Rows[i]["ShipmentType"].ToString(),
                    TariffType = dt.Rows[i]["TariffType"].ToString(),
                    ChargeCode = dt.Rows[i]["ChargeCode"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    ServiceType = dt.Rows[i]["ServiceType"].ToString(),
                    ISSlab = dt.Rows[i]["ISSlab"].ToString()
                });
            }
            return ViewList;
        }


        public DataTable GetPortTariffDtlsExistingView(MYPortTariffMaster Data)
        {
            string _Query = " SELECT TID,ShipmentTypeID,TariffTypeID,ChargeCodeID,CommodityID,BasicID,CurrencyID,ServiceTypeID,Amount, " +
                            " case when ShipmentTypeID = 1 then 'EXPORT' else 'IMPORT' end ShipmentType, " +
                            " (select top(1) GeneralName from NVO_GeneralMaster where Id = TariffTypeID)  as TariffType, " +
                            " (select top(1) ChgDesc from NVO_ChargeTB where Id = ChargeCodeID) as ChargeCode, " +
                            " (select top(1) GeneralName from NVO_GeneralMaster where Id = CommodityID)  as Commodity, " +
                            " case when BasicID = 1 then 'BL' else 'CONTAINER' end Basic, " +
                            " (select TOP(1) CurrencyCode from NVO_CurrencyMaster WHERE Id = CurrencyID) as Currency, " +
                            " (select top(1) GeneralName from NVO_GeneralMaster where Id = ServiceTypeID)  as ServiceType, " +
                            "  case when PortTariffTypeID = 3 then 1 else case when PortTariffTypeID = 7  then 0 else case when PortTariffTypeID = 2  then 0   " +
                            "  else case when PortTariffTypeID = 1 then (select top(1) ISSlab from NVO_ChargeTB where Id = ChargeCodeID) end end end end as ISSlab " +
                            " FROM NVO_PortTariffDtls where PTID=" + Data.ID + " and PortTariffTypeID=" + Data.PortTariffTypeID;
            return GetViewData(_Query, "");
        }

        public List<MYPortTariffMaster> PortTraiffSlabExistingView(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> ViewList = new List<MYPortTariffMaster>();
            DataTable dt = GetPortTariffSlabExistingView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYPortTariffMaster
                {
                    SLID = Int32.Parse(dt.Rows[i]["SLID"].ToString()),
                    ShipmentTypeID = Int32.Parse(dt.Rows[i]["ShipmentTypeID"].ToString()),
                    SlabFrom = dt.Rows[i]["SlabFrom"].ToString(),
                    SlabTo = dt.Rows[i]["SlabTo"].ToString(),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    Amount = decimal.Parse(dt.Rows[i]["Amount"].ToString()),
                });
            }
            return ViewList;
        }

        public DataTable GetPortTariffSlabExistingView(MYPortTariffMaster Data)
        {
            string _Query = "select * from NVO_PortTariffSlabdtls where PTID = " + Data.ID + " and PortTariffTypeID= " + Data.PortTariffTypeID + " and ShipmentTypeID=" + Data.ShipmentTypeID + " order by SLID asc";
            return GetViewData(_Query, "");
        }


        public List<MYPortTariffMaster> PortTraiffStorageExistingView(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> ViewList = new List<MYPortTariffMaster>();
            DataTable dt = GetPortTariffStoreExistingView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYPortTariffMaster
                {
                    SLID = Int32.Parse(dt.Rows[i]["SLID"].ToString()),
                    ShipmentTypeID = Int32.Parse(dt.Rows[i]["ShipmentTypeID"].ToString()),
                    SlabFrom = dt.Rows[i]["SlabFrom"].ToString(),
                    SlabTo = dt.Rows[i]["SlabTo"].ToString(),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    Amount = decimal.Parse(dt.Rows[i]["Amount"].ToString()),
                });
            }
            return ViewList;
        }

        public DataTable GetPortTariffStoreExistingView(MYPortTariffMaster Data)
        {
            string _Query = "select* from NVO_PortTariffStoragedtls where PTID = " + Data.ID + " and EQType = " + Data.EqTypeID + " and Type=" + Data.TypeID;
            return GetViewData(_Query, "");
        }

        public List<MYPortTariffMaster> PortTraiffRevenuDOChargesExistingView(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> ViewList = new List<MYPortTariffMaster>();
            DataTable dt = GetPortTariffRevenuDOChargesExistingView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYPortTariffMaster
                {
                    SLID = Int32.Parse(dt.Rows[i]["SLID"].ToString()),
                    SlabUpto = dt.Rows[i]["SlabUpto"].ToString(),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    Amount = decimal.Parse(dt.Rows[i]["Amount"].ToString()),
                });
            }
            return ViewList;
        }

        public DataTable GetPortTariffRevenuDOChargesExistingView(MYPortTariffMaster Data)
        {
            string _Query = "select * from NVO_PortTariffRateDOChargesdtls where PTID = " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MYPortTariffMaster> PortTraiffTHCBrackupChargesExistingView(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> ViewList = new List<MYPortTariffMaster>();
            DataTable dt = GetPortTariffTHCBrackupChargesExistingView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYPortTariffMaster
                {
                    SLID = Int32.Parse(dt.Rows[i]["TCID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeCodeID"].ToString()),
                    CommodityID = Int32.Parse(dt.Rows[i]["CommodityID"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    ShipmentID = dt.Rows[i]["ShipmetID"].ToString(),
                    CntrType = dt.Rows[i]["CntrTypeID"].ToString(),
                    Amount = decimal.Parse(dt.Rows[i]["Amount"].ToString()),
                    ExRate = decimal.Parse(dt.Rows[i]["ExRate"].ToString()),
                    LocalAmount = decimal.Parse(dt.Rows[i]["LocalAmount"].ToString()),
                });
            }
            return ViewList;
        }


        public DataTable GetPortTariffTHCBrackupChargesExistingView(MYPortTariffMaster Data)
        {
            string _Query = "select * from NVO_PortTariffTHCChargedtls where PTID = " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MYPortTariffMaster> PortTraiffIHCBrackupChargesExistingView(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> ViewList = new List<MYPortTariffMaster>();
            DataTable dt = GetPortTariffIHCBrackupChargesExistingView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYPortTariffMaster
                {
                    SLID = Int32.Parse(dt.Rows[i]["TCID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeCodeID"].ToString()),
                    PaymentTo = dt.Rows[i]["PaymentTo"].ToString(),
                    Amount = decimal.Parse(dt.Rows[i]["Amount"].ToString())

                });
            }
            return ViewList;
        }



        public DataTable GetPortTariffIHCBrackupChargesExistingView(MYPortTariffMaster Data)
        {
            string _Query = "select * from NVO_PortTariffIHCChargedtls where PTID = " + Data.ID + " and TCID=" + Data.TCID;
            return GetViewData(_Query, "");
        }


        public List<MYPortTariffMaster> PortTraiffIHCExistingView(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> ViewList = new List<MYPortTariffMaster>();
            DataTable dt = GetPortTariffIHCExistingView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYPortTariffMaster
                {
                    SLID = Int32.Parse(dt.Rows[i]["SLID"].ToString()),
                    ShipmentTypeID = Int32.Parse(dt.Rows[i]["ShipmentTypeID"].ToString()),
                    SlabFrom = dt.Rows[i]["SlabFrom"].ToString(),
                    SlabTo = dt.Rows[i]["SlabTo"].ToString(),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    RevenueAmount = decimal.Parse(dt.Rows[i]["RevenueAmount"].ToString()),
                    CostAmount = decimal.Parse(dt.Rows[i]["CostAmount"].ToString()),
                    LineAmount = decimal.Parse(dt.Rows[i]["LineAmount"].ToString()),
                });
            }
            return ViewList;
        }
        public DataTable GetPortTariffIHCExistingView(MYPortTariffMaster Data)
        {
            string _Query = "select * from NVO_PortTariffIHCdtls where PTID = " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MYPortTariffMaster> PortTariffDelete(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> ViewList = new List<MYPortTariffMaster>();
            DataTable dt = DeletePortTariffdtlsValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYPortTariffMaster
                {
                    TID = Int32.Parse(dt.Rows[i]["TID"].ToString()),

                });

            }
            return ViewList;
        }
        public DataTable DeletePortTariffdtlsValues(MYPortTariffMaster Data)
        {

            string _Query = "Delete NVO_PortTariffdtls where TID=" + Data.TID;


            return GetViewData(_Query, "");
        }


        public List<MYPortTariffMaster> DeleteTariffBrackupRecord(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> List = new List<MYPortTariffMaster>();

            int r1 = 0;
            int r2 = 0;
            int result = 0;
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


                    Cmd.CommandText = " delete from NVO_PortTariffChargedtls where TCID=@TCID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TCID", Data.ID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    List.Add(new MYPortTariffMaster
                    {
                        ID = Data.ID,

                    });
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return List;
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

        public List<MYPortTariffMaster> DeleteTariffChargesRecord(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> List = new List<MYPortTariffMaster>();

            int r1 = 0;
            int r2 = 0;
            int result = 0;
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
                    Cmd.CommandText = " delete from NVO_PortTariffdtls where TID=@TID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TID", Data.TID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    List.Add(new MYPortTariffMaster
                    {
                        ID = Data.ID,
                        AlertMessage = "Delete Tariff Port Charges"

                    });
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return List;
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


        public List<MYPortTariffMaster> DeleteTariffDetentionExpRecord(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> List = new List<MYPortTariffMaster>();

            int r1 = 0;
            int r2 = 0;
            int result = 0;
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
                    Cmd.CommandText = " delete from NVO_PortTariffSlabdtls where SLID=@SLID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SLID", Data.SLID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    List.Add(new MYPortTariffMaster
                    {
                        ID = Data.ID,
                        AlertMessage = "Delete Tariff Port Charges"

                    });
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return List;
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


        public List<MYPortTariffMaster> DeleteTariffStorageExpRecord(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> List = new List<MYPortTariffMaster>();

            int r1 = 0;
            int r2 = 0;
            int result = 0;
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
                    Cmd.CommandText = " delete from NVO_PortTariffStoragedtls where SLID=@SLID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SLID", Data.SLID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    List.Add(new MYPortTariffMaster
                    {
                        ID = Data.ID,
                        AlertMessage = "Delete Tariff Port Charges"

                    });
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return List;
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


        public List<MYPortTariffMaster> DeleteTariffIHCRecord(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> List = new List<MYPortTariffMaster>();

            int r1 = 0;
            int r2 = 0;
            int result = 0;
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
                    Cmd.CommandText = " delete from NVO_PortTariffIHCdtls where SLID=@SLID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SLID", Data.SLID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    List.Add(new MYPortTariffMaster
                    {
                        ID = Data.ID,
                        AlertMessage = "Delete Tariff Port Charges"

                    });
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return List;
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

        public List<MYPortTariffMaster> DeleteTariffDochargesRecord(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> List = new List<MYPortTariffMaster>();

            int r1 = 0;
            int r2 = 0;
            int result = 0;
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
                    Cmd.CommandText = " delete from NVO_PortTariffRateDOChargesdtls where SLID=@SLID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SLID", Data.SLID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    List.Add(new MYPortTariffMaster
                    {
                        ID = Data.ID,
                        AlertMessage = "Delete Tariff Port Charges"

                    });
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return List;
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


        public List<MYPortTariffMaster> DeleteTariffTHCBrackupchargesRecord(MYPortTariffMaster Data)
        {
            List<MYPortTariffMaster> List = new List<MYPortTariffMaster>();

            int r1 = 0;
            int r2 = 0;
            int result = 0;
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
                    Cmd.CommandText = " delete from NVO_PortTariffTHCChargedtls where TCID=@TCID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TCID", Data.SLID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    List.Add(new MYPortTariffMaster
                    {
                        ID = Data.ID,
                        AlertMessage = "Delete Tariff Port Charges"

                    });
                    return List;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return List;
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


        #region Ratesheet

        public List<MyRatesheet> InsertRatesheetMaster(MyRatesheet Data)
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
                    if (Data.ID == 0)
                    {
                        string AutoGen = GetMaxseqNumber("RRNO", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'RR' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.RatesheetNo = Cmd.ExecuteScalar().ToString();
                    }
                    Cmd.CommandText = " IF((select count(*) from NVO_Ratesheet where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Ratesheet(RatesheetNo,Date,BookingPartyID,SalesPersonID,ShipmentID,PortOfOrgin,PortOfLoading,ExpHaulageID,placeofDischargeId,FinalPODId,ImpHaulageId,TranshimentPortID,ServiceTypeID,ValidTill,CurrentDate,UserID,AgentId,Remarks) " +
                                     " values (@RatesheetNo,@Date,@BookingPartyID,@SalesPersonID,@ShipmentID,@PortOfOrgin,@PortOfLoading,@ExpHaulageID,@PlaceofDischargeId,@FinalPODId,@ImpHaulageId,@TranshimentPortID,@ServiceTypeID,@ValidTill,@CurrentDate,@UserID,@AgentId,@Remarks) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Ratesheet SET RatesheetNo=@RatesheetNo,Date=@Date,BookingPartyID=@BookingPartyID,SalesPersonID=@SalesPersonID,ShipmentID=@ShipmentID,PortOfOrgin=@PortOfOrgin,PortOfLoading=@PortOfLoading,ExpHaulageID=@ExpHaulageID," +
                                     " PlaceofDischargeId=@PlaceofDischargeId,FinalPODId=@FinalPODId,ImpHaulageId=@ImpHaulageId,TranshimentPortID=@TranshimentPortID,ServiceTypeID=@ServiceTypeID,ValidTill=@ValidTill,CurrentDate=@CurrentDate,UserID=@UserID,AgentId=@AgentId,Remarks=@Remarks where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RatesheetNo", Data.RatesheetNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Date", DateTime.ParseExact(Data.Date, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BookingPartyID", Data.BookingPartyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SalesPersonID", Data.SalesPersonID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentID", Data.ShipmentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortOfOrgin", Data.PortOfOrgin));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortOfLoading", Data.PortOfLoading));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExpHaulageID", Data.ExpHaulageID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PlaceofDischargeId", Data.PlaceofDischargeId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FinalPODId", Data.FinalPODId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ImpHaulageId", Data.ImpHaulageId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TranshimentPortID", Data.TranshimentPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ServiceTypeID", Data.ServiceTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", DateTime.ParseExact(Data.ValidTill, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentId", Data.AgentId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_Ratesheet')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }

                    trans.Commit();

                    RateList.Add(new MyRatesheet
                    {
                        ID = Data.ID,
                        RatesheetNo = Data.RatesheetNo
                    });
                    return RateList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return RateList;
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

        public List<MyRatesheet> InsertRatesheetMasterNew(MyRatesheet Data)
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
                    if (Data.ID == 0)
                    {
                        string AutoGen = GetMaxseqNumber("RRNO", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'RR' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.RatesheetNo = Cmd.ExecuteScalar().ToString();
                    }
                    Cmd.CommandText = " IF((select count(*) from NVO_Ratesheet where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Ratesheet(RatesheetNo,Date,BookingPartyID,SalesPersonID,ShipmentID,PortOfOrgin,PortOfLoading,ExpHaulageID,placeofDischargeId,FinalPODId,ImpHaulageId,TranshimentPortID,ServiceTypeID,ValidTill,CurrentDate,UserID,AgentId,Remarks,RouteType,ShipperID,ExportIHC,ImportIHC,IsRebate,RebateAmt,OtherRemarks,DocumentAttached,RSStatus,SingleUser) " +
                                     " values (@RatesheetNo,@Date,@BookingPartyID,@SalesPersonID,@ShipmentID,@PortOfOrgin,@PortOfLoading,@ExpHaulageID,@PlaceofDischargeId,@FinalPODId,@ImpHaulageId,@TranshimentPortID,@ServiceTypeID,@ValidTill,@CurrentDate,@UserID,@AgentId,@Remarks,@RouteType,@ShipperID,@ExportIHC,@ImportIHC,@IsRebate,@RebateAmt,@OtherRemarks,@DocumentAttached,@RSStatus,@SingleUser) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Ratesheet SET RatesheetNo=@RatesheetNo,Date=@Date,BookingPartyID=@BookingPartyID,SalesPersonID=@SalesPersonID,ShipmentID=@ShipmentID,PortOfOrgin=@PortOfOrgin,PortOfLoading=@PortOfLoading,ExpHaulageID=@ExpHaulageID," +
                                     " PlaceofDischargeId=@PlaceofDischargeId,FinalPODId=@FinalPODId,ImpHaulageId=@ImpHaulageId,TranshimentPortID=@TranshimentPortID,ServiceTypeID=@ServiceTypeID,ValidTill=@ValidTill,CurrentDate=@CurrentDate,UserID=@UserID,AgentId=@AgentId,Remarks=@Remarks,RouteType=@RouteType,ShipperID=@ShipperID,ExportIHC=@ExportIHC,ImportIHC=@ImportIHC,IsRebate=@IsRebate,RebateAmt=@RebateAmt,OtherRemarks=@OtherRemarks,DocumentAttached=@DocumentAttached,RSStatus=@RSStatus,SingleUser=@SingleUser where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RatesheetNo", Data.RatesheetNo));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@Date", DateTime.ParseExact(Data.Date, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Date", Data.Date));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BookingPartyID", Data.BookingPartyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SalesPersonID", Data.SalesPersonID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentID", Data.ShipmentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortOfOrgin", Data.PortOfOrgin));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortOfLoading", Data.PortOfLoading));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExpHaulageID", Data.ExpHaulageID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PlaceofDischargeId", Data.PlaceofDischargeId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FinalPODId", Data.FinalPODId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ImpHaulageId", Data.ImpHaulageId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TranshimentPortID", Data.TranshimentPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ServiceTypeID", Data.ServiceTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", Data.ValidTill));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentId", Data.AgentId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RouteType", Data.RouteType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperID", Data.ShipperID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExportIHC", Data.ExportIHC));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ImportIHC", Data.ImportIHC));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsRebate", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RebateAmt", 0.00));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OtherRemarks", Data.OtherRemarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DocumentAttached", Data.DocumentAttached));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SingleUser", Data.SingleUser));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_Ratesheet')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    //TsPort
                    if (Data.TranshimentPort != "Insert:undefined")
                    {
                        string[] ArrayTs = Data.TranshimentPort.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ArrayTs.Length; i++)
                        {
                            var CharSplit = ArrayTs[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_RatesheetTranshipmentPort where RRID=@RRID and TSPortID=@TSPortID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_RatesheetTranshipmentPort(RRID,TSPortID) " +
                                         " values (@RRID,@TSPortID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_RatesheetTranshipmentPort SET RRID=@RRID,TSPortID=@TSPortID where RRID=@RRID and TSPortID=@TSPortID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TSPortID", CharSplit[0]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    //Cntrtypes
                    string[] Array = Data.CntrItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCntrTypes where RRID=@RRID and RCID=@RCID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetCntrTypes(RRID,CntrTypeID,CommodityTypeID,DGClass,VGM) " +
                                     " values (@RRID,@CntrTypeID,@CommodityTypeID,@DGClass,@VGM) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetCntrTypes SET RRID=@RRID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID,DGClass=@DGClass,VGM=@VGM where RRID=@RRID and RCID=@RCID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RCID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DGClass", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VGM", CharSplit[4]));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    //Mode

                    string[] ArrayMode = Data.ModeItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayMode.Length; i++)
                    {
                        var CharSplit = ArrayMode[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetMode where RRID=@RRID and ModeID=@ModeID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetMode(RRID,ModeID,ExpFreeDays,ImpFreeDays) " +
                                     " values (@RRID,@ModeID,@ExpFreeDays,@ImpFreeDays) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetMode SET RRID=@RRID,ModeID=@ModeID,ExpFreeDays=@ExpFreeDays,ImpFreeDays=@ImpFreeDays where RRID=@RRID and ModeID=@ModeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ExpFreeDays", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ImpFreeDays", CharSplit[2]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    //
                    //Freight
                    string[] ArrayF = Data.FreightItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayF.Length; i++)
                    {
                        var CharSplit = ArrayF[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,PortTariffID,ChargeTypeID) " +
                                     " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@PortTariffID,@ChargeTypeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,PortTariffID=@PortTariffID,ChargeTypeID=@ChargeTypeID " +
                                     " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 135));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 1));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] ArrayT = Data.TerminalItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayT.Length; i++)
                    {
                        var CharSplit = ArrayT[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,PortTariffID,ChargeTypeID) " +
                                     " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@PortTariffID,@ChargeTypeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,PortTariffID=@PortTariffID,ChargeTypeID=@ChargeTypeID" +
                                     " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 136));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 1));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    string[] ArrayHaulage = Data.HaulagItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayHaulage.Length; i++)
                    {
                        var CharSplit = ArrayHaulage[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,PortTariffID,ChargeTypeID) " +
                                     " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@PortTariffID,@ChargeTypeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,PortTariffID=@PortTariffID,ChargeTypeID=@ChargeTypeID" +
                                     " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 137));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 1));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] ImpArray = Data.ImportItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ImpArray.Length; i++)
                    {
                        var CharSplit = ImpArray[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,PortTariffID,ChargeTypeID) " +
                                     " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@PortTariffID,@ChargeTypeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,PortTariffID=@PortTariffID,ChargeTypeID=@ChargeTypeID" +
                                     " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 138));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 1));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    string[] ExpArray = Data.ExportItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ExpArray.Length; i++)
                    {
                        var CharSplit = ExpArray[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,PortTariffID,ChargeTypeID) " +
                                     " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@PortTariffID,@ChargeTypeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,PortTariffID=@PortTariffID,ChargeTypeID=@ChargeTypeID" +
                                     " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 138));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 1));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();




                    }


                    //DataTable _dtCost = GetTariffCostValueExistingValus(Data.ID.ToString(), Data.CntrItems);
                    //if(_dtCost.Rows.Count >0)
                    //{
                    //    for (int m = 0; m < _dtCost.Rows.Count; m++)
                    //    {
                    //        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                    //                   " BEGIN " +
                    //                   " INSERT INTO  NVO_RatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,PortTariffID,ChargeTypeID) " +
                    //                   " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@PortTariffID,@ChargeTypeID) " +
                    //                   " END  " +
                    //                   " ELSE " +
                    //                   " UPDATE NVO_RatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,PortTariffID=@PortTariffID,ChargeTypeID=@ChargeTypeID" +
                    //                   " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffID", _dtCost.Rows[m]["PortTariffID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", _dtCost.Rows[m]["TraiffRegular"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", _dtCost.Rows[m]["TID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtCost.Rows[m]["ChargeTypeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtCost.Rows[m]["ChargeCodeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtCost.Rows[m]["CurrencyID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", _dtCost.Rows[m]["CollectionModeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtCost.Rows[m]["Amount"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtCost.Rows[m]["ManifestRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtCost.Rows[m]["CustomeRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", _dtCost.Rows[m]["RateDiffernt"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 2));
                    //        result = Cmd.ExecuteNonQuery();
                    //        Cmd.Parameters.Clear();
                    //    }
                    //}

                    trans.Commit();

                    RateList.Add(new MyRatesheet
                    {
                        ID = Data.ID,
                        RatesheetNo = Data.RatesheetNo
                    });
                    return RateList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return RateList;
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


        public List<MyRatesheet> InsertRatesheetMasterNewvalidity(MyRatesheet Data)
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

                    Cmd.CommandText = " UPDATE NVO_Ratesheet SET APStatus=@APStatus,RSStatus=@RSStatus where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ExtRRID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@APStatus", 5));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", 5));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        string AutoGen = GetMaxseqNumber("RRNO", "1", Data.SessionFinYear);
                        Cmd.CommandText = "select 'RR' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.RatesheetNo = Cmd.ExecuteScalar().ToString();
                    }
                    Cmd.CommandText = " IF((select count(*) from NVO_Ratesheet where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Ratesheet(RatesheetNo,Date,BookingPartyID,SalesPersonID,ShipmentID,PortOfOrgin,PortOfLoading,ExpHaulageID,placeofDischargeId,FinalPODId,ImpHaulageId,TranshimentPortID,ServiceTypeID,ValidTill,CurrentDate,UserID,AgentId,Remarks,RouteType,ShipperID,ExportIHC,ImportIHC,IsRebate,RebateAmt,OtherRemarks,DocumentAttached,RSStatus,SingleUser) " +
                                     " values (@RatesheetNo,@Date,@BookingPartyID,@SalesPersonID,@ShipmentID,@PortOfOrgin,@PortOfLoading,@ExpHaulageID,@PlaceofDischargeId,@FinalPODId,@ImpHaulageId,@TranshimentPortID,@ServiceTypeID,@ValidTill,@CurrentDate,@UserID,@AgentId,@Remarks,@RouteType,@ShipperID,@ExportIHC,@ImportIHC,@IsRebate,@RebateAmt,@OtherRemarks,@DocumentAttached,@RSStatus,@SingleUser) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Ratesheet SET RatesheetNo=@RatesheetNo,Date=@Date,BookingPartyID=@BookingPartyID,SalesPersonID=@SalesPersonID,ShipmentID=@ShipmentID,PortOfOrgin=@PortOfOrgin,PortOfLoading=@PortOfLoading,ExpHaulageID=@ExpHaulageID," +
                                     " PlaceofDischargeId=@PlaceofDischargeId,FinalPODId=@FinalPODId,ImpHaulageId=@ImpHaulageId,TranshimentPortID=@TranshimentPortID,ServiceTypeID=@ServiceTypeID,ValidTill=@ValidTill,CurrentDate=@CurrentDate,UserID=@UserID,AgentId=@AgentId,Remarks=@Remarks,RouteType=@RouteType,ShipperID=@ShipperID,ExportIHC=@ExportIHC,ImportIHC=@ImportIHC,IsRebate=@IsRebate,RebateAmt=@RebateAmt,OtherRemarks=@OtherRemarks,DocumentAttached=@DocumentAttached,RSStatus=@RSStatus,SingleUser=@SingleUser where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RatesheetNo", Data.RatesheetNo));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@Date", DateTime.ParseExact(Data.Date, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Date", Data.Date));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BookingPartyID", Data.BookingPartyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SalesPersonID", Data.SalesPersonID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentID", Data.ShipmentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortOfOrgin", Data.PortOfOrgin));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortOfLoading", Data.PortOfLoading));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExpHaulageID", Data.ExpHaulageID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PlaceofDischargeId", Data.PlaceofDischargeId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FinalPODId", Data.FinalPODId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ImpHaulageId", Data.ImpHaulageId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TranshimentPortID", Data.TranshimentPortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ServiceTypeID", Data.ServiceTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", Data.ValidTill));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentId", Data.AgentId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RouteType", Data.RouteType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperID", Data.ShipperID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExportIHC", Data.ExportIHC));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ImportIHC", Data.ImportIHC));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsRebate", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RebateAmt", 0.00));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OtherRemarks", Data.OtherRemarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DocumentAttached", Data.DocumentAttached));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SingleUser", Data.SingleUser));

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_Ratesheet')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    //TsPort
                    if (Data.TranshimentPort != "Insert:undefined")
                    {
                        string[] ArrayTs = Data.TranshimentPort.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ArrayTs.Length; i++)
                        {
                            var CharSplit = ArrayTs[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_RatesheetTranshipmentPort where RRID=@RRID and TSPortID=@TSPortID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_RatesheetTranshipmentPort(RRID,TSPortID) " +
                                         " values (@RRID,@TSPortID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_RatesheetTranshipmentPort SET RRID=@RRID,TSPortID=@TSPortID where RRID=@RRID and TSPortID=@TSPortID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TSPortID", CharSplit[0]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    //Cntrtypes
                    string[] Array = Data.CntrItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCntrTypes where RRID=@RRID and RCID=@RCID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetCntrTypes(RRID,CntrTypeID,CommodityTypeID,DGClass,VGM) " +
                                     " values (@RRID,@CntrTypeID,@CommodityTypeID,@DGClass,@VGM) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetCntrTypes SET RRID=@RRID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID,DGClass=@DGClass,VGM=@VGM where RRID=@RRID and RCID=@RCID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RCID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DGClass", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VGM", CharSplit[4]));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    //Mode

                    string[] ArrayMode = Data.ModeItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayMode.Length; i++)
                    {
                        var CharSplit = ArrayMode[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetMode where RRID=@RRID and ModeID=@ModeID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetMode(RRID,ModeID,ExpFreeDays,ImpFreeDays) " +
                                     " values (@RRID,@ModeID,@ExpFreeDays,@ImpFreeDays) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetMode SET RRID=@RRID,ModeID=@ModeID,ExpFreeDays=@ExpFreeDays,ImpFreeDays=@ImpFreeDays where RRID=@RRID and ModeID=@ModeID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ExpFreeDays", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ImpFreeDays", CharSplit[2]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    //
                    //Freight
                    string[] ArrayF = Data.FreightItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayF.Length; i++)
                    {
                        var CharSplit = ArrayF[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,PortTariffID,ChargeTypeID) " +
                                     " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@PortTariffID,@ChargeTypeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,PortTariffID=@PortTariffID,ChargeTypeID=@ChargeTypeID " +
                                     " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 135));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 1));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] ArrayT = Data.TerminalItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayT.Length; i++)
                    {
                        var CharSplit = ArrayT[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,PortTariffID,ChargeTypeID) " +
                                     " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@PortTariffID,@ChargeTypeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,PortTariffID=@PortTariffID,ChargeTypeID=@ChargeTypeID" +
                                     " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 136));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 1));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    string[] ArrayHaulage = Data.HaulagItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayHaulage.Length; i++)
                    {
                        var CharSplit = ArrayHaulage[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,PortTariffID,ChargeTypeID) " +
                                     " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@PortTariffID,@ChargeTypeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,PortTariffID=@PortTariffID,ChargeTypeID=@ChargeTypeID" +
                                     " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 137));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 1));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] ImpArray = Data.ImportItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ImpArray.Length; i++)
                    {
                        var CharSplit = ImpArray[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,PortTariffID,ChargeTypeID) " +
                                     " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@PortTariffID,@ChargeTypeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,PortTariffID=@PortTariffID,ChargeTypeID=@ChargeTypeID" +
                                     " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 138));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 1));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    string[] ExpArray = Data.ExportItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ExpArray.Length; i++)
                    {
                        var CharSplit = ExpArray[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,PortTariffID,ChargeTypeID) " +
                                     " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@PortTariffID,@ChargeTypeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,PortTariffID=@PortTariffID,ChargeTypeID=@ChargeTypeID" +
                                     " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 138));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 1));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();




                    }

                    //DataTable _dtCost = GetTariffCostValueExistingValus(Data.ID.ToString(), Data.CntrItems);
                    //if(_dtCost.Rows.Count >0)
                    //{
                    //    for (int m = 0; m < _dtCost.Rows.Count; m++)
                    //    {
                    //        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                    //                   " BEGIN " +
                    //                   " INSERT INTO  NVO_RatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,PortTariffID,ChargeTypeID) " +
                    //                   " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@PortTariffID,@ChargeTypeID) " +
                    //                   " END  " +
                    //                   " ELSE " +
                    //                   " UPDATE NVO_RatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,PortTariffID=@PortTariffID,ChargeTypeID=@ChargeTypeID" +
                    //                   " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffID", _dtCost.Rows[m]["PortTariffID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", _dtCost.Rows[m]["TraiffRegular"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", _dtCost.Rows[m]["TID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtCost.Rows[m]["ChargeTypeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtCost.Rows[m]["ChargeCodeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtCost.Rows[m]["CurrencyID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", _dtCost.Rows[m]["CollectionModeID"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtCost.Rows[m]["Amount"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtCost.Rows[m]["ManifestRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtCost.Rows[m]["CustomeRate"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", _dtCost.Rows[m]["RateDiffernt"].ToString()));
                    //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 2));
                    //        result = Cmd.ExecuteNonQuery();
                    //        Cmd.Parameters.Clear();
                    //    }
                    //}

                    trans.Commit();

                    RateList.Add(new MyRatesheet
                    {
                        ID = Data.ID,
                        RatesheetNo = Data.RatesheetNo
                    });
                    return RateList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return RateList;
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

        public List<MyRatesheet> InsertRatesheetCastMasterNew(MyRatesheet Data)
        {
            int r1 = 0;
            int r2 = 0;
            int result = 0;
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


                    DataTable _dtCost = GetTariffCostValueExistingValus(Data.ID.ToString());
                    if (_dtCost.Rows.Count > 0)
                    {
                        for (int m = 0; m < _dtCost.Rows.Count; m++)
                        {
                            Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                       " BEGIN " +
                                       " INSERT INTO  NVO_RatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID,PortTariffID,ChargeTypeID) " +
                                       " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID,@PortTariffID,@ChargeTypeID) " +
                                       " END  " +
                                       " ELSE " +
                                       " UPDATE NVO_RatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID,PortTariffID=@PortTariffID,ChargeTypeID=@ChargeTypeID" +
                                       " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PortTariffID", _dtCost.Rows[m]["PortTariffID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", _dtCost.Rows[m]["TraiffRegular"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", _dtCost.Rows[m]["TID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", _dtCost.Rows[m]["ChargeTypeID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtCost.Rows[m]["ChargeCodeID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtCost.Rows[m]["CurrencyID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", _dtCost.Rows[m]["CollectionModeID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", _dtCost.Rows[m]["Amount"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", _dtCost.Rows[m]["ManifestRate"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", _dtCost.Rows[m]["CustomeRate"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", _dtCost.Rows[m]["RateDiffernt"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 2));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }
                    }

                    trans.Commit();

                    RateList.Add(new MyRatesheet
                    {
                        ID = Data.ID,
                        RatesheetNo = Data.RatesheetNo
                    });
                    return RateList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return RateList;
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


        public DataTable GetTariffCostValueExistingValus(string RID)
        {
            string _Query = " select NVO_PortTariffMaster.ID as PortTariffID,TID, ChargeTypeID as ChargeTypes, CntrID as ChargeTypeID, ChargeCodeID, CurrencyID, CollectionModeID, Amount,  " +
                            " Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt,TraiffRegular from NVO_PortTariffMaster " +
                            " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                            " where ChargeTypeID = 2 and PTID in(select  PortTariffID from NVO_RatesheetCharges where RRID = " + RID + ") " +
                            " and  CntrID in (select CntrTypeID from NVO_RatesheetCntrTypes where RRID = " + RID + ")";
            return GetViewData(_Query, "");
        }


        public List<MyRatesheet> RRForeExpirevalues(MyRatesheet Data)
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

                    Cmd.CommandText = " UPDATE NVO_Ratesheet SET APStatus=@APStatus,RSStatus=@RSStatus where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@APStatus", 2));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", 2));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();



                    trans.Commit();

                    RateList.Add(new MyRatesheet
                    {
                        ID = Data.ID,
                        RatesheetNo = Data.RatesheetNo
                    });
                    return RateList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return RateList;
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


        public List<MyRatesheet> RatesheetRecordView(MyRatesheet Data)
        {
            List<MyRatesheet> ViewList = new List<MyRatesheet>();
            DataTable dt = GetRatesheetView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheet
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RatesheetNo = dt.Rows[i]["RatesheetNo"].ToString(),
                    BookingParty = dt.Rows[i]["BookingParty"].ToString(),
                    PortofOrgin = dt.Rows[i]["PortofOrgin"].ToString(),
                    PortofLoading = dt.Rows[i]["PortofLoading"].ToString(),
                    PortofDischarge = dt.Rows[i]["PlaceofDischarge"].ToString(),
                    Date = dt.Rows[i]["Datev"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString()
                }); ;
            }
            return ViewList;
        }

        public DataTable GetRatesheetView(MyRatesheet Data)
        {
            string strWhere = "";
            string _Query = " select ID, RatesheetNo," +
                " ( select top(1) upper(CustomerName + '-' + Branch)  from NVO_CustomerMaster inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID = NVO_CustomerMaster.ID  WHERE NVO_CusBranchLocation.CID = BookingPartyID ) BookingParty, " +

                " convert(varchar, date, 101) as Datev,(select top(1) PortName from NVO_PortMaster where Id = PortOfOrgin) PortofOrgin, " +
                            " (select top(1) PortName from NVO_PortMaster where Id = PortofLoading) PortofLoading," +
                            " (select top(1) Status from NVO_RRStatusMaster where ID =RSStatus) as Status ,(select top(1) PortName from NVO_PortMaster where Id = PlaceofDischargeId) PlaceofDischarge from NVO_Ratesheet ";

            if (Data.RRNumber != "")
                if (strWhere == "")
                    strWhere += _Query + " where RatesheetNo like'%" + Data.RRNumber + "%'";
                else
                    strWhere += " and RatesheetNo like'%" + Data.RRNumber + "%'";

            if (Data.PortofLoading != "" && Data.PortofLoading != "0" && Data.PortofLoading != null && Data.PortofLoading != "?")

                if (strWhere == "")
                    strWhere += _Query + " where PortOfLoading=" + Data.PortofLoading;
                else
                    strWhere += " and PortOfLoading=" + Data.PortofLoading;

            if (Data.PortofDischarge != "" && Data.PortofDischarge != "0" && Data.PortofDischarge != null && Data.PortofDischarge != "?")
                if (strWhere == "")
                    strWhere += _Query + " where PlaceofDischargeId=" + Data.PortofDischarge;
                else
                    strWhere += " and PlaceofDischargeId=" + Data.PortofDischarge;


            if (Data.BookingParty != "" && Data.BookingParty != "0" && Data.BookingParty != null && Data.BookingParty != "?")
                if (strWhere == "")
                    strWhere += _Query + " where BookingPartyID=" + Data.BookingParty;
                else
                    strWhere += " and BookingPartyID=" + Data.BookingParty;

            if (Data.Status != "" && Data.Status != "0" && Data.Status != null && Data.Status != "?")
                if (strWhere == "")
                    strWhere += _Query + " where RSStatus=" + Data.Status;
                else
                    strWhere += " and RSStatus=" + Data.Status;


            if (Data.AgentId.ToString() != "" && Data.AgentId.ToString() != "0" && Data.AgentId.ToString() != "2" && Data.AgentId.ToString() != "undefined" && Data.AgentId.ToString() != null)

                if (strWhere == "")
                    strWhere += _Query + " where NVO_Ratesheet.Agentid = " + Data.AgentId.ToString();
                else
                    strWhere += " and NVO_Ratesheet.Agentid = " + Data.AgentId.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " order by Id desc", "");
        }


        public List<MyRatesheet> RatesheetExistingMasterRecordView(string ID)
        {
            List<MyRatesheet> ViewList = new List<MyRatesheet>();
            DataTable dt = GetRatesheetExistingValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheet
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RatesheetNo = dt.Rows[i]["RatesheetNo"].ToString(),
                    Date = dt.Rows[i]["Date"].ToString(),
                    BookingPartyID = Int32.Parse(dt.Rows[i]["BookingPartyID"].ToString()),
                    SalesPersonID = Int32.Parse(dt.Rows[i]["SalesPersonID"].ToString()),
                    ShipmentID = Int32.Parse(dt.Rows[i]["ShipmentID"].ToString()),
                    PortOfOrgin = Int32.Parse(dt.Rows[i]["PortOfOrgin"].ToString()),
                    PortOfLoading = Int32.Parse(dt.Rows[i]["PortOfLoading"].ToString()),
                    ExpHaulageID = Int32.Parse(dt.Rows[i]["ExpHaulageID"].ToString()),
                    PlaceofDischargeId = Int32.Parse(dt.Rows[i]["PlaceofDischargeId"].ToString()),
                    FinalPODId = Int32.Parse(dt.Rows[i]["FinalPODId"].ToString()),
                    ImpHaulageId = Int32.Parse(dt.Rows[i]["ImpHaulageId"].ToString()),
                    TranshimentPortID = Int32.Parse(dt.Rows[i]["TranshimentPortID"].ToString()),
                    ServiceTypeID = Int32.Parse(dt.Rows[i]["ServiceTypeID"].ToString()),
                    ValidTill = dt.Rows[i]["ValidTill"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    POLName = dt.Rows[i]["POLName"].ToString(),
                    POLCode = dt.Rows[i]["POLCode"].ToString(),
                    PODName = dt.Rows[i]["PODName"].ToString(),
                    PODCode = dt.Rows[i]["PODCode"].ToString(),
                    BookingParty = dt.Rows[i]["BookingParty"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    RouteType = dt.Rows[i]["RouteType"].ToString(),
                    ShipperID = dt.Rows[i]["ShipperID"].ToString(),
                    ExportIHC = dt.Rows[i]["ExportIHC"].ToString(),
                    ImportIHC = dt.Rows[i]["ImportIHC"].ToString(),
                    IsRebate = dt.Rows[i]["IsRebate"].ToString(),
                    RebateAmt = dt.Rows[i]["RebateAmt"].ToString(),
                    OtherRemarks = dt.Rows[i]["OtherRemarks"].ToString(),
                    DocumentAttached = dt.Rows[i]["DocumentAttached"].ToString(),
                    SingleUser = dt.Rows[i]["SingleUser"].ToString(),
                    ValidTillStatus = dt.Rows[i]["ValidTillStatus"].ToString()




                });
            }
            return ViewList;
        }

        public DataTable GetRatesheetExistingValus(string RID)
        {
            string _Query = " select ID,RatesheetNo, convert(varchar, Date, 23) as Date,BookingPartyID,SalesPersonID,ShipmentID,PortOfOrgin,PortOfLoading,ExpHaulageID, " +
                            " PlaceofDischargeId,FinalPODId,ImpHaulageId,TranshimentPortID,ServiceTypeID, convert(varchar, ValidTill, 23) as ValidTill ,Remarks,RouteType,ShipperID,ExportIHC,ImportIHC,IsRebate,RebateAmt,OtherRemarks,DocumentAttached, " +
                            " (select top(1) PortName from NVO_PortMaster where  Id = PortOfLoading) as POLName, " +
                            " (select top(1) PortCode from NVO_PortMaster where  Id = PortOfLoading) as POLCode, " +
                            " (select top(1) PortName from NVO_PortMaster where  Id = PlaceofDischargeId) as PODName, " +
                            " (select top(1) PortCode from NVO_PortMaster where  Id = PlaceofDischargeId) as PODCode, " +
                            " (select top(1) CustomerName from NVO_CustomerMaster where ID =BookingPartyID) as BookingParty,(select top(1) Status from NVO_RRStatusMaster where ID = RSStatus) as Status,SingleUser, " +
                            " case when (ValidTill > Convert(varchar,DateAdd(day, -1,GetDate()),101)  or ValidTill is null) then 'ACTIVE' else 'EXPIRED' end as ValidTillStatus " +
                            " from NVO_Ratesheet where ID=" + RID;
            return GetViewData(_Query, "");
        }

        public List<MyRatesheet> RatesheetBkgCntrTypes(string ID)
        {
            List<MyRatesheet> ViewList = new List<MyRatesheet>();
            DataTable dt = GetRatesheetBkgCntrTypes(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheet
                {

                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    CommodityTypeID = Int32.Parse(dt.Rows[i]["CommodityTypeID"].ToString())
                });
            }
            return ViewList;
        }


        public DataTable GetRatesheetBkgCntrTypes(string RID)
        {
            string _Query = "select CntrTypeID,CommodityTypeID from NVO_RatesheetCntrTypes where RRID=" + RID;
            return GetViewData(_Query, "");
        }

        public List<MyRatesheet> RatesheetExistingDashBoard(string ID)
        {
            List<MyRatesheet> ViewList = new List<MyRatesheet>();
            DataTable dt = GetRatesheetDashBoardExistingValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheet
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RatesheetNo = dt.Rows[i]["RatesheetNo"].ToString(),
                    Date = dt.Rows[i]["Date"].ToString(),
                    BookingPartyID = Int32.Parse(dt.Rows[i]["BookingPartyID"].ToString()),
                    SalesPersonID = Int32.Parse(dt.Rows[i]["SalesPersonID"].ToString()),
                    ShipmentID = Int32.Parse(dt.Rows[i]["ShipmentID"].ToString()),
                    PortOfOrgin = Int32.Parse(dt.Rows[i]["PortOfOrgin"].ToString()),
                    PortOfLoading = Int32.Parse(dt.Rows[i]["PortOfLoading"].ToString()),
                    ExpHaulageID = Int32.Parse(dt.Rows[i]["ExpHaulageID"].ToString()),
                    PlaceofDischargeId = Int32.Parse(dt.Rows[i]["PlaceofDischargeId"].ToString()),
                    FinalPODId = Int32.Parse(dt.Rows[i]["FinalPODId"].ToString()),
                    ImpHaulageId = Int32.Parse(dt.Rows[i]["ImpHaulageId"].ToString()),
                    TranshimentPortID = Int32.Parse(dt.Rows[i]["TranshimentPortID"].ToString()),
                    ServiceTypeID = Int32.Parse(dt.Rows[i]["ServiceTypeID"].ToString()),
                    ValidTill = dt.Rows[i]["ValidTill"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    POLName = dt.Rows[i]["POLName"].ToString(),
                    POLCode = dt.Rows[i]["POLCode"].ToString(),
                    PODName = dt.Rows[i]["PODName"].ToString(),
                    PODCode = dt.Rows[i]["PODCode"].ToString(),
                    BookingParty = dt.Rows[i]["BookingParty"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    Tsport = dt.Rows[i]["TSPort"].ToString(),
                    CollectMode = dt.Rows[i]["PePaid"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOpt"].ToString(),
                    SalesMode = "FREE HAND",
                    Validate = dt.Rows[i]["ValidDate"].ToString()

                });
            }
            return ViewList;
        }


        public DataTable GetRatesheetDashBoardExistingValus(string RID)
        {
            string _Query = " select ID,RatesheetNo, convert(varchar, Date, 103) as Date,BookingPartyID,SalesPersonID,ShipmentID,PortOfOrgin,PortOfLoading,ExpHaulageID, " +
                            " PlaceofDischargeId,FinalPODId,ImpHaulageId,TranshimentPortID,ServiceTypeID, convert(varchar, ValidTill, 103) as ValidTill ,Remarks," +
                            " (select top(1) PortName from NVO_PortMaster where  Id = PortOfLoading) as POLName, " +
                            " (select top(1) PortCode from NVO_PortMaster where  Id = PortOfLoading) as POLCode, " +
                            " (select top(1) PortName from NVO_PortMaster where  Id = PlaceofDischargeId) as PODName, " +
                            " (select top(1) PortCode from NVO_PortMaster where  Id = PlaceofDischargeId) as PODCode, " +
                            " (select top(1) CustomerName from NVO_CustomerMaster where ID =BookingPartyID) as BookingParty,(select top(1) Status from NVO_RRStatusMaster where ID = RSStatus) as Status, " +
                            " (select top(1) PortName from NVO_PortMaster where  Id = TranshimentPortID) as TSPort,  " +
                            " (select top(1) ExFreeday from NVO_RatesheetCntrTypes where RRID = ID) as FreeDays, " +
                            " (select top(1)(select top(1) GeneralName from NVO_GeneralMaster where ID = NVO_RatesheetMRG.FreightTerms) from NVO_RatesheetMRG where RRID = NVO_Ratesheet.Id) as PePaid,  " +
                            " (select top(1)(select top(1) CustomerName from NVO_CustomerMaster where ID = slotOperator) from NVO_RatesheetSLOT where NVO_RatesheetSLOT.RRID = NVO_Ratesheet.Id)  as SlotOpt, " +
                            " convert(varchar, ValidTill, 106) as ValidDate " +
                            " from NVO_Ratesheet where ID=" + RID;
            return GetViewData(_Query, "");
        }

        public List<MyRatesheet> InsertRatesheetContainerMaster(MyRatesheet Data)
        {

            int result = 0;
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

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCntrTypes where RRID=@RRID and RCID=@RCID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetCntrTypes(RRID,CntrTypeID,CommodityTypeID,ExFreeday,ImFreeday,VGM) " +
                                     " values (@RRID,@CntrTypeID,@CommodityTypeID,@ExFreeday,@ImFreeday,@VGM) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetCntrTypes SET RRID=@RRID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID,ExFreeday=@ExFreeday,ImFreeday=@ImFreeday,VGM=@VGM where RRID=@RRID and RCID=@RCID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RCID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ExFreeday", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ImFreeday", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VGM", CharSplit[5]));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }


                    trans.Commit();

                    RateList.Add(new MyRatesheet { RRID = Data.RRID });
                    return RateList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return RateList;
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


        public List<MyRatesheet> RatesheetContainerExistingView(string ID)
        {
            List<MyRatesheet> ViewList = new List<MyRatesheet>();
            DataTable dt = GetRatesheetContainerExistingValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheet
                {
                    RCID = Int32.Parse(dt.Rows[i]["RCID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    CommodityTypeID = Int32.Parse(dt.Rows[i]["CommodityTypeID"].ToString()),
                    DGClass = dt.Rows[i]["DGClass"].ToString(),
                    VGM = decimal.Parse(dt.Rows[i]["VGM"].ToString())

                });
            }
            return ViewList;
        }

        public List<MyRatesheet> RatesheetModeExistingView(string ID)
        {
            List<MyRatesheet> ViewList = new List<MyRatesheet>();
            DataTable dt = GetRatesheetModeExistingValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheet
                {
                    Mode = dt.Rows[i]["ModeID"].ToString(),
                    ExpFreeDays = dt.Rows[i]["ExpFreeDays"].ToString(),
                    ImpFreeDays = dt.Rows[i]["ImpFreeDays"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetRatesheetModeExistingValus(string RID)
        {
            string _Query = " select * from NVO_RatesheetMode where RRID = " + RID;
            return GetViewData(_Query, "");
        }

        public List<MyRatesheet> RatesheetTsPortExistingView(string ID)
        {
            List<MyRatesheet> ViewList = new List<MyRatesheet>();
            DataTable dt = GetRatesheetTsPortExistingValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheet
                {
                    PortID = dt.Rows[i]["TsPortID"].ToString()

                });
            }
            return ViewList;
        }
        public DataTable GetRatesheetTsPortExistingValus(string RID)
        {
            string _Query = " select * from NVO_RatesheetTranshipmentPort where RRID = " + RID;
            return GetViewData(_Query, "");
        }
        public DataTable GetRatesheetContainerExistingValus(string RID)
        {
            string _Query = " select * from NVO_RatesheetCntrTypes where RRID = " + RID;
            return GetViewData(_Query, "");
        }

        public List<MyRatesheet> InsertRatesheetRateChargeMaster(MyRatesheet Data)
        {

            int result = 0;
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
                    if (Data.Itemsv.Length > 0)
                    {
                        string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_RatesheetRevRate where RRID=@RRID and RID=@RID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_RatesheetRevRate(RRID,ChargeCodeID,infoChID,BasicID,CntrTypeID,CommodityTypeID,CurrencyID,Amt,CollectionModeID,CollectionAgentID,ChargeOwnershipID,ShipmentType) " +
                                         " values (@RRID,@ChargeCodeID,@infoChID,@BasicID,@CntrTypeID,@CommodityTypeID,@CurrencyID,@Amt,@CollectionModeID,@CollectionAgentID,@ChargeOwnershipID,@ShipmentType) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_RatesheetRevRate SET RRID=@RRID,ChargeCodeID=@ChargeCodeID,infoChID=@infoChID,BasicID=@BasicID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID," +
                                         " CurrencyID=@CurrencyID,Amt=@Amt,CollectionModeID=@CollectionModeID,CollectionAgentID=@CollectionAgentID,ChargeOwnershipID=@ChargeOwnershipID,ShipmentType=@ShipmentType where RRID=@RRID and RID=@RID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@infoChID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amt", CharSplit[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionModeID", CharSplit[8]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionAgentID", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeOwnershipID", CharSplit[9]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentType", 1));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }
                    if (Data.ItemsvImp.Length > 0)
                    {
                        string[] ArrayImp = Data.ItemsvImp.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ArrayImp.Length; i++)
                        {
                            var CharSplitImp = ArrayImp[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_RatesheetRevRate where RRID=@RRID and RID=@RID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_RatesheetRevRate(RRID,ChargeCodeID,infoChID,BasicID,CntrTypeID,CommodityTypeID,CurrencyID,Amt,CollectionModeID,CollectionAgentID,ChargeOwnershipID,ShipmentType) " +
                                         " values (@RRID,@ChargeCodeID,@infoChID,@BasicID,@CntrTypeID,@CommodityTypeID,@CurrencyID,@Amt,@CollectionModeID,@CollectionAgentID,@ChargeOwnershipID,@ShipmentType) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_RatesheetRevRate SET RRID=@RRID,ChargeCodeID=@ChargeCodeID,infoChID=@infoChID,BasicID=@BasicID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID," +
                                         " CurrencyID=@CurrencyID,Amt=@Amt,CollectionModeID=@CollectionModeID,CollectionAgentID=@CollectionAgentID,ChargeOwnershipID=@ChargeOwnershipID,ShipmentType=@ShipmentType where RRID=@RRID and RID=@RID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RID", CharSplitImp[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplitImp[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@infoChID", CharSplitImp[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", CharSplitImp[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplitImp[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", CharSplitImp[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplitImp[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amt", CharSplitImp[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionModeID", CharSplitImp[8]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionAgentID", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeOwnershipID", CharSplitImp[9]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentType", 2));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    if (Data.ItemsCR.Length > 0)
                    {
                        string[] Arrayv = Data.ItemsCR.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Arrayv.Length; i++)
                        {
                            var CharSplit = Arrayv[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCostRate where RRID=@RRID and RID=@RID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_RatesheetCostRate(RRID,ChargeCodeID,BasicID,CntrTypeID,CommodityTypeID,CurrencyID,Amt,CollectionModeID,CollectionAgentID,ChargeOwnershipID,ShipmentType) " +
                                         " values (@RRID,@ChargeCodeID,@BasicID,@CntrTypeID,@CommodityTypeID,@CurrencyID,@Amt,@CollectionModeID,@CollectionAgentID,@ChargeOwnershipID,@ShipmentType) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_RatesheetCostRate SET RRID=@RRID,ChargeCodeID=@ChargeCodeID,BasicID=@BasicID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID," +
                                         " CurrencyID=@CurrencyID,Amt=@Amt,CollectionModeID=@CollectionModeID,CollectionAgentID=@CollectionAgentID,ChargeOwnershipID=@ChargeOwnershipID,ShipmentType=@ShipmentType where RRID=@RRID and RID=@RID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amt", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionModeID", CharSplit[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionAgentID", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeOwnershipID", CharSplit[8]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentType", 1));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }
                    if (Data.ItemsCRImp.Length > 0)
                    {
                        string[] ArrayvImp = Data.ItemsCRImp.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ArrayvImp.Length; i++)
                        {
                            var CharSplitImp = ArrayvImp[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_RatesheetCostRate where RRID=@RRID and RID=@RID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_RatesheetCostRate(RRID,ChargeCodeID,BasicID,CntrTypeID,CommodityTypeID,CurrencyID,Amt,CollectionModeID,CollectionAgentID,ChargeOwnershipID,ShipmentType) " +
                                         " values (@RRID,@ChargeCodeID,@BasicID,@CntrTypeID,@CommodityTypeID,@CurrencyID,@Amt,@CollectionModeID,@CollectionAgentID,@ChargeOwnershipID,@ShipmentType) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_RatesheetCostRate SET RRID=@RRID,ChargeCodeID=@ChargeCodeID,BasicID=@BasicID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID," +
                                         " CurrencyID=@CurrencyID,Amt=@Amt,CollectionModeID=@CollectionModeID,CollectionAgentID=@CollectionAgentID,ChargeOwnershipID=@ChargeOwnershipID,ShipmentType=@ShipmentType where RRID=@RRID and RID=@RID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RID", CharSplitImp[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplitImp[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", CharSplitImp[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplitImp[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", CharSplitImp[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplitImp[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amt", CharSplitImp[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionModeID", CharSplitImp[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionAgentID", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeOwnershipID", CharSplitImp[8]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentType", 2));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }
                    if (Data.ItemsTrans.Length > 0)
                    {
                        string[] ArrayvTrans = Data.ItemsTrans.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ArrayvTrans.Length; i++)
                        {
                            var CharSplitTrans = ArrayvTrans[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_RatesheetTranshimentRate where RRID=@RRID and RID=@RID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_RatesheetTranshimentRate(RRID,ChargeCodeID,BasicID,CntrTypeID,CommodityTypeID,CurrencyID,Amt,CollectionModeID,CollectionAgentID,ChargeOwnershipID,ShipmentType) " +
                                         " values (@RRID,@ChargeCodeID,@BasicID,@CntrTypeID,@CommodityTypeID,@CurrencyID,@Amt,@CollectionModeID,@CollectionAgentID,@ChargeOwnershipID,@ShipmentType) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_RatesheetTranshimentRate SET RRID=@RRID,ChargeCodeID=@ChargeCodeID,BasicID=@BasicID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID," +
                                         " CurrencyID=@CurrencyID,Amt=@Amt,CollectionModeID=@CollectionModeID,CollectionAgentID=@CollectionAgentID,ChargeOwnershipID=@ChargeOwnershipID,ShipmentType=@ShipmentType where RRID=@RRID and RID=@RID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RID", ArrayvTrans[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", ArrayvTrans[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", ArrayvTrans[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", ArrayvTrans[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", ArrayvTrans[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", ArrayvTrans[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amt", ArrayvTrans[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionModeID", ArrayvTrans[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionAgentID", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeOwnershipID", ArrayvTrans[8]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentType", 2));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }

                    }


                    trans.Commit();

                    RateList.Add(new MyRatesheet { RRID = Data.RRID });
                    return RateList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return RateList;
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



        public List<MyRatesheetRates> RatesheetRevRateExistingView(MyRatesheetRates Data)
        {
            List<MyRatesheetRates> ViewList = new List<MyRatesheetRates>();
            DataTable dt = GetRatesheetRevRateExistingValus(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheetRates
                {
                    RID = Int32.Parse(dt.Rows[i]["RID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeCodeID"].ToString()),
                    infoChID = Int32.Parse(dt.Rows[i]["infoChID"].ToString()),
                    BasicID = Int32.Parse(dt.Rows[i]["BasicID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    CommodityTypeID = Int32.Parse(dt.Rows[i]["CommodityTypeID"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    Amt = decimal.Parse(dt.Rows[i]["Amt"].ToString()),
                    CollectionModeID = Int32.Parse(dt.Rows[i]["CollectionModeID"].ToString()),
                    CollectionAgentID = Int32.Parse(dt.Rows[i]["CollectionAgentID"].ToString()),
                    ChargeOwnershipID = Int32.Parse(dt.Rows[i]["ChargeOwnershipID"].ToString()),
                });
            }

            return ViewList;
        }


        public DataTable GetRatesheetRevRateExistingValus(MyRatesheetRates Data)
        {
            string _Query = "Select * from NVO_RatesheetRevRate where RRID=" + Data.RRID + " and ShipmentType=" + Data.ShipmentType;
            return GetViewData(_Query, "");
        }


        public List<MyRatesheetRates> RatesheetCostRateExistingView(MyRatesheetRates Data)
        {
            List<MyRatesheetRates> ViewList = new List<MyRatesheetRates>();
            DataTable dt = GetRatesheetCostRateExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheetRates
                {
                    RID = Int32.Parse(dt.Rows[i]["RID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeCodeID"].ToString()),
                    BasicID = Int32.Parse(dt.Rows[i]["BasicID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    CommodityTypeID = Int32.Parse(dt.Rows[i]["CommodityTypeID"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    Amt = decimal.Parse(dt.Rows[i]["Amt"].ToString()),
                    CollectionModeID = Int32.Parse(dt.Rows[i]["CollectionModeID"].ToString()),
                    CollectionAgentID = Int32.Parse(dt.Rows[i]["CollectionAgentID"].ToString()),
                    ChargeOwnershipID = Int32.Parse(dt.Rows[i]["ChargeOwnershipID"].ToString()),



                });
            }
            return ViewList;
        }
        public DataTable GetRatesheetCostRateExistingValus(MyRatesheetRates Data)
        {
            string _Query = "Select * from NVO_RatesheetCostRate where RRID=" + Data.RRID + " and ShipmentType=" + Data.ShipmentType;
            return GetViewData(_Query, "");
        }

        public List<MyRatesheetRates> RatesheetCostRateTransExistingView(MyRatesheetRates Data)
        {
            List<MyRatesheetRates> ViewList = new List<MyRatesheetRates>();
            DataTable dt = GetRatesheetCostRateTransExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheetRates
                {
                    RID = Int32.Parse(dt.Rows[i]["RID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeCodeID"].ToString()),
                    BasicID = Int32.Parse(dt.Rows[i]["BasicID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    CommodityTypeID = Int32.Parse(dt.Rows[i]["CommodityTypeID"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    Amt = decimal.Parse(dt.Rows[i]["Amt"].ToString()),
                    CollectionModeID = Int32.Parse(dt.Rows[i]["CollectionModeID"].ToString()),
                    CollectionAgentID = Int32.Parse(dt.Rows[i]["CollectionAgentID"].ToString()),
                    ChargeOwnershipID = Int32.Parse(dt.Rows[i]["ChargeOwnershipID"].ToString()),



                });
            }
            return ViewList;
        }


        public DataTable GetRatesheetCostRateTransExistingValus(MyRatesheetRates Data)
        {
            string _Query = "Select * from NVO_RatesheetTranshimentRate where RRID=" + Data.RRID + " and ShipmentType=" + Data.ShipmentType;
            return GetViewData(_Query, "");
        }
        public List<MyRRMRG> RatesheetMRGView(string ID)
        {
            List<MyRRMRG> ViewList = new List<MyRRMRG>();
            DataTable dt = GetRatesheetMRGValus(ID);
            //if (dt.Rows.Count > 0)
            //{
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRMRG
                {
                    RCID = Int32.Parse(dt.Rows[i]["RCID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    MRGAmt = dt.Rows[i]["MRGAmt"].ToString(),
                    QuotedAmt = dt.Rows[i]["QuotedAmt"].ToString(),
                    FreightTems = dt.Rows[i]["FreightTems"].ToString(),
                    AgentID = Int32.Parse(dt.Rows[i]["AgentID"].ToString()),
                    Size = dt.Rows[i]["size"].ToString()

                });
            }

            return ViewList;
        }
        public DataTable GetRatesheetMRGValus(string RID)
        {
            string _Query = " Select NVO_MRGRate.Id as RCID, PortOfLoading,PlaceofDischargeId,CntrTypeID,CommodityTypeID ,Amount as MRGAmt, Amount as QuotedAmt, 18 as FreightTems,NVO_Ratesheet.AgentID, " +
                            " (select top(1) size from NVO_tblCntrTypes where ID = CntrTypeID) as size  " +
                            " from NVO_Ratesheet inner join NVO_RatesheetCntrTypes on NVO_RatesheetCntrTypes.RRID = NVO_Ratesheet.ID " +
                            " inner join NVO_MRGRate on NVO_MRGRate.PofLoading = NVO_Ratesheet.PortOfLoading and NVO_MRGRate.PofDischarge = NVO_Ratesheet.PlaceofDischargeId " +
                            " AND NVO_MRGRate.CntrTypes = NVO_RatesheetCntrTypes.CntrTypeID AND NVO_MRGRate.Commodity = NVO_RatesheetCntrTypes.CommodityTypeID " +
                            " where NVO_Ratesheet.Id = " + RID;
            return GetViewData(_Query, "");
        }

        public List<MyRRMRG> RatesheetSLOTView(string ID)
        {
            List<MyRRMRG> ViewList = new List<MyRRMRG>();
            DataTable dt = GetRatesheetSLOTValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRMRG
                {
                    RSID = Int32.Parse(dt.Rows[i]["RSID"].ToString()),
                    SlotOperator = Int32.Parse(dt.Rows[i]["SlotOperator"].ToString()),
                    SlotTermID = Int32.Parse(dt.Rows[i]["SlotTermID"].ToString()),
                    SlotRef = dt.Rows[i]["SlotRef"].ToString(),
                    ValidDate = dt.Rows[i]["ValidDate"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetRatesheetSLOTValus(string RID)
        {
            string _Query = " SELECT SlotRef,convert(varchar,ValidTo, 106) as ValidDate,NVO_SLOTMaster.ID as RSID,SlotOperator,SlotTermID FROM NVO_SLOTMaster " +
                            " inner join NVO_Ratesheet on NVO_Ratesheet.PortOfLoading = NVO_SLOTMaster.POL and NVO_Ratesheet.PlaceofDischargeId = NVO_SLOTMaster.POD " +
                            " where NVO_Ratesheet.Id =" + RID;
            return GetViewData(_Query, "");
        }


        public List<MyRRMRG> RatesheetSLOTDtlsView(string ID)
        {
            List<MyRRMRG> ViewList = new List<MyRRMRG>();
            DataTable dt = GetRatesheetSLOTDtlsValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRMRG
                {
                    RSIDD = Int32.Parse(dt.Rows[i]["RSIDD"].ToString()),
                    ChargeID = Int32.Parse(dt.Rows[i]["ChargeID"].ToString()),
                    SizeID = Int32.Parse(dt.Rows[i]["SizeID"].ToString()),
                    CommodityID = Int32.Parse(dt.Rows[i]["Commodity"].ToString()),
                    Amount = dt.Rows[i]["Amount"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetRatesheetSLOTDtlsValus(string RID)
        {
            string _Query = " SELECT NVO_SLOTDDtls.SID as RSIDD,SizeID,Commodity,Amount,ChargeID FROM NVO_SLOTMaster " +
                            " inner join NVO_SLOTDDtls on NVO_SLOTDDtls.SLID = NVO_SLOTMaster.ID " +
                            " inner join NVO_Ratesheet on NVO_Ratesheet.PortOfLoading = NVO_SLOTMaster.POL and NVO_Ratesheet.PlaceofDischargeId = NVO_SLOTMaster.POD " +
                            " where NVO_Ratesheet.Id=" + RID;
            return GetViewData(_Query, "");
        }



        public List<MyRRMRG> InsertRatesheetMRGSLOTMaster(MyRRMRG Data)
        {
            List<MyRRMRG> ListView = new List<MyRRMRG>();

            int result = 0;
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

                    string[] Array = Data.MRGItemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetMRG where RRID=@RRID and MRGID=@MRGID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetMRG(RRID,MRGID,QuotedAmount,FreightTerms,CntrTypes) " +
                                     " values (@RRID,@MRGID,@QuotedAmount,@FreightTerms,@CntrTypes) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetMRG SET RRID=@RRID,MRGID=@MRGID,QuotedAmount=@QuotedAmount,FreightTerms=@FreightTerms,CntrTypes=@CntrTypes where RRID=@RRID and MRGID=@MRGID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MRGID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@QuotedAmount", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@FreightTerms", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypes", CharSplit[3]));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }
                    string[] Array1 = Data.SLTItemsv.Split(new[] { "Insert1:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetSLOT where RRID=@RRID and SLTID=@SLTID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetSLOT(RRID,SLTID,SlotOperator,SlotTerm) " +
                                     " values (@RRID,@SLTID,@SlotOperator,@SlotTerm) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetSLOT SET RRID=@RRID,SLTID=@SLTID,SlotOperator=@SlotOperator,SlotTerm=@SlotTerm where RRID=@RRID and SLTID=@SLTID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SLTID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotOperator", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotTerm", CharSplit[2]));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] Array2 = Data.SLTDItemsv.Split(new[] { "Insert2:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array2.Length; i++)
                    {
                        var CharSplit = Array2[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetSLOTDtls where RRID=@RRID and SLTIDD=@SLTIDD)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetSLOTDtls(RRID,SLTIDD,ChargeCode,CntrTypes,Commodity,SlotAmt) " +
                                     " values (@RRID,@SLTIDD,@ChargeCode,@CntrTypes,@Commodity,@SlotAmt) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetSLOTDtls SET RRID=@RRID,SLTIDD=@SLTIDD,ChargeCode=@ChargeCode,CntrTypes=@CntrTypes,Commodity=@Commodity,SlotAmt=@SlotAmt where RRID=@RRID and SLTIDD=@SLTIDD";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SLTIDD", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCode", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypes", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Commodity", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotAmt", CharSplit[4]));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }


                    trans.Commit();

                    ListView.Add(new MyRRMRG { RRID = Data.RRID });
                    return ListView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListView;
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


        public List<MyRRMRG> RatesheetMRGSelectView(MyRRMRG Data)
        {
            List<MyRRMRG> ViewList = new List<MyRRMRG>();
            DataTable dt = GetRatesheetMRGSelectValus(Data.RRID.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRMRG
                {

                    MRGID = Int32.Parse(dt.Rows[i]["MRGID"].ToString()),
                    QuotedAmount = dt.Rows[i]["QuotedAmount"].ToString()

                });
            }
            return ViewList;
        }
        public DataTable GetRatesheetMRGSelectValus(string RID)
        {
            string _Query = "select * from NVO_RatesheetMRG where RRID=" + RID;
            return GetViewData(_Query, "");
        }

        public List<MyRRMRG> RatesheetSLOTSelectView(MyRRMRG Data)
        {
            List<MyRRMRG> ViewList = new List<MyRRMRG>();
            DataTable dt = GetRatesheetSLOTSelectValus(Data.RRID.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRMRG
                {
                    SLTID = Int32.Parse(dt.Rows[i]["SLTID"].ToString())
                });
            }
            return ViewList;
        }

        public DataTable GetRatesheetSLOTSelectValus(string RID)
        {
            string _Query = "select * from NVO_RatesheetSLOT where RRID=" + RID;
            return GetViewData(_Query, "");
        }
        public List<MyRRMRG> RatesheetSLOTDtlsSelectView(MyRRMRG Data)
        {
            List<MyRRMRG> ViewList = new List<MyRRMRG>();
            DataTable dt = GetRatesheetSLOTDtlsSelectValus(Data.RRID.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRMRG
                {
                    SLTIDD = Int32.Parse(dt.Rows[i]["SLTIDD"].ToString())
                });
            }
            return ViewList;
        }
        public DataTable GetRatesheetSLOTDtlsSelectValus(string RID)
        {
            string _Query = "select * from NVO_RatesheetSLOTDtls where RRID=" + RID;
            return GetViewData(_Query, "");
        }


        public List<MyRatesheetRates> RatesheetCeckTariffRevRateExistingView(MyRatesheetRates Data)
        {
            List<MyRatesheetRates> ViewList = new List<MyRatesheetRates>();
            DataTable dt = GetRatesheetCheckTariffRevRateExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheetRates
                {
                    RID = Int32.Parse(dt.Rows[i]["RID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeCodeID"].ToString()),
                    infoChID = Int32.Parse(dt.Rows[i]["infoChID"].ToString()),
                    BasicID = Int32.Parse(dt.Rows[i]["BasicID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    CommodityTypeID = Int32.Parse(dt.Rows[i]["CommodityTypeID"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    Amt = decimal.Parse(dt.Rows[i]["Amt"].ToString()),
                    CollectionModeID = Int32.Parse(dt.Rows[i]["CollectionModeID"].ToString()),
                    ChargeOwnershipID = Int32.Parse(dt.Rows[i]["ChargeOwnershipID"].ToString()),



                });
            }
            return ViewList;
        }
        public DataTable GetRatesheetCheckTariffRevRateExistingValus(MyRatesheetRates Data)
        {
            string _Query = " select TID,PTID,0 as RID,ChargeCodeID, 1 as infoChID, BasisID as BasicID,CntrID as CntrTypeID,CurrencyID as CurrencyID,Amount as Amt, " +
                            " CommodityTypeID,CollectionModeID, 23 as ChargeOwnershipID from NVO_Ratesheet " +
                            " inner join NVO_PortTariffMaster on NVO_PortTariffMaster.PortLocationID = NVO_Ratesheet.PortOfLoading " +
                            " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                            " where NVO_PortTariffMaster.ValidTo >= NVO_Ratesheet.Date and ShipmentID=" + Data.ShipmentType + " and NVO_Ratesheet.Id=" + Data.RRID + " and CollectionModeID = " + Data.CollectionModeID + " and ChargeTypeID = " + Data.ChargeCodeID;
            return GetViewData(_Query, "");
        }



        public List<MyRatesheet> InsertRatesheetRebateMaster(MyRatesheet Data)
        {

            int result = 0;
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

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_RatesheetRebate where RRID=@RRID and RBID=@RBID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_RatesheetRebate(RRID,ChargeCodeId,FRT,Rebate,Vendor,Remarks) " +
                                     " values (@RRID,@ChargeCodeId,@FRT,@Rebate,@Vendor,@Remarks) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RatesheetRebate SET RRID=@RRID,ChargeCodeId=@ChargeCodeId,FRT=@FRT,Rebate=@Rebate,Vendor=@Vendor,Remarks=@Remarks where RRID=@RRID and RBID=@RBID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RBID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@FRT", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Rebate", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Vendor", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", CharSplit[5]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    trans.Commit();

                    RateList.Add(new MyRatesheet { RRID = Data.RRID });
                    return RateList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return RateList;
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


        public List<MyRatesheetRates> RatesheetRebateExistingView(MyRatesheetRates Data)
        {
            List<MyRatesheetRates> ViewList = new List<MyRatesheetRates>();
            DataTable dt = GetRatesheetRebateExistingValus(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheetRates
                {
                    RBID = Int32.Parse(dt.Rows[i]["RBID"].ToString()),
                    ChargeCodeID = Int32.Parse(dt.Rows[i]["ChargeCodeID"].ToString()),
                    FRT = dt.Rows[i]["FRT"].ToString(),
                    Rebate = dt.Rows[i]["Rebate"].ToString(),
                    Vendor = dt.Rows[i]["Vendor"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),

                });
            }

            return ViewList;
        }


        public DataTable GetRatesheetRebateExistingValus(MyRatesheetRates Data)
        {
            string _Query = "Select * from NVO_RatesheetRebate where RRID=" + Data.RRID;
            return GetViewData(_Query, "");
        }


        public List<MyRatesheet> SendingApproval(MyRatesheet Data)
        {

            int result = 0;
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
                    if (Data.Status == "0")
                    {
                        Cmd.CommandText = " UPDATE NVO_Ratesheet SET RSStatus=@RSStatus where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", Data.Status));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        trans.Commit();
                    }
                    if (Data.Status == "1")
                    {
                        Cmd.CommandText = " UPDATE NVO_Ratesheet SET RSStatus=@RSStatus where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", Data.Status));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        trans.Commit();
                    }
                    if (Data.Status == "2")
                    {
                        Cmd.CommandText = " UPDATE NVO_Ratesheet SET RSStatus=@RSStatus,RJStatus=@RJStatus,RJRemarks=@RJRemarks,RejectedBy=@RejectedBy,DtRejected=@DtRejected where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RJStatus", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RJRemarks", Data.Notes));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RejectedBy", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtRejected", System.DateTime.Now));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        trans.Commit();
                    }
                    if (Data.Status == "3")
                    {
                        Cmd.CommandText = " UPDATE NVO_Ratesheet SET RSStatus=@RSStatus, REStatus=@REStatus,RERemarks=@RERemarks,RequotedBy=@RequotedBy,DtRequoted=@DtRequoted where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@REStatus", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RERemarks", Data.Notes));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RequotedBy", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtRequoted", System.DateTime.Now));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        trans.Commit();
                    }

                    if (Data.Status == "4")
                    {
                        Cmd.CommandText = " UPDATE NVO_Ratesheet SET RSStatus=@RSStatus,APStatus=@APStatus,APRemarks=@APRemarks,ApprovedBy=@ApprovedBy,DtApproved=@DtApproved where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@APStatus", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@APRemarks", Data.Notes));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ApprovedBy", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtApproved", System.DateTime.Now));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        trans.Commit();
                    }

                    RateList.Add(new MyRatesheet { ID = Data.ID });
                    //if (Data.Status == "1")
                    //{
                    //    DataTable dtE = GetEmailsedingRRView(Data.ID.ToString());
                    //    if (dtE.Rows.Count > 0)
                    //    {
                    //        string HTMLstr = "";

                    //        HTMLstr = "<table border='1' cellpadding='0' cellspacing='0' width='50%' style='font-family:Arial; border: 1px solid #2196f3;'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td style='background-color:#2196f3;color:#fff;border-right:0px solid #303297;border-left:0px solid #303297;border-top:0px solid #303297;border-bottom:0px solid #303297'> " +
                    //                  " <table cellpadding='0' cellspacing='0' width='100%'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td style='font-family:Arial;font-size:14px;font-weight:bold;text-align:left;color:#fff;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;'>RR NUMBER : <a href='https://nerida.rmjtech.in/RRPDF/" + dtE.Rows[0]["RatesheetNo"].ToString() + ".pdf' style='color:#fff;'>" + dtE.Rows[0]["RatesheetNo"].ToString() + "</a></td> " +
                    //                  " <td style='font-family:Arial;font-size:14px;font-weight:bold;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;text-align:right;'> STATUS : " + dtE.Rows[0]["Status"].ToString() + "</td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td style='border:none;'> " +
                    //                  " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px; font-size:14px;'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2'> " +
                    //                  " <p style='margin-top: 10px;margin-bottom:0px;margin-left:10px;padding-bottom:0;'>Hi,</p><p style='padding-top:0;margin-top:0;'>This is the system generated message to notify the rate request details</p> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td style ='border:none;'> " +
                    //                  " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='background-color:#2196f3;color:#fff;padding-left:4px;padding-top:4px;padding-bottom:4px;font-size:14px;'> Rate Request Details</td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td style='border:none;'> " +
                    //                  " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px; padding-bottom:8px; font-size:14px;'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2'> " +
                    //                  " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='font-weight:bold;'> Customer </td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["Customer"].ToString() + "</td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='font-weight:bold;'> Loading </td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='padding-bottom:8px;'> " + dtE.Rows[0]["Loading"].ToString() + " </td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='font-weight:bold;'>T/S Port</td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["TSPort"].ToString() + "</td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                   " <td colspan='2' style='font-weight:bold;'>Freedays</td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["Freedays"].ToString() + " Days</td> " +
                    //                  " </tr> " +
                    //                   " <tr> " +
                    //                   " <td colspan='2' style='font-weight:bold;'>Collection Mode</td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["PePaid"].ToString() + "</td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " <td colspan='2'> " +
                    //                  " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='font-weight:bold;'> Sales Person </td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["SalesPerson"].ToString() + "</td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='font-weight:bold;'> Discharge </td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='padding-bottom:8px;'> " + dtE.Rows[0]["Discharge"].ToString() + " </td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='font-weight:bold;'>Commodity</td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='padding-bottom:8px;'>GENERAL CARGO</td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                   " <td colspan='2' style='font-weight:bold;'>Validity Till</td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["ValidDate"].ToString() + "</td> " +
                    //                  " </tr> " +
                    //                   " <tr> " +
                    //                   " <td colspan='2' style='font-weight:bold;'>Remarks</td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["Remarks"].ToString() + "</td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                  " <td style ='border:none;'> " +
                    //                  " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='background-color:#2196f3;color:#fff;padding-left:4px;padding-top:4px;padding-bottom:4px;font-size:14px;'> Rate</td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                   " <tr> " +
                    //                  " <td style='border:none;'> " +
                    //                  " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;font-size:14px;'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2'>" +
                    //                   " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='font-weight:bold;'>20GP - " + dtE.Rows[0]["Cntr20"].ToString() + " USD</td>" +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                   " <td colspan='2'>" +
                    //                   " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='font-weight:bold;'>40HC - " + dtE.Rows[0]["Cntr40"].ToString() + " USD</td>" +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                    " <tr> " +
                    //                  " <td style='border:none;'> " +
                    //                  " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='background-color:#2196f3;color:#fff; padding-left:4px;padding-top:4px;padding-bottom:4px;font-size:14px;'> Slot Cost </td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                   " <tr> " +
                    //                  " <td style='border:none;'> " +
                    //                  " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;font-size:14px;'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2'>" +
                    //                   " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='font-weight:bold;'>20GP - " + dtE.Rows[0]["Slot20"].ToString() + " USD</td>" +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                   " <td colspan='2'>" +
                    //                   " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='font-weight:bold;'>40HC - " + dtE.Rows[0]["Slot40"].ToString() + " USD</td>" +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                  " <tr> " +
                    //                    " <td style='border:none;'> " +
                    //                  " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='color:#000; padding-left:4px;padding-top:4px;padding-bottom:4px;font-size:14px;'> Slot Operator </td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                   " <tr> " +
                    //                    " <td style='border:none;'> " +
                    //                  " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;font-size:14px;'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='font-weight:bold;'>" + dtE.Rows[0]["SlotOpt"].ToString() + "</td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                    " <tr> " +
                    //                  " <td style='border:none;'> " +
                    //                  " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;padding-top:6px;border-top:1px solid #2196f3;font-size:14px;'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2'>" +
                    //                   " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='font-weight:bold;'>Created By: Venkat</td>" +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                   " <td colspan='2'>" +
                    //                   " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding:left:64px!important;'> " +
                    //                  " <tbody> " +
                    //                  " <tr> " +
                    //                  " <td colspan='2' style='font-weight:bold;'>Created On : 10/05/2021</td>" +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table> " +
                    //                  " </td> " +
                    //                  " </tr> " +
                    //                  " </tbody> " +
                    //                  " </table>";

                    //        MailMessage EmailObject = new MailMessage();
                    //        EmailObject.From = new MailAddress("noreply@nerida-shipping.com", "   NERIDA SHIPPING");
                    //        DataTable dtAuto = GetCustomerEmailsending(Data.AgentId);
                    //        var EmailID = dtAuto.Rows[0]["EmailID"].ToString().Split(',');
                    //        for (int y = 0; y < EmailID.Length; y++)
                    //        {
                    //            if (EmailID[y].ToString() != "")
                    //            {
                    //                EmailObject.To.Add(new MailAddress(EmailID[y].ToString()));
                    //            }
                    //        }

                    //        EmailObject.Attachments.Add(new Attachment(Server.MapPath("~/PrePDF\\" + dtE.Rows[0]["RatesheetNo"].ToString() + ".pdf")));
                    //        EmailObject.Body = HTMLstr;
                    //        EmailObject.IsBodyHtml = true;
                    //        EmailObject.Priority = MailPriority.Normal;
                    //        EmailObject.Subject = "Rate Request: " + dtE.Rows[0]["RatesheetNo"].ToString() + " - APPROVAL PENDING";
                    //        EmailObject.Priority = MailPriority.Normal;
                    //        SmtpClient SMTPServer = new SmtpClient();
                    //        SMTPServer.UseDefaultCredentials = true;
                    //        SMTPServer.Credentials = new NetworkCredential("noreply@nerida-shipping.com", "Automail@123");
                    //        SMTPServer.Host = "smtp.office365.com";
                    //        SMTPServer.ServicePoint.MaxIdleTime = 1;
                    //        SMTPServer.Port = 587;
                    //        SMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //        SMTPServer.EnableSsl = true;
                    //        SMTPServer.Send(EmailObject);
                    //    }
                    //}

                    return RateList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return RateList;
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
        public DataTable GetCustomerEmailsending(int AgentID)
        {
            string _Query = "select EmailID from NVO_AgencyEmailDtls where AlertTypeID = 1 and AgencyID=" + AgentID;
            return GetViewData(_Query, "");
        }
        public DataTable GetEmailsedingRRView(string RRID)
        {
            string _Query = " select NVO_Ratesheet.Id,RatesheetNo,convert(varchar, ValidTill, 106) as ValidDate,(select top(1) Status from NVO_RRStatusMaster where Id = NVO_Ratesheet.RSStatus) as Status,  " +
                            " (select top(1) CustomerName from NVO_CustomerMaster where ID = BookingPartyID) as Customer, " +
                            " (select top(1) UserName from NVO_UserDetails where ID = NVO_Ratesheet.AgentID) as SalesPerson, " +
                            " (select top(1) PortName from NVO_PortMaster where ID = PortOfLoading) as Loading, " +
                            " (select top(1) PortName from NVO_PortMaster where ID = PlaceofDischargeId) as Discharge, " +
                            " (select top(1) PortName from NVO_PortMaster where ID = TranshimentPortID) as TSPort, '14' as Freedays,Remarks, " +
                            " (select top(1)(select top(1) GeneralName from NVO_GeneralMaster where ID = NVO_RatesheetMRG.FreightTerms) from NVO_RatesheetMRG where RRID = NVO_Ratesheet.Id) as PePaid, " +
                            " (select top(1)(select top(1) Size from NVO_tblCntrTypes where SizeId = 1 and ID = NVO_RatesheetMRG.CntrTypes) from NVO_RatesheetMRG where RRID = NVO_Ratesheet.Id) as Cntr20, " +
                            " (select sum(QuotedAmount) from NVO_RatesheetMRG where CntrTypes = 1 and RRID = NVO_Ratesheet.Id) as MrgRate20, " +
                            " (select top(1)(select top(1) Size from NVO_tblCntrTypes where SizeId = 2 and ID = NVO_RatesheetMRG.CntrTypes) from NVO_RatesheetMRG where RRID = NVO_Ratesheet.Id) as Cntr40, " +
                            " (select sum(QuotedAmount) from NVO_RatesheetMRG where CntrTypes = 2 and RRID = NVO_Ratesheet.Id) as MrgRate40, " +
                            " (select sum(SlotAmt) from NVO_RatesheetSLOTDtls where CntrTypes = 1 and Commodity = 3 and RRID = NVO_Ratesheet.Id) as Slot20, " +
                            " (select sum(SlotAmt) from NVO_RatesheetSLOTDtls where CntrTypes = 2 and Commodity = 4 and RRID = NVO_Ratesheet.Id) as Slot40, " +
                            " (select top(1) (select top(1) CustomerName from NVO_CustomerMaster where ID =slotOperator) from NVO_RatesheetSLOT where NVO_RatesheetSLOT.RRID = NVO_Ratesheet.Id)  as SlotOpt " +
                            " from NVO_Ratesheet where Id = " + RRID;
            return GetViewData(_Query, "");
        }

        public List<MyRatesheet> RRNotificationRecordView(MyRatesheet Data)
        {
            List<MyRatesheet> ViewList = new List<MyRatesheet>();
            DataTable dt = GetRRNotificationView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheet
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RatesheetNo = dt.Rows[i]["RatesheetNo"].ToString(),
                    BookingParty = dt.Rows[i]["BookingParty"].ToString(),
                    PortofOrgin = dt.Rows[i]["PortofOrgin"].ToString(),
                    PortofLoading = dt.Rows[i]["PortofLoading"].ToString(),
                    PortofDischarge = dt.Rows[i]["PlaceofDischarge"].ToString(),
                    Date = dt.Rows[i]["Datev"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable GetRRNotificationView(MyRatesheet Data)
        {
            string strWhere = "";
            string _Query = " select ID, RatesheetNo," +
                   " ( select top(1) upper(CustomerName + '-' + Branch)  from NVO_CustomerMaster inner join NVO_CusBranchLocation on NVO_CusBranchLocation.CustomerID = NVO_CustomerMaster.ID  WHERE NVO_CusBranchLocation.CID = BookingPartyID ) BookingParty, " +
                            " convert(varchar, date, 101) as Datev,(select top(1) PortName from NVO_PortMaster where Id = PortOfOrgin) PortofOrgin, " +
                            " (select top(1) PortName from NVO_PortMaster where Id = PortofLoading) PortofLoading,(select top(1) PortName from NVO_PortMaster where Id = PlaceofDischargeId) PlaceofDischarge, " +
                            "(select top(1) Status from NVO_RRStatusMaster where Id=NVO_Ratesheet.RSStatus) as Status " +
                            " from NVO_Ratesheet";


            if (Data.RRNumber != "")
                if (strWhere == "")
                    strWhere += _Query + " where RatesheetNo like'%" + Data.RRNumber + "%'";
                else
                    strWhere += " and RatesheetNo like'%" + Data.RRNumber + "%'";

            if (Data.PortofLoading != "" && Data.PortofLoading != "0" && Data.PortofLoading != null && Data.PortofLoading != "?")

                if (strWhere == "")
                    strWhere += _Query + " where PortOfLoading=" + Data.PortofLoading;
                else
                    strWhere += " and PortOfLoading=" + Data.PortofLoading;

            if (Data.PortofDischarge != "" && Data.PortofDischarge != "0" && Data.PortofDischarge != null && Data.PortofDischarge != "?")
                if (strWhere == "")
                    strWhere += _Query + " where PlaceofDischargeId=" + Data.PortofDischarge;
                else
                    strWhere += " and PlaceofDischargeId=" + Data.PortofDischarge;


            if (Data.BookingParty != "" && Data.BookingParty != "0" && Data.BookingParty != null && Data.BookingParty != "?")
                if (strWhere == "")
                    strWhere += _Query + " where BookingPartyID=" + Data.BookingParty;
                else
                    strWhere += " and BookingPartyID=" + Data.BookingParty;

            if (Data.Status != "" && Data.Status != "0" && Data.Status != null && Data.Status != "?")
                if (strWhere == "")
                    strWhere += _Query + " where RSStatus=" + Data.Status;
                else
                    strWhere += " and RSStatus=" + Data.Status;
            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyRatesheet> RRFinalSubmitCheckRecordView(MyRatesheet Data)
        {
            List<MyRatesheet> ViewList = new List<MyRatesheet>();
            DataTable dt = GetRRFinalSubmitCheckView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheet
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CheckCntr = dt.Rows[i]["CheckCntr"].ToString(),
                    CheckMRG = dt.Rows[i]["CheckMRG"].ToString(),
                    CheckSLOT = dt.Rows[i]["CheckSLOT"].ToString(),
                    Status = dt.Rows[i]["RSStatus"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetRRFinalSubmitCheckView(MyRatesheet Data)
        {
            string _Query = " select Id, (select count(RRID) as RCNtr from NVO_RatesheetCntrTypes where RRID = NVO_Ratesheet.ID) as CheckCntr, " +
                            " (select count(RRID) from NVO_RatesheetMRG where NVO_RatesheetMRG.RRID = NVO_Ratesheet.ID) as CheckMRG, " +
                            " (select Count(RRID) from NVO_RatesheetSLOTDtls where NVO_RatesheetSLOTDtls.RRID = NVO_Ratesheet.ID) as CheckSLOT,RSStatus " +
                            " from NVO_Ratesheet where ID = " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyRatesheet> RRDashBordCountRecordView(MyRatesheet Data)
        {
            List<MyRatesheet> ViewList = new List<MyRatesheet>();
            DataTable dt = GetRRDashBoradView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheet
                {
                    Pending = dt.Rows[i]["PENDING"].ToString(),
                    Rejected = dt.Rows[i]["REJECTED"].ToString(),
                    REQuote = dt.Rows[i]["REUOTE"].ToString(),
                    Approved = dt.Rows[i]["APPROVED"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetRRDashBoradView(MyRatesheet Data)
        {
            if (Data.AgentId.ToString() == "2")
            {
                string _Query = " select " +
                            " (select count(Date) from NVO_Ratesheet where RSStatus is NULL or RSStatus = 1) as PENDING, " +
                            " (select count(Date) from NVO_Ratesheet where RSStatus = 2 ) as REJECTED, " +
                            " (select count(Date) from NVO_Ratesheet where RSStatus = 3 ) as REUOTE, " +
                            " (select count(date) from NVO_Ratesheet where RSStatus = 4 ) as APPROVED ";
                return GetViewData(_Query, "");
            }
            else
            {
                string _Query = " select " +
                           " (select count(Date) from NVO_Ratesheet where RSStatus is NULL or RSStatus = 1 and  AGENTID=" + Data.AgentId + " ) as PENDING, " +
                           " (select count(Date) from NVO_Ratesheet where RSStatus = 2 and  AGENTID=" + Data.AgentId + ") as REJECTED, " +
                           " (select count(Date) from NVO_Ratesheet where RSStatus = 3 and  AGENTID=" + Data.AgentId + ") as REUOTE, " +
                           " (select count(date) from NVO_Ratesheet where RSStatus = 4 and  AGENTID=" + Data.AgentId + ") as APPROVED ";
                return GetViewData(_Query, "");
            }

        }

        public List<MyRRRate> RRFreighTariff(MyRRRate Data)
        {
            List<MyRRRate> ViewList = new List<MyRRRate>();
            DataTable dt = GetRRFreightTraiff(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRRate
                {
                    PortTariffID = dt.Rows[i]["PortTariffID"].ToString(),
                    RCID = Int32.Parse(dt.Rows[i]["TID"].ToString()),
                    CntrTypes = dt.Rows[i]["ChargeTypeID"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCodeID"].ToString(),
                    PaymentModeID = dt.Rows[i]["CollectionModeID"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    ReqRate = dt.Rows[i]["Amount"].ToString(),
                    ManifRate = dt.Rows[i]["ManifestRate"].ToString(),
                    CustomerRate = dt.Rows[i]["CustomeRate"].ToString(),
                    RateDiff = dt.Rows[i]["RateDiffernt"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetRRFreightTraiff(MyRRRate Data)
        {
            string _Query = "";
            if (Data.TraiffRegular == "137")
            {
                string PortID = "0";

                if (Data.ExportIHC == "1")
                    PortID = Data.POL;
                if (Data.ImportIHC == "1")
                    PortID += "," + Data.POD;

                //_Query = " select NVO_PortTariffMaster.ID as PortTariffID,TID, CntrID as ChargeTypeID, ChargeCodeID, CurrencyID, CollectionModeID, Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt from NVO_PortTariffMaster " +
                //         " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                //         " where CntrId in (" + Data.CntrTypes + ") and PortLocationID in (" + PortID + ") and TraiffRegular = " + Data.TraiffRegular + " and ChargeTypeID = "+ Data.ChargeTypeID +" and CommodityTypeID in (" + Data.CommodityTypeID + ")";
                if (Data.ExportIHC == "1")
                {
                    _Query = " Select NVO_IHCHaulageTariff.Id as PortTariffID,TID,ContainerTypeID as ChargeTypeID,ChargesID as ChargeCodeID, 18 as CollectionModeID,CurrencyID, " +
                             " Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt " +
                             " from NVO_IHCHaulageTariff " +
                             " inner join NVO_IHCHaulageTariffDtls on NVO_IHCHaulageTariffDtls.IHCTariffID = NVO_IHCHaulageTariff.ID " +
                             " where ChargeTypeID= " + Data.ChargeTypeID + " and PortID in (" + PortID + ") and ValidTill >= getdate() and CommodityTypeID in  (" + Data.CommodityTypeID + ") and ContainerTypeID in ( " + Data.CntrTypes + " ) and Status = 1 and THCIncluded = 1 and ICDLocID= " + Data.POO +
                             " and(SlabFrom <= " + Data.SlabValue + " and SlabTo >= " + Data.SlabValue + ")";
                }
                if (Data.ImportIHC == "1")
                {
                    _Query = " Select NVO_IHCHaulageTariff.Id as PortTariffID,TID,ContainerTypeID as ChargeTypeID,ChargesID as ChargeCodeID, 19 as CollectionModeID,CurrencyID, " +
                             " Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt " +
                             " from NVO_IHCHaulageTariff " +
                             " inner join NVO_IHCHaulageTariffDtls on NVO_IHCHaulageTariffDtls.IHCTariffID = NVO_IHCHaulageTariff.ID " +
                             " where ChargeTypeID= " + Data.ChargeTypeID + " and PortID in (" + PortID + ") and ValidTill >= getdate() and CommodityTypeID in  (" + Data.CommodityTypeID + ") and ContainerTypeID in ( " + Data.CntrTypes + " ) and Status = 1 and THCIncluded = 1 and ICDLocID= " + Data.FPOD +
                             " and(SlabFrom <= " + Data.SlabValue + " and SlabTo >= " + Data.SlabValue + ")";
                }



            }
            if (Data.TraiffRegular == "135")
            {

                //_Query = " select NVO_PortTariffMaster.ID as PortTariffID,TID, CntrID as ChargeTypeID, ChargeCodeID, CurrencyID, CollectionModeID, Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt from NVO_PortTariffMaster " +
                //                " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                //                " where CntrId in (" + Data.CntrTypes + ") and PortLocationID = " + Data.POL + "  and TraiffRegular = " + Data.TraiffRegular + " and ChargeTypeID = " + Data.ChargeTypeID + " and CommodityTypeID in (" + Data.CommodityTypeID + ")";

                _Query = " select NVO_PortTariffMaster.ID as PortTariffID,TID, CntrID as ChargeTypeID, ChargeCodeID, CurrencyID, CollectionModeID, Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt from NVO_PortTariffMaster " +
                                " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                                " where CntrId in (" + Data.CntrTypes + ") and PortLocationID = " + Data.POL + "  and TraiffRegular = " + Data.TraiffRegular + " and ChargeTypeID = " + Data.ChargeTypeID + " and CommodityTypeID in (" + Data.CommodityTypeID + ")" +
                                " and (DestCountryID =0  or   DestCountryID = " + Data.POD + ")";
            }
            if (Data.TraiffRegular == "136")
            {

                if (Data.CommodityTypeID == "4")
                {
                    _Query = " select NVO_PortTariffMaster.ID as PortTariffID,TID, CntrID as ChargeTypeID, ChargeCodeID, CurrencyID, CollectionModeID, Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt from NVO_PortTariffMaster " +
                            " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                            " where CntrId in (" + Data.CntrTypes + ") and (PortLocationID=  " + Data.POL + ") and TraiffRegular = " + Data.TraiffRegular + " and ChargeTypeID = " + Data.ChargeTypeID + " and CollectionModeID= 18 and CommodityTypeID in (" + Data.CommodityTypeID + ")";
                    if (Data.POL == "232" || Data.POL == "237")
                        _Query += "and (GroupID=" + Data.GroupID + ")";

                    _Query += " union " +
                            " select NVO_PortTariffMaster.ID as PortTariffID,TID, CntrID as ChargeTypeID, ChargeCodeID, CurrencyID, CollectionModeID, Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt from NVO_PortTariffMaster " +
                            " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                            " where CntrId in (" + Data.CntrTypes + ") and (PortLocationID=" + Data.POD + ") and TraiffRegular = " + Data.TraiffRegular + " and ChargeTypeID = " + Data.ChargeTypeID + " and CollectionModeID= 19 and CommodityTypeID in (" + Data.CommodityTypeID + ")";
                    if (Data.POD == "232" || Data.POD == "237")
                        _Query += "and (GroupID=" + Data.GroupID + ")";

                }
                else
                {
                    _Query = " select NVO_PortTariffMaster.ID as PortTariffID,TID, CntrID as ChargeTypeID, ChargeCodeID, CurrencyID, CollectionModeID, Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt from NVO_PortTariffMaster " +
                                                     " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                                                     " where CntrId in (" + Data.CntrTypes + ") and (PortLocationID=  " + Data.POL + ") and TraiffRegular = " + Data.TraiffRegular + " and ChargeTypeID = " + Data.ChargeTypeID + " and CollectionModeID= 18 and CommodityTypeID in (" + Data.CommodityTypeID + ") " +
                                                     " union " +
                                                     " select NVO_PortTariffMaster.ID as PortTariffID,TID, CntrID as ChargeTypeID, ChargeCodeID, CurrencyID, CollectionModeID, Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt from NVO_PortTariffMaster " +
                                                     " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                                                     " where CntrId in (" + Data.CntrTypes + ") and (PortLocationID=" + Data.POD + ") and TraiffRegular = " + Data.TraiffRegular + " and ChargeTypeID = " + Data.ChargeTypeID + " and CollectionModeID= 19 and CommodityTypeID in (" + Data.CommodityTypeID + ")";

                }

            }
            if (Data.TraiffRegular == "138")
            {

                _Query = " select NVO_PortTariffMaster.ID as PortTariffID,TID, CntrID as ChargeTypeID, ChargeCodeID, CurrencyID, CollectionModeID, Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt from NVO_PortTariffMaster " +
                                " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                                " where CollectionModeID = " + Data.CollectionModeID + " and CntrId in (" + Data.CntrTypes + ") and PortLocationID = " + Data.PortID + "  and TraiffRegular = " + Data.TraiffRegular + " and ChargeTypeID = " + Data.ChargeTypeID + " and CommodityTypeID in (" + Data.CommodityTypeID + ")";

            }

            return GetViewData(_Query, "");
        }

        public List<MyRRRate> RRTariffExisting(MyRRRate Data)
        {
            List<MyRRRate> ViewList = new List<MyRRRate>();
            DataTable dt = GetRRTariffExisting(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRRate
                {
                    PortTariffID = dt.Rows[i]["PortTariffID"].ToString(),
                    RCID = Int32.Parse(dt.Rows[i]["RCID"].ToString()),
                    CntrTypes = dt.Rows[i]["CntrType"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCodeID"].ToString(),
                    PaymentModeID = dt.Rows[i]["PaymentModeID"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    ReqRate = dt.Rows[i]["ReqRate"].ToString(),
                    ManifRate = dt.Rows[i]["ManifRate"].ToString(),
                    CustomerRate = dt.Rows[i]["CustomerRate"].ToString(),
                    RateDiff = dt.Rows[i]["RateDiff"].ToString(),

                });
            }

            return ViewList;
        }
        public DataTable GetRRTariffExisting(MyRRRate Data)
        {
            //string _Query = " Select PortTariffID, TariffID as  RCID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff  " +
            //                " from NVO_RatesheetCharges where ChargeTypeID = 1 and  RRId = " + Data.ID + " and TariffTypeID = " + Data.TraiffRegular + " and PaymentModeID=" + Data.PaymentModeID;
            string _Query = " Select PortTariffID, TariffID as  RCID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff  " +
                " from NVO_RatesheetCharges where ChargeTypeID = 1 and  RRId = " + Data.ID + " and TariffTypeID = " + Data.TraiffRegular;
            return GetViewData(_Query, "");
        }


        public List<MyRRRate> RRTariffExistingLocalcharge(MyRRRate Data)
        {
            List<MyRRRate> ViewList = new List<MyRRRate>();
            DataTable dt = GetRRTariffExistingLocalCharge(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRRate
                {
                    PortTariffID = dt.Rows[i]["PortTariffID"].ToString(),
                    RCID = Int32.Parse(dt.Rows[i]["RCID"].ToString()),
                    CntrTypes = dt.Rows[i]["CntrType"].ToString(),
                    ChargeCodeID = dt.Rows[i]["ChargeCodeID"].ToString(),
                    PaymentModeID = dt.Rows[i]["PaymentModeID"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    ReqRate = dt.Rows[i]["ReqRate"].ToString(),
                    ManifRate = dt.Rows[i]["ManifRate"].ToString(),
                    CustomerRate = dt.Rows[i]["CustomerRate"].ToString(),
                    RateDiff = dt.Rows[i]["RateDiff"].ToString(),

                });
            }

            return ViewList;
        }


        public DataTable GetRRTariffExistingLocalCharge(MyRRRate Data)
        {
            string _Query = " Select PortTariffID, TariffID as  RCID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff  " +
                            " from NVO_RatesheetCharges where ChargeTypeID = 1 and  RRId = " + Data.ID + " and TariffTypeID = " + Data.TraiffRegular + " and PaymentModeID=" + Data.PaymentModeID;

            return GetViewData(_Query, "");
        }


        public List<MyRRRate> RRFreighTariffLocalAmt(MyRRRate Data)
        {
            List<MyRRRate> ViewList = new List<MyRRRate>();
            DataTable dt = GetRRFreightTraiffLocalAmt(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRRate
                {
                    Currency = dt.Rows[0]["Currency"].ToString(),
                    Amount = dt.Rows[0]["Amount"].ToString()


                });
            }

            return ViewList;
        }

        public DataTable GetRRFreightTraiffLocalAmt(MyRRRate Data)
        {
            string _Query = " select sum(Amount) as Amount, " +
                            " (select top(1)(select CurrencyCode from NVO_CurrencyMaster where NVO_CurrencyMaster.ID = CurrencyId)  from NVO_PortTariffdtls where PTID = NVO_PortTariffMaster.ID) as Currency " +
                            " from NVO_PortTariffMaster inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                            " where CollectionModeID = " + Data.CollectionModeID + " and CntrId in (" + Data.CntrTypes + ") and PortLocationID = " + Data.PortID + "  and TraiffRegular = " + Data.TraiffRegular + " and CommodityTypeID in (" + Data.CommodityTypeID + ")" +
                            " group by NVO_PortTariffMaster.ID";
            return GetViewData(_Query, "");
        }


        public List<MyRRRate> ExistingRateSheetFreighTariffLocalAmt(MyRRRate Data)
        {
            List<MyRRRate> ViewList = new List<MyRRRate>();
            DataTable dt = GetExistRatesheetFreightTraiffLocalAmt(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRRate
                {
                    Currency = dt.Rows[0]["Currency"].ToString(),
                    Amount = dt.Rows[0]["AmountRate"].ToString()


                });
            }

            return ViewList;
        }

        public DataTable GetExistRatesheetFreightTraiffLocalAmt(MyRRRate Data)
        {
            string _Query = " select sum(CustomerRate) as AmountRate,(select top(1) CurrencyCode from NVO_CurrencyMaster where ID = CurrencyID) as Currency " +
                            " from NVO_RatesheetCharges where TariffTypeID = " + Data.TraiffRegular + " and RRId = " + Data.RRID + " and PaymentModeID = " + Data.PaymentModeID + " " +
                            " group by NVO_RatesheetCharges.CurrencyID";
            //string _Query = " select sum(Amount) as Amount, " +
            //                " (select top(1)(select CurrencyCode from NVO_CurrencyMaster where NVO_CurrencyMaster.ID = CurrencyId)  from NVO_PortTariffdtls where PTID = NVO_PortTariffMaster.ID) as Currency " +
            //                " from NVO_PortTariffMaster inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
            //                " where CollectionModeID = " + Data.CollectionModeID + " and CntrId in (" + Data.CntrTypes + ") and PortLocationID = " + Data.PortID + "  and TraiffRegular = " + Data.TraiffRegular + " and CommodityTypeID in (" + Data.CommodityTypeID + ")" +
            //                " group by NVO_PortTariffMaster.ID";
            return GetViewData(_Query, "");
        }


        public List<MyRRRate> RRBkgPartSales(MyRRRate Data)
        {
            List<MyRRRate> ViewList = new List<MyRRRate>();
            DataTable dt = GetRRBkgPartSales(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRRate
                {
                    ID = Int32.Parse(dt.Rows[0]["SelesPersonID"].ToString()),
                    SalesPersion = dt.Rows[0]["SalesPerson"].ToString()


                }); ; ;
            }

            return ViewList;
        }
        public DataTable GetRRBkgPartSales(MyRRRate Data)
        {
            string _Query = "select SalesPerson,SelesPersonID from NVO_CusSalesLink where BranchID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyRRRate> RRListUsers(MyRRRate Data)
        {
            List<MyRRRate> ViewList = new List<MyRRRate>();
            DataTable dt = GetRRListUsers(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRRRate
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserName = dt.Rows[i]["UserName"].ToString()


                }); ; ;
            }

            return ViewList;
        }
        public DataTable GetRRListUsers(MyRRRate Data)
        {
            if (Data.ID > 0)
            {
                string _Query = "select * from NVO_UserDetails where ID not IN (4,8)";
                return GetViewData(_Query, "");
            }
            else
            {
                string _Query = "select * from NVO_UserDetails where ID IN (4,8)";
                return GetViewData(_Query, "");
            }
        }



        #endregion

        #region Ganesh RRNOTIFICATION

        public List<MyRatesheet> RatesheetNotificationValues(string ID)
        {
            List<MyRatesheet> ViewList = new List<MyRatesheet>();
            DataTable dt = GetRatesheetNotificationValues(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheet
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RatesheetNo = dt.Rows[i]["RatesheetNo"].ToString(),
                    Date = dt.Rows[i]["Date"].ToString(),
                    BookingPartyID = Int32.Parse(dt.Rows[i]["BookingPartyID"].ToString()),
                    SalesPersonID = Int32.Parse(dt.Rows[i]["SalesPersonID"].ToString()),
                    ShipmentID = Int32.Parse(dt.Rows[i]["ShipmentID"].ToString()),
                    PortOfOrgin = Int32.Parse(dt.Rows[i]["PortOfOrgin"].ToString()),
                    PortOfLoading = Int32.Parse(dt.Rows[i]["PortOfLoading"].ToString()),
                    ExpHaulageID = Int32.Parse(dt.Rows[i]["ExpHaulageID"].ToString()),
                    PlaceofDischargeId = Int32.Parse(dt.Rows[i]["PlaceofDischargeId"].ToString()),
                    FinalPODId = Int32.Parse(dt.Rows[i]["FinalPODId"].ToString()),
                    ImpHaulageId = Int32.Parse(dt.Rows[i]["ImpHaulageId"].ToString()),
                    TranshimentPortID = Int32.Parse(dt.Rows[i]["TranshimentPortID"].ToString()),
                    ServiceTypeID = Int32.Parse(dt.Rows[i]["ServiceTypeID"].ToString()),
                    ValidTill = dt.Rows[i]["ValidTill"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    POLName = dt.Rows[i]["POLName"].ToString(),
                    POLCode = dt.Rows[i]["POLCode"].ToString(),
                    PODName = dt.Rows[i]["PODName"].ToString(),
                    PODCode = dt.Rows[i]["PODCode"].ToString(),
                    BookingParty = dt.Rows[i]["BookingParty"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    Tsport = dt.Rows[i]["TSPort"].ToString(),
                    CollectMode = dt.Rows[i]["PePaid"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOpt"].ToString(),
                    SalesMode = "FREE HAND",
                    Validate = dt.Rows[i]["ValidDate"].ToString(),
                    PORName = dt.Rows[i]["PORName"].ToString(),
                });
            }
            return ViewList;
        }


        public DataTable GetRatesheetNotificationValues(string RID)
        {
            string _Query = " select ID,RatesheetNo, convert(varchar, Date, 103) as Date,BookingPartyID,SalesPersonID,ShipmentID,PortOfOrgin,PortOfLoading,ExpHaulageID, " +
                            " PlaceofDischargeId,FinalPODId,ImpHaulageId,TranshimentPortID,ServiceTypeID, convert(varchar, ValidTill, 103) as ValidTill ,Remarks," +
                              " (select top(1) PortName from NVO_PortMaster where  Id = PortOfOrgin) as PORName, " +
                            " (select top(1) PortName from NVO_PortMaster where  Id = PortOfLoading) as POLName, " +
                            " (select top(1) PortCode from NVO_PortMaster where  Id = PortOfLoading) as POLCode, " +
                            " (select top(1) PortName from NVO_PortMaster where  Id = PlaceofDischargeId) as PODName, " +
                            " (select top(1) PortCode from NVO_PortMaster where  Id = PlaceofDischargeId) as PODCode, " +
                            " (select top(1) CustomerName from NVO_CustomerMaster where ID =BookingPartyID) as BookingParty,(select top(1) Status from NVO_RRStatusMaster where ID = RSStatus) as Status, " +
                            " (select top(1) PortName from NVO_PortMaster where  Id = TranshimentPortID) as TSPort,  " +
                            "   (select top(1) ImpFreeDays from NVO_RatesheetMode where RRID = ID) as FreeDays, " +
                            " (select top(1) GeneralName from  NVO_RatesheetCharges inner join NVO_GeneralMaster GM ON GM.ID = NVO_RatesheetCharges.PaymentModeID AND GM.SeqNo = 9 WHERE RRID = NVO_Ratesheet.ID And TariffTypeID = 135) as PePaid,  " +
                            " (select top(1)(select top(1) CustomerName from NVO_CustomerMaster where ID = slotOperator) from NVO_RatesheetSLOT where NVO_RatesheetSLOT.RRID = NVO_Ratesheet.Id)  as SlotOpt, " +
                            " convert(varchar, ValidTill, 106) as ValidDate " +
                            " from NVO_Ratesheet where ID=" + RID;
            return GetViewData(_Query, "");
        }


        public List<MyRatesheet> RateSheetNotificationTHCandIHCValues(string ID)
        {
            List<MyRatesheet> ViewList = new List<MyRatesheet>();
            DataTable dt = GetRateSheetNotificationTHCandIHCValues(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheet
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Size = dt.Rows[i]["Size"].ToString(),
                    DestTHCRate = dt.Rows[i]["DestTHCRate"].ToString(),
                    LoadTHCRate = dt.Rows[i]["LoadTHCRate"].ToString(),
                    ExportIHCRate = dt.Rows[i]["ExportIHCRate"].ToString(),
                    ImportIHCRate = dt.Rows[i]["ImportIHCRate"].ToString(),
                    Curr1 = dt.Rows[i]["Curr1"].ToString(),
                    Curr2 = dt.Rows[i]["Curr2"].ToString(),
                    Curr3 = dt.Rows[i]["Curr3"].ToString(),
                    Curr4 = dt.Rows[i]["Curr4"].ToString(),
                });
            }
            return ViewList;
        }


        public DataTable GetRateSheetNotificationTHCandIHCValues(string RID)
        {
            string _Query = "select R.ID,TC.Size,LoadPortTHC.LoadTHCRate, LoadPortTHC.CurrencyCode As Curr1, ExportIHC.CurrencyCode As Curr2,ImportIHC.CurrencyCode As Curr3,DestTHC.CurrencyCode As Curr4,DestTHC.DestTHCRate,ExportIHC.ExportIHCRate," +

              " ImportIHC.ImportIHCRate from  NVO_Ratesheet R Inner join NVO_RatesheetCntrTypes RCT ON RCT.RRID = R.ID " +

              " Inner join NVO_tblCntrTypes TC ON TC.ID = RCT.CntrTypeID OUTER APPLY(Select  isnull((ManifRate),0) as LoadTHCRate,  CM.CurrencyCode  from NVO_RatesheetCharges RSC Inner Join NVO_CurrencyMaster CM on CM.ID = RSC.CurrencyID  where RSC.ChargeCodeID = 4 and R.ID = RSC.RRID AND RSC.TariffTypeID = 136 and ChargeTypeID = 1 and RSC.CntrType = RCT.CntrTypeID ) LoadPortTHC " +

              "  OUTER APPLY(Select   (ManifRate) as DestTHCRate,CM.CurrencyCode from NVO_RatesheetCharges RSC  Inner Join NVO_CurrencyMaster CM on CM.ID = RSC.CurrencyID where RSC.ChargeCodeID = 9 and R.ID = RSC.RRID AND RSC.TariffTypeID = 136 and ChargeTypeID = 1 and RSC.CntrType = RCT.CntrTypeID) DestTHC  " +

             "    OUTER APPLY(Select ( ManifRate) As ExportIHCRate,CM.CurrencyCode from NVO_RatesheetCharges RSC  Inner Join NVO_CurrencyMaster CM on CM.ID = RSC.CurrencyID   where R.ID = RSC.RRID  AND RSC.TariffTypeID = 137 and RSC.PaymentModeID = 18 and ChargeTypeID = 1 and RSC.CntrType = RCT.CntrTypeID) ExportIHC  " +

             "  OUTER APPLY(Select  ( ManifRate ) As ImportIHCRate,CM.CurrencyCode from NVO_RatesheetCharges RSC  Inner Join NVO_CurrencyMaster CM on CM.ID = RSC.CurrencyID where R.ID = RSC.RRID AND RSC.TariffTypeID = 137 and RSC.PaymentModeID = 19 and ChargeTypeID = 1 and RSC.CntrType = RCT.CntrTypeID) ImportIHC WHERE R.ID = " + RID;

            return GetViewData(_Query, "");
        }

        public List<MyRatesheet> RRNotificationChargewiseRates(string ID)
        {
            List<MyRatesheet> ViewList = new List<MyRatesheet>();
            DataTable dt = GetRRNotificationChargewiseRates(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyRatesheet
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Size = dt.Rows[i]["Size"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),
                    FRT = dt.Rows[i]["FRT"].ToString(),
                    BAF = dt.Rows[i]["BAF"].ToString(),
                    DGS = dt.Rows[i]["DGS"].ToString(),
                    ECRS = dt.Rows[i]["ECRS"].ToString(),
                    CAF = dt.Rows[i]["CAF"].ToString(),
                    EWRS = dt.Rows[i]["EWRS"].ToString(),
                    LSS = dt.Rows[i]["LSS"].ToString(),
                    FRTCurr = dt.Rows[i]["FRTCurr"].ToString(),
                    BAFCurr = dt.Rows[i]["BAFCurr"].ToString(),
                    DGSCurr = dt.Rows[i]["DGSCurr"].ToString(),
                    ECRSCurr = dt.Rows[i]["ECRSCurr"].ToString(),
                    CAFCurr = dt.Rows[i]["CAFCurr"].ToString(),
                    EWRSCurr = dt.Rows[i]["LSSCurr"].ToString(),
                    LSSCurr = dt.Rows[i]["LSSCurr"].ToString(),
                });
            }
            return ViewList;
        }


        public DataTable GetRRNotificationChargewiseRates(string RID)
        {

            string _Query = "select Id,RatesheetNo,(select top(1) Size + '-' + Type from NVO_tblCntrTypes where ID = CntrTypeID) AS Size,(select top(1) GeneralName from NVO_GeneralMaster where ID = CommodityTypeID) AS Commodity," +

                " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID= NVO_Ratesheet.ID and TariffTypeID= 135 and CntrType= NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid= 1),0) as FRT, " +

                " isnull((select top(1) CurrencyCode from NVO_RatesheetCharges Inner Join NVO_CurrencyMaster CM on CM.ID = CurrencyID  where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 1),'') as FRTCurr," +

              " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID= NVO_Ratesheet.ID and TariffTypeID= 135 and CntrType= NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid= 22),0) as BAF, " +

             " isnull((select top(1) CurrencyCode from NVO_RatesheetCharges Inner Join NVO_CurrencyMaster CM on CM.ID = CurrencyID where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 22),'') as BAFCurr, " +

              " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID= NVO_Ratesheet.ID and TariffTypeID= 135 and CntrType= NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid= 27),0) as DGS, " +

             " isnull((select top(1) CurrencyCode from NVO_RatesheetCharges Inner Join NVO_CurrencyMaster CM on CM.ID = CurrencyID where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 27),0) as DGSCurr," +

             " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID= NVO_Ratesheet.ID and TariffTypeID= 135 and CntrType= NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid= 15),0) as ECRS, " +

             " isnull((select top(1) CurrencyCode from NVO_RatesheetCharges Inner Join NVO_CurrencyMaster CM on CM.ID = CurrencyID where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 15),'') as ECRSCurr ," +

              " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID= NVO_Ratesheet.ID and TariffTypeID= 135 and CntrType= NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid= 46),0) as CAF, " +

              " isnull((select top(1) CurrencyCode from NVO_RatesheetCharges Inner Join NVO_CurrencyMaster CM on CM.ID = CurrencyID where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 46),'') as CAFCurr," +

               " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID= NVO_Ratesheet.ID and TariffTypeID= 135 and CntrType= NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid= 35),0) as EWRS, " +
               " isnull((select top(1) CurrencyCode from NVO_RatesheetCharges Inner Join NVO_CurrencyMaster CM on CM.ID = CurrencyID where RRID = NVO_Ratesheet.ID and TariffTypeID = 135 and CntrType = NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid = 35),0) as EWRSCurr," +

               " isnull((select top(1) ManifRate from NVO_RatesheetCharges where RRID= NVO_Ratesheet.ID and TariffTypeID= 135 and CntrType= NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid= 23),0) as LSS," +

               " isnull((select top(1) CurrencyCode from NVO_RatesheetCharges Inner Join NVO_CurrencyMaster CM on CM.ID =CurrencyID where RRID= NVO_Ratesheet.ID and TariffTypeID= 135 and CntrType= NVO_RatesheetCntrTypes.CntrTypeID and chargecodeid= 23),'') as LSSCurr " +
               "  from NVO_Ratesheet inner join NVO_RatesheetCntrTypes on NVO_RatesheetCntrTypes.RRID=NVO_Ratesheet.ID where ID =" + RID;

            return GetViewData(_Query, "");
        }
        #endregion



        #region Commission Contract



        List<MyCommContract> ListCom = new List<MyCommContract>();
        public List<MyCommContract> CommissionChargesValues(string ChargeCommTypes)
        {

            DataTable dt = GetCommissionChargesBind(ChargeCommTypes);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCom.Add(new MyCommContract
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeCode = dt.Rows[i]["ChgCode"].ToString(),

                });
            }
            return ListCom;
        }


        public DataTable GetCommissionChargesBind(string ChargeCommTypes)
        {
            string _Query = "select ID,ChgCode from NVO_ChargeTB WHERE ID IN (" + ChargeCommTypes + " )";
            return GetViewData(_Query, "");
        }

        public List<MyCommContract> ShipmentTypesValues(string ShipmentTypes)
        {

            DataTable dt = GetShipmentTypesValues(ShipmentTypes);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCom.Add(new MyCommContract
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ShipmentTypes = dt.Rows[i]["GeneralName"].ToString(),

                });
            }
            return ListCom;
        }


        public DataTable GetShipmentTypesValues(string ShipmentTypes)
        {
            string _Query = "select * from NVO_GeneralMaster where ID in (" + ShipmentTypes + " )";
            return GetViewData(_Query, "");
        }

        public List<MyCommContract> InsertCommissionContract(MyCommContract Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_Commissioncontract where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Commissioncontract(ShipmentType,AgencyID,ComChargeID,CurrencyID,FixedRate,FrieghtChargeID,CommPercentage,ValidFrom,ValidTill,StatusID,LoginAgencyID,GeoLocID,UserID) " +
                                     " values (@ShipmentType,@AgencyID,@ComChargeID,@CurrencyID,@FixedRate,@FrieghtChargeID,@CommPercentage,@ValidFrom,@ValidTill,@StatusID,@LoginAgencyID,@GeoLocID,@UserID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Commissioncontract SET ShipmentType=@ShipmentType,AgencyID=@AgencyID,ComChargeID=@ComChargeID,CurrencyID=@CurrencyID,CommPercentage=@CommPercentage,FixedRate=@FixedRate,FrieghtChargeID=@FrieghtChargeID,ValidFrom=@ValidFrom," +
                                     " ValidTill=@ValidTill,StatusID=@StatusID,LoginAgencyID=@LoginAgencyID,GeoLocID=@GeoLocID,UserID=@UserID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentType", Data.ShipmentType));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ComChargeID", Data.ComChargeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", Data.CurrencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CommPercentage", Data.CommissionPercentage));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FixedRate", Data.FixedRate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FrieghtChargeID", Data.FreightChargeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidFrom", Data.ValidFrom));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", Data.ValidTill));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LoginAgencyID", Data.LoginAgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocID", Data.GeoLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));


                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_Commissioncontract')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();

                    ListCom.Add(new MyCommContract { ID = Data.ID });
                    return ListCom;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCom;
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
        public List<MyCommContract> GetCommContractView(MyCommContract Data)
        {
            DataTable dt = GetCommContractValuesView(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCom.Add(new MyCommContract
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Agency = dt.Rows[i]["Agency"].ToString(),
                    ShipmentTypes = dt.Rows[i]["ShipmentType"].ToString(),
                    StatusResult = dt.Rows[i]["STATUSResult"].ToString(),
                    CommissionCharge = dt.Rows[i]["CommissionCharge"].ToString(),

                });
            }


            return ListCom;
        }


        public DataTable GetCommContractValuesView(MyCommContract Data)
        {
            string strWhere = "";
            string _Query = "select ID,(Select top 1 GeneralName from NVO_GeneralMaster WHERE ID = ShipmentType) As ShipmentType,(Select top 1 AgencyName from NVO_AgencyMaster WHERE ID = AgencyID) As Agency," +
                "(Select top 1 ChgCode from NVO_ChargeTB WHERE ID = ComChargeID) As CommissionCharge, " +
                " CASE WHEN StatusID = 1 Then 'ACTIVE' WHEN StatusID = 2 THEN 'INACTIVE' END STATUSResult from NVO_Commissioncontract ";

            if (Data.AgencyID.ToString() != "" && Data.AgencyID.ToString() != "0" && Data.AgencyID.ToString() != "undefined")

                if (strWhere == "")
                    strWhere += _Query + " where  AgencyID = " + Data.AgencyID.ToString() + "";
                else
                    strWhere += " and  AgencyID = " + Data.AgencyID.ToString() + "";

            if (Data.ShipmentType.ToString() != "" && Data.ShipmentType.ToString() != "0" && Data.ShipmentType.ToString() != "undefined")

                if (strWhere == "")
                    strWhere += _Query + " where  ShipmentType = " + Data.ShipmentType.ToString() + "";
                else
                    strWhere += " and  ShipmentType = " + Data.ShipmentType.ToString() + "";

            if (Data.ComChargeID.ToString() != "" && Data.ComChargeID.ToString() != "0" && Data.ComChargeID.ToString() != "undefined")

                if (strWhere == "")
                    strWhere += _Query + " where  ComChargeID = " + Data.ComChargeID.ToString() + "";
                else
                    strWhere += " and  ComChargeID = " + Data.ComChargeID.ToString() + "";

            if (Data.StatusID.ToString() != "" && Data.StatusID.ToString() != "0" && Data.StatusID.ToString() != "undefined")

                if (strWhere == "")
                    strWhere += _Query + " where  StatusID = " + Data.StatusID.ToString() + "";
                else
                    strWhere += " and  StatusID = " + Data.StatusID.ToString() + "";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyCommContract> CommContractEditValues(MyCommContract Data)
        {

            DataTable dt = GetCommContractEditValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCom.Add(new MyCommContract
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ShipmentType = Int32.Parse(dt.Rows[i]["ShipmentType"].ToString()),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    ComChargeID = Int32.Parse(dt.Rows[i]["ComChargeID"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    FixedRate = dt.Rows[i]["FixedRate"].ToString(),
                    FreightChargeID = Int32.Parse(dt.Rows[i]["FrieghtChargeID"].ToString()),
                    ValidFrom = dt.Rows[i]["DtValidFrom"].ToString(),
                    ValidTill = dt.Rows[i]["DtValidTill"].ToString(),
                    CommissionPercentage = dt.Rows[i]["CommPercentage"].ToString(),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),
                });
            }
            return ListCom;
        }


        public DataTable GetCommContractEditValues(MyCommContract Data)
        {
            string _Query = "select convert(varchar, ValidFrom, 23) as DtValidFrom," +
                " convert(varchar, ValidTill, 23) as DtValidTill, *  from NVO_Commissioncontract WHERE ID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyCommContract> ExistCheckCCValidation(MyCommContract Data)
        {
            DataTable dt = GetExistCheckCCValidation(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCom.Add(new MyCommContract
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ShipmentType = Int32.Parse(dt.Rows[i]["ShipmentType"].ToString()),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    ComChargeID = Int32.Parse(dt.Rows[i]["ComChargeID"].ToString()),

                });
            }
            return ListCom;
        }


        public DataTable GetExistCheckCCValidation(MyCommContract Data)

        {
            string _Query = " select * from NVO_CommissionContract  where ShipmentType = " + Data.ShipmentType + " and AgencyID = " + Data.AgencyID + " and ComChargeID = " + Data.ComChargeID + " ";
            return GetViewData(_Query, "");
        }

        #endregion

        #region IHC Haulage Tariff

        List<MyIHCTariff> ListIHC = new List<MyIHCTariff>();
        public List<MyIHCTariff> InsertIHCTariffMaster(MyIHCTariff Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_IHCHaulageTariff where ID=@ID)<=0) " +
                                     " BEGIN " +
                                      " INSERT INTO  NVO_IHCHaulageTariff(ICDName,ICDLocID,PortID,ChargeTypeID,ChargesID,CommodityTypeID,ContainerTypeID,THCIncluded,Status,CreatedBy,CreatedOn,ValidFrom,ValidTill) " +
                                     " values (@ICDName,@ICDLocID,@PortID,@ChargeTypeID,@ChargesID,@CommodityTypeID,@ContainerTypeID,@THCIncluded,@Status,@CreatedBy,@CreatedOn,@ValidFrom,@ValidTill) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_IHCHaulageTariff SET ICDName=@ICDName,ICDLocID=@ICDLocID,PortID=@PortID,ChargeTypeID=@ChargeTypeID,ChargesID=@ChargesID,CommodityTypeID=@CommodityTypeID,ContainerTypeID=@ContainerTypeID,THCIncluded=@THCIncluded,Status=@Status,ValidFrom=@ValidFrom,ValidTill=@ValidTill,ModifiedBy=@ModifiedBy,ModifiedOn=@ModifiedOn where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ICDName", Data.ICDName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ICDLocID", Data.ICDLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", Data.PortID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", Data.ChargeTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargesID", Data.ChargesID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", Data.CommodityTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerTypeID", Data.ContainerTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@THCIncluded", Data.THCIncluded));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedBy", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModifiedBy", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModifiedOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidFrom", Data.ValidFrom));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", Data.ValidTill));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_IHCHaulageTariff')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;



                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_IHCHaulageTariffDTLS where TID=@TID and IHCTariffID=@IHCTariffID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_IHCHaulageTariffDTLS(IHCTariffID,SlabFrom,SlabTo,CurrencyID,Amount) " +
                                    " values (@IHCTariffID,@SlabFrom,@SlabTo,@CurrencyID,@Amount) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_IHCHaulageTariffDTLS SET IHCTariffID=@IHCTariffID,SlabFrom=@SlabFrom,SlabTo=@SlabTo,CurrencyID=@CurrencyID,Amount=@Amount where TID=@TID and IHCTariffID=@IHCTariffID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@IHCTariffID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlabFrom", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlabTo", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[4]));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }


                    trans.Commit();

                    ListIHC.Add(new MyIHCTariff { ID = Data.ID });
                    return ListIHC;


                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListIHC;
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

        public List<MyIHCTariff> IHCHaulageTariffViewValues(MyIHCTariff Data)
        {
            DataTable dt = GetIHCHaulageTariffViewValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListIHC.Add(new MyIHCTariff
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ICDName = dt.Rows[i]["ICDName"].ToString(),
                    Port = dt.Rows[i]["Port"].ToString(),
                    CommodityType = dt.Rows[i]["CommodityType"].ToString(),
                    ContainerType = dt.Rows[i]["ContainerType"].ToString(),
                    ChargeType = dt.Rows[i]["ChargeType"].ToString(),
                    Status = dt.Rows[i]["StatusV"].ToString(),
                    ValidFrom = dt.Rows[i]["ValidFromV"].ToString(),
                    ValidTill = dt.Rows[i]["ValidTillV"].ToString(),

                });
            }


            return ListIHC;
        }


        public DataTable GetIHCHaulageTariffViewValues(MyIHCTariff Data)
        {
            string strWhere = "";
            string _Query = "SELECT  IHC.ID,IHC.ICDName,convert (varchar,IHC.ValidTill,103) as validTillV, " +
                     " convert(varchar, IHC.ValidFrom, 103) as ValidFromV, (Select top 1 PortName from NVO_PortMaster where ID = IHC.PortID)  AS Port,(Select top 1 GeneralName from NVO_GeneralMaster where ID = IHC.ChargeTypeID)  AS ChargeType,(Select top 1 GeneralName from NVO_GeneralMaster where ID = IHC.CommodityTypeID)  AS CommodityType,(Select top 1 Size from NVO_TblCntrTypes where ID = IHC.ContainerTypeID)  AS ContainerType, case when IHC.Status = 1 then 'ACTIVE' WHEN IHC.Status = 2 then 'INACTIVE' End As StatusV FROM NVO_IHCHaulageTariff IHC ";


            if (Data.ICDLocID != "" && Data.ICDLocID != "0" && Data.ICDLocID != null && Data.ICDLocID != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where IHC.ICDLocID=" + Data.ICDLocID;
                else
                    strWhere += " and IHC.ICDLocID =" + Data.ICDLocID;

            if (Data.PortID != "" && Data.PortID != "0" && Data.PortID != null && Data.PortID != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where IHC.PortID=" + Data.PortID;
                else
                    strWhere += " and IHC.PortID =" + Data.PortID;

            if (Data.ChargeTypeID != "" && Data.ChargeTypeID != "0" && Data.ChargeTypeID != null && Data.ChargeTypeID != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where IHC.ChargeTypeID=" + Data.ChargeTypeID;
                else
                    strWhere += " and IHC.ChargeTypeID =" + Data.ChargeTypeID;

            if (Data.ContainerTypeID != "" && Data.ContainerTypeID != "0" && Data.ContainerTypeID != null && Data.ContainerTypeID != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where IHC.ContainerTypeID=" + Data.ContainerTypeID;
                else
                    strWhere += " and IHC.ContainerTypeID =" + Data.ContainerTypeID;

            if (Data.CommodityTypeID != "" && Data.CommodityTypeID != "0" && Data.CommodityTypeID != null && Data.CommodityTypeID != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where IHC.CommodityTypeID=" + Data.CommodityTypeID;
                else
                    strWhere += " and IHC.CommodityTypeID =" + Data.CommodityTypeID;

            if (Data.Status != "" && Data.Status != "0" && Data.Status != null && Data.Status != "?")

                if (strWhere == "")
                    strWhere += _Query + " where  IHC.Status = " + Data.Status;
                else
                    strWhere += " and IHC.Status = " + Data.Status;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyIHCTariff> IHCHaulageTariffVEditValues(MyIHCTariff Data)
        {

            DataTable dt = GetIHCHaulageTariffVEditValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListIHC.Add(new MyIHCTariff
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ICDName = dt.Rows[i]["ICDName"].ToString(),
                    ICDLocID = dt.Rows[i]["ICDLocID"].ToString(),
                    PortID = dt.Rows[i]["PortID"].ToString(),
                    ChargesID = dt.Rows[i]["ChargesID"].ToString(),
                    ChargeTypeID = dt.Rows[i]["ChargeTypeID"].ToString(),
                    CommodityTypeID = dt.Rows[i]["CommodityTypeID"].ToString(),
                    ContainerTypeID = dt.Rows[i]["ContainerTypeID"].ToString(),
                    THCIncluded = dt.Rows[i]["THCIncluded"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    ValidFrom = dt.Rows[i]["DtValidFrom"].ToString(),
                    ValidTill = dt.Rows[i]["DtValidTill"].ToString(),

                });
            }
            return ListIHC;
        }


        public DataTable GetIHCHaulageTariffVEditValues(MyIHCTariff Data)
        {
            string _Query = "select convert(varchar, ValidFrom, 23) as DtValidFrom," +
                " convert(varchar, ValidTill, 23) as DtValidTill, *  from NVO_IHCHaulageTariff WHERE ID =" + Data.ID;
            return GetViewData(_Query, "");
        }
        public List<MyIHCTariff> IHCHaulageTariffDtlsEditValues(MyIHCTariff Data)
        {

            DataTable dt = GetIHCHaulageTariffDtlsEditValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListIHC.Add(new MyIHCTariff
                {
                    TID = Int32.Parse(dt.Rows[i]["TID"].ToString()),
                    IHCTariffID = Int32.Parse(dt.Rows[i]["IHCTariffID"].ToString()),
                    SlabFrom = dt.Rows[i]["SlabFrom"].ToString(),
                    SlabTo = dt.Rows[i]["SlabTo"].ToString(),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    Amount = dt.Rows[i]["Amount"].ToString()
                });

            }
            return ListIHC;
        }

        public DataTable GetIHCHaulageTariffDtlsEditValues(MyIHCTariff Data)
        {
            string _Query = "select * FROM NVO_IHCHaulageTariffDTLS where IHCTariffID=" + Data.IHCTariffID;
            return GetViewData(_Query, "");
        }
        public List<MyIHCTariff> GetIHCHaulageTariffDtlsDelete(MyIHCTariff Data)
        {
            DataTable dt = RentTariffDelete(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListIHC.Add(new MyIHCTariff
                {
                    TID = Int32.Parse(dt.Rows[i]["TID"].ToString()),

                });

            }
            return ListIHC;
        }

        public DataTable RentTariffDelete(MyIHCTariff Data)
        {
            string _Query = " Delete NVO_IHCHaulageTariffDTLS where TID=" + Data.TID;
            return GetViewData(_Query, "");
        }

        public List<MyIHCTariff> IHCHaulageTariffValidation(MyIHCTariff Data)
        {
            DataTable dt = GetIHCHaulageTariffValidation(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListIHC.Add(new MyIHCTariff
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ICDName = dt.Rows[i]["ICDName"].ToString(),
                    ICDLocID = dt.Rows[i]["ICDLocID"].ToString(),
                    PortID = dt.Rows[i]["PortID"].ToString(),
                    ChargesID = dt.Rows[i]["ChargesID"].ToString(),
                    ChargeTypeID = dt.Rows[i]["ChargeTypeID"].ToString(),
                    CommodityTypeID = dt.Rows[i]["CommodityTypeID"].ToString(),
                    ContainerTypeID = dt.Rows[i]["ContainerTypeID"].ToString(),



                });

            }
            return ListIHC;
        }

        public DataTable GetIHCHaulageTariffValidation(MyIHCTariff Data)
        {
            string _Query = " select * from NVO_IHCHaulageTariff where ICDLocID=" + Data.ICDLocID + " and PortID =" + Data.PortID + "  and ChargeTypeID =" + Data.ChargeTypeID + " and CommodityTypeID =" + Data.CommodityTypeID + "  and ContainerTypeID =" + Data.ContainerTypeID + "  ";
            return GetViewData(_Query, "");
        }
        #endregion


        #region Ganesh Empty YARD COST

        List<MyEmptyYard> ListET = new List<MyEmptyYard>();
        public List<MyEmptyYard> GeoLocByCountry(MyEmptyYard Data)
        {
            DataTable dt = GETGeoLocByCountry(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListET.Add(new MyEmptyYard
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeoLocations = dt.Rows[i]["GeoLocation"].ToString()
                });

            }
            return ListET;
        }

        public DataTable GETGeoLocByCountry(MyEmptyYard Data)
        {
            string _Query = " Select * from NVO_GeoLocations where CountryID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyEmptyYard> InsertEmptyYardCosts(MyEmptyYard Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_EmptyYardCntrCost where ID=@ID)<=0) " +
                                     " BEGIN " +
                                      " INSERT INTO  NVO_EmptyYardCntrCost(CountryID,GeoLocID,EmptyYardID,CostPerCurrID,CostPerManHr,FreeUnits,UnitsPerID,Status,CreatedBy,CreatedOn,ValidFrom,ValidTill) " +
                                     " values (@CountryID,@GeoLocID,@EmptyYardID,@CostPerCurrID,@CostPerManHr,@FreeUnits,@UnitsPerID,@Status,@CreatedBy,@CreatedOn,@ValidFrom,@ValidTill) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_EmptyYardCntrCost SET CountryID=@CountryID,GeoLocID=@GeoLocID,EmptyYardID=@EmptyYardID,CostPerCurrID=@CostPerCurrID,CostPerManHr=@CostPerManHr,FreeUnits=@FreeUnits,UnitsPerID=@UnitsPerID,Status=@Status,ValidFrom=@ValidFrom,ValidTill=@ValidTill,ModifiedBy=@ModifiedBy,ModifiedOn=@ModifiedOn where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocID", Data.GeoLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EmptyYardID", Data.EmptyYardID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CostPerCurrID", Data.CostPerCurrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CostPerManHr", Data.CostPerManHr));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeUnits", Data.FreeUnits));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UnitsPerID", Data.UnitsPerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedBy", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModifiedBy", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModifiedOn", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidFrom", Data.ValidFrom));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", Data.ValidTill));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_EmptyYardCntrCost')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;



                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_EmptyYardCntrCostSlabDtls where TID=@TID and EYTariffID=@EYTariffID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_EmptyYardCntrCostSlabDtls(EYTariffID,SlabFrom,SlabTo,CT20,CT40,HQCT) " +
                                    " values (@EYTariffID,@SlabFrom,@SlabTo,@CT20,@CT40,@HQCT) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_EmptyYardCntrCostSlabDtls SET EYTariffID=@EYTariffID,SlabFrom=@SlabFrom,SlabTo=@SlabTo,CT20=@CT20,CT40=@CT40,HQCT=@HQCT where TID=@TID and EYTariffID=@EYTariffID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EYTariffID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlabFrom", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SlabTo", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CT20", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CT40", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@HQCT", CharSplit[5]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] Array2 = Data.Itemsv2.Split(new[] { "Insert:" }, StringSplitOptions.None);

                    for (int i = 1; i < Array2.Length; i++)
                    {
                        var CharSplit1 = Array2[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_EmptyYardCntrPortCostDtls where    EID=@EID and EYTariffID=@EYTariffID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_EmptyYardCntrPortCostDtls(EYTariffID,ChargeID,CurrencyID,CT20,CT40,HQCT) " +
                                    " values (@EYTariffID,@ChargeID,@CurrencyID,@CT20,@CT40,@HQCT) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_EmptyYardCntrPortCostDtls SET EYTariffID=@EYTariffID,ChargeID=@ChargeID,CurrencyID=@CurrencyID,CT20=@CT20,CT40=@CT40,HQCT=@HQCT where EID=@EID and EYTariffID=@EYTariffID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EID", CharSplit1[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EYTariffID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeID", CharSplit1[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit1[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CT20", CharSplit1[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CT40", CharSplit1[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@HQCT", CharSplit1[5]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    trans.Commit();

                    ListET.Add(new MyEmptyYard { ID = Data.ID });
                    return ListET;


                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListET;
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
        public List<MyEmptyYard> EmptyYardTariffViewRecord(MyEmptyYard Data)
        {
            DataTable dt = GetEmptyYardTariffViewRecordValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListET.Add(new MyEmptyYard
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Country = dt.Rows[i]["Country"].ToString(),
                    GeoLocations = dt.Rows[i]["GeoLocation"].ToString(),
                    EmptyYard = dt.Rows[i]["EmptyYard"].ToString(),
                    Status = dt.Rows[i]["StatusV"].ToString(),
                    ValidFrom = dt.Rows[i]["ValidFromV"].ToString(),
                    ValidTill = dt.Rows[i]["ValidTillV"].ToString(),

                });
            }


            return ListET;
        }


        public DataTable GetEmptyYardTariffViewRecordValues(MyEmptyYard Data)
        {
            string strWhere = "";
            string _Query = "select ET.ID,(Select top 1 CountryName from NVO_CountryMaster where ID = ET.CountryID) As Country,convert (varchar, ET.ValidTill, 103) as validTillV,  convert(varchar, ET.ValidFrom, 103) as ValidFromV,(Select top 1 GeoLocation from NVO_GeoLocations where ID = ET.GeoLocID) As GeoLocation,(Select top 1 DepName from NVO_DepotMaster where ID = ET.EmptyYardID) As EmptyYard, case when ET.Status = 1 then 'ACTIVE' when ET.Status = 2 then 'INACTIVE' end StatusV from NVO_EmptyYardCntrCost ET ";


            if (Data.CountryID != "" && Data.CountryID != "0" && Data.CountryID != null && Data.CountryID != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where ET.CountryID=" + Data.CountryID;
                else
                    strWhere += " and ET.CountryID =" + Data.CountryID;

            if (Data.GeoLocID != "" && Data.GeoLocID != "0" && Data.GeoLocID != null && Data.GeoLocID != "?")
                if (strWhere == "")
                    strWhere += _Query + " Where ET.GeoLocID=" + Data.GeoLocID;
                else
                    strWhere += " and ET.GeoLocID =" + Data.GeoLocID;



            if (Data.Status != "" && Data.Status != "0" && Data.Status != null && Data.Status != "?")

                if (strWhere == "")
                    strWhere += _Query + " where  ET.Status = " + Data.Status;
                else
                    strWhere += " and ET.Status = " + Data.Status;

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }


        public List<MyEmptyYard> EmptyYardTariffEditValues(MyEmptyYard Data)
        {
            DataTable dt = GetEmptyYardTariffEditValue(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListET.Add(new MyEmptyYard
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CountryID = dt.Rows[i]["CountryID"].ToString(),
                    GeoLocID = dt.Rows[i]["GeoLocID"].ToString(),
                    EmptyYardID = dt.Rows[i]["EmptyYardID"].ToString(),
                    CostPerCurrID = dt.Rows[i]["CostPerCurrID"].ToString(),
                    CostPerManHr = dt.Rows[i]["CostPerManHr"].ToString(),
                    FreeUnits = dt.Rows[i]["FreeUnits"].ToString(),
                    UnitsPerID = dt.Rows[i]["UnitsPerID"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    ValidFrom = dt.Rows[i]["DtValidFrom"].ToString(),
                    ValidTill = dt.Rows[i]["DtValidTill"].ToString(),

                });
            }


            return ListET;
        }


        public DataTable GetEmptyYardTariffEditValue(MyEmptyYard Data)
        {

            string _Query = "select convert(varchar, ValidFrom, 23) as DtValidFrom," +
                " convert(varchar, ValidTill, 23) as DtValidTill , * from NVO_EmptyYardCntrCost ET WHERE ET.ID = " + Data.ID;


            return GetViewData(_Query, "");


        }

        public List<MyEmptyYard> EmptyYardTariffSlabEdit(MyEmptyYard Data)
        {
            DataTable dt = GetEmptyYardTariffSlabEdit(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListET.Add(new MyEmptyYard
                {

                    TID = Int32.Parse(dt.Rows[i]["TID"].ToString()),
                    SlabFrom = dt.Rows[i]["SlabFrom"].ToString(),
                    SlabTo = dt.Rows[i]["SlabTo"].ToString(),
                    CT20 = dt.Rows[i]["CT20"].ToString(),
                    CT40 = dt.Rows[i]["CT40"].ToString(),
                    HQCT = dt.Rows[i]["HQCT"].ToString(),
                });
            }


            return ListET;
        }


        public DataTable GetEmptyYardTariffSlabEdit(MyEmptyYard Data)
        {

            string _Query = "select * from NVO_EmptyYardCntrCostSlabDtls  WHERE EYTariffID = " + Data.ID;


            return GetViewData(_Query, "");


        }
        public List<MyEmptyYard> EmptyYardTariffPortCostEdit(MyEmptyYard Data)
        {
            DataTable dt = GetEmptyYardTariffPortCostEdit(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListET.Add(new MyEmptyYard
                {

                    EID = Int32.Parse(dt.Rows[i]["EID"].ToString()),
                    ChargeID = Int32.Parse(dt.Rows[i]["ChargeID"].ToString()),
                    CurrencyID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    PCT20 = dt.Rows[i]["CT20"].ToString(),
                    PCT40 = dt.Rows[i]["CT40"].ToString(),
                    PHQCT = dt.Rows[i]["HQCT"].ToString(),
                });
            }


            return ListET;
        }


        public DataTable GetEmptyYardTariffPortCostEdit(MyEmptyYard Data)
        {

            string _Query = "select * from NVO_EmptyYardCntrPortCostDtls  WHERE EYTariffID = " + Data.ID;


            return GetViewData(_Query, "");


        }
        public List<MyEmptyYard> EmptyYardTariffValidation(MyEmptyYard Data)
        {
            DataTable dt = GetEmptyYardTariffValidation(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListET.Add(new MyEmptyYard
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    EmptyYardID = dt.Rows[i]["EmptyYardID"].ToString()
                });
            }


            return ListET;
        }


        public DataTable GetEmptyYardTariffValidation(MyEmptyYard Data)
        {

            string _Query = "select * from NVO_EmptyYardCntrCost where CountryID = " + Data.CountryID + " and GeoLocID =" + Data.GeoLocID + " and EmptyYardID=" + Data.EmptyYardID;


            return GetViewData(_Query, "");


        }

        #endregion
        public string GetMaxseqNumber(string Prefix, string GeoLocId, string SessionFinYear)
        {
            DbConnection con = null;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                DbCommand cmd = _dbFactory.GetCommand();
                cmd.Connection = con;

                int sno = 0;
                string Seqno = "0";

                cmd.CommandText = "select Max(ISNULL(" + Prefix + ",0)) from NVO_SeqNo where GeoLocId=" + GeoLocId + " and intYear=" + SessionFinYear;
                Seqno = cmd.ExecuteScalar().ToString();
                if (Seqno == "")
                {
                    sno = int.Parse("1");
                    Seqno = "1";
                }
                else if (Seqno == "0")
                    sno = int.Parse("1");
                else if (Seqno != "0")
                    sno = int.Parse(Seqno) + 1;

                cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_SeqNo WHERE GeoLocId=" + GeoLocId + " and intYear = " + SessionFinYear + ")<=0)" +
                                   " BEGIN  " +
                                   " INSERT INTO NVO_SeqNo(GeoLocId," + Prefix + ",intYear)Values(" + GeoLocId + "," + sno.ToString() + ", " + SessionFinYear + ") " +
                                   " END " +
                                   " ELSE " +
                                   " UPDATE NVO_SeqNo SET " + Prefix + "=" + sno.ToString() + " where GeoLocId=" + GeoLocId + " and intYear = " + SessionFinYear;
                int result = cmd.ExecuteNonQuery();

                return Seqno.ToString();
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
    }
}