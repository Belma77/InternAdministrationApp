import { Component, OnInit } from '@angular/core';
import { Applicants } from 'src/app/models/applicants';

@Component({
  selector: 'app-applicationstable',
  templateUrl: './applicationstable.component.html',
  styleUrls: ['./applicationstable.component.css']
})
export class ApplicationstableComponent implements OnInit {
  applicants: Applicants[] = [
    {
      id: 1,
      first: "Tarik",
      last: "Lilic",
      email: "tl@test.com",
      education: "phd",
      status: "applicant"
    },
    {
      id: 2,
      first: "Belma",
      last: "Aliman",
      email: "ba@test.com",
      education: "phd",
      status: "applicant"
    },
    {
      id: 3,
      first: "Sandi",
      last: "Stokanovic",
      email: "ss@test.com",
      education: "phd",
      status: "applicant"
    },
    {
      id: 4,
      first: "Emina",
      last: "Sirbubalo",
      email: "es@test.com",
      education: "phd",
      status: "applicant"
    },
    {
      id: 5,
      first: "Belma",
      last: "Hadzic",
      email: "bh@test.com",
      education: "phd",
      status: "applicant"
    },
    {
      id: 6,
      first: "Nejla",
      last: "Sabotic",
      email: "ns@test.com",
      education: "phd",
      status: "applicant"
    },
    {
      id: 7,
      first: "Mahir",
      last: "Prcanovic",
      email: "mp@test.com",
      education: "phd",
      status: "applicant"
    },
    {
      id: 8,
      first: "Adna",
      last: "Salcin",
      email: "as@test.com",
      education: "phd",
      status: "applicant"
    },
    {
      id: 9,
      first: "Harun",
      last: "Cavcic",
      email: "hc@test.com",
      education: "phd",
      status: "applicant"
    },
    {
      id: 10,
      first: "Nejra",
      last: "Karavdic",
      email: "nk@test.com",
      education: "phd",
      status: "applicant"
    },
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
