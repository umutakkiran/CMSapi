using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Season : BaseEntity
    {
        public string Name { get; set; }
        public bool status { get; set; }

        public ICollection<Week> Weeks { get; set; }
    }
}
