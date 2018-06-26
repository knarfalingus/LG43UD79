using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Enums
{
	public sealed class InputListEnum
	{
		private readonly String name;
		private readonly int value;

		public static readonly InputListEnum DisplayPort = new InputListEnum(0, "C0");
		public static readonly InputListEnum HDMI1 = new InputListEnum(1, "90");
		public static readonly InputListEnum HDMI2 = new InputListEnum(2, "91");
		public static readonly InputListEnum HDMI3 = new InputListEnum(3, "92");
		public static readonly InputListEnum HDMI4 = new InputListEnum(4, "93");
		public static readonly InputListEnum USB_C = new InputListEnum(5, "E0");

		private InputListEnum(int value, String name)
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
