using ProjectLatest.Core.Models;
using ProjectLatest.DAL.Contexts;
using ProjectLatest.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLatest.DAL.Repositories.Implementations
{
    public class ExploreItemRepository : Repository<ExploreItem>, IExploreItemRepository
    {
        public ExploreItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}
