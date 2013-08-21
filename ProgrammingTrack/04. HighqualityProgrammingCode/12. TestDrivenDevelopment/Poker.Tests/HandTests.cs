using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void TestToStringRolyalFrushSpades()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.Jack, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);
            string actual = newHand.ToString();

            Assert.AreEqual("A♠ K♠ Q♠ J♠ 10♠", actual);
        }

        public void TestToStringJustSomeCards()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Hearts),
                    new Card(CardFace.Nine, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Clubs)
                };


            Hand newHand = new Hand(allCardsInHand);
            string actual = newHand.ToString();

            Assert.AreEqual("2♠ Q♥ 9♣ 10♦ 7♣", actual);
        }

    }
}
