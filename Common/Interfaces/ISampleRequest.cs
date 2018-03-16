using System;

namespace Common.Interfaces
{
    public interface ISampleRequest
    {
        DateTime Timestamp { get; set; }
        string Request { get; set; }
        string RoutingKey { get; set; }
    }
}
