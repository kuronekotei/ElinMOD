using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;
using UnityEngine;

namespace TpRemoveFireAndColdSpellbook
{
	[HarmonyPatch]
	public class RemoveFireAndColdSpellbook
    {
		[HarmonyPostfix, HarmonyPatch(typeof(Game), nameof(Game.OnGameInstantiated))]
		public static void OnGameInstantiated_Postfix() {
			List<SourceElement.Row> list = EClass.sources.elements.rows;
			list.Find(x => x.alias == "eleFire").tag = new string[] { };
			list.Find(x => x.alias == "eleCold").tag = new string[] { };
		}

	}
}
