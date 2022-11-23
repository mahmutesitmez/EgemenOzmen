import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BackendService } from '../backendservice';

@Component({
  selector: 'app-settings-user',
  templateUrl: './settings-user.component.html',
  styleUrls: ['./settings-user.component.css']
})
export class SettingsUserComponent implements OnInit {
  public user: any = "";
 
  constructor(private service: BackendService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    let user = this.service.getClientUser();
    let sid = this.route.snapshot.params["id"];
    console.log(user)
   
    console.log("snapshot", sid);
    this.readUser(sid);
  }
  readUser(id:number){
    this.service.getUser(id).subscribe((value: any) => {
      this.user = value;
      console.log("user okundu", this.user);
  }
    )
  }
}