import { Component, OnInit } from '@angular/core';
import { _Icons } from 'src/app/models/_Icons';

@Component({
  selector: 'app-td-note-card',
  templateUrl: './td-note-card.component.html',
  styleUrls: ['./td-note-card.component.css']
})
export class TdNoteCardComponent implements OnInit {

  _icons = new _Icons();
  constructor() { }

  ngOnInit() {
  }


}
