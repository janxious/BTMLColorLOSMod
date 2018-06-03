using System;
using System.Reflection;
using Harmony;
using Newtonsoft.Json;

namespace BTMLColorLOSMod
{
    public static class BTMLColorLOSMod
    {
        internal static Settings ModSettings = new Settings();
        internal static string ModDirectory;

        public static void Init(string directory, string settingsJSON)
        {
            ModDirectory = directory;
            try
            {
                ModSettings = JsonConvert.DeserializeObject<Settings>(settingsJSON);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                ModSettings = new Settings();
            }

            var harmony = HarmonyInstance.Create("com.joelmeador.BTMLColorLOSMod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}