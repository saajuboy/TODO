import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TdNoteComponent } from './components/td-note/td-note.component';

const routes: Routes = [{ path: '', component: TdNoteComponent },];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
