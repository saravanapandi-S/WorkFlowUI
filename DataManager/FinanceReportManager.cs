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
  public  class FinanceReportManager
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public FinanceReportManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region FinanceReport

        public List<MyFinanceReportData> StatementOfAccReport(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = GetStatementOfAccountDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                    CreditDays = dt.Rows[i]["CreditDays"].ToString(),
                    Balance = dt.Rows[i]["DebitAmt"].ToString(),
                    InvoiceBalance = dt.Rows[i]["CreditAmt"].ToString(),
                    TotalBalance = dt.Rows[i]["BalanceAmt"].ToString(),

                });
            }
            return ReportList;
        }
        public DataTable GetStatementOfAccountDtls(MyFinanceReportData Data)
        {
            string _Query = "Select distinct CustomerName,PartyID,(select top(1) CusCreditDays from NVO_FinCustomerCreditControl where PartyID = Nav_Acc_Rep_AccountSummary.PartyID) as CreditDays, " +
                            " isnull((select sum(DebitAmt) from Nav_Acc_Rep_AccountSummary RepDebit where RepDebit.PartyID = Nav_Acc_Rep_AccountSummary.PartyID),0.00) as DebitAmt, " +
                            " isnull((select sum(CreditAmt) from Nav_Acc_Rep_AccountSummary RepDebit where RepDebit.PartyID = Nav_Acc_Rep_AccountSummary.PartyID),0.00) as CreditAmt, " +
                            " ((isnull((select sum(DebitAmt) from Nav_Acc_Rep_AccountSummary RepDebit where RepDebit.PartyID = Nav_Acc_Rep_AccountSummary.PartyID), 0.00)) - " +
                            " (isnull((select sum(CreditAmt) from Nav_Acc_Rep_AccountSummary RepDebit where RepDebit.PartyID = Nav_Acc_Rep_AccountSummary.PartyID), 0.00))) as BalanceAmt " +
                            " from Nav_Acc_Rep_AccountSummary";
            return GetViewData(_Query, "");
        }

        public List<MyFinanceReportData> CustomersDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = CustomerValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                });
            }
            return ReportList;
        }
        public DataTable CustomerValues(MyFinanceReportData Data)
        {
            string _Query = "select distinct PartyID,CustomerName  from Nav_Acc_Rep_AccountSummary";
            return GetViewData(_Query, "");
        }

        public List<MyFinanceReportData> CustomerWiseDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = CustomersByID(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                    CreditDays = dt.Rows[i]["CreditDays"].ToString(),
                    Balance = dt.Rows[i]["DebitAmt"].ToString(),
                    InvoiceBalance = dt.Rows[i]["CreditAmt"].ToString(),
                    TotalBalance = dt.Rows[i]["BalanceAmt"].ToString(),

                });
            }
            return ReportList;
        }
        public DataTable CustomersByID(MyFinanceReportData Data)
        {
            string _Query = "Select distinct CustomerName,PartyID,(select top(1) CusCreditDays from NVO_FinCustomerCreditControl where PartyID = Nav_Acc_Rep_AccountSummary.PartyID) as CreditDays, " +
                            " isnull((select sum(DebitAmt) from Nav_Acc_Rep_AccountSummary RepDebit where RepDebit.PartyID = Nav_Acc_Rep_AccountSummary.PartyID),0.00) as DebitAmt, " +
                            " isnull((select sum(CreditAmt) from Nav_Acc_Rep_AccountSummary RepDebit where RepDebit.PartyID = Nav_Acc_Rep_AccountSummary.PartyID),0.00) as CreditAmt, " +
                            " ((isnull((select sum(DebitAmt) from Nav_Acc_Rep_AccountSummary RepDebit where RepDebit.PartyID = Nav_Acc_Rep_AccountSummary.PartyID), 0.00)) - " +
                            " (isnull((select sum(CreditAmt) from Nav_Acc_Rep_AccountSummary RepDebit where RepDebit.PartyID = Nav_Acc_Rep_AccountSummary.PartyID), 0.00))) as BalanceAmt " +
                            " from Nav_Acc_Rep_AccountSummary where PartyID=" + Data.PartyID;
            return GetViewData(_Query, "");
        }

        public List<MyFinanceReportData> CustomerViewDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = CustomersDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    Address = dt.Rows[i]["CustomerAddress"].ToString(),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                    CreditDays = dt.Rows[i]["CreditDays"].ToString(),
                    Balance = dt.Rows[i]["DebitAmt"].ToString(),
                    InvoiceBalance = dt.Rows[i]["CreditAmt"].ToString(),
                    TotalBalance = dt.Rows[i]["BalanceAmt"].ToString(),

                });
            }
            return ReportList;
        }
        public DataTable CustomersDtls(MyFinanceReportData Data)
        {
            string _Query = "Select distinct CustomerName,PartyID,(select top(1) CusCreditDays from NVO_FinCustomerCreditControl where PartyID = Nav_Acc_Rep_AccountSummary.PartyID) as CreditDays, " +
                            " (select Top(1) Address  from NVO_CusBranchLocation where CustomerID= Nav_Acc_Rep_AccountSummary.PartyID)as CustomerAddress, " +
                            " isnull((select sum(DebitAmt) from Nav_Acc_Rep_AccountSummary RepDebit where RepDebit.PartyID = Nav_Acc_Rep_AccountSummary.PartyID),0.00) as DebitAmt, " +
                            " isnull((select sum(CreditAmt) from Nav_Acc_Rep_AccountSummary RepDebit where RepDebit.PartyID = Nav_Acc_Rep_AccountSummary.PartyID),0.00) as CreditAmt, " +
                            " ((isnull((select sum(DebitAmt) from Nav_Acc_Rep_AccountSummary RepDebit where RepDebit.PartyID = Nav_Acc_Rep_AccountSummary.PartyID), 0.00)) - " +
                            " (isnull((select sum(CreditAmt) from Nav_Acc_Rep_AccountSummary RepDebit where RepDebit.PartyID = Nav_Acc_Rep_AccountSummary.PartyID), 0.00))) as BalanceAmt " +
                            " from Nav_Acc_Rep_AccountSummary where PartyID=" + Data.PartyID;
            return GetViewData(_Query, "");
        }
        public List<MyFinanceReportData> CustomerInvoiceDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = CusInvDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    InvDate = dt.Rows[i]["InvDate"].ToString(),
                    InvAmt = dt.Rows[i]["InvAmount"].ToString(),
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    InvID = dt.Rows[i]["ID"].ToString()
                });
            }
            return ReportList;
        }
        public DataTable CusInvDtls(MyFinanceReportData Data)
        {
            string _Query = "select  ID,FinalInvoice,PartyID,InvoiceNo,Convert(varchar, InvDate, 106)as InvDate,InvAmount,InvTotal from NVO_InvoiceCusBilling where PartyID=" + Data.PartyID;
            return GetViewData(_Query, "");
        }

        public List<MyFinanceReportData> CustomerReceiptDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = CusReceiptDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                    ReceiptDate = dt.Rows[i]["ReceiptDate"].ToString(),
                    LocalAmount = dt.Rows[i]["LocalAmount"].ToString(),
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    BalDue = dt.Rows[i]["BalDue"].ToString(),
                    RecID = dt.Rows[i]["ID"].ToString()
                });
            }
            return ReportList;
        }
        public DataTable CusReceiptDtls(MyFinanceReportData Data)
        {
            string _Query = "select ID,ReceiptNo,PartyID,Convert(varchar, DtReceipt, 106)as ReceiptDate,LocalAmount, " +
                            " (select Top(1) InvTotal  from NVO_InvoiceCusBilling where NVO_InvoiceCusBilling.ID = NVO_ReceiptBL.InvCusBillingId) as InvTotal, " +
                            " (LocalAmount - (select Top(1) InvTotal  from NVO_InvoiceCusBilling where NVO_InvoiceCusBilling.ID = NVO_ReceiptBL.InvCusBillingId))as BalDue " +
                            " from NVO_Receipts inner join NVO_ReceiptBL On NVO_ReceiptBL.ReceiptID = NVO_Receipts.ID " +
                            " where PartyID =" + Data.PartyID;
            return GetViewData(_Query, "");
        }
        public List<MyFinanceReportData> CustomerInvoiceListDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = CustomerInvoiceDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    InvID = dt.Rows[i]["ID"].ToString(),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    PartyName = dt.Rows[i]["PartyName"].ToString(),
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    InvDate = dt.Rows[i]["InvDate"].ToString(),
                });
            }
            return ReportList;
        }
        public DataTable CustomerInvoiceDtls(MyFinanceReportData Data)
        {
            string _Query = "select ID,FinalInvoice,InvoiceNo,PartyID,PartyName,InvTotal,Convert(varchar, InvDate, 23)as InvDate from NVO_InvoiceCusBilling where PartyID =" + Data.PartyID;

            return GetViewData(_Query, "");
        }

        public List<MyFinanceReportData> CustomerInvoiceListChangeDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = CustomerInvoiceChangeDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    InvID = dt.Rows[i]["ID"].ToString(),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    PartyName = dt.Rows[i]["PartyName"].ToString(),
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    InvDate = dt.Rows[i]["InvDate"].ToString(),
                });
            }
            return ReportList;
        }
        public DataTable CustomerInvoiceChangeDtls(MyFinanceReportData Data)
        {
            string _Query = "select ID,FinalInvoice,InvoiceNo,PartyID,PartyName,InvTotal,Convert(varchar, InvDate, 23)as InvDate from NVO_InvoiceCusBilling where ID=" + Data.InvID;

            return GetViewData(_Query, "");
        }

        public List<MyFinanceReportData> CustomerReceiptListDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = CustomerRecpDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    RecID = dt.Rows[i]["ID"].ToString(),
                    ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    PartyName = dt.Rows[i]["PartyName"].ToString(),
                    LocalAmount = dt.Rows[i]["Amount"].ToString(),
                    RecpDate = dt.Rows[i]["RecpDate"].ToString()
                });
            }
            return ReportList;
        }
        public DataTable CustomerRecpDtls(MyFinanceReportData Data)
        {
            string _Query = "select ID,ReceiptNo,PartyID,PartyName,Convert(varchar, DtReceipt, 23)as RecpDate,Amount  from NVO_Receipts where PartyID =" + Data.PartyID;

            return GetViewData(_Query, "");
        }


        //Accounts Receivable
        public List<MyFinanceReportData> AccountsReceivableReport(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = GetAccReceivableDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    CustomerName = dt.Rows[i]["PartyName"].ToString(),
                    InvAmt = dt.Rows[i]["InoiceAmount"].ToString(),
                    ReceivedAmt = dt.Rows[i]["SettledAmount"].ToString(),
                    TotalBalance = dt.Rows[i]["BalanceAmt"].ToString(),
                    CreditDays = dt.Rows[i]["OutStandingDay"].ToString()
                });
            }
            return ReportList;
        }
        public DataTable GetAccReceivableDtls(MyFinanceReportData Data)
        {
            string _Query = "select PartyID,PartyName,InoiceAmount,SettledAmount,BalanceAmt,OutStandingDay from NVO_V_AccountReceivableNew";
            return GetViewData(_Query, "");
        }


        public List<MyFinanceReportData> AccReceivableViewDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = AccReceivableDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    CustomerName = dt.Rows[i]["PartyName"].ToString(),
                    Address = dt.Rows[i]["CustomerAddress"].ToString(),
                    InvAmt = dt.Rows[i]["InoiceAmount"].ToString(),
                    Balance = dt.Rows[i]["SettledAmount"].ToString(),
                    TotalBalance = dt.Rows[i]["BalanceAmt"].ToString()

                });
            }
            return ReportList;
        }
        public DataTable AccReceivableDtls(MyFinanceReportData Data)
        {
            string _Query = "select PartyID,PartyName,InoiceAmount,SettledAmount,BalanceAmt," +
                            " (select Top(1) Address  from NVO_CusBranchLocation where CustomerID= NVO_V_AccountReceivableNew.PartyID)as CustomerAddress from NVO_V_AccountReceivableNew where PartyID=" + Data.PartyID;
            return GetViewData(_Query, "");
        }

        public List<MyFinanceReportData> AccRecInvoiceDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = AccRecInvDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    InvDate = dt.Rows[i]["invDatev"].ToString(),
                    InvAmt = dt.Rows[i]["InoiceAmount"].ToString(),
                    Balance = dt.Rows[i]["BalanceAmt"].ToString(),
                    InvID = dt.Rows[i]["ID"].ToString(),
                    PartyName = dt.Rows[i]["PartyName"].ToString()
                });
            }
            return ReportList;
        }
        public DataTable AccRecInvDtls(MyFinanceReportData Data)
        {
            string _Query = "select Id, PartyID,PartyName,InoiceAmount,SettledAmount,BalanceAmt,InvoiceNo,invDatev from NVO_V_AccountReceivableNew where PartyID=" + Data.PartyID;
            return GetViewData(_Query, "");
        }


        public List<MyFinanceReportData> ReceivableReceiptListDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = ReceivableRecpDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    RecID = dt.Rows[i]["ID"].ToString(),
                    ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    PartyName = dt.Rows[i]["PartyName"].ToString(),
                    LocalAmount = dt.Rows[i]["Amount"].ToString(),
                    RecpDate = dt.Rows[i]["RecpDate"].ToString()
                });
            }
            return ReportList;
        }
        public DataTable ReceivableRecpDtls(MyFinanceReportData Data)
        {
            string _Query = "select ID,ReceiptNo,PartyID,PartyName,Convert(varchar, DtReceipt, 23)as RecpDate,Amount  from NVO_Receipts where PartyID =" + Data.PartyID;

            return GetViewData(_Query, "");
        }
        public List<MyFinanceReportData> ReceivableReceiptDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = RecReceiptDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                    ReceiptDate = dt.Rows[i]["ReceiptDate"].ToString(),
                    LocalAmount = dt.Rows[i]["LocalAmount"].ToString(),
                    InvTotal = dt.Rows[i]["InvTotal"].ToString(),
                    BalDue = dt.Rows[i]["BalDue"].ToString(),
                    RecID = dt.Rows[i]["ID"].ToString()
                });
            }
            return ReportList;
        }
        public DataTable RecReceiptDtls(MyFinanceReportData Data)
        {
            string _Query = "select ID,ReceiptNo,PartyID,Convert(varchar, DtReceipt, 106)as ReceiptDate,LocalAmount, " +
                            " (select Top(1) InvTotal  from NVO_InvoiceCusBilling where NVO_InvoiceCusBilling.ID = NVO_ReceiptBL.InvCusBillingId) as InvTotal, " +
                            " (LocalAmount - (select Top(1) InvTotal  from NVO_InvoiceCusBilling where NVO_InvoiceCusBilling.ID = NVO_ReceiptBL.InvCusBillingId))as BalDue " +
                            " from NVO_Receipts inner join NVO_ReceiptBL On NVO_ReceiptBL.ReceiptID = NVO_Receipts.ID " +
                            " where PartyID =" + Data.PartyID;
            return GetViewData(_Query, "");
        }
        public List<MyFinanceReportData> ReceivableCustomersDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = ReceivableCustomerValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    CustomerName = dt.Rows[i]["PartyName"].ToString(),
                });
            }
            return ReportList;
        }
        public DataTable ReceivableCustomerValues(MyFinanceReportData Data)
        {
            string _Query = "select distinct PartyID,PartyName  from NVO_V_AccountReceivableNew";
            return GetViewData(_Query, "");
        }

        public List<MyFinanceReportData> ReceivableCustomerViewDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = ReceivableCustomersDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    CustomerName = dt.Rows[i]["PartyName"].ToString(),
                    InvAmt = dt.Rows[i]["InoiceAmount"].ToString(),
                    ReceivedAmt = dt.Rows[i]["SettledAmount"].ToString(),
                    TotalBalance = dt.Rows[i]["BalanceAmt"].ToString(),
                    CreditDays = dt.Rows[i]["OutStandingDay"].ToString()

                });
            }
            return ReportList;
        }
        public DataTable ReceivableCustomersDtls(MyFinanceReportData Data)
        {
            string _Query = "select PartyID,PartyName,InoiceAmount,SettledAmount,BalanceAmt,OutStandingDay from NVO_V_AccountReceivableNew where PartyID=" + Data.PartyID;
            return GetViewData(_Query, "");
        }

        //Accounts Payable
        public List<MyFinanceReportData> AccountsPayableReport(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = GetAccPayableDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    CustomerName = dt.Rows[i]["PartyName"].ToString(),
                    InvAmt = dt.Rows[i]["InoiceAmount"].ToString(),
                    ReceivedAmt = dt.Rows[i]["SettledAmount"].ToString(),
                    TotalBalance = dt.Rows[i]["BalanceAmt"].ToString(),
                    CreditDays = dt.Rows[i]["OutStandingDay"].ToString()
                });
            }
            return ReportList;
        }
        public DataTable GetAccPayableDtls(MyFinanceReportData Data)
        {
            string _Query = "select PartyID,PartyName,InoiceAmount,SettledAmount,BalanceAmt,OutStandingDay from NVO_V_AccountPayableNew";
            return GetViewData(_Query, "");
        }


        public List<MyFinanceReportData> AccPayableViewDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = AccPayableDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    CustomerName = dt.Rows[i]["PartyName"].ToString(),
                    Address = dt.Rows[i]["CustomerAddress"].ToString(),
                    InvAmt = dt.Rows[i]["InoiceAmount"].ToString(),
                    Balance = dt.Rows[i]["SettledAmount"].ToString(),
                    TotalBalance = dt.Rows[i]["BalanceAmt"].ToString()

                });
            }
            return ReportList;
        }
        public DataTable AccPayableDtls(MyFinanceReportData Data)
        {
            string _Query = "select PartyID,PartyName,InoiceAmount,SettledAmount,BalanceAmt," +
                            " (select Top(1) Address  from NVO_CusBranchLocation where CustomerID= NVO_V_AccountPayableNew.PartyID)as CustomerAddress from NVO_V_AccountPayableNew where PartyID=" + Data.PartyID;
            return GetViewData(_Query, "");
        }

        public List<MyFinanceReportData> AccPayInvoiceDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = AccPayInvDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    InvDate = dt.Rows[i]["invDatev"].ToString(),
                    InvAmt = dt.Rows[i]["InoiceAmount"].ToString(),
                    Balance = dt.Rows[i]["BalanceAmt"].ToString(),
                    InvID = dt.Rows[i]["ID"].ToString(),
                    PartyName = dt.Rows[i]["PartyName"].ToString()
                });
            }
            return ReportList;
        }
        public DataTable AccPayInvDtls(MyFinanceReportData Data)
        {
            string _Query = "select Id, PartyID,PartyName,InoiceAmount,SettledAmount,BalanceAmt,InvoiceNo,invDatev from NVO_V_AccountPayableNew where PartyID=" + Data.PartyID;
            return GetViewData(_Query, "");
        }

        public List<MyFinanceReportData> AccPayReceiptDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = AccPayReceiptDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    RecID = dt.Rows[i]["ID"].ToString(),
                    ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    PartyName = dt.Rows[i]["PartyName"].ToString(),
                    LocalAmount = dt.Rows[i]["Amount"].ToString(),
                    RecpDate = dt.Rows[i]["RecpDate"].ToString()
                });
            }
            return ReportList;
        }
        public DataTable AccPayReceiptDtls(MyFinanceReportData Data)
        {
            string _Query = "select ID,ReceiptNo,PartyID,PartyName,Convert(varchar, DtReceipt, 23)as RecpDate,Amount  from NVO_Receipts where PartyID =" + Data.PartyID;
            return GetViewData(_Query, "");
        }

        public List<MyFinanceReportData> AccPayInvoiceListDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = AccPayInvoiceDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    RecID = dt.Rows[i]["ID"].ToString(),
                    ReceiptNo = dt.Rows[i]["ReceiptNo"].ToString(),
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    PartyName = dt.Rows[i]["PartyName"].ToString(),
                    LocalAmount = dt.Rows[i]["Amount"].ToString(),
                    RecpDate = dt.Rows[i]["RecpDate"].ToString()
                });
            }
            return ReportList;
        }
        public DataTable AccPayInvoiceDtls(MyFinanceReportData Data)
        {
            string _Query = "select ID,ReceiptNo,PartyID,PartyName,Convert(varchar, DtReceipt, 23)as RecpDate,Amount  from NVO_Payments where PartyID =" + Data.PartyID;

            return GetViewData(_Query, "");
        }

        public List<MyFinanceReportData> PayableCustomersDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = PayableCustomerValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    CustomerName = dt.Rows[i]["PartyName"].ToString(),
                });
            }
            return ReportList;
        }
        public DataTable PayableCustomerValues(MyFinanceReportData Data)
        {
            string _Query = "select distinct PartyID,PartyName  from NVO_V_AccountPayableNew";
            return GetViewData(_Query, "");
        }

        public List<MyFinanceReportData> PayableCustomerViewDetails(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = PayableCustomersDtls(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    CustomerName = dt.Rows[i]["PartyName"].ToString(),
                    InvAmt = dt.Rows[i]["InoiceAmount"].ToString(),
                    ReceivedAmt = dt.Rows[i]["SettledAmount"].ToString(),
                    TotalBalance = dt.Rows[i]["BalanceAmt"].ToString(),
                    CreditDays = dt.Rows[i]["OutStandingDay"].ToString()

                });
            }
            return ReportList;
        }
        public DataTable PayableCustomersDtls(MyFinanceReportData Data)
        {
            string _Query = "select PartyID,PartyName,InoiceAmount,SettledAmount,BalanceAmt,OutStandingDay from NVO_V_AccountPayableNew where PartyID=" + Data.PartyID;
            return GetViewData(_Query, "");
        }

        #endregion

        #region Customer OutStanding Report

        public List<MyFinanceReportData> CustomerOutStandingDtls(MyFinanceReportData Data)
        {
            List<MyFinanceReportData> ReportList = new List<MyFinanceReportData>();
            DataTable dt = CustomerOutStandingValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReportList.Add(new MyFinanceReportData
                {
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),

                });
            }
            return ReportList;
        }
        public DataTable CustomerOutStandingValues(MyFinanceReportData Data)
        {
            string _Query = "select distinct PartyID,CustomerName from Nav_Acc_Rep_AccountSummary";
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
