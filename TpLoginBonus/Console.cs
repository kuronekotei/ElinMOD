using ReflexCLI.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace TpLoginBonus
{
	[ConsoleCommandClassCustomizer("")]
	public class Console : EScriptable
	{
		[ConsoleCommand]
		public static string _ResetLoginBonus() {
			EClass.pc.SetObj<DataLoginBonus>(222222001, new DataLoginBonus { LastDate = "", TotalDate = 0 });
			return $"_ResetLoginBonus";
		}
		[ConsoleCommand]
		public static string _ResetLoginDate() {
			DataLoginBonus data = EClass.pc.GetObj<DataLoginBonus>(222222001);
			if (data == null) {
				data = new DataLoginBonus();
			}
			EClass.pc.SetObj<DataLoginBonus>(222222001, new DataLoginBonus { LastDate = "", TotalDate = data.TotalDate });
			return $"_ResetLoginBonus";
		}
	}
}