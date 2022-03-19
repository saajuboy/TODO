import { Component, OnInit } from '@angular/core';
import { Note } from 'src/app/models/note';
import { NoteDetail, NoteDetailForUpdate } from 'src/app/models/note-detail';
import { NoteParam } from 'src/app/models/note-param';
import { _Icons } from 'src/app/models/_Icons';
import { AlertifyService } from 'src/app/services/alertify.service';
import { NoteService } from 'src/app/services/note.service';

@Component({
  selector: 'app-archived-notes',
  templateUrl: './archived-notes.component.html',
  styleUrls: ['./archived-notes.component.css']
})
export class ArchivedNotesComponent implements OnInit {

  archivedNotes: NoteDetail[] = [];
  _icons = new _Icons();
  searchText: string;
  deletedNotes: NoteDetail[] = [];
  constructor(private noteService: NoteService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.populateInitialData();
  }


  async populateInitialData() {
    this.archivedNotes = await this.getNotes();
  }


  async getNotes(): Promise<NoteDetail[]> {
    let _noteParam = new NoteParam();
    _noteParam.isArchived = true;
    return new Promise((resolve, reject) => {
      this.noteService.getNotes(_noteParam).subscribe({
        next: (response) => {
          let _notes: Note[] = response;
          let _noteDetailsToReturn: NoteDetail[] = []
          if (_notes && _notes.length > 0) {
            _notes.forEach(x => {
              _noteDetailsToReturn.push(...x.notesDetails);
            });
            resolve(_noteDetailsToReturn);
          } else {
            resolve(_noteDetailsToReturn);
          }

        }
      });
    });
  }

  async onNoteDelete(note: NoteDetail) {
    this.deletedNotes.push(note);

    this.archivedNotes.splice(this.archivedNotes.indexOf(note), 1);

    this.alertify.ActionUndo('Note has been deleted. UNDO', () => {
      //call delete Function
      if (note.id > 0) {
        this.noteService.deleteNoteDetail(note.id).subscribe((res) => {
        });
      }
    }, () => {
      this.archivedNotes.push(note);
    });
  }

  async editNote(_noteDetail: NoteDetail) {
        console.log(_noteDetail);
        let _noteDetailForUpdate = new NoteDetailForUpdate();
        _noteDetailForUpdate.archived = _noteDetail.archived;
        _noteDetailForUpdate.description = _noteDetail.description;
        _noteDetailForUpdate.status = _noteDetail.status;
        _noteDetailForUpdate.title = _noteDetail.title;
        this.updateNoteDetail(_noteDetail.id, _noteDetailForUpdate);
    
  }

  updateNoteDetail(id: number, noteDetailForUpdate: NoteDetailForUpdate) {
    this.noteService.updateNoteDetail(id, noteDetailForUpdate).subscribe((x) => {
      this.alertify.success('Saved Changes');
      var index = this.archivedNotes.findIndex(x=>x.id == id);
      if(index>-1){
        this.archivedNotes.splice(index, 1);
      }
    }, (err) => {
      this.alertify.warning('Failed to save changes');
    })
  }
}
