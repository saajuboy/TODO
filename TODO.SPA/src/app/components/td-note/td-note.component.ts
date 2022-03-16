import { Component, OnInit } from '@angular/core';
import { faCalendarDay, faHourglass } from '@fortawesome/free-solid-svg-icons';
import { NgbCalendar, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';
import { Note } from 'src/app/models/note';
import { NoteDetail } from 'src/app/models/note-detail';
import { NoteParam } from 'src/app/models/note-param';
import { _Icons } from 'src/app/models/_Icons';
import { NoteService } from 'src/app/services/note.service';

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

  model: NgbDateStruct;
  searchText: string;

  _icons = new _Icons();
  constructor(private noteService: NoteService, private calendar: NgbCalendar) { }

  async ngOnInit() {
    // let _date = moment().format('DD-YY-MM')
    let _date = moment().toISOString();
    // this.getNotes(_date);

    this.note = await this.getNote(_date);

    console.log('await response', this.note);

  }

  // getNotes(date: string, searchString?: string, isArchived?: boolean) {
  //   let _noteParam = new NoteParam();
  //   _noteParam.date = date;
  //   this.noteService.getNotes(_noteParam).subscribe(res => {
  //     this.notes = res;
  //     //validate or create
  //   });
  // }

  selectToday() {
    this.model = this.calendar.getToday();
  }


  async getNote(date: string, searchString?: string, isArchived?: boolean): Promise<Note> {
    let _noteParam = new NoteParam();
    _noteParam.date = date;
    return new Promise((resolve,reject) => {
      this.noteService.getNotes(_noteParam).subscribe({
        next: (response) => {
          let _notes: Note[] = response;
          if (_notes && _notes.length > 0) {
            resolve(_notes[0]);
          } else {
            reject(new Note());
          }

        }
      });
    })


  }
}
