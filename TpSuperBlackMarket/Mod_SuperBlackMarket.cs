using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpSuperBlackMarket
{
	[BepInPlugin("net.kuronekotei.super_black_market", "SuperBlackMarket", "1.0.0.0")]
	public class Mod_SuperBlackMarket : BaseUnityPlugin
	{
		public static ModConfig ModConfig;

		private void Awake() {
			new Harmony("SuperBlackMarket").PatchAll();
			ModConfig = new ModConfig(this.Config);
		}

		public void OnStartCore() {
			SuperBlackMarket.OnStartCore();
		}
	}
}
