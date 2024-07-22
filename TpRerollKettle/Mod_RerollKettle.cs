using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpRerollKettle
{
	[BepInPlugin("net.kuronekotei.reroll_kettle", "RerollKettle", "1.0.0.0")]
	public class Mod_RerollKettle : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("RerollKettle").PatchAll();
		}
	}
}
