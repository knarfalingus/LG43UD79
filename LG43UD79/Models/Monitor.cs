using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Models
{
	public abstract class Monitor<T> : IDisposable where T : class
	{
		public event EventHandler<SerialDataReceivedEventArgs> DataReceivedEventHandler;

		protected string SetID { get; private set; }
		private SerialPort serialPort;

		public Monitor(string setID)
		{
			SetID = setID;
		}

		public void Connect (string portName)
		{
			serialPort = new SerialPort(); // Create a new SerialPort Object

			serialPort.DataReceived += SerialPort_DataReceived;

			//COM port settings to 8N1 mode
			serialPort.PortName = portName;             // Name of the COM port 
			serialPort.BaudRate = 9600;                  // Baudrate = 9600bps
			serialPort.Parity = Parity.None;             // Parity bits = none  
			serialPort.DataBits = 8;                     // No of Data bits = 8
			serialPort.StopBits = StopBits.One;          // No of Stop bits = 1
			serialPort.Encoding = Encoding.ASCII;        // ASCII encoding

			serialPort.Open();
		}

		private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			DataReceivedEventHandler?.Invoke(sender, e);
		}

		protected T Write(string command)
		{
			serialPort.Write(command);
			return this as T;
		}

		private void Close()
		{
			if (serialPort != null)
			{
				serialPort.DataReceived -= SerialPort_DataReceived;

				if (serialPort.IsOpen == true)
					serialPort.Close();

			}

		}

		protected static string ZeroToOneHundredHex(int v)
		{
			v = Math.Max(v, 0);
			v = Math.Min(v, 100);
			return v.ToString("X2");
		}

		protected static string BoolToHex(bool b)
		{
			if (b == false)
				return "00";
			else
				return "01";
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// get rid of managed resources
				Close();
				serialPort?.Dispose();
			}
			// get rid of unmanaged resources
		}

	}
}
