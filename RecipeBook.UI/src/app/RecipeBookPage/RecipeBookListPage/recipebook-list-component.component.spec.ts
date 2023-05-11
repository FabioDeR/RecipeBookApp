import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipebookListComponentComponent } from './recipebook-list-component.component';

describe('RecipebookListComponentComponent', () => {
  let component: RecipebookListComponentComponent;
  let fixture: ComponentFixture<RecipebookListComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecipebookListComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RecipebookListComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
