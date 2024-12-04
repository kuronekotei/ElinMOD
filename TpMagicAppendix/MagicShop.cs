using HarmonyLib;

using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using UnityEngine;

namespace TpMagicAppendix
{
	[HarmonyPatch]
	public class MagicShop
	{
		[HarmonyPrefix, HarmonyPatch(typeof(Trait), nameof(Trait.OnBarter))]
		public static void OnBarterPrefix(Trait __instance) {
			__instance.owner.isRestocking = false;

			if (EClass.world.date.IsExpired(__instance.owner.c_dateStockExpire)) {
				Thing t = __instance.owner.things.Find("chest_merchant");
				t?.things.ChangeSize(t.things.width, Mathf.Min(Mathf.Max(Mathf.Max(t.things.Count / t.things.width + 1, 5), t.things.height), 10));
			}
		}

		[HarmonyPostfix, HarmonyPatch(typeof(Trait), nameof(Trait.OnBarter))]
		public static void OnBarter(Trait __instance) {
			if (__instance.ShopType != ShopType.Magic) {
				return;
			}

			//	再入荷前なら処理終了
			if (!__instance.owner.isRestocking) {
				return;
			}

			//	鞄を捕まえる
			Thing t = __instance.owner.things.Find("chest_merchant");
			if (t == null) {
				//	鞄がない時は作って持たせる
				t = ThingGen.Create("chest_merchant");
				__instance.owner.AddThing(t);
			}

			List<string> spellName = new List<string>() {
				nameof(Source_MagicAppendix.TpDemolition),
				nameof(Source_MagicAppendix.TpDrilling),
				nameof(Source_MagicAppendix.TpPullingRug),
				nameof(Source_MagicAppendix.TpCollectAll),
				nameof(Source_MagicAppendix.TpGathering),
				nameof(Source_MagicAppendix.TpReturnG),
				nameof(Source_MagicAppendix.TpTeleportG),
				nameof(Source_MagicAppendix.TpSenceObject),
				nameof(Source_MagicAppendix.TpClearSky),
				nameof(Source_MagicAppendix.TpBringRain),
				nameof(Source_MagicAppendix.TpCreateWind),
				nameof(Source_MagicAppendix.TpForceOvulation),
				nameof(Source_MagicAppendix.TpForceMilking),
				nameof(Source_MagicAppendix.TpForceSqueeze),
				nameof(Source_MagicAppendix.TpBrainwash),
			};

			//	鞄にアイテムを入れる
			t.AddThing(ThingGen.CreateSpellbook(spellName.RandomItem()).Identify(false));
			t.AddThing(ThingGen.CreateSpellbook(spellName.RandomItem()).Identify(false));


			//	鞄が溢れたら鞄の列を増やす
			if (t.things.Count > t.things.GridSize) {
				t.things.ChangeSize(t.things.width, (t.things.Count + t.things.width - 1) / t.things.width);
			}
		}
	}
}
