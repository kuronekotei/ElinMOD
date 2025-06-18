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


namespace TpCheatBackpack
{
	[HarmonyPatch]
	public class CheatBackpack
	{
		static ModConfig config;
		public static void OnStartCore() {
			config = Mod_CheatBackpack.ModConfig;

			SourceManager sources = Core.Instance.sources;

			List<SourceThing.Row> list = sources.things.rows?.FindAll(x => x.name_JP == "バックパック");
			foreach(var item in list) {
				if (config.IsNoDecay.Value) { 
					AddElement(item, 405, 50);
				}
				if (config.IsNoWeight.Value) {
					AddElement(item, 404, 100);
				}
			}
			EClass.sources.things.Reset();
		}

		private static void AddElement(SourceThing.Row thing, int elm, int val) {
			if (thing == null || thing.elements == null || thing.elements.Contains(elm) == true) {
				return;
			}
			thing.elements = thing.elements.AddItem(elm).ToArray();
			thing.elements = thing.elements.AddItem(val).ToArray();

			//OnStartCoreでは不要　それより後に調整するなら必要
			//thing.elementMap[elm] = val;
		}

		[HarmonyPrefix, HarmonyPatch(typeof(TraitBaseContainer), nameof(TraitBaseContainer.DecaySpeedChild), MethodType.Getter)]
		public static bool DecaySpeedChild(TraitBaseContainer __instance, ref int __result) {
			if (config.IsNoDecay.Value && __instance.owner.sourceCard.name_JP == "バックパック") {
				__result = 0;
				return false;
			}
			return true;
		}

		[HarmonyPrefix, HarmonyPatch(typeof(Trait), nameof(Trait.DecaySpeedChild), MethodType.Getter)]
		public static bool DecaySpeedChild(Trait __instance, ref int __result) {
			if (config.IsNoDecay_MainInventory.Value && __instance.owner.IsPC) {
				__result = 0;
				return false;
			}
			return true;
		}

	}
}
