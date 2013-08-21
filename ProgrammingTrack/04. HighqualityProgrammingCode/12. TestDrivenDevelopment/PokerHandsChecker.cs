using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int NumberOfCardsInHand = 5;

        public bool IsValidHand(IHand hand)
        {
            IList<ICard> allCardsInHand = hand.Cards;

            if (allCardsInHand.Count != NumberOfCardsInHand)
            {
                return false;
            }

            for (int i = 0; i < allCardsInHand.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (allCardsInHand[i].ToString() == allCardsInHand[j].ToString())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Hand non valid: " + hand.ToString());
            }

            IList<ICard> allCardsInHand = hand.Cards;
            Dictionary<CardFace, int> cardsAndCounts = CountCardFaces(allCardsInHand);

            bool hasFlush = this.HasFlush(allCardsInHand);
            bool hasStraight = this.HasStraight(cardsAndCounts);

            return hasFlush && hasStraight;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Hand non valid: " + hand.ToString());
            }

            IList<ICard> allCardsInHand = hand.Cards;
            Dictionary<CardFace, int> cardsAndCounts = CountCardFaces(allCardsInHand);

            bool hasFourOfAKind = this.HasFourEqualCards(cardsAndCounts);

            if (hasFourOfAKind)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Hand non valid: " + hand.ToString());
            }

            IList<ICard> allCardsInHand = hand.Cards;
            Dictionary<CardFace, int> cardsAndCounts = CountCardFaces(allCardsInHand);

            bool hasThreeOfAKind = this.HasThreeEqualCards(cardsAndCounts);
            bool hasTwoOfAKind = this.HasTwoEqualCards(cardsAndCounts);

            if (hasThreeOfAKind && hasTwoOfAKind)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Hand non valid: " + hand.ToString());
            }

            IList<ICard> allCardsInHand = hand.Cards;
            Dictionary<CardFace, int> cardsAndCounts = CountCardFaces(allCardsInHand);

            bool hasFlush = this.HasFlush(allCardsInHand);
            bool hasStraight = this.HasStraight(cardsAndCounts);

            return hasFlush&&!hasStraight;
        }

        public bool IsStraight(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Hand non valid: " + hand.ToString());
            }

            IList<ICard> allCardsInHand = hand.Cards;
            Dictionary<CardFace, int> cardsAndCounts = CountCardFaces(allCardsInHand);

            bool hasStraight = this.HasStraight(cardsAndCounts);
            bool hasFlush = this.HasFlush(allCardsInHand);

            return hasStraight && !hasFlush;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Hand non valid: " + hand.ToString());
            }

            IList<ICard> allCardsInHand = hand.Cards;
            Dictionary<CardFace, int> cardsAndCounts = CountCardFaces(allCardsInHand);

            bool hasThreeOfAKind = this.HasThreeEqualCards(cardsAndCounts);
            bool hasTwoOfAKind = this.HasTwoEqualCards(cardsAndCounts);

            if (hasThreeOfAKind && !hasTwoOfAKind)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Hand non valid: " + hand.ToString());
            }

            IList<ICard> allCardsInHand = hand.Cards;
            Dictionary<CardFace, int> cardsAndCounts = CountCardFaces(allCardsInHand);

            bool hasTwoPairs = HasTwoPairs(cardsAndCounts);
            return hasTwoPairs;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Hand non valid: " + hand.ToString());
            }

            IList<ICard> allCardsInHand = hand.Cards;
            Dictionary<CardFace, int> cardsAndCounts = CountCardFaces(allCardsInHand);

            bool hasTwoPairs = HasTwoPairs(cardsAndCounts);
            bool hasOnePair = HasTwoEqualCards(cardsAndCounts);
            bool hasFullHouse = this.IsFullHouse(hand);

            return hasOnePair && !hasFullHouse && !hasTwoPairs;
        }

        public bool IsHighCard(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("Hand non valid: " + hand.ToString());
            }

            if (IsStraightFlush(hand))
            {
                return false;
            }
            else if (IsFourOfAKind(hand))
            {
                return false;
            }
            else if (IsFullHouse(hand))
            {
                return false;
            }
            else if (IsFlush(hand))
            {
                return false;
            }
            else if (IsStraight(hand))
            {
                return false;
            }
            else if (IsThreeOfAKind(hand))
            {
                return false;
            }
            else if (IsTwoPair(hand))
            {
                return false;
            }
            else if (IsOnePair(hand))
            {
                return false;
            }

            return true;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private bool HasThreeEqualCards(Dictionary<CardFace, int> cardsAndCounts)
        {
            foreach (var card in cardsAndCounts)
            {
                if (card.Value == 3)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasTwoEqualCards(Dictionary<CardFace, int> cardsAndCounts)
        {
            foreach (var card in cardsAndCounts)
            {
                if (card.Value == 2)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasFourEqualCards(Dictionary<CardFace, int> cardsAndCounts)
        {
            foreach (var card in cardsAndCounts)
            {
                if (card.Value == 4)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasTwoPairs(Dictionary<CardFace, int> cardsAndCounts)
        {
            bool isFirstPairsFound = false;
            bool isSecondpairFound = false;

            foreach (var card in cardsAndCounts)
            {
                if (isFirstPairsFound == true && card.Value == 2)
                {
                    isSecondpairFound = true;
                }
                if (card.Value == 2)
                {
                    isFirstPairsFound = true;
                }
            }

            return isFirstPairsFound && isSecondpairFound;
        }
        
        private bool HasFlush(IList<ICard> allCardsInHand)
        {
            ICard firstCard = allCardsInHand[0];
            for (int i = 1; i < allCardsInHand.Count; i++)
            {
                if (firstCard.Suit != allCardsInHand[i].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        private Dictionary<CardFace, int> CountCardFaces(IList<ICard> allCardsInHand)
        {
            Dictionary<CardFace, int> cardsAndCounts = new Dictionary<CardFace, int>();
            for (int i = 0; i < allCardsInHand.Count; i++)
            {
                if (cardsAndCounts.ContainsKey(allCardsInHand[i].Face))
                {
                    cardsAndCounts[allCardsInHand[i].Face]++;
                }
                else
                {
                    cardsAndCounts.Add(allCardsInHand[i].Face, 1);
                }
            }

            return cardsAndCounts;
        }

        private bool HasStraight(Dictionary<CardFace, int> cardsAndCounts)
        {
            foreach (var card in cardsAndCounts)
            {
                if (card.Value != 1)
                {
                    return false;
                }
            }

            IList<CardFace> cardFacesValues= cardsAndCounts.Keys.ToList<CardFace>();
            cardFacesValues.OrderBy(x => (int)x);

            for (int i = 1; i < cardFacesValues.Count; i++)
            {
                if ( (int)cardFacesValues[i] != (int)cardFacesValues[i-1]-1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
