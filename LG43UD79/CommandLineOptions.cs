using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG
{
	class CommandLineOptions
	{
		[Option(Required = true, HelpText = "Port to use, COM1, COM2, COM3 ...")]
		public string COMPort { get; set; }

		[Option(Required = true, HelpText = "Layout name to use")]
		public string Layout { get; set; }

		[Option(Required = false, Default = "01", HelpText = "SetID to use")]
		public string SetID { get; set; }


	}

}
