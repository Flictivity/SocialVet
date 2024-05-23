namespace SoVet.Domain.SqlQueries;

public static class PatientRepositoryQueries
{
    public const string GetPatients = @"SELECT p.id, p.name, p.birth_date as BirthDate, a.*, c.* , p.comment as Comment FROM patients p 
                                                JOIN public.animal_type a on a.id = p.animal_type_id
                                                JOIN public.clients c on c.id = p.client_id /**where**/";
    
    public const string GetPatient = @"SELECT p.id, p.name, p.birth_date as BirthDate, a.*, c.* , p.comment as Comment FROM patients p 
                                                JOIN public.animal_type a on a.id = p.animal_type_id
                                                JOIN public.clients c on c.id = p.client_id WHERE p.id=@patientId";
}