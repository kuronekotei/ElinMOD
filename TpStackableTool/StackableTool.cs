using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using UnityEngine;

using static InvOwner;

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
				if (!isStack) {
					return true;
				}

				to.ModCharge(__instance.c_charges);
				__instance.Destroy();
				__result = true;

				return false;
			}
			return true;
		}

		[HarmonyPostfix, HarmonyPatch(typeof(InvOwner), nameof(InvOwner.ListInteractions),new Type[] { typeof(ButtonGrid), typeof(bool) })]
		public static void ListInteractions(InvOwner __instance, ButtonGrid b, bool context, ref ListInteraction __result) {

			Thing t = b.card.Thing;
			if (t == null) {
				return;
			}


			if (!context || !__instance.AllowHold(t) || __instance.Container.isNPCProperty || HasTrader) {
				return;
			}

			bool isStack = false;
			var config = Mod_StackableTool.ModConfig;
			switch (t.id) {
				case "stethoscope": isStack = config.CanSplit_stethoscope.Value; break;
				case "lockpick": isStack = config.CanSplit_lockpick.Value; break;
				case "blanket_fire": isStack = config.CanSplit_blanketFire.Value; break;
				case "blanket_cold": isStack = config.CanSplit_blanketCold.Value; break;
				case "whip_love": isStack = config.CanSplit_whipLove.Value; break;
				case "whip_interest": isStack = config.CanSplit_whipInterest.Value; break; 
				default:
					return ;
			}
			if (!isStack) {
				return ;
			}

			if (t.c_charges<2 || __instance.Container.things.IsFull()) {
				return;
			}
			__result.Add("actSplit", 50, delegate {
				int n1 = t.c_charges / 2;
				int n2 = (t.c_charges + 1) / 2;
				Thing t2 = t.Duplicate(1);
				t.SetCharge(n1);
				t2.SetCharge(n2);
				__instance.Container.AddThing(t2, tryStack: false);
			});

			return;
		}


	}
}
