using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingConsole
{
	[Flags]
	public enum DebugSaveLocations : long
	{

		Default,
		Memory,
		Console,
		File,
		EventViewer,
		Database,
		Email,
		SMSTextMessage,
		HttpRequest,

	}
}
