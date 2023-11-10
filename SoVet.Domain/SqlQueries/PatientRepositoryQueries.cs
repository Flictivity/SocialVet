namespace SoVet.Domain.SqlQueries;

public static class PatientRepositoryQueries
{
    public const string GetPatients = @"SELECT p.id, p.name, p.age, a.id as AnimalTypeId, a.name as AnimalTypeName,
                                            c.id as ClientId, c.name as ClientName, p.comment as Comment FROM patients p 
                                                JOIN public.animal_type a on a.id = p.animal_type_id
                                                JOIN public.clients c on c.id = p.client_id /**where**/";
}