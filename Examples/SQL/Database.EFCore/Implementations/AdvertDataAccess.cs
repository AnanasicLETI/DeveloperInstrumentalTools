using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Contracts;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.EFCore.Implementations
{
    public class AdvertDataAccess : IAdvertDataAccess
    {
        private ExampleContext ExampleContext { get; }
        
        public AdvertDataAccess(ExampleContext exampleContext)
        {
            ExampleContext = exampleContext;
        }

        public async Task<IEnumerable<AdvertEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await this.ExampleContext.Adverts
                .Include(x => x.Type)
                .OrderBy(x => x.TimeStamp)
                .ToListAsync(ct);
        }
    }
}