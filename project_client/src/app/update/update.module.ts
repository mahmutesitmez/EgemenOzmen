import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UpdateHomeComponent } from './update-home/update-home.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    UpdateHomeComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports:[UpdateHomeComponent]
})
export class UpdateModule { }
