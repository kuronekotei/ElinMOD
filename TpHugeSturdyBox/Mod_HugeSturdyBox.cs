using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpHugeSturdyBox
{
	[BepInPlugin("net.kuronekotei.huge_sturdy_box", "HugeSturdyBox", "1.0.0.0")]
	public class Mod_HugeSturdyBox : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("HugeSturdyBox").PatchAll();
		}
	}
}
