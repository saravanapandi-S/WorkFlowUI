import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { MySACommon, MyCompany, MyConfig } from 'src/app/model/systemadmin';
import { Globals } from '../globals';
@Injectable({
  providedIn: 'root'
})
export class SystemadminService {

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

    GetCountries(OL: MySACommon): Observable<MySACommon[]> {
        return this.http.post<MySACommon[]>(this.globals.APIURL + '/SystemAdminApi/GetCountries', OL, this.createAuthHeader());
    }

    GetState(OL: MySACommon): Observable<MySACommon[]> {
        return this.http.post<MySACommon[]>(this.globals.APIURL + '/SystemAdminApi/GetState', OL, this.createAuthHeader());
    }

    GetStates(OL: MySACommon): Observable<MySACommon[]> {
        return this.http.post<MySACommon[]>(this.globals.APIURL + '/SystemAdminApi/GetStates', OL, this.createAuthHeader());
    }

    GetCity(OL: MySACommon): Observable<MySACommon[]> {
        return this.http.post<MySACommon[]>(this.globals.APIURL + '/SystemAdminApi/GetCity', OL, this.createAuthHeader());
    }

    GetCities(OL: MySACommon): Observable<MySACommon[]> {
        return this.http.post<MySACommon[]>(this.globals.APIURL + '/SystemAdminApi/GetCities', OL, this.createAuthHeader());
    }

    GetPort(OL: MySACommon): Observable<MySACommon[]> {
        return this.http.post<MySACommon[]>(this.globals.APIURL + '/SystemAdminApi/GetPort', OL, this.createAuthHeader());
    }

    GetTerminal(OL: MySACommon): Observable<MySACommon[]> {
        return this.http.post<MySACommon[]>(this.globals.APIURL + '/SystemAdminApi/GetTerminal', OL, this.createAuthHeader());
    }

    GetShipmentLocation(OL: MySACommon): Observable<MySACommon[]> {
        return this.http.post<MySACommon[]>(this.globals.APIURL + '/SystemAdminApi/GetShipmentLocation', OL, this.createAuthHeader());
    }

    GetShipmentLocations(OL: MySACommon): Observable<MySACommon[]> {
        return this.http.post<MySACommon[]>(this.globals.APIURL + '/SystemAdminApi/GetShipmentLocations', OL, this.createAuthHeader());
    }

    GetCommodities(OL: MySACommon): Observable<MySACommon[]> {
        return this.http.post<MySACommon[]>(this.globals.APIURL + '/SystemAdminApi/GetCommodities', OL, this.createAuthHeader());
    }

    GetPackageTypes(OL: MySACommon): Observable<MySACommon[]> {
        return this.http.post<MySACommon[]>(this.globals.APIURL + '/SystemAdminApi/GetPackageTypes', OL, this.createAuthHeader());
    }

    GetContainerTypes(OL: MySACommon): Observable<MySACommon[]> {
        return this.http.post<MySACommon[]>(this.globals.APIURL + '/SystemAdminApi/GetContainerTypes', OL, this.createAuthHeader());
    }

    GetHazClasses(OL: MySACommon): Observable<MySACommon[]> {
        return this.http.post<MySACommon[]>(this.globals.APIURL + '/SystemAdminApi/GetHazClasses', OL, this.createAuthHeader());
    }

    GetCompanyDetails(OL: MyCompany): Observable<MyCompany[]> {
        return this.http.post<MyCompany[]>(this.globals.APIURL + '/SystemAdminApi/GetCompanyDetails', OL, this.createAuthHeader());
    }

    saveCompany(OD: MyCompany) {

        return this.http.post(this.globals.APIURL + '/SystemAdminApi/SaveCompany/', OD);
    }

    GetCompanyView(OL: MyCompany): Observable<MyCompany[]> {
        return this.http.post<MyCompany[]>(this.globals.APIURL + '/SystemAdminApi/GetCompanyView', OL, this.createAuthHeader());
    }
    GetCompanyEdit(OL: MyCompany): Observable<MyCompany[]> {
        return this.http.post<MyCompany[]>(this.globals.APIURL + '/SystemAdminApi/GetCompanyEdit', OL, this.createAuthHeader());
    }  
    SaveConfig(OD: MyConfig) {

        return this.http.post(this.globals.APIURL + '/SystemAdminApi/SaveConfig/', OD);
    }
    GetConfigEdit(OL: MyConfig): Observable<MyConfig[]> {
        return this.http.post<MyConfig[]>(this.globals.APIURL + '/SystemAdminApi/GetConfigEdit', OL, this.createAuthHeader());
    }
    SendTestConnection(OL: MyConfig): Observable<MyConfig[]> {
        return this.http.post<MyConfig[]>(this.globals.APIURL + '/SystemAdminApi/SendTestEmail', OL, this.createAuthHeader());
    }

    AttachUpload(file): Observable<any> {

        const formData = new FormData();
        formData.append("file", file, file.name);
        return this.http.post(this.globals.APIURL + '/SystemAdminApi/ImageUpload/', formData)
    }

}
