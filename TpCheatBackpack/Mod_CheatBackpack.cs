using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpCheatBackpack
{
	[BepInPlugin("net.kuronekotei.cheat_backpack", "CheatBackpack", "1.0.0.0")]
	public class Mod_CheatBackpack : BaseUnityPlugin
	{
		public static ModConfig ModConfig;

		private void Awake() {
			new Harmony("CheatBackpack").PatchAll();
			ModConfig = new ModConfig(this.Config);
		}

		public void OnStartCore() {
			CheatBackpack.OnStartCore();
		}
	}
}
