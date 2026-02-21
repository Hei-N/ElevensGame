# Elevens (Console App)

This project is a C# console implementation of the card game **Elevens**.

## Current Progress

Added game rules:
Remove 2 cards that sum to 11 (A=1, cards 2–10 only)
Remove J + Q + K as a set
Added a basic game loop with input validation and game-over detection

Implemented 'Card' class
Stores suit and value
Displays face cards (A, J, Q, K)

Implemented 'Deck' class
Creates 52 cards
Shuffles the deck
Deals cards
Tracks remaining cards

Implemented 'Table' class
Maintains 9 visible cards
Validates sum-to-11 pairs (A = 1, cards 2–10 only)
Validates J + Q + K sets
Replaces removed cards from the deck
Detects if legal moves remain

Implemented 'GameController' class
Controls the main game loop
Handles user input
Validates moves
Manages game state (Running, Win, Loss)
Detects game over

Implemented 'Program' class
Entry point of the application
Instantiates GameController and starts the game
