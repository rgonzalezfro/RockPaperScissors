# RockPaperScissors

## Table of Contents
- [Overview](#overview)
- [Architecture](#architecture)

## Overview
This project is a simple rock-paper-scissors-lizzard-spock game where a single player competes against the computer in a match to the best of 5 rounds.

## Architecture
The game uses and MVC pattern where the UI Panels handles the view and States are the controllers.

### GameManager
The `GameManager` acts as the controller of the game. It manages the core game logic and uses a state machine to control the game's flow across different phases, such as the main menu, gameplay, and results screen.

### States
Each state is a controller and contains the logic of each phase of the game.

### UIManager
The `UIManager` serves as the view manager. It is responsible for handling all UI-related elements and uses C# generics to access and display the necessary views dynamically.

### UI Panels
Each panel contains the logic of the view and controls how the information is displayed in screen.
