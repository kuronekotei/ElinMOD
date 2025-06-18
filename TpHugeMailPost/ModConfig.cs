using BepInEx.Configuration;

using UnityEngine;

namespace TpHugeMailPost
{
	/// <summary>
	/// Modコンフィグ用.
	/// </summary>
	public class ModConfig
	{
		public ConfigEntry<int> W { get; set; }
		public ConfigEntry<int> H { get; set; }

		public ModConfig(ConfigFile config) {
			W = config.Bind("Size", nameof(W), 16, "Width.");
			H = config.Bind("Size", nameof(H), 10, "Height.");
		}
	}
}