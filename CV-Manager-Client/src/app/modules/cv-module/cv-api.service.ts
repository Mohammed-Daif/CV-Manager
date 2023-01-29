import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiService } from 'src/app/core/services/api.service';
@Injectable({
  providedIn: 'root',
})
export class CvApiService extends ApiService {
   prefix: string = 'cv';
  constructor( http: HttpClient) {
    super(http);
  }
}
