using StudyWeb.Models;

namespace StudyHallTests.StudyWebTests.model;

[TestFixture]
public class ErrorViewModelTest
{
    [Test]
    public void TestShowRequestId()
    {
        var errorViewModel = new ErrorViewModel
        {
            RequestId = "123"
        };
        Assert.That(errorViewModel.ShowRequestId, Is.True);
    }

    [Test]
    public void TestShowRequestIdFalse()
    {
        var errorViewModel = new ErrorViewModel
        {
            RequestId = ""
        };
        Assert.That(errorViewModel.ShowRequestId, Is.False);
    }
}