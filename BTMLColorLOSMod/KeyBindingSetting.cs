using System;
using System.Collections.Generic;
using InControl;

namespace BTMLColorLOSMod
{
    public class KeyBindingSetting
    {
        public bool active = false;
        public bool Active => active;

        public string[] keys
        {
            set
            {
                Keys.Clear();
                foreach (var keyString in value)
                {
                    var key = (Key) Enum.Parse(typeof(Key), keyString, true);
                    Keys.AddInclude(key);
                }
            }
        }
        public KeyCombo Keys;
    }
}