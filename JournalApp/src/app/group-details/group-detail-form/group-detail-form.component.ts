import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { GroupDetail } from 'src/app/shared/group/group-detail.model';
import { GroupDetailService } from 'src/app/shared/group/group-detail.service';

@Component({
  selector: 'app-group-detail-form',
  templateUrl: './group-detail-form.component.html',
  styles: [
  ]
})
export class GroupDetailFormComponent implements OnInit {

  constructor(public service:GroupDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.id == 0)
      this.inserRecord(form);
    else
      this.updateRecord(form);
  }

  inserRecord(form: NgForm){
    this.service.postGroupDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted succesfully', "Group added")
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putGroupDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated succesfully', "Group updated")
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new GroupDetail();
  }
}
