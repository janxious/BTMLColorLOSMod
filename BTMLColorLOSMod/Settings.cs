using UnityEngine;

namespace BTMLColorLOSMod
{
    // the properties in in here are to be a deserializer step from JSON format
    // into the C# variables used by the mod.
    public class Settings
    {
        #region DirectLineOfFire

        // The color to be patched into the game for the coloring direct Line of Fire (LOF)'s
        // Defaults to magenta if the user gives us funky data so it should stand out
        public Color DirectLineOfFireColor = Color.magenta;

        public float[] directLineOfFireColor
        {
            set => DirectLineOfFireColor = SettingsColorHelper.ColorFromValues(value[0], value[1], value[2], value[3]);
        }

        // Controls whether we change the color of the near part of an obstructed LOF line.
        public bool DirectLineOfFireActive = false;

        public bool directLineOfFireActive
        {
            set => DirectLineOfFireActive = value;
        }

        #endregion

        #region IndirectLineOfFireArcOptions

        // The color to be patched into the game for coloring indirect lines of fire
        // Defaults to magenta if the user gives us funky data so it should stand out
        public Color IndirectLineOfFireArcColor = Color.magenta;

        public float[] indirectLineOfFireArcColor
        {
            set => IndirectLineOfFireArcColor = SettingsColorHelper.ColorFromValues(value[0], value[1], value[2], value[3]);
        }

        // Controls whether we set the Indirect Line Of Fire Line to Dashed (true: dashed, false: solid)
        public bool IndirectLineOfFireArcDashed = false;

        public bool indirectLineOfFireArcDashed
        {
            set => IndirectLineOfFireArcDashed = value;
        }

        // Controls the thickness of the Indirect Line of Fire when dashed
        public float IndirectLineOfFireArcDashedThicknessMultiplier = 1.75f;

        public float indirectLineOfFireArcDashedThicknessMultiplier
        {
            set => IndirectLineOfFireArcDashedThicknessMultiplier = value;
        }

        // Controls whether we change anything about the Indirect Line of Fire arc style.
        public bool IndirectLineOfFireArcActive = true;

        public bool indirectLineOfFireArcActive
        {
            set => IndirectLineOfFireArcActive = value;
        }

        #endregion

        #region obstructedLineOfFireAttackerSide

        // The color to be patched into the game for the coloring obstructed Line of Fire (LOF)'s part between
        // the shooter and obstruction
        // Defaults to magenta if the user gives us funky data so it should stand out
        public Color ObstructedLineOfFireAttackerSideColor = Color.magenta;

        public float[] obstructedLineOfFireAttackerSideColor
        {
            set => ObstructedLineOfFireAttackerSideColor = SettingsColorHelper.ColorFromValues(value[0], value[1], value[2], value[3]);
        }

        // Controls whether we change the color of the near part of an obstructed LOF line.
        public bool ObstructedLineOfFireAttackerSideActive = true;

        public bool obstructedLineOfFireAttackerSideActive
        {
            set => ObstructedLineOfFireAttackerSideActive = value;
        }

        #endregion

        #region obstructedLineOfFireTargetSide

        // The color to be patched into the game for the coloring obstructed Line of Fire (LOF)'s part between
        // the obstruction and target.
        // Defaults to magenta if the user gives us funky data so it should stand out
        public Color ObstructedLineOfFireTargetSideColor = Color.magenta;

        public float[] obstructedLineOfFireTargetSideColor
        {
            set => ObstructedLineOfFireTargetSideColor = SettingsColorHelper.ColorFromValues(value[0], value[1], value[2], value[3]);
        }

        // Controls whether we change the color of the far part of an obstructed LOF line.
        public bool ObstructedLineOfFireTargetSideActive = true;

        public bool obstructedLineOfFireTargetSideActive
        {
            set => ObstructedLineOfFireTargetSideActive = value;
        }

        // Controls the thickness of the obstructed LOF target side line.
        public float ObstructedLineOfFireTargetSiteThicknessMultiplier = 1.75f;

        public float obstructedLineOfFireTargetSiteThicknessMultiplier
        {
            set => ObstructedLineOfFireTargetSiteThicknessMultiplier = value;
        }

        #endregion

        #region debug settings

        public bool debug = false;

        #endregion
    }
}