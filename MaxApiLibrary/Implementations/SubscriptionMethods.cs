using System.Reflection;
using System.Text.Json.Serialization;
using MaxApiLibrary.Entities.UpdateEntities;
using MaxApiLibrary.Implementations.Extensions;
using MaxApiLibrary.Methods.Subscriptions;
using MaxApiLibrary.Methods.Subscriptions.Requests;
using MaxApiLibrary.Methods.Subscriptions.Responses;
using Microsoft.AspNetCore.Http.Extensions;

namespace MaxApiLibrary.Implementations;

/// <summary>
/// Имплементация API-методов из группы <c>subscriptions</c>
/// </summary>
public class SubscriptionMethods : BaseApiClient, ISubscriptionMethods
{
    /// <inheritdoc />
    public SubscriptionMethods(string accessToken, HttpClient? httpClient = null, CancellationToken? cancellationToken = null) : base(accessToken, httpClient, cancellationToken)
    {
    }

    /// <inheritdoc />
    public async Task<GetSubscriptionsResponse> GetSubscriptionsAsync() =>
        await GetFromJsonAsync<GetSubscriptionsResponse>("subscriptions");

    /// <inheritdoc />
    public async Task<PostSubscriptionsResponse> PostSubscriptionsAsync(PostSubscriptionsRequest request)
    {
        var postSubscriptionRequest = new PostSubscriptionsRequestInternal()
        {
            Url = request.Url,
            Secret = request.Secret
        };

        if (request.UpdateTypes != null)
        {
            var updateTypesStrings = ConvertTypesToStringArray(request.UpdateTypes);
            postSubscriptionRequest.UpdateTypes = updateTypesStrings.ToList();
        }

        var response = await PostAndDeserializeAsJsonAsync<PostSubscriptionsRequestInternal, PostSubscriptionsResponse>("subscriptions", postSubscriptionRequest);
        return response;
    }

    /// <inheritdoc />
    public async Task<DeleteSubscriptionsResponse> DeleteSubscriptionsAsync(string url)
    {
        var queryBuilder = new QueryBuilder();

        queryBuilder
            .AddQueryParameter(nameof(url), url);

        var response = await DeleteFromJsonAsync<DeleteSubscriptionsResponse>($"subscriptions{queryBuilder.ToQueryString()}");
        return response;
    }

    /// <inheritdoc />
    public async Task<GetUpdatesResponse> GetUpdatesAsync(int? limit = null, int? timeout = null, long? marker = null, Type[]? types = null)
    {
        var queryBuilder = new QueryBuilder();

        if (types is not null)
        {
            var updateTypesStrings = ConvertTypesToStringArray(types);
            var updateTypesValue = string.Join(",", updateTypesStrings);

            queryBuilder
                .AddQueryParameter(nameof(types), updateTypesValue);
        }

        queryBuilder
            .AddQueryParameter(nameof(limit), limit)
            .AddQueryParameter(nameof(timeout), timeout)
            .AddQueryParameter(nameof(marker), marker);

        var response = await GetFromJsonAsync<GetUpdatesResponse>($"updates{queryBuilder.ToQueryString()}");
        return response;
    }

    private static IEnumerable<string> ConvertTypesToStringArray(IEnumerable<Type> types) =>
        types
            .Select(x =>
            {
                var attributes = typeof(BaseUpdate).GetCustomAttributes<JsonDerivedTypeAttribute>();
                var attributeForCurrentType = attributes.FirstOrDefault(y => y.DerivedType == x);
                if (attributeForCurrentType is null)
                    throw new ArgumentException($"Type {x} doesn't have corresponding {nameof(JsonDerivedTypeAttribute)} attribute " +
                                                $"in the {nameof(BaseUpdate)} class");
                if (attributeForCurrentType.TypeDiscriminator is not string typeDiscriminatorAsString)
                    throw new ArgumentException($"{nameof(attributeForCurrentType.TypeDiscriminator)} for the type {x} is not a string. It must be a string " +
                                                $"for it to be convertable to JSON");
                return typeDiscriminatorAsString;
            });
}
