import { NoteState } from "./note-state.enum";

export class NoteDetail {
    id: number;
    title: string;
    description: string;
    status: NoteState;
    archived: boolean;
    noteId?:number;
}
