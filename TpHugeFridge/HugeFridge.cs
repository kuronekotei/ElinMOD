using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using HarmonyLib;
using UnityEngine;

namespace TpHugeFridge
{
	[HarmonyPatch]
	public class HugeFridge
    {
		[HarmonyPrefix, HarmonyPatch(typeof(Game), nameof(Game.OnGameInstantiated))]
		public static void OnGameInstantiated_Prefix() {
			List<SourceThing.Row> list = EClass.sources.things.rows;
			var tgts = list?.FindAll(x => x.name_JP == "冷蔵庫");
			foreach (var tgt in tgts) {
				FixContainerSize(tgt, 12, 18);
			}
		}

		private static void FixContainerSize(SourceThing.Row thing, int w, int h) {
			var traits = thing?.trait;
			if (traits == null) {
				return;
			}
			for (int i = 0; i < traits.Count(); i++) {
				try {
					if (Regex.Match(traits[i], @"^(Container.*)|(.*Chest)|(Fridge)$").Success
						&& (i + 2 < traits.Count())
					) {
						int wx = int.Parse(traits[i + 1]);
						int hx = int.Parse(traits[i + 2]);
						traits[i + 1] = (w).ToString();
						traits[i + 2] = (h).ToString();
						i += 2;
					}

				} catch (Exception) { }
			}
		}
	}
}
