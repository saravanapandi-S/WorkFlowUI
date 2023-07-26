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
    public class VendorBillUpload
    {
        #region Constructor Method
        public VendorBillUpload()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        public DataTable InsertPortBillTariffChangeExcelUploading(DataTable dtv)
        {
            string ChargeTB = "0";

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
                    dt = dts.ToTable(true, "ID", "VesVoy", "BLNo", "ContainerNo", "Charges", "Currency", "Amount", "ExRate", "LocalAmount", "TaxPercentage", "TaxAmount", "NetAmount", "Result", "Status");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ID"].ToString() != "")
                        {

                            if (dt.Rows[i]["ID"].ToString() == "0")
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_TempPortBillUpload where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_TempPortBillUpload(VesVoy,BLNo,ContainerNo,Charges,Currency,Amount,LocalAmount,TaxPercentage,TaxAmount,NetAmount,ROE,BLID,ChargeCodeID,BkgID,CntrID) " +
                                     " values (@VesVoy,@BLNo,@ContainerNo,@Charges,@Currency,@Amount,@LocalAmount,@TaxPercentage,@TaxAmount,@NetAmount,@ROE,@BLID,@ChargeCodeID,@BkgID,@CntrID) " +

                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_TempPortBillUpload SET VesVoy=@VesVoy,BLNo=@BLNo,ContainerNo=@ContainerNo,Charges=@Charges,Currency=@Currency,Amount=@Amount,LocalAmount=@LocalAmount, TaxPercentage=@TaxPercentage,TaxAmount=@TaxAmount,NetAmount=@NetAmount,ROE=@ROE,BLID=@BLID,ChargeCodeID=@ChargeCodeID,BkgID=@BkgID,CntrID=@CntrID where ID=@ID";


                                dt.Rows[i]["Result"] = "Y";
                                dt.Rows[i]["Status"] = "PortBill Upload has been Created";
                            }
                            else
                            {
                                Cmd.CommandText = " IF((select count(*) from NVO_TempPortBillUpload where ID=@ID)<=0) " +
                                   " BEGIN " +
                                   " INSERT INTO  NVO_TempPortBillUpload(VesVoy,BLNo,ContainerNo,Charges,Currency,Amount,LocalAmount,TaxPercentage,TaxAmount,NetAmount,ROE,BLID,ChargeCodeID,BkgID,CntrID) " +
                                   " values (@VesVoy,@BLNo,@ContainerNo,@Charges,@Currency,@Amount,@LocalAmount,@TaxPercentage,@TaxAmount,@NetAmount,@ROE,@BLID,@ChargeCodeID,@BkgID,@CntrID) " +

                                   " END  " +
                                   " ELSE " +
                                   " UPDATE NVO_TempPortBillUpload SET VesVoy=@VesVoy,BLNo=@BLNo,ContainerNo=@ContainerNo,Charges=@Charges,Currency=@Currency,Amount=@Amount,LocalAmount=@LocalAmount, TaxPercentage=@TaxPercentage,TaxAmount=@TaxAmount,NetAmount=@NetAmount,ROE=@ROE,BLID=@BLID,ChargeCodeID=@ChargeCodeID,BkgID=@BkgID,CntrID=@CntrID  where ID=@ID";

                                dt.Rows[i]["Result"] = "Y";
                                dt.Rows[i]["Status"] = "PortBill Upload has been Updated";
                            }

                            DataTable _dtbl = GetBLS(dt.Rows[i]["BLNo"].ToString());
                            if (_dtbl.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", _dtbl.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", 0));

                            DataTable _dtBkg = GetBookings(dt.Rows[i]["BLNo"].ToString());
                            if (_dtBkg.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", _dtBkg.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@BkgID", 0));

                            DataTable _dtChg = GetChargeCodes(dt.Rows[i]["Charges"].ToString());
                            if (_dtChg.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", _dtChg.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ChargeCodeID", 0));

                            DataTable _dtcntrs = GetContainerNos(dt.Rows[i]["ContainerNo"].ToString());
                            if (_dtcntrs.Rows.Count > 0)
                            {
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", _dtcntrs.Rows[0]["ID"].ToString()));

                            }
                            else
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", 0));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", dt.Rows[i]["ID"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VesVoy", dt.Rows[i]["VesVoy"].ToString()));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNo", dt.Rows[i]["BLNo"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerNo", dt.Rows[i]["ContainerNo"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Charges", dt.Rows[i]["Charges"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Currency", dt.Rows[i]["Currency"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", dt.Rows[i]["Amount"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ROE", dt.Rows[i]["ExRate"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@LocalAmount", dt.Rows[i]["LocalAmount"].ToString()));

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxPercentage", dt.Rows[i]["TaxPercentage"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxAmount", dt.Rows[i]["TaxAmount"].ToString()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NetAmount", dt.Rows[i]["NetAmount"].ToString()));

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

        public DataTable GetBLS(string Name)
        {
            string _Query = "select * from NVO_BOL where BLNumber like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetBookings(string Name)
        {
            string _Query = "select * from NVO_Booking where BookingNo like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetChargeCodes(string Name)
        {
            string _Query = "select * from NVO_ChargeTB where ChgDesc like  '" + Name + "'";
            return GetViewData(_Query, "");
        }
        public DataTable GetContainerNos(string Name)
        {
            string _Query = "select * from NVO_Containers where CntrNo like  '" + Name + "'";
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
