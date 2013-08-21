using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestToStringAceOfSpades()
        {
            Card newCard = new Card(CardFace.Ace, CardSuit.Spades);
            string actual = newCard.ToString();

            Assert.AreEqual("A♠", actual);
        }

        [TestMethod]
        public void TestToStringTenOfClubs()
        {
            Card newCard = new Card(CardFace.Ten, CardSuit.Clubs);
            string actual = newCard.ToString();

            Assert.AreEqual("10♣", actual);
        }

        [TestMethod]
        public void TestToStringThreeOfHearths()
        {
            Card newCard = new Card(CardFace.Three, CardSuit.Hearts);
            string actual = newCard.ToString();

            Assert.AreEqual("3♥", actual);
        }

        [TestMethod]
        public void TestToStringQueenOfDiamonds()
        {
            Card newCard = new Card(CardFace.Queen, CardSuit.Diamonds);
            string actual = newCard.ToString();

            Assert.AreEqual("Q♦", actual);
        }
    }
}
