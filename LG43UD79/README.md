# LG43UD79 control via RS232

## Summary

<dl>
<p>
I wanted a simple way of switching the LG43UD79 across its various display configurations.  The remote is useful, 
but still, with 6 inputs and 8 different ways the screen real estate can be allocated it is a lot of potential combinations.
</p>
<p>
My older monitor is on the side and dedicated to the PC, so that is where I run this program from, with the benefit of the program not disappearing on me as the monitor reconfigures, especially if I select a layout that does not include the PC.
</p>
</dl>

## Audience

<dl>
<p>
	Developers. Uses the <a href='https://github.com/commandlineparser/commandline'>CommandLineParser/CommandLine</a> package to process the command line.  
	Most of the action happens in Program.cs, in RunOptionsAndReturnExitCode().  Arrange and refactor/rename the inputs at the top and then perform actions on them
	in the switch statement based on the value that was passed in via the layout parameter.  Rename and add/delete layouts to the switch statement that meet your use cases.
</p>
<p>
	Example Usage:<br/>
	<code>
	LGRS232.exe --comport COM3 --layout pc+cast
	</code>
	<br/>
	The way the code currently is, this will make DisplayPort fullscreen (PC) with HDMI4 (Chromecast) in upper right PIP, where I prefer it.
</p>
</dl>


## Errata

<dl>
	<ul>
		<li>As far as I can tell, the input the audio is coming from can't be changed via RS232.  Keep the remote and "Audio Select" button handy.</li>
		<li>It doesnt appear the PIP transparency can be altered via RS232 either, although at least the monitor remembers it even when PIP is hidden.</li>
		<li>I was using enums to represent a lot of different commands & options and found it led to switch statement heavy code.  I used type safe enums/enumeration classes instead, a simpler version of what is described in this <a href='https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types'>article.</a></li>
		<li>Dont have USB-C video so its completely untested</li>
	</ul>
</dl>


## Equipment used

*   [USB to RS232 DB 9 Cable ](https://www.amazon.com/gp/product/B01DYNNUS8/)
*   [3.5 mm to DB9 crossover cable](https://www.amazon.com/gp/product/B007ARWLBW/) 
*   Could the above be cheaper? Probably, but it did work first attempt.
*   Windows 10 PC with USB port (appropriate driver auto-installed upon connection), the COM port assigned was displayed.  Otherwise you can find it in Device Manager under LPT & COM ports.


