using DebuggingConsole.Services.Extensions.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingConsole
{
	public struct DebugConsoleEntry
	{

		public readonly string Source;

		public readonly string Value;

		public readonly DateTime Timestamp;

		public readonly string User;

		public readonly string OpCode;

		public readonly int EventID;

		public readonly string TaskCategory;

		public readonly string MachineName;

		public readonly Module ModuleInstance;

		public readonly Assembly AssemblyInstance;

		public readonly Thread ThreadInstance;


		/// <summary>
		/// Creates a new structured data object that stores debug console entry information.
		/// </summary>
		/// <param name="source">The name of the method that this log is classified as.</param>
		/// <param name="value">The value of the log entry.</param>
		/// <param name="user">The username that invoked this log entry.</param>
		/// <param name="opCode">The operational code of the executing assembly's thread.</param>
		/// <param name="eventId">The event id classification.</param>
		/// <param name="taskCategory">The task category of the operation that was performed.</param>
		/// <param name="machineName">The name of the computer/machine that invoked this log entry.</param>
		/// <param name="assemblyInstance">The <see cref="Assembly"/> instance that invoked this log.</param>
		/// <param name="threadInstance">The <see cref="Thread"/> instance that invoked this log.</param>
		public DebugConsoleEntry(string source, object? value, string? user=null, string opCode="Info", int eventId=1001, string? taskCategory=null, string? machineName=null, Assembly? assemblyInstance=null, Thread? threadInstance=null, Module? moduleInstance=null)
		{
			Timestamp=DateTime.Now;
			Source = source;
			Value=value.Serialize();
			User = user??Environment.UserName;
			OpCode = opCode;
			EventID = eventId;
			TaskCategory = taskCategory??"(100)";
			MachineName = machineName??Environment.MachineName;
			AssemblyInstance=assemblyInstance??Assembly.GetExecutingAssembly();
			ThreadInstance=threadInstance??Thread.CurrentThread;
			ModuleInstance=moduleInstance??GetInvoker()?.GetMethod()?.Module??AssemblyInstance.GetLoadedModules().First();
		}

		private static StackFrame? GetInvoker(int index=3) => new StackTrace().GetFrame(index);

		/// <summary>
		/// Serializes this object into a human-readable <see cref="string"/> value.
		/// </summary>
		/// <returns>a <see cref="string"/> representation of this object.</returns>
		public new string ToString() => "[" + Timestamp.Serialize() + "] | " + Source + ":\t\t" + Value;

		public void WriteEntry()
		{

		}

	}
}