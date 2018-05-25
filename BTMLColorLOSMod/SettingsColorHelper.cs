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
            if(r != 0 && r > 1)
            {
                outR = (float)(r / 255);
            }
            else
            {
                outR = r;
            }

            if(g != 0 && g > 1)
            {
                outG = (float)(g / 255);
            }
            else
            {
                outG = g;
            }

            if(b != 0 && b > 1)
            {
                outB = (float)(b / 255);
            }
            else
            {
                outB = b;
            }

            if(a != 0 && a > 1)
            {
                outA = (float)(a / 255);
            }
            else
            {
                outA = a;
            }

            try
            {
                Color outColor = new Color(outR, outG, outB, outA);
                return outColor;
            }
            catch
            {
                return Color.magenta;   
            }
        }
    }
}