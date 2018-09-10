import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PicturesComponent } from './pictures/pictures.component';
import { FileService } from '../services/file.service';
import { MapComponent } from './google-map/map.component';
import { TextFormatter } from './textFormatter/textFormatter';
import { AgmCoreModule } from '@agm/core';
import { CKEditorModule } from 'ng2-ckeditor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PicturesComponent,
    TextFormatter,
    MapComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent, pathMatch: 'full' },
      { path: '', component: PicturesComponent },
      { path: 'google-map', component: MapComponent}
    ]),
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyBCIOgDee3t7dpxUNR7NRX6UKb6suLYv1U'
    }),
    CKEditorModule
  ],
  providers: [FileService],
  bootstrap: [AppComponent]
})
export class AppModule { }
