using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using BepInEx;
using HarmonyLib;
using UnityEngine;

using ReflexCLI.Attributes;
using static TextureReplace;
using System.Net.NetworkInformation;
using static ActPlan;


namespace TpLoginBonus
{
	[HarmonyPatch]
	public class LoginBonus
	{
		static ModConfig config;
		public static void OnStartCore() {
			config = Mod_LoginBonus.ModConfig;
		}

		[HarmonyPrefix, HarmonyPatch(typeof(Zone), nameof(Zone.OnActivate))]
		public static void OnActivate(Zone __instance) {
			GetLoginBonus();
			return;
		}

		[HarmonyPrefix, HarmonyPatch(typeof(Zone), nameof(Zone.OnAdvanceHour))]
		public static void OnAdvanceHour(Zone __instance) {
			GetLoginBonus();
			return;
		}

		public static void GetLoginBonus() {
			if (EClass.pc == null) { return; }
			DataLoginBonus data = EClass.pc.GetObj<DataLoginBonus>(222222001);
			if (data == null) {
				data = new DataLoginBonus();
			}
			if (data.LastDate == DateTime.Now.ToString("yyyyMMdd")) { return; }

			Debug.Log($"GetLoginBonus");
			Thing t = GetThing(data.TotalDate + 1);
			EClass.world.SendPackage(ThingGen.CreateParcel(Lang.isJP ? $"ログインボーナス {data.TotalDate + 1}日目" : $"LoginBonus day {data.TotalDate + 1}", t));
			EClass.pc.SetObj<DataLoginBonus>(222222001, new DataLoginBonus { LastDate = DateTime.Now.ToString("yyyyMMdd"), TotalDate = data.TotalDate + 1 });
		}

