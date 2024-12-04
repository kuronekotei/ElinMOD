using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

using ReflexCLI;

using UnityEngine;

using static Lang;

namespace TpGoodLand
{
	[BepInPlugin("net.kuronekotei.good_land", "GoodLand", "1.0.0.0")]
	public class Mod_GoodLand : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("GoodLand").PatchAll();
			CommandRegistry.assemblies.Add(this.GetType().Assembly);
		}
	}
}