using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GameMembership: BaseEntity
    {
        public Guid GameId { get; set; }
        public Guid TeamId { get; set; }

        public Team Team { get; set; }
        public Game Game { get; set; }
        public Boolean IsHomeTeam { get; set; }
    }
}
