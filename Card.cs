using System;

namespace ConsoleApp1;

public class Card
{
    private readonly int value;
    private readonly string suit;

    public static readonly string[] Suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
    public static readonly int[] Values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

    public Card(string suit, int value)
    {
        this.suit = suit;
        this.value = value;
    }

    public int GetValue() => value;
    public string GetSuit() => suit;

    public override string ToString()
    {
        string faceValue =
            value == 1 ? "A" :
            value == 11 ? "J" :
            value == 12 ? "Q" :
            value == 13 ? "K" :
            value.ToString();

        return $"{faceValue} of {suit}";
    }
}
