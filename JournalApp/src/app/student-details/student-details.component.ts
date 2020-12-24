import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { StudentDetail } from '../shared/student/student-detail.model';
import { StudentDetailService } from '../shared/student/student-detail.service';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styles: [
  ]
})
export class StudentDetailsComponent implements OnInit {
  search:string;
  constructor(public service:StudentDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.search ='';
  }

  populateForm(selectedRecord:StudentDetail){
    this.service.formData =  Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if (confirm('Are you sure to delete this record?'))
    {
      this.service.deleteStudentDetails(id)
      .subscribe(
       res=>{
         this.service.refreshList();
         this.service.formData = new StudentDetail();
         this.toastr.error("Deleted successfully", "Student deleted");
       },
       err => {
        console.log(err);
        }
      )
    }
  }
}
