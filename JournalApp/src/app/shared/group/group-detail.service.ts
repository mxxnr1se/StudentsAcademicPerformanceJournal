import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { GroupDetail } from './group-detail.model';

@Injectable({
  providedIn: 'root'
})
export class GroupDetailService {

  constructor(private http:HttpClient) { }

  readonly baseURL = "http://localhost:5000/api/groups"
  formData:GroupDetail = new GroupDetail();
  list:GroupDetail[];

  postGroupDetails(){
    return this.http.post(this.baseURL, this.formData)
  }

  putGroupDetails(){
    return this.http.put(`${this.baseURL}`, this.formData)
  }

  deleteGroupDetails(id:number){
    return this.http.delete(`${this.baseURL}/${id}`)
  }

  refreshList(){
    this.http.get(this.baseURL).toPromise()
    .then(res => this.list = res as GroupDetail[]);
  }
}
