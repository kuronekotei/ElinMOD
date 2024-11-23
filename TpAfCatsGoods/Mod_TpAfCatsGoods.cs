using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;

using HarmonyLib;

using UnityEngine;


namespace TpAfCatsGoods
{
	[BepInPlugin("net.kuronekotei.af_cats_goods", "AfCatsGoods", "1.0.0.0")]
	public class Mod_TpAfCatsGoods : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("AfCatsGoods").PatchAll();
		}

		public void OnStartCore() {
			AfCatsGoods.OnStartCore();
		}
	}
}
