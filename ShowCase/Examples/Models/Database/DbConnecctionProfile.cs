using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Examples.Models.Database
{
    public class DbConnecctionProfile : IDbConnecctionProfile
    {
        public string ConnectionString { get; set; }
    }
}
