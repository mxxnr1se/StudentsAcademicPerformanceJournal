import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { SubjectDetail } from './subject-detail.model';

@Injectable({
    providedIn: 'root'
})
export class SubjectDetailService {

  constructor(private http:HttpClient) {}

  readonly baseURL = "http://localhost:5000/api/subjects"
  formData:SubjectDetail = new SubjectDetail();
  list:SubjectDetail[];

  postSubjectDetails(){
    return this.http.post(this.baseURL, this.formData)
  }

  putSubjectDetails(){
    return this.http.put(`${this.baseURL}`, this.formData)
  }

  deleteSubjectDetails(id:number){
    return this.http.delete(`${this.baseURL}/${id}`)
  }

  refreshList(){
    this.http.get(this.baseURL).toPromise()
    .then(res => this.list = res as SubjectDetail[]);
  }
}
