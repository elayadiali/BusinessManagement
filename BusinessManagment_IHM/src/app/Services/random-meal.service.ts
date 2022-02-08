import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Meal } from '../Models/Meal';

@Injectable({
  providedIn: 'root'
})
export class RandomMealService {

  mealUrl: string = 'https://www.themealdb.com/api/json/v1/1/random.php';

  constructor(private http: HttpClient) {}

  getRandomMeal(): Observable<any> {
    return this.http.get<any>(this.mealUrl);
  }
  //get a random meal by category
  getMealByCategory(category: string): Observable<any> {
    if (category === 'Meat') {
      const meatList = ['Beef', 'Chicken', 'Lamb', 'Pork', 'Goat'];
      let randomNumber = Math.floor(Math.random() * meatList.length);
      category = meatList[randomNumber];
      return this.http.get<any>(
        `https://www.themealdb.com/api/json/v1/1/filter.php?c=${category}`
      );
    } else {
      return this.http.get<any>(
        `https://www.themealdb.com/api/json/v1/1/filter.php?c=${category}`
      );
    }
  }
  //get details of a meal (used for meal by category)
  getMealDetails(id: number): Observable<any> {
    return this.http.get<any>(
      `https://www.themealdb.com/api/json/v1/1/lookup.php?i=${id}`
    );
  }
  getMealList(prefix:string): Observable<any>{
    return this.http.get<any>(      `https://www.themealdb.com/api/json/v1/1/search.php?f=${prefix}`      )

  }


   getAllMeals(prefix:string) {

    return this.http.get<Meal[]>(`https://www.themealdb.com/api/json/v1/1/search.php?f=${prefix}`);
  };
}