		public static Thing GetThing(int i) {
			int idx = i % 30;
			int loop = i / 30;
			int fame = Math.Abs(EClass.player.fame);
			List<SourceThing.Row> list = EClass.sources.things.rows;
			switch (idx) {
				case 1: return ThingGen.CreateCurrency(fame);
				case 2: return ThingGen.CreateCurrency((int)Math.Sqrt(fame / 100) + 1, "plat");
				case 3: return ThingGen.CreateScroll(SPELL.SpLighten, (int)Math.Sqrt(fame / 1000) + 1);
				case 4: return ThingGen.Create("monsterball").SetLv(fame / 100).SetNum((int)Math.Sqrt(fame / 1000) + 1);
				case 5: return ThingGen.Create(list?.Find(x => x.name_JP == "癒しの女神像").id);
				case 6: {
						Thing t = ThingGen.CreateCurrency(10, "goodness");
						t.elements.SetTo(ELEMENT.comfort, (int)Math.Sqrt(fame / 100) + 80);
						return t;
					}
				case 7: return ThingGen.CreateScroll(SPELL.SpEnchantArmorGreat, (int)Math.Sqrt(fame / 1000) + 1);
				case 8: return ThingGen.Create("rod_wish");
				case 9: return ThingGen.Create(list?.Find(x => x.name_JP == "風の女神像").id);
				case 10: {
						CardBlueprint.Set(new CardBlueprint() {
							lv = i,
							rarity = Rarity.Normal,
							blesstedState = BlessedState.Blessed,
							
						});
						Thing t = ThingGen.Create(list?.Find(x => x.name_JP == "合成腰当").id, 25/*竜鱗*/, i);
						t.elements.SetTo(SKILL.mining, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.lumberjack, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.digging, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.fishing, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.gathering, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.taming, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.farming, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.handicraft, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.rarity = Rarity.Mythical;
						t.encLV = 6;
						return t;
					}
				case 11: return ThingGen.CreateCurrency((int)Math.Sqrt(fame / 1000) + 1, "gacha_coin");
				case 12: return ThingGen.CreateCurrency((int)Math.Sqrt(fame / 100) + 1, "casino_coin");
				case 13: return ThingGen.Create(list?.Find(x => x.name_JP == "元素の神像").id);
				case 14: return ThingGen.CreateScroll(SPELL.SpFaith, (int)Math.Sqrt(fame / 1000) + 1);
				case 15: return ThingGen.Create(list?.Find(x => x.name_JP == "収穫の神像").id);
				case 16: return ThingGen.CreateCurrency((int)Math.Sqrt(fame / 1000) + 1, "gacha_coin_silver");
				case 17: {
						Thing t = ThingGen.CreateCurrency(10, "nobility");
						t.elements.SetTo(ELEMENT.comfort, (int)Math.Sqrt(fame / 100) + 10);
						return t;
					}
				case 18: return ThingGen.Create(list?.Find(x => x.name_JP == "大地の神像").id);
				case 19: return ThingGen.CreateScroll(SPELL.SpReconstruction, (int)Math.Sqrt(fame / 1000) + 1);
				case 20: {
						CardBlueprint.Set(new CardBlueprint() {
							lv = i,
							rarity = Rarity.Normal,
							blesstedState = BlessedState.Blessed,

						});
						Thing t = ThingGen.Create(list?.Find(x => x.name_JP == "合成腰当").id, 25/*竜鱗*/, i);
						t.elements.SetTo(SKILL.handicraft, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.carpentry, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.blacksmith, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.alchemy, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.sculpture, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.jewelry, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.weaving, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.cooking, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.rarity = Rarity.Mythical;
						t.encLV = 6;
						return t;
					}
				case 21: return ThingGen.CreateCurrency((int)Math.Sqrt(fame / 100) + 1, "medal");
				case 22: return ThingGen.CreateCurrency((int)Math.Sqrt(fame / 1000) + 1, "gacha_coin_gold");
				case 23: {
						CardBlueprint.Set(new CardBlueprint() {
							lv = i,
							rarity = Rarity.Normal,
							blesstedState = BlessedState.Blessed,

						});
						Thing t = ThingGen.Create(list?.Find(x => x.name_JP == "スピードの指輪").id, 25/*竜鱗*/, i);
						t.elements.SetTo(SKILL.mining, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.lumberjack, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.digging, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.fishing, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.gathering, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.taming, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.farming, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.handicraft, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.rarity = Rarity.Mythical;
						t.encLV = 6;
						return t;
					}
				case 24: return ThingGen.Create(list?.Find(x => x.name_JP == "機械の神像").id);
				case 25: return ThingGen.CreateScroll(SPELL.SpEnchantWeaponGreat, (int)Math.Sqrt(fame / 1000) + 1);
				case 26: {
						CardBlueprint.Set(new CardBlueprint() {
							lv = i,
							rarity = Rarity.Normal,
							blesstedState = BlessedState.Blessed,

						});
						Thing t = ThingGen.Create(list?.Find(x => x.name_JP == "スピードの指輪").id, 25/*竜鱗*/, i);
						t.elements.SetTo(SKILL.handicraft, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.carpentry, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.blacksmith, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.alchemy, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.sculpture, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.jewelry, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.weaving, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.elements.SetTo(SKILL.cooking, (int)Math.Sqrt(fame / 1000) + 1 + loop);
						t.rarity = Rarity.Mythical;
						t.encLV = 6;
						return t;
					}
				case 27: return ThingGen.Create(list?.Find(x => x.name_JP == "幸運の女神像").id);
				case 28: return ThingGen.CreateCurrency((int)Math.Sqrt(fame / 1000) + 1, list?.Find(x => x.name_JP == "エーテル抗体のポーション").id);
				case 29: {
						Thing t = ThingGen.CreateCurrency(10, "ticket_furniture");
						TraitTicketFurniture.SetZone(EClass.game.spatials.Find("little_garden"), t);
						return t;
					}
				default: return ThingGen.Create(list?.Find(x => x.name_JP == "土地の権利書").id);
			}
		}
	}

	public class DataLoginBonus {
		public string LastDate = "";
		public int TotalDate = 0;

	}
}
