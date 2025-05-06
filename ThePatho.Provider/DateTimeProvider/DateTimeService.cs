using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Provider.DateTimeProvider
{
    public sealed class DateTimeService : IDateTimeService
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

        public DateOnly UtcDate => DateOnly.FromDateTime(UtcDateTimeNow);

        public DateTimeOffset ServerNow => DateTimeOffset.Now;

        public DateOnly ServerDate => DateOnly.FromDateTime(ServerDateTimeNow);

        public DateTime UtcDateTimeNow => UtcNow.UtcDateTime;

        public DateTime ServerDateTimeNow => ServerNow.UtcDateTime;
    }
}
