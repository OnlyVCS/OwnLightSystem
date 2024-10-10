using System.Text;
using AutomationService.Application.Common.Services.Interfaces;
using AutomationService.Application.Contracts;
using AutomationService.Domain.Entities;
using AutomationService.Domain.Enums;

namespace AutomationService.Application.Common.Services;

public class DeviceServiceClient(HttpClient httpClient) : IDeviceServiceClient
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<DeviceServiceResult> ExecuteActionAsync(Routine routine)
    {
        var token = routine.JwtToken;

        if (string.IsNullOrEmpty(token))
            throw new UnauthorizedAccessException("Missing JWT token.");

        var requestUri = GenerateUriForRoutineAction(routine);

        var content = routine.ActionType switch
        {
            RoutineActionType.TurnOn => new StringContent(
                "{\"status\": 0}",
                Encoding.UTF8,
                "application/json"
            ),
            RoutineActionType.TurnOff => new StringContent(
                "{\"status\": 1}",
                Encoding.UTF8,
                "application/json"
            ),
            RoutineActionType.Dim => new StringContent(
                $"{{\"brightness\": {routine.Brightness}}}",
                Encoding.UTF8,
                "application/json"
            ),
            _ => throw new InvalidOperationException("Invalid action type"),
        };

        var request = new HttpRequestMessage(HttpMethod.Post, requestUri) { Content = content };

        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
            "Bearer",
            token
        );

        var response = await _httpClient.SendAsync(request);

        return response.IsSuccessStatusCode
            ? new DeviceServiceResult { IsSuccess = true }
            : new DeviceServiceResult
            {
                IsSuccess = false,
                ErrorMessage = await response.Content.ReadAsStringAsync(),
            };
    }

    private static string GenerateUriForRoutineAction(Routine routine)
    {
        return routine.ActionType switch
        {
            RoutineActionType.TurnOn => $"api/DeviceAction/control/{routine.TargetId}",
            RoutineActionType.TurnOff => $"api/DeviceAction/control/{routine.TargetId}",
            RoutineActionType.Dim => $"api/DeviceAction/dim/{routine.TargetId}",
            _ => throw new InvalidOperationException("Invalid action type for device"),
        };
    }
}
