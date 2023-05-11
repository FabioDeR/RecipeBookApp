import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GammeEditComponent } from './gamme-edit.component';

describe('GammeEditComponent', () => {
  let component: GammeEditComponent;
  let fixture: ComponentFixture<GammeEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GammeEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GammeEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
