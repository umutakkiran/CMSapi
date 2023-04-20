using Application.Abstraction.AbsTeam;
using CMS.Persistence.Contexts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Concrete.ConTeam
{
    public class TeamWriteRepository : WriteRepository<Team>, ITeamWriteRepository
    {
        public TeamWriteRepository(CmsDbContext context) : base(context)
        {
        }

    }
}
