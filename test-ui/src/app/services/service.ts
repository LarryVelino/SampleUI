import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User} from '../models/user'
import { Study} from '../models/study'

const baseUrl = 'https://localhost:44375/api/Study';

@Injectable({
  providedIn: 'root'
})
export class StudyService {

  constructor(private http: HttpClient) { }

  getAllStudies(): Observable<any> {
    return this.http.get<any>(baseUrl);
  }

  getAllStudiesWithUser(userId: any): Observable<any> {
    return this.http.get<Study[]>(`${baseUrl}?userId=${userId}`);
  }

  getUsersInStudy(studyId: any): Observable<any> {
    return this.http.get<User[]>(`${baseUrl}/${studyId}/users`);
  }

  addUserToStudy(userId: any, studyId: any): Observable<any> {
    return this.http.put(`${baseUrl}/${studyId}/users/${userId}`, '');
  }

  removeUserFromStudy(userId: any, studyId: any): Observable<any> {
    return this.http.delete(`${baseUrl}/${studyId}/users/${userId}`);
  }
}
