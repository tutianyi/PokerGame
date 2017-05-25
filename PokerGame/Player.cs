using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            while(!dealer.Empty() && Hands.Count < 5)
                Hands.Add(dealer.Deal());
            Hands = Hands.OrderBy(x => x).ToList();
        }

        private IList<CardGroup> AllCardGroup()
        {
            IList<CardGroup> groups = new List<CardGroup>();
            foreach (var card in Hands)
            {
                if(groups.Count==0 || groups.Last().Cards[0]!=card)
                    groups.Add(new Single(card));
                else
                    groups.Add(groups.Last().UpRank(card));
            }
            return groups;
        }

        public IDictionary<int, CardGroup> CandidateShowCards(CardGroup againstCardGroup)
        {
            var dictionary = new Dictionary<int, CardGroup>();
            foreach (var group in AllCardGroup())
            {
                if(group >= againstCardGroup)
                    dictionary.Add(dictionary.Count+1, @group);
            }
            return dictionary;
        }

        public void ShowCard(CardGroup group)
        {
            foreach (var card in group.Cards)
            {
                Hands.Remove(card);
                CardHeap.Add(card);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}: ({1})\t", this.Name, this.CardHeap.Count);
            foreach (var card in Hands)
                sb.AppendFormat("{0} ", card.ToString());
            return sb.ToString();
        }
    }
}