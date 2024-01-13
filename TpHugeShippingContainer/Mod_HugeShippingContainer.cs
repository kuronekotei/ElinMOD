using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpHugeShippingContainer
{
	[BepInPlugin("net.kuronekotei.huge_shipping_container", "HugeShippingContainer", "1.0.0.0")]
	public class Mod_HugeShippingContainer : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("HugeShippingContainer").PatchAll();
		}
	}
}
