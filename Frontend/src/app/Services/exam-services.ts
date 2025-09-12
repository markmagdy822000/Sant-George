import { Injectable } from '@angular/core';
import { IExam } from '../Models/iexam';
import { HttpUrlEncodingCodec } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExamServices {
constructor(private http:HttpClient) {}
baseUrl = 'https://localhost:7169/api/Exam';
  
public getAllTeacherExams():Observable<{message:string,exams:IExam[]}>{
    return this.http.get<{message:string, exams:IExam[]}>(`${this.baseUrl}/TeacherExams`);
  }

  public getAllTStudentExams():Observable<{message:string,exams:IExam[]}>{
    return this.http.get<{message:string, exams:IExam[]}>(`${this.baseUrl}/StudentExams`);
  }
}
