import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { LinerName, GeneralMaster } from 'src/app/model/common';
/*import { map } from 'jquery';*/
import { map, skipWhile, tap } from 'rxjs/operators';
import { Globals } from '../globals';


@Injectable({
  providedIn: 'root'
})
export class CommonService {
    /*readonly APIUrl = "https://localhost:44301/api";*/
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

    getLinerNameList(OL: LinerName): Observable<LinerName[]> {

        return this.http.post<LinerName[]>(this.globals.APIURL + '/CommonAccessApi/CustomerBussTypesMaster', OL, this.createAuthHeader());
    }

    getModuleList(id): Observable<GeneralMaster[]> {
       
        return this.http.get<GeneralMaster[]>(this.globals.APIURL + '/CommonAccessApi/ModuleValues/' + id, this.createAuthHeader());
    }
    getProgramList(idv): Observable<GeneralMaster[]> {
        
        return this.http.get<GeneralMaster[]>(this.globals.APIURL + '/CommonAccessApi/ModuleValues/' + idv, this.createAuthHeader());
    }
    //getData() {
    //    return this.http.get('https://jsonplaceholder.typicode.com/users')
    //        .pipe(
    //            map((response: []) => response.map(item => item['name']))
    //        )
    //}

    //getData() {
    //    return this.http.get('http://test.oceanus-lines.com/api/CommonAccessApi/ModuleValues')
    //        .pipe(
    //            map((response: []) => response.map(item => item['LinerNmae']))
    //        )
    //}
    getData() {
        return this.http.get<LinerName[]>(this.globals.APIURL + '/CommonAccessApi/CustomerBussTypesMaster/', this.createAuthHeader())
            .pipe(
                map((response: []) => response.map(item => item['CustomerName']))
            )
    }
}
