using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpAddGlassToSmelter
{
	[BepInPlugin("net.kuronekotei.add_glass_to_smelter", "AddGlassToSmelter", "1.0.0.0")]
	public class Mod_AddGlassToSmelter : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("AddGlassToSmelter").PatchAll();
		}
	}
}
