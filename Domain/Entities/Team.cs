using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string Logo { get; set; }

        public ICollection<Player>? Players { get; set; }
        public ICollection<GameMembership>? GameMemberships { get; set; }

    }
}
