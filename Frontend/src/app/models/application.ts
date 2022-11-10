import { educationLevels } from "../services/educationLevelEnum";

export class Application {
    id?: number;
    firstName: string;
    lastName: string;
    email: string;
    educationLevel: string;
    status: string;
    coverLetter: string;
    cv: string;
}