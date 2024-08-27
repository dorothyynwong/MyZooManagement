using System;

namespace ZooManagement.Data
{
    public static class DateGenerator
    {
        private static readonly Random Random = new Random();
        private const int MaxCameAge = 3650;

        public static DateTime GetDateOfBirth()
        {
            var randomDaysAgo = Random.Next(1, MaxCameAge);
            return DateTime.Now.AddDays(-1 * (MaxCameAge + randomDaysAgo)).Date;
        }
        
        public static DateTime GetDateCameZoo()
        {
            var randomDaysAgo = Random.Next(1, MaxCameAge);
            return DateTime.Now.AddDays(-1 * randomDaysAgo).Date;
        }
    }
}
