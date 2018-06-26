using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Enums
{

	public sealed class PIPLocationEnum
	{
		private readonly String name;
		private readonly int value;

		public static readonly PIPLocationEnum OFF = new PIPLocationEnum(1, "00");
		public static readonly PIPLocationEnum PBP = new PIPLocationEnum(2, "01");
		public static readonly PIPLocationEnum PBP2 = new PIPLocationEnum(3, "02");
		public static readonly PIPLocationEnum TopLeft = new PIPLocationEnum(4, "03");
		public static readonly PIPLocationEnum TopRight = new PIPLocationEnum(5, "04");
		public static readonly PIPLocationEnum BottomLeft = new PIPLocationEnum(6, "05");
		public static readonly PIPLocationEnum BottomRight = new PIPLocationEnum(7, "06");
		public static readonly PIPLocationEnum PBP_3P_NA = new PIPLocationEnum(8, "07");
		public static readonly PIPLocationEnum PBP_L1P_R2P_NA = new PIPLocationEnum(9, "08");
		public static readonly PIPLocationEnum PBP_4P = new PIPLocationEnum(10, "09");

		private PIPLocationEnum(int value, String name)
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
