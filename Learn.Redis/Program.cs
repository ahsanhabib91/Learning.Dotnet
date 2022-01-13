using System;
using StackExchange.Redis;

namespace Learn.Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
            IDatabase db = redis.GetDatabase();
            var set = db.StringSet(
                "customerId", "My-Customer-Id", 
                TimeSpan.FromSeconds(10));
            Console.WriteLine(set);
            // var val = db.StringGet("age");
            // Console.WriteLine(val);
        }
    }
}