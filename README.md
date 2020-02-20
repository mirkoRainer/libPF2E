# Pathfinder Second Edition Rules Lawyer

This project will start as a basic character sheet for tracking stats, actions, items, etc. for a Player Character. Hopefully it will grow into a tool for use with Pathfinder 2e to make playing easier for players and GMs alike.

## Technology

This project is developed using C# for language and Xamarin as the framework. This will allow the app to easily deploy to a number of operatin systems. The primary focus will be iOS, as there is currently a gap in the market for this. (February 2020)

The main library is under the PF2E folder and will hopefully become a standalone Nuget package for others to use in the future. This holds the core funtionality surround the PF2e rules, while the "Rules Lawyer" portion will be the app itself and will hold the UI/UX logic and design.


## PF2E Library

The core library this app is built around is the PF2E Library. 
Ideally this Library will be used similar to the following:


```
var player = new PlayerCharacter(Ancestries.Dwarf, Backgrounds.Emancipated, PcClasses.Rogue);

var goblin = new Creature(Goblins.Warrior);

player.Strike(goblin, player.melee[0]);
```

This is a very rough example but using DDD I hope to make the external API very friendly to Parhfinder 2E players. 
