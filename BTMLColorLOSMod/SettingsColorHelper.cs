using UnityEngine;


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
            float outR, outG, outB, outA;
            outR = rgbaColorValueFromFloat(r);
            outG = rgbaColorValueFromFloat(g);
            outB = rgbaColorValueFromFloat(b);
            outA = rgbaColorValueFromFloat(a);

            try
            {
                Color outColor = new Color(outR, outG, outB, outA);
                return outColor;
            }
            catch
            {
                Logger.LogLine(string.Format("Error converting ({0}, {1}, {2}, {3}) to a color", r, g, b, a));
                return Color.magenta;   
            }
        }

        // Takes in a float
        // If the value is 0 <= X <= 1, return it
        // if the value is X > 1, we'll divide it by 255 then return
        public static float rgbaColorValueFromFloat(float value)
        {
            float outValue;
            if(value !=0 && value > 1)
            {
                outValue = (float)(value / 255);
            }
            else
            {
                outValue = value;
            }
            return outValue;
        }
    }
}