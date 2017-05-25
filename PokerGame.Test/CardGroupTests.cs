using System.Collections.Generic;
using NUnit.Framework;

namespace PokerGame.Test
{
    [TestFixture]
    public class CardGroupTests
    {
        private CardGroup big;
        private CardGroup little;
        
        [Test]
        public void when_up_rank_to_double()
        {
            big = new Single(new Card("黑桃", "7"))
                .UpRank(new Card("红桃", "7"));
            Assert.IsInstanceOf<Double>(big);
        }

        [Test]
        public void when_up_rank_to_little_bomb()
        {
            big = new Single(new Card("黑桃", "7"))
                .UpRank(new Card("红桃", "7"))
                .UpRank(new Card("梅花", "7"));
            Assert.IsInstanceOf<LittleBomb>(big);
        }

        [Test]
        public void when_up_rank_to_big_bomb()
        {
            big = new Single(new Card("黑桃", "7"))
                .UpRank(new Card("红桃", "7"))
                .UpRank(new Card("梅花", "7"))
                .UpRank(new Card("方块", "7"));
            Assert.IsInstanceOf<BigBomb>(big);
        }

        [Test]
        public void when_compare_single_with_single()
        {
            big = new Single(new Card("黑桃", "7"));
            little = new Single(new Card("黑桃", "10"));
            Assert.True(big >= little);
        }

        [Test]
        public void when_compare_little_bomb_with_little_bomb()
        {
            big = new Single(new Card("黑桃", "7"))
                .UpRank(new Card("红桃", "7"))
                .UpRank(new Card("梅花", "7"));
            little = new Single(new Card("黑桃", "4"))
                .UpRank(new Card("红桃", "4"))
                .UpRank(new Card("梅花", "4"));
            Assert.True(big >= little);
        }

        [Test]
        public void when_compare_double_with_single()
        {
            big = new Single(new Card("黑桃", "7"))
                .UpRank(new Card("红桃", "7"));
            little = new Single(new Card("黑桃", "4"));
            Assert.False(big >= little);
        }

        [Test]
        public void when_compare_little_bomb_with_single()
        {
            big = new Single(new Card("黑桃", "4"))
                .UpRank(new Card("红桃", "4"))
                .UpRank(new Card("梅花", "4"));
            little = new Single(new Card("黑桃", "7"));
            Assert.True(big >= little);
        }

        [Test]
        public void when_compare_little_bomb_with_double()
        {
            big = new Single(new Card("黑桃", "4"))
                .UpRank(new Card("红桃", "4"))
                .UpRank(new Card("梅花", "4"));
            little = new Single(new Card("黑桃", "7"))
                .UpRank(new Card("红桃", "7"));
            Assert.True(big >= little);
        }

        [Test]
        public void when_compare_big_bomb_with_little_bomb()
        {
            big = new Single(new Card("黑桃", "4"))
                .UpRank(new Card("红桃", "4"))
                .UpRank(new Card("梅花", "4"))
                .UpRank(new Card("方片", "4"));
            little = new Single(new Card("黑桃", "7"))
                .UpRank(new Card("红桃", "7"))
                .UpRank(new Card("梅花", "7"));
            Assert.True(big >= little);
        }
    }
}