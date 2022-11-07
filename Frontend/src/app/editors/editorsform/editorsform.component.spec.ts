import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditorsformComponent } from './editorsform.component';

describe('EditorsformComponent', () => {
  let component: EditorsformComponent;
  let fixture: ComponentFixture<EditorsformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditorsformComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditorsformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
