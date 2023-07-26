import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Globals } from '../globals';
import { MovementUploadConfig } from 'src/app/model/MovementUploadConfig';

@Injectable({
  providedIn: 'root'
})
export class MovementUploadConfigService {
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
    GetSaveMovementUpload(OL: MovementUploadConfig): Observable<MovementUploadConfig[]> {

        return this.http.post<MovementUploadConfig[]>(this.globals.APIURL + '/MovementUploadConfig/SaveMovementUpload', OL);
    }
    getMovementUploadList(OL: MovementUploadConfig): Observable<MovementUploadConfig[]> {
        
        return this.http.post<MovementUploadConfig[]>(this.globals.APIURL + '/MovementUploadConfig/MovementUploadList', OL);
    }
    getMovementUploadEdit(OL: MovementUploadConfig): Observable<MovementUploadConfig[]> {
      
        return this.http.post<MovementUploadConfig[]>(this.globals.APIURL + '/MovementUploadConfig/MovementUploadEdit', OL);
    }
}
