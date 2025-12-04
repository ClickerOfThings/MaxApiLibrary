namespace MaxApiLibrary.Implementations.Extensions;

/// <summary>
/// Методы расширения для enum-значений
/// </summary>
public static class EnumExtension
{
    /// <summary>
    /// Извлечение атрибута из enum-значения
    /// </summary>
    /// <typeparam name="T">Тип извлекаемого атрибута</typeparam>
    /// <param name="enumVal">Enum-значение</param>
    /// <returns>Атрибут в enum-значении, если он присутствует. <c>null</c>, если атрибут отсутствует у enum-значения.</returns>
    public static T? GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
    {
        var type = enumVal.GetType();
        var memberInfo = type.GetMember(enumVal.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
        return attributes.Length > 0 ? (T)attributes[0] : null;
    }
}
