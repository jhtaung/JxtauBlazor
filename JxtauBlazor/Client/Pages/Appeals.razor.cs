using System.Net.Http.Json;
using JxtauBlazor.Client.Interfaces;
using JxtauBlazor.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace JxtauBlazor.Client.Pages
{
    public class AppealsComponent : ComponentBase
    {
        [Inject] IJSRuntime? _jsRuntime { get; set; }

        [Inject] HttpClient? _httpClient { get; set; }

        public bool isLoading = false;

        public int[] pageSizeOptions = new int[] { 50, 100, 200 };

        public List<AppealListDto> appealList = new List<AppealListDto>() { };

        protected override async Task OnInitializedAsync()
        {
            // Employees = (await EmployeeService.GetEmployees()).ToList();
            // var response = await appealService!.GetAppealList();
            isLoading = true;
            var response = await _httpClient!.GetFromJsonAsync<AppealListDto[]>("api/appeals/list");
            appealList = response!.ToList();
            await _jsRuntime!.InvokeVoidAsync("console.log", response);
            isLoading = false;
        }
    }
}