namespace SoVet.Auth.SqlQueries;

public static class UserQueries
{
    public const string GetEmployeesUsers = @"SELECT c.""ClaimValue"" FROM identity.""AspNetUserClaims"" c
                                                JOIN identity.""AspNetUsers"" u on c.""UserId"" = u.""Id""
                                                JOIN identity.""AspNetUserRoles"" ur on u.""Id"" = ur.""UserId""
                                                JOIN identity.""AspNetRoles"" r on ur.""RoleId"" = r.""Id"" 
                                                    WHERE r.""Name"" = @roleName and c.""ClaimType"" = @claimType";
}