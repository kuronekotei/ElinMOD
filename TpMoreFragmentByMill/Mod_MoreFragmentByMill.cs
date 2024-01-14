using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpMoreFragmentByMill
{
	[BepInPlugin("net.kuronekotei.more_fragment_by_mill", "MoreFragmentByMill", "1.0.0.0")]
	public class Mod_MoreFragmentByMill : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("MoreFragmentByMill").PatchAll();
		}
	}
}
