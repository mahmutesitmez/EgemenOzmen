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
  public Error = "email ya da şifre hatalı";
  public IsLogin =true;
  
  constructor(private service: BackendService,
    private router:Router) { }

  ngOnInit(): void {
  }

  doLogin() {
    this.service.login(this.email, this.password).subscribe((data: any) => {
      console.log(data);
     
      this.IsLogin = data.isLogin;
      console.log(this.IsLogin);
      if (data.isLogin) {
        this.service.setClientUser(data);
        this.router.navigate(['']);
       
      }
      else{
        this.Error
      }
    })
  }
  goRegister(){
    this.router.navigate(['/register']);
  }

}
