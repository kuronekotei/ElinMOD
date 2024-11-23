using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

using ReflexCLI.Attributes;

using UnityEngine;


namespace TpPerfectTrainer
{
	[HarmonyPatch]
	public class PerfectTrainer
	{

		static string lastSeq = "";
		[HarmonyPrefix, HarmonyPatch(typeof(DramaSequence), nameof(DramaSequence.Play), new Type[] { typeof(string) })]
		public static void Play(DramaSequence __instance, string id) {
			lastSeq = id;
		}


		[HarmonyPrefix, HarmonyPatch(typeof(UIList), nameof(UIList.List), new Type[] { typeof(UIList.SortMode), typeof(bool) })]
		public static bool List(UIList __instance, UIList.SortMode m, bool refreshHighlight) {
			if (lastSeq != "_train") {
				return true;
			}
			if (!EClass._zone.IsPCFaction) {
				return true;
			}
			__instance.sortMode = m;
			__instance.Clear();
			foreach (SourceElement.Row row in EClass.sources.elements.rows.Where<SourceElement.Row>((Func<SourceElement.Row, bool>)(a => {
				if (ClassExtension.Contains(a.tag, "unused")) {
					return false;
				}
				if(a.category != "skill") {
					return false;
				}
				return !string.IsNullOrWhiteSpace(TraitTrainer.ids.FirstOrDefault(x => x == a.categorySub));
			})).ToList<SourceElement.Row>()
			) {
				__instance.items.Add((object)Element.Create(row.id));
			}

			__instance.Refresh(refreshHighlight);
			return false;
		}
	}
}
