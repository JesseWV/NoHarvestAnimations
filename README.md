# No Harvest Animations

A [MelonLoader](https://melonloader.co/) mod for **The Long Dark** that disables the
first-person carcass **harvesting and quartering** animation and falls back to the game's
native progress circle.

## Install

1. Install MelonLoader for The Long Dark.
2. Download `NoHarvestAnimations.dll` from the [latest release](https://github.com/JesseWV/NoHarvestAnimations/releases/latest).
3. Drop it into your `TheLongDark/Mods/` folder.
4. *(Optional)* Install [ModSettings](https://github.com/DigitalzombieTLD/ModSettings) to get an
   in-game toggle for the mod (see [Configuration](#configuration)).
5. Launch the game.

## Configuration

The mod is **enabled by default**. ModSettings is optional:

- **Without ModSettings:** harvest animations are always disabled — there is no toggle.
- **With [ModSettings](https://github.com/DigitalzombieTLD/ModSettings) installed:** a
  **Disable harvesting animation** toggle appears in the settings menu (main menu and in-game).
  Changes apply as soon as you confirm — no restart needed — and persist to
  `Mods/NoHarvestAnimations.json`.

## Compatibility

- The Long Dark **v2.55 (181032)**, MelonLoader **v0.7.2** (Il2Cpp).
- Optional: [ModSettings](https://github.com/DigitalzombieTLD/ModSettings) for the in-game toggle.
- Affects carcass harvesting and quartering only. Breaking down objects, plants and gear is
  unchanged.

## License

[MIT](LICENSE)
