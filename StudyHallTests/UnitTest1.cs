using StudyWeb.Models;

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
            Assert.Pass();
        }

        [Test]
        public void TestInvalidSourceType()
        {
            var source = new Source
            {
                Type = (SourceTypes)5
            };
            Assert.Throws<ArgumentException>(() => source.SourceTypeToString());
        }
    }
}