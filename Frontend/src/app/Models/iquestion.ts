export interface IQuestion {
    id? : number;
    title :string;
    degree :number;
    examId?:number;
    answers :IAnswer[];
    questionType : string;
}

export interface IAnswer {
    id? : number;
    title :string;
}
