using System;
using System.Collections.Generic;

namespace ConsoleApp1;

public enum GameState
{
    Running,
    Win,
    Loss
}

public class GameController
{
    private readonly Deck deck;
    private readonly Table table;
    private GameState gameState;

    public GameController()
    {
        deck = new Deck();
        table = new Table();
        gameState = GameState.Running;
    }

    public void Start()
    {
        table.DealInitial(deck);

        while (gameState == GameState.Running)
        {
            Render();

            // WIN (simple): deck empty AND table has no cards
            if (deck.IsEmpty() && table.IsAllEmpty())
            {
                gameState = GameState.Win;
                break;
            }

            // LOSS: no legal move and deck empty
            if (!table.HasLegalMove() && deck.IsEmpty())
            {
                gameState = GameState.Loss;
                break;
            }

            Console.WriteLine("\nChoose a move:");
            Console.WriteLine("2 = remove 2 cards that sum to 11 (A..10 only)");
            Console.WriteLine("3 = remove J + Q + K");
            Console.WriteLine("q = quit");

            string choice = (Console.ReadLine() ?? "").Trim().ToLower();

            if (choice == "q")
            {
                gameState = GameState.Loss;
                break;
            }

            bool moved = false;

            if (choice == "2")
            {
                int a = ReadIndex("First index: ");
                int b = ReadIndex("Second index: ");

                if (a != -1 && b != -1 && table.IsPairSum11(a, b))
                {
                    table.RemovePair(a, b, deck);
                    moved = true;
                }
            }
            else if (choice == "3")
            {
                int a = ReadIndex("First index: ");
                int b = ReadIndex("Second index: ");
                int c = ReadIndex("Third index: ");

                if (a != -1 && b != -1 && c != -1 && table.IsJQK(a, b, c))
                {
                    table.RemoveJQK(a, b, c, deck);
                    moved = true;
                }
            }

            Console.WriteLine(moved ? "\nGood move!" : "\nInvalid move.");
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        Console.Clear();
        Render();

        Console.WriteLine(gameState == GameState.Win ? "\nYou win!" : "\nGame over!");
    }

    private void Render()
    {
        Console.Clear();
        Console.WriteLine("ELEVENS");
        Console.WriteLine("Cards left in deck: " + deck.CardsLeft() + "\n");

        List<Card?> cards = table.GetVisibleCards();
        for (int i = 0; i < cards.Count; i++)
        {
            Console.WriteLine(cards[i] == null ? $"{i}: (empty)" : $"{i}: {cards[i]}");
        }
    }

    private int ReadIndex(string prompt)
    {
        Console.Write(prompt);
        return int.TryParse(Console.ReadLine(), out int x) ? x : -1;
    }
}
