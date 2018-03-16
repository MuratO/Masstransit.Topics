using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Helpers;
using Common.Interfaces;
using GreenPipes;
using log4net.Config;
using MassTransit;
using MassTransit.Context;
using MassTransit.Log4NetIntegration.Logging;

namespace Consumer
{
        class Program
        {
            static void Main()
            {
                var busControl = new BusInstance().CreateBus();
            
                busControl.Start();
        }
        
        }
 }

