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
    public class UserManager
    {
        List<MyUser> ListUser = new List<MyUser>();
        List<MyDivision> ListDivision = new List<MyDivision>();
        List<MyDepartment> ListDepartment = new List<MyDepartment>();
        List<MyDesignation> ListDesignation = new List<MyDesignation>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public UserManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region anand
        #region Users
        public List<MyUser> InsertUserMaster(MyUser Data)
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

                    Cmd.CommandText = " IF((select count(*) from NVO_UserDetails where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_UserDetails(UserName,DOB,Gender,MartialStatus,Address,BranchID,DivID,DepID,DesID,FunRepID,DOJ,EmailID,MobNo,AgentID,CountryID,CurrentDate,UserID,Password) " +
                                     " values (@UserName,@DOB,@Gender,@MartialStatus,@Address,@BranchID,@DivID,@DepID,@DesID,@FunRepID,@DOJ,@EmailID,@MobNo,@AgentID,@CountryID,@CurrentDate,@UserID,@Password) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_UserDetails SET UserName=@UserName,DOB=@DOB,Gender=@Gender,MartialStatus=@MartialStatus,Address=@Address,BranchID=@BranchID,DivID=@DivID,DepID=@DepID,DesID=@DesID,FunRepID=@FunRepID,DOJ=@DOJ,EmailID=@EmailID,MobNo=@MobNo,AgentID=@AgentID,CountryID=@CountryID,CurrentDate=@CurrentDate,UserID=@UserID,Password=@Password where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserName", Data.UserName));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DOB", Data.DOB));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Gender", Data.Gender));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MartialStatus", Data.MartialStatus));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Address", Data.Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BranchID", Data.BranchID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DivID", Data.DivID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DepID", Data.DepID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DesID", Data.DesID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FunRepID", Data.FunRepID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@DOJ", Data.DOJ));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EmailID", Data.EmailID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@MobNo", Data.MobNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AgentID", Data.AgentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CountryID", Data.CountryID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Password", Data.Password));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    Cmd.CommandText = "select ident_current('NVO_UserDetails')";
                    if (Data.ID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;
                    string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_UserOfficeLocs where UserID=@UserID and UID=@UID)<=0) " +
                                   " BEGIN " +
                                   " INSERT INTO  NVO_UserOfficeLocs(UserID,OfficeLocID,OfficeLoc) " +
                                   " values (@UserID,@OfficeLocID,@OfficeLoc) " +
                                   " END  " +
                                   " ELSE " +
                                   " UPDATE NVO_UserOfficeLocs SET UserID=@UserID,OfficeLocID=@OfficeLocID,OfficeLoc=@OfficeLoc where UserID=@UserID and UID=@UID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.ID));

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeLocID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeLoc", CharSplit[2]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    ListUser.Add(new MyUser
                    {
                        ID = Data.ID


                    });

                    trans.Commit();
                    return ListUser;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListUser;
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

        public List<MyUser> GetOfficeLocationDelete(MyUser Data)
        {
            DataTable dt = GetOfficeLocationDeleteValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListUser.Add(new MyUser
                {
                    UID = Int32.Parse(dt.Rows[i]["UID"].ToString()),
                    OfficeLocID = Int32.Parse(dt.Rows[i]["OfficeLocID"].ToString()),
                    OfficeLoc = dt.Rows[i]["OfficeLoc"].ToString(),
                });
            }


            return ListUser;
        }

        public DataTable GetOfficeLocationDeleteValues(MyUser Data)
        {

            string _Query = "Delete from NVO_UserOfficeLocs where UID=" + Data.UID;


            return GetViewData(_Query, "");

        }


        public List<MyUser> InsertUserRoleMaster(MyUser Data)
        {

            int r1 = 0;
            int r2 = 0;
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

                try
                {


                    string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array.Length; i++)
                    {
                        var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_UserOfficeLocs where UserID=@UserID and UID=@UID)<=0) " +
                                   " BEGIN " +
                                   " INSERT INTO  NVO_UserOfficeLocs(UserID,OfficeLocID,OfficeLoc) " +
                                   " values (@UserID,@OfficeLocID,@OfficeLoc) " +
                                   " END  " +
                                   " ELSE " +
                                   " UPDATE NVO_UserOfficeLocs SET UserID=@UserID,OfficeLocID=@OfficeLocID,OfficeLoc=@OfficeLoc where UserID=@UserID and UID=@UID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.ID));

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeLocID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeLoc", CharSplit[2]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    ListUser.Add(new MyUser
                    {
                        ID = Data.ID


                    });

                    trans.Commit();
                    return ListUser;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListUser;
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

        public int UpdateUserMaster(MyUser Data, DataTable dt)
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
                    Cmd.CommandText = " UPDATE NVO_UserDetails SET Password=@Password,Active=@Active,CurrentDate=@CurrentDate,RoleLocation=@RoleLocation where ID=@ID";


                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Password", Data.Password));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Active", Data.IsActive));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RoleLocation", Data.Description));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        Cmd.CommandText = " IF((select count(*) from NVO_UserRoleDetails where staffID=@staffID and RoleID=@RoleID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_UserRoleDetails(staffID,RoleID) " +
                                     " values (@staffID,@RoleID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_UserRoleDetails SET staffID=@staffID,RoleID=@RoleID where staffID=@staffID and RoleID=@RoleID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@staffID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RoleID", dt.Rows[i]["RoleID"].ToString()));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return 0;
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

        public List<MyDivision> GetDivisionMaster(MyDivision Data)
        {
            DataTable dt = GetDivDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListDivision.Add(new MyDivision
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Name = dt.Rows[i]["GeneralName"].ToString()
                }); ;
            }

            return ListDivision;
        }
        public DataTable GetDivDetails(MyDivision Data)
        {
            string _Query = "Select * from NVO_GeneralMaster where SeqNo=56";
            return GetViewData(_Query, "");
        }

        public List<MyDepartment> GetDepartementMaster(MyDepartment Data)
        {
            DataTable dt = GetDepDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListDepartment.Add(new MyDepartment
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Name = dt.Rows[i]["GeneralName"].ToString()
                }); ;
            }

            return ListDepartment;
        }
        public DataTable GetDepDetails(MyDepartment Data)
        {
            string _Query = "Select * from NVO_GeneralMaster where SeqNo=57";
            return GetViewData(_Query, "");
        }

        public List<MyDesignation> GetDesignationMaster(MyDesignation Data)
        {
            DataTable dt = GetDesDetails(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListDesignation.Add(new MyDesignation
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Name = dt.Rows[i]["GeneralName"].ToString()
                }); ;
            }

            return ListDesignation;
        }
        public DataTable GetDesDetails(MyDesignation Data)
        {
            string _Query = "Select * from NVO_GeneralMaster where SeqNo=58";
            return GetViewData(_Query, "");
        }

        public List<MyUser> GetUserViewMaster(MyUser Data)
        {
            DataTable dt = GetUserView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyUser
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    City = dt.Rows[i]["CityName"].ToString(),
                    Designation = dt.Rows[i]["Designation"].ToString(),
                    Department = dt.Rows[i]["Department"].ToString(),
                    Division = dt.Rows[i]["Division"].ToString(),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                });
            }
            return ListUser;
        }
        public DataTable GetUserView(MyUser Data)
        {
            string strWhere = "";

            string _Query = " select NVO_UserDetails.ID,UserName,replace(convert(NVARCHAR, DOB, 106), ' ', '-') as DOB,Case When Gender=1 then 'Male' else 'Female' end as GenderV, " +
                            " Case when MartialStatus = 1 then 'Single' else 'Married' end as MartialStatusV,Address,(select top 1 CityName from NVO_CityMaster where ID=BranchID  ) as CityName,(select top 1 GeneralName from NVO_GeneralMaster where ID=DivID and SeqNo=56)  as Division,(select top 1 GeneralName from NVO_GeneralMaster where ID=DepID and SeqNo=57 ) as Department,(select top 1 GeneralName from NVO_GeneralMaster where ID=DesID and SeqNo=58 )  as Designation,UserID from NVO_UserDetails";

            //" inner join NVO_CityMaster On NVO_CityMaster.ID = NVO_UserDetails.BranchID " +
            //" inner Join NVO_DivisionDtls On NVO_DivisionDtls.ID = NVO_UserDetails.DivID " +
            //" inner join NVO_DepartmentDtls On NVO_DepartmentDtls.ID = NVO_UserDetails.DepID " +
            //" inner join NVO_DesignationDtls On NVO_DesignationDtls.ID = NVO_UserDetails.DesID";

            if (Data.UserName != "" && Data.UserName != null)
                if (strWhere == "")
                    strWhere += _Query + " where UserName like '%" + Data.UserName + "%'";
                else
                    strWhere += " and UserName like '%" + Data.UserName + "%'";

            if (Data.City != "" && Data.City != null)
                if (strWhere == "")
                    strWhere += _Query + " where (select top 1 CityName from NVO_CityMaster where ID=BranchID )  like '%" + Data.City + "%'";
                else
                    strWhere += " and (select top 1 CityName from NVO_CityMaster where ID=BranchID )  like '%" + Data.City + "%'";

            if (Data.Division != "" && Data.Division != null)
                if (strWhere == "")
                    strWhere += _Query + " where (select top 1 GeneralName from NVO_GeneralMaster where ID=DivID and SeqNo=56 ) like '%" + Data.Division + "%'";
                else
                    strWhere += " and (select top 1 GeneralName from NVO_GeneralMaster where ID=DivID and SeqNo=56 ) like '%" + Data.Division + "%'";

            if (Data.Department != "" && Data.Department != null)
                if (strWhere == "")
                    strWhere += _Query + " where (select top 1 GeneralName from NVO_GeneralMaster where ID=DepID and SeqNo=57 ) like '%" + Data.Department + "%'";
                else
                    strWhere += " and (select top 1 GeneralName from NVO_GeneralMaster where ID=DepID and SeqNo=57 ) like '%" + Data.Department + "%'";

            if (Data.Designation != "" && Data.Designation != null)
                if (strWhere == "")
                    strWhere += _Query + " where (select top 1 GeneralName from NVO_GeneralMaster where ID=DesID  and SeqNo=58 ) like '%" + Data.Designation + "%'";
                else
                    strWhere += " and (select top 1 GeneralName from NVO_GeneralMaster where ID=DesID  and SeqNo=58 ) like '%" + Data.Designation + "%'";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }

        public List<MyUser> GetUserMasterRecord(string UserID)
        {
            DataTable dt = GetUserRecord(UserID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyUser
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    Password = dt.Rows[i]["Password"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    DOB = dt.Rows[i]["DOB"].ToString(),
                    Gender = Int32.Parse(dt.Rows[i]["Gender"].ToString()),
                    MartialStatus = Int32.Parse(dt.Rows[i]["MartialStatus"].ToString()),
                    Address = dt.Rows[i]["Address"].ToString(),
                    BranchID = Int32.Parse(dt.Rows[i]["BranchID"].ToString()),
                    DivID = Int32.Parse(dt.Rows[i]["DivID"].ToString()),
                    DepID = Int32.Parse(dt.Rows[i]["DepID"].ToString()),
                    DesID = Int32.Parse(dt.Rows[i]["DesID"].ToString()),
                    FunRepID = Int32.Parse(dt.Rows[i]["FunRepID"].ToString()),
                    DOJ = dt.Rows[i]["DOJ"].ToString(),
                    EmailID = dt.Rows[i]["EmailID"].ToString(),
                    MobNo = dt.Rows[i]["MobNo"].ToString(),
                    //AgentID = Int32.Parse(dt.Rows[i]["AgentID"].ToString()),
                    //CountryID = Int32.Parse(dt.Rows[i]["CountryID"].ToString())
                });

            }
            return ListUser;
        }
        public DataTable GetUserRecord(string UserID)
        {
            string _Query = "Select convert(NVARCHAR, DOB, 23) as DOB,convert(NVARCHAR, DOJ, 23) as DOJ, * from NVO_UserDetails where ID=" + UserID;
            return GetViewData(_Query, "");
        }

        public List<MyUser> GetOfficeLocationEidt(MyUser Data)
        {
            DataTable dt = GetOfficeLocationEidtRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyUser
                {

                    UID = Int32.Parse(dt.Rows[i]["UID"].ToString()),
                    OfficeLocID = Int32.Parse(dt.Rows[i]["OfficeLocID"].ToString()),
                    OfficeLoc = dt.Rows[i]["OfficeLoc"].ToString(),

                });
            }
            return ListUser;

        }
        public DataTable GetOfficeLocationEidtRecord(MyUser Data)
        {
            string _Query = " select * from NVO_UserOfficeLocs where UserID=" + Data.ID;
            return GetViewData(_Query, "");

        }

        public List<MyUser> GetUserDetails()
        {
            DataTable dt = GetUserMaster();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyUser
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserName = dt.Rows[i]["UserName"].ToString(),

                });

            }
            return ListUser;
        }





        public DataTable GetUserMaster()
        {
            string _Query = "select Id,UserName from NVO_UserDetails where Active = 1";
            return GetViewData(_Query, "");
        }

        public List<MyUser> NotificationMaster()
        {
            DataTable dt = GetNotificationMaster();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyUser
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Notification = dt.Rows[i]["Notification"].ToString(),
                    IsTrue = Int32.Parse(dt.Rows[i]["IsTrue"].ToString())

                });

            }
            return ListUser;
        }

        public DataTable GetNotificationMaster()
        {
            string _Query = "SELECT Id, Notification, '0' as IsTrue FROM NVO_NotificationMaster";
            return GetViewData(_Query, "");
        }


        public List<MyUser> NotificationMasterUser(MyUser Data)
        {
            DataTable dt = GetNotificationMasterUser(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyUser
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Notification = dt.Rows[i]["Notification"].ToString(),
                    IsTrue = Int32.Parse(dt.Rows[i]["IsTrue"].ToString())

                });

            }
            return ListUser;
        }

        public DataTable GetNotificationMasterUser(MyUser Data)
        {
            string _Query = " Select ID, Notification,case when (select PageID from NVO_RoleNotificationDetails where UserID= " + Data.UserID + " and NVO_NotificationMaster.ID= NVO_RoleNotificationDetails.PageID) >0 then 1 else 0 end  as IsTrue  " +
                            " from NVO_NotificationMaster";
            return GetViewData(_Query, "");
        }


        public List<MyUser> NotificationExistingMasterUser(MyUser Data)
        {
            DataTable dt = GetExistingNotificationMasterUser(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyUser
                {
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString(),


                });

            }
            return ListUser;
        }

        public DataTable GetExistingNotificationMasterUser(MyUser Data)

        {

            string _Query = " select distinct UserID,(select top(1) UserName  from NVO_UserDetails where NVO_UserDetails.Id = NVO_RoleNotificationDetails.UserID) as UserName " +

                            " from NVO_RoleNotificationDetails";



            return GetViewData(_Query, "");

        }


        public List<MyUser> GetUserMasterRole(string UserID)
        {
            DataTable dt = GetUserRoleRecord(UserID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyUser
                {
                    RoleID = dt.Rows[i]["RoleID"].ToString(),
                    CompnayID = dt.Rows[i]["CompanyID"].ToString(),
                    LocationID = dt.Rows[i]["LocationID"].ToString(),

                });

            }
            return ListUser;
        }

        public DataTable GetUserRoleRecord(string UserID)
        {
            string _Query = "select * from NVO_UserRoleDetails where UserID=" + UserID;
            return GetViewData(_Query, "");
        }

        public int InsertUserRollMaster(MyRole Data, DataTable dt)
        {


            int result = 0;
            int result1 = 0;
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

                Cmd.CommandText = "delete from Nav_UserAccessRoleMasterdtls where RoleId=@RoleId and Models=@Models";
                Cmd.Parameters.Add(_dbFactory.GetParameter("@RoleId", Data.RId));
                Cmd.Parameters.Add(_dbFactory.GetParameter("@Models", Data.Models));

                result1 = Cmd.ExecuteNonQuery();
                ////Cmd.Parameters.Clear();

                try
                {

                    Cmd.CommandText = " IF((select count(*) from Nav_UserAccessRoleMaster where RId=@RId)<=0) " +
                                    " BEGIN " +
                                    " INSERT INTO  Nav_UserAccessRoleMaster(RoleName) " +
                                    " values (@RoleName) " +
                                    " END  " +
                                    " ELSE " +
                                    " UPDATE Nav_UserAccessRoleMaster SET RoleName=@RoleName where RId=@RId";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RId", Data.RId));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RoleName", Data.RoleName));
                    result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();


                    if (Data.RId == 0)
                    {
                        Cmd.CommandText = "select ident_current('Nav_UserAccessRoleMaster')";
                        Data.RId = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }
                    else
                        Data.RId = Data.RId;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        Cmd.CommandText = " IF((select count(*) from Nav_UserAccessRoleMasterdtls where RoleId=@RoleId and MenuID=@MenuID AND Models=@Models)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  Nav_UserAccessRoleMasterdtls(RoleId,MenuId,Deleteboolean,Edit,Search,Printboolean,MenuLevel,MainMenuID,Models) " +
                                     " values (@RoleId,@MenuId,@Deleteboolean,@Edit,@Search,@Printboolean,@MenuLevel,@MainMenuID,@Models) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE Nav_UserAccessRoleMasterdtls SET RoleId=@RoleId,MenuId=@MenuId,Deleteboolean=@Deleteboolean,Edit=@Edit,Search=@Search,Printboolean=@Printboolean,MenuLevel=@MenuLevel,MainMenuID=@MainMenuID,Models=@Models where RoleId=@RoleId and MenuID=@MenuID AND Models=@Models";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RoleId", Data.RId));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MenuId", dt.Rows[i]["MenuId"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Deleteboolean", dt.Rows[i]["Deleteboolean"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Edit", dt.Rows[i]["Edit"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Printboolean", dt.Rows[i]["Printboolean"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Search", dt.Rows[i]["Search"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MenuLevel", dt.Rows[i]["MenuLevel"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@MainMenuID", dt.Rows[i]["MainMenuID"].ToString()));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@Models", Data.Models));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return 0;

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

        public List<MyUser> DeleteUserRoleMaster(MyUser Data)
        {
            int result = 0;
            DbConnection con = null;
            DbTransaction trans;
            con = _dbFactory.GetConnection();
            con.Open();
            trans = _dbFactory.GetTransaction(con);
            DbCommand Cmd = _dbFactory.GetCommand();
            Cmd.Connection = con;
            Cmd.Transaction = trans;

            try
            {
                Cmd.CommandText = "delete NVO_UserRoleDetails where UserID =@UserID and RoleID=@RoleId";
                Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                Cmd.Parameters.Add(_dbFactory.GetParameter("@RoleID", Data.RoleID));
                result = Cmd.ExecuteNonQuery();
                Cmd.Parameters.Clear();
                trans.Commit();
                ListUser.Add(new MyUser
                {
                    AlertMessage = "Delete Sucessfully"

                });
                return ListUser;
            }
            catch (Exception ex)
            {
                string ss = ex.ToString();
                trans.Rollback();
                ListUser.Add(new MyUser
                {
                    AlertMessage = ex.Message

                });
                return ListUser;

            }


            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        #endregion
        #endregion


        public List<MyUser> InsertNotificationMaster(MyUser Data)
        {


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

                Cmd.CommandText = "delete from NVO_RoleNotificationDetails where UserID=@UserID";
                Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                result = Cmd.ExecuteNonQuery();
                Cmd.Parameters.Clear();

                try
                {

                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_RoleNotificationDetails where UserID=@UserID and PageID=@PageID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO NVO_RoleNotificationDetails(UserID,PageID) " +
                                     " values (@UserID,@PageID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_RoleNotificationDetails SET UserID=@UserID,PageID=@PageID where UserID=@UserID and PageID=@PageID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PageID", CharSplit[0]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();
                    ListUser.Add(new MyUser
                    {
                        AlertMessage = "Sucessfully"

                    });
                    return ListUser;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListUser;

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

        public List<MyUser> UserAndUserIDValidation(MyUser Data)
        {
            DataTable dt = GetUserAndUserIDValidation(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyUser
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString(),

                });

            }
            return ListUser;
        }

        public DataTable GetUserAndUserIDValidation(MyUser Data)
        {
            string _Query = "select * from NVO_UserDetails where UserID='" + Data.UserID + "' or UserName='" + Data.UserName + "'";
            return GetViewData(_Query, "");
        }


        public List<MyUser> InsertMISExRateMaster(MyUser Data)
        {


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

                Cmd.CommandText = " IF((select count(*) from NVO_MISExchangeRate where EffectiveDate=@EffectiveDate)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO NVO_MISExchangeRate(EffectiveDate) " +
                                     " values (@EffectiveDate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MISExchangeRate SET EffectiveDate=@EffectiveDate where EffectiveDate=@EffectiveDate";
                Cmd.Parameters.Add(_dbFactory.GetParameter("@EffectiveDate", Data.CurrentDate));
                result = Cmd.ExecuteNonQuery();
                Cmd.Parameters.Clear();

                if (Data.ID == 0)
                {
                    Cmd.CommandText = "select ident_current('NVO_MISExchangeRate')";
                    Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                }
                else
                    Data.ID = Data.ID;
                try
                {

                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {
                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');
                        Cmd.CommandText = " IF((select count(*) from NVO_MISExchangeRatedtls where PortID=@PortID and ExID=@ExID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO NVO_MISExchangeRatedtls(ExID,PortID,ExRate) " +
                                     " values (@ExID,@PortID,@ExRate) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_MISExchangeRatedtls SET ExID=@ExID,PortID=@PortID,ExRate=@ExRate where PortID=@PortID and ExID=@ExID";
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ExID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ExRate", CharSplit[1]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }
                    trans.Commit();
                    ListUser.Add(new MyUser
                    {
                        AlertMessage = "Sucessfully"

                    });
                    return ListUser;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    return ListUser;

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



        public List<MyUser> ExistingExRateMaster(MyUser Data)
        {
            DataTable dt = GetMISExRateExistingMaster(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyUser
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    EffectiveDate = dt.Rows[i]["EffectiveDate"].ToString(),


                });

            }
            return ListUser;
        }

        public DataTable GetMISExRateExistingMaster(MyUser Data)
        {
            string strWhere = "";
            string _Query = " select ID, convert(varchar, EffectiveDate, 103) as EffectiveDate from NVO_MISExchangeRate";

            if (Data.EffectiveDate != "")
                if (strWhere == "")
                    strWhere += _Query + " Where EffectiveDate <= ' " + Data.EffectiveDate + "'";

            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");
        }



        public List<MyUser> ExtExRateMaster(MyUser Data)
        {
            DataTable dt = GetExitExRateMaster(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyUser
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    EffectiveDate = dt.Rows[i]["EffectiveDate"].ToString(),

                });

            }
            return ListUser;
        }

        public DataTable GetExitExRateMaster(MyUser Data)
        {
            string _Query = " select ID, convert(varchar, EffectiveDate, 23) as EffectiveDate from NVO_MISExchangeRate where ID =" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyUser> ExtExMisRatedtls(MyUser Data)
        {
            DataTable dt = GetExtExMisRatedtls(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListUser.Add(new MyUser
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    PortID = dt.Rows[i]["PortID"].ToString(),
                    ExRate = dt.Rows[i]["ExRate"].ToString(),

                });

            }
            return ListUser;
        }

        public DataTable GetExtExMisRatedtls(MyUser Data)
        {
            string _Query = " select ID, PortID,ExRate from NVO_MISExchangeRatedtls where ExID =" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyUser> ExtExMisRatedtlsMis(MyUser Data)
        {
            DataTable dtR = GetExtExLastRecord();
            if (dtR.Rows.Count > 0)
            {
                DataTable dt = GetExtExMisRatedtlsMis(dtR.Rows[0]["ID"].ToString());

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListUser.Add(new MyUser
                    {
                        ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                        PortID = dt.Rows[i]["PortID"].ToString(),
                        ExRate = dt.Rows[i]["ExRate"].ToString(),

                    });

                }
            }
            return ListUser;
        }

        public DataTable GetExtExLastRecord()
        {
            string _Query = "select top(1) Id from NVO_MISExchangeRate order by ID desc";
            return GetViewData(_Query, "");
        }
        public DataTable GetExtExMisRatedtlsMis(string ExRateId)
        {
            string _Query = " select ID, PortID,ExRate from NVO_MISExchangeRatedtls where ExID =" + ExRateId;
            return GetViewData(_Query, "");
        }


        public List<MyUser> UserAccessRoleNotification(MyUser Data)
        {

            try
            {
                DataTable dt = GetUserAccessNotification(Data.UserID);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListUser.Add(new MyUser
                    {
                        ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                        Notification = dt.Rows[i]["Notification"].ToString(),
                        PageName = dt.Rows[i]["PageName"].ToString(),

                    });
                }
                return ListUser;
            }
            catch (Exception ex)
            {
                ListUser.Add(new MyUser { AlertMessage = ex.Message });
                return ListUser;
            }
        }



        public DataTable GetUserAccessNotification(string UserID)
        {
            string _Query = " select NVO_RoleNotificationDetails.Id,(select top(1) Notification from NVO_NotificationMaster where ID= NVO_RoleNotificationDetails.PageID) as Notification, " +
                            " (select top(1) PageName from NVO_NotificationMaster where ID = NVO_RoleNotificationDetails.PageID) as PageName " +
                            " from NVO_RoleNotificationDetails where UserID=" + UserID;
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
