import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Cuisine } from '../model/cuisine';

@Injectable({ providedIn: 'root' })

export class CuisineService{

  constructor(private http: HttpClient){}

  getCuisineList() {
    return this.http.get('api/cuisine');
  }

  getCuisineNameListById(cuisineId: number[]) {
    return this.http.post('api/cuisine', cuisineId);
  }

  initializeCuisine(): Cuisine {
    return {
      CuisineId: 0,
      CuisineName: ''
    }
  }
}
