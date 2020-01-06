import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/internal/Observable';

import { Music } from 'src/app/shared/models/music.model';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/shared/models/user.model';

@Injectable()
export class RankingService {

    constructor(private http: HttpClient) { }

    loadTopSongs(): Observable<Music[]> {
        const url = `${environment.adminEndpoint}/admin/topsongs`;
        return this.http.get<Music[]>(url);
    }

    loadUsers(): Observable<User[]> {
        const url = `${environment.adminEndpoint}/admin/usercontribution`;
        return this.http.get<User[]>(url);
    }

}
