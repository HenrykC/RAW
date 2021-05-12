using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShowCase.Models.Database
{
    public class ShowCaseDbContext : DbContext
    {
        public ShowCaseDbContext(DbContextOptions<ShowCaseDbContext> options) : base(options)
        {
        }

        public DbSet<ExampleView> ExampleViews { get; set; }
        public DbSet<Example> Examples { get; set; }
    }
}
