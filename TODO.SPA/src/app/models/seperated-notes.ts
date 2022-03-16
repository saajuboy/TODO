import { NoteDetail } from "./note-detail";

export class SeperatedNotes {
    assignedNotes: NoteDetail[] = [];
    activeNotes: NoteDetail[] = [];
    onHoldNotes: NoteDetail[] = [];
    completedNotes: NoteDetail[] = [];

    archivedNotes: NoteDetail[] = [];
}
