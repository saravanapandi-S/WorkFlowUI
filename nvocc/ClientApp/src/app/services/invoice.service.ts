import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Globals } from '../globals';
import { MyChargeCode, MyCustomerGSTNoDropdown, MyCustomerNameDropdown, MyGSTCategory, MyPartyAddressOnchange, MyPartyBranchDropdown, MyPartyDropdown, MyPartyGSTDropdown } from '../model/invoice';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

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

    getOfficeLocationList(): Observable<MyCustomerNameDropdown[]> {

        return this.http.post<MyCustomerNameDropdown[]>(this.globals.APIURL + '/Invoice/OfficeLocationMaster', this.createAuthHeader());
    }

    getOfficeGSTNoList(OL: MyCustomerGSTNoDropdown): Observable<MyCustomerGSTNoDropdown[]> {

        return this.http.post<MyCustomerGSTNoDropdown[]>(this.globals.APIURL + '/Invoice/OfficeTaxGSTNo',OL);
    }

    getCustomerNameList(): Observable<MyPartyDropdown[]> {

        return this.http.post<MyPartyDropdown[]>(this.globals.APIURL + '/Invoice/GetCustomerNameList', this.createAuthHeader());
    }

    getCustomerBranchCode(OL: MyPartyBranchDropdown): Observable<MyPartyBranchDropdown[]> {

        return this.http.post<MyPartyBranchDropdown[]>(this.globals.APIURL + '/Invoice/GetCustomerBranchCode', OL);
    }

    getCustomerGSTIN(OL: MyPartyGSTDropdown): Observable<MyPartyGSTDropdown[]> {

        return this.http.post<MyPartyGSTDropdown[]>(this.globals.APIURL + '/Invoice/GetCustomerGSTIN', OL);
    }

    getCustomerAddress(OL: MyPartyAddressOnchange): Observable<MyPartyAddressOnchange[]> {

        return this.http.post<MyPartyAddressOnchange[]>(this.globals.APIURL + '/Invoice/GetCustomerAddress', OL);
    }

    getInvoiceChargeCode(): Observable<MyChargeCode[]> {

        return this.http.post<MyChargeCode[]>(this.globals.APIURL + '/Invoice/GetInvoiceChargeCode', this.createAuthHeader());
    }

    getCustomerGSTCategory(): Observable<MyGSTCategory[]> {

        return this.http.post<MyGSTCategory[]>(this.globals.APIURL + '/Invoice/GetCustomerGSTCategory', this.createAuthHeader());
    }


}
