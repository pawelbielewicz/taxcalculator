import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from './product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url = 'https://localhost:5001/Vat';

  constructor(private http: HttpClient) { }

  getAllProducts(): Observable<string[]> {
    // return this.http.get<[Product]>(this.url + '/ProductDetails');
    return this.http.get<[string]>(this.url);
  }

}
