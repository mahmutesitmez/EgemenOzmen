import { Component, OnInit } from '@angular/core';
import { BackendService } from '../backendservice';
import { NgModule } from '@angular/core';
import { BackButtonDisableModule } from 'angular-disable-browser-back-button';

@Component({
  selector: 'app-menu-main',
  templateUrl: './menu-main.component.html',
  styleUrls: ['./menu-main.component.css']
})
export class MenuMainComponent implements OnInit {

  public username=""
  constructor(private service: BackendService) { }

  ngOnInit(): void {
    console.log(this.username)
    let user = this.service.getClientUser();
    if (user != null) {
      this.username = user.Name;
    }
    else{
      console.log("user yok")
    }
  }

}
