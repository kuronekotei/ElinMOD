using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using UnityEngine;

namespace TpAnyStethoscope
{
	[HarmonyPatch]
	public class AnyStethoscope
	{
		[HarmonyPrefix, HarmonyPatch(typeof(TraitStethoscope), nameof(TraitStethoscope.TrySetHeldAct))]
		public static bool TrySetHeldAct(TraitStethoscope __instance, ActPlan p) {
			p.pos.ListCards().ForEach((Action<Card>)(a =>
			{
				Chara c = a.Chara;
				if (c == null || !p.IsSelfOrNeighbor || !EClass.pc.CanSee(a))
					return;
				p.TrySetAct("actInvestigate", (Func<bool>)(() =>
				{
					EClass.pc.Say("use_scope", (Card)c, __instance.owner);
					EClass.pc.Say("use_scope2", (Card)c);
					c.Talk("pervert2");
					EClass.ui.AddLayer<LayerChara>().SetChara(c);
					__instance.owner.ModCharge(-1);
					if (__instance.owner.c_charges <= 0) {
						EClass.pc.Say("spellbookCrumble", __instance.owner);
						__instance.owner.Destroy();
					}
					return false;
				}), (Card)c);
			}));
			return false;
		}

	}
}
