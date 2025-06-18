using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using HarmonyLib;
using UnityEngine;

using static ActPlan;

namespace TpHugeMailPost
{
	[HarmonyPatch]
	public class HugeMailPost
    {

		static ModConfig config;
		public static void OnStartCore() {
			config = Mod_HugeMailPost.ModConfig;

			SourceManager sources = Core.Instance.sources;

			FixContainerSize(sources.things.rows?.Find(x => x.name_JP == "郵便受け"), config.W.Value, config.H.Value);

			sources.things.Reset();
		}

		private static void FixContainerSize(SourceThing.Row thing, int w, int h) {
			var traits = thing?.trait;
			if (traits == null) {
				return;
			}
			for (int i = 0; i < traits.Count(); i++) {
				try {
					if (Regex.Match(traits[i], @"^(Container.*)|(.*Chest)|(Fridge)|(MailPost)$").Success
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
