using StudyDesk.Model;

namespace StudyHallTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var webSource = new StudyWeb.Models.Source
            {
                Title = "Test",
                Id = 5
            };
            var deskSource = new StudyDesk.Model.Source(1, "test", "test", SourceType.Pdf, "test");
            Assert.Pass();
        }
    }
}