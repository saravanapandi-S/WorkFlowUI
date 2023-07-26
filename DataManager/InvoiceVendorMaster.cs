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
   public class InvoiceVendorMaster
    {
        #region Constructor Method
        public InvoiceVendorMaster()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        public List<MyInvoiceVendor> InvVendorCustomerMaster()
        {
            List<MyInvoiceVendor> CustomerList = new List<MyInvoiceVendor>();
            DataTable dt = GetVendorMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyInvoiceVendor
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VendorName = dt.Rows[i]["CustomerName"].ToString()
                });
            }
            return CustomerList;
        }

        public DataTable GetVendorMaster()
        {
            string _Query = " select NVO_CustomerMaster.ID,CustomerName from NVO_CustomerMaster inner join NVO_CusBusinessTypes on NVO_CusBusinessTypes.CustomerID = NVO_CustomerMaster.ID " +
                            " where BussTypes in (13, 14, 15, 7, 6)";
            return GetViewData(_Query, "");
        }

        public List<MyInvoiceVendor>VoyageMaster(MyInvoiceVendor Data)
        {
            List<MyInvoiceVendor> CustomerList = new List<MyInvoiceVendor>();
            DataTable dt = GetVoyageMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyInvoiceVendor
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VoyageName = dt.Rows[i]["VoyageNo"].ToString()
                });
            }
            return CustomerList;
        }

        public DataTable GetVoyageMaster(MyInvoiceVendor Data)
        {
            string _Query = "select ID,VoyageNo from NVO_VoyageDetails where VesID=" + Data.VesID;
            return GetViewData(_Query, "");
        }



        public List<MyInvoiceVendorInsert> InsertVendorInvoiceMaster(MyInvoiceVendorInsert Data)
        {
            List<MyInvoiceVendorInsert> List = new List<MyInvoiceVendorInsert>();
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

                    Cmd.CommandText = " IF((select count(*) from NVO_InvoiceVenBilling where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_InvoiceVenBilling(InvoiceNo,InvDate,CurrencyID,InvTax,InvAmount,Remarks,GeoLocID,PartyID,PartyName,UserID,SessionFinYear) " +
                                     " values (@InvoiceNo,@InvDate,@CurrencyID,@InvTax,@InvAmount,@Remarks,@GeoLocID,@PartyID,@PartyName,@UserID,@SessionFinYear) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_InvoiceVenBilling SET InvoiceNo=@InvoiceNo,InvDate=@InvDate,CurrencyID=@CurrencyID,InvTax=@InvTax,InvAmount=@InvAmount,Remarks=@Remarks,GeoLocID=@GeoLocID,PartyID=@PartyID,PartyName=@PartyName,UserID=@UserID,SessionFinYear=@SessionFinYear where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvoiceNo", Data.InvoiceNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvDate", Data.InvDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", Data.CurrencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvTax", Data.InvTax));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InvAmount", Data.InvAmount));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocID", Data.GeoLocID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyID", Data.PartyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyName", Data.PartyName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SessionFinYear", Data.SessionFinYear));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_InvoiceVenBilling')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_InvoiceVenBillingdtls where InvCusBillingID=@InvCusBillingID and ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_InvoiceVenBillingdtls(InvCusBillingID,VesselID,NarrationID,VoyageID,PortID,ContainerNo,CntrTypeID,BLNo,CurrencyID,Amount,TaxPCD,TaxAmt) " +
                                     " values (@InvCusBillingID,@VesselID,@NarrationID,@VoyageID,@PortID,@ContainerNo,@CntrTypeID,@BLNo,@CurrencyID,@Amount,@TaxPCD,@TaxAmt) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_InvoiceVenBillingdtls SET InvCusBillingID=@InvCusBillingID,VesselID=@VesselID,NarrationID=@NarrationID,VoyageID=@VoyageID,PortID=@PortID,ContainerNo=@ContainerNo," +
                                     " CntrTypeID=@CntrTypeID,BLNo=@BLNo,CurrencyID=@CurrencyID,Amount=@Amount,TaxPCD=@TaxPCD,TaxAmt=@TaxAmt where InvCusBillingID=@InvCusBillingID and ID=@ID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@InvCusBillingID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NarrationID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerNo", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrTypeID", CharSplit[10]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNo", CharSplit[11]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[14]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Amount", CharSplit[15]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxPCD", CharSplit[16]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxAmt", CharSplit[17]));
                      
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }


                    trans.Commit();

                    List.Add(new MyInvoiceVendorInsert { ID = Data.ID });
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


        public List<MyInvoiceVendorSearch> VendorInvoiceSearch(MyInvoiceVendorSearch Data)
        {
            List<MyInvoiceVendorSearch> List = new List<MyInvoiceVendorSearch>();
            DataTable dt = GetVendorInvoiceSearch(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List.Add(new MyInvoiceVendorSearch
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    InvDate = dt.Rows[i]["invDate"].ToString(),
                    PartyName = dt.Rows[i]["PartyName"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    InvAmount = dt.Rows[i]["InvAmount"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    Dispute = dt.Rows[i]["Dispute"].ToString(),
                    DisputeDetails = dt.Rows[i]["DisputeDetails"].ToString(),
                    DisputeOn = dt.Rows[i]["DisputeOn"].ToString(),
                    DisputeBy = dt.Rows[i]["DisputeBy"].ToString(),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    FileName = dt.Rows[i]["FileName"].ToString(),

                });
            }
            return List;
        }

        public DataTable GetVendorInvoiceSearch(MyInvoiceVendorSearch Data)
        {
            string strWhere = "";
            string _Query = " select Id,InvoiceNo, convert(varchar,InvDate, 103) as invDate,PartyName, " +
                            " (select top(1) CurrencyCode from NVO_CurrencyMaster where ID = CurrencyID) as Currency, InvAmount,'' as Status, " +
                            " '' Dispute, '' DisputeDetails,'' DisputeOn,'' as DisputeBy,  " +
                            " (select top(1)(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_InvoiceVenBillingdtls.VesselID) " +
                            " from NVO_InvoiceVenBillingdtls where InvCusBillingID = NVO_InvoiceVenBilling.Id) as VesselName,  " +
                            " (select top(1)(select top(1) VoyageNo from NVO_VoyageDetails where NVO_VoyageDetails.ID = NVO_InvoiceVenBillingdtls.VoyageID) " +
                            " from NVO_InvoiceVenBillingdtls where InvCusBillingID = NVO_InvoiceVenBilling.Id) as VoyageNo, '' as FileName from NVO_InvoiceVenBilling";

            if (Data.InvoiceNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where InvoiceNo like'%" + Data.InvoiceNo + "%'";
                else
                    strWhere += " and InvoiceNo like'%" + Data.InvoiceNo + "%'";

            if (Data.PartyName != "")
                if (strWhere == "")
                    strWhere += _Query + " where PartyName like'%" + Data.PartyName + "%'";
                else
                    strWhere += " and PartyName like'%" + Data.PartyName + "%'";


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere + " order by Id desc", "");
        }


        public List<MyInvoiceVendorSearch> VendorInvoiceExisting(MyInvoiceVendorSearch Data)
        {
            List<MyInvoiceVendorSearch> List = new List<MyInvoiceVendorSearch>();
            DataTable dt = GetVendorInvoiceExisting(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List.Add(new MyInvoiceVendorSearch
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    InvDate = dt.Rows[i]["invDatev"].ToString(),
                    PartyID = dt.Rows[i]["PartyId"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    InvAmount = dt.Rows[i]["InvAmount"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString()
                });
            }
            return List;
        }

        public DataTable GetVendorInvoiceExisting(MyInvoiceVendorSearch Data)
        {
            string _Query = "select convert(varchar,invDate, 23) as invDatev, * from NVO_InvoiceVenBilling  where Id=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyInvoiceVendorSearch> VendorInvoiceExistingDtls(MyInvoiceVendorSearch Data)
        {
            List<MyInvoiceVendorSearch> List = new List<MyInvoiceVendorSearch>();
            DataTable dt = GetVendorInvoiceExistingdtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List.Add(new MyInvoiceVendorSearch
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VesselID = dt.Rows[i]["VesselID"].ToString(),
                    VoyageID = dt.Rows[i]["VoyageID"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    PortID = dt.Rows[i]["PortID"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    ContainerNo = dt.Rows[i]["ContainerNo"].ToString(),
                    CntrTypes = dt.Rows[i]["CntrTypes"].ToString(),
                    CntrTypeID = dt.Rows[i]["CntrTypeID"].ToString(),
                    Narration = dt.Rows[i]["Narration"].ToString(),
                    NarrationID = dt.Rows[i]["NarrationID"].ToString(),
                    Currency = dt.Rows[i]["Currency"].ToString(),
                    CurrencyID = dt.Rows[i]["CurrencyID"].ToString(),
                    InvAmount = dt.Rows[i]["Amount"].ToString(),
                    InvTax = dt.Rows[i]["TaxAmt"].ToString(),
                    TaxPCD = dt.Rows[i]["TaxPCD"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    ErrorLog = dt.Rows[i]["Status"].ToString(),
                    BLNo = dt.Rows[i]["BLNo"].ToString(),

                });
            }
            return List;
        }

        public DataTable GetVendorInvoiceExistingdtls(MyInvoiceVendorSearch Data)
        {
            string _Query = " select NVO_InvoiceVenBillingdtls.Id,InvCusBillingID,(select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID = NVO_InvoiceVenBillingdtls.VesselID) as VesselName,VesselID, " +
                            " (select top(1) VoyageNo from NVO_VoyageDetails where NVO_VoyageDetails.Id = VoyageID) as VoyageNo, VoyageID, " +
                            " (select top(1) PortName from NVO_PortMaster where NVO_PortMaster.ID = NVO_InvoiceVenBillingdtls.PortID) as PortName,PortID, " +
                            " ContainerNo,(select top(1) Size from NVO_tblCntrTypes where NVO_tblCntrTypes.ID = NVO_InvoiceVenBillingdtls.CntrTypeID) as CntrTypes, " +
                            " CntrTypeID,BLNo,(select top(1) ChgDesc from NVO_ChargeTB where NVO_ChargeTB.ID = NarrationID) as Narration,NarrationID, " +
                            " (select top(1) CurrencyName from NVO_CurrencyMaster where Id = NVO_InvoiceVenBillingdtls.CurrencyID) as Currency,CurrencyID,Amount,TaxPCD,TaxAmt,Status,ErrorLog from NVO_InvoiceVenBillingdtls " +
                            " where InvCusBillingID=" + Data.ID;
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
