import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Country, City, MyAgency, Port, Terminal, Commodity, Cargo, UOMtypes,UOMMaster, StateMaster, Depot, DamageMaster, RepairMaster, ContLocationMaster, Assembly, GeneralMaster, Notes, NotesGrid, ComponentMaster, ContainerType, CTTypes, State, Vessel, ServiceSetup, SlotOperator, VoyageDetails, DynamicGridSchedule, DynamicGridOperator, DynamicGridManifest, DynamicGridNotes, DynamicPDF1, shipmentLocations, Hazardous, UOMConversions, CTGroups, UOMValues, CurrencyName } from 'src/app/model/common';
import { SalesOffice } from 'src/app/model/org';
import { Globals } from '../globals';
import { Operator } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class MastersService {
    /*readonly APIUrl = "https://localhost:44301/api";*/
    constructor(private http: HttpClient, private globals: Globals) { }


    public authToken = "";

    loadToken() {
        const token = localStorage.getItem('Token');
        this.authToken = token;
    }
    createAuthHeader() {
        this.loadToken();
        const headers = new HttpHeaders().set(
            'Authorization',
            `Bearer ${this.authToken}`
        );
        return { headers };
    }
    getCountryList(OL: Country): Observable<Country[]> {

        return this.http.post<Country[]>(this.globals.APIURL + '/home/CountryView', OL,this.createAuthHeader());
    }

    getCountryEdit(OL: Country): Observable<Country[]> {
        return this.http.post<Country[]>(this.globals.APIURL + '/home/countryEdit',OL);
    }
    
    saveCtry(OD: Country) {
      
        return this.http.post(this.globals.APIURL + '/home/CountryInsert/',OD);
    }

    /*City*/

    getCityList(OL: City): Observable<City[]> {

        return this.http.post<City[]>(this.globals.APIURL + '/home/CityView', OL);
    }

    getCityEdit(OL: City): Observable<City[]> {
        return this.http.post<City[]>(this.globals.APIURL + '/home/CityEdit', OL);
    }
    saveCty(OD: City) {

        return this.http.post(this.globals.APIURL + '/home/City/', OD);
    }

    /*port*/
    getPortList(OL: Port): Observable<Port[]> {

        return this.http.post<Port[]>(this.globals.APIURL + '/home/Portview', OL);
    }

    getCountryBind(): Observable<Country[]> {

        return this.http.get<Country[]>(this.globals.APIURL + '/home/countryBind');
    }
    getPortEdit(OL: Port): Observable<Port[]>  {
        return this.http.post<Port[]>(this.globals.APIURL + '/home/Portviewedit', OL);

    }
    //getGeoLocByCountryBind(OL: MyAgency): Observable<MyAgency[]> {
    //    return this.http.post<MyAgency[]>(this.globals.APIURL + '/home/GeoLocByCountry' ,OL);
    //}

    getGeoLocByCountryBind(OL: SalesOffice): Observable<SalesOffice[]> {
        return this.http.post<SalesOffice[]>(this.globals.APIURL + '/OrgStructure/OfficeLocation', OL);
    }
    getGeoLocBind(OL: SalesOffice): Observable<SalesOffice[]> {
        return this.http.post<SalesOffice[]>(this.globals.APIURL + '/OrgStructure/OfficeLocationBind', OL);
    }

    savePort(OD: Port) {

        return this.http.post(this.globals.APIURL + '/home/Port/', OD);
    }

    /*Terminal*/

    getTerminalList(OL: Terminal): Observable<Terminal[]> {
        return this.http.post<Terminal[]>(this.globals.APIURL + '/home/TerminalView', OL);
    }

    getTerminaledit(OL: Terminal): Observable<Terminal[]> {
        return this.http.post<Terminal[]>(this.globals.APIURL + '/home/TerminalRecord', OL);
    }

    getPortBind(): Observable<Port[]> {
        return this.http.get<Port[]>(this.globals.APIURL + '/home/portBind');
    }

    saveTerminal(OD: Terminal) {

        return this.http.post(this.globals.APIURL + '/home/Terminal/', OD);
    }


    /*Commodity*/

    getCommodityList(OL: Commodity): Observable<Commodity[]> {
        return this.http.post<Commodity[]>(this.globals.APIURL + '/home/Commodityview', OL);
    }

    getCommodityedit(OL: Commodity): Observable<Commodity[]> {
        return this.http.post<Commodity[]>(this.globals.APIURL + '/home/Commodityviewedit', OL);
    }

    saveCommodity(OD: Commodity) {
        return this.http.post(this.globals.APIURL + '/home/Commodity', OD);
    }

    getCommodityTypes(OL: Commodity): Observable<Commodity[]> {
        return this.http.post<Commodity[]>(this.globals.APIURL + '/home/CommodityTypes', OL);
    }

    /*Cargo*/

    getCargoList(OL: Cargo): Observable<Cargo[]> {
        return this.http.post<Cargo[]>(this.globals.APIURL + '/home/CargoPkgview', OL);
    }

    getCargoedit(OL: Cargo): Observable<Cargo[]> {
        return this.http.post<Cargo[]>(this.globals.APIURL + '/home/CargoPkgviewedit', OL);
    }

    saveCargo(OD: Cargo) {
        return this.http.post(this.globals.APIURL + '/home/CargoPackage', OD);
    }


    /*UOMMaster*/

    saveUOM(OD: UOMMaster) {
        return this.http.post(this.globals.APIURL + '/home/UOMMaster', OD);
    }

    getUOMedit(OL: UOMMaster): Observable<UOMMaster[]> {
        return this.http.post<UOMMaster[]>(this.globals.APIURL + '/home/UOMMasterviewedit', OL);
    }

    getUOMList(OL: UOMMaster): Observable<UOMMaster[]> {
        return this.http.post<UOMMaster[]>(this.globals.APIURL + '/home/UOMMasterview', OL);
    }
    getUOMTypes(OL: UOMtypes): Observable<UOMtypes[]> {
        return this.http.post<UOMtypes[]>(this.globals.APIURL + '/home/UOMTypes', OL);
    }
    getUOMActions(OL: UOMtypes): Observable<UOMtypes[]> {
        return this.http.post<UOMtypes[]>(this.globals.APIURL + '/home/UOMActions', OL);
    }
    getUOMValues(OL: UOMValues): Observable<UOMValues[]> {
        return this.http.post<UOMValues[]>(this.globals.APIURL + '/home/UOMValues', OL);
    }
    
    /*StateMaster*/

    saveState(OD: StateMaster) {
        return this.http.post(this.globals.APIURL + '/home/State', OD);
    }

    getStateedit(OL: StateMaster): Observable<StateMaster[]> {
        return this.http.post<StateMaster[]>(this.globals.APIURL + '/home/StateRecord', OL);
    }

    getStateList(OL: StateMaster): Observable<StateMaster[]> {
        return this.http.post<StateMaster[]>(this.globals.APIURL + '/home/StateView', OL);
    }

    getStateBind(): Observable<StateMaster[]> {
        return this.http.get<StateMaster[]>(this.globals.APIURL + '/home/stateBind');
    }
    getStatesBindByCtry(OL: State): Observable<State[]> {

        return this.http.post<State[]>(this.globals.APIURL + '/OrgStructure/BindStatesByCountry', OL, this.createAuthHeader());
    }

    /* Depot Master */

    getDepotList(OL: Depot): Observable<Depot[]> {
        return this.http.post<Depot[]>(this.globals.APIURL + '/home/DepotView', OL);
    }

    getDepotedit(OL: Depot): Observable<Depot[]> {
        return this.http.post<Depot[]>(this.globals.APIURL + '/home/DepotRecord', OL);
    }


    getDepoteditDtls(OL: Depot): Observable<Depot[]> {
        return this.http.post<Depot[]>(this.globals.APIURL + '/home/BindDepoMasterPortDtls', OL);
    }

    saveDepot(OD: Depot) {
        return this.http.post(this.globals.APIURL + '/home/Depot', OD);
    }

    getCityBind(OL: City): Observable<City[]> {
        return this.http.post<City[]>(this.globals.APIURL + '/home/cityBind', OL);
    }

    getPortByCountryBind(id): Observable<Depot[]> {
        return this.http.get<Depot[]>(this.globals.APIURL + '/home/PortByCountry/' + id);
    }


    getCityByCountryBind(id): Observable<City[]> {
        return this.http.get<City[]>(this.globals.APIURL + '/home/BindCities/' + id);
    }

    /*DamageMaster*/

    saveDamage(OD: DamageMaster) {
        return this.http.post(this.globals.APIURL + '/home/DamageMaster', OD);
    }

    getDamageedit(OL: DamageMaster): Observable<DamageMaster[]> {
        return this.http.post<DamageMaster[]>(this.globals.APIURL + '/home/DamageMasterviewedit', OL);
    }

    getDamageList(OL: DamageMaster): Observable<DamageMaster[]> {
        return this.http.post<DamageMaster[]>(this.globals.APIURL + '/home/DamageMasterview', OL);
    }

    /*RepairMaster*/

    saveRepair(OD: RepairMaster) {
        return this.http.post(this.globals.APIURL + '/home/RepairMaster', OD);
    }

    getRepairedit(OL: RepairMaster): Observable<RepairMaster[]> {
        return this.http.post<RepairMaster[]>(this.globals.APIURL + '/home/RepairMasterviewedit', OL);
    }

    getRepairList(OL: RepairMaster): Observable<RepairMaster[]> {
        return this.http.post<RepairMaster[]>(this.globals.APIURL + '/home/RepairMasterview', OL);
    }
    /*ContLocationMaster*/

    saveContLocation(OD: ContLocationMaster) {
        return this.http.post(this.globals.APIURL + '/home/ContLocationMaster', OD);
    }

    getContLocationedit(OL: ContLocationMaster): Observable<ContLocationMaster[]> {
        return this.http.post<ContLocationMaster[]>(this.globals.APIURL + '/home/ContLocationMasterviewedit', OL);
    }

    getContLocationList(OL: ContLocationMaster): Observable<ContLocationMaster[]> {
        return this.http.post<ContLocationMaster[]>(this.globals.APIURL + '/home/ContLocationMasterview', OL);
    }

    /*ComponentMaster*/

    saveComponent(OD: ComponentMaster) {
        return this.http.post(this.globals.APIURL + '/home/MNRComponentMaster', OD);
    }

    getComponentedit(OL: ComponentMaster): Observable<ComponentMaster[]> {
        return this.http.post<ComponentMaster[]>(this.globals.APIURL + '/home/MNRComponentViewEdit', OL);
    }

    getComponentList(OL: ComponentMaster): Observable<ComponentMaster[]> {
        return this.http.post<ComponentMaster[]>(this.globals.APIURL + '/home/MNRComponentView', OL);
    }

    getAssemblyBind(OL: GeneralMaster): Observable<GeneralMaster[]> {
        return this.http.post<GeneralMaster[]>(this.globals.APIURL + '/home/BindAssembly', OL);
    }

    getNotesList(OL: Notes): Observable<Notes[]> {
        return this.http.post<Notes[]>(this.globals.APIURL + '/home/NotesandClausesView', OL);
    }
    SaveNotes(OD: NotesGrid) {
        return this.http.post(this.globals.APIURL + '/home/NotesandClausesInsert', OD);
    }
    getNotesEditDtls(OL: NotesGrid): Observable<NotesGrid[]> {
        return this.http.post<NotesGrid[]>(this.globals.APIURL + '/home/ExistingNotesandClauses', OL);
    }

    DeleteNotes(OD: NotesGrid) {
        return this.http.post(this.globals.APIURL + '/home/NotesandClausesDelete', OD);
    }

    /*ContTypeMaster*/

    saveContType(OD: ContainerType) {
        return this.http.post(this.globals.APIURL + '/home/ContTypeMaster', OD);
    }

    getContTypeedit(OL: ContainerType): Observable<ContainerType[]> {
        return this.http.post<ContainerType[]>(this.globals.APIURL + '/home/ContTypeMasterviewedit', OL);
    }

    getContTypeList(OL: ContainerType): Observable<ContainerType[]> {
        return this.http.post<ContainerType[]>(this.globals.APIURL + '/home/ContTypeMasterview', OL);
    }

    getContainerTypes(OL: ContainerType): Observable<ContainerType[]> {
        return this.http.post<ContainerType[]>(this.globals.APIURL + '/home/CntrTypeValues', OL);
    }

    getContainerSize(OL: CTTypes): Observable<CTTypes[]> {
        return this.http.post<CTTypes[]>(this.globals.APIURL + '/home/ContainerSize', OL);
    }
    getContainerGroup(OL: CTGroups): Observable<CTGroups[]> {
        return this.http.post<CTGroups[]>(this.globals.APIURL + '/home/ContainerGroup', OL);
    }
    
    /*Vessel Master*/

    getVesselList(OL: ContainerType): Observable<Vessel[]> {
        return this.http.post<Vessel[]>(this.globals.APIURL + '/home/Vesselview', OL);
    }
    getVesseledit(OL: Vessel): Observable<Vessel[]> {
        return this.http.post<Vessel[]>(this.globals.APIURL + '/home/Vesselviewparticular', OL);
    }
    saveVessel(OD: Vessel) {
        return this.http.post(this.globals.APIURL + '/home/Vessel', OD);
    }

    /*Service Setup*/

    getServiceSetupList(OL: ServiceSetup): Observable<ServiceSetup[]> {
        return this.http.post<ServiceSetup[]>(this.globals.APIURL + '/home/ServiceSetupView', OL);
    }
    getServiceSetupedit(OL: ServiceSetup): Observable<ServiceSetup[]> {
        return this.http.post<ServiceSetup[]>(this.globals.APIURL + '/home/ServiceSetupEdit', OL);
    }
    saveServiceSetup(OD: ServiceSetup) {
        return this.http.post(this.globals.APIURL + '/home/InsertServiceSetup', OD);
    }
    getServiceSetupRoutedit(OL: ServiceSetup): Observable<ServiceSetup[]> {
        return this.http.post<ServiceSetup[]>(this.globals.APIURL + '/home/ServiceRouteEdit', OL);
    }
    getOperatorBind(OL: SlotOperator): Observable<SlotOperator[]> {
        return this.http.post<SlotOperator[]>(this.globals.APIURL + '/CommonAccessApi/CustomerBussTypesMaster', OL);
    }
    getServiceOperatoredit(OL: ServiceSetup): Observable<ServiceSetup[]> {
        return this.http.post<ServiceSetup[]>(this.globals.APIURL + '/home/ServiceOperatorsEdit', OL);
    }
    getServiceRouteDelete(OL: ServiceSetup): Observable<ServiceSetup[]> {
        return this.http.post<ServiceSetup[]>(this.globals.APIURL + '/home/ServiceRouteDelete', OL);
    }
    getServiceOperatorDelete(OL: ServiceSetup): Observable<ServiceSetup[]> {
        return this.http.post<ServiceSetup[]>(this.globals.APIURL + '/home/ServiceOperatorsDelete', OL);
    }

    /*Voyage Details*/

    getVoyageList(OL: VoyageDetails): Observable<VoyageDetails[]> {
        return this.http.post<VoyageDetails[]>(this.globals.APIURL + '/home/VoyageDetailsView', OL);
    }

    getServiceBind(OL: ServiceSetup): Observable<ServiceSetup[]> {
        return this.http.post<ServiceSetup[]>(this.globals.APIURL + '/home/BindServices', OL);
    }
    getVesselBind(OL: Vessel): Observable<Vessel[]> {
        return this.http.post<Vessel[]>(this.globals.APIURL + '/home/VesselDropDown', OL);
    }
    getPortbyServiceBind(OL: DynamicGridSchedule): Observable<DynamicGridSchedule[]> {
        return this.http.post<DynamicGridSchedule[]>(this.globals.APIURL + '/home/BindServiceSchedule', OL);
    }
    getTerminalbyPort(OL: Terminal): Observable<Terminal[]> {
        return this.http.post<Terminal[]>(this.globals.APIURL + '/home/BindTerminalByPort', OL);
    }
    saveVoyageDetails(OD: VoyageDetails) {
        return this.http.post(this.globals.APIURL + '/home/InsertVoyageFirstTab', OD);
    }

    getVoyageEdit(OL: VoyageDetails): Observable<VoyageDetails[]> {
        return this.http.post<VoyageDetails[]>(this.globals.APIURL + '/home/VoyageDetailsEdit', OL);
    }
    getVoyageDtlsEdit(OL: DynamicGridSchedule): Observable<DynamicGridSchedule[]> {
        return this.http.post<DynamicGridSchedule[]>(this.globals.APIURL + '/home/VoyageSailingDetailsEdit', OL);
    }

    saveVoyageOperator(OD: VoyageDetails) {
        return this.http.post(this.globals.APIURL + '/home/InsertOperatorServices', OD);
    }
    getVoyageOperatorEdit(OL: DynamicGridOperator): Observable<DynamicGridOperator[]> {
        return this.http.post<DynamicGridOperator[]>(this.globals.APIURL + '/home/VoyageOperatorsEdit', OL);
    }

    getVoyageOperatorDelete(OL: DynamicGridOperator): Observable<DynamicGridOperator[]> {
        return this.http.post<DynamicGridOperator[]>(this.globals.APIURL + '/home/VoyageOperatorsDelete', OL);
    }

    saveVoyageManifest(OD: DynamicGridManifest) {
        return this.http.post(this.globals.APIURL + '/home/InsertManifestDtls', OD);
    }
    getVoyageManifestEdit(OL: DynamicGridManifest): Observable<DynamicGridManifest[]> {
        return this.http.post<DynamicGridManifest[]>(this.globals.APIURL + '/home/ViewManifestDtls', OL);
    }
    getVoyageType(OL: GeneralMaster): Observable<GeneralMaster[]> {
        return this.http.post<GeneralMaster[]>(this.globals.APIURL + '/home/BindVoyageTypes', OL);
    }
    saveVoyageNotes(OD: DynamicGridNotes) {
        return this.http.post(this.globals.APIURL + '/home/InsertVoyageNotes', OD);
    }
    getVoyageNotesEdit(OL: DynamicGridNotes): Observable<DynamicGridNotes[]> {
        return this.http.post<DynamicGridNotes[]>(this.globals.APIURL + '/home/BindVoyageNotes', OL);
    }
    getVoyageNotesDelete(OL: DynamicGridNotes): Observable<DynamicGridNotes[]> {
        return this.http.post<DynamicGridNotes[]>(this.globals.APIURL + '/home/VoyageNotesDelete', OL);
    }

    getPDF(OL: DynamicPDF1): Observable<DynamicPDF1[]> {
       
        return this.http.post<DynamicPDF1[]>(this.globals.APIURL + '/home/BLPrintPDF', OL);
    }


    //Aravind
    getHSCode(OL: Commodity): Observable<Commodity[]> {
        return this.http.post<Commodity[]>(this.globals.APIURL + '/home/GetHSCode', OL);
    }

    //udhaya ShipmentLocations


    getSaveshipmentlocation(OL: shipmentLocations): Observable<shipmentLocations[]> {

        return this.http.post<shipmentLocations[]>(this.globals.APIURL + '/home/InsertShipment', OL);

    }

    ShipmentLocationList(OL: shipmentLocations): Observable<shipmentLocations[]> {

        return this.http.post<shipmentLocations[]>(this.globals.APIURL + '/home/ShipmentLocationList', OL);

    }

    ShipmentLocationEdit(OL: shipmentLocations): Observable<shipmentLocations[]> {

        return this.http.post<shipmentLocations[]>(this.globals.APIURL + '/home/ShipmentLocationEdit', OL);

    }

    getCountry(OL: Country): Observable<Country[]> {
        return this.http.post<Country[]>(this.globals.APIURL + '/home/countryList', OL);
    }

    getcitylist(OL: City): Observable<City[]> {

        return this.http.post<City[]>(this.globals.APIURL + '/home/Citylist', OL);
    }

    //Hazardous Classes


    getSaveHazardousClasses(OL: Hazardous): Observable<Hazardous[]> {

        return this.http.post<Hazardous[]>(this.globals.APIURL + '/home/InsertHazardousClasses', OL);

    }
    HazardousEdit(OL: Hazardous): Observable<Hazardous[]> {

        return this.http.post<Hazardous[]>(this.globals.APIURL + '/home/HazardousEdit', OL);

    }

    HazardousClassesList(OL: Hazardous): Observable<Hazardous[]> {

        return this.http.post<Hazardous[]>(this.globals.APIURL + '/home/HazardousClassesList', OL);

    }

    //UOM Conversions 
    SaveUOMConversions(OL: UOMConversions): Observable<UOMConversions[]> {

        return this.http.post<UOMConversions[]>(this.globals.APIURL + '/home/InsertUOMConversions', OL);

    }

    UOMConversionsEdit(OL: UOMConversions): Observable<UOMConversions[]> {

        return this.http.post<UOMConversions[]>(this.globals.APIURL + '/home/UOMConversionsEdit', OL);

    }

    UOMConversionsList(OL: UOMConversions): Observable<UOMConversions[]> {

        return this.http.post<UOMConversions[]>(this.globals.APIURL + '/home/UOMConversionsList', OL);

    }

    //Currency Name master

    getCurrencyList(OL: CurrencyName): Observable<CurrencyName[]> {

        return this.http.post<CurrencyName[]>(this.globals.APIURL + '/home/getCurrencyList', OL);

    }
    saveCurrency(OL: CurrencyName): Observable<CurrencyName[]> {

        return this.http.post<CurrencyName[]>(this.globals.APIURL + '/home/saveCurrency', OL);

    }

    Currencyedit(OL: CurrencyName): Observable<CurrencyName[]> {

        return this.http.post<CurrencyName[]>(this.globals.APIURL + '/home/Currencyedit', OL);

    }


}
