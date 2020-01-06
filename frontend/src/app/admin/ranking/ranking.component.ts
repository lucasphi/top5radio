import { Component, OnInit } from '@angular/core';

import { RankingService } from './ranking.service';
import { Music } from 'src/app/shared/models/music.model';
import { User } from 'src/app/shared/models/user.model';

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.scss'],
  providers: [ RankingService ]
})
export class RankingComponent implements OnInit {

  topSongs: Array<Music>;
  users: Array<User>;

  constructor(private rankingService: RankingService) { }

  ngOnInit() {
    this.rankingService.loadTopSongs().subscribe(
      (result) => {
        this.topSongs = result;
      }
    );

    this.rankingService.loadUsers().subscribe(
      (result) => {
        this.users = result;
      }
    );
  }

}
