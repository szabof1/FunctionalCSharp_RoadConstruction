using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadConstruction
{
    class TrafficRecord
    {
        public DateTime inTime { get; private set; }
        public int journeyTimeSec { get; private set; }
        public char cityFrom { get; private set; }
        public DateTime outTime { get; set; } // set must be public

        public TrafficRecord()
        {
        }

        public TrafficRecord(string line)
        {
            load(line);
        }

        public void load(string line)
        {
            string[] values = line.Split(' ');
            inTime = new DateTime(1, 1, 1, int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
            journeyTimeSec = int.Parse(values[3]);
            cityFrom = values[4][0];
            calcOutTime(journeyTimeSec);
        }

        public int realJourneyTimeSec()
        {
            return (int)outTime.Subtract(inTime).TotalSeconds;
        }

        public double inSpeed()
        {
            return 1000.0 / journeyTimeSec;
        }

        public double outSpeed()
        {
            return 1000.0 / realJourneyTimeSec();
        }

        public void calcOutTime(int sec)
        {
            outTime = inTime.AddSeconds(sec);
        }

        public string inTimeTxt()
        {
            return inTime.ToString("HH mm ss");
        }

        public string outTimeTxt()
        {
            return outTime.ToString("HH mm ss");
        }

        public string getValuesAsTxt()
        {
            return string.Format("{0} {1} {2}", inTimeTxt(), + journeyTimeSec, + cityFrom);
        }

        public string cityToTxt()
        {
            string cityToStr = "Lower"; // 'U'
            if (cityFrom == 'L')
                cityToStr = "Upper";
            return cityToStr;
        }

        public string cityFromTxt()
        {
            string cityFromStr = "Lower"; // 'L'
            if (cityFrom == 'U')
                cityFromStr = "Upper";
            return cityFromStr;
        }

        static void adjustOutTime(TrafficRecord lastLine, TrafficRecord line)
        {
            if (lastLine == null) lastLine = line;
            else
            {
                if (line.outTime < lastLine.outTime)
                {
                    line.outTime = lastLine.outTime;
                }
                lastLine = line;
            }
        }

        public static void adjustOutTimeForOneDirection(List<TrafficRecord> trafficData)
        {
            TrafficRecord previousLine = null;
            trafficData.ForEach(line => TrafficRecord.adjustOutTime(previousLine, line));
        }
    }
}
