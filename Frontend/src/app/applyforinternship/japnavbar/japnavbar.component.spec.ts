import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JapnavbarComponent } from './japnavbar.component';

describe('JapnavbarComponent', () => {
  let component: JapnavbarComponent;
  let fixture: ComponentFixture<JapnavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JapnavbarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JapnavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
