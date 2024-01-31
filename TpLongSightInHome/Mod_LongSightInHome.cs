using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpLongSightInHome
{
	[BepInPlugin("net.kuronekotei.huge_fridge", "LongSightInHome", "1.0.0.0")]
	public class Mod_LongSightInHome : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("LongSightInHome").PatchAll();
		}
	}
}
