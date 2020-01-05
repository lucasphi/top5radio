import {Pipe, PipeTransform} from '@angular/core';

import { Music } from '../models/music.model';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  transform(value: Music[], filter: string) {

    if (!value || filter.length === 0) {
     return value;
    }

    return (value || []).filter(item => item.name.toLocaleLowerCase().indexOf(filter.toLocaleLowerCase()) >= 0);

  }

}
