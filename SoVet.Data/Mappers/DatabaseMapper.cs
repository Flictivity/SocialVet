using Riok.Mapperly.Abstractions;
using SoVet.Data.Entities;

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
    [MapperIgnoreSource(nameof(Domain.Models.Registration.TypeName))]
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
}