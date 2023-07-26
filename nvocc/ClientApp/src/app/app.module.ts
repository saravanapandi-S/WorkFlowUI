import { BrowserModule, Title } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { LoginRoutingModule } from './login-routing.module';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatRadioModule } from '@angular/material/radio';
import { PdfViewerModule } from 'ng2-pdf-viewer';
import { Globals } from './globals'
import { MatDatepickerModule } from '@angular/material/datepicker';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HeaderComponent } from './header/header.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { CountryComponent } from './views/masters/commonmaster/country/country.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatMenuModule } from '@angular/material/menu';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
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
import { MatSelectModule } from '@angular/material/select';
import { LoginComponent } from './login/login.component';
import { AuthguardServiceService } from './authguard-service.service';
import { MatDialogModule, MatCheckboxModule } from '@angular/material';
import { PopupComponent } from './popup/popup.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { ViewsComponent } from './views/views.component';
import { MastersComponent } from './views/masters/masters.component';
import { CommonmasterComponent } from './views/masters/commonmaster/commonmaster.component';
import { EncrDecrServiceService } from 'src/app/services/encr-decr-service.service';
import { SelectAutocompleteModule } from 'mat-select-autocomplete';
import { MatInputModule } from '@angular/material/input';
import { PartymasterComponent } from './views/masters/commonmaster/partymaster/partymaster.component';
import { PartymasterviewComponent } from './views/masters/commonmaster/partymaster/partymasterview/partymasterview.component';

import { SpinnerComponent } from './spinner/spinner.component';
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








@NgModule({
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    declarations: [

        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent,
        HeaderComponent,
        SidenavComponent,
        SideMenuComponent,
        CountryComponent,
        Countryview1Component,
        CityComponent,
        CityviewComponent,
        CommodityComponent,
        CommodityviewComponent,
        CargopackageComponent,
        CargopackageviewComponent,    
        PortComponent,
        PortviewComponent,
        TerminalComponent,
        TerminalviewComponent,    
        LoginComponent,
        PopupComponent,
        ViewsComponent,
        MastersComponent,
        CommonmasterComponent, 
        UommasterComponent,
        UommasterviewComponent,
        StatemasterComponent,
        StatemasterviewComponent,
        ContypemasterComponent,
        ContypemasterviewComponent,    
        PartymasterviewComponent,
        PartymasterComponent,
        
          SpinnerComponent,
        StoragelocationtypeComponent,
        StoragelocationtypeviewComponent,
        DashboardComponent,
        SystemadminComponent,
        ShipmentlocationsComponent,
        ShipmentlocationsviewComponent,
        HazardousclassComponent,
        HazardousclassviewComponent,
        UomconversionsComponent,
        UomconversionsviewComponent, 
        InstanceprofileComponent,
        CompanydetailsComponent,
        ClientmanagementComponent,
        ConfigurationComponent,
    
        CurrencyComponent,  
        CurrencyviewComponent, 
        DocumentmanagerComponent

    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        AppRoutingModule,
        LoginRoutingModule,
        FormsModule,
        MatGridListModule,
        MatMenuModule,
        MatIconModule,
        MatListModule,
        MatExpansionModule,
        MatToolbarModule,
        MatButtonModule,
        MatDatepickerModule,
        RouterModule,
        MatDialogModule,
        ReactiveFormsModule,
        MatSelectModule,
        MatAutocompleteModule,
        SelectAutocompleteModule,
        MatCheckboxModule,
        MatInputModule,
        PdfViewerModule,




        //RouterModule.forRoot([
        //  { path: '', component: HomeComponent, pathMatch: 'full' },
        //  { path: 'counter', component: CounterComponent },
        //    { path: 'fetch-data', component: FetchDataComponent },
        //    { path: 'masters/country/countryview', component: CountryviewComponent },
        //    { path: 'masters/country/countryview1', component: Countryview1Component },
        //]),
        BrowserAnimationsModule
    ],
    providers: [AuthguardServiceService, EncrDecrServiceService, Globals, Title, ],
    bootstrap: [AppComponent],

})
export class AppModule { }
