namespace Day5
{
    public class Mapping
    {
        private readonly List<Map> SeedSoil = new List<Map>();
        private readonly List<Map> SoilFert = new List<Map>();
        private readonly List<Map> FertWater = new List<Map>();
        private readonly List<Map> WaterLigth = new List<Map>();
        private readonly List<Map> LigthTemp = new List<Map>();
        private readonly List<Map> TempHumid = new List<Map>();
        private readonly List<Map> HumidLocation = new List<Map>();

        public void ReadSeedSoilMap(List<string> maps)
        {
            var currentMap = new List<Map>();
            maps.ForEach(map =>
            {                
                var numbers = map.Split(" ")
                     .Where(n => !string.IsNullOrEmpty(n))
                .Select(n => long.Parse(n))           
                .ToArray();

                SeedSoil.Add(new Map()
                {
                    From = numbers[1],
                    To = numbers[0],
                    Length = numbers[2]
                });

            });

        }

        public void ReadSoilFertMap(List<string> maps)
        {
            var currentMap = new List<Map>();
            maps.ForEach(map =>
            {
                var numbers = map.Split(" ").Select(n => long.Parse(n)).ToArray();

                SoilFert.Add(new Map()
                {
                    From = numbers[1],
                    To = numbers[0],
                    Length = numbers[2]
                });

            });

        }

        public void ReadFertWaterMap(List<string> maps)
        {
            var currentMap = new List<Map>();
            maps.ForEach(map =>
            {
                var numbers = map.Split(" ").Select(n => long.Parse(n)).ToArray();

                FertWater.Add(new Map()
                {
                    From = numbers[1],
                    To = numbers[0],
                    Length = numbers[2]
                });

            });

        }

        public void ReadWaterLigthMap(List<string> maps)
        {
            var currentMap = new List<Map>();
            maps.ForEach(map =>
            {
                var numbers = map.Split(" ").Select(n => long.Parse(n)).ToArray();

                WaterLigth.Add(new Map()
                {
                    From = numbers[1],
                    To = numbers[0],
                    Length = numbers[2]
                });

            });

        }

        public void ReadLigthTempMap(List<string> maps)
        {
            var currentMap = new List<Map>();
            maps.ForEach(map =>
            {
                var numbers = map.Split(" ").Select(n => long.Parse(n)).ToArray();

                LigthTemp.Add(new Map()
                {
                    From = numbers[1],
                    To = numbers[0],
                    Length = numbers[2]
                });

            });

        }

        public void ReadTempHumidMap(List<string> maps)
        {
            var currentMap = new List<Map>();
            maps.ForEach(map =>
            {
                var numbers = map.Split(" ").Select(n => long.Parse(n)).ToArray();

                TempHumid.Add(new Map()
                {
                    From = numbers[1],
                    To = numbers[0],
                    Length = numbers[2]
                });

            });

        }

        public void ReadHumidLocationMap(List<string> maps)
        {
            var currentMap = new List<Map>();
            maps.ForEach(map =>
            {
                var numbers = map.Split(" ").Select(n => long.Parse(n)).ToArray();

                HumidLocation.Add(new Map()
                {
                    From = numbers[1],
                    To = numbers[0],
                    Length = numbers[2]
                });

            });

        }

        public long GetLocation(long seed)
        {

            var soil = GetMappedVaule(SeedSoil, seed);

            var fert = GetMappedVaule(SoilFert, soil);

            var water = GetMappedVaule(FertWater, fert);

            var ligth = GetMappedVaule(WaterLigth, water);

            var temp = GetMappedVaule(LigthTemp, ligth);

            var humid = GetMappedVaule(TempHumid, temp);

            var location = GetMappedVaule(HumidLocation, humid);

            return location;
        }

        private long GetMappedVaule(List<Map> mapping, long number)
        {
            foreach (var map in mapping)
            {
                if (map.From <= number && map.From + map.Length >= number) {
                    var difference = number - map.From;
                    return map.To + difference;
                }                
            }

            return number;
        }

    }
}
