using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BepInEx;
using HarmonyLib;

using ReflexCLI.Attributes;

using UnityEngine;

namespace TpDiligencePeaple
{
	[HarmonyPatch]
	public class DiligencePeaple
	{
		[HarmonyPostfix, HarmonyPatch(typeof(Chara), nameof(Chara.RerollHobby))]
		public static void RerollHobby(Chara __instance) {
			if (__instance._works?.Count < 2) {
				int newWork = EClass.sources.hobbies.listWorks.RandomItem<SourceHobby.Row>().id;
				__instance.AddWork(newWork);
			}
			__instance.GetWorkSummary().Reset();
		}
	}
}
