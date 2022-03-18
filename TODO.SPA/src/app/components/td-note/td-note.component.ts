import { Component, OnInit } from '@angular/core';
import { NgbCalendar, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import * as moment from 'moment';
import { Note } from 'src/app/models/note';
import { NoteDetail } from 'src/app/models/note-detail';
import { NoteParam } from 'src/app/models/note-param';
import { NoteState } from 'src/app/models/note-state.enum';
import { SeperatedNotes } from 'src/app/models/seperated-notes';
import { _Icons } from 'src/app/models/_Icons';
import { NoteService } from 'src/app/services/note.service';
import { Utility } from 'src/app/utility';

@Component({
  selector: 'app-td-note',
  templateUrl: './td-note.component.html',
  styleUrls: ['./td-note.component.css']
})
export class TdNoteComponent implements OnInit {

  note: Note;
  assignedNotes: NoteDetail[] = [];
  activeNotes: NoteDetail[] = [];
  onHoldNotes: NoteDetail[] = [];
  completedNotes: NoteDetail[] = [];
  archivedNotes: NoteDetail[] = [];

  date: NgbDateStruct;
  searchText: string;

  _icons = new _Icons();

  get getSelectedDateInIso(): string {
    return moment(this.date.year + '-' + this.date.month + '-' + this.date.day).startOf('day').format('YYYY-MM-DDT00:00:00.000z');
  }
  constructor(private noteService: NoteService, private calendar: NgbCalendar) { }

  ngOnInit() {
    this.getInitialData();
  }

  // getNotes(date: string, searchString?: string, isArchived?: boolean) {
  //   let _noteParam = new NoteParam();
  //   _noteParam.date = date;
  //   this.noteService.getNotes(_noteParam).subscribe(res => {
  //     this.notes = res;
  //     //validate or create
  //   });
  // }

  async getInitialData() {
    this.selectToday()
    let _date = moment().toISOString();

    this.populateNoteData(_date);

    // console.log('await response', this.note);
  }

  async populateNoteData(date: string) {
    this.note = await this.getNote(date);
    let _seperatedNotes = this.getSeperatedNotes(this.note);

    // console.log(_seperatedNotes);

    this.assignedNotes = _seperatedNotes.assignedNotes;
    this.activeNotes = _seperatedNotes.activeNotes;
    this.onHoldNotes = _seperatedNotes.onHoldNotes;
    this.completedNotes = _seperatedNotes.completedNotes;
    this.archivedNotes = _seperatedNotes.archivedNotes;
  }

  selectToday() {
    this.date = this.calendar.getToday();
  }


  async getNote(date: string, searchString?: string, isArchived?: boolean): Promise<Note> {
    let _noteParam = new NoteParam();
    _noteParam.date = date;
    return new Promise((resolve, reject) => {
      this.noteService.getNotes(_noteParam).subscribe({
        next: (response) => {
          let _notes: Note[] = response;
          if (_notes && _notes.length > 0) {
            resolve(_notes[0]);
          } else {
            resolve(Utility.getDefaultNote(date));
          }

        }
      });
    });
  }

  getSeperatedNotes(note: Note) {
    let _seperatedNoteToReturn = new SeperatedNotes();

    if ((!note) || !(note.notesDetails) || note.notesDetails.length == 0) {
      return _seperatedNoteToReturn;
    }

    for (let index = 0; index < note.notesDetails.length; index++) {
      const singleNote = note.notesDetails[index];

      singleNote.noteId = note.id;

      if (singleNote.archived) {
        _seperatedNoteToReturn.archivedNotes.push(singleNote);
        continue;
      }

      switch (singleNote.status) {
        case NoteState.Assigned:
          _seperatedNoteToReturn.assignedNotes.push(singleNote);
          break;
        case NoteState.Active:
          _seperatedNoteToReturn.activeNotes.push(singleNote);
          break;
        case NoteState.OnHold:
          _seperatedNoteToReturn.onHoldNotes.push(singleNote);
          break;
        case NoteState.Done:
          _seperatedNoteToReturn.completedNotes.push(singleNote);
          break;
        default:
          break;
      }
    }

    return _seperatedNoteToReturn
  }
  
  AddNewNoteDetail(){
      let _noteDetail = Utility.getDefaultNoteDetail(this.note.id,NoteState.Assigned)
      this.assignedNotes.push(_noteDetail);
  }

  dateChanged() {
    this.populateNoteData(this.getSelectedDateInIso);
  }

  drop(event: CdkDragDrop<NoteDetail[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex,
      );
    }
    
  }

}
