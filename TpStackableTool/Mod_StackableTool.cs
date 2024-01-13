using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpStackableTool
{
	[BepInPlugin("net.kuronekotei.stackable_tool", "StackableTool", "1.0.0.0")]
	public class Mod_StackableTool : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("StackableTool").PatchAll();
		}
	}
}
