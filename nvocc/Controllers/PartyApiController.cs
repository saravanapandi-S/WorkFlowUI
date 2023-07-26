
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
namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyApiController : ControllerBase
    {
        #region anand


        [HttpGet("CitiesBind")]
        public List<MyCity> cityBind()
        {
            PartyManager cm = new PartyManager();
            List<MyCity> st = cm.GetCommonCityMaster();
            return st;
        }
        [HttpGet("statesBind")]
        public List<MyState> stateBind()
        {
            PartyManager cm = new PartyManager();
            List<MyState> st = cm.GetCommonStateMaster();
            return st;
        }
        [HttpPost("Customer")]
        public List<MyCustomer> Customer(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.InsertCustomerMaster(Data);
            return st;
        }
        [ActionName("CustomerSubmitAll")]
        public List<MyCustomer> CustomerSubmitAll(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.CheckCustomerValues(Data);
            return st;
        }
        [HttpPost("CustomerView")]
        public List<MyCustomer> CustomerView(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCustMaster(Data);
            return st;
        }
        [HttpPost("CustomerViewParticular")]
        public List<MyCustomer> CustomerViewParticular(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCustMasterRecord(Data);
            return st;
        }

        [HttpPost("CusBranchUpdate")]
        public List<MyCustomer> CusBranchUpdate(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCusBranchMasterUpdate(Data);
            return st;
        }

        [HttpGet("BusinessTypes")]
        public List<MyCustomer> BusinessTypes()
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetBusinessTypeMaster();
            return st;
        }

        [HttpPost("BindBusinessTypes")]
        public List<MYCustomerBuss> BindBusinessTypes(MYCustomerBuss Data)
        {
            PartyManager cm = new PartyManager();
            List<MYCustomerBuss> st = cm.GetBusinessMasterRecord(Data);
            return st;
        }

        [ActionName("CustomerBranch")]
        public List<MyCustomer> CustomerBranch(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.InsertCustomerLocation(Data);
            return st;
        }

        [HttpPost("BranchDropDown")]
        public List<MyCustomer> BranchDropDown(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.BindBranchDropDown(Data);
            return st;
        }
        [HttpPost("GSTCategory")]
        public List<MyCustomer> GSTCategoryList(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GSTCategoryListDropDown(Data);
            return st;
        }
        [HttpPost("UserDetails")]
        public List<MyCustomer> UserDetails(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.UserDetailsListDropDown(Data);
            return st;
        }

        [HttpPost("CustomerBranchView")]
        public List<MyCustomer> CustomerBranchValues(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCusBranchMaster(Data);
            return st;
        }

        [ActionName("CusBranchDelete")]
        public List<MyCustomer> CusBranchDelete(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.CusBranchDeleteMaster(Data);
            return st;
        }

        [ActionName("CustomerEmailAlert")]
        public List<MyCustomer> CustomerEmailAlert(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.InsertCustomerEmailAlerts(Data);
            return st;
        }

        [ActionName("CustomerEmailAlertView")]
        public List<MyCustomer> CustomerEmailAlertView(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCusEmailAlertsMaster(Data);
            return st;
        }



        [HttpPost("CusEmailAlertUpdate")]
        public List<MyCustomer> CusEmailAlertUpdate(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCusEmailAltMasterUpdate(Data);
            return st;
        }

        [ActionName("CusEmailAlertDelete")]
        public List<MyCustomer> CusEmailAlertDelete(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.CusEmailAlertsDeleteMaster(Data);
            return st;
        }

        [HttpPost("CustomerAddInfo")]
        public List<MyCustomer> CustomerAddInfo(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.InsertCusAddInfoMaster(Data);
            return st;
        }
        [HttpGet("AttachmentValues")]
        public List<MyCustomer> ModuleValues()
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GeneralmasterAttachmentValues();
            return st;
        }
        [ActionName("CustomerAddInfoView")]
        public List<MyCustomer> CustomerAddInfoView(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCusAddInfoMaster(Data);
            return st;
        }

        [ActionName("CusAddInfoUpdate")]
        public List<MyCustomer> CusAddInfoUpdate(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCusAddInfoUpdateMaster(Data);
            return st;
        }

        [ActionName("CusAddInfoDelete")]
        public List<MyCustomer> CusAddInfoDelete(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.CusAddInfoDeleteMaster(Data);
            return st;
        }

        [ActionName("AgencyState")]
        public List<MyCustomer> AgencyState(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetAgencyStateMaster(Data);
            return st;
        }
        [ActionName("AgencyMaster")]
        public List<MyCustomer> AgencyMaster(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetAgencyMaster(Data);
            return st;
        }
        [HttpPost("CustomerAccSave")]
        public List<MyCustomer> CustomerSalesLink(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.InsertCusSalesLinkMaster(Data);
            return st;
        }


        [HttpPost("CustomerAccLinkView")]
        public List<MyCustomer> CustomerAccLinkView(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCustomerSalesLinkMaster(Data);
            return st;
        }
        [ActionName("CusSalesLinkUpdate")]
        public List<MyCustomer> CusSalesLinkUpdate(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCustomerSalesLinkMasterUpdate(Data);
            return st;
        }
        [ActionName("CusSalesLinkDelete")]
        public List<MyCustomer> CusSalesLinkDelete(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCustomerSalesLinkMasterDelete(Data);
            return st;
        }

        [HttpPost("CustomerCrSave")]
        public List<MyCustomer> CustomerCrSave(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.InsertCustomerCrSave(Data);
            return st;
        }

        [HttpPost("CustomerCrView")]
        public List<MyCustomer> CustomerCrView(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCustomerCrMaster(Data);
            return st;
        }
        [HttpPost("CustomerAttachments")]
        public List<MyCustomer> CustomerAttachments(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.InsertCustomerAttachmentsMaster(Data);
            return st;
        }

        [HttpPost("CustomerAttachDetails")]
        public List<MyCustomer> CustomerAttachDetails(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCusAttachmentMaster(Data);
            return st;
        }

        [ActionName("CusAttachDelete")]
        public List<MyCustomer> CusAttachDelete(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCusAttachDelete(Data);
            return st;
        }

        [ActionName("CusSalPersonDtls")]
        public List<MyCustomer> CusSalPersonDtls(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCusSalesUserList(Data);
            return st;
        }


        [HttpPost("AlertTypes")]
        public List<MyCustomer> AlertTypesalues(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.AlertTypesList(Data);
            return st;
        }

        [HttpPost("CustomerEmailAlertSave")]
        public List<MyCustomer> CustomerEmailAlertSave(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.InsertCustomerEmailAlerts(Data);
            return st;
        }

        #endregion

        #region Ganesh
        #region Agency Master
        [HttpPost("Agency")]
        public List<MyAgency> Agency(MyAgency Data)
        {
            PartyManager pm = new PartyManager();
            List<MyAgency> st = pm.InsertAgencyMaster(Data);
            return st;
        }

        [HttpPost("Agencyview")]
        public List<MyAgency> Agencyview(MyAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyAgency> st = cm.GetAgencyMaster(Data);
            return st;
        }

        [HttpPost("Agencyviewedit")]
        public List<MyAgency> AgencyViewEdit(MyAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyAgency> st = cm.GetAgencyMasterRecord(Data);
            return st;
        }
        [ActionName("AgencyBind")]
        public List<MyAgency> AgencyBind(MyAgency Data)
        {
            PartyManager pm = new PartyManager();
            List<MyAgency> st = pm.BindAgencyDropDown(Data);
            return st;
        }
        [HttpPost("InsertAgencyPrincipalDtls")]
        public List<MyAgency> InsertAgencyPrincipalDtls(MyAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyAgency> st = cm.InsertAgencyPrincipalDtlsValues(Data);
            return st;
        }
        [HttpPost("AgencyPrincipalDtlsView")]
        public List<MyPortAgency> AgencyPrincipalDtlsView(MyPortAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyPortAgency> st = cm.GetAgencyPrincipalDtlsView(Data);
            return st;
        }
        [HttpPost("RemoveprDtls")]
        public List<MyPortAgency> RemoveprDtlsAgencyDtls(MyPortAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyPortAgency> st = new List<MyPortAgency>();
            DataTable dt = cm.RemoveprincipalDtlsAgencyDtls(Data);
            return st;
        }

        [HttpPost("PrincipalMasterBind")]
        public List<MyPortAgency> GetPrincipalNames(MyPortAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyPortAgency> st = cm.PrincipalList(Data);
            return st;
        }

        [HttpPost("PortMasterBind")]
        public List<MyPortAgency> GetPortCode(MyPortAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyPortAgency> st = cm.PortList(Data);
            return st;
        }

        [HttpPost("AgencyPortCodes")]
        public List<MyAgency> AgencyPortCodes(MyAgency Data)
        {
            PartyManager pm = new PartyManager();
            List<MyAgency> st = pm.InsertAgencyPortCodes(Data);
            return st;
        }


        [HttpPost("AgencyPortView")]
        public List<MyPortAgency> AgencyPortView(MyPortAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyPortAgency> st = cm.GetAgencyPortView(Data);
            return st;
        }
        [HttpPost("RemoveAgencyPortDtls")]
        public List<MyPortAgency> DeleteAgencyPortDtls(MyPortAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyPortAgency> st = new List<MyPortAgency>();
            DataTable dt = cm.DelAgencyPortDtls(Data);
            return st;
        }


        [ActionName("GetCityCodes")]
        public List<MyCityAgency> GetCitCode()
        {
            PartyManager cm = new PartyManager();
            List<MyCityAgency> st = cm.CityList();
            return st;
        }

        [ActionName("AgencyCityCodes")]
        public List<MyCityAgency> AgencyCityCodes(MyCityAgency Data)
        {
            PartyManager pm = new PartyManager();
            List<MyCityAgency> st = pm.InsertAgencyCityCodes(Data);
            return st;
        }


        [ActionName("AgencyCityView")]
        public List<MyCityAgency> AgencyCityView(MyCityAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCityAgency> st = cm.GetAgencyCityView(Data);
            return st;
        }

        [HttpPost, ActionName("DeleteAgencyCityDtls")]
        public List<MyCityAgency> DeleteAgencyCityDtls(MyCityAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCityAgency> st = new List<MyCityAgency>();
            DataTable dt = cm.DelAgencyCityDtls(Data);
            return st;
        }


        [ActionName("AgencyAccDtls")]
        public List<MyAccAgency> InsertAgencyAccDtls(MyAccAgency Data)
        {
            PartyManager pm = new PartyManager();
            List<MyAccAgency> st = pm.InsertAgencyAccDtls(Data);
            return st;
        }

        [HttpGet("CurrencyValues")]
        public List<MyAccCurrency> CurrencyValues()
        {
            PartyManager cm = new PartyManager();
            List<MyAccCurrency> st = cm.CurrencyMaster();
            return st;
        }
        [ActionName("AgencyAccEdit")]
        public List<MyAccAgency> AgencyAccEdit(MyAccAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyAccAgency> st = cm.GetAgencyAccDtls(Data);
            return st;
        }

        [ActionName("AgencyAlertEmailDtls")]
        public List<MyAlertEmailAgency> InsertAgencyAlertEmailDtls(MyAlertEmailAgency Data)
        {
            PartyManager pm = new PartyManager();
            List<MyAlertEmailAgency> st = pm.InsertAgencyEmailDtls(Data);
            return st;
        }

        [ActionName("AgencyAlertEmailView")]
        public List<MyAlertEmailAgency> AgencyAlertEmailView(MyAlertEmailAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyAlertEmailAgency> st = cm.GetAgencyAlertEmailView(Data);
            return st;
        }

        [ActionName("AgencyEmailDtlsEdit")]
        public List<MyAlertEmailAgency> AgencyEmailDtlsEdit(MyAlertEmailAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyAlertEmailAgency> st = cm.GetAgencyEmailDetails(Data);
            return st;
        }


        [HttpPost, ActionName("DeleteEmailDtls")]
        public List<MyAlertEmailAgency> DeleteAgencyCityDtls(MyAlertEmailAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyAlertEmailAgency> st = new List<MyAlertEmailAgency>();
            DataTable dt = cm.DelAgencyEmailDtls(Data);
            return st;
        }
        [ActionName("OrganizationType")]
        public List<MyAgency> OrganizationType()
        {
            PartyManager cm = new PartyManager();

            List<MyAgency> st = cm.ListOrganizationType();
            return st;
        }
        [HttpGet("BindGeoLocations")]
        public List<MyAgency> BindGeoLocations()
        {
            PartyManager cm = new PartyManager();
            List<MyAgency> st = cm.GeoLocationsList();
            return st;
        }

        [ActionName("CheckAgencyValidation")]
        public List<MyAgency> CheckAgencyValidation(MyAgency Data)
        {
            PartyManager cm = new PartyManager();
            List<MyAgency> st = cm.ExistAgencyValidation(Data);
            return st;
        }
        #endregion

        #region Online Portal Creation

        [ActionName("BindPartyWiseByRole")]
        public List<MyOnlinePortal> BindPartyWiseByRole(MyOnlinePortal Data)
        {
            PartyManager pm = new PartyManager();
            List<MyOnlinePortal> st = pm.BindPartyWiseByRole(Data);
            return st;
        }

        [ActionName("InsertOnlinePortal")]
        public List<MyOnlinePortal> InsertOnlinePortal(MyOnlinePortal Data)
        {
            PartyManager cm = new PartyManager();
            List<MyOnlinePortal> st = cm.InsertOnlinePortal(Data);
            return st;
        }
        [ActionName("OnlinePortalView")]
        public List<MyOnlinePortal> OnlinePortalView(MyOnlinePortal Data)
        {
            PartyManager pm = new PartyManager();
            List<MyOnlinePortal> st = pm.BindOnlinePortalView(Data);
            return st;
        }
        [ActionName("OnlinePortalEdit")]
        public List<MyOnlinePortal> OnlinePortalEdit(MyOnlinePortal Data)
        {
            PartyManager pm = new PartyManager();
            List<MyOnlinePortal> st = pm.BindOnlinePortalEdit(Data);
            return st;
        }

        [ActionName("OnlinePortalDtlsEdit")]
        public List<MyOnlinePortal> OnlinePortalDtlsEdit(MyOnlinePortal Data)
        {
            PartyManager pm = new PartyManager();
            List<MyOnlinePortal> st = pm.BindOnlinePortalDtlsEdit(Data);
            return st;
        }
        #endregion




        [ActionName("BindRoleMaster")]
        public List<MyAgency> BindRoleMaster()
        {
            PartyManager cm = new PartyManager();
            List<MyAgency> st = cm.RoleMasterList();
            return st;
        }


        #region Vendor Master

        [HttpPost("VendorView")]
        public List<MyCustomer> VendorView(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetVendorMaster(Data);
            return st;
        }
        [HttpPost("VendorInsert")]
        public List<MyCustomer> Vendor(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.InsertVendorMaster(Data);
            return st;
        }

        [HttpPost("VendorAccSave")]
        public List<MyCustomer> VendorSalesLink(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.InsertVenSalesLinkMaster(Data);
            return st;
        }
        [HttpPost("VendorAccLinkView")]
        public List<MyCustomer> VendorAccLinkView(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetVendorSalesLinkMaster(Data);
            return st;
        }
        [HttpPost("BranchByPOS")]
        public List<MyCustomer> BranchByPOS(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetBranchByPOS(Data);
            return st;
        }
        [HttpPost("CusVendorBranchDelete")]
        public List<MyCustomer> CusVendorBranchDelete(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.CusVendorBranchDeleteMaster(Data);
            return st;
        }
        [HttpPost("CusVendorAccLinkDelete")]
        public List<MyCustomer> CusVendorAccLinkDelete(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.CusVendorAccLinkDeleteMaster(Data);
            return st;
        }
        [HttpPost("CusVendorCrLinkDelete")]
        public List<MyCustomer> CusVendorCrLinkDelete(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.CusVendorCrLinkDeleteMaster(Data);
            return st;
        }
        [HttpPost("CusVendorAlertLinkDelete")]
        public List<MyCustomer> CusVendorAlertLinkDelete(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.CusVendorAlertLinkDeleteMaster(Data);
            return st;
        }

        [HttpPost("PartyExistingDivisionTypes")]
        public List<MyCustomer> PartyExistingDivisionTypes(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.PartyExistingDivisionTypesMaster(Data);
            return st;
        }

        #endregion


        #endregion


        [HttpPost("UploadFiles")]
        public HttpResponseMessage UploadFiles()
        {

            HttpResponseMessage response = new HttpResponseMessage();
            //var abc = Request.Properties.Values;
            //var httpRequest = HttpContext.Current.Request;
            //if (httpRequest.Files.Count > 0)
            //{
            //    foreach (string file in httpRequest.Files)
            //    {
            //        var postedFile = httpRequest.Files[file];
            //        var filePath = HttpContext.Current.Server.MapPath("~/UploadFolder/Attachments" + postedFile.FileName);
            //        postedFile.SaveAs(filePath);
            //    }
            //}
            return response;
        }

        //public ContentResult Upload()
        //{
        //    string path = Server.MapPath("~/CustomerFileAttach/");


        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }
        //    var FileNamev = "";
        //    foreach (string key in Request.Files)
        //    {
        //        Random rd = new Random();
        //        FileNamev += rd.Next(1000).ToString();

        //        HttpPostedFileBase postedFile = Request.Files[key];

        //        FileNamev += "_" + postedFile.FileName;
        //        postedFile.SaveAs(path + FileNamev);
        //    }

        //    return Content(FileNamev);
        //}



    }
}
