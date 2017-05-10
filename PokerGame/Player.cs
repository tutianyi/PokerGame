using System.Collections.Generic;
using System.Linq;

namespace PokerGame
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Hands = new List<Card>();
            CardHeap = new List<Card>();
        }

        public string Name { get; private set; }
        public IList<Card> Hands { get; private set; }
        public IList<Card> CardHeap { get; private set; }

        public void TouchCards(Dealer dealer)
        {
            Hands.Add(dealer.Deal());
            Hands = Hands.OrderBy(x => x).ToList();
        }

        public IDictionary<int, Card> CandidateShowCards(Card needGreateAndEqualThanCard)
        {
            var dictionary = new Dictionary<int, Card>();
            foreach (var card in Hands)
            {
                if(card >= needGreateAndEqualThanCard)
                    dictionary.Add(dictionary.Count+1, card);
            }
            return dictionary;
        }

        public void ShowCard(Card card)
        {
            Hands.Remove(card);
            CardHeap.Add(card);
        }
    }
}