import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MastersService } from 'src/app/services/masters.service';
import Swal from 'sweetalert2';
import { MyCompany } from '../../model/systemadmin';
import { PaginationService } from '../../pagination.service';
import { SystemadminService } from '../../services/systemadmin.service';
import { EncrDecrServiceService } from '../../services/encr-decr-service.service';

declare let $: any;

@Component({
  selector: 'app-instanceprofile',
  templateUrl: './instanceprofile.component.html',
  styleUrls: ['./instanceprofile.component.css']
})
export class InstanceprofileComponent implements OnInit {

    constructor(private router: Router, private route: ActivatedRoute, private ES: EncrDecrServiceService, private service: MastersService, private fb: FormBuilder, public ps: PaginationService, private sa: SystemadminService) { }

    // array of all items to be paged
    private allItems: any[];

    // pager object
    pager: any = {};

    // paged items
    pagedItems: any[];
    myControl = new FormControl('');
    searchForm: FormGroup;
    dataSource: MyCompany[];

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

    }

    refreshDepList() {

        this.sa.GetCompanyView(this.searchForm.value).subscribe(data => {
            this.allItems = data;
            this.setPage(1);
        });
    }

    createForm() {
        this.searchForm = this.fb.group({
            ID: 0,
            CompanyName: '',
            CompanyCode: '',
        });
    }

    onSubmit() {
       
        this.refreshDepList();

    }

    clearSearch() {
              this.createForm()
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
    OnClickEdit(IDv) {

        var values = "ID: " + IDv;
        var encrypted = this.ES.set(localStorage.getItem("EncKey"), values);
        this.router.navigate(['/views/masters/instanceprofile/companydetails/companydetails/'], { queryParams: { encrypted } });
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
