using BepInEx.Configuration;

using UnityEngine;

namespace TpStackableTool
{
	/// <summary>
	/// Modコンフィグ用.
	/// </summary>
	public class ModConfig
	{
		public ConfigEntry<bool> IsStack_stethoscope { get; set; }
		public ConfigEntry<bool> IsStack_lockpick { get; set; }
		public ConfigEntry<bool> IsStack_blanketFire { get; set; }
		public ConfigEntry<bool> IsStack_blanketCold { get; set; }
		public ConfigEntry<bool> IsStack_whipLove { get; set; }
		public ConfigEntry<bool> IsStack_whipInterest { get; set; }
		public ConfigEntry<bool> CanSplit_stethoscope { get; set; }
		public ConfigEntry<bool> CanSplit_lockpick { get; set; }
		public ConfigEntry<bool> CanSplit_blanketFire { get; set; }
		public ConfigEntry<bool> CanSplit_blanketCold { get; set; }
		public ConfigEntry<bool> CanSplit_whipLove { get; set; }
		public ConfigEntry<bool> CanSplit_whipInterest { get; set; }


		public ModConfig(ConfigFile config) {
			IsStack_stethoscope = config.Bind("Toggle", "IsStack_stethoscope", true, "IsStack_stethoscope.");
			IsStack_lockpick = config.Bind("Toggle", "IsStack_lockpick", true, "IsStack_lockpick.");
			IsStack_blanketFire = config.Bind("Toggle", "IsStack_blanketFire", true, "IsStack_blanketFire.");
			IsStack_blanketCold = config.Bind("Toggle", "IsStack_blanketCold", true, "IsStack_blanketCold.");
			IsStack_whipLove = config.Bind("Toggle", "IsStack_whipLove", true, "IsStack_whipLove.");
			IsStack_whipInterest = config.Bind("Toggle", "IsStack_whipInterest", true, "IsStack_whipInterest.");

			CanSplit_stethoscope = config.Bind("Toggle", "CanSplit_stethoscope", false, "CanSplit_stethoscope.");
			CanSplit_lockpick = config.Bind("Toggle", "CanSplit_lockpick", false, "CanSplit_lockpick.");
			CanSplit_blanketFire = config.Bind("Toggle", "CanSplit_blanketFire", true, "CanSplit_blanketFire.");
			CanSplit_blanketCold = config.Bind("Toggle", "CanSplit_blanketCold", true, "CanSplit_blanketCold.");
			CanSplit_whipLove = config.Bind("Toggle", "CanSplit_whipLove", false, "CanSplit_whipLove.");
			CanSplit_whipInterest = config.Bind("Toggle", "CanSplit_whipInterest", false, "CanSplit_whipInterest.");
		}
	}
}