using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Extensions;

namespace MaxApiLibrary.Implementations.Extensions;

/// <summary>
/// Расширения для класса <see cref="QueryBuilder"/>
/// </summary>
public static class QueryBuilderExtension
{
    /// <summary>
    /// Добавление параметра в запрос. Если <c>paramValue</c> равен <c>null</c>, то он не добавляется в запрос.
    /// </summary>
    /// <param name="qb">Объект билдера запроса</param>
    /// <param name="paramName">Название параметра</param>
    /// <param name="paramValue">Значение параметра. Если равен <c>null</c>, то параметр не добавляется в запрос.</param>
    /// <returns>Тот же самый объект билдера запроса, что и в <c>qb</c>, для chain-вызовов</returns>
    public static QueryBuilder AddQueryParameter<T>(this QueryBuilder qb, string paramName, T? paramValue)
    {
        if (paramValue is not null)
            qb.Add(paramName, paramValue.ToString());
        return qb;
    }

    /// <summary>
    /// Добавление параметра в запрос. Если <c>paramValue</c> равен <c>null</c>, то он не добавляется в запрос.
    /// </summary>
    /// <param name="qb">Объект билдера запроса</param>
    /// <param name="paramName">Название параметра</param>
    /// <param name="enumVal">Enum-переменная. Если равен <c>null</c>, то параметр не добавляется в запрос. Если у enum-значения есть атрибут <see cref="JsonStringEnumMemberNameAttribute"/>, то извлекается название из него</param>
    /// <returns>Тот же самый объект билдера запроса, что и в <c>qb</c>, для chain-вызовов</returns>
    public static QueryBuilder AddQueryParameter(this QueryBuilder qb, string paramName, Enum? enumVal)
    {
        if (enumVal is null)
            return qb;

        var jsonStringEnumMemberName = enumVal.GetAttributeOfType<JsonStringEnumMemberNameAttribute>();
        qb.Add(paramName,
            jsonStringEnumMemberName is not null ? jsonStringEnumMemberName.Name : enumVal.ToString());

        return qb;
    }
}
