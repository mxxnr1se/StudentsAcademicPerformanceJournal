import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { RatingDetail } from './rating-detail.model';
import { StudentDetail} from '../student/student-detail.model';
import { SubjectDetail} from '../subject/subject-detail.model';

@Injectable({
  providedIn: 'root'
})
export class RatingDetailService {

  constructor(private http:HttpClient) { }

  readonly baseURL = "http://localhost:5000/api/ratings"
  formData:RatingDetail = new RatingDetail();
  list:RatingDetail[];
  subjectList:SubjectDetail[];
  studentList:StudentDetail[];

  postRatingDetails(){
    if (this.formData.subjectId == "null")
    this.formData.subjectId = null;

    if (this.formData.studentId == "null")
    this.formData.studentId = null;

    return this.http.post(this.baseURL, this.formData)
  }

  putRatingDetails(){
    if (this.formData.subjectId == "null")
    this.formData.subjectId = null;

    if (this.formData.studentId == "null")
    this.formData.studentId = null;

    return this.http.put(`${this.baseURL}`, this.formData)
  }

  deleteRatingDetails(id:number){
    return this.http.delete(`${this.baseURL}/${id}`)
  }


  refreshList(){
    this.http.get(this.baseURL).toPromise()
    .then(res => {
      this.list = res as RatingDetail[];
      this.list.forEach(element => {
        if (element.subjectTitle == null)
          element.subjectTitle = "???";
      });
      this.list.forEach(element => {
        if (element.studentFirstName == null)
          element.studentFirstName = "???";
      });
      this.list.forEach(element => {
        if (element.studentLastName == null)
          element.studentLastName = "???";
      });
    });
    this.http.get("http://localhost:5000/api/subjects").toPromise()
    .then(res => this.subjectList = res as SubjectDetail[]);
    this.http.get("http://localhost:5000/api/students").toPromise()
    .then(res => this.studentList = res as StudentDetail[]);
  }
}
