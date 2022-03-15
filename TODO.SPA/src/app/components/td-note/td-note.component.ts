import { Component, OnInit } from '@angular/core';
import { NgbCalendar, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';
import { Note } from 'src/app/models/note';
import { NoteDetail } from 'src/app/models/note-detail';
import { NoteParam } from 'src/app/models/note-param';
import { NoteService } from 'src/app/services/note.service';

@Component({
  selector: 'app-td-note',
  templateUrl: './td-note.component.html',
  styleUrls: ['./td-note.component.css']
})
export class TdNoteComponent implements OnInit {

  notes: Note[] = [];
  assignedNotes:NoteDetail[] = [];
  activeNotes:NoteDetail[] = [];
  onHoldNotes:NoteDetail[] = [];
  completedNotes:NoteDetail[] = [];
  
  model: NgbDateStruct;
  searchText: string;


  constructor(private noteService: NoteService, private calendar: NgbCalendar) { }

 async ngOnInit() {
    // let _date = moment().format('DD-YY-MM')
    let _date = moment().toISOString();
    // this.getNotes(_date);

    this.notes = await this.getNote(_date);

    console.log('await response',this.notes);
    
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


  async getNote(date: string, searchString?: string, isArchived?: boolean): Promise<Array<Note>> {
    let _noteParam = new NoteParam();
    _noteParam.date = date;
    return new Promise((resolve) => {
      this.noteService.getNotes(_noteParam).subscribe({
        next: (response) => {
          let _notes: Note[] = response;
          resolve(_notes);
        }
      });
    })


  }
}
