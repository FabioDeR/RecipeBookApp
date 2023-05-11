import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GammeListComponent } from './gamme-list.component';

describe('GammeListComponent', () => {
  let component: GammeListComponent;
  let fixture: ComponentFixture<GammeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GammeListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GammeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
