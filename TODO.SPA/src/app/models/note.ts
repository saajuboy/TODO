import { NoteDetail } from "./note-detail";

export class Note {
    id:number;
    date:string;
    description:string = '';
    notesDetails:NoteDetail[];
}

export class NoteForUpdate{
    description:string;
}
