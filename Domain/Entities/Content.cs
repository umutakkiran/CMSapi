using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Content : BaseEntity
    {
        public string Title { get; set; }
        public string AnyText { get; set; }

    }
}
