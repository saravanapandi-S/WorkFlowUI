using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataManager;
using DataTier;
using Microsoft.Extensions.Configuration;
using nvocc.FunServices;

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Division")]
        public List<MyDivision> Division(MyDivision Data)
        {
            UserManager cm = new UserManager();
            List<MyDivision> st = cm.GetDivisionMaster(Data);
            return st;
        }

        [HttpPost("Department")]
        public List<MyDepartment> Department(MyDepartment Data)
        {
            UserManager cm = new UserManager();
            List<MyDepartment> st = cm.GetDepartementMaster(Data);
            return st;
        }
        [HttpPost("Designation")]
        public List<MyDesignation> Designation(MyDesignation Data)
        {
            UserManager cm = new UserManager();
            List<MyDesignation> st = cm.GetDesignationMaster(Data);
            return st;
        }

        [HttpPost("InsertUser")]
        public List<MyUser> InsertUser(MyUser Data)
        {
            UserManager cm = new UserManager();
            List<MyUser> st = cm.InsertUserMaster(Data);
            return st;
        }

        [HttpPost("UserView")]
        public List<MyUser> UserView(MyUser Data)
        {
            UserManager cm = new UserManager();
            List<MyUser> st = cm.GetUserViewMaster(Data);
            return st;
        }

        [HttpPost("UserViewRecord")]
        public List<MyUser> UserViewRecord(MyUser Data)
        {
            UserManager cm = new UserManager();
            List<MyUser> st = cm.GetUserMasterRecord(Data.ID.ToString());
            return st;
        }

        [HttpPost("OfficeLocationEidt")]
        public List<MyUser> OfficeLocationEidt(MyUser Data)
        {
            UserManager cm = new UserManager();
            List<MyUser> st = cm.GetOfficeLocationEidt(Data);
            return st;
        }

        [HttpPost("OfficeLocationDelete")]
        public List<MyUser> OfficeLocationDelete(MyUser Data)
        {
            UserManager cm = new UserManager();
            List<MyUser> st = cm.GetOfficeLocationDelete(Data);
            return st;
        }

    }
}
