import { Component, Input, ViewChild } from '@angular/core';
import {MatPaginator, MatSort, MatTableDataSource} from '@angular/material';

import { Movie } from '../../shared/services/movies.service';
import { AfterViewInit, OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
  selector: 'app-movie-list',
  styleUrls: ['movie-list.component.scss'],
  template: `
    <div class="movie-list">
      <div class="table-header">
        <h1>Movies list</h1>

        <mat-form-field>
          <input matInput (keyup)="applyFilter($event.target.value)" placeholder="Filter">
        </mat-form-field>

        <a mat-raised-button color="primary" class="create-movie" [routerLink]="'../movies/new'">
          <mat-icon>add</mat-icon> New
        </a>
      </div>

      <div class="container mat-elevation-z8">
        <mat-table [dataSource]="movies" matSort>

          <!-- Title column -->
          <ng-container matColumnDef="title">
            <mat-header-cell *matHeaderCellDef mat-sort-header> Title </mat-header-cell>
            <mat-cell *matCellDef="let movie"> {{ movie.title }} </mat-cell>
          </ng-container>

          <!-- Year column -->
          <ng-container matColumnDef="year">
            <mat-header-cell *matHeaderCellDef mat-sort-header> Year </mat-header-cell>
            <mat-cell *matCellDef="let movie"> {{ movie.year }} </mat-cell>
          </ng-container>

          <!-- Created at column -->
          <ng-container matColumnDef="createdAt">
            <mat-header-cell *matHeaderCellDef mat-sort-header> Created At </mat-header-cell>
            <mat-cell *matCellDef="let movie"> {{ movie.created_at | date : 'MMM d, yyyy' }} </mat-cell>
          </ng-container>

          <!-- Edit column -->
          <ng-container matColumnDef="edit">
            <mat-header-cell *matHeaderCellDef mat-sort-header> Edit </mat-header-cell>
            <mat-cell *matCellDef="let movie">
              <a [routerLink]="['../movies', movie.movieid]"><mat-icon>create</mat-icon></a></mat-cell>
          </ng-container>

          <mat-header-row *matHeaderRowDef="displayedColumns"></mat-header-row>
          <mat-row *matRowDef="let movie; columns: displayedColumns;">
          </mat-row>
        </mat-table>

      </div>
    </div>
  `
})

export class MovieListComponent  {

  displayedColumns = ['title', 'year', 'createdAt', 'edit'];
  dataSource: MatTableDataSource<Movie>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  @Input()
  movies: Movie[];

  constructor() {}

  

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }

}
