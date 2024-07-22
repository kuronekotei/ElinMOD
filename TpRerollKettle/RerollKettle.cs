using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using HarmonyLib;
using UnityEngine;

namespace TpRerollKettle
{
	[HarmonyPatch]
	public class RerollKettle
    {
		[HarmonyPrefix, HarmonyPatch(typeof(TraitKettle), nameof(TraitKettle.CostRerollShop), MethodType.Getter)]
		public static bool MaxAlly(ref int __result) {
			__result = 5;
			return false;
		}
		[HarmonyPrefix, HarmonyPatch(typeof(TraitKettle), nameof(TraitKettle.RestockDay), MethodType.Getter)]
		public static bool RestockDay(ref int __result) {
			__result = 5;
			return false;
		}
		[HarmonyPrefix, HarmonyPatch(typeof(Trait), nameof(Trait.NumCopyItem), MethodType.Getter)]
		public static bool NumCopyItem(Trait __instance,ref int __result) {
			__result = 3 + Mathf.Min(__instance.owner.c_invest / 5, 7);
			return false;
		}

	}
}
