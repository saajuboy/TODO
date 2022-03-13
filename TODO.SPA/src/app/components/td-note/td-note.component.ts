import { Component, OnInit } from '@angular/core';
import { NgbCalendar, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';
import { Note } from 'src/app/models/note';
import { NoteParam } from 'src/app/models/note-param';
import { NoteService } from 'src/app/services/note.service';

@Component({
  selector: 'app-td-note',
  templateUrl: './td-note.component.html',
  styleUrls: ['./td-note.component.css']
})
export class TdNoteComponent implements OnInit {

  notes: Note[] = [];


  model: NgbDateStruct;
  date: {year: number, month: number};

  constructor(private noteService: NoteService,private calendar: NgbCalendar) { }

  ngOnInit() {
    // let _date = moment().format('DD-YY-MM')
    let _date = moment().toISOString();
    this.getNotes(_date);
  }

  getNotes(date: string) {
    let _noteParam = new NoteParam();
    _noteParam.date = date;
    this.noteService.getNotes(_noteParam).subscribe(res => {
      this.notes = res;
      //validate or create
    });
  }
 
  selectToday() {
    this.model = this.calendar.getToday();
  }

}
