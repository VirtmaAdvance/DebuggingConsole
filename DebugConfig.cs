using DebuggingConsole.Services.Extensions.Objects;
using System.Text.RegularExpressions;

namespace DebuggingConsole
{
	public struct DebugConfig
	{

		public DebugSaveLocations SaveLocation = DebugSaveLocations.Default;
		public bool Append { get; set; } = true;
		private string _extension="log";
		public string Extension
		{
			get => _extension;
			set
			{
				if(value.IsNull())
					throw new ArgumentNullException(nameof(value));
				if(!(value.Length>0 && value.Length<20))
					throw new ArgumentException("The string value provided is either empty or exceeds the maximum number of characters allowed for a file extension (20).");
				if(Regex.IsMatch(value, "[\\\\\\/\\:\\*\\?\\\"\\<\\>\\|\\#]+"))
					throw new ArgumentException("The value provided contains an illegal character.");
				_extension=value;
			}
		}
		private string _filePath="/"+DateTime.Now.ToString("MM-dd-yyyy") + ".log";
		public string FilePath
		{
			get => _filePath;
			set
			{
				if(value.IsNull())
					throw new ArgumentNullException(nameof(value));
				if(!(value.Length>0 && value.Length<20))
					throw new ArgumentException("The string value provided is either empty or exceeds the maximum number of characters allowed for a file extension (20).");
				if(Regex.IsMatch(value, "[\\\\\\/\\:\\*\\?\\\"\\<\\>\\|\\#]+"))
					throw new ArgumentException("The value provided contains an illegal character.");
				_filePath=value + "." + Extension;
			}
		}

		public DebugConfig()
		{

		}

	}
}