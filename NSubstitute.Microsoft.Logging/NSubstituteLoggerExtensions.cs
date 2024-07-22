namespace NSubstitute.Microsoft.Logging;

/// <summary>
/// Extensions to check if <see cref="ILogger{TCategoryName}"/> received the specific calls
/// </summary>
public static class NSubstituteLoggerExtensions
{
    /// <summary>
    /// Verifies that any log contains the message
    /// </summary>
    /// <param name="logger">the logger <see cref="ILogger{TCategoryName}"/></param>
    /// <param name="message">a message to verify is in log</param>
    /// <param name="logLevel">a log level to check</param>
    /// <typeparam name="T">logger parameter type</typeparam>
    /// <returns><see cref="ILogger{TCategoryName}"/> for chaining</returns>
    /// <exception cref="ReceivedCallsException"></exception>
    public static ILogger<T> VerifyLogContains<T>(this ILogger<T> logger, string message, LogLevel? logLevel = null)
    {
        logger.Received()
            .Log(
                logLevel ?? Arg.Any<LogLevel>(),
                Arg.Any<EventId>(),
                Arg.Is<IReadOnlyList<KeyValuePair<string, object>>>(x => (x.ToString() ?? string.Empty).Contains(message)),
                Arg.Any<Exception>(),
                Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception?, string>>()
                );
        return logger;
    }
    
    /// <summary>
    /// Verifies that any debug log contains the message
    /// </summary>
    /// <param name="logger">the logger <see cref="ILogger{TCategoryName}"/></param>
    /// <param name="message">a message to verify is in log</param>
    /// <typeparam name="T">logger parameter type</typeparam>
    /// <returns><see cref="ILogger{TCategoryName}"/> for chaining</returns>
    /// <exception cref="ReceivedCallsException"></exception>
    public static ILogger<T> VerifyAtLeastOneDebugLogContains<T>(this ILogger<T> logger, string message)
    {
        return logger.VerifyLogContains(message, LogLevel.Debug);
    }

    /// <summary>
    /// Verifies that any information log contains the message
    /// </summary>
    /// <param name="logger">the logger <see cref="ILogger{TCategoryName}"/></param>
    /// <param name="message">a message to verify is in log</param>
    /// <typeparam name="T">logger parameter type</typeparam>
    /// <returns><see cref="ILogger{TCategoryName}"/> for chaining</returns>
    /// <exception cref="ReceivedCallsException"></exception>
    public static ILogger<T> VerifyAtLeastOneInformationLogContains<T>(this ILogger<T> logger, string message)
    {
        return logger.VerifyLogContains(message, LogLevel.Information);
    }
    
    /// <summary>
    /// Verifies that any warning log contains the message
    /// </summary>
    /// <param name="logger">the logger <see cref="ILogger{TCategoryName}"/></param>
    /// <param name="message">a message to verify is in log</param>
    /// <typeparam name="T">logger parameter type</typeparam>
    /// <returns><see cref="ILogger{TCategoryName}"/> for chaining</returns>
    /// <exception cref="ReceivedCallsException"></exception>
    public static ILogger<T> VerifyAtLeastOneWarningLogContains<T>(this ILogger<T> logger, string message)
    {
        return logger.VerifyLogContains(message, LogLevel.Warning);
    }
    
    /// <summary>
    /// Verifies that any error log contains the message
    /// </summary>
    /// <param name="logger">the logger <see cref="ILogger{TCategoryName}"/></param>
    /// <param name="message">a message to verify is in log</param>
    /// <typeparam name="T">logger parameter type</typeparam>
    /// <returns><see cref="ILogger{TCategoryName}"/> for chaining</returns>
    /// <exception cref="ReceivedCallsException"></exception>
    public static ILogger<T> VerifyAtLeastOneErrorLogContains<T>(this ILogger<T> logger, string message)
    {
        return logger.VerifyLogContains(message, LogLevel.Error);
    }

