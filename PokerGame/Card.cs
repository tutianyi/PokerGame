namespace PokerGame
{
    public class Card
    {
        public Card(string color, string point)
        {
            Color = color;
            Point = point;
        }

        public string Color { get; private set; }
        public string Point { get; private set; }

        public override string ToString()
        {
            return Color + Point;
        }
    }
}
