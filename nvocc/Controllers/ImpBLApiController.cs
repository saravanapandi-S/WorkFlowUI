using DataManager;
using DataTier;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpBLApiController : ControllerBase
    {
        [HttpPost("ImpBLInsert")]
        public List<MyImpBL> ImpBLInsert(MyImpBL Data)
        {
            ImpBLManager cm = new ImpBLManager();
            List<MyImpBL> st = cm.ImpBLInsert(Data);
            return st;
        }


        [HttpPost("ContainerValues")]
        public List<MyImpBL> ContainerValues(MyImpBL Data)
        {
            ImpBLManager cm = new ImpBLManager();
            List<MyImpBL> st = cm.ContainerALLDetails(Data);
            return st;
        }

        [HttpPost("ExistingImpBL")]
        public List<MyImpBL> ExistingImpBL(MyImpBL Data)
        {
            ImpBLManager cm = new ImpBLManager();
            List<MyImpBL> st = cm.ExistingImpBL(Data);
            return st;
        }


        [HttpPost("ExistingImpBLCntr")]
        public List<MyImpBLCntr> ExistingImpBLCntr(MyImpBLCntr Data)
        {
            ImpBLManager cm = new ImpBLManager();
            List<MyImpBLCntr> st = cm.ExistingImpBLCntr(Data);
            return st;
        }

        [HttpPost("ImpBLCntrInsert")]
        public List<MyImpBL> ImpBLCntrInsert(MyImpBL Data)
        {
            ImpBLManager cm = new ImpBLManager();
            List<MyImpBL> st = cm.InsertImpBLContainer(Data);
            return st;
        }

        [HttpPost("ExistingCntrvaluesImpBL")]
        public List<MyImpBL> ExistingCntrvaluesImpBL(MyImpBL Data)
        {
            ImpBLManager cm = new ImpBLManager();
            List<MyImpBL> st = cm.ExistingImpBLCntrValues(Data);
            return st;
        }

        [HttpPost("ImpHBLInsert")]
        public List<MyImpBL> ImpHBLInsert(MyImpBL Data)
        {
            ImpBLManager cm = new ImpBLManager();
            List<MyImpBL> st = cm.ImpHBLInsert(Data);
            return st;
        }



        [HttpPost("ImpHBLNo")]
        public List<MyImpBL> ImpHBLNo(MyImpBL Data)
        {
            ImpBLManager cm = new ImpBLManager();
            List<MyImpBL> st = cm.ImpHBLValues(Data);
            return st;
        }

        [HttpPost("ExistingImpHBL")]
        public List<MyImpBL> ExistingImpHBL(MyImpBL Data)
        {
            ImpBLManager cm = new ImpBLManager();
            List<MyImpBL> st = cm.ExistingImpHBL(Data);
            return st;
        }

        [HttpPost("ExistingImpHBLCntr")]
        public List<MyImpBLCntr> ExistingImpHBLCntr(MyImpBLCntr Data)
        {
            ImpBLManager cm = new ImpBLManager();
            List<MyImpBLCntr> st = cm.ExistingImpHBLCntr(Data);
            return st;
        }


        [HttpPost("ExistingImpHBLCntrCheck")]
        public List<MyImpBLCntr> ExistingImpHBLCntrCheck(MyImpBLCntr Data)
        {
            ImpBLManager cm = new ImpBLManager();
            List<MyImpBLCntr> st = cm.ExistingImpHBLCheckCntr(Data);
            return st;
        }

        [HttpPost("ImpEnquiryNo")]
        public List<MyImpBLCntr> ImpEnquiryNo(MyImpBLCntr Data)
        {
            ImpBLManager cm = new ImpBLManager();
            List<MyImpBLCntr> st = cm.ImpEnquiryNo(Data);
            return st;
        }


    }
}
