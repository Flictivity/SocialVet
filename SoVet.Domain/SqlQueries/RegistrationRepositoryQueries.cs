namespace SoVet.Domain.SqlQueries;

public static class RegistrationRepositoryQueries
{
    public const string GetAvailableTimes = @"WITH all_hours as(
                                           WITH clinic_work_time AS (SELECT cs.start_time, cs.end_time FROM clinic_schedules cs LIMIT 1)
                                           SELECT * FROM generate_series(
                                               @dateReg::date + (SELECT mt.start_time FROM clinic_work_time mt),
                                               @dateReg::date + (SELECT mt.end_time FROM clinic_work_time mt), '90 minutes') as hour
                                       )
                                       SELECT hour FROM all_hours ah WHERE ah.hour not in (select r.start_time from registrations r 
                                            WHERE r.employee_id = @employeeId and r.start_time::date = @dateReg::date) 
                                                and EXTRACT(HOUR FROM ah.hour) > EXTRACT(HOUR FROM now() AT TIME ZONE 'Europe/Moscow')";

    public const string GetRegistrations =
        @"SELECT r.id, r.start_time as StartTime, c.id as ClientId, c.name as ClientName, e.id as EmployeeId,
                                                       e.name as EmployeeName, r.Comment as Comment
                                                FROM public.registrations r
                                                         JOIN public.clients c on c.id = r.client_id
                                                         JOIN public.employees e on e.id = r.employee_id /**where**/";
}