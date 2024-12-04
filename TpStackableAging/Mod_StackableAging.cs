using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpStackableAging
{
	[BepInPlugin("net.kuronekotei.stackable_aging", "StackableAging", "1.0.0.0")]
	public class Mod_StackableAging : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("StackableAging").PatchAll();
		}
	}
}
