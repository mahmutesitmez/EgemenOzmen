import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';





@Injectable()
export class BackendService {

  baseURL: string = "https://localhost:5001";

  httpOptions = {
    header : new HttpHeaders ({
      'Content-Type' : 'application/json',
      'Authorization': 'my-auth-token'
    })
  }

  constructor(private HttpClient: HttpClient) {
  }

  getCategory() {
    return this.HttpClient.get(this.baseURL + "/api" + "/Category")
  }
  putCategory(id: number, category: any) {
    return this.HttpClient.put(this.baseURL + "/api" + "/Category/" + id, category);
  }

  postCategory(category:any){
    return this.HttpClient.post(this.baseURL + "/api" + "/Category", category)
  }
  deleteCategory(id:number){
    return this.HttpClient.delete(this.baseURL + "/api" + "/Category/" + id)
  }
  getById(id: number, category: any){
    return this.HttpClient.get(this.baseURL + "/api" + "/Category/" + id, category)
  }
}



