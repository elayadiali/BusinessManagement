


import { Component, EventEmitter, Input, OnInit, Output, ViewChild,Inject } from '@angular/core';
import {MatDialog, MatDialogConfig, MAT_DIALOG_DATA} from '@angular/material/dialog';

import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { Meal } from '../Models/Meal';
import { RandomMealService } from '../Services/random-meal.service';
import{RestaurantsService} from '../Services/restaurants.service';
import { PlatsService } from '../Services/plats.service';
import {MatSidenav, MatSidenavModule} from '@angular/material/sidenav';
import { Restaurant } from '../Models/Restaurant';
import { Plat } from '../Models/Plat';
import { DialogOverviewMealsComponent } from '../dialog-overview-meals/dialog-overview-meals.component';


@Component({
  selector: 'app-restaurants',
  templateUrl: './restaurants.component.html',
  styleUrls: ['./restaurants.component.css']
})



export class RestaurantsComponent implements OnInit {


  
  isExpanded = true;
  showSubmenu: boolean = true;
  isShowing = false;
  showSubSubMenu: boolean = true;

  mouseenter() {
    if (!this.isExpanded) {
      this.isShowing = true;
    }
  }

  mouseleave() {
    if (!this.isExpanded) {
      this.isShowing = false;
    }
  }
  
  meal: Meal;
  restaurant:Restaurant;
  plat:Plat;
  
  isLoading: boolean = true;
  safeUrl: SafeResourceUrl;

  constructor(
    private dialog: MatDialog,
    private mealService: RandomMealService,
    private restautantsService: RestaurantsService,
    private platsService:PlatsService,
    private sanitizer: DomSanitizer
  ) {}
  openDialog() {

    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    dialogConfig.data = this.meals;

    this.dialog.open(DialogOverviewMealsComponent, dialogConfig);
  }

  selectedRestaurant: Restaurant;

  meals: Meal[];
  restaurants:Restaurant[];
  plats:Plat[];
  ngOnInit(): void {
    this.meal = new Meal();
    this.restaurant = new Restaurant();
    this.restaurants = new Array<Restaurant>();
    this.meals = new Array<Meal>();
    this.plats = new Array<Plat>();
    this.plat = new Plat();
    this.getAllRestaurants();
    this.GetMealByName('a');

  }

  getRandomMeal() {
    this.mealService.getRandomMeal().subscribe((meal) => {
      this.createMeal(meal.meals[0]);
    });
  }

  /*private restaurantId: number;
 
  get selectedRestaurantId(): number {
    return this.restaurantId;
  }

  //@Output() restaurantChange = new EventEmitter();
 /* @Input()
  set selectedRestaurantId(val: number) {
    this.restaurantId = val;

    if (this.restaurants) {
      this.selectedRestaurant = this.restaurants.find(d => d.id === this.selectedRestaurantId);
    }
  }*/
  changeSelected(element: Restaurant) {
    this.selectedRestaurant = element;
    
    //this.restaurantChange.emit(this.selectedRestaurant.id);
    this.getPlatByRestaurant(this.selectedRestaurant.id);
  }

  GetMealByCategory(category: string) {
    this.mealService.getMealByCategory(category).subscribe((meal) => {
      let randomNumber = Math.floor(Math.random() * meal.meals.length);
      this.mealService
        .getMealDetails(meal.meals[randomNumber].idMeal)
        .subscribe((mealDetails) => {
          this.createMeal(mealDetails.meals[0]);
        });
    });
  }

  GetMealByName(prefix: string) {
    this.isLoading = true;

    this.mealService.getAllMeals(prefix)
    .subscribe((data: Meal[]) => {
      this.meals = data["meals"];
      //console.log(data);
      this.isLoading = false;
  
    });
  }
  getAllRestaurants()
  {
    this.restautantsService.getAllRestaurants().subscribe((data:Restaurant[])=>{
      this.restaurants = data;
    })
  }
  getPlatByRestaurant(restaurantId:number){
    this.platsService.getPlatsByRestaurant(restaurantId).subscribe((data:Plat[])=>{
      this.plats=data;
    })
  }



  
  createMeal(meal: any) {
    this.meal.idMeal = meal.idMeal;
    this.meal.imgSrc = meal.strMealThumb;
    this.meal.recipe = meal.strInstructions;
    this.meal.title = meal.strMeal;
    this.meal.video = `https://www.youtube.com/embed/${meal.strYoutube.slice(
      -11
    )}`;
    this.safeUrl = this.sanitizer.bypassSecurityTrustResourceUrl(
      this.meal.video
    );
    this.meal.category = meal.strCategory;
    this.meal.area = meal.strArea;
    if (meal.strTags) {
      let tags = meal.strTags.split(',').join(', ');
      this.meal.tags = tags;
    }

    var ingredients = Array<any>();

    for (let i = 1; i <= 20; i++) {
      if (meal[`strIngredient${i}`]) {
        ingredients.push(
          `${meal[`strIngredient${i}`]} - ${meal[`strMeasure${i}`]}`
        );
      }
    }

    this.meal.ingredients = ingredients;
    this.isLoading = false;
    setTimeout(() => {
      const target = document.getElementById('target');
      target.scrollIntoView({ behavior: 'smooth' });
    }, 1);
  }
}
