import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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
}
