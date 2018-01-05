import { Module, RequestMethod, MiddlewaresConsumer } from '@nestjs/common';

import { DatabaseModule } from '../database/database.module';
import { AuthMiddleware } from '../common/middlewares/auth.middlewares';
import { MoviesController } from './movies.controller';
import { MoviesService } from './movies.service';
import { moviesProviders } from './movies.providers';

@Module({
  modules: [DatabaseModule],
  controllers: [MoviesController],
  components: [
    MoviesService,
    ...moviesProviders,
  ],
  exports: [
    MoviesService
  ],
})
export class MoviesModule {
  public configure(consumer: MiddlewaresConsumer) {
   // consumer.apply(AuthMiddleware).forRoutes(
       // { path: '/users', method: RequestMethod.GET },
       // { path: '/users/:id', method: RequestMethod.GET },
        // { path: '/users/:id', method: RequestMethod.PUT },
        // { path: '/users/:id', method: RequestMethod.DELETE },
   // );
}
}