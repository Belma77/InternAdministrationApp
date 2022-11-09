import { Applicants } from "./applicants";

export class ApplicantsParams {
    educationLevel: string;
    status: string;
    PageNumber = 1;
    PageSize = 10;

    constructor(applicants: Applicants) {
        this.educationLevel = applicants.educationLevel;
        switch (this.educationLevel) {
            case 'Highschool': {
                applicants.educationLevel == 'Highschool';
                break;
            }
            case 'Bachelor': {
                applicants.educationLevel == 'Bachelor';
                break;
            }
            case 'Master': {
                applicants.educationLevel == 'Master';
                break;
            }
            case 'PhD': {
                applicants.educationLevel == 'PhD';
                break;
            }
        }
    }
}