import { Component, Inject, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EncrDecrServiceService } from '../../../services/encr-decr-service.service';
import Swal from 'sweetalert2';
import { SystemadminService } from '../../../services/systemadmin.service';
@Component({
  selector: 'app-configuration',
  templateUrl: './configuration.component.html',
  styleUrls: ['./configuration.component.css']
})
export class ConfigurationComponent implements OnInit {

    constructor(private router: Router, private route: ActivatedRoute,private ES: EncrDecrServiceService, private sa: SystemadminService, private fb: FormBuilder) { }
    ConfigForm: FormGroup;
    CompanyIDv = 0;
    ngOnInit(): void {
        this.createForm();
        var queryString = new Array();

        this.route.queryParams.subscribe(params => {
            var Parameter = this.ES.get(localStorage.getItem("EncKey"), params['encrypted']);
            var KeyPara = Parameter.split(',');
            for (var i = 0; i < KeyPara.length; i++) {
                var key = KeyPara[i].split(':')[0];
                var value = KeyPara[i].split(':')[1];
                queryString[key] = value;
            }
            if (queryString["ID"] != null) {
                this.CompanyIDv = queryString["ID"];
               
            }
            this.ExistingConfigBind();
            this.createForm();
        });
      
    }

    createForm() {

        this.ConfigForm = this.fb.group({
            ID: 0,
            IsSMTPS: 0,
            IsSSLTLS: 0,
            HostName: '',
            IPPort: 0,
            Password: '',
            SenderID: '',
            MBSize: '',
            MaxNoAttachs: '',
            MaxSizeAllAttachs:''
        });


    }

    ExistingConfigBind() {
        this.ConfigForm.value.CompanyID = this.CompanyIDv;
        this.sa.GetConfigEdit(this.ConfigForm.value).pipe(
        ).subscribe(data => {
            this.ConfigForm.patchValue(data[0]);           
        });
    }
    onSubmitConfig() {

        var validation = "";
        if (this.ConfigForm.value.HostName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Host Name</span></br>"
        }
        if (this.ConfigForm.value.IPPort == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Port</span></br>"
        }
        if (this.ConfigForm.value.Password == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Password</span></br>"
        }
        if (this.ConfigForm.value.SenderID == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter SenderID</span></br>"
        }
        if (this.ConfigForm.value.MBSize == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Max Size Per Attachment</span></br>"
        }
        if (this.ConfigForm.value.MaxNoAttachs == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Max Number of Attachments</span></br>"
        }
        if (this.ConfigForm.value.MaxSizeAllAttachs == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Max Size of All Attachments</span></br>"
        }
        if (validation != "") {

            Swal.fire(validation)
            return false;
        }
        this.ConfigForm.value.CompanyID = this.CompanyIDv;
        this.sa.SaveConfig(this.ConfigForm.value).subscribe(Data => {
            Swal.fire(Data[0].AlertMessage)
        },
            (error: HttpErrorResponse) => {
                Swal.fire(error.message)
            });

    }
    OnSubmitTest() {
        this.sa.SendTestConnection(this.ConfigForm.value).subscribe(Data => {
            Swal.fire("Email Sent Successfully")
        },
            (error: HttpErrorResponse) => {
                Swal.fire(error.message)
            });
    }
    btntabclick(tab) {


        var values = "ID: " + this.ConfigForm.value.ID;
        //var values = "ID: 8";
        var encrypted = this.ES.set(localStorage.getItem("EncKey"), values);
        if (tab == 1) {

            this.router.navigate(['/views/masters/instanceprofile/companydetails/companydetails'], { queryParams: { encrypted } });
        }
        else if (tab == 2) {

            this.router.navigate(['/views/masters/instanceprofile/clientmanagement/clientmanagement'], { queryParams: { encrypted } });

        }
        else if (tab == 3) {

            this.router.navigate(['/views/masters/instanceprofile/configuration/configuration'], { queryParams: { encrypted } });

        }

    }

}
