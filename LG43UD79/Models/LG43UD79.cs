using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LG.Enums;

namespace LG.Models
{
	public class LG43UD79 : Monitor<LG43UD79>
	{
		public LG43UD79(string setID) : base(setID)
		{
		}
		public LG43UD79 Transmit(string Command1, string Command2, string Data)
		{
			string command = $"{Command1}{Command2} {this.SetID} {Data}\r";
			Console.WriteLine("SEND : " + command);
			Console.WriteLine("");
			return this.Write(command);
		}

		public LG43UD79 TurnOn()
		{
			return this.Transmit("k", "a", "01");
		}

		public LG43UD79 TurnOff()
		{
			return this.Transmit("k", "a", "00");
		}


		// not working...??
		public LG43UD79 ScreenMute(bool On)
		{
			return this.Transmit("k", "d",BoolToHex(On));
		}

		private LG43UD79 SetPBP_PIP(string data)
		{
			return this.Transmit("k", "n", data);
		}

		/// <summary>
		/// one input being displayed (picture by picture off)
		/// </summary>
		public LG43UD79 SetPBP_SingleInputMode(PIPLocationEnum PIPLocation = null)
		{
			if (PIPLocation == null)
				PIPLocation = PIPLocationEnum.OFF;

			return this.Transmit("k", "n", PIPLocation.ToString());
		}

		/// <summary>
		/// picture by picture : two inputs side by side (left/right)
		/// </summary>
		public LG43UD79 SetPBP_HorizontalSplitMode()
		{
			return this.Transmit("k", "n", "01");
		}

		/// <summary>
		/// picture by picture : two inputs, one above other (top/bottom)
		/// </summary>
		public LG43UD79 SetPBP_VerticalSplitMode()
		{
			return this.Transmit("k", "n", "02");
		}

		/// <summary>
		/// four inputs (picture by picture quadrants)
		/// </summary>
		public LG43UD79 SetPBP_FourInputMode()
		{
			return this.Transmit("k", "n", "09");
		}


		public LG43UD79 SetPIP_Size(PIPSizeEnum PIPSize)
		{
			return this.Transmit("k", "p", PIPSize.ToString());
		}

		public LG43UD79 PictureReset()
		{
			return this.Transmit("f", "k", "00");
		}

		public LG43UD79 FactoryReset()
		{
			return this.Transmit("f", "k", "01");
		}


		public LG43UD79 SelectInput(InputSelectEnum input, InputListEnum item)
		{
			string Command1 = "x";
			string Command2 = input.ToString();

			return Transmit(Command1, Command2, item.ToString());
		}

		public LG43UD79 SelectAspectRatio(ARInputSelectEnum input, AspectRatioEnum aspectRatio)
		{
			string Command1 = "x";
			string Command2 = input.ToString();
			return Transmit(Command1, Command2, aspectRatio.ToString());
		}

		/// <summary>
		/// main/sub screen change.  A toggle? argh
		/// </summary>
		public LG43UD79 MainSubScreenToggle()
		{
			return this.Transmit("m", "a", "01");
		}

		public LG43UD79 SetPictureMode(PictureModeEnum pictureMode)
		{
			return this.Transmit("d", "x", pictureMode.ToString());
		}

		public LG43UD79 SetBrightness(int Brightness)
		{
			return this.Transmit("k", "h", ZeroToOneHundredHex(Brightness));
		}
		public LG43UD79 SetContrast(int Contrast)
		{
			return this.Transmit("k", "g", ZeroToOneHundredHex(Contrast));
		}

		public LG43UD79 SetSharpness(int Sharpness)
		{
			return this.Transmit("k", "k", ZeroToOneHundredHex(Sharpness));
		}

		public LG43UD79 SetBrightnessStabilization(bool On)
		{
			return this.Transmit("m", "b", BoolToHex(On));
		}

		public LG43UD79 SetSuperResolutionMode(SuperResolutionEnum superResolution)
		{
			return this.Transmit("m", "c", superResolution.ToString());
		}

	}
}
