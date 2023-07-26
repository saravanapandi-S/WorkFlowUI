import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MastersService } from 'src/app/services/masters.service';
import { UOMConversions, UOMtypes, UOMValues } from '../../../../model/common';
import Swal from 'sweetalert2';
declare let $: any;


@Component({
    selector: 'app-uomconversions',
    templateUrl: './uomconversions.component.html',
    styleUrls: ['./uomconversions.component.css']
})
export class UomconversionsComponent implements OnInit {
    statusvalues: Status[] = [
        { value: '1', viewValue: 'Yes' },
        { value: '2', viewValue: 'No' },
    ];



    constructor(private router: Router, private route: ActivatedRoute, private service: MastersService, private fb: FormBuilder) {
        this.route.queryParams.subscribe(params => {
            this.UOMForm = this.fb.group({
                ID: params['id'],
            });

        });
    }

    id = "0";
    myControl = new FormControl('');
    UOMForm: FormGroup;
    dataSource: UOMConversions[];
    DsUOMActions: UOMtypes[];
    DsUOMValues: UOMValues[];
    statusvalues1: action[] = [
        { value: '1', viewValue: 'Plus' },
        { value: '2', viewValue: 'Minus' },
        { value: '3', viewValue: 'Multiply' },
        { value: '4', viewValue: 'Divide' },
    ];


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
        this.service.getUOMActions(this.UOMForm.value).subscribe(data => {
            this.DsUOMActions = data;
        });
        this.service.getUOMValues(this.UOMForm.value).subscribe(data => {
            this.DsUOMValues = data;
        });
    }

    createForm() {

        if (this.UOMForm.value.ID != null) {
            this.service.UOMConversionsEdit(this.UOMForm.value).pipe(
            ).subscribe(data => {
                this.UOMForm.patchValue(data[0]);
                $('#ddlAction').select2().val(data[0].Action);
                $('#ddlStatus').select2().val(data[0].Status);
                $('#ddlUOMFrom').select2().val(data[0].UOMFrom);
                $('#ddlUOMTo').select2().val(data[0].UOMTo);
            });
            this.UOMForm = this.fb.group({

                ID: 0,
                UOMFrom: 0,
                UOMTo: 0,
                Factor: '',
                Action: 0,
                Status: 0,

            });
            this.ForsControDisable();
        }
        else {
            this.UOMForm = this.fb.group({

                ID: 0,
                UOMFrom: 0,
                UOMTo: 0,
                Factor: '',
                Action: 0,
                Status: 0,

            });
        }
    }
    ForsControDisable() {

        $('#ddlUOMFrom').select2("enable", false);
        $('#ddlUOMTo').select2("enable", false);
        $('#ddlAction').select2("enable", false);
        $("#txtFactor").attr("disabled", "disabled");
       
    }
    onSubmit() {

        var validation = "";

        if ($('#ddlUOMFrom').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select UOM From</span></br>"
        }
        if ($('#ddlUOMTo').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select UOM To</span></br>"
        }
        if ($('#ddlAction').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Action</span></br>"
        }
        if (this.UOMForm.value.Factor == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Factor Name</span></br>"
        }
        if (validation != "") {

            Swal.fire(validation)
            return false;
        }
        else {

            this.UOMForm.value.Status = $('#ddlStatus').val();
            this.UOMForm.value.Action = $('#ddlAction').val();
            this.UOMForm.value.UOMFrom = $('#ddlUOMFrom').val();
          
            this.UOMForm.value.UOMTo = $('#ddlUOMTo').val();
            this.service.SaveUOMConversions(this.UOMForm.value).subscribe(Data => {
                Swal.fire(Data[0].AlertMessage)
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview/']);
                    }, 1500);  //5s
                }

            },
                (error: HttpErrorResponse) => {
                    Swal.fire(error.message)
                });
        }
    }
    onBack() {
        if (this.UOMForm.value.ID == 0) {
            var validation = "";
            if (this.UOMForm.value.UOMFrom != "" || this.UOMForm.value.UOMTo != "") {
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
                        this.router.navigate(['/views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview/']);
                    }
                })

                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview/']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/uomconversions/uomconversionsview/uomconversionsview/']);
        }
    }
} 


interface Status {
    value: string;
    viewValue: string;
}
interface action {
    value: string;
    viewValue: string;
}