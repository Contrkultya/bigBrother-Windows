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
        public string date { get; private set; }
        public string uid { get; set; }
        public appLog(string newName, string newUid) {
            name = newName;
            date = DateTime.Now.ToShortDateString();
            stopwatch.Start();
            uid = newUid;
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
