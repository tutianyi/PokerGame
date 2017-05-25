using System.Threading.Tasks;
using NUnit.Framework;

namespace PokerGame.Test
{
    [TestFixture]
    public class PlayerTests
    {
        private Dealer dealer;
        private Player player;
        [SetUp]
        public void SetUp()
        {
            dealer = new Dealer();
            player = new Computer("A");
            player.TouchCards(dealer);
        }

        [Test]
        public void when_touch_5_cards()
        {
            Assert.AreEqual(5, player.Hands.Count);
            Assert.AreEqual(54 - 5, dealer.SurplusCount());

            Assert.AreEqual("A", player.Hands[0].Point);
            Assert.AreEqual("3", player.Hands[1].Point);
            Assert.AreEqual("2", player.Hands[2].Point);
            Assert.AreEqual("鬼", player.Hands[3].Point);
            Assert.AreEqual("鬼", player.Hands[4].Point);
        }

        [Test]
        public void candidate_show_cards()
        {
            var result = player.CandidateShowCards(new Single(new Card("红桃", "2")));
            Assert.AreEqual("2", result[1].Cards[0].Point);
            Assert.AreEqual("鬼", result[2].Cards[0].Point);
        }

        [Test]
        public void show_card()
        {
            player.ShowCard(new Single(player.Hands[0]));
            Assert.AreEqual(5 - 1, player.Hands.Count);
            Assert.AreEqual(1, player.CardHeap.Count);
        }

        [Test]
        public void to_string()
        {
            player.CardHeap.Add(Card.Null());
            player.CardHeap.Add(Card.Null());
            player.CardHeap.Add(Card.Null());
            player.CardHeap.Add(Card.Null());
            player.CardHeap.Add(Card.Null());

            string expected = "A: (5)\t黑桃A 黑桃3 黑桃2 大鬼 小鬼 ";
            Assert.AreEqual(expected, player.ToString());
        }
    }
}