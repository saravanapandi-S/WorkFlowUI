import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Globals } from '../globals';
import { Inventory } from '../model/InventoryManage';

@Injectable({
  providedIn: 'root'
})
export class InventoryManagerService {

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

    getEmtyCntrStatusViewlist(OL: Inventory): Observable<Inventory[]> {
     
        return this.http.post<Inventory[]>(this.globals.APIURL + '/InventoryManage/EmtyCntrStatusViewlist', OL);
    }

    getEmtyIdlingViewlist(OL: Inventory): Observable<Inventory[]> {
       
        return this.http.post<Inventory[]>(this.globals.APIURL + '/InventoryManage/EmtyIdlingViewlist', OL);
    }
    getContainerStockViewlist(OL: Inventory): Observable<Inventory[]> {

        return this.http.post<Inventory[]>(this.globals.APIURL + '/InventoryManage/ContainerStockViewlist', OL);

    }
    getViewLongIdlingWithConsigViewlist(OL: Inventory): Observable<Inventory[]> {

        return this.http.post<Inventory[]>(this.globals.APIURL + '/InventoryManage/ViewLongIdlingWithConsigViewlist', OL);
    }
    getViewLongIdlingWithShipper(OL: Inventory): Observable<Inventory[]> {

        return this.http.post<Inventory[]>(this.globals.APIURL + '/InventoryManage/ViewLongIdlingWithShipper', OL);
    }
    getMixUpCntrStatusViewlist(OL: Inventory): Observable<Inventory[]> {

        return this.http.post<Inventory[]>(this.globals.APIURL + '/InventoryManage/MixUpCntrStatusViewlist', OL);
    }
}
