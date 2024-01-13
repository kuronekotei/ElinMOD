using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpHugeTrashContainer
{
	[BepInPlugin("net.kuronekotei.huge_trash_container", "HugeTrashContainer", "1.0.0.0")]
	public class Mod_HugeTrashContainer : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("HugeTrashContainer").PatchAll();
		}
	}
}
