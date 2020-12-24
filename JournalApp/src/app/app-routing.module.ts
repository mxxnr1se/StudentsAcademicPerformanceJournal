import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'
import { RatingDetailsComponent } from './rating-details/rating-details.component';
import { StudentDetailsComponent } from './student-details/student-details.component';
import { SubjectDetailsComponent } from './subject-details/subject-details.component';
import { GroupDetailsComponent } from './group-details/group-details.component';

const routes: Routes = [
    { path:'ratings', component: RatingDetailsComponent},
    { path:'students', component: StudentDetailsComponent},
    { path:'subjects', component: SubjectDetailsComponent},
    { path:'groups', component: GroupDetailsComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
export const routingComponents = [RatingDetailsComponent, StudentDetailsComponent, SubjectDetailsComponent, GroupDetailsComponent]
