using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using UnityEngine;

namespace TpInfinityMagic
{
	[HarmonyPatch]
	public class InfinityMagic
	{
		static int vPot;
		[HarmonyPrefix, HarmonyPatch(typeof(Chara), nameof(Chara.UseAbility), new Type[] { typeof(Act), typeof(Card), typeof(Point), typeof(bool) })]
		public static void UseAbility_Prefix(Chara __instance, Act a) {
			vPot=a.vPotential;
			return;
		}

		[HarmonyPostfix, HarmonyPatch(typeof(Chara), nameof(Chara.UseAbility), new Type[] { typeof(Act), typeof(Card), typeof(Point), typeof(bool) })]
		public static void UseAbility_Postfix(Chara __instance, Act a) {
			if (a is Spell && __instance.IsPC) {
				a.vPotential = vPot;
				LayerAbility.SetDirty(a);
			}

			return;
		}
	}
}
