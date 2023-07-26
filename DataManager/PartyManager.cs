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
    public class PartyManager
    {
        List<MyCustomer> ListCustomer = new List<MyCustomer>();
        List<MYCustomerBuss> ListCusBuss = new List<MYCustomerBuss>();
        List<MyAgency> ListAgency = new List<MyAgency>();
        MasterManager cm = new MasterManager();
        List<MyPortAgency> ListAgencyPort = new List<MyPortAgency>();
        List<MyCityAgency> ListAgencyCity = new List<MyCityAgency>();
        List<MyAccAgency> ListAgencyAcc = new List<MyAccAgency>();
        List<MyAlertEmailAgency> ListAgencyEmail = new List<MyAlertEmailAgency>();



        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public PartyManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region anand
        #region Customer Master
        List<MyCity> ListCity = new List<MyCity>();
        public List<MyCity> GetCommonCityMaster()
        {
            DataTable dt = GetCommonCityValues();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCity.Add(new MyCity
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CityName = dt.Rows[i]["CityName"].ToString(),

                });

            }
            return ListCity;
        }
        public DataTable GetCommonCityValues()
        {

            string _Query = "Select * from NVO_CityMaster";
            return GetViewData(_Query, "");
        }
        List<MyState> ListStatev = new List<MyState>();

        public List<MyState> GetCommonStateMaster()
        {
            DataTable dt = GetCommonStateValues();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListStatev.Add(new MyState
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StateName = dt.Rows[i]["StateName"].ToString(),

                });

            }
            return ListStatev;
        }

        public DataTable GetCommonStateValues()
        {

            string _Query = "Select * from NVO_StateMaster";
            return GetViewData(_Query, "");
        }

        public List<MyCustomer> InsertCustomerMaster(MyCustomer Data)
        {

            int r1 = 0;
            int r2 = 0;
            DbConnection con = null;
            DbTransaction trans;

            DataTable ChckExist = GetExistingCustomer(Data);
            if (Data.ID == 0)
            {
                if (ChckExist.Rows.Count >= 1)
                {
                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Customer Name Already Exists"

                    }); ;
                    return ListCustomer;
                }
            }
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
                                      //" INSERT INTO  NVO_CustomerMaster(CustomerName,CustomerType,CountryID,CityID,StateID,PinCode,Tel,Fax,GSTINTax,EmailID,Address,CurrentDate) " +
                                      //" values (@CustomerName,@CustomerType,@CountryID,@CityID,@StateID,@PinCode,@Tel,@Fax,@GSTINTax,@EmailID,@Address,@CurrentDate) " +
                                      //" END  " +
                                      //" ELSE " +
                                      //" UPDATE NVO_CustomerMaster SET CustomerName=@CustomerName,CustomerType=@CustomerType,CountryID=@CountryID,CityID=@CityID,StateID=@StateID,PinCode=@PinCode,Tel=@Tel,Fax=@Fax,GSTINTax=@GSTINTax,EmailID=@EmailID,Address=@Address,CurrentDate=@CurrentDate where ID=@ID";
                                      " INSERT INTO  NVO_CustomerMaster(CustomerName,CountryID,CustomerType,IsFF,IsNVOCC,CurrentDate) " +
                                     " values (@CustomerName,@CountryID,@CustomerType,@IsFF,@IsNVOCC,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CustomerMaster SET CustomerName=@CustomerName,CountryID=@CountryID,IsFF=@IsFF,CustomerType=@CustomerType,IsNVOCC=@IsNVOCC,CurrentDate=@CurrentDate where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerName", Data.CustomerName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerType", 1));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsFF", Data.IsFF));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsNVOCC", Data.IsNVOCC));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_CustomerMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.BusinessType.TrimEnd(',').Split(',');

                    Cmd.CommandText = "delete from NVO_CusBusinessTypes where CustomerID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();

                    for (int i = 0; i < Array.Length; i++)
                    {
                        Cmd.CommandText = " IF((select count(*) from NVO_CusBusinessTypes where CustomerID=@CustomerID and BussTypes=@BussTypes)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_CusBusinessTypes(CustomerID,BussTypes) " +
                                    " values (@CustomerID,@BussTypes) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_CusBusinessTypes SET CustomerID=@CustomerID,BussTypes=@BussTypes where CustomerID=@CustomerID and BussTypes=@BussTypes";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BussTypes", Array[i]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] Arrayd = Data.DivisionDetails.TrimEnd(',').Split(',');

                    Cmd.CommandText = "delete from NVO_CusDivisionTypes where CustomerID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();

                    for (int i = 0; i < Arrayd.Length; i++)
                    {
                        Cmd.CommandText = " IF((select count(*) from NVO_CusDivisionTypes where CustomerID=@CustomerID and DivisionID=@DivisionID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_CusDivisionTypes(CustomerID,DivisionID) " +
                                    " values (@CustomerID,@DivisionID) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_CusDivisionTypes SET CustomerID=@CustomerID,DivisionID=@DivisionID where CustomerID=@CustomerID and DivisionID=@DivisionID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DivisionID", Arrayd[i]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }


                    for (int i = 0; i < Array.Length; i++)
                    {
                        Cmd.CommandText = " IF((select count(*) from NVO_CusBusinessTypes where CustomerID=@CustomerID and BussTypes=@BussTypes)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_CusBusinessTypes(CustomerID,BussTypes) " +
                                    " values (@CustomerID,@BussTypes) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_CusBusinessTypes SET CustomerID=@CustomerID,BussTypes=@BussTypes where CustomerID=@CustomerID and BussTypes=@BussTypes";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BussTypes", Array[i]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);



                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().Split(new[] { "Address:" }, StringSplitOptions.None);
                        var CharSplitA = CharSplit[0].ToString().Split(',');
                        var CharSplitB = CharSplit[1].ToString();



                        Cmd.CommandText = " IF((select count(*) from NVO_CusBranchLocation where CID=@CID and CustomerID=@CustomerID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_CusBranchLocation(CustomerID,City,CityID,State,StateID,Address,CurrentDate,Branch,TelNo,PinCode,EmailID,Status,StatusID,PIC) " +
                                        " values (@CustomerID,@City,@CityID,@State,@StateID,@Address,@CurrentDate,@Branch,@TelNo,@PinCode,@EmailID,@Status,@StatusID,@PIC) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_CusBranchLocation SET CustomerID=@CustomerID,CityID=@CityID,City=@City,State=@State,StateID=@StateID,Address=@Address,CurrentDate=@CurrentDate,Branch=@Branch,TelNo=@TelNo,PinCode=@PinCode,EmailID=@EmailID,StatusID=@StatusID,Status=@Status,PIC=@PIC where CID=@CID and CustomerID=@CustomerID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CID", CharSplitA[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Branch", CharSplitA[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CityID", CharSplitA[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@City", CharSplitA[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StateID", CharSplitA[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@State", CharSplitA[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TelNo", CharSplitA[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PinCode", CharSplitA[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EmailID", CharSplitA[8]));
                        // Cmd.Parameters.Add(_dbFactory.GetParameter("@GSTIN", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PIC", CharSplitA[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", CharSplitA[10]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", CharSplitA[11]));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@PanNo", 0));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@TanNo", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", CharSplitB));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();



                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListCustomer;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListCustomer;
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
        public DataTable GetExistingCustomer(MyCustomer Data)
        {
            string Strwhere = "select * from NVO_CustomerMaster Where CustomerType=1 and CustomerName = '" + Data.CustomerName + "'";
            return GetViewData(Strwhere, "");
        }
        public List<MyCustomer> GetCustMaster(MyCustomer Data)
        {
            DataTable dt = GetCustomerValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    CityName = dt.Rows[i]["CityName"].ToString(),
                    StateName = dt.Rows[i]["StateName"].ToString(),
                    PartyType = dt.Rows[i]["PartyType"].ToString()

                });

            }
            return ListCustomer;
        }

        public List<MyCustomer> GetCustDropDownMaster(MyCustomer Data)
        {
            DataTable dt = GetCustDropDownValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                });

            }
            return ListCustomer;
        }
        public DataTable GetCustomerValues(MyCustomer Data)
        {
            string strWhere = "";

            string _Query = "select  ID,CustomerName,(Select top(1) CountryName from NVO_CountryMaster WHERE ID = CountryID)  CountryName, (Select top(1) CityName from NVO_CityMaster WHERE ID = CityID)  CityName, " +
              " (Select top(1) StateName from NVO_StateMaster WHERE ID = StateID)  StateName,(Select top(1) GeneralName from NVO_GeneralMaster " +
                " WHERE ID = CustomerType)  PartyType, CustomerType from NVO_CustomerMaster WHERE CustomerType=1 ";

            if (Data.CustomerName != "")
                if (strWhere == "")
                    strWhere += _Query + " and CustomerName like '%" + Data.CustomerName + "%'";
                else
                    strWhere += " and CustomerName like '%" + Data.CustomerName + "%'";

            if (Data.CountryID.ToString() != "" && Data.CountryID.ToString() != null && Data.CountryID.ToString() != "0" && Data.CountryID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " and CountryID=" + Data.CountryID.ToString();
                else
                    strWhere += " and CountryID =" + Data.CountryID.ToString();

            if (Data.CustomerType.ToString() != "" && Data.CustomerType.ToString() != null && Data.CustomerType.ToString() != "0" && Data.CustomerType.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " and CustomerType=" + Data.CustomerType.ToString();
                else
                    strWhere += " and CustomerType =" + Data.CustomerType.ToString();


            if (strWhere == "")
                strWhere = _Query + " order by NVO_CustomerMaster.ID desc ";

            return GetViewData(strWhere, "");

        }

        public List<MyCustomer> GetCustMasterRecord(MyCustomer Data)
        {
            DataTable dt = GetCustomerRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                    //CustomerType = Int32.Parse(dt.Rows[i]["CustomerType"].ToString()),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    IsFF = Int32.Parse(dt.Rows[i]["IsFF"].ToString()),
                    IsNVOCC = Int32.Parse(dt.Rows[i]["IsNVOCC"].ToString()),
                });

            }
            return ListCustomer;
        }
        public DataTable GetCustomerRecord(MyCustomer Data)
        {
            string _Query = "Select * from NVO_CustomerMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public DataTable GetCustDropDownValues(MyCustomer Data)
        {
            string _Query = "Select * from NVO_CustomerMaster";
            return GetViewData(_Query, "");
        }

        public List<MyCustomer> CheckCustomerValues(MyCustomer data)
        {
            DataTable dt = GetCheckValues(data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Branch = dt.Rows[i]["Branch"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    Link = dt.Rows[i]["Link"].ToString()
                });
            }
            return ListCustomer;
        }

        public DataTable GetCheckValues(MyCustomer Data)
        {
            string _Query = "select ID, isnull((select Top(1) CID   from NVO_CusBranchLocation where CustomerID= NVO_CustomerMaster.ID),0)as Branch, " +
                            " isnull((select Top(1) ID   from NVO_CusEmailAlerts where CustomerID= NVO_CustomerMaster.ID),0)as Email, " +
                            " isnull((select Top(1) ID   from NVO_CusSalesLink where CustomerID= NVO_CustomerMaster.ID),0)as Link " +
                            " from NVO_CustomerMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        //public DataTable CustomerAllUpdate(MyCustomer Data)
        //{
        //    string _Query = "Update NVO_CustomerMaster Set Active=1 where ID=" + Data.ID;
        //    return GetViewData(_Query, "");
        //}
        #endregion

        #region Customer Branch Location
        public List<MyCustomer> InsertCustomerLocation(MyCustomer Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_CusBranchLocation where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_CusBranchLocation(CustomerID,CityID,StateID,Address,CurrentDate,GSTIN,Branch) " +
                                     " values (@CustomerID,@CityID,@StateID,@Address,@CurrentDate,@GSTIN,@Branch) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CusBranchLocation SET CustomerID=@CustomerID,CityID=@CityID,StateID=@StateID,Address=@Address,CurrentDate=@CurrentDate,GSTIN=@GSTIN,Branch=@Branch where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.CusLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CityID", Data.CityID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StateID", Data.StateID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", Data.Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GSTIN", Data.GSTIN));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Branch", Data.Branch));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_CustomerMaster')";
                    if (Data.CusID == 0)
                        Data.CusID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.CusID = Data.CusID;


                    trans.Commit();
                    return ListCustomer;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCustomer;
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



        public List<MyCustomer> GetCusBranchMaster(MyCustomer Data)
        {
            DataTable dt = GetCustomerBranchValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    CID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    PIC = dt.Rows[i]["PIC"].ToString(),
                    //TanNo = dt.Rows[i]["TanNo"].ToString(),
                    City = dt.Rows[i]["City"].ToString(),
                    CityID = Int32.Parse(dt.Rows[i]["CityID"].ToString()),
                    State = dt.Rows[i]["State"].ToString(),
                    StateID = Int32.Parse(dt.Rows[i]["StateID"].ToString()),
                    //GSTIN = dt.Rows[i]["GSTIN"].ToString(),
                    TelNo = dt.Rows[i]["TelNo"].ToString(),
                    PinCode = dt.Rows[i]["PinCode"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    LocBranch = dt.Rows[i]["Branch"].ToString(),
                    EmailID = dt.Rows[i]["EmailID"].ToString(),
                    StatusResult = dt.Rows[i]["Status"].ToString(),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),

                });

            }
            return ListCustomer;
        }

        public DataTable GetCustomerBranchValues(MyCustomer Data)
        {

            string _Query = "Select * from NVO_CusBranchLocation where CustomerID = " + Data.ID + "";



            return GetViewData(_Query, "");
        }
        public List<MyCustomer> GetCusBranchMasterUpdate(MyCustomer Data)
        {
            DataTable dt = GetCustomerBranchUpdate(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    CusLID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    CityID = Int32.Parse(dt.Rows[i]["CityID"].ToString()),
                    StateID = Int32.Parse(dt.Rows[i]["StateID"].ToString()),
                    Address = dt.Rows[i]["Address"].ToString(),
                    GSTIN = dt.Rows[i]["GSTIN"].ToString(),
                    Branch = dt.Rows[i]["Branch"].ToString(),
                    Tel = dt.Rows[i]["TelNo"].ToString(),
                    Fax = dt.Rows[i]["Fax"].ToString(),
                    Email = dt.Rows[i]["EmailID"].ToString()

                });

            }
            return ListCustomer;
        }
        public DataTable GetCustomerBranchUpdate(MyCustomer Data)
        {

            string _Query = " select CID,CustomerID,CityID,StateID,Address,GSTIN,Branch,TelNo,Fax,EmailID from NVO_CusBranchLocation where ID=" + Data.CusLID;


            return GetViewData(_Query, "");
        }

        public List<MyCustomer> CusBranchDeleteMaster(MyCustomer Data)
        {
            DataTable dt = DeleteBranchValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    CID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    CityID = Int32.Parse(dt.Rows[i]["CityID"].ToString()),
                    StateID = Int32.Parse(dt.Rows[i]["StateID"].ToString()),
                    Address = dt.Rows[i]["Address"].ToString(),
                    GSTIN = dt.Rows[i]["GSTIN"].ToString()
                });

            }
            return ListCustomer;
        }
        public DataTable DeleteBranchValues(MyCustomer Data)
        {

            string _Query = "Delete NVO_CusBranchLocation where CID=" + Data.CID;


            return GetViewData(_Query, "");
        }

        public List<MyCustomer> GSTCategoryListDropDown(MyCustomer Data)
        {
            DataTable dt = GetGSTCategoryListDropDown(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCustomer.Add(new MyCustomer
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GSTINTax = dt.Rows[i]["TaxCode"].ToString()

                });
            }


            return ListCustomer;
        }

        public DataTable GetGSTCategoryListDropDown(MyCustomer Data)
        {

            string _Query = "select * from NVO_FinanceTaxNames where CountryID =53";


            return GetViewData(_Query, "");
        }

        public List<MyCustomer> UserDetailsListDropDown(MyCustomer Data)
        {
            DataTable dt = GetUserDetailsListDropDown(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCustomer.Add(new MyCustomer
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserName = dt.Rows[i]["UserName"].ToString()

                });
            }


            return ListCustomer;
        }

        public DataTable GetUserDetailsListDropDown(MyCustomer Data)
        {

            string _Query = "select * from NVO_UserDetails";


            return GetViewData(_Query, "");
        }
        public List<MyCustomer> BindBranchDropDown(MyCustomer Data)
        {
            DataTable dt = GetBranchDropDown(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCustomer.Add(new MyCustomer
                {

                    CID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    Branch = dt.Rows[i]["Branch"].ToString()

                });
            }


            return ListCustomer;
        }

        public DataTable GetBranchDropDown(MyCustomer Data)
        {

            string _Query = "Select CID,Branch,CustomerID From NVO_CusBranchLocation where CustomerID=" + Data.ID;


            return GetViewData(_Query, "");
        }


        #endregion

        #region Business Types

        public List<MyCustomer> GetBusinessTypeMaster()
        {
            DataTable dt = GetBusinessMaster();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BusinessType = dt.Rows[i]["BusinessType"].ToString(),

                });

            }
            return ListCustomer;
        }
        public DataTable GetBusinessMaster()
        {
            string _Query = "Select * from NVO_BusinessTypes";
            return GetViewData(_Query, "");
        }

        public List<MYCustomerBuss> GetBusinessMasterRecord(MYCustomerBuss Data)
        {

            DataTable dt = GetBusinessMasterValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCusBuss.Add(new MYCustomerBuss
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BusinessType = dt.Rows[i]["BusinessType"].ToString(),
                    IsTrue = Int32.Parse(dt.Rows[i]["IsTrue"].ToString()),

                });

            }
            return ListCusBuss;
        }
        public DataTable GetBusinessMasterValues(MYCustomerBuss Data)
        {
            string _Query = "select Id, BusinessType, case when(select top(1) BussTypes from NVO_CusBusinessTypes where BussTypes = NVO_BusinessTypes.ID and CustomerID = " + Data.ID + ") > 0 then 1 else 0 end as IsTrue from NVO_BusinessTypes ";
            return GetViewData(_Query, "");
        }
        #endregion

        #region Email Alerts
        public List<MyCustomer> InsertCustomerEmailAlerts(MyCustomer Data)
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


                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_CusEmailAlerts where BranchID=@BranchID AND CustomerID=@CustomerID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_CusEmailAlerts(BranchID,Branch,CustomerID,AlertTypeID,AlertType,EmailID,CurrentDate) " +
                                     " values (@BranchID,@Branch,@CustomerID,@AlertTypeID,@AlertType,@EmailID,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CusEmailAlerts SET CustomerID=@CustomerID,BranchID=@BranchID,Branch=@Branch,CurrentDate=@CurrentDate,AlertTypeID=@AlertTypeID,AlertType=@AlertType,EmailID=@EmailID where BranchID=@BranchID and CustomerID=@CustomerID ";


                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BranchID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Branch", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AlertTypeID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AlertType", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EmailID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();
                    return ListCustomer;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCustomer;
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

        public List<MyCustomer> GetCusEmailAlertsMaster(MyCustomer Data)
        {
            DataTable dt = GetCusEmailAlerts(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    CusAltID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),
                    AlertTypeV = dt.Rows[i]["AlertTypeV"].ToString(),
                    EmailID = dt.Rows[i]["EmailID"].ToString(),
                    Branch = dt.Rows[i]["Branch"].ToString()

                });

            }
            return ListCustomer;
        }

        public DataTable GetCusEmailAlerts(MyCustomer Data)
        {

            string _Query = " select nvo_CusEmailAlerts.ID,nvo_CusEmailAlerts.CustomerID,AgencyName,(select GeneralName from NVO_GeneralMaster where ID=NVO_CusEmailAlerts.AlertType)as AlertTypeV,NVO_CusBranchLocation.EmailID,NVO_CusBranchLocation.Branch from NVO_CusEmailAlerts " +
                            " inner join NVO_AgencyMaster on NVO_AgencyMaster.ID = NVO_CusEmailAlerts.AgencyID " +
                            " inner join NVO_CusBranchLocation On NVO_CusBranchLocation.CID = NVO_CusEmailAlerts.BranchID " +
                            " where nvo_CusEmailAlerts.CustomerID=" + Data.CusID;


            return GetViewData(_Query, "");
        }

        public List<MyCustomer> GetCusEmailAltMasterUpdate(MyCustomer Data)
        {
            DataTable dt = GetCustomerEmailAltUpdate(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BranchID = Int32.Parse(dt.Rows[i]["BranchID"].ToString()),
                    Branch = dt.Rows[i]["Branch"].ToString(),
                    AlertTypeID = Int32.Parse(dt.Rows[i]["AlertTypeID"].ToString()),
                    AlertType = dt.Rows[i]["AlertType"].ToString(),
                    EmailAlertID = dt.Rows[i]["EmailID"].ToString(),

                });

            }
            return ListCustomer;
        }
        public DataTable GetCustomerEmailAltUpdate(MyCustomer Data)
        {
            string _Query = " select * from NVO_CusEmailAlerts where CustomerID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        public List<MyCustomer> CusEmailAlertsDeleteMaster(MyCustomer Data)
        {
            DataTable dt = DeleteEmailAlertsValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    CusAltID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    AlertType = dt.Rows[i]["AlertType"].ToString(),
                    EmailID = dt.Rows[i]["EmailID"].ToString()
                });

            }
            return ListCustomer;
        }
        public DataTable DeleteEmailAlertsValues(MyCustomer Data)
        {

            string _Query = "Delete NVO_CusEmailAlerts where ID=" + Data.CusAltID;


            return GetViewData(_Query, "");
        }
        #endregion

        #region Customer Additional Information
        public List<MyCustomer> InsertCusAddInfoMaster(MyCustomer Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_CusAddInfo where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_CusAddInfo(CustomerID,InfoType,InfoValue,CurrentDate) " +
                                     " values (@CustomerID,@InfoType,@InfoValue,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CusAddInfo SET CustomerID=@CustomerID,InfoType=@InfoType,InfoValue=@InfoValue,CurrentDate=@CurrentDate where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.CusInfoID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.CusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InfoType", Data.InfoType));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@InfoValue", Data.InfoValue));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_CustomerMaster')";
                    if (Data.CusID == 0)
                        Data.CusID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.CusID = Data.CusID;


                    trans.Commit();
                    return ListCustomer;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCustomer;
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

        public List<MyCustomer> GeneralmasterAttachmentValues()
        {
            List<MyCustomer> GeneralList = new List<MyCustomer>();
            DataTable dt = GetGeneralMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GeneralList.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return GeneralList;
        }

        public DataTable GetGeneralMaster()
        {
            string _Query = "select * from NVO_GeneralMaster where SeqNo =63";
            return GetViewData(_Query, "");
        }


        public List<MyCustomer> GetCusAddInfoMaster(MyCustomer Data)
        {
            DataTable dt = GetCusAddInfo(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    CusInfoID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    InfoTypeV = dt.Rows[i]["GeneralName"].ToString(),
                    InfoValue = dt.Rows[i]["InfoValue"].ToString()

                });

            }
            return ListCustomer;
        }

        public DataTable GetCusAddInfo(MyCustomer Data)
        {

            string _Query = " select NVO_CusAddInfo.ID,CustomerID,GeneralName, " +
                            " InfoValue from NVO_CusAddInfo inner join NVO_CustomerMaster On NVO_CustomerMaster.ID = nvo_CusAddInfo.CustomerID" +
                            " inner join NVO_GeneralMaster On NVO_GeneralMaster.ID = NVO_CusAddInfo.InfoType " +
                            " where CustomerID= " + Data.CusID;
            return GetViewData(_Query, "");
        }

        public List<MyCustomer> GetCusAddInfoUpdateMaster(MyCustomer Data)
        {
            DataTable dt = GetCustomerAddInfoUpdate(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    CusInfoID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    InfoType = Int32.Parse(dt.Rows[i]["InfoType"].ToString()),
                    InfoValue = dt.Rows[i]["InfoValue"].ToString()
                });

            }
            return ListCustomer;
        }
        public DataTable GetCustomerAddInfoUpdate(MyCustomer Data)
        {

            string _Query = " select NVO_CusAddInfo.ID,CustomerID,InfoType,InfoValue from NVO_CusAddInfo where NVO_CusAddInfo.ID=" + Data.CusInfoID;
            return GetViewData(_Query, "");
        }

        public List<MyCustomer> CusAddInfoDeleteMaster(MyCustomer Data)
        {
            DataTable dt = DeleteAddInfoValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    CusInfoID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    InfoTypeV = dt.Rows[i]["InfoTypeV"].ToString(),
                    InfoValue = dt.Rows[i]["InfoValue"].ToString()
                });

            }
            return ListCustomer;
        }
        public DataTable DeleteAddInfoValues(MyCustomer Data)
        {

            string _Query = "Delete NVO_CusAddInfo where ID=" + Data.CusInfoID;
            return GetViewData(_Query, "");
        }
        #endregion

        #region Customer SalesLink
        public List<MyCustomer> InsertCusSalesLinkMaster(MyCustomer Data)
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

                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_CusSalesLink where BranchID=@BranchID and CustomerID=@CustomerID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_CusSalesLink(BranchID,Branch,CustomerID,CurrentDate,GSTListID,GSTINTax,GSTNo,LegalName,PAN,	TANNo,POSID,POS,CurrencyID,CurrencyCode) " +
                                        " values (@BranchID,@Branch,@CustomerID,@CurrentDate,@GSTListID,@GSTINTax,@GSTNo,@LegalName,@PAN,	@TANNo,@POSID,@POS,@CurrencyID,@CurrencyCode) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_CusSalesLink SET BranchID=@BranchID,Branch=@Branch,CustomerID=@CustomerID,CurrentDate=@CurrentDate,GSTListID=@GSTListID,GSTINTax=@GSTINTax,GSTNo=@GSTNo,LegalName=@LegalName,PAN=@PAN,TANNo=@TANNo,POSID=@POSID,POS=@POS,CurrencyID=@CurrencyID where BranchID=@BranchID and CustomerID=@CustomerID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BranchID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Branch", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GSTListID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GSTINTax", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GSTNo", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LegalName", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PAN", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TANNo", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@POSID", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@POS", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[10]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyCode", CharSplit[11]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));


                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }




                    trans.Commit();
                    return ListCustomer;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCustomer;
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

        public List<MyCustomer> GetAgencyStateMaster(MyCustomer Data)
        {
            DataTable dt = GetAgencyState(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCustomer.Add(new MyCustomer
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StateName = dt.Rows[i]["StateName"].ToString(),

                });
            }
            return ListCustomer;
        }

        public List<MyCustomer> GetAgencyMaster(MyCustomer Data)
        {
            DataTable dt = GetAgencyValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCustomer.Add(new MyCustomer
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),

                });
            }
            return ListCustomer;
        }

        public List<MyCustomer> GetCustomerSalesLinkMaster(MyCustomer Data)
        {
            DataTable dt = GetusSalesLinkValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCustomer.Add(new MyCustomer
                {

                    BranchID = Int32.Parse(dt.Rows[i]["BranchID"].ToString()),
                    Branch = dt.Rows[i]["Branch"].ToString(),
                    GSTListID = Int32.Parse(dt.Rows[i]["GSTListID"].ToString()),
                    GSTINTax = dt.Rows[i]["GSTINTax"].ToString(),
                    GSTNo = dt.Rows[i]["GSTNo"].ToString(),
                    Legalname = dt.Rows[i]["Legalname"].ToString(),
                    PAN = dt.Rows[i]["PAN"].ToString(),
                    TAN = dt.Rows[i]["PAN"].ToString(),
                    POSID = Int32.Parse(dt.Rows[i]["POSID"].ToString()),
                    POS = dt.Rows[i]["POS"].ToString(),
                    CurrID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString(),


                });
            }
            return ListCustomer;
        }
        public DataTable GetAgencyState(MyCustomer Data)
        {
            string _Query = " select NVO_AgencyMaster.ID,StateName from nvo_AgencyMaster " +
                             " inner join nvo_StateMaster On NVO_StateMaster.ID = NVO_AgencyMaster.StateID";
            return GetViewData(_Query, "");
        }
        public DataTable GetAgencyValues(MyCustomer Data)
        {
            string _Query = " Select ID,AgencyName from NVO_AgencyMaster";
            return GetViewData(_Query, "");
        }


        public DataTable GetusSalesLinkValues(MyCustomer Data)
        {
            string _Query = " select * from NVO_CusSalesLink where CustomerID=" + Data.ID;

            return GetViewData(_Query, "");
        }
        public List<MyCustomer> GetCustomerSalesLinkMasterUpdate(MyCustomer Data)
        {
            DataTable dt = GetCustomerSalesLinkUpdate(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    CusLinkID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    BranchID = Int32.Parse(dt.Rows[i]["BranchID"].ToString()),
                    SalesPerson = dt.Rows[i]["SalesPerson"].ToString(),
                    SalesPicID = Int32.Parse(dt.Rows[i]["SelesPersonID"].ToString()),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    ValidFromV = dt.Rows[i]["ValidFromV"].ToString(),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString())
                });

            }
            return ListCustomer;
        }
        public DataTable GetCustomerSalesLinkUpdate(MyCustomer Data)
        {

            string _Query = " select *,replace(convert(NVARCHAR, ValidFrom, 103), ' ', '-') as ValidFromV  from NVO_CusSalesLink where ID=" + Data.CusLinkID;


            return GetViewData(_Query, "");
        }

        public List<MyCustomer> GetCustomerSalesLinkMasterDelete(MyCustomer Data)
        {
            DataTable dt = GetCustomerSalesLinkDelete(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    CusLinkID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    BranchID = Int32.Parse(dt.Rows[i]["BranchID"].ToString()),
                    SalesPicID = Int32.Parse(dt.Rows[i]["SelesPersonID"].ToString()),
                    SalesPerson = dt.Rows[i]["SalesPerson"].ToString(),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    ValidFrom = DateTime.Parse(dt.Rows[i]["ValidFrom"].ToString()),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString())
                });

            }
            return ListCustomer;
        }
        public DataTable GetCustomerSalesLinkDelete(MyCustomer Data)
        {

            string _Query = " Delete NVO_CusSalesLink where ID=" + Data.CusLinkID;


            return GetViewData(_Query, "");
        }

        public List<MyCustomer> GetCusSalesUserList(MyCustomer Data)
        {
            DataTable dt = GetCusSalesUser(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserName = dt.Rows[i]["UserName"].ToString(),

                });
            }
            return ListCustomer;
        }

        public DataTable GetCusSalesUser(MyCustomer Data)
        {
            string _Query = " select ID,UserName from NVO_UserDetails";

            return GetViewData(_Query, "");
        }

        public List<MyCustomer> AlertTypesList(MyCustomer Data)
        {
            DataTable dt = GetAlertTypesList(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString(),

                });
            }
            return ListCustomer;
        }

        public DataTable GetAlertTypesList(MyCustomer Data)
        {
            string _Query = " select ID,GeneralName from NVO_GeneralMaster where SeqNo=25";

            return GetViewData(_Query, "");
        }
        #endregion

        #region Crlimit
        public List<MyCustomer> InsertCustomerCrSave(MyCustomer Data)
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

                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_CusCreditLimitDtls where BranchID=@BranchID and CustomerID=@CustomerID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_CusCreditLimitDtls(BranchID,CustomerID,Branch,CreditDays,CreditLimit,ApprovedByID,	ApprovedBy,EffectiveDate,Status,StatusCrID,CurrentDate) " +
                                        " values (@BranchID,@CustomerID,@Branch,@CreditDays,@CreditLimit,@ApprovedByID,	@ApprovedBy,@EffectiveDate,@Status,@StatusCrID,@CurrentDate) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_CusCreditLimitDtls SET BranchID=@BranchID,Branch=@Branch,CustomerID=@CustomerID,CurrentDate=@CurrentDate,CreditDays=@CreditDays,CreditLimit=@CreditLimit,ApprovedByID=@ApprovedByID,ApprovedBy=@ApprovedBy,EffectiveDate=@EffectiveDate,Status=@Status,StatusCrID=@StatusCrID where BranchID=@BranchID and CustomerID=@CustomerID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BranchID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Branch", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CreditDays", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CreditLimit", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ApprovedByID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ApprovedBy", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EffectiveDate", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCrID", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));


                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }




                    trans.Commit();
                    return ListCustomer;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCustomer;
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

        public List<MyCustomer> GetCustomerCrMaster(MyCustomer Data)
        {
            DataTable dt = GetCrValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BranchID = Int32.Parse(dt.Rows[i]["BranchID"].ToString()),
                    Branch = dt.Rows[i]["Branch"].ToString(),
                    CreditDays = dt.Rows[i]["CreditDays"].ToString(),
                    CreditLimit = dt.Rows[i]["CreditLimit"].ToString(),
                    EffectiveDate = dt.Rows[i]["DtEff"].ToString(),
                    ApprovedBy = Int32.Parse(dt.Rows[i]["ApprovedByID"].ToString()),
                    ApprovedName = dt.Rows[i]["ApprovedBy"].ToString(),
                    StatusCrID = Int32.Parse(dt.Rows[i]["StatusCrID"].ToString()),
                    StatusV = dt.Rows[i]["Status"].ToString(),


                });
            }
            return ListCustomer;
        }

        public DataTable GetCrValues(MyCustomer Data)
        {
            string _Query = " select convert(varchar, EffectiveDate, 23) as DtEff,* from NVO_CusCreditLimitDtls where CustomerID=" + Data.ID;

            return GetViewData(_Query, "");
        }
        #endregion

        #region Customer Attachments
        public List<MyCustomer> InsertCustomerAttachmentsMaster(MyCustomer Data)
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


                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);

                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_CusAttachments where AttachID=@AttachID and CustomerID=@CustomerID)<=0) " +
                         " BEGIN " +
                         " INSERT INTO  NVO_CusAttachments(CustomerID,AttachName,AttachFile,UploadedBy,UploadedOn,AttachID) " +
                                      " values (@CustomerID,@AttachName,@AttachFile,@UploadedBy,@UploadedOn,@AttachID) " +
                        " END  " +
                        " ELSE " +
                        " UPDATE NVO_CusAttachments SET CustomerID=@CustomerID,AttachName=@AttachName,AttachFile=@AttachFile,UploadedBy=@UploadedBy,UploadedOn=@UploadedOn,AttachID=@AttachID where CustomerID=@CustomerID and AttachID=@AttachID ";


                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachFile", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachName", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedBy", 1));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UploadedOn", System.DateTime.Now));


                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }




                    //Cmd.CommandText = "select ident_current('NVO_CusAttachments')";
                    //if (Data.CusID == 0)
                    //    Data.CusID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    //else
                    //    Data.CusID = Data.CusID;


                    trans.Commit();
                    ListCustomer.Add(new MyCustomer { CusID = Data.CusID });
                    return ListCustomer;





                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCustomer;
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


        public List<MyCustomer> GetCusAttachmentMaster(MyCustomer Data)
        {
            DataTable dt = GetCustomerAttValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    AttachName = dt.Rows[i]["AttachName"].ToString(),
                    AttachFile = dt.Rows[i]["AttachFile"].ToString(),
                    AttachID = dt.Rows[i]["AttachID"].ToString()
                });

            }
            return ListCustomer;
        }

        public DataTable GetCustomerAttValues(MyCustomer Data)
        {
            string _Query = "Select * from NVO_CusAttachments where CustomerID = " + Data.ID + "";
            return GetViewData(_Query, "");
        }


        public List<MyCustomer> GetCusAttachDelete(MyCustomer Data)
        {
            DataTable dt = AttachDeletevalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CusID = Int32.Parse(dt.Rows[i]["CustomerID"].ToString()),
                    CusAttID = Int32.Parse(dt.Rows[i]["AttachID"].ToString()),
                    AttachName = dt.Rows[i]["AttachName"].ToString(),
                    AttachFile = dt.Rows[i]["AttachFile"].ToString(),
                    UploadedBy = dt.Rows[i]["UploadedBy"].ToString(),
                    UploadedOn = DateTime.Parse(dt.Rows[i]["UploadedOn"].ToString()),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    CurrentDate = DateTime.Parse(dt.Rows[i]["CurrentDate"].ToString()),
                });

            }
            return ListCustomer;
        }

        public DataTable AttachDeletevalues(MyCustomer Data)
        {
            string _Query = "Delete NVO_CusAttachments where ID=" + Data.AID;
            return GetViewData(_Query, "");
        }

        #endregion

        #endregion

        #region Agency Master
        public List<MyAgency> InsertAgencyMaster(MyAgency Data)
        {


            DbConnection con = null;
            DbTransaction trans;
            DataTable ChckExist = GetExistingAgency(Data);
            if (Data.ID == 0)
            {
                if (ChckExist.Rows.Count >= 1)
                {
                    ListAgency.Add(new MyAgency
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Agency Name Already Exists"

                    }); ;
                    return ListAgency;
                }
            }
            if (Data.Status != 1 || Data.Status != 2)
            {
                if (ChckExist.Rows.Count >= 1)
                {
                    if (ChckExist.Rows[0]["AgencyCode"].ToString().ToUpper() == Data.AgencyCode.ToUpper() && ChckExist.Rows[0]["AgencyName"].ToString().ToUpper() == Data.AgencyName.ToUpper())
                    {
                        ListAgency.Add(new MyAgency
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Agency Code/Name Already Exists"
                        });
                        return ListAgency;
                    }
                    if (ChckExist.Rows[0]["AgencyCode"].ToString().ToUpper() == Data.AgencyCode.ToUpper())
                    {
                        ListAgency.Add(new MyAgency
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Agency Code Already Exists"
                        });
                        return ListAgency;
                    }
                    if (ChckExist.Rows[0]["AgencyName"].ToString().ToUpper() == Data.AgencyName.ToUpper())
                    {
                        ListAgency.Add(new MyAgency
                        {
                            ID = Data.ID,

                            AlertMegId = "1",
                            AlertMessage = "Agency Name Already Exists"
                        });
                        return ListAgency;
                    }

                }

            }
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

                    Cmd.CommandText = " IF((select count(*) from NVO_AgencyMaster where ID=@ID)<=0) " +
                                     " BEGIN " +
                          " INSERT INTO  NVO_AgencyMaster(AgencyName,AgencyCode,CountryID,CityID,StateID,TaxGSTNo,Status,Address,Notes,PinCode,Email,TelNo) " +
                                     " values (@AgencyName,@AgencyCode,@CountryID,@CityID,@StateID,@TaxGSTNo,@Status,@Address,@Notes,@PinCode,@Email,@TelNo) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_AgencyMaster SET AgencyName=@AgencyName,AgencyCode=@AgencyCode,CountryID=@CountryID,CityID=@CityID,StateID=@StateID,TaxGSTNo=@TaxGSTNo,Status=@Status,Address=@Address,Notes=@Notes,PinCode=@PinCode,Email=@Email,TelNo=@TelNo where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyName", Data.AgencyName.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyCode", Data.AgencyCode.ToUpper()));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CityID", Data.CityID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StateID", Data.StateID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TaxGSTNo", Data.TaxGSTNo));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@OwnOffice", Data.OwnOffice));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@DocumentSuffix", Data.DocumentSuffix));
                    // Cmd.Parameters.Add(_dbFactory.GetParameter("@OrganizationType", Data.OrganizationType));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@RegPanNO", Data.RegPanNO));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", Data.Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notes", Data.Notes));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@GeoLocationID", Data.GeoLocationID));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@IsOceanus", Data.IsOceanus));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@Is3rdParty", Data.Is3rdParty));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@IsBoth", Data.IsBoth));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PinCode", Data.PinCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Email", Data.EmailDetail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TelNo", Data.TelNo));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_AgencyMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
                    ListAgency.Add(new MyAgency
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListAgency;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListAgency.Add(new MyAgency
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = ex.Message
                    });
                    return ListAgency;
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
        public DataTable GetExistingAgency(MyAgency Data)
        {
            string _Query = "Select * from NVO_AgencyMaster where (ID not in(" + Data.ID + ")) and (AgencyCode ='" + Data.AgencyCode + "' AND AgencyName='" + Data.AgencyName + "')";
            return GetViewData(_Query, "");
        }

        public List<MyAgency> GetAgencyMaster(MyAgency Data)
        {
            DataTable dt = GetAgencyValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListAgency.Add(new MyAgency
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgencyCode = dt.Rows[i]["agencycode"].ToString(),
                    AgencyName = dt.Rows[i]["agencyname"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    CityName = dt.Rows[i]["cityname"].ToString(),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    CountryID = dt.Rows[i]["CountryID"].ToString(),

                });
            }
            return ListAgency;
        }
        public DataTable GetAgencyValues(MyAgency Data)
        {
            string strWhere = "";

            string _Query = "select am.id,agencycode,am.CountryID,agencyname, " +
                "  (select top 1 CountryName from NVO_CountryMaster where ID =CountryID)as CountryName,Address,(select top 1 cityname from NVO_CityMaster where ID =CityID) as cityname ," +
                " (select top 1 GeneralName from NVO_GeneralMaster where ID =OrganizationType) as OrganizationTypes,Case when ownoffice=1 then 'YES' Else 'No' END AS OwnOffices " +
                   " from NVO_AgencyMaster am ";

            if (Data.CountryID != "" && Data.CountryID != null && Data.CountryID != "?" && Data.CountryID != "0")
                if (strWhere == "")
                    strWhere += _Query + " Where am.CountryID=" + Data.CountryID;
                else
                    strWhere += " and am.CountryID =" + Data.CountryID;

            if (Data.CityID != "" && Data.CityID != null && Data.CityID != "?" && Data.CityID != "0")
                if (strWhere == "")
                    strWhere += _Query + " Where am.CityID=" + Data.CityID;
                else
                    strWhere += " and am.CityID =" + Data.CityID;

            if (Data.AgencyCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where agencycode like '%" + Data.AgencyCode + "%'";
                else
                    strWhere += " and agencycode like '%" + Data.AgencyCode + "%'";

            if (Data.AgencyName != "")
                if (strWhere == "")
                    strWhere += _Query + " where agencyname like '%" + Data.AgencyName + "%'";
                else
                    strWhere += " and agencyname like '%" + Data.AgencyName + "%'";

            if (Data.OwnOffice != "" && Data.OwnOffice != null && Data.OwnOffice != "?" && Data.OwnOffice != "0")
                if (strWhere == "")
                    strWhere += _Query + " Where OwnOffice =" + Data.OwnOffice;
                else
                    strWhere += " and OwnOffice =" + Data.OwnOffice;

            if (Data.OrganizationType != "" && Data.OrganizationType != null && Data.OrganizationType != "?" && Data.OrganizationType != "0")
                if (strWhere == "")
                    strWhere += _Query + " Where OrganizationType =" + Data.OrganizationType;
                else
                    strWhere += " and OrganizationType =" + Data.OrganizationType;


            if (strWhere == "")
                strWhere = _Query + " order by am.ID desc "; ;

            return cm.GetViewData(strWhere, "");

        }

        public List<MyAgency> GetAgencyMasterRecord(MyAgency Data)
        {
            DataTable dt = GetAgencyRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListAgency.Add(new MyAgency
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgencyCode = dt.Rows[i]["AgencyCode"].ToString(),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    // DocumentSuffix = dt.Rows[i]["DocumentSuffix"].ToString(),
                    //RegPanNO = dt.Rows[i]["RegPanNO"].ToString(),
                    TaxGSTNo = dt.Rows[i]["TaxGSTNo"].ToString(),
                    Notes = dt.Rows[i]["Notes"].ToString(),
                    CountryID = dt.Rows[i]["CountryID"].ToString(),
                    // GeoLocationID = Int32.Parse(dt.Rows[i]["GeoLocationID"].ToString()),
                    CityID = dt.Rows[i]["CityID"].ToString(),
                    //OrganizationType = dt.Rows[i]["OrganizationType"].ToString(),
                    //OwnOffice = dt.Rows[i]["OwnOffice"].ToString(),
                    StateID = dt.Rows[i]["StateID"].ToString(),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),
                    //Is3rdParty = Int32.Parse(dt.Rows[i]["Is3rdParty"].ToString()),
                    //IsBoth = Int32.Parse(dt.Rows[i]["IsBoth"].ToString()),
                    //IsOceanus = Int32.Parse(dt.Rows[i]["IsOceanus"].ToString()),
                    TelNo = dt.Rows[i]["TelNo"].ToString(),
                    EmailDetail = dt.Rows[i]["Email"].ToString(),
                    PinCode = Int32.Parse(dt.Rows[i]["pincodev"].ToString()),

                });
            }


            return ListAgency;
        }

        public List<MyAgency> BindAgencyDropDown(MyAgency Data)
        {
            DataTable dt = GetAgencyDropDown(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListAgency.Add(new MyAgency
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),

                });
            }


            return ListAgency;
        }

        public DataTable GetAgencyRecord(MyAgency Data)
        {
            string _Query = "Select isnull(pincode,0) as pincodev ,* from NVO_AgencyMaster where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public DataTable GetAgencyDropDown(MyAgency Data)
        {
            string _Query = "Select * from NVO_AgencyMaster";
            return GetViewData(_Query, "");
        }


        public List<MyAgency> InsertAgencyPrincipalDtlsValues(MyAgency Data)
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


                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_AgencyPrincipalDtls where ID=@ID AND AgencyID=@AgencyID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_AgencyPrincipalDtls(AgencyID,PrincipalID,PrincipalName,DtAdded,AddedBy) " +
                                     " values (@AgencyID,@PrincipalID,@PrincipalName,@DtAdded,@AddedBy) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_AgencyPrincipalDtls SET AgencyID=@AgencyID,PrincipalID=@PrincipalID,PrincipalName=@PrincipalName,AddedBy=@AddedBy,DtModified=@DtModified where ID=@ID and AgencyID=@AgencyID ";


                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincipalID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincipalName", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AddedBy", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtAdded", System.DateTime.Now));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtModified", System.DateTime.Now));
                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();
                    return ListAgency;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListAgency;
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

        public List<MyPortAgency> GetAgencyPrincipalDtlsView(MyPortAgency Data)
        {
            DataTable dt = GetAgencyPrincipalDtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListAgencyPort.Add(new MyPortAgency
                {

                    PID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PrincipalName = dt.Rows[i]["PrincipalName"].ToString(),
                    PrincipalID = Int32.Parse(dt.Rows[i]["PrincipalID"].ToString()),

                });
            }
            return ListAgencyPort;
        }
        public DataTable GetAgencyPrincipalDtls(MyPortAgency Data)
        {

            string _Query = "select * FROM NVO_AgencyPrincipalDtls where AgencyID = " + Data.ID + " ";
            return GetViewData(_Query, "");
        }
        public DataTable RemoveprincipalDtlsAgencyDtls(MyPortAgency Data)
        {

            string _Query = "Delete NVO_AgencyPrincipalDtls where ID = " + Data.PID + " ";
            return GetViewData(_Query, "");
        }


        public List<MyPortAgency> PortList(MyPortAgency Data)
        {
            DataTable dt = GetPortcodes(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListAgencyPort.Add(new MyPortAgency

                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortCode = dt.Rows[i]["PortCode"].ToString()
                });
            }
            return ListAgencyPort;
        }
        public DataTable GetPortcodes(MyPortAgency Data)
        {
            string _Query = "select ID,(PortCode +'-'+ PortNAME) AS PortCode from NVO_PortMaster where Status=1 order by ID ";
            return GetViewData(_Query, "");
        }
        public List<MyPortAgency> PrincipalList(MyPortAgency Data)
        {
            DataTable dt = GetPrincipalList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListAgencyPort.Add(new MyPortAgency

                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PrincipalName = dt.Rows[i]["PrincipalName"].ToString()
                });
            }
            return ListAgencyPort;
        }
        public DataTable GetPrincipalList(MyPortAgency Data)
        {
            string _Query = "select ID,(LineCode +'-'+ LineName) as PrincipalName from NVO_Principalmaster where Status=1 order by ID ";
            return GetViewData(_Query, "");
        }
        public List<MyAgency> InsertAgencyPortCodes(MyAgency Data)
        {
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


                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_AgencyPortDtls where ID=@ID AND AgencyID=@AgencyID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_AgencyPortDtls(AgencyID,PortID,PortName,DtAdded,AddedBy) " +
                                     " values (@AgencyID,@PortID,@PortName,@DtAdded,@AddedBy) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_AgencyPortDtls SET AgencyID=@AgencyID,PortID=@PortID,PortName=@PortName,AddedBy=@AddedBy,DtAdded=@DtAdded where ID=@ID and AgencyID=@AgencyID ";


                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortName", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@AddedBy", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DtAdded", System.DateTime.Now));

                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    trans.Commit();
                    return ListAgency;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListAgency;
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

        public List<MyPortAgency> GetAgencyPortView(MyPortAgency Data)
        {
            DataTable dt = GetAgencyPorts(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListAgencyPort.Add(new MyPortAgency
                {

                    CID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortCode = dt.Rows[i]["PortCode"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                });
            }
            return ListAgencyPort;
        }
        public DataTable GetAgencyPorts(MyPortAgency Data)
        {
            //AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
            //DbCommand Cmd = _dbFactory.GetCommand();
            //if (AgencyID == 0)
            //    Cmd.CommandText = "select ident_current('NVO_AgencyMaster')";
            //Data.AgencyID = Int32.Parse(Cmd.ExecuteScalar().ToString());
            //else
            //    AgencyID


            string _Query = "select NVO_AgencyPortDtls.id,PortCode,(NVO_PortMaster.PortCode +'-'+ NVO_PortMaster.PortName) as PortName,NVO_PortMaster.ID As PortID from  NVO_PortMaster " +
                           "inner join  NVO_AgencyPortDtls on NVO_AgencyPortDtls.portid = NVO_PortMaster.id where NVO_AgencyPortDtls.AgencyID = " + Data.ID + " ";
            return GetViewData(_Query, "");
        }
        public DataTable RemoveprDtlsAgencyDtls(MyPortAgency Data)
        {

            string _Query = " Delete NVO_AgencyPrincipalDtls where ID=" + Data.PID;
            return GetViewData(_Query, "");
        }
        public DataTable DelAgencyPortDtls(MyPortAgency Data)
        {

            string _Query = " Delete NVO_AgencyPortDtls where ID=" + Data.CID;
            return GetViewData(_Query, "");
        }

        public List<MyCityAgency> CityList()
        {
            DataTable dt = GetCitycodes();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListAgencyCity.Add(new MyCityAgency

                {
                    CityID = dt.Rows[i]["CityID"].ToString(),
                    CityCode = dt.Rows[i]["CityCode"].ToString()
                });
            }
            return ListAgencyCity;
        }
        public DataTable GetCitycodes()
        {
            string _Query = "select ID as CityID,CityCode from NVO_CityMaster order by CityName ";
            return GetViewData(_Query, "");
        }


        public List<MyCityAgency> InsertAgencyCityCodes(MyCityAgency Data)
        {
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
                    Cmd.CommandText = "select ident_current('NVO_AgencyMaster')";
                    if (Data.AgencyID == 0)
                        Data.AgencyID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.AgencyID = Data.AgencyID;

                    Cmd.CommandText =
                          " INSERT INTO  NVO_AgencyLocDtls(AgencyID,CityID,DtAdded) " +
                                     " values (@AgencyID,@CityID,@DtAdded) ";


                    // Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CityID", Data.CityID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtAdded", System.DateTime.Now));
                    int result = Cmd.ExecuteNonQuery();




                    trans.Commit();
                    return ListAgencyCity;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListAgencyCity;
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

        public List<MyCityAgency> GetAgencyCityView(MyCityAgency Data)
        {
            DataTable dt = GetAgencyCities(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListAgencyCity.Add(new MyCityAgency
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CityCode = dt.Rows[i]["CityCode"].ToString(),
                    CityName = dt.Rows[i]["CityName"].ToString(),

                });
            }
            return ListAgencyCity;
        }
        public DataTable GetAgencyCities(MyCityAgency Data)
        {
            string _Query = "select NVO_AgencyLocDtls.id,CityCode,CityName from  NVO_CityMaster " +
                           "inner join  NVO_AgencyLocDtls on NVO_AgencyLocDtls.cityid = NVO_CityMaster.id where NVO_AgencyLocDtls.AgencyID = " + Data.AgencyID + " ";
            return GetViewData(_Query, "");
        }



        public DataTable DelAgencyCityDtls(MyCityAgency Data)
        {

            string _Query = " Delete NVO_AgencyLocDtls where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }
        public List<MyAccAgency> InsertAgencyAccDtls(MyAccAgency Data)
        {
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
                    Cmd.CommandText = "select ident_current('NVO_AgencyMaster')";
                    if (Data.AgencyID == 0)
                        Data.AgencyID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.AgencyID = Data.AgencyID;

                    Cmd.CommandText = " IF((select count(*) from NVO_AgencyAccDtls where AgencyID=@AgencyID)<=0) " +
                                   " BEGIN " +
                                   " INSERT INTO  NVO_AgencyAccDtls(AgencyID,CurrID,FromMonth,ToMonth,AccNotes,DtAdded) " +
                                     " values (@AgencyID,@CurrID,@FromMonth,@ToMonth,@AccNotes,@DtAdded) " +
                                   " END  " +
                                   " ELSE " +
                                   " UPDATE NVO_AgencyAccDtls SET AgencyID=@AgencyID,CurrID=@CurrID,AccNotes=@AccNotes,FromMonth=@FromMonth,ToMonth=@ToMonth,DtAdded=@DtAdded where AgencyID=@AgencyID ";

                    // Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FromMonth", Data.FromMonth));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrID", Data.CurrID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ToMonth", Data.ToMonth));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AccNotes", Data.AccNotes));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtAdded", System.DateTime.Now));
                    int result = Cmd.ExecuteNonQuery();



                    trans.Commit();
                    return ListAgencyAcc;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListAgencyAcc;
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
        public List<MyAccAgency> GetAgencyAccDtls(MyAccAgency Data)
        {
            DataTable dt = GetAgencyAcc(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListAgencyAcc.Add(new MyAccAgency
                {
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),

                    FromMonth = dt.Rows[i]["FromMonth"].ToString(),
                    ToMonth = dt.Rows[i]["ToMonth"].ToString(),
                    CurrID = dt.Rows[i]["CurrID"].ToString(),
                    AccNotes = dt.Rows[i]["AccNotes"].ToString(),


                }); ;
            }
            return ListAgencyAcc;
        }

        public List<MyAccCurrency> CurrencyMaster()
        {
            List<MyAccCurrency> CurrencyList = new List<MyAccCurrency>();
            DataTable dt = GetCurrencyMaster();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CurrencyList.Add(new MyAccCurrency
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString()
                });
            }
            return CurrencyList;
        }

        public DataTable GetCurrencyMaster()
        {
            string _Query = " select * from NVO_CurrencyMaster";
            return GetViewData(_Query, "");
        }
        public DataTable GetAgencyAcc(MyAccAgency Data)
        {
            string _Query = "Select * from NVO_AgencyAccDtls where AgencyID = " + Data.AgencyID + " ";
            return GetViewData(_Query, "");
        }

        public List<MyAlertEmailAgency> InsertAgencyEmailDtls(MyAlertEmailAgency Data)
        {
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
                    Cmd.CommandText = "select ident_current('NVO_AgencyMaster')";
                    if (Data.AgencyID == 0)
                        Data.AgencyID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.AgencyID = Data.AgencyID;

                    Cmd.CommandText =
                         " IF((select count(*) from NVO_AgencyEmailDtls where ID=@ID)<=0) " +
                                   " BEGIN " +
                          " INSERT INTO  NVO_AgencyEmailDtls(AgencyID,AlertTypeID,EMailID,DtAdded) " +
                                     " values (@AgencyID,@AlertTypeID,@EMailID,@DtAdded) " +
                    " END  " +
                                   " ELSE " +
                                   " UPDATE NVO_AgencyEmailDtls SET AgencyID=@AgencyID,AlertTypeID=@AlertTypeID,EMailID=@EMailID,DtAdded=@DtAdded where ID=@ID ";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.AgEmailDtlsID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AlertTypeID", Data.AlertTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EMailID", Data.EmailID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtAdded", System.DateTime.Now));
                    int result = Cmd.ExecuteNonQuery();


                    trans.Commit();
                    return ListAgencyEmail;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListAgencyEmail;
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

        public List<MyAlertEmailAgency> GetAgencyAlertEmailView(MyAlertEmailAgency Data)
        {
            DataTable dt = GetAgencyAlertEmail(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListAgencyEmail.Add(new MyAlertEmailAgency
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AlertTypeID = dt.Rows[i]["AlertType"].ToString(),
                    EmailID = dt.Rows[i]["EmailID"].ToString(),

                });
            }
            return ListAgencyEmail;
        }
        public DataTable GetAgencyAlertEmail(MyAlertEmailAgency Data)
        {
            string _Query = "select (Select Top 1 GeneralName from NVO_GeneralMaster Where ID=AlertTypeID) AlertType ,* from NVO_AgencyEmailDtls where AgencyID = " + Data.AgencyID + " ";
            return GetViewData(_Query, "");
        }

        public List<MyAlertEmailAgency> GetAgencyEmailDetails(MyAlertEmailAgency Data)
        {
            DataTable dt = GetAgencyEmailRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListAgencyEmail.Add(new MyAlertEmailAgency
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    AlertTypeID = dt.Rows[i]["AlertTypeID"].ToString(),
                    EmailID = dt.Rows[i]["EmailID"].ToString(),

                }); ;
            }

            return ListAgencyEmail;
        }

        public DataTable GetAgencyEmailRecord(MyAlertEmailAgency Data)
        {
            string _Query = "Select * from NVO_AgencyEmailDtls where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public DataTable DelAgencyEmailDtls(MyAlertEmailAgency Data)
        {

            string _Query = " Delete NVO_AgencyEmailDtls where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyAgency> ListOrganizationType()
        {
            DataTable dt = GetOrganizationlist();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListAgency.Add(new MyAgency
                {
                    OrganizationType = dt.Rows[i]["OrganizationType"].ToString(),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListAgency;
        }

        public DataTable GetOrganizationlist()
        {
            string _Query = "select Id as OrganizationType,GeneralName from NVO_GeneralMaster where seqno=11 ";
            return GetViewData(_Query, "");
        }

        public List<MyAgency> GeoLocationsList()
        {
            DataTable dt = GetGeoLocationsList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListAgency.Add(new MyAgency
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeoLocation = dt.Rows[i]["GeoLocation"].ToString()
                });
            }
            return ListAgency;
        }

        public DataTable GetGeoLocationsList()
        {
            string _Query = "select * from NVO_GeoLocations ";
            return GetViewData(_Query, "");
        }

        public List<MyAgency> ExistAgencyValidation(MyAgency Data)
        {
            DataTable dt = GetExistServiceValidations(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListAgency.Add(new MyAgency
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),
                    AgencyCode = dt.Rows[i]["AgencyCode"].ToString(),
                });
            }
            return ListAgency;
        }

        public DataTable GetExistServiceValidations(MyAgency Data)

        {
            string _Query = " select * from NVO_AgencyMaster where AgencyName ='" + Data.AgencyName + "' or AgencyCode='" + Data.AgencyCode + "'";
            return GetViewData(_Query, "");
        }
        #endregion

        #region Online Portal Creation

        List<MyOnlinePortal> ListOC = new List<MyOnlinePortal>();
        public List<MyOnlinePortal> BindPartyWiseByRole(MyOnlinePortal Data)
        {
            DataTable dt = GetBindPartyWiseByRole(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListOC.Add(new MyOnlinePortal
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PartyName = dt.Rows[i]["CustomerName"].ToString(),

                });
            }


            return ListOC;
        }

        public DataTable GetBindPartyWiseByRole(MyOnlinePortal Data)
        {
            if (Data.ID == 1)
            {
                string _Query = "Select * from NVO_CustomerMaster  where CustomerType <> 44";
                return GetViewData(_Query, "");
            }
            else
            {
                string _Query = "Select * from NVO_CustomerMaster where CustomerType=44 ";
                return GetViewData(_Query, "");
            }
        }

        public List<MyOnlinePortal> InsertOnlinePortal(MyOnlinePortal Data)
        {

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

                    Cmd.CommandText = " IF((select count(*) from NVO_OnlinePortal where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_OnlinePortal(UserName,Password,RoleID,PartyID,DepotID,Status,DtAdded) " +
                                     " values (@UserName,@Password,@RoleID,@PartyID,@DepotID,@Status,@DtAdded) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_OnlinePortal SET UserName=@UserName,Password=@Password,RoleID=@RoleID,PartyID=@PartyID,DepotID=@DepotID,Status=@Status where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserName", Data.UserName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Password", Data.Password));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RoleID", Data.RoleID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyID", Data.PartyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepotID", Data.DepotID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", Data.Status));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DtAdded", System.DateTime.Now));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    Cmd.CommandText = "select ident_current('NVO_OnlinePortal')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    if (Data.RoleID.ToString() == "1")
                    {
                        string[] Array = Data.Itemsv.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_OnlinePortalDtls where PID=@PID and OPID=@OPID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_OnlinePortalDtls(BusinessTypeID,PartyID,BusinessType,Party,DtAdded,OPID) " +
                                         " values (@BusinessTypeID,@PartyID,@BusinessType,@Party,@DtAdded,@OPID) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_OnlinePortalDtls SET BusinessTypeID=@BusinessTypeID,PartyID=@PartyID,BusinessType=@BusinessType,Party=@Party,OPID=@OPID where OPID=@OPID and PID=@PID ";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BusinessTypeID", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@BusinessType", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@PartyID", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Party", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@OpID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Dtadded", System.DateTime.Now.Date.ToString()));
                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }

                    }
                    trans.Commit();
                    ListOC.Add(new MyOnlinePortal { ID = Data.ID });
                    return ListOC;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListOC;
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

        public List<MyOnlinePortal> BindOnlinePortalView(MyOnlinePortal Data)
        {
            DataTable dt = GetOnlinePortalValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListOC.Add(new MyOnlinePortal
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    Role = dt.Rows[i]["Role"].ToString(),
                    Party = dt.Rows[i]["Party"].ToString(),
                    Depot = dt.Rows[i]["Depot"].ToString(),
                    StatusResult = dt.Rows[i]["StatusResult"].ToString(),


                });
            }
            return ListOC;
        }
        public DataTable GetOnlinePortalValues(MyOnlinePortal Data)
        {
            string strWhere = "";

            string _Query = "Select ID,UserName,case when RoleID=1 Then 'Customer' else 'Vendor-Depo' end as Role,(select top(1) CustomerName from NVO_CustomerMaster where ID = PartyID) AS Party,(select top(1) DepName from NVO_DepotMaster where ID = DepotID) AS Depot,case when STATUS = 1 Then 'Active' else 'InActive' end as StatusResult from NVO_OnlinePortal ";

            if (Data.RoleID.ToString() != "" && Data.RoleID.ToString() != null && Data.RoleID.ToString() != "?" && Data.RoleID.ToString() != "0")
                if (strWhere == "")
                    strWhere += _Query + " Where RoleID=" + Data.RoleID;
                else
                    strWhere += " and RoleID=" + Data.RoleID;

            if (Data.PartyID.ToString() != "" && Data.PartyID.ToString() != null && Data.PartyID.ToString() != "?" && Data.PartyID.ToString() != "0")
                if (strWhere == "")
                    strWhere += _Query + " Where PartyID=" + Data.PartyID;
                else
                    strWhere += " and PartyID =" + Data.PartyID;

            if (strWhere == "")
                strWhere = _Query + " order by NVO_OnlinePortal.ID desc "; ;

            return cm.GetViewData(strWhere, "");

        }


        public List<MyOnlinePortal> BindOnlinePortalEdit(MyOnlinePortal Data)
        {
            DataTable dt = GetOnlinePortalEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListOC.Add(new MyOnlinePortal
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    Password = dt.Rows[i]["Password"].ToString(),
                    RoleID = Int32.Parse(dt.Rows[i]["RoleID"].ToString()),
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    DepotID = Int32.Parse(dt.Rows[i]["DepotID"].ToString()),
                    Status = Int32.Parse(dt.Rows[i]["Status"].ToString()),


                });
            }
            return ListOC;
        }
        public DataTable GetOnlinePortalEditValues(MyOnlinePortal Data)
        {
            string _Query = "Select * from  NVO_OnlinePortal Where ID= " + Data.ID;

            return cm.GetViewData(_Query, "");

        }

        public List<MyOnlinePortal> BindOnlinePortalDtlsEdit(MyOnlinePortal Data)
        {
            DataTable dt = GetOnlinePortalDtlsEditValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListOC.Add(new MyOnlinePortal
                {

                    PID = Int32.Parse(dt.Rows[i]["PID"].ToString()),
                    Party = dt.Rows[i]["Party"].ToString(),
                    PartyID = Int32.Parse(dt.Rows[i]["PartyID"].ToString()),
                    PartyTypeID = Int32.Parse(dt.Rows[i]["BusinessTypeID"].ToString()),
                    PartyType = dt.Rows[i]["BusinessType"].ToString(),



                });
            }
            return ListOC;
        }
        public DataTable GetOnlinePortalDtlsEditValues(MyOnlinePortal Data)
        {
            string _Query = "Select * from NVO_OnlinePortalDtls Where OPID= " + Data.ID;

            return cm.GetViewData(_Query, "");

        }
        #endregion




        public List<MyAgency> RoleMasterList()
        {
            DataTable dt = GetRoleList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListAgency.Add(new MyAgency
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RoleName = dt.Rows[i]["RoleCode"].ToString()
                });
            }
            return ListAgency;
        }

        public DataTable GetRoleList()
        {
            string _Query = "select Id,RoleCode from NVO_StaffRoleMasterDtls ";
            return GetViewData(_Query, "");
        }

        #region Vendor MASTER

        public List<MyCustomer> GetVendorMaster(MyCustomer Data)
        {
            DataTable dt = GetVendorMasterValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    CityName = dt.Rows[i]["CityName"].ToString(),
                    StateName = dt.Rows[i]["StateName"].ToString(),
                    PartyType = dt.Rows[i]["PartyType"].ToString()

                });

            }
            return ListCustomer;
        }
        public DataTable GetVendorMasterValues(MyCustomer Data)
        {
            string strWhere = "";

            string _Query = "select  ID,CustomerName,(Select top(1) CountryName from NVO_CountryMaster WHERE ID = CountryID)  CountryName, (Select top(1) CityName from NVO_CityMaster WHERE ID = CityID)  CityName, " +
              " (Select top(1) StateName from NVO_StateMaster WHERE ID = StateID)  StateName,(Select top(1) GeneralName from NVO_GeneralMaster " +
                " WHERE ID = CustomerType)  PartyType, CustomerType from NVO_CustomerMaster WHERE CustomerType=2 ";

            if (Data.CustomerName != "")
                if (strWhere == "")
                    strWhere += _Query + " and CustomerName like '%" + Data.CustomerName + "%'";
                else
                    strWhere += " and CustomerName like '%" + Data.CustomerName + "%'";

            if (Data.CountryID.ToString() != "" && Data.CountryID.ToString() != null && Data.CountryID.ToString() != "0" && Data.CountryID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " and CountryID=" + Data.CountryID.ToString();
                else
                    strWhere += " and CountryID =" + Data.CountryID.ToString();

            if (Data.CustomerType.ToString() != "" && Data.CustomerType.ToString() != null && Data.CustomerType.ToString() != "0" && Data.CustomerType.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " and CustomerType=" + Data.CustomerType.ToString();
                else
                    strWhere += " and CustomerType =" + Data.CustomerType.ToString();


            if (strWhere == "")
                strWhere = _Query + " order by NVO_CustomerMaster.ID desc ";

            return GetViewData(strWhere, "");

        }

        public List<MyCustomer> InsertVendorMaster(MyCustomer Data)
        {

            int r1 = 0;
            int r2 = 0;
            DbConnection con = null;
            DbTransaction trans;
            DataTable ChckExist = GetExistingVendor(Data);
            if (Data.ID == 0)
            {
                if (ChckExist.Rows.Count >= 1)
                {
                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "1",
                        AlertMessage = "Vendor Name Already Exists"

                    }); ;
                    return ListCustomer;
                }
            }
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
                                      //" INSERT INTO  NVO_CustomerMaster(CustomerName,CustomerType,CountryID,CityID,StateID,PinCode,Tel,Fax,GSTINTax,EmailID,Address,CurrentDate) " +
                                      //" values (@CustomerName,@CustomerType,@CountryID,@CityID,@StateID,@PinCode,@Tel,@Fax,@GSTINTax,@EmailID,@Address,@CurrentDate) " +
                                      //" END  " +
                                      //" ELSE " +
                                      //" UPDATE NVO_CustomerMaster SET CustomerName=@CustomerName,CustomerType=@CustomerType,CountryID=@CountryID,CityID=@CityID,StateID=@StateID,PinCode=@PinCode,Tel=@Tel,Fax=@Fax,GSTINTax=@GSTINTax,EmailID=@EmailID,Address=@Address,CurrentDate=@CurrentDate where ID=@ID";
                                      " INSERT INTO  NVO_CustomerMaster(CustomerName,CountryID,CustomerType,IsFF,IsNVOCC,CurrentDate) " +
                                     " values (@CustomerName,@CountryID,@CustomerType,@IsFF,@IsNVOCC,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CustomerMaster SET CustomerName=@CustomerName,CountryID=@CountryID,IsFF=@IsFF,CustomerType=@CustomerType,IsNVOCC=@IsNVOCC,CurrentDate=@CurrentDate where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerName", Data.CustomerName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerType", 2));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsFF", Data.IsFF));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsNVOCC", Data.IsNVOCC));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_CustomerMaster')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    string[] Arrayd = Data.DivisionDetails.TrimEnd(',').Split(',');

                    Cmd.CommandText = "delete from NVO_CusDivisionTypes where CustomerID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();

                    for (int i = 0; i < Arrayd.Length; i++)
                    {
                        Cmd.CommandText = " IF((select count(*) from NVO_CusDivisionTypes where CustomerID=@CustomerID and DivisionID=@DivisionID)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_CusDivisionTypes(CustomerID,DivisionID) " +
                                    " values (@CustomerID,@DivisionID) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_CusDivisionTypes SET CustomerID=@CustomerID,DivisionID=@DivisionID where CustomerID=@CustomerID and DivisionID=@DivisionID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DivisionID", Arrayd[i]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }



                    string[] Array = Data.BusinessType.TrimEnd(',').Split(',');

                    Cmd.CommandText = "delete from NVO_CusBusinessTypes where CustomerID=" + Data.ID;
                    result = Cmd.ExecuteNonQuery();

                    for (int i = 0; i < Array.Length; i++)
                    {
                        Cmd.CommandText = " IF((select count(*) from NVO_CusBusinessTypes where CustomerID=@CustomerID and BussTypes=@BussTypes)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_CusBusinessTypes(CustomerID,BussTypes) " +
                                    " values (@CustomerID,@BussTypes) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_CusBusinessTypes SET CustomerID=@CustomerID,BussTypes=@BussTypes where CustomerID=@CustomerID and BussTypes=@BussTypes";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BussTypes", Array[i]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    for (int i = 0; i < Array.Length; i++)
                    {
                        Cmd.CommandText = " IF((select count(*) from NVO_CusBusinessTypes where CustomerID=@CustomerID and BussTypes=@BussTypes)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  NVO_CusBusinessTypes(CustomerID,BussTypes) " +
                                    " values (@CustomerID,@BussTypes) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE NVO_CusBusinessTypes SET CustomerID=@CustomerID,BussTypes=@BussTypes where CustomerID=@CustomerID and BussTypes=@BussTypes";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BussTypes", Array[i]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);



                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().Split(new[] { "Address:" }, StringSplitOptions.None);
                        var CharSplitA = CharSplit[0].ToString().Split(',');
                        var CharSplitB = CharSplit[1].ToString();



                        Cmd.CommandText = " IF((select count(*) from NVO_CusBranchLocation where CID=@CID and CustomerID=@CustomerID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_CusBranchLocation(CustomerID,City,CityID,State,StateID,Address,CurrentDate,Branch,TelNo,PinCode,EmailID,Status,StatusID,PIC) " +
                                        " values (@CustomerID,@City,@CityID,@State,@StateID,@Address,@CurrentDate,@Branch,@TelNo,@PinCode,@EmailID,@Status,@StatusID,@PIC) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_CusBranchLocation SET CustomerID=@CustomerID,CityID=@CityID,City=@City,State=@State,StateID=@StateID,Address=@Address,CurrentDate=@CurrentDate,Branch=@Branch,TelNo=@TelNo,PinCode=@PinCode,EmailID=@EmailID,StatusID=@StatusID,Status=@Status,PIC=@PIC where CID=@CID and CustomerID=@CustomerID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CID", CharSplitA[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Branch", CharSplitA[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CityID", CharSplitA[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@City", CharSplitA[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StateID", CharSplitA[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@State", CharSplitA[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TelNo", CharSplitA[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PinCode", CharSplitA[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EmailID", CharSplitA[8]));
                        // Cmd.Parameters.Add(_dbFactory.GetParameter("@GSTIN", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PIC", CharSplitA[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", CharSplitA[10]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Status", CharSplitA[11]));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@PanNo", 0));
                        //Cmd.Parameters.Add(_dbFactory.GetParameter("@TanNo", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", CharSplitB));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));


                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }


                    trans.Commit();

                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListCustomer;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListCustomer;
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


        public DataTable GetExistingVendor(MyCustomer Data)
        {
            string Strwhere = "select * from NVO_CustomerMaster Where CustomerType=2 and CustomerName = '" + Data.CustomerName + "'";
            return GetViewData(Strwhere, "");
        }
        public List<MyCustomer> InsertVenSalesLinkMaster(MyCustomer Data)
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

                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_CusSalesLink where BranchID=@BranchID and CustomerID=@CustomerID)<=0) " +
                                        " BEGIN " +
                                        " INSERT INTO  NVO_CusSalesLink(BranchID,Branch,CustomerID,CurrentDate,GSTListID,GSTINTax,GSTNo,LegalName,PAN,	TANNo,POSID,POS,TDS,TDSType,CurrencyID,CurrencyCode) " +
                                        " values (@BranchID,@Branch,@CustomerID,@CurrentDate,@GSTListID,@GSTINTax,@GSTNo,@LegalName,@PAN,	@TANNo,@POSID,@POS,@TDS,@TDSType,@CurrencyID,@CurrencyCode) " +
                                        " END  " +
                                        " ELSE " +
                                        " UPDATE NVO_CusSalesLink SET BranchID=@BranchID,Branch=@Branch,CustomerID=@CustomerID,CurrentDate=@CurrentDate,GSTListID=@GSTListID,GSTINTax=@GSTINTax,GSTNo=@GSTNo,LegalName=@LegalName,PAN=@PAN,TANNo=@TANNo,POSID=@POSID,POS=@POS,TDS=@TDS,TDSType=@TDSType,CurrencyID=@CurrencyID where BranchID=@BranchID and CustomerID=@CustomerID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BranchID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Branch", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CustomerID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GSTListID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GSTINTax", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@GSTNo", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@LegalName", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PAN", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TANNo", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@POSID", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@POS", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TDS", CharSplit[10]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TDSType", CharSplit[11]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyID", CharSplit[12]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrencyCode", CharSplit[13]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));


                        int result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }




                    trans.Commit();
                    return ListCustomer;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListCustomer;
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

        public List<MyCustomer> GetVendorSalesLinkMaster(MyCustomer Data)
        {
            DataTable dt = GetVenSalesLinkValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCustomer.Add(new MyCustomer
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BranchID = Int32.Parse(dt.Rows[i]["BranchID"].ToString()),
                    Branch = dt.Rows[i]["Branch"].ToString(),
                    GSTListID = Int32.Parse(dt.Rows[i]["GSTListID"].ToString()),
                    GSTINTax = dt.Rows[i]["GSTINTax"].ToString(),
                    GSTNo = dt.Rows[i]["GSTNo"].ToString(),
                    Legalname = dt.Rows[i]["Legalname"].ToString(),
                    PAN = dt.Rows[i]["PAN"].ToString(),
                    TAN = dt.Rows[i]["PAN"].ToString(),
                    POSID = Int32.Parse(dt.Rows[i]["POSID"].ToString()),
                    POS = dt.Rows[i]["POS"].ToString(),
                    CurrID = Int32.Parse(dt.Rows[i]["CurrencyID"].ToString()),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString(),
                    TDS = Int32.Parse(dt.Rows[i]["TDS"].ToString()),
                    TDSType = dt.Rows[i]["TDSType"].ToString(),
                });
            }
            return ListCustomer;
        }
        public DataTable GetVenSalesLinkValues(MyCustomer Data)
        {
            string _Query = " select * from NVO_CusSalesLink where CustomerID=" + Data.ID;

            return GetViewData(_Query, "");
        }

        public List<MyCustomer> GetBranchByPOS(MyCustomer Data)
        {
            DataTable dt = GetBranchByPOSValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListCustomer.Add(new MyCustomer
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    StateName = dt.Rows[i]["StateName"].ToString()

                }); ;
            }
            return ListCustomer;
        }
        public DataTable GetBranchByPOSValues(MyCustomer Data)
        {
            string _Query = " select SM.ID,SM.StateName from NVO_CusBranchLocation CB INNER JOIN NVO_StateMaster SM ON SM.ID = CB.StateID  WHERE CB.CID = " + Data.BranchID;

            return GetViewData(_Query, "");
        }

        public List<MyCustomer> CusVendorBranchDeleteMaster(MyCustomer Data)
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

                    Cmd.CommandText = "Delete from NVO_CusBranchLocation where CID=" + Data.ID;
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Deleted Successfully"
                    });
                    return ListCustomer;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListCustomer;
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

        public List<MyCustomer> CusVendorAccLinkDeleteMaster(MyCustomer Data)
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

                    Cmd.CommandText = "Delete from NVO_CusSalesLink where ID=" + Data.ID;
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Deleted Successfully"
                    });
                    return ListCustomer;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListCustomer;
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

        public List<MyCustomer> CusVendorCrLinkDeleteMaster(MyCustomer Data)
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

                    Cmd.CommandText = "Delete from NVO_CusCreditLimitDtls where ID=" + Data.ID;
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Deleted Successfully"
                    });
                    return ListCustomer;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListCustomer;
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

        public List<MyCustomer> CusVendorAlertLinkDeleteMaster(MyCustomer Data)
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

                    Cmd.CommandText = "Delete from NVO_CusEmailAlerts where ID=" + Data.ID;
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();

                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Deleted Successfully"
                    });
                    return ListCustomer;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCustomer.Add(new MyCustomer
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListCustomer;
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

        public List<MyCustomer> PartyExistingDivisionTypesMaster(MyCustomer Data)
        {

            DataTable dt = GetPartyExistingDivisionTypesValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCustomer.Add(new MyCustomer
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Division = dt.Rows[i]["GeneralName"].ToString(),
                    IsTrue = Int32.Parse(dt.Rows[i]["IsTrue"].ToString()),

                });

            }
            return ListCustomer;
        }
        public DataTable GetPartyExistingDivisionTypesValues(MyCustomer Data)
        {
            string _Query = "select ID, GeneralName, case when(select top(1) DivisionID from NVO_CusDivisionTypes where DivisionID = NVO_GeneralMaster.ID and CustomerID = " + Data.ID + ") > 0 then 1 else 0 end as IsTrue from NVO_GeneralMaster where SeqNo=56 ";
            return GetViewData(_Query, "");
        }
        #endregion


        #region get values
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
    }
}
