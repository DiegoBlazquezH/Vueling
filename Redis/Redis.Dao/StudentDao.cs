using Redis.Common.Models;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace Redis.Dao
{
    public class StudentDao
    {
        private StackExchangeRedisCacheClient cacheClient;

        public StudentDao()
        {
            var serializer = new NewtonsoftSerializer();

            var redisConfiguration = new RedisConfiguration()
            {
                AbortOnConnectFail = true,
                KeyPrefix = "",
                Hosts = new RedisHost[] { new RedisHost() { Host = "192.168.99.100", Port = 6379 } },
                ConnectTimeout = 3000,
                Database = 0
            };
            cacheClient = new StackExchangeRedisCacheClient(serializer, redisConfiguration);
        }

        public Student Read(string key)
        {
            return cacheClient.Get<Student>(key);
        }

        public bool Save(string key, Student student)
        {
            return cacheClient.Add<Student>(key, student);
        }
    }
}
