using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Enums
{
	public sealed class SuperResolutionEnum
	{

		private readonly String name;
		private readonly int value;

		public static readonly SuperResolutionEnum High = new SuperResolutionEnum(0, "00");
		public static readonly SuperResolutionEnum Middle = new SuperResolutionEnum(1, "01");
		public static readonly SuperResolutionEnum Low = new SuperResolutionEnum(2, "02");
		public static readonly SuperResolutionEnum Off = new SuperResolutionEnum(3, "03");

		private SuperResolutionEnum(int value, String name)
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
