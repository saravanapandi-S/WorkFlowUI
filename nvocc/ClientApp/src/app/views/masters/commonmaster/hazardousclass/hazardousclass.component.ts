import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MastersService } from 'src/app/services/masters.service';
import { Hazardous } from '../../../../model/common';
import Swal from 'sweetalert2';
declare let $: any;
@Component({
    selector: 'app-hazardousclass',
    templateUrl: './hazardousclass.component.html',
    styleUrls: ['./hazardousclass.component.css']
})
export class HazardousclassComponent implements OnInit {

    statusvalues: Status[] = [
        { value: '1', viewValue: 'Yes' },
        { value: '2', viewValue: 'No' },
    ];

    constructor(private router: Router, private route: ActivatedRoute, private service: MastersService, private fb: FormBuilder) {
        this.route.queryParams.subscribe(params => {

            this.HazardousForm = this.fb.group({
                ID: params['id'],

            });
        });
    }

    myControl = new FormControl('');
    HazardousForm: FormGroup;
    dataSource: Hazardous[];

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
    }

    createForm() {
        if (this.HazardousForm.value.ID != null) {
            this.service.HazardousEdit(this.HazardousForm.value).pipe(
            ).subscribe(data => {
                this.HazardousForm.patchValue(data[0]);               
                $('#ddlStatus').select2().val(data[0].Status);
            });
            this.HazardousForm = this.fb.group({
                ID: 0,
                ClassDesc: '',
                DivisionDesc: '',
                Status: 0,
            });
            this.ForsControDisable();
        }
        else {
            this.HazardousForm = this.fb.group({
                ID: 0,
                ClassDesc: '',
                DivisionDesc: '',
                Status: 0,
            });
        }
    }
    ForsControDisable() {
       
        $("#txtClassDesc").attr("disabled", "disabled");
        $("#txtDivisionDesc").attr("disabled", "disabled");
       
    }

    onSubmit() {

        var validation = "";
        if (this.HazardousForm.value.ClassDesc == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Class Description</span></br>"
        }
        if (this.HazardousForm.value.DivisionDesc == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Division Description</span></br>"
        }
        if (validation != "") {

            Swal.fire(validation)
            return false;
        }
        else {
            this.HazardousForm.value.Status = $('#ddlStatus').val();
            this.service.getSaveHazardousClasses(this.HazardousForm.value).subscribe(Data => {
              //  this.HazardousForm.value.ID = Data[0].ID;
                Swal.fire(Data[0].AlertMessage)
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview/']);
                    }, 1500);  //5s
                }

            },
                (error: HttpErrorResponse) => {
                    Swal.fire(error.message)
                });
        }
    }
    onBack() {
        if (this.HazardousForm.value.ID == 0) {
            var validation = "";
            if (this.HazardousForm.value.ClassDesc != "" || this.HazardousForm.value.DivisionDesc != "") {
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
                        this.router.navigate(['/views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview/']);
                    }
                })

                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview/']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/hazardousclass/hazardousclassview/hazardousclassview/']);
        }
    }

}


interface Status {
    value: string;
    viewValue: string;
}