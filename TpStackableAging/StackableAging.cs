using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using UnityEngine;

namespace TpStackableAging
{
	[HarmonyPatch]
	public class StackableAging
	{
		static bool fStack;
		[HarmonyPrefix, HarmonyPatch(typeof(TraitBrewery), nameof(TraitBrewery.OnChildDecay))]
		public static void OnChildDecay(TraitBrewery __instance) {
			fStack = true;
		}
		[HarmonyPostfix, HarmonyPatch(typeof(TraitBrewery), nameof(TraitBrewery.OnChildDecay))]
		public static void OnChildDecayPostfix(TraitBrewery __instance) {
			fStack = false;
		}
		[HarmonyPrefix, HarmonyPatch(typeof(Card), nameof(Card.AddThing), new Type[] { typeof(Thing), typeof(bool), typeof(int), typeof(int) })]
		public static bool AddThing(Card __instance, Thing t, bool tryStack = true, int destInvX = -1, int destInvY = -1) {
			if (fStack) {
				fStack = false;
				__instance.AddThing(t, true, destInvX, destInvY);
				return false;
			}
			return true;
		}
	}
}
