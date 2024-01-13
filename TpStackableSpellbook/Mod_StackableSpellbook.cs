using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpStackableSpellbook
{
	[BepInPlugin("net.kuronekotei.stackable_spellbook", "StackableSpellbook", "1.0.0.0")]
	public class Mod_StackableSpellbook : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("StackableSpellbook").PatchAll();
		}
	}
}
