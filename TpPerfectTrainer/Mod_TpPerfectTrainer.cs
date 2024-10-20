using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpPerfectTrainer
{
	[BepInPlugin("net.kuronekotei.perfect_trainer", "PerfectTrainer", "1.0.0.0")]
	public class Mod_TpPerfectTrainer : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("PerfectTrainer").PatchAll();
		}
	}
}
