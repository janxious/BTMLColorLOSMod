# BTMLColorLOSMod
BattleTech Mod (using [BTML](https://github.com/Mpstark/BattleTechModLoader) and [ModTek](https://github.com/Mpstark/ModTek)) that changes the color of indirect firing lines in battle to a different color from direct.

You've been in the situation where the lines are both red and you move and then realize you actually don't have an alpha strike. The orange-yellow line is indirect fire:

<img width="201" alt="screen shot 2018-05-20 at 6 53 02 pm" src="https://user-images.githubusercontent.com/50124/40288821-11b0066e-5c83-11e8-98c2-aba640c7dc73.png">

The defaults for this mod setup the indirect line and the nearer target obstructed line to stand out. You can change settings as described below to make the lines very customized in appearance.

## Features
- Change the color of direct line of fire indicator drawn between the currently controlled mech and enemy targets
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

The `*Color` variables below (`float[4]`) are RGBA colors. You can enter your colors as a number 0-255, or a float from 0 to 1. For example, pure red can be entered as `[255, 0, 0, 1]` (hex/web format) or `[1, 0, 0, 1]` (unity format). If you make the alpha channel `0`, you will probably not have a line at all. You can use a color picker like [the W3's](https://www.w3schools.com/colors/colors_picker.asp) and then divide the individual values by 255 to get the decimal you need. For example hex color `#66ff33` / rgb color `rgb(102, 255, 51)` can be entered directly as `[102, 255, 51, 1]` or converted from `[102/255, 255/255, 51/255, 1]`, which works out to `[0.4, 1, 0.2, 1]`.

Setting | Type | Default | Description
--- | --- | --- | ---
`directLineOfFireArcActive` | `bool` | `false` | change the look of the direct firing line arc
`directLineOfFireArcColor` | `float[4]` | `[0, 1, 0.5, 1]` (light blue) | the color of the direct firing line arc. The default in vanilla is `[1, 0, 0, 1]` (red).
`indirectLineOfFireArcActive` | `bool` | `true` | change the look of the indirect firing line arc
`indirectLineOfFireArcColor` | `float[4]` | `[1, 0.5, 0, 1]` (orange) | the color of the indirect firing line arc. The default in vanilla is `[1, 0, 0, 1]` (red).
`indirectLineOfFireArcDashed` | `bool` | `false` | make the indirect firing line arc a dashed line
`indirectLineOfFireArcDashedThicknessMultiplier` | `float` | `1.75` | change how thick the indirect firing line looks when dashed
`obstructedLineOfFireAttackerSideActive` | `bool` | false | change the look of the line of fire indicator when obstructed on the side nearest the attacker
`obstructedLineOfFireAttackerSideColor` | `float[4]` | `[0, 0.25, 1, 1]` (blue) | line of fire color nearest the attacker when fire is obstructed
`obstructedLineOfFireTargetSideActive` | `bool` | true | change the look of the line of fire indicator when obstructed on the side nearest the target
`obstructedLineOfFireTargetSideColor` | `float[4]` | `[0.6, 0, 1, 0.9]` (purple) | line of fire color nearest the target when fire is obstructed
`obstructedLineOfFireTargetSiteThicknessMultiplier` | `float` | `1.25` | change how thick the obstructed firing line looks on the target side




## More Screenshots

Side angle

<img width="576" alt="screen shot 2018-05-20 at 10 57 16 pm" src="https://user-images.githubusercontent.com/50124/40288819-0ed5a9f8-5c83-11e8-8889-ddf65437f444.png">


With the settings on cyan instead of orange

<img width="490" alt="screen shot 2018-05-20 at 3 59 46 pm" src="https://user-images.githubusercontent.com/50124/40288810-0a8ad8f0-5c83-11e8-8234-8598580d4631.png">


Marvelous

<img width="937" alt="screen shot 2018-05-20 at 10 29 41 pm" src="https://user-images.githubusercontent.com/50124/40288822-13ecd8bc-5c83-11e8-8111-8d17f439f9f1.png">


Dashes!

<img width="478" alt="screen shot 2018-05-21 at 12 40 23 am" src="https://user-images.githubusercontent.com/50124/40314402-6610d090-5ce6-11e8-8700-92a0de80f015.png">


Obstructed Colors!

<img width="898" alt="screen shot 2018-05-21 at 10 12 46 am" src="https://user-images.githubusercontent.com/50124/40314408-6bf2caa4-5ce6-11e8-887f-c165546abb1a.png">
<img width="886" alt="screen shot 2018-05-21 at 10 27 46 am" src="https://user-images.githubusercontent.com/50124/40314409-6c17545a-5ce6-11e8-98f2-275870b183b6.png">

## Special Thanks

HBS, @Mpstark, @Morphyum, @gponick


## Maintainer Notes: New HBS Patch Instructions

* pop open VS
* grab the latest version of the assembly
* copy the new version of the methods in `original_src` over the existing ones
* see if anything important changed via git
