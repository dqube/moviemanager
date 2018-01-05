import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchMovieComponent } from '../fetchmovie/fetchmovie.component';
import { MovieService } from '../../services/movieservice.service';

@Component({
    selector: 'createmovie',
    templateUrl: './AddMovie.component.html'
})

export class createMovie implements OnInit {
    movieForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _movieService: MovieService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        this.movieForm = this._fb.group({
            id: 0,
            name: ['', [Validators.required]],
            gender: ['', [Validators.required]],
            department: ['', [Validators.required]],
            city: ['', [Validators.required]]
        })
    }

    ngOnInit() {
        if (this.id > 0) {
            this.title = "Edit";
            this._movieService.getMovieById(this.id)
                .subscribe(resp => this.movieForm.setValue(resp)
                , error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.movieForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._movieService.saveMovie(this.movieForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-movie']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._movieService.updateMovie(this.movieForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-movie']);
                }, error => this.errorMessage = error) 
        }
    }

    cancel() {
        this._router.navigate(['/fetch-movie']);
    }

    get name() { return this.movieForm.get('name'); }
    get gender() { return this.movieForm.get('gender'); }
    get department() { return this.movieForm.get('department'); }
    get city() { return this.movieForm.get('city'); }
}