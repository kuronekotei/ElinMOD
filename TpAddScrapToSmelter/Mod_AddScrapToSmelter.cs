using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpAddScrapToSmelter
{
	[BepInPlugin("net.kuronekotei.add_scrap_to_smelter", "AddScrapToSmelter", "1.0.0.0")]
	public class Mod_AddScrapToSmelter : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("AddScrapToSmelter").PatchAll();
		}
	}
}
