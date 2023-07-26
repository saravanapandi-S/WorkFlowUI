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
  public class InvoiceManager
    {
        

        #region Constructor Method
        public InvoiceManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion
        #region GetView
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
        #endregion


        public List<MyInvoice> OfficeLocationMaster()
        {
            List<MyInvoice> CustomerList = new List<MyInvoice>();
            DataTable dt = GetLocationMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyInvoice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["OfficeLoc"].ToString().ToUpper()
                });
            }
            return CustomerList;
        }

        public DataTable GetLocationMaster()
        {
            string _Query = " select * from NVO_OfficeMaster";
            return GetViewData(_Query, "");
        }

        public List<MyInvoice> OfficeTaxGSTNo(MyInvoice Data)
        {
            List<MyInvoice> CustomerList = new List<MyInvoice>();
            DataTable dt = GetOfficeTaxGSTNo(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyInvoice
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TaxGSTNo = dt.Rows[i]["TaxGSTNo"].ToString().ToUpper()
                });
            }
            return CustomerList;
        }

        public DataTable GetOfficeTaxGSTNo(MyInvoice Data)
        {
            string _Query = " select * from NVO_OfficeMaster where ID= " + Data.GSTID;
            return GetViewData(_Query, "");
        }


        public List<MyInvoice> CustomerNameList(MyInvoice Data)
        {
            List<MyInvoice> CustomerList = new List<MyInvoice>();
            DataTable dt = GetCustomerNameList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyInvoice
                {
                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    PartyName = dt.Rows[i]["CustomerName"].ToString().ToUpper(),
                });
            }
            return CustomerList;
        }

        public DataTable GetCustomerNameList(MyInvoice Data)
        {
            string _Query = " select * from NVO_view_CustomerDetails ";
            return GetViewData(_Query, "");
        }


        public List<MyInvoice> CustomerBranchCode(MyInvoice Data)
        {
            List<MyInvoice> CustomerList = new List<MyInvoice>();
            DataTable dt = GetCustomerBranchCode(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyInvoice
                {
                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    Branch = dt.Rows[i]["Branch"].ToString().ToUpper(),
                    GSTIN = dt.Rows[i]["GSTIN"].ToString().ToUpper(),
                });
            }
            return CustomerList;
        }

        public DataTable GetCustomerBranchCode(MyInvoice Data)
        {
            string _Query = " select CID,Branch,GSTIN from NVO_CusBranchLocation where CID= " + Data.PartyBranch;
            return GetViewData(_Query, "");
        }

        public List<MyInvoice> CustomerGSTIN(MyInvoice Data)
        {
            List<MyInvoice> CustomerList = new List<MyInvoice>();
            DataTable dt = GetCustomerGSTIN(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyInvoice
                {
                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    GSTIN = dt.Rows[i]["GSTIN"].ToString().ToUpper(),
                });
            }
            return CustomerList;
        }

        public DataTable GetCustomerGSTIN(MyInvoice Data)
        {
            string _Query = " select CID,GSTIN from NVO_CusBranchLocation where CID= " + Data.PartyGST;
            return GetViewData(_Query, "");
        }

        public List<MyInvoice> CustomerAddress(MyInvoice Data)
        {
            List<MyInvoice> CustomerList = new List<MyInvoice>();
            DataTable dt = GetCustomerAddress(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyInvoice
                {
                    ID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    Address = dt.Rows[i]["Address"].ToString().ToUpper(),
                });
            }
            return CustomerList;
        }

        public DataTable GetCustomerAddress(MyInvoice Data)
        {
            string _Query = " select CID,Address from NVO_CusBranchLocation where CID= " + Data.PartyGST;
            return GetViewData(_Query, "");
        }



        public List<MyInvoice> InvoiceChargeCode(MyInvoice Data)
        {
            List<MyInvoice> CustomerList = new List<MyInvoice>();
            DataTable dt = GetInvoiceChargeCode(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyInvoice
                {
                    ID = Int32.Parse(dt.Rows[i]["ChargesId"].ToString()),
                    ChargeName = dt.Rows[i]["ChargeName"].ToString().ToUpper(),
                });
            }
            return CustomerList;
        }

        public DataTable GetInvoiceChargeCode(MyInvoice Data)
        {
            string _Query = " select dbo.charge.ChargesId,ChargeName from dbo.charge " +
                "inner join dbo.ChargeDetail on dbo.ChargeDetail.ChargesId = dbo.charge.ChargesId " +
                "where dbo.ChargeDetail.DivisionID = 1 and IsActive = 1 ";

            return GetViewData(_Query, "");
        }


        public List<MyInvoice> CustomerGSTCategory(MyInvoice Data)
        {
            List<MyInvoice> CustomerList = new List<MyInvoice>();
            DataTable dt = GetCustomerGSTCategory(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerList.Add(new MyInvoice
                {
                    ID = Int32.Parse(dt.Rows[i]["GSTCategoryID"].ToString()),
                    GSTCategory = dt.Rows[i]["GSTCategory"].ToString().ToUpper(),
                });
            }
            return CustomerList;
        }

        public DataTable GetCustomerGSTCategory(MyInvoice Data)
        {
            string _Query = " select * from dbo.GSTCategory ";
            return GetViewData(_Query, "");
        }


    }
}
