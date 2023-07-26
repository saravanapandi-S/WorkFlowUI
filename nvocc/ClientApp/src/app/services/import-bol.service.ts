import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Globals } from '../globals';
import { ImportBOL } from '../model/importbol';

@Injectable({
  providedIn: 'root'
})
export class ImportBOLService {

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

    getImportBOLViewBind(OL: ImportBOL): Observable<ImportBOL[]> {
        return this.http.post<ImportBOL[]>(this.globals.APIURL + '/ImportBOLTask/ImportBOLView', OL);
    }

    getImportBOLVsDisplayBind(OL: ImportBOL): Observable<ImportBOL[]> {
        return this.http.post<ImportBOL[]>(this.globals.APIURL + '/ImportBOLTask/ImportBOLVsDisplay', OL);
    }

    getImportBOLStatusViewBind(OL: ImportBOL): Observable<ImportBOL[]> {
        return this.http.post<ImportBOL[]>(this.globals.APIURL + '/ImportBOLTask/ImportBOLStatusView', OL);
    }

    getImportBOLSearchViewBind(OL: ImportBOL): Observable<ImportBOL[]> {
        return this.http.post<ImportBOL[]>(this.globals.APIURL + '/ImportBOLTask/ImportBOLSearchView', OL);
    }

    getImportBOLContainerViewBind(OL: ImportBOL): Observable<ImportBOL[]> {
        return this.http.post<ImportBOL[]>(this.globals.APIURL + '/ImportBOLTask/ImportBOLContainerView', OL);
    }



}
