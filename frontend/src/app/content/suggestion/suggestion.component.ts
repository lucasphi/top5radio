import { Component, OnInit } from '@angular/core';

import { Music } from 'src/app/shared/models/music.model';
import { SuggestionService } from './suggestion.service';

@Component({
  selector: 'app-suggestion',
  templateUrl: './suggestion.component.html',
  styleUrls: ['./suggestion.component.scss'],
  providers: [ SuggestionService ]
})
export class SuggestionComponent implements OnInit {

  musics: Array<Music>;
  selectedMusic: Array<Music> = [];
  searchInput = '';
  username: string;

  constructor(private suggestionService: SuggestionService) { }

  ngOnInit() {
    this.suggestionService.loadMusics().subscribe(
      (musics) => {
        this.musics = musics.sort((a, b) => a.name.localeCompare(b.name));
      },
      (error) => {
        console.log(error);
      }
    );
  }

  selectSong(music: Music): void {
    if (this.selectedMusic.length < 5) {
      this.searchInput = '';

      this.selectedMusic.push(music);
      this.musics = this.musics.filter(f => f.id !== music.id);
    }
  }

  removeSong(music: Music): void {
    this.searchInput = '';
    this.musics.push(music);
    this.musics = this.musics.sort((a, b) => a.name.localeCompare(b.name));
    this.selectedMusic = this.selectedMusic.filter(f => f.id !== music.id);
  }

  sendChoises(): void {

  }

}
