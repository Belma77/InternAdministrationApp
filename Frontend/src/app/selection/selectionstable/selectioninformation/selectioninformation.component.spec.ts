import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectioninformationComponent } from './selectioninformation.component';

describe('SelectioninformationComponent', () => {
  let component: SelectioninformationComponent;
  let fixture: ComponentFixture<SelectioninformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectioninformationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SelectioninformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
