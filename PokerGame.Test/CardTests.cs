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
            Assert.True(new Card("黑桃", "A") == new Card("黑桃", "A"));
        }

        [Test]
        public void compare_equal_with_not_same_color()
        {
            Assert.False(new Card("黑桃", "A") == new Card("红桃", "A"));
        }

        [Test]
        public void compare_equal_with_not_same_point()
        {
            Assert.False(new Card("黑桃", "A") == new Card("黑桃", "2"));
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
    }
}