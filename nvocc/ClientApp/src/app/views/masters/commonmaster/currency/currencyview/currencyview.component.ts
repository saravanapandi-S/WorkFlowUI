import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CurrencyName } from '../../../../../model/common';
import { PaginationService } from '../../../../../pagination.service';
import { MastersService } from '../../../../../services/masters.service';
import { Title } from '@angular/platform-browser';
import { SystemadminService } from '../../../../../services/systemadmin.service';
import { MySACommon } from '../../../../../model/systemadmin';
declare let $: any;

@Component({
  selector: 'app-currencyview',
  templateUrl: './currencyview.component.html',
 // styleUrls: ['./currencyview.component.css']
})
export class CurrencyviewComponent implements OnInit {

    title = 'Currency Master';
    statusvalues: Status[] = [
        { value: '1', viewValue: 'Yes' },
        { value: '2', viewValue: 'No' },
    ];

    constructor(private ms: MastersService, private fb: FormBuilder, public ps: PaginationService, private titleService: Title, private Service: SystemadminService) { }


    // array of all items to be paged
    private allItems: any[];

    // pager object
    pager: any = {};

    // paged items
    pagedItems: any[];

    dataSource: CurrencyName[];
    dscountryItem: MySACommon[];
    searchForm: FormGroup;


    ngOnInit(): void {


        this.titleService.setTitle(this.title);
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
        this.refreshDepList();
        this.dropdownCountry();
        this.clearSearch();
    }

    dropdownCountry() {
        this.Service.GetCountries(this.searchForm.value).subscribe(data => {
            this.dscountryItem = data;

        });
    }

    refreshDepList() {
        this.ms.getCurrencyList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;

            // initialize to page 1
            this.setPage(1);
        });
    }
    onSubmit() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.searchForm.value.CountryID = $('#ddlCountryv').val();
        this.refreshDepList();
    }
    createForm() {

        this.searchForm = this.fb.group({
            ID: 0,
            CurrencyCode: '',
            CurrencyName: '',          
            Status: 0,
            CountryID: 0
        });
    }
    clearSearch() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.searchForm.value.CountryID = $('#ddlCountryv').val();
        this.createForm();
        this.refreshDepList();
        $('#ddlStatusv').val(0).trigger("change");
        $('#ddlCountryv').val(0).trigger("change");
    }


    setPage(page: number) {
        //if (page < 1 || page > this.pager.totalPages) {
        //    return;
        //}

        // get pager object from service
        this.pager = this.ps.getPager(this.allItems.length, page);

        // get current page of items
        this.pagedItems = this.allItems.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
    isDesc: boolean = false;
    column: string = '';
    sort(property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        let direction = this.isDesc ? 1 : -1;

        this.pagedItems.sort(function (a, b) {
            if (a[property] < b[property]) {
                return -1 * direction;
            }
            else if (a[property] > b[property]) {
                return 1 * direction;
            }
            else {
                return 0;
            }
        });
    };
}
interface Status {
    value: string;
    viewValue: string;
}