using Application.Abstraction.AbsPlayer;
using CMS.Persistence.Contexts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Concrete.ConPlayer
{
    internal class PlayerWriteRepository : WriteRepository<Player>, IPlayerWriteRepository
    {
        public PlayerWriteRepository(CmsDbContext context) : base(context)
        {
        }
    }
}
