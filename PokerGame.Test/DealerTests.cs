using NUnit.Framework;

namespace PokerGame.Test
{
    [TestFixture]
    public class DealerTests
    {
        [Test]
        public void deal_cards_when_not_shuffle()
        {
            var dealer = new Dealer();
            Assert.AreEqual(new Card("大", "鬼"), dealer.Deal());
            Assert.AreEqual(new Card("小", "鬼"), dealer.Deal());
            Assert.AreEqual(new Card("黑桃", "A"), dealer.Deal());
            for (int i = 0; i < 12; i++)
                dealer.Deal();
            Assert.AreEqual(new Card("红桃", "A"), dealer.Deal());
            for (int i = 0; i < 12; i++)
                dealer.Deal();
            Assert.AreEqual(new Card("梅花", "A"), dealer.Deal());
            for (int i = 0; i < 12; i++)
                dealer.Deal();
            Assert.AreEqual(new Card("方块", "A"), dealer.Deal());
        }

        [Test]
        public void deal_cards_after_shuffle()
        {
            int times = 10;
            while (times-- > 0)
            {
                var unShuffleDealer = new Dealer();
                var shuffledDealer = new Dealer();
                shuffledDealer.Shuffle();
                int countNotSame = 0;
                for (int i = 0; i < 54; i++)
                {
                    if (!unShuffleDealer.Deal().Equals(shuffledDealer.Deal()))
                        countNotSame++;
                }
                Assert.GreaterOrEqual(countNotSame, 36);
            }
        }

        [Test]
        public void when_deal_is_empty()
        {
            var dealer = new Dealer();
            Assert.False(dealer.Empty());
            for (int i = 0; i < 54; i++)
            {
                dealer.Deal();
            }
            Assert.True(dealer.Empty());
        }
    }
}