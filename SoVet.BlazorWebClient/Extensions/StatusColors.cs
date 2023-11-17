using SoVet.BlazorWebClient.Models;

namespace SoVet.BlazorWebClient.Extensions;

public static class StatusColors
{
    public static Dictionary<AppointmentStatus, string> StatusColor = new()
    {
        {AppointmentStatus.NotVisited, "#919191"},
        {AppointmentStatus.Finished, "#FF5D5D"},
        {AppointmentStatus.Active, "#0E9924"},
        {AppointmentStatus.WaitingStart, "#4AB7F5"}
    };
}