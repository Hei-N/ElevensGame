using System;
using System.Collections.Generic;

namespace ConsoleApp1;

public class Table
{
    // use nullable Card because deck can run out
    private readonly List<Card?> visibleCards = new List<Card?>();

    public void DealInitial(Deck deck)
    {
        visibleCards.Clear();
        for (int i = 0; i < 9; i++)
        {
            visibleCards.Add(deck.DealCard());
        }
    }

    public List<Card?> GetVisibleCards() => visibleCards;

    private bool ValidIndex(int i)
    {
        return i >= 0 && i < visibleCards.Count && visibleCards[i] != null;
    }

    public bool IsPairSum11(int i, int j)
    {
        if (!ValidIndex(i) || !ValidIndex(j) || i == j) return false;

        int a = visibleCards[i]!.GetValue();
        int b = visibleCards[j]!.GetValue();

        if (a > 10 || b > 10) return false; // J/Q/K not allowed in sum-to-11
        return a + b == 11;
    }

    public bool IsJQK(int i, int j, int k)
    {
        if (!ValidIndex(i) || !ValidIndex(j) || !ValidIndex(k)) return false;
        if (i == j || i == k || j == k) return false;

        int a = visibleCards[i]!.GetValue();
        int b = visibleCards[j]!.GetValue();
        int c = visibleCards[k]!.GetValue();

        bool hasJ = (a == 11 || b == 11 || c == 11);
        bool hasQ = (a == 12 || b == 12 || c == 12);
        bool hasK = (a == 13 || b == 13 || c == 13);

        return hasJ && hasQ && hasK;
    }

    public void RemovePair(int i, int j, Deck deck)
    {
        if (!IsPairSum11(i, j)) return;

        visibleCards[i] = deck.DealCard();
        visibleCards[j] = deck.DealCard();
    }

    public void RemoveJQK(int i, int j, int k, Deck deck)
    {
        if (!IsJQK(i, j, k)) return;

        visibleCards[i] = deck.DealCard();
        visibleCards[j] = deck.DealCard();
        visibleCards[k] = deck.DealCard();
    }

    public bool HasLegalMove()
    {
        // sum-to-11 pairs
        for (int i = 0; i < visibleCards.Count; i++)
        {
            for (int j = i + 1; j < visibleCards.Count; j++)
            {
                if (IsPairSum11(i, j)) return true;
            }
        }

        // JQK sets
        for (int i = 0; i < visibleCards.Count; i++)
        {
            for (int j = i + 1; j < visibleCards.Count; j++)
            {
                for (int k = j + 1; k < visibleCards.Count; k++)
                {
                    if (IsJQK(i, j, k)) return true;
                }
            }
        }

        return false;
    }

    public bool IsAllEmpty()
    {
        for (int i = 0; i < visibleCards.Count; i++)
        {
            if (visibleCards[i] != null) return false;
        }
        return true;
    }
}
