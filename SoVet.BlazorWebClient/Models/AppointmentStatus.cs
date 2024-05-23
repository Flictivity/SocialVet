using System.ComponentModel.DataAnnotations;

namespace SoVet.BlazorWebClient.Models;

public enum AppointmentStatus
{
    [Display(Name = "Ожидает начала")]
    WaitingStart = 0,
    [Display(Name = "В работе")]
    Active = 1,
    [Display(Name = "Завершен")]
    Finished = 2,
    [Display(Name = "Не проведен")]
    NotVisited = 3
}