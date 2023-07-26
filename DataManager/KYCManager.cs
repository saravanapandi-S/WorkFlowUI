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
    public class KYCManager
    {
        List<MyKYC> ListKYC = new List<MyKYC>();
        

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public KYCManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        public List<MyKYC> KYCCustomerMaster(MyKYC Data)
        {
            DataTable dt = GetKYCValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListKYC.Add(new MyKYC
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    CityName = dt.Rows[i]["CityName"].ToString(),
                    StateName = dt.Rows[i]["StateName"].ToString(),
                    PinCode = dt.Rows[i]["PinCode"].ToString(),
                    TelNo = dt.Rows[i]["TelNo"].ToString(),
                    FaxNo = dt.Rows[i]["FaxNo"].ToString(),
                    MailId = dt.Rows[i]["MailId"].ToString(),
                    TaxNo = dt.Rows[i]["TaxNo"].ToString(),
                    PanNo = dt.Rows[i]["PanNo"].ToString(),
                    TanNo = dt.Rows[i]["TanNo"].ToString(),
                    IECCode = dt.Rows[i]["IECCode"].ToString(),
                    UserId = dt.Rows[i]["UserId"].ToString()

                });

            }
            return ListKYC;
        }
        public DataTable GetKYCValues(MyKYC Data)
        {
            string _Query = " select ID,CompanyName,Address, " +
                            " (select CountryName from NVO_CountryMaster where NVO_CountryMaster.ID = NVO_KYCCustomerInfo.CountryID) as CountryName, " +
                            " (select CityName from NVO_CityMaster where NVO_CityMaster.ID = NVO_KYCCustomerInfo.CityID)as CityName, " +
                            " (select StateName from NVO_StateMaster where NVO_StateMaster.ID = NVO_KYCCustomerInfo.StateID)as StateName, " +
                            " PinCode,TelNo,FaxNo,MailId,TaxNo,PanNo,TanNo,IECCode,UserId " +
                            " from NVO_KYCCustomerInfo";
            return GetViewData(_Query, "");
        }
        public List<MyKYC> KYCPartyMaster(MyKYC Data)
        {
            DataTable dt = GetKYCPartyValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListKYC.Add(new MyKYC
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),                   
                });

            }
            return ListKYC;
        }
        public DataTable GetKYCPartyValues(MyKYC Data)
        {
            string _Query = "select ID,CompanyName from NVO_KYCCustomerInfo";
            return GetViewData(_Query, "");
        }

        public List<MyKYC> KYCApprovalMaster(string ID)
        {
            DataTable dt = GetKYCAppValues(ID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListKYC.Add(new MyKYC
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    CityID = Int32.Parse(dt.Rows[i]["CityID"].ToString()),
                    StateID = Int32.Parse(dt.Rows[i]["StateID"].ToString()),
                    PinCode = dt.Rows[i]["PinCode"].ToString(),
                    TelNo = dt.Rows[i]["TelNo"].ToString(),
                    FaxNo = dt.Rows[i]["FaxNo"].ToString(),
                    MailId = dt.Rows[i]["MailId"].ToString(),
                    TaxNo = dt.Rows[i]["TaxNo"].ToString(),
                    PanNo = dt.Rows[i]["PanNo"].ToString(),
                    TanNo = dt.Rows[i]["TanNo"].ToString(),
                    IECCode = dt.Rows[i]["IECCode"].ToString(),
                    UserId = dt.Rows[i]["UserId"].ToString()

                });

            }
            return ListKYC;
        }

        public DataTable GetKYCAppValues(string ID)
        {
            string _Query = "select * from NVO_KYCCustomerInfo where ID = " + ID;
            return GetViewData(_Query, "");
        }


        #region Business Types

        public List<MyKYC> GetBusinessTypeMaster(MyKYC Data)
        {
            DataTable dt = GetBusinessMaster(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListKYC.Add(new MyKYC
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BusinessType = dt.Rows[i]["BusinessType"].ToString(),

                });

            }
            return ListKYC;
        }
        public DataTable GetBusinessMaster(MyKYC Data)
        {
            string _Query = "Select * from NVO_KYCCustomerInfo";
            return GetViewData(_Query, "");
        }


        #endregion

        public List<MyKYC> InsertKYCApproval(MyKYC Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_CustomerMaster where ID=@ID)<=0) " +
                                     " BEGIN " +                                    
                                      " INSERT INTO  NVO_CustomerMaster(CustomerName,CustomerType,CountryID,CurrentDate) " +
                                     " values (@CustomerName,@CustomerType,@CountryID,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CustomerMaster SET CustomerName=@CustomerName,CustomerType=@CustomerType,CountryID=@CountryID,CurrentDate=@CurrentDate where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.KYCID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerName", Data.CompanyName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerType", Data.LoginRole));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));                   
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_CustomerMaster')";
                    if (Data.KYCID == 0)
                        Data.KYCID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.KYCID = Data.KYCID;
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = " IF((select count(*) from NVO_CusBranchLocation where CustomerID=@CustomerID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_CusBranchLocation(CustomerID,City,CityID,State,StateID,Address,CurrentDate,GSTIN,Branch,TelNo,Fax,EmailID) " +
                                    " values (@CustomerID,@City,@CityID,@State,@StateID,@Address,@CurrentDate,@GSTIN,@Branch,@TelNo,@Fax,@EmailID) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_CusBranchLocation SET CustomerID=@CustomerID,CityID=@CityID,City=@City,State=@State,StateID=@StateID,Address=@Address,CurrentDate=@CurrentDate,GSTIN=@GSTIN,Branch=@Branch,TelNo=@TelNo,Fax=@Fax,EmailID=@EmailID where CustomerID=@CustomerID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.KYCID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Branch", Data.Branch));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CityID", Data.CityID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@City", Data.CityName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StateID", Data.StateID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@State", Data.StateName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TelNo", Data.TelNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Fax", Data.FaxNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EmailID", Data.MailId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GSTIN", Data.TaxNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", Data.Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    Cmd.CommandText = " IF((select count(*) from NVO_LoginDetails where ID=@ID)<=0) " +
                                     " BEGIN " +
                                      " INSERT INTO  NVO_LoginDetails(UserType,UserName,Password,TelNo,EmailID,CurrentDate,UserID) " +
                                     " values (@UserType,@UserName,@Password,@TelNo,@EmailID,@CurrentDate,@UserID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_LoginDetails SET UserType=@UserType,UserName=@UserName,Password=@Password,TelNo=@TelNo,EmailID=@EmailID,CurrentDate=@CurrentDate,UserID=@UserID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserType", Data.LoginRole));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserName", Data.UserName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Password", Data.Password));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TelNo", Data.TelNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EmailID", Data.MailId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.KYCID));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    trans.Commit();
                    return ListKYC;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListKYC;
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