    /// <summary>
    /// Verifies that required number of logs contains the message
    /// </summary>
    /// <param name="logger">the logger <see cref="ILogger{TCategoryName}"/></param>
    /// <param name="message">a message to verify is in log</param>
    /// <param name="requiredNumberOfTimes"></param>
    /// <param name="logLevel">a log level to check</param>
    /// <typeparam name="T">logger parameter type</typeparam>
    /// <returns><see cref="ILogger{TCategoryName}"/> for chaining</returns>
    /// <exception cref="ReceivedCallsException"></exception>
    public static ILogger<T> VerifyLogContains<T>(this ILogger<T> logger, string message, int requiredNumberOfTimes, LogLevel? logLevel = null)
    {
        logger.Received(requiredNumberOfTimes)
            .Log(
                logLevel ?? Arg.Any<LogLevel>(),
                Arg.Any<EventId>(),
                Arg.Is<IReadOnlyList<KeyValuePair<string, object>>>(x => (x.ToString() ?? string.Empty).Contains(message)),
                Arg.Any<Exception>(),
                Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception?, string>>()
            );
        return logger;
    }

    /// <summary>
    /// Verifies that required number of debug logs contains the message
    /// </summary>
    /// <param name="logger">the logger <see cref="ILogger{TCategoryName}"/></param>
    /// <param name="message">a message to verify is in log</param>
    /// <param name="requiredNumberOfTimes">the required number of times to </param>
    /// <typeparam name="T">logger parameter type</typeparam>
    /// <returns><see cref="ILogger{TCategoryName}"/> for chaining</returns>
    /// <exception cref="ReceivedCallsException"></exception>
    public static ILogger<T> VerifyDebugLogContains<T>(this ILogger<T> logger, string message, int requiredNumberOfTimes)
    {
        return logger.VerifyLogContains(message,  requiredNumberOfTimes, LogLevel.Debug);
    }

    /// <summary>
    /// Verifies that required number of information logs contains the message
    /// </summary>
    /// <param name="logger">the logger <see cref="ILogger{TCategoryName}"/></param>
    /// <param name="message">a message to verify is in log</param>
    /// <typeparam name="T">logger parameter type</typeparam>
    /// <returns><see cref="ILogger{TCategoryName}"/> for chaining</returns>
    /// <exception cref="ReceivedCallsException"></exception>
    public static ILogger<T> VerifyInformationLogContains<T>(this ILogger<T> logger, string message, int requiredNumberOfTimes)
    {
        return logger.VerifyLogContains(message, requiredNumberOfTimes,  LogLevel.Information);
    }
    
    /// <summary>
    /// Verifies that required number of warning logs contains the message
    /// </summary>
    /// <param name="logger">the logger <see cref="ILogger{TCategoryName}"/></param>
    /// <param name="message">a message to verify is in log</param>
    /// <typeparam name="T">logger parameter type</typeparam>
    /// <returns><see cref="ILogger{TCategoryName}"/> for chaining</returns>
    /// <exception cref="ReceivedCallsException"></exception>
    public static ILogger<T> VerifyWarningLogContains<T>(this ILogger<T> logger, string message, int requiredNumberOfTimes)
    {
        return logger.VerifyLogContains(message, requiredNumberOfTimes, LogLevel.Warning);
    }
    
    /// <summary>
    /// Verifies that required number of error logs contains the message
    /// </summary>
    /// <param name="logger">the logger <see cref="ILogger{TCategoryName}"/></param>
    /// <param name="message">a message to verify is in log</param>
    /// <typeparam name="T">logger parameter type</typeparam>
    /// <returns><see cref="ILogger{TCategoryName}"/> for chaining</returns>
    /// <exception cref="ReceivedCallsException"></exception>
    public static ILogger<T> VerifyErrorLogContains<T>(this ILogger<T> logger, string message, int requiredNumberOfTimes)
    {
        return logger.VerifyLogContains(message, requiredNumberOfTimes, LogLevel.Error);
    }
}
