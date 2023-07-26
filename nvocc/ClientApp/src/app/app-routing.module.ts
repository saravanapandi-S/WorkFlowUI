import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CountryComponent } from './views/masters/commonmaster/country/country.component';
import { Countryview1Component } from './views/masters/commonmaster/country/countryview1/countryview1.component';
import { CityComponent } from './views/masters/commonmaster/city/city.component';
import { CityviewComponent } from './views/masters/commonmaster/city/cityview/cityview.component';
import { CommodityComponent } from './views/masters/commonmaster/commodity/commodity.component';
import { CommodityviewComponent } from './views/masters/commonmaster/commodity/commodityview/commodityview.component';
import { CargopackageComponent } from './views/masters/commonmaster/cargopackage/cargopackage.component';
import { CargopackageviewComponent } from './views/masters/commonmaster/cargopackage/cargopackageview/cargopackageview.component';
import { PortComponent } from './views/masters/commonmaster/port/port.component';
import { PortviewComponent } from './views/masters/commonmaster/port/portview/portview.component';
import { TerminalComponent } from './views/masters/commonmaster/terminal/terminal.component';
import { TerminalviewComponent } from './views/masters/commonmaster/terminal/terminalview/terminalview.component';
import { UommasterComponent } from './views/masters/commonmaster/uommaster/uommaster.component';
import { UommasterviewComponent } from './views/masters/commonmaster/uommaster/uommasterview/uommasterview.component';
import { StatemasterComponent } from './views/masters/commonmaster/statemaster/statemaster.component';
import { StatemasterviewComponent } from './views/masters/commonmaster/statemaster/statemasterview/statemasterview.component';
import { ContypemasterComponent } from './views/masters/commonmaster/contypemaster/contypemaster.component';
import { ContypemasterviewComponent } from './views/masters/commonmaster/contypemaster/contypemasterview/contypemasterview.component';

import { LoginComponent } from './login/login.component';
import { AuthenticationGuard } from './authentication.guard';

import { ViewsComponent } from './views/views.component';
import { MastersComponent } from './views/masters/masters.component';

import { CommonmasterComponent } from './views/masters/commonmaster/commonmaster.component';



import { PartymasterComponent } from './views/masters/commonmaster/partymaster/partymaster.component';
import { PartymasterviewComponent } from './views/masters/commonmaster/partymaster/partymasterview/partymasterview.component';




import { StoragelocationtypeComponent } from './views/masters/commonmaster/storagelocationtype/storagelocationtype.component';
import { StoragelocationtypeviewComponent } from './views/masters/commonmaster/storagelocationtype/storagelocationtypeview/storagelocationtypeview.component';
import { DashboardComponent } from './views/dashboard/dashboard.component';
import { SystemadminComponent } from './views/systemadmin/systemadmin.component';

import { ShipmentlocationsComponent } from './views/masters/commonmaster/shipmentlocations/shipmentlocations.component';
import { ShipmentlocationsviewComponent } from './views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview.component';
import { HazardousclassComponent } from './views/masters/commonmaster/hazardousclass/hazardousclass.component';
import { HazardousclassviewComponent } from './views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview.component';
import { UomconversionsComponent } from './views/masters/commonmaster/uomconversions/uomconversions.component';
import { UomconversionsviewComponent } from './views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview.component';

import { InstanceprofileComponent } from './views/instanceprofile/instanceprofile.component';
import { CompanydetailsComponent } from './views/instanceprofile/companydetails/companydetails.component';
import { ClientmanagementComponent } from './views/instanceprofile/clientmanagement/clientmanagement.component';
import { ConfigurationComponent } from './views/instanceprofile/configuration/configuration.component';

import { CurrencyComponent } from './views/masters/commonmaster/currency/currency.component';
import { CurrencyviewComponent } from './views/masters/commonmaster/currency/currencyview/currencyview.component';
import { DocumentmanagerComponent } from './views/systemadmin/documentmanager/documentmanager.component';




