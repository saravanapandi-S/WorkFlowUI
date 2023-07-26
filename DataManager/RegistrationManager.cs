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
    public class RegistrationManager
    {
        List<MyDataBusinessLogic> List = new List<MyDataBusinessLogic>();
        List<MyMenu> ListMenu = new List<MyMenu>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public RegistrationManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region Public Method
        #region Menus

        public DataTable GetMenusValuesFirstAll()
        {
            string _Query = " select * from NVO_Menu where IsCommon=1";
            return GetViewData(_Query, "");
        }

        public DataTable GetMenusValuesFirstAllUser(int UserID)
        {
           // // string _Query = "select * from NVO_Menu where Id in (select distinct MenuID from V_MainMenus where USERID= " + UserID + ")";

            string _Query = " select Id,FileName,Description,Url,NVO_Menu.MenuID,MenuOrder,CSSPage from NVO_Menu where Id in (select distinct MenuID from V_MainMenus where USERID= " + UserID + ") " +
                            " union " +
                            " select NVO_Menu.ID,FileName,Description,Url,NVO_Menu.MenuID,MenuOrder,CSSPage from NVO_UserRoleDetails " +
                            " inner join NVO_StaffRoleMasterDtls on NVO_StaffRoleMasterDtls.ID = NVO_UserRoleDetails.RoleID " +
                            " inner join NVO_StaffRoleMasterMenuDtls on NVO_StaffRoleMasterMenuDtls.RoleID = NVO_StaffRoleMasterDtls.ID " +
                            " inner join NVO_Menu on NVO_Menu.ID = NVO_StaffRoleMasterMenuDtls.MenuID " +
                            " where UserID = " + UserID + " and NVO_Menu.MenuID in (select distinct MenuID from V_MainMenus where USERID = " + UserID + ")";


            return GetViewData(_Query, "");
        }
        public DataTable GetMenusValuesFirst()
        {
            string _Query = " select * from NVO_Menu where MenuId=0 and IsCommon=1";
            return GetViewData(_Query, "");
        }

        public DataTable GetMenusValuesTow(string MenuID)
        {
            string _Query = " select * from NVO_Menu where MenuId=" + MenuID;
            return GetViewData(_Query, "");

        }

        public DataTable MenusThiredLevelNew(string MenuID)
        {

            string _Query = "select * from NVO_Menu where MenuId=" + MenuID + " order by MenuOrder";
            return GetViewData(_Query, "");

        }

        public DataTable MenusFourthLevelNew(string MenuID)
        {
            string _Query = "select * from NVO_Menu where MenuId=" + MenuID + " order by Nav_Menu.MenuOrder";
            return GetViewData(_Query, "");

        }

        public List<MyMenu> MenusMaster(MyMenu Data)
        {
            string HTMStr = "";
            HTMStr = "<li class='active'>";
            HTMStr += "<a href='/Home/Dashboard'><i class='fa fa-dashboard'></i> DASHBOARD</a>";
            HTMStr += "</li>";
            if (Data.UserID == 1)
            {
                DataTable dtMenu = GetMenusValuesFirstAll();
                DataTable _dtFirstMenu = dtMenu.Select("MenuID=0", " MenuOrder ASC").CopyToDataTable();
                for (int i = 0; i < _dtFirstMenu.Rows.Count; i++)
                {
                    string Name = _dtFirstMenu.Rows[i]["FileName"].ToString();
                    HTMStr += "<li class='treeview'>";
                    HTMStr += "<a href='/Home/Dashboard'><i class='" + _dtFirstMenu.Rows[i]["CSSPage"].ToString() + "' aria-hidden='true'></i><span>" + _dtFirstMenu.Rows[i]["FileName"].ToString() + "</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";


                    DataRow[] dtTwRow = dtMenu.Select("MenuID='" + Convert.ToInt64(_dtFirstMenu.Rows[i]["ID"].ToString()) + "'");

                    if (dtTwRow.Length > 0)
                    {

                        DataTable _dtsecondMenu = dtMenu.Select("MenuID='" + Convert.ToInt64(_dtFirstMenu.Rows[i]["ID"].ToString()) + "'").CopyToDataTable();
                        // DataTable _dtsecondMenu = GetMenusValuesTow(_dtFirstMenu.Rows[i]["ID"].ToString());
                        if (_dtsecondMenu.Rows.Count > 0)
                        {
                            HTMStr += "<ul class='treeview-menu'>";
                            for (int y = 0; y < _dtsecondMenu.Rows.Count; y++)
                            {
                                if (_dtsecondMenu.Rows[y]["Url"].ToString() == "")
                                {

                                    string hhh = "<li class='treeview'><a href='#'><i class='fa fa-bookmark-o' aria-hidden='true'></i> <span>" + _dtsecondMenu.Rows[y]["FileName"].ToString() + "</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i> </span></a>";
                                    HTMStr += "<li class='treeview'><a href='#'><i class='fa fa-bookmark-o' aria-hidden='true'></i> <span>" + _dtsecondMenu.Rows[y]["FileName"].ToString() + "</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i> </span></a>";
                                }
                                else
                                {
                                    HTMStr += "<li><a href='" + _dtsecondMenu.Rows[y]["Url"].ToString() + "'><i class='fa fa-angle-double-right'></i> <span>" + _dtsecondMenu.Rows[y]["FileName"].ToString() + "</span> </a></li>";
                                }
                                string Id = _dtsecondMenu.Rows[y]["ID"].ToString();
                                if (_dtsecondMenu.Rows[y]["ID"].ToString() != "")
                                {
                                    DataRow[] _dtRows = dtMenu.Select("MenuID='" + Convert.ToInt64(_dtsecondMenu.Rows[y]["ID"].ToString()) + "'");
                                    if (_dtRows.Length > 0)
                                    {

                                        DataTable _dtTriredMenu = dtMenu.Select("MenuID='" + Convert.ToInt64(_dtsecondMenu.Rows[y]["ID"].ToString()) + "'").CopyToDataTable();

                                        //DataTable _dtTriredMenu = MenusThiredLevelNew(_dtsecondMenu.Rows[y]["ID"].ToString());
                                        if (_dtTriredMenu.Rows.Count > 0)
                                        {
                                            HTMStr += "<ul class='treeview-menu'>";
                                            for (int x = 0; x < _dtTriredMenu.Rows.Count; x++)
                                            {
                                                if (_dtTriredMenu.Rows[x]["Url"].ToString() != "")
                                                    HTMStr += "<li><a href='" + _dtTriredMenu.Rows[x]["Url"].ToString() + "'><i class='fa fa-angle-double-right'></i> <span>" + _dtTriredMenu.Rows[x]["FileName"].ToString() + "</span> </a></li>";
                                                else
                                                {
                                                    string bb = _dtTriredMenu.Rows[x]["FileName"].ToString();
                                                    HTMStr += "<li class='treeview'><a href='#'><i class='fa fa-bookmark-o' aria-hidden='true'></i> <span>" + _dtTriredMenu.Rows[x]["FileName"].ToString() + "</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i> </span></a>";
                                                    HTMStr += "<ul class='treeview-menu'>";
                                                    string idff = _dtTriredMenu.Rows[x]["ID"].ToString();

                                                    DataRow[] _dtRowsF = dtMenu.Select("MenuID='" + Convert.ToInt64(_dtTriredMenu.Rows[x]["ID"].ToString()) + "'");
                                                    if (_dtRowsF.Length > 0)
                                                    {
                                                        DataTable dtfourth = dtMenu.Select("MenuID='" + Convert.ToInt64(_dtTriredMenu.Rows[x]["ID"].ToString()) + "'").CopyToDataTable();
                                                        //DataTable dtfourth = MenusFourthLevelNew(_dtTriredMenu.Rows[x]["ID"].ToString());
                                                        for (int n = 0; n < dtfourth.Rows.Count; n++)
                                                        {
                                                            HTMStr += "<li><a href='" + dtfourth.Rows[n]["Url"].ToString() + "'><i class='fa fa-angle-double-right'></i> <span>" + dtfourth.Rows[n]["FileName"].ToString() + "</span> </a></li>";
                                                        }

                                                    }
                                                    HTMStr += "</li>";
                                                    HTMStr += "</ul>";
                                                }

                                            }
                                            HTMStr += "</ul>";
                                        }
                                    }

                                }
                            }
                            HTMStr += "</ul>";
                            HTMStr += "</li>";
                        }
                    }


                }

            }
            else
            {
                DataTable dtMenu = GetMenusValuesFirstAllUser(Data.UserID);

                DataTable _dtFirstMenu = dtMenu.Select("MenuID=0", " MenuOrder ASC").CopyToDataTable();
                for (int i = 0; i < _dtFirstMenu.Rows.Count; i++)
                {
                    string Name = _dtFirstMenu.Rows[i]["FileName"].ToString();
                    HTMStr += "<li class='treeview'>";
                    HTMStr += "<a href='/Home/Dashboard'><i class='" + _dtFirstMenu.Rows[i]["CSSPage"].ToString() + "' aria-hidden='true'></i><span>" + _dtFirstMenu.Rows[i]["FileName"].ToString() + "</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";


                    DataRow[] dtTwRow = dtMenu.Select("MenuID='" + Convert.ToInt64(_dtFirstMenu.Rows[i]["ID"].ToString()) + "'");

                    if (dtTwRow.Length > 0)
                    {

                        DataTable _dtsecondMenu = dtMenu.Select("MenuID='" + Convert.ToInt64(_dtFirstMenu.Rows[i]["ID"].ToString()) + "'").CopyToDataTable();
                        // DataTable _dtsecondMenu = GetMenusValuesTow(_dtFirstMenu.Rows[i]["ID"].ToString());
                        if (_dtsecondMenu.Rows.Count > 0)
                        {
                            HTMStr += "<ul class='treeview-menu'>";
                            for (int y = 0; y < _dtsecondMenu.Rows.Count; y++)
                            {
                                if (_dtsecondMenu.Rows[y]["Url"].ToString() == "")
                                {

                                    string hhh = "<li class='treeview'><a href='#'><i class='fa fa-bookmark-o' aria-hidden='true'></i> <span>" + _dtsecondMenu.Rows[y]["FileName"].ToString() + "</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i> </span></a>";
                                    HTMStr += "<li class='treeview'><a href='#'><i class='fa fa-bookmark-o' aria-hidden='true'></i> <span>" + _dtsecondMenu.Rows[y]["FileName"].ToString() + "</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i> </span></a>";
                                }
                                else
                                {
                                    HTMStr += "<li><a href='" + _dtsecondMenu.Rows[y]["Url"].ToString() + "'><i class='fa fa-angle-double-right'></i> <span>" + _dtsecondMenu.Rows[y]["FileName"].ToString() + "</span> </a></li>";
                                }
                                string Id = _dtsecondMenu.Rows[y]["ID"].ToString();
                                if (_dtsecondMenu.Rows[y]["ID"].ToString() != "")
                                {
                                    DataRow[] _dtRows = dtMenu.Select("MenuID='" + Convert.ToInt64(_dtsecondMenu.Rows[y]["ID"].ToString()) + "'");
                                    if (_dtRows.Length > 0)
                                    {

                                        DataTable _dtTriredMenu = dtMenu.Select("MenuID='" + Convert.ToInt64(_dtsecondMenu.Rows[y]["ID"].ToString()) + "'").CopyToDataTable();

                                        //DataTable _dtTriredMenu = MenusThiredLevelNew(_dtsecondMenu.Rows[y]["ID"].ToString());
                                        if (_dtTriredMenu.Rows.Count > 0)
                                        {
                                            HTMStr += "<ul class='treeview-menu'>";
                                            for (int x = 0; x < _dtTriredMenu.Rows.Count; x++)
                                            {
                                                if (_dtTriredMenu.Rows[x]["Url"].ToString() != "")
                                                    HTMStr += "<li><a href='" + _dtTriredMenu.Rows[x]["Url"].ToString() + "'><i class='fa fa-angle-double-right'></i> <span>" + _dtTriredMenu.Rows[x]["FileName"].ToString() + "</span> </a></li>";
                                                else
                                                {
                                                    string bb = _dtTriredMenu.Rows[x]["FileName"].ToString();
                                                    HTMStr += "<li class='treeview'><a href='#'><i class='fa fa-bookmark-o' aria-hidden='true'></i> <span>" + _dtTriredMenu.Rows[x]["FileName"].ToString() + "</span><span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i> </span></a>";
                                                    HTMStr += "<ul class='treeview-menu'>";
                                                    string idff = _dtTriredMenu.Rows[x]["ID"].ToString();

                                                    DataRow[] _dtRowsF = dtMenu.Select("MenuID='" + Convert.ToInt64(_dtTriredMenu.Rows[x]["ID"].ToString()) + "'");
                                                    if (_dtRowsF.Length > 0)
                                                    {
                                                        DataTable dtfourth = dtMenu.Select("MenuID='" + Convert.ToInt64(_dtTriredMenu.Rows[x]["ID"].ToString()) + "'").CopyToDataTable();
                                                        //DataTable dtfourth = MenusFourthLevelNew(_dtTriredMenu.Rows[x]["ID"].ToString());
                                                        for (int n = 0; n < dtfourth.Rows.Count; n++)
                                                        {
                                                            HTMStr += "<li><a href='" + dtfourth.Rows[n]["Url"].ToString() + "'><i class='fa fa-angle-double-right'></i> <span>" + dtfourth.Rows[n]["FileName"].ToString() + "</span> </a></li>";
                                                        }

                                                    }
                                                    HTMStr += "</li>";
                                                    HTMStr += "</ul>";
                                                }

                                            }
                                            HTMStr += "</ul>";
                                        }
                                    }

                                }
                            }
                            HTMStr += "</ul>";
                            HTMStr += "</li>";
                        }
                    }


                }
            }

            ListMenu.Add(new MyMenu
            {
                Url = HTMStr

            });
            return ListMenu;
        }


    


        #endregion
        public List<MyDataBusinessLogic> InsertUserMaster(MyDataBusinessLogic Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_Reg where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Reg(Name,Mobile,Email,UserName,Password,UserCode,Location,Designation,Branch,Address,CurrentDate) " +
                                     " values (@Name,@Mobile,@Email,@UserName,@Password,@UserCode,@Location,@Designation,@Branch,@Address,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Reg SET Name=@Name,Mobile=@Mobile,Email=@Email,UserName=@UserName,Password=@Password,UserCode=@UserCode,Location=@Location,Designation=@Designation,Branch=@Branch,Address=@Address,CurrentDate=@CurrentDate where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Name", Data.Name));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Mobile", Data.MobileNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Email", Data.Email));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserName", Data.UserName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Password", Data.Password));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserCode", Data.UserCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Location", Data.Location));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Designation", Data.Designation));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Branch", Data.Branch));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", Data.Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_Reg')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
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

        public List<MyDataBusinessLogic> LoginValues(MyDataBusinessLogic Data)
        {
            DataTable dt = ExistingUser(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List.Add(new MyDataBusinessLogic
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    //CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    LocationIDv = dt.Rows[i]["LocationID"].ToString(),
                    AgencyIDv = dt.Rows[i]["AgencyID"].ToString(),
                    Token = Data.Token,
                    //LocationName = dt.Rows[i]["CityName"].ToString(),
                    //Country = dt.Rows[i]["CountryName"].ToString(),
                    //Agency = dt.Rows[i]["CountryName"].ToString(),
                });

            }
            return List;
        }

        public List<MyDataBusinessLogic> ListFinancialYear(MyDataBusinessLogic Data)
        {
            DataTable dt = GetFinancialYear(Data);
            
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    List.Add(new MyDataBusinessLogic
                    {
                        ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                        YearID = dt.Rows[i]["YearID"].ToString(),
                        FinancialYear = dt.Rows[i]["FinancialYear"].ToString(),
                    });
                }
     
            return List;
        }

        public DataTable GetFinancialYear(MyDataBusinessLogic Data)
        {
            string _query = "select ID,YearID,CONCAT(DATEPART(year, FDate) ,'-' ,  DATEPART(year, TDate)) as FinancialYear  from NVO_FinancialYear ";
            return GetViewData(_query, "");

        }
        public List<MyDataBusinessLogic> BindCurrentFinancialYear(MyDataBusinessLogic Data)
        {
            DataTable dt = GetBindCurrentFinancialYear(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List.Add(new MyDataBusinessLogic
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    YearID = dt.Rows[i]["YearID"].ToString(),
                    FinancialYear = dt.Rows[i]["FinancialYear"].ToString(),
                });
            }

            return List;
        }

        public DataTable GetBindCurrentFinancialYear(MyDataBusinessLogic Data)
        {
            string _query = "select ID,YearID,CONCAT(DATEPART(year, FDate) ,'-' ,  DATEPART(year, TDate)) as FinancialYear  from NVO_FinancialYear where  FDate = DATEFROMPARTS(DATEPART(year, FDate), 4, 1) and Tdate = DATEFROMPARTS(DATEPART(year, TDate), 3, 31) ";
            return GetViewData(_query, "");

        }

        public List<MyDataBusinessLogic> GeoLocationsList()
        {
            List<MyDataBusinessLogic> List = new List<MyDataBusinessLogic>();
            DataTable dt = GetGeoLocationsList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List.Add(new MyDataBusinessLogic
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeoLocation = dt.Rows[i]["GeoLocation"].ToString()
                });
            }
            return List;
        }

        public DataTable GetGeoLocationsList()
        {
            string _Query = "select * from NVO_GeoLocations ";
            return GetViewData(_Query, "");
        }


        public List<MyDataBusinessLogic> GeoLocationsUserList(MyDataBusinessLogic Data)
        {
            List<MyDataBusinessLogic> List = new List<MyDataBusinessLogic>();
            DataTable dt = GetGeoLocationsUserList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                List.Add(new MyDataBusinessLogic
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeoLocation = dt.Rows[i]["GeoLocation"].ToString()
                });
            }
            return List;
        }

        public DataTable GetGeoLocationsUserList(MyDataBusinessLogic Data)
        {
            string _Query = "";
            if (Data.UserID != 1)
                _Query = "select * from NVO_GeoLocations where Id in (select LocationID from NVO_UserRoleDetails where UserID=" + Data.UserID + ")";
            else
                _Query = "select * from NVO_GeoLocations";

            return GetViewData(_Query, "");
        }


        public List<MyDataBusinessLogic> AgencyMasterByGeoloc(MyDataBusinessLogic Data)
        {
            List<MyDataBusinessLogic> AgencyList = new List<MyDataBusinessLogic>();
            DataTable dt = GetAgencyMasterByGeoloc(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AgencyList.Add(new MyDataBusinessLogic
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),
                    DocumentSuffix = dt.Rows[i]["DocumentSuffix"].ToString(),
                });
            }
            return AgencyList;
        }

        public DataTable GetAgencyMasterByGeoloc(MyDataBusinessLogic Data)
        {
            string _Query = "SELECT * FROM NVO_AgencyMaster Where GeoLocationID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyDataBusinessLogic> ListAgencyDocumentSuffix(MyDataBusinessLogic Data)
        {
            List<MyDataBusinessLogic> AgencyList = new List<MyDataBusinessLogic>();
            DataTable dt = GetListAgencyDocumentSuffix(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AgencyList.Add(new MyDataBusinessLogic
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DocumentSuffix = dt.Rows[i]["DocumentSuffix"].ToString(),
                    CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString()),
                    Country = dt.Rows[i]["Country"].ToString(),
                    TaxGST = dt.Rows[i]["TaxGSTNo"].ToString()

                });
            }
            return AgencyList;
        }

        public DataTable GetListAgencyDocumentSuffix(MyDataBusinessLogic Data)
        {
            string _Query = "SELECT  (select top(1) CountryName from NVO_CountryMaster where Id = CountryID) as Country,*  FROM NVO_AgencyMaster Where ID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyDataBusinessLogic> ListMenuListDD(MyDataBusinessLogic Data)
        {
            List<MyDataBusinessLogic> AgencyList = new List<MyDataBusinessLogic>();
            DataTable dt = GetListMenuListDD(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AgencyList.Add(new MyDataBusinessLogic
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Module = dt.Rows[i]["FileName"].ToString(),
                });
            }
            return AgencyList;
        }

        public DataTable GetListMenuListDD(MyDataBusinessLogic Data)
        {
            string _Query = "select * from NVO_Menu  where ID <10 ";
            return GetViewData(_Query, "");
        }

        public List<MyDataBusinessLogic> InsertControlParameter(MyDataBusinessLogic Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_ControlParameter where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ControlParameter(AgencyID,ModuleID,Parameter,Value,StatusID,GLCodeID) " +
                                     " values (@AgencyID,@ModuleID,@Parameter,@Value,@StatusID,@GLCodeID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ControlParameter SET AgencyID=@AgencyID,ModuleID=@ModuleID,Parameter=@Parameter,Value=@Value,StatusID=@StatusID,GLCodeID=@GLCodeID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModuleID", Data.ModuleID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Parameter", Data.Parameter));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Value", Data.Value));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusID", Data.StatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@GLCodeID", Data.GLCodeID));
                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_ControlParameter')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;

                    trans.Commit();
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

        public List<MyDataBusinessLogic> ListControlParameterEdit(MyDataBusinessLogic Data)
        {
            List<MyDataBusinessLogic> AgencyList = new List<MyDataBusinessLogic>();
            DataTable dt = GetControlParameterEdit(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AgencyList.Add(new MyDataBusinessLogic
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    AgencyID = Int32.Parse(dt.Rows[i]["AgencyID"].ToString()),
                    ModuleID = Int32.Parse(dt.Rows[i]["ModuleID"].ToString()),
                    Parameter = dt.Rows[i]["Parameter"].ToString(),
                    Value = dt.Rows[i]["Value"].ToString(),
                    GLCodeID = dt.Rows[i]["GLCodeID"].ToString(),
                    StatusID = Int32.Parse(dt.Rows[i]["StatusID"].ToString()),
                });
            }
            return AgencyList;
        }

        public DataTable GetControlParameterEdit(MyDataBusinessLogic Data)
        {
           
            string _Query = " select * FROM NVO_ControlParameter Where ID="+Data.ID;

            return GetViewData(_Query, "");
        }
        public List<MyDataBusinessLogic> ListControlParameterView(MyDataBusinessLogic Data)
        {
            List<MyDataBusinessLogic> AgencyList = new List<MyDataBusinessLogic>();
            DataTable dt = GetControlParameterView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AgencyList.Add(new MyDataBusinessLogic
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Agency = dt.Rows[i]["Agency"].ToString(),
                    Module = dt.Rows[i]["Module"].ToString(),
                    Parameter = dt.Rows[i]["Parameter"].ToString(),
                    GLCode = dt.Rows[i]["GLCode"].ToString(),
                    Value = dt.Rows[i]["Value"].ToString(),
                    StatusResult = dt.Rows[i]["Status"].ToString(),
                });
            }
            return AgencyList;
        }

        public DataTable GetControlParameterView(MyDataBusinessLogic Data)
        {
            string strWhere = "";
            string _Query = " select ID,(Select top 1 AgencyName  from NVO_AgencyMaster Where ID = AgencyID )As Agency,(Select top 1 FileName  from NVO_Menu Where ID = ModuleID ) As Module, Parameter, Value,Case when StatusID = 1 THEN 'ACTIVE' Else 'INACTIVE' End as Status,(Select top 1 (GLCODE +'-'+ GLDESC )  from NVO_GLMaster Where ID = GLCodeID ) As GLCode from NVO_ControlParameter";


            if (Data.AgencyID.ToString() != "0" && Data.AgencyID.ToString() != null && Data.AgencyID.ToString() != "?" && Data.AgencyID.ToString() != "")
                if (strWhere == "")
                    strWhere += _Query + " Where (Select top 1 ID  from NVO_AgencyMaster Where ID = AgencyID ) = " + Data.AgencyID.ToString();
                else
                    strWhere += " and (Select top 1 ID  from NVO_AgencyMaster Where ID = AgencyID ) =" + Data.AgencyID.ToString();

            if (Data.ModuleID.ToString() != "0" && Data.ModuleID.ToString() != null && Data.ModuleID.ToString() != "?" && Data.ModuleID.ToString() != "")
                if (strWhere == "")
                    strWhere += _Query + " Where (Select top 1 ID  from NVO_Menu Where ID = ModuleID )=" + Data.ModuleID.ToString();
                else
                    strWhere += " and (Select top 1 ID  from NVO_Menu Where ID = ModuleID ) =" + Data.ModuleID.ToString();


            if (Data.Parameter != "")
                if (strWhere == "")
                    strWhere += _Query + " where Parameter like '%" + Data.Parameter + "%'";
                else
                    strWhere += " and Parameter like '%" + Data.Parameter + "%'";

            if (Data.Value != "")
                if (strWhere == "")
                    strWhere += _Query + " where Value like '%" + Data.Value + "%'";
                else
                    strWhere += " and Value like '%" + Data.Value + "%'";

            if (Data.StatusID.ToString() != "0" && Data.StatusID.ToString() != null && Data.StatusID.ToString() != "?" && Data.StatusID.ToString() != "")
                if (strWhere == "")
                    strWhere += _Query + " where StatusID =" + Data.StatusID;
                else
                    strWhere += " and StatusID =" + Data.StatusID;


            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere, "");
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
        public DataTable ExistingUser(MyDataBusinessLogic Data)
        {   
            
            //string _query = "select UD.ID,UserName,AM.ID AS AgencyID,AgencyName,CM.ID AS CountryID,CountryName,CM1.ID as LocationID,CM1.CityName from NVO_UserDetails UD " +
            // " inner join NVO_AgencyMaster AM on AM.ID = UD.AgentID " +
            // "inner join NVO_CountryMaster CM on CM.ID = AM.CountryID " +
            //  " inner join NVO_CityMaster CM1 on CM1.ID = AM.CityID where  UserName='" + Data.UserName + "' and Password='" + Data.Password + "'";

            string _query = "select ID,UserName, (select top(1) LocationID from NVO_UserRoleDetails where UserID = NVO_UserDetails.Id) as LocationID, " +
                            " (select top(1) CompanyID from NVO_UserRoleDetails where UserID = NVO_UserDetails.Id) as AgencyID " +
                            " from NVO_UserDetails where UserID='" + Data.UserName + "' and Password='" + Data.Password + "'";
            return GetViewData(_query, "");
           
        }
       
            #endregion

        }
}
