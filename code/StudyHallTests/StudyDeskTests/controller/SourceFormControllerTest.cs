using Moq;
using NuGet.Packaging;
using StudyDesk.Controller;
using StudyDesk.Model;

namespace StudyHallTests.StudyDeskTests.controller;

[TestFixture]
public class SourceFormControllerTest
{
    private Mock<INotesRepository>? notesRepositoryMock;
    private Source? source;

    [SetUp]
    public void SetUp()
    {
        this.source = new Source(1, "title", "author", SourceType.Image, "year");
        this.notesRepositoryMock = new Mock<INotesRepository>();
    }
    
    [Test]
    public void TestDefaultConstruction()
    {
        var controller = new SourceFormController(this.source!);

        Assert.Multiple(() =>
        {
            Assert.That(controller.Notes, Is.Not.Null);
            Assert.That(controller.NotesRepository, Is.Not.Null);
        });
    }

    // [Test]
    // public void GetNotesMockRepo()
    // {
    //     var notes = new List<Note>
    //     {
    //         new(1, "note", this.source!.Id, this.source!.Owner)
    //     };
    //     this.notesRepositoryMock!.Setup(x => x.GetNotes()).Returns(notes);
    //     var controller = new SourceFormController(this.source!, this.notesRepositoryMock!.Object);
    //
    //     controller.RefreshNotes();
    //     var result = controller.Notes;
    //
    //     Assert.That(result, Is.EqualTo(notes));
    //     this.notesRepositoryMock.Verify(x => x.GetNotes(), Times.Once);
    // }

    [Test]
    public void AddNoteToDatabaseMockRepo_ReturnsTrue()
    {
        var note = new Note(1, "note", this.source!.Id, this.source!.Owner);
        this.notesRepositoryMock!.Setup(x => x.AddNoteToDatabase(It.Is<Note>(n => n.Text == note.Text))).Returns(true);
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock!.Object);

        var result = controller.AddNote(note.Text);
        
