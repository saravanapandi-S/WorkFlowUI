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

namespace DataManager
{
   public class LinerAgencyManager
    {
        List<MyLinerMRG> MRGList = new List<MyLinerMRG>();
        List<MyLinerSLOT> SLOTList = new List<MyLinerSLOT>();
        List<MYLinerPortTariffMaster> PortTariffList = new List<MYLinerPortTariffMaster>();
        List<MyLinerRatesheet> RateList = new List<MyLinerRatesheet>();
        List<MYLinerBOL> MyBOLList = new List<MYLinerBOL>();
        List<MYLinerBLRelease> MyBLRList = new List<MYLinerBLRelease>();


        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public LinerAgencyManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region MUTHU
    



        #region Ratesheet

        public List<MyLinerRatesheet> InsertRatesheetMaster(MyLinerRatesheet Data)
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
                        string AutoGen = GetMaxseqNumber("RRNO", "1",Data.SessionFinYear);
                        Cmd.CommandText = "select 'RR' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.RatesheetNo = Cmd.ExecuteScalar().ToString();
                    }
                    Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheet where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_LinerAgencyRatesheet(RatesheetNo,Date,BookingPartyID,SalesPersonID,ShipmentID,PortOfOrgin,PortOfLoading,ExpHaulageID,placeofDischargeId,FinalPODId,ImpHaulageId,TranshimentPortID,ServiceTypeID,ValidTill,CurrentDate,UserID,AgentId,Remarks) " +
                                     " values (@RatesheetNo,@Date,@BookingPartyID,@SalesPersonID,@ShipmentID,@PortOfOrgin,@PortOfLoading,@ExpHaulageID,@PlaceofDischargeId,@FinalPODId,@ImpHaulageId,@TranshimentPortID,@ServiceTypeID,@ValidTill,@CurrentDate,@UserID,@AgentId,@Remarks) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LinerAgencyRatesheet SET RatesheetNo=@RatesheetNo,Date=@Date,BookingPartyID=@BookingPartyID,SalesPersonID=@SalesPersonID,ShipmentID=@ShipmentID,PortOfOrgin=@PortOfOrgin,PortOfLoading=@PortOfLoading,ExpHaulageID=@ExpHaulageID," +
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
                        Cmd.CommandText = "select ident_current('NVO_LinerAgencyRatesheet')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }

                    trans.Commit();

