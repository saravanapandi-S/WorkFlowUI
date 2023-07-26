import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Globals } from '../globals';
import { ImpArrival } from '../model/ImpArrival';

@Injectable({
    providedIn: 'root'
})
export class ImArrivalNoticeService {

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

    getImportArrivalList(OL: ImpArrival): Observable<ImpArrival[]> {

        return this.http.post<ImpArrival[]>(this.globals.APIURL + '/ImpArrival/ImportArrivalList', OL);
    }

    getSaveArrival(OL: ImpArrival): Observable<ImpArrival[]> {

        return this.http.post<ImpArrival[]>(this.globals.APIURL + '/ImpArrival/SaveArrival', OL);
    }
    getImpArrivalEdit(OL: ImpArrival): Observable<ImpArrival[]> {

        return this.http.post<ImpArrival[]>(this.globals.APIURL + '/ImpArrival/ImpArrivalEdit', OL);
    }

    getArrivalEmailSend(OL: ImpArrival): Observable<ImpArrival[]> {

        return this.http.post<ImpArrival[]>(this.globals.APIURL + '/ImpArrival/ArrivalEmailSend', OL, this.createAuthHeader());
    }

    async getArrivalPdf(BLID: string): Promise<Blob> {
        const url = `${this.globals.APIURL}/ImpArrival/ArrivalPdf?BLID=${BLID}`;
        return this.http.get(url, { responseType: 'blob' }).toPromise();
    }
    async getArrivalPDFView(BLID: string): Promise<Blob> {
       
        const url = `${this.globals.APIURL}/ImpArrival/ArrivalPdfView?BLID=${BLID}`;
        return this.http.get(url, { responseType: 'blob' }).toPromise();
    }

}






