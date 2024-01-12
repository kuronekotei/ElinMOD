using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BepInEx;
using HarmonyLib;

using ReflexCLI.Attributes;

using UnityEngine;

namespace TpHalloMod
{
	[HarmonyPatch]
	public class HalloMod
	{
		[HarmonyPrefix, HarmonyPatch(typeof(CoreDebug), nameof(CoreDebug.GodMode))]
		public static void GodMode() {
			Debug.Log("HalloMod");
			if (EClass.debug.godMode) {
				EClass.debug.godMode = false;
				EClass.debug._godBuild = false;
				EClass.debug.godCraft = true;
			} else {
				EClass.debug.godMode = true;
				EClass.debug._godBuild = true;
				EClass.debug.godCraft = true;
			}
		}
		[HarmonyPrefix, HarmonyPatch(typeof(CoreDebug), nameof(CoreDebug.FlyMode))]
		public static void FlyMode() {
			Debug.Log("HalloMod");
			if (EClass.debug.showExtra) {
				EClass.debug.inviteAnytime = false;
				EClass.debug.showExtra = false;
			} else {
				EClass.debug.inviteAnytime = true;
				EClass.debug.showExtra = true;
			}
		}
	}
}
