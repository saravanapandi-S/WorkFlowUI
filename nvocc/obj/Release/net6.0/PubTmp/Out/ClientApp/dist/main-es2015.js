(self["webpackChunknvocc"] = self["webpackChunknvocc"] || []).push([["main"],{

/***/ 98255:
/*!*******************************************************!*\
  !*** ./$_lazy_route_resources/ lazy namespace object ***!
  \*******************************************************/
/***/ (function(module) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = 98255;
module.exports = webpackEmptyAsyncContext;

/***/ }),

/***/ 90158:
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppRoutingModule": function() { return /* binding */ AppRoutingModule; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_42__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_43__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var _views_masters_commonmaster_country_country_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./views/masters/commonmaster/country/country.component */ 58043);
/* harmony import */ var _views_masters_commonmaster_country_countryview1_countryview1_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./views/masters/commonmaster/country/countryview1/countryview1.component */ 91976);
/* harmony import */ var _views_masters_commonmaster_city_city_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./views/masters/commonmaster/city/city.component */ 953);
/* harmony import */ var _views_masters_commonmaster_city_cityview_cityview_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./views/masters/commonmaster/city/cityview/cityview.component */ 92979);
/* harmony import */ var _views_masters_commonmaster_commodity_commodity_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./views/masters/commonmaster/commodity/commodity.component */ 15405);
/* harmony import */ var _views_masters_commonmaster_commodity_commodityview_commodityview_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./views/masters/commonmaster/commodity/commodityview/commodityview.component */ 8968);
/* harmony import */ var _views_masters_commonmaster_cargopackage_cargopackage_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./views/masters/commonmaster/cargopackage/cargopackage.component */ 46326);
/* harmony import */ var _views_masters_commonmaster_cargopackage_cargopackageview_cargopackageview_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./views/masters/commonmaster/cargopackage/cargopackageview/cargopackageview.component */ 42545);
/* harmony import */ var _views_masters_commonmaster_port_port_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./views/masters/commonmaster/port/port.component */ 59060);
/* harmony import */ var _views_masters_commonmaster_port_portview_portview_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./views/masters/commonmaster/port/portview/portview.component */ 65306);
/* harmony import */ var _views_masters_commonmaster_terminal_terminal_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./views/masters/commonmaster/terminal/terminal.component */ 73470);
/* harmony import */ var _views_masters_commonmaster_terminal_terminalview_terminalview_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./views/masters/commonmaster/terminal/terminalview/terminalview.component */ 28520);
/* harmony import */ var _views_masters_commonmaster_uommaster_uommaster_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./views/masters/commonmaster/uommaster/uommaster.component */ 8884);
/* harmony import */ var _views_masters_commonmaster_uommaster_uommasterview_uommasterview_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./views/masters/commonmaster/uommaster/uommasterview/uommasterview.component */ 91529);
/* harmony import */ var _views_masters_commonmaster_statemaster_statemaster_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./views/masters/commonmaster/statemaster/statemaster.component */ 13356);
/* harmony import */ var _views_masters_commonmaster_statemaster_statemasterview_statemasterview_component__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ./views/masters/commonmaster/statemaster/statemasterview/statemasterview.component */ 20038);
/* harmony import */ var _views_masters_commonmaster_contypemaster_contypemaster_component__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ./views/masters/commonmaster/contypemaster/contypemaster.component */ 82777);
/* harmony import */ var _views_masters_commonmaster_contypemaster_contypemasterview_contypemasterview_component__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! ./views/masters/commonmaster/contypemaster/contypemasterview/contypemasterview.component */ 69394);
/* harmony import */ var _login_login_component__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! ./login/login.component */ 98458);
/* harmony import */ var _authentication_guard__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! ./authentication.guard */ 71225);
/* harmony import */ var _views_views_component__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! ./views/views.component */ 6963);
/* harmony import */ var _views_masters_masters_component__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! ./views/masters/masters.component */ 76348);
/* harmony import */ var _views_masters_commonmaster_commonmaster_component__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! ./views/masters/commonmaster/commonmaster.component */ 4449);
/* harmony import */ var _views_masters_commonmaster_partymaster_partymaster_component__WEBPACK_IMPORTED_MODULE_23__ = __webpack_require__(/*! ./views/masters/commonmaster/partymaster/partymaster.component */ 59816);
/* harmony import */ var _views_masters_commonmaster_partymaster_partymasterview_partymasterview_component__WEBPACK_IMPORTED_MODULE_24__ = __webpack_require__(/*! ./views/masters/commonmaster/partymaster/partymasterview/partymasterview.component */ 97658);
/* harmony import */ var _views_masters_commonmaster_storagelocationtype_storagelocationtype_component__WEBPACK_IMPORTED_MODULE_25__ = __webpack_require__(/*! ./views/masters/commonmaster/storagelocationtype/storagelocationtype.component */ 88820);
/* harmony import */ var _views_masters_commonmaster_storagelocationtype_storagelocationtypeview_storagelocationtypeview_component__WEBPACK_IMPORTED_MODULE_26__ = __webpack_require__(/*! ./views/masters/commonmaster/storagelocationtype/storagelocationtypeview/storagelocationtypeview.component */ 7623);
/* harmony import */ var _views_dashboard_dashboard_component__WEBPACK_IMPORTED_MODULE_27__ = __webpack_require__(/*! ./views/dashboard/dashboard.component */ 66101);
/* harmony import */ var _views_systemadmin_systemadmin_component__WEBPACK_IMPORTED_MODULE_28__ = __webpack_require__(/*! ./views/systemadmin/systemadmin.component */ 17948);
/* harmony import */ var _views_masters_commonmaster_shipmentlocations_shipmentlocations_component__WEBPACK_IMPORTED_MODULE_29__ = __webpack_require__(/*! ./views/masters/commonmaster/shipmentlocations/shipmentlocations.component */ 3765);
/* harmony import */ var _views_masters_commonmaster_shipmentlocations_shipmentlocationsview_shipmentlocationsview_component__WEBPACK_IMPORTED_MODULE_30__ = __webpack_require__(/*! ./views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview.component */ 35157);
/* harmony import */ var _views_masters_commonmaster_hazardousclass_hazardousclass_component__WEBPACK_IMPORTED_MODULE_31__ = __webpack_require__(/*! ./views/masters/commonmaster/hazardousclass/hazardousclass.component */ 73326);
/* harmony import */ var _views_masters_commonmaster_hazardousclass_hazardousclassview_hazardousclassview_component__WEBPACK_IMPORTED_MODULE_32__ = __webpack_require__(/*! ./views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview.component */ 68124);
/* harmony import */ var _views_masters_commonmaster_uomconversions_uomconversions_component__WEBPACK_IMPORTED_MODULE_33__ = __webpack_require__(/*! ./views/masters/commonmaster/uomconversions/uomconversions.component */ 26898);
/* harmony import */ var _views_masters_commonmaster_uomconversions_uomconversionsview_uomconversionsview_component__WEBPACK_IMPORTED_MODULE_34__ = __webpack_require__(/*! ./views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview.component */ 56980);
/* harmony import */ var _views_instanceprofile_instanceprofile_component__WEBPACK_IMPORTED_MODULE_35__ = __webpack_require__(/*! ./views/instanceprofile/instanceprofile.component */ 73202);
/* harmony import */ var _views_instanceprofile_companydetails_companydetails_component__WEBPACK_IMPORTED_MODULE_36__ = __webpack_require__(/*! ./views/instanceprofile/companydetails/companydetails.component */ 45561);
/* harmony import */ var _views_instanceprofile_clientmanagement_clientmanagement_component__WEBPACK_IMPORTED_MODULE_37__ = __webpack_require__(/*! ./views/instanceprofile/clientmanagement/clientmanagement.component */ 46535);
/* harmony import */ var _views_instanceprofile_configuration_configuration_component__WEBPACK_IMPORTED_MODULE_38__ = __webpack_require__(/*! ./views/instanceprofile/configuration/configuration.component */ 97928);
/* harmony import */ var _views_masters_commonmaster_currency_currency_component__WEBPACK_IMPORTED_MODULE_39__ = __webpack_require__(/*! ./views/masters/commonmaster/currency/currency.component */ 49072);
/* harmony import */ var _views_masters_commonmaster_currency_currencyview_currencyview_component__WEBPACK_IMPORTED_MODULE_40__ = __webpack_require__(/*! ./views/masters/commonmaster/currency/currencyview/currencyview.component */ 13095);
/* harmony import */ var _views_systemadmin_documentmanager_documentmanager_component__WEBPACK_IMPORTED_MODULE_41__ = __webpack_require__(/*! ./views/systemadmin/documentmanager/documentmanager.component */ 21848);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};












































const routes = [
    { path: '', redirectTo: "/login", pathMatch: 'full' },
    { path: 'login', component: _login_login_component__WEBPACK_IMPORTED_MODULE_18__.LoginComponent },
    {
        path: 'views', component: _views_views_component__WEBPACK_IMPORTED_MODULE_20__.ViewsComponent, canActivate: [_authentication_guard__WEBPACK_IMPORTED_MODULE_19__.AuthenticationGuard],
        children: [
            { path: 'dashboard', component: _views_dashboard_dashboard_component__WEBPACK_IMPORTED_MODULE_27__.DashboardComponent },
            { path: 'systemadmin', component: _views_systemadmin_systemadmin_component__WEBPACK_IMPORTED_MODULE_28__.SystemadminComponent },
            { path: 'masters/commonmaster', component: _views_masters_commonmaster_commonmaster_component__WEBPACK_IMPORTED_MODULE_22__.CommonmasterComponent },
            { path: 'masters/commonmaster/country/country', component: _views_masters_commonmaster_country_country_component__WEBPACK_IMPORTED_MODULE_0__.CountryComponent },
            { path: 'masters/commonmaster/country/countryview1', component: _views_masters_commonmaster_country_countryview1_countryview1_component__WEBPACK_IMPORTED_MODULE_1__.Countryview1Component },
            { path: 'masters/commonmaster/country/country', component: _views_masters_commonmaster_country_country_component__WEBPACK_IMPORTED_MODULE_0__.CountryComponent },
            { path: 'masters/masters', component: _views_masters_masters_component__WEBPACK_IMPORTED_MODULE_21__.MastersComponent },
            { path: 'masters/commonmaster/city/city', component: _views_masters_commonmaster_city_city_component__WEBPACK_IMPORTED_MODULE_2__.CityComponent },
            { path: 'masters/commonmaster/city/cityview', component: _views_masters_commonmaster_city_cityview_cityview_component__WEBPACK_IMPORTED_MODULE_3__.CityviewComponent },
            { path: 'masters/commonmaster/commodity/commodity', component: _views_masters_commonmaster_commodity_commodity_component__WEBPACK_IMPORTED_MODULE_4__.CommodityComponent },
            { path: 'masters/commonmaster/commodity/commodityview', component: _views_masters_commonmaster_commodity_commodityview_commodityview_component__WEBPACK_IMPORTED_MODULE_5__.CommodityviewComponent },
            { path: 'masters/commonmaster/cargopackage/cargopackage', component: _views_masters_commonmaster_cargopackage_cargopackage_component__WEBPACK_IMPORTED_MODULE_6__.CargopackageComponent },
            { path: 'masters/commonmaster/cargopackage/cargopackageview', component: _views_masters_commonmaster_cargopackage_cargopackageview_cargopackageview_component__WEBPACK_IMPORTED_MODULE_7__.CargopackageviewComponent },
            { path: 'masters/commonmaster/port/port', component: _views_masters_commonmaster_port_port_component__WEBPACK_IMPORTED_MODULE_8__.PortComponent },
            { path: 'masters/commonmaster/port/portview', component: _views_masters_commonmaster_port_portview_portview_component__WEBPACK_IMPORTED_MODULE_9__.PortviewComponent },
            { path: 'masters/commonmaster/terminal/terminal', component: _views_masters_commonmaster_terminal_terminal_component__WEBPACK_IMPORTED_MODULE_10__.TerminalComponent },
            { path: 'masters/commonmaster/terminal/terminalview', component: _views_masters_commonmaster_terminal_terminalview_terminalview_component__WEBPACK_IMPORTED_MODULE_11__.TerminalviewComponent },
            { path: 'masters/commonmaster/uommaster/uommaster', component: _views_masters_commonmaster_uommaster_uommaster_component__WEBPACK_IMPORTED_MODULE_12__.UommasterComponent },
            { path: 'masters/commonmaster/uommaster/uommasterview', component: _views_masters_commonmaster_uommaster_uommasterview_uommasterview_component__WEBPACK_IMPORTED_MODULE_13__.UommasterviewComponent },
            { path: 'masters/commonmaster/statemaster/statemaster', component: _views_masters_commonmaster_statemaster_statemaster_component__WEBPACK_IMPORTED_MODULE_14__.StatemasterComponent },
            { path: 'masters/commonmaster/statemaster/statemasterview', component: _views_masters_commonmaster_statemaster_statemasterview_statemasterview_component__WEBPACK_IMPORTED_MODULE_15__.StatemasterviewComponent },
            { path: 'masters/commonmaster/contypemaster/contypemaster', component: _views_masters_commonmaster_contypemaster_contypemaster_component__WEBPACK_IMPORTED_MODULE_16__.ContypemasterComponent },
            { path: 'masters/commonmaster/contypemaster/contypemasterview', component: _views_masters_commonmaster_contypemaster_contypemasterview_contypemasterview_component__WEBPACK_IMPORTED_MODULE_17__.ContypemasterviewComponent },
            { path: 'masters/commonmaster/partymaster/partymaster', component: _views_masters_commonmaster_partymaster_partymaster_component__WEBPACK_IMPORTED_MODULE_23__.PartymasterComponent },
            { path: 'masters/commonmaster/partymaster/partymasterview', component: _views_masters_commonmaster_partymaster_partymasterview_partymasterview_component__WEBPACK_IMPORTED_MODULE_24__.PartymasterviewComponent },
            { path: 'masters/commonmaster/storagelocationtype/storagelocationtype', component: _views_masters_commonmaster_storagelocationtype_storagelocationtype_component__WEBPACK_IMPORTED_MODULE_25__.StoragelocationtypeComponent },
            { path: 'masters/commonmaster/storagelocationtype/storagelocationtypeview/storagelocationtypeview', component: _views_masters_commonmaster_storagelocationtype_storagelocationtypeview_storagelocationtypeview_component__WEBPACK_IMPORTED_MODULE_26__.StoragelocationtypeviewComponent },
            { path: 'masters/commonmaster/shipmentlocations/shipmentlocations', component: _views_masters_commonmaster_shipmentlocations_shipmentlocations_component__WEBPACK_IMPORTED_MODULE_29__.ShipmentlocationsComponent },
            { path: 'masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview', component: _views_masters_commonmaster_shipmentlocations_shipmentlocationsview_shipmentlocationsview_component__WEBPACK_IMPORTED_MODULE_30__.ShipmentlocationsviewComponent },
            { path: 'masters/commonmaster/hazardousclass/hazardousclass', component: _views_masters_commonmaster_hazardousclass_hazardousclass_component__WEBPACK_IMPORTED_MODULE_31__.HazardousclassComponent },
            { path: 'masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview', component: _views_masters_commonmaster_hazardousclass_hazardousclassview_hazardousclassview_component__WEBPACK_IMPORTED_MODULE_32__.HazardousclassviewComponent },
            { path: 'masters/commonmaster/uomconversions/uomconversions', component: _views_masters_commonmaster_uomconversions_uomconversions_component__WEBPACK_IMPORTED_MODULE_33__.UomconversionsComponent },
            { path: 'masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview', component: _views_masters_commonmaster_uomconversions_uomconversionsview_uomconversionsview_component__WEBPACK_IMPORTED_MODULE_34__.UomconversionsviewComponent },
            { path: 'masters/instanceprofile/instanceprofile', component: _views_instanceprofile_instanceprofile_component__WEBPACK_IMPORTED_MODULE_35__.InstanceprofileComponent },
            { path: 'masters/instanceprofile/companydetails/companydetails', component: _views_instanceprofile_companydetails_companydetails_component__WEBPACK_IMPORTED_MODULE_36__.CompanydetailsComponent },
            { path: 'masters/instanceprofile/clientmanagement/clientmanagement', component: _views_instanceprofile_clientmanagement_clientmanagement_component__WEBPACK_IMPORTED_MODULE_37__.ClientmanagementComponent },
            { path: 'masters/instanceprofile/configuration/configuration', component: _views_instanceprofile_configuration_configuration_component__WEBPACK_IMPORTED_MODULE_38__.ConfigurationComponent },
            { path: 'masters/commonmaster/currency/currency', component: _views_masters_commonmaster_currency_currency_component__WEBPACK_IMPORTED_MODULE_39__.CurrencyComponent },
            { path: 'masters/commonmaster/currency/currencyview/currencyview', component: _views_masters_commonmaster_currency_currencyview_currencyview_component__WEBPACK_IMPORTED_MODULE_40__.CurrencyviewComponent },
            { path: 'systemadmin/documentmanager/documentmanager', component: _views_systemadmin_documentmanager_documentmanager_component__WEBPACK_IMPORTED_MODULE_41__.DocumentmanagerComponent },
        ]
    },
];
let AppRoutingModule = class AppRoutingModule {
};
AppRoutingModule = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_42__.NgModule)({
        declarations: [],
        imports: [_angular_router__WEBPACK_IMPORTED_MODULE_43__.RouterModule.forRoot(routes)],
        exports: [_angular_router__WEBPACK_IMPORTED_MODULE_43__.RouterModule]
    })
], AppRoutingModule);



/***/ }),

/***/ 55041:
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppComponent": function() { return /* binding */ AppComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_app_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./app.component.html */ 75158);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


let AppComponent = class AppComponent {
    constructor() {
        this.title = 'app';
        this.sideBarOpen = true;
    }
    sideBarToggler() {
        this.sideBarOpen = !this.sideBarOpen;
    }
};
AppComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_1__.Component)({
        selector: 'app-root',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_app_component_html__WEBPACK_IMPORTED_MODULE_0__.default
    })
], AppComponent);



/***/ }),

/***/ 36747:
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AppModule": function() { return /* binding */ AppModule; }
/* harmony export */ });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_57__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./app-routing.module */ 90158);
/* harmony import */ var _login_routing_module__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./login-routing.module */ 67819);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_56__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_59__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_58__ = __webpack_require__(/*! @angular/common/http */ 53882);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_68__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var ng2_pdf_viewer__WEBPACK_IMPORTED_MODULE_75__ = __webpack_require__(/*! ng2-pdf-viewer */ 89035);
/* harmony import */ var _globals__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./globals */ 37503);
/* harmony import */ var _angular_material_datepicker__WEBPACK_IMPORTED_MODULE_67__ = __webpack_require__(/*! @angular/material/datepicker */ 39141);
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./app.component */ 55041);
/* harmony import */ var _nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./nav-menu/nav-menu.component */ 36499);
/* harmony import */ var _home_home_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./home/home.component */ 45067);
/* harmony import */ var _counter_counter_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./counter/counter.component */ 65693);
/* harmony import */ var _fetch_data_fetch_data_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./fetch-data/fetch-data.component */ 49339);
/* harmony import */ var _header_header_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./header/header.component */ 93482);
/* harmony import */ var _sidenav_sidenav_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./sidenav/sidenav.component */ 10226);
/* harmony import */ var _side_menu_side_menu_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./side-menu/side-menu.component */ 74806);
/* harmony import */ var _views_masters_commonmaster_country_country_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./views/masters/commonmaster/country/country.component */ 58043);
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_76__ = __webpack_require__(/*! @angular/platform-browser/animations */ 20718);
/* harmony import */ var _angular_material_icon__WEBPACK_IMPORTED_MODULE_62__ = __webpack_require__(/*! @angular/material/icon */ 10524);
/* harmony import */ var _angular_material_list__WEBPACK_IMPORTED_MODULE_63__ = __webpack_require__(/*! @angular/material/list */ 81244);
/* harmony import */ var _angular_material_grid_list__WEBPACK_IMPORTED_MODULE_60__ = __webpack_require__(/*! @angular/material/grid-list */ 98076);
/* harmony import */ var _angular_material_menu__WEBPACK_IMPORTED_MODULE_61__ = __webpack_require__(/*! @angular/material/menu */ 40938);
/* harmony import */ var _angular_material_expansion__WEBPACK_IMPORTED_MODULE_64__ = __webpack_require__(/*! @angular/material/expansion */ 55933);
/* harmony import */ var _angular_material_toolbar__WEBPACK_IMPORTED_MODULE_65__ = __webpack_require__(/*! @angular/material/toolbar */ 19449);
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_66__ = __webpack_require__(/*! @angular/material/button */ 75532);
/* harmony import */ var _views_masters_commonmaster_country_countryview1_countryview1_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./views/masters/commonmaster/country/countryview1/countryview1.component */ 91976);
/* harmony import */ var _views_masters_commonmaster_city_city_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./views/masters/commonmaster/city/city.component */ 953);
/* harmony import */ var _views_masters_commonmaster_city_cityview_cityview_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./views/masters/commonmaster/city/cityview/cityview.component */ 92979);
/* harmony import */ var _views_masters_commonmaster_commodity_commodity_component__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ./views/masters/commonmaster/commodity/commodity.component */ 15405);
/* harmony import */ var _views_masters_commonmaster_commodity_commodityview_commodityview_component__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ./views/masters/commonmaster/commodity/commodityview/commodityview.component */ 8968);
/* harmony import */ var _views_masters_commonmaster_cargopackage_cargopackage_component__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! ./views/masters/commonmaster/cargopackage/cargopackage.component */ 46326);
/* harmony import */ var _views_masters_commonmaster_cargopackage_cargopackageview_cargopackageview_component__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! ./views/masters/commonmaster/cargopackage/cargopackageview/cargopackageview.component */ 42545);
/* harmony import */ var _views_masters_commonmaster_port_port_component__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! ./views/masters/commonmaster/port/port.component */ 59060);
/* harmony import */ var _views_masters_commonmaster_port_portview_portview_component__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! ./views/masters/commonmaster/port/portview/portview.component */ 65306);
/* harmony import */ var _views_masters_commonmaster_terminal_terminal_component__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! ./views/masters/commonmaster/terminal/terminal.component */ 73470);
/* harmony import */ var _views_masters_commonmaster_terminal_terminalview_terminalview_component__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! ./views/masters/commonmaster/terminal/terminalview/terminalview.component */ 28520);
/* harmony import */ var _views_masters_commonmaster_uommaster_uommaster_component__WEBPACK_IMPORTED_MODULE_23__ = __webpack_require__(/*! ./views/masters/commonmaster/uommaster/uommaster.component */ 8884);
/* harmony import */ var _views_masters_commonmaster_uommaster_uommasterview_uommasterview_component__WEBPACK_IMPORTED_MODULE_24__ = __webpack_require__(/*! ./views/masters/commonmaster/uommaster/uommasterview/uommasterview.component */ 91529);
/* harmony import */ var _views_masters_commonmaster_statemaster_statemaster_component__WEBPACK_IMPORTED_MODULE_25__ = __webpack_require__(/*! ./views/masters/commonmaster/statemaster/statemaster.component */ 13356);
/* harmony import */ var _views_masters_commonmaster_statemaster_statemasterview_statemasterview_component__WEBPACK_IMPORTED_MODULE_26__ = __webpack_require__(/*! ./views/masters/commonmaster/statemaster/statemasterview/statemasterview.component */ 20038);
/* harmony import */ var _views_masters_commonmaster_contypemaster_contypemaster_component__WEBPACK_IMPORTED_MODULE_27__ = __webpack_require__(/*! ./views/masters/commonmaster/contypemaster/contypemaster.component */ 82777);
/* harmony import */ var _views_masters_commonmaster_contypemaster_contypemasterview_contypemasterview_component__WEBPACK_IMPORTED_MODULE_28__ = __webpack_require__(/*! ./views/masters/commonmaster/contypemaster/contypemasterview/contypemasterview.component */ 69394);
/* harmony import */ var _angular_material_select__WEBPACK_IMPORTED_MODULE_70__ = __webpack_require__(/*! @angular/material/select */ 18396);
/* harmony import */ var _login_login_component__WEBPACK_IMPORTED_MODULE_29__ = __webpack_require__(/*! ./login/login.component */ 98458);
/* harmony import */ var _authguard_service_service__WEBPACK_IMPORTED_MODULE_30__ = __webpack_require__(/*! ./authguard-service.service */ 85742);
/* harmony import */ var _angular_material__WEBPACK_IMPORTED_MODULE_69__ = __webpack_require__(/*! @angular/material */ 91172);
/* harmony import */ var _angular_material__WEBPACK_IMPORTED_MODULE_73__ = __webpack_require__(/*! @angular/material */ 68879);
/* harmony import */ var _popup_popup_component__WEBPACK_IMPORTED_MODULE_31__ = __webpack_require__(/*! ./popup/popup.component */ 15122);
/* harmony import */ var _angular_material_autocomplete__WEBPACK_IMPORTED_MODULE_71__ = __webpack_require__(/*! @angular/material/autocomplete */ 92165);
/* harmony import */ var _views_views_component__WEBPACK_IMPORTED_MODULE_32__ = __webpack_require__(/*! ./views/views.component */ 6963);
/* harmony import */ var _views_masters_masters_component__WEBPACK_IMPORTED_MODULE_33__ = __webpack_require__(/*! ./views/masters/masters.component */ 76348);
/* harmony import */ var _views_masters_commonmaster_commonmaster_component__WEBPACK_IMPORTED_MODULE_34__ = __webpack_require__(/*! ./views/masters/commonmaster/commonmaster.component */ 4449);
/* harmony import */ var src_app_services_encr_decr_service_service__WEBPACK_IMPORTED_MODULE_35__ = __webpack_require__(/*! src/app/services/encr-decr-service.service */ 33056);
/* harmony import */ var mat_select_autocomplete__WEBPACK_IMPORTED_MODULE_72__ = __webpack_require__(/*! mat-select-autocomplete */ 26673);
/* harmony import */ var _angular_material_input__WEBPACK_IMPORTED_MODULE_74__ = __webpack_require__(/*! @angular/material/input */ 73204);
/* harmony import */ var _views_masters_commonmaster_partymaster_partymaster_component__WEBPACK_IMPORTED_MODULE_36__ = __webpack_require__(/*! ./views/masters/commonmaster/partymaster/partymaster.component */ 59816);
/* harmony import */ var _views_masters_commonmaster_partymaster_partymasterview_partymasterview_component__WEBPACK_IMPORTED_MODULE_37__ = __webpack_require__(/*! ./views/masters/commonmaster/partymaster/partymasterview/partymasterview.component */ 97658);
/* harmony import */ var _spinner_spinner_component__WEBPACK_IMPORTED_MODULE_38__ = __webpack_require__(/*! ./spinner/spinner.component */ 64283);
/* harmony import */ var _views_masters_commonmaster_storagelocationtype_storagelocationtype_component__WEBPACK_IMPORTED_MODULE_39__ = __webpack_require__(/*! ./views/masters/commonmaster/storagelocationtype/storagelocationtype.component */ 88820);
/* harmony import */ var _views_masters_commonmaster_storagelocationtype_storagelocationtypeview_storagelocationtypeview_component__WEBPACK_IMPORTED_MODULE_40__ = __webpack_require__(/*! ./views/masters/commonmaster/storagelocationtype/storagelocationtypeview/storagelocationtypeview.component */ 7623);
/* harmony import */ var _views_dashboard_dashboard_component__WEBPACK_IMPORTED_MODULE_41__ = __webpack_require__(/*! ./views/dashboard/dashboard.component */ 66101);
/* harmony import */ var _views_systemadmin_systemadmin_component__WEBPACK_IMPORTED_MODULE_42__ = __webpack_require__(/*! ./views/systemadmin/systemadmin.component */ 17948);
/* harmony import */ var _views_masters_commonmaster_shipmentlocations_shipmentlocations_component__WEBPACK_IMPORTED_MODULE_43__ = __webpack_require__(/*! ./views/masters/commonmaster/shipmentlocations/shipmentlocations.component */ 3765);
/* harmony import */ var _views_masters_commonmaster_shipmentlocations_shipmentlocationsview_shipmentlocationsview_component__WEBPACK_IMPORTED_MODULE_44__ = __webpack_require__(/*! ./views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview.component */ 35157);
/* harmony import */ var _views_masters_commonmaster_hazardousclass_hazardousclass_component__WEBPACK_IMPORTED_MODULE_45__ = __webpack_require__(/*! ./views/masters/commonmaster/hazardousclass/hazardousclass.component */ 73326);
/* harmony import */ var _views_masters_commonmaster_hazardousclass_hazardousclassview_hazardousclassview_component__WEBPACK_IMPORTED_MODULE_46__ = __webpack_require__(/*! ./views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview.component */ 68124);
/* harmony import */ var _views_masters_commonmaster_uomconversions_uomconversions_component__WEBPACK_IMPORTED_MODULE_47__ = __webpack_require__(/*! ./views/masters/commonmaster/uomconversions/uomconversions.component */ 26898);
/* harmony import */ var _views_masters_commonmaster_uomconversions_uomconversionsview_uomconversionsview_component__WEBPACK_IMPORTED_MODULE_48__ = __webpack_require__(/*! ./views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview.component */ 56980);
/* harmony import */ var _views_instanceprofile_instanceprofile_component__WEBPACK_IMPORTED_MODULE_49__ = __webpack_require__(/*! ./views/instanceprofile/instanceprofile.component */ 73202);
/* harmony import */ var _views_instanceprofile_companydetails_companydetails_component__WEBPACK_IMPORTED_MODULE_50__ = __webpack_require__(/*! ./views/instanceprofile/companydetails/companydetails.component */ 45561);
/* harmony import */ var _views_instanceprofile_clientmanagement_clientmanagement_component__WEBPACK_IMPORTED_MODULE_51__ = __webpack_require__(/*! ./views/instanceprofile/clientmanagement/clientmanagement.component */ 46535);
/* harmony import */ var _views_instanceprofile_configuration_configuration_component__WEBPACK_IMPORTED_MODULE_52__ = __webpack_require__(/*! ./views/instanceprofile/configuration/configuration.component */ 97928);
/* harmony import */ var _views_masters_commonmaster_currency_currency_component__WEBPACK_IMPORTED_MODULE_53__ = __webpack_require__(/*! ./views/masters/commonmaster/currency/currency.component */ 49072);
/* harmony import */ var _views_masters_commonmaster_currency_currencyview_currencyview_component__WEBPACK_IMPORTED_MODULE_54__ = __webpack_require__(/*! ./views/masters/commonmaster/currency/currencyview/currencyview.component */ 13095);
/* harmony import */ var _views_systemadmin_documentmanager_documentmanager_component__WEBPACK_IMPORTED_MODULE_55__ = __webpack_require__(/*! ./views/systemadmin/documentmanager/documentmanager.component */ 21848);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};












































































let AppModule = class AppModule {
};
AppModule = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_56__.NgModule)({
        schemas: [_angular_core__WEBPACK_IMPORTED_MODULE_56__.CUSTOM_ELEMENTS_SCHEMA],
        declarations: [
            _app_component__WEBPACK_IMPORTED_MODULE_3__.AppComponent,
            _nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_4__.NavMenuComponent,
            _home_home_component__WEBPACK_IMPORTED_MODULE_5__.HomeComponent,
            _counter_counter_component__WEBPACK_IMPORTED_MODULE_6__.CounterComponent,
            _fetch_data_fetch_data_component__WEBPACK_IMPORTED_MODULE_7__.FetchDataComponent,
            _header_header_component__WEBPACK_IMPORTED_MODULE_8__.HeaderComponent,
            _sidenav_sidenav_component__WEBPACK_IMPORTED_MODULE_9__.SidenavComponent,
            _side_menu_side_menu_component__WEBPACK_IMPORTED_MODULE_10__.SideMenuComponent,
            _views_masters_commonmaster_country_country_component__WEBPACK_IMPORTED_MODULE_11__.CountryComponent,
            _views_masters_commonmaster_country_countryview1_countryview1_component__WEBPACK_IMPORTED_MODULE_12__.Countryview1Component,
            _views_masters_commonmaster_city_city_component__WEBPACK_IMPORTED_MODULE_13__.CityComponent,
            _views_masters_commonmaster_city_cityview_cityview_component__WEBPACK_IMPORTED_MODULE_14__.CityviewComponent,
            _views_masters_commonmaster_commodity_commodity_component__WEBPACK_IMPORTED_MODULE_15__.CommodityComponent,
            _views_masters_commonmaster_commodity_commodityview_commodityview_component__WEBPACK_IMPORTED_MODULE_16__.CommodityviewComponent,
            _views_masters_commonmaster_cargopackage_cargopackage_component__WEBPACK_IMPORTED_MODULE_17__.CargopackageComponent,
            _views_masters_commonmaster_cargopackage_cargopackageview_cargopackageview_component__WEBPACK_IMPORTED_MODULE_18__.CargopackageviewComponent,
            _views_masters_commonmaster_port_port_component__WEBPACK_IMPORTED_MODULE_19__.PortComponent,
            _views_masters_commonmaster_port_portview_portview_component__WEBPACK_IMPORTED_MODULE_20__.PortviewComponent,
            _views_masters_commonmaster_terminal_terminal_component__WEBPACK_IMPORTED_MODULE_21__.TerminalComponent,
            _views_masters_commonmaster_terminal_terminalview_terminalview_component__WEBPACK_IMPORTED_MODULE_22__.TerminalviewComponent,
            _login_login_component__WEBPACK_IMPORTED_MODULE_29__.LoginComponent,
            _popup_popup_component__WEBPACK_IMPORTED_MODULE_31__.PopupComponent,
            _views_views_component__WEBPACK_IMPORTED_MODULE_32__.ViewsComponent,
            _views_masters_masters_component__WEBPACK_IMPORTED_MODULE_33__.MastersComponent,
            _views_masters_commonmaster_commonmaster_component__WEBPACK_IMPORTED_MODULE_34__.CommonmasterComponent,
            _views_masters_commonmaster_uommaster_uommaster_component__WEBPACK_IMPORTED_MODULE_23__.UommasterComponent,
            _views_masters_commonmaster_uommaster_uommasterview_uommasterview_component__WEBPACK_IMPORTED_MODULE_24__.UommasterviewComponent,
            _views_masters_commonmaster_statemaster_statemaster_component__WEBPACK_IMPORTED_MODULE_25__.StatemasterComponent,
            _views_masters_commonmaster_statemaster_statemasterview_statemasterview_component__WEBPACK_IMPORTED_MODULE_26__.StatemasterviewComponent,
            _views_masters_commonmaster_contypemaster_contypemaster_component__WEBPACK_IMPORTED_MODULE_27__.ContypemasterComponent,
            _views_masters_commonmaster_contypemaster_contypemasterview_contypemasterview_component__WEBPACK_IMPORTED_MODULE_28__.ContypemasterviewComponent,
            _views_masters_commonmaster_partymaster_partymasterview_partymasterview_component__WEBPACK_IMPORTED_MODULE_37__.PartymasterviewComponent,
            _views_masters_commonmaster_partymaster_partymaster_component__WEBPACK_IMPORTED_MODULE_36__.PartymasterComponent,
            _spinner_spinner_component__WEBPACK_IMPORTED_MODULE_38__.SpinnerComponent,
            _views_masters_commonmaster_storagelocationtype_storagelocationtype_component__WEBPACK_IMPORTED_MODULE_39__.StoragelocationtypeComponent,
            _views_masters_commonmaster_storagelocationtype_storagelocationtypeview_storagelocationtypeview_component__WEBPACK_IMPORTED_MODULE_40__.StoragelocationtypeviewComponent,
            _views_dashboard_dashboard_component__WEBPACK_IMPORTED_MODULE_41__.DashboardComponent,
            _views_systemadmin_systemadmin_component__WEBPACK_IMPORTED_MODULE_42__.SystemadminComponent,
            _views_masters_commonmaster_shipmentlocations_shipmentlocations_component__WEBPACK_IMPORTED_MODULE_43__.ShipmentlocationsComponent,
            _views_masters_commonmaster_shipmentlocations_shipmentlocationsview_shipmentlocationsview_component__WEBPACK_IMPORTED_MODULE_44__.ShipmentlocationsviewComponent,
            _views_masters_commonmaster_hazardousclass_hazardousclass_component__WEBPACK_IMPORTED_MODULE_45__.HazardousclassComponent,
            _views_masters_commonmaster_hazardousclass_hazardousclassview_hazardousclassview_component__WEBPACK_IMPORTED_MODULE_46__.HazardousclassviewComponent,
            _views_masters_commonmaster_uomconversions_uomconversions_component__WEBPACK_IMPORTED_MODULE_47__.UomconversionsComponent,
            _views_masters_commonmaster_uomconversions_uomconversionsview_uomconversionsview_component__WEBPACK_IMPORTED_MODULE_48__.UomconversionsviewComponent,
            _views_instanceprofile_instanceprofile_component__WEBPACK_IMPORTED_MODULE_49__.InstanceprofileComponent,
            _views_instanceprofile_companydetails_companydetails_component__WEBPACK_IMPORTED_MODULE_50__.CompanydetailsComponent,
            _views_instanceprofile_clientmanagement_clientmanagement_component__WEBPACK_IMPORTED_MODULE_51__.ClientmanagementComponent,
            _views_instanceprofile_configuration_configuration_component__WEBPACK_IMPORTED_MODULE_52__.ConfigurationComponent,
            _views_masters_commonmaster_currency_currency_component__WEBPACK_IMPORTED_MODULE_53__.CurrencyComponent,
            _views_masters_commonmaster_currency_currencyview_currencyview_component__WEBPACK_IMPORTED_MODULE_54__.CurrencyviewComponent,
            _views_systemadmin_documentmanager_documentmanager_component__WEBPACK_IMPORTED_MODULE_55__.DocumentmanagerComponent
        ],
        imports: [
            _angular_platform_browser__WEBPACK_IMPORTED_MODULE_57__.BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
            _angular_common_http__WEBPACK_IMPORTED_MODULE_58__.HttpClientModule,
            _app_routing_module__WEBPACK_IMPORTED_MODULE_0__.AppRoutingModule,
            _login_routing_module__WEBPACK_IMPORTED_MODULE_1__.LoginRoutingModule,
            _angular_forms__WEBPACK_IMPORTED_MODULE_59__.FormsModule,
            _angular_material_grid_list__WEBPACK_IMPORTED_MODULE_60__.MatGridListModule,
            _angular_material_menu__WEBPACK_IMPORTED_MODULE_61__.MatMenuModule,
            _angular_material_icon__WEBPACK_IMPORTED_MODULE_62__.MatIconModule,
            _angular_material_list__WEBPACK_IMPORTED_MODULE_63__.MatListModule,
            _angular_material_expansion__WEBPACK_IMPORTED_MODULE_64__.MatExpansionModule,
            _angular_material_toolbar__WEBPACK_IMPORTED_MODULE_65__.MatToolbarModule,
            _angular_material_button__WEBPACK_IMPORTED_MODULE_66__.MatButtonModule,
            _angular_material_datepicker__WEBPACK_IMPORTED_MODULE_67__.MatDatepickerModule,
            _angular_router__WEBPACK_IMPORTED_MODULE_68__.RouterModule,
            _angular_material__WEBPACK_IMPORTED_MODULE_69__.MatDialogModule,
            _angular_forms__WEBPACK_IMPORTED_MODULE_59__.ReactiveFormsModule,
            _angular_material_select__WEBPACK_IMPORTED_MODULE_70__.MatSelectModule,
            _angular_material_autocomplete__WEBPACK_IMPORTED_MODULE_71__.MatAutocompleteModule,
            mat_select_autocomplete__WEBPACK_IMPORTED_MODULE_72__.SelectAutocompleteModule,
            _angular_material__WEBPACK_IMPORTED_MODULE_73__.MatCheckboxModule,
            _angular_material_input__WEBPACK_IMPORTED_MODULE_74__.MatInputModule,
            ng2_pdf_viewer__WEBPACK_IMPORTED_MODULE_75__.PdfViewerModule,
            //RouterModule.forRoot([
            //  { path: '', component: HomeComponent, pathMatch: 'full' },
            //  { path: 'counter', component: CounterComponent },
            //    { path: 'fetch-data', component: FetchDataComponent },
            //    { path: 'masters/country/countryview', component: CountryviewComponent },
            //    { path: 'masters/country/countryview1', component: Countryview1Component },
            //]),
            _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_76__.BrowserAnimationsModule
        ],
        providers: [_authguard_service_service__WEBPACK_IMPORTED_MODULE_30__.AuthguardServiceService, src_app_services_encr_decr_service_service__WEBPACK_IMPORTED_MODULE_35__.EncrDecrServiceService, _globals__WEBPACK_IMPORTED_MODULE_2__.Globals, _angular_platform_browser__WEBPACK_IMPORTED_MODULE_57__.Title,],
        bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_3__.AppComponent],
    })
], AppModule);



/***/ }),

/***/ 71225:
/*!*****************************************!*\
  !*** ./src/app/authentication.guard.ts ***!
  \*****************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AuthenticationGuard": function() { return /* binding */ AuthenticationGuard; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var _authguard_service_service__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./authguard-service.service */ 85742);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let AuthenticationGuard = class AuthenticationGuard {
    constructor(Authguardservice, router) {
        this.Authguardservice = Authguardservice;
        this.router = router;
    }
    canActivate() {
        if (!this.Authguardservice.gettoken()) {
            this.router.navigateByUrl("/login");
        }
        //next: ActivatedRouteSnapshot,
        //state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        return true;
    }
};
AuthenticationGuard.ctorParameters = () => [
    { type: _authguard_service_service__WEBPACK_IMPORTED_MODULE_0__.AuthguardServiceService },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_1__.Router }
];
AuthenticationGuard = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Injectable)({
        providedIn: 'root'
    })
], AuthenticationGuard);



/***/ }),

/***/ 85742:
/*!**********************************************!*\
  !*** ./src/app/authguard-service.service.ts ***!
  \**********************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "AuthguardServiceService": function() { return /* binding */ AuthguardServiceService; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

let AuthguardServiceService = class AuthguardServiceService {
    constructor() { }
    gettoken() {
        return !!localStorage.getItem("SeesionUser");
    }
};
AuthguardServiceService.ctorParameters = () => [];
AuthguardServiceService = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_0__.Injectable)({
        providedIn: 'root'
    })
], AuthguardServiceService);



/***/ }),

/***/ 65693:
/*!**********************************************!*\
  !*** ./src/app/counter/counter.component.ts ***!
  \**********************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CounterComponent": function() { return /* binding */ CounterComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_counter_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./counter.component.html */ 53079);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


let CounterComponent = class CounterComponent {
    constructor() {
        this.currentCount = 0;
    }
    incrementCounter() {
        this.currentCount++;
    }
};
CounterComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_1__.Component)({
        selector: 'app-counter-component',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_counter_component_html__WEBPACK_IMPORTED_MODULE_0__.default
    })
], CounterComponent);



/***/ }),

/***/ 49339:
/*!****************************************************!*\
  !*** ./src/app/fetch-data/fetch-data.component.ts ***!
  \****************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "FetchDataComponent": function() { return /* binding */ FetchDataComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_fetch_data_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./fetch-data.component.html */ 80561);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ 53882);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let FetchDataComponent = class FetchDataComponent {
    constructor(http, baseUrl) {
        http.get(baseUrl + 'weatherforecast').subscribe(result => {
            this.forecasts = result;
        }, error => console.error(error));
    }
};
FetchDataComponent.ctorParameters = () => [
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient },
    { type: String, decorators: [{ type: _angular_core__WEBPACK_IMPORTED_MODULE_2__.Inject, args: ['BASE_URL',] }] }
];
FetchDataComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Component)({
        selector: 'app-fetch-data',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_fetch_data_component_html__WEBPACK_IMPORTED_MODULE_0__.default
    })
], FetchDataComponent);



/***/ }),

/***/ 37503:
/*!****************************!*\
  !*** ./src/app/globals.ts ***!
  \****************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "Globals": function() { return /* binding */ Globals; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

let Globals = class Globals {
    constructor() {
        this.APIURL = 'https://odaksaqa.odaksolutions.com/api';
        /*APIURL: string = 'https://localhost:44301/api'*/
        /* APIURL: string = 'https://odaksa.odaksolutions.com/api';*/
    }
};
Globals = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_0__.Injectable)()
], Globals);



/***/ }),

/***/ 93482:
/*!********************************************!*\
  !*** ./src/app/header/header.component.ts ***!
  \********************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "HeaderComponent": function() { return /* binding */ HeaderComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_header_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./header.component.html */ 7030);
/* harmony import */ var _header_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./header.component.css */ 22978);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let HeaderComponent = class HeaderComponent {
    /* @Output() toggleSidebarForMe: EventEmitter<any> = new EventEmitter();*/
    constructor() { }
    ngOnInit() {
    }
};
HeaderComponent.ctorParameters = () => [];
HeaderComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Component)({
        selector: 'app-header',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_header_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_header_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], HeaderComponent);



/***/ }),

/***/ 45067:
/*!****************************************!*\
  !*** ./src/app/home/home.component.ts ***!
  \****************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "HomeComponent": function() { return /* binding */ HomeComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_home_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./home.component.html */ 91659);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


let HomeComponent = class HomeComponent {
    constructor() { }
    ngOnInit() {
        this.loadJsFile("../assets/plugins/alertify/js/alertify.js");
    }
    loadJsFile(url) {
        let node = document.createElement('script');
        node.src = url;
        node.type = 'text/javascript';
        document.getElementsByTagName('head')[0].appendChild(node);
    }
};
HomeComponent.ctorParameters = () => [];
HomeComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_1__.Component)({
        selector: 'app-home',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_home_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
    })
], HomeComponent);



/***/ }),

/***/ 67819:
/*!*****************************************!*\
  !*** ./src/app/login-routing.module.ts ***!
  \*****************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "LoginRoutingModule": function() { return /* binding */ LoginRoutingModule; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var _login_login_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./login/login.component */ 98458);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



const routes = [
    { path: '', component: _login_login_component__WEBPACK_IMPORTED_MODULE_0__.LoginComponent, pathMatch: 'full' },
];
let LoginRoutingModule = class LoginRoutingModule {
};
LoginRoutingModule = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_1__.NgModule)({
        declarations: [],
        imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__.RouterModule.forRoot(routes)],
        exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__.RouterModule]
    })
], LoginRoutingModule);



/***/ }),

/***/ 98458:
/*!******************************************!*\
  !*** ./src/app/login/login.component.ts ***!
  \******************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "LoginComponent": function() { return /* binding */ LoginComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_login_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./login.component.html */ 82090);
/* harmony import */ var _login_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./login.component.css */ 55440);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _services_login_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../services/login.service */ 54120);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};








let LoginComponent = class LoginComponent {
    constructor(router, route, LService, fb, titleService) {
        this.router = router;
        this.route = route;
        this.LService = LService;
        this.fb = fb;
        this.titleService = titleService;
        this.title = 'Odak Solutions Pvt Ltd';
        this.user = '1';
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
        this.createForm();
        localStorage.setItem('SeesionUser', this.user);
    }
    createForm() {
        this.LoginForm = this.fb.group({
            ID: 0,
            Username: '',
            Password: '',
            Token: ''
        });
    }
    OnsubmitLogin() {
        var Validation = "";
        if (this.LoginForm.value.Username == "") {
            Validation += "please type email id</br>";
        }
        if (this.LoginForm.value.Password == "") {
            Validation += "please type Password</br>";
        }
        if (Validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(Validation);
            return;
        }
        this.LService.getLoginList(this.LoginForm.value).subscribe(data => {
            this.allItems = data;
            localStorage.setItem("UserID", data[0].ID.toString());
            localStorage.setItem("Token", data[0].Token);
            localStorage.setItem("EncKey", "ODAK21$#@$^@1ODK");
            localStorage.setItem("NotAllowed", "Edit not Allowed");
            localStorage.setItem("Save", "Record Saved Successfully");
            this.router.navigate(['/views/dashboard']);
        });
    }
    OnsubmitOverlay() {
        /* $('#overlay').fadeIn().delay(2000).fadeOut();*/
    }
};
LoginComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_4__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_4__.ActivatedRoute },
    { type: _services_login_service__WEBPACK_IMPORTED_MODULE_3__.LoginService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormBuilder },
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_6__.Title }
];
LoginComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_7__.Component)({
        selector: 'app-login',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_login_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_login_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], LoginComponent);



/***/ }),

/***/ 36499:
/*!************************************************!*\
  !*** ./src/app/nav-menu/nav-menu.component.ts ***!
  \************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "NavMenuComponent": function() { return /* binding */ NavMenuComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_nav_menu_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./nav-menu.component.html */ 13230);
/* harmony import */ var _nav_menu_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./nav-menu.component.css */ 20106);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let NavMenuComponent = class NavMenuComponent {
    constructor() {
        this.isExpanded = false;
    }
    collapse() {
        this.isExpanded = false;
    }
    toggle() {
        this.isExpanded = !this.isExpanded;
    }
};
NavMenuComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Component)({
        selector: 'app-nav-menu',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_nav_menu_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_nav_menu_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], NavMenuComponent);



/***/ }),

/***/ 35217:
/*!***************************************!*\
  !*** ./src/app/pagination.service.ts ***!
  \***************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PaginationService": function() { return /* binding */ PaginationService; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var underscore__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! underscore */ 1173);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


let PaginationService = class PaginationService {
    getPager(totalItems, currentPage = 1, pageSize = 10) {
        // calculate total pages
        let totalPages = Math.ceil(totalItems / pageSize);
        let startPage, endPage;
        //if (totalPages <= 10) {
        //    // less than 10 total pages so show all
        //    startPage = 1;
        //    endPage = totalPages;
        //} else {
        //    // more than 10 total pages so calculate start and end pages
        //    if (currentPage <= 6) {
        //        startPage = 1;
        //        endPage = 10;
        //    } else if (currentPage + 4 >= totalPages) {
        //        startPage = totalPages - 9;
        //        endPage = totalPages;
        //    } else {
        //        startPage = currentPage - 5;
        //        endPage = currentPage + 4;
        //    }
        //}
        if (totalPages <= 5) {
            startPage = 1;
            endPage = totalPages;
        }
        else {
            if (currentPage <= 3) {
                startPage = 1;
                endPage = 5;
            }
            else if (currentPage + 1 >= totalPages) {
                startPage = totalPages - 4;
                endPage = totalPages;
            }
            else {
                if ((totalPages - (currentPage - 2)) == 5) {
                    startPage = currentPage - 1;
                    endPage = currentPage + 3;
                }
                else {
                    startPage = currentPage - 2;
                    endPage = currentPage + 2;
                }
            }
        }
        // calculate start and end item indexes
        let startIndex = (currentPage - 1) * pageSize;
        let endIndex = Math.min(startIndex + pageSize - 1, totalItems - 1);
        // create an array of pages to ng-repeat in the pager control
        let pages = underscore__WEBPACK_IMPORTED_MODULE_0__.range(startPage, endPage + 1);
        // return object with all pager properties required by the view
        return {
            totalItems: totalItems,
            currentPage: currentPage,
            pageSize: pageSize,
            totalPages: totalPages,
            startPage: startPage,
            endPage: endPage,
            startIndex: startIndex,
            endIndex: endIndex,
            pages: pages
        };
    }
};
PaginationService = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_1__.Injectable)({
        providedIn: 'root'
    })
], PaginationService);



/***/ }),

/***/ 15122:
/*!******************************************!*\
  !*** ./src/app/popup/popup.component.ts ***!
  \******************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PopupComponent": function() { return /* binding */ PopupComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_popup_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./popup.component.html */ 55823);
/* harmony import */ var _popup_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./popup.component.css */ 50970);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_material_dialog__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material/dialog */ 91172);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




let PopupComponent = class PopupComponent {
    constructor(dialogRef) {
        this.dialogRef = dialogRef;
    }
    ngOnInit() {
    }
};
PopupComponent.ctorParameters = () => [
    { type: _angular_material_dialog__WEBPACK_IMPORTED_MODULE_2__.MatDialogRef }
];
PopupComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_3__.Component)({
        selector: 'app-popup',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_popup_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_popup_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], PopupComponent);



/***/ }),

/***/ 33056:
/*!*******************************************************!*\
  !*** ./src/app/services/encr-decr-service.service.ts ***!
  \*******************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "EncrDecrServiceService": function() { return /* binding */ EncrDecrServiceService; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var crypto_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! crypto-js */ 95373);
/* harmony import */ var crypto_js__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(crypto_js__WEBPACK_IMPORTED_MODULE_0__);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


let EncrDecrServiceService = class EncrDecrServiceService {
    constructor() { }
    set(keys, value) {
        var key = crypto_js__WEBPACK_IMPORTED_MODULE_0__.enc.Utf8.parse(keys);
        var iv = crypto_js__WEBPACK_IMPORTED_MODULE_0__.enc.Utf8.parse(keys);
        var encrypted = crypto_js__WEBPACK_IMPORTED_MODULE_0__.AES.encrypt(crypto_js__WEBPACK_IMPORTED_MODULE_0__.enc.Utf8.parse(value.toString()), key, {
            keySize: 128 / 8,
            iv: iv,
            mode: crypto_js__WEBPACK_IMPORTED_MODULE_0__.mode.CBC,
            padding: crypto_js__WEBPACK_IMPORTED_MODULE_0__.pad.Pkcs7
        });
        return encrypted.toString();
    }
    get(keys, value) {
        var key = crypto_js__WEBPACK_IMPORTED_MODULE_0__.enc.Utf8.parse(keys);
        var iv = crypto_js__WEBPACK_IMPORTED_MODULE_0__.enc.Utf8.parse(keys);
        var decrypted = crypto_js__WEBPACK_IMPORTED_MODULE_0__.AES.decrypt(value, key, {
            keySize: 128 / 8,
            iv: iv,
            mode: crypto_js__WEBPACK_IMPORTED_MODULE_0__.mode.CBC,
            padding: crypto_js__WEBPACK_IMPORTED_MODULE_0__.pad.Pkcs7
        });
        return decrypted.toString(crypto_js__WEBPACK_IMPORTED_MODULE_0__.enc.Utf8);
    }
};
EncrDecrServiceService.ctorParameters = () => [];
EncrDecrServiceService = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_1__.Injectable)({
        providedIn: 'root'
    })
], EncrDecrServiceService);



/***/ }),

/***/ 489:
/*!*********************************************!*\
  !*** ./src/app/services/enquiry.service.ts ***!
  \*********************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "EnquiryService": function() { return /* binding */ EnquiryService; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ 53882);
/* harmony import */ var _globals__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../globals */ 37503);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let EnquiryService = class EnquiryService {
    /*readonly APIUrl = "https://localhost:44301/api";*/
    constructor(http, globals) {
        this.http = http;
        this.globals = globals;
        this.authToken = "";
    }
    loadToken() {
        const token = localStorage.getItem('Token');
        this.authToken = token;
    }
    createAuthHeader() {
        this.loadToken();
        const headers = new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders().set('Authorization', `Bearer ${this.authToken}`);
        return { headers };
    }
    getCustomerList() {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/CustomerMaster', this.createAuthHeader());
    }
    getUserMasterList() {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/UserMaster', this.createAuthHeader());
    }
    getAgencyMasterList() {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/AgencyMaster', this.createAuthHeader());
    }
    getPortList() {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/PortValues', this.createAuthHeader());
    }
    getGeneralList(id) {
        return this.http.get(this.globals.APIURL + '/CommonAccessApi/ModuleValues/' + id, this.createAuthHeader());
    }
    getVslVoyList() {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/VesselMaster', this.createAuthHeader());
    }
    getCntrTypesList() {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/CntrTypeValues', this.createAuthHeader());
    }
    getTerminalList(OL) {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/BindTerminalPortMaster', OL, this.createAuthHeader());
    }
    getCargoMasterList() {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/CommodityValues', this.createAuthHeader());
    }
    getPrincibleList() {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/PrincipleMaster', this.createAuthHeader());
    }
    getPrincibleAgenctPort(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/equiryPrincipalport', OL, this.createAuthHeader());
    }
    getPrincibleFreightCharges(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/equiryPrincipalFreightCharges', OL, this.createAuthHeader());
    }
    getPrincibleRevenuCharges(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/equiryPrincipalRevenuCharges', OL, this.createAuthHeader());
    }
    EnquirySaveList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/enquiryInsert', OL, this.createAuthHeader());
    }
    viewExstingEnquiryList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/exsistingenquiry', OL, this.createAuthHeader());
    }
    bindExstingEnquiryList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingEnquiryBind', OL, this.createAuthHeader());
    }
    bindExstingEnquiryCntrTypeList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingEnquiryCntrTypeBind', OL, this.createAuthHeader());
    }
    bindExstingEnquiryHazardousList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingEnquiryHazardousBind', OL, this.createAuthHeader());
    }
    bindExstingEnquiryOutGaugeCargoList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingEnquiryOutGaugeBind', OL, this.createAuthHeader());
    }
    bindExstingEnquiryRefferList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingEnquiryRefferBind', OL, this.createAuthHeader());
    }
    bindExstingEnquiryShipmentPOLList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingEnquiryShimpmentPOLBind', OL, this.createAuthHeader());
    }
    bindExstingEnquiryShipmentPODList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingEnquiryShimpmentPODBind', OL, this.createAuthHeader());
    }
    bindExstingEnquiryFreightRateList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingEnquiryFreightRateBind', OL, this.createAuthHeader());
    }
    bindExstingEnquirySlotList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingEnquirySlotRateBind', OL, this.createAuthHeader());
    }
    bindExstingEnquiryRevenuRateList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingEnquiryRevenuRateBind', OL, this.createAuthHeader());
    }
    getCurrencyList() {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/CurrencyValues', this.createAuthHeader());
    }
    getChargeCodeList() {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/ChargeCode', this.createAuthHeader());
    }
    InsertfromEnquiry(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/InsertFromEnquiry', OL);
    }
    EnquiryFreightBrackupSaveList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/enquiryFreightBrackupInsert', OL, this.createAuthHeader());
    }
    bindExstingEnquiryFreightBrackupList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingFreightBrackupvalues', OL, this.createAuthHeader());
    }
    bindExstingEnquiryBkgFreightBrackupList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingBkgFreightBrackupvalues', OL, this.createAuthHeader());
    }
    bindCommodityHSCode(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingCommodityHSCode', OL, this.createAuthHeader());
    }
    getLinerContractList() {
        return this.http.post(this.globals.APIURL + '/enquiryApi/LinerMaster', this.createAuthHeader());
    }
    getCustomerContractList() {
        return this.http.post(this.globals.APIURL + '/enquiryApi/CustomerContractMaster', this.createAuthHeader());
    }
    InsertCopyEnquiry(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/enquiryCopyInsert', OL);
    }
    EnquiryStatusList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/enquiryStatusUpdate', OL, this.createAuthHeader());
    }
    getVoyageList(id) {
        return this.http.get(this.globals.APIURL + '/CommonAccessApi/newVoyageMaster/' + id, this.createAuthHeader());
    }
    //getVoyageList(OL: drodownVeslVoyage): Observable<drodownVeslVoyage[]> {
    //    return this.http.get<drodownVeslVoyage[]>(this.globals.APIURL + '/CommonAccessApi/VoyageMaster/' + OL, this.createAuthHeader());
    //}
    getOfficeList() {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/OfficeLocationMaster', this.createAuthHeader());
    }
    DeleteEnqCntrType(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/EnquiryCntrTypeDelete', OL, this.createAuthHeader());
    }
    bindExstingEnquiryAttachedList(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/ExistingEnquiryAttched', OL, this.createAuthHeader());
    }
    download(fileUrl) {
        return this.http.get(`${this.globals.APIURL}/enquiryApi/download?fileUrl=${fileUrl}`, {
            reportProgress: true,
            observe: 'events',
            responseType: 'blob'
        });
    }
    DeleteEnqAttahced(OL) {
        return this.http.post(this.globals.APIURL + '/enquiryApi/EnquiryAttahcedDelete', OL, this.createAuthHeader());
    }
};
EnquiryService.ctorParameters = () => [
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient },
    { type: _globals__WEBPACK_IMPORTED_MODULE_0__.Globals }
];
EnquiryService = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Injectable)({
        providedIn: 'root'
    })
], EnquiryService);



/***/ }),

/***/ 54120:
/*!*******************************************!*\
  !*** ./src/app/services/login.service.ts ***!
  \*******************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "LoginService": function() { return /* binding */ LoginService; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ 53882);
/* harmony import */ var _globals__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../globals */ 37503);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let LoginService = class LoginService {
    constructor(http, globals) {
        this.http = http;
        this.globals = globals;
    }
    getLoginList(OL) {
        var reqHeader = new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders({ 'Content-Type': 'application/json', 'No-Auth': 'True' });
        return this.http.post(this.globals.APIURL + '/Home/Login', OL, { headers: reqHeader });
    }
};
LoginService.ctorParameters = () => [
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient },
    { type: _globals__WEBPACK_IMPORTED_MODULE_0__.Globals }
];
LoginService = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Injectable)({
        providedIn: 'root'
    })
], LoginService);



/***/ }),

/***/ 52852:
/*!*********************************************!*\
  !*** ./src/app/services/masters.service.ts ***!
  \*********************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "MastersService": function() { return /* binding */ MastersService; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ 53882);
/* harmony import */ var _globals__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../globals */ 37503);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let MastersService = class MastersService {
    /*readonly APIUrl = "https://localhost:44301/api";*/
    constructor(http, globals) {
        this.http = http;
        this.globals = globals;
        this.authToken = "";
    }
    loadToken() {
        const token = localStorage.getItem('Token');
        this.authToken = token;
    }
    createAuthHeader() {
        this.loadToken();
        const headers = new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders().set('Authorization', `Bearer ${this.authToken}`);
        return { headers };
    }
    getCountryList(OL) {
        return this.http.post(this.globals.APIURL + '/home/CountryView', OL, this.createAuthHeader());
    }
    getCountryEdit(OL) {
        return this.http.post(this.globals.APIURL + '/home/countryEdit', OL);
    }
    saveCtry(OD) {
        return this.http.post(this.globals.APIURL + '/home/CountryInsert/', OD);
    }
    /*City*/
    getCityList(OL) {
        return this.http.post(this.globals.APIURL + '/home/CityView', OL);
    }
    getCityEdit(OL) {
        return this.http.post(this.globals.APIURL + '/home/CityEdit', OL);
    }
    saveCty(OD) {
        return this.http.post(this.globals.APIURL + '/home/City/', OD);
    }
    /*port*/
    getPortList(OL) {
        return this.http.post(this.globals.APIURL + '/home/Portview', OL);
    }
    getCountryBind() {
        return this.http.get(this.globals.APIURL + '/home/countryBind');
    }
    getPortEdit(OL) {
        return this.http.post(this.globals.APIURL + '/home/Portviewedit', OL);
    }
    //getGeoLocByCountryBind(OL: MyAgency): Observable<MyAgency[]> {
    //    return this.http.post<MyAgency[]>(this.globals.APIURL + '/home/GeoLocByCountry' ,OL);
    //}
    getGeoLocByCountryBind(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OfficeLocation', OL);
    }
    getGeoLocBind(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OfficeLocationBind', OL);
    }
    savePort(OD) {
        return this.http.post(this.globals.APIURL + '/home/Port/', OD);
    }
    /*Terminal*/
    getTerminalList(OL) {
        return this.http.post(this.globals.APIURL + '/home/TerminalView', OL);
    }
    getTerminaledit(OL) {
        return this.http.post(this.globals.APIURL + '/home/TerminalRecord', OL);
    }
    getPortBind() {
        return this.http.get(this.globals.APIURL + '/home/portBind');
    }
    saveTerminal(OD) {
        return this.http.post(this.globals.APIURL + '/home/Terminal/', OD);
    }
    /*Commodity*/
    getCommodityList(OL) {
        return this.http.post(this.globals.APIURL + '/home/Commodityview', OL);
    }
    getCommodityedit(OL) {
        return this.http.post(this.globals.APIURL + '/home/Commodityviewedit', OL);
    }
    saveCommodity(OD) {
        return this.http.post(this.globals.APIURL + '/home/Commodity', OD);
    }
    getCommodityTypes(OL) {
        return this.http.post(this.globals.APIURL + '/home/CommodityTypes', OL);
    }
    /*Cargo*/
    getCargoList(OL) {
        return this.http.post(this.globals.APIURL + '/home/CargoPkgview', OL);
    }
    getCargoedit(OL) {
        return this.http.post(this.globals.APIURL + '/home/CargoPkgviewedit', OL);
    }
    saveCargo(OD) {
        return this.http.post(this.globals.APIURL + '/home/CargoPackage', OD);
    }
    /*UOMMaster*/
    saveUOM(OD) {
        return this.http.post(this.globals.APIURL + '/home/UOMMaster', OD);
    }
    getUOMedit(OL) {
        return this.http.post(this.globals.APIURL + '/home/UOMMasterviewedit', OL);
    }
    getUOMList(OL) {
        return this.http.post(this.globals.APIURL + '/home/UOMMasterview', OL);
    }
    getUOMTypes(OL) {
        return this.http.post(this.globals.APIURL + '/home/UOMTypes', OL);
    }
    getUOMActions(OL) {
        return this.http.post(this.globals.APIURL + '/home/UOMActions', OL);
    }
    getUOMValues(OL) {
        return this.http.post(this.globals.APIURL + '/home/UOMValues', OL);
    }
    /*StateMaster*/
    saveState(OD) {
        return this.http.post(this.globals.APIURL + '/home/State', OD);
    }
    getStateedit(OL) {
        return this.http.post(this.globals.APIURL + '/home/StateRecord', OL);
    }
    getStateList(OL) {
        return this.http.post(this.globals.APIURL + '/home/StateView', OL);
    }
    getStateBind() {
        return this.http.get(this.globals.APIURL + '/home/stateBind');
    }
    getStatesBindByCtry(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/BindStatesByCountry', OL, this.createAuthHeader());
    }
    /* Depot Master */
    getDepotList(OL) {
        return this.http.post(this.globals.APIURL + '/home/DepotView', OL);
    }
    getDepotedit(OL) {
        return this.http.post(this.globals.APIURL + '/home/DepotRecord', OL);
    }
    getDepoteditDtls(OL) {
        return this.http.post(this.globals.APIURL + '/home/BindDepoMasterPortDtls', OL);
    }
    saveDepot(OD) {
        return this.http.post(this.globals.APIURL + '/home/Depot', OD);
    }
    getCityBind(OL) {
        return this.http.post(this.globals.APIURL + '/home/cityBind', OL);
    }
    getPortByCountryBind(id) {
        return this.http.get(this.globals.APIURL + '/home/PortByCountry/' + id);
    }
    getCityByCountryBind(id) {
        return this.http.get(this.globals.APIURL + '/home/BindCities/' + id);
    }
    /*DamageMaster*/
    saveDamage(OD) {
        return this.http.post(this.globals.APIURL + '/home/DamageMaster', OD);
    }
    getDamageedit(OL) {
        return this.http.post(this.globals.APIURL + '/home/DamageMasterviewedit', OL);
    }
    getDamageList(OL) {
        return this.http.post(this.globals.APIURL + '/home/DamageMasterview', OL);
    }
    /*RepairMaster*/
    saveRepair(OD) {
        return this.http.post(this.globals.APIURL + '/home/RepairMaster', OD);
    }
    getRepairedit(OL) {
        return this.http.post(this.globals.APIURL + '/home/RepairMasterviewedit', OL);
    }
    getRepairList(OL) {
        return this.http.post(this.globals.APIURL + '/home/RepairMasterview', OL);
    }
    /*ContLocationMaster*/
    saveContLocation(OD) {
        return this.http.post(this.globals.APIURL + '/home/ContLocationMaster', OD);
    }
    getContLocationedit(OL) {
        return this.http.post(this.globals.APIURL + '/home/ContLocationMasterviewedit', OL);
    }
    getContLocationList(OL) {
        return this.http.post(this.globals.APIURL + '/home/ContLocationMasterview', OL);
    }
    /*ComponentMaster*/
    saveComponent(OD) {
        return this.http.post(this.globals.APIURL + '/home/MNRComponentMaster', OD);
    }
    getComponentedit(OL) {
        return this.http.post(this.globals.APIURL + '/home/MNRComponentViewEdit', OL);
    }
    getComponentList(OL) {
        return this.http.post(this.globals.APIURL + '/home/MNRComponentView', OL);
    }
    getAssemblyBind(OL) {
        return this.http.post(this.globals.APIURL + '/home/BindAssembly', OL);
    }
    getNotesList(OL) {
        return this.http.post(this.globals.APIURL + '/home/NotesandClausesView', OL);
    }
    SaveNotes(OD) {
        return this.http.post(this.globals.APIURL + '/home/NotesandClausesInsert', OD);
    }
    getNotesEditDtls(OL) {
        return this.http.post(this.globals.APIURL + '/home/ExistingNotesandClauses', OL);
    }
    DeleteNotes(OD) {
        return this.http.post(this.globals.APIURL + '/home/NotesandClausesDelete', OD);
    }
    /*ContTypeMaster*/
    saveContType(OD) {
        return this.http.post(this.globals.APIURL + '/home/ContTypeMaster', OD);
    }
    getContTypeedit(OL) {
        return this.http.post(this.globals.APIURL + '/home/ContTypeMasterviewedit', OL);
    }
    getContTypeList(OL) {
        return this.http.post(this.globals.APIURL + '/home/ContTypeMasterview', OL);
    }
    getContainerTypes(OL) {
        return this.http.post(this.globals.APIURL + '/home/CntrTypeValues', OL);
    }
    getContainerSize(OL) {
        return this.http.post(this.globals.APIURL + '/home/ContainerSize', OL);
    }
    getContainerGroup(OL) {
        return this.http.post(this.globals.APIURL + '/home/ContainerGroup', OL);
    }
    /*Vessel Master*/
    getVesselList(OL) {
        return this.http.post(this.globals.APIURL + '/home/Vesselview', OL);
    }
    getVesseledit(OL) {
        return this.http.post(this.globals.APIURL + '/home/Vesselviewparticular', OL);
    }
    saveVessel(OD) {
        return this.http.post(this.globals.APIURL + '/home/Vessel', OD);
    }
    /*Service Setup*/
    getServiceSetupList(OL) {
        return this.http.post(this.globals.APIURL + '/home/ServiceSetupView', OL);
    }
    getServiceSetupedit(OL) {
        return this.http.post(this.globals.APIURL + '/home/ServiceSetupEdit', OL);
    }
    saveServiceSetup(OD) {
        return this.http.post(this.globals.APIURL + '/home/InsertServiceSetup', OD);
    }
    getServiceSetupRoutedit(OL) {
        return this.http.post(this.globals.APIURL + '/home/ServiceRouteEdit', OL);
    }
    getOperatorBind(OL) {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/CustomerBussTypesMaster', OL);
    }
    getServiceOperatoredit(OL) {
        return this.http.post(this.globals.APIURL + '/home/ServiceOperatorsEdit', OL);
    }
    getServiceRouteDelete(OL) {
        return this.http.post(this.globals.APIURL + '/home/ServiceRouteDelete', OL);
    }
    getServiceOperatorDelete(OL) {
        return this.http.post(this.globals.APIURL + '/home/ServiceOperatorsDelete', OL);
    }
    /*Voyage Details*/
    getVoyageList(OL) {
        return this.http.post(this.globals.APIURL + '/home/VoyageDetailsView', OL);
    }
    getServiceBind(OL) {
        return this.http.post(this.globals.APIURL + '/home/BindServices', OL);
    }
    getVesselBind(OL) {
        return this.http.post(this.globals.APIURL + '/home/VesselDropDown', OL);
    }
    getPortbyServiceBind(OL) {
        return this.http.post(this.globals.APIURL + '/home/BindServiceSchedule', OL);
    }
    getTerminalbyPort(OL) {
        return this.http.post(this.globals.APIURL + '/home/BindTerminalByPort', OL);
    }
    saveVoyageDetails(OD) {
        return this.http.post(this.globals.APIURL + '/home/InsertVoyageFirstTab', OD);
    }
    getVoyageEdit(OL) {
        return this.http.post(this.globals.APIURL + '/home/VoyageDetailsEdit', OL);
    }
    getVoyageDtlsEdit(OL) {
        return this.http.post(this.globals.APIURL + '/home/VoyageSailingDetailsEdit', OL);
    }
    saveVoyageOperator(OD) {
        return this.http.post(this.globals.APIURL + '/home/InsertOperatorServices', OD);
    }
    getVoyageOperatorEdit(OL) {
        return this.http.post(this.globals.APIURL + '/home/VoyageOperatorsEdit', OL);
    }
    getVoyageOperatorDelete(OL) {
        return this.http.post(this.globals.APIURL + '/home/VoyageOperatorsDelete', OL);
    }
    saveVoyageManifest(OD) {
        return this.http.post(this.globals.APIURL + '/home/InsertManifestDtls', OD);
    }
    getVoyageManifestEdit(OL) {
        return this.http.post(this.globals.APIURL + '/home/ViewManifestDtls', OL);
    }
    getVoyageType(OL) {
        return this.http.post(this.globals.APIURL + '/home/BindVoyageTypes', OL);
    }
    saveVoyageNotes(OD) {
        return this.http.post(this.globals.APIURL + '/home/InsertVoyageNotes', OD);
    }
    getVoyageNotesEdit(OL) {
        return this.http.post(this.globals.APIURL + '/home/BindVoyageNotes', OL);
    }
    getVoyageNotesDelete(OL) {
        return this.http.post(this.globals.APIURL + '/home/VoyageNotesDelete', OL);
    }
    getPDF(OL) {
        return this.http.post(this.globals.APIURL + '/home/BLPrintPDF', OL);
    }
    //Aravind
    getHSCode(OL) {
        return this.http.post(this.globals.APIURL + '/home/GetHSCode', OL);
    }
    //udhaya ShipmentLocations
    getSaveshipmentlocation(OL) {
        return this.http.post(this.globals.APIURL + '/home/InsertShipment', OL);
    }
    ShipmentLocationList(OL) {
        return this.http.post(this.globals.APIURL + '/home/ShipmentLocationList', OL);
    }
    ShipmentLocationEdit(OL) {
        return this.http.post(this.globals.APIURL + '/home/ShipmentLocationEdit', OL);
    }
    getCountry(OL) {
        return this.http.post(this.globals.APIURL + '/home/countryList', OL);
    }
    getcitylist(OL) {
        return this.http.post(this.globals.APIURL + '/home/Citylist', OL);
    }
    //Hazardous Classes
    getSaveHazardousClasses(OL) {
        return this.http.post(this.globals.APIURL + '/home/InsertHazardousClasses', OL);
    }
    HazardousEdit(OL) {
        return this.http.post(this.globals.APIURL + '/home/HazardousEdit', OL);
    }
    HazardousClassesList(OL) {
        return this.http.post(this.globals.APIURL + '/home/HazardousClassesList', OL);
    }
    //UOM Conversions 
    SaveUOMConversions(OL) {
        return this.http.post(this.globals.APIURL + '/home/InsertUOMConversions', OL);
    }
    UOMConversionsEdit(OL) {
        return this.http.post(this.globals.APIURL + '/home/UOMConversionsEdit', OL);
    }
    UOMConversionsList(OL) {
        return this.http.post(this.globals.APIURL + '/home/UOMConversionsList', OL);
    }
    //Currency Name master
    getCurrencyList(OL) {
        return this.http.post(this.globals.APIURL + '/home/getCurrencyList', OL);
    }
    saveCurrency(OL) {
        return this.http.post(this.globals.APIURL + '/home/saveCurrency', OL);
    }
    Currencyedit(OL) {
        return this.http.post(this.globals.APIURL + '/home/Currencyedit', OL);
    }
};
MastersService.ctorParameters = () => [
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient },
    { type: _globals__WEBPACK_IMPORTED_MODULE_0__.Globals }
];
MastersService = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Injectable)({
        providedIn: 'root'
    })
], MastersService);



/***/ }),

/***/ 51957:
/*!*****************************************!*\
  !*** ./src/app/services/org.service.ts ***!
  \*****************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "OrgService": function() { return /* binding */ OrgService; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ 53882);
/* harmony import */ var _globals__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../globals */ 37503);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let OrgService = class OrgService {
    /* readonly APIUrl = "https://localhost:44301/api";*/
    constructor(http, globals) {
        this.http = http;
        this.globals = globals;
        this.authToken = "";
    }
    loadToken() {
        const token = localStorage.getItem('Token');
        this.authToken = token;
    }
    createAuthHeader() {
        this.loadToken();
        const headers = new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders().set('Authorization', `Bearer ${this.authToken}`);
        return { headers };
    }
    //---OFFICE---//
    getRegionList(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/RegionView', OL, this.createAuthHeader());
    }
    getRegionEdit(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/RegionEdit', OL, this.createAuthHeader());
    }
    saveRegion(OD) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/RegionInsert/', OD, this.createAuthHeader());
    }
    //-Region end---//
    //---OFFICE---//
    getCityBind(OL) {
        return this.http.post(this.globals.APIURL + '/home/cityBind', OL, this.createAuthHeader());
    }
    getCitiesBindByCountry(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/BindCitiesByCountry', OL, this.createAuthHeader());
    }
    getStateBind(OL) {
        return this.http.post(this.globals.APIURL + '/home/stateBind', OL, this.createAuthHeader());
    }
    getStatesBindByCtry(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/BindStatesByCountry', OL, this.createAuthHeader());
    }
    getOfficeList(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OfficeView', OL, this.createAuthHeader());
    }
    getOfficeEdit(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OfficeEdit', OL, this.createAuthHeader());
    }
    saveOffice(OD) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OfficeInsert/', OD, this.createAuthHeader());
    }
    //--OFFICE end---//
    //--sales OFFICE ---//
    getOfficeLocBind(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OfficeLocBind', OL, this.createAuthHeader());
    }
    getOfficeByLoc(id) {
        return this.http.get(this.globals.APIURL + '/OrgStructure/OfficeByLoc/' + id, this.createAuthHeader());
    }
    getOfficeByLocs(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OfficeByLocs', OL, this.createAuthHeader());
    }
    saveSalesOffice(OD) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/SalesOfficeInsert/', OD, this.createAuthHeader());
    }
    getSalesOfficeView(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/SalesOfficeView', OL, this.createAuthHeader());
    }
    getSalesOfficeEdit(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/SalesOfficeEdit', OL, this.createAuthHeader());
    }
    //--sales OFFICE end ---//
    //---ORGANISATION---//
    saveOrg(OD) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OrgInsert/', OD);
    }
    getRegionBindList(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/RegionBindList', OL, this.createAuthHeader());
    }
    getSalesOfficeByOfficeLoc(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/SalesOfficeByOfficeLoc', OL, this.createAuthHeader());
    }
    getOrgList(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OrgView', OL, this.createAuthHeader());
    }
    getOrgEdit(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OrgEdit', OL, this.createAuthHeader());
    }
    getOrgDtlsEdit(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OrgDetailsEdit', OL, this.createAuthHeader());
    }
    getSalesLocBind(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/SalesLocBind', OL, this.createAuthHeader());
    }
    getOfficeLocBySalesOffice(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OfficeLocBySalesOffice', OL, this.createAuthHeader());
    }
    OrgOfficeDtlsDelete(OD) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OrgOfficeDtlsDelete/', OD);
    }
    getDivisionTypes(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/DivisionsBind', OL, this.createAuthHeader());
    }
    OrgExistingDivisonTypes(OL) {
        return this.http.post(this.globals.APIURL + '/OrgStructure/OrgExistingDivisionTypes', OL, this.createAuthHeader());
    }
};
OrgService.ctorParameters = () => [
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient },
    { type: _globals__WEBPACK_IMPORTED_MODULE_0__.Globals }
];
OrgService = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Injectable)({
        providedIn: 'root'
    })
], OrgService);



/***/ }),

/***/ 42826:
/*!*******************************************!*\
  !*** ./src/app/services/party.service.ts ***!
  \*******************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PartyService": function() { return /* binding */ PartyService; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ 53882);
/* harmony import */ var _globals__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../globals */ 37503);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let PartyService = class PartyService {
    constructor(http, globals) {
        this.http = http;
        this.globals = globals;
        this.authToken = "";
    }
    loadToken() {
        const token = localStorage.getItem('Token');
        this.authToken = token;
    }
    createAuthHeader() {
        this.loadToken();
        const headers = new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders().set('Authorization', `Bearer ${this.authToken}`);
        return { headers };
    }
    getLocationBind() {
        return this.http.get(this.globals.APIURL + '/PartyApi/BindGeoLocations');
    }
    getBusinessTypes() {
        return this.http.get(this.globals.APIURL + '/PartyApi/BusinessTypes');
    }
    getCitiesBind() {
        return this.http.get(this.globals.APIURL + '/PartyApi/CitiesBind');
    }
    getStateBind() {
        return this.http.get(this.globals.APIURL + '/PartyApi/StatesBind');
    }
    partySave(OD) {
        return this.http.post(this.globals.APIURL + '/PartyApi/Customer/', OD);
    }
    getPartyList(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CustomerView', OL, this.createAuthHeader());
    }
    getPartyEdit(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CustomerViewParticular', OL, this.createAuthHeader());
    }
    getPartyBranchDtlsEdit(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CustomerBranchView', OL, this.createAuthHeader());
    }
    getPartyExistingBusTypes(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/BindBusinessTypes', OL, this.createAuthHeader());
    }
    PartyExistingDivisonTypes(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/PartyExistingDivisionTypes', OL, this.createAuthHeader());
    }
    getPartyTypeAttchments() {
        return this.http.get(this.globals.APIURL + '/PartyApi/AttachmentValues');
    }
    getPartyBranchList(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/BranchDropDown', OL, this.createAuthHeader());
    }
    getPartyGSTList(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/GSTCategory', OL, this.createAuthHeader());
    }
    getCurrencyBind() {
        return this.http.get(this.globals.APIURL + '/PartyApi/CurrencyValues');
    }
    partyAccSave(OD) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CustomerAccSave/', OD);
    }
    getPartyAccEdit(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CustomerAccLinkView', OL, this.createAuthHeader());
    }
    getUserDetails(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/UserDetails', OL, this.createAuthHeader());
    }
    partyCrSave(OD) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CustomerCrSave/', OD);
    }
    getPartyCrEdit(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CustomerCrView', OL, this.createAuthHeader());
    }
    getAlertType(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/AlertTypes', OL, this.createAuthHeader());
    }
    partyEmailAlertSave(OD) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CustomerEmailAlertSave/', OD);
    }
    getPartyEmailDtlsEdit(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CusEmailAlertUpdate', OL, this.createAuthHeader());
    }
    partyAttachSave(OD) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CustomerAttachments/', OD);
    }
    getPartyAttachDtlsEdit(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CustomerAttachDetails', OL, this.createAuthHeader());
    }
    ///-----vendor--//
    getVendorList(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/VendorView', OL, this.createAuthHeader());
    }
    VendorSave(OD) {
        return this.http.post(this.globals.APIURL + '/PartyApi/VendorInsert/', OD);
    }
    VendorAccSave(OD) {
        return this.http.post(this.globals.APIURL + '/PartyApi/VendorAccSave/', OD);
    }
    getVendorAccEdit(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/VendorAccLinkView', OL, this.createAuthHeader());
    }
    getBranchByPOS(OL) {
        return this.http.post(this.globals.APIURL + '/PartyApi/BranchByPOS', OL, this.createAuthHeader());
    }
    CusVendorBranchDelete(OD) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CusVendorBranchDelete/', OD);
    }
    CusVendorAccLinkDelete(OD) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CusVendorAccLinkDelete/', OD);
    }
    CusVendorCrLinkDelete(OD) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CusVendorCrLinkDelete/', OD);
    }
    CusVendorAlertLinkDelete(OD) {
        return this.http.post(this.globals.APIURL + '/PartyApi/CusVendorAlertLinkDelete/', OD);
    }
};
PartyService.ctorParameters = () => [
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient },
    { type: _globals__WEBPACK_IMPORTED_MODULE_0__.Globals }
];
PartyService = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Injectable)({
        providedIn: 'root'
    })
], PartyService);



/***/ }),

/***/ 671:
/*!******************************************************!*\
  !*** ./src/app/services/storage-location.service.ts ***!
  \******************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "StorageLocationService": function() { return /* binding */ StorageLocationService; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ 53882);
/* harmony import */ var _globals__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../globals */ 37503);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let StorageLocationService = class StorageLocationService {
    constructor(http, globals) {
        this.http = http;
        this.globals = globals;
        this.authToken = "";
    }
    loadToken() {
        const token = localStorage.getItem('Token');
        this.authToken = token;
    }
    createAuthHeader() {
        this.loadToken();
        const headers = new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders().set('Authorization', `Bearer ${this.authToken}`);
        return { headers };
    }
    getPortMasterBind(OL) {
        return this.http.post(this.globals.APIURL + '/StorageLocation/PortCodeMasterBind', OL);
    }
    getSaveStoragealocation(OL) {
        return this.http.post(this.globals.APIURL + '/StorageLocation/SaveStoragealocation', OL);
    }
    getStorageLocationList(OL) {
        return this.http.post(this.globals.APIURL + '/StorageLocation/StorageLocationList', OL);
    }
    getStorageLocationEdit(OL) {
        return this.http.post(this.globals.APIURL + '/StorageLocation/StorageLocationEdit', OL);
    }
    getDepotMasterBind(OL) {
        return this.http.post(this.globals.APIURL + '/CommonAccessApi/DepotMaster', OL);
    }
};
StorageLocationService.ctorParameters = () => [
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient },
    { type: _globals__WEBPACK_IMPORTED_MODULE_0__.Globals }
];
StorageLocationService = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Injectable)({
        providedIn: 'root'
    })
], StorageLocationService);



/***/ }),

/***/ 31554:
/*!*************************************************!*\
  !*** ./src/app/services/systemadmin.service.ts ***!
  \*************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "SystemadminService": function() { return /* binding */ SystemadminService; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ 53882);
/* harmony import */ var _globals__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../globals */ 37503);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let SystemadminService = class SystemadminService {
    constructor(http, globals) {
        this.http = http;
        this.globals = globals;
        this.authToken = "";
    }
    loadToken() {
        const token = localStorage.getItem('Token');
        this.authToken = token;
    }
    createAuthHeader() {
        this.loadToken();
        const headers = new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpHeaders().set('Authorization', `Bearer ${this.authToken}`);
        return { headers };
    }
    GetCountries(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetCountries', OL, this.createAuthHeader());
    }
    GetState(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetState', OL, this.createAuthHeader());
    }
    GetStates(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetStates', OL, this.createAuthHeader());
    }
    GetCity(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetCity', OL, this.createAuthHeader());
    }
    GetCities(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetCities', OL, this.createAuthHeader());
    }
    GetPort(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetPort', OL, this.createAuthHeader());
    }
    GetTerminal(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetTerminal', OL, this.createAuthHeader());
    }
    GetShipmentLocation(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetShipmentLocation', OL, this.createAuthHeader());
    }
    GetShipmentLocations(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetShipmentLocations', OL, this.createAuthHeader());
    }
    GetCommodities(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetCommodities', OL, this.createAuthHeader());
    }
    GetPackageTypes(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetPackageTypes', OL, this.createAuthHeader());
    }
    GetContainerTypes(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetContainerTypes', OL, this.createAuthHeader());
    }
    GetHazClasses(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetHazClasses', OL, this.createAuthHeader());
    }
    GetCompanyDetails(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetCompanyDetails', OL, this.createAuthHeader());
    }
    saveCompany(OD) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/SaveCompany/', OD);
    }
    GetCompanyView(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetCompanyView', OL, this.createAuthHeader());
    }
    GetCompanyEdit(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetCompanyEdit', OL, this.createAuthHeader());
    }
    SaveConfig(OD) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/SaveConfig/', OD);
    }
    GetConfigEdit(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/GetConfigEdit', OL, this.createAuthHeader());
    }
    SendTestConnection(OL) {
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/SendTestEmail', OL, this.createAuthHeader());
    }
    AttachUpload(file) {
        const formData = new FormData();
        formData.append("file", file, file.name);
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/ImageUpload/', formData);
    }
};
SystemadminService.ctorParameters = () => [
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__.HttpClient },
    { type: _globals__WEBPACK_IMPORTED_MODULE_0__.Globals }
];
SystemadminService = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Injectable)({
        providedIn: 'root'
    })
], SystemadminService);



/***/ }),

/***/ 74806:
/*!**************************************************!*\
  !*** ./src/app/side-menu/side-menu.component.ts ***!
  \**************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "SideMenuComponent": function() { return /* binding */ SideMenuComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_side_menu_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./side-menu.component.html */ 43075);
/* harmony import */ var _side_menu_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./side-menu.component.css */ 25287);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let SideMenuComponent = class SideMenuComponent {
    constructor() { }
    ngOnInit() {
    }
};
SideMenuComponent.ctorParameters = () => [];
SideMenuComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Component)({
        selector: 'app-side-menu',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_side_menu_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_side_menu_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], SideMenuComponent);



/***/ }),

/***/ 10226:
/*!**********************************************!*\
  !*** ./src/app/sidenav/sidenav.component.ts ***!
  \**********************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "SidenavComponent": function() { return /* binding */ SidenavComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_sidenav_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./sidenav.component.html */ 12059);
/* harmony import */ var _sidenav_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./sidenav.component.css */ 40598);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let SidenavComponent = class SidenavComponent {
    constructor() {
        this.panelOpenState = false;
    }
    ngOnInit() {
    }
};
SidenavComponent.ctorParameters = () => [];
SidenavComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Component)({
        selector: 'app-sidenav',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_sidenav_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_sidenav_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], SidenavComponent);



/***/ }),

/***/ 64283:
/*!**********************************************!*\
  !*** ./src/app/spinner/spinner.component.ts ***!
  \**********************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "SpinnerComponent": function() { return /* binding */ SpinnerComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_spinner_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./spinner.component.html */ 79589);
/* harmony import */ var _spinner_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./spinner.component.css */ 90275);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _spinner_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./spinner.service */ 42429);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




let SpinnerComponent = class SpinnerComponent {
    constructor(spinnerService, cdRef) {
        this.spinnerService = spinnerService;
        this.cdRef = cdRef;
        this.showSpinner = false;
    }
    ngOnInit() {
        this.init();
    }
    init() {
        this.spinnerService.getSpinnerObserver().subscribe((status) => {
            this.showSpinner = (status === 'start');
            this.cdRef.detectChanges();
        });
    }
};
SpinnerComponent.ctorParameters = () => [
    { type: _spinner_service__WEBPACK_IMPORTED_MODULE_2__.SpinnerService },
    { type: _angular_core__WEBPACK_IMPORTED_MODULE_3__.ChangeDetectorRef }
];
SpinnerComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_3__.Component)({
        selector: 'app-spinner',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_spinner_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_spinner_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], SpinnerComponent);



/***/ }),

/***/ 42429:
/*!********************************************!*\
  !*** ./src/app/spinner/spinner.service.ts ***!
  \********************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "SpinnerService": function() { return /* binding */ SpinnerService; }
/* harmony export */ });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! rxjs */ 76491);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


let SpinnerService = class SpinnerService {
    constructor() {
        this.count = 0;
        this.spinner$ = new rxjs__WEBPACK_IMPORTED_MODULE_0__.BehaviorSubject('');
    }
    getSpinnerObserver() {
        return this.spinner$.asObservable();
    }
    requestStarted() {
        if (++this.count === 1) {
            this.spinner$.next('start');
        }
    }
    requestEnded() {
        if (this.count === 0 || --this.count === 0) {
            this.spinner$.next('stop');
        }
    }
    resetSpinner() {
        this.count = 0;
        this.spinner$.next('stop');
    }
};
SpinnerService.ctorParameters = () => [];
SpinnerService = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_1__.Injectable)({
        providedIn: 'root'
    })
], SpinnerService);



/***/ }),

/***/ 66101:
/*!********************************************************!*\
  !*** ./src/app/views/dashboard/dashboard.component.ts ***!
  \********************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "DashboardComponent": function() { return /* binding */ DashboardComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_dashboard_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./dashboard.component.html */ 22399);
/* harmony import */ var _dashboard_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./dashboard.component.css */ 49761);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let DashboardComponent = class DashboardComponent {
    constructor() { }
    ngOnInit() {
    }
};
DashboardComponent.ctorParameters = () => [];
DashboardComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Component)({
        selector: 'app-dashboard',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_dashboard_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_dashboard_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], DashboardComponent);



/***/ }),

/***/ 46535:
/*!**************************************************************************************!*\
  !*** ./src/app/views/instanceprofile/clientmanagement/clientmanagement.component.ts ***!
  \**************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ClientmanagementComponent": function() { return /* binding */ ClientmanagementComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_clientmanagement_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./clientmanagement.component.html */ 96570);
/* harmony import */ var _clientmanagement_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./clientmanagement.component.css */ 6288);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _services_encr_decr_service_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../services/encr-decr-service.service */ 33056);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






let ClientmanagementComponent = class ClientmanagementComponent {
    constructor(router, route, ES, fb) {
        this.router = router;
        this.route = route;
        this.ES = ES;
        this.fb = fb;
        this.CompanyID = 0;
    }
    ngOnInit() {
        this.createForm();
        var queryString = new Array();
        this.route.queryParams.subscribe(params => {
            var Parameter = this.ES.get(localStorage.getItem("EncKey"), params['encrypted']);
            var KeyPara = Parameter.split(',');
            for (var i = 0; i < KeyPara.length; i++) {
                var key = KeyPara[i].split(':')[0];
                var value = KeyPara[i].split(':')[1];
                queryString[key] = value;
            }
            if (queryString["ID"] != null) {
                this.CompanyID = queryString["ID"];
            }
            this.createForm();
        });
    }
    createForm() {
        this.ClientForm = this.fb.group({
            ID: 0,
        });
    }
    btntabclick(tab) {
        var values = "ID: " + this.CompanyID;
        //var values = "ID: 8";
        var encrypted = this.ES.set(localStorage.getItem("EncKey"), values);
        if (tab == 1) {
            this.router.navigate(['/views/masters/instanceprofile/companydetails/companydetails'], { queryParams: { encrypted } });
        }
        else if (tab == 2) {
            this.router.navigate(['/views/masters/instanceprofile/clientmanagement/clientmanagement'], { queryParams: { encrypted } });
        }
        else if (tab == 3) {
            this.router.navigate(['/views/masters/instanceprofile/configuration/configuration'], { queryParams: { encrypted } });
        }
    }
};
ClientmanagementComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_3__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_3__.ActivatedRoute },
    { type: _services_encr_decr_service_service__WEBPACK_IMPORTED_MODULE_2__.EncrDecrServiceService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder }
];
ClientmanagementComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_5__.Component)({
        selector: 'app-clientmanagement',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_clientmanagement_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_clientmanagement_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], ClientmanagementComponent);



/***/ }),

/***/ 45561:
/*!**********************************************************************************!*\
  !*** ./src/app/views/instanceprofile/companydetails/companydetails.component.ts ***!
  \**********************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CompanydetailsComponent": function() { return /* binding */ CompanydetailsComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_companydetails_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./companydetails.component.html */ 66895);
/* harmony import */ var _companydetails_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./companydetails.component.css */ 21903);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../services/systemadmin.service */ 31554);
/* harmony import */ var _services_encr_decr_service_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../services/encr-decr-service.service */ 33056);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};









let CompanydetailsComponent = class CompanydetailsComponent {
    constructor(router, route, ES, service, sa, fb) {
        this.router = router;
        this.route = route;
        this.ES = ES;
        this.service = service;
        this.sa = sa;
        this.fb = fb;
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_6__.FormControl('');
        this.CompanyID = 0;
        this.route.queryParams.subscribe(params => {
            this.InstanceForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.onInitalBinding();
        $('#ddlCountry').on('select2:select', (e, args) => {
            this.CountryChange($("#ddlCountry").val());
        });
        var queryString = new Array();
        this.route.queryParams.subscribe(params => {
            var Parameter = this.ES.get(localStorage.getItem("EncKey"), params['encrypted']);
            var KeyPara = Parameter.split(',');
            for (var i = 0; i < KeyPara.length; i++) {
                var key = KeyPara[i].split(':')[0];
                var value = KeyPara[i].split(':')[1];
                queryString[key] = value;
            }
            if (queryString["ID"] != null) {
                this.InstanceForm = this.fb.group({
                    ID: queryString["ID"].toString(),
                });
                this.CompanyID = queryString["ID"].toString();
                this.ExistingYardBind();
                this.createForm();
            }
        });
    }
    CountryChange(countryval) {
        this.InstanceForm.value.CountryID = countryval;
        this.sa.GetCities(this.InstanceForm.value).subscribe(data => {
            this.dscityItem = data;
        });
    }
    onInitalBinding() {
        this.sa.GetCountries(this.InstanceForm.value).subscribe(data => {
            this.dscountryItem = data;
        });
    }
    ExistingYardBind() {
        this.InstanceForm.value.ID = this.CompanyID;
        this.sa.GetCompanyEdit(this.InstanceForm.value).pipe().subscribe(data => {
            this.InstanceForm.patchValue(data[0]);
            this.CountryChange(data[0].CountryID);
            $('#ddlCity').select2().val(data[0].CityID);
            $('#ddlCountry').select2().val(data[0].CountryID);
        });
    }
    createForm() {
        this.InstanceForm = this.fb.group({
            ID: 0,
            CompanyName: '',
            CompanyCode: '',
            Address: '',
            CountryID: 0,
            CityID: 0,
            ContactName: '',
            POBox: '',
            ZipCode: '',
            Designation: '',
            TelePhone1: '',
            TelePhone2: '',
            ContactEmailID: '',
            EmailID: '',
            URL: '',
            MobileNo: '',
            FileName: '',
        });
    }
    onSubmit() {
        var validation = "";
        if (this.InstanceForm.value.CompanyName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Company Name</span></br>";
        }
        if (this.InstanceForm.value.CompanyCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Company Short Name</span></br>";
        }
        if (this.InstanceForm.value.Address == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Address</span></br>";
        }
        if (this.InstanceForm.value.ContactName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter ContactName</span></br>";
        }
        if (this.InstanceForm.value.ZipCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter ZipCode</span></br>";
        }
        if (this.InstanceForm.value.Designation == "") {
            validation += "<span style='color:red;'>*</span> <span>Please EnterDesignation</span></br>";
        }
        if (this.InstanceForm.value.ContactEmailID == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Contact EmailID</span></br>";
        }
        if (this.InstanceForm.value.TelePhone1 == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter TelePhone1</span></br>";
        }
        if (this.InstanceForm.value.MobileNo == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter MobileNo</span></br>";
        }
        if (this.InstanceForm.value.EmailID == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Contact EmailID</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(validation);
            return false;
        }
        this.InstanceForm.value.CityID = $('#ddlCity').val();
        this.InstanceForm.value.CountryID = $('#ddlCountry').val();
        this.sa.saveCompany(this.InstanceForm.value).subscribe(Data => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(Data[0].AlertMessage);
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(error.message);
        });
    }
    btntabclick(tab) {
        var values = "ID: " + this.InstanceForm.value.ID;
        //var values = "ID: 8";
        var encrypted = this.ES.set(localStorage.getItem("EncKey"), values);
        if (tab == 1) {
            this.router.navigate(['/views/masters/instanceprofile/companydetails/companydetails'], { queryParams: { encrypted } });
        }
        else if (tab == 2) {
            this.router.navigate(['/views/masters/instanceprofile/clientmanagement/clientmanagement'], { queryParams: { encrypted } });
        }
        else if (tab == 3) {
            this.router.navigate(['/views/masters/instanceprofile/configuration/configuration'], { queryParams: { encrypted } });
        }
    }
};
CompanydetailsComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_7__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_7__.ActivatedRoute },
    { type: _services_encr_decr_service_service__WEBPACK_IMPORTED_MODULE_5__.EncrDecrServiceService },
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_4__.SystemadminService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_6__.FormBuilder }
];
CompanydetailsComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_8__.Component)({
        selector: 'app-companydetails',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_companydetails_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_companydetails_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], CompanydetailsComponent);



/***/ }),

/***/ 97928:
/*!********************************************************************************!*\
  !*** ./src/app/views/instanceprofile/configuration/configuration.component.ts ***!
  \********************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ConfigurationComponent": function() { return /* binding */ ConfigurationComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_configuration_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./configuration.component.html */ 55435);
/* harmony import */ var _configuration_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./configuration.component.css */ 88679);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _services_encr_decr_service_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../services/encr-decr-service.service */ 33056);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../services/systemadmin.service */ 31554);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};








let ConfigurationComponent = class ConfigurationComponent {
    constructor(router, route, ES, sa, fb) {
        this.router = router;
        this.route = route;
        this.ES = ES;
        this.sa = sa;
        this.fb = fb;
        this.CompanyIDv = 0;
    }
    ngOnInit() {
        this.createForm();
        var queryString = new Array();
        this.route.queryParams.subscribe(params => {
            var Parameter = this.ES.get(localStorage.getItem("EncKey"), params['encrypted']);
            var KeyPara = Parameter.split(',');
            for (var i = 0; i < KeyPara.length; i++) {
                var key = KeyPara[i].split(':')[0];
                var value = KeyPara[i].split(':')[1];
                queryString[key] = value;
            }
            if (queryString["ID"] != null) {
                this.CompanyIDv = queryString["ID"];
            }
            this.ExistingConfigBind();
            this.createForm();
        });
    }
    createForm() {
        this.ConfigForm = this.fb.group({
            ID: 0,
            IsSMTPS: 0,
            IsSSLTLS: 0,
            HostName: '',
            IPPort: 0,
            Password: '',
            SenderID: '',
            MBSize: '',
            MaxNoAttachs: '',
            MaxSizeAllAttachs: ''
        });
    }
    ExistingConfigBind() {
        this.ConfigForm.value.CompanyID = this.CompanyIDv;
        this.sa.GetConfigEdit(this.ConfigForm.value).pipe().subscribe(data => {
            this.ConfigForm.patchValue(data[0]);
        });
    }
    onSubmitConfig() {
        var validation = "";
        if (this.ConfigForm.value.HostName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Host Name</span></br>";
        }
        if (this.ConfigForm.value.IPPort == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Port</span></br>";
        }
        if (this.ConfigForm.value.Password == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Password</span></br>";
        }
        if (this.ConfigForm.value.SenderID == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter SenderID</span></br>";
        }
        if (this.ConfigForm.value.MBSize == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Max Size Per Attachment</span></br>";
        }
        if (this.ConfigForm.value.MaxNoAttachs == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Max Number of Attachments</span></br>";
        }
        if (this.ConfigForm.value.MaxSizeAllAttachs == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Max Size of All Attachments</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(validation);
            return false;
        }
        this.ConfigForm.value.CompanyID = this.CompanyIDv;
        this.sa.SaveConfig(this.ConfigForm.value).subscribe(Data => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(Data[0].AlertMessage);
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(error.message);
        });
    }
    OnSubmitTest() {
        this.sa.SendTestConnection(this.ConfigForm.value).subscribe(Data => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire("Email Sent Successfully");
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(error.message);
        });
    }
    btntabclick(tab) {
        var values = "ID: " + this.ConfigForm.value.ID;
        //var values = "ID: 8";
        var encrypted = this.ES.set(localStorage.getItem("EncKey"), values);
        if (tab == 1) {
            this.router.navigate(['/views/masters/instanceprofile/companydetails/companydetails'], { queryParams: { encrypted } });
        }
        else if (tab == 2) {
            this.router.navigate(['/views/masters/instanceprofile/clientmanagement/clientmanagement'], { queryParams: { encrypted } });
        }
        else if (tab == 3) {
            this.router.navigate(['/views/masters/instanceprofile/configuration/configuration'], { queryParams: { encrypted } });
        }
    }
};
ConfigurationComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.ActivatedRoute },
    { type: _services_encr_decr_service_service__WEBPACK_IMPORTED_MODULE_2__.EncrDecrServiceService },
    { type: _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_4__.SystemadminService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_6__.FormBuilder }
];
ConfigurationComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_7__.Component)({
        selector: 'app-configuration',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_configuration_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_configuration_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], ConfigurationComponent);



/***/ }),

/***/ 73202:
/*!********************************************************************!*\
  !*** ./src/app/views/instanceprofile/instanceprofile.component.ts ***!
  \********************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "InstanceprofileComponent": function() { return /* binding */ InstanceprofileComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_instanceprofile_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./instanceprofile.component.html */ 65085);
/* harmony import */ var _instanceprofile_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./instanceprofile.component.css */ 18811);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var _pagination_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../pagination.service */ 35217);
/* harmony import */ var _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../services/systemadmin.service */ 31554);
/* harmony import */ var _services_encr_decr_service_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../services/encr-decr-service.service */ 33056);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};









let InstanceprofileComponent = class InstanceprofileComponent {
    constructor(router, route, ES, service, fb, ps, sa) {
        this.router = router;
        this.route = route;
        this.ES = ES;
        this.service = service;
        this.fb = fb;
        this.ps = ps;
        this.sa = sa;
        // pager object
        this.pager = {};
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_6__.FormControl('');
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.refreshDepList();
        this.clearSearch();
    }
    refreshDepList() {
        this.sa.GetCompanyView(this.searchForm.value).subscribe(data => {
            this.allItems = data;
            this.setPage(1);
        });
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            CompanyName: '',
            CompanyCode: '',
        });
    }
    onSubmit() {
        this.refreshDepList();
    }
    clearSearch() {
        this.createForm();
        this.refreshDepList();
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
    OnClickEdit(IDv) {
        var values = "ID: " + IDv;
        var encrypted = this.ES.set(localStorage.getItem("EncKey"), values);
        this.router.navigate(['/views/masters/instanceprofile/companydetails/companydetails/'], { queryParams: { encrypted } });
    }
};
InstanceprofileComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_7__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_7__.ActivatedRoute },
    { type: _services_encr_decr_service_service__WEBPACK_IMPORTED_MODULE_5__.EncrDecrServiceService },
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_6__.FormBuilder },
    { type: _pagination_service__WEBPACK_IMPORTED_MODULE_3__.PaginationService },
    { type: _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_4__.SystemadminService }
];
InstanceprofileComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_8__.Component)({
        selector: 'app-instanceprofile',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_instanceprofile_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_instanceprofile_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], InstanceprofileComponent);



/***/ }),

/***/ 46326:
/*!***********************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/cargopackage/cargopackage.component.ts ***!
  \***********************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CargopackageComponent": function() { return /* binding */ CargopackageComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_cargopackage_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./cargopackage.component.html */ 26664);
/* harmony import */ var _cargopackage_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./cargopackage.component.css */ 25819);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../services/masters.service */ 52852);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let CargopackageComponent = class CargopackageComponent {
    constructor(router, route, service, fb) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.fb = fb;
        this.statusvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        this.id = "0";
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControl('');
        this.route.queryParams.subscribe(params => {
            this.cargoForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
    }
    createForm() {
        if (this.cargoForm.value.ID != null) {
            this.service.getCargoedit(this.cargoForm.value).pipe().subscribe(data => {
                this.cargoForm.patchValue(data[0]);
                $('#ddlStatus').select2().val(data[0].Status);
            });
            this.cargoForm = this.fb.group({
                ID: 0,
                PkgCode: '',
                PkgDescription: '',
                Status: 0
            });
            this.ForsControDisable();
        }
        else {
            this.cargoForm = this.fb.group({
                ID: 0,
                PkgCode: '',
                PkgDescription: '',
                Status: 1
            });
            $('#ddlStatus').select2().val(0);
        }
    }
    ForsControDisable() {
        $("#txtPkgCode").attr("disabled", "disabled");
        $("#txtPkgDesc").attr("disabled", "disabled");
    }
    onSubmit() {
        var validation = "";
        if (this.cargoForm.value.PkgCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Package Code</span></br>";
        }
        if (this.cargoForm.value.PkgDescription == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Package Description</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(validation);
            return false;
        }
        else {
            this.cargoForm.value.Status = $('#ddlStatus').val();
            this.service.saveCargo(this.cargoForm.value).subscribe(Data => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(Data[0].AlertMessage);
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/cargopackage/cargopackageview']);
                    }, 1500); //5s
                }
            }, (error) => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(error.message);
            });
        }
    }
    onBack() {
        if (this.cargoForm.value.ID == 0) {
            var validation = "";
            if (this.cargoForm.value.PkgCode != "" || this.cargoForm.value.PkgDescription != "") {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>";
            }
            if (validation != "") {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                    else {
                        this.router.navigate(['/views/masters/commonmaster/cargopackage/cargopackageview']);
                    }
                });
                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/cargopackage/cargopackageview']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/cargopackage/cargopackageview']);
        }
    }
};
CargopackageComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.ActivatedRoute },
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder }
];
CargopackageComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-cargopackage',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_cargopackage_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_cargopackage_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], CargopackageComponent);



/***/ }),

/***/ 42545:
/*!********************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/cargopackage/cargopackageview/cargopackageview.component.ts ***!
  \********************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CargopackageviewComponent": function() { return /* binding */ CargopackageviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_cargopackageview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./cargopackageview.component.html */ 33172);
/* harmony import */ var _cargopackageview_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./cargopackageview.component.css */ 34500);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _pagination_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../../pagination.service */ 35217);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../services/masters.service */ 52852);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let CargopackageviewComponent = class CargopackageviewComponent {
    constructor(ms, fb, ps, titleService) {
        this.ms = ms;
        this.fb = fb;
        this.ps = ps;
        this.titleService = titleService;
        this.title = 'Cargo Package Master';
        this.statusvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        // pager object
        this.pager = {};
        this.isDesc = false;
        this.column = '';
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.refreshDepList();
        this.clearSearch();
    }
    refreshDepList() {
        this.ms.getCargoList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;
            // initialize to page 1
            this.setPage(1);
        });
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            PkgCode: '',
            PkgDescription: '',
            Status: 0
        });
    }
    onSubmit() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.ms.getCargoList(this.searchForm.value).subscribe(Cargo => {
            this.allItems = Cargo;
            this.setPage(1);
        });
        $('#ddlStatusv').val(0).trigger("change");
    }
    clearSearch() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.createForm();
        $('#ddlStatusv').val(0).trigger("change");
        this.refreshDepList();
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
    sort(property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        let direction = this.isDesc ? 1 : -1;
        this.pagedItems.sort(function (a, b) {
            if (a[property] < b[property]) {
                return -1 * direction;
            }
            else if (a[property] > b[property]) {
                return 1 * direction;
            }
            else {
                return 0;
            }
        });
    }
    ;
};
CargopackageviewComponent.ctorParameters = () => [
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder },
    { type: _pagination_service__WEBPACK_IMPORTED_MODULE_2__.PaginationService },
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__.Title }
];
CargopackageviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-cargopackageview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_cargopackageview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_cargopackageview_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], CargopackageviewComponent);



/***/ }),

/***/ 953:
/*!*******************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/city/city.component.ts ***!
  \*******************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CityComponent": function() { return /* binding */ CityComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_city_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./city.component.html */ 86078);
/* harmony import */ var _city_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./city.component.css */ 69514);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../services/systemadmin.service */ 31554);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};








let CityComponent = class CityComponent {
    constructor(router, route, SA, service, fb) {
        this.router = router;
        this.route = route;
        this.SA = SA;
        this.service = service;
        this.fb = fb;
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormControl('');
        this.route.queryParams.subscribe(params => {
            this.cityForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.onInitalBinding();
        $('#ddlCountryv').on('select2:select', (e, args) => {
            this.CountryChanged($("#ddlCountryv").val());
        });
    }
    onInitalBinding() {
        this.OnBindDropdownCountry();
    }
    CountryChanged(countryval) {
        this.cityForm.value.CountryID = countryval;
        this.SA.GetStates(this.cityForm.value).subscribe(data => {
            this.dsStateItem = data;
        });
    }
    OnBindDropdownCountry() {
        this.service.getCountryBind().subscribe(data => {
            this.dscountryItem = data;
        });
    }
    createForm() {
        if (this.cityForm.value.ID != null) {
            this.service.getCityEdit(this.cityForm.value).pipe().subscribe(data => {
                this.cityForm.patchValue(data[0]);
                $('#ddlStatus').select2().val(data[0].Status);
                $('#ddlCountryv').select2().val(data[0].CountryID);
                $('#ddlStatev').select2().val(data[0].StateID);
                this.CountryChanged(data[0].CountryID);
            });
            this.cityForm = this.fb.group({
                ID: 0,
                CityCode: '',
                CityName: '',
                StateName: '',
                CountryName: '',
                CountryCode: '',
                CountryID: 0,
                Status: 0,
                StateID: 0
            });
            this.ForsControDisable();
        }
        else {
            this.cityForm = this.fb.group({
                ID: 0,
                CityCode: '',
                CityName: '',
                StateName: '',
                CountryName: '',
                CountryCode: '',
                CountryID: 0,
                Status: 1,
                StateID: 0
            });
        }
    }
    ForsControDisable() {
        $('#ddlCountryv').select2("enable", false);
        $('#ddlStatev').select2("enable", false);
        $("#txtCityCode").attr("disabled", "disabled");
        $("#txtCityName").attr("disabled", "disabled");
    }
    onSubmit() {
        var validation = "";
        if (this.cityForm.value.CityCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter City Code</span></br>";
        }
        if (this.cityForm.value.CityName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter City Name</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(validation);
            return false;
        }
        else {
            this.cityForm.value.Status = $('#ddlStatus').val();
            this.cityForm.value.CountryID = $('#ddlCountryv').val();
            if (this.cityForm.value.StateID != "") {
                this.cityForm.value.StateID = $('#ddlStatev').val();
            }
            else {
                this.cityForm.value.StateID = 0;
            }
            this.service.saveCty(this.cityForm.value).subscribe(Data => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(Data[0].AlertMessage);
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/city/cityview']);
                    }, 1500); //5s
                }
            }, (error) => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(error.message);
            });
        }
    }
    onBack() {
        if (this.cityForm.value.ID == 0) {
            var validation = "";
            if (this.cityForm.value.CityCode != "" || this.cityForm.value.CityName != "") {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>";
            }
            if (validation != "") {
                sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                    else {
                        this.router.navigate(['/views/masters/commonmaster/city/cityview']);
                    }
                });
                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/city/cityview']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/city/cityview']);
        }
    }
};
CityComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_6__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_6__.ActivatedRoute },
    { type: _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_4__.SystemadminService },
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormBuilder }
];
CityComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_7__.Component)({
        selector: 'app-city',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_city_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_city_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], CityComponent);



/***/ }),

/***/ 92979:
/*!********************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/city/cityview/cityview.component.ts ***!
  \********************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CityviewComponent": function() { return /* binding */ CityviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_cityview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./cityview.component.html */ 8023);
/* harmony import */ var _cityview_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./cityview.component.css */ 59581);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var src_app_pagination_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/pagination.service */ 35217);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let CityviewComponent = class CityviewComponent {
    constructor(ms, fb, ps, titleService) {
        this.ms = ms;
        this.fb = fb;
        this.ps = ps;
        this.titleService = titleService;
        this.title = 'City Master';
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        // pager object
        this.pager = {};
        this.DepartmentList = [];
        this.ActivateAddEditDepComp = false;
        this.DepartmentIdFilter = "";
        this.DepartmentNameFilter = "";
        this.DepartmentListWithoutFilter = [];
        this.isDesc = false;
        this.column = '';
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.CityList();
        this.clearSearch();
    }
    CityList() {
        this.ms.getCityList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;
            // initialize to page 1
            this.setPage(1);
        });
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            CityName: '',
            CountryCode: '',
            CityCode: '',
            Status: 0
        });
    }
    clearSearch() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.createForm();
        this.CityList();
        $('#ddlStatusv').val(0).trigger("change");
    }
    onSubmit() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.ms.getCityList(this.searchForm.value).subscribe(city => {
            // set items to json response
            this.allItems = city;
            // initialize to page 1
            this.setPage(1);
        });
    }
    highlightRow(dataItem) {
        this.selectedName = dataItem.CityCode;
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
    sort(property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        let direction = this.isDesc ? 1 : -1;
        this.pagedItems.sort(function (a, b) {
            if (a[property] < b[property]) {
                return -1 * direction;
            }
            else if (a[property] > b[property]) {
                return 1 * direction;
            }
            else {
                return 0;
            }
        });
    }
    ;
};
CityviewComponent.ctorParameters = () => [
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder },
    { type: src_app_pagination_service__WEBPACK_IMPORTED_MODULE_3__.PaginationService },
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__.Title }
];
CityviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-cityview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_cityview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_cityview_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], CityviewComponent);



/***/ }),

/***/ 15405:
/*!*****************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/commodity/commodity.component.ts ***!
  \*****************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CommodityComponent": function() { return /* binding */ CommodityComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_commodity_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./commodity.component.html */ 46878);
/* harmony import */ var _commodity_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./commodity.component.css */ 2675);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../services/masters.service */ 52852);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let CommodityComponent = class CommodityComponent {
    constructor(router, route, service, fb) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.fb = fb;
        this.dgflag = [
            { value: '1', viewValue: 'YES' },
            { value: '0', viewValue: 'NO' },
        ];
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        this.id = "0";
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControl('');
        this.route.queryParams.subscribe(params => {
            this.commodityForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.DropdownCommodityTypes();
    }
    DropdownCommodityTypes() {
        this.service.getCommodityTypes(this.commodityForm.value).subscribe(data => {
            this.dsCommodityType = data;
        });
    }
    createForm() {
        if (this.commodityForm.value.ID != null) {
            this.service.getCommodityedit(this.commodityForm.value).pipe().subscribe(data => {
                this.commodityForm.patchValue(data[0]);
                $('#ddlFlag').select2().val(data[0].DangerousFlag);
                $('#ddlCommodityType').select2().val(data[0].CommodityType);
                $('#ddlStatus').select2().val(data[0].Status);
            });
            this.commodityForm = this.fb.group({
                ID: 0,
                Status: 0,
                CommodityUnCode: '',
                CommodityName: '',
                HSCode: '',
                DangerousFlag: '',
                CommodityType: '',
                Remarks: '',
            });
            this.ForsControDisable();
        }
        else {
            this.commodityForm = this.fb.group({
                ID: 0,
                Status: 0,
                CommodityUnCode: '',
                CommodityName: '',
                HSCode: '',
                DangerousFlag: '',
                CommodityType: '',
                Remarks: '',
            });
        }
    }
    ForsControDisable() {
        $('#ddlCommodityType').select2("enable", false);
        $('#ddlFlag').select2("enable", false);
        $("#txtCmdCode").attr("disabled", "disabled");
        $("#txtCmdName").attr("disabled", "disabled");
        $("#txtHsCode").attr("disabled", "disabled");
        $("#txtRemarks").attr("disabled", "disabled");
    }
    onSubmit() {
        var validation = "";
        if ($('#ddlFlag').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select DangerousFlag</span></br>";
        }
        if ($('#ddlCommodityType').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Commodity Type</span></br>";
        }
        if (this.commodityForm.value.CommodityUnCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Commodity Un Code</span></br>";
        }
        if (this.commodityForm.value.CommodityName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Commodity Name</span></br>";
        }
        if (this.commodityForm.value.HSCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter HS Code</span></br>";
        }
        //if (this.commodityForm.value.DangerousFlag == "") {
        //    validation += "<span style='color:red;'>*</span> <span>Please Enter DangerousFlag</span></br>"
        //}
        //if (this.commodityForm.value.CommodityType == "") {
        //    validation += "<span style='color:red;'>*</span> <span>Please Enter Commodity Type</span></br>"
        //}
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(validation);
            return false;
        }
        else {
            this.commodityForm.value.DangerousFlag = $('#ddlFlag').val();
            this.commodityForm.value.CommodityType = $('#ddlCommodityType').val();
            this.commodityForm.value.Status = $('#ddlStatus').val();
            this.service.saveCommodity(this.commodityForm.value).subscribe(Data => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(Data[0].AlertMessage);
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/commodity/commodityview']);
                    }, 1500); //5s
                }
            }, (error) => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(error.message);
            });
        }
    }
    onBack() {
        if (this.commodityForm.value.ID == 0) {
            var validation = "";
            if (this.commodityForm.value.CommodityUnCode != "" || this.commodityForm.value.CommodityName != "" || this.commodityForm.value.HSCode != "" || this.commodityForm.value.DangerousFlag != "" || this.commodityForm.value.CommodityType != "") {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>";
            }
            if (validation != "") {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                    else {
                        this.router.navigate(['/views/masters/commonmaster/commodity/commodityview']);
                    }
                });
                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/commodity/commodityview']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/commodity/commodityview']);
        }
    }
};
CommodityComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.ActivatedRoute },
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder }
];
CommodityComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-commodity',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_commodity_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_commodity_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], CommodityComponent);



/***/ }),

/***/ 8968:
/*!***********************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/commodity/commodityview/commodityview.component.ts ***!
  \***********************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CommodityviewComponent": function() { return /* binding */ CommodityviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_commodityview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./commodityview.component.html */ 88810);
/* harmony import */ var _commodityview_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./commodityview.component.css */ 24985);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _pagination_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../../pagination.service */ 35217);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../services/masters.service */ 52852);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let CommodityviewComponent = class CommodityviewComponent {
    constructor(ms, fb, ps, titleService) {
        this.ms = ms;
        this.fb = fb;
        this.ps = ps;
        this.titleService = titleService;
        this.title = 'Commodity Master';
        this.statusvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        this.dgflag = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        // pager object
        this.pager = {};
        this.isDesc = false;
        this.column = '';
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.refreshDepList();
        this.onInitalBinding();
        this.clearSearch();
    }
    onInitalBinding() {
        this.OnBindDropdownCommodity();
    }
    OnBindDropdownCommodity() {
        this.ms.getCommodityTypes(this.searchForm.value).subscribe(data => {
            this.CommodityItem = data;
        });
    }
    refreshDepList() {
        this.ms.getCommodityList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;
            // initialize to page 1
            this.setPage(1);
        });
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            CommodityUnCode: '',
            CommodityName: '',
            HSCode: '',
            CommodityTypeID: 0,
            DangerousFlag: 0,
            Status: 0,
        });
    }
    clearSearch() {
        this.searchForm.value.CommodityTypeID = $('#ddlCommodityTypev').val();
        this.searchForm.value.DangerousFlag = $('#ddlFlagv').val();
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.createForm();
        this.refreshDepList();
        $('#ddlCommodityTypev').val(0).trigger("change");
        $('#ddlFlagv').val(0).trigger("change");
        $('#ddlStatusv').val(0).trigger("change");
    }
    onSubmit() {
        this.searchForm.value.CommodityTypeID = $('#ddlCommodityTypev').val();
        this.searchForm.value.DangerousFlag = $('#ddlFlagv').val();
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.ms.getCommodityList(this.searchForm.value).subscribe(commodity => {
            // set items to json response
            this.allItems = commodity;
            // initialize to page 1
            this.setPage(1);
        });
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
    sort(property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        let direction = this.isDesc ? 1 : -1;
        this.pagedItems.sort(function (a, b) {
            if (a[property] < b[property]) {
                return -1 * direction;
            }
            else if (a[property] > b[property]) {
                return 1 * direction;
            }
            else {
                return 0;
            }
        });
    }
    ;
};
CommodityviewComponent.ctorParameters = () => [
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder },
    { type: _pagination_service__WEBPACK_IMPORTED_MODULE_2__.PaginationService },
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__.Title }
];
CommodityviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-commodityview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_commodityview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_commodityview_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], CommodityviewComponent);



/***/ }),

/***/ 4449:
/*!**********************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/commonmaster.component.ts ***!
  \**********************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CommonmasterComponent": function() { return /* binding */ CommonmasterComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_commonmaster_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./commonmaster.component.html */ 73032);
/* harmony import */ var _commonmaster_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./commonmaster.component.css */ 69635);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




let CommonmasterComponent = class CommonmasterComponent {
    constructor(titleService) {
        this.titleService = titleService;
        this.title = 'Master Data Management - Common Master';
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
    }
};
CommonmasterComponent.ctorParameters = () => [
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_2__.Title }
];
CommonmasterComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_3__.Component)({
        selector: 'app-commonmaster',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_commonmaster_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_commonmaster_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], CommonmasterComponent);



/***/ }),

/***/ 82777:
/*!*************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/contypemaster/contypemaster.component.ts ***!
  \*************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ContypemasterComponent": function() { return /* binding */ ContypemasterComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_contypemaster_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./contypemaster.component.html */ 81716);
/* harmony import */ var _contypemaster_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./contypemaster.component.css */ 26551);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../services/masters.service */ 52852);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let ContypemasterComponent = class ContypemasterComponent {
    constructor(router, route, service, fb) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.fb = fb;
        this.statusvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        this.statusvalues1 = [
            { value: '1', viewValue: 'Reefer' },
            { value: '2', viewValue: 'General' },
            { value: '2', viewValue: 'special' },
        ];
        this.route.queryParams.subscribe(params => {
            this.contypeForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.DropdownContainerTypes();
        this.DropdownContainerSize();
        this.OnBindDropdownCntrGroup();
    }
    DropdownContainerTypes() {
        this.service.getContainerSize(this.contypeForm.value).subscribe(data => {
            this.dsCntrSizes = data;
        });
    }
    OnBindDropdownCntrGroup() {
        this.service.getContainerGroup(this.contypeForm.value).subscribe(data => {
            this.dsCntrGroup = data;
        });
    }
    DropdownContainerSize() {
        this.service.getContainerTypes(this.contypeForm.value).subscribe(data => {
            this.dsCntrTypes = data;
        });
    }
    createForm() {
        if (this.contypeForm.value.ID != null) {
            this.service.getContTypeedit(this.contypeForm.value).pipe().subscribe(data => {
                this.contypeForm.patchValue(data[0]);
                $('#ddlType').select2().val(data[0].EQTypeID);
                $('#ddlSize').select2().val(data[0].SizeID);
                $('#ddlgroup').select2().val(data[0].groupID);
                $('#ddlStatus').select2().val(data[0].status);
            });
            this.contypeForm = this.fb.group({
                ID: 0,
                EQTypeID: 0,
                SizeID: 0,
                groupID: 0,
                status: 0,
                ISOCode: '',
                TEUS: '',
                GeneralName: '',
                Length: '',
                Width: '',
                Height: '',
                TareWeight: '',
                MaxPayload: '',
                Remarks: '',
                CntrTypeDesc: '',
            });
            this.ForsControDisable();
        }
        else {
            this.contypeForm = this.fb.group({
                ID: 0,
                EQTypeID: 0,
                SizeID: 0,
                groupID: 0,
                status: 0,
                ISOCode: '',
                TEUS: '',
                GeneralName: '',
                Length: '',
                Width: '',
                Height: '',
                TareWeight: '',
                MaxPayload: '',
                Remarks: '',
                CntrTypeDesc: '',
            });
        }
    }
    ForsControDisable() {
        $('#ddlSize').select2("enable", false);
        $('#ddlType').select2("enable", false);
        $('#ddlgroup').select2("enable", false);
        $("#txtCntrTypeDesc").attr("disabled", "disabled");
        $("#ddlISOCode").attr("disabled", "disabled");
        $("#txtHeight").attr("disabled", "disabled");
        $("#txtRemarks").attr("disabled", "disabled");
        $("#txtLength").attr("disabled", "disabled");
        $("#txtWidth").attr("disabled", "disabled");
        $("#txtTEUS").attr("disabled", "disabled");
        $("#txtTareWeight").attr("disabled", "disabled");
        $("#txtMaxPayload").attr("disabled", "disabled");
    }
    onSubmit() {
        var validation = "";
        if ($('#ddlType').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Container Type</span></br>";
        }
        if ($('#ddlSize').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Equipment Size</span></br>";
        }
        if (this.contypeForm.value.ISOCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter ISOCode</span></br>";
        }
        if (this.contypeForm.value.CntrTypeDesc == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Container Type Description</span></br>";
        }
        if (this.contypeForm.value.Width == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Width</span></br>";
        }
        if (this.contypeForm.value.Height == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Height</span></br>";
        }
        if (this.contypeForm.value.TareWeight == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Tare Weight</span></br>";
        }
        if (this.contypeForm.value.MaxPayload == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Max. Payload</span></br>";
        }
        if (this.contypeForm.value.TEUS == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter TEUs</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(validation);
            return false;
        }
        this.contypeForm.value.EQTypeID = $('#ddlType').val();
        this.contypeForm.value.SizeID = $('#ddlSize').val();
        this.contypeForm.value.groupID = $('#ddlgroup').val();
        this.contypeForm.value.status = $('#ddlStatus').val();
        this.contypeForm.value.Size = $("#ddlSize option:selected").text();
        this.contypeForm.value.Type = $("#ddlType option:selected").text();
        this.service.saveContType(this.contypeForm.value).subscribe(Data => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(Data[0].AlertMessage);
            if (Data[0].AlertMegId == 2) {
                setTimeout(() => {
                    this.router.navigate(['/views/masters/commonmaster/contypemaster/contypemasterview']);
                }, 1500); //5s
            }
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(error.message);
        });
    }
    onBack() {
        if (this.contypeForm.value.ID == 0) {
            var validation = "";
            if ($('#ddlType').val() != null || $('#ddlSize').val() != null || this.contypeForm.value.ISOCode != "" || this.contypeForm.value.Length != "" || this.contypeForm.value.Width != "" || this.contypeForm.value.Height != "" || this.contypeForm.value.TareWeight != "" || this.contypeForm.value.MaxPayload != "" || this.contypeForm.value.TEUS != "") {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>";
            }
            if (validation != "") {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                    else {
                        this.router.navigate(['/views/masters/commonmaster/contypemaster/contypemasterview']);
                    }
                });
                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/contypemaster/contypemasterview']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/contypemaster/contypemasterview']);
        }
    }
};
ContypemasterComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_4__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_4__.ActivatedRoute },
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormBuilder }
];
ContypemasterComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-contypemaster',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_contypemaster_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_contypemaster_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], ContypemasterComponent);



/***/ }),

/***/ 69394:
/*!***********************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/contypemaster/contypemasterview/contypemasterview.component.ts ***!
  \***********************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ContypemasterviewComponent": function() { return /* binding */ ContypemasterviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_contypemasterview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./contypemasterview.component.html */ 45465);
/* harmony import */ var _contypemasterview_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./contypemasterview.component.css */ 35108);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _pagination_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../../pagination.service */ 35217);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../services/masters.service */ 52852);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let ContypemasterviewComponent = class ContypemasterviewComponent {
    constructor(ms, fb, ps, titleService) {
        this.ms = ms;
        this.fb = fb;
        this.ps = ps;
        this.titleService = titleService;
        this.title = 'ContainerType Master';
        this.statusvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        // pager object
        this.pager = {};
        this.isDesc = false;
        this.column = '';
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.refreshDepList();
        this.clearSearch();
    }
    refreshDepList() {
        this.ms.getContTypeList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;
            // initialize to page 1
            this.setPage(1);
        });
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            Type: '',
            Size: '',
            ISOCode: '',
            status: 0,
        });
    }
    clearSearch() {
        this.searchForm.value.status = $('#ddlStatusv').val();
        this.createForm();
        $('#ddlStatusv').val(0).trigger("change");
        this.refreshDepList();
    }
    onSubmit() {
        this.searchForm.value.status = $('#ddlStatusv').val();
        this.refreshDepList();
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
    sort(property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        let direction = this.isDesc ? 1 : -1;
        this.pagedItems.sort(function (a, b) {
            if (a[property] < b[property]) {
                return -1 * direction;
            }
            else if (a[property] > b[property]) {
                return 1 * direction;
            }
            else {
                return 0;
            }
        });
    }
    ;
};
ContypemasterviewComponent.ctorParameters = () => [
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder },
    { type: _pagination_service__WEBPACK_IMPORTED_MODULE_2__.PaginationService },
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__.Title }
];
ContypemasterviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-contypemasterview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_contypemasterview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_contypemasterview_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], ContypemasterviewComponent);



/***/ }),

/***/ 58043:
/*!*************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/country/country.component.ts ***!
  \*************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CountryComponent": function() { return /* binding */ CountryComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_country_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./country.component.html */ 75938);
/* harmony import */ var _country_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./country.component.css */ 32814);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_3__);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let CountryComponent = class CountryComponent {
    constructor(router, route, service, fb) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.fb = fb;
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        // options: string[] = ['One', 'Two', 'Three'];
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControl('');
        this.DepartmentList = [];
        this.route.queryParams.subscribe(params => {
            this.countryForm = this.fb.group({
                ID: params['id'],
                //CountryName: '',
                //CountryCode: '',
                //Status: 0
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        this.createForm();
    }
    createForm() {
        if (this.countryForm.value.ID != null) {
            this.service.getCountryEdit(this.countryForm.value).pipe().subscribe(data => {
                this.countryForm.patchValue(data[0]);
                $('#ddlStatus').select2().val(data[0].Status);
            });
            this.countryForm = this.fb.group({
                ID: 0,
                CountryName: '',
                CountryCode: '',
                Status: 0
            });
            this.ForsControDisable();
        }
        else {
            this.countryForm = this.fb.group({
                ID: 0,
                CountryName: '',
                CountryCode: '',
                Status: 1
            });
            $('#ddlStatus').select2().val(0);
        }
    }
    ForsControDisable() {
        $("#txtSymbol").attr("disabled", "disabled");
        $("#txtCountryCode").attr("disabled", "disabled");
        $("#txtCountryName").attr("disabled", "disabled");
    }
    onSubmit() {
        var validation = "";
        if (this.countryForm.value.CountryName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Country Name </span></br>";
        }
        if (this.countryForm.value.CountryCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Country Code</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(validation);
            return false;
        }
        else {
            this.countryForm.value.Status = $('#ddlStatus').val();
            this.service.saveCtry(this.countryForm.value).subscribe(data => {
                //this.countryForm.value.ID = data[0].ID;
                sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(data[0].AlertMessage);
                if (data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/country/countryview1']);
                    }, 1500); //5s
                }
            }, (error) => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(error.message);
            });
        }
    }
    onBack() {
        if (this.countryForm.value.ID == 0) {
            var validation = "";
            if (this.countryForm.value.CountryName != "" || this.countryForm.value.CountryCode != "") {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>";
            }
            if (validation != "") {
                sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                    else {
                        this.router.navigate(['/views/masters/commonmaster/country/countryview1']);
                    }
                });
                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/country/countryview1']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/country/countryview1']);
        }
    }
};
CountryComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.ActivatedRoute },
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder }
];
CountryComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-country',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_country_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_country_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], CountryComponent);



/***/ }),

/***/ 91976:
/*!*******************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/country/countryview1/countryview1.component.ts ***!
  \*******************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "Countryview1Component": function() { return /* binding */ Countryview1Component; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_countryview1_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./countryview1.component.html */ 36754);
/* harmony import */ var _countryview1_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./countryview1.component.css */ 62850);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var src_app_pagination_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/pagination.service */ 35217);
/* harmony import */ var _globals__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../../globals */ 37503);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/common/http */ 53882);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};










let Countryview1Component = class Countryview1Component {
    constructor(http, globals, ms, router, route, fb, ps, titleService) {
        this.http = http;
        this.globals = globals;
        this.ms = ms;
        this.router = router;
        this.route = route;
        this.fb = fb;
        this.ps = ps;
        this.titleService = titleService;
        this.title = 'Country Master';
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        // pager object
        this.pager = {};
        this.DepartmentList = [];
        this.ActivateAddEditDepComp = false;
        this.DepartmentIdFilter = "";
        this.DepartmentNameFilter = "";
        this.DepartmentListWithoutFilter = [];
        //openpdf() {
        //    $('#pdfview').modal('show');
        //}
        this.isDesc = false;
        this.column = '';
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.CountryList();
        this.clearSearch();
    }
    CountryList() {
        this.ms.getCountryList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;
            // initialize to page 1
            this.setPage(1);
        });
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            CountryName: '',
            CountryCode: '',
            Status: 0,
            pdfFilename: ''
        });
    }
    clearSearch() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.createForm();
        this.CountryList();
        $('#ddlStatusv').val(0).trigger("change");
    }
    onSubmit() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.ms.getCountryList(this.searchForm.value).subscribe(country => {
            // set items to json response
            this.allItems = country;
            // initialize to page 1
            this.setPage(1);
        });
    }
    highlightRow(dataItem) {
        this.selectedName = dataItem.CountryCode;
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
    pdflink() {
        this.ms.getPDF(this.searchForm.value).subscribe(data => {
            console.log(data[0].aclFilename);
            window.open("assets/pdfFiles/" + data[0].aclFilename + ".pdf");
        });
        //alert('hi');
        //this.http.get(this.globals.APIURL + '/home/BLPrintPDF/').subscribe(res => {
        //   });
        /*window.open(RouterLink("BLPrintPDF", "BLPrint")');*/
        /*window.open("assets/pdfFiles/test.pdf");*/
    }
    sort(property) {
        this.isDesc = !this.isDesc;
        this.column = property;
        let direction = this.isDesc ? 1 : -1;
        this.pagedItems.sort(function (a, b) {
            if (a[property] < b[property]) {
                return -1 * direction;
            }
            else if (a[property] > b[property]) {
                return 1 * direction;
            }
            else {
                return 0;
            }
        });
    }
    ;
};
Countryview1Component.ctorParameters = () => [
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_5__.HttpClient },
    { type: _globals__WEBPACK_IMPORTED_MODULE_4__.Globals },
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_6__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_6__.ActivatedRoute },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_7__.FormBuilder },
    { type: src_app_pagination_service__WEBPACK_IMPORTED_MODULE_3__.PaginationService },
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_8__.Title }
];
Countryview1Component = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_9__.Component)({
        selector: 'app-countryview1',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_countryview1_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_countryview1_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], Countryview1Component);



/***/ }),

/***/ 49072:
/*!***************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/currency/currency.component.ts ***!
  \***************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CurrencyComponent": function() { return /* binding */ CurrencyComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_currency_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./currency.component.html */ 47814);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../services/masters.service */ 52852);
/* harmony import */ var _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../services/systemadmin.service */ 31554);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let CurrencyComponent = class CurrencyComponent {
    constructor(router, route, service, fb, country) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.fb = fb;
        this.country = country;
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        this.id = "0";
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControl('');
        this.route.queryParams.subscribe(params => {
            this.CurrencyForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.OnBindDropdownCountry();
    }
    OnBindDropdownCountry() {
        this.country.GetCountries(this.CurrencyForm.value).subscribe(data => {
            this.dscountryItem = data;
        });
    }
    createForm() {
        if (this.CurrencyForm.value.ID != null) {
            this.service.Currencyedit(this.CurrencyForm.value).pipe().subscribe(data => {
                this.CurrencyForm.patchValue(data[0]);
                $('#ddlStatus').select2().val(data[0].Status);
                $('#ddlCountry').select2().val(data[0].CountryID);
            });
            this.CurrencyForm = this.fb.group({
                ID: 0,
                CurrencyCode: '',
                CurrencyName: '',
                Symbol: '',
                CountryID: 0,
                Status: 0
            });
            this.ForsControDisable();
        }
        else {
            this.CurrencyForm = this.fb.group({
                ID: 0,
                CurrencyCode: '',
                CurrencyName: '',
                Symbol: '',
                CountryID: 0,
                Status: 1
            });
            $('#ddlStatus').select2().val(0);
        }
    }
    ForsControDisable() {
        $('#ddlCountry').select2("enable", false);
        $("#txtSymbol").attr("disabled", "disabled");
        $("#txtCurrencyCode").attr("disabled", "disabled");
        $("#txtCurrencyName").attr("disabled", "disabled");
    }
    onSubmit() {
        var validation = "";
        if ($('#ddlCountry').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Country</span></br>";
        }
        if (this.CurrencyForm.value.CurrencyCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Currency Code </span></br>";
        }
        if (this.CurrencyForm.value.CurrencyName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Currency Name</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_1___default().fire(validation);
            return false;
        }
        else {
            this.CurrencyForm.value.Status = $('#ddlStatus').val();
            this.CurrencyForm.value.CountryID = $('#ddlCountry').val();
            this.service.saveCurrency(this.CurrencyForm.value).subscribe(Data => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_1___default().fire(Data[0].AlertMessage);
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/currency/currencyview/currencyview']);
                    }, 1500); //5s
                }
            }, (error) => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_1___default().fire(error.message);
            });
        }
    }
    onBack() {
        if (this.CurrencyForm.value.ID == 0) {
            var validation = "";
            if ($('#ddlCountry').val() != null || this.CurrencyForm.value.CurrencyCode != "" || this.CurrencyForm.value.CurrencyName != "") {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>";
            }
            if (validation != "") {
                sweetalert2__WEBPACK_IMPORTED_MODULE_1___default().fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                    else {
                        this.router.navigate(['/views/masters/commonmaster/currency/currencyview/currencyview']);
                    }
                });
                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/currency/currencyview/currencyview']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/currency/currencyview/currencyview']);
        }
    }
};
CurrencyComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.ActivatedRoute },
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder },
    { type: _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_3__.SystemadminService }
];
CurrencyComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-currency',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_currency_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        //styleUrls: ['./currency.component.css']
    })
], CurrencyComponent);



/***/ }),

/***/ 13095:
/*!********************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/currency/currencyview/currencyview.component.ts ***!
  \********************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "CurrencyviewComponent": function() { return /* binding */ CurrencyviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_currencyview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./currencyview.component.html */ 57832);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _pagination_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../../../pagination.service */ 35217);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../../services/masters.service */ 52852);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
/* harmony import */ var _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../services/systemadmin.service */ 31554);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let CurrencyviewComponent = class CurrencyviewComponent {
    constructor(ms, fb, ps, titleService, Service) {
        this.ms = ms;
        this.fb = fb;
        this.ps = ps;
        this.titleService = titleService;
        this.Service = Service;
        this.title = 'Currency Master';
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        // pager object
        this.pager = {};
        this.isDesc = false;
        this.column = '';
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.refreshDepList();
        this.dropdownCountry();
        this.clearSearch();
    }
    dropdownCountry() {
        this.Service.GetCountries(this.searchForm.value).subscribe(data => {
            this.dscountryItem = data;
        });
    }
    refreshDepList() {
        this.ms.getCurrencyList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;
            // initialize to page 1
            this.setPage(1);
        });
    }
    onSubmit() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.searchForm.value.CountryID = $('#ddlCountryv').val();
        this.refreshDepList();
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            CurrencyCode: '',
            CurrencyName: '',
            Status: 0,
            CountryID: 0
        });
    }
    clearSearch() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.searchForm.value.CountryID = $('#ddlCountryv').val();
        this.createForm();
        this.refreshDepList();
        $('#ddlStatusv').val(0).trigger("change");
        $('#ddlCountryv').val(0).trigger("change");
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
    sort(property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        let direction = this.isDesc ? 1 : -1;
        this.pagedItems.sort(function (a, b) {
            if (a[property] < b[property]) {
                return -1 * direction;
            }
            else if (a[property] > b[property]) {
                return 1 * direction;
            }
            else {
                return 0;
            }
        });
    }
    ;
};
CurrencyviewComponent.ctorParameters = () => [
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder },
    { type: _pagination_service__WEBPACK_IMPORTED_MODULE_1__.PaginationService },
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__.Title },
    { type: _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_3__.SystemadminService }
];
CurrencyviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-currencyview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_currencyview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        // styleUrls: ['./currencyview.component.css']
    })
], CurrencyviewComponent);



/***/ }),

/***/ 73326:
/*!***************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/hazardousclass/hazardousclass.component.ts ***!
  \***************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "HazardousclassComponent": function() { return /* binding */ HazardousclassComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_hazardousclass_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./hazardousclass.component.html */ 32151);
/* harmony import */ var _hazardousclass_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./hazardousclass.component.css */ 20922);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_3__);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let HazardousclassComponent = class HazardousclassComponent {
    constructor(router, route, service, fb) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.fb = fb;
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControl('');
        this.route.queryParams.subscribe(params => {
            this.HazardousForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
    }
    createForm() {
        if (this.HazardousForm.value.ID != null) {
            this.service.HazardousEdit(this.HazardousForm.value).pipe().subscribe(data => {
                this.HazardousForm.patchValue(data[0]);
                $('#ddlStatus').select2().val(data[0].Status);
            });
            this.HazardousForm = this.fb.group({
                ID: 0,
                ClassDesc: '',
                DivisionDesc: '',
                Status: 0,
            });
            this.ForsControDisable();
        }
        else {
            this.HazardousForm = this.fb.group({
                ID: 0,
                ClassDesc: '',
                DivisionDesc: '',
                Status: 0,
            });
        }
    }
    ForsControDisable() {
        $("#txtClassDesc").attr("disabled", "disabled");
        $("#txtDivisionDesc").attr("disabled", "disabled");
    }
    onSubmit() {
        var validation = "";
        if (this.HazardousForm.value.ClassDesc == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Class Description</span></br>";
        }
        if (this.HazardousForm.value.DivisionDesc == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Division Description</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(validation);
            return false;
        }
        else {
            this.HazardousForm.value.Status = $('#ddlStatus').val();
            this.service.getSaveHazardousClasses(this.HazardousForm.value).subscribe(Data => {
                //  this.HazardousForm.value.ID = Data[0].ID;
                sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(Data[0].AlertMessage);
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview/']);
                    }, 1500); //5s
                }
            }, (error) => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(error.message);
            });
        }
    }
    onBack() {
        if (this.HazardousForm.value.ID == 0) {
            var validation = "";
            if (this.HazardousForm.value.ClassDesc != "" || this.HazardousForm.value.DivisionDesc != "") {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>";
            }
            if (validation != "") {
                sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                    else {
                        this.router.navigate(['/views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview/']);
                    }
                });
                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview/']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview/']);
        }
    }
};
HazardousclassComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.ActivatedRoute },
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder }
];
HazardousclassComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-hazardousclass',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_hazardousclass_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_hazardousclass_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], HazardousclassComponent);



/***/ }),

/***/ 68124:
/*!**************************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview.component.ts ***!
  \**************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "HazardousclassviewComponent": function() { return /* binding */ HazardousclassviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_hazardousclassview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./hazardousclassview.component.html */ 89972);
/* harmony import */ var _hazardousclassview_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./hazardousclassview.component.css */ 3794);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var _pagination_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../pagination.service */ 35217);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let HazardousclassviewComponent = class HazardousclassviewComponent {
    constructor(router, route, service, fb, ps) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.fb = fb;
        this.ps = ps;
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        // pager object
        this.pager = {};
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControl('');
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.refreshDepList();
        this.clearSearch();
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            ClassDesc: '',
            DivisionDesc: '',
            Status: 0,
        });
    }
    refreshDepList() {
        this.service.HazardousClassesList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;
            // initialize to page 1
            this.setPage(1);
        });
    }
    onSubmit() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.refreshDepList();
    }
    clearSearch() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.createForm();
        $('#ddlStatusv').val(0).trigger("change");
        this.refreshDepList();
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
};
HazardousclassviewComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.ActivatedRoute },
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder },
    { type: _pagination_service__WEBPACK_IMPORTED_MODULE_3__.PaginationService }
];
HazardousclassviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-hazardousclassview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_hazardousclassview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_hazardousclassview_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], HazardousclassviewComponent);



/***/ }),

/***/ 59816:
/*!*********************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/partymaster/partymaster.component.ts ***!
  \*********************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PartymasterComponent": function() { return /* binding */ PartymasterComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_partymaster_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./partymaster.component.html */ 87234);
/* harmony import */ var _partymaster_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./partymaster.component.css */ 65466);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var src_app_services_org_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/org.service */ 51957);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs/operators */ 98636);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../services/masters.service */ 52852);
/* harmony import */ var _services_party_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../services/party.service */ 42826);
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/common/http */ 53882);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_5___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_5__);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};











let PartymasterComponent = class PartymasterComponent {
    constructor(router, route, service, ms, ps, fb, http) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.ms = ms;
        this.ps = ps;
        this.fb = fb;
        this.http = http;
        this.DynamicGrid = [];
        this.DynamicGridAccLink = [];
        this.DynamicGridCrLink = [];
        this.DynamicGridAlertLink = [];
        this.DynamicGridAttachLink = [];
        this.Chkbox = [];
        this.val = {};
        this.statusvalues = [
            { value: '1', viewValue: 'ACTIVE' },
            { value: '2', viewValue: 'IN-ACTIVE' },
        ];
        this.statusCrvalues = [
            { value: '1', viewValue: 'ACTIVE' },
            { value: '2', viewValue: 'IN-ACTIVE' },
        ];
        this.CID = null;
        this.HDArrayIndex = '';
        this.cusID = 0;
        this.onPageTab = function (val) {
            if (val == "2" || val == "3" || val == "4" || val == "5" || val == "6") {
                if (this.partyForm.value.ID == "0") {
                    sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire("Please Save Party Details First");
                    $('#attachtab').addClass('active');
                    $('#acctab').addClass('active');
                    $('#crtab').addClass('active');
                    $('#emailtab').addClass('active');
                }
            }
        };
        this.selectedFile = null;
        this.route.queryParams.subscribe(params => {
            this.partyForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.onInitalBinding();
        $('#ddlCountry').on('select2:select', (e, args) => {
            this.CountryChanged($("#ddlCountry").val());
        });
        $('#ddlCity').on('select2:select', (e, args) => {
            this.BranchChanged($("#ddlCity").val());
        });
        $('#ddlBranch').on('select2:select', (e, args) => {
            this.BranchChangePOS($("#ddlBranch").val());
        });
    }
    onInitalBinding() {
        this.OnBindDropdownCountry();
        this.OnBindAttachTypes();
        this.OnBindPartyGSTlist();
        this.OnBindCurrencyList();
        this.OnBindUserList();
        this.OnBindAlertList();
    }
    OnBindDivisionTypes() {
        this.service.getDivisionTypes(this.partyForm.value).subscribe(data => {
            this.dsDivision = data;
        });
    }
    BranchChangePOS(BranchID) {
        this.partyForm.value.BranchID = BranchID;
        this.ps.getBranchByPOS(this.partyForm.value).subscribe(data => {
            this.dsBranchByPosItem = data;
        });
    }
    BranchChanged(cityval) {
        $('#txtBranch').val($("#ddlCity option:selected").text());
    }
    CountryChanged(countryval) {
        this.partyForm.value.CountryID = countryval;
        this.service.getCitiesBindByCountry(this.partyForm.value).subscribe(data => {
            this.dsCityItem = data;
        });
        this.service.getStatesBindByCtry(this.partyForm.value).subscribe(data => {
            this.dsStateItem = data;
        });
    }
    OnBindAttachTypes() {
        this.ps.getPartyTypeAttchments().subscribe(data => {
            this.dsAttachedDocumentTypes = data;
        });
    }
    OnBindPartyBranchlist() {
        this.ps.getPartyBranchList(this.partyForm.value).subscribe(data => {
            this.dsBranchList = data;
        });
    }
    OnBindPartyGSTlist() {
        this.ps.getPartyGSTList(this.partyForm.value).subscribe(data => {
            this.dsGSTList = data;
        });
    }
    OnBindDropdownCountry() {
        this.ms.getCountryBind().subscribe(data => {
            this.dscountryItem = data;
        });
    }
    OnBindBusinessTypes() {
        this.ps.getBusinessTypes().subscribe(data => {
            this.dsBTItem = data;
        });
    }
    OnBindCurrencyList() {
        this.ps.getCurrencyBind().subscribe(data => {
            this.dsCurrList = data;
        });
    }
    OnBindUserList() {
        this.ps.getUserDetails(this.partyForm.value).subscribe(data => {
            this.dsUserList = data;
        });
    }
    OnBindAlertList() {
        this.ps.getAlertType(this.partyForm.value).subscribe(data => {
            this.dsAlertTypeList = data;
        });
    }
    createForm() {
        if (this.partyForm.value.ID != null) {
            //alert(this.partyForm.value.ID);
            this.OnBindPartyBranchlist();
            this.ps.getPartyEdit(this.partyForm.value).subscribe(data => {
                this.partyForm.patchValue(data[0]);
                $("#txtCustomerName").val(data[0].CustomerName);
                $('#ddlCountry').select2().val(data[0].CountryID);
                //$("#ddlCountry").val(data[0].CountryID);
                this.CountryChanged(data[0].CountryID);
            });
            this.ps.PartyExistingDivisonTypes(this.partyForm.value).subscribe(data => { this.dsDivision = data; });
            this.ps.getPartyExistingBusTypes(this.partyForm.value).subscribe(data => { this.dsBTItem = data; });
            this.ps.getPartyBranchDtlsEdit(this.partyForm.value).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_6__.tap)(data1 => {
                this.DynamicGrid.splice(0, 1);
                for (let item of data1) {
                    this.DynamicGrid.push({
                        'CID': item.CID,
                        'LocBranch': item.LocBranch,
                        'CityID': item.CityID,
                        'City': item.City,
                        'StateID': item.StateID,
                        'State': item.State,
                        'TelNo': item.TelNo,
                        'PinCode': item.PinCode,
                        'EmailID': item.EmailID,
                        'PIC': item.PIC,
                        'Address': item.Address,
                        'StatusID': item.StatusID,
                        'StatusResult': item.StatusResult
                    });
                }
            })).subscribe();
            this.ps.getPartyAccEdit(this.partyForm.value).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_6__.tap)(data1 => {
                this.DynamicGridAccLink.splice(0, 1);
                for (let item of data1) {
                    this.DynamicGridAccLink.push({
                        'ID': item.ID,
                        'Branch': item.Branch,
                        'BranchID': item.BranchID,
                        'GSTINTax': item.GSTINTax,
                        'GSTListID': item.GSTListID,
                        'GSTNo': item.GSTNo,
                        'TAN': item.TAN,
                        'PAN': item.PAN,
                        'Legalname': item.Legalname,
                        'POS': item.POS,
                        'POSID': item.POSID,
                        'CurrencyCode': item.CurrencyCode,
                        'CurrID': item.CurrID,
                    });
                }
            })).subscribe();
            this.ps.getPartyCrEdit(this.partyForm.value).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_6__.tap)(data1 => {
                this.DynamicGridCrLink.splice(0, 1);
                for (let item of data1) {
                    this.DynamicGridCrLink.push({
                        'ID': item.ID,
                        'Branch': item.Branch,
                        'BranchID': item.BranchID,
                        'CreditDays': item.CreditDays,
                        'CreditLimit': item.CreditLimit,
                        'ApprovedBy': item.ApprovedBy,
                        'ApprovedName': item.ApprovedName,
                        'EffectiveDate': item.EffectiveDate,
                        'StatusV': item.StatusV,
                        'StatusCrID': item.StatusCrID,
                    });
                }
            })).subscribe();
            this.ps.getPartyEmailDtlsEdit(this.partyForm.value).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_6__.tap)(data1 => {
                this.DynamicGridAlertLink.splice(0, 1);
                for (let item of data1) {
                    this.DynamicGridAlertLink.push({
                        'ID': item.ID,
                        'Branch': item.Branch,
                        'BranchID': item.BranchID,
                        'AlertTypeID': item.AlertTypeID,
                        'AlertType': item.AlertType,
                        'EmailAlertID': item.EmailAlertID,
                    });
                }
            })).subscribe();
            this.ps.getPartyAttachDtlsEdit(this.partyForm.value).pipe((0,rxjs_operators__WEBPACK_IMPORTED_MODULE_6__.tap)(data1 => {
                this.DynamicGridAttachLink.splice(0, 1);
                for (let item of data1) {
                    this.DynamicGridAttachLink.push({
                        'AttachFile': item.AttachFile,
                        'AttachID': item.AttachID,
                        'AttachName': item.AttachName,
                    });
                }
            })).subscribe();
            this.partyForm = this.fb.group({
                ID: 0,
                CustomerName: '',
                CountryID: 0,
                IsNVOCC: 0,
                IsFF: 0,
                Itemsv1: '',
                BusinessType: '',
                BranchID: 0,
                DivisionDetails: ''
            });
        }
        else {
            this.partyForm = this.fb.group({
                ID: 0,
                CustomerName: '',
                CountryID: 0,
                IsNVOCC: 0,
                IsFF: 0,
                Itemsv1: '',
                BusinessType: '',
                BranchID: 0,
                DivisionDetails: ''
            });
            this.OnBindBusinessTypes();
            this.OnBindDivisionTypes();
            $('#ddlCountry').select2().val(0);
        }
    }
    AddBranch() {
        var validation = "";
        var ddlLocCity = $('#ddlCity').val();
        if (ddlLocCity == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select City</span></br>";
        }
        var txtBranch = $('#txtBranch').val();
        if (txtBranch.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Branch</span></br>";
        }
        var txtTel = $('#txtTel').val();
        if (txtTel.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter TelNo</span></br>";
        }
        var txtPincode = $('#txtPincode').val();
        if (txtPincode.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Pincode</span></br>";
        }
        var txtPic = $('#txtPic').val();
        if (txtPic.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter PIC</span></br>";
        }
        var txtLocAddress = $('#txtLocAddress').val();
        if (txtLocAddress.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Address</span></br>";
        }
        var ddlStatus = $('#ddlStatus').val();
        if (ddlStatus == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Status</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(validation);
            return false;
        }
        for (var i = 0; i < this.DynamicGrid.length; i++) {
            if (this.DynamicGrid[i].CID == 0) {
                if (this.DynamicGrid[i].CityID == $('#ddlCity').val()) {
                    validation += "<span style='color:red;'>*</span> <span>Branch Already Exists </span></br>";
                }
            }
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(validation);
            return false;
        }
        var CIDValue;
        CIDValue = (this.CID == null) ? 0 : this.CID;
        this.val = {
            CID: CIDValue,
            LocBranch: $("#txtBranch").val(),
            CityID: $("#ddlCity").val(),
            City: $("#ddlCity option:selected").text(),
            StateID: $("#ddlState").val(),
            State: $("#ddlState option:selected").text(),
            TelNo: $("#txtTel").val(),
            PinCode: $("#txtPincode").val(),
            EmailID: $("#txtEmailID").val(),
            PIC: $("#txtPic").val(),
            Address: $("#txtLocAddress").val(),
            StatusID: $("#ddlStatus").val(),
            StatusResult: $("#ddlStatus option:selected").text(),
            //PanNo: $("#txtPanNo").val(),
            //TanNo: $("#txtTanNo").val(),
        };
        if (this.HDArrayIndex != null && this.HDArrayIndex.length != 0) {
            this.DynamicGrid[this.HDArrayIndex] = this.val;
        }
        else {
            this.DynamicGrid.push(this.val);
        }
        $("#ddlCity").select2().val(0, "").trigger("change");
        $("#ddlState").select2().val(0, "").trigger("change");
        $("#ddlStatus").select2().val(0, "").trigger("change");
        $("#txtBranch").val("");
        $("#txtTel").val("");
        $("#txtPincode").val("");
        $("#txtEmailID").val("");
        $("#txtPic").val("");
        $("#txtLocAddress").val("");
        //$("#txtPanNo").val("");
        //$("#txtTanNo").val("");
        this.HDArrayIndex = "";
        this.CID = 0;
    }
    AddAttach() {
        var validation = "";
        var ddlAttachType = $('#ddlAttachType').val();
        if (ddlAttachType == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Attachment Type</span></br>";
        }
        var txtAttachFile = $('#txtAttachFile').val();
        if (txtAttachFile.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Upload File</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(validation);
            return false;
        }
        this.val = {
            AttachID: $("#ddlAttachType").val(),
            AttachName: $("#ddlAttachType option:selected").text(),
            AttachFile: $("#txtAttachFile").val(),
        };
        if (this.HDArrayIndex != null && this.HDArrayIndex.length != 0) {
            this.DynamicGridAttachLink[this.HDArrayIndex] = this.val;
        }
        else {
            this.DynamicGridAttachLink.push(this.val);
        }
        $("#ddlAttachType").select2().val(0, "").trigger("change");
        $("#txtAttachFile").val("");
        this.HDArrayIndex = "";
    }
    AddAccLink() {
        var validation = "";
        var ddlBranch = $('#ddlBranch').val();
        if (ddlBranch == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Branch</span></br>";
        }
        var ddlGstlist = $('#ddlGstlist').val();
        if (ddlGstlist == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select GST Category</span></br>";
        }
        var txtGST = $('#txtGST').val();
        if (txtGST.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter GST No</span></br>";
        }
        var txtLegalname = $('#txtLegalname').val();
        if (txtLegalname.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Legal Name</span></br>";
        }
        var ddlCurrency = $('#ddlCurrency').val();
        if (ddlCurrency == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Currency</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(validation);
            return false;
        }
        this.val = {
            BranchID: $("#ddlBranch").val(),
            Branch: $("#ddlBranch option:selected").text(),
            GSTListID: $("#ddlGstlist").val(),
            GSTINTax: $("#ddlGstlist option:selected").text(),
            GSTNo: $("#txtGST").val(),
            Legalname: $("#txtLegalname").val(),
            PAN: $("#txtPAN").val(),
            TAN: $("#txtTAN").val(),
            POSID: $("#ddlPOS").val(),
            POS: $("#ddlPOS option:selected").text(),
            CurrID: $("#ddlCurrency").val(),
            CurrencyCode: $("#ddlCurrency option:selected").text(),
        };
        if (this.HDArrayIndex != null && this.HDArrayIndex.length != 0) {
            this.DynamicGridAccLink[this.HDArrayIndex] = this.val;
        }
        else {
            this.DynamicGridAccLink.push(this.val);
        }
        $("#ddlBranch").select2().val(0, "").trigger("change");
        $("#ddlGstlist").select2().val(0, "").trigger("change");
        $("#ddlPOS").select2().val(0, "").trigger("change");
        $("#ddlCurrency").select2().val(0, "").trigger("change");
        $("#txtGST").val("");
        $("#txtLegalname").val("");
        $("#txtPAN").val("");
        $("#txtTAN").val("");
        this.HDArrayIndex = "";
    }
    AddCrLink() {
        var validation = "";
        var ddlCrBranch = $('#ddlCrBranch').val();
        if (ddlCrBranch == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Branch</span></br>";
        }
        var txtCrDays = $('#txtCrDays').val();
        if (txtCrDays.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Credit Days</span></br>";
        }
        var txtCrLmt = $('#txtCrLmt').val();
        if (txtCrLmt.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Credit Limit</span></br>";
        }
        var ddlUser = $('#ddlUser').val();
        if (ddlUser == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Approved by</span></br>";
        }
        var txtEffDate = $('#txtEffDate').val();
        if (txtEffDate.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Effective Date</span></br>";
        }
        var ddlCrStatus = $('#ddlCrStatus').val();
        if (ddlCrStatus == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Status </span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(validation);
            return false;
        }
        this.val = {
            BranchID: $("#ddlCrBranch").val(),
            Branch: $("#ddlCrBranch option:selected").text(),
            CreditDays: $("#txtCrDays").val(),
            CreditLimit: $("#txtCrLmt").val(),
            ApprovedBy: $("#ddlUser").val(),
            ApprovedName: $("#ddlUser option:selected").text(),
            EffectiveDate: $("#txtEffDate").val(),
            StatusCrID: $("#ddlCrStatus").val(),
            StatusV: $("#ddlCrStatus option:selected").text(),
        };
        if (this.HDArrayIndex != null && this.HDArrayIndex.length != 0) {
            this.DynamicGridCrLink[this.HDArrayIndex] = this.val;
        }
        else {
            this.DynamicGridCrLink.push(this.val);
        }
        $("#ddlCrBranch").select2().val(0, "").trigger("change");
        $("#ddlUser").select2().val(0, "").trigger("change");
        $("#ddlCrStatus").select2().val(0, "").trigger("change");
        $("#txtCrDays").val("");
        $("#txtCrLmt").val("");
        $("#txtEffDate").val("");
        this.HDArrayIndex = "";
    }
    AddEmailLink() {
        var validation = "";
        var ddlAlertBranch = $('#ddlAlertBranch').val();
        if (ddlAlertBranch == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Branch</span></br>";
        }
        var ddlAlertType = $('#ddlAlertType').val();
        if (ddlAlertType == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Alert Types</span></br>";
        }
        var txtEmailAlertID = $('#txtEmailAlertID').val();
        if (txtEmailAlertID.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Email ID</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(validation);
            return false;
        }
        this.val = {
            BranchID: $("#ddlAlertBranch").val(),
            Branch: $("#ddlAlertBranch option:selected").text(),
            AlertTypeID: $("#ddlAlertType").val(),
            AlertType: $("#ddlAlertType option:selected").text(),
            EmailAlertID: $("#txtEmailAlertID").val(),
        };
        if (this.HDArrayIndex != null && this.HDArrayIndex.length != 0) {
            this.DynamicGridAlertLink[this.HDArrayIndex] = this.val;
        }
        else {
            this.DynamicGridAlertLink.push(this.val);
        }
        $("#ddlAlertType").select2().val(0, "").trigger("change");
        $("#ddlAlertBranch").select2().val(0, "").trigger("change");
        $("#txtEmailAlertID").val("");
        this.HDArrayIndex = "";
    }
    Selectvalues(DynamicGrid, index) {
        this.HDArrayIndex = index;
        this.CID = this.DynamicGrid[index].CID;
        $("#ddlCity").select2().val(this.DynamicGrid[index].CityID).trigger("change");
        $("#ddlState").select2().val(this.DynamicGrid[index].StateID).trigger("change");
        $("#ddlStatus").select2().val(this.DynamicGrid[index].StatusID).trigger("change");
        $("#txtBranch").val(this.DynamicGrid[index].LocBranch);
        $("#txtTel").val(this.DynamicGrid[index].TelNo);
        $("#txtPincode").val(this.DynamicGrid[index].PinCode);
        $("#txtEmailID").val(this.DynamicGrid[index].EmailID);
        $("#txtPic").val(this.DynamicGrid[index].PIC);
        $("#txtLocAddress").val(this.DynamicGrid[index].Address);
        //$("#txtPanNo").val(this.DynamicGrid[index].PanNo);
        //$("#txtTanNo").val(this.DynamicGrid[index].TanNo);
    }
    SelectAccvalues(DynamicGridAccLink, index) {
        this.HDArrayIndex = index;
        //$("#ddlBranch").select2().val(this.DynamicGridAccLink[index].BranchID).trigger("change");
        $("#ddlBranch").val(this.DynamicGridAccLink[index].BranchID).trigger("change");
        $("#ddlGstlist").val(this.DynamicGridAccLink[index].GSTListID).trigger("change");
        $("#ddlPOS").select2().val(this.DynamicGridAccLink[index].POSID).trigger("change");
        $("#ddlCurrency").select2().val(this.DynamicGridAccLink[index].CurrID).trigger("change");
        $("#txtGST").val(this.DynamicGridAccLink[index].GSTNo);
        $("#txtLegalname").val(this.DynamicGridAccLink[index].Legalname);
        $("#txtPAN").val(this.DynamicGridAccLink[index].PAN);
        $("#txtTAN").val(this.DynamicGridAccLink[index].TAN);
        this.BranchChangePOS(this.DynamicGridAccLink[index].BranchID);
    }
    SelectCrvalues(DynamicGridCrLink, index) {
        this.HDArrayIndex = index;
        //$("#ddlBranch").select2().val(this.DynamicGridAccLink[index].BranchID).trigger("change");
        $("#ddlCrBranch").val(this.DynamicGridCrLink[index].BranchID).trigger("change");
        $("#ddlUser").val(this.DynamicGridCrLink[index].ApprovedBy).trigger("change");
        $("#ddlCrStatus").select2().val(this.DynamicGridCrLink[index].StatusCrID).trigger("change");
        $("#txtCrLmt").val(this.DynamicGridCrLink[index].CreditLimit);
        $("#txtCrDays").val(this.DynamicGridCrLink[index].CreditDays);
        $("#txtEffDate").val(this.DynamicGridCrLink[index].EffectiveDate);
        ;
    }
    SelectEmailAlert(DynamicGridAlertLink, index) {
        this.HDArrayIndex = index;
        //$("#ddlBranch").select2().val(this.DynamicGridAccLink[index].BranchID).trigger("change");
        $("#ddlAlertBranch").val(this.DynamicGridAlertLink[index].BranchID).trigger("change");
        $("#ddlAlertType").val(this.DynamicGridAlertLink[index].AlertTypeID).trigger("change");
        $("#txtEmailAlertID").val(this.DynamicGridAlertLink[index].EmailAlertID);
    }
    RemoveBranch(DynamicGrid, index, CID) {
        this.partyForm.value.ID = CID;
        this.DynamicGrid.splice(index, 1);
        this.ps.CusVendorBranchDelete(this.partyForm.value).subscribe(Data => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(Data[0].AlertMessage);
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(error.message);
        });
    }
    RemoveAccValues(DynamicGridAccLink, index, CID) {
        this.partyForm.value.ID = CID;
        this.DynamicGridAccLink.splice(index, 1);
        this.ps.CusVendorAccLinkDelete(this.partyForm.value).subscribe(Data => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(Data[0].AlertMessage);
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(error.message);
        });
    }
    RemoveCrvalues(DynamicGridCrLink, index, CID) {
        this.partyForm.value.ID = CID;
        this.DynamicGridCrLink.splice(index, 1);
        this.ps.CusVendorCrLinkDelete(this.partyForm.value).subscribe(Data => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(Data[0].AlertMessage);
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(error.message);
        });
    }
    RemoveAlertvalues(DynamicGridAlertLink, index, CID) {
        this.partyForm.value.ID = CID;
        this.DynamicGridAlertLink.splice(index, 1);
        this.ps.CusVendorAlertLinkDelete(this.partyForm.value).subscribe(Data => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(Data[0].AlertMessage);
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(error.message);
        });
    }
    OnSubmit() {
        var validation = "";
        if (this.partyForm.value.CustomerName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Customer Name</span></br>";
        }
        if ($("#ddlCountry").val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Country</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(validation);
            return false;
        }
        var validation = "";
        if (this.DynamicGrid.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Add Branch Details </span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(validation);
            return false;
        }
        var Itemsd = [];
        for (var i = 0; i < this.dsDivision.length; i++) {
            if (this.dsDivision[i].IsTrue) {
                var Id = this.dsDivision[i].ID;
                Itemsd.push(Id);
            }
        }
        this.partyForm.value.DivisionDetails = Itemsd.toString();
        var Itemsc = [];
        for (var i = 0; i < this.dsBTItem.length; i++) {
            if (this.dsBTItem[i].IsTrue) {
                var Id = this.dsBTItem[i].ID;
                Itemsc.push(Id);
            }
        }
        this.partyForm.value.BusinessType = Itemsc.toString();
        var Items = [];
        for (let item of this.DynamicGrid) {
            Items.push('Insert:' + item.CID, item.LocBranch, item.CityID, item.City, item.StateID, item.State, item.TelNo, item.PinCode, item.EmailID, item.PIC, item.StatusID, item.StatusResult, 'Address:' + item.Address);
        }
        ;
        this.partyForm.value.Itemsv1 = Items.toString();
        this.partyForm.value.CountryID = $('#ddlCountry').val();
        if (this.partyForm.value.IsNVOCC == true) {
            this.partyForm.value.IsNVOCC = 1;
        }
        else {
            ;
            this.partyForm.value.IsNVOCC = 0;
        }
        if (this.partyForm.value.IsFF == true) {
            this.partyForm.value.IsFF = 1;
        }
        else {
            this.partyForm.value.IsFF = 0;
        }
        // this.partyForm.value.ID = this.partyForm.value.ID;
        this.ps.partySave(this.partyForm.value).subscribe(Data => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(Data[0].AlertMessage);
            setTimeout(() => {
                this.router.navigate(['/views/masters/commonmaster/partymaster/partymasterview']);
            }, 2000); //5s
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(error.message);
        });
    }
    OnSubmitAcc() {
        var validation = "";
        if (this.DynamicGridAccLink.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Add Accounting Link Details </span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(validation);
            return false;
        }
        var ItemsAcc = [];
        for (let item of this.DynamicGridAccLink) {
            ItemsAcc.push('Insert:' + item.BranchID, item.Branch, item.GSTListID, item.GSTINTax, item.GSTNo, item.Legalname, item.PAN, item.TAN, item.POSID, item.POS, item.CurrID, item.CurrencyCode);
        }
        ;
        this.partyForm.value.Itemsv1 = ItemsAcc.toString();
        this.ps.partyAccSave(this.partyForm.value).subscribe(cty => { sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire("Record Saved Successfully"); });
    }
    OnSubmitCr() {
        var validation = "";
        if (this.DynamicGridCrLink.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Add Credit Limit Details </span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(validation);
            return false;
        }
        var ItemsCr = [];
        for (let item of this.DynamicGridCrLink) {
            ItemsCr.push('Insert:' + item.BranchID, item.Branch, item.CreditDays, item.CreditLimit, item.ApprovedBy, item.ApprovedName, item.EffectiveDate, item.StatusCrID, item.StatusV);
        }
        ;
        this.partyForm.value.Itemsv1 = ItemsCr.toString();
        this.ps.partyCrSave(this.partyForm.value).subscribe(cty => { sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire("Record Saved Successfully"); });
    }
    OnSubmitEmailAlert() {
        var validation = "";
        if (this.DynamicGridAlertLink.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Add Email Alert Details </span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(validation);
            return false;
        }
        var ItemsAlert = [];
        for (let item of this.DynamicGridAlertLink) {
            ItemsAlert.push('Insert:' + item.BranchID, item.Branch, item.AlertTypeID, item.AlertType, item.EmailAlertID);
        }
        ;
        this.partyForm.value.Itemsv1 = ItemsAlert.toString();
        this.ps.partyEmailAlertSave(this.partyForm.value).subscribe(cty => { sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire("Record Saved Successfully"); });
    }
    RecordAttachSave() {
        var validation = "";
        if (this.DynamicGridAttachLink.length == 0) {
            validation += "<span style='color:red;'>*</span> <span>Please Add Attachment Details </span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire(validation);
            return false;
        }
        var ItemsAttach = [];
        for (let item of this.DynamicGridAttachLink) {
            ItemsAttach.push('Insert:' + item.AttachFile, item.AttachID, item.AttachName);
        }
        ;
        this.partyForm.value.Itemsv1 = ItemsAttach.toString();
        this.ps.partyAttachSave(this.partyForm.value).subscribe(cty => { sweetalert2__WEBPACK_IMPORTED_MODULE_5___default().fire("Record Saved Successfully"); });
    }
    onFileSelected(event) {
        this.selectedFile = event.target.files[0];
        const filedata = new FormData();
        filedata.append('image', this.selectedFile, this.selectedFile.name);
        this.http.post('https://localhost:44301/api/PartyApi/UploadFiles', filedata).subscribe(res => { console.log(res); });
    }
};
PartymasterComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_7__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_7__.ActivatedRoute },
    { type: src_app_services_org_service__WEBPACK_IMPORTED_MODULE_2__.OrgService },
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _services_party_service__WEBPACK_IMPORTED_MODULE_4__.PartyService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_8__.FormBuilder },
    { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_9__.HttpClient }
];
PartymasterComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_10__.Component)({
        selector: 'app-partymaster',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_partymaster_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_partymaster_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], PartymasterComponent);



/***/ }),

/***/ 97658:
/*!*****************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/partymaster/partymasterview/partymasterview.component.ts ***!
  \*****************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PartymasterviewComponent": function() { return /* binding */ PartymasterviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_partymasterview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./partymasterview.component.html */ 63213);
/* harmony import */ var _partymasterview_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./partymasterview.component.css */ 12655);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var src_app_pagination_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/pagination.service */ 35217);
/* harmony import */ var _services_party_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../services/party.service */ 42826);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../../services/masters.service */ 52852);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};








let PartymasterviewComponent = class PartymasterviewComponent {
    constructor(cs, fb, ps, ms, titleService) {
        this.cs = cs;
        this.fb = fb;
        this.ps = ps;
        this.ms = ms;
        this.titleService = titleService;
        this.title = 'Customer Master';
        this.pager = {};
        this.DepartmentList = [];
        this.ActivateAddEditDepComp = false;
        this.isDesc = false;
        this.column = '';
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.OnBindDropdownCountry();
        this.partyList();
        this.clearSearch();
    }
    partyList() {
        //this.searchForm.value.CountryID = $('#ddlCountry').val();
        this.cs.getPartyList(this.searchForm.value).subscribe(data => {
            this.allItems = data;
            this.setPage(1);
        });
    }
    OnBindDropdownCountry() {
        this.ms.getCountryBind().subscribe(data => {
            this.dscountryItem = data;
        });
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            CustomerName: '',
            CountryID: 0,
        });
    }
    clearSearch() {
        this.searchForm.value.CountryID = $('#ddlCountry').val();
        this.createForm();
        this.partyList();
        $('#ddlCountry').val(0).trigger("change");
    }
    onSubmit() {
        this.searchForm.value.CountryID = $('#ddlCountry').val();
        this.cs.getPartyList(this.searchForm.value).subscribe(data => {
            this.allItems = data;
            this.setPage(1);
        });
    }
    highlightRow(dataItem) {
        this.selectedName = dataItem.CityCode;
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
    sort(property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        let direction = this.isDesc ? 1 : -1;
        this.pagedItems.sort(function (a, b) {
            if (a[property] < b[property]) {
                return -1 * direction;
            }
            else if (a[property] > b[property]) {
                return 1 * direction;
            }
            else {
                return 0;
            }
        });
    }
    ;
};
PartymasterviewComponent.ctorParameters = () => [
    { type: _services_party_service__WEBPACK_IMPORTED_MODULE_3__.PartyService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormBuilder },
    { type: src_app_pagination_service__WEBPACK_IMPORTED_MODULE_2__.PaginationService },
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_4__.MastersService },
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_6__.Title }
];
PartymasterviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_7__.Component)({
        selector: 'app-partymasterview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_partymasterview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_partymasterview_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], PartymasterviewComponent);



/***/ }),

/***/ 59060:
/*!*******************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/port/port.component.ts ***!
  \*******************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PortComponent": function() { return /* binding */ PortComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_port_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./port.component.html */ 13405);
/* harmony import */ var _port_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./port.component.css */ 37590);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_3__);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let PortComponent = class PortComponent {
    constructor(router, route, ms, fb) {
        this.router = router;
        this.route = route;
        this.ms = ms;
        this.fb = fb;
        this.id = "0";
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        this.route.queryParams.subscribe(params => {
            //this.id = params['id'];
            this.portForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.onInitalBinding();
        $('#ddlCountry').on('select2:select', (e, args) => {
            this.CountryChange($("#ddlCountry").val());
        });
    }
    onInitalBinding() {
        this.OnBindDropdownCountry();
    }
    OnBindDropdownCountry() {
        this.ms.getCountryBind().subscribe(data => {
            this.dscountryItem = data;
        });
    }
    CountryChange(countryval) {
        this.portForm.value.CountryID = countryval;
        this.ms.getGeoLocByCountryBind(this.portForm.value).subscribe(data => {
            this.ddGeoLocationItem = data;
        });
    }
    createForm() {
        if (this.portForm.value.ID != null) {
            this.ms.getPortEdit(this.portForm.value).pipe().subscribe(data => {
                this.portForm.patchValue(data[0]);
                this.CountryChange(data[0].CountryID);
                $('#ddlCountry').select2().val(data[0].CountryID);
                $('#ddlGeoLocation').select2().val(data[0].OffLocID);
                $('#ddlStatus').select2().val(data[0].Status);
            });
            this.portForm = this.fb.group({
                ID: 0,
                PortName: '',
                PortCode: '',
                CountryCode: '',
                MainPort: 0,
                IsSeaPort: 0,
                CountryID: 0,
                Status: 0,
                IsICDPort: 0,
                OffLocID: 0,
                SeaPort: '',
                ICDPort: '',
                IsAirPort: 0,
                AirPort: '',
            });
            this.ForsControDisable();
        }
        else {
            this.portForm = this.fb.group({
                ID: 0,
                PortName: '',
                PortCode: '',
                CountryCode: '',
                MainPort: 0,
                IsSeaPort: 1,
                CountryID: 0,
                Status: 1,
                IsICDPort: 0,
                GeoLocID: 0,
                SeaPort: '',
                ICDPort: '',
                IsAirPort: 0,
                AirPort: '',
            });
            $('#ddlStatus').select2().val(0);
        }
    }
    ForsControDisable() {
        $('#ddlCountry').select2("enable", false);
        $('#ddlGeoLocation').select2("enable", false);
        $("#txtPortCode").attr("disabled", "disabled");
        $("#txtPortName").attr("disabled", "disabled");
        $("#SeaChk").attr("disabled", "disabled");
        $("#IsICDPort").attr("disabled", "disabled");
        $("#IsAirPort").attr("disabled", "disabled");
    }
    onSubmit() {
        var validation = "";
        if ($('#ddlCountry').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Country</span></br>";
        }
        if (this.portForm.value.PortName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Port Name</span></br>";
        }
        if (this.portForm.value.PortCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Port Code</span></br>";
        }
        if (this.portForm.value.IsSeaPort == true && this.portForm.value.IsICDPort == true) {
            validation += "<span style='color:red;'>*</span> <span>Please Check One Either ICDPort or SeaPort </span></br>";
        }
        if (this.portForm.value.IsSeaPort == true && this.portForm.value.IsAirPort == true) {
            validation += "<span style='color:red;'>*</span> <span>Please Check One Either SeaPort or Airport</span></br>";
        }
        if (this.portForm.value.IsICDPort == true && this.portForm.value.IsAirPort == true) {
            validation += "<span style='color:red;'>*</span> <span>Please Check One Either ICDPort or Airport</span></br>";
        }
        var seaportlen = "";
        if (this.portForm.value.IsSeaPort == 1) {
            seaportlen = this.portForm.value.PortCode.length;
            if (seaportlen != "5") {
                validation += "<span style='color:red;'>*</span> <span>Port Code Must be 5 Characters</span></br>";
            }
        }
        var icdportlen = "";
        if (this.portForm.value.IsICDPort == 1) {
            icdportlen = this.portForm.value.PortCode.length;
            if (icdportlen != "5") {
                validation += "<span style='color:red;'>*</span> <span>Port Code Must be 5 Characters</span></br>";
            }
        }
        var airportlen = "";
        if (this.portForm.value.IsAirPort == 1) {
            airportlen = this.portForm.value.PortCode.length;
            if (airportlen != "3") {
                validation += "<span style='color:red;'>*</span> <span>Port Code Must be 3 Characters</span></br>";
            }
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(validation);
            return false;
        }
        if (this.portForm.value.IsSeaPort == true) {
            this.portForm.value.IsSeaPort = 1;
        }
        else {
            ;
            this.portForm.value.IsSeaPort = 0;
        }
        if (this.portForm.value.IsICDPort == true) {
            this.portForm.value.IsICDPort = 1;
        }
        else {
            this.portForm.value.IsICDPort = 0;
        }
        if (this.portForm.value.IsAirPort == true) {
            this.portForm.value.IsAirPort = 1;
        }
        else {
            this.portForm.value.IsAirPort = 0;
        }
        this.portForm.value.Status = $('#ddlStatus').val();
        this.portForm.value.CountryID = $('#ddlCountry').val();
        if ($('#ddlGeoLocation').val() == null) {
            this.portForm.value.GeoLocID = 0;
        }
        else {
            this.portForm.value.GeoLocID = $('#ddlGeoLocation').val();
        }
        this.ms.savePort(this.portForm.value).subscribe(Data => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(Data[0].AlertMessage);
            if (Data[0].AlertMegId == 2) {
                setTimeout(() => {
                    this.router.navigate(['/views/masters/commonmaster/port/portview']);
                }, 1500); //5s
            }
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(error.message);
        });
    }
    onBack() {
        if (this.portForm.value.ID == 0) {
            var validation = "";
            if ($('#ddlCountry').val() != null || this.portForm.value.PortName != "" || this.portForm.value.PortCode != "") {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>";
            }
            if (validation != "") {
                sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                    else {
                        this.router.navigate(['/views/masters/commonmaster/port/portview']);
                    }
                });
                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/port/portview']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/port/portview']);
        }
    }
};
PortComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_4__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_4__.ActivatedRoute },
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormBuilder }
];
PortComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-port',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_port_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_port_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], PortComponent);



/***/ }),

/***/ 65306:
/*!********************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/port/portview/portview.component.ts ***!
  \********************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "PortviewComponent": function() { return /* binding */ PortviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_portview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./portview.component.html */ 89349);
/* harmony import */ var _portview_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./portview.component.css */ 97706);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var src_app_pagination_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/pagination.service */ 35217);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let PortviewComponent = class PortviewComponent {
    constructor(ms, fb, ps, titleService) {
        this.ms = ms;
        this.fb = fb;
        this.ps = ps;
        this.titleService = titleService;
        this.title = 'Port Master';
        this.seaportvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        this.icdportvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        this.airportvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        this.statusvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        this.pager = {};
        this.isDesc = false;
        this.column = '';
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.PageLoadingPortList();
        this.clearSearch();
    }
    PageLoadingPortList() {
        this.ms.getPortList(this.searchForm.value).subscribe(data => {
            this.allItems = data;
            this.setPage(1);
        });
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            PortCode: '',
            PortName: '',
            CountryCode: '',
            MainPort: '',
            SeaPort: 0,
            ICDPort: 0,
            AirPort: 0,
            Status: 0
        });
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
    onSubmit() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.searchForm.value.SeaPort = $('#ddlSeaPort').val();
        this.searchForm.value.ICDPort = $('#ddlICDPort').val();
        this.searchForm.value.AirPort = $('#ddlAirPort').val();
        this.PageLoadingPortList();
    }
    clearSearch() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.searchForm.value.SeaPort = $('#ddlSeaPort').val();
        this.searchForm.value.ICDPort = $('#ddlICDPort').val();
        this.searchForm.value.AirPort = $('#ddlAirPort').val();
        this.createForm();
        this.PageLoadingPortList();
        $('#ddlStatusv').val(0).trigger("change");
        $('#ddlSeaPort').val(0).trigger("change");
        $('#ddlICDPort').val(0).trigger("change");
        $('#ddlAirPort').val(0).trigger("change");
    }
    sort(property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        let direction = this.isDesc ? 1 : -1;
        this.pagedItems.sort(function (a, b) {
            if (a[property] < b[property]) {
                return -1 * direction;
            }
            else if (a[property] > b[property]) {
                return 1 * direction;
            }
            else {
                return 0;
            }
        });
    }
    ;
};
PortviewComponent.ctorParameters = () => [
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder },
    { type: src_app_pagination_service__WEBPACK_IMPORTED_MODULE_3__.PaginationService },
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__.Title }
];
PortviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-portview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_portview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_portview_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], PortviewComponent);



/***/ }),

/***/ 3765:
/*!*********************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/shipmentlocations/shipmentlocations.component.ts ***!
  \*********************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ShipmentlocationsComponent": function() { return /* binding */ ShipmentlocationsComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_shipmentlocations_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./shipmentlocations.component.html */ 11611);
/* harmony import */ var _shipmentlocations_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./shipmentlocations.component.css */ 57266);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var src_app_services_systemadmin_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/systemadmin.service */ 31554);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_4___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_4__);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};








let ShipmentlocationsComponent = class ShipmentlocationsComponent {
    constructor(router, route, service, fb, service1) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.fb = fb;
        this.service1 = service1;
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormControl('');
        this.route.queryParams.subscribe(params => {
            this.ShipmentForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.onInitalBinding();
        $('#ddlCountryv').on('select2:select', (e, args) => {
            this.OnClickCitydropdown($("#ddlCountryv").val());
        });
    }
    createForm() {
        if (this.ShipmentForm.value.ID != null) {
            this.service.ShipmentLocationEdit(this.ShipmentForm.value).pipe().subscribe(data => {
                this.ShipmentForm.patchValue(data[0]);
                this.OnClickCitydropdown(data[0].CountryID);
                $('#ddlcity').select2().val(data[0].CityID);
                $('#ddlCountryv').select2().val(data[0].CountryID);
                $('#ddlStatus').select2().val(data[0].status);
            });
            this.ShipmentForm = this.fb.group({
                ID: 0,
                LocationCode: '',
                Location: '',
                CityID: 0,
                CountryID: 0,
                status: 1,
            });
            this.ForsControDisable();
        }
        else {
            this.ShipmentForm = this.fb.group({
                ID: 0,
                LocationCode: '',
                Location: '',
                CityID: 0,
                CountryID: 0,
                status: 1,
            });
        }
    }
    ForsControDisable() {
        $('#ddlCountryv').select2("enable", false);
        $('#ddlcity').select2("enable", false);
        $("#txtLocationCode").attr("disabled", "disabled");
        $("#txtLocation").attr("disabled", "disabled");
    }
    onInitalBinding() {
        this.dropdowncountry();
    }
    OnClickCitydropdown(CtryID) {
        this.ShipmentForm.value.CountryID = CtryID;
        this.service1.GetCities(this.ShipmentForm.value).subscribe(data => {
            this.dscityItem = data;
        });
    }
    dropdowncountry() {
        this.service.getCountry(this.ShipmentForm.value).subscribe(data => {
            this.dscountryItem = data;
        });
    }
    onSubmit() {
        var validation = "";
        if (this.ShipmentForm.value.LocationCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Location Code</span></br>";
        }
        if (this.ShipmentForm.value.Location == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Location Name</span></br>";
        }
        if ($('#ddlCountryv').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Country</span></br>";
        }
        if ($('#ddlcity').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select City</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_4___default().fire(validation);
            return false;
        }
        else {
            this.ShipmentForm.value.CityID = $('#ddlcity').val();
            this.ShipmentForm.value.CountryID = $('#ddlCountryv').val();
            this.ShipmentForm.value.status = $('#ddlStatus').val();
            this.service.getSaveshipmentlocation(this.ShipmentForm.value).subscribe(Data => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_4___default().fire(Data[0].AlertMessage);
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview/']);
                    }, 1500); //5s
                }
            }, (error) => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_4___default().fire(error.message);
            });
        }
    }
    onBack() {
        if (this.ShipmentForm.value.ID == 0) {
            var validation = "";
            if (this.ShipmentForm.value.LocationCode != "" || this.ShipmentForm.value.Location != "") {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>";
            }
            if (validation != "") {
                sweetalert2__WEBPACK_IMPORTED_MODULE_4___default().fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                    else {
                        this.router.navigate(['/views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview/']);
                    }
                });
                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview/']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview/']);
        }
    }
};
ShipmentlocationsComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_6__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_6__.ActivatedRoute },
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormBuilder },
    { type: src_app_services_systemadmin_service__WEBPACK_IMPORTED_MODULE_3__.SystemadminService }
];
ShipmentlocationsComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_7__.Component)({
        selector: 'app-shipmentlocations',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_shipmentlocations_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_shipmentlocations_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], ShipmentlocationsComponent);



/***/ }),

/***/ 35157:
/*!***********************************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview.component.ts ***!
  \***********************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ShipmentlocationsviewComponent": function() { return /* binding */ ShipmentlocationsviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_shipmentlocationsview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./shipmentlocationsview.component.html */ 17616);
/* harmony import */ var _shipmentlocationsview_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./shipmentlocationsview.component.css */ 73759);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var _pagination_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../pagination.service */ 35217);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let ShipmentlocationsviewComponent = class ShipmentlocationsviewComponent {
    constructor(router, route, service, fb, ps) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.fb = fb;
        this.ps = ps;
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        // pager object
        this.pager = {};
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControl('');
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.refreshDepList();
        this.clearSearch();
    }
    refreshDepList() {
        this.service.ShipmentLocationList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;
            // initialize to page 1
            this.setPage(1);
        });
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            LocationCode: '',
            Location: '',
            status: 0,
        });
    }
    onSubmit() {
        this.searchForm.value.status = $('#ddlStatusv').val();
        this.refreshDepList();
    }
    clearSearch() {
        this.searchForm.value.status = $('#ddlStatusv').val();
        this.createForm();
        $('#ddlStatusv').val(0).trigger("change");
        this.refreshDepList();
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
};
ShipmentlocationsviewComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.ActivatedRoute },
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder },
    { type: _pagination_service__WEBPACK_IMPORTED_MODULE_3__.PaginationService }
];
ShipmentlocationsviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-shipmentlocationsview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_shipmentlocationsview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_shipmentlocationsview_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], ShipmentlocationsviewComponent);



/***/ }),

/***/ 13356:
/*!*********************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/statemaster/statemaster.component.ts ***!
  \*********************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "StatemasterComponent": function() { return /* binding */ StatemasterComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_statemaster_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./statemaster.component.html */ 82513);
/* harmony import */ var _statemaster_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./statemaster.component.css */ 53769);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../services/masters.service */ 52852);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let StatemasterComponent = class StatemasterComponent {
    constructor(router, route, service, fb) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.fb = fb;
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        this.id = "0";
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControl('');
        this.route.queryParams.subscribe(params => {
            this.stateForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.OnBindDropdownCountry();
    }
    OnBindDropdownCountry() {
        this.service.getCountryBind().subscribe(data => {
            this.dscountryItem = data;
        });
    }
    createForm() {
        if (this.stateForm.value.ID != null) {
            this.service.getStateedit(this.stateForm.value).pipe().subscribe(data => {
                this.stateForm.patchValue(data[0]);
                $('#ddlStatus').select2().val(data[0].Status);
                $('#ddlCountry').select2().val(data[0].CountryID);
            });
            this.stateForm = this.fb.group({
                ID: 0,
                StateCode: '',
                StateName: '',
                CountryID: 0,
                Status: 0
            });
            this.ForsControDisable();
        }
        else {
            this.stateForm = this.fb.group({
                ID: 0,
                StateCode: '',
                StateName: '',
                CountryID: 0,
                Status: 1
            });
            $('#ddlStatus').select2().val(0);
        }
    }
    ForsControDisable() {
        $('#ddlCountry').select2("enable", false);
        $("#txtStateName").attr("disabled", "disabled");
        $("#txtStateCode").attr("disabled", "disabled");
    }
    onSubmit() {
        var validation = "";
        if ($('#ddlCountry').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Country</span></br>";
        }
        if (this.stateForm.value.StateName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter State Name</span></br>";
        }
        if (this.stateForm.value.StateCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter State Code</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(validation);
            return false;
        }
        else {
            this.stateForm.value.Status = $('#ddlStatus').val();
            this.stateForm.value.CountryID = $('#ddlCountry').val();
            this.service.saveState(this.stateForm.value).subscribe(Data => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(Data[0].AlertMessage);
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/statemaster/statemasterview']);
                    }, 1500); //5s
                }
            }, (error) => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(error.message);
            });
        }
    }
    onBack() {
        if (this.stateForm.value.ID == 0) {
            var validation = "";
            if ($('#ddlCountry').val() != null || this.stateForm.value.StateName != "" || this.stateForm.value.StateCode != "") {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>";
            }
            if (validation != "") {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                    else {
                        this.router.navigate(['/views/masters/commonmaster/statemaster/statemasterview']);
                    }
                });
                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/statemaster/statemasterview']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/statemaster/statemasterview']);
        }
    }
};
StatemasterComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.ActivatedRoute },
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder }
];
StatemasterComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-statemaster',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_statemaster_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_statemaster_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], StatemasterComponent);



/***/ }),

/***/ 20038:
/*!*****************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/statemaster/statemasterview/statemasterview.component.ts ***!
  \*****************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "StatemasterviewComponent": function() { return /* binding */ StatemasterviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_statemasterview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./statemasterview.component.html */ 8482);
/* harmony import */ var _statemasterview_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./statemasterview.component.css */ 6693);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _pagination_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../../pagination.service */ 35217);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../services/masters.service */ 52852);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let StatemasterviewComponent = class StatemasterviewComponent {
    constructor(ms, fb, ps, titleService) {
        this.ms = ms;
        this.fb = fb;
        this.ps = ps;
        this.titleService = titleService;
        this.title = 'State Master';
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        // pager object
        this.pager = {};
        this.isDesc = false;
        this.column = '';
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.refreshDepList();
        this.clearSearch();
    }
    refreshDepList() {
        this.ms.getStateList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;
            // initialize to page 1
            this.setPage(1);
        });
    }
    onSubmit() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.refreshDepList();
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            Country: '',
            StateCode: '',
            StateName: '',
            Status: 0
        });
    }
    clearSearch() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.createForm();
        this.refreshDepList();
        $('#ddlStatusv').val(0).trigger("change");
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
    sort(property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        let direction = this.isDesc ? 1 : -1;
        this.pagedItems.sort(function (a, b) {
            if (a[property] < b[property]) {
                return -1 * direction;
            }
            else if (a[property] > b[property]) {
                return 1 * direction;
            }
            else {
                return 0;
            }
        });
    }
    ;
};
StatemasterviewComponent.ctorParameters = () => [
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder },
    { type: _pagination_service__WEBPACK_IMPORTED_MODULE_2__.PaginationService },
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__.Title }
];
StatemasterviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-statemasterview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_statemasterview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_statemasterview_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], StatemasterviewComponent);



/***/ }),

/***/ 88820:
/*!*************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/storagelocationtype/storagelocationtype.component.ts ***!
  \*************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "StoragelocationtypeComponent": function() { return /* binding */ StoragelocationtypeComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_storagelocationtype_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./storagelocationtype.component.html */ 35346);
/* harmony import */ var _storagelocationtype_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./storagelocationtype.component.css */ 6158);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _services_enquiry_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../services/enquiry.service */ 489);
/* harmony import */ var _services_storage_location_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../services/storage-location.service */ 671);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};








let StoragelocationtypeComponent = class StoragelocationtypeComponent {
    constructor(router, route, fb, service, uk) {
        this.router = router;
        this.route = route;
        this.fb = fb;
        this.service = service;
        this.uk = uk;
        this.statusvalues = [
            { value: '1', viewValue: 'ACTIVE' },
            { value: '2', viewValue: 'IN-ACTIVE' },
        ];
        this.id = "0";
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormControl('');
        this.val = {};
        this.route.queryParams.subscribe(params => {
            this.StorageLocationForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.onInitalBinding();
    }
    PortChange(value) {
        /*$("#ddlPortCode").prop("disabled", "disabled");*/
        if (value == 1) {
            $('#ddlPortCode').removeAttr('disabled');
        }
        if (value == 2) {
            $("#ddlPortCode").prop("disabled", "disabled");
        }
        if (value == 3) {
            $("#ddlPortCode").prop("disabled", "disabled");
        }
    }
    onInitalBinding() {
        this.OnBindDropdownOfficeLocation();
        this.OnBindPorts();
    }
    OnBindDropdownOfficeLocation() {
        this.service.getOfficeList().subscribe(data => {
            this.OfficeMasterAllvalues = data;
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(error.message);
        });
    }
    OnBindPorts() {
        this.uk.getPortMasterBind(this.StorageLocationForm.value).subscribe(data => {
            this.dsPorts = data;
        });
    }
    createForm() {
        if (this.StorageLocationForm.value.ID != null) {
            this.uk.getStorageLocationEdit(this.StorageLocationForm.value).pipe().subscribe(data => {
                this.StorageLocationForm.patchValue(data[0]);
                this.PortChange(data[0].SLTypeID);
                $('#OfficeCode1').select2().val(data[0].OfficeID);
                $('#ddlPortCode').select2().val(data[0].PortID);
                $('#ddlStatus').select2().val(data[0].StatusID);
            });
            this.StorageLocationForm = this.fb.group({
                ID: 0,
                PortID: 0,
                PortCode: '',
                CustomerName: '',
                OfficeID: 0,
                StatusID: 1,
                SLTypeID: 0,
                StorageStatus: 1,
                StorageLoc: '',
                StorageCode: '',
                Remarks: '',
            });
        }
        else {
            this.StorageLocationForm = this.fb.group({
                ID: 0,
                PortID: 0,
                PortCode: '',
                CustomerName: '',
                OfficeID: 0,
                StatusID: 0,
                SLTypeID: 0,
                StorageStatus: 1,
                StorageLoc: '',
                StorageCode: '',
                Remarks: '',
            });
            $('#ddlStatus').select2().val(0);
        }
    }
    onSubmit() {
        var validation = "";
        if ($('#OfficeCode1').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Office</span></br>";
        }
        if (this.StorageLocationForm.value.StorageLoc == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Storage Location</span></br>";
        }
        if (this.StorageLocationForm.value.SLTypeID == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Select Storage Location Type</span></br>";
        }
        if (this.StorageLocationForm.value.StorageCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Short Name</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(validation);
            return false;
        }
        if ($('#ddlPortCode').val() != "" && $('#ddlPortCode').val() != null) {
            this.StorageLocationForm.value.PortID = $('#ddlPortCode').val();
        }
        else {
            this.StorageLocationForm.value.PortID = 0;
        }
        this.StorageLocationForm.value.OfficeID = $('#OfficeCode1').val();
        this.StorageLocationForm.value.StatusID = $('#ddlStatus').val();
        this.uk.getSaveStoragealocation(this.StorageLocationForm.value).subscribe(Data => {
            this.StorageLocationForm.value.ID = Data[0].ID;
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(Data[0].AlertMessage);
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(error.message);
        });
    }
};
StoragelocationtypeComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_6__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_6__.ActivatedRoute },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormBuilder },
    { type: _services_enquiry_service__WEBPACK_IMPORTED_MODULE_3__.EnquiryService },
    { type: _services_storage_location_service__WEBPACK_IMPORTED_MODULE_4__.StorageLocationService }
];
StoragelocationtypeComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_7__.Component)({
        selector: 'app-storagelocationtype',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_storagelocationtype_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_storagelocationtype_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], StoragelocationtypeComponent);



/***/ }),

/***/ 7623:
/*!*****************************************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/storagelocationtype/storagelocationtypeview/storagelocationtypeview.component.ts ***!
  \*****************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "StoragelocationtypeviewComponent": function() { return /* binding */ StoragelocationtypeviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_storagelocationtypeview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./storagelocationtypeview.component.html */ 3155);
/* harmony import */ var _storagelocationtypeview_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./storagelocationtypeview.component.css */ 92629);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _pagination_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../pagination.service */ 35217);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
/* harmony import */ var _services_storage_location_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../../services/storage-location.service */ 671);
/* harmony import */ var _services_enquiry_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../../services/enquiry.service */ 489);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};









let StoragelocationtypeviewComponent = class StoragelocationtypeviewComponent {
    constructor(fb, ps, titleService, service, uk) {
        this.fb = fb;
        this.ps = ps;
        this.titleService = titleService;
        this.service = service;
        this.uk = uk;
        this.title = 'Storage Location Master';
        this.statusvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        this.SLTypevalues = [
            { value: '1', viewValue: 'Port' },
            { value: '2', viewValue: 'Depot' },
            { value: '3', viewValue: 'Customer' },
        ];
        // pager object
        this.pager = {};
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.onInitalBinding();
        this.refreshDepList();
        this.clearSearch();
    }
    onInitalBinding() {
        this.OnBindDropdownOfficeLocation();
    }
    OnBindDropdownOfficeLocation() {
        this.service.getOfficeList().subscribe(data => {
            this.OfficeMasterAllvalues = data;
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(error.message);
        });
    }
    refreshDepList() {
        this.uk.getStorageLocationList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;
            // initialize to page 1
            this.setPage(1);
        });
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            OfficeID: 0,
            status: 0,
            statusTypes: 0,
            StorageLoc: '',
            StorageCode: '',
            SLTypeID: 0,
            StatusID: 0,
        });
    }
    clearSearch() {
        this.searchForm.value.OfficeID = $('#ddlOfficeID').val();
        this.searchForm.value.StatusID = $('#ddlStatusv').val();
        this.searchForm.value.SLTypeID = $('#ddlStatusv1').val();
        this.createForm();
        $('#ddlOfficeID').val(0).trigger("change");
        $('#ddlStatusv').val(0).trigger("change");
        $('#ddlStatusv1').val(0).trigger("change");
        this.refreshDepList();
    }
    onSubmit() {
        this.searchForm.value.OfficeID = $('#ddlOfficeID').val();
        this.searchForm.value.StatusID = $('#ddlStatusv').val();
        this.searchForm.value.SLTypeID = $('#ddlStatusv1').val();
        this.refreshDepList();
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
};
StoragelocationtypeviewComponent.ctorParameters = () => [
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_6__.FormBuilder },
    { type: _pagination_service__WEBPACK_IMPORTED_MODULE_3__.PaginationService },
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__.Title },
    { type: _services_enquiry_service__WEBPACK_IMPORTED_MODULE_5__.EnquiryService },
    { type: _services_storage_location_service__WEBPACK_IMPORTED_MODULE_4__.StorageLocationService }
];
StoragelocationtypeviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_8__.Component)({
        selector: 'app-storagelocationtypeview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_storagelocationtypeview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_storagelocationtypeview_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], StoragelocationtypeviewComponent);



/***/ }),

/***/ 73470:
/*!***************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/terminal/terminal.component.ts ***!
  \***************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "TerminalComponent": function() { return /* binding */ TerminalComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_terminal_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./terminal.component.html */ 67450);
/* harmony import */ var _terminal_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./terminal.component.css */ 23368);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../services/masters.service */ 52852);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let TerminalComponent = class TerminalComponent {
    constructor(router, route, service, fb) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.fb = fb;
        this.statusvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        this.id = "0";
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControl('');
        this.route.queryParams.subscribe(params => {
            this.terminalForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.OnBindDropdownPort();
    }
    OnBindDropdownPort() {
        this.service.getPortBind().subscribe(data => {
            this.dsportItem = data;
        });
    }
    createForm() {
        if (this.terminalForm.value.ID != null) {
            this.service.getTerminaledit(this.terminalForm.value).pipe().subscribe(data => {
                this.terminalForm.patchValue(data[0]);
                $('#ddlPort').select2().val(data[0].PortID);
                $('#ddlStatus').select2().val(data[0].Status);
            });
            this.terminalForm = this.fb.group({
                ID: 0,
                TerminalCode: '',
                TerminalName: '',
                PortID: 0,
                Status: 0
            });
            this.ForsControDisable();
        }
        else {
            this.terminalForm = this.fb.group({
                ID: 0,
                TerminalCode: '',
                TerminalName: '',
                PortID: 0,
                Status: 1
            });
        }
    }
    ForsControDisable() {
        $('#ddlPort').select2("enable", false);
        $("#txtTerminalCode").attr("disabled", "disabled");
        $("#txtTerminalName").attr("disabled", "disabled");
    }
    onSubmit() {
        var validation = "";
        if (this.terminalForm.value.TerminalCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Terminal Code</span></br>";
        }
        if (this.terminalForm.value.TerminalName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Terminal Name</span></br>";
        }
        if ($('#ddlPort').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Port</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(validation);
            return false;
        }
        this.terminalForm.value.PortID = $('#ddlPort').val();
        this.terminalForm.value.Status = $('#ddlStatus').val();
        this.service.saveTerminal(this.terminalForm.value).subscribe(Data => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(Data[0].AlertMessage);
            if (Data[0].AlertMegId == 2) {
                setTimeout(() => {
                    this.router.navigate(['/views/masters/commonmaster/terminal/terminalview']);
                }, 1500); //5s
            }
        }, (error) => {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(error.message);
        });
    }
    onBack() {
        if (this.terminalForm.value.ID == 0) {
            var validation = "";
            if (this.terminalForm.value.TerminalCode != "" || this.terminalForm.value.TerminalName != "" || $('#ddlPort').val() != null) {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>";
            }
            if (validation != "") {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                    else {
                        this.router.navigate(['/views/masters/commonmaster/terminal/terminalview']);
                    }
                });
                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/terminal/terminalview']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/terminal/terminalview']);
        }
    }
};
TerminalComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.ActivatedRoute },
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder }
];
TerminalComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-terminal',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_terminal_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_terminal_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], TerminalComponent);



/***/ }),

/***/ 28520:
/*!********************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/terminal/terminalview/terminalview.component.ts ***!
  \********************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "TerminalviewComponent": function() { return /* binding */ TerminalviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_terminalview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./terminalview.component.html */ 11133);
/* harmony import */ var _terminalview_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./terminalview.component.css */ 62125);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _pagination_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../../pagination.service */ 35217);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../services/masters.service */ 52852);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let TerminalviewComponent = class TerminalviewComponent {
    constructor(ms, fb, ps, titleService) {
        this.ms = ms;
        this.fb = fb;
        this.ps = ps;
        this.titleService = titleService;
        this.title = 'Terminal Master';
        this.statusvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        // pager object
        this.pager = {};
        this.isDesc = false;
        this.column = '';
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.refreshDepList();
        this.clearSearch();
    }
    refreshDepList() {
        this.ms.getTerminalList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;
            // initialize to page 1
            this.setPage(1);
        });
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            TerminalCode: '',
            TerminalName: '',
            PortName: '',
            Status: 0
        });
    }
    clearSearch() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.createForm();
        this.refreshDepList();
        $('#ddlStatusv').val(0).trigger("change");
    }
    onSubmit() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.refreshDepList();
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
    sort(property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        let direction = this.isDesc ? 1 : -1;
        this.pagedItems.sort(function (a, b) {
            if (a[property] < b[property]) {
                return -1 * direction;
            }
            else if (a[property] > b[property]) {
                return 1 * direction;
            }
            else {
                return 0;
            }
        });
    }
    ;
};
TerminalviewComponent.ctorParameters = () => [
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder },
    { type: _pagination_service__WEBPACK_IMPORTED_MODULE_2__.PaginationService },
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__.Title }
];
TerminalviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-terminalview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_terminalview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_terminalview_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], TerminalviewComponent);



/***/ }),

/***/ 26898:
/*!***************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/uomconversions/uomconversions.component.ts ***!
  \***************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UomconversionsComponent": function() { return /* binding */ UomconversionsComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_uomconversions_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./uomconversions.component.html */ 26938);
/* harmony import */ var _uomconversions_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./uomconversions.component.css */ 67334);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_3__);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let UomconversionsComponent = class UomconversionsComponent {
    constructor(router, route, service, fb) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.fb = fb;
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        this.id = "0";
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControl('');
        this.statusvalues1 = [
            { value: '1', viewValue: 'Plus' },
            { value: '2', viewValue: 'Minus' },
            { value: '3', viewValue: 'Multiply' },
            { value: '4', viewValue: 'Divide' },
        ];
        this.route.queryParams.subscribe(params => {
            this.UOMForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.service.getUOMActions(this.UOMForm.value).subscribe(data => {
            this.DsUOMActions = data;
        });
        this.service.getUOMValues(this.UOMForm.value).subscribe(data => {
            this.DsUOMValues = data;
        });
    }
    createForm() {
        if (this.UOMForm.value.ID != null) {
            this.service.UOMConversionsEdit(this.UOMForm.value).pipe().subscribe(data => {
                this.UOMForm.patchValue(data[0]);
                $('#ddlAction').select2().val(data[0].Action);
                $('#ddlStatus').select2().val(data[0].Status);
                $('#ddlUOMFrom').select2().val(data[0].UOMFrom);
                $('#ddlUOMTo').select2().val(data[0].UOMTo);
            });
            this.UOMForm = this.fb.group({
                ID: 0,
                UOMFrom: 0,
                UOMTo: 0,
                Factor: '',
                Action: 0,
                Status: 0,
            });
            this.ForsControDisable();
        }
        else {
            this.UOMForm = this.fb.group({
                ID: 0,
                UOMFrom: 0,
                UOMTo: 0,
                Factor: '',
                Action: 0,
                Status: 0,
            });
        }
    }
    ForsControDisable() {
        $('#ddlUOMFrom').select2("enable", false);
        $('#ddlUOMTo').select2("enable", false);
        $('#ddlAction').select2("enable", false);
        $("#txtFactor").attr("disabled", "disabled");
    }
    onSubmit() {
        var validation = "";
        if ($('#ddlUOMFrom').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select UOM From</span></br>";
        }
        if ($('#ddlUOMTo').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select UOM To</span></br>";
        }
        if ($('#ddlAction').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Action</span></br>";
        }
        if (this.UOMForm.value.Factor == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Factor Name</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(validation);
            return false;
        }
        else {
            this.UOMForm.value.Status = $('#ddlStatus').val();
            this.UOMForm.value.Action = $('#ddlAction').val();
            this.UOMForm.value.UOMFrom = $('#ddlUOMFrom').val();
            this.UOMForm.value.UOMTo = $('#ddlUOMTo').val();
            this.service.SaveUOMConversions(this.UOMForm.value).subscribe(Data => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(Data[0].AlertMessage);
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview/']);
                    }, 1500); //5s
                }
            }, (error) => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire(error.message);
            });
        }
    }
    onBack() {
        if (this.UOMForm.value.ID == 0) {
            var validation = "";
            if (this.UOMForm.value.UOMFrom != "" || this.UOMForm.value.UOMTo != "") {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>";
            }
            if (validation != "") {
                sweetalert2__WEBPACK_IMPORTED_MODULE_3___default().fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                    else {
                        this.router.navigate(['/views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview/']);
                    }
                });
                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview/']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview/']);
        }
    }
};
UomconversionsComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.ActivatedRoute },
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder }
];
UomconversionsComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-uomconversions',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_uomconversions_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_uomconversions_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], UomconversionsComponent);



/***/ }),

/***/ 56980:
/*!**************************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview.component.ts ***!
  \**************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UomconversionsviewComponent": function() { return /* binding */ UomconversionsviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_uomconversionsview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./uomconversionsview.component.html */ 40103);
/* harmony import */ var _uomconversionsview_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./uomconversionsview.component.css */ 69807);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/masters.service */ 52852);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var _pagination_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../pagination.service */ 35217);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let UomconversionsviewComponent = class UomconversionsviewComponent {
    constructor(router, route, service, fb, ps) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.fb = fb;
        this.ps = ps;
        this.statusvalues = [
            { value: '1', viewValue: 'Yes' },
            { value: '2', viewValue: 'No' },
        ];
        // pager object
        this.pager = {};
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormControl('');
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.refreshDepList();
        this.clearSearch();
        this.service.getUOMActions(this.searchForm.value).subscribe(data => {
            this.DsUOMActions = data;
        });
    }
    refreshDepList() {
        this.service.UOMConversionsList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;
            // initialize to page 1
            this.setPage(1);
        });
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            UOMFrom: '',
            UOMTo: '',
            Factor: '',
            Action: 0,
            Status: 0,
        });
    }
    onSubmit() {
        this.searchForm.value.Action = $('#ddlactionv').val();
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.refreshDepList();
    }
    clearSearch() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.searchForm.value.Action = $('#ddlactionv').val();
        this.createForm();
        $('#ddlStatusv').val(0).trigger("change");
        $('#ddlactionv').val(0).trigger("change");
        this.refreshDepList();
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
};
UomconversionsviewComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_5__.ActivatedRoute },
    { type: src_app_services_masters_service__WEBPACK_IMPORTED_MODULE_2__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder },
    { type: _pagination_service__WEBPACK_IMPORTED_MODULE_3__.PaginationService }
];
UomconversionsviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-uomconversionsview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_uomconversionsview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_uomconversionsview_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], UomconversionsviewComponent);



/***/ }),

/***/ 8884:
/*!*****************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/uommaster/uommaster.component.ts ***!
  \*****************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UommasterComponent": function() { return /* binding */ UommasterComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_uommaster_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./uommaster.component.html */ 82234);
/* harmony import */ var _uommaster_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./uommaster.component.css */ 50412);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/router */ 71258);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! sweetalert2 */ 18190);
/* harmony import */ var sweetalert2__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(sweetalert2__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../services/masters.service */ 52852);
/* harmony import */ var _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../services/systemadmin.service */ 31554);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};








let UommasterComponent = class UommasterComponent {
    constructor(router, route, service, sa, fb) {
        this.router = router;
        this.route = route;
        this.service = service;
        this.sa = sa;
        this.fb = fb;
        this.statusvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        this.statusvalues1 = [
            { value: '1', viewValue: 'Length' },
            { value: '2', viewValue: 'Weight' },
            { value: '3', viewValue: 'Time' },
            { value: '4', viewValue: 'Temperature' },
            { value: '5', viewValue: 'Capacity' },
            { value: '6', viewValue: 'Billing Unit' },
        ];
        this.id = "0";
        this.myControl = new _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormControl('');
        this.route.queryParams.subscribe(params => {
            this.uommasterForm = this.fb.group({
                ID: params['id'],
            });
        });
    }
    ngOnInit() {
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.service.getUOMTypes(this.uommasterForm.value).subscribe(data => {
            this.DsUOMCommon = data;
        });
    }
    createForm() {
        if (this.uommasterForm.value.ID != null) {
            this.service.getUOMedit(this.uommasterForm.value).pipe().subscribe(data => {
                this.uommasterForm.patchValue(data[0]);
                $('#ddlStatus').select2().val(data[0].Status);
                $('#ddlUOMType').select2().val(data[0].UOMType);
            });
            this.uommasterForm = this.fb.group({
                ID: 0,
                UOMCode: '',
                UOMDesc: '',
                Status: 0,
                UOMType: 0,
                PortID: 0,
            });
            this.ForsControDisable();
        }
        else {
            this.uommasterForm = this.fb.group({
                ID: 0,
                UOMCode: '',
                UOMDesc: '',
                Status: 1,
                UOMType: 0,
                PortID: 0,
            });
        }
    }
    ForsControDisable() {
        $('#ddlUOMType').select2("enable", false);
        $("#txtUOMCode").attr("disabled", "disabled");
        $("#txtUOMDesc").attr("disabled", "disabled");
    }
    onSubmit() {
        var validation = "";
        if (this.uommasterForm.value.UOMCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter UOM Code</span></br>";
        }
        if (this.uommasterForm.value.UOMDesc == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter UOM Description</span></br>";
        }
        if (validation != "") {
            sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(validation);
            return false;
        }
        else {
            this.uommasterForm.value.Status = $('#ddlStatus').val();
            this.uommasterForm.value.UOMType = $('#ddlUOMType').val();
            this.service.saveUOM(this.uommasterForm.value).subscribe(Data => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(Data[0].AlertMessage);
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/uommaster/uommasterview']);
                    }, 1500); //5s
                }
            }, (error) => {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire(error.message);
            });
        }
    }
    onBack() {
        if (this.uommasterForm.value.ID == 0) {
            var validation = "";
            if (this.uommasterForm.value.UOMCode != "" || this.uommasterForm.value.UOMDesc != "") {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>";
            }
            if (validation != "") {
                sweetalert2__WEBPACK_IMPORTED_MODULE_2___default().fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                    else {
                        this.router.navigate(['/views/masters/commonmaster/uommaster/uommasterview']);
                    }
                });
                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/uommaster/uommasterview']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/uommaster/uommasterview']);
        }
    }
};
UommasterComponent.ctorParameters = () => [
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_6__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_6__.ActivatedRoute },
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _services_systemadmin_service__WEBPACK_IMPORTED_MODULE_4__.SystemadminService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormBuilder }
];
UommasterComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_7__.Component)({
        selector: 'app-uommaster',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_uommaster_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_uommaster_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], UommasterComponent);



/***/ }),

/***/ 91529:
/*!***********************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/uommaster/uommasterview/uommasterview.component.ts ***!
  \***********************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "UommasterviewComponent": function() { return /* binding */ UommasterviewComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_uommasterview_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./uommasterview.component.html */ 76742);
/* harmony import */ var _uommasterview_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./uommasterview.component.css */ 55259);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 2316);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/forms */ 1707);
/* harmony import */ var _pagination_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../../../../pagination.service */ 35217);
/* harmony import */ var _services_masters_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../../services/masters.service */ 52852);
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/platform-browser */ 71570);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







let UommasterviewComponent = class UommasterviewComponent {
    constructor(ms, fb, service, ps, titleService) {
        this.ms = ms;
        this.fb = fb;
        this.service = service;
        this.ps = ps;
        this.titleService = titleService;
        this.title = 'UOM Master';
        this.statusvalues = [
            { value: '1', viewValue: 'YES' },
            { value: '2', viewValue: 'NO' },
        ];
        this.statusvalues1 = [
            { value: '1', viewValue: 'Length' },
            { value: '2', viewValue: 'Weight' },
            { value: '3', viewValue: 'Time' },
            { value: '4', viewValue: 'Temperature' },
            { value: '5', viewValue: 'Capacity' },
            { value: '6', viewValue: 'Billing Unit' },
        ];
        // pager object
        this.pager = {};
        this.isDesc = false;
        this.column = '';
    }
    ngOnInit() {
        this.titleService.setTitle(this.title);
        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id;
            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (key, value) {
                value.focus();
            });
        });
        this.createForm();
        this.service.getUOMTypes(this.searchForm.value).subscribe(data => {
            this.DsUOMCommon = data;
        });
        this.refreshDepList();
        this.clearSearch();
    }
    refreshDepList() {
        this.ms.getUOMList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;
            // initialize to page 1
            this.setPage(1);
        });
    }
    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            UOMCode: '',
            UOMDesc: '',
            Status: 0,
            UOMType: 0
        });
    }
    clearSearch() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.searchForm.value.UOMType = $('#ddlUOMTypev').val();
        this.createForm();
        this.refreshDepList();
        $('#ddlStatusv').val(0).trigger("change");
        $('#ddlUOMTypev').val(0).trigger("change");
    }
    onSubmit() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.searchForm.value.UOMType = $('#ddlUOMTypev').val();
        this.refreshDepList();
    }
    setPage(page) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}
        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);
        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
    sort(property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        let direction = this.isDesc ? 1 : -1;
        this.pagedItems.sort(function (a, b) {
            if (a[property] < b[property]) {
                return -1 * direction;
            }
            else if (a[property] > b[property]) {
                return 1 * direction;
            }
            else {
                return 0;
            }
        });
    }
    ;
};
UommasterviewComponent.ctorParameters = () => [
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _angular_forms__WEBPACK_IMPORTED_MODULE_4__.FormBuilder },
    { type: _services_masters_service__WEBPACK_IMPORTED_MODULE_3__.MastersService },
    { type: _pagination_service__WEBPACK_IMPORTED_MODULE_2__.PaginationService },
    { type: _angular_platform_browser__WEBPACK_IMPORTED_MODULE_5__.Title }
];
UommasterviewComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-uommasterview',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_uommasterview_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_uommasterview_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], UommasterviewComponent);



/***/ }),

/***/ 76348:
/*!****************************************************!*\
  !*** ./src/app/views/masters/masters.component.ts ***!
  \****************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "MastersComponent": function() { return /* binding */ MastersComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_masters_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./masters.component.html */ 71913);
/* harmony import */ var _masters_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./masters.component.css */ 58847);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let MastersComponent = class MastersComponent {
    constructor() { }
    ngOnInit() {
    }
};
MastersComponent.ctorParameters = () => [];
MastersComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Component)({
        selector: 'app-masters',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_masters_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_masters_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], MastersComponent);



/***/ }),

/***/ 21848:
/*!********************************************************************************!*\
  !*** ./src/app/views/systemadmin/documentmanager/documentmanager.component.ts ***!
  \********************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "DocumentmanagerComponent": function() { return /* binding */ DocumentmanagerComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_documentmanager_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./documentmanager.component.html */ 77883);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


let DocumentmanagerComponent = class DocumentmanagerComponent {
    constructor() { }
    ngOnInit() {
    }
};
DocumentmanagerComponent.ctorParameters = () => [];
DocumentmanagerComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_1__.Component)({
        selector: 'app-documentmanager',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_documentmanager_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        //styleUrls: ['./documentmanager.component.css']
    })
], DocumentmanagerComponent);



/***/ }),

/***/ 17948:
/*!************************************************************!*\
  !*** ./src/app/views/systemadmin/systemadmin.component.ts ***!
  \************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "SystemadminComponent": function() { return /* binding */ SystemadminComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_systemadmin_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./systemadmin.component.html */ 59861);
/* harmony import */ var _systemadmin_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./systemadmin.component.css */ 76633);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let SystemadminComponent = class SystemadminComponent {
    constructor() { }
    ngOnInit() {
    }
};
SystemadminComponent.ctorParameters = () => [];
SystemadminComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Component)({
        selector: 'app-systemadmin',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_systemadmin_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_systemadmin_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], SystemadminComponent);



/***/ }),

/***/ 6963:
/*!******************************************!*\
  !*** ./src/app/views/views.component.ts ***!
  \******************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ViewsComponent": function() { return /* binding */ ViewsComponent; }
/* harmony export */ });
/* harmony import */ var _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_views_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! !./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./views.component.html */ 13891);
/* harmony import */ var _views_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./views.component.css */ 94805);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 2316);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



let ViewsComponent = class ViewsComponent {
    constructor() { }
    ngOnInit() {
    }
    OnsubmitOverlay() {
        $('#overlay').fadeIn().delay(2000).fadeOut();
    }
};
ViewsComponent.ctorParameters = () => [];
ViewsComponent = __decorate([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.Component)({
        selector: 'app-views',
        template: _D_Office_Files_Projects_ODAK_Clients_ODAKERP_18Apr2023_odaksa_nvocc_nvocc_ClientApp_node_modules_ngtools_webpack_src_loaders_direct_resource_js_views_component_html__WEBPACK_IMPORTED_MODULE_0__.default,
        styles: [_views_component_css__WEBPACK_IMPORTED_MODULE_1__]
    })
], ViewsComponent);



/***/ }),

/***/ 14431:
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "getBaseUrl": function() { return /* binding */ getBaseUrl; }
/* harmony export */ });
/* harmony import */ var hammerjs__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! hammerjs */ 58256);
/* harmony import */ var hammerjs__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(hammerjs__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ 61882);
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./app/app.module */ 36747);



function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
const providers = [
    { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }
];
(0,_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_2__.platformBrowserDynamic)(providers).bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_1__.AppModule)
    .catch(err => console.log(err));


/***/ }),

/***/ 75158:
/*!***************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/app.component.html ***!
  \***************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<!--<body>\r\n  <app-nav-menu></app-nav-menu>\r\n  <div class=\"container\">\r\n    <router-outlet></router-outlet>\r\n  </div>\r\n</body>-->\r\n<!-- Loader -->\r\n<!--<div id=\"preloader\">\r\n    <div id=\"status\">\r\n        <div class=\"spinner\"></div>\r\n    </div>\r\n</div>-->\r\n<!--<div id=\"wrapper\">\r\n    <app-sidenav></app-sidenav>\r\n\r\n    <div class=\"content-page\">\r\n\r\n        <div class=\"content\">\r\n            <app-header></app-header>\r\n            <div class=\"page-content-wrapper dashborad-v\">\r\n                <router-outlet></router-outlet>\r\n\r\n            </div>\r\n\r\n        </div>\r\n        <footer class=\"footer\">\r\n            copyright 2022 Odak Solutions Pvt Ltd\r\n        </footer>\r\n    </div>\r\n</div>-->\r\n\r\n<router-outlet><app-spinner></app-spinner></router-outlet>\r\n\r\n<!--<div id=\"wrapper\">\r\n    <app-sidenav></app-sidenav>\r\n\r\n    <div class=\"content-page\">\r\n\r\n        <div class=\"content\">\r\n            <app-header></app-header>\r\n            <div class=\"page-content-wrapper dashborad-v\">\r\n                <router-outlet></router-outlet>\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n</div>-->\r\n\r\n");

/***/ }),

/***/ 53079:
/*!***************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/counter/counter.component.html ***!
  \***************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<h1>Counter</h1>\r\n\r\n<p>This is a simple example of an Angular component.</p>\r\n\r\n<p aria-live=\"polite\">Current count: <strong>{{ currentCount }}</strong></p>\r\n\r\n<button class=\"btn btn-primary\" (click)=\"incrementCounter()\">Increment</button>\r\n");

/***/ }),

/***/ 80561:
/*!*********************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/fetch-data/fetch-data.component.html ***!
  \*********************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<h1 id=\"tableLabel\">Weather forecast</h1>\r\n\r\n<p>This component demonstrates fetching data from the server.</p>\r\n\r\n<p *ngIf=\"!forecasts\"><em>Loading...</em></p>\r\n\r\n<table class='table table-striped' aria-labelledby=\"tableLabel\" *ngIf=\"forecasts\">\r\n  <thead>\r\n    <tr>\r\n      <th>Date</th>\r\n      <th>Temp. (C)</th>\r\n      <th>Temp. (F)</th>\r\n      <th>Summary</th>\r\n    </tr>\r\n  </thead>\r\n  <tbody>\r\n    <tr *ngFor=\"let forecast of forecasts\">\r\n      <td>{{ forecast.date }}</td>\r\n      <td>{{ forecast.temperatureC }}</td>\r\n      <td>{{ forecast.temperatureF }}</td>\r\n      <td>{{ forecast.summary }}</td>\r\n    </tr>\r\n  </tbody>\r\n</table>\r\n");

/***/ }),

/***/ 7030:
/*!*************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/header/header.component.html ***!
  \*************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"topbar\">\n\n    <nav class=\"navbar-custom\">\n        <ul class=\"list-inline float-left mb-0 mr-3\">\n\n            <li class=\"list-inline-item\">\n                <a class=\"nav-link nav-user\">\n                  Odak Solutions Pvt Ltd\n                </a>\n                </li>\n        </ul>\n        <ul class=\"list-inline float-right mb-0 mr-3\">\n            <li class=\"list-inline-item dropdown notification-list\">\n                <a class=\"nav-link dropdown-toggle arrow-none waves-effect nav-user\" data-toggle=\"dropdown\" href=\"#\" role=\"button\" aria-haspopup=\"false\"\n                   aria-expanded=\"false\">\n                   Welcome Admin <i class=\"fa fa-user\"></i>\n                </a>\n                <div class=\"dropdown-menu dropdown-menu-right profile-dropdown \">\n                    \n                   \n                    <a class=\"dropdown-item\" href=\"#\">\n                        <i class=\"mdi mdi-logout m-r-5 text-muted\"></i> Logout\n                    </a>\n                </div>\n            </li>\n        </ul>\n\n        <ul class=\"list-inline menu-left mb-0\">\n            <li class=\"float-left\">\n                <button class=\"button-menu-mobile open-left waves-light waves-effect\">\n                    <i class=\"mdi mdi-menu\"></i>\n                </button>\n            </li>\n        </ul>\n\n        <div class=\"clearfix\"></div>\n\n    </nav>\n\n</div>\n\n<!--<mat-toolbar class=\"mat-primary\">\n    <mat-toolbar-row class=\"justify-content-between\">\n        <button mat-icon-button (click)=\"toggleSidebar()\">\n            <mat-icon>menu</mat-icon>\n        </button>\n        <div class=\"row mr-2 ml-auto\">\n            <ul class=\"row m-0 align-items-center\">\n                <li>\n                    <button mat-button\n                            [matMenuTriggerFor]=\"menu\"\n                            class=\"user mt-2 d-flex align-items-center\">-->\n                        <!--<img src=\"./assets/user.jpg\" alt=\"\" class=\"user-image mr-1 p-2\" />-->\n                        <!--User Name\n                        <mat-icon class=\"user-image-icon ml-1\">keyboard_arrow_down</mat-icon>\n                    </button>\n                    <mat-menu #menu=\"matMenu\">\n                        <button mat-menu-item>\n                            <mat-icon>exit_to_app</mat-icon>\n                            Logout\n                        </button>\n                    </mat-menu>\n                </li>\n            </ul>\n        </div>\n    </mat-toolbar-row>\n</mat-toolbar>-->");

/***/ }),

/***/ 91659:
/*!*********************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/home/home.component.html ***!
  \*********************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<!--<lottie-player src=\"https://assets2.lottiefiles.com/packages/lf20_er1ktu3i.json\" background=\"transparent\" speed=\"1\" loop autoplay style=\"position:relative;\">\r\n</lottie-player>-->\r\n<!--<div id=\"wrapper\">\r\n    <app-sidenav></app-sidenav>\r\n\r\n    <div class=\"content-page\">\r\n\r\n        <div class=\"content\">\r\n            <app-header></app-header>\r\n            <div class=\"page-content-wrapper dashborad-v\">\r\n                <router-outlet></router-outlet>\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n</div>-->\r\n<!--<div id=\"wrapper\">\r\n    <app-sidenav></app-sidenav>\r\n\r\n    <div class=\"content-page\">\r\n\r\n        <div class=\"content\">\r\n            <app-header></app-header>\r\n            <div class=\"page-content-wrapper dashborad-v\">\r\n                <router-outlet></router-outlet>\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n</div>-->\r\n\r\n");

/***/ }),

/***/ 82090:
/*!***********************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/login/login.component.html ***!
  \***********************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n<!--<div id=\"overlay\" style=\"display:none;\">\n    <div class=\"spinner\"></div>\n \n    <br />\n    Loading...\n</div>-->\n<div class=\"row\">\n    <div class=\"col-md-12\">\n        <div class=\"card\">\n            <div class=\"card-body\">\n                <div class=\"row\">\n                    <div class=\"col-md-8\">\n                        <!--<img src=\"../../assets/images/logistics.png\" />-->\n                        <lottie-player src=\"https://assets2.lottiefiles.com/packages/lf20_uhIxIg.json\" background=\"transparent\" speed=\"1\" loop autoplay style=\"position:relative;\">\n                        </lottie-player>\n                    </div>\n                    <div class=\"col-md-4\">\n\n                        <div class=\"row login\">\n                            <div class=\"col-md-12 general-label\">\n                                <div class=\"col-md-12 alc\">\n                                    <img src=\"../../assets/images/OCEANUS LOGO.png\" style=\"width:200px;\" />\n                                </div>\n                                <form class=\"mb-0\" [formGroup]=\"LoginForm\">\n                                    <div class=\"col-md-12\">\n                                        <div class=\"form-group bmd-form-group\">\n                                            <!--<label for=\"exampleInputEmail1\" class=\"bmd-label-floating \">Email address</label>-->\n                                            <input type=\"text\" placeholder=\"Username\" class=\"form-control user\" formControlName=\"Username\" />\n                                        </div>\n                                    </div>\n                                    <div class=\"col-md-12\">\n                                        <div class=\"form-group bmd-form-group\">\n                                            <!--<label  class=\"bmd-label-floating\">Password</label>-->\n                                            <input type=\"password\" placeholder=\"Password\" class=\"form-control user\" formControlName=\"Password\" />\n                                        </div>\n                                    </div>\n\n                                    <div class=\"col-md-12\" style=\"text-align:right;\">\n                                        <div class=\"divide\"></div>\n                                        <button type=\"submit\" (click)=\"OnsubmitLogin()\" class=\"btn btn-primary btn-raised mb-0\">LOGIN</button>\n\n                                        <!--<button type=\"submit\" [routerLink]=\"['/views']\" class=\"btn btn-primary btn-raised mb-0\">LOGIN</button>-->\n                                        <!--<button (click)=\"OnsubmitOverlay()\" type=\"button\">Click</button>-->\n                                    </div>\n                                    <input type=\"hidden\" id=\"ID\" formControlName=\"ID\" />\n                                    <div class=\"divide\"></div>\n                                    <div class=\"divide\"></div>\n                                    <div class=\"divide\"></div>\n                                    <div class=\"col-md-12 alc\">\n                                        copyright 2022 Odak Solutions Pvt Ltd\n                                    </div>\n\n                                </form>\n\n                            </div>\n\n\n                        </div>\n                    </div>\n                </div>\n\n\n\n            </div>\n\n\n\n        </div>\n\n\n\n    </div>\n</div>\n\n\n");

/***/ }),

/***/ 13230:
/*!*****************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/nav-menu/nav-menu.component.html ***!
  \*****************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<header>\r\n  <nav\r\n    class=\"navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3\"\r\n  >\r\n    <div class=\"container\">\r\n      <a class=\"navbar-brand\" [routerLink]=\"['/']\">nvocc</a>\r\n      <button\r\n        class=\"navbar-toggler\"\r\n        type=\"button\"\r\n        data-toggle=\"collapse\"\r\n        data-target=\".navbar-collapse\"\r\n        aria-label=\"Toggle navigation\"\r\n        [attr.aria-expanded]=\"isExpanded\"\r\n        (click)=\"toggle()\"\r\n      >\r\n        <span class=\"navbar-toggler-icon\"></span>\r\n      </button>\r\n      <div\r\n        class=\"navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse\"\r\n        [ngClass]=\"{ show: isExpanded }\"\r\n      >\r\n        <ul class=\"navbar-nav flex-grow\">\r\n          <li\r\n            class=\"nav-item\"\r\n            [routerLinkActive]=\"['link-active']\"\r\n            [routerLinkActiveOptions]=\"{ exact: true }\"\r\n          >\r\n            <a class=\"nav-link text-dark\" [routerLink]=\"['/']\">Home</a>\r\n          </li>\r\n          <li class=\"nav-item\" [routerLinkActive]=\"['link-active']\">\r\n            <a class=\"nav-link text-dark\" [routerLink]=\"['/counter']\"\r\n              >Counter</a\r\n            >\r\n          </li>\r\n          <li class=\"nav-item\" [routerLinkActive]=\"['link-active']\">\r\n            <a class=\"nav-link text-dark\" [routerLink]=\"['/fetch-data']\"\r\n              >Fetch data</a\r\n            >\r\n          </li>\r\n        </ul>\r\n      </div>\r\n    </div>\r\n  </nav>\r\n</header>\r\n");

/***/ }),

/***/ 55823:
/*!***********************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/popup/popup.component.html ***!
  \***********************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<h1 mat-dialog-title>Dialog with elements</h1>\r\n<div mat-dialog-content>This dialog showcases the title, close, content and actions elements.</div>\r\n<div mat-dialog-actions>\r\n    <button mat-button mat-dialog-close>Close</button>\r\n</div>\r\n");

/***/ }),

/***/ 43075:
/*!*******************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/side-menu/side-menu.component.html ***!
  \*******************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n<div class=\"side-menu\">\n    <button type=\"button\" class=\"button-menu-mobile button-menu-mobile-topbar open-left waves-effect\">\n        <i class=\"mdi mdi-close\"></i>\n    </button>\n\n    <!-- LOGO -->\n    <div class=\"topbar-left\">\n        <div class=\"text-center\">\n            <!--<a href=\"index.html\" class=\"logo\"><i class=\"mdi mdi-assistant\"></i> Urora</a>-->\n            <a href=\"index.html\" class=\"logo\">\n                <img src=\"assets/images/logo-lg.png\" alt=\"\" class=\"logo-large\">\n            </a>\n        </div>\n    </div>\n\n    <div class=\"sidebar-inner slimscrollleft\" id=\"sidebar-main\">\n\n        <div id=\"sidebar-menu\">\n            <ul>\n                <li class=\"menu-title\">Main</li>\n\n                <li>\n                    <a href=\"index.html\" class=\"waves-effect\">\n                        <i class=\"mdi mdi-view-dashboard\"></i>\n                        <span>\n                            Dashboard\n                            <span class=\"badge badge-pill badge-primary float-right\">7</span>\n                        </span>\n                    </a>\n                </li>\n\n                <li>\n                    <a href=\"calendar.html\" class=\"waves-effect\">\n                        <i class=\"mdi mdi-calendar-clock\"></i>\n                        <span> Calendar </span>\n                    </a>\n                </li>\n                <li class=\"menu-title\">Components</li>\n\n                <li class=\"has_sub\">\n                    <a href=\"javascript:void(0);\" class=\"waves-effect\">\n                        <i class=\"mdi mdi-animation\"></i>\n                        <span> UI Elements </span>\n                        <span class=\"float-right\">\n                            <i class=\"mdi mdi-chevron-right\"></i>\n                        </span>\n                    </a>\n                    <ul class=\"list-unstyled\">\n                        <li>\n                            <a href=\"ui-badge.html\">Badge</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-alertify.html\">Alertify</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-buttons.html\">Buttons</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-carousel.html\">Carousel</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-dropdowns.html\">Dropdowns</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-typography.html\">Typography</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-cards.html\">Cards</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-grid.html\">Grid</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-rating.html\">Rating</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-tabs-accordions.html\">Tabs &amp; Accordions</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-modals.html\">Modals</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-images.html\">Images</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-alerts.html\">Alerts</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-progressbars.html\">Progress Bars</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-pagination.html\">Pagination</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-rangeslider.html\">Range Slider</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-navs.html\">Navs</a>\n                        </li>\n                        <li>\n                            <a href=\"ui-popover-tooltips.html\">Popover & Tooltips</a>\n                        </li>\n                    </ul>\n                </li>\n                <li class=\"has_sub\">\n                    <a href=\"javascript:void(0);\" class=\"waves-effect\">\n                        <i class=\"mdi mdi-table\"></i>\n                        <span> Tables </span>\n                        <span class=\"float-right\">\n                            <i class=\"mdi mdi-chevron-right\"></i>\n                        </span>\n                    </a>\n                    <ul class=\"list-unstyled\">\n                        <li>\n                            <a href=\"tables-basic.html\">Basic Tables</a>\n                        </li>\n                        <li>\n                            <a href=\"tables-datatable.html\">Data Table</a>\n                        </li>\n                    </ul>\n                </li>\n\n                <li class=\"has_sub\">\n                    <a href=\"javascript:void(0);\" class=\"waves-effect\">\n                        <i class=\"mdi mdi-cards\"></i>\n                        <span> Forms </span>\n                        <span class=\"badge badge-pill badge-info float-right\">8</span>\n                    </a>\n                    <ul class=\"list-unstyled\">\n                        <li>\n                            <a href=\"form-elements.html\">Form Elements</a>\n                        </li>\n                        <li>\n                            <a href=\"form-validation.html\">Form Validation</a>\n                        </li>\n                        <li>\n                            <a href=\"form-advanced.html\">Form Advanced</a>\n                        </li>\n                        <li>\n                            <a href=\"form-mask.html\">Form Mask</a>\n                        </li>\n                        <li>\n                            <a href=\"form-editors.html\">Form Editors</a>\n                        </li>\n                        <li>\n                            <a href=\"form-uploads.html\">Form File Upload</a>\n                        </li>\n                    </ul>\n                </li>\n\n                <li class=\"has_sub\">\n                    <a href=\"javascript:void(0);\" class=\"waves-effect\">\n                        <i class=\"mdi mdi-emoticon-poop\"></i>\n                        <span> Icons </span>\n                        <span class=\"float-right\">\n                            <i class=\"mdi mdi-chevron-right\"></i>\n                        </span>\n                    </a>\n                    <ul class=\"list-unstyled\">\n                        <li>\n                            <a href=\"icons-material.html\">Material Design</a>\n                        </li>\n                        <li>\n                            <a href=\"icons-fontawesome.html\">Font Awesome</a>\n                        </li>\n                        <li>\n                            <a href=\"icons-themify.html\">Themify Icons</a>\n                        </li>\n                    </ul>\n                </li>\n\n                <li class=\"has_sub\">\n                    <a href=\"javascript:void(0);\" class=\"waves-effect\">\n                        <i class=\"mdi mdi-chart-areaspline\"></i>\n                        <span> Charts </span>\n                        <span class=\"float-right\">\n                            <i class=\"mdi mdi-chevron-right\"></i>\n                        </span>\n                    </a>\n                    <ul class=\"list-unstyled\">\n                        <li>\n                            <a href=\"charts-morris.html\">Morris Chart</a>\n                        </li>\n                        <li>\n                            <a href=\"charts-chartist.html\">Chartist Chart</a>\n                        </li>\n                        <li>\n                            <a href=\"charts-chartjs.html\">Chartjs Chart</a>\n                        </li>\n                        <li>\n                            <a href=\"charts-flot.html\">Flot Chart</a>\n                        </li>\n                        <li>\n                            <a href=\"charts-c3.html\">C3 Chart</a>\n                        </li>\n                        <li>\n                            <a href=\"charts-xchart.html\">X Chart</a>\n                        </li>\n                        <li>\n                            <a href=\"charts-other.html\">Jquery Knob Chart</a>\n                        </li>\n                    </ul>\n                </li>\n\n                <li class=\"menu-title\">Extra</li>\n\n                <li class=\"has_sub\">\n                    <a href=\"javascript:void(0);\" class=\"waves-effect\">\n                        <i class=\"mdi mdi-map-marker-multiple\"></i>\n                        <span> Maps </span>\n                        <span class=\"badge badge-pill badge-danger float-right\">2</span>\n                    </a>\n                    <ul class=\"list-unstyled\">\n                        <li>\n                            <a href=\"maps-google.html\"> Google Map</a>\n                        </li>\n                        <li>\n                            <a href=\"maps-vector.html\"> Vector Map</a>\n                        </li>\n                    </ul>\n                </li>\n\n                <li class=\"has_sub\">\n                    <a href=\"javascript:void(0);\" class=\"waves-effect\">\n                        <i class=\"mdi mdi-layers\"></i>\n                        <span> Pages </span>\n                        <span class=\"float-right\">\n                            <i class=\"mdi mdi-chevron-right\"></i>\n                        </span>\n                    </a>\n                    <ul class=\"list-unstyled\">\n                        <li>\n                            <a href=\"pages-login.html\">Login</a>\n                        </li>\n                        <li>\n                            <a href=\"pages-register.html\">Register</a>\n                        </li>\n                        <li>\n                            <a href=\"pages-recoverpw.html\">Recover Password</a>\n                        </li>\n                        <li>\n                            <a href=\"pages-lock-screen.html\">Lock Screen</a>\n                        </li>\n                        <li>\n                            <a href=\"pages-blank.html\">Blank Page</a>\n                        </li>\n                        <li>\n                            <a href=\"pages-404.html\">Error 404</a>\n                        </li>\n                        <li>\n                            <a href=\"pages-500.html\">Error 500</a>\n                        </li>\n                    </ul>\n                </li>\n\n            </ul>\n        </div>\n        <div class=\"clearfix\"></div>\n    </div>\n    <!-- end sidebarinner -->\n</div>\n");

/***/ }),

/***/ 12059:
/*!***************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/sidenav/sidenav.component.html ***!
  \***************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"left side-menu\">\n    <mat-nav-list>\n        <div class=\"logo\">\n            <img src=\"../../assets/images/OCEANUS LOGO.png\" alt=\"Company Logo\" />\n        </div>\n     \n\n        <div class=\"sidebar-inner slimscrollleft\" id=\"sidebar-main\">\n          \n            <mat-accordion>\n                <mat-expansion-panel hideToggle>\n                    <mat-expansion-panel-header class=\"dashboard\">\n                        <mat-panel-title>\n                            <a routerLink=\"/views/dashboard\"> <mat-icon>dashboard</mat-icon> <span style=\"margin-top:2px; float:right; padding-left:3px;\">Dashboards</span></a>\n                        </mat-panel-title>\n                    </mat-expansion-panel-header>\n\n                </mat-expansion-panel>\n                <mat-expansion-panel hideToggle>\n                    <mat-expansion-panel-header class=\"dashboard\">\n                        <mat-panel-title>\n                            <a routerLink=\"/views/systemadmin\">  <mat-icon>layers</mat-icon> <span style=\"margin-top: 2px; float: right; padding-left: 3px;\"> System Admin </span></a>\n                        </mat-panel-title>\n                    </mat-expansion-panel-header>\n\n                </mat-expansion-panel>\n\n                <mat-expansion-panel hideToggle>\n                    <mat-expansion-panel-header class=\"dashboard\">\n                        <mat-panel-title>\n                            <a routerLink=\"/views/masters/commonmaster\">  <mat-icon>layers</mat-icon> <span style=\"margin-top: 2px; float: right; padding-left: 3px;\">   Common Masters</span></a>\n                        </mat-panel-title>\n                    </mat-expansion-panel-header>\n\n                </mat-expansion-panel>\n\n                <mat-expansion-panel hideToggle>\n                    <mat-expansion-panel-header class=\"dashboard\">\n                        <mat-panel-title>\n                            <a routerLink=\"\">  <mat-icon>layers</mat-icon> <span style=\"margin-top: 2px; float: right; padding-left: 3px;\">    Liner Agency</span></a>\n                        </mat-panel-title>\n                    </mat-expansion-panel-header>\n\n                </mat-expansion-panel>\n\n                <mat-expansion-panel hideToggle>\n                    <mat-expansion-panel-header class=\"dashboard\">\n                        <mat-panel-title>\n                            <a routerLink=\"\">  <mat-icon>layers</mat-icon> <span style=\"margin-top: 2px; float: right; padding-left: 3px;\">  Freight Forwarding</span></a>\n                        </mat-panel-title>\n                    </mat-expansion-panel-header>\n\n                </mat-expansion-panel>\n\n                <mat-expansion-panel hideToggle>\n                    <mat-expansion-panel-header class=\"dashboard\">\n                        <mat-panel-title>\n                            <a routerLink=\"\">  <mat-icon>layers</mat-icon> <span style=\"margin-top: 2px; float: right; padding-left: 3px;\">   Finance</span></a>\n                        </mat-panel-title>\n                    </mat-expansion-panel-header>\n\n                </mat-expansion-panel>\n\n\n\n                <!--<mat-expansion-panel (opened)=\"panelOpenState = true\"\n                                         (closed)=\"panelOpenState = false\">\n                        <mat-expansion-panel-header>\n                            <mat-panel-title>\n                                <mat-icon>settings</mat-icon>  <span style=\"margin-top: 2px; float: right; padding-left: 3px;\">Admin</span>\n    </mat-panel-title>\n                        </mat-expansion-panel-header>\n                        <mat-list role=\"list\">\n                            <mat-list-item role=\"listitem\" routerLink=\"administration/systemmaster\">System</mat-list-item>\n                            <mat-list-item role=\"listitem\" routerLink=\"administration/orgstruct\">Org Structure</mat-list-item>\n                        </mat-list>\n                    </mat-expansion-panel>-->\n                <!--<mat-expansion-panel (opened)=\"panelOpenState = true\"\n                     (closed)=\"panelOpenState = false\">\n    <mat-expansion-panel-header>\n        <mat-panel-title>\n            <mat-icon>layers</mat-icon> <span style=\"margin-top: 2px; float: right; padding-left: 3px;\"> Master Data</span>\n        </mat-panel-title>\n    </mat-expansion-panel-header>\n    <mat-list role=\"list\">\n        <mat-list-item role=\"listitem\" routerLink=\"masters/commonmaster\">Common Master</mat-list-item>-->\n                <!--<mat-list-item role=\"listitem\" routerLink=\"masters/LAmaster\">LA Master</mat-list-item>-->\n                <!--</mat-list>\n    </mat-expansion-panel>-->\n                <!--<mat-expansion-panel hideToggle>\n        <mat-expansion-panel-header class=\"dashboard\">\n            <mat-panel-title>\n                <a [routerLink]=\"['/views/ladashboards/laworkspace/laworkspace']\"> <mat-icon>width_normal</mat-icon> <span style=\"margin-top: 2px; float: right; padding-left: 3px;\">Liner Agency</span></a>\n            </mat-panel-title>\n        </mat-expansion-panel-header>\n\n    </mat-expansion-panel>-->\n\n\n\n            </mat-accordion>\n        \n            </div>\n\n\n</mat-nav-list>\n</div>");

/***/ }),

/***/ 79589:
/*!***************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/spinner/spinner.component.html ***!
  \***************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<!--<p>spinner works!</p>-->\n\n<div class=\"page-overlay-wrapper\" *ngIf=\"showSpinner\">\n    <div class=\"col-md-2 offset-6 loaderbg\">\n        <div class=\"loaderabc\">\n        </div>\n    </div>\n    \n</div>");

/***/ }),

/***/ 22399:
/*!*************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/dashboard/dashboard.component.html ***!
  \*************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\r\n<div class=\"col-md-12\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <div class=\"col-md-12 card dashbox\">\r\n                <div class=\"card-body\">\r\n                    <p>Empty Out</p>\r\n                    <h5>17</h5>\r\n                    <div class=\"col-md-12 cardwrapper\">\r\n                        <mat-icon _ngcontent-syc-c119=\"\" role=\"img\" class=\"mat-icon notranslate material-icons mat-icon-no-color\" aria-hidden=\"true\">dvr</mat-icon>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <div class=\"col-md-12 card dashbox\">\r\n                <div class=\"card-body\">\r\n                    <p>Port In</p>\r\n                    <h5>17</h5>\r\n                    <div class=\"col-md-12 cardwrapperorange\">\r\n                        <mat-icon _ngcontent-syc-c119=\"\" role=\"img\" class=\"mat-icon notranslate material-icons mat-icon-no-color\" aria-hidden=\"true\">dvr</mat-icon>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <div class=\"col-md-12 card dashbox\">\r\n                <div class=\"card-body\">\r\n                    <p>Transit</p>\r\n                    <h5>17</h5>\r\n                    <div class=\"col-md-12 cardwrapperpurple\">\r\n                        <mat-icon _ngcontent-syc-c119=\"\" role=\"img\" class=\"mat-icon notranslate material-icons mat-icon-no-color\" aria-hidden=\"true\">dvr</mat-icon>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <div class=\"col-md-12 card dashbox\">\r\n                <div class=\"card-body\">\r\n                    <p>Discharge</p>\r\n                    <h5>17</h5>\r\n                    <div class=\"col-md-12 cardwrapperblue\">\r\n                        <mat-icon _ngcontent-syc-c119=\"\" role=\"img\" class=\"mat-icon notranslate material-icons mat-icon-no-color\" aria-hidden=\"true\">dvr</mat-icon>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n</div>");

/***/ }),

/***/ 96570:
/*!*******************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/instanceprofile/clientmanagement/clientmanagement.component.html ***!
  \*******************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-12\">\n        <h4>Instance Profile </h4>\n    </div>\n</div>\n<div class=\"row\">\n    <div class=\"col-md-12\">\n        <div class=\"row enquirynav\">\n            <div class=\"col-md-12\">\n                <ul class=\"nav nav-pills nav-justified\" role=\"tablist\">\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link \" data-toggle=\"tab\" (click)=\"btntabclick(1)\" role=\"tab\" aria-selected=\"true\">\n                            Company Details\n                        </a>\n                    </li>\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link active\" data-toggle=\"tab\" (click)=\"btntabclick(2)\" role=\"tab\" aria-selected=\"false\">\n                            Client Management\n                        </a>\n                    </li>\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link\" data-toggle=\"tab\" (click)=\"btntabclick(3)\" role=\"tab\" aria-selected=\"false\">\n                            Configuration\n                        </a>\n                    </li>\n                </ul>\n            </div>\n        </div>\n    </div>\n</div>\n<form [formGroup]=\"ClientForm\">\n    </form>");

/***/ }),

/***/ 66895:
/*!***************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/instanceprofile/companydetails/companydetails.component.html ***!
  \***************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9\">\n        <h4>Instance Profile </h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btn-raised bmd-btn-edit btntop\" [routerLink]=\"['/views/masters/instanceprofile/instanceprofile']\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n<div class=\"row\">\n    <div class=\"col-md-12\">\n        <div class=\"row enquirynav\">\n            <div class=\"col-md-12\">\n                <ul class=\"nav nav-pills nav-justified\" role=\"tablist\">\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link active\" data-toggle=\"tab\" (click)=\"btntabclick(1)\" role=\"tab\" aria-selected=\"true\">\n                            Company Details\n                        </a>\n                    </li>\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link \" data-toggle=\"tab\" (click)=\"btntabclick(2)\" role=\"tab\" aria-selected=\"false\">\n                            Client Management\n                        </a>\n                    </li>\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link\" data-toggle=\"tab\" (click)=\"btntabclick(3)\" role=\"tab\" aria-selected=\"false\">\n                            Configuration\n                        </a>\n                    </li>\n                </ul>\n            </div>\n        </div>\n    </div>\n</div>\n<form [formGroup]=\"InstanceForm\">\n    <div class=\"row bolpage\">\n        <div class=\"col-md-12 col-lg-12\">\n            <div class=\"tab-content\">\n                <div class=\"tab-pane pt-3 active show\" role=\"tabpanel\">\n                    <div class=\"row\">\n                        <div class=\"col-md-8\">\n                            <div class=\"form-group\">\n                                <div class=\"row\">\n\n\n                                    <div class=\"col-md-12\">\n                                        <div class=\"form-group\">\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <label class=\"str\">\n                                                        Company Name\n                                                    </label>\n                                                    <input class=\"form-control\" type=\"text\" id=\"txtCompanyName\" name=\"CompanyName\" formControlName=\"CompanyName\" autocomplete=\"off\" />\n                                                </div>\n                                            </div>\n\n                                        </div>\n                                    </div>\n                                    <div class=\"col-md-12\">\n                                        <div class=\"form-group\">\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <label class=\"str\">\n                                                        Company Short Name\n                                                    </label>\n                                                    <input class=\"form-control\" type=\"text\" id=\"txtCompanyCode\" name=\"CompanyCode\" formControlName=\"CompanyCode\" autocomplete=\"off\" />\n                                                </div>\n                                            </div>\n\n                                        </div>\n                                    </div>\n                                    <div class=\"col-md-12\">\n                                        <div class=\"form-group\">\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <label class=\"str\">\n                                                        Address\n                                                    </label>\n                                                    <textarea id=\"txtAddress\" class=\"form-control\" autocomplete=\"off\" rows=\"5\" style=\"height:100px!important;\" name=\"CompanyCode\" formControlName=\"Address\"></textarea>\n                                                </div>\n                                            </div>\n\n                                        </div>\n                                    </div>\n\n                                    <div class=\"col-md-6\">\n                                        <div class=\"form-group\">\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <label  class=\"str\">\n                                                        Country\n                                                    </label>\n                                                    <select class=\"form-control my-select\" id=\"ddlCountry\" formControlName=\"CountryID\">\n                                                        <option *ngFor=\"let gRow of dscountryItem\" [value]=\"gRow.ID\">\n                                                            {{gRow.Country}}\n                                                        </option>\n\n                                                    </select>\n                                                </div>\n                                            </div>\n                                        </div>\n                                    </div>\n                                    <div class=\"col-md-6\">\n                                        <div class=\"form-group\">\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <label  class=\"str\">\n                                                        City\n                                                    </label>\n                                                    <select class=\"form-control my-select\" formControlName=\"CityID\" id=\"ddlCity\">\n                                                        <option *ngFor=\"let gRow of dscityItem\" [value]=\"gRow.ID\"> {{gRow.City}}</option>\n                                                    </select>\n                                                </div>\n                                            </div>\n                                        </div>\n                                    </div>\n\n                                    <div class=\"col-md-6\">\n                                        <div class=\"form-group\">\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <label >\n                                                        P.O Box\n                                                    </label>\n                                                    <input class=\"form-control\" type=\"text\" id=\"txtPOBox\" name=\"POBox\" formControlName=\"POBox\" autocomplete=\"off\" />\n                                                </div>\n                                            </div>\n                                        </div>\n                                    </div>\n                                    <div class=\"col-md-6\">\n                                        <div class=\"form-group\">\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <label class=\"str\">\n                                                        Zip Code\n                                                    </label>\n                                                    <input class=\"form-control\" type=\"text\" id=\"txtZipCode\" name=\"ZipCode\" formControlName=\"ZipCode\" autocomplete=\"off\" />\n                                                </div>\n                                            </div>\n                                        </div>\n                                    </div>\n\n                                    <div class=\"col-md-6\">\n                                        <div class=\"form-group\">\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <label class=\"str\">\n                                                        Telephone (1)\n                                                    </label>\n                                                    <input class=\"form-control\" type=\"text\" id=\"txtTelePhone1\" name=\"TelePhone1\" formControlName=\"TelePhone1\" autocomplete=\"off\" />\n                                                </div>\n                                            </div>\n                                        </div>\n                                    </div>\n                                    <div class=\"col-md-6\">\n                                        <div class=\"form-group\">\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <label>\n                                                        Telephone (2)\n                                                    </label>\n                                                    <input class=\"form-control\" type=\"text\" id=\"txtTelePhone2\" name=\"TelePhone2\" formControlName=\"TelePhone2\" autocomplete=\"off\" />\n                                                </div>\n                                            </div>\n                                        </div>\n                                    </div>\n\n                                    <div class=\"col-md-6\">\n                                        <div class=\"form-group\">\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <label class=\"str\">\n                                                        Email\n                                                    </label>\n                                                    <input class=\"form-control\" type=\"text\" id=\"txtEmailID\" name=\"EmailID\" formControlName=\"EmailID\" autocomplete=\"off\" />\n                                                </div>\n                                            </div>\n                                        </div>\n                                    </div>\n                                    <div class=\"col-md-6\">\n                                        <div class=\"form-group\">\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <label>\n                                                        URL\n                                                    </label>\n                                                    <input class=\"form-control\" type=\"text\" id=\"txtURL\" name=\"URL\" formControlName=\"URL\" autocomplete=\"off\" />\n                                                </div>\n                                            </div>\n                                        </div>\n                                    </div>\n\n                                </div>\n                            </div>\n                        </div>\n\n                        <div class=\"col-md-4\">\n\n\n                            <div class=\"col-md-12\">\n                                <label>Logo</label>\n                                <div class=\"col-md-12\" style=\"height: 10rem !important; border: 2px solid #9e9e9e!important; margin-bottom: 2rem!important;\">\n                                    <!--<input type=\"file\" id=\"txtAttachFile\" formControlName=\"FileName\" (change)=\"onFileSelected($event)\">-->\n                                    <!--<img id=\"imgsrc\" />-->\n                                    <!--<button class=\"btn btn-primary btn-raised mb-0\" (click)=\"onUpload()\">Upload</button>-->\n                                </div>\n\n                            </div>\n\n                            <div class=\"row\" style=\"background-color: #f6f6f6; padding-left: 1rem; padding-right: 1rem; padding-top: 0.5rem;\">\n                                <div class=\"col-md-12\">\n                                    <div class=\"row\">\n                                        <div class=\"col-md-12\">\n                                            <h4 style=\"text-align: center; font-weight: 600; \">Contact Details</h4>\n                                        </div>\n                                    </div>\n                                </div>\n                                <div class=\"col-md-12\">\n                                    <div class=\"form-group\">\n                                        <div class=\"row\">\n                                            <div class=\"col-md-12\">\n                                                <label class=\"str\">\n                                                    Contact Name\n                                                </label>\n                                                <input class=\"form-control\" type=\"text\" id=\"txtContactName\" name=\"ContactName\" formControlName=\"ContactName\" autocomplete=\"off\" />\n                                            </div>\n                                        </div>\n                                    </div>\n                                </div>\n                                <div class=\"col-md-12\">\n                                    <div class=\"form-group\">\n                                        <div class=\"row\">\n                                            <div class=\"col-md-12\">\n                                                <label class=\"str\">\n                                                    Designation\n                                                </label>\n                                                <input class=\"form-control\" type=\"text\" id=\"txtDesignation\" name=\"Designation\" formControlName=\"Designation\" autocomplete=\"off\" />\n                                            </div>\n                                        </div>\n                                    </div>\n                                </div>\n                                <div class=\"col-md-12\">\n                                    <div class=\"form-group\">\n                                        <div class=\"row\">\n                                            <div class=\"col-md-12\">\n                                                <label class=\"str\">\n                                                    Email\n                                                </label>\n                                                <input class=\"form-control\" type=\"text\" id=\"txtContactEmailID\" name=\"ContactEmailID\" formControlName=\"ContactEmailID\" autocomplete=\"off\" />\n                                            </div>\n                                        </div>\n                                    </div>\n                                </div>\n\n                                <div class=\"col-md-12\">\n                                    <div class=\"form-group\">\n                                        <div class=\"row\">\n                                            <div class=\"col-md-12\">\n                                                <label class=\"str\">\n                                                    Mobile\n                                                </label>\n                                                <input class=\"form-control\" type=\"text\" id=\"txtMobileNo\" name=\"MobileNo\" formControlName=\"MobileNo\" autocomplete=\"off\" />\n                                            </div>\n                                        </div>\n                                    </div>\n                                </div>\n                            </div>\n\n\n                        </div>\n\n                    </div>\n                </div>\n            </div>\n        </div>\n\n    </div>\n    <div class=\"row\">\n        <div class=\"col-md-12 alrt\">\n            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Save</button>\n        </div>\n        <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n    </div>\n</form>");

/***/ }),

/***/ 55435:
/*!*************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/instanceprofile/configuration/configuration.component.html ***!
  \*************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9\">\n        <h4>Instance Profile </h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btn-raised bmd-btn-edit btntop\" [routerLink]=\"['/views/masters/instanceprofile/instanceprofile']\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n<div class=\"row\">\n    <div class=\"col-md-12\">\n        <div class=\"row enquirynav\">\n            <div class=\"col-md-12\">\n                <ul class=\"nav nav-pills nav-justified\" role=\"tablist\">\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link \" data-toggle=\"tab\" (click)=\"btntabclick(1)\" role=\"tab\" aria-selected=\"true\">\n                            Company Details\n                        </a>\n                    </li>\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link \" data-toggle=\"tab\" (click)=\"btntabclick(2)\" role=\"tab\" aria-selected=\"false\">\n                            Client Management\n                        </a>\n                    </li>\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link active\" data-toggle=\"tab\" (click)=\"btntabclick(3)\" role=\"tab\" aria-selected=\"false\">\n                            Configuration\n                        </a>\n                    </li>\n                </ul>\n            </div>\n        </div>\n    </div>\n</div>\n\n<form [formGroup]=\"ConfigForm\">\n    <div class=\"row\">\n        <div class=\"col-md-12\">\n            <div class=\"row forms\">\n                <div class=\"col-md-12 padlr0\">\n\n                    <div class=\"tab-content\" style=\"padding:0;\">\n                        <div class=\"tab-pane pt-3 active show\" id=\"Enquiry\" role=\"tabpanel\">\n                            <div class=\"col-md-12\">\n                                <div class=\"row\">\n                                    <div class=\"col-md-12\">\n                                        <h4 class=\"enqtitle\">\n                                            System eMail Configuration\n                                        </h4>\n                                    </div>\n                                </div>\n                                <div class=\"row\">\n                                    <div class=\"col-md-12\">\n                                        <div class=\"form-group\">\n                                            <div class=\"row\">\n\n                                                <div class=\"col-md-12\">\n                                                    <div class=\"form-group\">\n                                                        <div class=\"row\">\n                                                            <div class=\"col-md-4\">\n                                                                <div class=\"form-group\">\n                                                                    <div class=\"row\">\n                                                                        <div class=\"col-md-12\">\n                                                                            <label>Protocol</label>\n                                                                        </div>\n                                                                        <!--<div class=\"col-md-12\">\n                                                                            <label class=\"check\">\n                                                                                SMTP\n                                                                            </label>\n                                                                            <input class=\"form-check-input\" type=\"radio\" id=\"IsSMTPS\" [value]=\"1\" formControlName=\"IsSMTPS\" name=\"IsSMTPS\">\n                                                                            <label class=\"check\">\n                                                                                <input class=\"form-check-input\" type=\"radio\" id=\"IsSMTPS\" [value]=\"2\" formControlName=\"IsSMTPS\" name=\"IsSMTPS\">\n                                                                                <span>SMTPS</span>\n                                                                            </label>\n                                                                        </div>-->\n                                                                        <div class=\"col-md-12\">\n                                                                            <div class=\"row\">\n                                                                                <div class=\"col-md-4\" style=\"left: 20px;\">\n                                                                                    <input class=\"form-check-input\" type=\"radio\" id=\"IsSMTPS\" [value]=\"1\" formControlName=\"IsSMTPS\" name=\"IsSMTPS\">\n                                                                                    <label>SMTP</label>\n                                                                                </div>\n\n                                                                                <div class=\"col-md-4\">\n                                                                                    <input class=\"form-check-input\" type=\"radio\" id=\"IsSMTPS\" [value]=\"2\" formControlName=\"IsSMTPS\" name=\"IsSMTPS\">\n                                                                                    <label>SMTPS</label>\n                                                                                </div>\n                                                                            </div>\n                                                                        </div>\n\n                                                                    </div>\n                                                                </div>\n                                                            </div>\n                                                            <div class=\"col-md-4\">\n                                                                <div class=\"form-group\">\n                                                                    <div class=\"row\">\n                                                                        <div class=\"col-md-12\">\n                                                                            <label>\n                                                                                Security Mode\n                                                                            </label>\n                                                                        </div>\n                                                                        <div class=\"col-md-12\">\n                                                                            <div class=\"row\">\n                                                                                <div class=\"col-md-4\" style=\"left: 20px;\">\n                                                                                    <input class=\"form-check-input\" type=\"radio\" id=\"IsSSLTLS\" [value]=\"1\" formControlName=\"IsSSLTLS\" name=\"IsSSLTLS\">\n                                                                                    <label>SSL</label>\n                                                                                </div>\n\n                                                                                <div class=\"col-md-4\">\n                                                                                    <input class=\"form-check-input\" type=\"radio\" id=\"IsSSLTLS\" [value]=\"2\" formControlName=\"IsSSLTLS\" name=\"IsSSLTLS\">\n                                                                                    <label>TLS</label>\n                                                                                </div>\n\n                                                                            </div>\n                                                                        </div>\n\n                                                                    </div>\n                                                                </div>\n                                                            </div>\n\n                                                            <div class=\"col-md-4\">\n                                                                <div class=\"form-group\">\n                                                                    <div class=\"row\">\n                                                                        <div class=\"col-md-12\">\n                                                                            <label class=\"str\">\n                                                                                Host Name\n                                                                            </label>\n                                                                            <input class=\"form-control\" type=\"text\" id=\"txtHostName\" name=\"HostName\" formControlName=\"HostName\" autocomplete=\"off\" />\n                                                                        </div>\n                                                                    </div>\n                                                                </div>\n                                                            </div>\n                                                            <div class=\"col-md-4\">\n                                                                <div class=\"form-group\">\n                                                                    <div class=\"row\">\n                                                                        <div class=\"col-md-12\">\n                                                                            <label class=\"str\">\n                                                                                Port\n                                                                            </label>\n                                                                            <input class=\"form-control\" type=\"number\" id=\"txtIPPort\" name=\"IPPort\" formControlName=\"IPPort\" autocomplete=\"off\" />\n                                                                        </div>\n                                                                    </div>\n                                                                </div>\n                                                            </div>\n\n                                                            <div class=\"col-md-4\">\n                                                                <div class=\"form-group\">\n                                                                    <div class=\"row\">\n                                                                        <div class=\"col-md-12\">\n                                                                            <label>\n                                                                                Sender Id\n                                                                            </label>\n                                                                            <input class=\"form-control\" type=\"text\" id=\"txtSenderID\" name=\"SenderID\" formControlName=\"SenderID\" autocomplete=\"off\" />\n                                                                        </div>\n                                                                    </div>\n                                                                </div>\n                                                            </div>\n                                                            <div class=\"col-md-4\">\n                                                                <div class=\"form-group\">\n                                                                    <div class=\"row\">\n                                                                        <div class=\"col-md-12\">\n                                                                            <label>\n                                                                                Password\n                                                                            </label>\n                                                                            <input class=\"form-control\" type=\"password\" id=\"txtPassword\" name=\"Password\" formControlName=\"Password\" autocomplete=\"off\" />\n                                                                        </div>\n                                                                    </div>\n                                                                </div>\n                                                            </div>\n\n                                                            <div class=\"col-md-4\">\n                                                                <div class=\"form-group\">\n                                                                    <div class=\"row\">\n                                                                        <div class=\"col-md-12\">\n                                                                            <label>\n                                                                                Max Size Per Attachment (in MBs):\n                                                                            </label>\n                                                                            <input class=\"form-control\" type=\"text\" id=\"txtMBSize\" name=\"MBSize\" formControlName=\"MBSize\" autocomplete=\"off\" />\n                                                                        </div>\n                                                                    </div>\n                                                                </div>\n                                                            </div>\n                                                            <div class=\"col-md-4\">\n                                                                <div class=\"form-group\">\n                                                                    <div class=\"row\">\n                                                                        <div class=\"col-md-12\">\n                                                                            <label>\n                                                                                Max Number of Attachments\n                                                                            </label>\n                                                                            <input class=\"form-control\" type=\"text\" id=\"txtMaxNoAttachs\" name=\"MaxNoAttachs\" formControlName=\"MaxNoAttachs\" autocomplete=\"off\" />\n                                                                        </div>\n                                                                    </div>\n                                                                </div>\n                                                            </div>\n\n                                                            <div class=\"col-md-4\">\n                                                                <div class=\"form-group\">\n                                                                    <div class=\"row\">\n                                                                        <div class=\"col-md-12\">\n                                                                            <label>\n                                                                                Max Size of All Attachments (in MBs):\n                                                                            </label>\n                                                                            <input class=\"form-control\" type=\"text\" id=\"txtMaxNoAllAttachs\" name=\"MaxSizeAllAttachs\" formControlName=\"MaxSizeAllAttachs\" autocomplete=\"off\" />\n                                                                        </div>\n                                                                    </div>\n                                                                </div>\n                                                            </div>\n\n                                                        </div>\n                                                    </div>\n                                                </div>\n                                            </div>\n                                        </div>\n                                    </div>\n                                </div>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n    <div class=\"row alogtop\">\n        <div class=\"col-md-12 alrt\">\n            <button type=\"submit\" (click)=\"OnSubmitTest()\" class=\"btn btn-info btn-raised mb-0\">Test Connection</button>\n            <button type=\"submit\" (click)=\"onSubmitConfig()\" class=\"btn btn-primary btn-raised cntrbtn mb-0 \">Save</button>\n        </div>\n        <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n    </div>\n</form>");

/***/ }),

/***/ 65085:
/*!*************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/instanceprofile/instanceprofile.component.html ***!
  \*************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle rotle\">\n    <div class=\"col-md-9\">\n        <h4>Instance Profile</h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" [routerLink]=\"['/views/masters/instanceprofile/companydetails/companydetails']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n    </div>\n\n</div>\n\n\n\n<div class=\"row\">\n    <div class=\"col-9\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12 master\" >\n                            <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr role=\"row\">\n                                        <th class=\"actwid\">\n                                            S.No\n                                        </th>\n                                        <th>\n                                           Company Name\n\n                                        </th>\n                                        <th>\n                                            Company Code\n                                        </th>\n                                        <th>\n                                            City  \n                                        </th>\n                                        <th>\n                                            Country\n                                        </th>\n                                      \n                                       \n                                    </tr>\n                                </thead>\n\n                                <tbody>\n\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\"\n                                        [ngClass]=\"{'highlight' : dataItem.StateCode == selectedName}\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td><button class=\"btn btn-primary bmd-btn-fab enqbtn voybtn\" (click)=\"OnClickEdit(dataItem.ID)\">{{dataItem.CompanyName}}</button></td>\n                                        <td>{{dataItem.CompanyCode}}</td>\n                                        <td>{{dataItem.City}}</td>\n                                        <td>{{dataItem.Country}}</td>\n\n                                       \n                                    </tr>\n                                </tbody>\n                            </table>\n                        </div>\n                    </div>\n                    <div class=\"row page\" align=\"right\">\n\n                        <!-- pager -->\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{disabled:pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{disabled:pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{disabled:pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{disabled:pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n                    </div>\n                </div>\n            </div>\n        </div> <!-- end col -->\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n        <form [formGroup]=\"searchForm\">\n            <div class=\"card m-b-30 sidesearch\">\n                <div class=\"card-body cpad\">\n                    <div class=\"row\">\n\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"CompanyName\" class=\"form-control\" placeholder=\"Company Name\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"CompanyCode\" class=\"form-control\" placeholder=\"Company Code\">\n                            </div>\n                        </div>\n                      \n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 searchbtn alrt\">\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                            <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </form>\n    </div>\n</div>\n\n");

/***/ }),

/***/ 26664:
/*!****************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/cargopackage/cargopackage.component.html ***!
  \****************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9\">\n        <h4>Cargo Package Master</h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success bmd-btn-edit btn-raised btntop\" (click)=\"onBack()\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<form [formGroup]=\"cargoForm\">\n    <div class=\"row\">\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Package Code</label>\n                        <input type=\"text\" name=\"PkgCode\" autocomplete=\"off\" formControlName=\"PkgCode\" id=\"txtPkgCode\" ng-model=\"txtPkgCode\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Package Description</label>\n                        <input type=\"text\" name=\"PkgDescription\" autocomplete=\"off\" formControlName=\"PkgDescription\" id=\"txtPkgDesc\" ng-model=\"txtPkgDesc\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12 input-field\">\n                        <label>Active</label>\n                        <select name=\"Status\" formControlName=\"Status\" id=\"ddlStatus\" class=\"form-control my-select\">\n                            <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                {{status.viewValue}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n    </div>\n\n    <div class=\"row alogtop\">\n        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt\">\n            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Save</button>\n        </div>\n        <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n    </div>\n\n</form>\n");

/***/ }),

/***/ 33172:
/*!*************************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/cargopackage/cargopackageview/cargopackageview.component.html ***!
  \*************************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle rotle\">\n    <div class=\"col-md-9\">\n        <h4>Cargo Package Master</h4>\n    </div>\n    <div class=\"col-md-3 alrt\">        \n            <button type=\"button\" class=\"btn btn-success btn-raised bmd-btn-edit btntop\" [routerLink]=\"['/views/masters/commonmaster/cargopackage/cargopackage']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n        </div>\n    </div>\n\n\n<div class=\"row\">\n    <div class=\"col-9\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n\n                    <div class=\"row\">\n                        <div class=\"col-sm-12 master\">\n                            <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr role=\"row\">\n                                        <th class=\"actwid\">\n                                            S.No\n                                        </th>\n                                        <th>\n                                            Package Code\n                                        </th>\n                                        <th>Package Description</th>\n                                        <th class=\"actwid\">Active</th>\n                                        <!--<th class=\"actwid\">Action</th>-->\n                                    </tr>\n                                </thead>\n\n                                <tbody>\n\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\"\n                                        [ngClass]=\"{'highlight' : dataItem.PkgCode == selectedName}\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td class=\"alc\"><button class=\"btn btn-success bmd-btn-fab enqbtn\" [routerLink]=\"['/views/masters/commonmaster/cargopackage/cargopackage']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">{{dataItem.PkgCode}} </button></td>\n                                        <td>{{dataItem.PkgDescription}}</td>\n                                        <td>{{dataItem.StatusResult}}</td>\n                                        <!--<td class=\"alc\">\n                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/cargopackage/cargopackage']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\n                                <i class=\"material-icons\">edit</i>\n                            </button>\n                        </td>-->\n                                    </tr>\n\n                                </tbody>\n                            </table>\n                        </div>\n                    </div>\n                    <div class=\"row page\" align=\"right\">\n\n\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{'pag-disable':pager.endIndex + 1 === pager.totalItems}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n\n    <div class=\"col-md-3\">\n        <form [formGroup]=\"searchForm\">\n            <div class=\"card m-b-30 sidesearch\">\n                <div class=\"card-body cpad\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"PkgCode\" class=\"form-control\" placeholder=\"Package Code\">\n\n                            </div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"PkgDescription\" class=\"form-control\" placeholder=\"Package Description\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlStatusv\" name=\"Status\" formControlName=\"Status\">\n                                    <option value=\"0\">Active</option>\n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                        {{status.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n\n                        <div class=\"col-md-12 searchbtn alrt\">\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                            <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\n                        </div>\n\n\n                    </div>\n                </div>\n            </div>\n        </form>\n    </div>\n</div>\n");

/***/ }),

/***/ 86078:
/*!************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/city/city.component.html ***!
  \************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9\">\n        <h4>City Master</h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btn-raised bmd-btn-edit btntop\" (click)=\"onBack()\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n<form [formGroup]=\"cityForm\">\n    <div class=\"row\">\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">City  Code</label>\n                        <input type=\"text\" name=\"CityCode\" autocomplete=\"off\" id=\"txtCityCode\" formControlName=\"CityCode\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">City Name</label>\n                        <input type=\"text\" name=\"CityName\" autocomplete=\"off\" id=\"txtCityName\" formControlName=\"CityName\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n\n                    <div class=\"col-md-12\">\n                        <label>Country </label>\n                        <select class=\"form-control my-select\" id=\"ddlCountryv\" formControlName=\"CountryID\" (ngModelChange)=\"CountryChanged()\">\n                            <option *ngFor=\"let gRow of dscountryItem\" [value]=\"gRow.ID\">\n                                {{gRow.CountryName}}\n                            </option>\n\n                        </select>\n\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label>State Name</label>\n                        <select class=\"form-control my-select\" formControlName=\"StateID\" id=\"ddlStatev\">\n                            <option *ngFor=\"let gRow of dsStateItem\" [value]=\"gRow.ID\"> {{gRow.StateName}}</option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12 \">\n                        <label>Active</label>\n                        <select class=\"form-control my-select\" id=\"ddlStatus\" formControlName=\"Status\">\n                            <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                {{status.viewValue}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n\n    <div class=\"row alogtop\">\n        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt\">\n            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Save</button>\n        </div>\n        <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n    </div>\n</form>");

/***/ }),

/***/ 8023:
/*!*************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/city/cityview/cityview.component.html ***!
  \*************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle rotle\">\n    <div class=\"col-md-9\">\n        <h4>City Master</h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success bmd-btn-edit btn-raised btntop\" [routerLink]=\"['/views/masters/commonmaster/city/city']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n\n<div class=\"row\">\n    <div class=\"col-9\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n\n                    <div class=\"row\">\n                        <div class=\"col-sm-12 master\">\n                            <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr>\n                                        <th class=\"actwid\">S.No</th>\n                                        <th>City Code</th>\n                                        <th>City Name</th>\n                                        <th>Country Code</th>\n                                        <th class=\"actwid\">Active</th>\n                                        <!--<th class=\"actwid\">Action</th>-->\n                                    </tr>\n                                </thead>\n\n\n                                <tbody>\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\"\n                                        [ngClass]=\"{'highlight' : dataItem.CountryCode == selectedName}\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td class=\"alc\"> <button class=\"btn btn-success bmd-btn-fab enqbtn\" [routerLink]=\"['/views/masters/commonmaster/city/city']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">{{dataItem.CityCode}}</button></td>\n                                        <td>{{dataItem.CityName}}</td>\n                                        <td>{{dataItem.CountryCode}}</td>\n                                        <td>{{dataItem.StatusResult}}</td>\n                                        <!--<td class=\"alc\">\n                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/city/city']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\n                                <i class=\"material-icons\">edit</i>\n                            </button>\n                        </td>-->\n                                    </tr>\n\n                                </tbody>\n                                <!--<pagination-controls (pageChange)=\"p = $event\"></pagination-controls>-->\n                            </table>\n\n                        </div>\n                    </div>\n                    <div class=\"row page\" align=\"right\">\n\n\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{'pag-disable':pager.endIndex + 1 === pager.totalItems}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n\n    <div class=\"col-md-3\">\n        <form [formGroup]=\"searchForm\">\n            <div class=\"card m-b-30 sidesearch\">\n                <div class=\"card-body cpad\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n\n                                <input type=\"text\" autocomplete=\"off\" name=\"cityCode\" formControlName=\"CityCode\" class=\"form-control\" placeholder=\"City Code\">\n\n                            </div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" name=\"cityName\" formControlName=\"CityName\" class=\"form-control\" placeholder=\"City Name\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" name=\"countrycode\" formControlName=\"CountryCode\" class=\"form-control\" placeholder=\"Country Code\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlStatusv\" formControlName=\"Status\">\n                                    <option value=\"0\">Active</option>\n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                        {{status.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n\n                        <div class=\"col-md-12 searchbtn alrt\">\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                            <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\n                        </div>\n\n                        <!--<button mat-flat-button (click)=\"onCreate()\">\n        <mat-icon>add</mat-icon>Create\n    </button>\n\n    <button (click)=\"simpleAlert()\">\n        alert\n    </button>-->\n\n\n                    </div>\n                </div>\n            </div>\n            </form>\n    </div>\n</div>\n");

/***/ }),

/***/ 46878:
/*!**********************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/commodity/commodity.component.html ***!
  \**********************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9\">\n        <h4>Commodity Master</h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" (click)=\"onBack()\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<form [formGroup]=\"commodityForm\">\n    <div class=\"row\">\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Commodity UN Code</label>\n                        <input type=\"text\" name=\"CommodityUnCode\" formControlName=\"CommodityUnCode\" autocomplete=\"off\" id=\"txtCmdCode\" ng-model=\"txtCmdCode\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Commodity Name</label>\n                        <input type=\"text\" name=\"CommodityName\" formControlName=\"CommodityName\" id=\"txtCmdName\" autocomplete=\"off\" ng-model=\"txtCmdName\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">HS Code</label>\n                        <input type=\"text\" name=\"HSCode\" formControlName=\"HSCode\" autocomplete=\"off\" id=\"txtHsCode\" ng-model=\"txtHsCode\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n\n\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Commodity Type</label>\n                        <select name=\"CommodityType\" id=\"ddlCommodityType\" formControlName=\"CommodityType\" class=\"form-control my-select\">\n                            <option *ngFor=\"let commtype of dsCommodityType\" [value]=\"commtype.CommodityType\">\n                                {{commtype.GeneralName}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Dangerous Flag</label>\n                        <select name=\"DangerousFlag\" id=\"ddlFlag\" formControlName=\"DangerousFlag\" class=\"form-control my-select\">\n                            <option *ngFor=\"let dgflag of dgflag\" [value]=\"dgflag.value\">\n                                {{dgflag.viewValue}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label>Remarks</label>\n                        <input name=\"Remarks\" formControlName=\"Remarks\" type=\"text\" id=\"txtRemarks\" autocomplete=\"off\" ng-model=\"txtRemarks\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label>Active </label>\n                        <select name=\"status\" formControlName=\"Status\" class=\"form-control my-select\" id=\"ddlStatus\">\n                            <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                {{status.viewValue}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n    <div class=\"row alogtop\">\n        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt\">\n            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Save</button>\n        </div>\n        <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n    </div>\n</form>\n");

/***/ }),

/***/ 88810:
/*!****************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/commodity/commodityview/commodityview.component.html ***!
  \****************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle rotle\">\n    <div class=\"col-md-9\">\n        <h4>Commodity Master</h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" [routerLink]=\"['/views/masters/commonmaster/commodity/commodity']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n\n<div class=\"row\">\n    <div class=\"col-9\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n\n                    <div class=\"row\">\n                        <div class=\"col-sm-12 master\">\n                            <table id=\"datatable-buttons\" class=\"table table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr role=\"row\">\n                                        <th class=\"actwid\">\n                                            S.No\n                                        </th>\n                                        <th>\n                                            Commodity UN Code\n                                        </th>\n                                        <th>Commodity Name</th>\n                                        <th>HS Code</th>\n                                        <th> Flag</th>\n                                        <th>Commodity Type</th>\n\n                                        <th class=\"actwid\">Active</th>\n                                    </tr>\n                                </thead>\n\n                                <tbody>\n\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\"\n                                        [ngClass]=\"{'highlight' : dataItem.CommodityCode == selectedName}\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td class=\"alc\"> <button class=\"btn btn-success bmd-btn-fab enqbtn\" [routerLink]=\"['/views/masters/commonmaster/commodity/commodity']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">{{dataItem.CommodityUnCode}} </button></td>\n                                        <td>{{dataItem.CommodityName}}</td>\n                                        <td>{{dataItem.HSCode}}</td>\n                                        <td>{{dataItem.DangerousFlag}}</td>\n                                        <td>{{dataItem.CommodityType}}</td>\n                                        <td>{{dataItem.StatusResult}}</td>\n\n                                        <!--<td class=\"alc\">\n                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/commodity/commodity']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\n                                <i class=\"material-icons\">edit</i>\n                            </button>\n                        </td>-->\n                                    </tr>\n\n                                </tbody>\n                            </table>\n                        </div>\n                    </div>\n\n                    <div class=\"row page\" align=\"right\">\n\n\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{'pag-disable':pager.endIndex + 1 === pager.totalItems}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n\n    <div class=\"col-md-3\">\n        <form [formGroup]=\"searchForm\">\n            <div class=\"card m-b-30 sidesearch\">\n                <div class=\"card-body cpad\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"CommodityUnCode\" name=\"CommodityUnCode\" class=\"form-control\" placeholder=\"Commodity UN Code\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"CommodityName\" name=\"CommodityName\" class=\"form-control\" placeholder=\"Commodity Name\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"HSCode\" class=\"form-control\" placeholder=\"HS Code\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlCommodityTypev\" formControlName=\"CommodityTypeID\">\n                                    <option value=\"0\">Commodity Type</option>\n                                    <option *ngFor=\"let gRow of CommodityItem\" [value]=\"gRow.CommodityType\">\n                                        {{gRow.GeneralName}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlFlagv\" formControlName=\"DangerousFlag\">\n                                    <option value=\"0\">DG Flag</option>\n                                    <option *ngFor=\"let gRow of dgflag\" [value]=\"gRow.value\">\n                                        {{gRow.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlStatusv\" formControlName=\"Status\">\n                                    <option value=\"0\">Active</option>\n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                        {{status.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n\n                        <div class=\"col-md-12 searchbtn alrt\">\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                            <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\n                        </div>\n\n\n                    </div>\n                </div>\n            </div>\n        </form>\n    </div>\n</div>\n");

/***/ }),

/***/ 73032:
/*!***************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/commonmaster.component.html ***!
  \***************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9 col-sm-9 col-lg-9 col-xl-9\">\n        <h4> Common Masters</h4>\n    </div>\n</div>\n<div class=\"card\">\n    <div class=\"card-body\">\n        <div class=\"row\">\n            <div class=\"col-md-4 panelbox\">\n                <div class=\"panel panel-default\">\n                    <div class=\"panel-heading\">Countries</div>\n                    <div class=\"panel-body\">\n                        <div class=\"col-md-12\">\n                            <button type=\"button\" class=\"btn btn-link\" [routerLink]=\"['/views/masters/commonmaster/country/countryview1']\" style=\"font-size: 14px; color: blue\">\n                                <i class=\"fa fa-angle-double-right\"></i> Country\n                            </button>\n                            <div style=\"border-bottom: dashed 1px;\"></div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <button type=\"button\" class=\"btn btn-link\" [routerLink]=\"['/views/masters/commonmaster/statemaster/statemasterview']\" style=\"font-size: 14px; color: blue\">\n                                <i class=\"fa fa-angle-double-right\"></i> State\n                            </button>\n                            <div style=\"border-bottom: dashed 1px;\"></div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <button type=\"button\" class=\"btn btn-link\" [routerLink]=\"['/views/masters/commonmaster/city/cityview']\" style=\"font-size: 14px; color: blue\">\n                                <i class=\"fa fa-angle-double-right\"></i> City\n                            </button>\n                            <div style=\"border-bottom: dashed 1px;\"></div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <button type=\"button\" class=\"btn btn-link\" [routerLink]=\"['/views/masters/commonmaster/currency/currencyview/currencyview']\" style=\"font-size: 14px; color: blue\">\n                                <i class=\"fa fa-angle-double-right\"></i> Currency\n                            </button>\n                            <div style=\"border-bottom: dashed 1px;\"></div>\n                        </div>\n                    </div>\n                </div>\n\n            </div>\n\n            <div class=\"col-md-4 panelbox\">\n                <div class=\"panel panel-default\">\n                    <div class=\"panel-heading\">Ports</div>\n                    <div class=\"panel-body\">\n\n                        <div class=\"col-md-12\">\n                            <button type=\"button\" class=\"btn btn-link\" [routerLink]=\"['/views/masters/commonmaster/port/portview']\" style=\"font-size: 14px; color: blue\">\n                                <i class=\"fa fa-angle-double-right\"></i>  Port (Sea, Air and ICD)\n                            </button>\n                            <div style=\"border-bottom: dashed 1px;\"></div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <button type=\"button\" class=\"btn btn-link\" [routerLink]=\"['/views/masters/commonmaster/terminal/terminalview']\" style=\"font-size: 14px; color: blue\"><i class=\"fa fa-angle-double-right\"></i>  Terminal </button>\n                            <div style=\"border-bottom: dashed 1px;\"></div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <button type=\"button\" class=\"btn btn-link\" [routerLink]=\"['/views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview']\" style=\"font-size: 14px; color: blue\"><i class=\"fa fa-angle-double-right\"></i>  Shipment Locations </button>\n                            <div style=\"border-bottom: dashed 1px;\"></div>\n                        </div>\n                    </div>\n                </div>\n\n            </div>\n\n            <div class=\"col-md-4 panelbox\">\n                <div class=\"panel panel-default\">\n                    <div class=\"panel-heading\">Commodity</div>\n                    <div class=\"panel-body\">\n                        <div class=\"col-md-12\">\n                            <button type=\"button\" class=\"btn btn-link\" [routerLink]=\"['/views/masters/commonmaster/commodity/commodityview']\" style=\"font-size: 14px; color: blue\"><i class=\"fa fa-angle-double-right\"></i>  Commodity</button>\n                            <div style=\"border-bottom: dashed 1px;\"></div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <button type=\"button\" class=\"btn btn-link\" [routerLink]=\"['/views/masters/commonmaster/cargopackage/cargopackageview']\" style=\"font-size: 14px; color: blue\">\n                                <i class=\"fa fa-angle-double-right\"></i>  Package Type\n                            </button>\n                            <div style=\"border-bottom: dashed 1px;\"></div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <button type=\"button\" class=\"btn btn-link\" [routerLink]=\"['/views/masters/commonmaster/contypemaster/contypemasterview']\" style=\"font-size: 14px; color: blue\">\n                                <i class=\"fa fa-angle-double-right\"></i>  Container Type\n                            </button>\n                            <div style=\"border-bottom: dashed 1px;\"></div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <button type=\"button\" class=\"btn btn-link\" [routerLink]=\"['/views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview']\" style=\"font-size: 14px; color: blue\">\n                                <i class=\"fa fa-angle-double-right\"></i>  Hazardous Classes\n                            </button>\n                            <div style=\"border-bottom: dashed 1px;\"></div>\n                        </div>\n                    </div>\n\n                </div>\n\n            </div>\n\n            <div class=\"col-md-4 panelbox\">\n                <div class=\"panel panel-default\">\n                    <div class=\"panel-heading\">\n                        UOM\n                    </div>\n                    <div class=\"panel-body\">\n\n                        <div class=\"col-md-12\">\n                            <button type=\"button\" class=\"btn btn-link\" style=\"font-size: 14px; color: blue\" [routerLink]=\"['/views/masters/commonmaster/uommaster/uommasterview']\">\n                                <i class=\"fa fa-angle-double-right\"></i>\n                                Unit of Measure\n                            </button>\n                            <div style=\"border-bottom: dashed 1px;\"></div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <button type=\"button\" class=\"btn btn-link\" [routerLink]=\"['/views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview']\" style=\"font-size: 14px; color: blue\"><i class=\"fa fa-angle-double-right\"></i>  UOM Conversions </button>\n\n                        </div>\n\n                    </div>\n                </div>\n\n            </div>\n\n\n        </div>\n    </div>\n</div>");

/***/ }),

/***/ 81716:
/*!******************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/contypemaster/contypemaster.component.html ***!
  \******************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9\">\n        <h4>Container Type Master</h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" (click)=\"onBack()\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<form [formGroup]=\"contypeForm\">\n\n    <div class=\"row\">\n        <div class=\"col-md-3\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Container Type</label>\n\n                        <input type=\"hidden\" formControlName=\"Size\" />\n                        <select name=\"Size\" id=\"ddlSize\" formControlName=\"SizeID\" class=\"form-control my-select\">\n                            <option *ngFor=\"let contype of dsCntrSizes\" [value]=\"contype.ID\">\n                                {{contype.GeneralName}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-3\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Equipment Size</label>\n                        <input type=\"hidden\" formControlName=\"Type\" />\n                        <select name=\"Type\" id=\"ddlType\" formControlName=\"EQTypeID\" class=\"form-control my-select\">\n                            <option *ngFor=\"let contype of dsCntrTypes\" [value]=\"contype.ID\">\n                                {{contype.GeneralName}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-3\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Container Type Description</label>\n\n                        <input type=\"text\" name=\"CntrTypeDesc\" formControlName=\"CntrTypeDesc\" autocomplete=\"off\" id=\"txtCntrTypeDesc\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n\n        <div class=\"col-md-3\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">ISO Code</label>\n                        <input type=\"text\" name=\"ISOCode\" formControlName=\"ISOCode\" autocomplete=\"off\" id=\"ddlISOCode\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-3\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n\n                    <div class=\"col-md-6\">\n                        <label class=\"str\">Length(in foot)</label>\n                        <input type=\"number\" name=\"Length\" formControlName=\"Length\" min=\"0\" autocomplete=\"off\" id=\"txtLength\" ng-model=\"txtTerminalName\" class=\"form-control\">\n                    </div>\n                    <div class=\"col-md-6\">\n                        <label class=\"str\">Width(in foot)</label>\n                        <input type=\"number\" name=\"Width\" formControlName=\"Width\" min=\"0\" autocomplete=\"off\" id=\"txtWidth\" ng-model=\"txtTerminalName\" class=\"form-control\">\n                    </div>\n                </div>\n\n            </div>\n        </div>\n\n        <div class=\"col-md-3\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n\n                    <div class=\"col-md-6\">\n                        <label class=\"str\">Height(in foot) </label>\n                        <input type=\"number\" name=\"Height\" formControlName=\"Height\" min=\"0\" autocomplete=\"off\" id=\"txtHeight\" ng-model=\"txtTerminalName\" class=\"form-control\">\n                    </div>\n                    <div class=\"col-md-6\">\n                        <label class=\"str\">TEU's </label>\n\n                        <input type=\"number\" name=\"TEUS\" formControlName=\"TEUS\" min=\"0\" autocomplete=\"off\" id=\"txtTEUS\" class=\"form-control\">\n                    </div>\n\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-3\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Tare Weight(in Kgs)</label>\n                        <input type=\"number\" name=\"TareWeight\" formControlName=\"TareWeight\" min=\"0\" autocomplete=\"off\" id=\"txtTareWeight\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n\n        <div class=\"col-md-3\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Max. Payload(in Kgs)</label>\n                        <input type=\"number\" name=\"MaxPayload\" formControlName=\"MaxPayload\" min=\"0\" autocomplete=\"off\" id=\"txtMaxPayload\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n\n\n\n        <div class=\"col-md-3\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Group</label>\n                        <select name=\"group\" formControlName=\"groupID\" id=\"ddlgroup\" class=\"form-control my-select\">\n\n                            <option *ngFor=\"let group of dsCntrGroup\" [value]=\"group.ID\">\n                                {{group.GeneralName}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-3\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label>Active</label>\n                        <select name=\"Status\" formControlName=\"status\" id=\"ddlStatus\" class=\"form-control my-select\">\n\n                            <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                {{status.viewValue}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n\n        <div class=\"col-md-6\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label>Remarks</label>\n                        <input type=\"text\" name=\"Remarks\" formControlName=\"Remarks\" autocomplete=\"off\" id=\"txtRemarks\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n\n    <div class=\"row alogtop\">\n        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt\">\n            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Save</button>\n        </div>\n        <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n    </div>\n\n</form>\n\n\n");

/***/ }),

/***/ 45465:
/*!****************************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/contypemaster/contypemasterview/contypemasterview.component.html ***!
  \****************************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\r\n\r\n<div class=\"row headtitle rotle\">\r\n    <div class=\"col-md-9\">\r\n        <h4>Container Type Master</h4>\r\n    </div>\r\n    <div class=\"col-md-3 alrt\">\r\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" [routerLink]=\"['/views/masters/commonmaster/contypemaster/contypemaster']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-9\">\r\n        <div class=\"card m-b-30\">\r\n            <div class=\"card-body leftcard\">\r\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\r\n                    <div class=\"row\">\r\n                        <div class=\"col-sm-12 master\">\r\n                            <table id=\"datatable-buttons\" class=\"table table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\r\n                                <thead>\r\n                                    <tr role=\"row\">\r\n                                        <th class=\"actwid\">\r\n                                            S.No\r\n                                        </th>\r\n                                        <th>\r\n                                            Equipment Size\r\n                                        </th>\r\n                                        <th>\r\n                                            Container Type\r\n                                        </th>\r\n                                        <th>\r\n                                            ISO Code\r\n                                        </th>\r\n                                        <th class=\"actwid\">Action</th>\r\n                                    </tr>\r\n                                </thead>\r\n\r\n                                <tbody>\r\n\r\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\r\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\"\r\n                                        [ngClass]=\"{'highlight' : dataItem.Type == selectedName}\">\r\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\r\n                                        <td class=\"alc\"><button class=\"btn btn-success bmd-btn-fab enqbtn\" [routerLink]=\"['/views/masters/commonmaster/contypemaster/contypemaster']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">{{dataItem.Size}} </button></td>\r\n                                        <td>{{dataItem.Type}}</td>\r\n                                        <td>{{dataItem.ISOCode}}</td>\r\n                                        <td>{{dataItem.StatusResult}}</td>\r\n                                        <!--<td class=\"alc\">\r\n                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/contypemaster/contypemaster']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\r\n                                <i class=\"material-icons\">edit</i>\r\n                            </button>\r\n                        </td>-->\r\n                                    </tr>\r\n                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"row page\" align=\"right\">\r\n\r\n\r\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\r\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\r\n                                <a (click)=\"setPage(1)\">First</a>\r\n                            </li>\r\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\r\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\r\n                            </li>\r\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\r\n                                <a (click)=\"setPage(page)\">{{page}}</a>\r\n                            </li>\r\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\r\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\r\n                            </li>\r\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\r\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\r\n                            </li>\r\n\r\n                            <li [ngClass]=\"{'pag-disable':pager.endIndex + 1 === pager.totalItems}\">\r\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\r\n                            </li>\r\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === pager.totalPages}\">\r\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\r\n                            </li>\r\n                        </ul>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div> <!-- end col -->\r\n\r\n    <div class=\"col-md-3\">\r\n        <form [formGroup]=\"searchForm\">\r\n            <div class=\"card m-b-30 sidesearch\">\r\n                <div class=\"card-body cpad\">\r\n                    <div class=\"row\">\r\n                        <div class=\"col-md-12\">\r\n                            <div class=\"form-group bmd-form-group\">\r\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"Type\" class=\"form-control\" placeholder=\"Container Type\">\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-md-12\">\r\n                            <div class=\"form-group bmd-form-group\">\r\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"Size\" class=\"form-control\" placeholder=\"Equipment Size\">\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-md-12\">\r\n                            <div class=\"form-group bmd-form-group\">\r\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"ISOCode\" class=\"form-control\" placeholder=\"ISO Code\">\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\r\n                            <div class=\"form-group bmd-form-group\">\r\n                                <select class=\"form-control my-select\" id=\"ddlStatusv\" formControlName=\"status\">\r\n                                    <option value=\"0\">Status</option>\r\n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\r\n                                        {{status.viewValue}}\r\n                                    </option>\r\n                                </select>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-md-12 searchbtn alrt\">\r\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\r\n                            <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>\r\n");

/***/ }),

/***/ 75938:
/*!******************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/country/country.component.html ***!
  \******************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9\">\n        <h4>Country Master</h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success bmd-btn-edit btn-raised btntop\" (click)=\"onBack()\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n<form [formGroup]=\"countryForm\">\n        <div class=\"row\">\n                <div class=\"col-md-4\">\n                    <div class=\"form-group\">\n                        <div class=\"row\">\n                            <div class=\"col-md-12\">\n                                <label class=\"str\">Country Code</label>\n                                <input type=\"text\" name=\"countryCode\" autocomplete=\"off\" formControlName=\"CountryCode\" id=\"txtCountryCode\" class=\"form-control\">\n                            </div>\n                        </div>\n                    </div>\n                </div>\n                <div class=\"col-md-4\">\n                    <div class=\"form-group\">\n                        <div class=\"row\">\n                            <div class=\"col-md-12\">\n                                <label class=\"str\">Country Name</label>\n                                <input type=\"text\" name=\"countryName\" autocomplete=\"off\" formControlName=\"CountryName\" id=\"txtCountryName\" class=\"form-control\">\n                            </div>\n                        </div>\n                    </div>\n                </div>\n                <div class=\"col-md-4\">\n                    <div class=\"form-group\">\n                        <div class=\"row\">\n                            <div class=\"col-md-12\">\n                                <label>Status</label>\n                                <select class=\"form-control my-select\" id=\"ddlStatus\" formControlName=\"Status\">\n                                    <option value=\"0\">Active</option>\n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                        {{status.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        <div class=\"row alogtop\">\n            <div class=\"col-md-12 alrt\">\n                <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Save</button>\n            </div>\n            <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n        </div>\n</form>");

/***/ }),

/***/ 36754:
/*!************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/country/countryview1/countryview1.component.html ***!
  \************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle rotle\">\n    <div class=\"col-md-9\">\n        <h4>Country Master</h4>\n    </div>\n\n    <div class=\"col-md-3 alrt\">\n\n        <button type=\"button\" class=\"btn btn-success btn-raised bmd-btn-edit btntop\" [routerLink]=\"['/views/masters/commonmaster/country/country']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n        <!--<button type=\"button\" class=\"btn btn-success btn-raised bmd-btn-edit btntop\" (click)=\"pdflink()\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>-->\n\n    </div>\n</div>\n\n\n<div class=\"row\">\n    <div class=\"col-md-9 padl0\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12 master\">\n                            <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr role=\"row\">\n                                        <th class=\"actwid\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Name: activate to sort column ascending\" style=\"width: 177.575px;\">\n                                            S.No\n                                        </th>\n                                        <th>\n                                            Country Code\n                                        </th>\n                                        <th>Country Name</th>\n                                        <th class=\"actwid\">Active</th>\n                                        <!--<th class=\" actwid\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Office: activate to sort column ascending\" style=\"width: 129.95px;\">Action</th>-->\n\n                                    </tr>\n                                </thead>\n\n                                <tbody>\n\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\"\n                                        [ngClass]=\"{'highlight' : dataItem.CountryCode == selectedName}\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td class=\"alc\"> <button class=\"btn btn-success bmd-btn-fab enqbtn\" [routerLink]=\"['/views/masters/commonmaster/country/country']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">{{dataItem.CountryCode}} </button></td>\n                                        <td>{{dataItem.CountryName}}</td>\n                                        <td>{{dataItem.StatusV}}</td>\n                                        <!--<td class=\"alc\">\n\n                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/country/country']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\n                                <i class=\"material-icons\">edit</i>\n                            </button>\n                        </td>-->\n\n                                    </tr>\n\n                                </tbody>\n                            </table>\n                        </div>\n                    </div>\n\n\n                    <div class=\"row page\" align=\"right\">\n\n\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{'pag-disable':pager.endIndex + 1 === pager.totalItems}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n                    </div>\n                </div>\n            </div>\n            </div>\n            </div>\n            <div class=\"col-md-3\">\n                <form [formGroup]=\"searchForm\" (ngSubmit)=\"onSubmit\">\n                    <div class=\"card m-b-30 sidesearch\">\n                        <div class=\"card-body cpad\">\n                            <div class=\"row\">\n                                <div class=\"col-md-12\">\n                                    <div class=\"form-group bmd-form-group\">\n\n                                        <input type=\"text\" autocomplete=\"off\" class=\"form-control\" name=\"countryCode\" formControlName=\"CountryCode\" placeholder=\"Country Code\">\n\n                                    </div>\n                                </div>\n                                <div class=\"col-md-12\">\n                                    <div class=\"form-group bmd-form-group\">\n                                        <input type=\"text\" autocomplete=\"off\" class=\"form-control\" name=\"countryCode\" formControlName=\"CountryName\" placeholder=\"Country Name\">\n                                    </div>\n                                </div>\n                                <div class=\"col-md-12\">\n                                    <div class=\"form-group bmd-form-group\">\n                                        <select class=\"form-control my-select statuscls\" id=\"ddlStatusv\" name=\"Status\" formControlName=\"Status\" placeholder=\"Status\">\n                                            <option value=\"0\">Active</option>\n                                            <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                                {{status.viewValue}}\n                                            </option>\n                                        </select>\n                                    </div>\n\n                                </div>\n\n                                <div class=\"col-md-12 searchbtn alrt\">\n                                    <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                                    <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\n                                </div>\n\n\n                            </div>\n                        </div>\n                    </div>\n                </form>\n            </div>\n\n        </div>\n\n");

/***/ }),

/***/ 47814:
/*!********************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/currency/currency.component.html ***!
  \********************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9 col-sm-9 col-lg-9 col-xl-9\">\n        <h4>Currency Master</h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" (click)=\"onBack()\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<form [formGroup]=\"CurrencyForm\">\n    <div class=\"row\">\n        <div class=\"col-md-4\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">State Name</label>\n                        <input type=\"text\" name=\"CurrencyCode\" formControlName=\"CurrencyCode\" autocomplete=\"off\" id=\"txtCurrencyCode\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n\n        <div class=\"col-md-4\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">State Code</label>\n                        <input type=\"text\" name=\"CurrencyName\" formControlName=\"CurrencyName\" id=\"txtCurrencyName\" autocomplete=\"off\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Symbol</label>\n                        <input type=\"text\" name=\"Symbol\" formControlName=\"Symbol\" id=\"txtSymbol\" autocomplete=\"off\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label>Country</label>\n                        <select name=\"Country\" id=\"ddlCountry\" formControlName=\"CountryID\" class=\"form-control my-select\">\n                            <option *ngFor=\"let gRow of dscountryItem\" [value]=\"gRow.ID\">\n                                {{gRow.Country}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n        <div class=\"col-md-4\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label>Active</label>\n                        <select name=\"Status\" formControlName=\"Status\" id=\"ddlStatus\" class=\"form-control my-select\">\n                            <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                {{status.viewValue}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n    </div>\n    <div class=\"row alogtop\">\n        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt\">\n            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-success btn-raised mb-0\">Save</button>\n        </div>\n        <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n    </div>\n</form>\n\n\n");

/***/ }),

/***/ 57832:
/*!*************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/currency/currencyview/currencyview.component.html ***!
  \*************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle rotle\">\r\n    <div class=\"col-md-9\">\r\n        <h4>Currency Master</h4>\r\n    </div>\r\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\r\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" [routerLink]=\"['/views/masters/commonmaster/currency/currency']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-9\">\r\n        <div class=\"card m-b-30\">\r\n            <div class=\"card-body leftcard\">\r\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\r\n                    <div class=\"row\">\r\n                        <div class=\"col-md-12 master\">\r\n                            <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\r\n                                <thead>\r\n                                    <tr role=\"row\">\r\n                                        <th class=\"actwid\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Name: activate to sort column ascending\" style=\"width: 177.575px;\">\r\n                                            S.No\r\n                                        </th>\r\n                                        <th>\r\n                                            Currency Code\r\n                                        </th>\r\n                                        <th>\r\n                                            Currency Name\r\n                                        </th>\r\n                                        <th>\r\n                                            Country\r\n                                        </th>\r\n                                        <th class=\"actwid\">\r\n                                            Active\r\n                                        </th>\r\n                                    </tr>\r\n                                </thead>\r\n\r\n                                <tbody>\r\n\r\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\r\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\"\r\n                                        [ngClass]=\"{'highlight' : dataItem.StateCode == selectedName}\">\r\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\r\n                                        <td class=\"alc\"> <button class=\"btn btn-success bmd-btn-fab enqbtn\" [routerLink]=\"['/views/masters/commonmaster/currency/currency']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">{{dataItem.CurrencyCode}} </button></td>\r\n                                        <td>{{dataItem.CurrencyName}}</td>\r\n                                        <td>{{dataItem.Country}}</td>\r\n                                        <td>{{dataItem.StatusResult}}</td>\r\n\r\n                                    </tr>\r\n                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"row page\" align=\"right\">\r\n\r\n\r\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\r\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\r\n                                <a (click)=\"setPage(1)\">First</a>\r\n                            </li>\r\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\r\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\r\n                            </li>\r\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\r\n                                <a (click)=\"setPage(page)\">{{page}}</a>\r\n                            </li>\r\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\r\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\r\n                            </li>\r\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\r\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\r\n                            </li>\r\n\r\n                            <li [ngClass]=\"{'pag-disable':pager.endIndex + 1 === pager.totalItems}\">\r\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\r\n                            </li>\r\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === pager.totalPages}\">\r\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\r\n                            </li>\r\n                        </ul>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div> <!-- end col -->\r\n\r\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\r\n        <form [formGroup]=\"searchForm\">\r\n            <div class=\"card m-b-30 sidesearch\">\r\n                <div class=\"card-body cpad\">\r\n                    <div class=\"row\">\r\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\r\n                            <div class=\"form-group bmd-form-group\">\r\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"CurrencyCode\" class=\"form-control\" placeholder=\"Currency Code\">\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\r\n                            <div class=\"form-group bmd-form-group\">\r\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"CurrencyName\" class=\"form-control\" placeholder=\"Currency Name\">\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\r\n                            <div class=\"form-group bmd-form-group\">\r\n                                <select name=\"Country\" id=\"ddlCountryv\" formControlName=\"CountryID\" class=\"form-control my-select\">\r\n                                    <option value=\"0\">Country</option>\r\n                                    <option *ngFor=\"let gRow of dscountryItem\" [value]=\"gRow.ID\">\r\n                                        {{gRow.Country}}\r\n                                    </option>\r\n                                </select>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\r\n                            <div class=\"form-group bmd-form-group\">\r\n                                <select class=\"form-control my-select\" id=\"ddlStatusv\" formControlName=\"Status\">\r\n                                    <option value=\"0\">Active</option>\r\n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\r\n                                        {{status.viewValue}}\r\n                                    </option>\r\n                                </select>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 searchbtn alrt\">\r\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\r\n                            <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>\r\n\r\n");

/***/ }),

/***/ 32151:
/*!********************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/hazardousclass/hazardousclass.component.html ***!
  \********************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9\">\n        <h4>  Hazardous Classes Master</h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btn-raised bmd-btn-edit btntop\" (click)=\"onBack()\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n<form [formGroup]=\"HazardousForm\">\n\n    <div class=\"row\">\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">                   \n                    <div class=\"col-md-12\">\n                        <label class=\"str\">\n                            Class Description\n                        </label>\n                        <input type=\"text\" name=\"LocationCode\" autocomplete=\"off\" formControlName=\"ClassDesc\" id=\"txtClassDesc\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">                 \n                    <div class=\"col-md-12\">\n                        <label class=\"str\">\n                            Division Description\n                        </label>\n                        <input type=\"text\" name=\"Location\" autocomplete=\"off\" formControlName=\"DivisionDesc\" id=\"txtDivisionDesc\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">         \n                    <div class=\"col-md-12\">\n                        <label>Active</label>\n                        <select class=\"form-control my-select\" id=\"ddlStatus\" formControlName=\"Status\">\n                            <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                {{status.viewValue}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n    \n        <div class=\"row alogtop\">\n            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt\">\n                <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-success btn-raised mb-0\">Save</button>\n            </div>\n            <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n        </div>\n \n</form>");

/***/ }),

/***/ 89972:
/*!*******************************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview.component.html ***!
  \*******************************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle rotle\">\n    <div class=\"col-md-9\">\n        <h4>\n            Hazardous Classes Master\n        </h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" [routerLink]=\"['/views/masters/commonmaster/hazardousclass/hazardousclass/']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<div class=\"row\">\n    <div class=\"col-9\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n                    <div class=\"row\">\n                        <div class=\"col-sm-12 master\">\n                            <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr role=\"row\">\n                                        <th class=\"actwid\">\n                                            S.No\n                                        </th>\n                                        <th>\n                                            Class Description\n                                        </th>\n                                        <th>\n                                            Division Description\n                                        </th>\n                                        <th class=\"actwid\">\n                                            Active\n                                        </th>\n                                        <!--<th class=\"actwid\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Office: activate to sort column ascending\" style=\"width: 129.95px;\">Action</th>-->\n                                    </tr>\n                                </thead>\n\n                                <tbody>\n\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td> <button class=\"btn btn-success bmd-btn-fab enqbtn\" [routerLink]=\"['/views/masters/commonmaster/hazardousclass/hazardousclass/']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">{{dataItem.ClassDesc}}</button></td>\n                                        <td>{{dataItem.DivisionDesc}}</td>\n                                        <td>{{dataItem.StatusResult}}</td>\n                                        <!--<td class=\"alc\">\n                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/hazardousclass/hazardousclass/']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\n                                <i class=\"material-icons\">edit</i>\n                            </button>\n                        </td>-->\n                                    </tr>\n                                </tbody>\n                            </table>\n                        </div>\n                    </div>\n                    <div class=\"row page\" align=\"right\">\n\n\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{'pag-disable':pager.endIndex + 1 === pager.totalItems}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n                    </div>\n                </div>\n            </div>\n        </div> <!-- end col -->\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n        <form [formGroup]=\"searchForm\">\n            <div class=\"card m-b-30 sidesearch\">\n                <div class=\"card-body cpad\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"ClassDesc\" class=\"form-control\" placeholder=\"Class Description\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"DivisionDesc\" class=\"form-control\" placeholder=\"Division Description\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlStatusv\" formControlName=\"Status\">\n                                    <option value=\"0\">Status</option>\n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                        {{status.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 searchbtn alrt\">\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                            <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </form>\n    </div>\n</div>\n");

/***/ }),

/***/ 87234:
/*!**************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/partymaster/partymaster.component.html ***!
  \**************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9 col-sm-9 col-lg-9 col-xl-9\">\n        <h4>Customer Master</h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success bmd-btn-edit btn-raised btntop\" [routerLink]=\"['/views/masters/commonmaster/partymaster/partymasterview']\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<div class=\"card\">\n    <div class=\"card-body \">\n        <div class=\"row\">\n            <div class=\"col-md-8 col-sm-8 col-lg-8 col-xl-8\">\n                <ul class=\"nav nav-pills nav-justified\" role=\"tablist\">\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link active show\" data-toggle=\"tab\" id=\"custab\" (click)=\"onPageTab(1)\" href=\"#profile-1\" role=\"tab\" aria-selected=\"true\">PARTY DETAILS</a>\n                    </li>\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link\" data-toggle=\"tab\" id=\"attachtab\" (click)=\"onPageTab(2)\" href=\"#profile-2\" role=\"tab\" aria-selected=\"false\">ATTACHMENTS</a>\n                    </li>\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link\" data-toggle=\"tab\" id=\"acctab\" (click)=\"onPageTab(2)\" href=\"#profile-3\" role=\"tab\" aria-selected=\"false\">ACCOUNTING LINK</a>\n                    </li>\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link\" data-toggle=\"tab\" id=\"crtab\" (click)=\"onPageTab(4)\" href=\"#profile-4\" role=\"tab\" aria-selected=\"false\">CREDIT LIMIT</a>\n                    </li>\n                    <li class=\"nav-item waves-effect waves-light\">\n                        <a class=\"nav-link\" data-toggle=\"tab\" id=\"emailtab\" (click)=\"onPageTab(5)\" href=\"#profile-5\" role=\"tab\" aria-selected=\"false\">EMAIL ALERTS</a>\n                    </li>\n                </ul>\n            </div>\n        </div>\n        <div class=\"row\">\n            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                <div class=\"tab-content\">\n\n                    <div class=\"tab-pane pt-3 active show\" id=\"profile-1\" role=\"tabpanel\">\n                        <div class=\"row\">\n                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n\n                                <div class=\"row\">\n                                    <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                        <form [formGroup]=\"partyForm\">\n                                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0 partydash\">\n\n                                                <div class=\"row\">\n                                                    <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                        <div class=\"form-group\">\n                                                            <div class=\"row\">\n                                                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                                                    <label class=\"str\">Party Name </label>\n                                                                    <input type=\"text\" formControlName=\"CustomerName\" id=\"txtCustomerName\" class=\"form-control\">\n                                                                    <input type=\"hidden\" id=\"HDIDv\" class=\"form-control\" formControlName=\"Itemsv1\" />\n                                                                    <input type=\"hidden\" id=\"HDIDSS\" class=\"form-control\" formControlName=\"BranchID\" />\n                                                                    <input type=\"hidden\" id=\"HDIDv\" class=\"form-control\" formControlName=\"BusinessType\" />\n\n                                                                </div>\n\n                                                            </div>\n                                                        </div>\n                                                    </div>\n\n                                                    <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                        <div class=\"form-group\">\n                                                            <div class=\"row\">\n                                                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                                                    <label class=\"lblfont str\">Country </label>\n                                                                    <select class=\"form-control my-select\" id=\"ddlCountry\" formControlName=\"CountryID\" (ngModelChange)=\"CountryChanged()\">\n                                                                        <option *ngFor=\"let gRow of dscountryItem\" [value]=\"gRow.ID\">\n                                                                            {{gRow.CountryName}}\n                                                                        </option>\n\n                                                                    </select>\n\n                                                                </div>\n\n                                                            </div>\n                                                        </div>\n                                                    </div>\n                                                </div>\n\n\n                                            </div>\n                                            <!--<div class=\"col-md-12 padlr0\" style=\"border-bottom:3px dashed #ccc; padding-bottom:4px;\">\n        <div class=\"row\">\n            <div class=\"col-md-12\">\n                <h5 style=\"margin-bottom:7px; margin-top:-3px; font-size:15px;color: #636161; font-weight: 600;text-decoration: underline;\">Division <span class=\"man\">*</span></h5>\n            </div>\n            <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n                <div class=\"form-group\">\n                    <div class=\"row\">\n\n                        <div class=\"col-md-12\">\n                            <span class=\"bmd-form-group is-filled is-focused\">\n                                <div class=\"checkbox\">\n                                    <label>\n                                        <input type=\"checkbox\" ng-true-value=\"1\" ng-false-value=\"0\" formControlName=\"IsNVOCC\"><span class=\"checkbox-decorator\">\n                                            <span class=\"check\"></span>\n                                            <div class=\"ripple-container\"></div>\n                                        </span> NVOCC\n                                    </label>\n                                </div>\n                            </span>\n                        </div>\n                    </div>\n                </div>\n            </div>\n            <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n                <div class=\"form-group\">\n                    <div class=\"row\">\n\n                        <div class=\"col-md-12\">\n                            <span class=\"bmd-form-group is-filled is-focused\">\n                                <div class=\"checkbox\">\n                                    <label>\n                                        <input type=\"checkbox\" ng-true-value=\"1\" ng-false-value=\"0\" formControlName=\"IsFF\"><span class=\"checkbox-decorator\"><span class=\"check\"></span><div class=\"ripple-container\"></div></span> FREIGHT FORWARDING\n                                    </label>\n                                </div>\n                            </span>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n    </div>-->\n                                        </form>\n                                        <div class=\"col-md-12 padlr0 partydash\">\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <h5 class=\"partylabel\">Division Details <span class=\"man\">*</span></h5>\n                                                </div>\n                                                <div class=\"col-md-12 padlr0 tblparty\">\n\n                                                    <div *ngFor=\"let BT of dsDivision\" class=\"chkvalues\">\n\n                                                        <label class=\"check\">\n                                                            <input type=\"checkbox\" id=\"chkDivision_{{BT.ID}}\" [value]=\"BT.ID\" ng-true-value=\"1\" ng-false-value=\"0\" [(ngModel)]=\"BT.IsTrue\">\n                                                            <!--<input type=\"checkbox\">-->\n                                                            {{BT.Division}}\n\n                                                        </label>\n                                                    </div>\n\n                                                </div>\n                                            </div>\n\n                                        </div>\n                                        <div class=\"col-md-12 padlr0 partydash alogtop\">\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <h5 class=\"partylabel\">Category <span class=\"man\">*</span></h5>\n                                                </div>\n                                                <div class=\"col-md-12 padlr0 tblparty\">\n                                                    <div *ngFor=\"let BT of dsBTItem\" class=\"chkvalues \">\n                                                        <label class=\"chkbox\">\n                                                            <input type=\"checkbox\" id=\"chkBusinessType_{{BT.ID}}\" [value]=\"BT.ID\" ng-true-value=\"1\" ng-false-value=\"0\" [(ngModel)]=\"BT.IsTrue\">\n                                                            <!--<input type=\"checkbox\">-->\n                                                            {{BT.BusinessType}}\n\n                                                        </label>\n                                                    </div>\n\n                                                </div>\n                                            </div>\n\n                                        </div>\n                                        <div class=\"col-md-12 padlr0 alogtop\">\n\n                                            <div class=\"row\">\n                                                <div class=\"col-md-12\">\n                                                    <h5 class=\"partylabel\">Branch Details <span class=\"man\">*</span></h5>\n                                                    <div class=\"row\">\n                                                        <div class=\"col-md-12\">\n                                                            <div class=\"row\">\n                                                                <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n                                                                    <div class=\"form-group\">\n                                                                        <div class=\"row\">\n                                                                            <div class=\"col-md-12\">\n                                                                                <label class=\"str\">City</label>\n                                                                                <select class=\"form-control my-select\" [(ngModel)]=\"CityID\" id=\"ddlCity\" [ngModelOptions]=\"{standalone: true}\" (ngModelChange)=\"BranchChanged()\">\n                                                                                    <option *ngFor=\"let gRow of dsCityItem\" [value]=\"gRow.ID\">{{gRow.CityName}}</option>\n                                                                                </select>\n                                                                            </div>\n\n                                                                        </div>\n                                                                    </div>\n                                                                </div>\n                                                                <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n                                                                    <div class=\"form-group\">\n                                                                        <div class=\"row\">\n                                                                            <div class=\"col-md-12\">\n                                                                                <label>State</label>\n                                                                                <select class=\"form-control my-select\" [(ngModel)]=\"StateID\" id=\"ddlState\" [ngModelOptions]=\"{standalone: true}\">\n                                                                                    <option *ngFor=\"let gRow of dsStateItem\" [value]=\"gRow.ID\"> {{gRow.StateName}}</option>\n                                                                                </select>\n                                                                            </div>\n\n                                                                        </div>\n                                                                    </div>\n                                                                </div>\n                                                                <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n                                                                    <div class=\"form-group\">\n                                                                        <div class=\"row\">\n                                                                            <div class=\"col-md-12\">\n                                                                                <label class=\"str\">Tel</label>\n                                                                                <input type=\"number\" id=\"txtTel\" autocomplete=\"off\" [(ngModel)]=\"TelNo\" class=\"form-control\" />\n                                                                            </div>\n\n                                                                        </div>\n                                                                    </div>\n                                                                </div>\n                                                                <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n                                                                    <div class=\"form-group\">\n                                                                        <div class=\"row\">\n                                                                            <div class=\"col-md-12\">\n                                                                                <label class=\"str\">Pin Code</label>\n                                                                                <input type=\"number\" id=\"txtPincode\" autocomplete=\"off\" [(ngModel)]=\"PinCode\" class=\"form-control\" />\n                                                                            </div>\n\n                                                                        </div>\n                                                                    </div>\n                                                                </div>\n\n                                                                <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                                    <div class=\"form-group\">\n                                                                        <div class=\"col-md-12 padlr0\">\n                                                                            <label class=\"str\">Address</label>\n                                                                            <textarea class=\"form-control\" autocomplete=\"off\" [(ngModel)]=\"Address\" id=\"txtLocAddress\" rows=\"5\" style=\"height:109px!important;\"></textarea>\n                                                                        </div>\n                                                                    </div>\n                                                                </div>\n                                                                <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                                    <div class=\"row\">\n                                                                        <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                                            <div class=\"form-group\">\n                                                                                <div class=\"row\">\n                                                                                    <div class=\"col-md-12\">\n                                                                                        <label>Email ID</label>\n                                                                                        <input type=\"text\" autocomplete=\"off\" id=\"txtEmailID\" [(ngModel)]=\"EmailID\" class=\"form-control\" />\n                                                                                    </div>\n\n                                                                                </div>\n                                                                            </div>\n                                                                        </div>\n                                                                        <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                                            <div class=\"form-group\">\n                                                                                <div class=\"row\">\n                                                                                    <div class=\"col-md-12\">\n                                                                                        <label class=\"str\">PIC Name</label>\n                                                                                        <input type=\"text\" autocomplete=\"off\" id=\"txtPic\" [(ngModel)]=\"PIC\" class=\"form-control\" />\n                                                                                    </div>\n                                                                                </div>\n                                                                            </div>\n                                                                        </div>\n\n                                                                        <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                                            <div class=\"form-group\">\n                                                                                <div class=\"col-md-12 padlr0\">\n                                                                                    <label>Branch</label>\n                                                                                    <input type=\"hidden\" id=\"HDIDv\" class=\"form-control\" [(ngModel)]=\"CID\" />\n                                                                                    <input type=\"hidden\" id=\"HDArrayIndex\" class=\"form-control\" [(ngModel)]=\"HDArrayIndex\" />\n                                                                                    <input type=\"text\" id=\"txtBranch\" [(ngModel)]=\"LocBranch\" class=\"form-control\" />\n\n                                                                                </div>\n                                                                            </div>\n                                                                        </div>\n                                                                        <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                                            <div class=\"form-group\">\n                                                                                <div class=\"col-md-12 padlr0\">\n                                                                                    <label class=\"str\">Status</label>\n\n                                                                                    <select class=\"form-control my-select\" [(ngModel)]=\"StatusID\" id=\"ddlStatus\" [ngModelOptions]=\"{standalone: true}\">\n                                                                                        <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                                                                            {{status.viewValue}}\n                                                                                        </option>\n                                                                                    </select>\n\n                                                                                </div>\n                                                                            </div>\n                                                                        </div>\n\n                                                                    </div>\n                                                                </div>\n\n                                                            </div>\n\n                                                        </div>\n                                                    </div>\n                                                </div>\n\n                                            </div>\n\n                                            <div class=\"col-md-12\">\n\n                                                <div class=\"row\">\n                                                    <div class=\"col-md-12 alrt padlr0\">\n                                                        <button type=\"submit\" (click)=\"AddBranch();\" class=\"btn btn-fill btn-success btn-raised\">\n\n                                                            ADD\n                                                        </button>\n\n                                                    </div>\n                                                    <div class=\"clearfix\"></div>\n                                                </div>\n\n                                                <div class=\"row alogtop\">\n                                                    <div class=\"col-md-12 padlr0\">\n                                                        <div class=\"material-datatables\" style=\"width:100%;overflow:scroll;\">\n\n                                                            <table class=\"table table-responsive table-striped table-bordered table-hover\" cellspacing=\"0\" width=\"100%\" style=\"width:100%\">\n                                                                <thead>\n                                                                    <tr>\n                                                                        <th class=\"actwid\">S.No</th>\n                                                                        <th>Branch</th>\n                                                                        <th>City</th>\n                                                                        <th>State</th>\n                                                                        <th>Tel</th>\n                                                                        <th>PinCode</th>\n                                                                        <th>EmailID</th>\n                                                                        <th>PIC</th>\n                                                                        <th>Address</th>\n                                                                        <th class=\"actwid\">Status</th>\n                                                                        <th class=\"disabled-sorting text-right actwid\">Actions</th>\n                                                                    </tr>\n                                                                </thead>\n\n                                                                <tbody>\n\n\n                                                                    <tr *ngFor=\"let gRow of DynamicGrid; let i= index\">\n                                                                        <td> {{i+1}}</td>\n                                                                        <td class=\"txtright\">\n                                                                            {{gRow.LocBranch}}\n\n                                                                        </td>\n                                                                        <td>\n                                                                            {{gRow.City}}\n\n\n                                                                        </td>\n                                                                        <td>\n                                                                            {{gRow.State}}\n\n\n                                                                        </td>\n\n                                                                        <td class=\"txtright\">\n                                                                            {{gRow.TelNo}}\n\n                                                                        </td>\n\n                                                                        <td class=\"txtright\">\n                                                                            {{gRow.PinCode}}\n\n                                                                        </td>\n                                                                        <td class=\"txtright\">\n                                                                            {{gRow.EmailID}}\n\n                                                                        </td>\n                                                                        <td class=\"txtright\">\n                                                                            {{gRow.PIC}}\n\n                                                                        </td>\n\n                                                                        <td class=\"txtright\">\n                                                                            {{gRow.Address}}\n\n                                                                        </td>\n                                                                        <td>\n                                                                            {{gRow.StatusResult}}\n\n\n                                                                        </td>\n                                                                        <td class=\"td-actions text-right bindgrid\">\n\n                                                                            <button type=\"button\" rel=\"tooltip\" (click)=\"Selectvalues(DynamicGrid,i)\" class=\"btn btn-success bmd-btn-fab\" data-original-title=\"\" title=\"\">\n                                                                                <i class=\"material-icons\">edit</i>\n                                                                            </button>\n                                                                            <button type=\"button\" rel=\"tooltip\" (click)=\"RemoveBranch(DynamicGrid,i,gRow.CID)\" class=\"btn btn-danger bmd-btn-fab\" data-original-title=\"\" title=\"\">\n                                                                                <i class=\"material-icons\">delete</i>\n                                                                            </button>\n                                                                        </td>\n\n                                                                    </tr>\n\n\n                                                                </tbody>\n\n\n                                                            </table>\n\n                                                        </div>\n                                                    </div>\n                                                </div>\n                                            </div>\n                                        </div>\n\n                                    </div>\n\n\n\n                                </div>\n\n                            </div>\n\n                        </div>\n\n                        <div class=\"card-footer padlr0\">\n                            <div class=\"col-md-12 alrt padlr0\">\n                                <button type=\"submit\" (click)=\"OnSubmit()\" class=\"btn btn-primary btn-raised mb-0\"><i class=\"fa fa-save\"></i> Submit</button>\n                            </div>\n\n                        </div>\n                    </div>\n                    \n                    <div class=\"tab-pane pt-3\" id=\"profile-2\" role=\"tabpanel\">\n                        <div class=\"col-md-12 padlr0\">\n                            <div class=\"material-datatables tblattach bkgtable\">\n                                <table class=\"table table-responsive table-striped table-bordered table-hover\" cellspacing=\"0\">\n                                    <thead>\n                                        <tr>\n                                            <th>Attach File</th>\n                                            <th>Attachment Type</th>\n                                            <th class=\"actwid\">Action</th>\n                                        </tr>\n                                    </thead>\n                                    <tbody>\n                                        <tr>\n\n\n                                            <td class=\"tabwid\">\n                                                <!--<span class=\"input-group-addon\">\n                                                <i class=\"fa fa-upload\">-->\n                                                <input type=\"file\" class=\"file-upload\" id=\"txtAttachFile\" [(ngModel)]=\"AttachFile\" (change)=\"onFileSelected($event)\">\n                                                <!--</i>-->\n                                                <!--</span>-->\n                                                <span class='label label-info' id=\"upload-file-info\"></span>\n                                                <!--<input type=\"hidden\" id=\"HDArrayIndex\" class=\"form-control\" ng-model=\"HDArrayIndex\" />\n                                                <input type=\"hidden\" id=\"HDIDv\" class=\"form-control\" ng-model=\"AID\" />-->\n                                            </td>\n                                            <td>\n                                                <select class=\"form-control my-select\" [(ngModel)]=\"AttachTypeID\" id=\"ddlAttachType\" [ngModelOptions]=\"{standalone: true}\">\n                                                    <option *ngFor=\"let gRow of dsAttachedDocumentTypes\" [value]=\"gRow.ID\">{{gRow.GeneralName}}</option>\n                                                </select>\n\n                                            </td>\n                                            <td class=\"td-actions text-right entrygrid actwid\">\n                                                <button type=\"button\" rel=\"tooltip\" (click)=\"AddAttach(gRow)\" class=\"btn btn-success bmd-btn-fab\" data-original-title=\"\" title=\"\">\n                                                    <i class=\"material-icons\">add</i>\n                                                </button>\n\n                                            </td>\n                                        </tr>\n                                    </tbody>\n\n                                </table>\n\n                            </div>\n                        </div>\n\n                        <div class=\"col-md-12 alogtop padlr0\">\n                            <div class=\"material-datatables tblattach bkgtable\">\n\n                                <table class=\"table table-responsive table-striped table-bordered table-hover\" cellspacing=\"0\">\n                                    <thead>\n                                        <tr>\n                                            <th class=\"actwid\">S.No</th>\n                                            <th>Attach File</th>\n                                            <th>Attachment Type</th>\n                                            <th class=\"actwid\">Action</th>\n                                        </tr>\n                                    </thead>\n                                    <tbody>\n                                        <tr *ngFor=\"let gRow of DynamicGridAttachLink; let i= index\">\n                                            <td> {{i+1}}</td>\n\n\n                                            <td class=\"tabwid\">\n                                                {{gRow.AttachFile}}\n                                                <!--<a href=\"#\" ng-click=\"DownloadFile(gRow.FileName);\" style=\"text-decoration:underline;\"></a>-->\n\n                                            </td>\n                                            <td>\n                                                {{gRow.AttachName}}\n\n                                                <!--<input type=\"hidden\" id=\"HDID\" class=\"form-control\" ng-model=\"gRow.AID\" />-->\n                                            </td>\n                                            <td class=\"td-actions text-right\">\n                                                <button type=\"button\" rel=\"tooltip\" (click)=\"RemoveAttach(DynamicGridAttachLink,$index,gRow.AID)\" class=\"btn btn-danger bmd-btn-fab\" data-original-title=\"\" title=\"\">\n                                                    <i class=\"material-icons\">delete</i>\n                                                </button>\n\n                                            </td>\n                                        </tr>\n                                    </tbody>\n                                    \n                                </table>\n\n                            </div>\n                        </div>\n\n                        <div class=\"card-footer padlr0\">\n                            <div class=\"col-md-12 alrt padlr0 alogtop\">\n                                <button type=\"submit\" (click)=\"RecordAttachSave();\" class=\"btn btn-primary btn-raised mb-0\"><i class=\"fa fa-save\"></i> Save</button>\n\n                            </div>\n                        </div>\n                    </div>\n                    \n                    <div class=\"tab-pane pt-3\" id=\"profile-3\" role=\"tabpanel\">\n\n                        <div class=\"row\">\n                            <div class=\"col-md-12\">\n\n                                <div class=\"row\">\n                                    <div class=\"col-md-12\">\n                                        <form [formGroup]=\"partyForm\">\n                                            <div class=\"col-md-12 more alrt\">\n                                                <div class=\"dropdown\">\n                                                    <button class=\"btn btn-secondary btnmore dropdown-toggle\" type=\"button\" id=\"dropdownMenuButton\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\n                                                        More\n                                                    </button>\n                                                    <div class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuButton\">\n                                                        <a class=\"dropdown-item\" href=\"#\">Merge to Vendor</a>\n                                                    </div>\n                                                </div>\n                                                <!--<button type=\"button\" class=\"btn btn-outline btnmore\">More Options</button>-->\n                                            </div>\n                                            <div class=\"col-md-12 padlr0\" style=\"border-bottom: 2px dashed #ccc;padding-bottom: 7px;margin-bottom: 12px;\">\n\n                                                <div class=\"row\">\n                                                    <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                        <div class=\"form-group\">\n                                                            <div class=\"row\">\n                                                                <div class=\"col-md-12\">\n                                                                    <label>Party Name </label>\n                                                                    <input type=\"text\" disabled formControlName=\"CustomerName\" id=\"txtCustomerName\" class=\"form-control\">\n                                                                    <input type=\"hidden\" id=\"HDIDv\" class=\"form-control\" formControlName=\"Itemsv1\" />\n                                                                    <!--<input type=\"hidden\" id=\"HDIDSS\" class=\"form-control\" formControlName=\"cusID\" />-->\n                                                                    <input type=\"hidden\" id=\"HDIDv\" class=\"form-control\" formControlName=\"BusinessType\" />\n\n                                                                </div>\n\n                                                            </div>\n                                                        </div>\n                                                    </div>\n\n                                                    <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                        <div class=\"form-group\">\n                                                            <div class=\"row\">\n                                                                <div class=\"col-md-12\">\n                                                                    <label class=\"lblfont\">Country </label>\n                                                                    <select class=\"form-control my-select\" disabled id=\"ddlCountry\" formControlName=\"CountryID\" (ngModelChange)=\"CountryChanged()\">\n                                                                        <option *ngFor=\"let gRow of dscountryItem\" [value]=\"gRow.ID\">\n                                                                            {{gRow.CountryName}}\n                                                                        </option>\n\n                                                                    </select>\n\n                                                                </div>\n\n                                                            </div>\n                                                        </div>\n                                                    </div>\n                                                </div>\n\n\n                                            </div>\n                                        </form>\n\n\n                                    </div>\n\n\n\n                                </div>\n                                <form [formGroup]=\"partyAcc\">\n                                    <div class=\"row padlr0\">\n                                        <div class=\"col-md-12 padlr0 partydash\">\n                                            <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                                <div class=\"form-group\">\n                                                    <div class=\"col-md-12 padlr0\">\n                                                        <label>Branch</label>\n\n                                                        <select class=\"form-control my-select\" [(ngModel)]=\"BranchID\" id=\"ddlBranch\" [ngModelOptions]=\"{standalone: true}\">\n                                                            <option *ngFor=\"let gRow of dsBranchList\" [value]=\"gRow.CID\">{{gRow.Branch}}</option>\n                                                        </select>\n\n                                                    </div>\n                                                </div>\n                                            </div>\n                                        </div>\n\n                                    </div>\n                                    <div class=\"row padlr0 alogtop\">\n                                        <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                            <div class=\"form-group\">\n                                                <div class=\"col-md-12 padlr0\">\n                                                    <label>GST Category</label>\n                                                    <select class=\"form-control my-select\" [(ngModel)]=\"GSTListID\" id=\"ddlGstlist\" [ngModelOptions]=\"{standalone: true}\">\n                                                        <option *ngFor=\"let gRow of dsGSTList\" [value]=\"gRow.ID\">{{gRow.GSTINTax}}</option>\n                                                    </select>\n                                                </div>\n                                            </div>\n\n                                        </div>\n                                        <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                            <div class=\"form-group\">\n                                                <div class=\"col-md-12 padlr0\">\n                                                    <label>GST No</label>\n                                                    <input type=\"text\" autocomplete=\"off\" [(ngModel)]=\"GSTNo\" id=\"txtGST\" class=\"form-control\" />\n                                                </div>\n                                            </div>\n                                        </div>\n                                        <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                            <div class=\"form-group\">\n                                                <div class=\"col-md-12 padlr0\">\n                                                    <label>Business Legal Name</label>\n                                                    <input type=\"text\" autocomplete=\"off\" [(ngModel)]=\"Legalname\" id=\"txtLegalname\" class=\"form-control\" />\n                                                </div>\n                                            </div>\n                                        </div>\n                                        <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                            <div class=\"form-group\">\n                                                <div class=\"col-md-12 padlr0\">\n                                                    <label>PAN</label>\n                                                    <input type=\"text\" autocomplete=\"off\" [(ngModel)]=\"PAN\" id=\"txtPAN\" class=\"form-control\" />\n                                                </div>\n                                            </div>\n                                        </div>\n                                        <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                            <div class=\"form-group\">\n                                                <div class=\"col-md-12 padlr0\">\n                                                    <label>TAN</label>\n                                                    <input type=\"text\" autocomplete=\"off\" id=\"txtTAN\" [(ngModel)]=\"TAN\" class=\"form-control\" />\n                                                </div>\n                                            </div>\n                                        </div>\n                                        <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                            <div class=\"form-group\">\n                                                <div class=\"col-md-12 padlr0\">\n                                                    <label>Place of Supply</label>\n                                                    <select class=\"form-control my-select\" [(ngModel)]=\"POSID\" id=\"ddlPOS\" [ngModelOptions]=\"{standalone: true}\">\n                                                        <option *ngFor=\"let gRow of dsBranchByPosItem\" [value]=\"gRow.ID\">{{gRow.StateName}}</option>\n                                                    </select>\n                                                </div>\n                                            </div>\n\n                                        </div>\n                                        <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                            <div class=\"form-group\">\n                                                <div class=\"col-md-12 padlr0\">\n                                                    <label>Currency</label>\n                                                    <select class=\"form-control my-select\" [(ngModel)]=\"CurrID\" id=\"ddlCurrency\" [ngModelOptions]=\"{standalone: true}\">\n                                                        <option *ngFor=\"let gRow of dsCurrList\" [value]=\"gRow.ID\">{{gRow.CurrencyCode}}</option>\n                                                    </select>\n                                                </div>\n                                            </div>\n\n                                        </div>\n                                    </div>\n\n                                </form>\n                            </div>\n\n\n                        </div>\n\n                        <div class=\"col-md-12\">\n\n                            <div class=\"row\">\n                                <div class=\"col-md-12 alrt padlr0\">\n                                    <button type=\"submit\" (click)=\"AddAccLink();\" class=\"btn btn-fill btn-primary btn-raised\">\n\n                                        ADD\n                                    </button>\n\n                                </div>\n                                <div class=\"clearfix\"></div>\n                            </div>\n\n                            <div class=\"row alogtop\">\n                                <div class=\"col-md-12 padlr0\">\n                                    <div class=\"material-datatables bkgtable\">\n\n                                        <table class=\"table table-responsive table-striped table-bordered table-hover\" cellspacing=\"0\" width=\"100%\" style=\"width:100%\">\n                                            <thead>\n                                                <tr>\n                                                    <th class=\"actwid\">S.No</th>\n                                                    <th>Branch</th>\n                                                    <th>GST Category</th>\n                                                    <th>GST No</th>\n                                                    <th>Customer Legal Name</th>\n                                                    <th>PAN</th>\n                                                    <th>TAN</th>\n                                                    <th>Place of Supply</th>\n                                                    <th>Currency</th>\n\n                                                    <th class=\"disabled-sorting text-right actwid\">Actions</th>\n                                                </tr>\n                                            </thead>\n\n                                            <tbody>\n\n\n                                                <tr *ngFor=\"let gRow of DynamicGridAccLink; let i= index\">\n                                                    <td> {{i+1}}</td>\n                                                    <td class=\"txtright\">\n                                                        {{gRow.Branch}}\n\n                                                    </td>\n                                                    <td>\n                                                        {{gRow.GSTINTax}}\n\n\n                                                    </td>\n                                                    <td>\n                                                        {{gRow.GSTNo}}\n\n\n                                                    </td>\n\n                                                    <td class=\"txtright\">\n                                                        {{gRow.Legalname}}\n\n                                                    </td>\n\n                                                    <td class=\"txtright\">\n                                                        {{gRow.PAN}}\n\n                                                    </td>\n                                                    <td class=\"txtright\">\n                                                        {{gRow.TAN}}\n\n                                                    </td>\n                                                    <td class=\"txtright\">\n                                                        {{gRow.POS}}\n\n                                                    </td>\n\n                                                    <td class=\"txtright\">\n                                                        {{gRow.CurrencyCode}}\n\n                                                    </td>\n\n                                                    <td class=\"td-actions text-right bindgrid\">\n\n                                                        <button type=\"button\" rel=\"tooltip\" (click)=\"SelectAccvalues(DynamicGridAccLink,i)\" class=\"btn btn-success bmd-btn-fab\" data-original-title=\"\" title=\"\">\n                                                            <i class=\"material-icons\">edit</i>\n                                                        </button>\n                                                        <button type=\"button\" rel=\"tooltip\" (click)=\"RemoveAccValues(DynamicGridAccLink,i,gRow.ID)\" class=\"btn btn-danger bmd-btn-fab\" data-original-title=\"\" title=\"\">\n                                                            <i class=\"material-icons\">delete</i>\n                                                        </button>\n                                                    </td>\n\n                                                </tr>\n\n\n                                            </tbody>\n\n\n                                        </table>\n\n                                    </div>\n                                </div>\n                            </div>\n                        </div>\n\n\n\n\n                        <div class=\"card-footer padlr0\">\n                            <div class=\"col-md-12 alrt padlr0\">\n                                <button type=\"submit\" (click)=\"OnSubmitAcc();\" class=\"btn btn-primary btn-raised mb-0\"><i class=\"fa fa-save\"></i> Save</button>\n                            </div>\n                            <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n                        </div>\n                    </div>\n                    \n                    <div class=\"tab-pane pt-3\" id=\"profile-4\" role=\"tabpanel\">\n                        <div class=\"row\">\n                            <div class=\"col-md-12\">\n\n                                <div class=\"row\">\n                                    <div class=\"col-md-12\">\n                                        <form [formGroup]=\"partyForm\">\n                                            <div class=\"col-md-12 more alrt\">\n                                                <div class=\"dropdown\">\n                                                    <button class=\"btn btn-secondary btnmore dropdown-toggle\" type=\"button\" id=\"dropdownMenuButton\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\n                                                        More\n                                                    </button>\n                                                    <div class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuButton\">\n                                                        <a class=\"dropdown-item\" href=\"#\">Credit History</a>\n                                                    </div>\n                                                </div>\n                                                <!--<button type=\"button\" class=\"btn btn-outline btnmore\">Credit History</button>-->\n                                            </div>\n                                            <div class=\"col-md-12 padlr0 partydash\">\n\n                                                <div class=\"row\">\n                                                    <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                        <div class=\"form-group\">\n                                                            <div class=\"row\">\n                                                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                                                    <label>Party Name </label>\n                                                                    <input type=\"text\" disabled formControlName=\"CustomerName\" id=\"txtCustomerName\" class=\"form-control\">\n                                                                    <input type=\"hidden\" id=\"HDIDv\" class=\"form-control\" formControlName=\"Itemsv1\" />\n                                                                    <!--<input type=\"hidden\" id=\"HDIDSS\" class=\"form-control\" formControlName=\"cusID\" />-->\n                                                                    <input type=\"hidden\" id=\"HDIDv\" class=\"form-control\" formControlName=\"BusinessType\" />\n\n                                                                </div>\n\n                                                            </div>\n                                                        </div>\n                                                    </div>\n\n                                                    <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                        <div class=\"form-group\">\n                                                            <div class=\"row\">\n                                                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                                                    <label class=\"lblfont\">Country </label>\n                                                                    <select class=\"form-control my-select\" disabled id=\"ddlCountry\" formControlName=\"CountryID\" (ngModelChange)=\"CountryChanged()\">\n                                                                        <option *ngFor=\"let gRow of dscountryItem\" [value]=\"gRow.ID\">\n                                                                            {{gRow.CountryName}}\n                                                                        </option>\n\n                                                                    </select>\n\n                                                                </div>\n\n                                                            </div>\n                                                        </div>\n                                                    </div>\n                                                </div>\n\n\n                                            </div>\n                                        </form>\n\n\n                                    </div>\n\n\n\n                                </div>\n\n                                <div class=\"row\">\n                                    <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0 partydash\">\n                                        <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                            <div class=\"form-group\">\n                                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0\">\n                                                    <label>Branch</label>\n                                                    <select class=\"form-control my-select\" [(ngModel)]=\"BranchID\" id=\"ddlCrBranch\" [ngModelOptions]=\"{standalone: true}\">\n                                                        <option *ngFor=\"let gRow of dsBranchList\" [value]=\"gRow.CID\">{{gRow.Branch}}</option>\n                                                    </select>\n\n                                                </div>\n                                            </div>\n                                        </div>\n                                    </div>\n\n                                </div>\n                                <div class=\"row alogtop padlr0\">\n                                    <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                        <div class=\"form-group\">\n                                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0\">\n                                                <label>Credit Days</label>\n                                                <input type=\"text\" autocomplete=\"off\" [(ngModel)]=\"CreditDays\" id=\"txtCrDays\" class=\"form-control\" />\n                                            </div>\n                                        </div>\n\n                                    </div>\n                                    <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                        <div class=\"form-group\">\n                                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0\">\n                                                <label>Credit Limit</label>\n                                                <input type=\"text\" autocomplete=\"off\" [(ngModel)]=\"CreditLimit\" id=\"txtCrLmt\" class=\"form-control\" />\n                                            </div>\n                                        </div>\n                                    </div>\n                                    <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                        <div class=\"form-group\">\n                                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 palr0\">\n                                                <label>Approved By</label>\n                                                <select class=\"form-control my-select\" [(ngModel)]=\"UserID\" id=\"ddlUser\" [ngModelOptions]=\"{standalone: true}\">\n                                                    <option *ngFor=\"let gRow of dsUserList\" [value]=\"gRow.ID\">{{gRow.UserName}}</option>\n                                                </select>\n                                            </div>\n                                        </div>\n                                    </div>\n                                    <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                        <div class=\"form-group\">\n                                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0\">\n                                                <label>Effective Date</label>\n                                                <input type=\"date\" autocomplete=\"off\" [(ngModel)]=\"EffectiveDate\" id=\"txtEffDate\" class=\"form-control\" />\n                                            </div>\n                                        </div>\n                                    </div>\n                                    <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                        <div class=\"form-group\">\n                                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0\">\n                                                <label>Status</label>\n\n                                                <select class=\"form-control my-select\" [(ngModel)]=\"StatusCrID\" id=\"ddlCrStatus\" [ngModelOptions]=\"{standalone: true}\">\n                                                    <option *ngFor=\"let status of statusCrvalues\" [value]=\"status.value\">\n                                                        {{status.viewValue}}\n                                                    </option>\n                                                </select>\n                                            </div>\n                                        </div>\n                                    </div>\n\n                                </div>\n\n\n                            </div>\n\n\n                        </div>\n\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n\n                            <div class=\"row\">\n                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt padlr0\">\n                                    <button type=\"submit\" (click)=\"AddCrLink();\" class=\"btn btn-fill btn-primary btn-raised\">\n\n                                        ADD\n                                    </button>\n\n                                </div>\n                                <div class=\"clearfix\"></div>\n                            </div>\n\n                            <div class=\"row alogtop\">\n                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0\">\n                                    <div class=\"material-datatables partytbl\">\n\n                                        <table class=\"table table-responsive table-striped table-bordered table-hover\" cellspacing=\"0\" width=\"100%\">\n                                            <thead>\n                                                <tr>\n                                                    <th class=\"actwid\">S.No</th>\n                                                    <th>Branch</th>\n                                                    <th>Credit Days</th>\n                                                    <th>Credit Limit</th>\n                                                    <th>Approved By</th>\n                                                    <th>Effective Date</th>\n                                                    <th>Status</th>\n\n\n                                                    <th class=\"disabled-sorting text-right actwid\">Actions</th>\n                                                </tr>\n                                            </thead>\n\n                                            <tbody>\n\n\n                                                <tr *ngFor=\"let gRow of DynamicGridCrLink; let i= index\">\n                                                    <td> {{i+1}}</td>\n                                                    <td class=\"txtright\">\n                                                        {{gRow.Branch}}\n\n                                                    </td>\n                                                    <td>\n                                                        {{gRow.CreditDays}}\n\n\n                                                    </td>\n                                                    <td>\n                                                        {{gRow.CreditLimit}}\n\n\n                                                    </td>\n\n                                                    <td class=\"txtright\">\n                                                        {{gRow.ApprovedName}}\n\n                                                    </td>\n\n                                                    <td class=\"txtright\">\n                                                        {{gRow.EffectiveDate}}\n\n                                                    </td>\n                                                    <td class=\"txtright\">\n                                                        {{gRow.StatusV}}\n\n                                                    </td>\n\n\n                                                    <td class=\"td-actions text-right bindgrid\">\n\n                                                        <button type=\"button\" rel=\"tooltip\" (click)=\"SelectCrvalues(DynamicGridCrLink,i)\" class=\"btn btn-success bmd-btn-fab\" data-original-title=\"\" title=\"\">\n                                                            <i class=\"material-icons\">edit</i>\n                                                        </button>\n                                                        <button type=\"button\" rel=\"tooltip\" (click)=\"RemoveCrvalues(DynamicGridCrLink,i,gRow.ID)\" class=\"btn btn-danger bmd-btn-fab\" data-original-title=\"\" title=\"\">\n                                                            <i class=\"material-icons\">delete</i>\n                                                        </button>\n                                                    </td>\n\n                                                </tr>\n\n\n                                            </tbody>\n\n\n                                        </table>\n\n                                    </div>\n                                </div>\n                            </div>\n                        </div>\n\n\n\n\n                        <div class=\"card-footer padlr0\">\n                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt padlr0\">\n                                <button type=\"submit\" (click)=\"OnSubmitCr()\" class=\"btn btn-primary btn-raised mb-0\"><i class=\"fa fa-save\"></i> Save</button>\n                            </div>\n                            <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n                        </div>\n                    </div>\n                    \n                    <div class=\"tab-pane pt-3\" id=\"profile-5\" role=\"tabpanel\">\n                        <div class=\"row\">\n                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n\n                                <div class=\"row\">\n                                    <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                        <form [formGroup]=\"partyForm\">\n                                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0 partydash\">\n\n                                                <div class=\"row\">\n                                                    <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                        <div class=\"form-group\">\n                                                            <div class=\"row\">\n                                                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                                                    <label>Party Name </label>\n                                                                    <input type=\"text\" disabled formControlName=\"CustomerName\" id=\"txtCustomerName\" class=\"form-control\">\n                                                                    <input type=\"hidden\" id=\"HDIDv\" class=\"form-control\" formControlName=\"Itemsv1\" />\n                                                                    <!--<input type=\"hidden\" id=\"HDIDSS\" class=\"form-control\" formControlName=\"cusID\" />-->\n                                                                    <input type=\"hidden\" id=\"HDIDv\" class=\"form-control\" formControlName=\"BusinessType\" />\n\n                                                                </div>\n\n                                                            </div>\n                                                        </div>\n                                                    </div>\n\n                                                    <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                                                        <div class=\"form-group\">\n                                                            <div class=\"row\">\n                                                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                                                    <label class=\"lblfont\">Country </label>\n                                                                    <select class=\"form-control my-select\" disabled id=\"ddlCountry\" formControlName=\"CountryID\" (ngModelChange)=\"CountryChanged()\">\n                                                                        <option *ngFor=\"let gRow of dscountryItem\" [value]=\"gRow.ID\">\n                                                                            {{gRow.CountryName}}\n                                                                        </option>\n\n                                                                    </select>\n\n                                                                </div>\n\n                                                            </div>\n                                                        </div>\n                                                    </div>\n                                                </div>\n\n\n                                            </div>\n                                        </form>\n\n\n                                    </div>\n\n\n\n                                </div>\n\n                                <div class=\"row\">\n\n\n                                </div>\n                                <div class=\"row padlr0\">\n                                    <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                        <div class=\"form-group\">\n                                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0\">\n                                                <label>Branch</label>\n                                                <input type=\"hidden\" id=\"HDcusID\" class=\"form-control\" [(ngModel)]=\"CusID\" />\n                                                <select class=\"form-control my-select\" [(ngModel)]=\"BranchID\" id=\"ddlAlertBranch\" [ngModelOptions]=\"{standalone: true}\">\n                                                    <option *ngFor=\"let gRow of dsBranchList\" [value]=\"gRow.CID\">{{gRow.Branch}}</option>\n                                                </select>\n                                            </div>\n                                        </div>\n                                    </div>\n                                    <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                        <div class=\"form-group\">\n                                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0\">\n                                                <label>Alert Type</label>\n                                                <select class=\"form-control my-select\" [(ngModel)]=\"AlertTypeID\" id=\"ddlAlertType\" [ngModelOptions]=\"{standalone: true}\">\n                                                    <option *ngFor=\"let gRow of dsAlertTypeList\" [value]=\"gRow.ID\">{{gRow.GeneralName}}</option>\n                                                </select>\n                                            </div>\n                                        </div>\n                                    </div>\n\n                                    <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                        <div class=\"form-group\">\n                                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0\">\n                                                <label>Email-ID</label>\n                                                <input type=\"text\" autocomplete=\"off\" [(ngModel)]=\"EmailAlertID\" id=\"txtEmailAlertID\" class=\"form-control\" />\n                                            </div>\n                                        </div>\n\n                                    </div>\n                                    <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt\">\n                                        <div class=\"form-group\">\n                                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0\">\n                                                <label>&nbsp;</label>\n                                                <button type=\"submit\" (click)=\"AddEmailLink();\" class=\"btn btn-fill btn-success btn-raised\" style=\"margin-top:20px;\">\n                                                    ADD\n                                                </button>\n                                            </div>\n                                        </div>\n                                     \n\n                                    </div>\n                                </div>\n\n\n                            </div>\n\n\n                        </div>\n\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n\n\n                            <div class=\"row alogtop\">\n                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0\">\n                                    <div class=\"material-datatables partytbl\">\n\n                                        <table class=\"table table-responsive table-striped table-bordered table-hover\" cellspacing=\"0\">\n                                            <thead>\n                                                <tr>\n                                                    <th class=\"actwid\">S.No</th>\n                                                    <th>Branch</th>\n                                                    <th>Alert Type</th>\n                                                    <th>Email ID</th>\n\n\n                                                    <th class=\"disabled-sorting text-right actwid\">Actions</th>\n                                                </tr>\n                                            </thead>\n\n                                            <tbody>\n\n\n                                                <tr *ngFor=\"let gRow of DynamicGridAlertLink; let i= index\">\n                                                    <td> {{i+1}}</td>\n                                                    <td class=\"txtright\">\n                                                        {{gRow.Branch}}\n\n                                                    </td>\n                                                    <td>\n                                                        {{gRow.AlertType}}\n\n\n                                                    </td>\n                                                    <td>\n                                                        {{gRow.EmailAlertID}}\n\n\n                                                    </td>\n\n\n                                                    <td class=\"td-actions text-right bindgrid\">\n\n                                                        <button type=\"button\" rel=\"tooltip\" (click)=\"SelectEmailAlert(DynamicGridAlertLink,i)\" class=\"btn btn-success bmd-btn-fab\" data-original-title=\"\" title=\"\">\n                                                            <i class=\"material-icons\">edit</i>\n                                                        </button>\n                                                        <button type=\"button\" rel=\"tooltip\" (click)=\"RemoveAlertvalues(DynamicGridAlertLink,i,gRow.ID)\" class=\"btn btn-danger bmd-btn-fab\" data-original-title=\"\" title=\"\">\n                                                            <i class=\"material-icons\">delete</i>\n                                                        </button>\n                                                    </td>\n\n                                                </tr>\n\n\n                                            </tbody>\n\n\n                                        </table>\n\n                                    </div>\n                                </div>\n                            </div>\n                        </div>\n\n\n\n\n                        <div class=\"card-footer padlr0\">\n                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt padlr0\">\n                                <button type=\"submit\" (click)=\"OnSubmitEmailAlert()\" class=\"btn btn-primary btn-raised mb-0\"><i class=\"fa fa-save\"></i> Save</button>\n                            </div>\n                            <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n\n</div>\n\n");

/***/ }),

/***/ 63213:
/*!**********************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/partymaster/partymasterview/partymasterview.component.html ***!
  \**********************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9\">\n        <h4>Customer Master</h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btn-raised bmd-btn-edit btntop\" [routerLink]=\"['/views/masters/commonmaster/partymaster/partymaster']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n\n<div class=\"row\">\n    <div class=\"col-9\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12\" style=\"text-align:right;\">\n                            <!--<span style=\"font-size:13px; margin-right:0px;\">Download</span><a ng-click=\"btnPrint();\" style=\"color:#18aa08;font-size:16px; margin-right:20px;\"> <i class=\"fa fa-file-excel-o\"></i></a>-->\n                        </div>\n                        <div class=\"col-sm-12\">\n                            <table id=\"datatable-buttons\" class=\"table table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr role=\"row\">\n                                        <th class=\"actwid\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Name: activate to sort column ascending\" style=\"width: 177.575px;\">\n                                            S.No\n                                        </th>\n                                        <th class=\"sorting\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Name: activate to sort column ascending\" style=\"width: 177.575px;\" (click)=\"sort('CustomerName')\">\n                                            Customer Name\n                                        </th>\n                                        <th class=\"sorting\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Name: activate to sort column ascending\" style=\"width: 177.575px;\" (click)=\"sort('CountryName')\">\n                                            Country Name\n                                        </th>\n\n                                        <th class=\"actwid\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Office: activate to sort column ascending\" style=\"width: 129.95px;\">Action</th>\n                                    </tr>\n                                </thead>\n\n                                <tbody>\n\n                                    <tr *ngFor=\"let dataItem of pagedItems;let i = index\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td>{{dataItem.CustomerName}}</td>\n                                        <td>{{dataItem.CountryName}}</td>\n                                        <td class=\"alc\">\n                                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/partymaster/partymaster']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\n                                                <i class=\"material-icons\">edit</i>\n                                            </button>\n                                        </td>\n\n                                </tbody>\n                            </table>\n                        </div>\n                    </div>\n                    <div class=\"row page\" align=\"right\">\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{disabled:pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{disabled:pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{disabled:pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{disabled:pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n\n    <div class=\"col-md-3\">\n        <form [formGroup]=\"searchForm\">\n            <div class=\"card m-b-30 sidesearch\">\n                <div class=\"card-body cpad\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" formControlName=\"CustomerName\" class=\"form-control\" placeholder=\"Party Name\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlCountry\" formControlName=\"CountryID\">\n                                    <option  value=\"0\">Country</option>\n                                    <option *ngFor=\"let gRow of dscountryItem\" [value]=\"gRow.ID\">\n                                        {{gRow.CountryName}}\n                                    </option>\n\n                                </select>\n                            </div>\n                        </div>\n\n                        <div class=\"col-md-12 searchbtn alrt\">\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                            <button class=\"btn btn-raised btn-danger mb-0\" (click)=\"clearSearch()\">Clear<div class=\"ripple-container\"></div></button>\n                        </div>\n\n\n                    </div>\n                </div>\n            </div>\n        </form>\n    </div>\n</div>\n");

/***/ }),

/***/ 13405:
/*!************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/port/port.component.html ***!
  \************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9 col-sm-9 col-lg-9 col-xl-9\">\n        <h4>Port Master</h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btn-raised btntop bmd-btn-edit\" (click)=\"onBack()\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<form [formGroup]=\"portForm\">\n    <div class=\"row\">\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Port Code</label>\n                        <input type=\"text\" id=\"txtPortCode\" name=\"PortCode\" autocomplete=\"off\" formControlName=\"PortCode\" class=\"form-control\" />\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Port Name</label>\n                        <input type=\"text\" formControlName=\"PortName\" autocomplete=\"off\" name=\"PortName\" id=\"txtPortName\" class=\"form-control\" />\n                    </div>\n                </div>\n            </div>\n        </div>\n\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Country </label>\n                        <select class=\"form-control my-select\" id=\"ddlCountry\" name=\"ddlCountry\" formControlName=\"CountryID\" (ngModelChange)=\"CountryChange()\">\n                            <option *ngFor=\"let gRow of dscountryItem\" [value]=\"gRow.ID\">\n                                {{gRow.CountryName}}\n                            </option>\n\n                        </select>\n\n\n                    </div>\n                </div>\n            </div>\n        </div>\n\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label>Office Location</label>\n                        <select class=\"form-control my-select\" id=\"ddlGeoLocation\" formControlName=\"OffLocID\">\n                            <option *ngFor=\"let gRow of ddGeoLocationItem\" [value]=\"gRow.ID\">\n                                {{gRow.OfficeLoc}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n\n        <div class=\"col-md-3\">\n\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label>Active</label>\n                        <select class=\"form-control my-select\" id=\"ddlStatus\" formControlName=\"Status\">\n                            <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                {{status.viewValue}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n\n        <div class=\"col-md-5\" style=\"align-self: self-end!important;\">\n            <div class=\"row\">\n                <div class=\"col-md-4 col-sm-2 col-lg-3 col-xl-3\">\n                    <div class=\"form-group\">\n                        <div class=\"row\">\n\n                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                <span class=\"bmd-form-group is-filled is-focused\">\n                                    <div class=\"checkbox\">\n                                        <label>\n                                            <input type=\"checkbox\" id=\"SeaChk\" ng-true-value=\"1\" ng-false-value=\"0\" formControlName=\"IsSeaPort\">\n                                            <span class=\"checkbox-decorator\">\n                                                <span class=\"check\"></span>\n                                                <div class=\"ripple-container\"></div>\n                                            </span> Sea Port\n                                        </label>\n                                    </div>\n                                </span>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n                <div class=\"col-md-4 col-sm-3 col-lg-3 col-xl-3\">\n                    <div class=\"form-group\">\n                        <div class=\"row\">\n\n                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                <span class=\"bmd-form-group is-filled is-focused\">\n                                    <div class=\"checkbox\">\n                                        <label>\n                                            <input type=\"checkbox\" ng-true-value=\"1\" ng-false-value=\"0\" id=\"IsICDPort\" formControlName=\"IsICDPort\"><span class=\"checkbox-decorator\"><span class=\"check\"></span><div class=\"ripple-container\"></div></span> ICD Port\n                                        </label>\n                                    </div>\n                                </span>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n                <div class=\"col-md-4 col-sm-3 col-lg-3 col-xl-3\">\n                    <div class=\"form-group\">\n                        <div class=\"row\">\n\n                            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                <span class=\"bmd-form-group is-filled is-focused\">\n                                    <div class=\"checkbox\">\n                                        <label>\n                                            <input type=\"checkbox\" ng-true-value=\"1\" ng-false-value=\"0\" id=\"IsAirPort\" formControlName=\"IsAirPort\"><span class=\"checkbox-decorator\"><span class=\"check\"></span><div class=\"ripple-container\"></div></span> Air Port\n                                        </label>\n                                    </div>\n                                </span>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n\n            </div>\n        </div>\n    </div>\n\n    <div class=\"row alogtop\">\n        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt\">\n            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Save</button>\n        </div>\n        <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n    </div>\n\n\n</form>\n");

/***/ }),

/***/ 89349:
/*!*************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/port/portview/portview.component.html ***!
  \*************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle rotle\">\n    <div class=\"col-md-9 col-sm-9 col-lg-9 col-xl-9\">\n        <h4>Port Master</h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" [routerLink]=\"['/views/masters/commonmaster/port/port']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n\n<div class=\"row\">\n    <div class=\"col-9\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n\n                    <div class=\"row\">\n                        <div class=\"col-sm-12 master\">\n                            <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr role=\"row\">\n                                        <th class=\"actwid\">\n                                            S.No\n                                        </th>\n                                        <th>\n                                            Port Code\n                                        </th>\n                                        <th>Port Name</th>\n                                        <th>Country Code</th>\n                                        <th>Sea Port</th>\n                                        <th>ICD Port</th>\n                                        <th>Air Port</th>\n                                        <th class=\"actwid\">Active</th>\n                                        <!--<th class=\"actwid\">Action</th>-->\n                                    </tr>\n                                </thead>\n\n                                <tbody>\n\n                                    <tr role=\"row\" *ngFor=\"let dataItem of pagedItems;let i = index\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td class=\"alc\"> <button class=\"btn btn-success bmd-btn-fab enqbtn\" [routerLink]=\"['/views/masters/commonmaster/port/port']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">{{dataItem.PortCode}} </button></td>\n                                        <td>{{dataItem.PortName}}</td>\n                                        <td>{{dataItem.CountryCode}}</td>\n                                        <td>{{dataItem.SeaPort}}</td>\n                                        <td>{{dataItem.ICDPort}}</td>\n                                        <td>{{dataItem.AirPort}}</td>\n                                        <td>{{dataItem.StatusResult}}</td>\n                                        <!--<td class=\"alc\">\n\n                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/port/port']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\n                                <i class=\"material-icons\">edit</i>\n                            </button>\n                        </td>-->\n                                    </tr>\n\n                                </tbody>\n                            </table>\n                        </div>\n                    </div>\n                    <div class=\"row page\" align=\"right\">\n\n\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{'pag-disable':pager.endIndex + 1 === pager.totalItems}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n\n    <div class=\"col-md-3 \">\n        <form [formGroup]=\"searchForm\">\n            <div class=\"card m-b-30 sidesearch\">\n                <div class=\"card-body cpad\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" class=\"form-control\" formControlName=\"PortCode\" placeholder=\"Port Code\" />\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" class=\"form-control\" formControlName=\"PortName\" placeholder=\"Port Name\" />\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" class=\"form-control\" formControlName=\"CountryCode\" placeholder=\"Country Code\" />\n                            </div>\n                        </div>\n\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlSeaPort\" formControlName=\"SeaPort\">\n                                    <option value=\"0\">Sea Port</option>\n                                    <option *ngFor=\"let seaport of seaportvalues\" [value]=\"seaport.value\">\n                                        {{seaport.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlICDPort\" formControlName=\"ICDPort\">\n                                    <option value=\"0\">ICD Port</option>\n                                    <option *ngFor=\"let icdport of icdportvalues\" [value]=\"icdport.value\">\n                                        {{icdport.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlAirPort\" formControlName=\"AirPort\">\n                                    <option value=\"0\">Air Port</option>\n                                    <option *ngFor=\"let airport of airportvalues\" [value]=\"airport.value\">\n                                        {{airport.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlStatusv\" formControlName=\"Status\">\n                                    <option value=\"0\">Active</option>\n                                    <option *ngFor=\"let statusv of statusvalues\" [value]=\"statusv.value\">\n                                        {{statusv.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 searchbtn alrt\">\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                            <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\n                        </div>\n\n\n                    </div>\n                </div>\n            </div>\n        </form>\n    </div>\n</div>\n\n");

/***/ }),

/***/ 11611:
/*!**************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/shipmentlocations/shipmentlocations.component.html ***!
  \**************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9\">\n        <h4>Shipment Locations</h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btn-raised bmd-btn-edit btntop\" (click)=\"onBack()\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n<form [formGroup]=\"ShipmentForm\">\n    <div class=\"row\">\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Location Code</label>\n                        <input type=\"text\" name=\"LocationCode\" autocomplete=\"off\" id=\"txtLocationCode\" formControlName=\"LocationCode\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Location Name</label>\n                        <input type=\"text\" name=\"Location\" autocomplete=\"off\" id=\"txtLocation\" formControlName=\"Location\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Country </label>\n                        <select class=\"form-control my-select\" id=\"ddlCountryv\" formControlName=\"CountryID\">\n                            <option *ngFor=\"let gRow of dscountryItem\" [value]=\"gRow.ID\">\n                                {{gRow.CountryName}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">City</label>\n                        <select class=\"form-control my-select\" formControlName=\"CityID\" id=\"ddlcity\">\n                            <option *ngFor=\"let gRow of dscityItem\" [value]=\"gRow.ID\">\n                            {{gRow.City}}</option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label>Active</label>\n                        <select class=\"form-control my-select\" id=\"ddlStatus\" formControlName=\"status\">\n                            <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                {{status.viewValue}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n    <div class=\"row alogtop\">\n        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt\">\n            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Save</button>\n        </div>\n        <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n    </div>\n\n</form>");

/***/ }),

/***/ 17616:
/*!****************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview.component.html ***!
  \****************************************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle rotle\">\n    <div class=\"col-md-9\">\n        <h4>Shipment Locations Master</h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" [routerLink]=\"['/views/masters/commonmaster/shipmentlocations/shipmentlocations/']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<div class=\"row\">\n    <div class=\"col-9\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12 master\">\n                            <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr role=\"row\">\n                                        <th class=\"actwid\">\n                                            S.No\n                                        </th>\n                                        <th>\n                                            Location Code\n                                        </th>\n                                        <th>\n                                            Location Name\n                                        </th>\n                                        <th class=\"actwid\">\n                                            Active\n                                        </th>\n                                        <!--<th class=\"actwid\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Office: activate to sort column ascending\" style=\"width: 129.95px;\">Action</th>-->\n                                    </tr>\n                                </thead>\n\n                                <tbody>\n\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td class=\"alc\"> <button class=\"btn btn-success bmd-btn-fab enqbtn\" [routerLink]=\"['/views/masters/commonmaster/shipmentlocations/shipmentlocations/']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">{{dataItem.LocationCode}} </button></td>\n                                        <td>{{dataItem.Location}}</td>\n                                        <td>{{dataItem.StatusResult}}</td>\n                                        <!--<td class=\"alc\">\n                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/shipmentlocations/shipmentlocations/']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\n                                <i class=\"material-icons\">edit</i>\n                            </button>\n                        </td>-->\n                                    </tr>\n                                </tbody>\n                            </table>\n                        </div>\n                    </div>\n                    <div class=\"row page\" align=\"right\">\n\n\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{'pag-disable':pager.endIndex + 1 === pager.totalItems}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n                    </div>\n                </div>\n            </div>\n        </div> <!-- end col -->\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n        <form [formGroup]=\"searchForm\">\n            <div class=\"card m-b-30 sidesearch\">\n                <div class=\"card-body cpad\">\n                    <div class=\"row\">                       \n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"LocationCode\" class=\"form-control\" placeholder=\"Location Code\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"Location\" class=\"form-control\" placeholder=\"Location Name\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlStatusv\" formControlName=\"status\">\n                                    <option value=\"0\">Status</option>\n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                        {{status.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 searchbtn alrt\">\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                            <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </form>\n    </div>\n</div>\n");

/***/ }),

/***/ 82513:
/*!**************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/statemaster/statemaster.component.html ***!
  \**************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9 col-sm-9 col-lg-9 col-xl-9\">\n        <h4>State Master</h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" (click)=\"onBack()\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<form [formGroup]=\"stateForm\">\n            <div class=\"row\">\n                <div class=\"col-md-4\">\n                    <div class=\"form-group bmd-form-group\">\n                        <div class=\"row\">\n                            <div class=\"col-md-12\">\n                                <label class=\"str\">Country</label>\n                                <select name=\"Country\" id=\"ddlCountry\" formControlName=\"CountryID\" class=\"form-control my-select\">\n                                    <option *ngFor=\"let gRow of dscountryItem\" [value]=\"gRow.ID\">\n                                        {{gRow.CountryName}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n                <div class=\"col-md-4\">\n                    <div class=\"form-group bmd-form-group\">\n                        <div class=\"row\">\n                            <div class=\"col-md-12\">\n                                <label class=\"str\">State Name</label>\n                                <input type=\"text\" name=\"StateName\" formControlName=\"StateName\" autocomplete=\"off\" id=\"txtStateName\" ng-model=\"txtTerminalName\" class=\"form-control\">\n                            </div>\n                        </div>\n                    </div>\n                </div>\n\n                <div class=\"col-md-4\">\n                    <div class=\"form-group bmd-form-group\">\n                        <div class=\"row\">\n                            <div class=\"col-md-12\">\n                                <label class=\"str\">State Code</label>\n                                <input type=\"number\" name=\"StateCode\" formControlName=\"StateCode\" min=\"0\" id=\"txtStateCode\" autocomplete=\"off\" class=\"form-control\">\n                            </div>\n                        </div>\n                    </div>\n                </div>\n\n                <div class=\"col-md-4\">\n                    <div class=\"form-group bmd-form-group\">\n                        <div class=\"row\">\n                            <div class=\"col-md-12\">\n                                <label>Active</label>\n                                <select name=\"Status\" formControlName=\"Status\" id=\"ddlStatus\" class=\"form-control my-select\">                                   \n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                        {{status.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n\n            </div>\n        <div class=\"row alogtop\">\n            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt\">\n                <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-success btn-raised mb-0\">Save</button>\n            </div>\n            <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n        </div>\n</form>\n\n\n");

/***/ }),

/***/ 8482:
/*!**********************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/statemaster/statemasterview/statemasterview.component.html ***!
  \**********************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle rotle\">\n    <div class=\"col-md-9\">\n        <h4>State Master</h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" [routerLink]=\"['/views/masters/commonmaster/statemaster/statemaster']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<div class=\"row\">\n    <div class=\"col-md-9\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12 master\">\n                            <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr role=\"row\">\n                                        <th class=\"actwid\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Name: activate to sort column ascending\" style=\"width: 177.575px;\">\n                                            S.No\n                                        </th>\n                                        <th>\n                                            Country\n                                        </th>\n                                        <th>\n                                            State Name\n                                        </th>\n                                        <th>\n                                            State Code\n                                        </th>\n                                        <th class=\"actwid\">\n                                            Active\n                                        </th>\n                                        <!--<th class=\"actwid\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Office: activate to sort column ascending\" style=\"width: 129.95px;\">Action</th>-->\n                                    </tr>\n                                </thead>\n\n                                <tbody>\n\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\"\n                                        [ngClass]=\"{'highlight' : dataItem.StateCode == selectedName}\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td class=\"alc\"> <button class=\"btn btn-success bmd-btn-fab enqbtn\" [routerLink]=\"['/views/masters/commonmaster/statemaster/statemaster']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">{{dataItem.Country}} </button></td>\n                                        <td>{{dataItem.StateName}}</td>\n                                        <td>{{dataItem.StateCode}}</td>\n                                        <td>{{dataItem.StatusResult}}</td>\n                                        <!--<td class=\"alc\">\n                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/statemaster/statemaster']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\n                                <i class=\"material-icons\">edit</i>\n                            </button>\n                        </td>-->\n                                    </tr>\n                                </tbody>\n                            </table>\n                        </div>\n                    </div>\n                    <div class=\"row page\" align=\"right\">\n\n\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{'pag-disable':pager.endIndex + 1 === pager.totalItems}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n                    </div>\n\n                </div>\n                </div>\n                </div>\n            </div> <!-- end col -->\n\n            <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n                <form [formGroup]=\"searchForm\">\n                    <div class=\"card m-b-30 sidesearch\">\n                        <div class=\"card-body cpad\">\n                            <div class=\"row\">\n                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                    <div class=\"form-group bmd-form-group\">\n                                        <input type=\"text\" autocomplete=\"off\" formControlName=\"Country\" class=\"form-control\" placeholder=\"Country\">\n                                    </div>\n                                </div>\n                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                    <div class=\"form-group bmd-form-group\">\n                                        <input type=\"text\" autocomplete=\"off\" formControlName=\"StateName\" class=\"form-control\" placeholder=\"State Name\">\n                                    </div>\n                                </div>\n                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                    <div class=\"form-group bmd-form-group\">\n                                        <input type=\"text\" autocomplete=\"off\" formControlName=\"StateCode\" class=\"form-control\" placeholder=\"State Code\">\n                                    </div>\n                                </div>\n                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                                    <div class=\"form-group bmd-form-group\">\n                                        <select class=\"form-control my-select\" id=\"ddlStatusv\" formControlName=\"Status\">\n                                            <option value=\"0\">Active</option>\n                                            <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                                {{status.viewValue}}\n                                            </option>\n                                        </select>\n                                    </div>\n                                </div>\n                                <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 searchbtn alrt\">\n                                    <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                                    <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\n                                </div>\n                            </div>\n                        </div>\n                    </div>\n                </form>\n            </div>\n        </div>\n");

/***/ }),

/***/ 35346:
/*!******************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/storagelocationtype/storagelocationtype.component.html ***!
  \******************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9 col-sm-9 col-lg-9 col-xl-9\">\n        <h4>Storage Location Master</h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btn-raised btntop bmd-btn-edit\" [routerLink]=\"['/views/masters/commonmaster/storagelocationtype/storagelocationtypeview/storagelocationtypeview']\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<form [formGroup]=\"StorageLocationForm\">\n\n    <div class=\"card\">\n        <div class=\"card-body \">\n            <div class=\"row\">\n                <div class=\"col-md-6\">\n\n                </div>\n                <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                    <div class=\"form-group\">\n                        <div class=\"row\">\n                            <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4 headtitle\">\n                                <h4>Storage location Type</h4>\n                            </div>\n                            <div class=\"col-md-8\">\n                                <label class=\"check\">\n                                    <input type=\"radio\" (click)=\"PortChange(1)\" [value]=\"1\" name=\"SLTypeID\" checked formControlName=\"SLTypeID\" id=\"ChkPort\" />\n                                    <span>Port</span>\n                                </label>\n                                <label class=\"check\" style=\"margin-left:20px;\">\n                                    <input type=\"radio\" (click)=\"PortChange(2)\" [value]=\"2\" name=\"SLTypeID\" checked formControlName=\"SLTypeID\" />\n                                    <span>Depot</span>\n                                </label>\n                                <label class=\"check\" style=\"margin-left:20px;\">\n                                    <input type=\"radio\" (click)=\"PortChange(3)\" [value]=\"3\" name=\"SLTypeID\" checked formControlName=\"SLTypeID\" />\n                                    <span>Customer</span>\n                                </label>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n                <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                    <div class=\"form-group\">\n                        <div class=\"row\">\n                            <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                <label >Office</label>\n                            </div>\n                            <div class=\"col-md-1 col-sm-1 col-lg-1 col-xl-1\">:</div>\n                            <div class=\"col-md-7 col-sm-7 col-lg-7 col-xl-7\">\n                                <select class=\"form-control my-select\" id=\"OfficeCode1\" formControlName=\"OfficeID\">\n                                    <option *ngFor=\"let gRow of OfficeMasterAllvalues\" [value]=\"gRow.ID\">\n                                        {{gRow.CustomerName}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n                \n            </div>\n            <div class=\"row\">\n\n                <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                    <div class=\"form-group\">\n                        <div class=\"row\">\n                            <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                <label class=\"str\">Storage Location </label>\n                            </div>\n                            <div class=\"col-md-1 col-sm-1 col-lg-1 col-xl-1\">:</div>\n                            <div class=\"col-md-7 col-sm-7 col-lg-7 col-xl-7\">\n                                <input type=\"text\" name=\"StorageLoc\" formControlName=\"StorageLoc\" autocomplete=\"off\" class=\"form-control\">\n                            </div>\n                        </div>\n                    </div>\n                </div>\n\n                <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                    <div class=\"form-group\">\n                        <div class=\"row\">\n                            <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                <label class=\"str\">\n                                    Short Name\n                                </label>\n                            </div>\n                            <div class=\"col-md-1 col-sm-1 col-lg-1 col-xl-1\">:</div>\n                            <div class=\"col-md-7 col-sm-7 col-lg-7 col-xl-7\">\n                                <input type=\"text\" name=\"StorageCode\" formControlName=\"StorageCode\"  autocomplete=\"off\"  class=\"form-control\" />\n                            </div>\n                        </div>\n                    </div>\n                </div>\n                <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                    <div class=\"form-group\">\n                        <div class=\"row\">\n                            <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                <label class=\"str\">Port Code </label>\n                            </div>\n                            <div class=\"col-md-1 col-sm-1 col-lg-1 col-xl-1\">:</div>\n                            <div class=\"col-md-7 col-sm-7 col-lg-7 col-xl-7\">\n                                <select class=\"form-control my-select\" id=\"ddlPortCode\" disabled formControlName=\"PortID\">\n                                    <option *ngFor=\"let gRow of dsPorts\" [value]=\"gRow.ID\">\n                                        {{gRow.PortCode}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n\n\n\n                <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                    <div class=\"form-group\">\n                        <div class=\"row\">\n                            <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                <label>Status</label>\n                            </div>\n                            <div class=\"col-md-1 col-sm-1 col-lg-1 col-xl-1\">:</div>\n                            <div class=\"col-md-7 col-sm-7 col-lg-7 col-xl-7\">\n                                <select name=\"Status\" formControlName=\"StatusID\" id=\"ddlStatus\" class=\"form-control my-select\">\n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                        {{status.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n                <div class=\"col-md-6 col-sm-6 col-lg-6 col-xl-6\">\n                    <div>\n                        <div class=\"row\">\n                            <div class=\"col-md-4 col-sm-4 col-lg-4 col-xl-4\">\n                                <label>\n                                    Remarks\n                                </label>\n                            </div>\n                            <div class=\"col-md-1 col-sm-1 col-lg-1 col-xl-1\">:</div>\n                            <div class=\"col-md-7 col-sm-7 col-lg-7 col-xl-7\">\n                                <textarea class=\"form-control\" style=\"height:50px!important;\" rows=\"5\" placeholder=\"Notes\" formControlName=\"Remarks\"></textarea>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n\n            </div>\n        </div>\n        <div class=\"card-footer \">\n            <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 padlr0\" style=\"text-align:right;\">\n                <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Submit</button>\n            </div>\n           \n        </div>\n    </div>\n\n</form>\n");

/***/ }),

/***/ 3155:
/*!**********************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/storagelocationtype/storagelocationtypeview/storagelocationtypeview.component.html ***!
  \**********************************************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9\">\n        <h4>Storage Location Master</h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" [routerLink]=\"['/views/masters/commonmaster/storagelocationtype/storagelocationtype']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<div class=\"row\">\n    <div class=\"col-9\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n                    <div class=\"row\">\n                        <div class=\"col-sm-12 master\">\n                            <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr role=\"row\">\n                                        <th class=\"actwid\">\n                                            S.No\n                                        </th>\n                                        <th>\n                                            Storage Location Type\n                                        </th>\n                                        <th>\n                                            Storage Location\n                                        </th>\n                                        <th>\n                                            Short Name\n                                        </th>\n                                        <th class=\"actwid\">\n                                            Active\n                                        </th>\n                                        <th class=\"actwid\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Office: activate to sort column ascending\" style=\"width: 129.95px;\">Action</th>\n                                    </tr>\n                                </thead>\n\n                                <tbody>\n\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\"\n                                        [ngClass]=\"{'highlight' : dataItem.StateCode == selectedName}\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td>{{dataItem.StorageLocation}}</td>\n                                        <td>{{dataItem.StorageLoc}}</td>\n                                        <td>{{dataItem.StorageCode}}</td>\n                                        <td>{{dataItem.StatusResult}}</td>\n                                        <td class=\"alc\">\n                                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/storagelocationtype/storagelocationtype']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\n                                                <i class=\"material-icons\">edit</i>\n                                            </button>\n                                        </td>\n                                    </tr>\n                                </tbody>\n                            </table>\n                        </div>\n                    </div>\n                    <div class=\"row page\" align=\"right\">\n\n                        <!-- pager -->\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{disabled:pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{disabled:pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{disabled:pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{disabled:pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n\n\n\n\n                    </div>\n                </div>\n            </div>\n        </div> <!-- end col -->\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n        <form [formGroup]=\"searchForm\">\n            <div class=\"card m-b-30 sidesearch\">\n                <div class=\"card-body cpad\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlOfficeID\" formControlName=\"OfficeID\">\n                                    <option value=\"0\">Office</option>\n                                    <option *ngFor=\"let gRow of OfficeMasterAllvalues\" [value]=\"gRow.ID\">\n                                        {{gRow.CustomerName}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlStatusv1\" formControlName=\"SLTypeID\">\n                                    <option value=\"0\">Storage Location Type</option>\n                                    <option *ngFor=\"let status of SLTypevalues\" [value]=\"status.value\">\n                                        {{status.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"StorageLoc\" class=\"form-control\" placeholder=\"Storage Location\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"StorageCode\" class=\"form-control\" placeholder=\"Short Name\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlStatusv\" formControlName=\"StatusID\">\n                                    <option value=\"0\">Status</option>\n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                        {{status.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 searchbtn alrt\">\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                            <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </form>\n    </div>\n</div>\n");

/***/ }),

/***/ 67450:
/*!********************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/terminal/terminal.component.html ***!
  \********************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9 col-sm-9 col-lg-9 col-xl-9\">\n        <h4>Terminal Master</h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" (click)=\"onBack()\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<form [formGroup]=\"terminalForm\">\n    <div class=\"row\">\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Terminal Code</label>\n                        <input type=\"text\" name=\"TerminalCode\" formControlName=\"TerminalCode\" autocomplete=\"off\" id=\"txtTerminalCode\" ng-model=\"txtTerminalCode\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Terminal Name</label>\n                        <input type=\"text\" name=\"TerminalName\" formControlName=\"TerminalName\" autocomplete=\"off\" id=\"txtTerminalName\" ng-model=\"txtTerminalName\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Port</label>\n                        <select class=\"form-control my-select\" id=\"ddlPort\" name=\"PortID\" formControlName=\"PortID\">\n                            <option *ngFor=\"let gRow of dsportItem\" [value]=\"gRow.ID\">\n                                {{gRow.PortName}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12 input-field\">\n                        <label>Active</label>\n                        <select name=\"Status\" formControlName=\"Status\" id=\"ddlStatus\" class=\"form-control my-select\">\n                            <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                {{status.viewValue}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n    <div class=\"row alogtop\">\n        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt\">\n            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Save</button>\n        </div>\n        <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n    </div>\n</form>\n\n\n");

/***/ }),

/***/ 11133:
/*!*************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/terminal/terminalview/terminalview.component.html ***!
  \*************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle rotle\">\n    <div class=\"col-md-9 col-sm-9 col-lg-9 col-xl-9\">\n        <h4>Terminal Master</h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" [routerLink]=\"['/views/masters/commonmaster/terminal/terminal']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n\n<div class=\"row\">\n    <div class=\"col-md-9 col-sm-9 col-lg-9 col-xl-9\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n\n                    <div class=\"row\">\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 master\">\n                            <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr role=\"row\">\n                                        <th class=\"actwid\">\n                                            S.No\n                                        </th>\n                                        <th>\n                                            Terminal Code\n                                        </th>\n                                        <th>Terminal Name</th>\n                                        <th>Port</th>\n                                        <th class=\"actwid\">Active</th>\n                                        <!--<th class=\"actwid\">Action</th>-->\n                                    </tr>\n                                </thead>\n\n                                <tbody>\n\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\"\n                                        [ngClass]=\"{'highlight' : dataItem.TerminalCode == selectedName}\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td class=\"alc\"> <button class=\"btn btn-success bmd-btn-fab enqbtn\" [routerLink]=\"['/views/masters/commonmaster/terminal/terminal']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\"> {{dataItem.TerminalCode}} </button></td>\n                                        <td>{{dataItem.TerminalName}}</td>\n                                        <td>{{dataItem.PortName}}</td>\n                                        <td>{{dataItem.StatusName}}</td>\n                                        <!--<td class=\"alc\">\n                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/terminal/terminal']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\n                                <i class=\"material-icons\">edit</i>\n                            </button>\n                        </td>-->\n                                    </tr>\n                                </tbody>\n                            </table>\n                        </div>\n                    </div>\n\n                    <div class=\"row page\" align=\"right\">\n\n\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{'pag-disable':pager.endIndex + 1 === pager.totalItems}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n        <form [formGroup]=\"searchForm\">\n            <div class=\"card m-b-30 sidesearch\">\n                <div class=\"card-body cpad\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"TerminalCode\" class=\"form-control\" placeholder=\"Terminal Code\">\n\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"TerminalName\" class=\"form-control\" placeholder=\"Terminal Name\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"PortName\" class=\"form-control\" placeholder=\"Port\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlStatusv\" formControlName=\"Status\">\n                                    <option value=\"0\">Active</option>\n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                        {{status.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n\n\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 searchbtn alrt\">\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                            <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\n                        </div>\n\n\n                    </div>\n                </div>\n            </div>\n            </form>\n    </div>\n</div>\n\n\n");

/***/ }),

/***/ 26938:
/*!********************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/uomconversions/uomconversions.component.html ***!
  \********************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9\">\n        <h4>\n            UOM Conversions - Master            \n        </h4>\n    </div>\n    <div class=\"col-md-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btn-raised bmd-btn-edit btntop\" (click)=\"onBack()\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n<form [formGroup]=\"UOMForm\">\n    <div class=\"row\">\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">                    \n                    <div class=\"col-md-12\">\n                        <label class=\"str\">UOM Code From</label>\n                        <select class=\"form-control my-select\" id=\"ddlUOMFrom\" formControlName=\"UOMFrom\">\n                            <option *ngFor=\"let action of DsUOMValues\" [value]=\"action.ID\">\n                                {{action.UOMCode}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">                    \n                    <div class=\"col-md-12\">\n                        <label class=\"str\">UOM Code To</label>\n                        <select class=\"form-control my-select\" id=\"ddlUOMTo\" formControlName=\"UOMTo\">\n                            <option *ngFor=\"let action of DsUOMValues\" [value]=\"action.ID\">\n                                {{action.UOMCode}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">                   \n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Action</label>\n                        <select class=\"form-control my-select\" id=\"ddlAction\" formControlName=\"Action\">\n                            <option *ngFor=\"let action of DsUOMActions\" [value]=\"action.ID\">\n                                {{action.UOMActions}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">               \n                    <div class=\"col-md-12\">\n                        <label class=\"str\">Factor </label>\n                        <input type=\"text\" name=\"Factor\" autocomplete=\"off\" formControlName=\"Factor\" id=\"txtFactor\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group\">\n                <div class=\"row\">                  \n                    <div class=\"col-md-12\">\n                        <label>Active</label>\n                        <select class=\"form-control my-select\" id=\"ddlStatus\" formControlName=\"Status\">\n                            <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                {{status.viewValue}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n\n\n       \n    <div class=\"row alogtop\">\n        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt\">\n            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Save</button>\n        </div>\n        <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n    </div>\n   \n</form>");

/***/ }),

/***/ 40103:
/*!*******************************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview.component.html ***!
  \*******************************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle rotle\">\n    <div class=\"col-md-9\">\n        <h4>\n            UOM Conversions - Master             \n        </h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" [routerLink]=\"['/views/masters/commonmaster/uomconversions/uomconversions']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<div class=\"row\">\n    <div class=\"col-9\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n                    <div class=\"row\">\n                        <div class=\"col-sm-12 master\">\n                            <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr role=\"row\">\n                                        <th class=\"actwid\">\n                                            S.No\n                                        </th>\n                                        <th>\n                                            UOM Code From\n\n                                        </th>\n                                        <th>\n                                            UOM Code To\n                                        </th>\n                                        <th>\n                                            Action\n                                        </th>\n                                        <th>\n                                            Factor\n                                        </th>\n                                        <th class=\"actwid\">\n                                            Active\n                                        </th>\n                                        <!--<th class=\"actwid\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Office: activate to sort column ascending\" style=\"width: 129.95px;\">Action</th>-->\n                                    </tr>\n                                </thead>\n                                <tbody>\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\"\n                                        [ngClass]=\"{'highlight' : dataItem.StateCode == selectedName}\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td class=\"alc\"><button class=\"btn btn-success bmd-btn-fab enqbtn\" [routerLink]=\"['/views/masters/commonmaster/uomconversions/uomconversions']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\"> {{dataItem.UOMFrom}} </button></td>\n                                        <td>{{dataItem.UOMTo}}</td>\n                                        <td>{{dataItem.ActionResult}}</td>\n                                        <td>{{dataItem.Factor}}</td>\n                                        <td>{{dataItem.StatusResult}}</td>\n                                        <!--<td class=\"alc\">\n                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/uomconversions/uomconversions']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\n                                <i class=\"material-icons\">edit</i>\n                            </button>\n                        </td>-->\n                                    </tr>\n                                </tbody>\n                            </table>\n                        </div>\n                    </div>\n                    <div class=\"row page\" align=\"right\">\n\n\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{'pag-disable':pager.endIndex + 1 === pager.totalItems}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n                    </div>\n                </div>\n            </div>\n        </div> <!-- end col -->\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n        <form [formGroup]=\"searchForm\">\n            <div class=\"card m-b-30 sidesearch\">\n                <div class=\"card-body cpad\">\n                    <div class=\"row\">                    \n\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"UOMFrom\" class=\"form-control\" placeholder=\"UOM Code From\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" autocomplete=\"off\" formControlName=\"UOMTo\" class=\"form-control\" placeholder=\"UOM Code To\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlactionv\" formControlName=\"Action\">\n                                    <option value=\"0\">Action</option>\n                                    <option *ngFor=\"let action of DsUOMActions\" [value]=\"action.ID\">\n                                        {{action.UOMActions}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlStatusv\" formControlName=\"Status\">\n                                    <option value=\"0\">Active </option>\n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                        {{status.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 searchbtn alrt\">\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                            <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </form>\n    </div>\n</div>\n");

/***/ }),

/***/ 82234:
/*!**********************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/uommaster/uommaster.component.html ***!
  \**********************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9 col-sm-9 col-lg-9 col-xl-9\">\n        <h4>UOM Master</h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" (click)=\"onBack()\"><i class=\"material-icons editicon\">reply</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<form [formGroup]=\"uommasterForm\">\n    <div class=\"row\">\n        <div class=\"col-md-4\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">UOM Code</label>\n                        <input type=\"text\" name=\"UOMCode\" formControlName=\"UOMCode\" autocomplete=\"off\" id=\"txtUOMCode\" ng-model=\"txtTerminalCode\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label class=\"str\">UOM Description</label>\n                        <input type=\"text\" name=\"UOMDesc\" formControlName=\"UOMDesc\" autocomplete=\"off\" id=\"txtUOMDesc\" ng-model=\"txtTerminalName\" class=\"form-control\">\n                    </div>\n                </div>\n            </div>\n        </div>\n        <div class=\"col-md-4\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12 input-field\">\n                        <label>UOM Type</label>\n                        <select name=\"UOMType\" formControlName=\"UOMType\" id=\"ddlUOMType\" class=\"form-control my-select\">\n                            <option *ngFor=\"let UOMType of DsUOMCommon\" [value]=\"UOMType.ID\">\n                                {{UOMType.UOMTypes}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n        <div class=\"col-md-4\">\n            <div class=\"form-group bmd-form-group\">\n                <div class=\"row\">\n                    <div class=\"col-md-12\">\n                        <label>Active</label>\n                        <select name=\"Status\" formControlName=\"Status\" id=\"ddlStatus\" class=\"form-control my-select\">\n                            <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                {{status.viewValue}}\n                            </option>\n                        </select>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n    </div>\n\n    <div class=\"row alogtop\">\n        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 alrt\">\n            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Save</button>\n        </div>\n        <input type=\"hidden\" id=\"HDRegId\" ng-model=\"HDRegId\" />\n    </div>\n\n</form>\n\n");

/***/ }),

/***/ 76742:
/*!****************************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/commonmaster/uommaster/uommasterview/uommasterview.component.html ***!
  \****************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle rotle\">\n    <div class=\"col-md-9 col-sm-9 col-lg-9 col-xl-9\">\n        <h4>UOM Master</h4>\n    </div>\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3 alrt\">\n        <button type=\"button\" class=\"btn btn-success btntop btn-raised bmd-btn-edit\" [routerLink]=\"['/views/masters/commonmaster/uommaster/uommaster']\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<div class=\"row\">\n    <div class=\"col-9\">\n        <div class=\"card m-b-30\">\n            <div class=\"card-body leftcard\">\n                <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n                    <div class=\"row\">\n                        <div class=\"col-sm-12 master\">\n                            <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                                <thead>\n                                    <tr role=\"row\">\n                                        <th class=\"actwid\">\n                                            S.No\n                                        </th>\n                                        <th>\n                                            UOM Code\n                                        </th>\n                                        <th>\n                                            UOM Description\n                                        </th>\n                                        <th>\n                                            UOM Type\n                                        </th>\n\n                                        <th class=\"actwid\">\n                                            Active\n                                        </th>\n                                        <!--<th class=\"actwid\" tabindex=\"0\" aria-controls=\"datatable-buttons\" rowspan=\"1\" colspan=\"1\" aria-label=\"Office: activate to sort column ascending\" style=\"width: 129.95px;\">Action</th>-->\n                                    </tr>\n                                </thead>\n\n                                <tbody>\n\n                                    <tr *ngFor=\"let dataItem of pagedItems ;\n                                        let i = index\" (mouseover)=\"highlightRow(dataItem)\"\n                                        [ngClass]=\"{'highlight' : dataItem.UOMCode == selectedName}\">\n                                        <td> {{ i + 1*pager.startIndex+1 }}</td>\n                                        <td class=\"alc\"> <button class=\"btn btn-success bmd-btn-fab enqbtn\" [routerLink]=\"['/views/masters/commonmaster/uommaster/uommaster']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">{{dataItem.UOMCode}} </button></td>\n                                        <td>{{dataItem.UOMDesc}}</td>\n                                        <td>{{dataItem.UOMTypeResult}}</td>\n                                        <td>{{dataItem.StatusResult}}</td>\n                                        <!--<td class=\"alc\">\n                            <button class=\"btn btn-success bmd-btn-fab\" [routerLink]=\"['/views/masters/commonmaster/uommaster/uommaster']\" [queryParams]=\"{id: dataItem.ID}\" queryParamsHandling=\"merge\">\n                                <i class=\"material-icons\">edit</i>\n                            </button>\n                        </td>-->\n                                    </tr>\n                                </tbody>\n                            </table>\n                        </div>\n                    </div>\n                    <div class=\"row page\" align=\"right\">\n\n\n                        <ul *ngIf=\"pager.pages && pager.pages.length\" class=\"pagination\">\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(1)\">First</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === 1}\">\n                                <a (click)=\"setPage(pager.currentPage - 1)\">Previous</a>\n                            </li>\n                            <li *ngFor=\"let page of pager.pages\" [ngClass]=\"{active:pager.currentPage === page}\">\n                                <a (click)=\"setPage(page)\">{{page}}</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5 \">\n                                <a (click)=\"setPage(pager.startPage + 5)\">...</a>\n                            </li>\n                            <li *ngIf=\"(pager.totalPages - pager.startPage) > 5\">\n                                <a (click)=\"setPage(pager.totalPages)\">{{pager.totalPages}}</a>\n                            </li>\n\n                            <li [ngClass]=\"{'pag-disable':pager.endIndex + 1 === pager.totalItems}\">\n                                <a (click)=\"setPage(pager.currentPage + 1)\">Next</a>\n                            </li>\n                            <li [ngClass]=\"{'pag-disable':pager.currentPage === pager.totalPages}\">\n                                <a (click)=\"setPage(pager.totalPages)\">Last</a>\n                            </li>\n                        </ul>\n                    </div>\n                    <!--<div class=\"row\"><div class=\"col-sm-12 col-md-5\"><div class=\"dataTables_info\" id=\"datatable-buttons_info\" role=\"status\" aria-live=\"polite\">Showing 1 to 10 of 40 entries</div></div><div class=\"col-sm-12 col-md-7\"><div class=\"dataTables_paginate paging_simple_numbers\" id=\"datatable-buttons_paginate\"><ul class=\"pagination\"><li class=\"paginate_button page-item previous disabled\" id=\"datatable-buttons_previous\"><a href=\"#\" aria-controls=\"datatable-buttons\" data-dt-idx=\"0\" tabindex=\"0\" class=\"page-link\">Previous</a></li><li class=\"paginate_button page-item active\"><a href=\"#\" aria-controls=\"datatable-buttons\" data-dt-idx=\"1\" tabindex=\"0\" class=\"page-link\">1</a></li><li class=\"paginate_button page-item \"><a href=\"#\" aria-controls=\"datatable-buttons\" data-dt-idx=\"2\" tabindex=\"0\" class=\"page-link\">2</a></li><li class=\"paginate_button page-item \"><a href=\"#\" aria-controls=\"datatable-buttons\" data-dt-idx=\"3\" tabindex=\"0\" class=\"page-link\">3</a></li><li class=\"paginate_button page-item \"><a href=\"#\" aria-controls=\"datatable-buttons\" data-dt-idx=\"4\" tabindex=\"0\" class=\"page-link\">4</a></li><li class=\"paginate_button page-item \"><a href=\"#\" aria-controls=\"datatable-buttons\" data-dt-idx=\"5\" tabindex=\"0\" class=\"page-link\">5</a></li><li class=\"paginate_button page-item \"><a href=\"#\" aria-controls=\"datatable-buttons\" data-dt-idx=\"6\" tabindex=\"0\" class=\"page-link\">6</a></li><li class=\"paginate_button page-item next\" id=\"datatable-buttons_next\"><a href=\"#\" aria-controls=\"datatable-buttons\" data-dt-idx=\"7\" tabindex=\"0\" class=\"page-link\">Next</a></li></ul></div></div></div>-->\n                </div>\n            </div>\n        </div>\n    </div> <!-- end col -->\n\n    <div class=\"col-md-3 col-sm-3 col-lg-3 col-xl-3\">\n        <form [formGroup]=\"searchForm\">\n            <div class=\"card m-b-30 sidesearch\">\n                <div class=\"card-body cpad\">\n                    <div class=\"row\">\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" formControlName=\"UOMCode\" class=\"form-control\" placeholder=\"UOM Code\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <input type=\"text\" formControlName=\"UOMDesc\" class=\"form-control\" placeholder=\"UOM Description\">\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                          \n                                <select name=\"UOMType\" formControlName=\"UOMType\" id=\"ddlUOMTypev\" class=\"form-control my-select\">\n                                    <option value=\"0\">UOMType</option>\n                                    <option *ngFor=\"let UOMType of DsUOMCommon\" [value]=\"UOMType.ID\">\n                                        {{UOMType.UOMTypes}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12\">\n                            <div class=\"form-group bmd-form-group\">\n                                <select class=\"form-control my-select\" id=\"ddlStatusv\" formControlName=\"Status\">\n                                    <option value=\"0\">Status</option>\n                                    <option *ngFor=\"let status of statusvalues\" [value]=\"status.value\">\n                                        {{status.viewValue}}\n                                    </option>\n                                </select>\n                            </div>\n                        </div>\n\n                        <div class=\"col-md-12 col-sm-12 col-lg-12 col-xl-12 searchbtn alrt\">\n                            <button type=\"submit\" (click)=\"onSubmit()\" class=\"btn btn-primary btn-raised mb-0\">Search<div class=\"ripple-container\"></div></button>\n                            <button type=\"submit\" (click)=\"clearSearch()\" class=\"btn btn-raised btn-danger mb-0\">Clear<div class=\"ripple-container\"></div></button>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </form>\n    </div>\n</div>\n\n");

/***/ }),

/***/ 71913:
/*!*********************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/masters/masters.component.html ***!
  \*********************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n\n");

/***/ }),

/***/ 77883:
/*!*************************************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/systemadmin/documentmanager/documentmanager.component.html ***!
  \*************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"row headtitle\">\n    <div class=\"col-md-9\">\n        <h4>Document Management Storage and Retrieval</h4>\n    </div>\n</div>\n\n<div class=\"row alogtop\">\n    <div class=\"col-md-6\">\n        <h5>Document Configuration</h5>\n    </div>\n    <div class=\"col-md-6 alrt\">\n        <button type=\"submit\" class=\"btn btn-success bmd-btn-fab tblbtngap\"><i class=\"material-icons editicon\">add</i><div class=\"ripple-container\"></div></button>\n        <button type=\"submit\" class=\"btn btn-primary bmd-btn-fab tblbtngap\"><i class=\"material-icons editicon\">edit</i><div class=\"ripple-container\"></div></button>\n    </div>\n    <div class=\"col-md-12 padlr0\">\n        <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n            <div class=\"row\">\n                <div class=\"col-md-12 bkglvl\">\n                    <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                        <thead>\n                            <tr role=\"row\">\n                                <th rowspan=\"2\" class=\"actwid\">S.No.</th>\n                                <th rowspan=\"2\">Application</th>\n                                <th rowspan=\"2\">Module</th>\n                                <th rowspan=\"2\">Max Doc Size (KB)</th>\n                                <th rowspan=\"2\">Document Name</th>\n                                <th colspan=\"2\">Hot Storage</th>\n                                <th colspan=\"2\">Cold Storage</th>\n                            </tr>\n\n                            <tr>\n                                <th>Value</th>\n                                <th>Unit</th>\n                                <th>Value</th>\n                                <th>Unit</th>\n                            </tr>\n                        </thead>\n\n                        <tbody>\n                            <tr>\n                                <td class=\"actwid\"></td>\n                                <td></td>\n                                <td></td>\n                                <td></td>\n                                <td></td>\n                                <td></td>\n                                <td>\n                                    <select class=\"form-control my-select\">\n                                        <option value=\"0\">select</option>\n                                    </select>\n                                </td>\n                                <td></td>\n                                <td>\n                                    <select class=\"form-control my-select\">\n                                        <option value=\"0\">select</option>\n                                    </select>\n                                </td>\n                            </tr>\n                        </tbody>\n                    </table>\n                </div>\n            </div>\n\n        </div>\n    </div>\n</div>\n\n<div class=\"row alogtop\">\n    <div class=\"col-md-12 alrt\">\n        <button type=\"submit\" class=\"btn btn-primary btn-raised btn-default cntbtn mb-0\">Save<div class=\"ripple-container\"></div></button>\n        <button type=\"submit\" class=\"btn btn-danger btn-raised cntbtn mb-0\">Cancel<div class=\"ripple-container\"></div></button>\n    </div>\n</div>\n\n<div class=\"row alogtop\">\n    <div class=\"col-md-6\">\n        <h5>Document Storage Details</h5>\n    </div>\n    <div class=\"col-md-12 padlr0\">\n        <div id=\"datatable-buttons_wrapper\" class=\"dataTables_wrapper container-fluid dt-bootstrap4 no-footer\">\n            <div class=\"row\">\n                <div class=\"col-md-12 bkglvl\">\n                    <table id=\"datatable-buttons\" class=\"table table-responsive table-striped table-bordered w-100 dataTable no-footer\" role=\"grid\" aria-describedby=\"datatable-buttons_info\">\n                        <thead>\n                            <tr role=\"row\">\n                                <th class=\"actwid\">UID</th>\n                                <th>App</th>\n                                <th>Module</th>\n                                <th>Document</th>\n                                <th>Date</th>\n                                <th>User</th>\n                                <th>Size (KB)</th>\n                                <th>Type</th>\n                                <th>URL</th>\n                            </tr>\n                        </thead>\n\n                        <tbody>\n                            <tr>\n                                <td class=\"actwid\"></td>\n                                <td></td>\n                                <td></td>\n                                <td></td>\n                                <td></td>\n                                <td></td>\n                                <td></td>\n                                <td></td>\n                                <td></td>\n                            </tr>\n                        </tbody>\n                    </table>\n                </div>\n            </div>\n\n        </div>\n    </div>\n</div>");

/***/ }),

/***/ 59861:
/*!*****************************************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/systemadmin/systemadmin.component.html ***!
  \*****************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"card \">\r\n    <div class=\"card-body\">\r\n        <div class=\"row\">\r\n\r\n            <div class=\"col-md-4 panelbox\">\r\n                <div class=\"panel panel-default\">\r\n                    <div class=\"panel-heading\">Instance</div>\r\n                    <div class=\"panel-body\">\r\n                        <div class=\"col-md-12\">\r\n                            <button type=\"button\" class=\"btn btn-link\" [routerLink]=\"['/views/masters/instanceprofile/instanceprofile']\" style=\"font-size: 14px; color: blue\">\r\n                                <i class=\"fa fa-angle-double-right\"></i> Instance Profile\r\n                            </button>\r\n                            <div style=\"border-bottom: dashed 1px;\"></div>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-4 panelbox\">\r\n                <div class=\"panel panel-default\">\r\n                    <div class=\"panel-heading\">Notification</div>\r\n                    <div class=\"panel-body\">\r\n\r\n                        <div class=\"col-md-12\">\r\n                            <button type=\"button\" class=\"btn btn-link\" style=\"font-size: 14px; color: blue\"><i class=\"fa fa-angle-double-right\"></i>  Notification Events</button>\r\n                            <div style=\"border-bottom: dashed 1px;\"></div>\r\n                        </div>\r\n                        <div class=\"col-md-12\">\r\n                            <button type=\"button\" class=\"btn btn-link\" style=\"font-size: 14px; color: blue\"><i class=\"fa fa-angle-double-right\"></i>  Notification Content</button>\r\n                            <div style=\"border-bottom: dashed 1px;\"></div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n\r\n            <div class=\"col-md-4 panelbox\">\r\n                <div class=\"panel panel-default\">\r\n                    <div class=\"panel-heading\">Workflow</div>\r\n                    <div class=\"panel-body\">\r\n\r\n\r\n                        <div class=\"col-md-12\">\r\n                            <button type=\"button\" class=\"btn btn-link\" style=\"font-size: 14px; color: blue\"><i class=\"fa fa-angle-double-right\"></i>  Rule Engine</button>\r\n                            <div style=\"border-bottom: dashed 1px;\"></div>\r\n                        </div>\r\n                        <div class=\"col-md-12\">\r\n                            <button type=\"button\" class=\"btn btn-link\" style=\"font-size: 14px; color: blue\">\r\n                                <i class=\"fa fa-angle-double-right\"></i>  Workflow Configuration\r\n                            </button>\r\n                            <div style=\"border-bottom: dashed 1px;\"></div>\r\n                        </div>\r\n\r\n\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n\r\n            <div class=\"col-md-4 panelbox\">\r\n                <div class=\"panel panel-default\">\r\n                    <div class=\"panel-heading\">\r\n                        Access Management\r\n                    </div>\r\n                    <div class=\"panel-body\">\r\n\r\n                        <div class=\"col-md-12\">\r\n                            <button type=\"button\" class=\"btn btn-link\" style=\"font-size: 14px; color: blue\"><i class=\"fa fa-angle-double-right\"></i>Users </button>\r\n                            <div style=\"border-bottom: dashed 1px;\"></div>\r\n                        </div>\r\n                        <div class=\"col-md-12\">\r\n                            <button type=\"button\" class=\"btn btn-link\" style=\"font-size: 14px; color: blue\"><i class=\"fa fa-angle-double-right\"></i>Roles </button>\r\n\r\n                        </div>\r\n\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n\r\n\r\n            <div class=\"col-md-4 panelbox\">\r\n                <div class=\"panel panel-default\">\r\n                    <div class=\"panel-heading\">Integration</div>\r\n                    <div class=\"panel-body\">\r\n\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n            <div class=\"col-md-4 panelbox\">\r\n                <div class=\"panel panel-default\">\r\n                    <div class=\"panel-heading\"> Document</div>\r\n                    <div class=\"panel-body\">\r\n\r\n                        <div class=\"col-md-12\">\r\n                            <button type=\"button\" class=\"btn btn-link\" style=\"font-size: 14px; color: blue\" [routerLink]=\"['/views/systemadmin/documentmanager/documentmanager']\"><i class=\"fa fa-angle-double-right\"></i>Document Manager </button>\r\n                            <div style=\"border-bottom: dashed 1px;\"></div>\r\n                        </div>\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n\r\n        </div>\r\n    </div>\r\n</div>");

/***/ }),

/***/ 13891:
/*!***********************************************************************************************************!*\
  !*** ./node_modules/@ngtools/webpack/src/loaders/direct-resource.js!./src/app/views/views.component.html ***!
  \***********************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("\n\n<!--<div id=\"wrapper\">\n    <div id=\"overlay\" style=\"display:none;\">\n        <div class=\"spinner\"></div>\n\n        <br />\n        Loading...\n    </div>\n    <button (click)=\"OnsubmitOverlay()\" type=\"button\">Click</button>-->\n    <!--<app-sidenav style=\"margin-top:50px;\">-->\n<div id=\"wrapper\">\n    <app-sidenav>\n    </app-sidenav>\n\n    <div class=\"content-page\">\n\n        <div class=\"content\">\n            <app-header></app-header>\n            <div class=\"page-content-wrapper dashborad-v\">\n                <router-outlet>\n\n                </router-outlet>\n\n            </div>\n\n        </div>\n\n    </div>\n</div>\n");

/***/ }),

/***/ 22978:
/*!*********************************************!*\
  !*** ./src/app/header/header.component.css ***!
  \*********************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJoZWFkZXIuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 55440:
/*!*******************************************!*\
  !*** ./src/app/login/login.component.css ***!
  \*******************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJsb2dpbi5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 20106:
/*!*************************************************!*\
  !*** ./src/app/nav-menu/nav-menu.component.css ***!
  \*************************************************/
/***/ (function(module) {

"use strict";
module.exports = "a.navbar-brand {\r\n  white-space: normal;\r\n  text-align: center;\r\n  word-break: break-all;\r\n}\r\n\r\nhtml {\r\n  font-size: 14px;\r\n}\r\n\r\n@media (min-width: 768px) {\r\n  html {\r\n    font-size: 16px;\r\n  }\r\n}\r\n\r\n.box-shadow {\r\n  box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05);\r\n}\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIm5hdi1tZW51LmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDRSxtQkFBbUI7RUFDbkIsa0JBQWtCO0VBQ2xCLHFCQUFxQjtBQUN2Qjs7QUFFQTtFQUNFLGVBQWU7QUFDakI7O0FBQ0E7RUFDRTtJQUNFLGVBQWU7RUFDakI7QUFDRjs7QUFFQTtFQUNFLDhDQUE4QztBQUNoRCIsImZpbGUiOiJuYXYtbWVudS5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiYS5uYXZiYXItYnJhbmQge1xyXG4gIHdoaXRlLXNwYWNlOiBub3JtYWw7XHJcbiAgdGV4dC1hbGlnbjogY2VudGVyO1xyXG4gIHdvcmQtYnJlYWs6IGJyZWFrLWFsbDtcclxufVxyXG5cclxuaHRtbCB7XHJcbiAgZm9udC1zaXplOiAxNHB4O1xyXG59XHJcbkBtZWRpYSAobWluLXdpZHRoOiA3NjhweCkge1xyXG4gIGh0bWwge1xyXG4gICAgZm9udC1zaXplOiAxNnB4O1xyXG4gIH1cclxufVxyXG5cclxuLmJveC1zaGFkb3cge1xyXG4gIGJveC1zaGFkb3c6IDAgLjI1cmVtIC43NXJlbSByZ2JhKDAsIDAsIDAsIC4wNSk7XHJcbn1cclxuIl19 */";

/***/ }),

/***/ 50970:
/*!*******************************************!*\
  !*** ./src/app/popup/popup.component.css ***!
  \*******************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJwb3B1cC5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 25287:
/*!***************************************************!*\
  !*** ./src/app/side-menu/side-menu.component.css ***!
  \***************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzaWRlLW1lbnUuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 40598:
/*!***********************************************!*\
  !*** ./src/app/sidenav/sidenav.component.css ***!
  \***********************************************/
/***/ (function(module) {

"use strict";
module.exports = ".mat-expansion-panel\r\n{\r\n    background:transparent;\r\n    box-shadow:none!important;\r\n    border-radius:unset!important;\r\n}\r\n.mat-expansion-panel-header\r\n{\r\n    height:38px!important;\r\n}\r\n.mat-expansion-panel-body {\r\n    padding: 0 0px 16px!important;\r\n}\r\n/*.mat-expansion-panel-header-title {\r\n    color: #fff !important;\r\n}*/\r\n.mat-expansion-panel-header-title[_ngcontent-ng-cli-universal-c0] {\r\n        color: #fff !important;\r\n        font-weight:bold!important;\r\n    }\r\n.mat-expansion-panel-header.dashboard {\r\n    /*   background-color: #4558be;*/\r\n    background-color: transparent;\r\n    height: 37px !important;\r\n}\r\n.mat-expansion-panel-header.dashboard .mat-expansion-panel-header-title a {\r\n        color: #fff!important;\r\n    }\r\n.mat-expansion-panel-header.dashboard .mat-expansion-panel-header-title a .mat-icon\r\n        {\r\n            font-size:21px;\r\n        }\r\n.mat-expansion-panel-header-description, .mat-expansion-panel-header-title {\r\n           /* color: #fff;*/\r\n        }\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNpZGVuYXYuY29tcG9uZW50LmNzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTs7SUFFSSxzQkFBc0I7SUFDdEIseUJBQXlCO0lBQ3pCLDZCQUE2QjtBQUNqQztBQUNBOztJQUVJLHFCQUFxQjtBQUN6QjtBQUNBO0lBQ0ksNkJBQTZCO0FBQ2pDO0FBQ0E7O0VBRUU7QUFDRTtRQUNJLHNCQUFzQjtRQUN0QiwwQkFBMEI7SUFDOUI7QUFDSjtJQUNJLGdDQUFnQztJQUNoQyw2QkFBNkI7SUFDN0IsdUJBQXVCO0FBQzNCO0FBQ0k7UUFDSSxxQkFBcUI7SUFDekI7QUFDSTs7WUFFSSxjQUFjO1FBQ2xCO0FBQ0E7V0FDRyxnQkFBZ0I7UUFDbkIiLCJmaWxlIjoic2lkZW5hdi5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLm1hdC1leHBhbnNpb24tcGFuZWxcclxue1xyXG4gICAgYmFja2dyb3VuZDp0cmFuc3BhcmVudDtcclxuICAgIGJveC1zaGFkb3c6bm9uZSFpbXBvcnRhbnQ7XHJcbiAgICBib3JkZXItcmFkaXVzOnVuc2V0IWltcG9ydGFudDtcclxufVxyXG4ubWF0LWV4cGFuc2lvbi1wYW5lbC1oZWFkZXJcclxue1xyXG4gICAgaGVpZ2h0OjM4cHghaW1wb3J0YW50O1xyXG59XHJcbi5tYXQtZXhwYW5zaW9uLXBhbmVsLWJvZHkge1xyXG4gICAgcGFkZGluZzogMCAwcHggMTZweCFpbXBvcnRhbnQ7XHJcbn1cclxuLyoubWF0LWV4cGFuc2lvbi1wYW5lbC1oZWFkZXItdGl0bGUge1xyXG4gICAgY29sb3I6ICNmZmYgIWltcG9ydGFudDtcclxufSovXHJcbiAgICAubWF0LWV4cGFuc2lvbi1wYW5lbC1oZWFkZXItdGl0bGVbX25nY29udGVudC1uZy1jbGktdW5pdmVyc2FsLWMwXSB7XHJcbiAgICAgICAgY29sb3I6ICNmZmYgIWltcG9ydGFudDtcclxuICAgICAgICBmb250LXdlaWdodDpib2xkIWltcG9ydGFudDtcclxuICAgIH1cclxuLm1hdC1leHBhbnNpb24tcGFuZWwtaGVhZGVyLmRhc2hib2FyZCB7XHJcbiAgICAvKiAgIGJhY2tncm91bmQtY29sb3I6ICM0NTU4YmU7Ki9cclxuICAgIGJhY2tncm91bmQtY29sb3I6IHRyYW5zcGFyZW50O1xyXG4gICAgaGVpZ2h0OiAzN3B4ICFpbXBvcnRhbnQ7XHJcbn1cclxuICAgIC5tYXQtZXhwYW5zaW9uLXBhbmVsLWhlYWRlci5kYXNoYm9hcmQgLm1hdC1leHBhbnNpb24tcGFuZWwtaGVhZGVyLXRpdGxlIGEge1xyXG4gICAgICAgIGNvbG9yOiAjZmZmIWltcG9ydGFudDtcclxuICAgIH1cclxuICAgICAgICAubWF0LWV4cGFuc2lvbi1wYW5lbC1oZWFkZXIuZGFzaGJvYXJkIC5tYXQtZXhwYW5zaW9uLXBhbmVsLWhlYWRlci10aXRsZSBhIC5tYXQtaWNvblxyXG4gICAgICAgIHtcclxuICAgICAgICAgICAgZm9udC1zaXplOjIxcHg7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIC5tYXQtZXhwYW5zaW9uLXBhbmVsLWhlYWRlci1kZXNjcmlwdGlvbiwgLm1hdC1leHBhbnNpb24tcGFuZWwtaGVhZGVyLXRpdGxlIHtcclxuICAgICAgICAgICAvKiBjb2xvcjogI2ZmZjsqL1xyXG4gICAgICAgIH0iXX0= */";

/***/ }),

/***/ 90275:
/*!***********************************************!*\
  !*** ./src/app/spinner/spinner.component.css ***!
  \***********************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcGlubmVyLmNvbXBvbmVudC5jc3MifQ== */";

/***/ }),

/***/ 49761:
/*!*********************************************************!*\
  !*** ./src/app/views/dashboard/dashboard.component.css ***!
  \*********************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJkYXNoYm9hcmQuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 6288:
/*!***************************************************************************************!*\
  !*** ./src/app/views/instanceprofile/clientmanagement/clientmanagement.component.css ***!
  \***************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjbGllbnRtYW5hZ2VtZW50LmNvbXBvbmVudC5jc3MifQ== */";

/***/ }),

/***/ 21903:
/*!***********************************************************************************!*\
  !*** ./src/app/views/instanceprofile/companydetails/companydetails.component.css ***!
  \***********************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjb21wYW55ZGV0YWlscy5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 88679:
/*!*********************************************************************************!*\
  !*** ./src/app/views/instanceprofile/configuration/configuration.component.css ***!
  \*********************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjb25maWd1cmF0aW9uLmNvbXBvbmVudC5jc3MifQ== */";

/***/ }),

/***/ 18811:
/*!*********************************************************************!*\
  !*** ./src/app/views/instanceprofile/instanceprofile.component.css ***!
  \*********************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJpbnN0YW5jZXByb2ZpbGUuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 25819:
/*!************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/cargopackage/cargopackage.component.css ***!
  \************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjYXJnb3BhY2thZ2UuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 34500:
/*!*********************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/cargopackage/cargopackageview/cargopackageview.component.css ***!
  \*********************************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjYXJnb3BhY2thZ2V2aWV3LmNvbXBvbmVudC5jc3MifQ== */";

/***/ }),

/***/ 69514:
/*!********************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/city/city.component.css ***!
  \********************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjaXR5LmNvbXBvbmVudC5jc3MifQ== */";

/***/ }),

/***/ 59581:
/*!*********************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/city/cityview/cityview.component.css ***!
  \*********************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjaXR5dmlldy5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 2675:
/*!******************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/commodity/commodity.component.css ***!
  \******************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjb21tb2RpdHkuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 24985:
/*!************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/commodity/commodityview/commodityview.component.css ***!
  \************************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjb21tb2RpdHl2aWV3LmNvbXBvbmVudC5jc3MifQ== */";

/***/ }),

/***/ 69635:
/*!***********************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/commonmaster.component.css ***!
  \***********************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjb21tb25tYXN0ZXIuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 26551:
/*!**************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/contypemaster/contypemaster.component.css ***!
  \**************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjb250eXBlbWFzdGVyLmNvbXBvbmVudC5jc3MifQ== */";

/***/ }),

/***/ 35108:
/*!************************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/contypemaster/contypemasterview/contypemasterview.component.css ***!
  \************************************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjb250eXBlbWFzdGVydmlldy5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 32814:
/*!**************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/country/country.component.css ***!
  \**************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjb3VudHJ5LmNvbXBvbmVudC5jc3MifQ== */";

/***/ }),

/***/ 62850:
/*!********************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/country/countryview1/countryview1.component.css ***!
  \********************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJjb3VudHJ5dmlldzEuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 20922:
/*!****************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/hazardousclass/hazardousclass.component.css ***!
  \****************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJoYXphcmRvdXNjbGFzcy5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 3794:
/*!***************************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview.component.css ***!
  \***************************************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJoYXphcmRvdXNjbGFzc3ZpZXcuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 65466:
/*!**********************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/partymaster/partymaster.component.css ***!
  \**********************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = ".chkvalues {\r\n    float: left;\r\n    padding-left: 20px;\r\n}\r\nlabel.chkbox {\r\n    line-height: 1;\r\n}\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInBhcnR5bWFzdGVyLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7SUFDSSxXQUFXO0lBQ1gsa0JBQWtCO0FBQ3RCO0FBQ0E7SUFDSSxjQUFjO0FBQ2xCIiwiZmlsZSI6InBhcnR5bWFzdGVyLmNvbXBvbmVudC5jc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuY2hrdmFsdWVzIHtcclxuICAgIGZsb2F0OiBsZWZ0O1xyXG4gICAgcGFkZGluZy1sZWZ0OiAyMHB4O1xyXG59XHJcbmxhYmVsLmNoa2JveCB7XHJcbiAgICBsaW5lLWhlaWdodDogMTtcclxufSJdfQ== */";

/***/ }),

/***/ 12655:
/*!******************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/partymaster/partymasterview/partymasterview.component.css ***!
  \******************************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJwYXJ0eW1hc3RlcnZpZXcuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 37590:
/*!********************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/port/port.component.css ***!
  \********************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJwb3J0LmNvbXBvbmVudC5jc3MifQ== */";

/***/ }),

/***/ 97706:
/*!*********************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/port/portview/portview.component.css ***!
  \*********************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJwb3J0dmlldy5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 57266:
/*!**********************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/shipmentlocations/shipmentlocations.component.css ***!
  \**********************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzaGlwbWVudGxvY2F0aW9ucy5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 73759:
/*!************************************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview.component.css ***!
  \************************************************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzaGlwbWVudGxvY2F0aW9uc3ZpZXcuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 53769:
/*!**********************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/statemaster/statemaster.component.css ***!
  \**********************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzdGF0ZW1hc3Rlci5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 6693:
/*!******************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/statemaster/statemasterview/statemasterview.component.css ***!
  \******************************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzdGF0ZW1hc3RlcnZpZXcuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 6158:
/*!**************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/storagelocationtype/storagelocationtype.component.css ***!
  \**************************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzdG9yYWdlbG9jYXRpb250eXBlLmNvbXBvbmVudC5jc3MifQ== */";

/***/ }),

/***/ 92629:
/*!******************************************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/storagelocationtype/storagelocationtypeview/storagelocationtypeview.component.css ***!
  \******************************************************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzdG9yYWdlbG9jYXRpb250eXBldmlldy5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 23368:
/*!****************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/terminal/terminal.component.css ***!
  \****************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ0ZXJtaW5hbC5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 62125:
/*!*********************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/terminal/terminalview/terminalview.component.css ***!
  \*********************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ0ZXJtaW5hbHZpZXcuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 67334:
/*!****************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/uomconversions/uomconversions.component.css ***!
  \****************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ1b21jb252ZXJzaW9ucy5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 69807:
/*!***************************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview.component.css ***!
  \***************************************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ1b21jb252ZXJzaW9uc3ZpZXcuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 50412:
/*!******************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/uommaster/uommaster.component.css ***!
  \******************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ1b21tYXN0ZXIuY29tcG9uZW50LmNzcyJ9 */";

/***/ }),

/***/ 55259:
/*!************************************************************************************************!*\
  !*** ./src/app/views/masters/commonmaster/uommaster/uommasterview/uommasterview.component.css ***!
  \************************************************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ1b21tYXN0ZXJ2aWV3LmNvbXBvbmVudC5jc3MifQ== */";

/***/ }),

/***/ 58847:
/*!*****************************************************!*\
  !*** ./src/app/views/masters/masters.component.css ***!
  \*****************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJtYXN0ZXJzLmNvbXBvbmVudC5jc3MifQ== */";

/***/ }),

/***/ 76633:
/*!*************************************************************!*\
  !*** ./src/app/views/systemadmin/systemadmin.component.css ***!
  \*************************************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzeXN0ZW1hZG1pbi5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 94805:
/*!*******************************************!*\
  !*** ./src/app/views/views.component.css ***!
  \*******************************************/
/***/ (function(module) {

"use strict";
module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJ2aWV3cy5jb21wb25lbnQuY3NzIn0= */";

/***/ }),

/***/ 42480:
/*!************************!*\
  !*** crypto (ignored) ***!
  \************************/
/***/ (function() {

/* (ignored) */

/***/ }),

/***/ 93414:
/*!************************!*\
  !*** canvas (ignored) ***!
  \************************/
/***/ (function() {

/* (ignored) */

/***/ }),

/***/ 70172:
/*!********************!*\
  !*** fs (ignored) ***!
  \********************/
/***/ (function() {

/* (ignored) */

/***/ }),

/***/ 2001:
/*!**********************!*\
  !*** http (ignored) ***!
  \**********************/
/***/ (function() {

/* (ignored) */

/***/ }),

/***/ 33779:
/*!***********************!*\
  !*** https (ignored) ***!
  \***********************/
/***/ (function() {

/* (ignored) */

/***/ }),

/***/ 66558:
/*!*********************!*\
  !*** url (ignored) ***!
  \*********************/
/***/ (function() {

/* (ignored) */

/***/ }),

/***/ 82258:
/*!**********************!*\
  !*** zlib (ignored) ***!
  \**********************/
/***/ (function() {

/* (ignored) */

/***/ })

},
/******/ function(__webpack_require__) { // webpackRuntimeModules
/******/ var __webpack_exec__ = function(moduleId) { return __webpack_require__(__webpack_require__.s = moduleId); }
/******/ __webpack_require__.O(0, ["vendor"], function() { return __webpack_exec__(14431); });
/******/ var __webpack_exports__ = __webpack_require__.O();
/******/ }
]);
//# sourceMappingURL=main-es2015.js.map