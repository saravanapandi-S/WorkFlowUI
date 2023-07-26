import { Injectable } from '@angular/core';
import {
    HttpEvent,
    HTTP_INTERCEPTORS,
    HttpInterceptor,
    HttpHandler,
    HttpRequest, HttpResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { delay, finalize } from 'rxjs/operators';
import { SpinnerService } from './spinner.service';


@Injectable()
export class Spinner implements HttpInterceptor {

    constructor(public spinnerService: SpinnerService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.spinnerService.requestStarted();
        return next.handle(req).pipe(
            delay(500),
            finalize(() => this.spinnerService.requestEnded())
        );
    }
}

export const LoadingInterceptor = {
    provide: HTTP_INTERCEPTORS,
    useClass: Spinner,
    multi: true,
};