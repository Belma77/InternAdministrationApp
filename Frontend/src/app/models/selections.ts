import { Applicants } from "./applicants";

export class Selections {
    id: number;
    name = "";
    startDate: Date;
    endDate: Date;
    description = "";
    applications: Applicants[];
}
