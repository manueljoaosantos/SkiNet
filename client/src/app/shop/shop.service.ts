import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBrand } from '../shared/models/brand';
import { IPagination } from '../shared/models/pagination';
import { IType } from '../shared/models/productType';
import { delay, map } from 'rxjs/operators'
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/'  

  constructor(private http: HttpClient) { }    
    //getAllProducts(brandId?: number, typeId?: number, sort?: 
    getAllProducts(shopParams: ShopParams)
    {
      let params = new HttpParams();
      if(shopParams.brandId !== 0)
      {
        params = params.append('brandId', shopParams.brandId.toString());
      }

      if(shopParams.typeId !== 0)
      {
        params = params.append('typeId', shopParams.typeId.toString());
      }

      params = params.append('sort', shopParams.sort);

      params = params.append('pageIndex', shopParams.pageNumber.toString());

      params = params.append('pageIndex', shopParams.pageSize.toString());
      



      return this.http.get<IPagination>(this.baseUrl + 'products/get-all-products', {observe: 'response', params})
        .pipe(
          delay(1000),
          map(response => {
            return response.body;
          })
        );
    }

    getAllProductBrands()
    {
      return this.http.get<IBrand[]>(this.baseUrl + 'products/get-all-productBrands');
    }

    getAllProductTypes()
    {
      return this.http.get<IType[]>(this.baseUrl + 'products/get-all-productTypes');
    }
}
