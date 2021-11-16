import { Component, OnInit } from '@angular/core';
import { Study } from '../models/study';
import { StudyService } from '../services/service';

@Component({
  selector: 'app-study-management',
  templateUrl: './study-management.component.html',
  styleUrls: ['./study-management.component.scss']
})
export class StudyManagementComponent implements OnInit {

  studies: Study[]  = [];
  userId: string = '';
  studyId: string = '';

  resultText: string = '';

  constructor(private studyService: StudyService) { }

  ngOnInit(): void {
    console.log('hey');
    this.getStudies();
  }

  getStudies(){
    this.studyService.getAllStudies().subscribe(response => {

      console.log(response);
      console.log(response.data);
      this.studies = response.data;
    });
  }

  getStudiesWithUser(userId: any){
    console.log(userId);
    this.studyService.getAllStudiesWithUser(userId).subscribe(response => {

      console.log(response);
      console.log(response.data);
      this.studies = response.data;
    });
  }

  getStudyUsers(studyId: any){
    console.log(studyId);
    this.studyService.getUsersInStudy(studyId).subscribe(response => {

      console.log(response);
      console.log(response.data);
      this.studies = response.data;
    });
  }

  addUserToStudy(studyId: any, userId: any){
    this.studyService.addUserToStudy(userId, studyId).subscribe(response => {

      console.log(response);

    });
  }

  removeUserFromStudy(studyId: any, userId: any){
    this.studyService.removeUserFromStudy(userId, studyId).subscribe(response => {

      console.log(response);

    });
  }

}
