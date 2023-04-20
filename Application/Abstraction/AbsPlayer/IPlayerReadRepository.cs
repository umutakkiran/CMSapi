using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.AbsPlayer
{
    public interface IPlayerReadRepository : IReadRepository<Player>
    {
        IQueryable<Player> GetPlayerByTeam(Expression<Func<Player, bool>> method, bool tracking = true);

    }
}
