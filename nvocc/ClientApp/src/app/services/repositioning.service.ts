import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Globals } from '../globals';
import { GridContainer, Repositioning, RepositionDynamicGrid } from 'src/app/model/Repositioning';

@Injectable({
  providedIn: 'root'
})
export class RepositioningService {

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
    getSaveRepositioning(OD: Repositioning)  {

        return this.http.post(this.globals.APIURL + '/Repositioning/SaveRepositioning', OD);
    }
    SaveRepositioningCntrs(OD: Repositioning) {

        return this.http.post(this.globals.APIURL + '/Repositioning/SaveRepositioningCntrs', OD);
    }
    
    getRepositioningList(OL: Repositioning): Observable<Repositioning[]> {
       
        return this.http.post<Repositioning[]>(this.globals.APIURL + '/Repositioning/RepositioningList', OL);
    }
    getRepositioningEdit(OL: Repositioning): Observable<Repositioning[]> {
        
        return this.http.post<Repositioning[]>(this.globals.APIURL + '/Repositioning/RepositioningEdit', OL);
    }
    getCntrsEdit(OL: GridContainer): Observable<GridContainer[]> {
       
        return this.http.post<GridContainer[]>(this.globals.APIURL + '/Repositioning/RepositioningCntrsEdit', OL);
    }
    getCntrsTabView(OL: RepositionDynamicGrid): Observable<RepositionDynamicGrid[]> {

        return this.http.post<RepositionDynamicGrid[]>(this.globals.APIURL + '/Repositioning/RepositioningCntrsTabView', OL);
    }
    getvalidCntrNosValues(OL: RepositionDynamicGrid): Observable<RepositionDynamicGrid[]> {

        return this.http.post<RepositionDynamicGrid[]>(this.globals.APIURL + '/Repositioning/getValidCntrvalues', OL, this.createAuthHeader());
    }
}





