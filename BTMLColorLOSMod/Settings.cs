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

        // The color to be patched into the game for coloring indirect lines of fire
        // Defaults to magenta if the user gives us funky data so it should stand out
        public Color IndirectLineOfFireArcColor = Color.magenta;
    }
}