# Battleship

**Battleship** is a console-based game where two players compete in a naval battle. Players are assigned a fleet of ships and compete to see whose ships remain afloat the longest. This game is programmed in C# and utilizes random elements (e.g., ship orientation and state) to determine the winner.

## Features

- **Two Players**: Players can input their names, after which they are assigned a random fleet of ships.
- **Ship Types**: The game includes five different types of ships:
  - Submarine
  - Destroyer
  - Cruiser
  - Battleship
  - Aircraft Carrier
- **Randomness**: Ship states (afloat or sunk) and orientations (horizontal or vertical) are determined randomly.
- **Winner Determination**: The game counts how many ships each player has remaining and declares the winner or a tie.

## Installation

**Clone the repository:** `git clone https://github.com/lauri-sa/BattleshipGame.git`

**Navigate to the project directory:** `cd BattleshipGame`

**Build the project:** `dotnet build`

**Run the application:** `dotnet run`
