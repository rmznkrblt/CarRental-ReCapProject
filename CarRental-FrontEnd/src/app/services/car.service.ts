import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../models/car';
import { CarDetail } from '../models/carDetail';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  apiUrl="https://localhost:44345/api/";
  constructor(private httpClient:HttpClient) { }

  getCars():Observable<ListResponseModel<Car>> {
    let newPath=this.apiUrl + "cars/getall"
    return this.httpClient
    .get<ListResponseModel<Car>>(newPath);
  }
  getCarDetails():Observable<ListResponseModel<CarDetail>> {
    let newPath=this.apiUrl + "cars/getcardetails"
    return this.httpClient
    .get<ListResponseModel<CarDetail>>(newPath);
  }
  getCarsByBrandId(brandId:number):Observable<ListResponseModel<Car>> {
    let newPath=this.apiUrl + "cars/getcarsbybrandid?id="+brandId
    return this.httpClient
    .get<ListResponseModel<Car>>(newPath);
  }
  getCarsByColorId(colorId:number):Observable<ListResponseModel<Car>> {
    let newPath=this.apiUrl + "cars/getcarsbycolorid?id="+colorId
    return this.httpClient
    .get<ListResponseModel<Car>>(newPath);
  }
}
