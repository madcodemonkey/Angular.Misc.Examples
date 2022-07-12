import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { LookupItem } from '../_models/LookupItem';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StatesService {
  baseUrl = environment.apiUri;

  constructor(private http: HttpClient) { }


  getAll() : Observable<LookupItem[]> {
    return this.http.get<LookupItem[]>(`${this.baseUrl}/State`);
  }

  getById(id : number) : Observable<LookupItem> {
    return this.http.get<LookupItem>(`${this.baseUrl}/State?id=${id}`);
  }

}
