using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using UnityEngine;

namespace TpMagicAppendix
{
	public partial class Source_MagicAppendix
	{
		public static SourceElement.Row TpBrainwash(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223810;
			c.alias = nameof(TpBrainwash);
			c.name_JP = "洗脳";
			c.name = "Brainwash";
			c.aliasParent = nameof(SKILL.CHA);
			c.chance = 100;
			c.detail_JP = "心を支配する。(強度判定)";
			c.detail = "Brainwash Enemy. (Pow check)";
			c.thing = "B";
			c.target = "Ground";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}
		public static SourceElement.Row TpCultivate(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223804;
			c.alias = nameof(TpCultivate);
			c.name_JP = "培養";
			c.name = "Cultivate";
			c.aliasParent = nameof(SKILL.LER);
			c.chance = 100;
			c.detail_JP = "肉を培養する。(強度判定)";
			c.detail = "Cultivate meat. (Pow check)";
			c.thing = "B";
			c.target = "Ground";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}
		public static SourceElement.Row TpForceSqueeze(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223803;
			c.alias = nameof(TpForceSqueeze);
			c.name_JP = "強制抽出";
			c.name = "ForceSqueeze";
			c.aliasParent = nameof(SKILL.CHA);
			c.chance = 100;
			c.detail_JP = "遺伝子を抽出する。(強度判定)";
			c.detail = "Squeeze gene. (Pow check)";
			c.thing = "B";
			c.target = "Ground";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}
		public static SourceElement.Row TpForceOvulation(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223801;
			c.alias = nameof(TpForceOvulation);
			c.name_JP = "強制排卵";
			c.name = "ForceOvulation";
			c.aliasParent = nameof(SKILL.CHA);
			c.chance = 100;
			c.detail_JP = "卵を産ませる。(強度判定)";
			c.detail = "Lay egg. (Pow check)";
			c.thing = "B";
			c.target = "Ground";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}
		public static SourceElement.Row TpForceMilking(SourceElement.Row baseRecipe) {
			var c = CreateCopy(baseRecipe);
			c.id = 222223802;
			c.alias = nameof(TpForceMilking);
			c.name_JP = "強制搾乳";
			c.name = "ForceMilking";
			c.aliasParent = nameof(SKILL.CHA);
			c.chance = 100;
			c.detail_JP = "乳を出させる。(強度判定)";
			c.detail = "Produce milk. (Pow check)";
			c.thing = "B";
			c.target = "Ground";
			c.proc = new string[] { "None", };
			c.abilityType = new string[] { };
			return c;
		}

	}
}
