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
  public  class LeaseBillingManager
    {

        #region Constructor Method
        public LeaseBillingManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion
        public List<MyLeaseBilling> LeaseMonitoringBillingView(MyLeaseBilling Data)
        {
            List<MyLeaseBilling> ViewList = new List<MyLeaseBilling>();
            DataTable dt = GetLeaseBillView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLeaseBilling
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ContractRefNo = dt.Rows[i]["ContractRefNo"].ToString(),
                    LeasingPartner = dt.Rows[i]["LeasingPartner"].ToString(),
                    LeaseTerm = dt.Rows[i]["LeaseTerm"].ToString(),
                    PickUpLoc = dt.Rows[i]["PickUpLoc"].ToString(),
                    DropUpLoc = dt.Rows[i]["DropUpLoc"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString(),
                    Equipment = dt.Rows[i]["CntrType"].ToString() + " x " + dt.Rows[i]["Qty"].ToString()




                });
            }
            return ViewList;
        }

        public DataTable GetLeaseBillView(MyLeaseBilling Data)
        {
            string _Query = " select ID,ContractRefNo,(select top(1) CustomerName from NVO_CustomerMaster where ID = LeasingPartnerID) as LeasingPartner, " +
                            " (select top(1) GeneralName from NVO_GeneralMaster where Id = LeaseTermID) as LeaseTerm,  " +
                            " (select top(1) PortName from NVO_PortMaster where Id = PickUpPortID) as PickUpLoc, " +
                            " (select top(1) PortName from NVO_PortMaster where Id = DropOffPortID) as DropUpLoc,FreeDays,CntrType,Qty " +
                            " from NVO_LeaseContract " +
                            " inner join NVO_LeaseDetails on NVO_LeaseDetails.LeaseContractID = NVO_LeaseContract.ID";


            return GetViewData(_Query, "");
        }


        public List<MyLeaseBilling> LeaseMonitoringBillingExisting(MyLeaseBilling Data)
        {
            List<MyLeaseBilling> ViewList = new List<MyLeaseBilling>();
            DataTable dt = GetLeaseBillExisting(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLeaseBilling
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ContractRefNo = dt.Rows[i]["ContractRefNo"].ToString(),
                    LeasingPartner = dt.Rows[i]["LeasingPartner"].ToString(),
                    LeaseTerm = dt.Rows[i]["LeaseTerm"].ToString(),
                    PickUpLoc = dt.Rows[i]["PickUpPort"].ToString(),
                    DropUpLoc = dt.Rows[i]["DropOffPort"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString(),
                    Equipment = dt.Rows[i]["CntrType"].ToString() + " x " + dt.Rows[i]["Qty"].ToString(),
                    PickedUpDepo= dt.Rows[i]["PickUpDepot"].ToString()




                });
            }
            return ViewList;
        }



        public DataTable GetLeaseBillExisting(MyLeaseBilling Data)
        {
            string _Query = " select ID,ContractRefNo,(select top(1) CustomerName from NVO_CustomerMaster where ID = LeasingPartnerID) as LeasingPartner, " +
                            " (select top(1) GeneralName from NVO_GeneralMaster where Id = LeaseTermID) as LeaseTerm,  " +
                            " PickUpPort,PickUpCurr,PickUpDepot,InsCurr,DPPCurr,DropOffPort,DropOffCurr,PerDiemCurr,DropOffDebitID,DropOffDebit,PickUpDebit,PickUpDebitID,FreeDays,CntrType,Qty " +
                            " from NVO_LeaseContract " +
                            " inner join NVO_LeaseDetails on NVO_LeaseDetails.LeaseContractID = NVO_LeaseContract.ID where NVO_LeaseContract.Id=" + Data.ID;


            return GetViewData(_Query, "");
        }


        public List<MyLeaseBilling> LeaseDetailsBillGridExisting(MyLeaseBilling Data)
        {
            List<MyLeaseBilling> ViewList = new List<MyLeaseBilling>();
            DataTable dt = GetLeaseDetailsBillGridExisting(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLeaseBilling
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Description = dt.Rows[i]["Description"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    PickUpDepot = dt.Rows[i]["PickUpDepot"].ToString(),
                    PickUpPort = dt.Rows[i]["PickUpPort"].ToString(),
                    DropOffPort = dt.Rows[i]["DropOffPort"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString(),
                    DropOffDebit = dt.Rows[i]["DropOffDebit"].ToString(),
                    PickedUpDepo = dt.Rows[i]["PickUpDepot"].ToString(),
                    Validity = "12/3/2021",
                    Location = ""




                }) ;
            }
            return ViewList;
        }
        public DataTable GetLeaseDetailsBillGridExisting(MyLeaseBilling Data)
        {
            string _Query = " select NVO_LeaseContract.ID,'ON-Hire' as Description, CntrNo,CntrType,PickUpDepot,PickUpPort,DropOffPort,FreeDays,DropOffDebit " +
                            " from NVO_LeaseContract " +
                            " inner join NVO_LeaseDetails on NVO_LeaseDetails.LeaseContractID = NVO_LeaseContract.ID " +
                            " inner join NVO_Containers on NVO_Containers.PickUpRefID = NVO_LeaseContract.Id " +
                            " where NVO_LeaseContract.ID = " + Data.ID;


            return GetViewData(_Query, "");
        }


        public List<MyLeaseBilling>LeaseDetailsBillRentGrid(MyLeaseBilling Data)
        {
            List<MyLeaseBilling> ViewList = new List<MyLeaseBilling>();
            DataTable dt = GetLeaseBillingRentGrid(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLeaseBilling
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PickUpDebit = dt.Rows[i]["PickUpDebit"].ToString(),
                    Charges = dt.Rows[i]["Charges"].ToString(),
                    ContractRefNo = dt.Rows[i]["ContractRefNo"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    PickupDate = dt.Rows[i]["PickupDate"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString() + " Days",
                    EndofDate = dt.Rows[i]["EndofDate"].ToString(),
                    DropoffDate = dt.Rows[i]["DropoffDate"].ToString(),
                    Preday = dt.Rows[i]["Preday"].ToString(),
                    PerDiemAmt = dt.Rows[i]["PerDiemAmt"].ToString() + " " + dt.Rows[i]["PerDiemCurr"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString()


                }); ;
            }
            return ViewList;
        }


        public DataTable GetLeaseBillingRentGrid(MyLeaseBilling Data)
        {
            string _Query = " select NVO_LeaseContract.ID,PickUpDebit,'Per Diem Rental' as Charges,ContractRefNo,CntrNo," +
                            " CONVERT(varchar, dtContractfrom, 103) as PickupDate,FreeDays,CONVERT(varchar, dtContractTill, 103) as EndofDate," +
                            " 'NOT RETURNED' as DropoffDate, DATEDIFF(Day, dtContractfrom, GETDATE()) as Preday, PerDiemAmt, PerDiemCurr, " +
                            " (DATEDIFF(Day, dtContractfrom, GETDATE())) * PerDiemAmt as Amount,CntrType,PickUpDepot,PickUpPort,DropOffPort,DropOffDebit " +
                            " from NVO_LeaseContract " +
                            " inner join NVO_LeaseDetails on NVO_LeaseDetails.LeaseContractID = NVO_LeaseContract.ID " +
                            " inner join NVO_Containers on NVO_Containers.PickUpRefID = NVO_LeaseContract.Id " +
                            " where NVO_LeaseContract.ID = " + Data.ID;


            return GetViewData(_Query, "");
        }

        public List<MyCommonAccess> ChargeCodeMasterBind()
        {
            List<MyCommonAccess> ChargeList = new List<MyCommonAccess>();
            DataTable dt = GetChargecodeMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargeList.Add(new MyCommonAccess
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ChargeCode = dt.Rows[i]["ChgCode"].ToString()
                });
            }
            return ChargeList;
        }

        public DataTable GetChargecodeMaster()
        {
            string _Query = "select * from NVO_ChargeTB where ID = 14";
            return GetViewData(_Query, "");
        }


        public List<MyLeaseBilling> LeaseDetailsRentGridRetCharges(MyLeaseBilling Data)
        {
            List<MyLeaseBilling> ViewList = new List<MyLeaseBilling>();
            DataTable dt = GetLeaseRentGridRetCharges(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyLeaseBilling
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PickUpDebit = dt.Rows[i]["PickUpDebit"].ToString(),
                    Charges = dt.Rows[i]["Charges"].ToString(),
                    ContractRefNo = dt.Rows[i]["ContractRefNo"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    PickupDate = dt.Rows[i]["PickupDate"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString() + " Days",
                    EndofDate = dt.Rows[i]["EndofDate"].ToString(),
                    DropoffDate = dt.Rows[i]["DropoffDate"].ToString(),
                    Preday = dt.Rows[i]["Preday"].ToString(),
                    PerDiemAmt = dt.Rows[i]["PerDiemAmt"].ToString() + " " + dt.Rows[i]["PerDiemCurr"].ToString(),
                    Amount = dt.Rows[i]["Amount"].ToString()


                }); ;
            }
            return ViewList;
        }

        public DataTable GetLeaseRentGridRetCharges(MyLeaseBilling Data)
        {
            string _Query = " select NVO_LeaseContract.ID,PickUpDebit,'Per Diem Rental' as Charges,ContractRefNo,CntrNo," +
                            " CONVERT(varchar, '" + DateTime.Parse(Data.FDate).ToString("dd/MM/yyyy") + "', 103) as PickupDate,FreeDays,CONVERT(varchar, '" + DateTime.Parse(Data.ToDate).ToString("dd/MM/yyyy") + "', 103) as EndofDate," +
                            " 'NOT RETURNED' as DropoffDate, DATEDIFF(Day, '" + Data.FDate + "', '" + Data.ToDate + "') as Preday, PerDiemAmt, PerDiemCurr, " +
                            " (DATEDIFF(Day, '" + Data.FDate + "', '" + Data.ToDate + "')) * PerDiemAmt as Amount,CntrType,PickUpDepot,PickUpPort,DropOffPort,DropOffDebit " +
                            " from NVO_LeaseContract " +
                            " inner join NVO_LeaseDetails on NVO_LeaseDetails.LeaseContractID = NVO_LeaseContract.ID " +
                            " inner join NVO_Containers on NVO_Containers.PickUpRefID = NVO_LeaseContract.Id " +
                            " where NVO_LeaseContract.ID = " + Data.ID;


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
