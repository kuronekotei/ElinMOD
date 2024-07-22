using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using HarmonyLib;
using UnityEngine;

namespace TpPopulation
{
	[HarmonyPatch]
	public class Population
    {
		[HarmonyPrefix, HarmonyPatch(typeof(FactionBranch), nameof(FactionBranch.MaxPopulation), MethodType.Getter)]
		public static bool MaxPopulation(FactionBranch __instance, ref int __result) {
			__result = 100 + __instance.Evalue(2204);
			return false;
		}
	}
}
