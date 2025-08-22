# Copilot Instructions for [TP] Walkie-Talkie (Continued)

## Mod Overview and Purpose

The [TP] Walkie-Talkie mod enhances the vanilla RimWorld experience by introducing a pre-microelectronics communications console and orbital trade beacon. This adds a strategic layer to early gameplay by allowing players to engage in trade and communication before researching microelectronics. The mod is compact, requiring minimal resources and power, and can be placed indoors, making it ideal for early colony setups.

## Key Features and Systems

- **Simple Construction**: The Walkie-Talkie requires only 40 steel, 1 component, and 5 watts of power.
- **Early-Game Utility**: Functions before microelectronics are researched, integrating trade and communication into the early gameplay.
- **Small Footprint**: Designed for indoor placement with a reduced trade radius of approximately 3 tiles (note the issue with displaying the radius correctly).

## Known Issues

- **Trade Radius Mismatch**: The Walkie-Talkie's trade radius is visually displayed as the standard 7 cells when placing, whereas it functions as a 3-cell radius.
- **Incompatibility**: Currently incompatible with the RimBank mod.

## Load Order

It's recommended to position this mod close to the core game files in the load order, ideally above Deep Storage and its addons.

## Coding Patterns and Conventions

- **Class Inheritance**: The `Building_WalkieTalkie` class inherits from `Building_CommsConsole` to extend the functionality of the base game communications console.
- **Conventions**: Follow C# naming conventions where class names are PascalCase and method names are camelCase.

## XML Integration

- Utilize XML files to define and load def configurations for the Walkie-Talkie, specifying the resource costs, power usage, and build requirements.
- Ensure trade radius and settings match the intended gameplay implementation.

## Harmony Patching

- **Patch Targets**: The `Patches` class uses static Harmony methods to intercept and modify behavior where necessary within the game's original code.
- **Examples of Patching**: Adjust trade radius display or compatibility logic with other mods via Harmony patches.

## Suggestions for Copilot

To enhance your development experience, Copilot could assist by:

- **Generating Standard Methods**: Auto-complete common functionality for classes like `Building_WalkieTalkie`, potentially predicting the structure based on existing methods like `makeMatchingStockpile()`.
- **Harmony Patches**: Suggest Harmony patch templates for modifying base game methods.
- **XML Integration**: Provide code snippets for XML structure that binds the C# logic with in-game objects.
- **Debugging Assistance**: Generate potential fixes or code adjustments for known issues, like the trade radius display problem.

By adhering to these instructions, developers can maintain the consistency and functionality of the Walkie-Talkie mod while utilizing modern coding practices and tools to enhance their productivity.
