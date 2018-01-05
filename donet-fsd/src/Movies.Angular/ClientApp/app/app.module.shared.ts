import { NgModule } from '@angular/core';
import { MovieService } from './services/movieservice.service'
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchMovieComponent } from './components/fetchmovie/fetchmovie.component'
import { createMovie } from './components/addmovie/AddMovie.component'

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        FetchMovieComponent,
        createMovie,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'fetch-movie', component: FetchMovieComponent },
            { path: 'register-movie', component: createMovie },
            { path: 'movie/edit/:id', component: createMovie },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [MovieService]
})
export class AppModuleShared {
}
