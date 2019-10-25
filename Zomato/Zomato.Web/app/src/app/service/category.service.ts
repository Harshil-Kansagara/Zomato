import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '../model/category';

@Injectable({ providedIn:'root' })
export class CategoryService {

  constructor(private http: HttpClient) { }

  getCategoryList() {
    return this.http.get('api/Restaurant/category');
  }

  initializeCategory(): Category {
    return {
      CategoryId: 0,
      CategoryName: ''
    }
  }
}
