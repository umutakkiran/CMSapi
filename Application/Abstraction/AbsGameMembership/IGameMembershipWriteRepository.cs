using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.AbsGameMembership
{
    public interface IGameMembershipWriteRepository : IWriteRepository<GameMembership>
    {
    }
}
