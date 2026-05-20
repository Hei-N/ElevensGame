# Elevens Card Game

A full-stack implementation of the classic **Elevens** solitaire card game, built with C# and Blazor WebAssembly.

---

## What is Elevens?

Elevens is a solitaire card game played with a standard 52-card deck.
- Remove 2 cards from the table that sum to 11 (A=1, cards 2–10 only)
- Remove a set of J + Q + K
- Win by clearing all 52 cards
- Lose if no legal moves remain

---

## Technologies Used

| Layer | Technology |
|---|---|
| Language | C# (.NET 10) |
| UI Framework | Blazor WebAssembly |
| Styling | CSS3 (custom, no external UI library) |
| Console version | .NET Console App |

---

## Project Structure

```
ConsoleApp1/
├── ConsoleApp1.csproj        # Console app (original)
├── ConsoleApp1/
│   └── ElevensGame/          # Console game logic
│       ├── Card.cs
│       ├── Deck.cs
│       ├── Table.cs
│       ├── GameController.cs
│       └── Program.cs
└── ElevensUI/                # Blazor WebAssembly UI
    ├── Game/
    │   ├── Card.cs
    │   ├── Deck.cs
    │   ├── Table.cs
    │   └── ElevensGame.cs    # UI-friendly game model
    ├── Pages/
    │   └── Home.razor        # Main game page
    └── wwwroot/
        └── css/app.css       # Custom casino-style styling
```

---

## How to Run

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Blazor Web UI 

**Step 1** — Trust the HTTPS dev certificate (one time only):
```bash
dotnet dev-certs https --trust
```

**Step 2** — Navigate to the UI project:
```bash
cd "/Users/heinhtetaung/350 FEB5/ConsoleApp1/ElevensUI"
```

**Step 3** — Start the app:
```bash
dotnet run --launch-profile https
```

**Step 4** — Open your browser and go to:
```
https://localhost:7158
```

**To stop:** press `Ctrl + C` in the terminal.

### Console Version

```bash
cd "/Users/heinhtetaung/350 FEB5/ConsoleApp1"
dotnet run
```

---

## How to Play (Web UI)

1. **Click a card** to select it (it highlights in gold)
2. Select **2 cards that sum to 11** — they are removed automatically
3. Select **J + Q + K** — they are removed automatically
4. Keep clearing until the deck and table are empty to **win**
5. Press **NEW GAME** at any time to restart

---

## Classes

| Class | Description |
|---|---|
| `Card` | Stores suit and value, displays face cards (A, J, Q, K) |
| `Deck` | Creates and shuffles 52 cards, deals one at a time |
| `Table` | Manages 9 visible cards, validates moves, detects game over |
| `ElevensGame` | UI-facing game model — handles selection, auto-move, win/loss |
| `GameController` | Console-only game loop with input handling |
