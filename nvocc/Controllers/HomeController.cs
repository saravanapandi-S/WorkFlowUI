
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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Web;
using System.Drawing;
using Rectangle = iTextSharp.text.Rectangle;



namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

     
        #region muthu
        [ActionName("mainMenus")]
        public List<MyMenu> mainMenus(MyMenu Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyMenu> st = cm.MenusMaster(Data);
            return st;
        }
        [ActionName("FinancialYearList")]
        public List<MyDataBusinessLogic> FinancialYearList(MyDataBusinessLogic Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyDataBusinessLogic> st = cm.ListFinancialYear(Data);
            return st;
        }

        [ActionName("BindCurrentYear")]
        public List<MyDataBusinessLogic> BindCurrentFinancialYear(MyDataBusinessLogic Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyDataBusinessLogic> st = cm.BindCurrentFinancialYear(Data);
            return st;
        }
        [ActionName("GeoLocationsMaster")]
        public List<MyDataBusinessLogic> BindGeoLocations()
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyDataBusinessLogic> st = cm.GeoLocationsList();
            return st;
        }


        [ActionName("GeoLocationsUser")]
        public List<MyDataBusinessLogic> GeoLocationsUser(MyDataBusinessLogic Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyDataBusinessLogic> st = cm.GeoLocationsUserList(Data);
            return st;
        }


        [ActionName("AgencyMasterByGeoLoc")]
        public List<MyDataBusinessLogic> AgencyMasterByGeoLoc(MyDataBusinessLogic Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyDataBusinessLogic> st = cm.AgencyMasterByGeoloc(Data);
            return st;
        }

        [ActionName("AgencyDocumentSuffix")]
        public List<MyDataBusinessLogic> AgencyDocumentSuffix(MyDataBusinessLogic Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyDataBusinessLogic> st = cm.ListAgencyDocumentSuffix(Data);
            return st;
        }

        [ActionName("MenuListDD")]
        public List<MyDataBusinessLogic> MenuListDD(MyDataBusinessLogic Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyDataBusinessLogic> st = cm.ListMenuListDD(Data);
            return st;
        }
        [ActionName("InsertControlParameter")]
        public List<MyDataBusinessLogic> ControlParameter(MyDataBusinessLogic Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyDataBusinessLogic> st = cm.InsertControlParameter(Data);
            return st;
        }

        [ActionName("ControlParameterView")]
        public List<MyDataBusinessLogic> ControlParameterView(MyDataBusinessLogic Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyDataBusinessLogic> st = cm.ListControlParameterView(Data);
            return st;
        }
        [ActionName("ControlParameterEdit")]
        public List<MyDataBusinessLogic> ControlParameterEdit(MyDataBusinessLogic Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyDataBusinessLogic> st = cm.ListControlParameterEdit(Data);
            return st;
        }

        #endregion

        #region anand
        [HttpPost("Login")]
        public List<MyDataBusinessLogic> LogIn(MyDataBusinessLogic Data)
        {
            RegistrationManager cm = new RegistrationManager();
            TokenServices TS = new TokenServices(_configuration);
            // str = Data.UserName + Data.Password;
            Data.Token = TS.BuildToken(Data);
            List<MyDataBusinessLogic> st = cm.LoginValues(Data);
            return st;
        }

        [ActionName("Register")]
        public List<MyDataBusinessLogic> Register(MyDataBusinessLogic Data)
        {
            RegistrationManager cm = new RegistrationManager();
            List<MyDataBusinessLogic> st = cm.InsertUserMaster(Data);
            return st;
        }

        [HttpPost("CountryInsert")]

        public List<MyCountry> Country(MyCountry Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCountry> st = cm.InsertCountryMaster(Data);
            return st;
        }
        [HttpPost("CountryView")]
        public List<MyCountry> ListCountries(MyCountry Data)
        {

            MasterManager cm = new MasterManager();
            List<MyCountry> st = cm.GetCountryMaster(Data);
            return st;

        }

        [HttpPost("CountryEdit")]
        public List<MyCountry> Countryviewparticular(MyCountry Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCountry> st = cm.GetCountryMasterRecord(Data);
            return st;
        }      

        [HttpPost("Depot")]
        public List<MyDepot> Depot(MyDepot Data)
        {
            MasterManager cm = new MasterManager();
            List<MyDepot> st = cm.InsertDepotMaster(Data);
            return st;
        }

        [HttpGet("countryBind")]
        public List<MyCountry> countryBind()
        {
            MasterManager cm = new MasterManager();
            List<MyCountry> st = cm.GetCommonCountryMaster();
            return st;
        }

        [ActionName("cityBind")]
        public List<MyCity> cityBind(MyCity Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCity> st = cm.GetCommonCityMaster(Data);
            return st;
        }

        [ActionName("stateBind")]
        public List<MyState> stateBind(MyState Data)
        {
            MasterManager cm = new MasterManager();
            List<MyState> st = cm.GetCommonStateMaster(Data);
            return st;
        }
        [HttpGet("PortByCountry/{id}")]
        public List<MyDepot> PortByCountry(string id)
        {
            MasterManager cm = new MasterManager();
            List<MyDepot> st = cm.GetPortByCountry(id);
            return st;
        }
        [HttpPost("DepotView")]
        public List<MyDepot> DepotView(MyDepot Data)
        {
            MasterManager cm = new MasterManager();
            List<MyDepot> st = cm.GetDepotMaster(Data);
            return st;
        }

        [HttpPost("DepotRecord")]
        public List<MyDepot> DepotRecord(MyDepot Data)
        {
            MasterManager cm = new MasterManager();
            List<MyDepot> st = cm.GetDepotMasterRecord(Data);
            return st;
        }
        [HttpPost("BindDepoMasterPortDtls")]
        public List<MyDepot> BindDepoMasterPortDtls(MyDepot Data)
        {
            MasterManager cm = new MasterManager();
            List<MyDepot> st = cm.GetDepoMasterPortDtls(Data);
            return st;
        }
        [ActionName("DepotApplicablePortDelete")]
        public List<MyDepot> DepotApplicablePortDelete(MyDepot Data)
        {
            MasterManager cm = new MasterManager();
            List<MyDepot> st = cm.DepotApplicablePortDelete(Data);
            return st;
        }

        [HttpGet("BindCities/{id}")]
        public List<cityDD> BindCities(string id)
        {
            MasterManager cm = new MasterManager();
            List<cityDD> st = cm.ListCities(id);
            return st;
        }
        [HttpPost("Terminal")]
        public List<MyTerminal> Terminal(MyTerminal Data)
        {
            MasterManager cm = new MasterManager();
            List<MyTerminal> st = cm.InsertTerminalMaster(Data);
            return st;
        }

        [HttpPost("TerminalView")]
        public List<MyTerminal> TerminalView(MyTerminal Data)
        {
            MasterManager cm = new MasterManager();
            List<MyTerminal> st = cm.GetTerminalMaster(Data);
            return st;
        }
        [HttpPost("TerminalRecord")]
        public List<MyTerminal> TerminalRecord(MyTerminal Data)
        {
            MasterManager cm = new MasterManager();
            List<MyTerminal> st = cm.GetTerminalMasterRecord(Data);
            return st;
        }
        [HttpGet("portBind")]
        public List<MyPort> portBind()
        {
            MasterManager cm = new MasterManager();
            List<MyPort> st = cm.GetCommonPortMaster();
            return st;
        }

       

        [HttpPost("Vessel")]
        public List<MyVessel> Vessel(MyVessel Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVessel> st = cm.InsertVesselMaster(Data);
            return st;
        }
        [HttpPost("Vesselview")]
        public List<MyVessel> Vesselview(MyVessel Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVessel> st = cm.GetVesselMaster(Data);
            return st;
        }
        [HttpPost("Vesselviewparticular")]
        public List<MyVessel> Vesselviewparticular(MyVessel Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVessel> st = cm.GetVesselMasterRecord(Data);
            return st;
        }
        [HttpPost("VesselDropDown")]
        public List<MyVessel> VesselDropDown(MyVessel Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVessel> st = cm.GetVesselMasterDropDown(Data);
            return st;
        }
        [ActionName("VoyageDropDown")]
        public List<MyVoyage> VoyageDropDown(MyVoyage Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyage> st = cm.GetVoyageMasterDropDown(Data);
            return st;
        }
        [ActionName("RotNoDropDown")]
        public List<MyVoyage> RotNoDropDown(MyVoyage Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyage> st = cm.GetRotNoMasterDropDown(Data);
            return st;
        }
        [ActionName("Voyage")]
        public List<MyVoyage> Voyage(MyVoyage Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyage> st = cm.InsertVoyageMaster(Data);
            return st;
        }

        [ActionName("VoyageView")]
        public List<MyVoyage> VoyageView(MyVoyage Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyage> st = cm.GetVoyageMaster(Data);
            return st;
        }

        [ActionName("Voyageviewparticular")]
        public List<MyVoyage> Voyageviewparticular(MyVoyage Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyage> st = cm.GetVoyageMasterRecord(Data);
            return st;
        }
        [ActionName("VoyageDropDownChange")]
        public List<MyVoyage> VoyageDropDownChange(MyVoyage Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyage> st = cm.GetVoyDropDownChangeMaster(Data);
            return st;
        }
        [ActionName("RotNoDropDownChange")]
        public List<MyVoyage> RotNoDropDownChange(MyVoyage Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyage> st = cm.GetRotNoDropDownChangeMaster(Data);
            return st;
        }

        [ActionName("CustDropDown")]
        public List<MyCustomer> CustDropDown(MyCustomer Data)
        {
            PartyManager cm = new PartyManager();
            List<MyCustomer> st = cm.GetCustDropDownMaster(Data);
            return st;
        }

        [ActionName("PortDropDown")]
        public List<MyPort> PortDropDown(MyPort Data)
        {
            MasterManager cm = new MasterManager();
            List<MyPort> st = cm.GetPortDropDownMaster(Data);
            return st;
        }

        [ActionName("TerminalDropDown")]
        public List<MyTerminal> TerminalDropDown(MyTerminal Data)
        {
            MasterManager cm = new MasterManager();
            List<MyTerminal> st = cm.GetTerminalDropDownMaster(Data);
            return st;
        }

        [ActionName("VoyageDetails")]
        public List<MyVoyageDetails> VoyageDetails(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.InsertVoyageDetails(Data);
            return st;
        }

        [ActionName("VoyDtlsView")]
        public List<MyVoyageDetails> VoyDtlsView(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.GetVoyDtlsViewMaster(Data);
            return st;
        }
        [ActionName("VoyDtlsViewParticular")]
        public List<MyVoyageDetails> VoyDtlsViewParticular(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.GetVoyDtlsPartRecordMaster(Data.ID.ToString());
            return st;
        }
        [ActionName("VoyPortDtlsParticular")]
        public List<MyVoyageDetails> VoyPortDtlsParticular(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.GetVoyPortDtlsMaster(Data.ID.ToString());
            return st;
        }
        #endregion

        #region Ganesh

        [HttpPost("City")]
        public List<MyCity> City(MyCity Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCity> st = cm.InsertCityMaster(Data);
            return st;
        }


        [HttpPost("CityView")]
        public List<MyCity> ListCity(MyCity Data)
        {

            MasterManager cm = new MasterManager();
            List<MyCity> st = cm.GetCityMaster(Data);
            return st;
        }


        [ActionName("BindCountries")]
        public List<countryDD> BindCountries()
        {
            MasterManager cm = new MasterManager();
            List<countryDD> st = cm.Listcountry();
            return st;
        }

        [ActionName("BindStates")]
        public List<StateDD> BindStates()
        {
            MasterManager cm = new MasterManager();
            List<StateDD> st = cm.ListStates();
            return st;
        }


        //[ActionName("BindCities")]
        //public List<cityDD> BindCities(cityDD Data)
        //{
        //    MasterManager cm = new MasterManager();
        //    List<cityDD> st = cm.ListCities(Data);
        //    return st;
        //}


        [HttpPost("CityEdit")]
        public List<MyCity> ListCitiesEdit(MyCity Data)
        {
       
            MasterManager cm = new MasterManager();
            List<MyCity> st = cm.GetCityMasterRecord(Data);
            return st;
        }

        [HttpPost("Port")]
        public List<MyPort> Port(MyPort Data)
        {
            MasterManager cm = new MasterManager();
            List<MyPort> st = cm.InsertPortMaster(Data);
            return st;
        }


        [HttpPost("Portview")]
        public List<MyPort> Portview(MyPort Data)
        {
            MasterManager cm = new MasterManager();
            List<MyPort> st = cm.GetPortMaster(Data);
            return st;
        }
        [HttpPost("GeoLocByCountry")]
        public List<MyPort> GeoLocByCountry(MyPort Data)
        {
            MasterManager cm = new MasterManager();
            List<MyPort> st = cm.GetGeoLocByCountry(Data);
            return st;
        }

        [ActionName("MainPortview")]
        public List<MyPort> MainPortview(MyPort Data)
        {
            MasterManager cm = new MasterManager();
            List<MyPort> st = cm.GetMainPortMaster(Data);
            return st;
        }

        [HttpPost("Portviewedit")]
        public List<MyPort> PortViewEdit(MyPort Data)
        {
            MasterManager cm = new MasterManager();
            List<MyPort> st = cm.GetPortMasterRecord(Data);
            return st;
        }

        [ActionName("MainPortviewedit")]
        public List<MyPort> MainPortviewedit(MyPort Data)
        {
            MasterManager cm = new MasterManager();
            List<MyPort> st = cm.GetMainPortRecord(Data);
            return st;
        }

        [ActionName("MainPort")]
        public List<MyPort> MainPort(MyPort Data)
        {
            MasterManager cm = new MasterManager();
            List<MyPort> st = cm.InsertMainPortMaster(Data);
            return st;
        }


        [HttpPost("CargoPackage")]
        public List<MyCargo> CargoPackage(MyCargo Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCargo> st = cm.InsertCargoMaster(Data);
            return st;
        }

        [HttpPost("CargoPkgviewedit")]
        public List<MyCargo> CargoPkgViewEdit(MyCargo Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCargo> st = cm.GetCargoPkgMasterRecord(Data);
            return st;
        }


        [HttpPost("CargoPkgview")]
        public List<MyCargo> CargoPkgView(MyCargo Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCargo> st = cm.GetCargoPkgMaster(Data);
            return st;
        }





        [HttpPost("Commodity")]
        public List<MyCommodity> Commodity(MyCommodity Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCommodity> st = cm.InsertCommodityMaster(Data);
            return st;
        }

        [HttpPost("Commodityviewedit")]
        public List<MyCommodity> CommodityViewEdit(MyCommodity Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCommodity> st = cm.GetCommodityMasterRecord(Data);
            return st;
        }


        [HttpPost("Commodityview")]
        public List<MyCommodity> CommodityView(MyCommodity Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCommodity> st = cm.GetCommodityMaster(Data);
            return st;
        }

        [HttpPost("CommodityTypes")]
        public List<MyCommodityTypes> CommodityTypes()
        {
            MasterManager cm = new MasterManager();
            List<MyCommodityTypes> st = cm.CommodityTypeValues();
            return st;
        }


        [ActionName("ExchangeRate")]
        public List<MyExRate> ExchangeRate(MyExRate Data)
        {
            MasterManager cm = new MasterManager();
            List<MyExRate> st = cm.InsertExRateMaster(Data);
            return st;
        }

        [ActionName("FromCurrency")]
        public List<CurrencyDD> FromCurrency()
        {
            MasterManager cm = new MasterManager();

            List<CurrencyDD> st = cm.ListFromCurrencyDD();
            return st;
        }

        [ActionName("ToCurrency")]
        public List<CurrencyDD> ToCurrency()
        {
            MasterManager cm = new MasterManager();

            List<CurrencyDD> st = cm.ListToCurrencyDD();
            return st;
        }


        [ActionName("ExRateView")]
        public List<MyExRate> ExChangeRateView(MyExRate Data)
        {
            MasterManager cm = new MasterManager();
            List<MyExRate> st = cm.ExRateMaster(Data);
            return st;
        }

        [ActionName("ExRateviewedit")]
        public List<MyExRate> ExChangeRateViewEdit(MyExRate Data)
        {
            MasterManager cm = new MasterManager();
            List<MyExRate> st = cm.GetExRateMasterRecord(Data);
            return st;
        }
        [ActionName("InsertGeoLocation")]
        public List<MyGeoLocation> InsertGeoLocation(MyGeoLocation Data)
        {
            MasterManager cm = new MasterManager();
            List<MyGeoLocation> st = cm.InsertGeoLocationMaster(Data);
            return st;
        }

        [ActionName("GeoLocationView")]
        public List<MyGeoLocation> GeoLocationView(MyGeoLocation Data)
        {
            MasterManager cm = new MasterManager();
            List<MyGeoLocation> st = cm.GeoLocationViewMaster(Data);
            return st;
        }

        [ActionName("GeoLocationEdit")]
        public List<MyGeoLocation> GeoLocationEdit(MyGeoLocation Data)
        {
            MasterManager cm = new MasterManager();
            List<MyGeoLocation> st = cm.GeoLocationEditMaster(Data);
            return st;
        }

        [ActionName("BindGeoLocDepotDtls")]
        public List<MyGeoLocation> BindGeoLocDepotDtls(MyGeoLocation Data)
        {
            MasterManager cm = new MasterManager();
            List<MyGeoLocation> st = cm.BindGeoLocDepotDtls(Data);
            return st;
        }
        [ActionName("GeoLocApplicableDepotDelete")]
        public List<MyGeoLocation> GeoLocApplicableDepotDelete(MyGeoLocation Data)
        {
            MasterManager cm = new MasterManager();
            List<MyGeoLocation> st = cm.GeoLocApplicableDepotDelete(Data);
            return st;
        }

        #region voyage allocation
        [ActionName("VoyageTypes")]
        public List<MyVoyageAllocation> VoyageTypes(MyVoyageAllocation Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageAllocation> st = cm.ListVoyageTypes(Data);
            return st;
        }


        [ActionName("LegInfoTypes")]
        public List<MyVoyageAllocation> LegInfoTypes(MyVoyageAllocation Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageAllocation> st = cm.ListLegInfoTypes(Data);
            return st;
        }
        [ActionName("BLListAgentwise")]
        public List<MyVoyageAllocation> BLListAgentwise(MyVoyageAllocation Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageAllocation> st = cm.ListBLListAgentwise(Data);
            return st;
        }
        [ActionName("EXPandTSBLListAgentwise")]
        public List<MyVoyageAllocation> EXPandTSBLListAgentwise(MyVoyageAllocation Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageAllocation> st = cm.ListEXPandTSBLListAgentwise(Data);
            return st;
        }
        [ActionName("VoyageAllocation")]
        public List<MyVoyageAllocation> VoyageAllocation(MyVoyageAllocation Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageAllocation> st = cm.InsertVoyageAllocation(Data);
            return st;
        }

        [ActionName("BindLegVslVoyDetails")]
        public List<MyVoyageAllocation> BindLegVslVoyDetails(MyVoyageAllocation Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageAllocation> st = cm.ListBindLegVslVoyDetails(Data);
            return st;
        }
        [ActionName("VoyAllocationView")]
        public List<MyVoyageAllocation> VoyAllocationView(MyVoyageAllocation Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageAllocation> st = cm.ListVoyAllocationView(Data);
            return st;
        }

        [ActionName("BindVoyAllocationEdit")]
        public List<MyVoyageAllocation> BindVoyAllocationEdit(MyVoyageAllocation Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageAllocation> st = cm.BindVoyAllocationEditValues(Data);
            return st;
        }


        [ActionName("BindVoyAllocationDtlsEdit")]
        public List<MyVoyageAllocation> BindVoyAllocationDtlsEdit(MyVoyageAllocation Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageAllocation> st = cm.BindVoyAllocationDtlsEditValues(Data);
            return st;
        }

        [ActionName("BLVoyAllocationDelete")]
        public List<MyVoyageAllocation> BLVoyAllocationDelete(MyVoyageAllocation Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageAllocation> st = new List<MyVoyageAllocation>();
            DataTable dt = cm.BLVoyAllocationDelete(Data);
            return st;
        }

        #endregion

        #region ServiceSetup

        [ActionName("SlotOperatorByServices")]
        public List<MyServiceSetup> BindSlotOperatorByServices(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();

            List<MyServiceSetup> st = cm.ListSlotOperatorByServices(Data);
            return st;
        }

        [ActionName("BindSlotRefByOperator")]
        public List<MyServiceSetup> BindSlotRefByOperator(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();

            List<MyServiceSetup> st = cm.ListSlotRefByOperator(Data);
            return st;
        }

        [ActionName("ServiceValidation")]
        public List<MyServiceSetup> ServiceValidation(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();
            List<MyServiceSetup> st = cm.ExistServiceValidation(Data);
            return st;
        }
        [HttpPost("InsertServiceSetup")]
        public List<MyServiceSetup> InsertServiceSetup(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();
            List<MyServiceSetup> st = cm.InsertServiceSetup(Data);
            return st;
        }

        [HttpPost("ServiceSetupView")]
        public List<MyServiceSetup> ServiceSetupView(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();
            List<MyServiceSetup> st = cm.ServiceSetupViewMaster(Data);
            return st;
        }

        [HttpPost("ServiceSetupEdit")]
        public List<MyServiceSetup> ServiceSetupEdit(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();
            List<MyServiceSetup> st = cm.ServiceSetupEditMaster(Data);
            return st;
        }

        [HttpPost("ServiceRouteEdit")]
        public List<MyServiceSetup> ServiceRouteEdit(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();
            List<MyServiceSetup> st = cm.ServiceRouteEditMaster(Data);
            return st;
        }
        [HttpPost("ServiceRouteDelete")]
        public List<MyServiceSetup> ServiceRouteDelete(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();
            List<MyServiceSetup> st = cm.ServiceRouteDeleteValues(Data);
            return st;
        }
        [HttpPost("ServiceOperatorsEdit")]
        public List<MyServiceSetup> ServiceOperatorsEdit(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();
            List<MyServiceSetup> st = cm.ServiceOperatorsEditMaster(Data);
            return st;
        }

        [HttpPost("ServiceOperatorsDelete")]
        public List<MyServiceSetup> ServiceOperatorsDelete(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();
            List<MyServiceSetup> st = cm.ServiceOperatorsDeleteValues(Data);
            return st;
        }
        #endregion

        #region Voyage Details New (TPS)

        [HttpPost("BindServices")]
        public List<MyServiceSetup> BindServices(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();
            List<MyServiceSetup> st = cm.BindServicesMaster(Data);
            return st;

        }

        [HttpPost("BindTerminalByPort")]
        public List<MyCommonAccess> BindTerminalByPort(MyCommonAccess Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCommonAccess> st = cm.TerminalMasterByPort(Data);
            return st;

        }

        [HttpPost("BindServiceSchedule")]
        public List<MyServiceSetup> BindServiceSchedule(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();
            List<MyServiceSetup> st = cm.BindServiceScheduleMaster(Data);
            return st;
        }

        [HttpPost("VoyageOperatorsEdit")]
        public List<MyServiceSetup> VoyageOperatorsEdit(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();
            List<MyServiceSetup> st = cm.VoyageOperatorsEditMaster(Data);
            return st;
        }

        [HttpPost("InsertVoyageFirstTab")]
        public List<MyVoyageDetails> InsertVoyageFirstTab(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.InsertVoyageFirstTab(Data);
            return st;
        }

        [HttpPost("VoyageDetailsView")]
        public List<MyVoyageDetails> VoyageDetailsView(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.VoyageDetailsView(Data);
            return st;
        }

        [HttpPost("VoyageDetailsEdit")]
        public List<MyVoyageDetails> VoyageDetailsEdit(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.VoyageDetailsEditMaster(Data);
            return st;
        }

        [HttpPost("VoyageSailingDetailsEdit")]
        public List<MyVoyageDetails> VoyageSailingDetailsEdit(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.VoyageSailingDetailsEditMaster(Data);
            return st;
        }
        [HttpPost("InsertOperatorServices")]
        public List<MyVoyageDetails> InsertOperatorServices(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.InsertOperatorServiceValues(Data);
            return st;
        }
        [HttpPost("VoyageOperatorsDelete")]
        public List<MyServiceSetup> VoyageOperatorsDelete(MyServiceSetup Data)
        {
            MasterManager cm = new MasterManager();
            List<MyServiceSetup> st = cm.VoyageOperatorsDeleteValues(Data);
            return st;
        }
        [ActionName("BerthingPortDropdown")]
        public List<MyVoyageDetails> BerthingPortDropdown(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.BerthingPortDropdownList(Data);
            return st;
        }

        [ActionName("InsertBerthingDtls")]
        public List<MyVoyageDetails> InsertBerthingDtls(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.InsertBerthingDtlsValues(Data);
            return st;
        }


        [ActionName("BindBerthingDetails")]
        public List<MyVoyageDetails> BindBerthingDetails(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.BindBerthingDetailsValues(Data);
            return st;
        }

        [HttpPost("InsertManifestDtls")]
        public List<MyVoyageDetails> InsertManifestDtls(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.InsertManifestDtlsValues(Data);
            return st;
        }
        [HttpPost("ViewManifestDtls")]
        public List<MyVoyageDetails> ViewManifestDtls(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.ViewManifestDtlsValues(Data);
            return st;
        }
        [ActionName("BkgVoyageOperatorValidation")]
        public List<MyVoyageDetails> BkgVoyageOperatorValidation(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.BkgVoyageOperatorValidation(Data);
            return st;
        }

        [ActionName("SendEmailPopUpVoyDtls")]
        public List<MyVoyageDetails> SendEmailPopUpVoyDtls(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.SendEmailPopUpVoyDtls(Data);
            return st;
        }
        [ActionName("VoyBookingPartyEmailDtls")]
        public List<MyVoyageDetails> VoyBookingPartyEmailDtls(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.VoyBookingPartyEmailDtls(Data);
            return st;
        }

        [HttpPost("BindVoyageTypes")]
        public List<MyGeneralMaster> BindVoyageTypes(MyGeneralMaster Data)
        {
            MasterManager cm = new MasterManager();
            List<MyGeneralMaster> st = cm.VoyageTypsDtls(Data);
            return st;

        }
        [HttpPost("InsertVoyageNotes")]
        public List<MyVoyageDetails> InsertVoyageNotes(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.InsertVoyageNotes(Data);
            return st;

        }
        [HttpPost("BindVoyageNotes")]
        public List<MyVoyageDetails> BindVoyageNotes(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.VoyageNotesDtls(Data);
            return st;

        }
        [HttpPost("VoyageNotesDelete")]
        public List<MyVoyageDetails> VoyageNotesDelete(MyVoyageDetails Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageDetails> st = cm.VoyageNotesDeleteDtls(Data);
            return st;
        }
        #endregion

        #region Voyage opening

        [ActionName("VoyageOpeningView")]
        public List<MyVoyageOpening> VoyageOpeningView(MyVoyageOpening Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageOpening> st = cm.ListVoyageOpening(Data);
            return st;
        }

        [ActionName("VoyageOpeningEdit")]
        public List<MyVoyageOpening> VoyageOpeningEdit(MyVoyageOpening Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageOpening> st = cm.ListVoyageOpeningEdit(Data);
            return st;
        }

        [ActionName("PortByGeoLoc")]
        public List<MyVoyageOpening> PortByGeoLoc(MyVoyageOpening Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageOpening> st = cm.PortByGeoLoc(Data);
            return st;
        }
        [ActionName("TerminalDropDownByPortGeoLoc")]
        public List<MyVoyageOpening> TerminalDropDownByPortGeoLoc(MyVoyageOpening Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageOpening> st = cm.TerminalDropDownByPortGeoLoc(Data);
            return st;
        }


        [ActionName("VoyageOpeningEditBLDetails")]
        public List<MyVoyageOpening> VoyageOpeningEditBLDetails(MyVoyageOpening Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageOpening> st = cm.VoyageOpeningEditBLDetails(Data);
            return st;
        }
        [ActionName("VoyageUnOpenedBLDetails")]
        public List<MyVoyageOpening> VoyageUnOpenedBLDetails(MyVoyageOpening Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageOpening> st = cm.VoyageUnOpenedBLDetails(Data);
            return st;
        }
        [ActionName("InsertVoyageOpening")]
        public List<MyVoyageOpening> InsertVoyageOpening(MyVoyageOpening Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageOpening> st = cm.InsertVoyageOpening(Data);
            return st;
        }
        #endregion

        #region Voyage locking

        [ActionName("VoyageLockingRecView")]
        public List<MyVoyageOpening> VoyageLockingRecView(MyVoyageOpening Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageOpening> st = cm.VoyageLockingRecView(Data);
            return st;
        }

        [ActionName("VoyageLockingDetailsEdit")]
        public List<MyVoyageOpening> VoyageLockingDetailsEdit(MyVoyageOpening Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageOpening> st = cm.VoyageLockingDetailsEdit(Data);
            return st;
        }


        [ActionName("VesVoyMasterByAgency")]
        public List<MyVoyageOpening> VesVoyMaster(MyVoyageOpening Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageOpening> st = cm.VesVoyMaster(Data);
            return st;
        }

        [ActionName("VoyageLockingBLDetails")]
        public List<MyVoyageOpening> VoyageLockingBLDetails(MyVoyageOpening Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageOpening> st = cm.VoyageLockingBLDetails(Data);
            return st;
        }
        [ActionName("VoyageLockedBLDetails")]
        public List<MyVoyageOpening> VoyageLockedBLDetails(MyVoyageOpening Data)
        {
            MasterManager cm = new MasterManager();

            List<MyVoyageOpening> st = cm.VoyageLockedBLDetails(Data);
            return st;
        }
        [ActionName("VoyageLockingUpdate")]
        public List<MyVoyageOpening> VoyageLockingUpdate(MyVoyageOpening Data)
        {
            MasterManager cm = new MasterManager();
            List<MyVoyageOpening> st = cm.VoyageLockingUpdate(Data);
            return st;
        }

        [HttpPost("NotesandClausesInsert")]
        public List<MyNotes> NotesandClausesInsert(MyNotes Data)
        {
            MasterManager cm = new MasterManager();
            List<MyNotes> st = cm.NotesandClausesMaster(Data);
            return st;
        }

        [HttpPost("NotesandClausesView")]
        public List<MyNotes> NotesandClausesView(MyNotes Data)
        {
            MasterManager cm = new MasterManager();
            List<MyNotes> st = cm.NotesandClausesView(Data);
            return st;
        }


        [HttpPost("ExistingNotesandClauses")]
        public List<MyNotes> ExistingNotesandClauses(MyNotes Data)
        {
            MasterManager cm = new MasterManager();
            List<MyNotes> st = cm.NotesandClausesDetails(Data);
            return st;
        }

        [ActionName("ExistingDocType")]
        public List<MyNotes> ExistingDocType(MyNotes Data)
        {
            MasterManager cm = new MasterManager();
            List<MyNotes> st = cm.DocumentTypeValues(Data);
            return st;
        }

        [HttpPost("NotesandClausesDelete")]
        public List<MyNotes> NotesandClausesDelete(MyNotes Data)
        {
            MasterManager cm = new MasterManager();
            List<MyNotes> st = cm.NotesandClausesDelete(Data);
            return st;
        }


        #endregion

        #region State
        [HttpPost("State")]
        public List<MyState> State(MyState Data)
        {
            MasterManager cm = new MasterManager();
            List<MyState> st = cm.InsertStateMaster(Data);
            return st;
        }

        [HttpPost("StateView")]
        public List<MyState> StateView(MyState Data)

        {
            MasterManager cm = new MasterManager();
            List<MyState> st = cm.GetStateMaster(Data);
            return st;
        }
        [HttpPost("StateRecord")]
        public List<MyState> StateRecord(MyState Data)
        {
            MasterManager cm = new MasterManager();
            List<MyState> st = cm.GetStateMasterRecord(Data);
            return st;
        }
        #endregion


        #region UOM MASTER


        [HttpPost("UOMMaster")]
        public List<MyUOM> InsertUom(MyUOM Data)
        {
            MasterManager cm = new MasterManager();
            List<MyUOM> st = cm.InsertUOMMaster(Data);
            return st;
        }


        [HttpPost("UOMMasterview")]
        public List<MyUOM> UOMView(MyUOM Data)
        {
            MasterManager cm = new MasterManager();
            List<MyUOM> st = cm.GetUOMMaster(Data);
            return st;
        }

        [HttpPost("UOMMasterviewedit")]
        public List<MyUOM> UOMMasterViewEdit(MyUOM Data)
        {
            MasterManager cm = new MasterManager();
            List<MyUOM> st = cm.GetUOMMasterRecord(Data);
            return st;
        }


        [HttpPost("UOMTypes")]
        public List<MyUOM> UOMTypes(MyUOM Data)
        {
            MasterManager cm = new MasterManager();
            List<MyUOM> st = cm.GetUOMTypesRecord(Data);
            return st;
        }
        [HttpPost("UOMActions")]
        public List<MyUOM> UOMActions(MyUOM Data)
        {
            MasterManager cm = new MasterManager();
            List<MyUOM> st = cm.GetUOMActionsRecord(Data);
            return st;
        }
        #endregion




        #region DamageMaster

        [HttpPost("DamageMaster")]
        public List<MyDamage> InsertDamage(MyDamage Data)
        {
            MNRManager cm = new MNRManager();
            List<MyDamage> st = cm.InsertDamageMaster(Data);
            return st;
        }


        [HttpPost("DamageMasterview")]
        public List<MyDamage> DamageView(MyDamage Data)
        {
            MNRManager cm = new MNRManager();
            List<MyDamage> st = cm.GetDamageMaster(Data);
            return st;
        }

        [HttpPost("DamageMasterviewedit")]
        public List<MyDamage> DamageMasterViewEdit(MyDamage Data)
        {
            MNRManager cm = new MNRManager();
            List<MyDamage> st = cm.GetDamageRecord(Data);
            return st;
        }

        #endregion


        #region RepairMaster

        [HttpPost("RepairMaster")]
        public List<MyRepair> InsertRepair(MyRepair Data)
        {
            MNRManager cm = new MNRManager();
            List<MyRepair> st = cm.InsertRepairMaster(Data);
            return st;
        }


        [HttpPost("RepairMasterview")]
        public List<MyRepair> RepairView(MyRepair Data)
        {
            MNRManager cm = new MNRManager();
            List<MyRepair> st = cm.GetRepairMaster(Data);
            return st;
        }

        [HttpPost("RepairMasterviewedit")]
        public List<MyRepair> DamageMasterViewEdit(MyRepair Data)
        {
            MNRManager cm = new MNRManager();
            List<MyRepair> st = cm.GetRepairRecord(Data);
            return st;
        }

        #endregion


        #region ContLocationMaster

        [HttpPost("ContLocationMaster")]
        public List<MyMNRLoc> InsertContLocation(MyMNRLoc Data)
        {
            MNRManager cm = new MNRManager();
            List<MyMNRLoc> st = cm.InsertMNRLocMaster(Data);
            return st;
        }


        [HttpPost("ContLocationMasterview")]
        public List<MyMNRLoc> ContLocationView(MyMNRLoc Data)
        {
            MNRManager cm = new MNRManager();
            List<MyMNRLoc> st = cm.MNRLocationMaster(Data);
            return st;
        }

        [HttpPost("ContLocationMasterviewedit")]
        public List<MyMNRLoc> ContLocationMasterViewEdit(MyMNRLoc Data)
        {
            MNRManager cm = new MNRManager();
            List<MyMNRLoc> st = cm.GetMNRLocationRecord(Data);
            return st;
        }

        #endregion


        #region Component

        [HttpPost("BindAssembly")]
        public List<MyComponent> BindAssembly(MyComponent Data)
        {
            MNRManager cm = new MNRManager();
            List<MyComponent> st = cm.GetBindAssembly(Data);
            return st;
        }

        [HttpPost("MNRComponentMaster")]
        public List<MyComponent> MNRComponentMaster(MyComponent Data)
        {
            MNRManager cm = new MNRManager();
            List<MyComponent> st = cm.InsertMNRComponentMaster(Data);
            return st;
        }

        [HttpPost("MNRComponentView")]
        public List<MyComponent> MNRComponentView(MyComponent Data)
        {
            MNRManager cm = new MNRManager();
            List<MyComponent> st = cm.MNRComponentMaster(Data);
            return st;
        }


        [HttpPost("MNRComponentViewEdit")]
        public List<MyComponent> MNRComponentViewEdit(MyComponent Data)
        {
            MNRManager cm = new MNRManager();
            List<MyComponent> st = cm.GetMNRComponentRecord(Data);
            return st;
        }
        #endregion


        #endregion

        #region Container Type MASTER


        [HttpPost("ContTypeMaster")]
        public List<MyContType> InsertContType(MyContType Data)
        {
            MasterManager cm = new MasterManager();
            List<MyContType> st = cm.InsertConTypeMaster(Data);
            return st;
        }


        [HttpPost("ContTypeMasterview")]
        public List<MyContType> ContTypeView(MyContType Data)
        {
            MasterManager cm = new MasterManager();
            List<MyContType> st = cm.GetContTypeMaster(Data);
            return st;
        }

        [HttpPost("ContTypeMasterviewedit")]
        public List<MyContType> ContTypeMasterViewEdit(MyContType Data)
        {
            MasterManager cm = new MasterManager();
            List<MyContType> st = cm.GetContTypeMasterRecord(Data);
            return st;
        }

        [HttpPost("CntrTypeValues")]
        public List<ContainerType> ContainerType(ContainerType Data)
        {
            MasterManager cm = new MasterManager();
            List<ContainerType> st = cm.ContainerTypeValues(Data);
            return st;
        }


        [HttpPost("ContainerSize")]
        public List<ContainerSizes> ContainerSize(ContainerSizes Data)
        {
            MasterManager cm = new MasterManager();
            List<ContainerSizes> st = cm.ContainerSizeValues(Data);
            return st;
        }
        [HttpPost("BindStatesByCountry")]
        public List<MyState> BindStatesByCountry(MyState Data)
        {
            OrgStructureManager cm = new OrgStructureManager();
            List<MyState> st = cm.GetCommonStateMaster(Data);
            return st;
        }
        [HttpPost("ContainerGroup")]
        public List<ContainerSizes> ContainerGroup(ContainerSizes Data)
        {
            MasterManager cm = new MasterManager();
            List<ContainerSizes> st = cm.ContainerGroupValues(Data);
            return st;
        }
        
        #endregion

        private string[] SplitByLenght(string Values, int split)
        {

            List<string> list = new List<string>();
            int SplitTheLoop = Values.Length / split;
            for (int i = 0; i < SplitTheLoop; i++)
                list.Add(Values.Substring(i * split, split));
            if (SplitTheLoop * split != Values.Length)
                list.Add(Values.Substring(SplitTheLoop * split));

            return list.ToArray();
        }

        public DataTable GetBkgCustomer(string BLID)
        {
            string _Query = " select convert(varchar,BlDate, 103) as BlDatev,convert(varchar,SOBDate, 103) as SOBDatev,(SELECT top(1) NoofOriginal FROM NVO_BOL  where Id = NVO_BLRelease.BLID) as NoofOriginal,(select top(1) Notes from NVO_BLNotesClauses where DocID= 264 and NID=11) as ddlFreeday," +
                " (select top (1) case when GrsWtType=1 then 'KGS' else case when GrsWtType=2 then 'MT' end end from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID= NVO_BLRelease.BLID)  as GrsWtType, " +
                " (select top(1) case when NtWtType = 1 then 'KGS' else case when NtWtType = 2 then 'MT' end end  from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID = NVO_BLRelease.BLID) as NtWtType, " +
                " (select top(1) (select top(1) PkgDescription from NVO_CargoPkgMaster where NVO_CargoPkgMaster.Id = PakgType) from NVO_BOLCntrDetails where NVO_BOLCntrDetails.BLID= NVO_BLRelease.BLID) as CargoPakage, * from NVO_BLRelease  where BLID=69";
            return Manag.GetViewData(_Query, "");
        }


        public DataTable GetContainerDetails(string BLID)
        {
            string _Query = " Select(select top(1) CntrNo from NVO_Containers where Id = NVO_BOLCntrDetails.CntrID) + '/ ' + size + '/ ' + SealNo + '/ \n/' + convert(varchar, convert(decimal(8, 3), GrsWt)) + ' - ' + (case when GrsWtType = 1 then 'KGS' else 'MT' end) + '/' + convert(varchar, convert(decimal(8, 3), NtWt))  + '- ' + (case when NtWtType = 1 then 'KGS' else 'MT' end) + '/' + convert(varchar, convert(decimal(8, 3), CBM)) + 'CBM' as CntrDtls from NVO_BOLCntrDetails where BLID = 69";

            return Manag.GetViewData(_Query, "");
        }

        public DataTable GetNotes(string BLID)
        {
            string _Query = "select Notes from NVO_BLNotesClauses inner join NVO_BOL on NVO_BOL.PODID=NVO_BLNotesClauses.PortID where Id=69";

            return Manag.GetViewData(_Query, "");
        }
        #region udhaya country, city,ShipMents,Hazardous Classes,UOM Conversions


        [HttpPost("countryList")]
        public List<MyCountry> GetcountryList(MyCountry Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCountry> st = cm.countryListvalues(Data);
            return st;
        }


        [HttpPost("Citylist")]
        public List<MyCity> GetCitylist(MyCity Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCity> st = cm.Citylistvalues(Data);
            return st;
        }

        [HttpPost("InsertShipment")]
        public List<myshipmentlocation> InsertShipment(myshipmentlocation Data)
        {
            MasterManager cm = new MasterManager();
            List<myshipmentlocation> st = cm.InsertShipmentValues(Data);
            return st;
        }

        [HttpPost("ShipmentLocationList")]
        public List<myshipmentlocation> ShipmentLocationList(myshipmentlocation Data)
        {
            MasterManager cm = new MasterManager();
            List<myshipmentlocation> st = cm.ShipmentLocationListValues(Data);
            return st;
        }


        [HttpPost("ShipmentLocationEdit")]
        public List<myshipmentlocation> ShipmentLocationEdit(myshipmentlocation Data)
        {
            MasterManager cm = new MasterManager();
            List<myshipmentlocation> st = cm.ShipmentLocationEditValues(Data);
            return st;
        }

        [HttpPost("InsertHazardousClasses")]
        public List<myHazardous> InsertHazardousClasses(myHazardous Data)
        {
            MasterManager cm = new MasterManager();
            List<myHazardous> st = cm.InsertHazardousClassesValues(Data);
            return st;
        }

        [HttpPost("HazardousEdit")]
        public List<myHazardous> HazardousEdit(myHazardous Data)
        {
            MasterManager cm = new MasterManager();
            List<myHazardous> st = cm.HazardousEditValues(Data);
            return st;
        }

        [HttpPost("HazardousClassesList")]
        public List<myHazardous> HazardousClassesList(myHazardous Data)
        {
            MasterManager cm = new MasterManager();
            List<myHazardous> st = cm.HazardousClassesListValues(Data);
            return st;
        }

        [HttpPost("UOMValues")]
        public List<myUOMConversions> UOMFromValues(myUOMConversions Data)
        {
            MasterManager cm = new MasterManager();
            List<myUOMConversions> st = cm.UOMFromValues(Data);
            return st;
        }
    
        [HttpPost("InsertUOMConversions")]
        public List<myUOMConversions> InsertUOMConversions(myUOMConversions Data)
        {
            MasterManager cm = new MasterManager();
            List<myUOMConversions> st = cm.InsertUOMConversionsValues(Data);
            return st;
        }

        [HttpPost("UOMConversionsEdit")]
        public List<myUOMConversions> UOMConversionsEdit(myUOMConversions Data)
        {
            MasterManager cm = new MasterManager();
            List<myUOMConversions> st = cm.UOMConversionsEditValues(Data);
            return st;
        }

        [HttpPost("UOMConversionsList")]
        public List<myUOMConversions> UOMConversionsList(myUOMConversions Data)
        {
            MasterManager cm = new MasterManager();
            List<myUOMConversions> st = cm.UOMConversionsListValues(Data);
            return st;
        }

        #endregion



        //Currency master

        


        [HttpPost("getCurrencyList")]
        public List<MyCurrency> getCurrencyList(MyCurrency Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCurrency> st = cm.getCurrencyListValues(Data);
            return st;
        }
        [HttpPost("saveCurrency")]
        public List<MyCurrency> saveCurrency(MyCurrency Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCurrency> st = cm.saveCurrencyValues(Data);
            return st;
        }

        [HttpPost("Currencyedit")]
        public List<MyCurrency> Currencyedit(MyCurrency Data)
        {
            MasterManager cm = new MasterManager();
            List<MyCurrency> st = cm.Currencyeditvalues(Data);
            return st;
        }

    }
    
    //internal class MergeEx
    //{
    //    public string SourceFolder { get; internal set; }
    //    public string DestinationFile { get; internal set; }

    //    internal void Execute()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
