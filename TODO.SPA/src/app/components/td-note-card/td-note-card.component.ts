import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NoteDetail } from 'src/app/models/note-detail';
import { _Icons } from 'src/app/models/_Icons';

@Component({
  selector: 'app-td-note-card',
  templateUrl: './td-note-card.component.html',
  styleUrls: ['./td-note-card.component.css']
})
export class TdNoteCardComponent implements OnInit {
  @Input() note: NoteDetail;
  @Output() onDelete = new EventEmitter<NoteDetail>();
  @Output() onEditDetail = new EventEmitter<NoteDetail>();
  
  _icons = new _Icons();
  editMode: boolean;
  constructor() { }

  ngOnInit() {
  }
  toggleEdit() {

    this.editMode = !this.editMode;

    if(!this.editMode){
      
    }
  }
  deleteNote() {
    this.onDelete.emit(this.note);
  }

}
