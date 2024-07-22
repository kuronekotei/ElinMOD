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
			Debug.Log("DiligencePeaple");
			if (__instance._works?.Count < 2) {
				int newWork = EClass.sources.hobbies.listWorks.RandomItem<SourceHobby.Row>().id;
				newWork = __instance._works[0] != newWork ? newWork : EClass.sources.hobbies.listWorks.RandomItem<SourceHobby.Row>().id;
				newWork = __instance._works[0] != newWork ? newWork : EClass.sources.hobbies.listWorks.RandomItem<SourceHobby.Row>().id;
				__instance.AddWork(newWork);
			}
		}
	}
}
