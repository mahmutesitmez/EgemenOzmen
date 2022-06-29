import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from '../backendservice';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public email = "";
  public password = "";
  constructor(private service: BackendService,
    private router:Router) { }

  ngOnInit(): void {
  }

  doLogin() {
    this.service.login(this.email, this.password).subscribe((data: any) => {
      console.log(data);
      if (data.isLogin) {
        this.service.setClientUser(data);
        this.router.navigate(['']);
      }
    })
  }

}
