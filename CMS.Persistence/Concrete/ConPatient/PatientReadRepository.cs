using Application.Abstraction;
using Application.Abstraction.AbsPatient;
using CMS.Persistence.Contexts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Concrete.ConPatient
{
    public class PatientReadRepository : ReadRepository<Patient>, IPatientReadRepository
    {
        public PatientReadRepository(CmsDbContext context) : base(context)
        {
        }
    }
}
