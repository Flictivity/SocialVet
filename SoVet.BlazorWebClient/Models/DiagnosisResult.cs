using System.ComponentModel.DataAnnotations;

namespace SoVet.BlazorWebClient.Models;

public enum DiagnosisResult
{
    [Display(Name = "В процессе лечения")]
    New = 0,
    [Display(Name = "Полное выздоровление")]
    CompleteRecovery = 1,
    [Display(Name = "Улучшение симптомов")]
    SymptomImprovement = 2,
    [Display(Name = "Стабилизация состояния")]
    StabilizationOfCondition = 3
}