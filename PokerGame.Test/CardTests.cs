using System;
using NUnit.Framework;

namespace PokerGame.Test
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void compare_equal_with_equal_card()
        {
            Assert.True(new Card("黑桃", "A").Equals(new Card("黑桃", "A")));
        }

        [Test]
        public void compare_equal_with_not_same_color()
        {
            Assert.False(new Card("黑桃", "A").Equals(new Card("红桃", "A")));
        }

        [Test]
        public void compare_equal_with_not_same_point()
        {
            Assert.False(new Card("黑桃", "A").Equals(new Card("黑桃", "2")));
        }

        [Test]
        public void compare_equal_with_not_card_type()
        {
            Assert.Catch<ArgumentException>(() => new Card("", "").Equals(new object()));
        }

        [Test]
        public void to_string()
        {
            Assert.AreEqual("黑桃A", new Card("黑桃", "A").ToString());
        }

        [Test]
        public void dictionary()
        {
            Assert.Greater(Card.Dics["7"], Card.Dics["鬼"]);
            Assert.Greater(Card.Dics["鬼"], Card.Dics["5"]);
            Assert.Greater(Card.Dics["5"], Card.Dics["2"]);
            Assert.Greater(Card.Dics["2"], Card.Dics["3"]);
            Assert.Greater(Card.Dics["3"], Card.Dics["A"]);
            Assert.Greater(Card.Dics["A"], Card.Dics["K"]);
            Assert.Greater(Card.Dics["K"], Card.Dics["Q"]);
            Assert.Greater(Card.Dics["Q"], Card.Dics["J"]);
            Assert.Greater(Card.Dics["J"], Card.Dics["10"]);
            Assert.Greater(Card.Dics["10"], Card.Dics["9"]);
            Assert.Greater(Card.Dics["9"], Card.Dics["8"]);
            Assert.Greater(Card.Dics["8"], Card.Dics["6"]);
            Assert.Greater(Card.Dics["6"], Card.Dics["4"]);
        }

        [Test]
        public void equal()
        {
            Assert.True(new Card("黑桃", "7") == new Card("红桃", "7"));
            Assert.False(new Card("黑桃", "4") == new Card("黑桃", "7"));
        }

        [Test]
        public void not_equal()
        {
            Assert.False(new Card("黑桃", "7") != new Card("红桃", "7"));
            Assert.True(new Card("黑桃", "4") != new Card("黑桃", "7"));
        }

        [Test]
        public void greater()
        {
            Assert.True(new Card("黑桃", "7") > new Card("黑桃", "4"));
            Assert.False(new Card("黑桃", "7") > new Card("红桃", "7"));
            Assert.False(new Card("黑桃", "4") > new Card("黑桃", "7"));
        }

        [Test]
        public void less()
        {
            Assert.False(new Card("黑桃", "7") < new Card("黑桃", "4"));
            Assert.False(new Card("黑桃", "7") < new Card("红桃", "7"));
            Assert.True(new Card("黑桃", "4") < new Card("黑桃", "7"));
        }

        [Test]
        public void greater_and_equal()
        {
            Assert.True(new Card("黑桃", "7") >= new Card("黑桃", "4"));
            Assert.True(new Card("黑桃", "7") >= new Card("红桃", "7"));
            Assert.False(new Card("黑桃", "4") >= new Card("黑桃", "7"));
        }

        [Test]
        public void less_and_equal()
        {
            Assert.False(new Card("黑桃", "7") <= new Card("黑桃", "4"));
            Assert.True(new Card("黑桃", "7") <= new Card("红桃", "7"));
            Assert.True(new Card("黑桃", "4") <= new Card("黑桃", "7"));
        }

        [Test]
        public void compare_to()
        {
            Assert.AreEqual(1, new Card("黑桃", "7").CompareTo(new Card("黑桃", "4")));
            Assert.AreEqual(-1, new Card("黑桃", "4").CompareTo(new Card("黑桃", "7")));
            Assert.AreEqual(0, new Card("黑桃", "7").CompareTo(new Card("红桃", "7")));
        }
    }
}