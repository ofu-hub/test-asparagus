// asparagus.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AsparagusService {

  private apiUrl = 'http://localhost:5133/api/Asparagus';

  constructor(private http: HttpClient) { }

  addEntry(entry: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, entry);
  }

  getEntries(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}
