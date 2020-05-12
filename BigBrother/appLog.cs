using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BigBrother
{
    class appLog
    {
        public string name { get; set; }
        private Stopwatch stopwatch = new Stopwatch();
        public string time { get; private set; }
        public appLog(string newName) {
            name = newName;
            stopwatch.Start();
        }
        public void StartStopwatch() {
            if (stopwatch != null) stopwatch.Start();
        }
        public void StopStopwatch() {
            if(stopwatch!=null)stopwatch.Stop();
        }
        public double GetStopwatchTime() {
            return stopwatch.ElapsedMilliseconds;
        }
        public void makeTime() {
            time = (stopwatch.ElapsedMilliseconds / 1000).ToString();
        }
    }
}
