# BTMLColorLOSMod
BattleTech Mod (using [BTML](https://github.com/Mpstark/BattleTechModLoader) and [ModTek](https://github.com/Mpstark/ModTek)) that changes the color of indirect firing lines in battle to a different color from direct.

## Features
- Change the color of indirect line of fire indicator drawn between the currently controlled mech and enemy targets
- Add dashes to the indirect line of fire indicator drawn between the currently controlled mech and enemy targets
- Change the color of the line of fire indicator for obstructed targets on the attacker and target sides of the obstruction

## Download
Downloads can be found on [Github](https://github.com/janxious/BTMLColorLOSMod/releases) and on [Nexus](https://www.nexusmods.com/battletech/mods/135).

## Install
- [Install BTML and Modtek](https://github.com/Mpstark/ModTek/wiki/The-Drop-Dead-Simple-Guide-to-Installing-BTML-&-ModTek-&-ModTek-mods).
- Put the `BTMLColorLOSMod.dll` and `mod.json` files into `\BATTLETECH\Mods\BTMLColorLOSMod` folder.
- If you want to change the settings do so in the mod.json.
- Start the game.

## Settings
Setting | Type | Default | Description
--- | --- | --- | ---
`indirectLineOfFireArcActive` | `bool` | `true` | change the look of the indirect firing line arc
`indirectLineOfFireArcColor` | `float[4]` | `[1, 0.5, 0, 1]` (orange) | the color of the indirect firing line arc. The default in vanilla is `[1, 0, 0, 1]` (red).
`indirectLineOfFireArcDashed` | `bool` | `false` | make the indirect firing line arc a dashed line
`indirectLineOfFireArcDashedThicknessMultiplier` | `float` | `1.75` | change how thick the indirect firing line looks when dashed
`obstructedLineOfFireAttackerSideActive` | `bool` | false | change the look of the line of fire indicator when obstructed on the side nearest the attacker
`obstructedLineOfFireAttackerSideColor` | `float[4]` | `[0, 0.25, 1, 1]` (blue) | line of fire color nearest the attacker when fire is obstructed
`obstructedLineOfFireTargetSideActive` | `bool` | true | change the look of the line of fire indicator when obstructed on the side nearest the target
`obstructedLineOfFireTargetSideColor` | `float[4]` | `[0.6, 0, 1, 0.9]` (purple) | line of fire color nearest the target when fire is obstructed
`obstructedLineOfFireTargetSiteThicknessMultiplier` | `float` | `1.25` | change how thick the obstructed firing line looks on the target side

Note that the last number in the above `float[4]` controls alpha transparency, so if you make it a `0` you will probably not have an indirect firing line at all. All numbers should be between `0` and `1`.

## Special Thanks

HBS, @Mpstark, @Morphyum, @gponick


## Maintainer Notes: New HBS Patch Instructions

* pop open VS
* grab the latest version of the assembly
* copy the new version of the methods in `original_src` over the existing ones
* see if anything important changed via git