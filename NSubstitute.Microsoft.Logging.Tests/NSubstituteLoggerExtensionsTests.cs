using Microsoft.Extensions.Logging;
using NSubstitute.Exceptions;

namespace NSubstitute.Microsoft.Logging.Tests;

[TestFixture]
public class NSubstituteLoggerExtensionsTests
{
    private ILogger<UtilityTest> _logger;
    private UtilityTest _utility;
    
    [SetUp]
    public void Setup()
    {
        _logger = Substitute.For<ILogger<UtilityTest>>();
        _utility = new UtilityTest(_logger);
    }
    
    [Test]
    public void VerifyAtLeastOneDebugLogContains_LogContainsMessage_ShouldVerifySuccessfully()
    {
        _utility.TestMethod();

        _logger.VerifyAtLeastOneDebugLogContains("DEBUG");
    }

    [Test]
    public void VerifyAtLeastOneInformationLogContains_LogContainsMessage_ShouldVerifySuccessfully()
    {
        _utility.TestMethod();

        _logger.VerifyAtLeastOneInformationLogContains("INFO");
    }
    
    [Test]
    public void VerifyAtLeastOneWarningLogContains_LogContainsMessage_ShouldVerifySuccessfully()
    {
        _utility.TestMethod();

        _logger.VerifyAtLeastOneWarningLogContains("WARNING");
    }

    [Test]
    public void VerifyAtLeastOneErrorLogContains_LogContainsMessage_ShouldVerifySuccessfully()
    {
        _utility.TestMethod();

        _logger.VerifyAtLeastOneErrorLogContains("ERROR");
    }
    
    [Test]
    public void VerifyAtLeastOneDebugLogContains_LogDoesNotContainsMessage_ShouldThrowException()
    {
        _utility.TestMethod();

        Assert.Throws<ReceivedCallsException>(() => _logger.VerifyAtLeastOneDebugLogContains("no message"));
    }

    [Test]
    public void VerifyAtLeastOneInformationLogContains_LogDoesNotContainsMessage_ShouldThrowException()
    {
        _utility.TestMethod();

        Assert.Throws<ReceivedCallsException>(() => _logger.VerifyAtLeastOneInformationLogContains("no message"));
    }
    
    [Test]
    public void VerifyAtLeastOneWarningLogContains_LogDoesNotContainsMessage_ShouldThrowException()
    {
        _utility.TestMethod();

        Assert.Throws<ReceivedCallsException>(() => _logger.VerifyAtLeastOneWarningLogContains("no message"));
    }

    [Test]
    public void VerifyAtLeastOneErrorLogContains_LogDoesNotContainsMessage_ShouldThrowException()
    {
        _utility.TestMethod();

        Assert.Throws<ReceivedCallsException>(() => _logger.VerifyAtLeastOneErrorLogContains("no message"));
    }

    [Test]
    public void VerifyDebugLogContains_VerifySpecificallyOne_ShouldBeSuccessful()
    {
        _utility.TestMethod();

        _logger.VerifyDebugLogContains("DEBUG", 1);
    }
    
    [Test]
    public void VerifyInformationLogContains_VerifySpecificallyOne_ShouldBeSuccessful()
    {
        _utility.TestMethod();

        _logger.VerifyInformationLogContains("INFO", 1);
    }
    
    [Test]
    public void VerifyWarningLogContains_VerifySpecificallyOne_ShouldBeSuccessful()
    {
        _utility.TestMethod();

        _logger.VerifyWarningLogContains("WARNING", 1);
    }
    
    [Test]
    public void VerifyErrorLogContains_VerifySpecificallyOne_ShouldBeSuccessful()
    {
        _utility.TestMethod();

        _logger.VerifyErrorLogContains("ERROR", 1);
    }
}