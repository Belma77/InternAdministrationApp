import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditselectionComponent } from './editselection.component';

describe('EditselectionComponent', () => {
  let component: EditselectionComponent;
  let fixture: ComponentFixture<EditselectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditselectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditselectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
