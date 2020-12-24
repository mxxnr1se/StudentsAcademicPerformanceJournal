import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { SortDirective } from './diretive/sort.directive';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { AppRoutingModule, routingComponents } from './app-routing.module';
import { RatingDetailFormComponent } from './rating-details/rating-detail-form/rating-detail-form.component';
import { StudentDetailFormComponent } from './student-details/student-detail-form/student-detail-form.component';
import { SubjectDetailFormComponent } from './subject-details/subject-detail-form/subject-detail-form.component';
import { GroupDetailFormComponent } from './group-details/group-detail-form/group-detail-form.component';

@NgModule({
  declarations: [
    AppComponent,
    RatingDetailFormComponent,
    StudentDetailFormComponent,
    SubjectDetailFormComponent,
    GroupDetailFormComponent,
    SortDirective,
    routingComponents
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    Ng2SearchPipeModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
