using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Enums
{
	public sealed class PIPSizeEnum
	{

		private readonly String name;
		private readonly int value;

		public static readonly PIPSizeEnum Small = new PIPSizeEnum(0, "00");
		public static readonly PIPSizeEnum Medium = new PIPSizeEnum(1, "01");
		public static readonly PIPSizeEnum Large = new PIPSizeEnum(2, "02");

		private PIPSizeEnum(int value, String name)
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
