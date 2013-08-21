using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class PonkerHandsCheckerTest
    {

        #region Test IsValid
        [TestMethod]
        public void TestIsValidTrivial()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.Jack, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsValidHand(newHand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestIsValidTwoSameCards()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.Jack, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsValidHand(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestIsValidAllSameCards()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsValidHand(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestIsValidTooManyCards()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.Jack, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsValidHand(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestIsValidTwoFewCards()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.Jack, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsValidHand(newHand);

            Assert.AreEqual(false, actual);
        }
        
        [TestMethod]
        public void TestIsValidAllSameCardsTwoMeny()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades), 
                    new Card(CardFace.King, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsValidHand(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestIsValidEmptyHand()
        {
            IList<ICard> allCardsInHand = new List<ICard>();

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsValidHand(newHand);

            Assert.AreEqual(false, actual);
        }
        #endregion

        #region Test IsFlush
        [TestMethod]
        public void TestIsFlushTrivial()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Five, CardSuit.Spades),
                    new Card(CardFace.Two, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsFlush(newHand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestIsFlushNotRoyalFlush()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Jack, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Nine, CardSuit.Spades),
                    new Card(CardFace.Eight, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsFlush(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestIsFlushNoFlush()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Jack, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Nine, CardSuit.Spades),
                    new Card(CardFace.Eight, CardSuit.Hearts),
                    new Card(CardFace.Seven, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsFlush(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsFlushEmptyHand()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                new Card(CardFace.Jack, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Nine, CardSuit.Spades),
                    new Card(CardFace.Eight, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Jack, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Nine, CardSuit.Spades),
                    new Card(CardFace.Eight, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsFlush(newHand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsFlushInvalidHand()
        {
            IList<ICard> allCardsInHand = new List<ICard>()
            {
            };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsFlush(newHand);
        }
        #endregion

        #region Test IsThreeeOfAKind
        [TestMethod]
        public void TestIsThreeOfAKindAces()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Clubs),
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsThreeOfAKind(newHand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestIsThreeOfAKindFullHouse()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsThreeOfAKind(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestIsThreeOfAKindPair()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsThreeOfAKind(newHand);

            Assert.AreEqual(false, actual);
        }
        #endregion

        #region Test IsFullHouse
        [TestMethod]
        public void TestIsFullHouseAceAndKings()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsFullHouse(newHand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestIsFullHouseKingsAndAces()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsFullHouse(newHand);

            Assert.AreEqual(true, actual);
        }
        
        [TestMethod]
        public void TestIsFullHouseStraight()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Hearts),
                    new Card(CardFace.Jack, CardSuit.Diamonds),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Nine, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsFullHouse(newHand);

            Assert.AreEqual(false, actual);
        }
        #endregion

        #region Test IsFourOfAKind
        [TestMethod]
        public void TestIsFourOfAKindAces()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Clubs),
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsFourOfAKind(newHand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestIsFourOfTwoPairs()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsFourOfAKind(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestIsFourOfKindFullHose()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsFourOfAKind(newHand);

            Assert.AreEqual(false, actual);
        }
        #endregion

        #region Test isTwoPairs
        [TestMethod]
        public void TestIsTwoPairsAcesSevens()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.Five, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsTwoPair(newHand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestIsTwoPairsAcesSevensFullHouse()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsTwoPair(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestIsTwoPairsOnePair()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Eight, CardSuit.Spades),
                    new Card(CardFace.Six, CardSuit.Hearts),
                    new Card(CardFace.Five, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsTwoPair(newHand);

            Assert.AreEqual(false, actual);
        }

        #endregion

        #region Test IsOnePair
        [TestMethod]
        public void TestIsOneFullHouse()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsOnePair(newHand);

            Assert.AreEqual(false, actual);
        }

         [TestMethod]
        public void TestIsOnePairTwoPairs()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsOnePair(newHand);

            Assert.AreEqual(false, actual);
        }

         [TestMethod]
         public void TestIsOneQueens()
         {
             IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.Five, CardSuit.Diamonds),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Clubs),
                };

             Hand newHand = new Hand(allCardsInHand);

             PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
             bool actual = testPokerTandChecker.IsOnePair(newHand);

             Assert.AreEqual(true, actual);
         }

        #endregion

        #region Test IsStraight
         [TestMethod]
         public void TestIsStraightFullHouse()
         {
             IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                };

             Hand newHand = new Hand(allCardsInHand);

             PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
             bool actual = testPokerTandChecker.IsStraight(newHand);

             Assert.AreEqual(false, actual);
         }

         [TestMethod]
         public void TestIsStraightStraightFlush()
         {
             IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.Queen, CardSuit.Hearts),
                    new Card(CardFace.Jack, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Hearts),
                };

             Hand newHand = new Hand(allCardsInHand);

             PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
             bool actual = testPokerTandChecker.IsStraight(newHand);

             Assert.AreEqual(false, actual);
         }

        [TestMethod]
         public void TestIsStraightStraight()
         {
             IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.Queen, CardSuit.Diamonds),
                    new Card(CardFace.Jack, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Hearts),
                };

             Hand newHand = new Hand(allCardsInHand);

             PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
             bool actual = testPokerTandChecker.IsStraight(newHand);

             Assert.AreEqual(true, actual);
         }
        #endregion

        #region Test IsStraightFlush
        [TestMethod]
        public void TestIsStraightFlushFlushOfSpades()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Five, CardSuit.Spades),
                    new Card(CardFace.Two, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsStraightFlush(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestIsStraightFlushStraightFlush()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Jack, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Nine, CardSuit.Hearts),
                    new Card(CardFace.Eight, CardSuit.Hearts),
                    new Card(CardFace.Seven, CardSuit.Hearts)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsStraightFlush(newHand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestIsStraightFlushNoStraightFlush()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Seven, CardSuit.Clubs),
                    new Card(CardFace.Eight, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsStraightFlush(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestIsStraightFlushJustStraight()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Jack, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Nine, CardSuit.Clubs),
                    new Card(CardFace.Eight, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsStraightFlush(newHand);

            Assert.AreEqual(false, actual);
        }
        #endregion

        #region Test IsHighCard
        [TestMethod]
        public void TestIsHighCardFlushTrivial()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.Five, CardSuit.Spades),
                    new Card(CardFace.Two, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsHighCard(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestIsHighCardThreeOfAKindAces()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Clubs),
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsHighCard(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestIsHighCardFullHouseAceAndKings()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Ace, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Spades)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsFullHouse(newHand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestIsHighCardStraightFlush()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Jack, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Nine, CardSuit.Hearts),
                    new Card(CardFace.Eight, CardSuit.Hearts),
                    new Card(CardFace.Seven, CardSuit.Hearts)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsHighCard(newHand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestIsHighCardTrivial()
        {
            IList<ICard> allCardsInHand = new List<ICard>() {
                    new Card(CardFace.Jack, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.Nine, CardSuit.Diamonds),
                    new Card(CardFace.Three, CardSuit.Hearts),
                    new Card(CardFace.Five, CardSuit.Clubs)
                };

            Hand newHand = new Hand(allCardsInHand);

            PokerHandsChecker testPokerTandChecker = new PokerHandsChecker();
            bool actual = testPokerTandChecker.IsHighCard(newHand);

            Assert.AreEqual(true, actual);
        }

        #endregion
    }
}
