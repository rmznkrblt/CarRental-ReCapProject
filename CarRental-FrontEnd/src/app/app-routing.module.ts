import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarDetailComponent } from './components/car-detail/car-detail.component';
import { CarComponent } from './components/car/car.component';
import { RentalComponent } from './components/rental/rental.component';

const routes: Routes = [
{ path:"",pathMatch:"full", component:CarDetailComponent},
{ path:"rental", component:RentalComponent},
{ path:"rental/cardetail/:carId", component:RentalComponent},
{ path:"car/color/:colorId", component:CarComponent},
{ path:"car/color/getall", component:CarComponent},
{ path:"car/brand/:brandId", component:CarComponent},
{ path:"cars/getcarsbyid/:carId", component:CarComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
