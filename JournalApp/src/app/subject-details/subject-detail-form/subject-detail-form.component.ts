import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SubjectDetail } from 'src/app/shared/subject/subject-detail.model';
import { SubjectDetailService } from 'src/app/shared/subject/subject-detail.service';

@Component({
  selector: 'app-subject-detail-form',
  templateUrl: './subject-detail-form.component.html',
  styles: [
  ]
})

export class SubjectDetailFormComponent implements OnInit {

  constructor(public service:SubjectDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.id == 0)
      this.inserRecord(form);
    else
      this.updateRecord(form);
  }

  inserRecord(form: NgForm){
    this.service.postSubjectDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted succesfully', "Subject added")
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putSubjectDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated succesfully', "Subject updated")
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new SubjectDetail();
  }
}
