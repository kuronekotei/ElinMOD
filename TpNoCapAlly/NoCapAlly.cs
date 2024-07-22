using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using HarmonyLib;
using UnityEngine;

namespace TpNoCapAlly
{
	[HarmonyPatch]
	public class NoCapAlly
    {
		[HarmonyPrefix, HarmonyPatch(typeof(Player), nameof(Player.MaxAlly), MethodType.Getter)]
		public static bool MaxAlly(ref int __result) {
			__result = Mathf.Max(EClass.pc.CHA / 10, 1) + EClass.pc.Evalue(1645);
			return false;
		}
		[HarmonyPrefix, HarmonyPatch(typeof(Player), nameof(Player.RefreshEmptyAlly))]
		public static bool RefreshEmptyAlly(Player __instance) {
			int num = __instance.MaxAlly - EClass.pc.party.members.Count + 1;
			if (__instance.MaxAlly > 8) 
			{
				num = 8 * (__instance.MaxAlly - EClass.pc.party.members.Count) / __instance.MaxAlly + 1;
			}
			if (num == __instance.lastEmptyAlly) { return false; }
			__instance.lastEmptyAlly = num;
			foreach (Chara member in EClass.pc.party.members) {
				member.RefreshSpeed();
			}
			return false;
		}

	}
}
