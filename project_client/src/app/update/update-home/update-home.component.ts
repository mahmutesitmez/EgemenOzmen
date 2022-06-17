import { Component, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import * as $ from "jquery";

@Component({
  selector: 'app-update-home',
  templateUrl: './update-home.component.html',
  styleUrls: ['./update-home.component.css']
})

export class UpdateHomeComponent implements OnInit {
  
  
  constructor(public app : AppComponent) { }

  ngOnInit(): void {
  }

 updateClick(){
  $(".new").hide();
  $(".landing_page").show();
   this.app.putClick();
 }

}
