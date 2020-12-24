import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { RatingDetail } from 'src/app/shared/rating/rating-detail.model';
import { RatingDetailService } from 'src/app/shared/rating/rating-detail.service';

@Component({
  selector: 'app-rating-detail-form',
  templateUrl: './rating-detail-form.component.html',
  styles: [
  ]
})
export class RatingDetailFormComponent implements OnInit {

  constructor(public service:RatingDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.id == 0)
      this.inserRecord(form);
    else
      this.updateRecord(form);
  }

  inserRecord(form: NgForm){
    this.service.postRatingDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted succesfully', "Rating added")
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putRatingDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated succesfully', "Rating updated")
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new RatingDetail();
  }
}
