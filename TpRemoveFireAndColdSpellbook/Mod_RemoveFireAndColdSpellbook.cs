using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpRemoveFireAndColdSpellbook
{
	[BepInPlugin("net.kuronekotei.remove_fire_and_cold_spellbook", "RemoveFireAndColdSpellbook", "1.0.0.0")]
	public class Mod_RemoveFireAndColdSpellbook : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("RemoveFireAndColdSpellbook").PatchAll();
		}
	}
}
