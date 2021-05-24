import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/models/car';
import { CarService } from 'src/app/services/car.service';
import { ActivatedRoute } from '@angular/router';
import { CarDetail } from 'src/app/models/carDetail';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {
  cars:Car[]=[];
  carDetails:CarDetail[]=[];
  dataLoaded=false;
  currentComponent=" ";
  constructor(private carService:CarService,private activatedRoute:ActivatedRoute,private toastrService:ToastrService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["brandId"]){
        this.getCarsByBrandId(params["brandId"])
      }
      else if(params["colorId"])
      {
        this.getCarsByColorId(params["colorId"])
      }
      else{
        this.getCars()
      }
    })
  }
  getCars() {
    this.carService.getCars().subscribe(response=>{
      this.cars=response.data
      this.dataLoaded=true
      this.currentComponent=" "
    })
  }
  getCarsByBrandId(brandId:number) {
    this.carService.getCarsByBrandId(brandId).subscribe(response=>{
      this.cars=response.data
      this.dataLoaded=true
      this.currentComponent="brand"
    })
  }
  getCarsByColorId(colorId:number) {
    this.carService.getCarsByColorId(colorId).subscribe(response=>{
      this.cars=response.data
      this.dataLoaded=true
      this.currentComponent="color"
    })
  }
  addToCart(car:Car){
    this.toastrService.success("Sepete eklendi", car.brandId.toString())
  }
}
