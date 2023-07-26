using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataManager;
using DataTier;


namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CntrMovementController : ControllerBase
    {
        [HttpPost("CntrMovementStatusCode")]
        public List<MyCntrMoveMent> CntrMovementStatusCode(MyCntrMoveMent Data)
        {
            CntrMovementManager cm = new CntrMovementManager();
            List<MyCntrMoveMent> st = cm.BindCntrMovementStatusCode(Data);
            return st;
        }

        [HttpPost("CntrStorageLocation")]
        public List<MyCntrMoveMent> CntrStorageLocation(MyCntrMoveMent Data)
        {
            CntrMovementManager cm = new CntrMovementManager();
            List<MyCntrMoveMent> st = cm.BindStorageLocation(Data);
            return st;
        }

        [HttpPost("getBookingNo")]
        public List<MyCntrMoveMent> getBookingNo(MyCntrMoveMent Data)
        {
            CntrMovementManager cm = new CntrMovementManager();
            List<MyCntrMoveMent> st = cm.BindBookingNo(Data);
            return st;
        }

        [HttpPost("getValidCntrvalues")]
        public List<MyCntrMoveMent> getValidCntrvalues(MyCntrMoveMent Data)
        {
            CntrMovementManager cm = new CntrMovementManager();
            List<MyCntrMoveMent> st = cm.BindValidContainerNos(Data);
            return st;
        }

        [HttpPost("SaveContainerList")]
        public List<MyCntrMoveMent> SaveContainerList(MyCntrMoveMent Data)
        {
            CntrMovementManager cm = new CntrMovementManager();
            List<MyCntrMoveMent> st = cm.InsertContainerMovement(Data);
            return st;
        }

        [HttpPost("SearchContainerList")]
        public List<MyCntrMoveMent> SearchContainerList(MyCntrMoveMent Data)
        {
            CntrMovementManager cm = new CntrMovementManager();
            List<MyCntrMoveMent> st = cm.ListContainerSearch(Data);
            return st;
        }

        [HttpPost("ExistingBindContainerList")]
        public List<MyCntrMoveMent> ExistingBindContainerList(MyCntrMoveMent Data)
        {
            CntrMovementManager cm = new CntrMovementManager();
            List<MyCntrMoveMent> st = cm.ExistingContainerList(Data);
            return st;
        }

        [HttpPost("ExistingContainerListDtls")]
        public List<MyCntrMoveMent> ExistingContainerListDtls(MyCntrMoveMent Data)
        {
            CntrMovementManager cm = new CntrMovementManager();
            List<MyCntrMoveMent> st = cm.ExistingContainerListDtls(Data);
            return st;
        }

        [HttpPost("SearchContainerNoList")]
        public List<MyCntrMoveMent> SearchContainerNoList(MyCntrMoveMent Data)
        {
            CntrMovementManager cm = new CntrMovementManager();
            List<MyCntrMoveMent> st = cm.SearchContainerList(Data);
            return st;
        }





    }
}
