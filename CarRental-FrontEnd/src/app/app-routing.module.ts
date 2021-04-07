import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandComponent } from './components/brand/brand.component';
import { CarComponent } from './components/car/car.component';
import { ColorComponent } from './components/color/color.component';
import { CustomerComponent } from './components/customer/customer.component';
import { ImageComponent } from './components/image/image.component';
import { RentalComponent } from './components/rental/rental.component';

const routes: Routes = [
{ path:"",pathMatch:"full", component:RentalComponent},
{ path:"rental", component:RentalComponent},
{ path:"rental/cardetail/:carId", component:RentalComponent},
{ path:"color", component:ColorComponent},
{ path:"brand", component:BrandComponent},
{ path:"image", component:ImageComponent},
{ path:"car", component:CarComponent},
{ path:"customer", component:CustomerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
