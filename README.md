# Pathfinder Second Edition Rules Lawyer

This project will start as a basic character sheet for tracking stats, actions, items, etc. for a Player Character. Hopefully it will grow into a tool for use with Pathfinder 2e to make playing easier for players and GMs alike.

## Milestones

1. Editable Character sheet that auto-calculates certain fields of the sheet
2. Character builder with Core Rule Book classes, ancestries, etc. (basic selection with limited mechanical impact on character sheet)
3. Spell support, select and display spells
4. Export to PDF/HTML/JSON
5. More advanced Character builder

## Technology

This project is developed using C# for language and Xamarin as the framework. This will allow the app to easily deploy to a number of operatin systems. The primary focus will be iOS, as there is currently a gap in the market for this. (February 2020)

The main librart is under the PF2E folder and will hopefully become a standalone Nuget package for others to use in the future. This holds the core funtionality surround the PF2e rules, while the "Rules Lawyer" portion will be the app itself and will hold the UI/UX logic and design.
