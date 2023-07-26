import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { map, skipWhile, tap } from 'rxjs/operators';
import { MyAgencyDropdown, MyCntrTypeDropdown, MyCustomerDropdown, MyPortdrodown, MyTerminaldrodown } from 'src/app/model/Admin';

import { BLCargoDtls, BLContainer, BLNo, BLTypes, BOL, PortVessel, DynamicGridAttach, BLNotes } from 'src/app/model/boldata';
import { Globals } from '../globals';
import { MyImpBL, MyImpBlCntrList, MyImpHBlNoList } from '../model/ImpBL';
import { MyLinerDropdown } from '../model/enquiry';
import { CntrPickDrop } from '../model/CntrPickDepo';

@Injectable({
    providedIn: 'root'
})
export class ImpblService {

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

    InsertImpBL(OL: MyImpBL): Observable<MyImpBL[]> {

        return this.http.post<MyImpBL[]>(this.globals.APIURL + '/ImpBLApi/ImpBLInsert', OL, this.createAuthHeader());
    }

    getCntrNoList(): Observable<CntrPickDrop[]> {

        return this.http.post<CntrPickDrop[]>(this.globals.APIURL + '/ImpBLApi/ContainerValues', this.createAuthHeader());
    }

    //getImpBLList(): Observable<MyImpBL[]> {

    //    return this.http.post<MyImpBL[]>(this.globals.APIURL + '/ImpBLApi/ImpBLview', this.createAuthHeader());
    //}

    bindExstingImpBLList(OL: MyImpBL): Observable<MyImpBL[]> {

        return this.http.post<MyImpBL[]>(this.globals.APIURL + '/ImpBLApi/ExistingImpBL', OL, this.createAuthHeader());
    }


    bindExstingImpBLCntrList(OL: MyImpBlCntrList): Observable<MyImpBlCntrList[]> {

        return this.http.post<MyImpBlCntrList[]>(this.globals.APIURL + '/ImpBLApi/ExistingImpBLCntr', OL, this.createAuthHeader());
    }

    InsertImpBLCntr(OL: MyImpBL): Observable<MyImpBL[]> {

        return this.http.post<MyImpBL[]>(this.globals.APIURL + '/ImpBLApi/ImpBLCntrInsert', OL, this.createAuthHeader());
    }

    bindExstingImpBLCntrvaluesList(OL: MyImpBL): Observable<MyImpBL[]> {

        return this.http.post<MyImpBL[]>(this.globals.APIURL + '/ImpBLApi/ExistingCntrvaluesImpBL', OL, this.createAuthHeader());
    }


    InsertImpHBL(OL: MyImpBL): Observable<MyImpBL[]> {

        return this.http.post<MyImpBL[]>(this.globals.APIURL + '/ImpBLApi/ImpHBLInsert', OL, this.createAuthHeader());
    }

    ImpHBLNoList(OL: MyImpHBlNoList): Observable<MyImpHBlNoList[]> {

        return this.http.post<MyImpHBlNoList[]>(this.globals.APIURL + '/ImpBLApi/ImpHBLNo', OL, this.createAuthHeader());
    }

    bindExstingImpHBLList(OL: MyImpBL): Observable<MyImpBL[]> {

        return this.http.post<MyImpBL[]>(this.globals.APIURL + '/ImpBLApi/ExistingImpHBL', OL, this.createAuthHeader());
    }

    bindExstingImpHBLCntrList(OL: MyImpBlCntrList): Observable<MyImpBlCntrList[]> {

        return this.http.post<MyImpBlCntrList[]>(this.globals.APIURL + '/ImpBLApi/ExistingImpHBLCntr', OL, this.createAuthHeader());
    }

    bindExstingImpHBLCntrListCheck(OL: MyImpBlCntrList): Observable<MyImpBlCntrList[]> {

        return this.http.post<MyImpBlCntrList[]>(this.globals.APIURL + '/ImpBLApi/ExistingImpHBLCntrCheck', OL, this.createAuthHeader());
    }

    bindEnquiryList(OL: MyLinerDropdown): Observable<MyLinerDropdown[]> {

        return this.http.post<MyLinerDropdown[]>(this.globals.APIURL + '/ImpBLApi/ImpEnquiryNo', OL, this.createAuthHeader());
    }

}
