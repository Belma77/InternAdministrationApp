import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplyforinternshipComponent } from './applyforinternship.component';

describe('ApplyforinternshipComponent', () => {
  let component: ApplyforinternshipComponent;
  let fixture: ComponentFixture<ApplyforinternshipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplyforinternshipComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplyforinternshipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
