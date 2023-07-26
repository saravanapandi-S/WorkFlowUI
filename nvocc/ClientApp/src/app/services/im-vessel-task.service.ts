import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Globals } from '../globals';
import { confirmDischargeGrid, confirmDynamicGrid, ImVesselForm, Imvesselsearch, MyCustomerDropdown, Sendmanil } from '../model/ImvesselTask';

@Injectable({
    providedIn: 'root'
})
export class ImVesselTaskService {


    group: any;
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

    getVesselTaskList(OL: Imvesselsearch): Observable<Imvesselsearch[]> {

        return this.http.post<Imvesselsearch[]>(this.globals.APIURL + '/ImVesselTask/VesselTaskList', OL);
    }

    getVesselFormList(OL: ImVesselForm): Observable<ImVesselForm[]> {

        return this.http.post<ImVesselForm[]>(this.globals.APIURL + '/ImVesselTask/VesselFormList', OL);
    }

    getVesselDischargeStatusList(OL: Imvesselsearch): Observable<Imvesselsearch[]> {

        return this.http.post<Imvesselsearch[]>(this.globals.APIURL + '/ImVesselTask/GetDischargeStatusList', OL);
    }

    getVesselDischargeList(OL: confirmDynamicGrid): Observable<confirmDynamicGrid[]> {

        return this.http.post<confirmDynamicGrid[]>(this.globals.APIURL + '/ImVesselTask/GetDischargeList', OL);
    }

    getCustomerList(): Observable<MyCustomerDropdown[]> {

        return this.http.post<MyCustomerDropdown[]>(this.globals.APIURL + '/CommonAccessApi/CustomerMaster', this.createAuthHeader());
    }

    insertDischargeList(OL: Imvesselsearch): Observable<Imvesselsearch[]> {

        return this.http.post<Imvesselsearch[]>(this.globals.APIURL + '/ImVesselTask/ImpDischargeListInsert', OL);
    }



    getImportManifestStsList(OL: confirmDynamicGrid): Observable<confirmDynamicGrid[]> {

        return this.http.post<confirmDynamicGrid[]>(this.globals.APIURL + '/ImVesselTask/GetImportManifestStsList', OL);
    }

    getImportManifestStsTabList(OL: confirmDynamicGrid): Observable<confirmDynamicGrid[]> {

        return this.http.post<confirmDynamicGrid[]>(this.globals.APIURL + '/ImVesselTask/GetImportManifestStsTabList', OL);
    }

    getImportManifestList(OL: confirmDynamicGrid): Observable<confirmDynamicGrid[]> {

        return this.http.post<confirmDynamicGrid[]>(this.globals.APIURL + '/ImVesselTask/GetImportManifestList', OL);
    }

    getImportArrivalList(OL: confirmDynamicGrid): Observable<confirmDynamicGrid[]> {

        return this.http.post<confirmDynamicGrid[]>(this.globals.APIURL + '/ImVesselTask/GetImportArrivalList', OL);
    }

    getImportDischargeCnfrmStsList(OL: confirmDynamicGrid): Observable<confirmDynamicGrid[]> {

        return this.http.post<confirmDynamicGrid[]>(this.globals.APIURL + '/ImVesselTask/GetImportDischargeCnfrmStsList', OL);
    }

    getImportDischargeCnfrmList(OL: confirmDischargeGrid): Observable<confirmDischargeGrid[]> {

        return this.http.post<confirmDischargeGrid[]>(this.globals.APIURL + '/ImVesselTask/GetImportDischargeCnfrmList', OL);
    }

    insertDischargeConfirmList(OL: Imvesselsearch): Observable<Imvesselsearch[]> {

        return this.http.post<Imvesselsearch[]>(this.globals.APIURL + '/ImVesselTask/ImpDischargeConfirmInsert', OL);
    }

    getIMVesselValues(OL: Imvesselsearch): Observable<Imvesselsearch[]> {

        return this.http.post<Imvesselsearch[]>(this.globals.APIURL + '/ImVesselTask/IMVesselValues', OL);
    }





    getArrivalEmailSend(OL: Imvesselsearch): Observable<Imvesselsearch[]> {

        return this.http.post<Imvesselsearch[]>(this.globals.APIURL + '/ImVesselTask/ArrivalEmailSend', OL, this.createAuthHeader());
    }

    getBindEmailView(OL: Sendmanil): Observable<Sendmanil[]> {

        return this.http.post<Sendmanil[]>(this.globals.APIURL + '/ImVesselTask/BindEmailView', OL, this.createAuthHeader());
    }

    getImSaveArrival(OL: Sendmanil): Observable<Sendmanil[]> {

        return this.http.post<Sendmanil[]>(this.globals.APIURL + '/ImVesselTask/ImSaveArrival', OL, this.createAuthHeader());
    }






}


