using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using InControl;
using UnityEngine;



namespace BTMLColorLOSMod
{
    // the properties in in here are to be a deserializer step from JSON format
    // into the C# variables used by the mod.
    public class Settings
    {
        public LineSetting direct;
        public LineSetting Direct => direct;

        public LineSetting indirect;
        public LineSetting Indirect => indirect;

        public LineSetting obstructedAttackerSide;
        public LineSetting ObstructedAttackerSide => obstructedAttackerSide;

        public LineSetting obstructedTargetSide;
        public LineSetting ObstructedTargetSide => obstructedTargetSide;

        public KeyBindingSetting nextColorKeyBinding;
        public KeyBindingSetting NextColorKeyBinding => nextColorKeyBinding;

        public bool debug = false;

        #region deprecated settings
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
            set
            {
                IndirectLineOfFireArcColor = SettingsColorHelper.ColorFromValues(value[0], value[1], value[2], value[3]);
            }
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

        #endregion


        #region Alternate Colors 
        public List<Color> IDLOFCA = new List<Color>();
        public List<Color> DLOFCA = new List<Color>();
        public List<Color> OLOFASCA = new List<Color>();
        public List<Color> OLOFTSCA = new List<Color>();

        public int AlternateColorIndex = 1;


        public float[][] ObstructedLineOfFireTargetSideColorsExtra
        {
            set
            {
                OLOFTSCA.Clear();
                Logger.Debug("OTS: Adding the original color");
                OLOFTSCA.Add(DirectLineOfFireColor);
                foreach (float[] colorvals in value)
                {
                    Logger.Debug($"OTS: Adding new color: {colorvals[0]} {colorvals[1]} {colorvals[2]} {colorvals[3]}");
                    OLOFTSCA.Add(SettingsColorHelper.ColorFromValues(colorvals[0], colorvals[1], colorvals[2], colorvals[3]));
                }
                Logger.Debug($"OLOFTSCA: {OLOFTSCA.Count}");
            }
        }

        public float[][] ObstructedLineOfFireAttackerSideColorsExtra
        {
            set
            {
                OLOFASCA.Clear();
                Logger.Debug("OAS: Adding the original color");
                OLOFASCA.Add(DirectLineOfFireColor);
                foreach (float[] colorvals in value)
                {
                    Logger.Debug($"OAS: Adding new color: {colorvals[0]} {colorvals[1]} {colorvals[2]} {colorvals[3]}");
                    OLOFASCA.Add(SettingsColorHelper.ColorFromValues(colorvals[0], colorvals[1], colorvals[2], colorvals[3]));
                }
                Logger.Debug($"OLOFASCA: {OLOFASCA.Count}");
            }
        }


        public float[][] DirectLineOfFireColorsExtra
        {
            set
            {
                DLOFCA.Clear();
                Logger.Debug("D: Adding the original color");
                DLOFCA.Add(DirectLineOfFireColor);
                foreach (float[] colorvals in value)
                {
                    Logger.Debug($"D: Adding new color: {colorvals[0]} {colorvals[1]} {colorvals[2]} {colorvals[3]}");
                    DLOFCA.Add(SettingsColorHelper.ColorFromValues(colorvals[0], colorvals[1], colorvals[2], colorvals[3]));
                }
                Logger.Debug($"DLOFCA: {DLOFCA.Count}");
            }
        }

        public float[][] IndirectLineOfFireColorsExtra
        {
            set
            {
                IDLOFCA.Clear();
                Logger.Debug("Adding the original color");
                IDLOFCA.Add(IndirectLineOfFireArcColor);
                foreach (float[] colorvals in value)
                {
                    Logger.Debug($"Adding new color: {colorvals[0]} {colorvals[1]} {colorvals[2]} {colorvals[3]}");
                    IDLOFCA.Add(SettingsColorHelper.ColorFromValues(colorvals[0], colorvals[1], colorvals[2], colorvals[3]));
                }
                Logger.Debug($"IDLOFCA: {IDLOFCA.Count}");
                Logger.Debug("IDLOFCA:");
                foreach (Color c in IDLOFCA)
                {
                    Logger.Debug($"         C: {c.r} {c.g} {c.b} {c.a}");
                }
            }
        }
        #endregion
    }
}