        Assert.That(result, Is.True);
        this.notesRepositoryMock.Verify(x => x.AddNoteToDatabase(It.Is<Note>(n => n.Text == note.Text)), Times.Once);
    }

    [Test]
    public void AddNoteToDatabaseMockRepo_ReturnsFalse()
    {
        var note = new Note(1, "note", this.source!.Id, this.source!.Owner);
        this.notesRepositoryMock!.Setup(x => x.AddNoteToDatabase(It.Is<Note>(n => n.Text == note.Text))).Returns(false);
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock!.Object);

        var result = controller.AddNote(note.Text);
        
        Assert.That(result, Is.False);
        this.notesRepositoryMock.Verify(x => x.AddNoteToDatabase(It.Is<Note>(n => n.Text == note.Text)), Times.Once);
    }

    [Test]
    public void UpdateNoteInDatabaseMockRepo_ReturnsTrue()
    {
        var note = new Note(1, "note", this.source!.Id, this.source!.Owner);
        this.notesRepositoryMock!.Setup(x => x.UpdateNoteInDatabase(It.Is<Note>(n => n.Id == note.Id))).Returns(true);
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock!.Object);
        controller.Notes.Add(note);
        var result = controller.EditNote(0, "new note");
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(controller.Notes[0].Text, Is.EqualTo("new note"));
        });
        this.notesRepositoryMock.Verify(x => x.UpdateNoteInDatabase(It.Is<Note>(n => n.Id == note.Id)), Times.Once);
    }

    [Test]
    public void UpdateNoteInDatabaseMockRepo_ReturnsFalse()
    {
        var note = new Note(1, "note", this.source!.Id, this.source!.Owner);
        this.notesRepositoryMock!.Setup(x => x.UpdateNoteInDatabase(It.Is<Note>(n => n.Id == note.Id))).Returns(false);
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock!.Object);
        controller.Notes.Add(note);
        var result = controller.EditNote(0, "new note");
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            Assert.That(controller.Notes[0].Text, Is.EqualTo("note"));
        });
        this.notesRepositoryMock.Verify(x => x.UpdateNoteInDatabase(It.Is<Note>(n => n.Id == note.Id)), Times.Once);
    }

    [Test]
    public void DeleteNoteFromDatabaseMockRepo_ReturnsTrue()
    {
        var note = new Note(1, "note", this.source!.Id, this.source!.Owner);
        this.notesRepositoryMock!.Setup(x => x.DeleteNoteFromDatabase(It.Is<Note>(n => n.Id == note.Id))).Returns(true);
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock!.Object);
        controller.Notes.Add(note);
        var result = controller.DeleteNoteAt(0);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(controller.Notes, Is.Empty);
        });
        this.notesRepositoryMock.Verify(x => x.DeleteNoteFromDatabase(It.Is<Note>(n => n.Id == note.Id)), Times.Once);
    }

    [Test]
    public void DeleteNoteFromDatabaseMockRepo_ReturnsFalse()
    {
        var note = new Note(1, "note", this.source!.Id, this.source!.Owner);
        this.notesRepositoryMock!.Setup(x => x.DeleteNoteFromDatabase(It.Is<Note>(n => n.Id == note.Id))).Returns(false);
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock!.Object);
        controller.Notes.Add(note);
        var result = controller.DeleteNoteAt(0);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            Assert.That(controller.Notes, Has.Count.EqualTo(1));
        });
        this.notesRepositoryMock.Verify(x => x.DeleteNoteFromDatabase(It.Is<Note>(n => n.Id == note.Id)), Times.Once);
    }

    [Test]
    public void AddNoteWithTags_AllSuccess_ReturnsTrue()
    {
        var noteText = "Sample Note";
        var tags = new List<string> { "Tag1", "Tag2" };
        this.notesRepositoryMock!.Setup(x => x.AddNoteToDatabase(It.IsAny<Note>())).Returns(true);
        this.notesRepositoryMock.Setup(x => x.AddTagToDatabase(It.IsAny<NoteTag>())).Returns(true);
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock.Object);

        var result = controller.AddNoteWithTags(noteText, tags);

        Assert.IsTrue(result);
        this.notesRepositoryMock.Verify(x => x.AddNoteToDatabase(It.IsAny<Note>()), Times.Once);
        this.notesRepositoryMock.Verify(x => x.AddTagToDatabase(It.IsAny<NoteTag>()), Times.Exactly(tags.Count));
    }

    [Test]
    public void AddNoteWithTags_NoteAdditionFails_ReturnsFalse()
    {
        var noteText = "Sample Note";
        var tags = new List<string> { "Tag1", "Tag2" };
        this.notesRepositoryMock!.Setup(x => x.AddNoteToDatabase(It.IsAny<Note>())).Returns(false);
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock.Object);

        var result = controller.AddNoteWithTags(noteText, tags);

        Assert.IsFalse(result);
        this.notesRepositoryMock.Verify(x => x.AddNoteToDatabase(It.IsAny<Note>()), Times.Once);
        this.notesRepositoryMock.Verify(x => x.AddTagToDatabase(It.IsAny<NoteTag>()), Times.Never);
    }

    [Test]
    public void AddNoteWithTags_PartialTagAdditionSuccess_ReturnsFalse()
    {
        var noteText = "Sample Note";
        var tags = new List<string> { "Tag1", "Tag2" };
        this.notesRepositoryMock!.Setup(x => x.AddNoteToDatabase(It.IsAny<Note>())).Returns(true);
        this.notesRepositoryMock.Setup(x => x.AddTagToDatabase(It.Is<NoteTag>(tag => tag.Name == tags[0]))).Returns(true);
        this.notesRepositoryMock.Setup(x => x.AddTagToDatabase(It.Is<NoteTag>(tag => tag.Name == tags[1]))).Returns(false);
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock.Object);

        var result = controller.AddNoteWithTags(noteText, tags);

        Assert.IsFalse(result);
        this.notesRepositoryMock.Verify(x => x.AddNoteToDatabase(It.IsAny<Note>()), Times.Once);
        this.notesRepositoryMock.Verify(x => x.AddTagToDatabase(It.IsAny<NoteTag>()), Times.Exactly(tags.Count));
    }

    [Test]
    public void AddTagToExistingNote_Success_ReturnsTrue()
    {
        var notes = new List<Note>
        {
            new Note(1, "Sample Note 1", this.source!.Id, this.source!.Owner),
            new Note(2, "Sample Note 2", this.source!.Id, this.source!.Owner)
        };
        this.notesRepositoryMock!.Setup(x => x.AddTagToDatabase(It.IsAny<NoteTag>())).Returns(true);
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock.Object);
        controller.Notes.AddRange(notes);
        var tag = "New Tag";

        var result = controller.AddTagToExistingNote(1, tag);

        Assert.IsTrue(result);
        Assert.Contains(tag, controller.Notes[0].NoteTags);
        this.notesRepositoryMock.Verify(x => x.AddTagToDatabase(It.IsAny<NoteTag>()), Times.Once);
    }

    [Test]
    public void AddTagToExistingNote_RepoFails_ReturnsFalse()
    {
        var notes = new List<Note>
        {
            new Note(1, "Sample Note", this.source!.Id, this.source!.Owner)
        };
        this.notesRepositoryMock!.Setup(x => x.AddTagToDatabase(It.IsAny<NoteTag>())).Returns(false);
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock.Object);
        controller.Notes.AddRange(notes);
        var tag = "Unadded Tag";

        var result = controller.AddTagToExistingNote(1, tag);

        Assert.IsFalse(result);
        Assert.IsEmpty(controller.Notes[0].NoteTags);
        this.notesRepositoryMock.Verify(x => x.AddTagToDatabase(It.IsAny<NoteTag>()), Times.Once);
    }

    [Test]
    public void AddTagToExistingNote_InvalidIndex_ReturnsFalse()
    {
        var notes = new List<Note>
        {
            new Note(1, "Sample Note", this.source!.Id, this.source!.Owner)
        };
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock.Object);
        controller.Notes.AddRange(notes);
        var tag = "Nonexistent Tag";

        var result = controller.AddTagToExistingNote(3, tag);

        Assert.IsFalse(result);
        this.notesRepositoryMock.Verify(x => x.AddTagToDatabase(It.IsAny<NoteTag>()), Times.Never);
    }

    [Test]
    public void AddTagToExistingNote_ToLastNote_ReturnsTrue()
    {
        var notes = new List<Note>
        {
            new Note(1, "First Note", this.source!.Id, this.source!.Owner),
            new Note(2, "Last Note", this.source!.Id, this.source!.Owner)
        };
        this.notesRepositoryMock!.Setup(x => x.AddTagToDatabase(It.IsAny<NoteTag>())).Returns(true);
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock.Object);
        controller.Notes.AddRange(notes);
        var tag = "TagForLastNote";

        var result = controller.AddTagToExistingNote(2, tag);

        Assert.IsTrue(result);
        Assert.Contains(tag, controller.Notes[1].NoteTags);
    }

    /*[Test]
    public void DeleteNoteTag_Success_ReturnsTrue()
    {
        var notes = new List<Note>
        {
            new Note(1, "Sample Note", this.source!.Id, this.source!.Owner)
        };
        notes[0].NoteTags.Add("Tag1");
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock.Object);
        controller.Notes.AddRange(notes);
        this.notesRepositoryMock!.Setup(x => x.DeleteTagFromDatabase(It.IsAny<NoteTag>())).Returns(true);

        var result = controller.DeleteNoteTag(0, "Tag1");

        Assert.IsTrue(result);
        this.notesRepositoryMock.Verify(x => x.DeleteTagFromDatabase(It.IsAny<NoteTag>()), Times.Once);
    }*/

    /*[Test]
    public void DeleteNoteTag_TagDoesNotExist_ReturnsFalse()
    {
        var notes = new List<Note>
        {
            new Note(1, "Sample Note", this.source!.Id, this.source!.Owner)
        };
        notes[0].NoteTags.Add("Tag1");
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock.Object);
        controller.Notes.AddRange(notes);

        var result = controller.DeleteNoteTag(0, "NonExistentTag");

        Assert.IsFalse(result);
        this.notesRepositoryMock.Verify(x => x.DeleteTagFromDatabase(It.IsAny<NoteTag>()), Times.Never);
    }*/

    [Test]
    public void DeleteNoteTag_NoTagsOnNote_ReturnsFalse()
    {
        var notes = new List<Note>
        {
            new Note(1, "Sample Note", this.source!.Id, this.source!.Owner)
        };
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock.Object);
        controller.Notes.AddRange(notes);

        var result = controller.DeleteNoteTag(0, "Tag1");
        
        Assert.IsFalse(result);
        this.notesRepositoryMock.Verify(x => x.DeleteTagFromDatabase(It.IsAny<NoteTag>()), Times.Never);
    }

    /*[Test]
    public void DeleteNoteTag_NoteIndexOutOfBounds_ReturnsFalse()
    {
        var controller = new SourceFormController(this.source!, this.notesRepositoryMock.Object);

        Assert.IsFalse(controller.DeleteNoteTag(0, "Tag1"));
        this.notesRepositoryMock.Verify(x => x.DeleteTagFromDatabase(It.IsAny<NoteTag>()), Times.Never);
    }*/

    /*[Test]
    public void RefreshNotes_UpdatesNotesListAndTagsFromRepository()
    {
        var mockNotes = new List<Note>
        {
            new Note(1, "Note 1", this.source!.Id, this.source!.Owner),
            new Note(2, "Note 2", this.source!.Id, this.source!.Owner)
        };

        mockNotes[0].NoteTags = new List<string> { "Tag1" };
        mockNotes[1].NoteTags = new List<string> { "Tag2", "Tag3" };

        this.notesRepositoryMock!.Setup(repo => repo.GetNotes()).Returns(mockNotes);

        var controller = new SourceFormController(this.source!, this.notesRepositoryMock.Object);

        controller.RefreshNotes();

        Assert.AreEqual(mockNotes.Count, controller.Notes.Count, "The number of notes should match the mocked notes count.");
        for (int i = 0; i < mockNotes.Count; i++)
        {
            Assert.AreEqual(mockNotes[i].Id, controller.Notes[i].Id, $"Note ID at index {i} does not match.");
            Assert.AreEqual(mockNotes[i].Text, controller.Notes[i].Text, $"Note Text at index {i} does not match.");

            CollectionAssert.AreEquivalent(mockNotes[i].NoteTags, controller.Notes[i].NoteTags, $"Tags for note at index {i} do not match.");
        }

        this.notesRepositoryMock.Verify(repo => repo.GetNotes(), Times.Once, "GetNotes should be called exactly once.");
    }*/
}