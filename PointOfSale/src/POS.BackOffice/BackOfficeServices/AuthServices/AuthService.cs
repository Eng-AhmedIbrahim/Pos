using BlazorBase.API;
using BlazorBase.Helpers;
using POS.BackOffice.BackOfficeServices.AuthServices;
using static POS.BackOffice.Pages.Index;

public class AuthService : IAuthService
{
    private readonly ApiSettings _apiSettings;
    private readonly HttpClient _httpClient;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
        ApiSettings apiSettings,
        IHttpClientFactory httpClientFactory,
        ILogger<AuthService> logger)
    {
        _apiSettings = apiSettings;
        _httpClient = httpClientFactory.CreateClient(apiSettings.ApiName!);
        _logger = logger;
    }

    // ✅ Get Roles
    public async Task<List<string>> GetRolesAsync()
    {
        return (await GetApiResponseAsync<string>(GetAllRolesRequest, "Error fetching roles")).ToList();
    }

    // ✅ Get Claims for a Specific Role
    public async Task<List<ClaimModel>> GetRoleClaimsAsync(string roleName)
    {
        return (await GetApiResponseAsync<ClaimModel>(
            () => _httpClient.GetAsync($"api/roles/{roleName}/claims"),
            $"Error fetching claims for role {roleName}")).ToList();
    }

    // ✅ Add Claim to Role
    public async Task<bool> AddClaimToRoleAsync(string roleName, ClaimModel claim)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"api/roles/{roleName}/claims", claim);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error adding claim {claim.Value} to role {roleName}: {ex.Message}");
            return false;
        }
    }

    // ✅ Remove Claim from Role
    public async Task<bool> RemoveClaimFromRoleAsync(string roleName, ClaimModel claim)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"api/roles/{roleName}/claims/remove", claim);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error removing claim {claim.Value} from role {roleName}: {ex.Message}");
            return false;
        }
    }

    // ✅ Generic API Response Handler
    private async Task<ICollection<T>> GetApiResponseAsync<T>(
        Func<Task<HttpResponseMessage>> apiRequest,
        string? message)
    {
        var response = await ApiRequestHelpers.SendApiRequest(apiRequest, _logger);
        if (response is null || !response.IsSuccessStatusCode)
        {
            _logger.LogError("API call failed: {ErrorMessage}", message ?? "No message provided.");
            return [];
        }

        var content = await response.Content.ReadAsStringAsync();
        var items = ApiRequestHelpers.DeserializeResponseContent<List<T>>(content);

        return items ?? [];
    }

    // ✅ Get All Roles Request
    private Task<HttpResponseMessage> GetAllRolesRequest()
        => _httpClient.GetAsync(_apiSettings.Endpoints!.GetAllRoles);
}


public class ClaimModel
{
    public string Type { get; set; } = "Permission"; // Example: "Permission"
    public string? Value { get; set; } // Example: "View_Project"
}
