import { Connection } from 'mongoose';
import { MovieSchema } from './schemas/movie.schema';

export const moviesProviders = [
  {
    provide: 'MovieModelToken', // Deplace to a constants.ts
    useFactory: (connection: Connection) => connection.model('Movie', MovieSchema),
    inject: ['DbConnectionToken'], // Deplace to a constants.ts
  },
];