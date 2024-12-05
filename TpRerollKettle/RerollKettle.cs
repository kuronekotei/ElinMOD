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
		public static bool CostRerollShop(ref int __result) {
			__result = fBuild ? 0 : 5;
			fBuild = false;
			return false;
		}
		[HarmonyPrefix, HarmonyPatch(typeof(TraitKettle), nameof(TraitKettle.RestockDay), MethodType.Getter)]
		public static bool RestockDay(ref int __result) {
			__result = 5;
			return false;
		}
		[HarmonyPrefix, HarmonyPatch(typeof(Trait), nameof(Trait.NumCopyItem), MethodType.Getter)]
		public static bool NumCopyItem(Trait __instance, ref int __result) {
			__result = 3 + Mathf.Min(__instance.owner.c_invest / 5, 7);
			return false;
		}

		static bool fBuild = false;
		[HarmonyPrefix, HarmonyPatch(typeof(UIInventory), nameof(UIInventory.AddTab),new Type[] {typeof(InvOwner), typeof(UIInventory.Mode)   })]
		public static void AddTab(UIInventory __instance, InvOwner owner) {
			if (owner is InvOwnerCopyShop) {
				fBuild = true;
			}
		}
	}
}
