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
    public class CommonAccessApiController : ControllerBase
    {
        [HttpPost("PortValues")]
        public List<MyCommonAccess> PortValues()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.PortMaster();
            return st;
        }
        [HttpPost("CntrTypeValues")]
        public List<MyCommonAccess> CntrTypeValues()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.CntrTypesMaster();
            return st;
        }

        [HttpPost("BookingCntrTypeValues")]
        public List<MyCommonAccess> BookingCntrTypeValues(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.BookingCntrTypesMaster(Data);
            return st;
        }

        [HttpPost("BookingCntrTypeQtyValues")]
        public List<MyCommonAccess> BookingCntrTypeQtyValues(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.BookingCntrQtyTypesMaster(Data);
            return st;
        }

        [HttpPost("CntrTypeValuesPass")]
        public List<MyCommonAccess> CntrTypeValuesPass(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.CntrTypesMasterValuePass(Data);
            return st;
        }



        [HttpPost("CommodityValues")]
        public List<MyCommonAccess> CommodityValues()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.CommodityMaster();
            return st;
        }

        [HttpPost("ServiceTypesValues")]
        public List<MyCommonAccess> ServiceTypesValues()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.ServiceTypesMaster();
            return st;
        }

        [HttpPost("CurrencyValues")]
        public List<MyCommonAccess> CurrencyValues()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.CurrencyMaster();
            return st;
        }

        [HttpPost("ChargeCode")]
        public List<MyCommonAccess> ChargeCode()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.ChargecodeMaster();
            return st;
        }
        [HttpPost("ChargeCodeValue")]
        public List<MyCommonAccess> ChargeCodeValue()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.ChargeCodeMasterBind();
            return st;
        }


        [HttpPost("ChargeCodeAgent")]
        public List<MyCommonAccess> ChargeCodeAgent()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.ChargeCodeAgentMaster();
            return st;
        }




        [HttpPost("ChargeCodeTypes")]
        public List<MyCommonAccess> ChargeCodeTypes(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.ChargecodeMasterTypes(Data);
            return st;
        }

        [HttpPost("MUCChargeCodeTypes")]
        public List<MyCommonAccess> MUCChargeCodeTypes(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.MUCChargecodeMasterTypes(Data);
            return st;
        }

        [HttpPost("IFCChargeCodeTypes")]
        public List<MyCommonAccess> IFCChargeCodeTypes(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.IFSChargecodeMasterTypes(Data);
            return st;
        }



        [HttpGet("ModuleValues/{id}")]
        public List<MyCommonAccess> ModuleValues(string id)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.Generalmaster(id);
            return st;
        }



        [HttpPost("ModuleValuesTraiffMaster")]
        public List<MyCommonAccess> ModuleValuesTraiffMaster(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.TariffMasterGeneralmaster(Data.ID.ToString());
            return st;
        }

        [HttpPost("AgencyMaster")]
        public List<MyCommonAccess> AgencyMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.AgencyMaster();
            return st;
        }



        [HttpPost("PortAgencyMaster")]
        public List<MyCommonAccess> PortAgencyMaster(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.PortAgencyMaster(Data);
            return st;
        }

        [HttpPost("CustomerMaster")]
        public List<MyCommonAccess> CustomerMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.CustomerMaster();
            return st;
        }

        [HttpPost("PrincipleMaster")]
        public List<MyCommonAccess> PrincipleMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.PrincipleCustomerMaster();
            return st;
        }



        [HttpPost("CustomerMasterParameterPass")]
        public List<MyCommonAccess> CustomerMasterParameterPass(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.CustomerMasterValuesPass(Data);
            return st;
        }




        [HttpPost("VendorMaster")]
        public List<MyCommonAccess> VendorMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.VendorMaster();
            return st;
        }

        [HttpPost("CustomerMasterNew")]
        public List<MyCommonAccessNew> CustomerMasterNew()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccessNew> st = cm.CustomerMasterNew();
            return st;
        }

        [HttpPost("CountryMaster")]
        public List<MyCommonAccess> CountryMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.CountryMaster();
            return st;
        }

        [HttpPost("UserMaster")]
        public List<MyCommonAccess> UserMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.UserMaster();
            return st;
        }


        [HttpPost("RRMaster")]
        public List<MyCommonAccess> RRMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.RRNumberMaster();
            return st;
        }

        [HttpPost("DepotMaster")]
        public List<MyCommonAccess> DepotMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.DepotMaster();
            return st;
        }

        [HttpPost("TerminalMaster")]
        public List<MyCommonAccess> TerminalMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.TerminalMaster();
            return st;
        }

        [HttpPost("VesselMaster")]
        public List<MyCommonAccess> VesselMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.VesselMaster();
            return st;
        }

        [HttpPost("VesVoyMaster")]
        public List<MyCommonAccess> VesVoyMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.VesVoyMaster();
            return st;
        }
        [HttpPost("VesVoyMasterAgencywise")]
        public List<MyCommonAccess> VesVoyAgencywiseMaster(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.VesVoyAgencywiseMaster(Data);
            return st;
        }


        [HttpPost("BookingMaster")]
        public List<MyCommonAccess> BookingMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.BookingMaster();
            return st;
        }

        [HttpPost("BLMaster")]
        public List<MyCommonAccess> BLMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.BLMaster();
            return st;
        }

        [HttpPost("CntrNoValues")]
        public List<MyCommonAccess> CntrNoValues()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.CntrNoMaster();
            return st;
        }


        [HttpPost("BusinessTypes")]
        public List<MyCommonAccess> BusinessTypes()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.BusinessTypesMaster();
            return st;
        }


        [HttpPost("CustomerAddress")]
        public List<MyCommonAccess> CustomerAddress(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.CustomerAddress(Data.ID.ToString());
            return st;
        }


        [HttpPost("CargoTypesMaster")]
        public List<MyCommonAccess> CargoTypesMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.CargoTypesMaster();
            return st;
        }

        [HttpPost("SlotTremsValues")]
        public List<MyCommonAccess> SlotTremsValues()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.SlotTermsMaster();
            return st;
        }

        [HttpPost("CustomerBussTypesMaster")]
        public List<MyCommonAccess> CustomerBussTypesMaster(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.CustomerBussTypesmaster(Data);
            return st;
        }

        [HttpPost("CntrMovementMaster")]
        public List<MyCommonAccess> CntrMovementMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.CntrMovementMaster();
            return st;
        }

        [HttpPost("StatusMaster")]
        public List<MyCommonAccess> StatusMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.StatusMaster();
            return st;
        }

        [HttpPost("VesVoyByAgency")]
        public List<MyCommonAccess> VesVoyByAgency(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.VesVoyByAgency(Data);
            return st;
        }
        [HttpPost("BindMonthsList")]
        public List<MyCommonAccess> BindMonthsList(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.BindMonthsList(Data);
            return st;
        }
        [HttpPost("BindYearList")]
        public List<MyCommonAccess> BindYearList(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.BindYearList(Data);
            return st;
        }
        [HttpPost("BindMainPorts")]
        public List<MyCommonAccess> BindMainPorts(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.BindMainPortsList(Data);
            return st;
        }
        [HttpPost("BindAlertTypesAgency")]
        public List<MyCommonAccess> BindAlertTypesAgency(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.BindAlertTypesAgency(Data);
            return st;
        }


        [HttpPost("BindNotsClauses")]
        public List<MyCommonAccess> BindNotsClauses(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.BindNotsclauses(Data);
            return st;
        }

        [HttpPost("ChargeCodeDetentionValue")]
        public List<MyCommonAccess> ChargeCodeDetentionValue()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.ChargeCodeDetentionMasterBind();
            return st;
        }

        [HttpPost("BindTerminalPortMaster")]
        public List<MyCommonAccess> BindTerminalPortMaster(MyCommonAccess Data)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.TerminalPortMaster(Data);
            return st;
        }

        [HttpGet("newVoyageMaster/{id}")]
        public List<MyCommonAccess> newVoyageMaster(string id)
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.newVesVoyMaster(id);
            return st;
        }

        [HttpPost("OfficeLocationMaster")]
        public List<MyCommonAccess> OfficeLocationMaster()
        {
            CommonAccessManager cm = new CommonAccessManager();
            List<MyCommonAccess> st = cm.OfficeLocationMaster();
            return st;
        }
    }
}
