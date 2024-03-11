using Moq;
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
}