using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            if (this.Cards.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder allCardsInHand = new StringBuilder();
            foreach (var card in this.Cards)
            {
                allCardsInHand.Append(card.ToString());
                allCardsInHand.Append(" ");
            }

            allCardsInHand.Length--;

            return allCardsInHand.ToString();
        }
    }
}
