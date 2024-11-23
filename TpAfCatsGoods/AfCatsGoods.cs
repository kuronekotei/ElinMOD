using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpAfCatsGoods
{
	public class AfCatsGoods
	{
		public static void OnStartCore() {
			SourceManager sources = Core.Instance.sources;
			List<SourceThing.Row> things = sources.things.rows;
			var pickaxe = things.Find(x => x.id == "pickaxe");
			var cane_simple = things.Find(x => x.id == "cane_simple");
			var book_resident = things.Find(x => x.id == "book_resident");
			var lantern_old = things.Find(x => x.id == "lantern_old");
			var stradivarius = things.Find(x => x.id == "stradivarius");
			var container_magic = things.Find(x => x.id == "container_magic");
			List<SourceThing.Row> addList = new List<SourceThing.Row> {
				TpCatsClaw(pickaxe,"tp_catsclaw"),
				TpCatsTail(cane_simple,"tp_catstail"),
				TpCatsTail2(cane_simple,"tp_catstail2"),
				TpCatsNote(book_resident,"tp_catsnote"),
				TpCatsEye(lantern_old,"tp_catseye"),
				TpCatsWhisker(stradivarius,"tp_catswhisker"),
				TpCatsBag(container_magic,"tp_catsbag"),
			};
			foreach (var addItem in addList) {
				sources.things.rows.Add(addItem);
			}
			sources.things.Reset();
		}

		public static T CreateCopy<T>(T baseItem) where T : new() {
			System.Reflection.FieldInfo[] fields = baseItem.GetType().GetFields();
			T newItem = new T();
			foreach (System.Reflection.FieldInfo fieldInfo in fields) {
				newItem.SetField<object>(fieldInfo.Name, baseItem.GetField<object>(fieldInfo.Name));
			}
			return newItem;
		}

		public static SourceThing.Row TpCatsClaw(SourceThing.Row baseRecipe, string newId) {
			var c = CreateCopy(baseRecipe);
			c.id = newId;
			c.name_JP = "ネコのツメ";
			c.unknown_JP = "肉球";
			c.naming = "";
			c.name = "Cat's Claw";
			c.unknown = "cat paw";
			c.tiles = new int[] { 1013 };
			c.defMat = "!void";
			c.value = 1000000;
			c.tag = new string[] { "noShop" };
			c.LV = 50;
			c.chance = 0;
			c.quality = 4;
			c.weight = 1000;
			c.elements = new int[] { SKILL.mining, 20, SKILL.lumberjack, 20, SKILL.fishing, 20 };
			c.lightData = "grave_dagger";
			c.detail_JP = "それは岩を砕き、木を削り、魚を捕る。";
			c.detail = "It breaks rocks, chips wood, and catches fish.";
			c.factory = new string[] { "self" };
			c.components = new string[] { "rock/30", "log/50", };
			c.recipeKey = new string[] { "*" };
			return c;
		}
		public static SourceThing.Row TpCatsTail(SourceThing.Row baseRecipe, string newId) {
			var c = CreateCopy(baseRecipe);
			c.id = newId;
			c.trait = new string[] { "TpCatsTail" };
			c.name_JP = "ネコのシッポ";
			c.unknown_JP = "ふさふさの棒";
			c.naming = "";
			c.name = "Cat's Tail";
			c.unknown = "fluffy wand";
			c.tiles = new int[] { 1114 };
			c.defMat = "!obsidian";
			c.value = 1000000;
			c.tag = new string[] { "noShop" };
			c.LV = 50;
			c.chance = 0;
			c.quality = 4;
			c.weight = 400;
			c.elements = new int[] { SKILL.eleChaos, 50, SKILL.eleMind, 50, SKILL.eleNerve, 50, SPELL.SpBane, 50 };
			c.range = 4;
			c.offense = new int[] { 2, 20, 10, 0 };
			c.lightData = "grave_dagger";
			c.detail_JP = "それが振られると何かが起こる。";
			c.detail = "If it is zapped something happens.";
			c.factory = new string[] { "self" };
			c.components = new string[] { "fragment/20", "stick/50", };
			c.recipeKey = new string[] { "*" };
			return c;
		}
		public static SourceThing.Row TpCatsTail2(SourceThing.Row baseRecipe, string newId) {
			var c = CreateCopy(baseRecipe);
			c.id = newId;
			c.name_JP = "ネコのカギシッポ";
			c.unknown_JP = "ふさふさの棒";
			c.naming = "";
			c.name = "Cat's Kinked Tail";
			c.unknown = "fluffy wand";
			c.tiles = new int[] { 1114 };
			c.defMat = "!obsidian";
			c.value = 1000000;
			c.tag = new string[] { "noShop" };
			c.LV = 50;
			c.chance = 0;
			c.quality = 4;
			c.weight = 400;
			c.elements = new int[] { SKILL.elePoison, 50, SKILL.eleCut, 50, SKILL.eleLightning, 50, SKILL.eleEther, 50 };
			c.range = 4;
			c.offense = new int[] { 2, 20, 10, 0 };
			c.lightData = "grave_dagger";
			c.detail_JP = "それが振られると何かが起こる。";
			c.detail = "If it is zapped something happens.";
			c.factory = new string[] { "self" };
			c.components = new string[] { "fragment/20", "stick/50", };
			c.recipeKey = new string[] { "*" };
			return c;
		}

		public static SourceThing.Row TpCatsNote(SourceThing.Row baseRecipe, string newId) {
			var c = CreateCopy(baseRecipe);
			c.id = newId;
			c.trait = new string[] { "TpCatsNote" };
			c.name_JP = "ネコの手帳";
			c.unknown_JP = "かわいいノート";
			c.naming = "";
			c.name = "Cat's Note";
			c.unknown = "Cute Note";
			c.tiles = new int[] { 1712 };
			c.defMat = "!obsidian";
			c.value = 1000000;
			c.tag = new string[] { "noShop" };
			c.LV = 50;
			c.chance = 0;
			c.quality = 4;
			c.weight = 0;
			c.lightData = "grave_dagger";
			c.detail_JP = "それは世界のすべてが記されている。";
			c.detail = "It is where the whole world is written.";
			c.factory = new string[] { "self" };
			c.components = new string[] { "texture/50",  };
			c.recipeKey = new string[] { "*" };
			return c;
		}
		public static SourceThing.Row TpCatsEye(SourceThing.Row baseRecipe, string newId) {
			var c = CreateCopy(baseRecipe);
			c.id = newId;
			c.name_JP = "ネコの瞳";
			c.unknown_JP = "光る珠";
			c.unit = "個";
			c.naming = "";
			c.name = "Cat's Eye";
			c.unknown = "illuminate orb";
			c.tiles = new int[] { 1412 };
			c._tiles = new int[] { 908 };
			c.altTiles = new int[] { 1406 };
			c._altTiles = new int[] { 909 };
			c.defMat = "!mithril";
			c.value = 1000000;
			c.tag = new string[] { "noShop" };
			c.LV = 50;
			c.chance = 0;
			c.quality = 4;
			c.weight = 800;
			c.trait = new string[] { "LightSource", "8" };
			c.elements = new int[] { ENC.encSpell, 20, ENC.seeInvisible, 1, ENC.revealFaith, 1, ENC.negateBlind, 1 };
			c.lightData = "grave_dagger";
			c.detail_JP = "それは暗闇で光り、すべてを見通す。";
			c.detail = "It glows in the dark and see everything.";
			c.factory = new string[] { "self" };
			c.components = new string[] { "rock/50", "texture/10", };
			c.recipeKey = new string[] { "*" };
			return c;
		}
		public static SourceThing.Row TpCatsWhisker(SourceThing.Row baseRecipe, string newId) {
			var c = CreateCopy(baseRecipe);
			c.id = newId;
			c.name_JP = "ネコのヒゲ";
			c.unknown_JP = "艶やかなヒゲ";
			c.naming = "";
			c.name = "Cat's Whisker";
			c.defMat = "!obsidian";
			c.value = 1000000;
			c.tag = new string[] { "noShop" };
			c.LV = 50;
			c.chance = 0;
			c.quality = 4;
			c.trait = new string[] { "TpCatsWhisker" };
			c.elements = new int[] { SKILL.music, 20, ENC.throwReturn, 1, SKILL.eleMind, 100 };
			c.lightData = "grave_dagger";
			c.detail_JP = "それは世界を魅了する。";
			c.detail = "It captivates the world.";
			c.factory = new string[] { "self" };
			c.components = new string[] { "log/50", "stick/20", };
			c.recipeKey = new string[] { "*" };
			return c;
		}
		public static SourceThing.Row TpCatsBag(SourceThing.Row baseRecipe, string newId) {
			var c = CreateCopy(baseRecipe);
			c.id = newId;
			c.name_JP = "ネコの超次元バッグ";
			c.unknown_JP = "ネコの鞄";
			c.naming = "";
			c.name = "Cat's HD Bag";
			c.unknown = "cute bag";
			c.tiles = new int[] { 2028 };
			c._tiles = new int[] { 1308 };
			c.altTiles = new int[] {  };
			c._altTiles = new int[] {  };
			c.defMat = "!obsidian";
			c.value = 1000000;
			c.tag = new string[] { "noShop" };
			c.LV = 50;
			c.chance = 0;
			c.quality = 4;
			c.weight = 0;
			c.trait = new string[] { "TpCatsBag", "12", "8", "chest_magic" };
			c.lightData = "grave_dagger";
			c.detail_JP = "それは世界を内包する。";
			c.detail = "It contains the world.";
			c.factory = new string[] { "self" };
			c.components = new string[] { "texture/50", "stick/20", };
			c.recipeKey = new string[] { "*" };
			return c;
		}


	}
}
