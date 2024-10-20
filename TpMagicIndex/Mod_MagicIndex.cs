using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

using UnityEngine;

using static Lang;

namespace TpMagicIndex
{
	[BepInPlugin("net.kuronekotei.magic_index", "MagicIndex", "1.0.0.0")]
	public class Mod_MagicIndex : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("MagicIndex").PatchAll();
		}

		public void OnStartCore() {
			MagicIndex.OnStartCore();
		}
	}
}