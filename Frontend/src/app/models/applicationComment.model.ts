import { User } from "./user";

export class ApplicationComment {
    Id: number;
    ApplicationId: number;
    Comments: string;
    User?: User;
    id: number;
    Comment: string;
}