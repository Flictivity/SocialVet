namespace SoVet.Domain.SqlQueries;

public static class EmployeeRepositoryQueries
{
    public const string GetReport = @"WITH FacilitySales AS (SELECT e.id          AS EmployeeId,
                                                                    e.name        AS EmployeeName,
                                                                    f.name        AS FacilityName,
                                                                    SUM(af.count) AS FacilityCount
                                                             FROM employees e
                                                                      JOIN
                                                                  appointments a ON e.id = a.employee_id
                                                                      JOIN
                                                                  appointment_facilities af ON a.id = af.appointment_id
                                                                      JOIN
                                                                  facilities f ON af.facility_id = f.id
                                                             WHERE 
                                                                  a.change_date::date >= @start and a.change_date::date <= @end
                                                             GROUP BY e.id, e.name, f.name),
                                           EmployeeSales AS (SELECT e.id         AS EmployeeId,
                                                                    e.name       AS EmployeeName,
                                                                    SUM(af.count) AS FacilitiesSell,
                                                                    SUM(af.sum)  AS FacilitiesSellSum
                                                             FROM employees e
                                                                      JOIN
                                                                  appointments a ON e.id = a.employee_id
                                                                      JOIN
                                                                  appointment_facilities af ON a.id = af.appointment_id
                                                             WHERE 
                                                                  a.change_date::date >= @start and a.change_date::date <= @end
                                                             GROUP BY e.id, e.name)
                                        SELECT es.EmployeeName,
                                               es.FacilitiesSell,
                                               es.FacilitiesSellSum,
                                               fs.FacilityName,
                                               fs.FacilityCount
                                        FROM EmployeeSales es
                                                 JOIN
                                             FacilitySales fs ON es.EmployeeId = fs.EmployeeId
                                        ORDER BY es.EmployeeName";
}