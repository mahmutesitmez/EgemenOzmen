import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriesComponent } from './categories/categories.component';
import { CatgoriesEditComponent } from './catgories-edit/catgories-edit.component';
import { HomeComponent } from './home/home.component';


const routes: Routes = [

  { path: '', component: HomeComponent },
  { path: 'categories', component: CategoriesComponent },
  { path: 'categoriesedit/:id', component: CatgoriesEditComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }