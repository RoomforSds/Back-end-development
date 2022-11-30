using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TestWebapi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Students> Students { get; set; }
        public DbSet<s> s { get; set; }
        public DbSet<Test> Test { get; set; }

        public string GetConStr(string conStr)
        {
            return conStr;
        }
    }
}

