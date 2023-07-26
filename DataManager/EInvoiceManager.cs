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
using System.Globalization;

namespace DataManager
{
    public class EInvoiceManager
    {


        #region Constructor Method
        public EInvoiceManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        public List<MyEInvoice> AgencyInvoiceDtails(MyEInvoice Data)
        {
            List<MyEInvoice> ViewList = new List<MyEInvoice>();
            DataTable dt = GetInvoiceRecordvalues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyEInvoice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DocumentNo = dt.Rows[i]["FinalInvoice"].ToString(),
                    DocumentDate = dt.Rows[i]["InvDate"].ToString(),
                    IRNStatus = dt.Rows[i]["IRNStatus"].ToString(),
                    IRNGenerateDate = dt.Rows[i]["IRNGenerationDate"].ToString(),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                    CustomerGSTIN = dt.Rows[i]["CustomerGST"].ToString(),
                    TaxAmt = dt.Rows[i]["InvTax"].ToString(),
                    TotalAmt = dt.Rows[i]["InvAmount"].ToString(),
                    TaxableAmt = dt.Rows[i]["InvTotal"].ToString(),
                    CancelledResion = dt.Rows[i]["CancelledReason"].ToString(),
                    IRNNo = dt.Rows[i]["IRN"].ToString(),
                    Selected = "0"

                }) ;
            }
            return ViewList;
        }

        public DataTable GetInvoiceRecordvalues(MyEInvoice Data)
        {
            string _Query = " select Id,FinalInvoice, convert(varchar,InvDate, 103) as InvDate, " +
                            " (select top(1) Case when Status = 'ACT' then 'GENERATED' else 'CANCELLED'END from NVO_EInvoiceGeneration where InvID = NVO_InvoiceCusBilling.Id) as IRNStatus, " +
                            " (select  top(1) convert(varchar, AccDate, 121) from NVO_EInvoiceGeneration where InvID = NVO_InvoiceCusBilling.Id) as IRNGenerationDate, " +
                            " (select  top(1) CustomerName from NVO_EInvoiceGeneration where InvID = NVO_InvoiceCusBilling.Id) as CustomerName, " +
                            " (select  top(1) CustomerGST from NVO_EInvoiceGeneration where InvID = NVO_InvoiceCusBilling.Id) as CustomerGST, InvTax, InvAmount, InvTotal, " +
                            " (select  top(1) CancelledReason from NVO_EInvoiceGeneration where InvID = NVO_InvoiceCusBilling.Id) as CancelledReason, " +
                            " (select  top(1) IRN from NVO_EInvoiceGeneration where InvID = NVO_InvoiceCusBilling.Id) as IRN " +
                            " from NVO_InvoiceCusBilling where Isfinal = 1 and AgentId=" + Data.AgencyID;
            return GetViewData(_Query, "");
        }


        public List<MyEInvoice> InvoiceNoDtails(MyEInvoice Data)
        {
            List<MyEInvoice> ViewList = new List<MyEInvoice>();
            DataTable dt = GetInvoiceNumber(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyEInvoice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DocumentNo = dt.Rows[i]["FinalInvoice"].ToString(),

                });
            }
            return ViewList;
        }
        public DataTable GetInvoiceNumber(MyEInvoice Data)
        {
            string _Query = " select Id,FinalInvoice from NVO_InvoiceCusBilling where Isfinal = 1 and AgentId=" + Data.AgencyID;
            return GetViewData(_Query, "");
        }

        public List<MyEInvoice> InvoiceGSTNo(MyEInvoice Data)
        {
            List<MyEInvoice> ViewList = new List<MyEInvoice>();
            DataTable dt = GetInvoiceGSTNo(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyEInvoice
                {
                    ID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    CustomerGSTIN = dt.Rows[i]["CustomerGSTIN"].ToString(),

                });
            }
            return ViewList;
        }

        public DataTable GetInvoiceGSTNo(MyEInvoice Data)
        {
            string _Query = " Select PartyID,(select  top(1) CustomerGST from NVO_EInvoiceGeneration where InvID = NVO_InvoiceCusBilling.Id) as CustomerGSTIN " +
                            " from NVO_InvoiceCusBilling "+
                            " where Isfinal = 1 and AgentId=" + Data.AgencyID;
            return GetViewData(_Query, "");
        }

        public List<MyEInvoice> InvoiceCountGenerate(MyEInvoice Data)
        {
            List<MyEInvoice> ViewList = new List<MyEInvoice>();
            DataTable dt = GetInvoiceCountGenerate(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyEInvoice
                {
                    Total = dt.Rows[i]["Total"].ToString(),
                    Generated = dt.Rows[i]["Generated"].ToString()

                });
            }
            return ViewList;
        }

        public DataTable GetInvoiceCountGenerate(MyEInvoice Data)
        {
            string _Query = " select count(Id) as Total," +
                            " (select Case when Status = 'ACT' then '1' else '0'END from NVO_EInvoiceGeneration " +
                            " where InvID = NVO_InvoiceCusBilling.Id) as Generated from NVO_InvoiceCusBilling where Isfinal = 1 and AgentId = " + Data.AgencyID +
                            " group by NVO_InvoiceCusBilling.Id";
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
