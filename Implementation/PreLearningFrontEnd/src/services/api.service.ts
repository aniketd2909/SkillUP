import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private httpClient: HttpClient) {}

  get(path): Observable<any> {
    return this.httpClient.get(`${environment.baseUrl}/${path}`);
  }
  post(path, data): Observable<any> {
    return this.httpClient.post(`${environment.baseUrl}/${path}`, data);
  }
  postAnswer(path, data): Observable<any> {
    return this.httpClient.post(`${environment.baseUrl}/${path}`, data, {
      responseType:"text"
    });
  }

  delete(path): Observable<any> {
    return this.httpClient.delete(`${environment.baseUrl}/${path}`);
  }
  update(path, data): Observable<any> {
    return this.httpClient.put(`${environment.baseUrl}/${path}`, data);
  }

  getById(path,id): Observable<any> {
    return this.httpClient.get(`${environment.baseUrl}/${path}/${id}`);
  }

    UploadExcel(path,formData):Observable<any> {
        let headers = new HttpHeaders();

        headers.append('Content-Type', 'multipart/form-data');
        headers.append('Accept', 'application/json');

        const httpOptions = { headers: headers };

        return this.httpClient.post(`${environment.baseUrl}/${path}`, formData, httpOptions)
    } 
}
