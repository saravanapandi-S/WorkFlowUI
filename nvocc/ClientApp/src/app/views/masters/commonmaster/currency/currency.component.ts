import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { Country, CurrencyName, StateMaster } from '../../../../model/common';
import { MastersService } from '../../../../services/masters.service';
import { SystemadminService } from '../../../../services/systemadmin.service';
import { MySACommon } from '../../../../model/systemadmin';
declare let $: any;

@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html',
  //styleUrls: ['./currency.component.css']
})
export class CurrencyComponent implements OnInit {

    statusvalues: Status[] = [
        { value: '1', viewValue: 'Yes' },
        { value: '2', viewValue: 'No' },
    ];
    id = "0";
    myControl = new FormControl('');
    CurrencyForm: FormGroup;
    dataSource: CurrencyName[];
    dscountryItem: MySACommon[];

    constructor(private router: Router, private route: ActivatedRoute, private service: MastersService, private fb: FormBuilder, private country: SystemadminService) {
        this.route.queryParams.subscribe(params => {
            this.CurrencyForm = this.fb.group({
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
        this.OnBindDropdownCountry();
    }

    OnBindDropdownCountry() {
        this.country.GetCountries(this.CurrencyForm.value).subscribe(data => {
            this.dscountryItem = data;

        });
    }

    createForm() {
        if (this.CurrencyForm.value.ID != null) {

            this.service.Currencyedit(this.CurrencyForm.value).pipe(
            ).subscribe(data => {
                this.CurrencyForm.patchValue(data[0]);
                $('#ddlStatus').select2().val(data[0].Status);
                $('#ddlCountry').select2().val(data[0].CountryID);
            });

            this.CurrencyForm = this.fb.group({
                ID: 0,
                CurrencyCode: '',
                CurrencyName: '',
                Symbol: '',
                CountryID: 0,
                Status: 0
            });
            this.ForsControDisable();
        }
        else {
            this.CurrencyForm = this.fb.group({
                ID: 0,
                CurrencyCode: '',
                CurrencyName: '',
                Symbol: '',
                CountryID: 0,
                Status: 1
            });
            $('#ddlStatus').select2().val(0);
        }
    }

    ForsControDisable() {

        $('#ddlCountry').select2("enable", false);
        $("#txtSymbol").attr("disabled", "disabled");
        $("#txtCurrencyCode").attr("disabled", "disabled");
        $("#txtCurrencyName").attr("disabled", "disabled");

    }
    onSubmit() {
        var validation = "";
        if ($('#ddlCountry').val() == null) {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Country</span></br>"
        }
        if (this.CurrencyForm.value.CurrencyCode == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Currency Code </span></br>"
        }
        if (this.CurrencyForm.value.CurrencyName == "") {
            validation += "<span style='color:red;'>*</span> <span>Please Enter Currency Name</span></br>"
        }

        if (validation != "") {

            Swal.fire(validation)
            return false;
        } else {
            this.CurrencyForm.value.Status = $('#ddlStatus').val();
            this.CurrencyForm.value.CountryID = $('#ddlCountry').val();
            this.service.saveCurrency(this.CurrencyForm.value).subscribe(Data => {
                Swal.fire(Data[0].AlertMessage)
                if (Data[0].AlertMegId == 2) {
                    setTimeout(() => {
                        this.router.navigate(['/views/masters/commonmaster/currency/currencyview/currencyview']);
                    }, 1500);  //5s
                }

            },
                (error: HttpErrorResponse) => {
                    Swal.fire(error.message)
                });
        }
    }

    onBack() {
        if (this.CurrencyForm.value.ID == 0) {
            var validation = "";
            if ($('#ddlCountry').val() != null || this.CurrencyForm.value.CurrencyCode != "" || this.CurrencyForm.value.CurrencyName != "") {
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
                        this.router.navigate(['/views/masters/commonmaster/currency/currencyview/currencyview']);
                    }
                })

                return false;
            }
            else {
                this.router.navigate(['/views/masters/commonmaster/currency/currencyview/currencyview']);
            }
        }
        else {
            this.router.navigate(['/views/masters/commonmaster/currency/currencyview/currencyview']);
        }
    }
}

interface Status {
    value: string;
    viewValue: string;
}
