import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBrand } from '../shared/models/brand';
import { IPagination } from '../shared/models/pagination';
import { IType } from '../shared/models/productType';
import { delay, map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/'  

  constructor(private http: HttpClient) { }    
    getAllProducts(brandId?: number, typeId?: number)
    {
      let params = new HttpParams();
      if(brandId)
      {
        params = params.append('brandId', brandId.toString());
      }

      if(typeId)
      {
        params = params.append('typeId', typeId.toString());
      }

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
