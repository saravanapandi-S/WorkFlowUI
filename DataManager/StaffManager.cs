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
   public class StaffManager
    {
        #region Constructor Method
        public StaffManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        public List<MyStaffData> InsertStaffMaster(MyStaffData Data)
        {
            List<MyStaffData> ViewList = new List<MyStaffData>();
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

                    Cmd.CommandText = " IF((select count(*) from NVO_StaffMasterDtls where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_StaffMasterDtls(UserCode,UserName,Location,Designation,Branch,EmailID,Address,CurrentDate) " +
                                     " values (@UserCode,@UserName,@Location,@Designation,@Branch,@EmailID,@Address,@CurrentDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_StaffMasterDtls SET UserCode=@UserCode,UserName=@UserName,Location=@Location,Designation=@Designation,Branch=@Branch,EmailID=@EmailID,Address=@Address,CurrentDate=@CurrentDate where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserCode", Data.UserCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserName", Data.UserName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Location", Data.Location));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Designation", Data.Designation));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Branch", Data.Branch));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EmailID", Data.EmailID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", Data.Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));

                    int result = Cmd.ExecuteNonQuery();

                    Cmd.CommandText = "select ident_current('NVO_StaffMasterDtls')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;


                    trans.Commit();
                    return ViewList;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ViewList;
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

        public List<MyLocation> LocationMasterDtls(MyLocation Data)
        {
            List<MyLocation> ListStaff = new List<MyLocation>();
            DataTable dt = GetUserView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListStaff.Add(new MyLocation
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeoLocation = dt.Rows[i]["GeoLocation"].ToString(),
                });
            }
            return ListStaff;
        }
        public DataTable GetUserView(MyLocation Data)
        {
            string _Query = "Select ID,GeoLocation from NVO_GeoLocations";
            return GetViewData(_Query, "");
        }

        public List<MyStaffData> GetStaffViewMaster(MyStaffData Data)
        {
            List<MyStaffData> ListStaff = new List<MyStaffData>();
            DataTable dt = GetStaffView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListStaff.Add(new MyStaffData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserCode = dt.Rows[i]["UserCode"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    Location = dt.Rows[i]["Location"].ToString(),
                    Designation = dt.Rows[i]["Designation"].ToString(),
                    Branch = dt.Rows[i]["Branch"].ToString(),
                    EmailID = dt.Rows[i]["EmailID"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString()

                });
            }
            return ListStaff;
        }
        public DataTable GetStaffView(MyStaffData Data)
        {
            string strWhere = "";

            string _Query = " select ID,UserCode,UserName, " +
                            " (select CityName from NVO_CityMaster where NVO_CityMaster.ID = NVO_StaffMasterDtls.Location) as Location, " +
                            " (select Name from NVO_DesignationDtls where NVO_DesignationDtls.ID = NVO_StaffMasterDtls.Designation)as Designation, " +
                            " (select GeoLocation from NVO_GeoLocations where NVO_GeoLocations.ID = NVO_StaffMasterDtls.Branch)as Branch,EmailID, " +
                            " Address from NVO_StaffMasterDtls";

            if (Data.UserCode != "")
                if (strWhere == "")
                    strWhere += _Query + " where UserCode like '%" + Data.UserCode + "%'";
                else
                    strWhere += " and UserCode like '%" + Data.UserCode + "%'";

            if (Data.UserName != "")
                if (strWhere == "")
                    strWhere += _Query + " where UserName like '%" + Data.UserName + "%'";
                else
                    strWhere += " and UserName like '%" + Data.UserName + "%'";

            if (Data.Location != "")
                if (strWhere == "")
                    strWhere += _Query + " where Location like '%" + Data.Location + "%'";
                else
                    strWhere += " and Location like '%" + Data.Location + "%'";

            if (Data.Branch != "")
                if (strWhere == "")
                    strWhere += _Query + " where Branch like '%" + Data.Branch + "%'";
                else
                    strWhere += " and Branch like '%" + Data.Branch + "%'";

            if (Data.Designation != "")
                if (strWhere == "")
                    strWhere += _Query + " where Designation like '%" + Data.Designation + "%'";
                else
                    strWhere += " and Designation like '%" + Data.Designation + "%'";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }

        public List<MyStaffData> GetStaffRecordDtls(MyStaffData Data)
        {
            List<MyStaffData> ListStaff = new List<MyStaffData>();
            DataTable dt = GetUserRecordView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListStaff.Add(new MyStaffData
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserCode = dt.Rows[i]["UserCode"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    Location = dt.Rows[i]["Location"].ToString(),
                    Designation = dt.Rows[i]["Designation"].ToString(),
                    Branch = dt.Rows[i]["Branch"].ToString(),
                    EmailID = dt.Rows[i]["EmailID"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString()

                });
            }
            return ListStaff;
        }

        public DataTable GetUserRecordView(MyStaffData Data)
        {
            string _Query = "Select * from NVO_StaffMasterDtls where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyRoleMenu> GetMenuDtls(MyRoleMenu Data)
        {
            List<MyRoleMenu> ListMenu = new List<MyRoleMenu>();
            DataTable dt = GetMenuView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListMenu.Add(new MyRoleMenu
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    FileName = dt.Rows[i]["FileName"].ToString(),
                    Description = dt.Rows[i]["Description"].ToString(),
                    MenuID = dt.Rows[i]["MenuID"].ToString(),
                });
            }
            return ListMenu;
        }

        public DataTable GetMenuView(MyRoleMenu Data)
        {
            string _Query = "select ID,FileName,Description,MenuID  from NVO_Menu where MenuID!= 0 and IsCommon=" + Data.IsCommonID;
            return GetViewData(_Query, "");
        }

        //public DataTable GetMenuView(MyRoleMenu Data)
        //{
        //    string _Query = "select ID,FileName,Description,MenuID  from NVO_Menu where MenuID=0";
        //    return GetViewData(_Query, "");
        //}

        public List<MyRoleMenu> InsertStaffRoleMaster(MyRoleMenu Data)
        {
            List<MyRoleMenu> ViewList = new List<MyRoleMenu>();
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

                    Cmd.CommandText = " IF((select count(*) from NVO_StaffRoleMasterDtls where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_StaffRoleMasterDtls(RoleCode,RoleDes,CurrentDate,ModulID) " +
                                     " values (@RoleCode,@RoleDes,@CurrentDate,@ModulID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_StaffRoleMasterDtls SET RoleCode=@RoleCode,RoleDes=@RoleDes,CurrentDate=@CurrentDate,ModulID=@ModulID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RoleCode", Data.RoleCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RoleDes", Data.RoleDes));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ModulID", Data.ModulID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                   
                    if (Data.ID == 0)
                    { 
                        Cmd.CommandText = "select ident_current('NVO_StaffRoleMasterDtls')";
                    Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;

                    string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_StaffRoleMasterMenuDtls where RoleID=@RoleID and MenuID=@MenuID)<=0) " +
                   " BEGIN " +
                   " INSERT INTO  NVO_StaffRoleMasterMenuDtls(RoleID,MenuID,CreateID,UpdateID,DeleteID,ViewID,CurrentDate ) " +
                   " values(@RoleID,@MenuID,@CreateID,@UpdateID,@DeleteID,@ViewID,@CurrentDate )  " +
                   " END  " +
                   " ELSE " +
                   " UPDATE NVO_StaffRoleMasterMenuDtls SET RoleID=@RoleID,MenuID=@MenuID,CreateID=@CreateID,UpdateID=@UpdateID,DeleteID=@DeleteID,ViewID=@ViewID,CurrentDate=@CurrentDate where RoleID=@RoleID and MenuID=@MenuID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RoleID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MenuID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CreateID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UpdateID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DeleteID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ViewID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }

                    string[] Array1 = Data.ItemsData.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_StaffRoleMasterMenuAccessDtls where RoleID=@RoleID and MenuID=@MenuID)<=0) " +
                   " BEGIN " +
                   " INSERT INTO  NVO_StaffRoleMasterMenuAccessDtls(RoleID,MenuID,CreateID,UpdateID,DeleteID,ViewID,CurrentDate ) " +
                   " values(@RoleID,@MenuID,@CreateID,@UpdateID,@DeleteID,@ViewID,@CurrentDate )  " +
                   " END  " +
                   " ELSE " +
                   " UPDATE NVO_StaffRoleMasterMenuAccessDtls SET RoleID=@RoleID,MenuID=@MenuID,CreateID=@CreateID,UpdateID=@UpdateID,DeleteID=@DeleteID,ViewID=@ViewID,CurrentDate=@CurrentDate where RoleID=@RoleID and MenuID=@MenuID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RoleID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MenuID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CreateID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UpdateID", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@DeleteID", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ViewID", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }



                    trans.Commit();
                    ViewList.Add(new MyRoleMenu
                    {
                        ID = Data.ID,

                    });
                    return ViewList;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ViewList;
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

        public List<MyRoleMenu> GetStaffRoleMasterDtls(MyRoleMenu Data)
        {
            List<MyRoleMenu> ListMenu = new List<MyRoleMenu>();
            DataTable dt = GetRoleMasterView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListMenu.Add(new MyRoleMenu
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RoleCode = dt.Rows[i]["RoleCode"].ToString(),
                    RoleDes = dt.Rows[i]["RoleDes"].ToString(),
                    CurrentDate = dt.Rows[i]["CurrentDate"].ToString(),
                    //ProgramName = dt.Rows[i]["ProgramName"].ToString()
                    //Create = dt.Rows[i]["Create"].ToString(),
                    //Update = dt.Rows[i]["Update"].ToString(),
                    //Delete = dt.Rows[i]["Delete"].ToString(),
                    //View = dt.Rows[i]["View"].ToString()
                });
            }
            return ListMenu;
        }

        public DataTable GetRoleMasterView(MyRoleMenu Data)
        {
            string _Query = "select ID,RoleCode,RoleDes,convert(varchar,CurrentDate,103) as CurrentDate from NVO_StaffRoleMasterDtls";
            return GetViewData(_Query, "");
        }


        public List<MyRoleMenu> GetStaffRoleMasterRecord(MyRoleMenu Data)
        {
            List<MyRoleMenu> ListMenu = new List<MyRoleMenu>();
            DataTable dt = GetRoleMasterViewRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListMenu.Add(new MyRoleMenu
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RoleCode = dt.Rows[i]["RoleCode"].ToString(),
                    RoleDes = dt.Rows[i]["RoleDes"].ToString(),
                    ProgramName = dt.Rows[i]["ProgramName"].ToString()
                    //Create = dt.Rows[i]["Create"].ToString(),
                    //Update = dt.Rows[i]["Update"].ToString(),
                    //Delete = dt.Rows[i]["Delete"].ToString(),
                    //View = dt.Rows[i]["View"].ToString()
                });
            }
            return ListMenu;
        }

        public DataTable GetRoleMasterViewRecord(MyRoleMenu Data)
        {
            string _Query = "select ID,RoleCode,RoleDes, " +
                            " (select FileName from NVO_Menu where NVO_Menu.ID = nvo_StaffRoleMasterDtls.ProgramName) as ProgramName, " +
                            " CreateID, UpdateID, DeleteID, ViewID from NVO_StaffRoleMasterDtls where ID= " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyRoleMenu> GetStaffRoleMasterBindRecord(MyRoleMenu Data)
        {
            List<MyRoleMenu> ListMenu = new List<MyRoleMenu>();
            DataTable dt = GetRoleMasterBindRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListMenu.Add(new MyRoleMenu
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    RoleCode = dt.Rows[i]["RoleCode"].ToString(),
                    RoleDes = dt.Rows[i]["RoleDes"].ToString(),
                    ModulID = dt.Rows[i]["ModulID"].ToString(),
                    //ProgramName = dt.Rows[i]["ProgramName"].ToString(),
                    //Create = dt.Rows[i]["CreateID"].ToString(),
                    //Update = dt.Rows[i]["UpdateID"].ToString(),
                    //Delete = dt.Rows[i]["DeleteID"].ToString(),
                    //View = dt.Rows[i]["ViewID"].ToString()
                });
            }
            return ListMenu;
        }


        public DataTable GetRoleMasterBindRecord(MyRoleMenu Data)
        {
            string _Query = "select * from NVO_StaffRoleMasterDtls where ID= " + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyRoleMenu> GetStaffRoleSubmenuMaster(MyRoleMenu Data)
        {
            

            List<MyRoleMenu> ListMenu = new List<MyRoleMenu>();
                DataTable dt = GetRoleMasterSubMenuValues(Data);
              
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListMenu.Add(new MyRoleMenu
                        {
                            ID = Int32.Parse(dt.Rows[i]["MID"].ToString()),
                            MenuID = dt.Rows[i]["MenuID"].ToString(),
                            SubMenuID = dt.Rows[i]["SubMenuID"].ToString(),
                            Create = dt.Rows[i]["CreateID"].ToString(),
                            Update = dt.Rows[i]["UpdateID"].ToString(),
                            Delete = dt.Rows[i]["DeleteID"].ToString(),
                            View = dt.Rows[i]["ViewID"].ToString(),
                            FileName = dt.Rows[i]["FileName"].ToString(),

                        });
                    }
                
                return ListMenu;

            }


        

        public DataTable GetRoleMasterSubMenuValues(MyRoleMenu Data)
        { 
           
                string _Query = "select MID,MenuID,SubMenuID,CreateID,UpdateID,DeleteID,ViewID,FileName  from NVO_StaffRoleMasterMenuDtls where MenuID=" + Data.MenuID;
                return GetViewData(_Query, "");

               
            
          
        }

        public List<MyRoleMenu> GetStaffRoleExistingMaster(MyRoleMenu Data)
        {
            List<MyRoleMenu> ListMenu = new List<MyRoleMenu>();
            DataTable dt = GetRoleMasterExistingValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListMenu.Add(new MyRoleMenu
                {
                    ID = Int32.Parse(dt.Rows[i]["MID"].ToString()),
                    MenuID = dt.Rows[i]["MenuID"].ToString(),
                    SubMenuID = dt.Rows[i]["SubMenuID"].ToString(),
                    Create = dt.Rows[i]["CreateID"].ToString(),
                    Update = dt.Rows[i]["UpdateID"].ToString(),
                    Delete = dt.Rows[i]["DeleteID"].ToString(),
                    View = dt.Rows[i]["ViewID"].ToString(),
                    FileName = dt.Rows[i]["FileName"].ToString(),

                });
            }
            return ListMenu;
        }
        public DataTable GetRoleMasterExistingValues(MyRoleMenu Data)
        {
            string _Query = "select MID,MenuID,SubMenuID,CreateID,UpdateID,DeleteID,ViewID,FileName  from NVO_StaffRoleMasterMenuDtls where MenuID=" + Data.MenuID;
            return GetViewData(_Query, "");
        }


        public List<MyRoleMenu> GetMenuModuleDtls(MyRoleMenu Data)
        {
            List<MyRoleMenu> ListMenu = new List<MyRoleMenu>();
            DataTable dt = GetMenuModuleView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListMenu.Add(new MyRoleMenu
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Description = dt.Rows[i]["CommonDescription"].ToString(),
                   
                });
            }
            return ListMenu;
        }

        public DataTable GetMenuModuleView(MyRoleMenu Data)
        {
            string _Query = "select distinct IsCommon as ID, CommonDescription from NVO_Menu";
            return GetViewData(_Query, "");
        }


        public List<MyRoleMenu> GetMenuAccessDtls(MyRoleMenu Data)
        {
            List<MyRoleMenu> ListMenu = new List<MyRoleMenu>();
            DataTable dt = GetMenuAccessView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListMenu.Add(new MyRoleMenu
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Description = dt.Rows[i]["Description"].ToString(),

                });
            }
            return ListMenu;
        }

        public DataTable GetMenuAccessView(MyRoleMenu Data)
        {
            string _Query = " select ID, Description from NVO_MenuAccessDtls where MenuID = " + Data.MenuID;
            return GetViewData(_Query, "");
        }



        public List<MyRoleMenu> GetExistingGridProgramName(MyRoleMenu Data)
        {
            List<MyRoleMenu> ListMenu = new List<MyRoleMenu>();
            DataTable dt = GetRoleManagerExistingdtlsView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListMenu.Add(new MyRoleMenu
                {
                    MID = dt.Rows[i]["MID"].ToString(),
                    MenuID = dt.Rows[i]["MenuID"].ToString(),
                    MenuName = dt.Rows[i]["MenuName"].ToString(),
                    CreateID = Int32.Parse(dt.Rows[i]["CreateID"].ToString()),
                    UpdateID = Int32.Parse(dt.Rows[i]["UpdateID"].ToString()),
                    DeleteID = Int32.Parse(dt.Rows[i]["DeleteID"].ToString()),
                    ViewID = Int32.Parse(dt.Rows[i]["ViewID"].ToString()),
                });
            }
            return ListMenu;
        }

        public DataTable GetRoleManagerExistingdtlsView(MyRoleMenu Data)
        {
            string _Query = " select MID,(select top(1) FileName from NVO_Menu where Id = NVO_StaffRoleMasterMenuDtls.MenuID) as MenuName,MenuID,  " +
                            " CreateID,UpdateID,DeleteID,ViewID " +
                            " from NVO_StaffRoleMasterMenuDtls where RoleID =" + Data.ID;
            return GetViewData(_Query, "");
        }



        public List<MyRoleMenu> GetExistingGridAcess(MyRoleMenu Data)
        {
            List<MyRoleMenu> ListMenu = new List<MyRoleMenu>();
            DataTable dt = GetRoleManagerExistingdtlsViewAccess(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListMenu.Add(new MyRoleMenu
                {
                    MID = dt.Rows[i]["MID"].ToString(),
                    MenuID = dt.Rows[i]["MenuID"].ToString(),
                    MenuName = dt.Rows[i]["MenuName"].ToString(),
                    CreateID = Int32.Parse(dt.Rows[i]["CreateID"].ToString()),
                    UpdateID = Int32.Parse(dt.Rows[i]["UpdateID"].ToString()),
                    DeleteID = Int32.Parse(dt.Rows[i]["DeleteID"].ToString()),
                    ViewID = Int32.Parse(dt.Rows[i]["ViewID"].ToString()),
                });
            }
            return ListMenu;
        }
        public DataTable GetRoleManagerExistingdtlsViewAccess(MyRoleMenu Data)
        {
            string _Query = " Select MID,(select top(1) Description from  NVO_MenuAccessDtls where ID =NVO_StaffRoleMasterMenuAccessDtls.MenuID) as MenuName, " +
                            " NVO_StaffRoleMasterMenuAccessDtls.MenuID,   " +
                            " CreateID,UpdateID,DeleteID,ViewID,NVO_MenuAccessDtls.MenuID as MainMenuID from NVO_StaffRoleMasterMenuAccessDtls " +
                            " inner join NVO_MenuAccessDtls on NVO_MenuAccessDtls.ID = NVO_StaffRoleMasterMenuAccessDtls.MenuID " +
                            " where NVO_MenuAccessDtls.MenuID = " + Data.MenuID;
            return GetViewData(_Query, "");
        }



        public List<MyRoleMenu> RRBLAccessTableInsert(MyRoleMenu Data)
        {
            List<MyRoleMenu> ViewList = new List<MyRoleMenu>();
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



                    Cmd.CommandText = " IF((select count(*) from NVO_RRBLAccessTable where ID=@ID)<=0) " +
                                 " BEGIN " +
                                 " INSERT INTO  NVO_RRBLAccessTable(DocumentTypeID,RRID,BLID,AgencyID,AccessTypeID,Createdby,CreatedDate) " +
                                 " values (@DocumentTypeID,@RRID,@BLID,@AgencyID,@AccessTypeID,@Createdby,@CreatedDate) " +
                                 " END  " +
                                 " ELSE " +
                                 " UPDATE NVO_RRBLAccessTable SET DocumentTypeID=@DocumentTypeID,RRID=@RRID,BLID=@BLID,AgencyID=@AgencyID,AccessTypeID=@AccessTypeID,Createdby=@Createdby,CreatedDate=@CreatedDate where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DocumentTypeID", Data.DocumentTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RRID", Data.RRID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgencyID", Data.AgencyID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AccessTypeID", Data.AccessTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Createdby", Data.Createdby));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedDate", System.DateTime.Now));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_RRBLAccessTable')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.ID = Data.ID;


                    trans.Commit();
                    ViewList.Add(new MyRoleMenu { Message = "Sucessflly Created RR BL Access" });
                    return ViewList;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ViewList.Add(new MyRoleMenu { Message = "failed" });
                    return ViewList;
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




        public List<MyRoleMenu> RRBLAccessExstingTable(MyRoleMenu Data)
        {
            List<MyRoleMenu> ListMenu = new List<MyRoleMenu>();
            DataTable dt = GetRRBLAccessExistingTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListMenu.Add(new MyRoleMenu
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    DocumentType = dt.Rows[i]["DocumentType"].ToString(),
                    DocumentTypeID = dt.Rows[i]["DocumentTypeID"].ToString(),
                    RRNo = dt.Rows[i]["RRNumber"].ToString(),
                    RRID = dt.Rows[i]["RRID"].ToString(),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLID= dt.Rows[i]["BLID"].ToString(),
                    AgencyID = dt.Rows[i]["AgencyID"].ToString(),
                    Agency = dt.Rows[i]["Agency"].ToString(),
                    AccessType = dt.Rows[i]["AccessType"].ToString(),
                    AccessTypeID = dt.Rows[i]["AccessTypeID"].ToString(),
                    Createdby = dt.Rows[i]["Createdby"].ToString(),
                    CreatedDate = dt.Rows[i]["CreatedDate"].ToString(),



                });
            }
            return ListMenu;
        }

        public DataTable GetRRBLAccessExistingTable()
        {
            string _Query = " select NVO_RRBLAccessTable.ID,DocumentTypeID,(select top(1) GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = DocumentTypeID) as DocumentType, " +
                            " RRID,(select top(1) RatesheetNo from NVO_Ratesheet where NVO_Ratesheet.ID = NVO_RRBLAccessTable.RRID) as RRNumber, " +
                            " BLID,(select top(1) BLNumber from NVO_BOL where NVO_BOL.ID = NVO_RRBLAccessTable.BLID) as BLNumber, " +
                            " AgencyID,(select top(1) AgencyName from NVO_AgencyMaster where NVO_AgencyMaster.ID = AgencyID) as Agency, " +
                            " AccessTypeID,(select top(1) UserName from NVO_UserDetails where NVO_UserDetails.ID = NVO_RRBLAccessTable.Createdby) as Createdby, " +
                            " (select top(1) GeneralName from NVO_GeneralMaster where NVO_GeneralMaster.ID = AccessTypeID) as AccessType, " +
                            " Createdby as CreatedID,convert(varchar, CreatedDate, 103) as CreatedDate  from NVO_RRBLAccessTable";
            return GetViewData(_Query, "");
        }


        public List<MyRoleMenu> RRBLAccessTableDelete(MyRoleMenu Data)
        {
            List<MyRoleMenu> ViewList = new List<MyRoleMenu>();
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

                    Cmd.CommandText = "delete from NVO_RRBLAccessTable where ID=@ID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();



                    trans.Commit();
                    ViewList.Add(new MyRoleMenu { Message = "Record Deleted suncssfully" });
                    return ViewList;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ViewList.Add(new MyRoleMenu { Message = "failed" });
                    return ViewList;
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


        public List<MyRoleMenu> StaffRoleMenuDelete(MyRoleMenu Data)
        {
            List<MyRoleMenu> ViewList = new List<MyRoleMenu>();
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

                    Cmd.CommandText = "delete from NVO_StaffRoleMasterMenuDtls where MID=@MID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MID", Data.MID));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();



                    trans.Commit();
                    ViewList.Add(new MyRoleMenu { Message = "Record Deleted suncssfully" });
                    return ViewList;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ViewList.Add(new MyRoleMenu { Message = ex.Message });
                    return ViewList;
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

    }
}
