using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Enums
{
	public sealed class AspectRatioEnum
	{

		private readonly String name;
		private readonly int value;

		public static readonly AspectRatioEnum FullWide = new AspectRatioEnum(1, "00");
		public static readonly AspectRatioEnum Original = new AspectRatioEnum(2, "01");
		public static readonly AspectRatioEnum OneToOne = new AspectRatioEnum(3, "02");
		public static readonly AspectRatioEnum Cinema1 = new AspectRatioEnum(4, "03");
		public static readonly AspectRatioEnum Cinema2 = new AspectRatioEnum(5, "04");

		private AspectRatioEnum(int value, String name)
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
