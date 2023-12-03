namespace Day3
{
    public class Engine
    {
        public long[] CalGearRatio(string currentLine, string? previousLine, string? nextLine)
        {
            var totals = new List<long>();
            for (var i = 0; i < currentLine.Length; i++)
            {
                var numbers = new List<long>();

                if (!currentLine[i].ToString().Equals("*")) continue;

                var digitLeft = HasDigit(currentLine, i-1);
                if (digitLeft != null)
                {
                    numbers.Add(SearchForDigitInLine(currentLine, i-1));
                }

                var digitRigth = HasDigit(currentLine, i+1);

                if (digitRigth != null)
                {
                    numbers.Add(SearchForDigitInLine(currentLine, i+1));
                }

                for (var j = i-1; previousLine != null && j < previousLine.Length && j <= i+1; j++)
                {

                    var digit = HasDigit(previousLine, j);

                    if (digit != null)
                    {
                        numbers.Add(SearchForDigitInLine(previousLine, j));

                        if (!(j+1 > previousLine.Length) && char.IsDigit(previousLine[j + 1]))
                        {
                            break;
                        }
                    }
                    
                }

                for (var j = i-1; nextLine != null && j < nextLine.Length && j <= i + 1; j++)
                {
                    var digit = HasDigit(nextLine, j);

                    if (digit != null)
                    {
                        numbers.Add(SearchForDigitInLine(nextLine, j));
                        if (!(j + 1 > nextLine.Length) && char.IsDigit(nextLine[j + 1]))
                        {
                            break;
                        }
                    }
                }

                if (numbers.Count() != 2)
                {
                    numbers.Clear();
                    continue;
                }

                totals.Add(numbers.Aggregate((x, y) => x * y));
                numbers.Clear();
            }

            return totals.ToArray();
        }

        public int[] RetrieveValidPartNumbers(string currentLine, string? previousLine, string? nextLine)
        {
            var lineInChars = currentLine.ToCharArray();

            var numbers = new List<int>();
            for (var i=0; i < lineInChars.Length; i++)
            {
                if (!char.IsDigit(lineInChars[i])) continue;

                var number = "";
                var hasSuroundingSymbol = false;

                for(var j=i-1; j < lineInChars.Length; j++)
                {
                    if(j < 0) continue;

                    if (HasSymbol(currentLine, j) != null 
                        || HasSymbol(previousLine, j) != null 
                        || HasSymbol(nextLine, j) != null)
                    {
                        hasSuroundingSymbol = true;
                    }

                    if (char.IsDigit(lineInChars[j]))
                    {
                        number += lineInChars[j];
                    }

                    if ((!string.IsNullOrEmpty(number) && !char.IsDigit(lineInChars[j])) || j+1 >= lineInChars.Length)
                    {
                        i = j;
                        break;
                    }
                }

                if (hasSuroundingSymbol) numbers.Add(Int32.Parse(number));
                
                number = "";
                hasSuroundingSymbol = false;                
            }
            
            return [.. numbers];
        }

        private string? HasSymbol(string? line, int index)
        {
            if(!string.IsNullOrEmpty(line)
                        && index >= 0
                        && index < line.Length
                        && !char.IsLetterOrDigit(line[index])
                        && !line[index].ToString().Equals("."))
            {
                return line[index].ToString();
            }
            else
            {
                return null;
            }
        }

        private string? HasDigit(string? line, int index)
        {
            if (!string.IsNullOrEmpty(line)
                        && index < line.Length
                        && index > 0
                        && char.IsLetterOrDigit(line[index]))
            {
                return line[index].ToString();
            }
            else
            {
                return null;
            }
        }

        private long SearchForDigitInLine(string line, int index)
        {
            var number = line[index].ToString();

            for(var i = index + 1; i < line.Length; i++)
            {
                if (!char.IsDigit(line[i])) break;

                number = number + line[i].ToString();
            }

            for (var i = index - 1; i >= 0; i--)
            {
                if (!char.IsDigit(line[i])) break;

                number =  line[i].ToString()+ number;
            }

            return long.Parse(number);
        }
    }
}
