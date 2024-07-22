using Microsoft.Extensions.Logging;

namespace NSubstitute.Microsoft.Logging.Tests;

public class UtilityTest(ILogger<UtilityTest> logger)
{
    private ILogger<UtilityTest> _logger = logger;

    public void TestMethod()
    {
        _logger.LogDebug("DEBUG log");
        _logger.LogInformation("INFO log");
        _logger.LogWarning("WARNING log");
        _logger.LogError("ERROR log");
    }
}