
using System.Net.Sockets;
using System.Security.Principal;

namespace Day4
{
    public class Lotery
    {
        public List<int> GetWinningCardNumbers(string card)
        {
            var winningNumbers = new List<int>();
            var cardNumbers = new List<int>();

            var cardNumber = ProcessCard(card, out winningNumbers, out cardNumbers);

            var winningTicketNumbers = SearchWinningNumbers(winningNumbers,cardNumbers);
            return WonTicketCopies(winningTicketNumbers.Count(), cardNumber);
        }

        public int CheckWinningNumbers(string ticket)
        {
            var winningNumbers = new List<int>();
            var cardNumbers = new List<int>();

            ProcessCard(ticket, out winningNumbers, out cardNumbers);
            var winningTicketNumbers = SearchWinningNumbers(winningNumbers, cardNumbers);

            return CalculateScore(winningTicketNumbers);
        }

        private List<int> WonTicketCopies(int amountWonNumbers, int cardNumber)
        {
            if(amountWonNumbers == 0)
            {
                return new List<int>();
            }

            var numbers = WonTicketCopies(amountWonNumbers-1, cardNumber);
            numbers.Add(cardNumber+amountWonNumbers);

            return numbers;
        }

        private int ProcessCard(string ticket, out List<int> winningNumbers, out List<int> ticketNumbers)
        {
            var ticketParts = ticket.Split(':', '|');
            var cardNumber = ticketParts[0]
                .Replace("Card ", "")
                .Trim();

            winningNumbers = ticketParts[1]
                .Split(' ')
                .Where(n => !string.IsNullOrEmpty(n))
                .Select(n => int.Parse(n))
                .ToList();

            ticketNumbers = ticketParts[2]
                .Split(' ')
                .Where(n => !string.IsNullOrEmpty(n))
                .Select(n => int.Parse(n))
                .ToList();

            return int.Parse(cardNumber);
        }


        private List<int> SearchWinningNumbers(List<int> winningNumbers, List<int> ticketNumbers)
        {
            var result = new List<int>();

            foreach (int n in ticketNumbers)
            {
                if (winningNumbers.Contains(n))
                {
                    result.Add(n);
                }
            }

            return result;
        }

        private int CalculateScore(List<int> winningTicketNumbers)
        {
            if (winningTicketNumbers.Count == 0)
            {
                return 0;
            }

            var newList = new List<int>(winningTicketNumbers);
            newList.RemoveAt(0);
            var score = CalculateScore(newList);

            if (winningTicketNumbers.Count == 1)
            {
                return score + 1;
            }
            else
            {
                return score * 2;
            }

        }

        public Dictionary<int, int> GetAllMyCards(List<string> cards)
        {

            var result = new Dictionary<int, int>();
            foreach(var card in cards)
            {
                var winningNumbers = new List<int>();
                var currentCardNumbers = new List<int>();

                var cardNumber = ProcessCard(card, out winningNumbers, out currentCardNumbers);

                var newCardNumbers = GetWinningCardNumbers(card);

                if(!result.ContainsKey(cardNumber)) 
                {
                    result[cardNumber] = 0;
                }

                if (newCardNumbers.Any())
                {
                    for(var i = 1; i <= newCardNumbers.Count(); i++)
                    {
                       
                        if (!result.ContainsKey(cardNumber + i))
                        {
                            result[cardNumber + i] = 0;
                        }

                        if (result.ContainsKey(cardNumber))
                        {
                            result[cardNumber + i] = result[cardNumber + i] + result[cardNumber];
                        }

                        result[cardNumber + i] = result[cardNumber + i] + 1;
                    }
                }

                result[cardNumber] = result[cardNumber] + 1;

            }

            return result;

        }
    }
}
