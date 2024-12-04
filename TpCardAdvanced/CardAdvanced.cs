using HarmonyLib;

using ReflexCLI.Attributes;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using static ActPlan;

namespace TpCardAdvanced
{
	[HarmonyPatch]
	public class CardAdvanced
	{


		static ContentCodex codex;
		[HarmonyPrefix, HarmonyPatch(typeof(ContentCodex), nameof(ContentCodex.OnClickGetCard))]
		public static bool OnClickGetCard(ContentCodex __instance) {
			codex = __instance;
			UIContextMenu menu = EClass.ui.CreateContextMenuInteraction();

			menu.AddButton(Lang.isJP ? "カードで取得する" : "GetCard", GetCard);
			menu.AddButton(Lang.isJP ? "剥製で取得する" : "GetFigure", GetFigure);
			if (CoreDebug.CheatEnabled()) {
				menu.AddButton(Lang.isJP ? "最高の剥製で取得する" : "GetFigureEx", GetFigureEx);
			}
			menu.AddButton(Lang.isJP ? "彫像で取得する" : "GetStatue", GetStatue);
			if (CoreDebug.CheatEnabled()) {
				menu.AddButton(Lang.isJP ? "カードを増やす" : "AddCard", AddCard);
			}


			menu.Show();
			return false;
		}
		public static void Refresh() {
			if (!CoreDebug.CheatEnabled() || (!EClass.debug.godBuild && !EClass.debug.godCraft)) {
				codex.currentCodex.numCard--;
			}
			if (codex.currentCodex.numCard == 0) {
				codex.RefreshList();
				return;
			}
			codex.list.Redraw();
			codex.list.Select(codex.currentCodex);
			codex.RefreshInfo();
		}

		public static void AddCard() {
			codex.currentCodex.numCard++;
		}

		public static void GetCard() {
			bool flg = EClass.game.config.autoCollectCard;

			if (flg) {
				EClass.game.config.autoCollectCard = false;
			}
			Thing thing = ThingGen.Create("figure3");
			thing.MakeFigureFrom(codex.currentCodex.id);
			EClass.pc.Pick(thing);
			if (flg) {
				EClass.game.config.autoCollectCard = true;
			}
			Refresh();
		}
		public static void GetFigure() {
			Thing thing = ThingGen.Create("figure");
			thing.MakeFigureFrom(codex.currentCodex.id);
			EClass.pc.Pick(thing);
			Refresh();
		}

		public static void GetFigureEx() {
			Thing thing = ThingGen.Create("figure");
			thing.MakeFigureFrom(codex.currentCodex.id);
			thing.ChangeMaterial(43);
			thing.SetEncLv(13);
			EClass.pc.Pick(thing);
			Refresh();
		}

		public static void GetStatue() {
			Thing thing = ThingGen.Create("figure2");
			thing.MakeFigureFrom(codex.currentCodex.id);
			EClass.pc.Pick(thing);
			Refresh();
		}
	}
}