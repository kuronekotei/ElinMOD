using HarmonyLib;

using ReflexCLI.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace TpLoytelMart
{
	[HarmonyPatch]
	public class LoytelMart 
	{
		[HarmonyPrefix, HarmonyPatch(typeof(Trait), nameof(Trait.OnBarter))]
		public static void OnBarterPrefix(Trait __instance) {
			__instance.owner.isRestocking = false;
		}

		[HarmonyPostfix, HarmonyPatch(typeof(Trait), nameof(Trait.OnBarter))]
		public static void OnBarter(Trait __instance) {
			if (__instance.ShopType != ShopType.LoytelMart) {
				return; //	LoytelMartでなければ処理終了
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


			//	鞄にアイテムを入れる
			t.AddThing(ThingGen.Create("flower_white", -1, __instance.ShopLv).SetNum(10));
			t.AddThing(ThingGen.Create("flower_yellow", -1, __instance.ShopLv).SetNum(10));
			t.AddThing(ThingGen.Create("flower_blue", -1, __instance.ShopLv).SetNum(100));

			var rod_wish = ThingGen.Create("rod_wish", -1, __instance.ShopLv);
			rod_wish.SetCharge(EClass.rnd(100) == 0?1:0);
			t.AddThing(rod_wish);

			var figure = ThingGen.Create("figure");
			figure.MakeFigureFrom("loytel");
			figure.SetEncLv(1);
			t.AddThing(figure);

			var figure2 = ThingGen.Create("figure");
			figure2.MakeFigureFrom("loytel");
			figure2.SetEncLv(2);
			t.AddThing(figure2);

			var figure3 = ThingGen.Create("figure3");
			figure3.MakeFigureFrom("loytel");
			figure3.SetPriceFix(9900);
			t.AddThing(figure3);

			var meat = ThingGen.Create(EClass.rnd(10) == 0? "meat_marble": "_meat");
			meat.MakeFoodFrom("loytel");
			t.AddThing(meat);

			var junk = ThingGen.CreateFromFilter("shop_junk", __instance.ShopLv);
			junk.ChangeMaterial(0);
			junk.SetPriceFix(9900);
			t.AddThing(junk);


			//	鞄が溢れたら鞄の列を増やす
			if (t.things.Count > t.things.GridSize) {
				t.things.ChangeSize(t.things.width,(t.things.Count + t.things.width  - 1) / t.things.width);
			}
		}


	}
}