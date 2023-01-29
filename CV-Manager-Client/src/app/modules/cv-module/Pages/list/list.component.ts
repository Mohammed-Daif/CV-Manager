import { CvApiService } from './../../cv-api.service';
import { Component, OnInit } from '@angular/core';
import { IPagination } from 'src/app/core/components/table/pagination.interface';
import { Router } from '@angular/router';
import { ConfirmationService } from 'primeng/api';
import { UtilitiesService } from 'src/app/core/services/utilities.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
  providers: [ConfirmationService],
})
export class ListComponent implements OnInit {
  _index: number = 0;
  _size: number = 8;
  data: IPagination = { data: [], count: 0 };
  constructor(
    private cvApiService: CvApiService,
    private router: Router,
    private confirmationService: ConfirmationService,
    private utilitiesService: UtilitiesService
  ) {}
  ngOnInit(): void {
    this.getPagination();
  }
  getPagination(index: number = 0, size: number = 8) {
    this.cvApiService.getPagination(index, size).subscribe((data) => {
      (this.data = data), console.log(data);
    });
  }
  handelView(key: any) {
    this.router.navigateByUrl(`cv/view/${key}`);
  }
  handelEdit(key: any) {
    this.router.navigate(['cv/edit', key]);
  }
  handelDelete(key: any) {
    this.confirmationService.confirm({
      message: 'Are you sure that you want to Delete CV?',
      header: 'Confirmation',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.cvApiService.delete(key).subscribe((res) => {
          console.log({ res });
          this.utilitiesService.showMessage(
            'deleted',
            'item deleted successfully',
            'success'
          );
          this.getPagination(this._index, this._size);
        });
      },
      reject: () => {},
    });
  }
  handelNew() {
    this.router.navigate(['cv/create']);
  }
  handelPageChange(e: any) {
    console.log("handelPageChange", e)
    this._index = e.index;
    this._size = e.size;

    this.getPagination(e.index, e.size);
  }
}
