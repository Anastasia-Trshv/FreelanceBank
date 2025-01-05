using StackExchange.Redis;

namespace FreelanceBank.Services.Logger
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly string _connectionString;
        private ConnectionMultiplexer _redis;

        public LoggerProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new LoggerService(this, categoryName, GetDatabse());
        }

        public void Dispose()
        {
            _redis?.Dispose();
        }

        private IDatabase GetDatabse()
        {
            if (_redis == null || !_redis.IsConnected)
            {
                _redis = ConnectionMultiplexer.Connect(_connectionString);
            }
            return _redis.GetDatabase();
        }
    }
}
