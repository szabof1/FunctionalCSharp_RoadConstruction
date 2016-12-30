using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace RoadConstruction
{
    class Program
    {
        static void Main(string[] args)
        {
            // #1
            Console.WriteLine("#1 Reading traffic data from text file");
            var trafficData = File.ReadAllLines(".\\..\\..\\..\\traffic.txt")
                .Skip(1) // Skip first line that contains the number of records
                .Select(line => new TrafficRecord(line))
                .ToList();
            var trafficDataLower = trafficData.Where(line => line.cityFrom == 'L').ToList<TrafficRecord>();
            var trafficDataUpper = trafficData.Where(line => line.cityFrom == 'U').ToList<TrafficRecord>();

            // #1 / Calculating real out times
            Console.WriteLine("#1 Calculating real out times when cars leave the road-section under construction");
            adjustOutTimeForOneDirection(trafficDataLower);
            adjustOutTimeForOneDirection(trafficDataUpper);

            waitForEnterThenGoOn("\nPress Enter to continue");


            // #2
            Console.WriteLine("\n#2 What city was the \'n\'th car (reaching the restricted route-section) going toward?");
            Console.Write("2. Please, provide the (sequential / ordinal) number of the car (n, blank => 1): ");
            string numberEntered = Console.ReadLine();
            int n = int.Parse((numberEntered.Trim() == "") ? "1" : numberEntered);
            Console.WriteLine("2. The #{0} car reaching the restricted route-section was going toward \'{1}\' city.", n, trafficData[n - 1].cityToTxt());

            waitForEnterThenGoOn("\nPress Enter to continue");


            // #3
            Console.WriteLine("\n#3 What was the difference of the entering time (when reaching the road-section) in seconds of the last two cars going toward \'Upper\' city?");
            var last2Lower = trafficDataLower
                .OrderByDescending(line => line.inTime)
                .Take(2).ToList();
            Console.WriteLine("3. The last two cars going toward \'Upper\' city had {0} seconds time difference when reaching the road-section.", (last2Lower.ElementAt(0).inTime - last2Lower.ElementAt(1).inTime).TotalSeconds);

            waitForEnterThenGoOn("\nPress Enter to continue");


            // #4
            Console.WriteLine("\n#4 Show the sum of cars in both direction by hours (hour, fromLower, fromUpper)");
            Console.WriteLine("4. The sum of cars in both direction by hours (hour, fromLower, fromUpper):");
            var statisticsLower = trafficDataLower
                .Select(line => new { inHour = line.inTime.Hour })
                .GroupBy(line => line.inHour)
                .Select(grp => new { inHour = grp.Key, countLower = grp.Count(), countUpper = 0 })
                .ToList();
            var statisticsUpper = trafficDataUpper
                .Select(line => new { inHour = line.inTime.Hour })
                .GroupBy(line => line.inHour)
                .Select(grp => new { inHour = grp.Key, countLower = 0, countUpper = grp.Count() })
                .ToList();
            //
            // Merge the two lists together by key 'inHour':
            var statistics = statisticsLower.Concat(statisticsUpper)
                .ToLookup(line => line.inHour)
                .Select(g => g.Aggregate((s1, s2) => new
                {
                    inHour = s1.inHour,
                    countLower = s1.countLower + s2.countLower,
                    countUpper = s1.countUpper + s2.countUpper
                }))
                .ToList();
            statistics.ForEach(line => Console.WriteLine("=> {0:#0} {1:#,##0} {2:#,##0}", line.inHour, line.countLower, line.countUpper));

            waitForEnterThenGoOn("\nPress Enter to continue");


            // #5
            Console.WriteLine("\n#5 Show the 10 fastest cars regarding their speed when reaching the road-section");
            Console.WriteLine("5. The 10 fastest cars regarding their speed when reaching the road-section:");
            var fastest10 = trafficData
                .OrderBy(line => line.journeyTimeSec)
                .Take(10)
                .ToList();
            fastest10.ForEach(line => Console.WriteLine("{0} {1,-5} {2,5:#.0}", line.inTimeTxt(), line.cityToTxt(), line.inSpeed()));

            waitForEnterThenGoOn("\nPress Enter to continue");


            // #6
            Console.WriteLine("\n#6 Write the out the \'out\' time (when leaving the road-section) of all the cars going toward \'Lower\' city (hours minutes seconds)");
            using (StreamWriter writeFile = new StreamWriter(".\\..\\..\\..\\lower.txt"))
            {
                trafficDataUpper.ForEach(line => writeFile.WriteLine(line.outTimeTxt()));
            }


            // Finished
            waitForEnterThenGoOn("\nFinished\n\nPress Enter to quit");
        }

        static void waitForEnterThenGoOn(string textToConsole)
        {
            Console.WriteLine(textToConsole);
            Console.ReadLine();
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

        static void adjustOutTimeForOneDirection(List<TrafficRecord> trafficData)
        {
            TrafficRecord previousLine = null;
            trafficData.ForEach(line => adjustOutTime(previousLine, line));
        }
    }
}
