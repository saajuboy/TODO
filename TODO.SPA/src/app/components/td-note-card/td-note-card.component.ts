import { Component, Input, OnInit } from '@angular/core';
import { NoteDetail } from 'src/app/models/note-detail';
import { _Icons } from 'src/app/models/_Icons';

@Component({
  selector: 'app-td-note-card',
  templateUrl: './td-note-card.component.html',
  styleUrls: ['./td-note-card.component.css']
})
export class TdNoteCardComponent implements OnInit {
  @Input() note: NoteDetail;
  _icons = new _Icons();
  editMode: boolean;
  constructor() { }

  ngOnInit() {
  }
  toggleEdit() {
    this.editMode = !this.editMode;
  }

}
