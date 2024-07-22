using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using UnityEngine;

namespace TpStackableSpellbook
{
	[HarmonyPatch]
	public class StackableSpellbook
	{
		[HarmonyPrefix, HarmonyPatch(typeof(Card), nameof(Card.TryStackTo))]
		public static bool TryStackTo(Card __instance, Thing to, ref bool __result) {
			if (__instance.id == to.id && __instance.blessedState == to.blessedState) {
				switch (__instance.id) {
					case "spellbook":
					case "372":
						if (__instance.refVal != to.refVal) {
							return true;
						}
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
