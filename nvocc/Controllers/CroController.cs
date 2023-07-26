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
using System.Net.Http;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CroController : ControllerBase
    {

        [HttpPost("BindStufflist")]
        public List<MyCRO> BindStufflist(MyCRO Data)
        {
            CROManager cm = new CROManager();
            List<MyCRO> st = cm.BindStufflist(Data);
            return st;
        }

        [HttpPost("BindDepolist")]
        public List<MyCRO> BindDepolist(MyCRO Data)
        {
            CROManager cm = new CROManager();
            List<MyCRO> st = cm.BindDepolist(Data);
            return st;
        }
        [HttpPost("BkgExistingCntrTypesViewRecord")]
        public List<MyCROCntrTypes> BkgExistingCntrTypesViewRecord(MyCROCntrTypes Data)
        {
            CROManager cm = new CROManager();
            List<MyCROCntrTypes> st = cm.BkgCntrTypesExistingValus(Data);
            return st;
        }
        [HttpPost("CroSave")]
        public List<MyCRO> RateApprovalSave(MyCRO Data)
        {
            CROManager cm = new CROManager();
            List<MyCRO> st = cm.InsertCRO(Data);
            return st;
        }

        [HttpPost("CROViewRecord")]
        public List<MyCRO> CROViewRecordData(MyCRO Data)
        {
            CROManager cm = new CROManager();
            List<MyCRO> st = cm.CROViewRecordData(Data);
            return st;
        }
        [HttpPost("CROEdit")]
        public List<MyCRO> CROEditRecord(MyCRO Data)
        {
            CROManager cm = new CROManager();
            List<MyCRO> st = cm.CROEditRecordData(Data);
            return st;
        }
        [HttpPost("CROValidations")]
        public List<MyCRO> CROValidations(MyCRO Data)
        {
            CROManager cm = new CROManager();
            List<MyCRO> st = cm.CROValidationsData(Data);
            return st;
        }
        [HttpPost("ExistCROCntrTypesNos")]
        public List<MyCROCntrTypes> ExistCROCntrTypesNos(MyCROCntrTypes Data)
        {
            CROManager cm = new CROManager();
            List<MyCROCntrTypes> st = cm.ExistCROCntrTypesNosValus(Data);
            return st;
        }

        [HttpPost("CheckCroAvailable")]
        public List<MyCRO> CheckCroAvailable(MyCRO Data)
        {
            CROManager cm = new CROManager();
            List<MyCRO> st = cm.CheckCroAvailable(Data);
            return st;
        }

    }
}
