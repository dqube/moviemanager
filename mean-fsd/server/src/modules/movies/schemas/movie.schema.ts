import { Schema } from 'mongoose';

export const movieschema = new Schema({
  title: { type: String, required: true },
  year: { type: Number, required: true },
  cast: { type: String, required: true },
  rating: { type: Number, required: true },
  genre: { type: String, required: true },
  story: { type: String, required: true },
  created_at: { type: Date, default: Date.now },
  updated_at: { type: Date, default: Date.now }
});

/**
 * On every save, add the date
 */
movieschema.pre('save', function (next) {
  const currentDate = new Date();

  this.updated_at = currentDate;
  next();
});
// Duplicate the ID field.
movieschema.virtual('movieid').get(function () {
  return this._id.toString();
}).set(function (v) {
  this.__movieid = v;
});;

// Ensure virtual fields are serialised.
movieschema.set('toObject', {
  virtuals: true,
  versionKey: false
});

movieschema.set('toJSON', {
  virtuals: true,
  versionKey: false
});

movieschema.methods.serialize = function (movie) {
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
};

export const MovieSchema = movieschema;
