using Day7;

namespace Day7Tests
{
    public class CardGameTests
    {
        [Fact]
        public void High_Card()
        {
            var hand = new Hand()
            {
                cards = "23456".ToCharArray(),
                points = 5
            };            

            Assert.Equal(hand.CheckHand(), Rank.HIGHCARD);
        }

        [Fact]
        public void One_Pair()
        {
            var hand = new Hand()
            {
                cards = "A23A4".ToCharArray(),
                points = 5
            };

            Assert.Equal(hand.CheckHand(), Rank.ONEPAIR);
        }

        [Fact]
        public void Two_Pair()
        {
            var hand = new Hand()
            {
                cards = "23432".ToCharArray(),
                points = 5
            };

            Assert.Equal(hand.CheckHand(), Rank.TWOPAIR);
        }

        [Fact]
        public void Three_Of_A_Kind()
        {
            var hand = new Hand()
            {
                cards = "TTT98".ToCharArray(),
                points = 5
            };

            Assert.Equal(hand.CheckHand(), Rank.THREEOFAKIND);
        }

        [Fact]
        public void Full_House()
        {
            var hand = new Hand()
            {
                cards = "23332".ToCharArray(),
                points = 5
            };

            Assert.Equal(hand.CheckHand(), Rank.FULLHOUSE);
        }

        [Fact]
        public void Four_Of_A_Kind()
        {
            var hand = new Hand()
            {
                cards = "AA8AA".ToCharArray(),
                points = 5
            };

            Assert.Equal(hand.CheckHand(), Rank.FOUROFAKIND);
        }

        [Fact]
        public void Five_Of_A_Kind()
        {
            var hand = new Hand()
            {
                cards = "AAAAA".ToCharArray(),
                points = 5
            };

            Assert.Equal(hand.CheckHand(), Rank.FIVEOFAKIND);
        }

        [Fact]
        public void Compare_By_Card_FULL_HOUSE()
        {
            var hand1 = new Hand()
            {
                cards = "AAAAA".ToCharArray(),
                points = 5,
                rank = Rank.FIVEOFAKIND
            };

            var hand2 = new Hand()
            {
                cards = "TTTTT".ToCharArray(),
                points = 5,
                rank = Rank.FIVEOFAKIND
            };

            Assert.Equal(-1, hand1.CompareTo(hand2));
            Assert.Equal(1, hand2.CompareTo(hand1));
            Assert.Equal(0, hand1.CompareTo(hand1));
        }

        [Fact]
        public void Compare_By_Card_ONE_PAIR()
        {
            var hand1 = new Hand()
            {
                cards = "5Q2AA".ToCharArray(),
                points = 5,
                rank = Rank.ONEPAIR
            };

            var hand2 = new Hand()
            {
                cards = "5Q8TT".ToCharArray(),
                points = 5,
                rank = Rank.ONEPAIR
            };

            Assert.Equal(1, hand1.CompareTo(hand2));
            Assert.Equal(-1, hand2.CompareTo(hand1));
            Assert.Equal(0, hand1.CompareTo(hand1));
        }

        [Fact]
        public void Compare_By_Rank()
        {
            var hand1 = new Hand()
            {
                cards = "522AA".ToCharArray(),
                points = 5,
                rank = Rank.TWOPAIR
            };

            var hand2 = new Hand()
            {
                cards = "5Q8TT".ToCharArray(),
                points = 5,
                rank = Rank.ONEPAIR
            };

            Assert.Equal(-1, hand1.CompareTo(hand2));
            Assert.Equal(1, hand2.CompareTo(hand1));
            Assert.Equal(0, hand1.CompareTo(hand1));
        }

        
        //[Fact]
        //public void Retrieve_Sum()
        //{
        //    var list = new List<string>()
        //    {
        //        "32T3K 765",
        //        "T55J5 684",
        //        "KK677 28",
        //        "KTJJT 220",
        //        "QQQJA 483"
        //    };

        //    var sut = new CardGame();

        //    var result = sut.TotalWinnings(list);

        //    Assert.Equal(6440, result);
        //}

        [Fact]
        public void Retrieve_Sum_With_Joker()
        {
            var list = new List<string>()
            {
                "32T3K 765",
                "T55J5 684",
                "KK677 28",
                "KTJJT 220",
                "QQQJA 483"
            };

            var sut = new CardGame();

            var result = sut.TotalWinnings(list);

            Assert.Equal(5905, result);
        }
    }
}