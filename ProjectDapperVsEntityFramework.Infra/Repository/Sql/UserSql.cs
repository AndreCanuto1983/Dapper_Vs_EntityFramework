namespace ProjectDapperVsEntityFramework.Infra.Repository.Sql
{
    internal static class UserSql
    {
        internal const string query = @" SELECT
                                            Id
                                            ,Name   
                                            ,Cpf
                                            ,PhoneNumber
                                            ,BirthDate
                                            ,UserName
                                            ,Email
                                            ,EmailConfirmed
                                            ,LockoutEnabled   
                                            ,CreationDate
                                            ,UpdateDate
                                        FROM Users
                                        WHERE 
                                            Cpf IS NOT NULL";

        internal const string queryForEmail = @" SELECT
                                                     Id
                                                    ,Name   
                                                    ,Cpf
                                                    ,PhoneNumber
                                                    ,BirthDate
                                                    ,UserName
                                                    ,Email
                                                    ,EmailConfirmed
                                                    ,LockoutEnabled  
                                                    ,CreationDate
                                                    ,UpdateDate
                                                FROM Users
                                                WHERE 
                                                    Email = @Email";
    }
}