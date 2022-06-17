import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppComponent } from '../app.component';
import { BackendService } from '../backendservice';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  public categories: Array<any> = [];
  public loading = false;

  constructor(private service: BackendService,
    private router: Router) {
  }

  ngOnInit(): void {
    this.readCategories();
  }
  readCategories() {
    this.loading = true;
    this.service.getCategory().subscribe((data: any) => {
      this.categories = data;
      this.loading = false;
      console.log(this.categories);
    })
  }
  goUpdate(id: number) {
    this.router.navigate(['categoriesedit/' + id]);
    console.log("Update!" + id);

  }

}
