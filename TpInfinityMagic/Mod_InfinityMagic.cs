using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

using UnityEngine;

namespace TpInfinityMagic
{
	[BepInPlugin("net.kuronekotei.infinity_magic", "InfinityMagic", "1.0.0.0")]
	public class Mod_InfinityMagic : BaseUnityPlugin
	{
		private void Start() {
			new Harmony("InfinityMagic").PatchAll();
		}
	}
}
