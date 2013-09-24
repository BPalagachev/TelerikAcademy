using System;
using System.Data.Entity;

public class SearchLogContext : DbContext
{
    public SearchLogContext()
        :base("SeachLogsDb")
    {
    }

    public DbSet<SearchLog> SearchLogs { get; set; }
}
