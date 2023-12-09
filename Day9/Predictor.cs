namespace Day9
{
    public class Predictor
    {
        public int TotalPredictionNumber(List<string> input)
        {
            var predictions = new List<int>();
            foreach (var item in input)
            {
                predictions.Add(PredictNextAndHistoryNumber(item)[1]);
            }

            return predictions.Sum();
        }

        public int TotalHistoryNumber(List<string> input)
        {
            var predictions = new List<int>();
            foreach (var item in input)
            {
                predictions.Add(PredictNextAndHistoryNumber(item)[0]);
            }

            return predictions.Sum();
        }

        public int[] PredictNextAndHistoryNumber(string input)
        {
            var numbers = input.Split(' ')
                        .Select(n => int.Parse(n))
                        .ToList();

            var numberTree = new List<List<int>>
            {
                numbers
            };

            BuildTree(numberTree);

            AddPredictedNumber(numberTree);

            AddHistoricalNumber(numberTree);

            var historicNumber = numberTree[0][0];
            var predictedNumber = numberTree[0][numberTree[0].Count - 1];

            return [historicNumber, predictedNumber];
        }

        private void AddHistoricalNumber(List<List<int>> numberTree)
        {
            for (var i = numberTree.Count - 1; i > 0; i--)
            {
                var difference = numberTree[i][0];
                var prediction = numberTree[i - 1][0] - difference;

                numberTree[i - 1].Insert(0, prediction);
            }
        }

        private void AddPredictedNumber(List<List<int>> numberTree)
        {
            for (var i = numberTree.Count - 1; i > 0; i--)
            {
                var difference = numberTree[i][numberTree[i].Count - 1];
                var prediction = numberTree[i - 1][numberTree[i].Count - 1] + difference;

                numberTree[i - 1].Add(prediction);
            }
        }

        private void BuildTree(List<List<int>> numberTree)
        {
            for (var i = 0; i < numberTree.Count; i++)
            {
                if (numberTree[i].All(n => n == 0))
                {
                    break;
                }

                numberTree.Add(new List<int>());

                for (var j = 0; j < numberTree[i].Count - 1; j++)
                {
                    var difference = numberTree[i][j + 1] - numberTree[i][j];
                    numberTree[i + 1].Add(difference);
                }
            }
        }
    }
}
