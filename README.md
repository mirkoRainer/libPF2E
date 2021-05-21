# Pathfinder Second Edition Rules Lawyer
## PF2E Library

The core library this app is built around is the PF2E Library. 
Ideally this Library will be used similar to the following:


```
var player = new PlayerCharacter(Ancestries.Dwarf, Backgrounds.Emancipated, PcClasses.Rogue);

var goblin = new Creature(Goblins.Warrior);

player.Strike(goblin, player.melee[0]);
```

This is a very rough example but using language specific to PF2e I hope to make the external API very friendly to Parhfinder 2E players. 
