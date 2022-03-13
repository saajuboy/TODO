using TODO.API.Data.Interfaces;
using TODO.API.Dtos;
using TODO.API.Manager;
using TODO.API.Tests.ClassData;
using Xunit;

namespace TODO.API.Tests
{
    public class NotesManagerTests
    {
        private readonly NotesManager manager;
        public NotesManagerTests()
        {
            this.manager = new NotesManager();


        }
        [Theory]
        [ClassData(typeof(NoteValidClassData))]
        public void ValidateNote_ValidObject_ReturnsTrue(NoteDto noteDto)
        {
            var result = manager.ValidateNote(noteDto);

            Assert.True(result);
        }
    }
}