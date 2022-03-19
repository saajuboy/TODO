using Microsoft.AspNetCore.Mvc;
using TODO.API.Dtos;
using TODO.API.Dtos.Params;
using TODO.API.Manager;
using TODO.API.Models.Helpers;

namespace TODO.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly NotesManager _NotesManager;
        public NotesController(NotesManager notesManager)
        {
            this._NotesManager = notesManager;
        }

        [HttpGet(Name = "GetNotes")]
        public async Task<IActionResult> GetNotes([FromQuery] NotesParam notesParam)
        {
            var _notes = await _NotesManager.GetNotes(notesParam);


            return Ok(_notes);
        }

        [HttpGet("{id}", Name = "GetNote")]
        public async Task<IActionResult> GetNoteById(int id)
        {
            NotesParam notesParam = new NotesParam();
            notesParam.NotesId = id;

            var _notes = await _NotesManager.GetNotes(notesParam);

            if (_notes != null && _notes.Count() > 0)
            {
                return Ok(_notes[0]);
            }
            else
            {
                return Ok();
            }
        }


        // [HttpPost]
        // public async Task<IActionResult> InsertNote(NoteDto noteDto)
        // {
        //     // validate request

        //     noteDto.Username = noteDto.Username.ToLower();

        //     if (await _repository.UserExists(noteDto.Username))
        //         return BadRequest("Username Already Exists");
        //     var usertoCreate = _mapper.Map<User>(noteDto);

        //     var createdUser = await _repository.Register(usertoCreate, noteDto.Password);

        //     var userToReturn = _mapper.Map<UserForDetailDto>(createdUser);
        //     return CreatedAtRoute("GetUser", new { Controller = "Users", id = createdUser.Id }, userToReturn);

        // }


        [HttpDelete("Detail/{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Failed to delete the Note");
            }

            var _result = await _NotesManager.DeleteNoteDetail(id);

            if (_result)
                return Ok();

            return BadRequest("Failed to delete the Note");
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote(NoteDto noteDto)
        {
            if (noteDto == null)
                return BadRequest("Empty Body");

            var _result = await _NotesManager.CreateNote(noteDto);

            if (_result !=null )
            {
                // return CreatedAtRoute("GetNote", new { _result.Id }, _result);
                return Ok(_result) ;
            }

            return BadRequest("Could not create Note");
        }

        [HttpPost("Detail")]
        public async Task<IActionResult> CreateNoteDetal(NoteDetailDto noteDetailDto)
        {
            if (noteDetailDto == null)
                return BadRequest("Empty Body");

            var _result = await _NotesManager.CreateNoteDetail(noteDetailDto);

            if (_result !=null )
            {
                return Ok(_result) ;
            }

            return BadRequest("Could not create Note Detail");
        }
    }
}