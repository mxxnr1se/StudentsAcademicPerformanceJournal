import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { GroupDetail } from '../shared/group/group-detail.model';
import { GroupDetailService } from '../shared/group/group-detail.service';

@Component({
  selector: 'app-group-details',
  templateUrl: './group-details.component.html',
  styles: [
  ]
})
export class GroupDetailsComponent implements OnInit {
  search:string;
  constructor(public service:GroupDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.search ='';
  }

  populateForm(selectedRecord:GroupDetail){
    this.service.formData =  Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if (confirm('Are you sure to delete this record?'))
    {
      this.service.deleteGroupDetails(id)
      .subscribe(
       res=>{
         this.service.refreshList();
         this.service.formData = new GroupDetail();
         this.toastr.error("Deleted successfully", "Group deleted")
       },
       err => {
         console.log(err);
      }
      )
    }
  }
}
