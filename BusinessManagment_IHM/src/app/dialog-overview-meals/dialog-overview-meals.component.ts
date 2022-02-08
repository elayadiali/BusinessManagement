import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA,MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Meal } from '../Models/Meal';
import { Plat } from '../Models/Plat';
//import { DialogData } from '../restaurants/restaurants.component';



@Component({
  selector: 'app-dialog-overview-meals',
  templateUrl: './dialog-overview-meals.component.html',
  styleUrls: ['./dialog-overview-meals.component.css']
})
export class DialogOverviewMealsComponent implements OnInit { 
  
  Meals:[Plat];
  constructor( dialogRef: MatDialogRef<DialogOverviewMealsComponent>,
    @Inject(MAT_DIALOG_DATA) data ) {
    this.Meals = data;
    //this.Plats.push(data[Plat]) ;  

  }

  
  ngOnInit(): void {
    
  }
}

