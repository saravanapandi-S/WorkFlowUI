import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Globals } from '../globals';
import { accImportDrillDrow, CostAccounting, accExportDrillDrow } from '../model/CostAccounting';


@Injectable({
  providedIn: 'root'
})
export class CostAccountingService {

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

    getIMCostAccountingList(OL: CostAccounting): Observable<CostAccounting[]> {
   
        return this.http.post<CostAccounting[]>(this.globals.APIURL + '/costaccounting/IMCostAccountingList', OL);
    }
    getEXportCostAccountingList(OL: CostAccounting): Observable<CostAccounting[]> {

        return this.http.post<CostAccounting[]>(this.globals.APIURL + '/costaccounting/EXportCostAccountingList', OL);
    }


    getIMCostAccountingDrillDown(OL: accImportDrillDrow): Observable<accImportDrillDrow[]> {

        return this.http.post<accImportDrillDrow[]>(this.globals.APIURL + '/costaccounting/IMCostAccountingDrillDownList', OL);
    }

    getExportCostAccountingDrillDown(OL: accExportDrillDrow): Observable<accExportDrillDrow[]> {

        return this.http.post<accExportDrillDrow[]>(this.globals.APIURL + '/costaccounting/ExportCostAccountingDrillDown', OL);
    }

 
}



