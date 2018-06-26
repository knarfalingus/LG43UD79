using System.IO.Ports; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using LG.Models;
using LG.Enums;
using static LG.Models.LG43UD79;
using CommandLine;

namespace LG
{
	class SerialPortProgram
	{

		static void RunOptionsAndReturnExitCode(CommandLineOptions options)
		{
			LG43UD79 monitor = new LG43UD79(options.SetID);
			monitor.Connect(options.COMPort);
			monitor.DataReceivedEventHandler += Monitor_DataReceivedEventHandler;

			// my own config, what I have plugged in each port
			var MAC1 = InputListEnum.HDMI1; // single mac plugged into two HDMI ports.
			var MAC2 = InputListEnum.HDMI3;
			var LAPTOP = InputListEnum.HDMI2; // laptop
			var CHROMECAST = InputListEnum.HDMI4; // chromecast
			var DESKTOP = InputListEnum.DisplayPort; // PC

			string layout = options.Layout.ToLower();

			// my preferences
			monitor.SetBrightness(70)
				.SetSharpness(70)
				.SetContrast(70)
				.SetPictureMode(PictureModeEnum.Custom);

			switch (layout)
			{
				case "pc":
					monitor.SetPBP_SingleInputMode()
							.SelectInput(InputSelectEnum.Main, DESKTOP);
					break;
				case "pc+cast":
					// PC main +chromecast PIP in upper right
					monitor.SetPBP_SingleInputMode(PIPLocationEnum.TopRight)
							.SelectInput(InputSelectEnum.Main, DESKTOP)
							.SelectInput(InputSelectEnum.Sub1, CHROMECAST);
					break;
				case "4way":
					// PC lower left / mac top / laptop lower right
					monitor.SetPBP_FourInputMode()
							.SelectInput(InputSelectEnum.Main, MAC1)
							.SelectInput(InputSelectEnum.Sub1, MAC2)
							.SelectInput(InputSelectEnum.Sub2, LAPTOP)
							.SelectInput(InputSelectEnum.Sub3, DESKTOP);
					break;
				case "lap":
					// laptop fullscreen
					monitor.SetPBP_SingleInputMode()
							.SelectInput(InputSelectEnum.Main, LAPTOP);
					break;
				case "pc+lap":
					//// PC left/work to right side by side
					monitor.SetPBP_HorizontalSplitMode()
							.SelectInput(InputSelectEnum.Main, DESKTOP)
							.SelectInput(InputSelectEnum.Sub1, LAPTOP);
					break;
				case "pc)lap":
					//// pc on top /laptop bottom
					monitor.SetPBP_VerticalSplitMode()
						.SelectInput(InputSelectEnum.Main, DESKTOP)
						.SelectInput(InputSelectEnum.Sub1, LAPTOP);
					break;
				case "mac)pc":
					// mac top / pc bottom
					monitor.SetPBP_VerticalSplitMode()
							.SelectInput(InputSelectEnum.Main, MAC2)
							.SelectInput(InputSelectEnum.Sub1, DESKTOP);
					break;
				case "mac":
					// mac fullscreen (need better mac for this :( )
					monitor.SetPBP_SingleInputMode()
							.SelectInput(InputSelectEnum.Main, MAC2);
					break;
				case "pc+mac":
					//// pc left/mac to right side by side
					monitor.SetPBP_HorizontalSplitMode()
						.SelectInput(InputSelectEnum.Main, DESKTOP)
						.SelectInput(InputSelectEnum.Sub1, MAC2);
					break;
				case "off":
					monitor.TurnOff();
					break;
				case "on":
					monitor.TurnOn();
					break;
				default:
					Console.WriteLine($"Unknown layout = '{layout}'");
					break;
			}

		}

		static void HandleParseError(IEnumerable<Error> Errors)
		{
			//
		}

		static void Main(string[] args)
		{
			var result = CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args);

			result.WithParsed<CommandLineOptions>(opts => RunOptionsAndReturnExitCode(opts))
			  .WithNotParsed<CommandLineOptions>((errs) => HandleParseError(errs));

			System.Threading.Thread.Sleep(2000);
		}

		private static void Monitor_DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
		{
			if (sender is SerialPort port)
			{
				string data = port.ReadExisting();
				Console.Write(data);
			}
		}
	}
}
