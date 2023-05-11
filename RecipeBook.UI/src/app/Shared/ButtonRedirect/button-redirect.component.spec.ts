import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ButtonRedirectComponent } from './button-redirect.component';

describe('ButtonRedirectComponent', () => {
  let component: ButtonRedirectComponent;
  let fixture: ComponentFixture<ButtonRedirectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ButtonRedirectComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ButtonRedirectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
