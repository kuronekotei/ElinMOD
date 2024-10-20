using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using HarmonyLib;

using UnityEngine;

using static TableData;
using static TextureReplace;

namespace TpManyPutit
{
	[HarmonyPatch]
	public class ManyPutit
	{
		public static void OnStartCore() {
			SourceManager sources = Core.Instance.sources;
			List<SourceChara.Row> charas = sources.charas.rows;
			SourceChara.Row putitN = charas.First(x=>x.id=="putty");
			SourceChara.Row putitS = charas.First(x => x.id == "putty_snow");
			SourceChara.Row putitM = charas.First(x => x.id == "putty_metal");
			List<SourceChara.Row> addList = new List<SourceChara.Row> {
				BallPutit(putitN, "tp_putit_ball", "#ele4玉プチ", "#ele4 ball putit", putitM),
				BallPutit(putitS, "tp_putit_ball_snow", "#ele4玉雪プチ", "#ele4 ball snow putit", putitS),
				BallPutit(putitM, "tp_putit_ball_metal", "#ele4玉メタルプチ", "#ele4 ball metal putit", putitM),
				ArrowPutit(putitN, "tp_putit_arrow", "#ele4矢プチ", "#ele4 arrow putit", putitM),
				ArrowPutit(putitS, "tp_putit_arrow_snow", "#ele4矢雪プチ", "#ele4 arrow snow putit", putitS),
				ArrowPutit(putitM, "tp_putit_arrow_metal", "#ele4矢メタルプチ", "#ele4 arrow metal putit", putitM),
				HandPutit(putitN, "tp_putit_hand", "#ele4手プチ", "#ele4 hand putit", putitM),
				HandPutit(putitS, "tp_putit_hand_snow", "#ele4手雪プチ", "#ele4 hand snow putit", putitS),
				HandPutit(putitM, "tp_putit_hand_metal", "#ele4手メタルプチ", "#ele4 hand metal putit", putitM),
				SummonPutit(putitN, "tp_putit_summon", "#ele4召喚プチ", "#ele4 summon putit", putitM),
				SummonPutit(putitS, "tp_putit_summon_snow", "#ele4召喚雪プチ", "#ele4 summon snow putit", putitS),
				SummonPutit(putitM, "tp_putit_summon_metal", "#ele4召喚メタルプチ", "#ele4 summon metal putit", putitM),
				BombPutit(putitN, "tp_putit_bomb", "爆弾プチ", "bomb putit", putitM),
				DefenderPutit(putitN, "tp_putit_defender", "#ele4防衛プチ", "#ele4 defender putit", putitM),

			};
			foreach(var addItem in addList) {
				sources.charas.rows.Add(addItem);
			}
		}

		public static T CreateCopy<T>(T baseItem) where T : new() {
			System.Reflection.FieldInfo[] fields = baseItem.GetType().GetFields();
			T newItem = new T();
			foreach (System.Reflection.FieldInfo fieldInfo in fields) {
				newItem.SetField<object>(fieldInfo.Name, baseItem.GetField<object>(fieldInfo.Name));
			}
			return newItem;
		}

		public static SourceChara.Row BallPutit(SourceChara.Row baseChara, string newId, string name_JP, string name, SourceChara.Row tileBase) {
			var c = CreateCopy(baseChara);
			c.id = newId;
			c.name = name;
			c.name_JP = name_JP;
			c.LV += 30;
			c.job = "predator";
			c.mainElement = new string[] { "Fire", "Cold", "Lightning", "Darkness", "Mind", "Poison", "Nerve", "Nether", "Sound", "Chaos", "Ether", "Cut", "Acid", "Magic", "Impact" };
			c.actCombat = c.actCombat.AddRangeToArray(new string[] { "ball_/80", "funnel_/20" });
			c.lightData = "wisp";
			c.elements = c.elements.AddRangeToArray(new int[] { SKILL.mana, 100, FEAT.featSplit, 1, SKILL.evasionPerfect, 20, SKILL.controlmana, 100, SKILL.casting, 100 });
			c.colorMod = 100;
			c.tiles = tileBase.tiles;
			c._tiles = tileBase._tiles;
			return c;
		}

		public static SourceChara.Row ArrowPutit(SourceChara.Row baseChara, string newId, string name_JP, string name, SourceChara.Row tileBase) {
			var c = CreateCopy(baseChara);
			c.id = newId;
			c.name = name;
			c.name_JP = name_JP;
			c.LV += 15;
			c.job = "archer";
			c.mainElement = new string[] { "Fire", "Cold", "Lightning", "Darkness", "Mind", "Poison", "Nerve", "Nether", "Sound", "Chaos", "Ether", "Cut", "Acid", "Magic", "Impact" };
			c.actCombat = c.actCombat.AddRangeToArray(new string[] { "arrow_/80", "bolt_/20" });
			c.lightData = "wisp";
			c.elements = c.elements.AddRangeToArray(new int[] { SKILL.mana, 100, FEAT.featSplit, 1, SKILL.evasionPerfect, 20, SKILL.controlmana, 100, SKILL.casting, 100 });
			c.colorMod = 100;
			c.tiles = tileBase.tiles;
			c._tiles = tileBase._tiles;
			return c;
		}

