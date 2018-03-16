using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Common.Models
{
    public class SampleRequest :  ISampleRequest
    {
        public DateTime Timestamp { get; set; }
        public string Request { get; set; }
        public string RoutingKey { get; set; }
    }
}
