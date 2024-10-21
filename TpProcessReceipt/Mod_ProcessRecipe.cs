using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

using UnityEngine;

using static Lang;

namespace TpProcessRecipe
{
	[BepInPlugin("net.kuronekotei.process_Recipe", "ProcessRecipe", "1.0.0.0")]
	public class Mod_ProcessRecipe : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("ProcessRecipe").PatchAll();
		}

		public void OnStartCore() {
			ProcessRecipe.OnStartCore();
		}
	}
}