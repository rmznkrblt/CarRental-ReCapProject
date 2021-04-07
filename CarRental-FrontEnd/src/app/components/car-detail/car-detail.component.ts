import { Component, OnInit } from '@angular/core';
import { CarDetail } from 'src/app/models/carDetail';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent implements OnInit {

  carDetails:CarDetail[]=[];
  currentCarDetail:CarDetail;
  dataLoaded=false;
  constructor(private carService:CarService) { }

  ngOnInit(): void {
    this.getCarDetails();
  }
  getCarDetails() {
    this.carService.getCarDetails().subscribe(response=>{
      this.carDetails=response.data
      this.dataLoaded=true;
    })
  }
  setCurrentCarDetail(carDetail:CarDetail){
    this.currentCarDetail=carDetail;
  }
  getCurrentCarDetailClass(carDetail:CarDetail){
    if(carDetail==this.currentCarDetail){
      return "list-group-item active"
    }else{
      return "list-group-item"
    }
  }
  getAllCarDetailClass(){
    if(!this.currentCarDetail){
      return "list-group-item active"
    }else{
      return "list-group-item"
    }
  }
}
