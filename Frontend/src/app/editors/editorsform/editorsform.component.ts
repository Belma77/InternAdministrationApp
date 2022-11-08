import { Component, OnInit } from '@angular/core';
import { Editors } from 'src/app/models/editors';

declare var window: any;

@Component({
  selector: 'app-editorsform',
  templateUrl: './editorsform.component.html',
  styleUrls: ['./editorsform.component.css']
})
export class EditorsformComponent implements OnInit {
  editors: Editors[] = [
    {
      id: 1,
      first: "Tarik",
      last: "Lilic",
      username: "tariklilic",
      email: "tl@test.com",
      password: "tarik123"
    },
    {
      id: 2,
      first: "Belma",
      last: "Aliman",
      username: "belmaaliman",
      email: "ba@test.com",
      password: "belma123"
    },
    {
      id: 3,
      first: "Sandi",
      last: "Stokanovic",
      username: "sandistokanovic",
      email: "ss@test.com",
      password: "sandi123"
    },
    {
      id: 4,
      first: "Emina",
      last: "Sirbubalo",
      username: "eminasirbubalo",
      email: "es@test.com",
      password: "emina123"
    },
    {
      id: 5,
      first: "Belma",
      last: "Hadzic",
      username: "belmahadzic",
      email: "bh@test.com",
      password: "belma123"
    },
    {
      id: 6,
      first: "Nejla",
      last: "Sabotic",
      username: "nejlasabotic",
      email: "ns@test.com",
      password: "nejla123"
    },
    {
      id: 7,
      first: "Mahir",
      last: "Prcanovic",
      username: "mahirprcanovic",
      email: "mp@test.com",
      password: "mahir123"
    },
    {
      id: 8,
      first: "Adna",
      last: "Salcin",
      username: "adnasalcin",
      email: "as@test.com",
      password: "adna123"
    },
    {
      id: 9,
      first: "Harun",
      last: "Cavcic",
      username: "haruncavcic",
      email: "hc@test.com",
      password: "harun123"
    },
    {
      id: 10,
      first: "Nejra",
      last: "Karavdic",
      username: "nejrakaravdic",
      email: "nk@test.com",
      password: "nejra123"
    }
  ]

  formModal: any;


  constructor() { }

  ngOnInit(): void {
    this.formModal = new window.bootstrap.Modal(
      document.getElementById("exampleModal")
    );
  }

  openModal() {
    this.formModal.show();

  }

  addEditor() {
    this.formModal.hide();
  }

}
