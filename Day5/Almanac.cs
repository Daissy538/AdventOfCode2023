using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Almanac
    {
        private Mapping mappings = new Mapping();
        private List<long> seeds = new List<long>();
        private List<Seed> seedRanges = new List<Seed>();

        public long ProcessFile2(List<string> data)
        {
            ProcessSeedRange(data[0]);
            
            ProcessMappings(data);

            var locations = new List<long>();
            foreach (var seed in seedRanges)
            {
                mappings.GetLocation(seed);
            }
            
            locations.Sort();

            return locations.First();
        }

        public long ProcessFile(List<string> data) {

            ProcessSeeds(data[0]);
            ProcessMappings(data);
            
            var locations = new List<long>();
            foreach(long seed in seeds)
            {
                locations.Add(mappings.GetLocation(seed));
            }

            locations.Sort();

            return locations.First();
        }

        private void ProcessSeeds(string stringSeeds) {
            var data = stringSeeds.Split(":").ToArray();
            seeds.AddRange(data[1].Split(" ")
                .Where(n => !string.IsNullOrEmpty(n))
                .Select(d => long.Parse(d)).ToList());
        }

        private void ProcessSeedRange(string stringSeeds)
        {
            var data = stringSeeds.Split(":").ToArray(); 
            var seedList = data[1].Split(" ")
                .Where(n => !string.IsNullOrEmpty(n))
                .Select(d => long.Parse(d)).ToList();

            for(var i = 0; i < seedList.Count()-1; i = i+2)
            {
                seedRanges.Add(new Seed()
                {
                    Start = seedList[i],
                    Length = seedList[i+1]
                });
            }
        }

        private void ProcessMappings(List<string> data)
        {
            var maps = new Dictionary<string, List<string>>();
            var mapTitle = "";
            for (var i = 1; i < data.Count; i++)
            {
                if (string.IsNullOrEmpty(data[i]))
                {
                    mapTitle = data[i + 1];
                    maps.Add(mapTitle, new List<string>());
                    i = i + 1;
                    continue;
                }

                var list = maps[mapTitle];
                list.Add(data[i]);

                maps[mapTitle] = list;
            }
            
            mappings.ReadSeedSoilMap(maps["seed-to-soil map:"]);
            mappings.ReadSoilFertMap(maps["soil-to-fertilizer map:"]);
            mappings.ReadFertWaterMap(maps["fertilizer-to-water map:"]);
            mappings.ReadWaterLigthMap(maps["water-to-light map:"]);
            mappings.ReadLigthTempMap(maps["light-to-temperature map:"]);
            mappings.ReadTempHumidMap(maps["temperature-to-humidity map:"]);
            mappings.ReadHumidLocationMap(maps["humidity-to-location map:"]);
        }
        
    }
}
