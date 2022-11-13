import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddselectionComponent } from './addselection.component';

describe('AddselectionComponent', () => {
  let component: AddselectionComponent;
  let fixture: ComponentFixture<AddselectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddselectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddselectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
