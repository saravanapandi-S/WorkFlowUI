import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { ContainerType, CTSizes, CTTypes, CTGroups } from '../../../../model/common';
import { MastersService } from '../../../../services/masters.service';
declare let $: any;

@Component({
    selector: 'app-contypemaster',
    templateUrl: './contypemaster.component.html',
    styleUrls: ['./contypemaster.component.css']
})
export class ContypemasterComponent implements OnInit {

    statusvalues: Status[] = [
        { value: '1', viewValue: 'YES' },
        { value: '2', viewValue: 'NO' },
    ];

    statusvalues1: group[] = [
        { value: '1', viewValue: 'Reefer' },
        { value: '2', viewValue: 'General' },
        { value: '2', viewValue: 'special' },
    ];

    contypeForm: FormGroup;
    dsContainerType: ContainerType[];
    dsCntrTypes: CTTypes[];
    dsCntrSizes: CTSizes[];
    dsCntrGroup: CTGroups[];
    constructor(private router: Router, private route: ActivatedRoute, private service: MastersService, private fb: FormBuilder) {

        this.route.queryParams.subscribe(params => {
            this.contypeForm = this.fb.group({
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
        this.DropdownContainerTypes();
        this.DropdownContainerSize();
        this.OnBindDropdownCntrGroup();
    }

    DropdownContainerTypes() {

        this.service.getContainerSize(this.contypeForm.value).subscribe(data => {
            this.dsCntrSizes = data;
        });
       
    }
    OnBindDropdownCntrGroup() {
        this.service.getContainerGroup(this.contypeForm.value).subscribe(data => {
            this.dsCntrGroup = data;
        });
    }
    DropdownContainerSize() {

        this.service.getContainerTypes(this.contypeForm.value).subscribe(data => {
            this.dsCntrTypes = data;
        });


    }



    createForm() {
        if (this.contypeForm.value.ID != null) {
            this.service.getContTypeedit(this.contypeForm.value).pipe(
            ).subscribe(data => {
                this.contypeForm.patchValue(data[0]);
                $('#ddlType').select2().val(data[0].EQTypeID);
                $('#ddlSize').select2().val(data[0].SizeID);
                $('#ddlgroup').select2().val(data[0].groupID);
                $('#ddlStatus').select2().val(data[0].status);
            });

            this.contypeForm = this.fb.group({
                ID: 0,
                EQTypeID: 0,
                SizeID: 0,
                groupID: 0,
                status: 0,
                ISOCode: '',
                TEUS: '',
                GeneralName: '',
                Length: '',
                Width: '',
                Height: '',
                TareWeight: '',
                MaxPayload: '',
                Remarks: '',
                CntrTypeDesc: '',
            });
            this.ForsControDisable();
        }
        else {
            this.contypeForm = this.fb.group({
                ID: 0,
                EQTypeID: 0,
                SizeID: 0,
                groupID: 0,
                status: 0,
                ISOCode: '',
                TEUS: '',
                GeneralName: '',
                Length: '',
                Width: '',
                Height: '',
                TareWeight: '',
                MaxPayload: '',
                Remarks: '',
                CntrTypeDesc: '',
            });
        }
    }
    ForsControDisable() {

        $('#ddlSize').select2("enable", false);
        $('#ddlType').select2("enable", false);
        $('#ddlgroup').select2("enable", false);
        $("#txtCntrTypeDesc").attr("disabled", "disabled");
        $("#ddlISOCode").attr("disabled", "disabled");
        $("#txtHeight").attr("disabled", "disabled");
        $("#txtRemarks").attr("disabled", "disabled");
        $("#txtLength").attr("disabled", "disabled");
        $("#txtWidth").attr("disabled", "disabled");
        $("#txtTEUS").attr("disabled", "disabled");
        $("#txtTareWeight").attr("disabled", "disabled");
        $("#txtMaxPayload").attr("disabled", "disabled");
    }

    onSubmit() {
        var validation = "";

        if ($('#ddlType').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Container Type</span></br>"
        }
        if ($('#ddlSize').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Select Equipment Size</span></br>"
        }
        if (this.contypeForm.value.ISOCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter ISOCode</span></br>"
        }
        if (this.contypeForm.value.CntrTypeDesc == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Container Type Description</span></br>"
        }
        if (this.contypeForm.value.Width == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Width</span></br>"
        }
        if (this.contypeForm.value.Height == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Height</span></br>"
        }
        if (this.contypeForm.value.TareWeight == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Tare Weight</span></br>"
        }
        if (this.contypeForm.value.MaxPayload == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Max. Payload</span></br>"
        }
        if (this.contypeForm.value.TEUS == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter TEUs</span></br>"
        }

        if (validation != "") {

            Swal.fire(validation)
            return false;
        }

        this.contypeForm.value.EQTypeID = $('#ddlType').val();
        this.contypeForm.value.SizeID = $('#ddlSize').val();
        this.contypeForm.value.groupID = $('#ddlgroup').val();
        this.contypeForm.value.status = $('#ddlStatus').val();
        this.contypeForm.value.Size = $("#ddlSize option:selected").text();
        this.contypeForm.value.Type = $("#ddlType option:selected").text();
        this.service.saveContType(this.contypeForm.value).subscribe(Data => {
            Swal.fire(Data[0].AlertMessage)
            if (Data[0].AlertMegId == 2) {
                setTimeout(() => {
                    this.router.navigate(['/views/masters/commonmaster/contypemaster/contypemasterview']);
                }, 1500);  //5s
            }

        },
            (error: HttpErrorResponse) => {
                Swal.fire(error.message)
            });
    }


    onBack() {
        if (this.contypeForm.value.ID == 0) {
            var validation = "";
            if ($('#ddlType').val() != null || $('#ddlSize').val() != null || this.contypeForm.value.ISOCode != "" || this.contypeForm.value.Length != "" || this.contypeForm.value.Width != "" || this.contypeForm.value.Height != "" || this.contypeForm.value.TareWeight != "" || this.contypeForm.value.MaxPayload != "" || this.contypeForm.value.TEUS != "") {
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
                        this.router.navigate(['/views/masters/commonmaster/contypemaster/contypemasterview']);
                    }
                })

                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/contypemaster/contypemasterview']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/contypemaster/contypemasterview']);
        }
    }

}

interface Status {
    value: string;
    viewValue: string;
}
interface group {
    value: string;
    viewValue: string;
}