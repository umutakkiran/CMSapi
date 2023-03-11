using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetAllPatients
{
    public class GetAllPatientsQueryResponse
    {
        public object patients { get; set; }
        public int totalCount { get; set; }
    }
}
