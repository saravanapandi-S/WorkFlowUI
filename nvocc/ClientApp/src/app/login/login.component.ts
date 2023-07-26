import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MastersService } from 'src/app/services/masters.service';
import { Login } from '../model/common';
import { map, take, tap, startWith } from 'rxjs/operators';
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginService } from '../services/login.service';
declare let $: any;
import { Title } from '@angular/platform-browser';


@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    title = 'Odak Solutions Pvt Ltd';
    typeSelected: string;
    LoginForm: FormGroup;
    user = '1';
    constructor(private router: Router, private route: ActivatedRoute, private LService: LoginService, private fb: FormBuilder, private titleService: Title) { }
    private allItems: any[];
    ngOnInit() {
        this.titleService.setTitle(this.title);
        this.createForm();
        localStorage.setItem('SeesionUser', this.user)
    }

    createForm() {
        this.LoginForm = this.fb.group({
            ID: 0,
            Username: '',
            Password: '',
            Token: ''
        });
    }
    OnsubmitLogin() {



        var Validation = "";
        if (this.LoginForm.value.Username == "") {
            Validation += "please type email id</br>";
        }
        if (this.LoginForm.value.Password == "") {
            Validation += "please type Password</br>";
        }
        if (Validation != "") {
            Swal.fire(Validation);
            return;
        }
        this.LService.getLoginList(this.LoginForm.value).subscribe(data => {
            this.allItems = data;
            localStorage.setItem("UserID", data[0].ID.toString());
            localStorage.setItem("Token", data[0].Token);
            localStorage.setItem("EncKey", "ODAK21$#@$^@1ODK");
            localStorage.setItem("NotAllowed", "Edit not Allowed");
            localStorage.setItem("Save", "Record Saved Successfully");
            this.router.navigate(['/views/dashboard']);
        });
    }

    OnsubmitOverlay() {
        /* $('#overlay').fadeIn().delay(2000).fadeOut();*/

    }
    //userAuthentication(userName, password) {

    //    var data = {
    //        Username: userName,
    //        Password: password,
    //        grant_type: "password"
    //    };
    //    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json', 'No-Auth': 'True' });
    //    return this.http.post(this.globals.APIURL + '/users/authenticate', data, { headers: reqHeader });
    //}

}

