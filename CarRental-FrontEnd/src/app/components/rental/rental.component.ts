import { Component, OnInit } from '@angular/core';
import { Rental } from 'src/app/models/rental';
import { RentalService } from 'src/app/services/rental.service';
import { RentalDetail } from 'src/app/models/rentalDetail';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-rental',
  templateUrl: './rental.component.html',
  styleUrls: ['./rental.component.css']
})
export class RentalComponent implements OnInit {
  rentals:Rental[]=[];
  //rentalDetails:RentalDetail[]=[];
  dataLoaded=false;
  constructor(private rentalService:RentalService,private activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["carId"]){
        this.getRentalsById(params["carId"])
      }else{
        this.getRentals()
      }
    })
  }
  getRentals() {
    this.rentalService.getRentals().subscribe(response=>{
      this.rentals=response.data
      this.dataLoaded=true;
    })
  }
  getRentalsById(carId:number) {
    this.rentalService.getRentalsById(carId).subscribe(response=>{
      this.rentals=response.data
      this.dataLoaded=true;
    })
  }
 

}
