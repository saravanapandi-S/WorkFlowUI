using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class MyUser
    {
        public int ID;
        public string Name;
        public string UserName;
        public string Password;
        public string DOB;
        public int Gender;
        public int MartialStatus;
        public string Address;
        public int BranchID;
        public int DivID;
        public int DepID;
        public int DesID;
        public int FunRepID;
        public string DOJ;
        public string EmailID;
        public string MobNo;
        public int AgentID;
        public int CountryID;
        public string CurrentDate;
        public string City;
        public string Designation;
        public string Division;
        public string Department;
        public Boolean IsActive;
        public string Description;
        public string Items = "";

        public string RoleID = "";
        public string CompnayID = "";
        public string LocationID = "";
        public string UserID = "";
        public string Notification = "";
        public int IsTrue;
        public string AlertMessage = "";
        public string EffectiveDate = "";
        public string PortID = "";
        public string ExRate = "";
        public string PageName = "";

        public int UID = 0;
        public int OfficeLocID = 0;
        public string OfficeLoc = "";

    }
    public class MyDepartment
    {
        public int ID;
        public string Name;
    }
    public class MyDivision
    {
        public int ID;
        public string Name;
    }
    public class MyDesignation
    {
        public int ID;
        public string Name;
    }

    public class MyRole
    {
        private int _RId;
        public int RId { get { return _RId; } set { _RId = value; } }

        private string _RoleName = string.Empty;
        public string RoleName { get { return _RoleName; } set { _RoleName = value; } }

        private int _Models;
        public int Models { get { return _Models; } set { _Models = value; } }


        private int _RoleID;
        public int RoleID { get { return _RoleID; } set { _RoleID = value; } }

        private int _MenuID;
        public int MenuID { get { return _MenuID; } set { _MenuID = value; } }

        private Boolean _Deleteboolean;
        public Boolean Deleteboolean { get { return _Deleteboolean; } set { _Deleteboolean = value; } }

        private Boolean _Edit;
        public Boolean Edit { get { return _Edit; } set { _Edit = value; } }

        private Boolean _Search;
        public Boolean Search { get { return _Search; } set { _Search = value; } }


        private Boolean _PrintBoolean;
        public Boolean PrintBoolean { get { return _PrintBoolean; } set { _PrintBoolean = value; } }
    }
}
