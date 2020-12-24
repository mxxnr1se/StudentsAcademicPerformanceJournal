import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { StudentDetail } from 'src/app/shared/student/student-detail.model';
import { StudentDetailService } from 'src/app/shared/student/student-detail.service';

@Component({
  selector: 'app-student-detail-form',
  templateUrl: './student-detail-form.component.html',
  styles: [
  ]
})
export class StudentDetailFormComponent implements OnInit {

  constructor(public service:StudentDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.id == 0)
      this.inserRecord(form);
    else
      this.updateRecord(form);
  }

  inserRecord(form: NgForm){
    this.service.postStudentDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted succesfully', "Student added")
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putStudentDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated succesfully', "Student updated")
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new StudentDetail();
  }
}
