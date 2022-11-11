import { ApplicationComment } from "./applicationComment.model";

export class Applicants {
    id: number;
    firstName = "";
    lastName = "";
    email = "";
    educationLevel = "";
    status = "";
    coverLetter = "";
    cv = "";
    comments: Comment[] = [];
}
