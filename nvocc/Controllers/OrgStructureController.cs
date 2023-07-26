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
namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgStructureController : ControllerBase
    {

        #region Region Master
        [HttpPost("RegionView")]
        public List<MyRegion> ListRegion(MyRegion Data)
        {

            OrgStructureManager cm = new OrgStructureManager();
            List<MyRegion> st = cm.GetRegionMaster(Data);
            return st;
        }
        [HttpPost("RegionEdit")]
        public List<MyRegion> RegionValuesEdit(MyRegion Data)
        {

            OrgStructureManager cm = new OrgStructureManager();
            List<MyRegion> st = cm.GetRegionValuesEdit(Data);
            return st;
        }
        [HttpPost("RegionInsert")]

        public List<MyRegion> Region(MyRegion Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MyRegion> st = cm.InsertRegionMaster(Data);
            return st;
        }
        #endregion

        #region OFFICE master

        [HttpPost("BindCitiesByCountry")]
        public List<cityDD> ListBindCitiesByCountry(cityDD Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<cityDD> st = cm.ListBindCitiesByCountry(Data);
            return st;
        }
        [HttpPost("BindStatesByCountry")]
        public List<MyState> stateBind(MyState Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MyState> st = cm.GetCommonStateMaster(Data);
            return st;
        }
        [HttpPost("OfficeInsert")]

        public List<MyOffice> OfficeInsert(MyOffice Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MyOffice> st = cm.InserOfficeMaster(Data);
            return st;
        }

        [HttpPost("OfficeView")]
        public List<MyOffice> OfficeViewList(MyOffice Data)
        {

            OrgStructureManager cm = new OrgStructureManager();
            List<MyOffice> st = cm.GetOfficeViewList(Data);
            return st;
        }
        [HttpPost("OfficeEdit")]
        public List<MyOffice> OfficeEditList(MyOffice Data)
        {

            OrgStructureManager cm = new OrgStructureManager();
            List<MyOffice> st = cm.GetOfficeEditList(Data);
            return st;
        }
        [HttpPost("OfficeLocation")]
        public List<MyOffice> OfficeLocation(MyOffice Data)
        {

            OrgStructureManager cm = new OrgStructureManager();
            List<MyOffice> st = cm.GetOffLocation(Data);
            return st;
        }
        [HttpPost("OfficeLocationBind")]
        public List<MyOffice> OfficeLocationBind(MyOffice Data)
        {

            OrgStructureManager cm = new OrgStructureManager();
            List<MyOffice> st = cm.GetOffLocationBind(Data);
            return st;
        }
        #endregion

        #region Sales Master

        [HttpPost("OfficeLocBind")]
        public List<MyOffice> OfficeLocBind(MyOffice Data)
        {

            OrgStructureManager cm = new OrgStructureManager();
            List<MyOffice> st = cm.GetOfficeLocBind(Data);
            return st;
        }

        [HttpGet("OfficeByLoc/{id}")]
        public List<MyOffice> OfficeByLoc(string id)
        {

            OrgStructureManager cm = new OrgStructureManager();
            List<MyOffice> st = cm.GetOfficeByLoc(id);
            return st;
        }

        [HttpPost("OfficeByLocs")]
        public List<MyOffice> OfficeByLocsValues(MyOffice Data)
        {

            OrgStructureManager cm = new OrgStructureManager();
            List<MyOffice> st = cm.GetOfficeByLocsValues(Data);
            return st;
        }

        [HttpPost("SalesOfficeInsert")]

        public List<MySalesOffice> SalesOfficeInsert(MySalesOffice Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MySalesOffice> st = cm.SalesOfficeInsertMaster(Data);
            return st;
        }
        [HttpPost("SalesOfficeView")]

        public List<MySalesOffice> SalesOfficeView(MySalesOffice Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MySalesOffice> st = cm.SalesOfficeViewMaster(Data);
            return st;
        }
        [HttpPost("SalesOfficeEdit")]

        public List<MySalesOffice> SalesOfficeEdit(MySalesOffice Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MySalesOffice> st = cm.SalesOfficeEditMaster(Data);
            return st;
        }
        #endregion

        #region Org Master

        [HttpPost("OrgInsert")]

        public List<MyOrg> OrgInsertData(MyOrg Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MyOrg> st = cm.OrgInsertDataMaster(Data);
            return st;
        }

        [HttpPost("RegionBindList")]
        public List<MyRegion> RegionBindList(MyRegion Data)
        {

            OrgStructureManager cm = new OrgStructureManager();
            List<MyRegion> st = cm.GetRegionBindList(Data);
            return st;
        }
        [HttpPost("OrgView")]

        public List<MyOrg> OrgView(MyOrg Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MyOrg> st = cm.OrgViewMaster(Data);
            return st;
        }
        [HttpPost("OrgEdit")]

        public List<MyOrg> OrgEdit(MyOrg Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MyOrg> st = cm.OrgEditMaster(Data);
            return st;
        }
        [HttpPost("OrgDetailsEdit")]
        public List<MyOrgGrid> OrgDetailsEdit(MyOrgGrid Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MyOrgGrid> st = cm.OrgDetailsEditMaster(Data);
            return st;
        }


        [HttpPost("SalesOfficeByOfficeLoc")]
        public List<MySalesOffice> SalesOfficeByOfficeLoc(MySalesOffice Data)
        {

            OrgStructureManager cm = new OrgStructureManager();
            List<MySalesOffice> st = cm.GetSalesOfficeByOfficeLoc(Data);
            return st;
        }
        [HttpPost("SalesLocBind")]
        public List<MySalesOffice> SalesLocBind(MySalesOffice Data)
        {

            OrgStructureManager cm = new OrgStructureManager();
            List<MySalesOffice> st = cm.SalesLocBindValues(Data);
            return st;
        }
        [HttpPost("OfficeLocBySalesOffice")]
        public List<MySalesOffice> OfficeLocBySalesOffice(MySalesOffice Data)
        {

            OrgStructureManager cm = new OrgStructureManager();
            List<MySalesOffice> st = cm.OfficeLocBySalesOfficeValues(Data);
            return st;
        }
        [HttpPost("OrgOfficeDtlsDelete")]
        public List<MyOrg> OrgOfficeDtlsDelete(MyOrg Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MyOrg> st = cm.OrgOfficeDtlsDeleteMaster(Data);
            return st;
        }

        [HttpPost("DivisionsBind")]
        public List<MyOrg> DivisionsBind(MyOrg Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MyOrg> st = cm.DivisionsBindMaster(Data);
            return st;
        }

        [HttpPost("OrgExistingDivisionTypes")]
        public List<MyOrg> OrgExistingDivisionTypes(MyOrg Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MyOrg> st = cm.OrgExistingDivisionTypesMaster(Data);
            return st;
        }

        #endregion


    }
}
