import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Rental } from '../models/rental';

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  apiUrl="https://localhost:44345/api/";
  constructor(private httpClient:HttpClient) { }

  getRentals():Observable<ListResponseModel<Rental>> {
    let newPath=this.apiUrl + "rentals/getall"
    return this.httpClient
    .get<ListResponseModel<Rental>>(newPath);
  }
  getRentalsById(carId:number):Observable<ListResponseModel<Rental>> {
    let newPath=this.apiUrl + "rentals/getrentalsbyid?id="+carId
    return this.httpClient
    .get<ListResponseModel<Rental>>(newPath);
  }
}
