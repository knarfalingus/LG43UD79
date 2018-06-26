using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Enums
{
	public sealed class ARInputSelectEnum
	{
		private readonly String name;
		private readonly int value;

		public static readonly ARInputSelectEnum Main = new ARInputSelectEnum(1, "f");
		public static readonly ARInputSelectEnum Sub1 = new ARInputSelectEnum(2, "g");
		public static readonly ARInputSelectEnum Sub2 = new ARInputSelectEnum(3, "h");
		public static readonly ARInputSelectEnum Sub3 = new ARInputSelectEnum(4, "i");

		private ARInputSelectEnum(int value, String name)
		{
			this.name = name;
			this.value = value;
		}

		public override String ToString()
		{
			return name;
		}
	}
}
