using Application.Abstraction;
using Application.Abstraction.AbsDoctor;
using CMS.Persistence.Contexts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Concrete.ConDoctor
{
    public class DoctorWriteRepository : WriteRepository<Doctor>, IDoctorWriteRepository
    {
        public DoctorWriteRepository(CmsDbContext context) : base(context)
        {
        }
    }
}
