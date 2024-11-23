using HarmonyLib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class TraitTpCatsTail : TraitToolRangeCane
{
	public override bool Contains(RecipeSource r) => true;

	public override bool IsLightOn => true;

	public override void OnCreate(int lv) {
		while ((owner.sockets?.Count ?? 0) < 6) {
			owner.AddSocket();
		}
	}
}
