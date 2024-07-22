using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace TpHalloMod
{
	[HarmonyPatch]
	public class RemoveUnhealthyHobby
	{
		[HarmonyPostfix, HarmonyPatch(typeof(Game), nameof(Game.OnBeforeInstantiate))]
		public static void OnBeforeInstantiate() {
			Debug.Log("RemoveUnhealthyHobby");
			var list = EClass.sources.hobbies.listHobbies;
			list.Remove(list.Find(x => x.name_JP == "気持ちいいこと"));
			list.Remove(list.Find(x => x.name_JP == "飲酒"));
			list.Remove(list.Find(x => x.name_JP == "喫煙"));
			list.Remove(list.Find(x => x.name_JP == "薬"));
			list.Remove(list.Find(x => x.name_JP == "自傷"));
			list.Remove(list.Find(x => x.name_JP == "宝くじ"));
			list.Remove(list.Find(x => x.name_JP == "ガチャ"));
			list.Remove(list.Find(x => x.name_JP == "骨董品"));
		}
	}
}
