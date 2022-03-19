import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//imports
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {DragDropModule} from '@angular/cdk/drag-drop';
import { Ng2SearchPipeModule } from 'ng2-search-filter';

//components
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TdNoteComponent } from './components/td-note/td-note.component';
import { TdNoteCardComponent } from './components/td-note-card/td-note-card.component';
import { AlertifyService } from './services/alertify.service';
import { ArchivedNotesComponent } from './components/archived-notes/archived-notes.component';

@NgModule({
  declarations: [
    AppComponent,
    TdNoteComponent,
    TdNoteCardComponent,
    ArchivedNotesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FormsModule,
    FontAwesomeModule,
    BrowserAnimationsModule,
    DragDropModule,
    Ng2SearchPipeModule
  ],
  providers: [AlertifyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
