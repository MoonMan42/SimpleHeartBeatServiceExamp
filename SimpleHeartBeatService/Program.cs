using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace SimpleHeartBeatService
{
    class Program
    {
        static void Main(string[] args)
        {
            // downloaded Topshelf nuget package and using it to setup a service to run in the background.
            // Youtube demo - Tim Corey
            //https://www.youtube.com/watch?v=y64L-3HKuP0

            var exitCode = HostFactory.Run(x =>
            {
                x.Service<HeartBeat>(s =>
                {
                    s.ConstructUsing(heartbeat => new HeartBeat());
                    s.WhenStarted(heartbeat => heartbeat.Start());
                    s.WhenStopped(heartbeat => heartbeat.Stop());
                });

                x.RunAsLocalSystem();
                x.SetServiceName("HeartbeatService");
                x.SetDisplayName("Heart Beat");
                x.SetDescription("Records the heartbeat every second");
            });

            int exitCodeVal = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeVal;
        }
    }
}
