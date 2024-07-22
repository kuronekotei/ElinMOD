using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpNoCapAlly
{
	[BepInPlugin("net.kuronekotei.no_cap_ally", "NoCapAlly", "1.0.0.0")]
	public class Mod_NoCapAlly : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("NoCapAlly").PatchAll();
		}
	}
}
