using EmployeeConsultApp.Core.Interfaces;
using EmployeeConsultApp.Core.Models;
using EmployeeConsultApp.Core.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace EmployeeConsultAppTests.Repository;

[TestFixture]
public class BaseRepositoryTests
{
    [SetUp]
    public void Setup()
    {
        _mockLogger = new Mock<ILogger<IRepository<EntityImpl>>>();
        _endpointUri = "http://www.TestURL.test/api/employee";
        _endpointOptions = new OptionsWrapper<Endpoint<EntityImpl>>(new Endpoint<EntityImpl>
        {
            Value = _endpointUri
        });
    }

    [TearDown]
    public void TearDown()
    {
        _mockLogger = null;
        _endpointOptions = null;
        _endpointUri = null;
    }

    private Mock<ILogger<IRepository<EntityImpl>>> _mockLogger;
    private IOptions<Endpoint<EntityImpl>> _endpointOptions;
    private string _endpointUri;

    [Test]
    public void TestConstructor_NullLogger()
    {
        ILogger<IRepository<EntityImpl>> logger = null;

        Assert.Multiple(() =>
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new RepoImpl(_endpointOptions, logger));
            StringAssert.Contains("logger", exception.Message);
        });
    }

    [Test]
    public void TestConstructor_NullOptions()
    {
        IOptions<Endpoint<EntityImpl>> options = null;

        Assert.Multiple(() =>
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new RepoImpl(options, _mockLogger.Object));
            StringAssert.Contains("endpoint", exception.Message);
        });
    }

    [Test]
    public void TestConstructor_ValidResult()
    {
        Assert.NotNull(() => new RepoImpl(_endpointOptions, _mockLogger.Object));
    }

    [Test]
    public void TestGetClient_NullUri()
    {
        var repo = new RepoImpl(_endpointOptions, _mockLogger.Object);

        Assert.Multiple(() =>
        {
            var exception = Assert.Throws<ArgumentNullException>(() => repo.CallGetClient(null));
            StringAssert.Contains("uri", exception.Message);
        });
    }

    [Test]
    public void TestGetClient_ValidUri()
    {
        var repo = new RepoImpl(_endpointOptions, _mockLogger.Object);

        var result = repo.CallGetClient(_endpointUri);

        Assert.Multiple(() =>
        {
            Assert.NotNull(result);
            StringAssert.AreEqualIgnoringCase(_endpointUri, result.BaseAddress.AbsoluteUri);
        });
    }

    public sealed class EntityImpl : IEntity
    {
    }

    public sealed class RepoImpl : BaseRepository<EntityImpl>
    {
        public RepoImpl(IOptions<Endpoint<EntityImpl>> endpoint, ILogger<IRepository<EntityImpl>> logger) : base(
            endpoint, logger)
        {
        }

        public HttpClient CallGetClient(string uri)
        {
            return GetClient(uri);
        }
    }
}