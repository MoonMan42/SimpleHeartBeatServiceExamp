using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleHeartBeatService
{
    public class HeartBeat
    {
        private readonly Timer timer;

        public HeartBeat()
        {
            timer = new Timer(1000) { AutoReset = true };
            timer.Elapsed += TimerElapsed;

        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { $"Heart beat at {DateTime.Now.ToString()}" };
            File.AppendAllLines(@"./HeartBeat.txt", lines);
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}
