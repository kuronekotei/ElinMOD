using HarmonyLib;

using ReflexCLI.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using static ActPlan;

namespace TpGoodLand
{
	[HarmonyPatch]
	public class GoodLand 
	{
		[HarmonyPrefix, HarmonyPatch(typeof(Zone), nameof(Zone.ListLandFeats))]
		public static void ListLandFeats(Zone __instance) {
			if (__instance.landFeats != null) {
				return;
			}
			__instance.landFeats = new List<int>();
			string[] listBase = __instance.IDBaseLandFeat.Split(',');
			foreach (string str in listBase) {
				if (!str.IsEmpty())
					__instance.landFeats.Add(EClass.sources.elements.alias[str].id);
			}
			if (listBase.Length != 1) {
				return;
			}
			if (listBase[0] == "bfForest") {
				__instance.landFeats.Add(EClass.sources.elements.rows.Find(e => e.alias == "bfFreshAir").id);
				__instance.landFeats.Add(EClass.sources.elements.rows.Find(e => e.alias == "bfFertile").id);
			}
			if (listBase[0] == "bfPlain" || listBase[0] == "bfCave") {
				__instance.landFeats.Add(EClass.sources.elements.rows.Find(e => e.alias == "bfFreshAir").id);
				__instance.landFeats.Add(EClass.sources.elements.rows.Find(e => e.alias == "bfStart").id);
			}
			if (listBase[0] == "bfBeach" || listBase[0] == "bfSea") {
				__instance.landFeats.Add(EClass.sources.elements.rows.Find(e => e.alias == "bfFreshAir").id);
				__instance.landFeats.Add(EClass.sources.elements.rows.Find(e => e.alias == "bfFish").id);
			}
			if (listBase[0] == "bfHill") {
				__instance.landFeats.Add(EClass.sources.elements.rows.Find(e => e.alias == "bfFreshAir").id);
				__instance.landFeats.Add(EClass.sources.elements.rows.Find(e => e.alias == (EClass.rnd(2) == 0 ? "bfVolcano" : "bfRuin")).id);
			}
			if (listBase[0] == "bfSnow") {
				__instance.landFeats.Add(EClass.sources.elements.rows.Find(e => e.alias == "bfFreshAir").id);
				__instance.landFeats.Add(EClass.sources.elements.rows.Find(e => e.alias == (EClass.rnd(2) == 0 ? "bfGeyser" : "bfRuin")).id);
			}
		}

		[HarmonyPostfix, HarmonyPatch(typeof(FactionBranch), nameof(FactionBranch.OnClaimZone))]
		public static void OnClaimZone(FactionBranch __instance) {
			while (__instance.lv < __instance.MaxLv) {
				__instance.Upgrade();
			}
		}


	}
}