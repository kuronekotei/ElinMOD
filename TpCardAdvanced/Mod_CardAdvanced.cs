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

namespace TpCardAdvanced
{
	[BepInPlugin("net.kuronekotei.card_advanced", "CardAdvanced", "1.0.0.0")]
	public class Mod_CardAdvanced : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("CardAdvanced").PatchAll();
			CommandRegistry.assemblies.Add(this.GetType().Assembly);
		}
	}
}