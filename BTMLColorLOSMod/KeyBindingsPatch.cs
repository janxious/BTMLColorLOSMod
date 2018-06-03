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
                if (!ModSettings.NextColorKeyBinding.Active) return true;

                if (SelectNextLineOfFireColor.WasReleased)
                {
                    ModSettings.Indirect.NextColor();
                    ModSettings.Direct.NextColor();
                    ModSettings.ObstructedAttackerSide.NextColor();
                    ModSettings.ObstructedTargetSide.NextColor();
                    Logger.Debug($"next color selected");
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