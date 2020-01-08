import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/internal/Observable';

import { Music } from 'src/app/shared/models/music.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class SuggestionService {
    constructor(private http: HttpClient) { }

    loadMusics(): Observable<Music[]> {
        const url = `${environment.apiEndpoint}/musics`;
        return this.http.get<Music[]>(url);
    }

    saveTopMusics(username: string, songs: Music[]): Observable<any> {
        const url = `${environment.apiEndpoint}/musics/vote`;
        const selectedSongs = songs.map(f => f.id);

        const httpOptions = {
            headers: new HttpHeaders({
              'Content-Type':  'application/json',
            })
          };
        return this.http.post(url, { username, songs: selectedSongs }, httpOptions);
    }
}
