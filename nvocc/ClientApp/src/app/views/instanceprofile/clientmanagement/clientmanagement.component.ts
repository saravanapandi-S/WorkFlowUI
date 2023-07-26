import { Component, Inject, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EncrDecrServiceService } from '../../../services/encr-decr-service.service';


@Component({
  selector: 'app-clientmanagement',
  templateUrl: './clientmanagement.component.html',
  styleUrls: ['./clientmanagement.component.css']
})
export class ClientmanagementComponent implements OnInit {

    constructor(private router: Router, private route: ActivatedRoute, private ES: EncrDecrServiceService, private fb: FormBuilder) { }
    ClientForm: FormGroup;
    CompanyID = 0;
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
                this.CompanyID = queryString["ID"];

            }
         
            this.createForm();
        });
    }

    createForm() {

        this.ClientForm = this.fb.group({
            ID: 0,

        });


    }

    btntabclick(tab) {


        var values = "ID: " + this.CompanyID;
     
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
