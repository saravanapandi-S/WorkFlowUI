import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { MYPortTariff, MyDynamicGridSlab, MyDynamicGridIHC, MyDynamicGridDOCharges, myDynamicGridTHCCharges, myDynamicIHCBrackupCharges } from 'src/app/model/PortTariff';
import { MyAgencyDropdown, MyCntrTypeDropdown, MyCustomerDropdown, MyPortdrodown, MyTerminaldrodown } from 'src/app/model/Admin';
/*import { map } from 'jquery';*/
import { map, skipWhile, tap } from 'rxjs/operators'
import { GeneralMaster, drodownVeslVoyage, CurrencyMaster, ChargeTBMaster } from 'src/app/model/common';
import { Globals } from '../globals';
import { CntrPickDrop, DynamicGridcCntrsList } from '../model/CntrPickDepo';
@Injectable({
    providedIn: 'root'
})
export class CntrpickdropService {

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


    getPickDropTypeList(): Observable<CntrPickDrop[]> {

        return this.http.post<CntrPickDrop[]>(this.globals.APIURL + '/CntrPickDrop/BindPickUpDropTypes', this.createAuthHeader());
    }
    getPickDropTypeListDrop(): Observable<CntrPickDrop[]> {

        return this.http.post<CntrPickDrop[]>(this.globals.APIURL + '/CntrPickDrop/BindPickUpDropTypesDrop', this.createAuthHeader());
    }
    getStorageLocList(OL: CntrPickDrop): Observable<CntrPickDrop[]> {

        return this.http.post<CntrPickDrop[]>(this.globals.APIURL + '/CntrPickDrop/BindStorageLocation', OL, this.createAuthHeader());
    }
    getCntrTypes(): Observable<CntrPickDrop[]> {

        return this.http.post<CntrPickDrop[]>(this.globals.APIURL + '/CntrPickDrop/BindCntrTypes', this.createAuthHeader());
    }
    getOwningTypes(): Observable<CntrPickDrop[]> {

        return this.http.post<CntrPickDrop[]>(this.globals.APIURL + '/CntrPickDrop/BindOwningTypes', this.createAuthHeader());
    }
    getCntrNoList(): Observable<CntrPickDrop[]> {

        return this.http.post<CntrPickDrop[]>(this.globals.APIURL + '/CntrPickDrop/BindCntrNos', this.createAuthHeader());
    }

    getISOCodeByCntrTypes(OL: CntrPickDrop): Observable<CntrPickDrop[]> {

        return this.http.post<CntrPickDrop[]>(this.globals.APIURL + '/CntrPickDrop/BindISOCodesByType', OL, this.createAuthHeader());
    }

    CntrPickDropSave(OD: CntrPickDrop) {

        return this.http.post(this.globals.APIURL + '/CntrPickDrop/CntrPickDropSave/', OD);
    }
    CntrPickDropListView(OL: CntrPickDrop): Observable<CntrPickDrop[]> {

        return this.http.post<CntrPickDrop[]>(this.globals.APIURL + '/CntrPickDrop/CntrPickDropListView', OL, this.createAuthHeader());
    }
    getCntrPickDropEdit(OL: CntrPickDrop): Observable<CntrPickDrop[]> {

        return this.http.post<CntrPickDrop[]>(this.globals.APIURL + '/CntrPickDrop/CntrPickDropListEdit', OL, this.createAuthHeader());
    }
    getCntrPickDropCntrsEdit(OL: DynamicGridcCntrsList): Observable<DynamicGridcCntrsList[]> {

        return this.http.post<DynamicGridcCntrsList[]>(this.globals.APIURL + '/CntrPickDrop/CntrPickDropCntrsEdit', OL, this.createAuthHeader());
    }
    AttachUpload(file): Observable<any> {

        const formData = new FormData();
        formData.append("file", file, file.name);
        return this.http.post(this.globals.APIURL + '/CntrPickDrop/upload/', formData)
    }
    getOfficeListByUserID(OL: MyCustomerDropdown): Observable<MyCustomerDropdown[]> {

        return this.http.post<MyCustomerDropdown[]>(this.globals.APIURL + '/CntrPickDrop/OfficeLocByUser', OL, this.createAuthHeader());
    }

    //--ContainertRACE---//

    getCntrNoFullList(): Observable<CntrPickDrop[]> {

        return this.http.post<CntrPickDrop[]>(this.globals.APIURL + '/CntrPickDrop/BindCntrNosList', this.createAuthHeader());
    }

    viewCntrTraceList(OL: CntrPickDrop): Observable<CntrPickDrop[]> {

        return this.http.post<CntrPickDrop[]>(this.globals.APIURL + '/CntrPickDrop/CntrTraceView', OL, this.createAuthHeader());
    }

    ExcelContainersList(OL: DynamicGridcCntrsList): Observable<DynamicGridcCntrsList[]> {

        return this.http.post<DynamicGridcCntrsList[]>(this.globals.APIURL + '/CntrPickDrop/ExcelContainersSave', OL, this.createAuthHeader());
    }


    public download(fileUrl: string) {
        return this.http.get(`${this.globals.APIURL}/CntrPickDrop/download?fileUrl=${fileUrl}`, {
            reportProgress: true,
            observe: 'events',
            responseType: 'blob'
        });
    }
}
