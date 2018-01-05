import { Component, Input, Output, EventEmitter, ChangeDetectionStrategy, OnChanges, SimpleChanges } from '@angular/core';
import { FormArray, FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

import { Movie } from '../../shared/services/movies.service';

@Component({
  selector: 'app-movie-form',
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ['movie-form.component.scss'],
  template: `
    <div class="movie-form">
      <form [formGroup]="form">

      <mat-form-field>
        <input
          matInput
          placeholder="Title*"
          formControlName="title">
        <mat-error *ngIf="required('title')">
          Title is <strong>required</strong>
        </mat-error>
      </mat-form-field>

      <mat-form-field>
        <input
          matInput
          placeholder="Content*"
          formControlName="content">
        <mat-error *ngIf="required('content')">
          Content is <strong>required</strong>
        </mat-error>
      </mat-form-field>

      <mat-form-field>
        <input
          matInput
          placeholder="Author*"
          formControlName="author">
        <mat-error *ngIf="required('author')">
          Author is <strong>required</strong>
        </mat-error>
      </mat-form-field>

      <div class="submit">
        <button mat-raised-button color="primary" *ngIf="!exists" (click)="createMovie()">Create movie</button>
        <button mat-raised-button color="primary" *ngIf="exists" (click)="updateMovie()">Update movie</button>
        <a mat-raised-button color="warn" [routerLink]="['../']">Cancel</a>
        <button mat-raised-button color="primary" *ngIf="exists" (click)="removeMovie()">Delete movie</button>
      </div>

      </form>
    </div>
  `
})
export class MovieFormComponent implements OnChanges {

  exists = false;

  @Input()
  movie: Movie;

  @Output()
  create = new EventEmitter<Movie>();

  @Output()
  update = new EventEmitter<Movie>();

  @Output()
  remove = new EventEmitter<Movie>();

  form = this.fb.group({
    title: ['', Validators.required],
    content: ['', Validators.required],
    author: ['', Validators.required]
  });

  constructor(
    private fb: FormBuilder
  ) {}

  ngOnChanges(changes: SimpleChanges) {
    if (this.movie) {
      this.exists = true;

      const value = this.movie;
      this.form.patchValue(value);
    }
  }

  required(field) {
    return (
      this.form.get(field).hasError('required') &&
      this.form.get(field).touched
    );
  }

  createMovie() {
    if (this.form.valid) {
      this.create.emit(this.form.value);
    }
  }

  updateMovie() {
    if (this.form.valid) {
      this.update.emit(this.form.value);
    }
  }

  removeMovie() {
    this.remove.emit();
  }
}
