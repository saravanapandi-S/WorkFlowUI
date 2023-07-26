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
    public class AllFileUploading
    {
        #region Constructor Method
        public AllFileUploading()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion


        public DataTable InsertMRGExcelUploading(DataTable dt)
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
                string varv = "";
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ID"].ToString() != "")
                        {

                            if (dt.Rows[i]["ID"].ToString() == "0")
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_MRGRate where ID=@ID)<=0) " +
                                            " BEGIN " +
                                            " INSERT INTO  NVO_MRGRate(MRGRate,FDate,TDate,PofOrigin,PofLoading,PofDischarge,PofFinalPOD,CntrTypes,Commodity,ServiceTypes,Currency,Amount,Remarks,CurrentDate,UserID,AgentId,SessionFinYear,AgentCode) " +
                                            " values (@MRGRate,@FDate,@TDate,@PofOrigin,@PofLoading,@PofDischarge,@PofFinalPOD,@CntrTypes,@Commodity,@ServiceTypes,@Currency,@Amount,@Remarks,@CurrentDate,@UserID,@AgentId,@SessionFinYear,@AgentCode) " +
                                            " END  " +
                                            " ELSE " +
                                            " UPDATE NVO_MRGRate SET MRGRate=@MRGRate,FDate=@FDate,TDate=@TDate,PofOrigin=@PofOrigin,PofLoading=@PofLoading,PofDischarge=@PofDischarge,PofFinalPOD=@PofFinalPOD," +
                                            " CntrTypes=@CntrTypes,Commodity=@Commodity,ServiceTypes=@ServiceTypes,Currency=@Currency,Amount=@Amount,Remarks=@Remarks,CurrentDate=@CurrentDate,UserID=@UserID,AgentId=@AgentId,SessionFinYear=@SessionFinYear,AgentCode=@AgentCode where ID=@ID";

                                dt.Rows[i]["Result"] = "Y";
                                dt.Rows[i]["Status"] = "MRG as be Create";
                            }
                            else
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_MRGRate where ID=@ID)<=0) " +
                                          " BEGIN " +
                                          " INSERT INTO  NVO_MRGRate(MRGRate,FDate,TDate,PofOrigin,PofLoading,PofDischarge,PofFinalPOD,CntrTypes,Commodity,ServiceTypes,Currency,Amount,Remarks,CurrentDate,UserID,AgentId,SessionFinYear,AgentCode) " +
                                          " values (@MRGRate,@FDate,@TDate,@PofOrigin,@PofLoading,@PofDischarge,@PofFinalPOD,@CntrTypes,@Commodity,@ServiceTypes,@Currency,@Amount,@Remarks,@CurrentDate,@UserID,@AgentId,@SessionFinYear,@AgentCode) " +
                                          " END  " +
                                          " ELSE " +
                                          " UPDATE NVO_MRGRate SET MRGRate=@MRGRate,FDate=@FDate,TDate=@TDate,PofOrigin=@PofOrigin,PofLoading=@PofLoading,PofDischarge=@PofDischarge,PofFinalPOD=@PofFinalPOD," +
                                          " CntrTypes=@CntrTypes,Commodity=@Commodity,ServiceTypes=@ServiceTypes,Currency=@Currency,Amount=@Amount,Remarks=@Remarks,CurrentDate=@CurrentDate,UserID=@UserID,AgentId=@AgentId,SessionFinYear=@SessionFinYear,AgentCode=@AgentCode where ID=@ID";

                                dt.Rows[i]["Result"] = "Y";
                                dt.Rows[i]["Status"] = "MRG as be Updated";
                            }
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", dt.Rows[i]["ID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@MRGRate", "UPLOADEXCEL"));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@FDate", DateTime.Parse(dt.Rows[i]["VALID FROM"].ToString())));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TDate", DateTime.Parse(dt.Rows[i]["VALID TO"].ToString())));
                            DataTable _dtPort = GetPortID(dt.Rows[i]["PORT OF ORIGIN"].ToString());
                            if (_dtPort.Rows.Count > 0)
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PofOrigin", _dtPort.Rows[0]["ID"].ToString()));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PofOrigin", 0));

                            DataTable _dtPOL = GetPortID(dt.Rows[i]["PORT OF LOADING"].ToString());
                            if (_dtPOL.Rows.Count > 0)
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PofLoading", _dtPOL.Rows[0]["ID"].ToString()));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PofLoading", 0));

                            DataTable _dtPOD = GetPortID(dt.Rows[i]["PORT OF DISCHARGE"].ToString());
                            if (_dtPOD.Rows.Count > 0)
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PofDischarge", _dtPOD.Rows[0]["ID"].ToString()));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PofDischarge", 0));

                            DataTable _dtPOF = GetPortID(dt.Rows[i]["FINAL POD"].ToString());
                            if (_dtPOD.Rows.Count > 0)
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PofFinalPOD", _dtPOF.Rows[0]["ID"].ToString()));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PofFinalPOD", 0));

                            DataTable _dtCntType = GetCntrType(dt.Rows[i]["CONTAINER TYPE"].ToString());
                            if (_dtCntType.Rows.Count > 0)
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypes", _dtCntType.Rows[0]["ID"].ToString()));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypes", 0));

                            DataTable _dtComty = GetCommodity(dt.Rows[i]["COMMODITY TYPE"].ToString());
                            if (_dtComty.Rows.Count > 0)
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Commodity", _dtComty.Rows[i]["ID"].ToString()));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Commodity", 0));

                            DataTable _dtService = GetService(dt.Rows[i]["SERVICE TYPE"].ToString());
                            if (_dtService.Rows.Count > 0)
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ServiceTypes", _dtService.Rows[i]["ID"].ToString()));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ServiceTypes", 0));

                            DataTable _dtCurr = GetCurrency(dt.Rows[i]["CURRENCY"].ToString());
                            if (_dtCurr.Rows.Count > 0)
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Currency", _dtCurr.Rows[i]["ID"].ToString()));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Currency", 0));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", dt.Rows[i]["FREIGHT RATE"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", dt.Rows[i]["REMARKS"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", 1));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentId", 1));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SessionFinYear", "2021"));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentCode", "NC"));

                            Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();
                        }


                    }
                    trans.Commit();
                    result = 1;
                    return dt;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return dt;
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


        public DataTable InsertSLOTExcelUploading(DataTable dtv)
        {
            string SlotOp = "0";
            string SlotTerms = "0";
            string POL = "0";
            string POD = "0";
            string ServiceName = "";

            DataTable dt = new DataTable();
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
                string varv = "";
                try
                {
                    DataView dts = new DataView(dtv);
                    dt = dts.ToTable(true, "ID", "SLOTCONTRACTREF", "SLOT OPERATOR", "POL", "POD", "Result", "Status", "VALID FROM", "VALID TO", "SERVICE NAME", "SLOT TERM");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ID"].ToString() != "")
                        {

                            if (dt.Rows[i]["ID"].ToString() == "0")
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_SLOTMaster where SlotRef=@SlotRef)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_SLOTMaster(SlotRef,ValidFrom,ValidTo,ServiceName,SlotOperator,SlotTermID,POD,POL,TSPort,Remarks,CurrentDate) " +
                                     " values (@SlotRef,@ValidFrom,@ValidTo,@ServiceName,@SlotOperator,@SlotTermID,@POD,@POL,@TSPort,@Remarks,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_SLOTMaster SET SlotRef=@SlotRef,ValidFrom=@ValidFrom,ValidTo=@ValidTo,ServiceName=@ServiceName,SlotOperator=@SlotOperator,SlotTermID=@SlotTermID," +
                                     " POD=@POD,POL=@POL,TSPort=@TSPort,Remarks=@Remarks,CurrentDate=@CurrentDate where SlotRef=@SlotRef";

                                dt.Rows[i]["Result"] = "Y";
                                dt.Rows[i]["Status"] = "SLAT as be Create";
                            }
                            else
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_SLOTMaster where SlotRef=@SlotRef)<=0) " +
                                       " BEGIN " +
                                       " INSERT INTO  NVO_SLOTMaster(SlotRef,ValidFrom,ValidTo,ServiceName,SlotOperator,SlotTermID,POD,POL,TSPort,Remarks,CurrentDate) " +
                                       " values (@SlotRef,@ValidFrom,@ValidTo,@ServiceName,@SlotOperator,@SlotTermID,@POD,@POL,@TSPort,@Remarks,@CurrentDate) " +
                                       " END  " +
                                       " ELSE " +
                                       " UPDATE NVO_SLOTMaster SET SlotRef=@SlotRef,ValidFrom=@ValidFrom,ValidTo=@ValidTo,ServiceName=@ServiceName,SlotOperator=@SlotOperator,SlotTermID=@SlotTermID," +
                                       " POD=@POD,POL=@POL,TSPort=@TSPort,Remarks=@Remarks,CurrentDate=@CurrentDate where SlotRef=@SlotRef";

                                dt.Rows[i]["Result"] = "Y";
                                dt.Rows[i]["Status"] = "SLat as be Updated";
                            }
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", dt.Rows[i]["ID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotRef", dt.Rows[i]["SLOTCONTRACTREF"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidFrom", DateTime.Parse(dt.Rows[i]["VALID FROM"].ToString())));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTo", DateTime.Parse(dt.Rows[i]["VALID TO"].ToString())));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ServiceName", dt.Rows[i]["SERVICE NAME"].ToString()));

                            DataTable _dtCus = GetCustomer(dt.Rows[i]["SLOT OPERATOR"].ToString());
                            if (_dtCus.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotOperator", _dtCus.Rows[0]["ID"].ToString()));
                                SlotOp = _dtCus.Rows[0]["ID"].ToString();
                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotOperator", 0));

                            DataTable _dtSlotTerms = GetSlotTerms(dt.Rows[i]["SLOT TERM"].ToString());
                            if (_dtSlotTerms.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotTermID", _dtSlotTerms.Rows[0]["ID"].ToString()));
                                SlotTerms = _dtSlotTerms.Rows[0]["ID"].ToString();
                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@SlotTermID", 0));

                            DataTable _dtPort = GetPortIDSlot(dt.Rows[i]["POL"].ToString());
                            if (_dtPort.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@POL", _dtPort.Rows[0]["ID"].ToString()));
                                POL = _dtPort.Rows[0]["ID"].ToString();

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@POL", 0));

                            DataTable _dtPOL = GetPortIDSlot(dt.Rows[i]["POD"].ToString());
                            if (_dtPOL.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@POD", _dtPOL.Rows[0]["ID"].ToString()));
                                POD = _dtPOL.Rows[0]["ID"].ToString();
                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@POD", 0));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TSPort", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", ""));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));

                            Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                            int intID = 0;

                            if (dt.Rows[i]["SLOTCONTRACTREF"].ToString() != "")
                            {
                                Cmd.CommandText = "select Id from NVO_SLOTMaster where SlotRef = '" + dt.Rows[i]["SLOTCONTRACTREF"].ToString() + "'";
                                object objID = Cmd.ExecuteScalar();
                                if (objID != null && objID != DBNull.Value)
                                    intID = int.Parse(objID.ToString());

                            }
                            else
                            {
                                // intID = dt.Rows[i]["ID"].ToString();
                            }
                            
                            DataTable dtx = dtv.Select("SLOTCONTRACTREF='" + dt.Rows[i]["SLOTCONTRACTREF"].ToString() + "'").CopyToDataTable();
                           
                            for (int j = 0; j < dtx.Rows.Count; j++)
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_SLOTDDtls where SLID=@SLID and ChargeID=@ChargeID and BasicID=@BasicID and SizeID=@SizeID and Commodity=@Commodity and CurrencyID=@CurrencyID)<=0) " +
                                      " BEGIN " +
                                      " INSERT INTO  NVO_SLOTDDtls(SLID,ChargeID,BasicID,SizeID,Commodity,CurrencyID,Amount,ResponsibleAgent) " +
                                      " values (@SLID,@ChargeID,@BasicID,@SizeID,@Commodity,@CurrencyID,@Amount,@ResponsibleAgent) " +
                                      " END  " +
                                      " ELSE " +
                                      " UPDATE NVO_SLOTDDtls SET SLID=@SLID,ChargeID=@ChargeID,BasicID=@BasicID,SizeID=@SizeID,Commodity=@Commodity,CurrencyID=@CurrencyID," +
                                      " Amount=@Amount,ResponsibleAgent=@ResponsibleAgent where SLID=@SLID and ChargeID=@ChargeID and BasicID=@BasicID and SizeID=@SizeID and Commodity=@Commodity and CurrencyID=@CurrencyID";


                                Cmd.Parameters.Add(_dbFactory.GetParameter("@SLID", intID));
                                DataTable dtCh = GetChargeCode(dtx.Rows[j]["CHARGE"].ToString());
                                if (dtCh.Rows.Count > 0)
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeID", dtCh.Rows[0]["ID"].ToString()));
                                else
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeID", 0));


                                if (dtx.Rows[j]["BASIS"].ToString() == "CONTAINER")
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", "2"));
                                else
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BasicID", "1"));


                                DataTable _dtCntType = GetCntrType(dtx.Rows[j]["SIZE TYPE"].ToString());
                                if (_dtCntType.Rows.Count > 0)
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SizeID", _dtCntType.Rows[0]["ID"].ToString()));
                                else
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SizeID", 0));


                                DataTable _dtComty = GetCommodity(dtx.Rows[j]["COMMODITY"].ToString());
                                if (_dtComty.Rows.Count > 0)
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Commodity", _dtComty.Rows[0]["ID"].ToString()));
                                else
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Commodity", 0));


                                DataTable _dtCurr = GetCurrency(dtx.Rows[j]["CURRENCY"].ToString());
                                if (_dtCurr.Rows.Count > 0)
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtCurr.Rows[0]["ID"].ToString()));
                                else
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", 0));


                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", dtx.Rows[j]["Amount"].ToString()));

                                DataTable _dCus = GetAgency(dtx.Rows[j]["RESPONSIBLE AGENCY"].ToString());
                                if (_dCus.Rows.Count > 0)
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ResponsibleAgent", _dCus.Rows[0]["ID"].ToString()));
                                else
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ResponsibleAgent", 0));

                                Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                            }

                        }
                    }
                    trans.Commit();
                    result = 1;
                    return dt;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return dt;
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

        public DataTable InsertTariffExcelUploading(DataTable dtv, string TriffID)
        {

            string DestPort = "";
            DataTable dt = new DataTable();
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
                string varv = "";
                try
                {

                    string PortID = "0"; string Mode = "0"; string ShipmentType = "0"; string Commodity = "0";
                    string TariffModeID = "0"; string TraiffRegular = "0";

                    DataView dts = new DataView(dtv);
                    dt = dts.ToTable(true, "TARIFF_MODE", "TARIFF_TYPE", "INCIDENTAL_TARIFF_TYPE", "LOCATION", "MODULE", "SHIPMENT_TYPE", "COMMODITY_TYPE", "COLLECTION_MODE", "STATUS", "CUSTOMER", "VALID_FROM", "VALID_TO");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["LOCATION"].ToString() != "")
                        {


                            Cmd.CommandText = " IF((select count(*) from NVO_PortTariffMaster where PortLocationID=@PortLocationID and ModuleID=@ModuleID and ShipmentTypeID=@ShipmentTypeID and CommodityTypeID=@CommodityTypeID and TariffModeID=@TariffModeID and TraiffRegular=@TraiffRegular and ValidFrom=@ValidFrom and ValidTo=@ValidTo)<= 0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_PortTariffMaster(PortLocationID,ModuleID,ShipmentTypeID,CommodityTypeID,CollectionModeID,CollectionAgentID,StatusID,ValidFrom,ValidTo,CustomerID,Remarks,CurrentDate,TariffModeID,TariffType,TraiffRegular) " +
                                         " values (@PortLocationID,@ModuleID,@ShipmentTypeID,@CommodityTypeID,@CollectionModeID,@CollectionAgentID,@StatusID,@ValidFrom,@ValidTo,@CustomerID,@Remarks,@CurrentDate,@TariffModeID,@TariffType,@TraiffRegular) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_PortTariffMaster SET PortLocationID=@PortLocationID,ModuleID=@ModuleID,ShipmentTypeID=@ShipmentTypeID,CommodityTypeID=@CommodityTypeID,CollectionModeID=@CollectionModeID,CollectionAgentID=@CollectionAgentID,StatusID=@StatusID," +
                                         " ValidFrom=@ValidFrom,ValidTo=@ValidTo,CustomerID=@CustomerID,Remarks=@Remarks,CurrentDate=@CurrentDate,TariffModeID=@TariffModeID,TariffType=@TariffType,TraiffRegular=@TraiffRegular where PortLocationID=@PortLocationID and ModuleID=@ModuleID and ShipmentTypeID=@ShipmentTypeID and CommodityTypeID=@CommodityTypeID and TariffModeID=@TariffModeID and TraiffRegular=@TraiffRegular and ValidFrom=@ValidFrom and ValidTo=@ValidTo";

                            dtv.Rows[i]["Result"] = "Y";
                            dtv.Rows[i]["Status"] = "Tariff as be Create";


                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", 0));

                            DataTable _dtPortv = GetPortID(dt.Rows[i]["LOCATION"].ToString());
                            if (_dtPortv.Rows.Count > 0)
                            {
                                PortID = _dtPortv.Rows[0]["ID"].ToString();
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PortLocationID", _dtPortv.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PortLocationID", 0));


                            DataTable _dtMode = GetTariff(dt.Rows[i]["MODULE"].ToString());
                            if (_dtMode.Rows.Count > 0)
                            {
                                Mode = _dtMode.Rows[0]["ID"].ToString();
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ModuleID", _dtMode.Rows[0]["ID"].ToString()));
                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ModuleID", 0));


                            DataTable _dtShipmentType = GetShipmentType(dt.Rows[i]["SHIPMENT_TYPE"].ToString());
                            if (_dtShipmentType.Rows.Count > 0)
                            {
                                ShipmentType = _dtShipmentType.Rows[0]["ID"].ToString();
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", _dtShipmentType.Rows[0]["ID"].ToString()));
                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", 0));


                            DataTable _dtCommodity = GetCommodity(dt.Rows[i]["COMMODITY_TYPE"].ToString());
                            if (_dtCommodity.Rows.Count > 0)
                            {
                                Commodity = _dtCommodity.Rows[0]["ID"].ToString();
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", _dtCommodity.Rows[0]["ID"].ToString()));
                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", 0));


                            DataTable _dtCollMode = GetTariffCollectMode(dt.Rows[i]["COLLECTION_MODE"].ToString());
                            if (_dtCollMode.Rows.Count > 0)
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionModeID", _dtCollMode.Rows[0]["ID"].ToString()));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionModeID", 0));


                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CollectionAgentID", 0));


                            Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", 1));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidFrom", (DateTime.Parse(dt.Rows[i]["VALID_FROM"].ToString())).ToString("MM/dd/yyyy")));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTo", (DateTime.Parse(dt.Rows[i]["VALID_TO"].ToString())).ToString("MM/dd/yyyy")));

                            DataTable dtCus = GetCustomer(dt.Rows[i]["CUSTOMER"].ToString());
                            if (dtCus.Rows.Count > 0)
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", dtCus.Rows[0]["ID"].ToString()));
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", 0));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", ""));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));

                            DataTable _dtTariffMode = GetTariffModell(dt.Rows[i]["TARIFF_MODE"].ToString());
                            if (_dtTariffMode.Rows.Count > 0)
                            {
                                TariffModeID = _dtTariffMode.Rows[0]["ID"].ToString();
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffModeID", _dtTariffMode.Rows[0]["ID"].ToString()));
                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffModeID", 0));


                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffType", 0));

                            DataTable _dtTariffRegular = GetTariffRegular(dt.Rows[i]["TARIFF_TYPE"].ToString());
                            if (_dtTariffRegular.Rows.Count > 0)
                            {
                                TraiffRegular = _dtTariffRegular.Rows[0]["ID"].ToString();
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TraiffRegular", _dtTariffRegular.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TraiffRegular", 0));




                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                            int TriffIDv = 0;


                            if (dt.Rows[i]["LOCATION"].ToString() != "")
                            {
                                Cmd.CommandText = "select Id from NVO_PortTariffMaster where PortLocationID =" + PortID + " and ModuleID=" + Mode + " and ShipmentTypeID=" + ShipmentType + " and CommodityTypeID=" + Commodity + " and TariffModeID=" + TariffModeID + " and TraiffRegular=" + TraiffRegular;
                                object objID = Cmd.ExecuteScalar();
                                if (objID != null && objID != DBNull.Value)
                                    TriffIDv = int.Parse(objID.ToString());

                            }

                            DataTable dtx = dtv;
                            DataView dtsvs = new DataView(dtv);

                            //dtx = dtsvs.ToTable(true, "TARIFF_MODE", "TARIFF_TYPE", "INCIDENTAL_TARIFF_TYPE", "LOCATION", "MODULE", "SHIPMENT_TYPE", "COMMODITY_TYPE", "COLLECTION_MODE", "STATUS", "CUSTOMER", "VALID_FROM", "VALID_TO");
                            //dtx = dtv.Select("LOCATION='" + dt.Rows[i]["LOCATION"].ToString() + "' AND TARIFF_MODE= '" + dt.Rows[i]["TARIFF_MODE"].ToString() + "' AND INCIDENTAL_TARIFF_TYPE= '" + dt.Rows[i]["INCIDENTAL_TARIFF_TYPE"].ToString() + "'").CopyToDataTable();
                            dtx = dtv.Select("LOCATION='" + dt.Rows[i]["LOCATION"].ToString() + "' AND TARIFF_MODE= '" + dt.Rows[i]["TARIFF_MODE"].ToString() + "' and TARIFF_TYPE= '" + dt.Rows[i]["TARIFF_TYPE"].ToString() + "' and SHIPMENT_TYPE= '" + dt.Rows[i]["SHIPMENT_TYPE"].ToString() + "'  and COMMODITY_TYPE= '" + dt.Rows[i]["COMMODITY_TYPE"].ToString() + "' and COLLECTION_MODE= '" + dt.Rows[i]["COLLECTION_MODE"].ToString() + "'").CopyToDataTable();

                            for (int j = 0; j < dtx.Rows.Count; j++)
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_PortTariffDtls where PTID=@PTID and ChargeTypeID=@ChargeTypeID and ChargeCodeID=@ChargeCodeID and BasisID=@BasisID)<=0) " +
                                      " BEGIN " +
                                      " INSERT INTO  NVO_PortTariffDtls(PTID,ChargeTypeID,ChargeCodeID,BasisID,CntrID,CurrencyID,Amount,DestCountryID,ChargeType,ChargeCode,Basis,Cntr,Currency,DestCountry) " +
                                      " values (@PTID,@ChargeTypeID,@ChargeCodeID,@BasisID,@CntrID,@CurrencyID,@Amount,@DestCountryID,@ChargeType,@ChargeCode,@Basis,@Cntr,@Currency,@DestCountry) " +
                                      " END  " +
                                      " ELSE " +
                                      " UPDATE NVO_PortTariffDtls SET PTID=@PTID,ChargeTypeID=@ChargeTypeID,ChargeCodeID=@ChargeCodeID,BasisID=@BasisID,CntrID=@CntrID,CurrencyID=@CurrencyID,Amount=@Amount,DestCountryID=@DestCountryID," +
                                      " ChargeType=@ChargeType,ChargeCode=@ChargeCode,Basis=@Basis,Cntr=@Cntr,Currency=@Currency,DestCountry=@DestCountry where PTID=@PTID and ChargeTypeID=@ChargeTypeID and ChargeCodeID=@ChargeCodeID and BasisID=@BasisID";
                                dtx.Rows[j]["Result"] = "Y";
                                dtx.Rows[j]["Status"] = "Tariff as be Create";

                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PTID", TriffIDv));

                                if (dtx.Rows[j]["CHARGE_TYPE"].ToString() == "REVENUE")
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 1));
                                else
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 2));

                                DataTable dtCh = GetCharge(dtx.Rows[j]["CHARGE_CODE"].ToString());
                                if (dtCh.Rows.Count > 0)
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", dtCh.Rows[0]["ID"].ToString()));
                                else
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", 0));

                                if (dtx.Rows[j]["BASIS"].ToString() == "CONTAINER")
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BasisID", 2));
                                else
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BasisID", 1));

                                DataTable _dtCntType = GetCntrType(dtx.Rows[j]["CON_TYPE"].ToString());
                                if (_dtCntType.Rows.Count > 0)
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", _dtCntType.Rows[0]["ID"].ToString()));
                                else
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", 0));

                                DataTable _dtCurr = GetCurrency(dtx.Rows[j]["CURRENCY"].ToString());
                                if (_dtCurr.Rows.Count > 0)
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtCurr.Rows[0]["ID"].ToString()));
                                else
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", 0));

                                Cmd.Parameters.Add(_dbFactory.GetParameter("@AMOUNT", dtx.Rows[j]["Amount"].ToString()));


                                DataTable _dtPort = GetPortID(dtx.Rows[j]["DEST_PORT"].ToString());
                                if (_dtPort.Rows.Count > 0)
                                {
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DestCountryID", _dtPort.Rows[0]["ID"].ToString()));
                                    DestPort = _dtPort.Rows[0]["ID"].ToString();

                                }
                                else
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DestCountryID", 0));


                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeType", dtx.Rows[j]["CHARGE_TYPE"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCode", dtx.Rows[j]["CHARGE_CODE"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Basis", dtx.Rows[j]["BASIS"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Currency", dtx.Rows[j]["CURRENCY"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Cntr", dtx.Rows[j]["CON_TYPE"].ToString()));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DestCountry", dtx.Rows[j]["DEST_PORT"].ToString()));


                                Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                            }
                        }
                    }

                    trans.Commit();
                    result = 1;
                    return dtv;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return dt;
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

        public DataTable InsertMNRExcelUploading(DataTable dtv, string TriffID)
        {

            string DestPort = "";
            DataTable dt = new DataTable();
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
                string varv = "";
                try
                {


                    DataTable dtx = dtv;
                    for (int j = 0; j < dtx.Rows.Count; j++)
                    {
                        Cmd.CommandText = " IF((select count(*) from NVO_MNRTariffDtls where TID=@TID and TariffID=@TariffID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_MNRTariffDtls(TariffID,DamageDescription,DamageID,RepairID,LocationID,ComponentID,Length,Width,LabourHrs,LabourCostx100,MaterialCostx100) " +
                                    " values (@TariffID,@DamageDescription,@DamageID,@RepairID,@LocationID,@ComponentID,@Length,@Width,@LabourHrs,@LabourCostx100,@MaterialCostx100) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_MNRTariffDtls SET TariffID=@TariffID,DamageDescription=@DamageDescription,DamageID=@DamageID,RepairID=@RepairID,LocationID=@LocationID,ComponentID=@ComponentID,Length=@Length," +
                                    "Width=@Width,LabourHrs=@LabourHrs,LabourCostx100=@LabourCostx100,MaterialCostx100=@MaterialCostx100 where TariffID=@TariffID and TID=@TID";

                        dtx.Rows[j]["Result"] = "Y";
                        dtx.Rows[j]["Status"] = "MNR as be Create";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffID", TriffID));

                        DataTable _dtDamag = GetMNRDamage(dtx.Rows[j]["DM CODE"].ToString());
                        if (_dtDamag.Rows.Count > 0)
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageID", _dtDamag.Rows[0]["ID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageDescription", _dtDamag.Rows[0]["DamageDescription"].ToString()));
                        }
                        else
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageID", 0));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DamageDescription", ""));
                        }

                        DataTable _dtRepir = GetMNRRepair(dtx.Rows[j]["REPAIR TYPE"].ToString());
                        if (_dtRepir.Rows.Count > 0)
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RepairID", _dtRepir.Rows[0]["ID"].ToString()));
                        }
                        else
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RepairID", 0));
                        }


                        DataTable _dtCompo = GetMNRRepair(dtx.Rows[j]["COMPONENT CODE"].ToString());
                        if (_dtCompo.Rows.Count > 0)
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ComponentID", _dtCompo.Rows[0]["ID"].ToString()));
                        }
                        else
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ComponentID", 0));
                        }

                        DataTable _dtMNRLocation = GetMNRLocation(dtx.Rows[j]["LOCATION"].ToString());
                        if (_dtMNRLocation.Rows.Count > 0)
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", _dtMNRLocation.Rows[0]["ID"].ToString()));
                        }
                        else
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", 0));
                        }
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Length", dtx.Rows[j]["LENGTH(CM)"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Width", dtx.Rows[j]["WIDTH(CM)"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LabourHrs", dtx.Rows[j]["LAB HRS"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LabourCostx100", dtx.Rows[j]["LAB COST"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MaterialCostx100", dtx.Rows[j]["MAT COST"].ToString()));

                        Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    trans.Commit();
                    result = 1;
                    return dtx;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return dt;
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

        public DataTable InsertTaxEngineExcelUploading(DataTable dtv)
        {
            string ChargeTB = "0";
            string SlotTerms = "0";
            string POL = "0";
            string POD = "0";
            string ServiceName = "";

            DataTable dt = new DataTable();
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
                string varv = "";
                try
                {
                    DataView dts = new DataView(dtv);
                    dt = dts.ToTable(true, "ID", "CHARGE CODE", "SACCODE", "SHIPMENT TYPE", "TAX PERCENTAGE", "RESULT", "STATUS");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ID"].ToString() != "")
                        {

                            if (dt.Rows[i]["ID"].ToString() == "0")
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_ChargeTaxEngineDtls where ChargeTBID=@ChargeTBID and ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ChargeTaxEngineDtls(TaxPercentageID,ChargeTBID,SACCode,ShipmentTypeID,DtAdded) " +
                                     " values (@TaxPercentageID,@ChargeTBID,@SACCode,@ShipmentTypeID,@DtAdded) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ChargeTaxEngineDtls SET TaxPercentageID=@TaxPercentageID,ChargeTBID=@ChargeTBID,SACCode=@SACCode,ShipmentTypeID=@ShipmentTypeID,DtModified=@DtModified where ID=@ID and ChargeTBID=@ChargeTBID";

                                dt.Rows[i]["RESULT"] = "Y";
                                dt.Rows[i]["STATUS"] = "Tax Engine has been Created";
                            }
                            else
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_ChargeTaxEngineDtls where ChargeTBID=@ChargeTBID and ID=@ID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_ChargeTaxEngineDtls(TaxPercentageID,ChargeTBID,SACCode,ShipmentTypeID,DtAdded) " +
                                    " values (@TaxPercentageID,@ChargeTBID,@SACCode,@ShipmentTypeID,@DtAdded) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_ChargeTaxEngineDtls SET TaxPercentageID=@TaxPercentageID,ChargeTBID=@ChargeTBID,SACCode=@SACCode,ShipmentTypeID=@ShipmentTypeID,DtModified=@DtModified where ID=@ID and ChargeTBID=@ChargeTBID";


                                dt.Rows[i]["RESULT"] = "Y";
                                dt.Rows[i]["STATUS"] = "Tax Engine has been Updated";
                            }
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", dt.Rows[i]["ID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTBID", dt.Rows[i]["CHARGE CODE"].ToString()));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", dt.Rows[i]["SHIPMENT TYPE"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxPercentageID", dt.Rows[i]["TAX PERCENTAGE"].ToString()));

                            Cmd.Parameters.Clear();

                            DataTable _dtChg = GetChargeCodeTaxEngines(dt.Rows[i]["CHARGE CODE"].ToString());
                            if (_dtChg.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTBID", _dtChg.Rows[0]["ID"].ToString()));
                                //ChargeTB = _dtChg.Rows[0]["ID"].ToString();
                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTBID", 0));

                            DataTable _dtShipmentTypes = GetShipmentType(dt.Rows[i]["SHIPMENT TYPE"].ToString());
                            if (_dtShipmentTypes.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", _dtShipmentTypes.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipmentTypeID", 0));

                            DataTable _dtTP = GetTaxPercentage(dt.Rows[i]["TAX PERCENTAGE"].ToString());
                            if (_dtTP.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxPercentageID", _dtTP.Rows[0]["ID"].ToString()));


                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxPercentageID", 0));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", dt.Rows[i]["ID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SACCODE", dt.Rows[i]["SACCODE"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtAdded", System.DateTime.Now));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", System.DateTime.Now));

                            Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();


                        }
                    }
                    trans.Commit();
                    result = 1;
                    return dt;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return dt;
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
        public DataTable GetPortID(string Name)
        {
            string _Query = "select * from NVO_PortMaster where PortName like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetPortIDSlot(string Name)
        {
            string _Query = "select * from NVO_PortMainMaster where PortName like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        
        public DataTable GetCntrType(string Name)
        {
            string _Query = "select * from NVO_tblCntrTypes where Size like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetCommodity(string Name)
        {
            string _Query = " select * from NVO_GeneralMaster where SeqNo= 2 and GeneralName like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetService(string Name)
        {
            string _Query = "select * from NVO_tblDLValues where SeqNo = 1 and Description like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetSlotTerms(string Name)
        {
            string _Query = "select * from NVO_tblDLValues where SeqNo = 2 and Description like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetCurrency(string Name)
        {
            string _Query = "select * from NVO_CurrencyMaster where CurrencyCode like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetCustomer(string Name)
        {
            string _Query = "select * from NVO_CustomerMaster where CustomerName like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetAgency(string Name)
        {
            string _Query = "select * from NVO_AgencyMaster where AgencyName like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        
        public DataTable GetChargeCode(string Name)
        {
            string _Query = "select * from NVO_ChargeTB where ChgDesc like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetCharge(string Name)
        {
            string _Query = "select * from NVO_ChargeTB where ChgCode like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }


        public DataTable GetMNRDamage(string Name)
        {
            string _Query = "select * from NVO_MNRDamageMaster where DamageCode like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetMNRRepair(string Name)
        {
            string _Query = "select * from NVO_MNRRepairMaster where RepairCode like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetMNRComponent(string Name)
        {
            string _Query = "select * from NVO_MNRComponentMaster where ComponentCode like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetMNRLocation(string Name)
        {
            string _Query = "select * from NVO_MNRLocationMaster where LocationCode like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }


        public DataTable GetShipmentType(string Name)
        {
            string _Query = "select * from NVO_generalMaster where Seqno =1 and GeneralName like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetTaxPercentage(string Name)
        {
            string _Query = "select * from NVO_ChgTaxDeclaration where TaxName like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetChargeCodeTaxEngines(string Name)
        {
            string _Query = "select * from NVO_ChargeTB where ChgCode like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetTariff(string Name)
        {
            string _Query = " select * from NVO_GeneralMaster where SeqNo= 7 and GeneralName like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetTariffModell(string Name)
        {
            string _Query = " select * from NVO_GeneralMaster where SeqNo= 28 and GeneralName like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetTariffCollectMode(string Name)
        {
            string _Query = " select * from NVO_GeneralMaster where SeqNo= 9 and GeneralName like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetTariffRegular(string Name)
        {
            string _Query = " select * from NVO_GeneralMaster where SeqNo= 40 and GeneralName like '%" + Name + "%'";
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
    }
}
