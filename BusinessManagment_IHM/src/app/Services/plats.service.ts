import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PlatsService {

  PlatsUrl: string = 'https://localhost:7115/Plats/';
  constructor(private http: HttpClient) { }

  getPlatsByRestaurant(restaurantId: number): Observable<any>  {
    return this.http.get<any>(this.PlatsUrl+`${restaurantId}`);
  }
}
