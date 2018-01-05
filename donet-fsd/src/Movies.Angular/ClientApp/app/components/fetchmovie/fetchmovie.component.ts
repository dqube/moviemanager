import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { MovieService } from '../../Services/movieservice.service';

@Component({
    selector: 'fetchmovie',
    templateUrl: './fetchmovie.component.html'
})

export class FetchMovieComponent {
    public movList: MovieData[];

    constructor(public http: Http, private _router: Router, private _movieService: MovieService) {
        this.getMovies();
    }

    getMovies() {
        this._movieService.getMovies().subscribe(
            data => this.movList = data
        )
    }

    delete(movieID) {
        var ans = confirm("Do you want to delete customer with Id: " + movieID);
        if (ans) {
            this._movieService.deleteMovie(movieID).subscribe((data) => {
                this.getMovies();
            }, error => console.error(error)) 
        }
    }
}

interface MovieData {
    id: number;
    name: string;
    gender: string;
    department: string;
    city: string;
}