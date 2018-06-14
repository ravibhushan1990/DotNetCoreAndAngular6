using Microsoft.EntityFrameworkCore.Infrastructure;


public class SchoolContextFactory //: IDbContextFactory<SchoolContext>
{
    public SchoolContext Create()
    {
        return new SchoolContext("Data Source = RAVI; Initial Catalog = AdventureWorks2016CTP3; Integrated Security = True;");
    }

    public SchoolContext Create(DbContextFactoryOptions options)
    {
        throw new System.NotImplementedException();
    }
}