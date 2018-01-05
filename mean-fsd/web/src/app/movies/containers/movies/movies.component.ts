import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Movie } from '../../shared/services/movies.service';

import { MoviesService } from '../../shared/services/movies.service';
import { LoggerService } from './../../../shared/logger/logger.service';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-movies',
  styleUrls: ['movies.component.scss'],
  template: `
    <div class="movies">
      <app-movie-list
        [movies]="moviesTable">
      </app-movie-list>
    </div>
  `
})
export class MoviesComponent implements OnInit {

  movies: Movie[];
  moviesTable: MatTableDataSource<Movie>;
  isLoadingResults = true;

  displayedColumns = ['title', 'year', 'createdAt', 'edit'];

  constructor(
    private route: ActivatedRoute,
    private moviesService: MoviesService,
    private loggerService: LoggerService
  ) {}

  ngOnInit() {

    this.moviesService.getMovies()
    .subscribe(
      (movies: Movie[]) => {
        this.movies = movies;
        this.moviesTable = new MatTableDataSource<Movie>(movies);
      },
      error => this.loggerService.error(error.error.message)
    );
  }
}
