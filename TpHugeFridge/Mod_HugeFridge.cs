using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpHugeFridge
{
	[BepInPlugin("net.kuronekotei.huge_fridge", "HugeFridge", "1.0.0.0")]
	public class Mod_HugeFridge : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("HugeFridge").PatchAll();
		}
	}
}
