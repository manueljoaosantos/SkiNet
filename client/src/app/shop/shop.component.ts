import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  products: IProduct[];
  productBrands: IBrand[];
  productTypes: IType[];
  productBrandId: number;
  productTypeId: number;
  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getAllProducts();
    this.getAllProductBrands();
    this.getAllProductTypes();
  }

  getAllProducts()
  {
    this.shopService.getAllProducts(this.productBrandId, this.productTypeId).subscribe(response => {
      this.products = response.data;
      console.trace(response);
    }, error => {
      console.log(error);
    })
  }

  getAllProductBrands()
  {
    this.shopService.getAllProductBrands().subscribe(response => {
      //this.productBrands = response;
      this.productBrands = [{id: 0, name: 'All'}, ...response];
      console.trace(response);
    }, error => {
      console.log(error);
    })
  }

  getAllProductTypes()
  {
    this.shopService.getAllProductTypes().subscribe(response => {
      //this.productTypes = response;
      this.productTypes = [{id: 0, name: 'All'}, ...response];

      console.trace(response);
    }, error => {
      console.log(error);
    })
  }

  onBrandSeleted(brandId: number)
  {
    this.productBrandId = brandId;
    this.getAllProducts();
  }

  onTypeSeleted(typeId: number)
  {
    this.productTypeId = typeId;
    this.getAllProducts();
  }
}
