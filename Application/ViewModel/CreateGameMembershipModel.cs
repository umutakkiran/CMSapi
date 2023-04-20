using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class CreateGameMembershipModel
    {
        public Guid GameId { get; set; }
        public Guid TeamId { get; set; }
        public Boolean IsHomeTeam { get; set; }

    }
}
