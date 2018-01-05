import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

import { MaterialModule } from './../material.module';

// Services
import { MoviesService } from './shared/services/movies.service';

// components
import { MovieFormComponent } from './components/movie-form/movie-form.component';
import { MovieListComponent } from './components/movie-list/movie-list.component';

// containers
import { MoviesComponent } from './containers/movies/movies.component';
import { MovieComponent } from './containers/movie/movie.component';

export const ROUTES: Routes = [
  { path: '', component: MoviesComponent},
  { path: 'new', component: MovieComponent },
  { path: ':id', component: MovieComponent},
];

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild(ROUTES),
    MaterialModule
  ],
  declarations: [
    MoviesComponent,
    MovieComponent,
    MovieFormComponent,
    MovieListComponent
  ],
  providers: [
    MoviesService,
  ]
})
export class MoviesModule {}
