import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MastersService } from 'src/app/services/masters.service';
import { City, Country, shipmentLocations } from '../../../model/common';
import Swal from 'sweetalert2';
import { SystemadminService } from '../../../services/systemadmin.service';
import { MySACommon } from '../../../model/systemadmin';
import { EncrDecrServiceService } from '../../../services/encr-decr-service.service';
declare let $: any;

@Component({
  selector: 'app-companydetails',
  templateUrl: './companydetails.component.html',
  styleUrls: ['./companydetails.component.css']
})
export class CompanydetailsComponent implements OnInit {

    myControl = new FormControl('');
    InstanceForm: FormGroup;
    dataSource: shipmentLocations[];
    dscountryItem: MySACommon[];
    dscityItem: MySACommon[];
    CompanyID = 0;
    dspkg: MySACommon[];
    fileUrl: string;
    message: string;
    progress1: number;
    imgsrc: string;
    constructor(private router: Router, private route: ActivatedRoute, private ES: EncrDecrServiceService, private service: MastersService, private sa: SystemadminService, private fb: FormBuilder) {
        this.route.queryParams.subscribe(params => {

            this.InstanceForm = this.fb.group({
                ID: params['id'],

            });
        });
    }

    ngOnInit(): void {

        $('.my-select').select2();
        $(document).on('select2:open', (e) => {
            const selectId = e.target.id

            $(".select2-search__field[aria-controls='select2-" + selectId + "-results']").each(function (
                key,
                value,
            ) {
                value.focus();
            })
        })
        this.createForm();
        this.onInitalBinding();
        $('#ddlCountry').on('select2:select', (e, args) => {
            this.CountryChange($("#ddlCountry").val());
        });

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

                this.InstanceForm = this.fb.group({
                    ID: queryString["ID"].toString(),
                });
                this.CompanyID = queryString["ID"].toString();
                this.ExistingYardBind();
                this.createForm();
            }

        });
       
    }
    CountryChange(countryval) {

        this.InstanceForm.value.CountryID = countryval;
        this.sa.GetCities(this.InstanceForm.value).subscribe(data => {
            this.dscityItem = data;
        });
    }
    onInitalBinding() {

        this.sa.GetCountries(this.InstanceForm.value).subscribe(data => {
            this.dscountryItem = data;
        });
      
    }

    ExistingYardBind() {
        this.InstanceForm.value.ID = this.CompanyID;
        this.sa.GetCompanyEdit(this.InstanceForm.value).pipe(
        ).subscribe(data => {
            this.InstanceForm.patchValue(data[0]);
            this.CountryChange(data[0].CountryID);
            $('#ddlCity').select2().val(data[0].CityID);
            $('#ddlCountry').select2().val(data[0].CountryID);
        });
    }

    createForm() {
        
            this.InstanceForm = this.fb.group({
                ID: 0,
                CompanyName: '',
                CompanyCode: '',
                Address: '',
                CountryID: 0,
                CityID: 0,
                ContactName: '',
                POBox: '',
                ZipCode: '',
                Designation: '',
                TelePhone1: '',
                TelePhone2: '',
                ContactEmailID: '',
                EmailID: '',
                URL: '',
                MobileNo: '',
                FileName:'',

            });
       
    }

    onSubmit() {


        var validation = "";
        if (this.InstanceForm.value.CompanyName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Company Name</span></br>"
        }
        if (this.InstanceForm.value.CompanyCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Company Short Name</span></br>"
        }
        if (this.InstanceForm.value.Address == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Address</span></br>"
        }
        if (this.InstanceForm.value.ContactName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter ContactName</span></br>"
        }
         if (this.InstanceForm.value.ZipCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter ZipCode</span></br>"
        }
        if (this.InstanceForm.value.Designation == "") {
            validation += "<span style='color:red;'>*</span> <span>Please EnterDesignation</span></br>"
        }
        if (this.InstanceForm.value.ContactEmailID == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Contact EmailID</span></br>"
        }
        if (this.InstanceForm.value.TelePhone1 == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter TelePhone1</span></br>"
        }
        if (this.InstanceForm.value.MobileNo == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter MobileNo</span></br>"
        }
        if (this.InstanceForm.value.EmailID == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Contact EmailID</span></br>"
        }
        if (validation != "") {

            Swal.fire(validation)
            return false;
        }
        

            this.InstanceForm.value.CityID = $('#ddlCity').val();
            this.InstanceForm.value.CountryID = $('#ddlCountry').val();
           
            this.sa.saveCompany(this.InstanceForm.value).subscribe(Data => {
                Swal.fire(Data[0].AlertMessage);
            },
                (error: HttpErrorResponse) => {
                    Swal.fire(error.message)
                });
        
    }


    btntabclick(tab) {


        var values = "ID: " + this.InstanceForm.value.ID;
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


    ///*File Upload*/
    //selectedFile: File = null;
    //uploadedfile: string = null;
    //progress: string = '';

    //onFileSelected(event) {
    //    this.selectedFile = event.target.files[0];
    //    const filedata = new FormData();
    //    filedata.append('file', this.selectedFile, this.selectedFile.name)
    //    this.sa.AttachUpload(this.selectedFile).subscribe(
    //        (event) => {

    //            var fullpath = event;
    //            var res = JSON.stringify(fullpath).split('\\').pop().split('"}')[0]
    //            this.uploadedfile = res;
    //            console.log(this.uploadedfile);

    //        }
    //    );

    //}
    ///*File Upload*/

    //onUpload() {
    //    this.imgsrc = ("Uploader/CompanyLogo/202_243_thumb-1920-82317.jpg");
        
    //}
}
