using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Common.Models
{
    public class SampleResponse : ISampleResponse
    {
        public string Response { get; set; }
    }
}
