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
    public class PrincipalTariffController : ControllerBase
    {

        [HttpPost("InsertPrincipalTariffMaster")]
        public List<MyPrincibalTariff> InsertPrincipalTariffMaster(MyPrincibalTariff Data)
        {
            PrincipalTariffManager cm = new PrincipalTariffManager();
            List<MyPrincibalTariff> st = cm.InsertPrincipalTariffMaster(Data);
            return st;
        }

        [HttpPost("ViewPrincipalTariffMaster")]
        public List<MyPrincibalTariff> ViewPrincipalTariffCharge(MyPrincibalTariff Data)
        {
            PrincipalTariffManager cm = new PrincipalTariffManager();
            List<MyPrincibalTariff> st = cm.ViewPrincipalTraiffMaster(Data);
            return st;
        }

        [HttpPost("EditPrincipalTariffMaster")]
        public List<MyPrincibalTariff> EditPrincipalTariffMaster(MyPrincibalTariff Data)
        {
            PrincipalTariffManager cm = new PrincipalTariffManager();
            List<MyPrincibalTariff> st = cm.EditPrincipalTraiffMaster(Data);
            return st;
        }


        [HttpPost("PrincipalTariffPortMaster")]
        public List<MyPrincibalTariff> PrincipalTariffPortMaster(MyPrincibalTariff Data)
        {
            PrincipalTariffManager cm = new PrincipalTariffManager();
            List<MyPrincibalTariff> st = cm.PrincipalTraiffPortMaster(Data);
            return st;
        }

        [HttpPost("InsertPrincipalTariffMasterdtls")]
        public List<MyPrincibalTariff> InsertPrincipalTariffMasterdtls(MyPrincibalTariff Data)
        {
            PrincipalTariffManager cm = new PrincipalTariffManager();
            List<MyPrincibalTariff> st = cm.InsertPrincipalTariffMasterdtls(Data);
            return st;
        }

        [HttpPost("ExistingPrincipalAgreementTariff")]
        public List<MyPrincibalTariff> ExistingPrincipalAgreementTariff(MyPrincibalTariff Data)
        {
            PrincipalTariffManager cm = new PrincipalTariffManager();
            List<MyPrincibalTariff> st = cm.ViewPrincipalTraiffAgrementMaster(Data);
            return st;
        }

        [HttpPost("DeletePrincipalTariff")]
        public List<MyPrincibalTariff> DeletePrincipalTariff(MyPrincibalTariff Data)
        {
            PrincipalTariffManager cm = new PrincipalTariffManager();
            List<MyPrincibalTariff> st = cm.DeletePrincipalTariffRecord(Data);
            return st;
        }


        [HttpPost("InsertPrincipalTariffEmailAlert")]
        public List<MyPrincibalTariff> InsertPrincipalTariffEmailAlert(MyPrincibalTariff Data)
        {
            PrincipalTariffManager cm = new PrincipalTariffManager();
            List<MyPrincibalTariff> st = cm.InsertPrincipalTariffAlertEmail(Data);
            return st;
        }


        [HttpPost("ExistingPrincipalEmailAlert")]
        public List<MyPrincibalTariff> ExistingPrincipalEmailAlert(MyPrincibalTariff Data)
        {
            PrincipalTariffManager cm = new PrincipalTariffManager();
            List<MyPrincibalTariff> st = cm.ExistingPrincipalEmailAlert(Data);
            return st;
        }
        [HttpPost("ExistingPrincipalAgreementTariffView")]
        public List<MyPrincibalTariff> ExistingPrincipalAgreementTariffView(MyPrincibalTariff Data)
        {
            PrincipalTariffManager cm = new PrincipalTariffManager();
            List<MyPrincibalTariff> st = cm.ViewPrincipalTraiffAgrementMasterView(Data);
            return st;
        }

    }
}
