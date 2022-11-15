import { Applicants } from "./applicants";
import { SelectionComment } from "./selectionComment";

export class Selections {
    id: number;
    name = "";
    startDate: Date;
    endDate: Date;
    dateCreated: Date;
    dateEdited: Date;
    description = "";
    applications: Applicants[];
    comments: SelectionComment[];
}
