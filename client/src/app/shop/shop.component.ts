import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';
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
  shopParams = new ShopParams();
  totalCount: number = 0;

  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to Hight', value: 'priceAsc' },
    { name: 'Price: Hight to Low', value: 'priceDesc' }
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getAllProducts();
    this.getAllProductBrands();
    this.getAllProductTypes();
  }

  getAllProducts()
  {
    /*this.shopService.getAllProducts(this.productBrandIdSelected, this.productTypeIdSelected, this.sortSelected).subscribe(response => {*/
      this.shopService.getAllProducts(this.shopParams).subscribe(response => {      
      this.products = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount  = response.count;

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
    this.shopParams.brandId = brandId;
    this.getAllProducts();
  }

  onTypeSeleted(typeId: number)
  {
    this.shopParams.typeId = typeId;
    this.getAllProducts();
  }

  onSortSelected(sort: string)
  {
    this.shopParams.sort = sort;
    this.getAllProducts();
  }

  onPageChanged(event: any)
  {
    this.shopParams.pageNumber = event.page;
    this.getAllProducts();
  }
}
