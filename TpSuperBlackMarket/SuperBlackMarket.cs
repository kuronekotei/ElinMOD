using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using BepInEx;
using HarmonyLib;
using UnityEngine;

using ReflexCLI.Attributes;
using static TextureReplace;


namespace TpSuperBlackMarket
{
	[HarmonyPatch]
	public class SuperBlackMarket
	{
		static ModConfig config;
		public static void OnStartCore() {
			config = Mod_SuperBlackMarket.ModConfig;
		}

		[HarmonyPrefix, HarmonyPatch(typeof(ThingGen), nameof(ThingGen.CreateFromFilter))]
		public static void FromFilter(ThingGen __instance, string id) {
			if (config.ForceMythical_blackmarket.Value && id == "shop_blackmarket") {
				CardBlueprint.SetRarity(Rarity.Mythical);
			}
			if (config.ForceBlessed_blackmarket.Value != BlessedState.Normal && id == "shop_blackmarket") {
				CardBlueprint.current.blesstedState = config.ForceBlessed_blackmarket.Value;
			}
			if (config.ForceMythical_weaponsmith.Value && id == "shop_weapon") {
				CardBlueprint.SetRarity(Rarity.Mythical);
			}
			if (config.ForceBlessed_weaponsmith.Value != BlessedState.Normal && id == "shop_weapon") {
				CardBlueprint.current.blesstedState = config.ForceBlessed_weaponsmith.Value;
			}
			if (config.ForceMythical_gunsmith.Value && id == "shop_gun") {
				CardBlueprint.SetRarity(Rarity.Mythical);
			}
			if (config.ForceBlessed_gunsmith.Value != BlessedState.Normal && id == "shop_gun") {
				CardBlueprint.current.blesstedState = config.ForceBlessed_gunsmith.Value;
			}
		}

	}
}
