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

namespace TpLoytelMart
{
	[BepInPlugin("net.kuronekotei.loytel_mart", "LoytelMart", "1.0.0.0")]
	public class Mod_LoytelMart : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("LoytelMart").PatchAll();
			CommandRegistry.assemblies.Add(this.GetType().Assembly);
		}
	}
}