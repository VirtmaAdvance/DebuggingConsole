using DebuggingConsole.Services.Extensions.Objects;
using System.Reflection;

namespace DebuggingConsole
{
	public class DebugConsole
	{

		public readonly Assembly CurrentAssembly;
		public readonly string SourceName;
		public readonly DebugConfig Config;



		public DebugConsole(string? sourceName=null)
		{
			CurrentAssembly=Assembly.GetExecutingAssembly();
			SourceName=sourceName??(CurrentAssembly.FullName??CurrentAssembly.GetName().FullName??"UNKNOWN");
			Config=new DebugConfig();
		}

		public void Log(object value)
		{

		}

		protected void ReceiveLog(string source, object? argumentValue)
		{
			string value=argumentValue.Serialize();
		}


	}
}
