using ModSettings;

namespace NoHarvestAnimations
{
    // All ModSettings-typed code lives here so it is only ever touched when the ModSettings
    // assembly is actually loaded (see NoHarvestAnimationsMod.OnInitializeMelon). If ModSettings
    // is not installed, Register() is never called, so this class and NoAnimationsSettings are
    // never JIT-compiled and the missing assembly never has to resolve.
    internal static class ModSettingsIntegration
    {
        private static NoAnimationsSettings settings;

        public static void Register()
        {
            settings = new NoAnimationsSettings();
            settings.AddToModSettings("No Harvest Animations", MenuType.Both);
            // Apply the saved value (loaded by JsonModSettings) at startup.
            NoHarvestAnimationsMod.DisableAnimations = settings.disableHarvestAnimation;
        }
    }

    // JsonModSettings auto-loads/saves the value to Mods/NoHarvestAnimations.json.
    internal sealed class NoAnimationsSettings : JsonModSettings
    {
        [Section("General")]
        [Name("Disable harvesting animation")]
        [Description("When on, harvesting and quartering carcasses skip the first-person animation " +
                     "and use the game's native progress circle. Turn off to restore the stock animation.")]
        public bool disableHarvestAnimation = true;

        // Called when the player confirms the settings menu. base.OnConfirm() persists to JSON; we
        // then push the confirmed value to the flag the patch reads, so it takes effect immediately
        // (no game restart needed).
        protected override void OnConfirm()
        {
            base.OnConfirm();
            NoHarvestAnimationsMod.DisableAnimations = disableHarvestAnimation;
        }
    }
}
