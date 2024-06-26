﻿using LanguageExt;
using LanguageExt.Pipes;
using Riok.Mapperly.Abstractions;
using SoVet.Data.Entities;
using Client = SoVet.Data.Entities.Client;

namespace SoVet.Data.Mappers;

[Mapper]
public sealed partial class DatabaseMapper
{
    public partial Domain.Models.Client Map(Client client);
    public partial Client Map(Domain.Models.Client client);
    public partial Domain.Models.Clinic Map(Clinic clinic);
    public partial Clinic Map(Domain.Models.Clinic clinic);
    public partial Employee Map(Domain.Models.Employee employee);
    public partial Domain.Models.Employee Map(Employee employee);
    public partial Domain.Models.Registration Map(Registration registration);
    
    [MapperIgnoreSource(nameof(Domain.Models.Registration.EmployeeName))]
    [MapperIgnoreSource(nameof(Domain.Models.Registration.ClientName))]
    public partial Registration Map(Domain.Models.Registration registration);
    public partial AnimalType Map(Domain.Models.AnimalType animalType);
    public partial Domain.Models.AnimalType Map(AnimalType animalType);
    
    public partial Domain.Models.Patient Map(Patient patient);
    
    [MapperIgnoreTarget(nameof(Domain.Models.Patient.AnimalType))]
    [MapperIgnoreTarget(nameof(Domain.Models.Patient.Client))]
    public partial Patient Map(Domain.Models.Patient patient);
    
    public partial Diagnosis Map(Domain.Models.Diagnosis diagnosis);
    
    public partial Domain.Models.Diagnosis Map(Diagnosis diagnosis);
    public partial Domain.Models.Appointment Map(Appointment appointment);
    [MapperIgnoreTarget(nameof(Domain.Models.Appointment.Employee))]
    public partial Appointment Map(Domain.Models.Appointment appointment);
    [MapperIgnoreTarget(nameof(Domain.Models.Facility.FacilityCategory))]
    public partial Facility Map(Domain.Models.Facility facility);
    public partial Domain.Models.Facility Map(Facility facility);
    public partial Domain.Models.AppointmentFacility Map(AppointmentFacility appointmentFacility);
    [MapperIgnoreTarget(nameof(Domain.Models.AppointmentFacility.Facility))]
    public partial AppointmentFacility Map(Domain.Models.AppointmentFacility appointmentFacility);
    
    public partial Domain.Models.AppointmentDiagnoses Map(AppointmentDiagnoses appointmentDiagnoses);
    [MapperIgnoreTarget(nameof(Domain.Models.AppointmentDiagnoses.Diagnosis))]
    public partial AppointmentDiagnoses Map(Domain.Models.AppointmentDiagnoses appointmentDiagnoses);

    public partial FacilityCategory Map(Domain.Models.FacilityCategory facilityCategory);
    public partial Domain.Models.FacilityCategory Map(FacilityCategory facilityCategory);
}