using System.Text;

namespace Day15
{
    public class Hasher
    {
        public long currentValue(string input)
        {
            var listOfText = input.Split(",");

            var sums = new List<long>();
            foreach(var text in listOfText)
            {
                var numbers = ConvertToASCII(text);

                var currentValue = 0;
                foreach (var number in numbers)
                {
                    currentValue = currentValue + number;
                    currentValue = currentValue * 17;
                    currentValue = currentValue % 256;
                }

                sums.Add(currentValue);
            }


            return sums.Sum();

        }

        public int[] ConvertToASCII(string text)
        {
            return text.ToCharArray()
                .Select(c => (int) c)
                .ToArray();
        }
    }
}
