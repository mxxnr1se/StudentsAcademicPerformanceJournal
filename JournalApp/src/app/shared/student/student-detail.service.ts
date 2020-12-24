import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { StudentDetail } from './student-detail.model';
import { GroupDetail } from '../group/group-detail.model';

@Injectable({
  providedIn: 'root'
})
export class StudentDetailService {

  constructor(private http:HttpClient) { }

  readonly baseURL = "http://localhost:5000/api/students"
  formData:StudentDetail = new StudentDetail();
  list:StudentDetail[];
  groupList:GroupDetail[];

  postStudentDetails(){
    if (this.formData.groupId == "null")
    this.formData.groupId = null;

    return this.http.post(this.baseURL, this.formData)
  }

  putStudentDetails(){
    if (this.formData.groupId == "null")
    this.formData.groupId = null;

    return this.http.put(`${this.baseURL}`, this.formData)
  }

  deleteStudentDetails(id:number){
    return this.http.delete(`${this.baseURL}/${id}`)
  }

  refreshList(){
    this.http.get(this.baseURL).toPromise()
    .then(res => {
      this.list = res as StudentDetail[];
      this.list.forEach(element => {
        if (element.groupNumber == null)
          element.groupNumber = "-";
      });
    });
    this.http.get("http://localhost:5000/api/groups").toPromise()
    .then(res => this.groupList = res as GroupDetail[]);
  }
}