		public static SourceChara.Row HandPutit(SourceChara.Row baseChara, string newId, string name_JP, string name, SourceChara.Row tileBase) {
			var c = CreateCopy(baseChara);
			c.id = newId;
			c.name = name;
			c.name_JP = name_JP;
			c.LV += 10;
			c.job = "predator";
			c.mainElement = new string[] { "Fire", "Cold", "Lightning", "Darkness", "Mind", "Poison", "Nerve", "Nether", "Sound", "Chaos", "Ether", "Cut", "Acid", "Magic", "Impact" };
			c.actCombat = c.actCombat.AddRangeToArray(new string[] { "hand_/80", "ActDraw/20" });
			c.lightData = "wisp";
			c.elements = c.elements.AddRangeToArray(new int[] { SKILL.mana, 100, FEAT.featSplit, 1, SKILL.controlmana, 100, SKILL.casting, 100 });
			c.colorMod = 100;
			c.tiles = tileBase.tiles;
			c._tiles = tileBase._tiles;
			return c;
		}

		public static SourceChara.Row SummonPutit(SourceChara.Row baseChara, string newId, string name_JP, string name, SourceChara.Row tileBase) {
			var c = CreateCopy(baseChara);
			c.id = newId;
			c.name = name;
			c.name_JP = name_JP;
			c.LV += 20;
			c.job = "wizard";
			c.tactics = "summoner";
			c.mainElement = new string[] { "Fire", "Cold", "Lightning", "Darkness", "Mind", "Poison", "Nerve", "Nether", "Sound", "Chaos", "Ether", "Cut", "Acid", "Magic", "Impact" };
			c.actCombat = c.actCombat.AddRangeToArray(new string[] { "funnel_/80", "SpSummonTentacle/20", "SpHOT/20/pt" });
			c.lightData = "wisp";
			c.elements = c.elements.AddRangeToArray(new int[] { SKILL.mana, 200, FEAT.featSplit, 1, SKILL.evasionPerfect, 20, SKILL.controlmana, 100, SKILL.casting, 100, FEAT.featMilitant, 1 });
			c.colorMod = 100;
			c.tiles = tileBase.tiles;
			c._tiles = tileBase._tiles;
			return c;
		}

		public static SourceChara.Row BombPutit(SourceChara.Row baseChara, string newId, string name_JP, string name, SourceChara.Row tileBase) {
			var c = CreateCopy(baseChara);
			c.id = newId;
			c.name = name;
			c.name_JP = name_JP;
			c.LV += 22;
			c.job = "predator";
			c.mainElement = new string[] { "Impact" };
			c.tag = c.tag.AddRangeToArray(new string[] { "kamikaze" });
			c.actCombat = c.actCombat.AddRangeToArray(new string[] { "ActSuicide/100" });
			c.lightData = "wisp";
			c.elements = c.elements.AddRangeToArray(new int[] { SKILL.mana, 100, FEAT.featSplit, 1, SKILL.evasionPerfect, 20, SKILL.controlmana, 100, SKILL.casting, 100, FEAT.featGolem, 1 });
			c.colorMod = 100;
			c.tiles = tileBase.tiles;
			c._tiles = tileBase._tiles;
			return c;
		}

		public static SourceChara.Row DefenderPutit(SourceChara.Row baseChara, string newId, string name_JP, string name, SourceChara.Row tileBase) {
			var c = CreateCopy(baseChara);
			c.id = newId;
			c.name = name;
			c.name_JP = name_JP;
			c.LV += 25;
			c.chance = 20;
			c.job = "paladin";
			c.faith = "healing";
			c.tactics = "tank";
			c.mainElement = new string[] { "Fire", "Cold", "Lightning", "Darkness", "Mind", "Poison", "Nerve", "Nether", "Sound", "Chaos", "Ether", "Cut", "Acid", "Magic", "Impact" };
			c.actCombat = c.actCombat.AddRangeToArray(new string[] { "hand_/80", "ActRush/20", "SpRevive" });
			c.lightData = "wisp";
			c.elements = c.elements.AddRangeToArray(new int[] { SKILL.life, 50, SKILL.mana, 100, FEAT.featSplit, 1, SKILL.PDR, 40, SKILL.EDR, 40, SKILL.controlmana, 100, SKILL.casting, 100, FEAT.featLoyal, 1 });
			c.colorMod = 100;
			c.tiles = tileBase.tiles;
			c._tiles = tileBase._tiles;
			return c;
		}
	}
}
