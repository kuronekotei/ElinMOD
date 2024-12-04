using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using UnityEngine;

namespace TpMagicAppendix
{
	[HarmonyPatch]
	public partial class Source_MagicAppendix
	{
		public static void OnStartCore() {
			var sources = Core.Instance.sources;
			;
			List<SourceElement.Row> elements = sources.elements.rows;
			var SpTeleport = elements.Find(x => x.alias == "SpTeleport");
			List<SourceElement.Row> addList = new List<SourceElement.Row> {
				TpDemolition(SpTeleport),
				TpDrilling(SpTeleport),
				TpPullingRug(SpTeleport),
				TpCollectAll(SpTeleport),
				TpGathering(SpTeleport),
				TpReturnG(SpTeleport),
				TpTeleportG(SpTeleport),
				TpSenceObject(SpTeleport),
				TpClearSky(SpTeleport),
				TpBringRain(SpTeleport),
				TpCreateWind(SpTeleport),
				TpForceOvulation(SpTeleport),
				TpForceMilking(SpTeleport),
				TpForceSqueeze(SpTeleport),
				TpBrainwash(SpTeleport),
				TpEternalForceBlizzard(SpTeleport),
			};
			foreach (var addItem in addList) {
				sources.elements.rows.Add(addItem);
			}
			sources.elements.Reset();
		}

		public static T CreateCopy<T>(T baseItem) where T : new() {
			System.Reflection.FieldInfo[] fields = baseItem.GetType().GetFields();
			T newItem = new T();
			foreach (System.Reflection.FieldInfo fieldInfo in fields) {
				newItem.SetField<object>(fieldInfo.Name, baseItem.GetField<object>(fieldInfo.Name));
			}
			return newItem;
		}

		public static SourceElement.Row TpEternalForceBlizzard(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223999;
			c.alias = nameof(TpEternalForceBlizzard);
			c.name_JP = "エターナルフォースブリザード";
			c.name = "EternalForceBlizzard";
			c.aliasParent = nameof(SKILL.LUC);
			c.parentFactor = 0;
			c.chance = 10;
			c.detail_JP = "敵は死ぬ。";
			c.detail = "Enemy dies.";
			c.thing = "B";
			c.target = "Self";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			c.LV = 99;
			c.value = 1000000;
			c.charge = 1;
			c.cost = new int[] { 9999 };
			c.tag = new string[] {  };
			return c;
		}
		public static SourceElement.Row TpGathering(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223005;
			c.alias = nameof(TpGathering);
			c.name_JP = "収集";
			c.name = "Gathering";
			c.aliasParent = nameof(SKILL.LUC);
			c.parentFactor = 0;
			c.chance = 100;
			c.detail_JP = "何かを集める。";
			c.detail = "Get something.";
			c.thing = "B";
			c.target = "Self";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}
		public static SourceElement.Row TpCollectAll(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223004;
			c.alias = nameof(TpCollectAll);
			c.name_JP = "回収";
			c.name = "CollectAll";
			c.aliasParent = nameof(SKILL.DEX);
			c.chance = 100;
			c.detail_JP = "マップ上で拾えるものをすべて拾う。";
			c.detail = "Collect all pickable things in map.";
			c.thing = "B";
			c.target = "Self";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}


		public static SourceElement.Row TpDemolition(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223001;
			c.alias = nameof(TpDemolition);
			c.name_JP = "粉砕";
			c.name = "Demolition";
			c.aliasParent = nameof(SKILL.STR);
			c.chance = 100;
			c.detail_JP = "壁を粉砕する。自勢力の場合は回収。(強度判定)";
			c.detail = "Demolition the wall. If in your faction, pick it.(Pow check)";
			c.thing = "B";
			c.target = "Self";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] {  };
			return c;
		}

		public static SourceElement.Row TpDrilling(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223002;
			c.alias = nameof(TpDrilling);
			c.name_JP = "掘削";
			c.name = "Drilling";
			c.aliasParent = nameof(SKILL.STR);
			c.chance = 100;
			c.detail_JP = "壁を掘削する。自勢力の場合は回収。(強度判定)";
			c.detail = "Drilling the wall. If in your faction, pick it.(Pow check)";
			c.thing = "B";
			c.target = "Ground";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}

		public static SourceElement.Row TpPullingRug(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223003;
			c.alias = nameof(TpPullingRug);
			c.name_JP = "畳返し";
			c.name = "PullingRug";
			c.aliasParent = nameof(SKILL.STR);
			c.chance = 100;
			c.detail_JP = "床を返す。自勢力の場合は回収。(強度判定)";
			c.detail = "Demolition the floor. If in your faction, pick it.(Pow check)";
			c.thing = "B";
			c.target = "Self";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}

		public static SourceElement.Row TpReturnG(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223101;
			c.alias = nameof(TpReturnG);
			c.name_JP = "*帰還*";
			c.name = "*Return*";
			c.aliasParent = nameof(SKILL.WIL);
			c.chance = 100;
			c.detail_JP = "一瞬で好きな場所に帰還する。";
			c.detail = "Return to any place in an instant.";
			c.thing = "B";
			c.target = "Self";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}

		public static SourceElement.Row TpTeleportG(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223102;
			c.alias = nameof(TpTeleportG);
			c.name_JP = "*テレポート*";
			c.name = "*Teleport*";
			c.aliasParent = nameof(SKILL.WIL);
			c.chance = 100;
			c.detail_JP = "テレポートする。自身にかけるとランダムな位置に、敵にかけると敵を、地面を狙うとその位置に。";
			c.detail = "Teleports. Cast on yourself to a random location, cast on an enemy to teleport, or aim at the ground to teleport to that location.";
			c.thing = "B";
			c.target = "Ground";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}
		public static SourceElement.Row TpSenceObject(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223103;
			c.alias = nameof(TpSenceObject);
			c.name_JP = "探知";
			c.name = "SenceObject";
			c.aliasParent = nameof(SKILL.PER);
			c.chance = 100;
			c.detail_JP = "物体を探索する。";
			c.detail = "Sence object.";
			c.thing = "B";
			c.target = "Self";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}

		public static SourceElement.Row TpClearSky(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223201;
			c.alias = nameof(TpClearSky);
			c.name_JP = "日照り";
			c.name = "ClearSky";
			c.aliasParent = nameof(SKILL.WIL);
			c.chance = 100;
			c.detail_JP = "天候を操作する。　晴れさせる。";
			c.detail = "Control the weather. Make fine.";
			c.thing = "B";
			c.target = "Self";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}
		public static SourceElement.Row TpBringRain(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223202;
			c.alias = nameof(TpBringRain);
			c.name_JP = "雨乞い";
			c.name = "BringRain";
			c.aliasParent = nameof(SKILL.WIL);
			c.chance = 100;
			c.detail_JP = "天候を操作する。　雨を呼ぶ。";
			c.detail = "Control the weather. Bring rain.";
			c.thing = "B";
			c.target = "Self";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}
		public static SourceElement.Row TpCreateWind(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223203;
			c.alias = nameof(TpCreateWind);
			c.name_JP = "風起こし";
			c.name = "CreateWind";
			c.aliasParent = nameof(SKILL.WIL);
			c.chance = 100;
			c.detail_JP = "天候を操作する。　風を起こす。";
			c.detail = "Control the weather. Create wind.";
			c.thing = "B";
			c.target = "Self";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}
	}
}
