import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IngredientDetailComponent } from './ingredient-detail.component';

describe('IngredientDetailComponent', () => {
  let component: IngredientDetailComponent;
  let fixture: ComponentFixture<IngredientDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [IngredientDetailComponent]
    });
    fixture = TestBed.createComponent(IngredientDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
