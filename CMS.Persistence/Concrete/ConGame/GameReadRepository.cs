using Application.Abstraction.AbsGame;
using CMS.Persistence.Contexts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Concrete.ConGame
{
    public class GameReadRepository : ReadRepository<Game>, IGameReadRepository
    {
        public GameReadRepository(CmsDbContext context) : base(context)
        {
        }
    }
}
