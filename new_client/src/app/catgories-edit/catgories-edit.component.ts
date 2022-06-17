import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { BackendService } from '../backendservice';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-catgories-edit',
  templateUrl: './catgories-edit.component.html',
  styleUrls: ['./catgories-edit.component.css']
})
export class CatgoriesEditComponent implements OnInit {

  public category: any = null;
  constructor(private route: ActivatedRoute,
    private service: BackendService,
    private router: Router) { }

  ngOnInit(): void {
    let sid = this.route.snapshot.params["id"];
    console.log("snapshot", sid);
    this.getId(sid);
  }
  
  getId(id: number) {
    this.service.getById(id).subscribe((value: any) => {
      this.category = value;
      console.log("category okundu", this.category);
    });
  }
  doUpdate() {
    console.log("doSave()", this.category);
    this.service.putCategory(this.category.id, this.category).subscribe(() => {
      this.router.navigate(['/categories']);
    })
  }

}
