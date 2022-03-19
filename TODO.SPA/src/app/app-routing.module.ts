import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArchivedNotesComponent } from './components/archived-notes/archived-notes.component';
import { TdNoteComponent } from './components/td-note/td-note.component';

const routes: Routes = [{ path: '', component: TdNoteComponent },{ path: 'archived', component: ArchivedNotesComponent },];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
