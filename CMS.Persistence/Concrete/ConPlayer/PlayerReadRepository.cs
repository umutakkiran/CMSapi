using Application.Abstraction;
using Application.Abstraction.AbsPlayer;
using CMS.Persistence.Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Concrete.ConPlayer
{
    public class PlayerReadRepository : ReadRepository<Player>, IPlayerReadRepository
    {
        public PlayerReadRepository(CmsDbContext context) : base(context)
        {
        }

        public IQueryable<Player> GetPlayerByTeam(Expression<Func<Player, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
    }
}
