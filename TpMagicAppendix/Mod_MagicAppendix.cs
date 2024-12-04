using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

using UnityEngine;

using static Lang;

namespace TpMagicAppendix
{
	[BepInPlugin("net.kuronekotei.magic_appendix", "MagicAppendix", "1.0.0.0")]
	public class Mod_MagicAppendix : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("MagicIMagicAppendixndex").PatchAll();
		}

		public void OnStartCore() {
			Source_MagicAppendix.OnStartCore();
		}
	}
}