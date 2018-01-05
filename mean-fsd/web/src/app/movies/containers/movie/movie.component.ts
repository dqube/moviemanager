import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Movie, MoviesService } from '../../shared/services/movies.service';
import { LoggerService } from '../../../shared/logger/logger.service';

@Component({
  selector: 'app-movie',
  styleUrls: ['movie.component.scss'],
  template: `
    <div>
      <app-movie-form
        [movie]="movie"
        (create)="addMovie($event)"
        (update)="updateMovie($event)"
        (remove)="removeMovie()">
      </app-movie-form>
    </div>
  `
})
export class MovieComponent implements OnInit {

  movie: Movie;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private moviesService: MoviesService,
    private loggerService: LoggerService
  ) {}

  ngOnInit() {

    // Retrieve the prefetched movies
    this.route.data.subscribe(
      (data: { movie: Movie }) => {
        this.movie = data.movie;
      }
    );
  }

  addMovie(event: Movie) {
    this.moviesService.createMovie(event)
      .subscribe(
        res => {
          this.loggerService.success('Movie successfully added');
          this.backToMovies();
        },
        error => this.loggerService.error(error.error.message)
      );
  }

  updateMovie(event: Movie) {
    const key = this.route.snapshot.params.id;

    this.moviesService.updateMovie(key, event)
      .subscribe(
        res => {
          this.loggerService.success('Movie successfully updated');
          this.backToMovies();
        },
        error => this.loggerService.error(error.error.message)
      );
  }

  removeMovie() {
    const key = this.route.snapshot.params.id;

    this.moviesService.deleteMovie(key)
      .subscribe(
        res => {
          this.loggerService.success('Movie successfully deleted');
          this.backToMovies();
        },
        error => this.loggerService.error(error.error.message)
      );
  }

  backToMovies() {
    this.router.navigate(['movies']);
  }
}
