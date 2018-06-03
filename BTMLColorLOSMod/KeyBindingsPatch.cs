using System;
using BattleTech;
using BattleTech.UI;
using Harmony;
using InControl;
using static BTMLColorLOSMod.BTMLColorLOSMod;

namespace BTMLColorLOSMod
{
    public class KeyBindingsPatch
    {
        public class Adapter<T>
        {
            public readonly T instance;
            public readonly Traverse traverse;

            protected Adapter(T instance)
            {
                this.instance = instance;
                traverse = Traverse.Create(instance);
            }
        }

        public static PlayerAction SelectNextLineOfFireColor;


        [HarmonyPatch(typeof(UIManager), "Update")]
        public static class UIManager_Patch
        {
            public static bool Prefix(UIManager __instance)
            {
                if (SelectNextLineOfFireColor.WasReleased)
                {
                    Logger.Debug($"Toggling inverse: {ModSettings.AlternateColorIndex}");
                    ModSettings.AlternateColorIndex++;
                    if (ModSettings.IDLOFCA.Count > 0)
                        ModSettings.IndirectLineOfFireArcColor =
                            ModSettings.IDLOFCA[
                                ModSettings.AlternateColorIndex %
                                ModSettings.IDLOFCA.Count];

                    if (ModSettings.DLOFCA.Count > 0)
                        ModSettings.DirectLineOfFireColor = ModSettings.DLOFCA[
                            ModSettings.AlternateColorIndex % ModSettings.DLOFCA.Count];

                    if (ModSettings.OLOFTSCA.Count > 0)
                        ModSettings.ObstructedLineOfFireTargetSideColor =
                            ModSettings.OLOFTSCA[
                                ModSettings.AlternateColorIndex %
                                ModSettings.OLOFTSCA.Count];

                    if (ModSettings.OLOFASCA.Count > 0)
                        ModSettings.ObstructedLineOfFireAttackerSideColor =
                            ModSettings.OLOFASCA[
                                ModSettings.AlternateColorIndex %
                                ModSettings.OLOFASCA.Count];

                    Logger.Debug($"It's now inverted");
                }

                return true;
            }
        }


        [HarmonyPatch(typeof(DynamicActions), "CreateWithDefaultBindings")]
        public static class DynamicActionsCreateWithDefaultBindingsPatch
        {
            public static void Postfix(DynamicActions __result)
            {
                if (ModSettings.NextColorKeyBinding.Active)
                {
                    try
                    {
                        var adapter = new DynamicActionsAdapter(__result);
                        SelectNextLineOfFireColor = adapter.CreatePlayerAction("Select Next Line of Fire Color");
                        SelectNextLineOfFireColor.AddDefaultBinding(ModSettings.NextColorKeyBinding.Keys);
                        Logger.Debug("Keybind added");
                    }
                    catch (Exception e)
                    {
                        Logger.Error(e);
                    }
                }
            }
        }

        internal class DynamicActionsAdapter : Adapter<DynamicActions>
        {
            internal DynamicActionsAdapter(DynamicActions instance) : base(instance) { }

            internal PlayerAction CreatePlayerAction(string name)
            {
                return traverse.Method("CreatePlayerAction", name).GetValue<PlayerAction>(name);
            }
        }
    }
}