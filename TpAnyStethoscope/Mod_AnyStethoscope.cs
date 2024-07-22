using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpAnyStethoscope
{
	[BepInPlugin("net.kuronekotei.any_stethoscope", "AnyStethoscope", "1.0.0.0")]
	public class Mod_AnyStethoscope : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("AnyStethoscope").PatchAll();
		}
	}
}
