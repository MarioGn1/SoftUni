using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private readonly Stopwatch stopWhatch;
        private List<string> laps;

        public Chronometer()
        {
            this.stopWhatch = new Stopwatch();
            this.laps = new List<string>();
        }

        public string GetTime => ElapsedTime(this.stopWhatch);

        public List<string> Laps => this.laps;

        public string Lap()
        {
            string formatedLap = ElapsedTime(this.stopWhatch);
            this.laps.Add(formatedLap);
            return formatedLap;
        }

        public void Reset()
        {
            stopWhatch.Reset();
            laps = new List<string>();
        }

        public void Start()
        {
            stopWhatch.Start();
        }

        public void Stop()
        {
            stopWhatch.Stop();
        }

        private string ElapsedTime(Stopwatch stopwatch)
        {
            TimeSpan lap = stopWhatch.Elapsed;
            string formatedLap = $"{lap.Minutes:D2}:{lap.Seconds:D2}.{lap.Milliseconds:D4}";
            return formatedLap;
        }
    }
}
