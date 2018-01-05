import { Module } from '@nestjs/common';

import { AuthModule } from './auth/auth.module';
import { UsersModule } from './users/users.module';
import { MoviesModule } from './movies/movies.module';

@Module({
  modules: [
    AuthModule,
    UsersModule,
    MoviesModule
  ]
})
export class ApplicationModule {}
