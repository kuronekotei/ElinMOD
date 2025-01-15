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
				bool isStack = false;
				var config = Mod_StackableTool.ModConfig;
				switch (__instance.id) {
					case "stethoscope": isStack = config.IsStack_stethoscope.Value; break;
					case "lockpick": isStack = config.IsStack_lockpick.Value; break;
					case "blanket_fire": isStack = config.IsStack_blanketFire.Value; break;
					case "blanket_cold": isStack = config.IsStack_blanketCold.Value; break;
					case "whip_love": isStack = config.IsStack_whipLove.Value; break;
					case "whip_interest": isStack = config.IsStack_whipInterest.Value; break;
					default:
						return true;
				}
				if (!isStack)
					return true;

				to.ModCharge(__instance.c_charges);
				__instance.Destroy();
				__result = true;

				return false;
			}
			return true;
		}
	}
}
