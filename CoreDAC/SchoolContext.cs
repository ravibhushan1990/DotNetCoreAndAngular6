using Microsoft.EntityFrameworkCore;


public class SchoolContext : DbContext
{
    public SchoolContext(string connString) : base()
    {
    }
}