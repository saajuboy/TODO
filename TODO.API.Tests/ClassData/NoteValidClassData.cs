using System;
using System.Collections;
using System.Collections.Generic;
using TODO.API.Dtos;
using static TODO.API.Common.Enums;

namespace TODO.API.Tests.ClassData
{
    public class NoteValidClassData : IEnumerable<NoteDto>
    {
        public IEnumerator<NoteDto> GetEnumerator()
        {
            yield return new NoteDto
                {
                  Id=1,
                  Date= DateTime.Now,
                  Description = "Test desc 1",
                  NotesDetails = new List<NoteDetailDto>{
                    new NoteDetailDto{
                      Archived = true,
                      Description = "Test Description",
                      Status = NoteState.Active,
                      Title = "Test Title",
                    },
                    new NoteDetailDto{
                      Archived = false,
                      Description = "Test 2 Description",
                      Status = NoteState.Active,
                      Title = "Test -3 Title",
                    },
                  }
                  
                };
             yield return new NoteDto
                {
                  Id=1,
                  Date= DateTime.Now.AddDays(3),
                  Description = "Test desc 2",
                  NotesDetails = new List<NoteDetailDto>{
                    new NoteDetailDto{
                      Archived = false,
                      Description = "Test 2 _ Description",
                      Status = NoteState.Active,
                      Title = "Test s Title",
                    },
                    new NoteDetailDto{
                      Archived = false,
                      Description = "Test 2 Description",
                      Status = NoteState.Active,
                      Title = "Test 1 Title",
                    },
                  }
                  
                };
                // }
            // };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}