import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class MovieService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getMovies() {
        return this._http.get(this.myAppUrl + 'api/Movie/Index')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getMovieById(id: number) {
        return this._http.get(this.myAppUrl + "api/Movie/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveMovie(movie:any) {
        return this._http.post(this.myAppUrl + 'api/Movie/Create', movie)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateMovie(movie:any) {
        return this._http.put(this.myAppUrl + 'api/Movie/Edit', movie)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteMovie(id:number) {
        return this._http.delete(this.myAppUrl + "api/Movie/Delete/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}