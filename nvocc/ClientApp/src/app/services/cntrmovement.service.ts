import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Globals } from '../globals';
import { CntrMovementMaster, CntrMovementDynamicGrid } from '../model/CntrMovement';
import {
    myenquiry, myCntrTypesDynamicGrid, myHazardousDynamicGrid, myDynamicOutGaugeCargoGrid, myDynamicReeferGrid,
    
} from '../model/enquiry';
import { Commodity, ContainerType, CTTypes, drodownVeslVoyage, GeneralMaster, Vessel, VoyageDetails } from '../model/common';
import { MyAgencyDropdown, MyCntrTypeDropdown, MyCustomerDropdown, MyPortdrodown, MyTerminaldrodown } from 'src/app/model/Admin';
@Injectable({
  providedIn: 'root'
})
export class CntrmovementService {

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
    getCntrMovementStatusCode(): Observable<CntrMovementMaster[]> {

        return this.http.post<CntrMovementMaster[]>(this.globals.APIURL + '/CntrMovement/CntrMovementStatusCode', this.createAuthHeader());
    }

    getStorageLocations(OL: CntrMovementMaster): Observable<CntrMovementMaster[]> {

        return this.http.post<CntrMovementMaster[]>(this.globals.APIURL + '/CntrMovement/CntrStorageLocation',OL, this.createAuthHeader());
    }

    getBookingNo(OL: CntrMovementMaster): Observable<CntrMovementMaster[]> {

        return this.http.post<CntrMovementMaster[]>(this.globals.APIURL + '/CntrMovement/getBookingNo',OL, this.createAuthHeader());
    }

    getvalidCntrNosValues(OL: CntrMovementDynamicGrid): Observable<CntrMovementDynamicGrid[]> {

        return this.http.post<CntrMovementDynamicGrid[]>(this.globals.APIURL + '/CntrMovement/getValidCntrvalues', OL, this.createAuthHeader());
    }

    SaveContainerList(OL: CntrMovementMaster): Observable<CntrMovementMaster[]> {

        return this.http.post<CntrMovementMaster[]>(this.globals.APIURL + '/CntrMovement/SaveContainerList', OL, this.createAuthHeader());
    }

    SearchContainerList(OL: CntrMovementMaster): Observable<CntrMovementMaster[]> {

        return this.http.post<CntrMovementMaster[]>(this.globals.APIURL + '/CntrMovement/SearchContainerList', OL, this.createAuthHeader());
    }

    ExistingBindContainerList(OL: CntrMovementMaster): Observable<CntrMovementMaster[]> {

        return this.http.post<CntrMovementMaster[]>(this.globals.APIURL + '/CntrMovement/ExistingBindContainerList', OL, this.createAuthHeader());
    }

    ExistingBindContainerListdtls(OL: CntrMovementDynamicGrid): Observable<CntrMovementDynamicGrid[]> {

        return this.http.post<CntrMovementDynamicGrid[]>(this.globals.APIURL + '/CntrMovement/ExistingContainerListDtls', OL, this.createAuthHeader());
    }

    getOfficeList(): Observable<MyCustomerDropdown[]> {

        return this.http.post<MyCustomerDropdown[]>(this.globals.APIURL + '/CommonAccessApi/OfficeLocationMaster', this.createAuthHeader());
    }

    getCntrNoList(): Observable<CntrMovementMaster[]> {

        return this.http.post<CntrMovementMaster[]>(this.globals.APIURL + '/CntrMovement/SearchContainerNoList', this.createAuthHeader());
    }

}
