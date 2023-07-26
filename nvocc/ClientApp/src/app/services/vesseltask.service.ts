import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Globals } from '../globals';
import { confirmDynamicGrid, prealertDynamicGrid, tdrDynamicGrid, VesselTaskMaster } from 'src/app/model/vesseltask';
import { VesselTaskMaster1, VesselLoadCnfrm } from 'src/app/model/vesseltask';

@Injectable({
    providedIn: 'root'
})
export class VesseltaskService {

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


    getVesselTasklistBind(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/VesselTasklistBind', OL);
    }

    //Pre-Alert

    getPrealertStatusBind(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/PreAlertStatusBind', OL);
    }

    getPrealertFinalBind(OL: prealertDynamicGrid): Observable<prealertDynamicGrid[]> {
        return this.http.post<prealertDynamicGrid[]>(this.globals.APIURL + '/VesselTask/PreAlertFinalBind', OL);
    }

    getPrealertMailBind(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/PreAlertMailBind', OL);
    }

    getEmailSend(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {

        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/VesselEmailSend', OL, this.createAuthHeader());
    }

    insertPrealertFinalInstr(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/InsertPreAlertFinalInstr', OL);
    }

    insertPrealertMailInstr(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/InsertPreAlertMailInstr', OL);
    }

    insertPrealertAttachStatus(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/InsertPreAlertAttachStatus', OL);
    }

    getPrealertMailToBind(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/PreAlertMailToBind', OL);
    }

    //onBoard

    getOnboardConfirmBind(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/OnboardConfirmBind', OL);
    }

    insertOnboardMail(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/InsertOnboardMail', OL);
    }

    getOnboardEmailSend(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {

        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/OnBoardEmailSend', OL, this.createAuthHeader());
    }

    insertOnboardConfirmStatus(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {

        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/InsertOnboardConfirmStatus', OL, this.createAuthHeader());
    }

    //TDR

    getTDRStatusBind(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/TDRStatusBind', OL);
    }

    getTDRFinalBind(OL: tdrDynamicGrid): Observable<tdrDynamicGrid[]> {
        return this.http.post<tdrDynamicGrid[]>(this.globals.APIURL + '/VesselTask/TDRFinalBind', OL);
    }

    getTDRMailBind(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/TDRMailBind', OL);
    }

    getTDREmailSend(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {

        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/TDREmailSend', OL, this.createAuthHeader());
    }

    insertTDRFinalInstr(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/InsertTDRFinalInstr', OL);
    }

    insertTDRMailInstr(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/InsertTDRMailInstr', OL);
    }

    InsertTDRAttachStatus(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/InsertTDRAttachStatus', OL);
    }

    getTDRMailToBind(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/TDRMailToBind', OL);
    }


    //TDR




    getVesselLoadListStatusViewlist(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {

        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/LoadListStatusBind', OL);
    }

    getVesselLoadListFinalViewlist(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {

        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/LoadListFinalBind', OL);
    }

    getVesselLoadListFinalTabViewlist(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {

        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/LoadListFinalTabBind', OL);
    }

    getVesselLoadListMailViewlist(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {

        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/LoadListMailBind', OL);
    }

    getLoadListEmailSend(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {

        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/LoadListEmailSend', OL, this.createAuthHeader());
    }


    getVesselTaskViewlist(OL: VesselTaskMaster1): Observable<VesselTaskMaster1[]> {

        return this.http.post<VesselTaskMaster1[]>(this.globals.APIURL + '/VesselTask/VesselTaskViewlist', OL);
    }
    getVesselLoadCnfrmViewlist(OL: VesselLoadCnfrm): Observable<VesselLoadCnfrm[]> {

        return this.http.post<VesselLoadCnfrm[]>(this.globals.APIURL + '/VesselTask/VesselLoadCnfrmViewlist', OL);
    }

    getVesselLoadCnfrmViewlist1(OL: confirmDynamicGrid): Observable<confirmDynamicGrid[]> {
        return this.http.post<confirmDynamicGrid[]>(this.globals.APIURL + '/VesselTask/VesselLoadCnfrmViewlist1', OL);
    }






    insertOnboardStatus(OL: VesselTaskMaster): Observable<VesselTaskMaster[]> {
        return this.http.post<VesselTaskMaster[]>(this.globals.APIURL + '/VesselTask/InsertOnboardStatusValue', OL);
    }
}
