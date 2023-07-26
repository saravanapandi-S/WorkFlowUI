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
    public class SystemController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SystemController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
        #region anand
        [HttpPost("GeneralMaster")]
        public List<MyGeneralMaster> GeneralMaster(MyGeneralMaster Data)
        {

            GeneralMasterManager GenMang = new GeneralMasterManager();
            List<MyGeneralMaster> st = GenMang.GeneralMasterView(Data);
            return st;
        }

        [HttpPost("GeneralMasteredit")]
        public List<MyGeneralMaster> GeneralMasteredit(MyGeneralMaster Data)
        {
            GeneralMasterManager GenMang = new GeneralMasterManager();
            List<MyGeneralMaster> st = GenMang.GetGeneralMasterEditRecord(Data);
            return st;
        }

        [HttpPost("GeneralMasterInsert")]
        public List<MyGeneralMaster> GeneralMasterInsert(MyGeneralMaster Data)
        {

            GeneralMasterManager GenMang = new GeneralMasterManager();
            List<MyGeneralMaster> st = GenMang.InsertGeneralMaster(Data);
            return st;
        }

        [HttpPost("BLNoLogicsView")]
        public List<MyDOCNumbering> BLLogicsViewRecord(MyDOCNumbering Data)
        {
            DocumentNumberingManager cm = new DocumentNumberingManager();
            List<MyDOCNumbering> st = cm.BLLogicsViewRecordValues(Data);
            return st;
        }


        [HttpPost("BLNoLogicsEdit")]
        public List<MyDOCNumbering> BLNoLogicsEdit(MyDOCNumbering Data)
        {
            DocumentNumberingManager cm = new DocumentNumberingManager();
            List<MyDOCNumbering> st = cm.BLNoLogicsEditValues(Data);
            return st;
        }

        [HttpGet("BLNoLogics/{id}")]
        public List<MyDOCNumbering> BLNoLogics(string id)
        {
            DocumentNumberingManager cm = new DocumentNumberingManager();
            List<MyDOCNumbering> st = cm.BLNoLogicsValues(id);
            return st;
        }

        [HttpPost("BLNoLogicsInsert")]
        public List<MyDOCNumbering> BLNoLogicsInsert(MyDOCNumbering Data)
        {
            DocumentNumberingManager cm = new DocumentNumberingManager();
            List<MyDOCNumbering> st = cm.BLNoLogicsInsert(Data);
            return st;
        }
        #endregion
    }
}
