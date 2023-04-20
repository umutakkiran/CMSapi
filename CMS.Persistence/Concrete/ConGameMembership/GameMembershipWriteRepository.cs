using Application.Abstraction.AbsGame;
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
    public class GameMembershipWriteRepository : WriteRepository<GameMembership>, IGameMembershipWriteRepository
    {
        public GameMembershipWriteRepository(CmsDbContext context) : base(context)
        {
        }
    }
}
