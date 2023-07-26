import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { MastersService } from 'src/app/services/masters.service';
import Swal from 'sweetalert2';
import { ActivatedRoute, Router } from '@angular/router';
import { UOMConversions } from '../../../../../model/common';
import { PaginationService } from '../../../../../pagination.service';
import { UOMMaster, UOMtypes } from '../../../../../model/common';
declare let $: any;

@Component({
  selector: 'app-uomconversionsview',
  templateUrl: './uomconversionsview.component.html',
  styleUrls: ['./uomconversionsview.component.css']
})
export class UomconversionsviewComponent implements OnInit {

    constructor(private router: Router, private route: ActivatedRoute, private service: MastersService, private fb: FormBuilder, public ps: PaginationService) { }


    statusvalues: Status[] = [
        { value: '1', viewValue: 'Yes' },
        { value: '2', viewValue: 'No' },
    ];

    //statusvalues1: action[] = [
    //    { value: '1', viewValue: 'Plus' },
    //    { value: '2', viewValue: 'Minus' },
    //    { value: '3', viewValue: 'Multiply' },
    //    { value: '4', viewValue: 'Divide' },
    //];

    // array of all items to be paged
    private allItems: any[];

    // pager object
    pager: any = {};

    // paged items
    pagedItems: any[];
    DsUOMActions: UOMtypes[];
    myControl = new FormControl('');
    searchForm: FormGroup;
    dataSource: UOMConversions[];

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
        this.refreshDepList();
        this.clearSearch();


        this.service.getUOMActions(this.searchForm.value).subscribe(data => {
            this.DsUOMActions = data;
        });
    }

    refreshDepList() {

        this.service.UOMConversionsList(this.searchForm.value).subscribe(data => {
            // set items to json response
            this.allItems = data;

            // initialize to page 1
            this.setPage(1);
        });
    }

    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            UOMFrom: '',
            UOMTo: '',
            Factor: '',
            Action: 0,
            Status: 0,
        });
    }

    onSubmit() {      
        this.searchForm.value.Action = $('#ddlactionv').val();
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.refreshDepList();

    }

    clearSearch() {
        this.searchForm.value.Status = $('#ddlStatusv').val();
        this.searchForm.value.Action = $('#ddlactionv').val();
        this.createForm()
        $('#ddlStatusv').val(0).trigger("change");
        $('#ddlactionv').val(0).trigger("change");
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

}
interface Status {
    value: string;
    viewValue: string;
}
interface action {
    value: string;
    viewValue: string;
}