using DebuggingConsole.Services.Extensions.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingConsole.Services.Extensions.Types
{
	internal static class TypeConversionExt
	{

		public static Type?[] ToTypeList(this object?[] values)
		{
			if(values.NotNull())
			{
				Type ?[] types=new Type?[values.Length];
				for(int i = 0;i<values.Length;i++)
					types[i]=values[i].NotNull() ? (values[i] is Type ? (Type)values[i]! : values[i]!.GetType()) : null;
				return types;
			}
			return [];
		}


	}
}
