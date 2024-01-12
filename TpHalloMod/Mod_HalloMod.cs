using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BepInEx;
using HarmonyLib;

using ReflexCLI.Attributes;

namespace TpHalloMod
{
	[BepInPlugin("net.kuronekotei.hallomod", "HalloMod", "1.0.0.0")]
	public class Mod_HalloMod : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("HalloMod").PatchAll();
		}
	}
}