                    RateList.Add(new MyLinerRatesheet
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

        public List<MyLinerRatesheet> InsertRatesheetMasterNew(MyLinerRatesheet Data)
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
                        string AutoGen = GetMaxseqNumber("RRNO", "1",Data.SessionFinYear);
                        Cmd.CommandText = "select 'RR' + ('" + Data.AgentCode + "')  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                        Data.RatesheetNo = Cmd.ExecuteScalar().ToString();
                    }
                    Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheet where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_LinerAgencyRatesheet(RatesheetNo,Date,BookingPartyID,SalesPersonID,ShipmentID,PortOfOrgin,PortOfLoading,ExpHaulageID,placeofDischargeId,FinalPODId,ImpHaulageId,TranshimentPortID,ServiceTypeID,ValidTill,CurrentDate,UserID,AgentId,Remarks,RouteType,ShipperID,ExportIHC,ImportIHC,IsRebate,RebateAmt,OtherRemarks,DocumentAttached,RSStatus,LinerID,VesVoyID,VesVoy) " +
                                     " values (@RatesheetNo,@Date,@BookingPartyID,@SalesPersonID,@ShipmentID,@PortOfOrgin,@PortOfLoading,@ExpHaulageID,@PlaceofDischargeId,@FinalPODId,@ImpHaulageId,@TranshimentPortID,@ServiceTypeID,@ValidTill,@CurrentDate,@UserID,@AgentId,@Remarks,@RouteType,@ShipperID,@ExportIHC,@ImportIHC,@IsRebate,@RebateAmt,@OtherRemarks,@DocumentAttached,@RSStatus,@LinerID,@VesVoyID,@VesVoy) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LinerAgencyRatesheet SET RatesheetNo=@RatesheetNo,Date=@Date,BookingPartyID=@BookingPartyID,SalesPersonID=@SalesPersonID,ShipmentID=@ShipmentID,PortOfOrgin=@PortOfOrgin,PortOfLoading=@PortOfLoading,ExpHaulageID=@ExpHaulageID," +
                                     " PlaceofDischargeId=@PlaceofDischargeId,FinalPODId=@FinalPODId,ImpHaulageId=@ImpHaulageId,TranshimentPortID=@TranshimentPortID,ServiceTypeID=@ServiceTypeID,ValidTill=@ValidTill,CurrentDate=@CurrentDate,UserID=@UserID,AgentId=@AgentId,Remarks=@Remarks,RouteType=@RouteType,ShipperID=@ShipperID,ExportIHC=@ExportIHC,ImportIHC=@ImportIHC,IsRebate=@IsRebate,RebateAmt=@RebateAmt,OtherRemarks=@OtherRemarks,DocumentAttached=@DocumentAttached,RSStatus=@RSStatus,LinerID=@LinerID,VesVoyID=@VesVoyID,VesVoy=@VesVoy where ID=@ID";

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
                    // Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", DateTime.ParseExact(Data.ValidTill, "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", Data.ValidTill));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentId", Data.AgentId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RouteType", Data.RouteType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperID", Data.ShipperID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ExportIHC", Data.ExportIHC));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ImportIHC", Data.ImportIHC));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsRebate", Data.IsRebate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RebateAmt", Data.RebateAmt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OtherRemarks", Data.OtherRemarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DocumentAttached", Data.DocumentAttached));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LinerID", Data.LinerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", Data.VesVoyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoy", Data.VesVoy));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_LinerAgencyRatesheet')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    //TsPort
                    if (Data.TranshimentPort != "Insert:undefined")
                    {
                        string[] ArrayTs = Data.TranshimentPort.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ArrayTs.Length; i++)
                        {
                            var CharSplit = ArrayTs[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetTranshipmentPort where RRID=@RRID and TSPortID=@TSPortID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_LinerAgencyRatesheetTranshipmentPort(RRID,TSPortID) " +
                                         " values (@RRID,@TSPortID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_LinerAgencyRatesheetTranshipmentPort SET RRID=@RRID,TSPortID=@TSPortID where RRID=@RRID and TSPortID=@TSPortID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TSPortID", CharSplit[0]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    //Cntrtypes
                    if (Data.CntrItems != "Insert:undefined")
                    { 
                        string[] Array = Data.CntrItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetCntrTypes where RRID=@RRID and RCID=@RCID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_LinerAgencyRatesheetCntrTypes(RRID,CntrTypeID,CommodityTypeID,DGClass,VGM,Qty) " +
                                     " values (@RRID,@CntrTypeID,@CommodityTypeID,@DGClass,@VGM,@Qty) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LinerAgencyRatesheetCntrTypes SET RRID=@RRID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID,DGClass=@DGClass,VGM=@VGM,Qty=@Qty where RRID=@RRID and RCID=@RCID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RCID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VGM", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DGClass", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Qty", CharSplit[5]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                }

                    //Mode
                    if (Data.ModeItems != "Insert:undefined")
                    {
                        string[] ArrayMode = Data.ModeItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ArrayMode.Length; i++)
                        {
                            var CharSplit = ArrayMode[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetMode where RRID=@RRID and ModeID=@ModeID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_LinerAgencyRatesheetMode(RRID,ModeID,ExpFreeDays,ImpFreeDays) " +
                                         " values (@RRID,@ModeID,@ExpFreeDays,@ImpFreeDays) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_LinerAgencyRatesheetMode SET RRID=@RRID,ModeID=@ModeID,ExpFreeDays=@ExpFreeDays,ImpFreeDays=@ImpFreeDays where RRID=@RRID and ModeID=@ModeID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ModeID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ExpFreeDays", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ImpFreeDays", CharSplit[2]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    //
                    //Freight
                    if (Data.FreightItems != "Insert:undefined")
                    {
                        string[] ArrayF = Data.FreightItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ArrayF.Length; i++)
                        {
                            var CharSplit = ArrayF[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_LinerAgencyRatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID) " +
                                         " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_LinerAgencyRatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID" +
                                         " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 135));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[8]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }
                    if (Data.TerminalItems != "Insert:undefined")
                    {
                        string[] ArrayT = Data.TerminalItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ArrayT.Length; i++)
                        {
                            var CharSplit = ArrayT[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_LinerAgencyRatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID) " +
                                         " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_LinerAgencyRatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID" +
                                         " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 136));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[8]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }


                    if (Data.HaulagItems != "Insert:undefined")
                    {
                        string[] ArrayHaulage = Data.HaulagItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ArrayHaulage.Length; i++)
                        {
                            var CharSplit = ArrayHaulage[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_LinerAgencyRatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID) " +
                                         " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_LinerAgencyRatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID" +
                                         " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 137));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[8]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    if (Data.ImportItems != "Insert:undefined")
                    {
                        string[] ImpArray = Data.ImportItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ImpArray.Length; i++)
                        {
                            var CharSplit = ImpArray[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_LinerAgencyRatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID) " +
                                         " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_LinerAgencyRatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID" +
                                         " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 138));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[8]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    if (Data.ExportItems != "Insert:undefined")
                    {
                        string[] ExpArray = Data.ExportItems.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ExpArray.Length; i++)
                        {
                            var CharSplit = ExpArray[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetCharges where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_LinerAgencyRatesheetCharges(RRID,TariffTypeID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff,TariffID) " +
                                         " values (@RRID,@TariffTypeID,@CntrType,@ChargeCodeID,@CurrencyID,@PaymentModeID,@ReqRate,@ManifRate,@CustomerRate,@RateDiff,@TariffID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_LinerAgencyRatesheetCharges SET RRID=@RRID,TariffTypeID=@TariffTypeID,CntrType=@CntrType,ChargeCodeID=@ChargeCodeID,CurrencyID=@CurrencyID,PaymentModeID=@PaymentModeID,ReqRate=@ReqRate,ManifRate=@ManifRate,CustomerRate=@CustomerRate,RateDiff=@RateDiff,TariffID=@TariffID" +
                                         " where RRID=@RRID and TariffTypeID=@TariffTypeID and TariffID=@TariffID";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffTypeID", 138));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentModeID", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ReqRate", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ManifRate", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerRate", CharSplit[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RateDiff", CharSplit[8]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }

                    trans.Commit();

                    RateList.Add(new MyLinerRatesheet
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


        public List<MyLinerRatesheet> RRForeExpirevalues(MyLinerRatesheet Data)
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

                    Cmd.CommandText = " UPDATE NVO_LinerAgencyRatesheet SET ValidTill=@ValidTill where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", System.DateTime.Now.Date));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();



                    trans.Commit();

                    RateList.Add(new MyLinerRatesheet
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


        public List<MyLinerRatesheet> RatesheetRecordView(MyLinerRatesheet Data)
        {
            List<MyLinerRatesheet> ViewList = new List<MyLinerRatesheet>();
            DataTable dt = GetRatesheetView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheet
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

        public DataTable GetRatesheetView(MyLinerRatesheet Data)
        {
            string strWhere = "";
            string _Query = " select ID, RatesheetNo,(select top(1) CustomerName from NVO_CustomerMaster where Id = BookingPartyID) as BookingParty, " +
                            " convert(varchar, date, 101) as Datev,(select top(1) PortName from NVO_PortMaster where Id = PortOfOrgin) PortofOrgin, " +
                            " (select top(1) PortName from NVO_PortMaster where Id = PortofLoading) PortofLoading," +
                            " (select top(1) Status from NVO_RRStatusMaster where ID =RSStatus) as Status ,(select top(1) PortName from NVO_PortMaster where Id = PlaceofDischargeId) PlaceofDischarge from NVO_LinerAgencyRatesheet";

            if (Data.RRNumber != "")
                if (strWhere == "")
                    strWhere += _Query + " where RatesheetNo like'%" + Data.RRNumber + "%'";
                else
                    strWhere += " and RatesheetNo like'%" + Data.RRNumber + "%'";

            if (Data.PortofLoading != null)
                if (strWhere == "")
                    strWhere += _Query + " where PortOfLoading=" + Data.PortofLoading;
                else
                    strWhere += " and PortOfLoading=" + Data.PortofLoading;

            if (Data.PortofDischarge != "")
                if (strWhere == "")
                    strWhere += _Query + " where PlaceofDischargeId=" + Data.PortofDischarge;
                else
                    strWhere += " and PlaceofDischargeId=" + Data.PortofDischarge;


            if (Data.BookingParty != "")
                if (strWhere == "")
                    strWhere += _Query + " where (select top(1) CustomerName from NVO_CustomerMaster where Id = BookingPartyID) like'%" + Data.BookingParty + "%'";
                else
                    strWhere += " and (select top(1) CustomerName from NVO_CustomerMaster where Id = BookingPartyID) like'%" + Data.BookingParty + "%'";

            if (Data.Status != null)
                if (strWhere == "")
                    strWhere += _Query + " where RSStatus=" + Data.PortofDischarge;
                else
                    strWhere += " and RSStatus=" + Data.PortofDischarge;
            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " order by Id desc", "");
        }


        public List<MyLinerRatesheet> RatesheetExistingMasterRecordView(string ID)
        {
            List<MyLinerRatesheet> ViewList = new List<MyLinerRatesheet>();
            DataTable dt = GetRatesheetExistingValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheet
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RatesheetNo = dt.Rows[i]["RatesheetNo"].ToString(),
                    Date = dt.Rows[i]["Date"].ToString(),
                    BookingPartyID = Int32.Parse(dt.Rows[i]["BookingPartyID"].ToString()),
                    SalesPersonID = Int32.Parse(dt.Rows[i]["SalesPersonID"].ToString()),
                    ShipmentID = Int32.Parse(dt.Rows[i]["ShipmentID"].ToString()),
                    PortOfOrgin = Int32.Parse(dt.Rows[i]["PortOfOrgin"].ToString()),
                    PortOfLoading = Int32.Parse(dt.Rows[i]["PortOfLoading"].ToString()),
                    //ExpHaulageID = Int32.Parse(dt.Rows[i]["ExpHaulageID"].ToString()),
                    PlaceofDischargeId = Int32.Parse(dt.Rows[i]["PlaceofDischargeId"].ToString()),
                    FinalPODId = Int32.Parse(dt.Rows[i]["FinalPODId"].ToString()),
                    //ImpHaulageId = Int32.Parse(dt.Rows[i]["ImpHaulageId"].ToString()),
                    //TranshimentPortID = Int32.Parse(dt.Rows[i]["TranshimentPortID"].ToString()),
                    ServiceTypeID = Int32.Parse(dt.Rows[i]["ServiceTypeID"].ToString()),
                    ValidTill = dt.Rows[i]["ValidTill"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    POLName = dt.Rows[i]["POLName"].ToString(),
                    POLCode = dt.Rows[i]["POLCode"].ToString(),
                    PODName = dt.Rows[i]["PODName"].ToString(),
                    PODCode = dt.Rows[i]["PODCode"].ToString(),
                    BookingParty = dt.Rows[i]["BookingParty"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    //RouteType = dt.Rows[i]["RouteType"].ToString(),
                    ShipperID = dt.Rows[i]["ShipperID"].ToString(),
                    //ExportIHC = dt.Rows[i]["ExportIHC"].ToString(),
                    //ImportIHC = dt.Rows[i]["ImportIHC"].ToString(),
                    IsRebate = dt.Rows[i]["IsRebate"].ToString(),
                    RebateAmt = dt.Rows[i]["RebateAmt"].ToString(),
                    OtherRemarks = dt.Rows[i]["OtherRemarks"].ToString(),
                    DocumentAttached = dt.Rows[i]["DocumentAttached"].ToString(),
                    LinerID = Int32.Parse(dt.Rows[i]["LinerID"].ToString()),
                    VesVoyID = Int32.Parse(dt.Rows[i]["VesVoyID"].ToString())



                });
            }
            return ViewList;
        }

        public DataTable GetRatesheetExistingValus(string RID)
        {
            string _Query = " select ID,RatesheetNo, convert(varchar, Date, 23) as Date,BookingPartyID,SalesPersonID,ShipmentID,PortOfOrgin,PortOfLoading,ExpHaulageID, " +
                            " PlaceofDischargeId,FinalPODId,ImpHaulageId,TranshimentPortID,ServiceTypeID, convert(varchar, ValidTill, 23) as ValidTill ,Remarks,RouteType,ShipperID,ExportIHC,ImportIHC,IsRebate,RebateAmt,OtherRemarks,DocumentAttached,LinerID,VesVoyID, " +
                            " (select top(1) PortName from NVO_PortMaster where  Id = PortOfLoading) as POLName, " +
                            " (select top(1) PortCode from NVO_PortMaster where  Id = PortOfLoading) as POLCode, " +
                            " (select top(1) PortName from NVO_PortMaster where  Id = PlaceofDischargeId) as PODName, " +
                            " (select top(1) PortCode from NVO_PortMaster where  Id = PlaceofDischargeId) as PODCode, " +
                            " (select top(1) CustomerName from NVO_CustomerMaster where ID =BookingPartyID) as BookingParty,(select top(1) Status from NVO_RRStatusMaster where ID = RSStatus) as Status " +
                            " from NVO_LinerAgencyRatesheet where ID=" + RID;
            return GetViewData(_Query, "");
        }

        public List<MyLinerRatesheet> RatesheetBkgCntrTypes(string ID)
        {
            List<MyLinerRatesheet> ViewList = new List<MyLinerRatesheet>();
            DataTable dt = GetRatesheetBkgCntrTypes(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheet
                {

                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    CommodityTypeID = Int32.Parse(dt.Rows[i]["CommodityTypeID"].ToString())
                });
            }
            return ViewList;
        }


        public DataTable GetRatesheetBkgCntrTypes(string RID)
        {
            string _Query = "select CntrTypeID,CommodityTypeID from NVO_LinerAgencyRatesheetCntrTypes where RRID=" + RID;
            return GetViewData(_Query, "");
        }

        public List<MyLinerName> LinerNameDetails(MyLinerName Data)
        {
            List<MyLinerName> ViewList = new List<MyLinerName>();
            DataTable dt = GetLinerName(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerName
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LinerName = dt.Rows[i]["CustomerName"].ToString()
                });
            }
            return ViewList;
        }


        public DataTable GetLinerName(MyLinerName Data)
        {
            string _Query = " select NVO_CustomerMaster.ID, CustomerName from NVO_CustomerMaster " +
                            " inner join NVO_CusBusinessTypes On NVO_CusBusinessTypes.CustomerID = NVO_CustomerMaster.ID " +
                            " where BussTypes in(7)";
            return GetViewData(_Query, "");
        }

        public List<MyLinerRatesheet> RatesheetExistingDashBoard(string ID)
        {
            List<MyLinerRatesheet> ViewList = new List<MyLinerRatesheet>();
            DataTable dt = GetRatesheetDashBoardExistingValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheet
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
                            " (select top(1) ExFreeday from NVO_LinerAgencyRatesheetCntrTypes where RRID = ID) as FreeDays, " +
                            " (select top(1)(select top(1) GeneralName from NVO_GeneralMaster where ID = NVO_LinerAgencyRatesheetMRG.FreightTerms) from NVO_LinerAgencyRatesheetMRG where RRID = NVO_LinerAgencyRatesheet.Id) as PePaid,  " +
                            " (select top(1)(select top(1) CustomerName from NVO_CustomerMaster where ID = slotOperator) from NVO_LinerAgencyRatesheetSLOT where NVO_LinerAgencyRatesheetSLOT.RRID = NVO_LinerAgencyRatesheet.Id)  as SlotOpt, " +
                            " convert(varchar, ValidTill, 106) as ValidDate " +
                            " from NVO_LinerAgencyRatesheet where ID=" + RID;
            return GetViewData(_Query, "");
        }

        public List<MyLinerRatesheet> InsertRatesheetContainerMaster(MyLinerRatesheet Data)
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

                        Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetCntrTypes where RRID=@RRID and RCID=@RCID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_LinerAgencyRatesheetCntrTypes(RRID,CntrTypeID,CommodityTypeID,ExFreeday,ImFreeday,VGM) " +
                                     " values (@RRID,@CntrTypeID,@CommodityTypeID,@ExFreeday,@ImFreeday,@VGM) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LinerAgencyRatesheetCntrTypes SET RRID=@RRID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID,ExFreeday=@ExFreeday,ImFreeday=@ImFreeday,VGM=@VGM where RRID=@RRID and RCID=@RCID";
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

                    RateList.Add(new MyLinerRatesheet { RRID = Data.RRID });
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


        public List<MyLinerRatesheet> RatesheetContainerExistingView(string ID)
        {
            List<MyLinerRatesheet> ViewList = new List<MyLinerRatesheet>();
            DataTable dt = GetRatesheetContainerExistingValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheet
                {
                    RCID = Int32.Parse(dt.Rows[i]["RCID"].ToString()),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    CommodityTypeID = Int32.Parse(dt.Rows[i]["CommodityTypeID"].ToString()),
                    DGClass = dt.Rows[i]["DGClass"].ToString(),
                    VGM = decimal.Parse(dt.Rows[i]["VGM"].ToString()),
                    Qty = dt.Rows[i]["Qty"].ToString()

                });
            }
            return ViewList;
        }

        public List<MyLinerRatesheet> RatesheetModeExistingView(string ID)
        {
            List<MyLinerRatesheet> ViewList = new List<MyLinerRatesheet>();
            DataTable dt = GetRatesheetModeExistingValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheet
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
            string _Query = " select * from NVO_LinerAgencyRatesheetMode where RRID = " + RID;
            return GetViewData(_Query, "");
        }

        public List<MyLinerRatesheet> RatesheetTsPortExistingView(string ID)
        {
            List<MyLinerRatesheet> ViewList = new List<MyLinerRatesheet>();
            DataTable dt = GetRatesheetTsPortExistingValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheet
                {
                    PortID = dt.Rows[i]["TsPortID"].ToString()

                });
            }
            return ViewList;
        }
        public DataTable GetRatesheetTsPortExistingValus(string RID)
        {
            string _Query = " select * from NVO_LinerAgencyRatesheetTranshipmentPort where RRID = " + RID;
            return GetViewData(_Query, "");
        }
        public DataTable GetRatesheetContainerExistingValus(string RID)
        {
            string _Query = " select * from NVO_LinerAgencyRatesheetCntrTypes where RRID = " + RID;
            return GetViewData(_Query, "");
        }

        public List<MyLinerRatesheet> InsertRatesheetRateChargeMaster(MyLinerRatesheet Data)
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

                            Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetRevRate where RRID=@RRID and RID=@RID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_LinerAgencyRatesheetRevRate(RRID,ChargeCodeID,infoChID,BasicID,CntrTypeID,CommodityTypeID,CurrencyID,Amt,CollectionModeID,CollectionAgentID,ChargeOwnershipID,ShipmentType) " +
                                         " values (@RRID,@ChargeCodeID,@infoChID,@BasicID,@CntrTypeID,@CommodityTypeID,@CurrencyID,@Amt,@CollectionModeID,@CollectionAgentID,@ChargeOwnershipID,@ShipmentType) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_LinerAgencyRatesheetRevRate SET RRID=@RRID,ChargeCodeID=@ChargeCodeID,infoChID=@infoChID,BasicID=@BasicID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID," +
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

                            Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetRevRate where RRID=@RRID and RID=@RID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_LinerAgencyRatesheetRevRate(RRID,ChargeCodeID,infoChID,BasicID,CntrTypeID,CommodityTypeID,CurrencyID,Amt,CollectionModeID,CollectionAgentID,ChargeOwnershipID,ShipmentType) " +
                                         " values (@RRID,@ChargeCodeID,@infoChID,@BasicID,@CntrTypeID,@CommodityTypeID,@CurrencyID,@Amt,@CollectionModeID,@CollectionAgentID,@ChargeOwnershipID,@ShipmentType) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_LinerAgencyRatesheetRevRate SET RRID=@RRID,ChargeCodeID=@ChargeCodeID,infoChID=@infoChID,BasicID=@BasicID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID," +
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

                            Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetCostRate where RRID=@RRID and RID=@RID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_LinerAgencyRatesheetCostRate(RRID,ChargeCodeID,BasicID,CntrTypeID,CommodityTypeID,CurrencyID,Amt,CollectionModeID,CollectionAgentID,ChargeOwnershipID,ShipmentType) " +
                                         " values (@RRID,@ChargeCodeID,@BasicID,@CntrTypeID,@CommodityTypeID,@CurrencyID,@Amt,@CollectionModeID,@CollectionAgentID,@ChargeOwnershipID,@ShipmentType) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_LinerAgencyRatesheetCostRate SET RRID=@RRID,ChargeCodeID=@ChargeCodeID,BasicID=@BasicID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID," +
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

                            Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetCostRate where RRID=@RRID and RID=@RID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_LinerAgencyRatesheetCostRate(RRID,ChargeCodeID,BasicID,CntrTypeID,CommodityTypeID,CurrencyID,Amt,CollectionModeID,CollectionAgentID,ChargeOwnershipID,ShipmentType) " +
                                         " values (@RRID,@ChargeCodeID,@BasicID,@CntrTypeID,@CommodityTypeID,@CurrencyID,@Amt,@CollectionModeID,@CollectionAgentID,@ChargeOwnershipID,@ShipmentType) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_LinerAgencyRatesheetCostRate SET RRID=@RRID,ChargeCodeID=@ChargeCodeID,BasicID=@BasicID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID," +
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

                            Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetTranshimentRate where RRID=@RRID and RID=@RID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_LinerAgencyRatesheetTranshimentRate(RRID,ChargeCodeID,BasicID,CntrTypeID,CommodityTypeID,CurrencyID,Amt,CollectionModeID,CollectionAgentID,ChargeOwnershipID,ShipmentType) " +
                                         " values (@RRID,@ChargeCodeID,@BasicID,@CntrTypeID,@CommodityTypeID,@CurrencyID,@Amt,@CollectionModeID,@CollectionAgentID,@ChargeOwnershipID,@ShipmentType) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_LinerAgencyRatesheetTranshimentRate SET RRID=@RRID,ChargeCodeID=@ChargeCodeID,BasicID=@BasicID,CntrTypeID=@CntrTypeID,CommodityTypeID=@CommodityTypeID," +
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

                    RateList.Add(new MyLinerRatesheet { RRID = Data.RRID });
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



        public List<MyLinerRatesheetRates> RatesheetRevRateExistingView(MyLinerRatesheetRates Data)
        {
            List<MyLinerRatesheetRates> ViewList = new List<MyLinerRatesheetRates>();
            DataTable dt = GetRatesheetRevRateExistingValus(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheetRates
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


        public DataTable GetRatesheetRevRateExistingValus(MyLinerRatesheetRates Data)
        {
            string _Query = "Select * from NVO_LinerAgencyRatesheetRevRate where RRID=" + Data.RRID + " and ShipmentType=" + Data.ShipmentType;
            return GetViewData(_Query, "");
        }


        public List<MyLinerRatesheetRates> RatesheetCostRateExistingView(MyLinerRatesheetRates Data)
        {
            List<MyLinerRatesheetRates> ViewList = new List<MyLinerRatesheetRates>();
            DataTable dt = GetRatesheetCostRateExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheetRates
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
        public DataTable GetRatesheetCostRateExistingValus(MyLinerRatesheetRates Data)
        {
            string _Query = "Select * from NVO_LinerAgencyRatesheetCostRate where RRID=" + Data.RRID + " and ShipmentType=" + Data.ShipmentType;
            return GetViewData(_Query, "");
        }

        public List<MyLinerRatesheetRates> RatesheetCostRateTransExistingView(MyLinerRatesheetRates Data)
        {
            List<MyLinerRatesheetRates> ViewList = new List<MyLinerRatesheetRates>();
            DataTable dt = GetRatesheetCostRateTransExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheetRates
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


        public DataTable GetRatesheetCostRateTransExistingValus(MyLinerRatesheetRates Data)
        {
            string _Query = "Select * from NVO_LinerAgencyRatesheetTranshimentRate where RRID=" + Data.RRID + " and ShipmentType=" + Data.ShipmentType;
            return GetViewData(_Query, "");
        }
        public List<MyLinerRRMRG> RatesheetMRGView(string ID)
        {
            List<MyLinerRRMRG> ViewList = new List<MyLinerRRMRG>();
            DataTable dt = GetRatesheetMRGValus(ID);
            //if (dt.Rows.Count > 0)
            //{
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRRMRG
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
            string _Query = " Select NVO_MRGRate.Id as RCID, PortOfLoading,PlaceofDischargeId,CntrTypeID,CommodityTypeID ,Amount as MRGAmt, Amount as QuotedAmt, 18 as FreightTems,NVO_LinerAgencyRatesheet.AgentID, " +
                            " (select top(1) size from NVO_tblCntrTypes where ID = CntrTypeID) as size  " +
                            " from NVO_LinerAgencyRatesheet inner join NVO_LinerAgencyRatesheetCntrTypes on NVO_LinerAgencyRatesheetCntrTypes.RRID = NVO_LinerAgencyRatesheet.ID " +
                            " inner join NVO_MRGRate on NVO_MRGRate.PofLoading = NVO_LinerAgencyRatesheet.PortOfLoading and NVO_MRGRate.PofDischarge = NVO_LinerAgencyRatesheet.PlaceofDischargeId " +
                            " AND NVO_MRGRate.CntrTypes = NVO_LinerAgencyRatesheetCntrTypes.CntrTypeID AND NVO_MRGRate.Commodity = NVO_LinerAgencyRatesheetCntrTypes.CommodityTypeID " +
                            " where NVO_LinerAgencyRatesheet.Id = " + RID;
            return GetViewData(_Query, "");
        }

        public List<MyLinerRRMRG> RatesheetSLOTView(string ID)
        {
            List<MyLinerRRMRG> ViewList = new List<MyLinerRRMRG>();
            DataTable dt = GetRatesheetSLOTValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRRMRG
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
                            " inner join NVO_LinerAgencyRatesheet on NVO_LinerAgencyRatesheet.PortOfLoading = NVO_SLOTMaster.POL and NVO_LinerAgencyRatesheet.PlaceofDischargeId = NVO_SLOTMaster.POD " +
                            " where NVO_LinerAgencyRatesheet.Id =" + RID;
            return GetViewData(_Query, "");
        }


        public List<MyLinerRRMRG> RatesheetSLOTDtlsView(string ID)
        {
            List<MyLinerRRMRG> ViewList = new List<MyLinerRRMRG>();
            DataTable dt = GetRatesheetSLOTDtlsValus(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRRMRG
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
                            " inner join NVO_LinerAgencyRatesheet on NVO_LinerAgencyRatesheet.PortOfLoading = NVO_SLOTMaster.POL and NVO_LinerAgencyRatesheet.PlaceofDischargeId = NVO_SLOTMaster.POD " +
                            " where NVO_LinerAgencyRatesheet.Id=" + RID;
            return GetViewData(_Query, "");
        }



        public List<MyLinerRRMRG> InsertRatesheetMRGSLOTMaster(MyLinerRRMRG Data)
        {
            List<MyLinerRRMRG> ListView = new List<MyLinerRRMRG>();

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

                        Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetMRG where RRID=@RRID and MRGID=@MRGID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_LinerAgencyRatesheetMRG(RRID,MRGID,QuotedAmount,FreightTerms,CntrTypes) " +
                                     " values (@RRID,@MRGID,@QuotedAmount,@FreightTerms,@CntrTypes) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LinerAgencyRatesheetMRG SET RRID=@RRID,MRGID=@MRGID,QuotedAmount=@QuotedAmount,FreightTerms=@FreightTerms,CntrTypes=@CntrTypes where RRID=@RRID and MRGID=@MRGID";
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

                        Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetSLOT where RRID=@RRID and SLTID=@SLTID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_LinerAgencyRatesheetSLOT(RRID,SLTID,SlotOperator,SlotTerm) " +
                                     " values (@RRID,@SLTID,@SlotOperator,@SlotTerm) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LinerAgencyRatesheetSLOT SET RRID=@RRID,SLTID=@SLTID,SlotOperator=@SlotOperator,SlotTerm=@SlotTerm where RRID=@RRID and SLTID=@SLTID";
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

                        Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetSLOTDtls where RRID=@RRID and SLTIDD=@SLTIDD)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_LinerAgencyRatesheetSLOTDtls(RRID,SLTIDD,ChargeCode,CntrTypes,Commodity,SlotAmt) " +
                                     " values (@RRID,@SLTIDD,@ChargeCode,@CntrTypes,@Commodity,@SlotAmt) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LinerAgencyRatesheetSLOTDtls SET RRID=@RRID,SLTIDD=@SLTIDD,ChargeCode=@ChargeCode,CntrTypes=@CntrTypes,Commodity=@Commodity,SlotAmt=@SlotAmt where RRID=@RRID and SLTIDD=@SLTIDD";
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

                    ListView.Add(new MyLinerRRMRG { RRID = Data.RRID });
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


        public List<MyLinerRRMRG> RatesheetMRGSelectView(MyLinerRRMRG Data)
        {
            List<MyLinerRRMRG> ViewList = new List<MyLinerRRMRG>();
            DataTable dt = GetRatesheetMRGSelectValus(Data.RRID.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRRMRG
                {

                    MRGID = Int32.Parse(dt.Rows[i]["MRGID"].ToString()),
                    QuotedAmount = dt.Rows[i]["QuotedAmount"].ToString()

                });
            }
            return ViewList;
        }
        public DataTable GetRatesheetMRGSelectValus(string RID)
        {
            string _Query = "select * from NVO_LinerAgencyRatesheetMRG where RRID=" + RID;
            return GetViewData(_Query, "");
        }

        public List<MyLinerRRMRG> RatesheetSLOTSelectView(MyLinerRRMRG Data)
        {
            List<MyLinerRRMRG> ViewList = new List<MyLinerRRMRG>();
            DataTable dt = GetRatesheetSLOTSelectValus(Data.RRID.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRRMRG
                {
                    SLTID = Int32.Parse(dt.Rows[i]["SLTID"].ToString())
                });
            }
            return ViewList;
        }

        public DataTable GetRatesheetSLOTSelectValus(string RID)
        {
            string _Query = "select * from NVO_LinerAgencyRatesheetSLOT where RRID=" + RID;
            return GetViewData(_Query, "");
        }
        public List<MyLinerRRMRG> RatesheetSLOTDtlsSelectView(MyLinerRRMRG Data)
        {
            List<MyLinerRRMRG> ViewList = new List<MyLinerRRMRG>();
            DataTable dt = GetRatesheetSLOTDtlsSelectValus(Data.RRID.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRRMRG
                {
                    SLTIDD = Int32.Parse(dt.Rows[i]["SLTIDD"].ToString())
                });
            }
            return ViewList;
        }
        public DataTable GetRatesheetSLOTDtlsSelectValus(string RID)
        {
            string _Query = "select * from NVO_LinerAgencyRatesheetSLOTDtls where RRID=" + RID;
            return GetViewData(_Query, "");
        }


        public List<MyLinerRatesheetRates> RatesheetCeckTariffRevRateExistingView(MyLinerRatesheetRates Data)
        {
            List<MyLinerRatesheetRates> ViewList = new List<MyLinerRatesheetRates>();
            DataTable dt = GetRatesheetCheckTariffRevRateExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheetRates
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
        public DataTable GetRatesheetCheckTariffRevRateExistingValus(MyLinerRatesheetRates Data)
        {
            string _Query = " select TID,PTID,0 as RID,ChargeCodeID, 1 as infoChID, BasisID as BasicID,CntrID as CntrTypeID,CurrencyID as CurrencyID,Amount as Amt, " +
                            " CommodityTypeID,CollectionModeID, 23 as ChargeOwnershipID from NVO_LinerAgencyRatesheet " +
                            " inner join NVO_PortTariffMaster on NVO_PortTariffMaster.PortLocationID = NVO_LinerAgencyRatesheet.PortOfLoading " +
                            " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                            " where NVO_PortTariffMaster.ValidTo >= NVO_LinerAgencyRatesheet.Date and ShipmentID=" + Data.ShipmentType + " and NVO_LinerAgencyRatesheet.Id=" + Data.RRID + " and CollectionModeID = " + Data.CollectionModeID + " and ChargeTypeID = " + Data.ChargeCodeID;
            return GetViewData(_Query, "");
        }



        public List<MyLinerRatesheet> InsertRatesheetRebateMaster(MyLinerRatesheet Data)
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

                        Cmd.CommandText = " IF((select count(*) from NVO_LinerAgencyRatesheetRebate where RRID=@RRID and RBID=@RBID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_LinerAgencyRatesheetRebate(RRID,ChargeCodeId,FRT,Rebate,Vendor,Remarks) " +
                                     " values (@RRID,@ChargeCodeId,@FRT,@Rebate,@Vendor,@Remarks) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LinerAgencyRatesheetRebate SET RRID=@RRID,ChargeCodeId=@ChargeCodeId,FRT=@FRT,Rebate=@Rebate,Vendor=@Vendor,Remarks=@Remarks where RRID=@RRID and RBID=@RBID";
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

                    RateList.Add(new MyLinerRatesheet { RRID = Data.RRID });
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


        public List<MyLinerRatesheetRates> RatesheetRebateExistingView(MyLinerRatesheetRates Data)
        {
            List<MyLinerRatesheetRates> ViewList = new List<MyLinerRatesheetRates>();
            DataTable dt = GetRatesheetRebateExistingValus(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheetRates
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


        public DataTable GetRatesheetRebateExistingValus(MyLinerRatesheetRates Data)
        {
            string _Query = "Select * from NVO_LinerAgencyRatesheetRebate where RRID=" + Data.RRID;
            return GetViewData(_Query, "");
        }


        public List<MyLinerRatesheet> SendingApproval(MyLinerRatesheet Data)
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
                        Cmd.CommandText = " UPDATE NVO_LinerAgencyRatesheet SET RSStatus=@RSStatus where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", Data.Status));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        trans.Commit();
                    }
                    if (Data.Status == "1")
                    {
                        Cmd.CommandText = " UPDATE NVO_LinerAgencyRatesheet SET RSStatus=@RSStatus where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", Data.Status));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        trans.Commit();
                    }
                    if (Data.Status == "2")
                    {
                        Cmd.CommandText = " UPDATE NVO_LinerAgencyRatesheet SET RSStatus=@RSStatus,RJStatus=@RJStatus,RJRemarks=@RJRemarks where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RJStatus", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RJRemarks", Data.Notes));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        trans.Commit();
                    }
                    if (Data.Status == "3")
                    {
                        Cmd.CommandText = " UPDATE NVO_LinerAgencyRatesheet SET RSStatus=@RSStatus, REStatus=@REStatus,RERemarks=@RERemarks where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@REStatus", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RERemarks", Data.Notes));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        trans.Commit();
                    }

                    if (Data.Status == "4")
                    {
                        Cmd.CommandText = " UPDATE NVO_LinerAgencyRatesheet SET RSStatus=@RSStatus,APStatus=@APStatus,APRemarks=@APRemarks where ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RSStatus", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@APStatus", Data.Status));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@APRemarks", Data.Notes));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        trans.Commit();
                    }
                    
                    DataTable _dtv = GetBLNumbers(Data);
                    if(_dtv.Rows.Count>0)
                    {
                        Data.ID = Int32.Parse(_dtv.Rows[0]["ID"].ToString());
                        Data.LinerCode = _dtv.Rows[0]["LinerCode"].ToString();
                        Data.POLCode = _dtv.Rows[0]["POLCode"].ToString();
                        Data.PODCode = _dtv.Rows[0]["PODCode"].ToString();
                        Data.DatYear = _dtv.Rows[0]["DatYear"].ToString();
                        Data.DatMonth = _dtv.Rows[0]["DtMonth"].ToString();

                    }
                    string AutoGen = GetMaxseqNumber("LinerRRNo", "1",Data.SessionFinYear);
                    string Liner = _dtv.Rows[0]["LinerCode"].ToString();
                    string POLC = _dtv.Rows[0]["POLCode"].ToString();
                    string PODC = _dtv.Rows[0]["PODCode"].ToString();
                    string Dtyear = _dtv.Rows[0]["DatYear"].ToString();
                    string DtMonth = _dtv.Rows[0]["DtMonth"].ToString();
                    string BLNumber = Liner + POLC + PODC + Dtyear + DtMonth + AutoGen;
                    Cmd.CommandText = " UPDATE NVO_LinerAgencyRatesheet SET BLNumber=@BLNumber where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", BLNumber));
                    result = Cmd.ExecuteNonQuery();
                    //Cmd.Parameters.Clear();
                    //trans.Commit();

                    RateList.Add(new MyLinerRatesheet { ID = Data.ID });
                    if (Data.Status == "1")
                    {
                        DataTable dtE = GetEmailsedingRRView(Data.ID.ToString());
                        if (dtE.Rows.Count > 0)
                        {
                            string HTMLstr = "";

                            HTMLstr = "<table border='1' cellpadding='0' cellspacing='0' width='50%' style='font-family:Arial; border: 1px solid #2196f3;'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td style='background-color:#2196f3;color:#fff;border-right:0px solid #303297;border-left:0px solid #303297;border-top:0px solid #303297;border-bottom:0px solid #303297'> " +
                                      " <table cellpadding='0' cellspacing='0' width='100%'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td style='font-family:Arial;font-size:14px;font-weight:bold;text-align:left;color:#fff;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;'>RR NUMBER : <a href='https://nerida.rmjtech.in/RRPDF/" + dtE.Rows[0]["RatesheetNo"].ToString() + ".pdf' style='color:#fff;'>" + dtE.Rows[0]["RatesheetNo"].ToString() + "</a></td> " +
                                      " <td style='font-family:Arial;font-size:14px;font-weight:bold;padding-top:2px;padding-left:3px;padding-bottom:2px;padding-right:3px;text-align:right;'> STATUS : " + dtE.Rows[0]["Status"].ToString() + "</td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td style='border:none;'> " +
                                      " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px; font-size:14px;'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2'> " +
                                      " <p style='margin-top: 10px;margin-bottom:0px;margin-left:10px;padding-bottom:0;'>Hi,</p><p style='padding-top:0;margin-top:0;'>This is the system generated message to notify the rate request details</p> " +
                                      " </td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td style ='border:none;'> " +
                                      " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2' style='background-color:#2196f3;color:#fff;padding-left:4px;padding-top:4px;padding-bottom:4px;font-size:14px;'> Rate Request Details</td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td style='border:none;'> " +
                                      " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px; padding-bottom:8px; font-size:14px;'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2'> " +
                                      " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2' style='font-weight:bold;'> Customer </td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["Customer"].ToString() + "</td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='font-weight:bold;'> Loading </td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='padding-bottom:8px;'> " + dtE.Rows[0]["Loading"].ToString() + " </td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='font-weight:bold;'>T/S Port</td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["TSPort"].ToString() + "</td> " +
                                      " </tr> " +
                                      " <tr> " +
                                       " <td colspan='2' style='font-weight:bold;'>Freedays</td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["Freedays"].ToString() + " Days</td> " +
                                      " </tr> " +
                                       " <tr> " +
                                       " <td colspan='2' style='font-weight:bold;'>Collection Mode</td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["PePaid"].ToString() + "</td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " <td colspan='2'> " +
                                      " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2' style='font-weight:bold;'> Sales Person </td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["SalesPerson"].ToString() + "</td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='font-weight:bold;'> Discharge </td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='padding-bottom:8px;'> " + dtE.Rows[0]["Discharge"].ToString() + " </td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='font-weight:bold;'>Commodity</td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='padding-bottom:8px;'>GENERAL CARGO</td> " +
                                      " </tr> " +
                                      " <tr> " +
                                       " <td colspan='2' style='font-weight:bold;'>Validity Till</td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["ValidDate"].ToString() + "</td> " +
                                      " </tr> " +
                                       " <tr> " +
                                       " <td colspan='2' style='font-weight:bold;'>Remarks</td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td colspan='2' style='padding-bottom:8px;'>" + dtE.Rows[0]["Remarks"].ToString() + "</td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                      " <tr> " +
                                      " <td style ='border:none;'> " +
                                      " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2' style='background-color:#2196f3;color:#fff;padding-left:4px;padding-top:4px;padding-bottom:4px;font-size:14px;'> Rate</td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                       " <tr> " +
                                      " <td style='border:none;'> " +
                                      " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;font-size:14px;'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2'>" +
                                       " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2' style='font-weight:bold;'>20GP - " + dtE.Rows[0]["Cntr20"].ToString() + " USD</td>" +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                       " <td colspan='2'>" +
                                       " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2' style='font-weight:bold;'>40HC - " + dtE.Rows[0]["Cntr40"].ToString() + " USD</td>" +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                        " <tr> " +
                                      " <td style='border:none;'> " +
                                      " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2' style='background-color:#2196f3;color:#fff; padding-left:4px;padding-top:4px;padding-bottom:4px;font-size:14px;'> Slot Cost </td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                       " <tr> " +
                                      " <td style='border:none;'> " +
                                      " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;font-size:14px;'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2'>" +
                                       " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2' style='font-weight:bold;'>20GP - " + dtE.Rows[0]["Slot20"].ToString() + " USD</td>" +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                       " <td colspan='2'>" +
                                       " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2' style='font-weight:bold;'>40HC - " + dtE.Rows[0]["Slot40"].ToString() + " USD</td>" +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                      " <tr> " +
                                        " <td style='border:none;'> " +
                                      " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2' style='color:#000; padding-left:4px;padding-top:4px;padding-bottom:4px;font-size:14px;'> Slot Operator </td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                       " <tr> " +
                                        " <td style='border:none;'> " +
                                      " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;font-size:14px;'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2' style='font-weight:bold;'>" + dtE.Rows[0]["SlotOpt"].ToString() + "</td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                        " <tr> " +
                                      " <td style='border:none;'> " +
                                      " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding-left:15px;padding-right:15px;padding-bottom:8px;padding-top:6px;border-top:1px solid #2196f3;font-size:14px;'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2'>" +
                                       " <table border='0' cellpadding='0' cellspacing='0' width='100%'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2' style='font-weight:bold;'>Created By: Venkat</td>" +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                       " <td colspan='2'>" +
                                       " <table border='0' cellpadding='0' cellspacing='0' width='100%' style='padding:left:64px!important;'> " +
                                      " <tbody> " +
                                      " <tr> " +
                                      " <td colspan='2' style='font-weight:bold;'>Created On : 10/05/2021</td>" +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table> " +
                                      " </td> " +
                                      " </tr> " +
                                      " </tbody> " +
                                      " </table>";

                            MailMessage EmailObject = new MailMessage();
                            EmailObject.From = new MailAddress("support@arctic1994.com", "   NERIDA SHIPPING");

                            EmailObject.To.Add(new MailAddress("venkat@neridashipping.com"));
                            EmailObject.Body = HTMLstr;
                            EmailObject.IsBodyHtml = true;
                            EmailObject.Priority = MailPriority.Normal;
                            EmailObject.Subject = "Rate Request: " + dtE.Rows[0]["RatesheetNo"].ToString() + " - APPROVAL PENDING";
                            EmailObject.Priority = MailPriority.Normal;
                            SmtpClient SMTPServer = new SmtpClient();
                            SMTPServer.UseDefaultCredentials = true;
                            SMTPServer.Credentials = new NetworkCredential("support@arctic1994.com", "ihyiiK!5");
                            SMTPServer.Host = "smtp.arctic1994.com";
                            SMTPServer.ServicePoint.MaxIdleTime = 1;
                            SMTPServer.Port = 587;
                            SMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                            //SMTPServer.Send(EmailObject);
                        }
                    }

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

        public DataTable GetBLNumbers(MyLinerRatesheet Data)
        {
            string _Query = "select NVO_LinerAgencyRatesheet.ID, " +
                            " (select top(1) LinerCode From NVO_LinerBLNoLogics where NVO_LinerBLNoLogics.LinerID = NVO_LinerAgencyRatesheet.LinerID)as LinerCode, " +
                            " (select top(1) RIGHT(RTRIM(PortCode), 3) from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerAgencyRatesheet.PortOfLoading)as POLCode, " +
                            " (select top(1) RIGHT(RTRIM(PortCode), 3) from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerAgencyRatesheet.FinalPODId)as PODCode, " +
                            " FORMAT(Date, 'yy') as DatYear, " +
                            " FORMAT(Date,'MM')as DtMonth, " +
                            " *from NVO_LinerAgencyRatesheet where ID=" + Data.ID ;
            return GetViewData(_Query, "");
        }
        public DataTable GetEmailsedingRRView(string RRID)
        {
            string _Query = " select NVO_LinerAgencyRatesheet.Id,RatesheetNo,convert(varchar, ValidTill, 106) as ValidDate,(select top(1) Status from NVO_RRStatusMaster where Id = NVO_LinerAgencyRatesheet.RSStatus) as Status,  " +
                            " (select top(1) CustomerName from NVO_CustomerMaster where ID = BookingPartyID) as Customer, " +
                            " (select top(1) UserName from NVO_UserDetails where ID = AgentID) as SalesPerson, " +
                            " (select top(1) PortName from NVO_PortMaster where ID = PortOfLoading) as Loading, " +
                            " (select top(1) PortName from NVO_PortMaster where ID = PlaceofDischargeId) as Discharge, " +
                            " (select top(1) PortName from NVO_PortMaster where ID = TranshimentPortID) as TSPort, '14' as Freedays,Remarks, " +
                            " (select top(1)(select top(1) GeneralName from NVO_GeneralMaster where ID = NVO_LinerAgencyRatesheetMRG.FreightTerms) from NVO_LinerAgencyRatesheetMRG where RRID = NVO_LinerAgencyRatesheet.Id) as PePaid, " +
                            " (select top(1)(select top(1) Size from NVO_tblCntrTypes where SizeId = 1 and ID = NVO_LinerAgencyRatesheetMRG.CntrTypes) from NVO_LinerAgencyRatesheetMRG where RRID = NVO_LinerAgencyRatesheet.Id) as Cntr20, " +
                            " (select sum(QuotedAmount) from NVO_LinerAgencyRatesheetMRG where CntrTypes = 1 and RRID = NVO_LinerAgencyRatesheet.Id) as MrgRate20, " +
                            " (select top(1)(select top(1) Size from NVO_tblCntrTypes where SizeId = 2 and ID = NVO_LinerAgencyRatesheetMRG.CntrTypes) from NVO_LinerAgencyRatesheetMRG where RRID = NVO_LinerAgencyRatesheet.Id) as Cntr40, " +
                            " (select sum(QuotedAmount) from NVO_LinerAgencyRatesheetMRG where CntrTypes = 2 and RRID = NVO_LinerAgencyRatesheet.Id) as MrgRate40, " +
                            " (select sum(SlotAmt) from NVO_LinerAgencyRatesheetSLOTDtls where CntrTypes = 1 and Commodity = 3 and RRID = NVO_LinerAgencyRatesheet.Id) as Slot20, " +
                            " (select sum(SlotAmt) from NVO_LinerAgencyRatesheetSLOTDtls where CntrTypes = 2 and Commodity = 4 and RRID = NVO_LinerAgencyRatesheet.Id) as Slot40, " +
                            " (select top(1) (select top(1) CustomerName from NVO_CustomerMaster where ID =slotOperator) from NVO_LinerAgencyRatesheetSLOT where NVO_LinerAgencyRatesheetSLOT.RRID = NVO_LinerAgencyRatesheet.Id)  as SlotOpt " +
                            " from NVO_LinerAgencyRatesheet where Id = " + RRID;
            return GetViewData(_Query, "");
        }

        public List<MyLinerRatesheet> RRNotificationRecordView(MyLinerRatesheet Data)
        {
            List<MyLinerRatesheet> ViewList = new List<MyLinerRatesheet>();
            DataTable dt = GetRRNotificationView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheet
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

        public DataTable GetRRNotificationView(MyLinerRatesheet Data)
        {
            string strWhere = "";
            string _Query = " select ID, RatesheetNo,(select top(1) CustomerName from NVO_CustomerMaster where Id = BookingPartyID) as BookingParty, " +
                            " convert(varchar, date, 101) as Datev,(select top(1) PortName from NVO_PortMaster where Id = PortOfOrgin) PortofOrgin, " +
                            " (select top(1) PortName from NVO_PortMaster where Id = PortofLoading) PortofLoading,(select top(1) PortName from NVO_PortMaster where Id = PlaceofDischargeId) PlaceofDischarge, " +
                            "(select top(1) Status from NVO_RRStatusMaster where Id=NVO_LinerAgencyRatesheet.RSStatus) as Status " +
                            " from NVO_LinerAgencyRatesheet";

            strWhere += _Query + " where RSStatus = 1";

            if (Data.RRNumber != "")
                if (strWhere == "")
                    strWhere += _Query + " where RatesheetNo like'%" + Data.RRNumber + "%'";
                else
                    strWhere += " and RatesheetNo like'%" + Data.RRNumber + "%'";

            if (Data.PortofLoading != null)
                if (strWhere == "")
                    strWhere += _Query + " where PortOfLoading=" + Data.PortofLoading;
                else
                    strWhere += " and PortOfLoading=" + Data.PortofLoading;

            if (Data.PortofDischarge != "")
                if (strWhere == "")
                    strWhere += _Query + " where PlaceofDischargeId=" + Data.PortofDischarge;
                else
                    strWhere += " and PlaceofDischargeId=" + Data.PortofDischarge;


            if (Data.BookingParty != "")
                if (strWhere == "")
                    strWhere += _Query + " where (select top(1) CustomerName from NVO_CustomerMaster where Id = BookingPartyID) like'%" + Data.BookingParty + "%'";
                else
                    strWhere += " and (select top(1) CustomerName from NVO_CustomerMaster where Id = BookingPartyID) like'%" + Data.BookingParty + "%'";

            if (Data.Status != null)
                if (strWhere == "")
                    strWhere += _Query + " where RSStatus=" + Data.PortofDischarge;
                else
                    strWhere += " and RSStatus=" + Data.PortofDischarge;
            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");


        }

        public List<MyLinerRatesheet> RRFinalSubmitCheckRecordView(MyLinerRatesheet Data)
        {
            List<MyLinerRatesheet> ViewList = new List<MyLinerRatesheet>();
            DataTable dt = GetRRFinalSubmitCheckView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheet
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

        public DataTable GetRRFinalSubmitCheckView(MyLinerRatesheet Data)
        {
            string _Query = " select Id, (select count(RRID) as RCNtr from NVO_LinerAgencyRatesheetCntrTypes where RRID = NVO_LinerAgencyRatesheet.ID) as CheckCntr, " +
                            " (select count(RRID) from NVO_LinerAgencyRatesheetMRG where NVO_LinerAgencyRatesheetMRG.RRID = NVO_LinerAgencyRatesheet.ID) as CheckMRG, " +
                            " (select Count(RRID) from NVO_LinerAgencyRatesheetSLOTDtls where NVO_LinerAgencyRatesheetSLOTDtls.RRID = NVO_LinerAgencyRatesheet.ID) as CheckSLOT,RSStatus " +
                            " from NVO_LinerAgencyRatesheet where ID = " + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyLinerRatesheet> RRDashBordCountRecordView()
        {
            List<MyLinerRatesheet> ViewList = new List<MyLinerRatesheet>();
            DataTable dt = GetRRDashBoradView();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheet
                {

                    Pending = dt.Rows[i]["PENDING"].ToString(),
                    Rejected = dt.Rows[i]["REJECTED"].ToString(),
                    REQuote = dt.Rows[i]["REUOTE"].ToString(),
                    Approved = dt.Rows[i]["APPROVED"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetRRDashBoradView()
        {
            string _Query = " select " +
                            " (select count(Date) from NVO_LinerAgencyRatesheet where RSStatus is NULL or RSStatus = 1) as PENDING, " +
                            " (select count(Date) from NVO_LinerAgencyRatesheet where RSStatus = 2) as REJECTED, " +
                            " (select count(Date) from NVO_LinerAgencyRatesheet where RSStatus = 3 ) as REUOTE, " +
                            " (select count(date) from NVO_LinerAgencyRatesheet where RSStatus = 4 ) as APPROVED";
            return GetViewData(_Query, "");
        }

        public List<MyLinerRRRate> RRFreighTariff(MyLinerRRRate Data)
        {
            List<MyLinerRRRate> ViewList = new List<MyLinerRRRate>();
            DataTable dt = GetRRFreightTraiff(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRRRate
                {
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

        public DataTable GetRRFreightTraiff(MyLinerRRRate Data)
        {
            string _Query = "";
            if (Data.TraiffRegular == "137")
            {
                string PortID = "0";

                if (Data.ExportIHC == "1")
                    PortID = Data.POL;
                if (Data.ImportIHC == "1")
                    PortID += "," + Data.POD;

                _Query = " select TID, CntrID as ChargeTypeID, ChargeCodeID, CurrencyID, CollectionModeID, Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt from NVO_PortTariffMaster " +
                         " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                         " where CntrId in (" + Data.CntrTypes + ") and PortLocationID in (" + PortID + ") and TraiffRegular = " + Data.TraiffRegular + " and CommodityTypeID in (" + Data.CommodityTypeID + ")";



            }
            if (Data.TraiffRegular == "135")
            {

                _Query = " select TID, CntrID as ChargeTypeID, ChargeCodeID, CurrencyID, CollectionModeID, Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt from NVO_PortTariffMaster " +
                                " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                                " where CntrId in (" + Data.CntrTypes + ") and PortLocationID = " + Data.POL + "  and TraiffRegular = " + Data.TraiffRegular + " and CommodityTypeID in (" + Data.CommodityTypeID + ")";
            }
            if (Data.TraiffRegular == "136")
            {

                _Query = " select TID, CntrID as ChargeTypeID, ChargeCodeID, CurrencyID, CollectionModeID, Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt from NVO_PortTariffMaster " +
                                " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                                " where CntrId in (" + Data.CntrTypes + ") and (PortLocationID=  " + Data.POL + "  or  PortLocationID=" + Data.POD + ") and TraiffRegular = " + Data.TraiffRegular + " and CommodityTypeID in (" + Data.CommodityTypeID + ")";
            }
            if (Data.TraiffRegular == "138")
            {

                _Query = " select TID, CntrID as ChargeTypeID, ChargeCodeID, CurrencyID, CollectionModeID, Amount, Amount as ManifestRate, Amount as CustomeRate,'0.0' as RateDiffernt from NVO_PortTariffMaster " +
                                " inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                                " where CollectionModeID = " + Data.CollectionModeID + " and CntrId in (" + Data.CntrTypes + ") and PortLocationID = " + Data.PortID + "  and TraiffRegular = " + Data.TraiffRegular + " and CommodityTypeID in (" + Data.CommodityTypeID + ")";
            }

            return GetViewData(_Query, "");
        }

        public List<MyLinerRRRate> RRTariffExisting(MyLinerRRRate Data)
        {
            List<MyLinerRRRate> ViewList = new List<MyLinerRRRate>();
            DataTable dt = GetRRTariffExisting(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRRRate
                {
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
        public DataTable GetRRTariffExisting(MyLinerRRRate Data)
        {
            string _Query = " Select TariffID as  RCID,CntrType,ChargeCodeID,CurrencyID,PaymentModeID,ReqRate,ManifRate,CustomerRate,RateDiff  " +
                            " from NVO_LinerAgencyRatesheetCharges where RRId = " + Data.ID + " and TariffTypeID = " + Data.TraiffRegular + " and PaymentModeID=" + Data.PaymentModeID;
            return GetViewData(_Query, "");
        }


        public List<MyLinerRRRate> RRFreighTariffLocalAmt(MyLinerRRRate Data)
        {
            List<MyLinerRRRate> ViewList = new List<MyLinerRRRate>();
            DataTable dt = GetRRFreightTraiffLocalAmt(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRRRate
                {
                    Currency = dt.Rows[0]["Currency"].ToString(),
                    Amount = dt.Rows[0]["Amount"].ToString()
                });
            }

            return ViewList;
        }

        public DataTable GetRRFreightTraiffLocalAmt(MyLinerRRRate Data)
        {
            string _Query = " select sum(Amount) as Amount, " +
                            " (select top(1)(select CurrencyCode from NVO_CurrencyMaster where NVO_CurrencyMaster.ID = CurrencyId)  from NVO_PortTariffdtls where PTID = NVO_PortTariffMaster.ID) as Currency " +
                            " from NVO_PortTariffMaster inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
                            " where CollectionModeID = " + Data.CollectionModeID + " and CntrId in (" + Data.CntrTypes + ") and PortLocationID = " + Data.PortID + "  and TraiffRegular = " + Data.TraiffRegular + " and CommodityTypeID in (" + Data.CommodityTypeID + ")" +
                            " group by NVO_PortTariffMaster.ID";
            return GetViewData(_Query, "");
        }


        public List<MyLinerRRRate> ExistingRateSheetFreighTariffLocalAmt(MyLinerRRRate Data)
        {
            List<MyLinerRRRate> ViewList = new List<MyLinerRRRate>();
            DataTable dt = GetExistRatesheetFreightTraiffLocalAmt(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRRRate
                {
                    Currency = dt.Rows[0]["Currency"].ToString(),
                    Amount = dt.Rows[0]["AmountRate"].ToString()


                });
            }

            return ViewList;
        }

        public DataTable GetExistRatesheetFreightTraiffLocalAmt(MyLinerRRRate Data)
        {
            string _Query = " select sum(CustomerRate) as AmountRate,(select top(1) CurrencyCode from NVO_CurrencyMaster where ID = CurrencyID) as Currency " +
                            " from NVO_LinerAgencyRatesheetCharges where TariffTypeID = " + Data.TraiffRegular + " and RRId = " + Data.RRID + " and PaymentModeID = " + Data.PaymentModeID + " " +
                            " group by NVO_LinerAgencyRatesheetCharges.CurrencyID";
            //string _Query = " select sum(Amount) as Amount, " +
            //                " (select top(1)(select CurrencyCode from NVO_CurrencyMaster where NVO_CurrencyMaster.ID = CurrencyId)  from NVO_PortTariffdtls where PTID = NVO_PortTariffMaster.ID) as Currency " +
            //                " from NVO_PortTariffMaster inner join NVO_PortTariffdtls on NVO_PortTariffdtls.PTID = NVO_PortTariffMaster.ID " +
            //                " where CollectionModeID = " + Data.CollectionModeID + " and CntrId in (" + Data.CntrTypes + ") and PortLocationID = " + Data.PortID + "  and TraiffRegular = " + Data.TraiffRegular + " and CommodityTypeID in (" + Data.CommodityTypeID + ")" +
            //                " group by NVO_PortTariffMaster.ID";
            return GetViewData(_Query, "");
        }


        public List<MyLinerRRRate> RRBkgPartSales(MyLinerRRRate Data)
        {
            List<MyLinerRRRate> ViewList = new List<MyLinerRRRate>();
            DataTable dt = GetRRBkgPartSales(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRRRate
                {
                    ID = Int32.Parse(dt.Rows[0]["SelesPersonID"].ToString()),
                    SalesPersion = dt.Rows[0]["SalesPerson"].ToString()


                }); ; ;
            }

            return ViewList;
        }
        public DataTable GetRRBkgPartSales(MyLinerRRRate Data)
        {
            string _Query = "select SalesPerson,SelesPersonID from NVO_CusSalesLink where CustomerID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region Ganesh RRNOTIFICATION

        public List<MyLinerRatesheet> RatesheetNotificationValues(string ID)
        {
            List<MyLinerRatesheet> ViewList = new List<MyLinerRatesheet>();
            DataTable dt = GetRatesheetNotificationValues(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheet
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
                            "   (select top(1) ImpFreeDays from NVO_LinerAgencyRatesheetMode where RRID = ID) as FreeDays, " +
                            " (select top(1) GeneralName from  NVO_LinerAgencyRatesheetCharges inner join NVO_GeneralMaster GM ON GM.ID = NVO_LinerAgencyRatesheetCharges.PaymentModeID AND GM.SeqNo = 9 WHERE RRID = NVO_LinerAgencyRatesheet.ID And TariffTypeID = 135) as PePaid,  " +
                            " (select top(1)(select top(1) CustomerName from NVO_CustomerMaster where ID = slotOperator) from NVO_LinerAgencyRatesheetSLOT where NVO_LinerAgencyRatesheetSLOT.RRID = NVO_LinerAgencyRatesheet.Id)  as SlotOpt, " +
                            " convert(varchar, ValidTill, 106) as ValidDate " +
                            " from NVO_LinerAgencyRatesheet where ID=" + RID;
            return GetViewData(_Query, "");
        }


        public List<MyLinerRatesheet> RateSheetNotificationTHCandIHCValues(string ID)
        {
            List<MyLinerRatesheet> ViewList = new List<MyLinerRatesheet>();
            DataTable dt = GetRateSheetNotificationTHCandIHCValues(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerRatesheet
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Size = dt.Rows[0]["Size"].ToString(),
                    DestTHCRate = dt.Rows[0]["DestTHCRate"].ToString(),
                    LoadTHCRate = dt.Rows[0]["LoadTHCRate"].ToString(),
                    ExportIHCRate = dt.Rows[0]["ExportIHCRate"].ToString(),
                    ImportIHCRate = dt.Rows[0]["ImportIHCRate"].ToString(),
                });
            }
            return ViewList;
        }


        public DataTable GetRateSheetNotificationTHCandIHCValues(string RID)
        {
            string _Query = "select R.ID,TC.Size,LoadPortTHC.LoadTHCRate,DestTHC.DestTHCRate,ExportIHC.ExportIHCRate," +
                " ImportIHC.ImportIHCRate from  NVO_LinerAgencyRatesheet R Inner join NVO_LinerAgencyRatesheetCntrTypes RCT ON RCT.RRID = R.ID " +
                " Inner join NVO_tblCntrTypes TC ON TC.ID = RCT.CntrTypeID OUTER APPLY(Select ManifRate as LoadTHCRate  from NVO_LinerAgencyRatesheetCharges RSC where RSC.ChargeCodeID = 4 and R.ID = RSC.RRID AND RSC.TariffTypeID = 136) LoadPortTHC " +
                " OUTER APPLY(Select ManifRate as DestTHCRate from NVO_LinerAgencyRatesheetCharges RSC where RSC.ChargeCodeID = 9 and R.ID = RSC.RRID AND  RSC.TariffTypeID = 136) DestTHC " +
               " OUTER APPLY(Select ManifRate As ExportIHCRate from NVO_LinerAgencyRatesheetCharges RSC where R.ID = RSC.RRID  AND  RSC.TariffTypeID = 137 and RSC.PaymentModeID = 18) ExportIHC " +
               " OUTER APPLY(Select ManifRate As ImportIHCRate from NVO_LinerAgencyRatesheetCharges RSC where R.ID = RSC.RRID AND  RSC.TariffTypeID = 137 and RSC.PaymentModeID = 19) ImportIHC WHERE R.ID = " + RID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region LinerBOL
        public List<MYLinerBOL> BOLViewValus(MYLinerBOL Data)
        {
            List<MYLinerBOL> ViewList = new List<MYLinerBOL>();
            DataTable dt = GetBOLSearchValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerBOL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    //BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    //BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    RRNo = dt.Rows[i]["RatesheetNo"].ToString(),
                    BkgParty = dt.Rows[i]["BkgParty"].ToString(),
                    LinerName = dt.Rows[i]["LinerName"].ToString(),
                    ShipmentType = dt.Rows[i]["ShipmentType"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetBOLSearchValus(MYLinerBOL Data)
        {
            string strWhere = "";

            string _Query = "select ID,Case when BLNumber IS NULL  then 'DRAFT' else  BLNumber end as BLNumber,RateSheetNo, " +
                            " (select CustomerName from NVO_CustomerMaster where NVO_CustomerMaster.ID = NVO_LinerAgencyRatesheet.BookingPartyID) as BkgParty, " +
                            " (select CustomerName from NVO_CustomerMaster where NVO_CustomerMaster.ID = NVO_LinerAgencyRatesheet.LinerID)as LinerName, " +
                            " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerAgencyRatesheet.PlaceofDischargeId)as POD, " +
                            " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerAgencyRatesheet.PortOfLoading)as POL, " +
                            " (select GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_LinerAgencyRatesheet.ShipmentID)as ShipmentType " +
                            " from NVO_LinerAgencyRatesheet";

            //string _Query = "select NVO_LinerBOL.ID,BkgID, NVO_LinerAgencyRatesheet.BLNumber,RatesheetNo, " +
            //                " (select CustomerName from NVO_CustomerMaster where NVO_CustomerMaster.ID = NVO_LinerAgencyRatesheet.BookingPartyID) as BkgParty, " +
            //                " (select CustomerName from NVO_CustomerMaster where NVO_CustomerMaster.ID = NVO_LinerAgencyRatesheet.LinerID)as LinerName, " +
            //                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerBOL.PODID)as POD, " +
            //                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerBOL.POLID)as POL, " +
            //                " (select GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_LinerAgencyRatesheet.ShipmentID)as ShipmentType " +
            //                " from NVO_LinerBOL " +
            //                " left Outer Join NVO_LinerAgencyRatesheet On NVO_LinerAgencyRatesheet.BookingPartyID = NVO_LinerBOL.ID";
            if (Data.BLNumber != "")
                if (strWhere == "")
                    strWhere += _Query + " where BLNumber= " + Data.BLNumber;
                else
                    strWhere += " and BLNumber= " + Data.BLNumber;
            return GetViewData(_Query, "");
        }

        public List<MYLinerBOL> BOLCountValus()
        {
            List<MYLinerBOL> ViewList = new List<MYLinerBOL>();
            DataTable dt = GetBOLCount();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerBOL
                {

                    Draft = dt.Rows[i]["Draft"].ToString(),
                    Cancelled = dt.Rows[i]["Cancel"].ToString(),
                    Confirm = dt.Rows[i]["Confirm"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetBOLCount()
        {
            string _Query = " select " +
                            " (select count(ID) from v_BLCountValues where Status is null) as Draft, " +
                            " (select count(ID) from v_BLCountValues where Status = 1) as Confirm, " +
                            " (select count(ID) from v_BLCountValues  where Status = 2) as Cancel";
            return GetViewData(_Query, "");
        }

        public List<MYLinerBOL> BOLCntrNoSelectExistingValus(MYLinerBOL Data)
        {
            List<MYLinerBOL> ViewList = new List<MYLinerBOL>();
            DataTable dt = GetBOLSelectCntrNoExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerBOL
                {
                    Size = dt.Rows[i]["size"].ToString(),
                    ISOCode = dt.Rows[i]["IsOCodeID"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetBOLSelectCntrNoExistingValus(MYLinerBOL Data)
        {
            string _Query = "select Id,CntrNo,(select size  from NVO_tblCntrTypes where Id =TypeID) as size,IsOCodeID  from NVO_Containers where ID=" + Data.CntrID;
            return GetViewData(_Query, "");
        }

        public List<MYLinerBOL> BOLVesselVoyageValus(MYLinerBOL Data)
        {
            List<MYLinerBOL> ViewList = new List<MYLinerBOL>();
            DataTable dt = GetVesselVoyageValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerBOL
                {

                    CurPortID = dt.Rows[i]["CurrentPortID"].ToString(),
                    NextPortID = dt.Rows[i]["NextPortID"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetVesselVoyageValus(MYLinerBOL Data)
        {
            string _Query = " select ID,(select top(1) VesselName from NVO_VesselMaster where ID = NVO_VoyageDetails.VesID) + ' -' + VoyageNo as VesVoy, " +
                            " CurrentPortID,(select top(1) NextPortID from NVO_VoyPortDtls where VoydtID = NVO_VoyageDetails.Id) as NextPortID, " +
                            " convert(varchar, ETA, 103) as ETA,convert(varchar, ETD, 103) as ETD " +
                            " from NVO_VoyageDetails where Id = " + Data.VesVoyID;
            return GetViewData(_Query, "");
        }

        public List<MYLinerBOL> BOLInsert(MYLinerBOL Data)
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


                    Cmd.CommandText = " IF((select count(*) from NVO_LinerBOL where ID=@ID)<=0) " +
                                 " BEGIN " +
                                 " INSERT INTO  NVO_LinerBOL(BLNumber,DesAgentID,NoofOriginal,SurrenderStatus,MarkNo,CagoDescription,BLTypes,MotherBL,FreeDays,FreightPaymentID,Remarks,CurrentDate,POOID,POLID,PODID,FPODID,LinerID,LinerBLNo,RatesheetNo,BookingParty,VesVoy,OtherRemarks,RRID) " +
                                 " values (@BLNumber,@DesAgentID,@NoofOriginal,@SurrenderStatus,@MarkNo,@CagoDescription,@BLTypes,@MotherBL,@FreeDays,@FreightPaymentID,@Remarks,@CurrentDate,@POOID,@POLID,@PODID,@FPODID,@LinerID,@LinerBLNo,@RatesheetNo,@BookingParty,@VesVoy,@OtherRemarks,@RRID) " +
                                 " END  " +
                                 " ELSE " +
                                 " UPDATE NVO_LinerBOL SET BLNumber=@BLNumber,DesAgentID=@DesAgentID,NoofOriginal=@NoofOriginal,SurrenderStatus=@SurrenderStatus,MarkNo=@MarkNo,CagoDescription=@CagoDescription," +
                                 " BLTypes=@BLTypes,MotherBL=@MotherBL,FreeDays=@FreeDays,FreightPaymentID=@FreightPaymentID,Remarks=@Remarks,CurrentDate=@CurrentDate,POOID=@POOID,POLID=@POLID,PODID=@PODID,FPODID=@FPODID,LinerID=@LinerID,LinerBLNo=@LinerBLNo,RatesheetNo=@RatesheetNo,BookingParty=@BookingParty,VesVoy=@VesVoy,OtherRemarks=@OtherRemarks,RRID=@RRID where  ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLNumber));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DesAgentID", Data.DesAgentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NoofOriginal", Data.NoofOriginal));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SurrenderStatus", Data.SurrenderStatus));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MarkNo", Data.MarkNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CagoDescription", Data.CagoDescription));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLTypes", Data.BLTypes));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MotherBL", Data.MotherBL));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDays", Data.FreeDays));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreightPaymentID", Data.FreightPaymentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now.ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POOID", Data.POOID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POLID", Data.POLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PODID", Data.PODID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FPODID", Data.FPODID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LinerID", Data.LinerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LinerBLNo", Data.LinerBLNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RatesheetNo", Data.RRNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BookingParty", Data.BkgParty));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoy", Data.VesVoy));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OtherRemarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_LinerBOL')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;


                    string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_LinerBOLCustomerDetails where BCID=@BCID and RRID=@RRID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_LinerBOLCustomerDetails(RRID,PartyTypeID,PartID,PartType,PartyName,PartyAddress,BLID) " +
                                     " values (@RRID,@PartyTypeID,@PartID,@PartType,@PartyName,@PartyAddress,@BLID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LinerBOLCustomerDetails SET RRID=@RRID,PartyTypeID=@PartyTypeID,PartID=@PartID,PartType=@PartType,PartyName=@PartyName,PartyAddress=@PartyAddress,BLID=@BLID where BCID=@BCID and RRID=@RRID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BCID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyTypeID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PartID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PartType", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyName", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyAddress", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] ArrayCntr = Data.ItemsCntr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < ArrayCntr.Length; i++)
                    {
                        var CharSplit = ArrayCntr[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_LinerBOLCntrDetails where CntrID=@CntrID and RRID=@RRID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_LinerBOLCntrDetails(RRID,CntrNo,CntrID,Size,ISOCode,SealNo,NoOfPkg,PakgType,PakgTypeName,GrsWt,NtWt,VGM,CBM,BLID) " +
                                     " values (@RRID,@CntrNo,@CntrID,@Size,@ISOCode,@SealNo,@NoOfPkg,@PakgType,@PakgTypeName,@GrsWt,@NtWt,@VGM,@CBM,@BLID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LinerBOLCntrDetails SET RRID=@RRID,CntrNo=@CntrNo,CntrID=@CntrID,Size=@Size,ISOCode=@ISOCode,SealNo=@SealNo,NoOfPkg=@NoOfPkg,PakgType=@PakgType" +
                                     " ,PakgTypeName=@PakgTypeName,GrsWt=@GrsWt,NtWt=@NtWt,VGM=@VGM,CBM=@CBM,BLID=@BLID where CntrID=@CntrID and RRID=@RRID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BCNID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Size", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCode", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SealNo", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NoOfPkg", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PakgType", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PakgTypeName", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GrsWt", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NtWt", CharSplit[10]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VGM", CharSplit[11]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CBM", CharSplit[12]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    //string[] ArrayVs = Data.ItemsVS.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    //for (int i = 1; i < ArrayVs.Length; i++)
                    //{
                    //    var CharSplit = ArrayVs[i].ToString().TrimEnd(',').Split(',');
                    //    Cmd.CommandText = " IF((select count(*) from NVO_LinerBOLVoyageDetails where VID=@VID and BLID=@BLID and BkgID=@BkgID and LegInformation=@LegInformation)<=0) " +
                    //                 " BEGIN " +
                    //                 " INSERT INTO  NVO_LinerBOLVoyageDetails(VoyageTypes,LegInformation,VesVoyID,LoadPort,NextPort,ETA,ETD,BLID,BkgID) " +
                    //                 " values (@VoyageTypes,@LegInformation,@VesVoyID,@LoadPort,@NextPort,@ETA,@ETD,@BLID,@BkgID) " +
                    //                 " END  " +
                    //                 " ELSE " +
                    //                 " UPDATE NVO_LinerBOLVoyageDetails SET VoyageTypes=@VoyageTypes,LegInformation=@LegInformation,VesVoyID=@VesVoyID,LoadPort=@LoadPort," +
                    //                 " NextPort=@NextPort,ETA=@ETA,ETD=@ETD,BLID=@BLID,BkgID=@BkgID where VID=@VID and BLID=@BLID and BkgID=@BkgID and LegInformation=@LegInformation";
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", Data.BkgID));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@VID", CharSplit[0]));

                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageTypes", CharSplit[1]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@LegInformation", CharSplit[2]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoyID", CharSplit[3]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@LoadPort", CharSplit[4]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@NextPort", CharSplit[5]));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@ETA", DateTime.ParseExact(CharSplit[6], "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));
                    //    Cmd.Parameters.Add(_dbFactory.GetParameter("@ETD", DateTime.ParseExact(CharSplit[7], "dd/MM/yyyy", null).ToString("MM/dd/yyyy")));


                    //    result = Cmd.ExecuteNonQuery();
                    //    Cmd.Parameters.Clear();

                    //}

                    trans.Commit();
                    MyBOLList.Add(new MYLinerBOL { ID = Data.ID });
                    return MyBOLList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyBOLList;
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

        public List<MYLinerBOL> BOLExistingViewValus(MYLinerBOL Data)
        {
            List<MYLinerBOL> ViewList = new List<MYLinerBOL>();
            DataTable dt = GetBOLExistingSearchValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
       
            {
                ViewList.Add(new MYLinerBOL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    RRID = Int32.Parse(dt.Rows[i]["RRID"].ToString()),

                    BkgParty = dt.Rows[i]["BookingParty"].ToString(),
                    RRNo = dt.Rows[i]["RateSheetNo"].ToString(),


                    PortOfOrginID = Int32.Parse(dt.Rows[i]["PortOfOrgin"].ToString()),
                    PortOfLoadingID = Int32.Parse(dt.Rows[i]["PortOfLoading"].ToString()),
                    PlaceOfDisID = Int32.Parse(dt.Rows[i]["PlaceOfDischargeId"].ToString()),
                    FinalPODID = Int32.Parse(dt.Rows[i]["FinalPODId"].ToString()),


                    ShipmentType = dt.Rows[i]["ShipmentType"].ToString(),
                    ServiceType = dt.Rows[i]["ServiceType"].ToString(),
                    VesVoyageID = Int32.Parse(dt.Rows[i]["VesVoyID"].ToString()),
                    LinerID = Int32.Parse(dt.Rows[i]["LinerID"].ToString()),

                    SalesPerson = dt.Rows[i]["SalesPerson"].ToString(),

                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    DesAgentID = dt.Rows[i]["AgentId"].ToString(),
                    NoofOriginal = dt.Rows[i]["NoofOriginal"].ToString(),
                    SurrenderStatus = dt.Rows[i]["SurrenderStatus"].ToString(),
                    MarkNo = dt.Rows[i]["MarkNo"].ToString(),
                    CagoDescription = dt.Rows[i]["CagoDescription"].ToString(),
                    OtherRemarks = dt.Rows[i]["OtherRemarks"].ToString()



                });
            }
            return ViewList;
        }
        public DataTable GetBOLExistingSearchValus(MYLinerBOL Data)
        {
            //string _Query = "select NVO_LinerAgencyRatesheet.ID,NVO_LinerAgencyRatesheet.RatesheetNo,NVO_LinerAgencyRatesheet.BLNumber,NVO_LinerBOL.SurrenderStatus,NVO_LinerBOL.NoofOriginal, convert(varchar, Date, 23) as Date,BookingPartyID,SalesPersonID,PortOfOrgin,PortOfLoading,ExpHaulageID,AgentId, " +
            //                " PlaceofDischargeId,FinalPODId,ImpHaulageId,TranshimentPortID,convert(varchar, ValidTill, 23) as ValidTill,NVO_LinerAgencyRatesheet.Remarks,RouteType,ShipperID,ExportIHC,ImportIHC,IsRebate,RebateAmt,DocumentAttached,NVO_LinerAgencyRatesheet.LinerID,VesVoyID," +
            //                " (select GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_LinerAgencyRatesheet.ShipmentID)as ShipmentType," +
            //                " (select GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_LinerAgencyRatesheet.ServiceTypeID)as ServiceType," +
            //                " (select UserName from NVO_UserDetails where NVO_UserDetails.ID = NVO_LinerAgencyRatesheet.UserID)as SalesPerson,NVO_LinerBOL.MarkNo,NVO_LinerBOL.CagoDescription, " +
            //                " (select top(1) CustomerName from NVO_CustomerMaster where ID = BookingPartyID) as BookingParty,NVO_LinerBOL.VesVoy,(select top(1) Status from NVO_RRStatusMaster where ID = RSStatus) as Status,NVO_LinerAgencyRatesheet.OtherRemarks " +
            //                " from NVO_LinerAgencyRatesheet " +
            //                " Inner join NVO_LinerBOL On NVO_LinerBOL.ID= NVO_LinerAgencyRatesheet.ID " +
            //                " where NVO_LinerAgencyRatesheet.ID = " + Data.ID;

            string _Query = "select NVO_LinerAgencyRatesheet.ID as RRID,NVO_LinerAgencyRatesheet.RatesheetNo,NVO_LinerAgencyRatesheet.BLNumber,NVO_LinerAgencyRatesheet.VesVoy, " +
                             " convert(varchar, Date, 23) as Date,BookingPartyID,SalesPersonID,PortOfOrgin,PortOfLoading,ExpHaulageID,AgentId,  PlaceofDischargeId, " +
                             " FinalPODId,ImpHaulageId,TranshimentPortID,convert(varchar, ValidTill, 23) as ValidTill, " +
                             " NVO_LinerAgencyRatesheet.Remarks,RouteType,ShipperID,ExportIHC,ImportIHC,IsRebate,RebateAmt, " +
                             " DocumentAttached,NVO_LinerAgencyRatesheet.LinerID,VesVoyID, " +
                             " (select GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_LinerAgencyRatesheet.ShipmentID)as ShipmentType, " +
                             " (select GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_LinerAgencyRatesheet.ServiceTypeID)as ServiceType, " +
                             " (select UserName from NVO_UserDetails where NVO_UserDetails.ID = NVO_LinerAgencyRatesheet.UserID)as SalesPerson, " +
                             " (select top(1) CustomerName from NVO_CustomerMaster where ID = BookingPartyID) as BookingParty, " +
                             " (select top(1) Status from NVO_RRStatusMaster where ID = RSStatus) as Status, " +
                             " (select top(1) SurrenderStatus from NVO_LinerBOL where NVO_LinerBOL.RRID = NVO_LinerAgencyRatesheet.ID) as SurrenderStatus, " +
                             " (select top(1) NoofOriginal from NVO_LinerBOL where NVO_LinerBOL.RRID = NVO_LinerAgencyRatesheet.ID) as NoofOriginal, " +
                             " (select top(1) OtherRemarks from NVO_LinerBOL where NVO_LinerBOL.RRID = NVO_LinerAgencyRatesheet.ID) as OtherRemarks, " +
                             " (select top(1) MarkNo from NVO_LinerBOL where NVO_LinerBOL.RRID = NVO_LinerAgencyRatesheet.ID) as CagoDescription, " +
                             " (select top(1) CagoDescription from NVO_LinerBOL where NVO_LinerBOL.RRID = NVO_LinerAgencyRatesheet.ID) as MarkNo, " +
                             " isnull((select top(1) ID from NVO_LinerBOL where NVO_LinerBOL.RRID = NVO_LinerAgencyRatesheet.ID),0) as ID " +
                             " from NVO_LinerAgencyRatesheet " +
                             " where NVO_LinerAgencyRatesheet.ID = " + Data.ID;

            //string _Query = "select NVO_LinerBOL.ID,NVO_LinerBOL.BLNumber,NVO_LinerAgencyRatesheet.RatesheetNo, " +
            //                " NVO_LinerAgencyRatesheet.VesVoy, " +
            //                " convert(varchar, Date, 23) as Date,BookingPartyID,SalesPersonID,PortOfOrgin,PortOfLoading,ExpHaulageID,AgentId, " +
            //                " PlaceofDischargeId,  FinalPODId,ImpHaulageId,TranshimentPortID,convert(varchar, ValidTill, 23) as ValidTill, " +
            //                " NVO_LinerAgencyRatesheet.Remarks,RouteType,ShipperID,ExportIHC,ImportIHC,IsRebate,RebateAmt, " +
            //                " DocumentAttached,NVO_LinerAgencyRatesheet.LinerID,VesVoyID, " +
            //                " (select GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_LinerAgencyRatesheet.ShipmentID)as ShipmentType, " +
            //                " (select GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_LinerAgencyRatesheet.ServiceTypeID)as ServiceType, " +
            //                " (select UserName from NVO_UserDetails where NVO_UserDetails.ID = NVO_LinerAgencyRatesheet.UserID)as SalesPerson, " +
            //                " (select top(1) CustomerName from NVO_CustomerMaster where ID = BookingPartyID) as BookingParty, " +
            //                " (select top(1) Status from NVO_RRStatusMaster where ID = RSStatus) as Status, " +
            //                " NVO_LinerAgencyRatesheet.OtherRemarks " +
            //                " from NVO_LinerBOL " +
            //                " inner join NVO_LinerAgencyRatesheet On NVO_LinerAgencyRatesheet.ID = NVO_LinerBOL.ID " +
            //                " where NVO_LinerBOL.ID= " + Data.ID;

            return GetViewData(_Query, "");
        }

        public List<MYLinerBOL> BOLCustomerExistingValus(MYLinerBOL Data)
        {
            List<MYLinerBOL> ViewList = new List<MYLinerBOL>();
            DataTable dt = GetBOLCustomerExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerBOL
                {
                    RRID = Int32.Parse(dt.Rows[i]["RRID"].ToString()),
                    BCID = Int32.Parse(dt.Rows[i]["BCID"].ToString()),
                    PartyTypeID = Int32.Parse(dt.Rows[i]["PartyTypeID"].ToString()),
                    PartyID = Int32.Parse(dt.Rows[i]["PartID"].ToString()),
                    Address = dt.Rows[i]["PartyAddress"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetBOLCustomerExistingValus(MYLinerBOL Data)
        {
            string _Query = "select * from NVO_LinerBOLCustomerDetails where RRID= " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MYLinerBOL> BOLCntrExistingValus(MYLinerBOL Data)
        {
            List<MYLinerBOL> ViewList = new List<MYLinerBOL>();
            DataTable dt = GetBOLCntrExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerBOL
                {
                    BCNID = Int32.Parse(dt.Rows[i]["BCNID"].ToString()),
                    CntrID = dt.Rows[i]["CntrID"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString(),
                    SealNo = dt.Rows[i]["SealNo"].ToString(),
                    NoOfPkg = dt.Rows[i]["NoOfPkg"].ToString(),
                    PakgType = dt.Rows[i]["PakgType"].ToString(),
                    GrsWt = dt.Rows[i]["GrsWt"].ToString(),
                    NtWt = dt.Rows[i]["NtWt"].ToString(),
                    VGM = dt.Rows[i]["VGM"].ToString(),
                    CBM = dt.Rows[i]["CBM"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetBOLCntrExistingValus(MYLinerBOL Data)
        {
            string _Query = "select * from NVO_LinerBOLCntrDetails where RRID= " + Data.ID;
            //string _Query = " select 0 as BCNID,CntrID,CntrType,BLID,(select top(1) ISOCode  from NVO_tblCntrTypes where ID = CntrType) as ISOCode, " +
            //                " (select top(1) Size  from NVO_tblCntrTypes where ID = CntrType) as Size, " +
            //                " (select top(1) SealNo from NVO_LinerBOLCntrDetails where NVO_LinerBOLCntrDetails.BCNID = NVO_LinerBOLCntrPickup.BLID) as SealNo, " +
            //                " (select top(1) NoOfPkg from NVO_LinerBOLCntrDetails where NVO_LinerBOLCntrDetails.BCNID = NVO_LinerBOLCntrPickup.BLID) as NoOfPkg, " +
            //                " (select top(1) PakgType from NVO_LinerBOLCntrDetails where NVO_LinerBOLCntrDetails.BCNID = NVO_LinerBOLCntrPickup.BLID) as PakgType, " +
            //                " (select top(1) PakgTypeName from NVO_LinerBOLCntrDetails where NVO_LinerBOLCntrDetails.BCNID = NVO_LinerBOLCntrPickup.BLID) as PakgTypeName, " +
            //                " (select top(1) GrsWt from NVO_LinerBOLCntrDetails where NVO_LinerBOLCntrDetails.BCNID = NVO_LinerBOLCntrPickup.BLID) as GrsWt, " +
            //                " (select top(1) GrsWt from NVO_LinerBOLCntrDetails where NVO_LinerBOLCntrDetails.BCNID = NVO_LinerBOLCntrPickup.BLID) as NtWt, " +
            //                " (select top(1) GrsWt from NVO_LinerBOLCntrDetails where NVO_LinerBOLCntrDetails.BCNID = NVO_LinerBOLCntrPickup.BLID) as VGM, " +
            //                " (select top(1) GrsWt from NVO_LinerBOLCntrDetails where NVO_LinerBOLCntrDetails.BCNID = NVO_LinerBOLCntrPickup.BLID) as CBM " +
            //                " from NVO_LinerBOLCntrPickup where BLID = " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MYLinerBOL> BkgVoyagedtlsExistingValus(MYLinerBOL Data)
        {
            List<MYLinerBOL> ViewList = new List<MYLinerBOL>();
            DataTable dt = GetBkgVoyageDtlsValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerBOL
                {
                    // VID = dt.Rows[i]["VID"].ToString(),
                    VoyageTypes = dt.Rows[i]["GeneralLeg"].ToString(),
                    LegInformation = dt.Rows[i]["Leg"].ToString(),
                    VesVoyID = dt.Rows[i]["ID"].ToString(),
                    CurPortID = dt.Rows[i]["CurrentPortID"].ToString(),
                    NextPortID = dt.Rows[i]["NextPortID"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString()


                });
            }
            return ViewList;
        }

        public DataTable GetBkgVoyageDtlsValus(MYLinerBOL Data)
        {
            string _Query = " select NVO_VoyageDetails.ID,(select top(1) VesselName from NVO_VesselMaster where ID = NVO_VoyageDetails.VesID) + ' -' + VoyageNo as VesVoy,  " +
                            " CurrentPortID,(select top(1) NextPortID from NVO_VoyPortDtls where VoydtID = NVO_VoyageDetails.Id) as NextPortID, " +
                            " convert(varchar, ETA, 103) as ETA,convert(varchar, ETD, 103) as ETD,(select count(ID) from NVO_BkgTranshipmentPort where BkgID = NVO_Booking.ID) as CoutTrans,  " +
                            " case when(select count(ID) from NVO_BkgTranshipmentPort where BkgID = NVO_Booking.ID) > 0 then 78 else 77 end as GeneralLeg,74 as Leg " +
                            " from NVO_VoyageDetails " +
                            " inner join NVO_Booking on NVO_Booking.VesVoyID = NVO_VoyageDetails.ID " +
                            " where NVO_Booking.ID = " + Data.BkgID;
            return GetViewData(_Query, "");
        }

        public List<MYLinerBOL> BOLBkgSelectExistingValus(MYLinerBOL Data)
        {
            List<MYLinerBOL> ViewList = new List<MYLinerBOL>();
            DataTable dt = GetBOLBkgSelectExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerBOL
                {
                    BLNumber = dt.Rows[i]["BookingNo"].ToString(),
                    RRNo = dt.Rows[i]["RRNo"].ToString(),
                    BkgParty = dt.Rows[i]["BkgParty"].ToString(),
                    POO = dt.Rows[i]["POO"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),

                    POOID = dt.Rows[i]["POOID"].ToString(),
                    POLID = dt.Rows[i]["POLID"].ToString(),
                    PODID = dt.Rows[i]["PODID"].ToString(),
                    FPODID = dt.Rows[i]["FPODID"].ToString(),

                    ShipmentType = dt.Rows[i]["ShipmentType"].ToString(),
                    ServiceType = dt.Rows[i]["ServiceType"].ToString(),
                    SalesPerson = dt.Rows[i]["SalesPerson"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    CntrCount = dt.Rows[i]["CntrCount"].ToString(),
                    DesAgentID = dt.Rows[i]["DestinationAgentID"].ToString(),
                    Shipper = dt.Rows[i]["ShipperID"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetBOLBkgSelectExistingValus(MYLinerBOL Data)
        {
            string _Query = " select BookingNo,RRNo,BkgParty,POO,POL,POD,FPOD,POOID,POLID,PODID,FPODID,ShipmentType,ServiceType,SalesPerson,VesVoy,'20' + ' x ' +  convert(varchar,CTQ20) + ',' + '40' + ' x ' + convert(varchar,CTQ40) as CntrCount," +
                            " DestinationAgentID, ShipperID, Shipper,(select top(1) Address from NVO_CusBranchLocation where CustomerID= ShipperID) as Address,  (select top(1) ExpFreeDays from NVO_RatesheetMode where RRId = RRID) as FreeDays from NVO_Booking where ID=" + Data.BkgID;
            return GetViewData(_Query, "");
        }

        public List<MYLinerBOL> BkgBOLVesselVoyageValus(MYLinerBOL Data)
        {
            List<MYLinerBOL> ViewList = new List<MYLinerBOL>();
            DataTable dt = GetBkgVesselVoyageValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerBOL
                {
                    VesVoyID = dt.Rows[i]["ID"].ToString(),
                    CurPortID = dt.Rows[i]["CurrentPortID"].ToString(),
                    NextPortID = dt.Rows[i]["NextPortID"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    ETD = dt.Rows[i]["ETD"].ToString()

                });
            }
            return ViewList;
        }
        public DataTable GetBkgVesselVoyageValus(MYLinerBOL Data)
        {
            string _Query = " select NVO_VoyageDetails.ID,(select top(1) VesselName from NVO_VesselMaster where ID = NVO_VoyageDetails.VesID) + ' -' + VoyageNo as VesVoy, " +
                            " CurrentPortID,(select top(1) NextPortID from NVO_VoyPortDtls where VoydtID = NVO_VoyageDetails.Id) as NextPortID, " +
                            " convert(varchar, ETA, 103) as ETA,convert(varchar, ETD, 103) as ETD " +
                            " from NVO_VoyageDetails " +
                            " inner join NVO_Booking on NVO_Booking.VesVoyID = NVO_VoyageDetails.Id where NVO_Booking.Id = " + Data.BkgID;
            return GetViewData(_Query, "");
        }

        public List<MYLinerRRBooking> BookingRRSearchBindValus(MYLinerRRBooking Data)
        {
            List<MYLinerRRBooking> ViewList = new List<MYLinerRRBooking>();
            DataTable dt = GetBookingRRSearchBindValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerRRBooking
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RatesheetNo = dt.Rows[i]["RatesheetNo"].ToString(),
                    POO = dt.Rows[i]["POO"].ToString(),
                    Date = dt.Rows[i]["Date"].ToString(),
                    POL = dt.Rows[i]["POLCode"].ToString(),
                    POD = dt.Rows[i]["PODCode"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    BookingParty = dt.Rows[i]["BookingParty"].ToString(),
                    ShipmentTypes = dt.Rows[i]["ShipmentTypes"].ToString(),
                    serviceTypes = dt.Rows[i]["serviceTypes"].ToString(),
                    ValidTill = dt.Rows[i]["ValidTillv"].ToString(),
                    BaseAmt = dt.Rows[i]["Base"].ToString(),
                    Rate = dt.Rows[i]["Rate"].ToString(),
                    SlotOperator = dt.Rows[i]["SlotOperator"].ToString(),
                    SlotCntr20Rate = dt.Rows[i]["SlotCntr20Rate"].ToString(),
                    SlotCntr4Rate = dt.Rows[i]["SlotCntr4Rate"].ToString(),
                    SlotTerm = dt.Rows[i]["SlotTerm"].ToString(),
                    Oceanfr20 = dt.Rows[i]["Oceanfr20"].ToString(),
                    Oceanfr40 = dt.Rows[i]["Oceanfr40"].ToString(),
                    Cntr20 = dt.Rows[i]["Cntr20"].ToString(),
                    Cntr40 = dt.Rows[i]["Cntr40"].ToString(),
                    Commodity = dt.Rows[i]["Commodity"].ToString(),
                    Commodity40 = dt.Rows[i]["Commodity40"].ToString(),

                    FRT20 = dt.Rows[i]["FRT20"].ToString(),
                    FRT40 = dt.Rows[i]["FRT40"].ToString(),

                    BAF20 = dt.Rows[i]["BAF20"].ToString(),
                    BAF40 = dt.Rows[i]["BAF40"].ToString(),

                    ECRS20 = dt.Rows[i]["ECRS20"].ToString(),
                    ECRS40 = dt.Rows[i]["ECRS40"].ToString(),

                    LSS20 = dt.Rows[i]["LSS20"].ToString(),
                    LSS40 = dt.Rows[i]["LSS40"].ToString(),





                });
            }
            return ViewList;
        }
        public DataTable GetBookingRRSearchBindValus(MYLinerRRBooking Data)
        {
            string strWhere = "";
            string _Query = "select * from v_NVO_BookingRatesheetView";

            if (Data.RatesheetNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where Id= " + Data.RatesheetNo;
                else
                    strWhere += " and Id= " + Data.RatesheetNo;

            if (Data.POD != "")
                if (strWhere == "")
                    strWhere += _Query + " where PlaceofDischargeId= " + Data.POD;
                else
                    strWhere += " and PlaceofDischargeId= " + Data.POD;

            if (Data.POL != "")
                if (strWhere == "")
                    strWhere += _Query + " where PortofLoading= " + Data.POL;
                else
                    strWhere += " and PortofLoading= " + Data.POL;


            if (Data.BookingParty != "")
                if (strWhere == "")
                    strWhere += _Query + " where BookingPartyID= " + Data.BookingParty;
                else
                    strWhere += " and BookingPartyID= " + Data.BookingParty;



            return GetViewData(_Query, "");
        }

        public List<MYLinerBOL> BOLRRUpDate(MYLinerBOL Data)
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
                    Cmd.CommandText = "select RatesheetNo from NVO_Ratesheet  where ID = " + Data.RRID;
                    Data.RRNo = Cmd.ExecuteScalar().ToString();

                    Cmd.CommandText = "update NVO_Booking set RRID=@RRID,RRNo=@RRNo where Id=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RRNo", Data.RRNo));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    trans.Commit();
                    MyBOLList.Add(new MYLinerBOL { RRNo = Data.RRNo });
                    return MyBOLList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyBOLList;
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


        public List<MYLinerBOL> BOLStatusUpDate(MYLinerBOL Data)
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

                    Cmd.CommandText = "update NVO_LinerBOL set Status=@Status where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    trans.Commit();
                    MyBOLList.Add(new MYLinerBOL { RRNo = Data.RRNo });
                    return MyBOLList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyBOLList;
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
        #region GANESH ( LINER BL NUMBERING)
        public List<MYLinerBLNoLogics> BLNoLogicsValues(MYLinerBLNoLogics Data)
        {
            List<MYLinerBLNoLogics> ViewList = new List<MYLinerBLNoLogics>();
            DataTable dt = GetBLNoLogicsValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerBLNoLogics
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNoLogic = dt.Rows[i]["GeneralName"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetBLNoLogicsValues(MYLinerBLNoLogics Data)
        {

            string _Query = "Select * from  NVO_GeneralMaster Where SeqNo=42";


            return GetViewData(_Query, "");
        }


        public List<MYLinerBLNoLogics> BLNoLogicsInsert(MYLinerBLNoLogics Data)
        {

            List<MYLinerBLNoLogics> ViewList = new List<MYLinerBLNoLogics>();
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

                    Cmd.CommandText = " IF((select count(*) from NVO_LinerBLNoLogics where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_LinerBLNoLogics(BLNoLogicsID,AgentCode,LinerCode,LinerID,Status) " +
                                     " values (@BLNoLogicsID,@AgentCode,@LinerCode,@LinerID,@Status) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LinerBLNoLogics SET BLNoLogicsID=@BLNoLogicsID,AgentCode=@AgentCode,LinerCode=@LinerCode,LinerID=@LinerID,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNoLogicsID", Data.BLNoLogicID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentCode", Data.AgentCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LinerCode", Data.LinerCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LinerID", Data.LinerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_LinerBLNoLogics')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    return ViewList;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ViewList;
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

        public List<MYLinerBLNoLogics> BLLogicsViewRecordValues(MYLinerBLNoLogics Data)
        {
            List<MYLinerBLNoLogics> ViewList = new List<MYLinerBLNoLogics>();
            DataTable dt = GetBLLogicsViewRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerBLNoLogics
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LinerName = dt.Rows[i]["LinerName"].ToString(),
                    LinerCode = dt.Rows[i]["LinerCode"].ToString(),
                    BLNoLogic = dt.Rows[i]["BLNoLogic"].ToString(),
                    AgentCode = dt.Rows[i]["AgentCode"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetBLLogicsViewRecord(MYLinerBLNoLogics Data)
        {
            string strWhere = "";
            string _Query = "Select ID,AgentCode,LinerCode, (select top(1) GeneralName   from NVO_GeneralMaster where ID = LBL.BLNoLogicsID AND SeqNo = 42) AS BLNoLogic,(select top(1) CustomerName   from NVO_CustomerMaster inner join NVO_CusBusinessTypes on NVO_CusBusinessTypes.CustomerID = NVO_CustomerMaster.ID and BussTypes in (7) where NVO_CustomerMaster.ID = LBL.LinerID) AS LinerName," +
                " case when LBL.status = 1 then 'Active' when LBL.status = 0 then 'Inactive' ELSE '' END as StatusResult from NVO_LinerBLNoLogics LBL ";

            if (Data.LinerID.ToString() != "" && Data.LinerID.ToString() != "0" && Data.LinerID.ToString() != null && Data.LinerID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where LinerID = " + Data.LinerID.ToString();
                else
                    strWhere += " and LinerID = " + Data.LinerID.ToString();

            if (Data.Status.ToString() == "1")
                if (strWhere == "")
                    strWhere += _Query + " where Status =" + Data.Status.ToString();

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }

        public List<MYLinerBLNoLogics> BLNoLogicsEditValues(MYLinerBLNoLogics Data)
        {
            List<MYLinerBLNoLogics> ViewList = new List<MYLinerBLNoLogics>();
            DataTable dt = GetBLNoLogicsEditRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int St = 0;
                if (dt.Rows[i]["Status"].ToString() != "")
                {
                    St = Int32.Parse(dt.Rows[i]["Status"].ToString());
                }
                else
                {
                    St = 0;
                }
                ViewList.Add(new MYLinerBLNoLogics
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    LinerID = Int32.Parse(dt.Rows[i]["LinerID"].ToString()),
                    BLNoLogicID = Int32.Parse(dt.Rows[i]["BLNoLogicsID"].ToString()),
                    LinerCode = dt.Rows[i]["LinerCode"].ToString(),
                    AgentCode = dt.Rows[i]["AgentCode"].ToString(),
                    Status = St

                });
            }
            return ViewList;
        }

        public DataTable GetBLNoLogicsEditRecord(MYLinerBLNoLogics Data)
        {

            string _Query = "Select * from NVO_LinerBLNoLogics where ID=" + Data.ID;



            return GetViewData(_Query, "");
        }


        public List<MYLinerBLRelease> BLReleaseExisCheckValus(MYLinerBLRelease Data)
        {
            List<MYLinerBLRelease> ViewList = new List<MYLinerBLRelease>();
            DataTable dt = GetBLReleaseExistingCheckValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerBLRelease
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString())

                });
            }
            return ViewList;
        }

        public DataTable GetBLReleaseExistingCheckValus(MYLinerBLRelease Data)
        {
            string _Query = " SELECT ID FROM NVO_LinerBLRelease  where ID = " + Data.ID;

            return GetViewData(_Query, "");
        }

        public List<MYLinerBLRelease> BLReleaseExistingViewValus(MYLinerBLRelease Data)
        {
            List<MYLinerBLRelease> ViewList = new List<MYLinerBLRelease>();
            DataTable dt = GetBLReleaseExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MYLinerBLRelease
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    POO = dt.Rows[i]["POO"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    POD = dt.Rows[i]["POD"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),
                    Shipper = dt.Rows[i]["Shipper"].ToString(),
                    ShipperAddress = dt.Rows[i]["ShipperAddress"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    ConsigneeAddress = dt.Rows[i]["ConsigneeAddress"].ToString(),
                    Notify1 = dt.Rows[i]["Notify1"].ToString(),
                    Notify1Address = dt.Rows[i]["Notify1Address"].ToString(),
                    Notify2 = dt.Rows[i]["Notify2"].ToString(),
                    Notify2Address = dt.Rows[i]["Notify2Address"].ToString(),
                    Agent = dt.Rows[i]["DesignationAgent"].ToString(),
                    AgentAddress = dt.Rows[i]["DesignationAgentAddress"].ToString(),
                    GrsWt = dt.Rows[i]["GRWT"].ToString(),
                    NtWt = dt.Rows[i]["NTWT"].ToString(),
                    CBM = dt.Rows[i]["CBM"].ToString(),
                    Packages = dt.Rows[i]["PakgType"].ToString(),
                    Marks = dt.Rows[i]["MarkNo"].ToString(),
                    Description = dt.Rows[i]["CagoDescription"].ToString(),
                    FreightPayment = dt.Rows[i]["PaymentMode"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),                   
                    FreeDays = dt.Rows[i]["ImpFreedays"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    SOBDate = dt.Rows[i]["SOBDate"].ToString(),
                    BLDate = dt.Rows[i]["BLDate"].ToString(),
                    IssuedAt = dt.Rows[i]["IssuedAt"].ToString()
                   
                });
            }
            return ViewList;
        }



        public DataTable GetBLReleaseExistingValus(MYLinerBLRelease Data)
        {
            //string _Query = " select NVO_LinerBOL.ID,NVO_LinerBOL.BLNumber,MarkNo,CagoDescription, " +
            //                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerBOL.POOID) as POO, " +
            //                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerBOL.POLID)as POL, " +
            //                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerBOL.PODID)as POD, " +
            //                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerBOL.FPODID)as FPOD, " +
            //                " (select sum(Grswt) from NVO_LinerBOLCntrDetails Cd where Cd.BLID = NVO_LinerBOL.Id AND Cd.BCNID = NVO_LinerBOL.ID) as GRWT, " +
            //                " (select sum(NtWt) from NVO_LinerBOLCntrDetails Cd where Cd.BLID = NVO_LinerBOL.Id  AND Cd.BCNID = NVO_LinerBOL.ID) as NTWT, " +
            //                " (select sum(CBM) from NVO_LinerBOLCntrDetails Cd where Cd.BLID = NVO_LinerBOL.Id  AND Cd.BCNID = NVO_LinerBOL.ID) as CBM, " +
            //                " (select sum(PakgType) from NVO_LinerBOLCntrDetails Cd where CD.BLID = NVO_LinerBOL.Id  AND Cd.BCNID = NVO_LinerBOL.ID) as PakgType, " +
            //                " (select(select top(1) CustomerName from NVO_CustomerMaster where Id = PartID) from NVO_LinerBOLCustomerDetails where PartyTypeID = 1 and BLId = NVO_LinerBOL.Id) as Shipper, " +
            //                " (select top(1) PartyAddress from NVO_LinerBOLCustomerDetails BC where PartyTypeID = 1 and BC.BLID = NVO_LinerBOL.Id  AND BC.BLID = NVO_LinerBOL.ID) as ShipperAddress, " +
            //                " (select(select top(1) CustomerName from NVO_CustomerMaster where Id = PartID) from NVO_LinerBOLCustomerDetails where PartyTypeID = 2 and BLId = NVO_LinerBOL.Id) as Consignee, " +
            //                " (select top(1) PartyAddress from NVO_LinerBOLCustomerDetails BC where PartyTypeID = 2 and BC.BLID = NVO_LinerBOL.Id  AND BC.BLID = NVO_LinerBOL.ID) as ConsigneeAddress, " +
            //                " (select(select top(1) CustomerName from NVO_CustomerMaster where Id = PartID) from NVO_LinerBOLCustomerDetails where PartyTypeID = 3 and BLId = NVO_LinerBOL.Id) as Notify1, " +
            //                " (select top(1) PartyAddress from NVO_LinerBOLCustomerDetails BC where PartyTypeID = 3 and BC.BLID = NVO_LinerBOL.Id  AND BC.BLID = NVO_LinerBOL.ID) as Notify1Address, " +
            //                " (select(select top(1) CustomerName from NVO_CustomerMaster where Id = PartID) from NVO_LinerBOLCustomerDetails where PartyTypeID = 12 and BLId = NVO_LinerBOL.Id) as Notify2, " +
            //                " (select top(1) PartyAddress from NVO_LinerBOLCustomerDetails BC where PartyTypeID = 12 and BC.BLID = NVO_LinerBOL.Id  AND BC.BLID = NVO_LinerBOL.ID) as Notify2Address, " +
            //                " (select top(1) AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.Id = DesAgentID) as DesignationAgent, " +
            //                " (select top(1) Address from NVO_AgencyMaster where NVO_AgencyMaster.Id = DesAgentID) as DesignationAgentAddress, " +
            //                " NVO_LinerBOL.VesVoy, " +
            //                " (select GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_LinerAgencyRatesheetCharges.PaymentModeID)as PaymentMode,ImpFreedays,FORMAT(SOBDate, 'yyyy-MM-ddTHH:mm:ss') as SOBDate,IssuedAt,convert(varchar, BLDate, 23) as BLDate " +
            //                " from NVO_LinerBOL" +
            //                " inner join NVO_LinerAgencyRatesheetCharges ON NVO_LinerAgencyRatesheetCharges.CID = NVO_LinerBOL.ID " +
            //                " inner join NVO_LinerAgencyRateSheetMode ON NVO_LinerAgencyRatesheetMode.ID = NVO_LinerBOL.ID " +
            //                " inner join NVO_LinerBLRelease On NVO_LinerBLRelease.BLID = NVO_LinerBOL.ID " +
            //                " where NVO_LinerBOL.ID=" + Data.ID;
            string _Query = " select NVO_LinerBOL.ID,NVO_LinerBOL.BLNumber,MarkNo,CagoDescription, " +
                            " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerBOL.POOID) as POO, " +
                            " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerBOL.POLID)as POL, " +
                            " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerBOL.PODID)as POD, " +
                            " (select PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_LinerBOL.FPODID)as FPOD, " +
                            " (select sum(Grswt) from NVO_LinerBOLCntrDetails Cd where Cd.BLID = NVO_LinerBOL.Id AND Cd.BCNID = NVO_LinerBOL.ID) as GRWT, " +
                            " (select sum(NtWt) from NVO_LinerBOLCntrDetails Cd where Cd.BLID = NVO_LinerBOL.Id  AND Cd.BCNID = NVO_LinerBOL.ID) as NTWT, " +
                            " (select sum(CBM) from NVO_LinerBOLCntrDetails Cd where Cd.BLID = NVO_LinerBOL.Id  AND Cd.BCNID = NVO_LinerBOL.ID) as CBM, " +
                            " (select sum(PakgType) from NVO_LinerBOLCntrDetails Cd where CD.BLID = NVO_LinerBOL.Id  AND Cd.BCNID = NVO_LinerBOL.ID) as PakgType, " +
                            " (select(select top(1) CustomerName from NVO_CustomerMaster where Id = PartID) from NVO_LinerBOLCustomerDetails where PartyTypeID = 1 and BLId = NVO_LinerBOL.Id) as Shipper, " +
                            " (select top(1) PartyAddress from NVO_LinerBOLCustomerDetails BC where PartyTypeID = 1 and BC.BLID = NVO_LinerBOL.Id  AND BC.BLID = NVO_LinerBOL.ID) as ShipperAddress, " +
                            " (select(select top(1) CustomerName from NVO_CustomerMaster where Id = PartID) from NVO_LinerBOLCustomerDetails where PartyTypeID = 2 and BLId = NVO_LinerBOL.Id) as Consignee, " +
                            " (select top(1) PartyAddress from NVO_LinerBOLCustomerDetails BC where PartyTypeID = 2 and BC.BLID = NVO_LinerBOL.Id  AND BC.BLID = NVO_LinerBOL.ID) as ConsigneeAddress, " +
                            " (select(select top(1) CustomerName from NVO_CustomerMaster where Id = PartID) from NVO_LinerBOLCustomerDetails where PartyTypeID = 3 and BLId = NVO_LinerBOL.Id) as Notify1, " +
                            " (select top(1) PartyAddress from NVO_LinerBOLCustomerDetails BC where PartyTypeID = 3 and BC.BLID = NVO_LinerBOL.Id  AND BC.BLID = NVO_LinerBOL.ID) as Notify1Address, " +
                            " (select(select top(1) CustomerName from NVO_CustomerMaster where Id = PartID) from NVO_LinerBOLCustomerDetails where PartyTypeID = 12 and BLId = NVO_LinerBOL.Id) as Notify2, " +
                            " (select top(1) PartyAddress from NVO_LinerBOLCustomerDetails BC where PartyTypeID = 12 and BC.BLID = NVO_LinerBOL.Id  AND BC.BLID = NVO_LinerBOL.ID) as Notify2Address, " +
                            " (select top(1) AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.Id = DesAgentID) as DesignationAgent, " +
                            " (select top(1) Address from NVO_AgencyMaster where NVO_AgencyMaster.Id = DesAgentID) as DesignationAgentAddress, " +
                            " NVO_LinerBOL.VesVoy,(select convert(varchar, BLDate, 23) from NVO_LinerBLRelease)as BLDate,(select FORMAT(SOBDate, 'yyyy-MM-ddTHH:mm:ss') from NVO_LinerBLRelease)as SOBDate, " +
                            " (select GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = NVO_LinerAgencyRatesheetCharges.PaymentModeID)as PaymentMode,ImpFreedays,(select IssuedAt from NVO_LinerBLRelease)as IssuedAt " +
                            " from NVO_LinerBOL" +
                            " inner join NVO_LinerAgencyRatesheetCharges ON NVO_LinerAgencyRatesheetCharges.CID = NVO_LinerBOL.ID " +
                            " inner join NVO_LinerAgencyRateSheetMode ON NVO_LinerAgencyRatesheetMode.ID = NVO_LinerBOL.ID " +                            
                            " where NVO_LinerBOL.RRID=" + Data.BLID;

            return GetViewData(_Query, "");
        }


        public List<MYLinerBLRelease> BLReleaseCntrExistingViewValus(MYLinerBLRelease Data)
        {
            var CntrDetailsv = "";
            List<MYLinerBLRelease> ViewList = new List<MYLinerBLRelease>();
            DataTable dt = GetBLReleaseCntrExistingValus(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CntrDetailsv = dt.Rows[i]["CntrNo"].ToString() + "/" + dt.Rows[i]["Size"].ToString() + "/" + dt.Rows[i]["SealNo"].ToString() + "/" + dt.Rows[i]["NoOfPkg"].ToString() +
                   "/" + dt.Rows[i]["PackageType"].ToString() + "/" + dt.Rows[i]["GrsWt"].ToString() + "/" + dt.Rows[i]["NtWt"].ToString() + "/" + dt.Rows[i]["CBM"].ToString() + "\n";


            }
            ViewList.Add(new MYLinerBLRelease
            {
                CntrDetails = CntrDetailsv
            });
            return ViewList;
        }


        public DataTable GetBLReleaseCntrExistingValus(MYLinerBLRelease Data)
        {
            string _Query = " Select(select top(1) CntrNo from NVO_Containers where ID = CntrID) as CntrNo,Size,SealNo,NoOfPkg, " +
                            " (select top(1) PkgCode from NVO_CargoPkgMaster where Id = PakgType) as PackageType,GrsWt,NtWt,CBM from NVO_LinerBOLCntrDetails " +
                            " where BLID=" + Data.ID;

            return GetViewData(_Query, "");
        }



        //public List<MYLinerBLRelease> BLReleaseFinalExistingViewValus(MYLinerBLRelease Data)
        //{
        //    List<MYLinerBLRelease> ViewList = new List<MYLinerBLRelease>();
        //    DataTable dt = GetBLReleaseFinalExistingValus(Data);
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        ViewList.Add(new MYLinerBLRelease
        //        {
        //            BkgID = Int32.Parse(dt.Rows[i]["BkgID"].ToString()),
        //            POO = dt.Rows[i]["POO"].ToString(),
        //            POL = dt.Rows[i]["POL"].ToString(),
        //            POD = dt.Rows[i]["POD"].ToString(),
        //            FPOD = dt.Rows[i]["FPOD"].ToString(),
        //            Shipper = dt.Rows[i]["Shipper"].ToString(),
        //            ShipperAddress = dt.Rows[i]["ShipperAddress"].ToString(),
        //            Consignee = dt.Rows[i]["Consignee"].ToString(),
        //            ConsigneeAddress = dt.Rows[i]["ConsigneeAddress"].ToString(),
        //            Notify1 = dt.Rows[i]["Notify1"].ToString(),
        //            Notify1Address = dt.Rows[i]["Notify1Address"].ToString(),
        //            Notify2 = dt.Rows[i]["Notify2"].ToString(),
        //            Notify2Address = dt.Rows[i]["Notify2Address"].ToString(),
        //            Agent = dt.Rows[i]["Agent"].ToString(),
        //            AgentAddress = dt.Rows[i]["AgentAddress"].ToString(),
        //            GrsWt = dt.Rows[i]["GRWT"].ToString(),
        //            NtWt = dt.Rows[i]["NTWT"].ToString(),
        //            CBM = dt.Rows[i]["CBM"].ToString(),
        //            Packages = dt.Rows[i]["Packages"].ToString(),
        //            Marks = dt.Rows[i]["Marks"].ToString(),
        //            Description = dt.Rows[i]["Description"].ToString(),
        //            FreightPayment = dt.Rows[i]["FreightPayment"].ToString(),
        //            VesVoy = dt.Rows[i]["VesVoy"].ToString(),
        //            FreeDays = dt.Rows[i]["FreeDays"].ToString(),
        //            BLNumber = dt.Rows[i]["BLNo"].ToString(),
        //            BLDate = dt.Rows[i]["BLDate"].ToString(),
        //            SOBDate = dt.Rows[i]["SOBDate"].ToString(),
        //            CntrDetails = dt.Rows[i]["CntrDetails"].ToString(),
        //            IssuedAt = dt.Rows[i]["IssuedAt"].ToString(),




        //        });
        //    }
        //    return ViewList;
        //}

        public DataTable GetBLReleaseFinalExistingValus(MYLinerBLRelease Data)
        {
            string _Query = " SELECT ID,BLNo,VesVoy,convert(varchar, BLDate, 23) as BLDate,Shipper,ShipperAddress,Consignee,ConsigneeAddress,Notify1,Notify1Address,Notify2,Notify2Address,Agent,AgentAddress,POO,POL,POD,FPOD, " +
                            " GRWT,NTWT,CBM,Packages,Description,Marks,CntrDetails,FreightPayment,FreeDays, FORMAT(SOBDate, 'yyyy-MM-ddTHH:mm:ss') as SOBDate,IssuedAt,BLLayout,CurrentDate,BLStatus " +
                            " FROM NVO_LinerBLRelease where BLID = " + Data.ID;

            return GetViewData(_Query, "");
        }
        public List<MYLinerBLRelease> BLReleaseInsert(MYLinerBLRelease Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_LinerBLRelease where BLID=@BLID)<=0) " +
                                 " BEGIN " +
                                 " INSERT INTO  NVO_LinerBLRelease(BLNo,VesVoy,BLDate,Shipper,ShipperAddress,Consignee,ConsigneeAddress,Notify1,Notify1Address,Notify2,Notify2Address,Agent,AgentAddress,POO,POL,POD,FPOD,GRWT,NTWT,CBM," +
                                 " Packages,Description,Marks,CntrDetails,FreightPayment,FreeDays,SOBDate,IssuedAt,BLLayout,CurrentDate,BLStatus,BkgId,BLID,GeoLocID) " +
                                 " values (@BLNo,@VesVoy,@BLDate,@Shipper,@ShipperAddress,@Consignee,@ConsigneeAddress,@Notify1,@Notify1Address,@Notify2,@Notify2Address,@Agent,@AgentAddress,@POO,@POL,@POD,@FPOD,@GRWT,@NTWT,@CBM," +
                                 " @Packages,@Description,@Marks,@CntrDetails,@FreightPayment,@FreeDays,@SOBDate,@IssuedAt,@BLLayout,@CurrentDate,@BLStatus,@BkgId,@BLID,@GeoLocID) " +
                                 " END  " +
                                 " ELSE " +
                                 " UPDATE NVO_LinerBLRelease SET BLNo=@BLNo,VesVoy=@VesVoy,BLDate=@BLDate,Shipper=@Shipper,ShipperAddress=@ShipperAddress,Consignee=@Consignee,ConsigneeAddress=@ConsigneeAddress,Notify1=@Notify1,Notify1Address=@Notify1Address," +
                                 " Notify2=@Notify2,Notify2Address=@Notify2Address,Agent=@Agent,AgentAddress=@AgentAddress,POO=@POO,POL=@POL,POD=@POD,FPOD=@FPOD,GRWT=@GRWT,NTWT=@NTWT,CBM=@CBM," +
                                 " Packages=@Packages,Description=@Description,Marks=@Marks,CntrDetails=@CntrDetails,FreightPayment=@FreightPayment,FreeDays=@FreeDays,SOBDate=@SOBDate,IssuedAt=@IssuedAt,BLLayout=@BLLayout,CurrentDate=@CurrentDate," +
                                 " BLStatus=@BLStatus,BkgId=@BkgId,BLID=@BLID,GeoLocID=@GeoLocID where BLID=@BLID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNo", Data.BLNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoy", Data.VesVoy));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLDate", Data.BLDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Shipper", Data.Shipper));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperAddress", Data.ShipperAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Consignee", Data.Consignee));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeAddress", Data.ConsigneeAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify1", Data.Notify1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify1Address", Data.Notify1Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify2", Data.Notify2));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify2Address", Data.Notify2Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Agent", Data.Agent));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentAddress", Data.AgentAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POO", Data.POO));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POL", Data.POL));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POD", Data.POD));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FPOD", Data.FPOD));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GRWT", Data.GrsWt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NTWT", Data.NtWt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CBM", Data.CBM));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Packages", Data.Packages));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Description", Data.Description));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Marks", Data.Marks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrDetails", Data.CntrDetails));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreightPayment", Data.FreightPayment));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDays", Data.FreeDays));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SOBDate", DateTime.Parse(Data.SOBDate).ToString("yyyy-MM-dd h:mm tt")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IssuedAt", Data.IssuedAt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLLayout", Data.BLLayout));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now.ToString("MM/dd/yyyy")));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLStatus", Data.BLStatus));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgId", Data.BkgID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.RRID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocID", Data.GeoLocID));

                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_LinerBLRelease')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;



                    trans.Commit();
                    MyBLRList.Add(new MYLinerBLRelease { ID = Data.ID });
                    return MyBLRList;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return MyBLRList;
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

        public List<MyLinerCntrPickupdtls> ExtPickcntrBooking(MyLinerCntrPickupdtls Data)
        {
            List<MyLinerCntrPickupdtls> ViewList = new List<MyLinerCntrPickupdtls>();
            DataTable dt = GetExtPickCntrBookingdtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLinerCntrPickupdtls
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Size = dt.Rows[i]["Size"].ToString(),
                    MSDate = dt.Rows[i]["MSDate"].ToString(),
                    ERDate = dt.Rows[i]["ERDate"].ToString(),
                    EODate = dt.Rows[i]["EODate"].ToString(),
                    GIDate = dt.Rows[i]["GIDate"].ToString(),
                    VDDate = dt.Rows[i]["VDDate"].ToString(),
                    TADate = dt.Rows[i]["TADate"].ToString(),
                    TDDate = dt.Rows[i]["TDDate"].ToString(),
                    VADate = dt.Rows[i]["VADate"].ToString(),
                    GODate = dt.Rows[i]["GODate"].ToString(),
                    IRDate = dt.Rows[i]["IRDate"].ToString(),
                    IODate = dt.Rows[i]["IODate"].ToString(),
                    LIDate = dt.Rows[i]["LIDate"].ToString(),
                    LODate = dt.Rows[i]["LODate"].ToString(),
                    MRDate = dt.Rows[i]["MRDate"].ToString(),
                    CurrentDepotID = dt.Rows[i]["CurrentDepotID"].ToString(),
                    LocationID = dt.Rows[i]["LocationID"].ToString(),
                    IsTrue = "0"

                });
            }
            return ViewList;
        }

        public DataTable GetExtPickCntrBookingdtls(MyLinerCntrPickupdtls Data)
        {
            string _Query = " select ID, CntrID,CntrNo,(select top(1) size from NVO_tblCntrTypes where Id = CntrType) as Size,CurrentDepotID,LocationID, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'MS' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as MSDate, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'ER' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as ERDate, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'ED' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as EODate, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'GI' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as GIDate, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'VD' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as VDDate, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'TA' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as TADate, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'TD' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as TDDate, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'VA' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as VADate, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'GO' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as GODate, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'IR' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as IRDate, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'IO' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as IODate, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'LI' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as LIDate, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'LO' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as LODate, " +
                            "(select top(1) convert(varchar, DtMovement, 100) from NVO_ContainerTxns where StatusCode = 'MR' and NVO_LinerBOLCntrPickup.CntrID = NVO_ContainerTxns.ContainerID order by DtMovement desc) as MRDate " +
                            "from NVO_LinerBOLCntrPickup where ID=" + Data.ID;
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
    }
}
