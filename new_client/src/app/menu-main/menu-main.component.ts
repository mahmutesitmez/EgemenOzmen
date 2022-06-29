import { Component, OnInit } from '@angular/core';
import { BackendService } from '../backendservice';

@Component({
  selector: 'app-menu-main',
  templateUrl: './menu-main.component.html',
  styleUrls: ['./menu-main.component.css']
})
export class MenuMainComponent implements OnInit {

  public username=""
  constructor(private service: BackendService) { }

  ngOnInit(): void {
    let user = this.service.getClientUser();
    if (user != null) {
      this.username = user.Name;
    }
  }

}
