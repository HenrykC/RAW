using Microsoft.EntityFrameworkCore;
using ShowCase.Models;
using ShowCase.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Examples.Repository
{
    public class ExamplesRepository : IExamplesRepository
    {
        private readonly DbContextOptions<ShowCaseDbContext> dbContextOptions;

        public ExamplesRepository(DbContextOptions<ShowCaseDbContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public IList<Example> GetExamples()
        {
            var dbContext = new ShowCaseDbContext(dbContextOptions);

            return dbContext.Examples.ToList();
        }
    }
}
