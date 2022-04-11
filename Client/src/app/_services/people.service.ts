import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Person } from '../_models/person';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {
  baseUrl = environment.apiUri;

  constructor(private http: HttpClient) { }

  getAll() : Observable<Person[]> {
    return this.http.get<Person[]>(`${this.baseUrl}/People`);
  }

  getById(id : number) : Observable<Person> {
    return this.http.get<Person>(`${this.baseUrl}/People/${id}`);
  }
}
