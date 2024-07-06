import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from './models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'https://localhost:7092/api/Productos'; 

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}/GetProductos`);
  }
  searchProducts(filtro: string): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}/GetProductosFiltro?filtro=${filtro}`);
  }
  filterProductsByCategory(filtro: number): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}/GetCategoriaFiltro?filtro=${filtro}`);
  }
}