const routes: Routes = [

    { path: '', redirectTo: "/login", pathMatch: 'full' },
    { path: 'login', component: LoginComponent },


    {
        path: 'views', component: ViewsComponent, canActivate: [AuthenticationGuard],

        children: [
            { path: 'dashboard', component: DashboardComponent },
            { path: 'systemadmin', component: SystemadminComponent },
            { path: 'masters/commonmaster', component: CommonmasterComponent },
         
            { path: 'masters/commonmaster/country/country', component: CountryComponent },
            { path: 'masters/commonmaster/country/countryview1', component: Countryview1Component },
            { path: 'masters/commonmaster/country/country', component: CountryComponent },
            { path: 'masters/masters', component: MastersComponent },

            { path: 'masters/commonmaster/city/city', component: CityComponent },
            { path: 'masters/commonmaster/city/cityview', component: CityviewComponent },
            { path: 'masters/commonmaster/commodity/commodity', component: CommodityComponent },
            { path: 'masters/commonmaster/commodity/commodityview', component: CommodityviewComponent },
            { path: 'masters/commonmaster/cargopackage/cargopackage', component: CargopackageComponent },
            { path: 'masters/commonmaster/cargopackage/cargopackageview', component: CargopackageviewComponent },
            { path: 'masters/commonmaster/port/port', component: PortComponent },
            { path: 'masters/commonmaster/port/portview', component: PortviewComponent },
            { path: 'masters/commonmaster/terminal/terminal', component: TerminalComponent },
            { path: 'masters/commonmaster/terminal/terminalview', component: TerminalviewComponent },
            { path: 'masters/commonmaster/uommaster/uommaster', component: UommasterComponent },
            { path: 'masters/commonmaster/uommaster/uommasterview', component: UommasterviewComponent },
            { path: 'masters/commonmaster/statemaster/statemaster', component: StatemasterComponent },
            { path: 'masters/commonmaster/statemaster/statemasterview', component: StatemasterviewComponent },
            { path: 'masters/commonmaster/contypemaster/contypemaster', component: ContypemasterComponent },
            { path: 'masters/commonmaster/contypemaster/contypemasterview', component: ContypemasterviewComponent },           
            { path: 'masters/commonmaster/partymaster/partymaster', component: PartymasterComponent },
            { path: 'masters/commonmaster/partymaster/partymasterview', component: PartymasterviewComponent },    
           
            { path: 'masters/commonmaster/storagelocationtype/storagelocationtype', component: StoragelocationtypeComponent },
            { path: 'masters/commonmaster/storagelocationtype/storagelocationtypeview/storagelocationtypeview', component: StoragelocationtypeviewComponent },      


            { path: 'masters/commonmaster/shipmentlocations/shipmentlocations', component: ShipmentlocationsComponent },
            { path: 'masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview', component: ShipmentlocationsviewComponent },
            { path: 'masters/commonmaster/hazardousclass/hazardousclass', component: HazardousclassComponent },
            { path: 'masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview', component: HazardousclassviewComponent },
            { path: 'masters/commonmaster/uomconversions/uomconversions', component: UomconversionsComponent },
            { path: 'masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview', component: UomconversionsviewComponent },

            { path: 'masters/instanceprofile/instanceprofile', component: InstanceprofileComponent },
            { path: 'masters/instanceprofile/companydetails/companydetails', component: CompanydetailsComponent },
            { path: 'masters/instanceprofile/clientmanagement/clientmanagement', component: ClientmanagementComponent },
            { path: 'masters/instanceprofile/configuration/configuration', component: ConfigurationComponent }, 
            
            { path: 'masters/commonmaster/currency/currency', component: CurrencyComponent },   
            { path: 'masters/commonmaster/currency/currencyview/currencyview', component: CurrencyviewComponent },   
            { path: 'systemadmin/documentmanager/documentmanager', component: DocumentmanagerComponent },
         



        ]

    },

];

@NgModule({
    declarations: [],
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
