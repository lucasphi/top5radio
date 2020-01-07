import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Injectable } from '@angular/core';

import { of } from 'rxjs/internal/observable/of';

import { RankingComponent } from './ranking.component';
import { Music } from 'src/app/shared/models/music.model';
import { User } from 'src/app/shared/models/user.model';
import { RankingService } from './ranking.service';

@Injectable()
class RankingServiceMock {
  loadTopSongs(): any {
    return of([] as Music[]);
  }
  loadUsers(): any {
    return of([] as User[]);
  }
}

describe('RankingComponent', () => {
  let component: RankingComponent;
  let fixture: ComponentFixture<RankingComponent>;
  let mockRankingService: RankingServiceMock;

  beforeEach(async(() => {
    mockRankingService = new RankingServiceMock();
    TestBed.configureTestingModule({
      declarations: [ RankingComponent ]
    })
    .overrideProvider(RankingService, { useValue: mockRankingService })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RankingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
