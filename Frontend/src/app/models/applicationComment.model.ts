import { User } from "./user";

export class ApplicationComment {
    Id: number;
    ApplicationId: number;
    Comments: string;//Description
    User?: User;
    id: number;
    comments: string;
}