using System;
using System.Collections.Generic;

namespace ConsoleApp1;

public class Deck
{
    private readonly List<Card> cards = new List<Card>();
    private readonly Random rand = new Random();

    public Deck()
    {
        for (int i = 0; i < Card.Suits.Length; i++)
        {
            for (int j = 0; j < Card.Values.Length; j++)
            {
                cards.Add(new Card(Card.Suits[i], Card.Values[j]));
            }
        }

        Shuffle();
    }

    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int r = rand.Next(cards.Count);
            (cards[i], cards[r]) = (cards[r], cards[i]);
        }
    }

    // Return null when empty (so Table spots can become empty)
    public Card? DealCard()
    {
        if (cards.Count == 0) return null;

        Card top = cards[0];
        cards.RemoveAt(0);
        return top;
    }

    public bool IsEmpty() => cards.Count == 0;
    public int CardsLeft() => cards.Count;
}
