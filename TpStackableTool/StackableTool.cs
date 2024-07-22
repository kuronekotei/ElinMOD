using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using UnityEngine;

namespace TpStackableTool
{
	[HarmonyPatch]
	public class StackableTool
	{
		[HarmonyPrefix, HarmonyPatch(typeof(Card), nameof(Card.TryStackTo))]
		public static bool TryStackTo(Card __instance, Thing to, ref bool __result) {
			if (__instance.id == to.id && __instance.blessedState == to.blessedState) {
				switch (__instance.id) {
					case "stethoscope":
					case "lockpick":
					case "blanket_fire":
					case "blanket_cold":
					case "whip_love":
					case "whip_interest":
						break;
					default:
						return true;
				}

				to.ModCharge(__instance.c_charges);
				__instance.Destroy();
				__result = true;

				return false;
			}
			return true;
		}
	}
}
