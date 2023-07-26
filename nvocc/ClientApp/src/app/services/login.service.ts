import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Login } from 'src/app/model/common';
import { Globals } from '../globals';


@Injectable({
  providedIn: 'root'
})
export class LoginService {
    
    constructor(private http: HttpClient, private globals: Globals) { }

   
    getLoginList(OL: Login): Observable<Login[]>
    {
        var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json', 'No-Auth': 'True' });
        return this.http.post<Login[]>(this.globals.APIURL + '/Home/Login', OL, { headers: reqHeader });
    }

}


