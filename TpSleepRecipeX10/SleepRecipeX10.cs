using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using UnityEngine;

namespace TpSleepRecipeX10
{
	[HarmonyPatch]
	public class SleepRecipeX10
	{
		[HarmonyPrefix, HarmonyPatch(typeof(ConSleep), nameof(ConSleep.OnRemoved))]
		public static void OnRemoved(ConSleep __instance) {
			Debug.Log("SleepRecipeX10");
			bool flag = __instance.owner.IsPC && LayerSleep.slept;
			if (flag) {
				for (int i = 0; i < 9; i++) {
					EClass.player.recipes.OnSleep();
				}
			}
		}
	}
}
