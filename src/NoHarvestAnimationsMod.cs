using System;
using System.Linq;
using HarmonyLib;
using Il2Cpp;
using MelonLoader;

[assembly: MelonInfo(typeof(NoHarvestAnimations.NoHarvestAnimationsMod), "NoHarvestAnimations", "1.0.0", "Lycanthor")]
[assembly: MelonGame("Hinterland", "TheLongDark")]
[assembly: MelonOptionalDependencies("ModSettings")]

namespace NoHarvestAnimations
{
    public class NoHarvestAnimationsMod : MelonMod
    {
        // Read by the Harmony patch on every harvest/quarter. Defaults to true so the mod works
        // (animations disabled) even when ModSettings is not installed.
        internal static bool DisableAnimations = true;

        public override void OnInitializeMelon()
        {
            // ModSettings is an optional dependency. Detect it at runtime and only then touch any
            // ModSettings-typed code, so the mod still loads (and stays enabled by default) when
            // ModSettings is not installed.
            bool modSettingsPresent = AppDomain.CurrentDomain.GetAssemblies()
                .Any(a => a.GetName().Name == "ModSettings");

            if (modSettingsPresent)
            {
                ModSettingsIntegration.Register();
                LoggerInstance.Msg("ModSettings detected — harvest animation toggle available in the settings menu.");
            }
            else
            {
                LoggerInstance.Msg("ModSettings not detected — mod enabled by default; harvesting animations will be skipped. Install ModSettings for an in-game on/off toggle.");
            }
        }
    }

    [HarmonyPatch(typeof(Panel_BodyHarvest), "InitializeTimelineData")]
    internal static class Patch_DisableHarvestTimeline
    {
        // Returning false skips InitializeTimelineData, so the harvest timeline never loads and the
        // game falls back to its native progress-circle path (the same one it uses in cramped
        // spaces). When the mod is toggled off, we return true and the stock animation plays.
        private static bool Prefix() => !NoHarvestAnimationsMod.DisableAnimations;
    }
}
