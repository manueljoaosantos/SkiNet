//import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
/*import { IPagination } from './shared/models/pagination';
import { IProduct } from './shared/models/product';
*/
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'SkiNet';
  //products: IProduct[];

  //constructor(private http: HttpClient) { }
  constructor() { }

  ngOnInit(): void {
   /* this.http.get('https://localhost:5001/api/Products/get-all-products?pageSize=50').subscribe((response: IPagination) => {
      this.products = response.data;
      console.trace(response);
    }, error => {
      console.log(error);
    })
    */
  }
}