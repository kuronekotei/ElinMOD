using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using HarmonyLib;

using UnityEngine;

using static ActPlan;
using static TableData;
using static TextureReplace;

namespace TpProcessRecipe
{
	[HarmonyPatch]
	public class ProcessRecipe
	{
		public static void OnStartCore() {
			SourceManager sources = Core.Instance.sources;
			List<SourceRecipe.Row> recipes = sources.recipes.rows;
			var baseIngot = recipes.Find(x => x.factory == "Smelter" && x.thing == "ingot" && x.id < 100);
			var baseClay = recipes.Find(x => x.factory == "Mill" && x.thing == "clay" && x.id < 100);
			var basePlank = recipes.Find(x => x.factory == "SawMill" && x.thing == "plank" && x.id < 100);
			var baseCutstone = recipes.Find(x => x.factory == "StoneCutter" && x.thing == "cutstone" && x.id < 100);
			var baseThread = recipes.Find(x => x.factory == "Spinner" && x.ing1[0] == "fiber" && x.id < 100);
			var baseKiln = recipes.Find(x => x.factory == "Kiln" && x.thing == "brick" && x.id < 100);
			var baseButcher = recipes.Find(x => x.factory == "Butcher" && x.ing1[0] == "meat" && x.id < 100);
			List<SourceRecipe.Row> addList = new List<SourceRecipe.Row> {
				AddRecipe(baseIngot, 222222001, "ingot", "scrap"),
				AddRecipe(baseIngot, 222222002, "gem", "glass"),
				AddMillRecipe(baseClay, 222222003, "fragment", "plank", "2"),
				AddMillRecipe(baseClay, 222222004, "fragment", "stick", "2"),
				AddMillRecipe(baseClay, 222222005, "fragment", "cutstone", "2"),
				AddMillRecipe(baseClay, 222222006, "fragment", "stone", "2"),
				AddMillRecipe(baseClay, 222222007, "fragment", "thread", "2"),
				AddMillRecipe(baseClay, 222222008, "fragment", "texture", "4"),
				AddRecipe(baseIngot, 222222009, "ingot", "texture"),
				AddRecipe(baseIngot, 222222010, "gem", "cutstone"),
				AddRecipe(basePlank, 222222011, "plank", "ingot"),
				AddRecipe(basePlank, 222222012, "plank", "fragment"),
				AddRecipe(baseCutstone, 222222013, "cutstone", "ingot"),
				AddRecipe(baseCutstone, 222222014, "cutstone", "fragment"),
				AddRecipe(baseThread, 222222015, "thread", "ingot"),
				AddRecipe(baseThread, 222222016, "thread", "fragment"),
				AddRecipe(basePlank, 222222017, "stick", "plank"),
				AddRecipe(basePlank, 222222018, "grass", "stick"),
				AddMillRecipe(baseClay, 222222019, "fragment", "grass", "2"),
				AddRecipe(baseThread, 222222020, "log", "plank"),
				AddRecipe(baseThread, 222222021, "rock", "cutstone"),
				AddMillRecipe(baseClay, 222222022, "chunk", "fragment", "2"),
				AddRecipe(baseKiln, 222222023, "potion_empty", "glass"),
				AddRecipeEx(baseButcher, 222222024, "meat", "#meal_meat", "Food"),
				AddRecipeEx(baseButcher, 222222025, "egg", "#meal_egg", "Food"),
				AddRecipeEx(baseButcher, 222222026, "fish", "#meal_fish", "Food"),
			};
			foreach (var addItem in addList) {
				sources.recipes.rows.Add(addItem);
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


		public static SourceRecipe.Row AddRecipe(SourceRecipe.Row baseRecipe, int newId, string thing, string ing) {
			var c = CreateCopy(baseRecipe);
			c.id = newId;
			c.thing = thing;
			c.ing1 = new string[] { ing };
			c.ing2 = new string[] { };
			c.ing3 = new string[] { };
			c.tag = new string[] { "known" };
			return c;
		}
		public static SourceRecipe.Row AddRecipeEx(SourceRecipe.Row baseRecipe, int newId, string thing, string ing, string type) {
			var c = CreateCopy(baseRecipe);
			c.id = newId;
			c.type = type;
			c.thing = thing;
			c.ing1 = new string[] { ing };
			c.ing2 = new string[] { };
			c.ing3 = new string[] { };
			c.tag = new string[] { "known" };
			return c;
		}

		public static SourceRecipe.Row AddMillRecipe(SourceRecipe.Row baseRecipe, int newId, string thing, string ing, string num) {
			var c = CreateCopy(baseRecipe);
			c.id = newId;
			c.thing = thing;
			c.num = num;
			c.ing1 = new string[] { ing };
			c.ing2 = new string[] { ing };
			c.ing3 = new string[] { };
			c.tag = new string[] { "known" };
			return c;
		}
	}
}
