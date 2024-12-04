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

namespace TpMapSize
{
	[BepInPlugin("net.kuronekotei.map_size", "MapSize", "1.0.0.0")]
	public class Mod_MapSize : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("MapSize").PatchAll();
			CommandRegistry.assemblies.Add(this.GetType().Assembly);
		}
	}
}