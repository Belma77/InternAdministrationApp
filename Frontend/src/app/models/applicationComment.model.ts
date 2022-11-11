import { User } from "./user";

export class ApplicationComment {
    Id: number;
    ApplicationId: number;
    Description: string;
    User?: User;
    id: number;
    comments: string;
}