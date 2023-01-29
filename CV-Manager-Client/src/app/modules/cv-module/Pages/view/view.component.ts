import { ICV } from './../../cv.interface';
import { CvApiService } from './../../cv-api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.scss'],
})
export class ViewComponent implements OnInit, OnDestroy {
  id: any;
  data: ICV| undefined;
  ref: Subscription |undefined;
  constructor(
    private route: ActivatedRoute,
    private cvApiService: CvApiService
  ) {}
  
  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.ref = this.cvApiService.getGetById<ICV>(this.id).subscribe(
      res => this.data = res
    )
  }
  ngOnDestroy(): void {
    this.ref?.unsubscribe()
  }
}
