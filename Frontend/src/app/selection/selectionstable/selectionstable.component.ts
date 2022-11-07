import { Component, OnInit } from '@angular/core';
import { Selections } from 'src/app/models/selections';

@Component({
  selector: 'app-selectionstable',
  templateUrl: './selectionstable.component.html',
  styleUrls: ['./selectionstable.component.css']
})
export class SelectionstableComponent implements OnInit {
  selections: Selections[] = [
    {
      id: 1,
      name: 'Internship',
      startDate: '10/6/2022',
      endDate: '10/7/2022',
      description: 'Angular + .Net'
    },
    {
      id: 2,
      name: 'Internship',
      startDate: '17/8/2022',
      endDate: '17/9/2022',
      description: 'React + Node.js'
    },
    {
      id: 3,
      name: 'Jap',
      startDate: '10/6/2022',
      endDate: '10/8/2022',
      description: 'Angular + .Net'
    },
    {
      id: 4,
      name: 'Jap',
      startDate: '22/6/2022',
      endDate: '22/8/2022',
      description: 'QA'
    },
    {
      id: 5,
      name: 'Job',
      startDate: '10/6/2020',
      endDate: '10/7/2022',
      description: 'Frontend Developers'
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
