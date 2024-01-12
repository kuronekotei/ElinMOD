using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;


namespace TpDiligencePeaple
{
	[BepInPlugin("net.kuronekotei.diligence_peaple", "DiligencePeaple", "1.0.0.0")]
	public class Mod_DiligencePeaple : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("DiligencePeaple").PatchAll();
		}
	}
}
