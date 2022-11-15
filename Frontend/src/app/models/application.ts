import { educationLevels } from "./educationLevelEnum";
import { ApplicationComment } from "./applicationComment.model";

export class Application {
    id?: number;
    firstName: string;
    lastName: string;
    email: string;
    educationLevel: string;
    status: string;
    coverLetter: string;
    cv: string;
    comments: ApplicationComment[];
}