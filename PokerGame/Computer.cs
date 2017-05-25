namespace PokerGame
{
    public class Computer : Player
    {
        public Computer(string name) : base(name)
        {
        }

        public override CardGroup Follow(CardGroup againstCard)
        {
            var group = CandidateShowCards(againstCard)[1];
            ShowCard(group);
            return group;
        }
    }
}