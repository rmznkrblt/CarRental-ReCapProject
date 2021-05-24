import { Component, OnInit } from '@angular/core';
import { CarDetail } from 'src/app/models/carDetail';

@Component({
  selector: 'app-navi',
  templateUrl: './navi.component.html',
  styleUrls: ['./navi.component.css']
})
export class NaviComponent implements OnInit {

  carDetail:CarDetail[]=[];
  filterText="";
  constructor() { }

  ngOnInit(): void {
  }

}
