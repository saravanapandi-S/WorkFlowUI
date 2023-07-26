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
    public class IHCUploadManager
    {
        #region Constructor Method
        public IHCUploadManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        public DataTable InsertIHCTariffExcelUploading(DataTable dtv)
        {

            string DestPort = "";
            DataTable dt = new DataTable();
            int result = 0;
            DbConnection con = null;
            DbTransaction trans;
            try
            {
                int rowdt = 0;
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;
                string varv = "";
                try
                {
                    Cmd.CommandText = "truncate table NVO_TempIHCTariffUpload";
                    result = Cmd.ExecuteNonQuery();

                    for (int i = 0; i < dtv.Rows.Count; i++)
                    {
                        rowdt = i;
                        Cmd.CommandText = " IF((select count(*) from NVO_TempIHCTariffUpload where ID=@ID)<= 0) " +
                                      " BEGIN " +
                                      " INSERT INTO  NVO_TempIHCTariffUpload(IHCTrfID,ICD_NAME,PORT,CHARGE_TYPE,Charge,COMMODITY_TYPE,CONTAINER_TYPE,THC_INCLUDED,STATUS,VALID_FROM,VALID_TILL,SLAB_FROM,SLAB_TO,CURRENCY,BREAKUP_CHARGE,PAYMENT_TO,Amount,TID) " +
                                      " values (@IHCTrfID,@ICD_NAME,@PORT,@CHARGE_TYPE,@Charge,@COMMODITY_TYPE,@CONTAINER_TYPE,@THC_INCLUDED,@STATUS,@VALID_FROM,@VALID_TILL,@SLAB_FROM,@SLAB_TO,@CURRENCY,@BREAKUP_CHARGE,@PAYMENT_TO,@Amount,@TID) " +
                                      " END  " +
                                      " ELSE " +
                                      " UPDATE NVO_TempIHCTariffUpload SET IHCTrfID=@IHCTrfID,ICD_NAME=@ICD_NAME,PORT=@PORT,CHARGE_TYPE=@CHARGE_TYPE,Charge=@Charge,COMMODITY_TYPE=@COMMODITY_TYPE,CONTAINER_TYPE=@CONTAINER_TYPE,THC_INCLUDED=@THC_INCLUDED,STATUS=@STATUS,VALID_FROM=@VALID_FROM,VALID_TILL=@VALID_TILL,SLAB_FROM=@SLAB_FROM,SLAB_TO=@SLAB_TO, " +
                                      " CURRENCY=@CURRENCY,BREAKUP_CHARGE=@BREAKUP_CHARGE,PAYMENT_TO=@PAYMENT_TO,Amount=@Amount,TID=@TID where ID=@ID ";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@IHCTrfID", dtv.Rows[i]["ID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ICD_NAME", dtv.Rows[i]["ICD_NAME"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PORT", dtv.Rows[i]["PORT"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CHARGE_TYPE", dtv.Rows[i]["CHARGE_TYPE"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Charge", dtv.Rows[i]["CHARGES"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@COMMODITY_TYPE", dtv.Rows[i]["COMMODITY_TYPE"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CONTAINER_TYPE", dtv.Rows[i]["CONTAINER_TYPE"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@THC_INCLUDED", dtv.Rows[i]["THC_INCLUDED"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@STATUS", dtv.Rows[i]["STATUS"].ToString()));

                        if(dtv.Rows[i]["VALID_FROM"].ToString() !="")
                        {
                            string ValidfromV =DateTime.Parse(dtv.Rows[i]["VALID_FROM"].ToString()).ToString("MM/dd/yyyy");
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VALID_FROM", ValidfromV));
                        }
                        else
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VALID_FROM", DBNull.Value));
                        }
                        if (dtv.Rows[i]["VALID_TILL"].ToString() != "")
                        {
                            string ValidTillV = DateTime.Parse(dtv.Rows[i]["VALID_TILL"].ToString()).ToString("MM/dd/yyyy");
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VALID_TILL", ValidTillV));
                        }
                        else
                        {
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VALID_TILL", DBNull.Value));
                        }
                        

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SLAB_FROM", dtv.Rows[i]["SLAB_FROM"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SLAB_TO", dtv.Rows[i]["SLAB_TO"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CURRENCY", dtv.Rows[i]["CURRENCY"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BREAKUP_CHARGE", dtv.Rows[i]["BREAKUP_CHARGE"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PAYMENT_TO", dtv.Rows[i]["PAYMENT_TO"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", dtv.Rows[i]["AMOUNT"]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TID", dtv.Rows[i]["TID"].ToString()));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    result = 1;
                    return dtv;

                }
                catch (Exception ex)
                {
                    int hh = rowdt;
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


        public DataTable InsertIHCTariffDataMove()
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
                    int TraffInCrmentID = 0;
                    int TID = 0;
                    DataTable _dtMove = GetIHCMainTable();
                    for (int i = 0; i < _dtMove.Rows.Count; i++)
                    {
                        Cmd.CommandText = " IF((select count(*) from NVO_IHCHaulageTariff where ID=@ID)<= 0) " +
                                          " BEGIN " +
                                          " INSERT INTO  NVO_IHCHaulageTariff(ICDName,ICDLocID,PortID,ChargeTypeID,ChargesID,CommodityTypeID,ContainerTypeID,THCIncluded,Status,ValidFrom,ValidTill) " +
                                          " values (@ICDName,@ICDLocID,@PortID,@ChargeTypeID,@ChargesID,@CommodityTypeID,@ContainerTypeID,@THCIncluded,@Status,@ValidFrom,@ValidTill) " +
                                          " END  " +
                                          " ELSE " +
                                          " UPDATE NVO_IHCHaulageTariff SET ICDName=@ICDName,ICDLocID=@ICDLocID,PortID=@PortID,ChargeTypeID=@ChargeTypeID,ChargesID=@ChargesID,CommodityTypeID=@CommodityTypeID,ContainerTypeID=@ContainerTypeID,THCIncluded=@THCIncluded,Status=@Status,ValidFrom=@ValidFrom,ValidTill=@ValidTill where ID=@ID ";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", _dtMove.Rows[i]["IHCTrfID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ICDName", _dtMove.Rows[i]["ICD_Name"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ICDLocID", _dtMove.Rows[i]["ICDLocID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", _dtMove.Rows[i]["PortID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", _dtMove.Rows[i]["ChargeTypeID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargesID", _dtMove.Rows[i]["ChargesID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", _dtMove.Rows[i]["CommodityTypeID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerTypeID", _dtMove.Rows[i]["ContainerTypeID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@THCIncluded", _dtMove.Rows[i]["THCIncluded"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", _dtMove.Rows[i]["STATUS"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidFrom", DateTime.Parse(_dtMove.Rows[i]["ValidFrom"].ToString()).ToString("MM/dd/yyyy")));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", DateTime.Parse(_dtMove.Rows[i]["ValidTill"].ToString()).ToString("MM/dd/yyyy")));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                        if (_dtMove.Rows[i]["IHCTrfID"].ToString() == "0")
                        {
                            Cmd.CommandText = "select ident_current('NVO_IHCHaulageTariff')";
                            TraffInCrmentID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                        }
                        else
                        {
                            TraffInCrmentID = Int32.Parse(_dtMove.Rows[i]["IHCTrfID"].ToString());
                        }

                        DataTable _dtTHCTow = GetIHCMainTowTable(_dtMove.Rows[i]["ICD_Name"].ToString(), _dtMove.Rows[i]["Port"].ToString(), _dtMove.Rows[i]["CHARGE_TYPE"].ToString(),
                               _dtMove.Rows[i]["Charge"].ToString(), _dtMove.Rows[i]["CONTAINER_TYPE"].ToString(), _dtMove.Rows[i]["THC_INCLUDED"].ToString(), _dtMove.Rows[i]["COMMODITY_TYPE"].ToString());
                        for (int x = 0; x < _dtTHCTow.Rows.Count; x++)
                        {
                            Cmd.CommandText = "IF((select count(*) from NVO_IHCHaulageTariffDTLS where  IHCTariffID = @IHCTariffID and SlabFrom=@SlabFrom) <= 0) " +
                                " BEGIN " +
                                " INSERT INTO  NVO_IHCHaulageTariffDTLS(IHCTariffID,SlabFrom,SlabTo,CurrencyID,Amount) " +
                                " values (@IHCTariffID,@SlabFrom,@SlabTo,@CurrencyID,@Amount) " +
                                " END  " +
                                " ELSE " +
                                " UPDATE NVO_IHCHaulageTariffDTLS SET IHCTariffID=@IHCTariffID,SlabFrom=@SlabFrom,SlabTo=@SlabTo,CurrencyID=@CurrencyID,Amount=@Amount where IHCTariffID=@IHCTariffID and SlabFrom=@SlabFrom ";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@IHCTariffID", TraffInCrmentID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SlabFrom", _dtTHCTow.Rows[x]["SlabFrom"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@SlabTo", _dtTHCTow.Rows[x]["SlabTo"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtTHCTow.Rows[x]["CurrencyID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", _dtTHCTow.Rows[x]["Amt"]));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                            string thids = _dtMove.Rows[i]["IHCTrfID"].ToString();
                            if (_dtMove.Rows[i]["IHCTrfID"].ToString() == "0")
                            {
                                Cmd.CommandText = "select ident_current('NVO_IHCHaulageTariffDTLS')";
                                TID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                            }
                            else
                            {
                                TID = Int32.Parse(_dtTHCTow.Rows[x]["TID"].ToString());
                            }

                            DataTable dty = GetIHCMainThreeTable(_dtMove.Rows[i]["ICD_Name"].ToString(), _dtMove.Rows[i]["Port"].ToString(), _dtMove.Rows[i]["CHARGE_TYPE"].ToString(),
                               _dtMove.Rows[i]["Charge"].ToString(), _dtMove.Rows[i]["CONTAINER_TYPE"].ToString(), _dtMove.Rows[i]["THC_INCLUDED"].ToString(), _dtMove.Rows[i]["COMMODITY_TYPE"].ToString(), _dtTHCTow.Rows[x]["SlabFrom"].ToString(),
                               _dtTHCTow.Rows[x]["SlabTo"].ToString());

                            for (int z = 0; z < dty.Rows.Count; z++)
                            {
                                if (dty.Rows[z]["Payment"].ToString() != "")
                                {
                                    Cmd.CommandText = " IF((select count(*) from NVO_PortTariffIHCChargedtls where TariffChID=@TariffChID and ChargeCodeID=@ChargeCodeID and PaymentTo=@PaymentTo)<=0) " +
                                                       " BEGIN " +
                                                       " INSERT INTO  NVO_PortTariffIHCChargedtls(TariffChID,ChargeCodeID,PaymentTo,Amount) " +
                                                       " values (@TariffChID,@ChargeCodeID,@PaymentTo,@Amount) " +
                                                       " END  " +
                                                       " ELSE " +
                                                       " UPDATE NVO_PortTariffIHCChargedtls SET TariffChID=@TariffChID,ChargeCodeID=@ChargeCodeID,PaymentTo=@PaymentTo,Amount=@Amount where TariffChID=@TariffChID and ChargeCodeID=@ChargeCodeID and PaymentTo=@PaymentTo";

                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffChID", TID));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", dty.Rows[z]["ChargeID"].ToString()));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentTo", dty.Rows[z]["Payment"].ToString()));
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", dty.Rows[z]["Amount"]));
                                    result = Cmd.ExecuteNonQuery();
                                    Cmd.Parameters.Clear();
                                  
                                }
                            }
                        }
                    }
                   
                    trans.Commit();

                    result = 1;
                    return _dtMove;
                   
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
        public DataTable ihcexist(DataTable dtv)
        {
            //string PortID = "0"; string LocID = "0"; string ChargeType = "0"; string Commodity = "0";
            //string CntrTypeID = "0"; string TraiffRegular = "0";

            //DataView dts = new DataView(dtv);

            //dt = dts.ToTable(true, "ID", "ICD_NAME", "PORT", "CHARGE_TYPE", "CHARGES", "COMMODITY_TYPE", "CONTAINER_TYPE", "THC_INCLUDED", "STATUS", "VALID_FROM", "VALID_TILL", "SLAB_FROM", "SLAB_TO", "CURRENCY", "BREAKUP_CHARGE", "PAYMENT_TO", "RESULT");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    object sumTotal = 0;
            //    sumTotal = dtv.Compute("sum(AMOUNT)", " SLAB_FROM='" + dt.Rows[i]["SLAB_FROM"].ToString() + "'");


            //    if (dt.Rows[i]["PORT"].ToString() != "")
            //    {

            //        Cmd.CommandText = " IF((select count(*) from NVO_IHCHaulageTariff where ID=@ID)<= 0) " +
            //                     " BEGIN " +
            //                      " INSERT INTO  NVO_IHCHaulageTariff(ICDName,ICDLocID,PortID,ChargeTypeID,ChargesID,CommodityTypeID,ContainerTypeID,THCIncluded,Status,ValidFrom,ValidTill) " +
            //                 " values (@ICDName,@ICDLocID,@PortID,@ChargeTypeID,@ChargesID,@CommodityTypeID,@ContainerTypeID,@THCIncluded,@Status,@ValidFrom,@ValidTill) " +
            //                 " END  " +
            //                 " ELSE " +
            //                 " UPDATE NVO_IHCHaulageTariff SET ICDName=@ICDName,ICDLocID=@ICDLocID,PortID=@PortID,ChargeTypeID=@ChargeTypeID,ChargesID=@ChargesID,CommodityTypeID=@CommodityTypeID,ContainerTypeID=@ContainerTypeID,THCIncluded=@THCIncluded,Status=@Status,ValidFrom=@ValidFrom,ValidTill=@ValidTill where ID=@ID ";

            //        DataTable _dtCommodity = GetCommodity(dt.Rows[i]["COMMODITY_TYPE"].ToString());

            //        dtv.Rows[i]["Result"] = "Y";
            //        dtv.Rows[i]["Status"] = "Tariff as be Create";




            //        DataTable _dtCity = GetCities(dt.Rows[i]["ICD_NAME"].ToString());
            //        if (_dtCity.Rows.Count > 0)
            //        {
            //            LocID = _dtCity.Rows[0]["ID"].ToString();
            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@ICDLocID", _dtCity.Rows[0]["ID"].ToString()));

            //        }
            //        else
            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@ICDLocID", 0));


            //        DataTable _dtPORT = GetPortID(dt.Rows[i]["PORT"].ToString());
            //        if (_dtPORT.Rows.Count > 0)
            //        {
            //            PortID = _dtPORT.Rows[0]["ID"].ToString();
            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", _dtPORT.Rows[0]["ID"].ToString()));
            //        }
            //        else
            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", 0));


            //        DataTable _dtChargeType = GetChargeType(dt.Rows[i]["CHARGE_TYPE"].ToString());
            //        if (_dtChargeType.Rows.Count > 0)
            //        {
            //            ChargeType = _dtChargeType.Rows[0]["ID"].ToString();
            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", _dtChargeType.Rows[0]["ID"].ToString()));
            //        }
            //        else
            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeTypeID", 0));



            //        if (_dtCommodity.Rows.Count > 0)
            //        {
            //            Commodity = _dtCommodity.Rows[0]["ID"].ToString();
            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", _dtCommodity.Rows[0]["ID"].ToString()));
            //        }
            //        else
            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@CommodityTypeID", 0));


            //        DataTable _dtCntrType = GetCntrType(dt.Rows[i]["CONTAINER_TYPE"].ToString());
            //        if (_dtCntrType.Rows.Count > 0)
            //        {
            //            CntrTypeID = _dtCntrType.Rows[0]["ID"].ToString();
            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerTypeID", _dtCntrType.Rows[0]["ID"].ToString()));
            //        }

            //        else
            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerTypeID", 0));

            //        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", 1));

            //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidFrom", (DateTime.Parse(dt.Rows[i]["VALID_FROM"].ToString())).ToString("MM/dd/yyyy")));
            //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ValidTill", (DateTime.Parse(dt.Rows[i]["VALID_TILL"].ToString())).ToString("MM/dd/yyyy")));
            //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ICDName", dt.Rows[i]["ICD_NAME"].ToString()));
            //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargesID", 24));
            //        Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", 1));
            //        if (dt.Rows[i]["THC_INCLUDED"].ToString() == "YES")
            //        {
            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@THCIncluded", 1));
            //        }
            //        else
            //        {
            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@THCIncluded", 2));
            //        }
            //        int TriffIDv = 0;

            //        Cmd.CommandText = "select ident_current('NVO_IHCHaulageTariff')";
            //        if (dt.Rows[i]["ID"].ToString() == "0")
            //            TriffIDv = Int32.Parse(Cmd.ExecuteScalar().ToString());
            //        else
            //            TriffIDv = Int32.Parse(dt.Rows[i]["ID"].ToString());

            //        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", TriffIDv));

            //        Cmd.Parameters.Clear();
            //        result = Cmd.ExecuteNonQuery();


            //        DataTable dtx = dtv;
            //        DataView dtsvs = new DataView(dtv);


            //        dtx = dtv.Select("ID = '" + TriffIDv + "' and SLAB_FROM= '" + dt.Rows[i]["SLAB_FROM"].ToString() + "'").CopyToDataTable();


            //        for (int j = 0; j < dtx.Rows.Count; j++)
            //        {
            //            Cmd.CommandText = "IF((select count(*) from NVO_IHCHaulageTariffDTLS where  IHCTariffID = @IHCTariffID and SlabFrom=@SlabFrom) <= 0) " +
            //                " BEGIN " +
            //                " INSERT INTO  NVO_IHCHaulageTariffDTLS(IHCTariffID,SlabFrom,SlabTo,CurrencyID,Amount) " +
            //                " values (@IHCTariffID,@SlabFrom,@SlabTo,@CurrencyID,@Amount) " +
            //                " END  " +
            //                " ELSE " +
            //                " UPDATE NVO_IHCHaulageTariffDTLS SET IHCTariffID=@IHCTariffID,SlabFrom=@SlabFrom,SlabTo=@SlabTo,CurrencyID=@CurrencyID,Amount=@Amount where IHCTariffID=@IHCTariffID and SlabFrom=@SlabFrom ";

            //            dt.Rows[i]["Result"] = "Y";
            //            dt.Rows[i]["Status"] = "Tariff as be Create";

            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@IHCTariffID", TriffIDv));

            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@AMOUNT", sumTotal));

            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@SlabFrom", dtx.Rows[j]["SLAB_FROM"].ToString()));

            //            Cmd.Parameters.Add(_dbFactory.GetParameter("@SlabTo", dtx.Rows[j]["SLAB_TO"].ToString()));

            //            DataTable _dtCurr = GetCurrency(dtx.Rows[j]["CURRENCY"].ToString());
            //            if (_dtCurr.Rows.Count > 0)
            //                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", _dtCurr.Rows[0]["ID"].ToString()));
            //            else
            //                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", 0));


            //            Cmd.ExecuteNonQuery();
            //            Cmd.Parameters.Clear();
            //            int tarifdtlsvalue = 0;
            //            int TariffdtlsID = 0;

            //            Cmd.CommandText = "SELECT TID FROM NVO_IHCHaulageTariffDtls WHERE IHCTariffID =" + TriffIDv+ " AND SlabFrom =" + dt.Rows[i]["SLAB_FROM"].ToString() + "";
            //            tarifdtlsvalue = Int32.Parse(Cmd.ExecuteScalar().ToString());
            //            if (tarifdtlsvalue.ToString() != "0")
            //            {
            //                TariffdtlsID = tarifdtlsvalue;
            //            }
            //            else
            //            {
            //                Cmd.CommandText = "SELECT Ident_current('NVO_IHCHaulageTariffDtls')";
            //                TariffdtlsID = Int32.Parse(Cmd.ExecuteScalar().ToString());
            //            }



            //            DataTable dtz = dtv.Select("ID = '" + TriffIDv + "' and BREAKUP_CHARGE= '" + dt.Rows[i]["BREAKUP_CHARGE"].ToString() + "'  and PAYMENT_TO= '" + dt.Rows[i]["PAYMENT_TO"].ToString() + "' and SLAB_FROM= '" + dt.Rows[i]["SLAB_FROM"].ToString() + "'").CopyToDataTable();

            //            for (int k = 0; k < dtz.Rows.Count; k++)
            //            {
            //                Cmd.CommandText = " IF((select count(*) from NVO_PortTariffIHCChargedtls where TariffChID=@TariffChID and ChargeCodeID=@ChargeCodeID and PaymentTo=@PaymentTo)<=0) " +
            //                    " BEGIN " +
            //                    " INSERT INTO  NVO_PortTariffIHCChargedtls(TariffChID,ChargeCodeID,PaymentTo,Amount) " +
            //                    " values (@TariffChID,@ChargeCodeID,@PaymentTo,@Amount) " +
            //                    " END  " +
            //                    " ELSE " +
            //                    " UPDATE NVO_PortTariffIHCChargedtls SET TariffChID=@TariffChID,ChargeCodeID=@ChargeCodeID,PaymentTo=@PaymentTo,Amount=@Amount where TariffChID=@TariffChID and ChargeCodeID=@ChargeCodeID and PaymentTo=@PaymentTo";

            //                Cmd.Parameters.Add(_dbFactory.GetParameter("@TariffChID", TariffdtlsID));

            //                string ChargeID = "0"; string PaymentID = "0";
            //                // BREAKUP_CHARGE

            //                DataTable _dtCharge = GetCharges(dtz.Rows[k]["BREAKUP_CHARGE"].ToString());
            //                if (_dtCharge.Rows.Count > 0)
            //                {
            //                    ChargeID = _dtCharge.Rows[0]["ID"].ToString();
            //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtCharge.Rows[0]["ID"].ToString()));
            //                }

            //                else
            //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", 0));

            //                //PAYMENT_TO

            //                DataTable _dtPaymentType = GetPayment(dtz.Rows[k]["PAYMENT_TO"].ToString());
            //                if (_dtPaymentType.Rows.Count > 0)
            //                {
            //                    PaymentID = _dtPaymentType.Rows[0]["ID"].ToString();
            //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentTo", _dtPaymentType.Rows[0]["ID"].ToString()));
            //                }

            //                else
            //                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PaymentTo", 0));



            //                Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", dtz.Rows[k]["AMOUNT"].ToString()));
            //                result = Cmd.ExecuteNonQuery();
            //                Cmd.Parameters.Clear();
            //            }
            //        }

            //    }
            //}
            return dtv;
        }
    
        public DataTable GetPortID(string Name)
        {
            string _Query = "select * from NVO_PortMaster where PortName like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetCities(string Name)
        {
            string _Query = "select * from NVO_CityMaster where CityName like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetCurrency(string Name)
        {
            string _Query = "select * from NVO_CurrencyMaster where CurrencyCode like  '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetChargeType(string Name)
        {
            string _Query = " select * from NVO_GeneralMaster where SeqNo= 34 and GeneralName like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetCommodity(string Name)
        {
            string _Query = " select * from NVO_GeneralMaster where SeqNo= 2 and GeneralName like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetPayment(string Name)
        {
            string _Query = " select * from NVO_GeneralMaster where SeqNo= 51 and GeneralName like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }

        public DataTable GetCntrType(string Name)
        {
            string _Query = "select * from NVO_tblCntrTypes where Size like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }
        public DataTable GetCharges(string Name)
        {
            string _Query = "select * from NVO_ChargeTB where ChgCode like '%" + Name + "%'";
            return GetViewData(_Query, "");
        }


        public DataTable GetIHCMainTable()
        {
            string _Query = " select distinct ICD_Name,(select top(1) ID from NVO_PortMaster where PortName = NVO_TempIHCTariffUpload.Port) as PortID, " +
                            " (select top(1) ID from NVO_GeneralMaster where GeneralName = NVO_TempIHCTariffUpload.CHARGE_TYPE) as ChargeTypeID, " +
                            " (select top(1) ID from NVO_ChargeTB where ChgCode = NVO_TempIHCTariffUpload.Charge) as ChargesID, " +
                            " (select top(1) ID from NVO_tblCntrTypes where Size = NVO_TempIHCTariffUpload.CONTAINER_TYPE) as ContainerTypeID, " +
                            " (select top(1) ID from NVO_GeneralMaster where GeneralName = NVO_TempIHCTariffUpload.Commodity_Type) as CommodityTypeID, " +
                            " case when THC_INCLUDED = 'YES' then 1 else 2 end as THCIncluded,VALID_FROM as ValidFrom,VALID_TILL as ValidTill, " +
                            " case when STATUS = 'ACTIVE' then 1 else 2 end as STATUS,IHCTrfID,(select top(1) ID from NVO_CityMaster where CityName= NVO_TempIHCTariffUpload.ICD_Name) as ICDLocID, " +
                            " Port,CHARGE_TYPE,Charge,CONTAINER_TYPE,Commodity_Type,THC_INCLUDED from NVO_TempIHCTariffUpload";
            return GetViewData(_Query, "");
        }

        public DataTable GetIHCMainTowTable(string ICDName, string PortName,string ChargeType,string Charge,string CntrType,string THCinc,string CommodityType)
        {
            string _Query = " Select distinct IHCTrfID as IHCTariffID,(select top(1) ID from NVO_CurrencyMaster where CurrencyCode= NVO_TempIHCTariffUpload.CURRENCY) as CurrencyID, " +
                            " SLAB_FROM as SlabFrom,SLAB_TO as SlabTo, sum(Amount) as Amt, " +
                            " isnull(( NVO_TempIHCTariffUpload.TID),0 ) AS TID " +
                            " from NVO_TempIHCTariffUpload where ICD_Name='" + ICDName + "' and Port='" + PortName + "' and COMMODITY_TYPE='" + CommodityType + "' and CHARGE_TYPE='" + ChargeType + "' and Charge='" + Charge + "' and CONTAINER_TYPE='" + CntrType + "' and THC_INCLUDED='" + THCinc + "'" +
                            " group by IHCTrfID,CURRENCY,SLAB_FROM,SLAB_TO,TID ";
            return GetViewData(_Query, "");
        }

        public DataTable GetIHCMainThreeTable(string ICDName, string PortName, string ChargeType, string Charge, string CntrType, string THCinc, string CommodityType,string SlPFrom,string SlpTo)
        {
            string _Query = " select IHCTrfID,(select top(1) ID from NVO_ChargeTB where ChgCode=NVO_TempIHCTariffUpload.BREAKUP_CHARGE) as ChargeID, " +
                            " (select top(1) ID from NVO_GeneralMaster where GeneralName = NVO_TempIHCTariffUpload.PAYMENT_TO) as Payment, Amount, " +
                            //" isnull((select top(1)TID from NVO_IHCHaulageTariffDtls where IHCTariffID = IHCTrfID and NVO_IHCHaulageTariffDtls.SlabFrom = NVO_TempIHCTariffUpload.SLAB_FROM),0) as TID, " +
                            "  Port,CHARGE_TYPE,Charge,CONTAINER_TYPE,Commodity_Type,THC_INCLUDED,ICD_Name,SLAB_FROM,SLAB_TO " +
                            " from NVO_TempIHCTariffUpload where  ICD_Name='" + ICDName + "' and Port='" + PortName + "' and CHARGE_TYPE='" + ChargeType + "' and Charge='" + Charge + "' and CONTAINER_TYPE='" + CntrType + "' and COMMODITY_TYPE='" + CommodityType + "' and THC_INCLUDED='" + THCinc + "' and SLAB_FROM=" + SlPFrom + " and SLAB_TO=" + SlpTo;
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

