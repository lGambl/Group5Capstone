﻿using System.Net;
using Moq;
using Moq.Protected;
using StudyDesk.Model;

namespace StudyHallTests.StudyDeskTests
{
    [TestFixture]
    public class AuthServiceTest
    {
        private Mock<HttpMessageHandler>? handlerMock;
        private AuthService? authService;

        [SetUp]
        public void Setup()
        {
            this.handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var httpClient = new HttpClient(this.handlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:7240/"),
            };
            this.authService = new AuthService(httpClient);
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
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("..."),
                })
                .Verifiable();

            var result = await this.authService!.LoginAsync("testuser", "testpass");

            Assert.That(result, Is.Not.Null);
            this.handlerMock!.Protected().Verify("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public async Task LoginAsync_UnsuccessfulLogin_ReturnsNull()
        {
            var expectedUri = new Uri("https://localhost:7240/auth/login");

            this.handlerMock!.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("..."),
                })
                .Verifiable();

            var result = await this.authService!.LoginAsync("testuser", "testpass");

            Assert.That(result, Is.Null);
            this.handlerMock!.Protected().Verify("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public void LoginAsync_FailedLogin_ThrowsException()
        {
            var expectedUri = new Uri("https://localhost:7240/auth/login");

            this.handlerMock!.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent("..."),
                })
                .Verifiable();

            Assert.ThrowsAsync<Exception>(() => this.authService!.LoginAsync("testuser", "testpass"));

            this.handlerMock!.Protected().Verify("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public async Task GetSources_SuccessfulRequest_ReturnsSources()
        {
            var expectedUri = new Uri("https://localhost:7240/SourceExplorer");

            this.handlerMock!.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("[{\"id\":1,\"title\":\"test\",\"owner\":\"test\",\"type\":1,\"link\":\"test\"}]"),
                })
                .Verifiable();

            var result = await this.authService!.GetSources();
            var sourceList = result.ToList();

            Assert.That(sourceList, Is.Not.Null);
            Assert.That(sourceList, Has.Exactly(1).Items);
            this.handlerMock!.Protected().Verify("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public void GetSources_UnsuccessfulRequest_ThrowsException()
        {
            var expectedUri = new Uri("https://localhost:7240/SourceExplorer");

            this.handlerMock!.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent("..."),
                })
                .Verifiable();

            Assert.ThrowsAsync<Exception>(() => this.authService!.GetSources());

            this.handlerMock!.Protected().Verify("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public void GetSources_ExceptionThrown_ThrowsException()
        {
            var expectedUri = new Uri("https://localhost:7240/SourceExplorer");

            this.handlerMock!.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new Exception("Test exception"))
                .Verifiable();

            Assert.ThrowsAsync<Exception>(() => this.authService!.GetSources());

            this.handlerMock!.Protected().Verify("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public void GetSources_Unauthorized_ReturnsEmptyList()
        {
            var expectedUri = new Uri("https://localhost:7240/SourceExplorer");

            this.handlerMock!.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("..."),
                })
                .Verifiable();

            var result = this.authService!.GetSources().Result.ToList();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
            this.handlerMock!.Protected().Verify("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
        }
    }
}