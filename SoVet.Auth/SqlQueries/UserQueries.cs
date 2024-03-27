namespace SoVet.Auth.SqlQueries;

public static class UserQueries
{
    public const string GetEmployeesUsersByRole = @"SELECT c.""ClaimValue"" FROM identity.""AspNetUserClaims"" c
                                                JOIN identity.""AspNetUsers"" u on c.""UserId"" = u.""Id""
                                                JOIN identity.""AspNetUserRoles"" ur on u.""Id"" = ur.""UserId""
                                                JOIN identity.""AspNetRoles"" r on ur.""RoleId"" = r.""Id"" 
                                                    WHERE r.""Name"" = @roleName and c.""ClaimType"" = @claimType";
    
    public const string GetUsers = @"SELECT c.""ClaimValue"" AS Id, u.""Email"", r.""Name"" AS RoleName FROM identity.""AspNetUserClaims"" c
                                                JOIN identity.""AspNetUsers"" u on c.""UserId"" = u.""Id""
                                                JOIN identity.""AspNetUserRoles"" ur on u.""Id"" = ur.""UserId""
                                                JOIN identity.""AspNetRoles"" r on ur.""RoleId"" = r.""Id"" WHERE c.""ClaimType"" = @claimType";

    public const string GetUserEmail = @"SELECT u.""Email"" FROM identity.""AspNetUserClaims"" c 
                                                JOIN identity.""AspNetUsers"" u on c.""UserId"" = u.""Id""
                                                WHERE c.""ClaimType"" = @claimType and c.""ClaimValue"" == @userId";
}