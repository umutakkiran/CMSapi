using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GetAllDoctors
{
    public class GetAllDoctorsQueryResponse
    {
        public object doctors { get; set; }
        public int totalCount { get; set; }
    }
}
