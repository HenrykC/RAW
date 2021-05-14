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

        public ResultExample AddExamples(Example example)
        {
            using var dbContext = new ShowCaseDbContext(dbContextOptions);
            dbContext.Add(example);
            if (dbContext.SaveChanges() != 1)
            {
                throw new Exception();
            }

            return new ResultExample() { Self = example.Id.ToString() };
        }

        public bool DeleteExamples(int id)
        {
            using var dbContext = new ShowCaseDbContext(dbContextOptions);
            var data = dbContext.Examples.Where(w => w.Id == id).FirstOrDefault();
            if (data == null || data.Id == 0)
            {
                throw new Exception();
            }

            dbContext.Remove(data);
            dbContext.SaveChanges();

            return true;
        }

        public Example GetExample(int id)
        {
            using var dbContext = new ShowCaseDbContext(dbContextOptions);
            return dbContext.Examples.AsNoTracking().FirstOrDefault(w => w.Id == id);
        }

        public IList<Example> GetExamples()
        {
            using var dbContext = new ShowCaseDbContext(dbContextOptions);

            return dbContext.Examples.ToList();
        }

        public Example UpdateExample(Example example)
        {
            throw new NotImplementedException();
        }
    }
}
