using Day4;
using FluentAssertions;
using System.Linq;

namespace Day4Tests
{

    public class LoteryTests
    {

        [Theory]
        [InlineData("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83")]
        public void Calculate_One_Point_When_One_Card_Number_Is_Part_Of_The_Winning_List(string ticket)
        {
            var sut = new Lotery();

            var response = sut.CheckWinningNumbers(ticket);

            response.Should().Be(1);
        }

        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8)]
        [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
        [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2)]
        public void Dubbel_The_Score_For_Every_Extra_Winning_Number(string ticket, int score)
        {
            var sut = new Lotery();

            var response = sut.CheckWinningNumbers(ticket);

            response.Should().Be(score);
        }

        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", new int[] { 2, 3, 4, 5 })]
        [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", new int[] { 3, 4 })]
        [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", new int[] { 4, 5 })]
        public void Retrieve_WinningNummers_For_Given_Card(string card, int[] results)
        {
            var sut = new Lotery();

            var response = sut.GetWinningCardNumbers(card);

            response.Should().BeEquivalentTo(results);
        }

        [Fact]
        public void Retrieve_Total_List_Won_Cards()
        {
            var cards = new List<string>()
            {
                "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
            };

            var expectedCards = new Dictionary<int, int>()
            {
                { 1 , 1 },
                { 2 , 2 },
                { 3 , 4 },
                { 4 , 8 },
                { 5 , 14 },
                { 6 , 1 },
            };

            var sut = new Lotery();

            var result = sut.GetAllMyCards(cards);

            result.Should().BeEquivalentTo(expectedCards);
        }
    }
}
