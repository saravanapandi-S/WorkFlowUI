import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UOMMaster, UOMtypes } from '../../../../../model/common';
import { PaginationService } from '../../../../../pagination.service';
import { MastersService } from '../../../../../services/masters.service';
import { Title } from '@angular/platform-browser';
declare let $: any;
@Component({
    selector: 'app-uommasterview',
    templateUrl: './uommasterview.component.html',
    styleUrls: ['./uommasterview.component.css']
})
export class UommasterviewComponent implements OnInit {
    title = 'UOM Master';


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
    constructor(private ms: MastersService, private fb: FormBuilder, private service: MastersService,public ps: PaginationService, private titleService: Title) { }

    // array of all items to be paged
    private allItems: any[];

    // pager object
    pager: any = {};

    // paged items
    pagedItems: any[];

    DsUOMCommon: UOMtypes[];
    dataSource: UOMMaster[];
    searchForm: FormGroup;

    ngOnInit() {
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
        this.service.getUOMTypes(this.searchForm.value).subscribe(data => {
            this.DsUOMCommon = data;
        });
        this.refreshDepList();
        this.clearSearch();
    }

    refreshDepList() {
        this.ms.getUOMList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;

            // initialize to page 1
            this.setPage(1);
        });
    }

    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            UOMCode: '',
            UOMDesc: '',
            Status: 0,
            UOMType: 0
        });
    }
    clearSearch() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.searchForm.value.UOMType = $('#ddlUOMTypev').val();
        this.createForm();

        this.refreshDepList();
        $('#ddlStatusv').val(0).trigger("change");
        $('#ddlUOMTypev').val(0).trigger("change");
    }
    onSubmit() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.searchForm.value.UOMType = $('#ddlUOMTypev').val();
        this.refreshDepList();
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

interface UOMType {
    value: string;
    viewValue: string;
}
