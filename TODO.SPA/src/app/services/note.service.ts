import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Note, NoteForUpdate } from '../models/note';
import { NoteDetail, NoteDetailForUpdate } from '../models/note-detail';
import { NoteParam } from '../models/note-param';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  baseUrl = environment.APIUrl;
  constructor(private http: HttpClient) { }

  getNotes(noteParam?: NoteParam): Observable<Note[]> {
    let params = new HttpParams();

    if (noteParam) {

      if (noteParam.pageNumber)
        params = params.append('pageNumber', noteParam.pageNumber);

      if (noteParam.pageSize)
        params = params.append('pageSize', noteParam.pageSize);

      if (noteParam.date)
        params = params.append('date', noteParam.date);

      if (noteParam.notesId)
        params = params.append('notesId', noteParam.notesId);

      if (noteParam.searchString)
        params = params.append('searchString', noteParam.searchString);

      if (noteParam.isArchived)
        params = params.append('isArchived', noteParam.isArchived);

      if (noteParam.orderBy)
        params = params.append('orderBy', noteParam.orderBy);
    }


    return this.http.get<Note[]>(this.baseUrl + 'Notes', { observe: 'body', params });
  }

  getNote(id: number): Observable<Note> {
    return this.http.get<Note>(this.baseUrl + 'Notes/' + id);
  }

  deleteNoteDetail(noteDetaild: number) {
    return this.http.delete(this.baseUrl + 'Notes/Detail/' + noteDetaild);
  }

  createNote(note: Note): Observable<Note> {
    return this.http.post<Note>(this.baseUrl + 'Notes', note);
  }

  createNoteDetail(noteDetail: NoteDetail): Observable<NoteDetail> {
    return this.http.post<NoteDetail>(this.baseUrl + 'Notes/Detail', noteDetail);
  }

  updateNote(id: number, note: NoteForUpdate) {
    return this.http.put(this.baseUrl + 'Notes/' + id, note);
  }

  updateNoteDetail(id: number, noteDetail: NoteDetailForUpdate) {
    return this.http.put(this.baseUrl + 'Notes/Detail/' + id, noteDetail);
  }

}
