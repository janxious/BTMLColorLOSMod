# BTMLColorLOSMod
BattleTech Mod (using [BTML](https://github.com/Mpstark/BattleTechModLoader) and [ModTek](https://github.com/Mpstark/ModTek)) that changes the color of indirect firing lines in battle to a different color from direct.

## Installing
After [installing BTML and Modtek](https://github.com/Mpstark/ModTek/wiki/The-Drop-Dead-Simple-Guide-to-Installing-BTML-&-ModTek-&-ModTek-mods), put into `\BATTLETECH\Mods\BTMLColorLOSMod` folder and launch the game.

## Features
- Make the line drawn between your currently controlled mech and an enemy in your firing arc with indirect-fire only a different color

## Settings
Setting | Type | Default | Description
--- | --- | --- | ---
indirectLineOfFireArcColor | float[4] | default [1, 0.5, 0, 1] (an orange-ish color) | the default in vanilla is [1, 0, 0, 1].

Note that the last number controls alpha transparency, so if you make it a zero you will probably not have an indirect firing line at all. All numbers should be between 0 and 1.

## Download
Downloads can be found on [github](https://github.com/janxious/BTMLColorLOSMod/releases).

## Install
- [Install BTML and Modtek](https://github.com/Mpstark/ModTek/wiki/The-Drop-Dead-Simple-Guide-to-Installing-BTML-&-ModTek-&-ModTek-mods).
- Put the `BTMLColorLOSMod.dll` and `mod.json` files into `\BATTLETECH\Mods\BTMLColorLOSMod` folder.
- If you want to change the settings do so in the mod.json.
- Start the game.
