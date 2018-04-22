using System;
using StackExchange.Redis;

namespace Redis.Dao
{
    class RedisDao
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static RedisDao()
        {
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { "192.186.99.100:6379" }
            };

            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        public static IDatabase RedisCache => Connection.GetDatabase();
    }
}