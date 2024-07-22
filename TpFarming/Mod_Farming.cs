using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

using UnityEngine;

namespace TpFarming
{
	[BepInPlugin("net.kuronekotei.farming", "Farming", "1.0.0.0")]
	public class Mod_Farming : BaseUnityPlugin
	{
		private void Start() {
			Debug.Log("Mod_Farming Start");
			new Harmony("Farming").PatchAll();
		}
	}
}
