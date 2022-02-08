import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogOverviewMealsComponent } from './dialog-overview-meals.component';

describe('DialogOverviewMealsComponent', () => {
  let component: DialogOverviewMealsComponent;
  let fixture: ComponentFixture<DialogOverviewMealsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogOverviewMealsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogOverviewMealsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
