using System.Net;
using System.Text;
using Moq;
using Moq.Protected;
using StudyDesk.Model;

namespace StudyHallTests.StudyDeskTests.model;

[TestFixture]
public class AuthServiceTest
{
    #region Data members

    private Mock<HttpMessageHandler>? handlerMock;
    private AuthService? authService;
    private string tempFilePath;

    #endregion

    #region Methods

    [SetUp]
    public void Setup()
    {
        this.handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var httpClient = new HttpClient(this.handlerMock.Object)
        {
            BaseAddress = new Uri("https://localhost:7240/")
        };
        this.authService = new AuthService(httpClient);

        tempFilePath = Path.GetTempFileName();
        File.WriteAllText(tempFilePath, "Test file content");
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(tempFilePath))
        {
            File.Delete(tempFilePath);
        }
    }

    [Test]
    public void DefaultConstructor_InitializesHttpClient()
    {
        var authService = new AuthService();
        Assert.That(authService, Is.Not.Null);
        Assert.That(authService, Is.InstanceOf<AuthService>());
    }

    [Test]
    public async Task LoginAsync_SuccessfulLogin_ReturnsSelf()
    {
        var expectedUri = new Uri("https://localhost:7240/auth/login");

        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("...")
            })
            .Verifiable();

        var result = await this.authService!.LoginAsync("testuser", "testpass");

        Assert.That(result, Is.Not.Null);
        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri),
            ItExpr.IsAny<CancellationToken>());
    }

    [Test]
    public async Task LoginAsync_UnsuccessfulLogin_ReturnsNull()
    {
        var expectedUri = new Uri("https://localhost:7240/auth/login");

        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Content = new StringContent("...")
            })
            .Verifiable();

        var result = await this.authService!.LoginAsync("testuser", "testpass");

        Assert.That(result, Is.Null);
        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri),
            ItExpr.IsAny<CancellationToken>());
    }

    [Test]
    public void LoginAsync_FailedLogin_ThrowsException()
    {
        var expectedUri = new Uri("https://localhost:7240/auth/login");

        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent("...")
            })
            .Verifiable();

        Assert.ThrowsAsync<Exception>(() => this.authService!.LoginAsync("testuser", "testpass"));

        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri),
            ItExpr.IsAny<CancellationToken>());
    }

    [Test]
    public async Task GetSources_SuccessfulRequest_ReturnsSources()
    {
        var expectedUri = new Uri("https://localhost:7240/SourceExplorer");

        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    "[{\"id\":1,\"title\":\"test\",\"owner\":\"test\",\"type\":1,\"link\":\"test\"}]")
            })
            .Verifiable();

        var result = await this.authService!.GetSources();
        var sourceList = result.ToList();

        Assert.That(sourceList, Is.Not.Null);
        Assert.That(sourceList, Has.Exactly(1).Items);
        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri),
            ItExpr.IsAny<CancellationToken>());
    }

    [Test]
    public void GetSources_UnsuccessfulRequest_ThrowsException()
    {
        var expectedUri = new Uri("https://localhost:7240/SourceExplorer");

        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent("...")
            })
            .Verifiable();

        Assert.ThrowsAsync<Exception>(() => this.authService!.GetSources());

        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri),
            ItExpr.IsAny<CancellationToken>());
    }

    [Test]
    public void GetSources_ExceptionThrown_ThrowsException()
    {
        var expectedUri = new Uri("https://localhost:7240/SourceExplorer");

        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new Exception("Test exception"))
            .Verifiable();

        Assert.ThrowsAsync<Exception>(() => this.authService!.GetSources());

        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri),
            ItExpr.IsAny<CancellationToken>());
    }

    [Test]
    public void GetSources_Unauthorized_ReturnsEmptyList()
    {
        var expectedUri = new Uri("https://localhost:7240/SourceExplorer");

        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Content = new StringContent("...")
            })
            .Verifiable();

        var result = this.authService!.GetSources().Result.ToList();

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Empty);
        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri),
            ItExpr.IsAny<CancellationToken>());
    }

    [Test]
    public void TryLogout_Success()
    {
        var expectedUri = new Uri("https://localhost:7240/Identity/Account/Logout?returnUrl=%2F");

        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("...")
            })
            .Verifiable();

        var result = this.authService!.Logout();

        Assert.That(result, Is.True);
        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri),
            ItExpr.IsAny<CancellationToken>());
    }

    [Test]
    public async Task AddSource_SuccessfulCall_DoesNotThrowException()
    {
        var expectedUri = new Uri("https://localhost:7240/SourceExplorer/Create");
        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(
                    req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("...")
            })
            .Verifiable();
        const SourceType sourceType = SourceType.Pdf;
        Assert.DoesNotThrowAsync(() => this.authService!.AddSource("Test Title", this.tempFilePath, sourceType));
        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri),
            ItExpr.IsAny<CancellationToken>());
    }

    [Test]
    public async Task GetSourcesWithMatchingTags_WhenCalledWithValidTags_ReturnsSources()
    {
        var expectedUri = new Uri("https://localhost:7240/SourceExplorer/SearchTags");
        var tags = new List<string> { "education", "science" };
        var mockResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("[{\"Id\":1,\"Name\":\"Source1\"},{\"Id\":2,\"Name\":\"Source2\"}]", Encoding.UTF8, "application/json")
        };

        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(mockResponse)
            .Verifiable();

        var result = await this.authService!.GetSourcesWithMatchingTags(tags);

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count());
        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri),
            ItExpr.IsAny<CancellationToken>());
    }

    [Test]
    public async Task GetSourcesWithMatchingTags_WhenUnauthorized_ReturnsEmptyList()
    {
        var expectedUri = new Uri("https://localhost:7240/SourceExplorer/SearchTags");
        var tags = new List<string> { "unauthorized", "test" };
        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized
            })
            .Verifiable();

        var result = await this.authService!.GetSourcesWithMatchingTags(tags);

        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }

    [Test]
    public void GetSourcesWithMatchingTags_WhenExceptionOccurs_ThrowsException()
    {
        var expectedUri = new Uri("https://localhost:7240/SourceExplorer/SearchTags");
        var tags = new List<string> { "exception", "test" };
        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("An error occurred while searching sources"))
            .Verifiable();

        Assert.ThrowsAsync<Exception>(async () => await this.authService!.GetSourcesWithMatchingTags(tags), "An error occurred while searching sources");
    }

    [Test]
    public void DeleteSource_Successful_ReturnsTrue()
    {
        var sourceId = 1;
        var expectedUri = new Uri($"https://localhost:7240/SourceExplorer/Delete/{sourceId}");

        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Delete &&
                    req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            })
            .Verifiable();

        var result = this.authService!.DeleteSource(sourceId);

        Assert.IsTrue(result);
        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Delete && req.RequestUri == expectedUri),
            ItExpr.IsAny<CancellationToken>());
    }

    [Test]
    public void DeleteSource_Unsuccessful_ReturnsFalse()
    {
        var sourceId = 1;
        var expectedUri = new Uri($"https://localhost:7240/SourceExplorer/Delete/{sourceId}");

        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Delete &&
                    req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError
            })
            .Verifiable();

        var result = this.authService!.DeleteSource(sourceId);

        Assert.IsFalse(result);
        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Delete && req.RequestUri == expectedUri),
            ItExpr.IsAny<CancellationToken>());
    }

    /*[Test]
    public void AddSource_FailedCall_ThrowsException()
    {
        var expectedUri = new Uri("https://localhost:7240/SourceExplorer/Create");

        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(
                    req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("...")
            })
            .Verifiable();

        Assert.ThrowsAsync<Exception>(() => this.authService!.AddSource("Test Title", tempFilePath));
        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri),
            It.Expr.IsAny<CancellationToken>());
    }*/

    #endregion
}