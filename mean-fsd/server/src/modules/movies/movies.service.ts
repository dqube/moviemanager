import { Model } from 'mongoose';
import { Component, Inject } from '@nestjs/common';
import { Movie } from './interfaces/movie.interface';

@Component()
export class MoviesService {
  constructor(
    @Inject('MovieModelToken') private readonly MovieModel: Model<Movie>
  ) { }

  async create(movie: Movie): Promise<Movie> {
    const createdMovie = new this.MovieModel(movie);
    return await createdMovie.save();
  }

  async findAll(options?: any): Promise<Movie[]> {
    let movies = await this.MovieModel.find(options).exec();
    const serializedMovies = movies.map((movie) => {
      return movie.schema.methods.serialize(movie);
    });
    return serializedMovies;
  }

  async findById(id: string): Promise<Movie | null> {
    let movie = await this.MovieModel.findById(id).exec();
    if (movie) {
      movie = await this.serializeMovie(movie);
    }
    return movie;
  }

  async findOne(options?: any, fields?: any): Promise<Movie | null> {
    let movie = await this.MovieModel.findOne(options, fields).exec();

    if (movie) {
      movie = await this.serializeMovie(movie);
    }

    return movie;
  }

  async update(id: number, newValue: Movie): Promise<Movie | null> {
    console.log(id);
    return await this.MovieModel.findByIdAndUpdate(id, newValue).exec();
  }

  async delete(id: number): Promise<Movie | null> {
    return await this.MovieModel.findByIdAndRemove(id).exec();
  }
  async serializeMovie(movie: any): Promise<any> {
    return {
      movieid: movie._id,
      title: movie.title,
      year: movie.year,
      cast: movie.cast,
      rating: movie.rating,
      genre: movie.genre,
      story: movie.story,
      created_at: movie.created_at,
      updated_at: movie.updated_at
    }
  }
}