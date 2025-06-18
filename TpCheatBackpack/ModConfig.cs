using BepInEx.Configuration;

using UnityEngine;

namespace TpCheatBackpack
{
	/// <summary>
	/// Modコンフィグ用.
	/// </summary>
	public class ModConfig
	{
		public ConfigEntry<bool> IsNoDecay { get; set; }
		public ConfigEntry<bool> IsNoWeight { get; set; }
		public ConfigEntry<bool> IsNoDecay_MainInventory { get; set; }

		public ModConfig(ConfigFile config) {
			IsNoDecay = config.Bind("BackPack", nameof(IsNoDecay), true, "IsNoDecay.");
			IsNoWeight = config.Bind("BackPack", nameof(IsNoWeight), true, "IsNoWeight.");
			IsNoDecay_MainInventory = config.Bind("MainInventory", nameof(IsNoDecay_MainInventory), false, "IsNoDecay_MainInventory.");
		}
	}
}