using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpRemoveUnhealthyHobby
{
	[BepInPlugin("net.kuronekotei.remove_unhealthy_hobby", "RemoveUnhealthyHobby", "1.0.0.0")]
	public class Mod_RemoveUnhealthyHobby : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("RemoveUnhealthyHobby").PatchAll();
		}
	}
}
