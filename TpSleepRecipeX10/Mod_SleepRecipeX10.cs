using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpSleepRecipeX10
{
	[BepInPlugin("net.kuronekotei.sleep_recipe_x10", "SleepRecipeX10", "1.0.0.0")]
	public class Mod_SleepRecipeX10 : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("SleepRecipeX10").PatchAll();
		}
	}
}
