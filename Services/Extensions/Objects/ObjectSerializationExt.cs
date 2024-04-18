using System.Collections;

namespace DebuggingConsole.Services.Extensions.Objects
{
	internal static class ObjectSerializationExt
	{
		/// <summary>
		/// Serializes the <paramref name="value"/>.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="includeQuotes"></param>
		/// <returns></returns>
		public static string Serialize(this object? value, bool includeQuotes=false)
		{
			if(value is null)
				return "null";
			if(value.IsComObject())
				return "{COMObject}";
			if(value is bool boolValue)
				return boolValue ? "true" : "false";
			Type type = value.GetType();
			if(value is string stringValue)
				return includeQuotes ? "\"" + stringValue + "\"" : stringValue;
			if(value.IsNumber())
				return value.ToString()!;
			if(value is char charValue)
				return includeQuotes ? "'" + charValue.ToString() + "'" : charValue.ToString();
			if(value is IEnumerable enumerableValue)
				return SerializeEnumeration(enumerableValue);
			if(type.Name.Contains("keyvaluepair", StringComparison.CurrentCultureIgnoreCase))
			{
				dynamic tmp=value as dynamic;
				return tmp.Key.Serialize(true) + " : " + tmp.Value.Serialize(true);
			}
			if(value is System.Net.IPAddress ipAddressValue)
				return ipAddressValue.ToString();
			if(value is System.Net.NetworkInformation.PhysicalAddress physicalAddressValue)
				return physicalAddressValue.ToString();
			if(value is Type typeValue)
				return typeValue.ToString();
			if(value is System.Reflection.MemberInfo memberInfoValue)
				return memberInfoValue.Name;
			if(value is DateTime dateTimeValue)
				return dateTimeValue.ToString("MM-dd-yyyy | hh:mm:ss:ffff tt");
			if(value is TimeSpan timeSpanValue)
				return timeSpanValue.ToString();
			if(value is System.Reflection.MethodBase methodBaseValue)
				return methodBaseValue.Name;
			if(value is FileInfo fileInfoValue)
				return fileInfoValue.FullName;
			if(value is Stream streamValue)
				return "{StreamObject}";
			if(value is Task taskValue)
				return "{TaskObject, \"taskValue.Id\"}";
			if(value is System.Windows.Markup.ValueSerializerAttribute valueSerializerAttribute)
				return "{ValueSerializerAttribute, \"valueSerializerAttribute.TypeId.Serialize()\"}";
			return value.ToString()??"null";
		}

		private static string SerializeEnumeration(IEnumerable source)
		{
			string res="";
			foreach(var sel in source)
				res+=(res.Length>0 ? "," : "") + sel;
			return res;
		}

	}
}