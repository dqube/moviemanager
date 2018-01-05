import { Controller, Get, Post, Delete, Body, UseGuards, Param, Request, HttpException, HttpStatus, Put } from '@nestjs/common';


import { RolesGuard } from '../common/guards/roles.guard';
import { MoviesService } from './movies.service';
import { Movie } from './interfaces/movie.interface';

@Controller('movies')
@UseGuards(RolesGuard)
export class MoviesController {
  constructor(private readonly moviesService: MoviesService) {}

  @Get()
  async index(): Promise<Movie[]> {
    return await this.moviesService.findAll();
  }
  
  @Get(':id')
  async show(@Request() req): Promise<Movie> {
    const id = req.params.id;
    if (!id) throw new HttpException('ID parameter is missing', HttpStatus.BAD_REQUEST);

    const user = await this.moviesService.findById(id);
    if (!user) throw new HttpException(`The user with the id: ${id} does not exists`, HttpStatus.BAD_REQUEST);

    return user
  }

  @Post()
  async create(@Body() body) {
    if (!body || (body && Object.keys(body).length === 0)) throw new HttpException('Missing informations', HttpStatus.BAD_REQUEST);

    await this.moviesService.create(body);
  }

  @Put(':id')
  async update(@Request() req) {
    const id = req.params.id;
    if (!id) throw new HttpException('ID parameter is missing', HttpStatus.BAD_REQUEST);

    await this.moviesService.update(id, req.body);
  }

  @Delete(':id')
  public async delete(@Request() req) {
      const id = req.params.id;
      if (!id) throw new HttpException('ID parameter is missing', HttpStatus.BAD_REQUEST);

      await this.moviesService.delete(id);
  }
}
