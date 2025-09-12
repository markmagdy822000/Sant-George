import { authInterceptor } from './../../../Interceptor/auth-interceptor';
import { CommonModule } from '@angular/common';
import { ExamServices } from '../../../Services/exam-services';
import { AuthServices } from './../../../Services/auth-services';
import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { Subscribable } from 'rxjs';
import { IExam } from '../../../Models/iexam';

@Component({
  selector: 'app-exams',
  imports: [CommonModule],
  templateUrl: './exams.html',
  styleUrl: './exams.css'
})
export class Exams implements  OnDestroy, OnInit{
  constructor(private examServices : ExamServices, private authServices:AuthServices, private cdr : ChangeDetectorRef) {}  
  ngOnInit(): void {
    this.getAllExams();
    this.cdr.detectChanges();
  }
  sub!:any;
  sub2!:any;
  ngOnDestroy(): void {
  //  this.sub.unsubscribe();
  //  this.sub2.unsubscribe();
  }

  getAllExams(){
    if(this.authServices.isTeacher())
      this.getAllTeacherExams();
    else 
      this.getAllTStudentExams();
  }

  exams!:any;
  getAllTeacherExams(){
    this.examServices.getAllTeacherExams().subscribe({
      next:res=>{
        this.exams = res.exams;
        // console.log('those are exams: ',this.exams as IExam[])
        console.log('those are exams: ',this.exams as IExam)
        this.exams.forEach((exam: any) => {
          console.log(exam.startDate)
        });
        // console.log
      }
    });
  }

  getAllTStudentExams(){
    this.examServices.getAllTeacherExams().subscribe({
    next:res=>this.exams= res
    });
  }

  decodeJwt(){
    let s = this.authServices.decodeJwt();
    return s;
  }
}
