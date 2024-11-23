using HarmonyLib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class TraitTpCatsBag : TraitMagicChest
{

	public override int Electricity => 0;

	public override bool IsHomeItem => false;

	public override bool IsSpecialContainer => true;

	public override bool CanBeOnlyBuiltInHome => false;

	public override bool CanOpenContainer => true;

	public override bool IsFridge => true;

	public override bool UseAltTiles => false;

	public override int DecaySpeedChild => 0;

	public override bool CanSearchContents => true;

	public override void SetName(ref string s) {
	}
}
