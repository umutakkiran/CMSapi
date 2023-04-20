using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Player: BaseEntity
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string age { get; set; }
        public string? Photo { get; set; }

        public Team? Team { get; set; }


    }
}
