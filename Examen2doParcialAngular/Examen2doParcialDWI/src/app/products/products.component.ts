import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Product } from '../models/product.model';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: Product[] = [];
  private searchTerms = new Subject<string>();

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.getAllProducts();

    this.searchTerms.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((term: string) => this.apiService.searchProducts(term)),
    ).subscribe(data => {
      this.products = data;
    });
  }

  search(event: Event): void {
    const target = event.target as HTMLInputElement;
    this.searchTerms.next(target.value);
  }

  filterByCategory(filtro: number): void {
    this.apiService.filterProductsByCategory(filtro).subscribe(data => {
      this.products = data;
    });
  }

  getAllProducts(): void {
    this.apiService.getProducts().subscribe(data => {
      this.products = data;
    });
  }
}
