using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class CreatePlayerModel
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string age { get; set; }
        public string photo { get; set; }

    }
}
