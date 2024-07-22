using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpPopulation
{
	
	[BepInPlugin("net.kuronekotei.population", "Population", "1.0.0.0")]
	public class Mod_Population : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("Population").PatchAll();
		}
	}
}
