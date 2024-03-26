using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyDesk.Model;

namespace StudyHallTests.StudyDeskTests.model
{
    [TestFixture]
    public class NoteTagTest
    {

        [Test]
        public void TestSettingIdValue()
        {
            var noteTag = new NoteTag();
            var expected = 1;
            noteTag.Id = expected;
            Assert.AreEqual(expected, noteTag.Id);
        }

        [Test]
        public void TestSettingNoteIdValue()
        {
            var noteTag = new NoteTag();
            var expected = 100;
            noteTag.NoteId = expected;
            Assert.AreEqual(expected, noteTag.NoteId);
        }

        [Test]
        public void TestSettingNameValue()
        {
            var noteTag = new NoteTag();
            var expected = "Math";
            noteTag.Name = expected;
            Assert.AreEqual(expected, noteTag.Name);
        }
    }
}
