using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Week: BaseEntity
    {
        public Guid SeasonId { get; set; }
        public string Name { get; set; }

        public Season Season { get; set; }
    }
}
