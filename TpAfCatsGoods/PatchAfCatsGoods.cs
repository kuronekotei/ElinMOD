using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

using BepInEx;

using HarmonyLib;

using ReflexCLI.Attributes;

using UnityEngine;

namespace TpAfCatsGoods
{
	[HarmonyPatch]
	public class PatchAfCatsGoods
	{
		[HarmonyPrefix, HarmonyPatch(typeof(LayerInventory), nameof(LayerInventory.CreateContainer), new Type[] { typeof(Card) })]
		public static bool CreateContainer(LayerInventory __instance, ref LayerInventory __result, Card owner) {
			if (owner.trait is TraitTpCatsBag) {
				if (LayerInventory.listInv.Find(x => x.Inv.owner == owner) is LayerInventory inv) {
					inv.Close();
				} else { 
					__result = LayerInventory.CreateContainer(owner, owner);
				}
				LayerInventory.SetDirty(owner.Thing);
				return false;
			}
			return true;
		}

		[HarmonyPrefix, HarmonyPatch(typeof(ThingContainer), nameof(ThingContainer.MaxCapacity), MethodType.Getter)]
		public static bool MaxCapacity(ThingContainer __instance, ref int __result) {
			if (__instance.owner.trait is TraitTpCatsBag) {
				__result = 860 + __instance.owner.c_containerUpgrade.cap;
				return false;
			}
			return true;
		}

		[HarmonyPrefix, HarmonyPatch(typeof(ThingContainer), nameof(ThingContainer.IsFull), new Type[] { typeof(int) })]
		public static bool IsFull(ThingContainer __instance, ref bool __result) {
			if (__instance.owner.trait is TraitTpCatsBag) {
				__result = __instance.Count >= __instance.MaxCapacity;
				return false;
			}
			return true;
		}
	}
}
