using DebuggingConsole.Services.Extensions.Objects;

namespace DebuggingConsole.Services.Extensions.Types
{
	internal static class TypeValidationExt
	{
		/// <summary>
		/// Determines if the <paramref name="type"/> inherits from any of the given <paramref name="types"/>.
		/// </summary>
		/// <param name="type">The source <see cref="Type"/> object.</param>
		/// <param name="types">The <see cref="Type"/>(s) to match against the <paramref name="type"/>.</param>
		/// <returns>a <see cref="bool">boolean</see> representation of the success status of this operation.</returns>
		public static bool Is(this Type? type, params Type?[]? types) => types.NotNull() && types!.Any(q=>q.NotNull() && q!.IsAssignableFrom(type));
		/// <inheritdoc cref="Is(Type?, Type?[]?)" path="//*[not(self::summary)]"/>
		/// <summary>
		/// Determines if the <paramref name="type"/> is a COMObject.
		/// </summary>
		public static bool IsComObject(this Type? type) => type.NotNull() && type!.IsCOMObject;

	}
}
