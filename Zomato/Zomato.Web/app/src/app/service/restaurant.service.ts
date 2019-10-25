import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Restaurant } from '../model/restaurant';
import { Category } from '../model/category';
import { Cuisine } from '../model/cuisine';
import { Observable, of } from 'rxjs';

@Injectable({ providedIn: 'root' })

export class RestaurantService {

  baseUrl: string = "api/restaurant/"

  constructor(private http: HttpClient) { }

  getRestaurant(id: number): Observable<Restaurant> {
    if (id == 0) {
      return of(this.initializeRestaurant());
    }
  }

  getRestaurantDetail(restaurantName: string) {
    return this.http.get(this.baseUrl+'restaurant/' + restaurantName);
  }

  getListRestaurantDetail() {
    return this.http.get(this.baseUrl + 'restaurant');
  }

  getListRestaurant() {
    return this.http.get(this.baseUrl+'list');
  }

  addRestaurant(restaurant: Restaurant) {
    return this.http.post('api/Restaurant/restaurant', restaurant);
  }

  deleteRestaurant(restaurantId: number) {
    return this.http.delete('api/Restaurant/delete/' + restaurantId);
  }

  initializeRestaurant(): Restaurant {
    return {
      RestaurantId: 0,
      RestaurantName: '',
      Location: [],
      CuisineId: [],
      CategoryId: []
    }
  }
}
