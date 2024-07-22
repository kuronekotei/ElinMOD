using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;


namespace TpFreeDomain
{
	[BepInPlugin("net.kuronekotei.diligence_peaple", "FreeDomain", "1.0.0.0")]
	public class Mod_FreeDomain : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("FreeDomain").PatchAll();
		}
	}
}
