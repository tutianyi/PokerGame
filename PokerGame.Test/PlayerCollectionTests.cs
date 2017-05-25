using NUnit.Framework;

namespace PokerGame.Test
{
    [TestFixture]
    public class PlayerCollectionTests
    {
        private PlayerCollection players;
        private Player playerA;
        private Player playerB;
        private Player playerC;

        [SetUp]
        public void SetUp()
        {
            playerA = new Computer("A");
            playerB = new Computer("B");
            playerC = new Computer("C");
            players = new PlayerCollection(playerA, playerB, playerC);
        }

        [Test]
        public void test_iterator_when_A_play_first()
        {
            string actual = "";
            players.Next = playerA;
            foreach (var player in players)
            {
                actual += player.Name;
            }
            Assert.AreEqual("ABC", actual);
        }

        [Test]
        public void test_iterator_when_B_play_first()
        {
            string actual = "";
            players.Next = playerB;
            foreach (var player in players)
            {
                actual += player.Name;
            }
            Assert.AreEqual("BCA", actual);
        }

        [Test]
        public void test_iterator_when_C_play_first()
        {
            string actual = "";
            players.Next = playerC;
            foreach (var player in players)
            {
                actual += player.Name;
            }
            Assert.AreEqual("CAB", actual);
        }
    }
}