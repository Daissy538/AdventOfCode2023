

namespace Day6
{
    public class BootRace
    {
        public long AmountOfWaysToWin(long time, long distance)
        {
            List<long> options = new List<long>();
            for (int millisec = 0; millisec <= time; millisec++)
            {
                var speed = HoldTeButton(millisec);
                var totalDistance = (time - millisec) * speed;
                if(totalDistance > distance) {
                    options.Add(totalDistance);
                }
            }

            return options.Count;
        }

        public long HoldTeButton(long time)
        {
            return time;
        }
    }
}
