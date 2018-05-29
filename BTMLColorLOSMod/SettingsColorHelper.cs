using UnityEngine;
using System;

namespace BTMLColorLOSMod
{
    public static class SettingsColorHelper
    {
        // Make a new color from the floats r, g, b, a. 
        // If the value is 0 <= X <= 1, we'll use that value 
        // if the value is X > 1, we'll divide it by 255 to get the decimal value 
        // and use that.
        public static Color ColorFromValues(float r, float g, float b, float a)
        {
            float outR=-1, outG=-1, outB=-1, outA=-1;

            try
            {
                outR = rgbaColorValueFromFloat(r);
                outG = rgbaColorValueFromFloat(g);
                outB = rgbaColorValueFromFloat(b);
                outA = rgbaColorValueFromFloat(a);
                Color outColor = new Color(outR, outG, outB, outA);
                return outColor;
            }
            catch(Exception ex)
            {
                Logger.Debug($"Error converting [raw] ({r}, {g}, {b}, {a}) to [converted] ({outR}, {outG}, {outB}, {outA}) to a color.");
                Logger.Error(ex);
                return Color.magenta;   
            }
        }

        // Takes in a float
        // If the value is 0 <= X <= 1, return it
        // if the value is X > 1, we'll divide it by 255 then return
        public static float rgbaColorValueFromFloat(float value)
        {
            if (value < 0 || value > 255)
                throw new ArgumentOutOfRangeException($"value is out of range: {value}");
            if (value <= 1)
                return value;
            return value / 255f;
        }
    }
}