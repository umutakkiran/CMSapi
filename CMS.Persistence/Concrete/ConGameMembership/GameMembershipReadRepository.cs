using Application.Abstraction.AbsGameMembership;
using CMS.Persistence.Contexts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Concrete.ConGameMembership
{
    public class GameMembershipReadRepository : ReadRepository<GameMembership>, IGameMembershipReadRepository
    {
        public GameMembershipReadRepository(CmsDbContext context) : base(context)
        {
        }
    }
}
