using DebuggingConsole.Services.Extensions.Types;

namespace DebuggingConsole.Services.Extensions.Objects
{
	internal static class ObjectValidationExt
	{
		/// <summary>
		/// Determines whether the <paramref name="value"/> is <see langword="null"/> or not.
		/// </summary>
		/// <param name="value">Any value that extends from the <see cref="object"/> class.</param>
		/// <returns>a <see cref="bool">boolean</see> value representing if the statement is <see cref="bool">true</see> or <see cref="bool">false</see>.</returns>
		public static bool IsNull(this object? value) => value is null;
		/// <inheritdoc cref="IsNull(object?)"/>
		public static bool NotNull(this object? value) => value is not null;
		/// <inheritdoc cref="IsNull(object?)" path="//*[self::returns]"/>
		/// <summary>
		/// Determines if the <paramref name="value"/> is any of the given <paramref name="types"/>.
		/// </summary>
		/// <param name="value">The <see cref="object"/> to analyze.</param>
		/// <param name="types">The <see cref="Type"/>(s) to match against the <paramref name="value"/>.</param>
		public static bool Is(this object? value, params Type?[]? types) => value.NotNull() && value!.GetType().Is(types);

		public static bool Is(this object? value, params object[] types)
		{
			if(value.NotNull() && types.NotNull() && types.Length>0)
			{
				Type baseType=value!.GetType();
				return baseType.Is(types.ToTypeList());
			}
			return false;
		}
		/// <inheritdoc cref="IsNull(object?)" path="//*[not(self::summary)]"/>
		/// <summary>
		/// Determines if the given <paramref name="value"/> is a number.
		/// </summary>
		public static bool IsNumber(this object? value) => value.NotNull() && value.Is(typeof(byte), typeof(sbyte), typeof(ushort), typeof(short), typeof(uint), typeof(int), typeof(nint), typeof(ulong), typeof(long), typeof(float), typeof(decimal), typeof(double));
		/// <inheritdoc cref="IsNull(object?)" path="//*[not(self::summary)]"/>
		/// <summary>
		/// Determines if the <paramref name="value"/> is a COMObject.
		/// </summary>
		public static bool IsComObject(this object? value) => value.NotNull() && value!.GetType().IsCOMObject;
		/// <inheritdoc cref="IsNull(object?)" path="//*[not(self::summary)]"/>
		/// <summary>
		/// Determines if the <paramref name="value"/> is an array.
		/// </summary>
		public static bool IsArray(this object? value) => value.NotNull() && value!.GetType().IsArray;

	}
}