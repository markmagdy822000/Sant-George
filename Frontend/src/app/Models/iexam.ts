import { IQuestion } from "./iquestion";

export interface IExam {
    id? : number;
    title :string;
    startDate :Date; //
    duration :number; // 
    description? :string;
    teacherId :string;
    questions :IQuestion[];
}
