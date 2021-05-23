import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BrandDetailComponent } from './brand-detail.component';

describe('BrandDetailComponent', () => {
  let component: BrandDetailComponent;
  let fixture: ComponentFixture<BrandDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BrandDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BrandDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
