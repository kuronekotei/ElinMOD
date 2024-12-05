using CreativeSpore.SuperTilemapEditor;

using HarmonyLib;

using ReflexCLI.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using static TextureReplace;

public class TraitTpCatsNote : TraitItem
{
	public override string LangUse => "actRead";

	public override bool CanUse(Chara c) => true;
	public override bool OnUse(Chara c) {
		UIContextMenu menu = EClass.ui.CreateContextMenuInteraction();
		if (EClass._zone.IsPCFaction) {
			menu.AddButton("actLayerHome", () => EClass.ui.AddLayer<LayerHome>());
		}
		menu.AddButton("actReadBoard", () => EClass.ui.AddLayer<LayerQuestBoard>());
		if (EClass._zone.IsPCFaction || EClass.debug.godMode) {
			menu.AddButton("LayerPeople", () => EClass.ui.AddLayer<LayerPeople>());
		}
		if (EClass._zone.IsPCFaction) {
			menu.AddButton("actChangeFactionName", () => EClass.ui.AddLayer<LayerList>()
			.SetStringList(() => {
				List<string> list = new List<string>();
				for (int i = 0; i < 10; i++) {
					list.Add(WordGen.GetCombinedName(EClass.player.title, "faction", false));
				}
				return list;
			}, (int a, string b) => EClass.Home.name = b)
			.SetSize().EnableReroll());
		}
		menu.AddButton(EClass.sources.things.GetRow("282").GetName(), () => EClass.ui.AddLayer<LayerNewspaper>());

		if (!EClass.debug.godMode && !EClass.debug.showExtra) {
			menu.AddButton(Lang.isJP ? "*神の目を持つ*" : "*GetGodEye*", ShowExtra);
		}
		if (!EClass.debug.godMode && EClass.debug.showExtra) {
			menu.AddButton(Lang.isJP ? "*神の目を捨てる*" : "*RemoveGodEye*", ShowExtra);
		}
		if (!CoreDebug.CheatEnabled()) {
			menu.Show();
			return false;
		}
		if (!EClass.debug.godMode) {
			menu.AddButton(Lang.isJP?"*神となる*":"*BecomeGod*", GodMode);
			menu.Show();
			return false;
		}
		menu.AddButton(Lang.isJP ? "*神をやめる*" : "*GiveUpGod*", GodMode);
		menu.AddButton("*SetZone*", SetZone);
		menu.AddButton("*GetSkill*", GetSkill);
		menu.AddButton("*GetGene*", GetGene);
		menu.AddButton("*GetFeatPt*", GetFeatPt);
		// menu.AddButton("actResearchBoard", () => EClass.ui.AddLayer<LayerTech>());
		menu.Show();
		return false;
	}
	public static void ShowExtra() {
		if (EClass.debug.showExtra) {
			EClass.debug.showExtra = false;
		} else {
			EClass.debug.showExtra = true;
		}
	}
	public static void GodMode() {
		if (EClass.debug.godMode) {
			EClass.debug.godMode = false;
			EClass.debug._godBuild = false;
			EClass.debug.godCraft = false;
			EClass.debug.inviteAnytime = false;
			EClass.debug.showExtra = false;
			EClass.debug.ignoreBuildRule = true;
		} else {
			EClass.debug.numResource = 10000;
			EClass.debug.godMode = true;
			EClass.debug._godBuild = true;
			EClass.debug.godCraft = true;
			EClass.debug.inviteAnytime = true;
			EClass.debug.showExtra = true;
			EClass.debug.ignoreBuildRule = true;
		}
	}

	public static void SetZone() {
		var branch = EClass.Branch;
		while (branch.lv < branch.MaxLv) {
			branch.Upgrade();
		}

		var plans = EClass.sources.elements.rows.Where(a => {
			return !a.tag.Contains("hidden")
				&& !a.tag.Contains("unused")
				&& (a.category == "policy" || a.category == "tech")
			;
		});

		foreach (var plan in plans) {
			if (plan.category == "policy") {
				if (!branch.policies.HasPolicy(plan.id) ){
					branch.elements.Learn(plan.id);
				}
				var ele = branch.elements.GetElement(plan.alias);
				if (ele.CanGainExp && ele.ValueWithoutLink > 0 && ele.ValueWithoutLink < 100) {
					branch.elements.ModBase(ele.id, 100);
				}
				branch.resources.SetDirty();
			}
			if (plan.category == "tech") {
				var ele = branch.elements.GetElement(plan.alias);
				if (ele==null) {
					branch.elements.Learn(plan.id);
					ele = branch.elements.GetElement(plan.alias);
				}
				if (ele.vBase < ele._source.max && branch.GetTechUpgradeCost(ele) > 0) {
					branch.elements.ModBase(ele.id, ele._source.max - ele.vBase);
					branch.resources.SetDirty();
				}
				if (ele._source.max == 0 && ele.source.cost[0] > 0 && ele.ValueWithoutLink > 0 && ele.ValueWithoutLink < 100) {
					branch.elements.ModBase(ele.id, 100);
					branch.resources.SetDirty();
				}
			}
			if (plan.tag.Contains("globalPolicy")) {
				EClass.pc.faction.AddGlobalPolicy(plan.id);
			}
		}
		foreach (FactionBranch child in EClass.pc.faction.GetChildren()) {
			child.ValidateUpgradePolicies();
		}

	}

	public static void GetSkill() {
		var branch = EClass.Branch;
		var zone = EClass.pc.currentZone;
		var map = EClass.pc.currentZone.map;
		var listChara = map.ListChara(EClass.pc.faction);

		var skills = EClass.sources.elements.rows.Where(a => {
			return !a.tag.Contains("hidden")
				&& !a.tag.Contains("unused")
				&& a.category == "skill"
			;
		});

		foreach (var chara in listChara) {
			foreach (var skill in skills) {
				var ele = chara.elements.GetElement(skill.alias);
				if (ele==null || !chara.elements.HasBase(ele.id)) {
					chara.elements.Learn(skill.id);
				} else {
					chara.elements.ModExp(ele.id, 10000);
				}
			}
		}
	}

	public static void GetGene() {
		var zone = EClass.pc.currentZone;
		var map = EClass.pc.currentZone.map;
		var listChara = map.ListChara(EClass.pc.faction);

		foreach (var chara in listChara) {
			var gene = DNA.GenerateGene(chara);
			var _ = zone.TryAddThingInSharedContainer(gene) || zone.TryAddThing(gene, EClass.pc.pos);
		}

	}
	public static void GetFeatPt() {
		var zone = EClass.pc.currentZone;
		var map = EClass.pc.currentZone.map;
		var listChara = map.ListChara(EClass.pc.faction);

		foreach (var chara in listChara) {
			chara.feat += 100;
		}

	}

}
