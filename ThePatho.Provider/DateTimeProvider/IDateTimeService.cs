using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Provider.DateTimeProvider
{
    public interface IDateTimeService
    {
        DateTimeOffset UtcNow { get; }
        DateTime UtcDateTimeNow { get; }
        DateOnly UtcDate { get; }
        DateTimeOffset ServerNow { get; }
        DateTime ServerDateTimeNow { get; }
        DateOnly ServerDate { get; }
    }
}
