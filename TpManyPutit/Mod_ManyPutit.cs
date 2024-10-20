using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

using UnityEngine;

using static Lang;

namespace TpManyPutit
{
	[BepInPlugin("net.kuronekotei.many_putit", "ManyPutit", "1.0.0.0")]
	public class Mod_ManyPutit : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("ManyPutit").PatchAll();
		}

		public void OnStartCore() {
			ManyPutit.OnStartCore();
		}
	}
}