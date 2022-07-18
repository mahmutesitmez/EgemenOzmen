import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from '../backendservice';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private service: BackendService,
    private router: Router) { }

  ngOnInit(): void {
    if (this.service.getClientUser() == null) {
      console.log("Home login olmadığı için login page i çağırdı!")
      this.router.navigate(['/login']);
    }
  }

}
