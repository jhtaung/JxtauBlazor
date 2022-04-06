using System.Net.Http.Json;
using JxtauBlazor.Client.Interfaces;
using JxtauBlazor.Shared.Models;

namespace JxtauBlazor.Client.Services
{
    public class AppealService : IAppealService
    {
        private readonly HttpClient _httpClient;

        public AppealService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AppealListDto>> GetAppealList()
        {
            var response = await _httpClient.GetFromJsonAsync<AppealListDto[]>("api/appeals/list");
            return response!;
        }
    }
}