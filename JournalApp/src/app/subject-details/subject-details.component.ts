import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SubjectDetail } from '../shared/subject/subject-detail.model';
import { SubjectDetailService } from '../shared/subject/subject-detail.service';

@Component({
  selector: 'app-subject-details',
  templateUrl: './subject-details.component.html',
  styles: [
  ]
})

export class SubjectDetailsComponent implements OnInit {
  search:string;
  constructor(public service:SubjectDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.search ='';
  }

  populateForm(selectedRecord:SubjectDetail){
    this.service.formData =  Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if (confirm('Are you sure to delete this record?'))
    {
      this.service.deleteSubjectDetails(id)
      .subscribe(
       res=>{
         this.service.refreshList();
         this.service.formData = new SubjectDetail();
         this.toastr.error("Deleted successfully", "Subject deleted")
       },
       err => {console.log(err)}
      )
    }
  }
}
