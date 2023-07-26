import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { UOMMaster, UOMtypes } from '../../../../model/common';
import { MastersService } from '../../../../services/masters.service';
import { SystemadminService } from '../../../../services/systemadmin.service';
import { MySACommon } from '../../../../model/systemadmin';
declare let $: any;
@Component({
    selector: 'app-uommaster',
    templateUrl: './uommaster.component.html',
    styleUrls: ['./uommaster.component.css']
})


export class UommasterComponent implements OnInit {
    statusvalues: Status[] = [
        { value: '1', viewValue: 'YES' },
        { value: '2', viewValue: 'NO' },
    ];

    statusvalues1: UOMType[] = [
        { value: '1', viewValue: 'Length' },
        { value: '2', viewValue: 'Weight' },
        { value: '3', viewValue: 'Time' },
        { value: '4', viewValue: 'Temperature' },
        { value: '5', viewValue: 'Capacity' },
        { value: '6', viewValue: 'Billing Unit' },
    ];
    id = "0";
    myControl = new FormControl('');
    uommasterForm: FormGroup;
    dataSource: UOMMaster[];
    DsUOMCommon: UOMtypes[];

    constructor(private router: Router, private route: ActivatedRoute, private service: MastersService, private sa: SystemadminService, private fb: FormBuilder) {

        this.route.queryParams.subscribe(params => {
            this.uommasterForm = this.fb.group({
                ID: params['id'],
            });
        });
    }

    ngOnInit() {
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

        this.service.getUOMTypes(this.uommasterForm.value).subscribe(data => {
            this.DsUOMCommon = data;
        });
   
    }

    createForm() {
        if (this.uommasterForm.value.ID != null) {

            this.service.getUOMedit(this.uommasterForm.value).pipe(
            ).subscribe(data => {
                this.uommasterForm.patchValue(data[0]);
                $('#ddlStatus').select2().val(data[0].Status);
                $('#ddlUOMType').select2().val(data[0].UOMType);
            });

           
            this.uommasterForm = this.fb.group({
                ID: 0,
                UOMCode: '',
                UOMDesc: '',
                Status: 0,
                UOMType: 0,
                PortID:0,
            });
            this.ForsControDisable();
        }
        else {
            this.uommasterForm = this.fb.group({
                ID: 0,
                UOMCode: '',
                UOMDesc: '',
                Status: 1,
                UOMType: 0,
                PortID: 0,
            });
        }
      
    }
    ForsControDisable() {
        $('#ddlUOMType').select2("enable", false);
        $("#txtUOMCode").attr("disabled", "disabled");
        $("#txtUOMDesc").attr("disabled", "disabled");
    }
    onSubmit() {
        
        var validation = "";

        if (this.uommasterForm.value.UOMCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter UOM Code</span></br>"
        }
        if (this.uommasterForm.value.UOMDesc == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter UOM Description</span></br>"
        }

        if (validation != "") {
            Swal.fire(validation)
            return false;
        } else {
            this.uommasterForm.value.Status = $('#ddlStatus').val();
            this.uommasterForm.value.UOMType = $('#ddlUOMType').val();
            this.service.saveUOM(this.uommasterForm.value).subscribe(Data => {
                Swal.fire(Data[0].AlertMessage)
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/uommaster/uommasterview']);
                    }, 1500);  //5s
                }

            },
                (error: HttpErrorResponse) => {
                    Swal.fire(error.message)
                });
        }
    }

    onBack() {
        if (this.uommasterForm.value.ID == 0) {
            var validation = "";
            if (this.uommasterForm.value.UOMCode != "" || this.uommasterForm.value.UOMDesc != "") {
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
                        this.router.navigate(['/views/masters/commonmaster/uommaster/uommasterview']);
                    }
                })

                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/uommaster/uommasterview']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/uommaster/uommasterview']);
        }
    }

}

interface Status {
    value: string;
    viewValue: string;
}

interface UOMType {
    value: string;
    viewValue: string;
}
