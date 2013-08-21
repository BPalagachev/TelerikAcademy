using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public string CardFaceAsString
        {
            get
            {
                string faceStr;
                if ((int)this.Face <= 10)
                {
                    faceStr = ((int)this.Face).ToString();
                }
                else
                {
                    faceStr = (this.Face.ToString()[0]).ToString();
                }

                return faceStr;
            }
        }

        public string CardSuitAsString
        {
            get
            {
                char suitSymbol;
                switch (this.Suit)
                {
                    case CardSuit.Clubs:
                        suitSymbol = '♣';
                        break;
                    case CardSuit.Diamonds:
                        suitSymbol = '♦';
                        break;
                    case CardSuit.Hearts:
                        suitSymbol = '♥';
                        break;
                    case CardSuit.Spades:
                        suitSymbol = '♠';
                        break;
                    default:
                        throw new InvalidOperationException("Invalid Card Suit: "+this.Suit);
                }

                return suitSymbol.ToString();
            }
        }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string cardFace = this.CardFaceAsString;
            string cardSiut = this.CardSuitAsString;

            return cardFace + cardSiut;
        }
    }
}
