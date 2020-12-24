import { StudentDetail } from "../student/student-detail.model";

export class RatingDetail {
    id: number=0;
    subjectId: any = null;
    subjectTitle: string='';
    studentId: any = null;
    studentFirstName: string='';
    studentLastName: string='';
    score: number;
}
