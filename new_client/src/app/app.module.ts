import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BackendService } from './backendservice';
import { HomeComponent } from './home/home.component';
import { CategoriesComponent } from './categories/categories.component';
import { CatgoriesEditComponent } from './catgories-edit/catgories-edit.component';
import { RouterModule } from '@angular/router';
import { MenuMainComponent } from './menu-main/menu-main.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CategoriesComponent,
    CatgoriesEditComponent,
    MenuMainComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    
  ],
  providers: [BackendService],
  bootstrap: [AppComponent]
})
export class AppModule { }
