using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Enums
{
	public sealed class PictureModeEnum
	{

		private readonly String name;
		private readonly int value;

		public static readonly PictureModeEnum Custom= new PictureModeEnum(1, "00");
		// In manual, not in menu
		//public static readonly PictureModeEnum Mono = new PictureModeEnum(2, "01");
		public static readonly PictureModeEnum Reader = new PictureModeEnum(3, "02");
		public static readonly PictureModeEnum Photo = new PictureModeEnum(4, "04");
		public static readonly PictureModeEnum Cinema = new PictureModeEnum(5, "05");
		// In manual, not in menu
		//public static readonly PictureModeEnum sRGB = new PictureModeEnum(6, "06");
		public static readonly PictureModeEnum ColorWeakness = new PictureModeEnum(7, "07");
		public static readonly PictureModeEnum Game = new PictureModeEnum(8, "08");
		public static readonly PictureModeEnum FPSGame1 = new PictureModeEnum(9, "09");
		public static readonly PictureModeEnum FPSGame2 = new PictureModeEnum(10, "0A");
		public static readonly PictureModeEnum RTSGame = new PictureModeEnum(11, "0B");
		public static readonly PictureModeEnum CustomGame = new PictureModeEnum(12, "0C");
		// In manual, not in menu
		//public static readonly PictureModeEnum EBU = new PictureModeEnum(13, "0D");
		//public static readonly PictureModeEnum REC_709 = new PictureModeEnum(14, "0E");
		//public static readonly PictureModeEnum SMPTE_C = new PictureModeEnum(15, "0F");
		//public static readonly PictureModeEnum DICOM = new PictureModeEnum(16, "10");
		//public static readonly PictureModeEnum CALIBRATION1 = new PictureModeEnum(17, "11");
		//public static readonly PictureModeEnum CALIBRATION2 = new PictureModeEnum(18, "12");
		public static readonly PictureModeEnum DARKROOM1 = new PictureModeEnum(19, "13");
		public static readonly PictureModeEnum DARKROOM2 = new PictureModeEnum(20, "14");

		private PictureModeEnum(int value, String name)
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
