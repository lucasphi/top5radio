import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SuggestionComponent } from './content/suggestion/suggestion.component';
import { RankingComponent } from './admin/ranking/ranking.component';


const routes: Routes = [
  {
    path: '',
    component: SuggestionComponent
  },
  {
    path: 'admin',
    children: [
      { path: 'ranking', component: RankingComponent}
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
