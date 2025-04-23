using System.Net.Http.Json;
using System.Text.Json;

using Resource = VictorFrye.Counter.WebApi.Resource;

namespace VictorFrye.Counter.Testing.Integrations.WebApi;

public class PutResourceByIdTests : TestAppHost
{
    [Fact]
    public async Task PutWaterResourceByIdReturnsOkResult()
    {
        var water = new Resource()
        {
            Id = Guid.NewGuid(),
            Name = "Water",
            Count = 100,
        };

        var http = App.CreateHttpClient(Resources.WebApi);
        await ResourceNotificationService.WaitForResourceAsync(Resources.WebApi, KnownResourceStates.Running).WaitAsync(TimeSpan.FromSeconds(30));
        var response = await http.PutAsJsonAsync($"/api/resources/{water.Id}", water);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = JsonSerializer.Deserialize<Resource>(await response.Content.ReadAsStringAsync(), JsonSerializerOptions.Web);
        Assert.NotNull(result);
        Assert.Equal(water, result);
    }
}
