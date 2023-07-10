import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ArticlesComponent } from './articles/articles.component';
import { AnnouncementsComponent } from './announcements/announcements.component';
import { SingleAnnouncementComponent } from './single-announcement/single-announcement.component';

import { HashLocationStrategy, LocationStrategy } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ArticlesComponent,
    AnnouncementsComponent,
    SingleAnnouncementComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'api/article', component: ArticlesComponent },
      { path: 'api/announcement', component: AnnouncementsComponent },
      { path: 'api/announcement/:title/:date/:id', component: SingleAnnouncementComponent },
      { path: '**', component: HomeComponent } // make it 404 page not found
    ])
  ],
  providers: [ {provide: LocationStrategy, useClass: HashLocationStrategy} ],
  bootstrap: [AppComponent] 
})
export class AppModule { }
