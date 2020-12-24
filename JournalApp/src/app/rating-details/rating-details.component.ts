import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RatingDetail } from '../shared/rating/rating-detail.model';
import { RatingDetailService } from '../shared/rating/rating-detail.service';

@Component({
  selector: 'app-rating-details',
  templateUrl: './rating-details.component.html',
  styles: [
  ]
})
export class RatingDetailsComponent implements OnInit {
  search:string;
  constructor(public service:RatingDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.search ='';
  }

  populateForm(selectedRecord:RatingDetail){
    this.service.formData =  Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if (confirm('Are you sure to delete this record?'))
    {
      this.service.deleteRatingDetails(id)
      .subscribe(
       res=>{
         this.service.refreshList();
         this.service.formData = new RatingDetail();
         this.toastr.error("Deleted successfully", "Rating deleted;")
       },
       err => {console.log(err)
      }
      )
    }
  }
}
