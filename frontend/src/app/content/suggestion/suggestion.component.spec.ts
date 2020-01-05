import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA, Pipe, PipeTransform, Injectable } from '@angular/core';

import { of } from 'rxjs/internal/observable/of';

import { SuggestionComponent } from './suggestion.component';
import { SuggestionService } from './suggestion.service';
import { Music } from 'src/app/shared/models/music.model';

@Pipe({
  name: 'search'
})
class SearchPipeMock implements PipeTransform {
  transform(value: any, filter: string) {
     return value;
  }
}

@Injectable()
class SuggestionServiceMock {
  loadMusics(): any {
    return of([] as Music[]);
  }
}

describe('SuggestionComponent', () => {
  let component: SuggestionComponent;
  let fixture: ComponentFixture<SuggestionComponent>;
  let mockSuggestionService: SuggestionServiceMock;

  beforeEach(async(() => {
    mockSuggestionService = new SuggestionServiceMock();
    TestBed.configureTestingModule({
      declarations: [ SuggestionComponent, SearchPipeMock ],
      schemas: [ NO_ERRORS_SCHEMA ],
    })
    .overrideProvider(SuggestionService, { useValue: mockSuggestionService })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SuggestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should select a song', () => {
    component.musics = [{ id: '1', name: 'test song 1' }, { id: '2', name: 'test song 2' }] as Music[];
    component.selectSong({ id: '2', name: 'test song 2' } as Music);

    expect(component.musics).toEqual([{ id: '1', name: 'test song 1' }] as Music[]);
    expect(component.selectedMusic).toEqual([{ id: '2', name: 'test song 2' }] as Music[]);
    expect(component.searchInput).toEqual('');
  });

  it('should not select a song after the 5th', () => {
    component.musics = [{ id: '1', name: 'test song 1' }, { id: '2', name: 'test song 2' }] as Music[];
    component.selectedMusic = [{}, {}, {}, {}, {}] as Music[];
    component.selectSong({ id: '2', name: 'test song 2' } as Music);

    expect(component.musics).toEqual([{ id: '1', name: 'test song 1' }, { id: '2', name: 'test song 2' }] as Music[]);
    expect(component.selectedMusic).toEqual([{}, {}, {}, {}, {}] as Music[]);
    expect(component.searchInput).toEqual('');
  });

  it('should remove a selected song', () => {
    component.musics = [{ id: '1', name: 'test song 1' }] as Music[];
    component.selectedMusic = [{ id: '2', name: 'test song 2' }] as Music[];
    component.removeSong({ id: '2', name: 'test song 2' } as Music);

    expect(component.selectedMusic).toEqual([] as Music[]);
    expect(component.musics).toEqual([{ id: '1', name: 'test song 1' }, { id: '2', name: 'test song 2' }] as Music[]);
    expect(component.searchInput).toEqual('');
  });
});
