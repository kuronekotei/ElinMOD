using BepInEx.Configuration;

using UnityEngine;

namespace TpSuperBlackMarket
{
	/// <summary>
	/// Modコンフィグ用.
	/// </summary>
	public class ModConfig
	{
		public ConfigEntry<bool> ForceMythical_blackmarket { get; set; }
		public ConfigEntry<bool> ForceMythical_weaponsmith { get; set; }
		public ConfigEntry<bool> ForceMythical_gunsmith { get; set; }
		public ConfigEntry<BlessedState> ForceBlessed_blackmarket { get; set; }
		public ConfigEntry<BlessedState> ForceBlessed_weaponsmith { get; set; }
		public ConfigEntry<BlessedState> ForceBlessed_gunsmith { get; set; }

		public ModConfig(ConfigFile config) {
			ForceMythical_blackmarket = config.Bind("BlackMarket", nameof(ForceMythical_blackmarket), true, "ForceMythical_blackmarket.");
			ForceBlessed_blackmarket = config.Bind("BlackMarket", nameof(ForceBlessed_blackmarket), BlessedState.Normal, "ForceBlessed_blackmarket.");
			ForceMythical_weaponsmith = config.Bind("WeaponSmith", nameof(ForceMythical_weaponsmith), false, "ForceMythical_weaponsmith.");
			ForceBlessed_weaponsmith = config.Bind("WeaponSmith", nameof(ForceBlessed_weaponsmith), BlessedState.Normal, "ForceBlessed_weaponsmith.");
			ForceMythical_gunsmith = config.Bind("GunSmith", nameof(ForceMythical_gunsmith), false, "ForceMythical_gunsmith.");
			ForceBlessed_gunsmith = config.Bind("GunSmith", nameof(ForceBlessed_gunsmith), BlessedState.Normal, "ForceBlessed_gunsmith.");
		}
	}
}