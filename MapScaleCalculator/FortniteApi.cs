using Fortnite_API;
using Fortnite_API.Objects;
using Fortnite_API.Objects.V1;

namespace MapScaleCalculator;

public class FortniteApi
{
    private readonly FortniteApiClient _client;

    public FortniteApi(FortniteApiClient client)
    {
        _client = client;
    }

    public async Task<MapV1?> GetFortniteMapLocations()
    {
        var mapInfo = await _client.V1.Map.GetAsync(GameLanguage.EN);
        return mapInfo is not { IsSuccess: true }
            ? null
            : mapInfo.Data;
    }
}