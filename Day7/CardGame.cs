
namespace Day7
{
    public enum Rank
    {
        FIVEOFAKIND = 1,
        FOUROFAKIND =2,
        FULLHOUSE = 3,
        THREEOFAKIND = 4,
        TWOPAIR = 5,
        ONEPAIR = 6,
        HIGHCARD = 7,
        NONE = 8
    }

   public class Hand : IComparable<Hand>
    {
        private Dictionary<char, int> cardTable = new Dictionary<char, int>
        {
            { char.Parse("A"), 1},
            { char.Parse("K"), 2},
            { char.Parse("Q"), 3},        
            { char.Parse("T"), 4},
            { char.Parse("9"), 5},
            { char.Parse("8"), 6},
            { char.Parse("7"), 7},
            { char.Parse("6"), 8},
            { char.Parse("5"), 9},
            { char.Parse("4"), 10},
            { char.Parse("3"), 11},
            { char.Parse("2"), 12},
            { char.Parse("J"), 13},
        };

        public Rank rank {  get;  set; }
        public long points { get; set; }

        public char[] cards { get; set; }


        public Rank CheckHand()
        {
            var cardMapping = new Dictionary<char, int>();

            for (var i = 0; i < cards.Length; i++)
            {                
                if (cardMapping.ContainsKey(cards[i]))
                {
                    cardMapping[cards[i]]++;
                }
                else
                {
                    cardMapping.Add(cards[i], 1);
                }
            }

            var jokerChar = char.Parse("J");
           if (cardMapping.ContainsKey(jokerChar) && cardMapping.Count() > 1)
           {
                KeyValuePair<char, int>? highestKey = null;
                foreach (var map in cardMapping)
                {
                    if(highestKey == null && !map.Key.Equals(jokerChar))
                    {
                        highestKey = map;
                    }else if (map.Value > highestKey?.Value && !map.Key.Equals(jokerChar))
                    {
                        highestKey = map;
                    }
                }

                cardMapping[highestKey.Value.Key] = cardMapping[highestKey.Value.Key] + cardMapping[jokerChar];
                cardMapping.Remove(jokerChar);
           }

            if (cardMapping.All(c => c.Value == 1))
            {
                return Rank.HIGHCARD;
            }
            else if (cardMapping.Count(c => c.Value == 2) == 1 && cardMapping.Count(c => c.Value == 1) == 3)
            {
                return Rank.ONEPAIR;
            }
            else if (cardMapping.Where(c => c.Value == 2).Count() == 2 && cardMapping.Any(c => c.Value == 1))
            {
                return Rank.TWOPAIR;
            }
            else if (cardMapping.Any(c => c.Value == 3) && cardMapping.Where(c => c.Value == 1).Count() == 2)
            {
                return Rank.THREEOFAKIND;
            }
            else if (cardMapping.Any(c => c.Value == 3) && cardMapping.Any(c => c.Value == 2))
            {
                return Rank.FULLHOUSE;
            }
            else if (cardMapping.Any(s => s.Value == 4) && cardMapping.Any(c => c.Value == 1))
            {
                return Rank.FOUROFAKIND;
            }
            if (cardMapping.Any(c => c.Value == 5))
            {
                return Rank.FIVEOFAKIND;
            }

            return Rank.NONE;

        }

        public int CompareTo(Hand other)
        {
            if((long) rank > (long)other.rank)
            {
                return 1;
            }else if((long )rank < (long) other.rank)
            {
                return -1;
            }
            else
            {
               var comp = cardTable[cards[0]].CompareTo(cardTable[other.cards[0]]);

                if (comp != 0)
                {
                    return comp;
                }

                comp = cardTable[cards[1]].CompareTo(cardTable[other.cards[1]]);

                if (comp != 0)
                {
                    return comp;
                }

                comp = cardTable[cards[2]].CompareTo(cardTable[other.cards[2]]);

                if (comp != 0)
                {
                    return comp;
                }

                comp = cardTable[cards[3]].CompareTo(cardTable[other.cards[3]]);

                if (comp != 0)
                {
                    return comp;
                }

                return cardTable[cards[4]].CompareTo(cardTable[other.cards[4]]);
            }
        }
    }

    public class CardGame
    {
        public long TotalWinnings(List<string> data)
        {
            var handResults = new List<Hand>();

            foreach (string item in data)
            {
                var game = item.Split(" ");

                var hand = new Hand()
                {
                    cards = game[0].ToUpper().ToCharArray(),
                    points = long.Parse(game[1])
                };

                hand.rank = hand.CheckHand();

                handResults.Add(hand);
            }

           handResults
                .Sort((a,b) => -a.CompareTo(b));

            var sum = 0L;
            for (int i = 0; i < handResults.Count(); i++)
            {
                var rank = i + 1;
                var totalPoint = handResults[i].points * rank;
                sum += totalPoint;
            }

            return sum;
        }

    }
}
