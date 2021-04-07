import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/models/category';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  currentCategory:Category;
  brand={categoryId:1,categoryName:"Brand"};
  carImage={categoryId:2,categoryName:"Car Image"};
  car={categoryId:3,categoryName:"Car"};
  color={categoryId:4,categoryName:"Color"};
  customer={categoryId:5,categoryName:"Customer"};
  rental={categoryId:6,categoryName:"Rental"};
  categories=[this.brand,this.carImage,this.car,this.color,this.customer,this.rental]

  constructor() { }

  ngOnInit(): void {
  }

  setCurrentCategory(category:any){
    this.currentCategory=category;
  }
  getCurrentCategoryClass(category:any){
    if(category==this.currentCategory){
      return "list-group-item active"
    }else{
      return "list-group-item"
    }
  }

}
