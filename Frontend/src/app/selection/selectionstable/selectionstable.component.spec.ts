import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectionstableComponent } from './selectionstable.component';

describe('SelectionstableComponent', () => {
  let component: SelectionstableComponent;
  let fixture: ComponentFixture<SelectionstableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectionstableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SelectionstableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
