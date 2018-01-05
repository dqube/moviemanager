import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpResponse } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

import { APP_CONFIG } from './../../../../config';

export interface Movie{
  movieid?: string;
  title: string;
  year: number;
  cast: string;
  rating: number;
  genre: string;
  story: string;
  created_at: Date;
  updated_at: Date;
}
@Injectable()
export class MoviesService {
  constructor(
    private http: HttpClient,
  ) {}

  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(`${APP_CONFIG.api}/movies`);
  }

  getMovie(id: string): Observable<Movie> {
    return this.http.get<Movie>(`${APP_CONFIG.api}/movies/${id}`);
  }

  createMovie(movie: Movie): Observable<Movie> {
    return this.http.post<Movie>(`${APP_CONFIG.api}/movies`, movie);
  }

  updateMovie(id: string, movie: Movie): Observable<any> {
    return this.http.put(`${APP_CONFIG.api}/movies/${id}`, movie);
  }

  deleteMovie(id: string): Observable<Movie> {
    return this.http.delete<Movie>(`${APP_CONFIG.api}/movies/${id}`);
  }
}
