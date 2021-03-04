using System;

namespace Forecaster.Enums
{
    [Flags]
    public enum StatusType
    {
        Approved = 1,
        Pending = 2,
        Rejected = 3,
        Complete = 4
    }
}
