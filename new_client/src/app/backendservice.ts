import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';


export class UserNG {
  constructor(public Name: string,
    public Email: string,
    public LoginDate: any) {

  }

}


@Injectable()
export class BackendService {

  baseURL: string = "https://localhost:5001";

  httpOptions = {
    header: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'my-auth-token'
    })
  }
  private USER_KEY = "USER";

  constructor(private HttpClient: HttpClient) {
  }

  getCategory() {
    return this.HttpClient.get(this.baseURL + "/api" + "/Category")
  }
  putCategory(id: number, category: any) {
    return this.HttpClient.put(this.baseURL + "/api" + "/Category/" + id, category);
  }

  postCategory(category: any) {
    return this.HttpClient.post(this.baseURL + "/api" + "/Category", category)
  }
  deleteCategory(id: number) {
    return this.HttpClient.delete(this.baseURL + "/api" + "/Category/" + id)
  }
  getById(id: number) {
    return this.HttpClient.get(this.baseURL + "/api" + "/Category/" + id)
  }
  login(email: string, password: string) {
    let model = {
      Email: email,
      Password: password
    };
    console.log("model", model);
    return this.HttpClient.post(this.baseURL + "/api" + "/User/Login", model);
  }
  register(firstname:string, lastname:string , email: string, password: string, password2: string, ){
    let register = {
      Firstname: firstname,
      Lastname: lastname,
      Email: email,
      Password: password,
      Password2 :password2,
      
    };
    console.log("register",register)
    return this.HttpClient.post(this.baseURL + "/api" + "/User/Register", register)
   
  }

  newClientUser(data: any) { //web service'te [frombody] olmadan nasıl gönderilir???
    let userNG: UserNG = new UserNG(data.name,
      data.email,
      data.isRegistered);
      console.log(userNG);
    sessionStorage.setItem(this.USER_KEY, JSON.stringify(userNG));
  }
  setClientUser(data: any) {
    let userNG: UserNG = new UserNG(data.name,
      data.email,
      data.loginDate);
    sessionStorage.setItem(this.USER_KEY, JSON.stringify(userNG));
  }

  getClientUser() {
    let userng: any = sessionStorage.getItem(this.USER_KEY);
    if (userng != null) {

      return JSON.parse(userng);
    }
    return null;
  }
}

