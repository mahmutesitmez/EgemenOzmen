import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BackendService } from './backend.service';
import { FormsModule } from '@angular/forms';
import { UpdateModule } from './update/update.module';
import { RouterModule, Routes } from '@angular/router';
import { UpdateHomeComponent } from './update/update-home/update-home.component';
import { CommonModule } from '@angular/common';
   


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    UpdateModule,
    RouterModule.forRoot([
      {path: '', component:UpdateHomeComponent },
      
    ]),
  ],
 
  providers: [BackendService],
  bootstrap: [AppComponent]
})
export class AppModule { }
