import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { map } from 'rxjs/operator/map';

@Injectable()
export class ApiService {

  private baseUrlApi: string = "http://localhost:54344/";

  constructor(private http: Http) {
  }

  get(url) {
    return this.http.get(this.baseUrlApi + url);
  }

  post(url, data) {
    return this.http.post(this.baseUrlApi + url, data);
  }
}
