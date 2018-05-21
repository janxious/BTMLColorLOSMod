using UnityEngine;

namespace BTMLColorLOSMod
{
    public class Settings
    {
        // the float here is to hold deserialized JSON data coming from ModTek and convert it to a UnityEngine.Color
        public float[] indirectLineOfFireArcColor
        {
            set => IndirectLineOfFireArcColor = new Color(value[0], value[1], value[2], value[3]);
        }

        public float[] blockedLOFLine1Color
        {
            set => BlockedLOFLine1Color = new Color(value[0], value[1], value[2], value[3]);
        }

        public float[] blockedLOFLine2Color
        {
            set => BlockedLOFLine2Color = new Color(value[0], value[1], value[2], value[3]);
        }

        public bool indirectLineOfFireArcDashed
        {
            set => IndirectLineOfFireArcDashed = value;
        }

        public bool blockedLOFLine1Active
        {
            set => BlockedLOFLine1Active = value;
        }

        public bool blockedLOFLine2Active
        {
            set => BlockedLOFLine2Active = value;
        }

        // The color to be patched into the game for coloring indirect lines of fire
        // Defaults to magenta if the user gives us funky data so it should stand out
        public Color IndirectLineOfFireArcColor = Color.magenta;

        public bool IndirectLineOfFireArcDashed = false;

        public bool BlockedLOFLine1Active = false;
        public bool BlockedLOFLine2Active = true;

        public Color BlockedLOFLine1Color = Color.green;

        public Color BlockedLOFLine2Color = Color.magenta;

    }
}