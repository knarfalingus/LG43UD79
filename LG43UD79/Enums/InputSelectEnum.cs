using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Enums
{
	public sealed class InputSelectEnum
	{

		private readonly String name;
		private readonly int value;

		/// <summary>
		/// entire screen or upper left quadrant or left half or top half
		/// </summary>
		public static readonly InputSelectEnum Main = new InputSelectEnum(1, "b");
		/// <summary>
		/// PIP or upper right quadrant or right half 
		/// </summary>
		public static readonly InputSelectEnum Sub1 = new InputSelectEnum(2, "c");
		/// <summary>
		/// lower right quadrant
		/// </summary>
		public static readonly InputSelectEnum Sub2 = new InputSelectEnum(3, "d");
		/// <summary>
		/// lower left quadrant
		/// </summary>
		public static readonly InputSelectEnum Sub3 = new InputSelectEnum(4, "e");

		private InputSelectEnum(int value, String name)
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
