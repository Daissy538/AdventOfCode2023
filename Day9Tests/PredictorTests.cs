using Day9;
using Xunit;

namespace Day9Tests
{
    public class PredictorTests
    {
        [Theory]
        [InlineData("0 3 6 9 12 15", 18)]
        [InlineData("1 3 6 10 15 21", 28)]
        [InlineData("10 13 16 21 30 45", 68)]
        public void Predict_Next_Number(string input, int prediction)
        {
            var sut = new Predictor();

            var result = sut.PredictNextAndHistoryNumber(input);

            Assert.Equal(prediction, result[1]);
        }

        [Fact]
        public void Sum_Of_All_Predictions()
        {
            var input = new List<string>()
            {
                "0 3 6 9 12 15",
                "1 3 6 10 15 21",
                "10 13 16 21 30 45"
            };

            var sut = new Predictor();

            var result = sut.TotalPredictionNumber(input);


            Assert.Equal(114, result);
        }

        [Theory]
        [InlineData("0 3 6 9 12 15", -3)]
        [InlineData("1 3 6 10 15 21", 0)]
        [InlineData("10 13 16 21 30 45", 5)]
        public void Look_Back_Number(string input, int prediction)
        {
            var sut = new Predictor();

            var result = sut.PredictNextAndHistoryNumber(input);

            Assert.Equal(prediction, result[0]);
        }
    }
}