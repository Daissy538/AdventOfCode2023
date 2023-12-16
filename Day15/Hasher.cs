using System.Text;

namespace Day15
{
    public class Lens : IEquatable<Lens>
    {
        public string Name { get; set; }
        public int Focus { get; set; }

        public bool Equals(Lens other)
        {
            return Name.Equals(other.Name);
        }

        public bool Equals(string other)
        {
            return Name.Equals(other);
        }

        public override string ToString()
        {
            return $"[{Name} {Focus}]";
        }
    }

    public class Hasher
    {
        private readonly Dictionary<int, LinkedList<Lens>> boxes = new Dictionary<int, LinkedList<Lens>>();

        public Hasher()
        {
        }

        public int CurrentValue(string input)
        {
            var listOfText = input.Split(",");

            var sums = new List<int>();
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

        public Dictionary<int, LinkedList<Lens>> ChangeBoxValue(string text)
        {
            var hasEquals = text.Contains("=");

            if(hasEquals)
            {
                var lensAndValue = text.Split("=");
                var lens = new Lens()
                {
                    Name = lensAndValue[0],
                    Focus = int.Parse(lensAndValue[1])
                };

                var box = FindBox(lens.Name);

                var foundLens = box.Find(lens);

                if (foundLens == null)
                {
                    box.AddLast(lens);
                }
                else
                {
                    foundLens.Value = lens;
                }          
            }
            else
            {
                var lensAndValue = text.Split("-");
                var lens = new Lens()
                {
                    Name = lensAndValue[0]
                };

                var box = FindBox(lens.Name);
                var foundLens = box.Find(lens);

                if (foundLens != null)
                {
                    box.Remove(lens);
                }

            }

            return boxes;
        }

        private LinkedList<Lens> FindBox(string label)
        {
            var key = CurrentValue(label);
            if (!boxes.ContainsKey(key))
            {
               boxes.Add(key, new LinkedList<Lens>());
            }

            return boxes[key];
        }

        public Dictionary<int, LinkedList<Lens>> LoadBoxInstructions(string input)
        {
            var listOfText = input.Split(",");
            foreach (var text in listOfText)
            {
                ChangeBoxValue(text);
                Console.WriteLine($"After {text}");
                PrintBoxes();
                Console.WriteLine();
            }

            return boxes;
        }

        public int CalculateTotalSumOfPowers()
        {
            var sum = 0;
            foreach(var box in boxes)
            {
                sum = sum + CalculateFocusPowerBox(box.Key, box.Value);
            }

            return sum;
        }

        public int CalculateFocusPowerBox(int boxNumber, LinkedList<Lens> box)
        {

            var totals = new List<int>();
            for (int i = 0; i < box.Count; i++)
            {
                var slot = i + 1;
                var boxFocus = (1 + boxNumber) * slot * box.ToList()[i].Focus;
                totals.Add(boxFocus);
            }

            return totals.Sum();
        }

        private void PrintBoxes()
        {
            foreach (var key in boxes.Keys)
            {
                var box = boxes[key];

                if(box.Count == 0)
                {
                    continue;
                }

                var stringBuilder = new StringBuilder();

                foreach(var Lens in box)
                {
                    stringBuilder.Append(Lens.ToString());
                }

                Console.WriteLine($"Box {key}: {stringBuilder.ToString()}" );
            }
        }
    }
}
