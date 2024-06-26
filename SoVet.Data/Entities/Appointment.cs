﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Прием
/// </summary>
/// 
public sealed class Appointment
{
    public int Id { get; set; }
    public string Purpose { get; set; } = null!;
    public string? Anamnesis { get; set; }
    public string? Information { get; set; }
    public DateTime ChangeDate { get; set; }
    public DateTime CreationDate { get; set; }
    public int AppointmentStatus { get; set; }

    public int EmployeeId { get; set; }
    [ForeignKey(nameof(EmployeeId))]
    public Employee Employee { get; set; } = null!;

    public string? Recommendations { get; set; }
    public int PatientId { get; set; }
    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; } = null!;
    
    public int RegistrationId { get; set; }
    [ForeignKey(nameof(RegistrationId))]
    public Registration? Registration { get; set; }

    public ICollection<AppointmentFacility> AppointmentFacilities { get; set; } = new List<AppointmentFacility>();
    public ICollection<AppointmentDiagnoses> AppointmentDiagnoses { get; set; } = new List<AppointmentDiagnoses>();
}