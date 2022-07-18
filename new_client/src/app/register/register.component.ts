import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from '../backendservice';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public IsRegistered = true;
  public firstname="";
  public lastname ="";
  public email ="";
  public password ="";
  public password2 ="";
 
  constructor(private service: BackendService,
               private router: Router) { 
    
  }

  ngOnInit(): void {
  }

  NewUser(){
      this.service.register(this.firstname,this.lastname,this.email,
        this.password,this.password2)
        .subscribe((data:any) => {  
           console.log(data);
     
          this.IsRegistered = data.isRegistered;
          console.log(this.IsRegistered);
          if (data.isRegistered) {
            this.service.newClientUser(data);
          
           
          }
          else{
            
          }
        })
     
  
   

  
      
    
  }}