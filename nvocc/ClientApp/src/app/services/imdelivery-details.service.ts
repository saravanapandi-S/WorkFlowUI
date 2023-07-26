import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Globals } from '../globals';
import { DeliveryDetails } from '../model/ImdeliveryDetails';

@Injectable({
    providedIn: 'root'
})
export class ImdeliveryDetailsService {

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

    getSaveDeliverydetails(OL: DeliveryDetails): Observable<DeliveryDetails[]> {

        return this.http.post<DeliveryDetails[]>(this.globals.APIURL + '/Imdeliverydetails/SaveDeliverydetails', OL);
    }

    getDeliverydetailsEdit(OL: DeliveryDetails): Observable<DeliveryDetails[]> {

        return this.http.post<DeliveryDetails[]>(this.globals.APIURL + '/Imdeliverydetails/DeliverydetailsEdit', OL);
    }

    getIMVesselValues(OL: DeliveryDetails): Observable<DeliveryDetails[]> {
       
        return this.http.post<DeliveryDetails[]>(this.globals.APIURL + '/Imdeliverydetails/IMVesselValues', OL);
    }
}




