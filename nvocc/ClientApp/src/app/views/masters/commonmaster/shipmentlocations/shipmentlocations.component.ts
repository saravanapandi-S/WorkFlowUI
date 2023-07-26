import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MastersService } from 'src/app/services/masters.service';
import { SystemadminService } from 'src/app/services/systemadmin.service';
import { City, Country, shipmentLocations } from '../../../../model/common';
import Swal from 'sweetalert2';
import { MySACommon } from '../../../../model/systemadmin';
declare let $: any;

@Component({
    selector: 'app-shipmentlocations',
    templateUrl: './shipmentlocations.component.html',
    styleUrls: ['./shipmentlocations.component.css']
})
export class ShipmentlocationsComponent implements OnInit {

    statusvalues: Status[] = [
        { value: '1', viewValue: 'Yes' },
        { value: '2', viewValue: 'No' },
    ];

    constructor(private router: Router, private route: ActivatedRoute, private service: MastersService, private fb: FormBuilder, private service1: SystemadminService) {
        this.route.queryParams.subscribe(params => {

            this.ShipmentForm = this.fb.group({
                ID: params['id'],

            });
        });
    }
    myControl = new FormControl('');
    ShipmentForm: FormGroup;
    dataSource: shipmentLocations[];
    dscountryItem: Country[];
    dscityItem: MySACommon[];



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
        $('#ddlCountryv').on('select2:select', (e, args) => {
            this.OnClickCitydropdown($("#ddlCountryv").val());
        });
    }
    createForm() {
        if (this.ShipmentForm.value.ID != null) {
            this.service.ShipmentLocationEdit(this.ShipmentForm.value).pipe(
            ).subscribe(data => {
                this.ShipmentForm.patchValue(data[0]);
                this.OnClickCitydropdown(data[0].CountryID);
                $('#ddlcity').select2().val(data[0].CityID);
                $('#ddlCountryv').select2().val(data[0].CountryID);
                $('#ddlStatus').select2().val(data[0].status);
            });
            this.ShipmentForm = this.fb.group({
                ID: 0,
                LocationCode: '',
                Location: '',
                CityID: 0,
                CountryID: 0,
                status: 1,

            });
            this.ForsControDisable();
        }
        else {
            this.ShipmentForm = this.fb.group({
                ID: 0,
                LocationCode: '',
                Location: '',
                CityID: 0,
                CountryID: 0,
                status: 1,

            });
        }
    
    }
    ForsControDisable() {
        $('#ddlCountryv').select2("enable", false);
        $('#ddlcity').select2("enable", false);
        $("#txtLocationCode").attr("disabled", "disabled");
        $("#txtLocation").attr("disabled", "disabled");
      
    }
    onInitalBinding() {

        this.dropdowncountry();      

        
    }

    OnClickCitydropdown(CtryID) {
        this.ShipmentForm.value.CountryID = CtryID;
        this.service1.GetCities(this.ShipmentForm.value).subscribe(data => {
            this.dscityItem = data;
        });
    }

    dropdowncountry() {

        this.service.getCountry(this.ShipmentForm.value).subscribe(data => {
            this.dscountryItem = data;

        });
    }

    onSubmit() {


        var validation = "";
        if (this.ShipmentForm.value.LocationCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Location Code</span></br>"
        }
        if (this.ShipmentForm.value.Location == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Location Name</span></br>"
        }
        if ($('#ddlCountryv').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Country</span></br>"
        }
        if ($('#ddlcity').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select City</span></br>"
        }
        if (validation != "") {

            Swal.fire(validation)
            return false;
        }
        else {

            this.ShipmentForm.value.CityID = $('#ddlcity').val();
            this.ShipmentForm.value.CountryID = $('#ddlCountryv').val();
            this.ShipmentForm.value.status = $('#ddlStatus').val();
            this.service.getSaveshipmentlocation(this.ShipmentForm.value).subscribe(Data => {
            
                Swal.fire(Data[0].AlertMessage)
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview/']);
                    }, 1500);  //5s
                }

            },
                (error: HttpErrorResponse) => {
                    Swal.fire(error.message)
                });
        }

    }
    onBack() {
        if (this.ShipmentForm.value.ID == 0) {
           
            var validation = "";
            if (this.ShipmentForm.value.LocationCode != "" || this.ShipmentForm.value.Location != "") {
                validation += "<span style='color:red;'>*</span> <span>Do you want save changes?</span></br>"
            }
            if (validation != "") {
                Swal.fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    confirmButtonText: 'YES',
                    denyButtonText: `NO`,
                }).then((result) => {
                    if (result.isConfirmed) {
                    } else {
                        this.router.navigate(['/views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview/']);
                    }
                })

                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview/']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/shipmentlocations/shipmentlocationsview/shipmentlocationsview/']);
        }
    }
}


interface Status {
    value: string;
    viewValue: string;
}