import * as moment from "moment";
import { Note } from "./models/note";
import { NoteDetail } from "./models/note-detail";
import { NoteState } from "./models/note-state.enum";

export class Utility {
    static getDefaultNote(date?: string): Note {
        if (!date) {
            date = moment().startOf('day').format('YYYY-MM-DDT00:00:00.000z');
        }

        let _noteToReturn = new Note();
        _noteToReturn.id = -1;
        _noteToReturn.description = 'Great Day !!'
        _noteToReturn.date = date;
        _noteToReturn.notesDetails = [];

        let _noteDetailToAdd = new NoteDetail();
        _noteDetailToAdd.status = NoteState.Assigned;
        _noteDetailToAdd.id = -1;
        _noteDetailToAdd.archived = false;
        _noteDetailToAdd.description = 'Start Typing Here ...';
        _noteDetailToAdd.title = 'Title here ...';
        _noteDetailToAdd.noteId = -1;

        _noteToReturn.notesDetails.push(_noteDetailToAdd);

        return _noteToReturn;
    }


    static getDefaultNoteDetail(id?:number,state?:NoteState): NoteDetail {
        if ((!id)||id<0) {
            id = -1;
        }
        if ((!state)) {
            state = NoteState.Assigned;
        }
        

        let _noteDetailToReturn = new NoteDetail();
        _noteDetailToReturn.status = state;
        _noteDetailToReturn.id = -1;
        _noteDetailToReturn.archived = false;
        _noteDetailToReturn.description = 'Start Typing Here ...';
        _noteDetailToReturn.title = 'Title here ...';
        _noteDetailToReturn.noteId = id;

        return _noteDetailToReturn;
    }

}
