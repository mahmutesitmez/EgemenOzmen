import { Component, OnInit } from '@angular/core';

import { BackendService } from './backendservice';




@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'new_project';
  public category: any = null;
  public newCategory: any = {
    title: "",
    description: "",
    password: "",
    rePassword: ""
  };

  constructor(public service: BackendService) {

  }

  ngOnInit(): void {

  }
}



