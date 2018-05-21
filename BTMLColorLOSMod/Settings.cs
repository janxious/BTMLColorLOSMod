using UnityEngine;

namespace BTMLColorLOSMod
{
    public class Settings
    {

        #region IndirectLineOfFireArcOptions
        // The color to be patched into the game for coloring indirect lines of fire
        // Defaults to magenta if the user gives us funky data so it should stand out
        public Color IndirectLineOfFireArcColor = Color.magenta;

        // the float here is to hold deserialized JSON data coming from ModTek and convert it to a UnityEngine.Color
        public float[] indirectLineOfFireArcColor
        {
            set => IndirectLineOfFireArcColor = new Color(value[0], value[1], value[2], value[3]);
        }

        // Controls whether we set the Indirect Line Of Fire Line to Dashed (true: dashed, false: solid)
        public bool IndirectLineOfFireArcDashed = false;

        // the bool here is to hold the deserialized JSON data coming from ModTek and convert it to a boolean
        public bool indirectLineOfFireArcDashed
        {
            set => IndirectLineOfFireArcDashed = value;
        }

        // Controls the thickness of the Indirect Line of Fire Dashes
        public float IndirectLineOfFireArcDashThickness = 1.75f;

        // the float here is to hold the deserialized JSON data coming from ModTek and convert it to a boolean
        public float indirectLineOfFireArcDashThickness
        {
            set => IndirectLineOfFireArcDashThickness = value;
        }
        #endregion


        #region BlockedLineOfFireLine1
        // The color to be patched into the game for the coloring obstructed Line of Fire (LOF)'s first part
        //Defaults to magenta if the user gives us funky data so it should stand out
        public Color BlockedLineOfFireLine1Color = Color.magenta;

        // the float here is to hold the deserialized JSON data coming from ModTek and convert it to a UnityEngine.Color
        public float[] blockedLineOfFireLine1Color
        {
            set => BlockedLineOfFireLine1Color = new Color(value[0], value[1], value[2], value[3]);
        }

        // Controls whether we change the color of the second part of an obstructed LOF line.
        public bool BlockedLineOfFireLine1Active = true;


        // the bool here is to hold the deserialized JSON data coming from ModTek and convert it to a boolean
        public bool blockedLineOfFireLine1Active
        {
            set => BlockedLineOfFireLine1Active = value;
        }
        #endregion

        #region BlockedLineOfFireLine2
        // The color to be patched into the game for the coloring obstructed Line of Fire (LOF)'s first part
        //Defaults to magenta if the user gives us funky data so it should stand out
        public Color BlockedLineOfFireLine2Color = Color.magenta;

        // the float here is to hold the deserialized JSON data coming from ModTek and convert it to a UnityEngine.Color
        public float[] blockedLineOfFireLine2Color
        {
            set => BlockedLineOfFireLine2Color = new Color(value[0], value[1], value[2], value[3]);
        }

        // Controls whether we change the color of the second part of an obstructed LOF line.
        public bool BlockedLineOfFireLine2Active = true;


        // the bool here is to hold the deserialized JSON data coming from ModTek and convert it to a boolean
        public bool blockedLineOfFireLine2Active
        {
            set => BlockedLineOfFireLine2Active = value;
        }
        #endregion

    }
}