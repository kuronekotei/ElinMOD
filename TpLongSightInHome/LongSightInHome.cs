using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using UnityEngine;


namespace TpLongSightInHome
{
	[HarmonyPatch]
	public class LongSightInHome
	{
		[HarmonyPrefix, HarmonyPatch(typeof(Card), nameof(Card.GetLightRadius))]
		public static bool GetLightRadius(Card __instance, ref int __result) {
			if (__instance.IsPC && EClass._zone.IsPCFaction) {
				__result = 100;
				return false;
			}
			return true;

		}
	}
}
