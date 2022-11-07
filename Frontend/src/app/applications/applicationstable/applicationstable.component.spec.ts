import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationstableComponent } from './applicationstable.component';

describe('ApplicationstableComponent', () => {
  let component: ApplicationstableComponent;
  let fixture: ComponentFixture<ApplicationstableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationstableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicationstableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
