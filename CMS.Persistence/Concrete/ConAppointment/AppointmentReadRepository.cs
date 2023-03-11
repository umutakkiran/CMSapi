using Application.Abstraction;
using Application.Abstraction.AbsAppointment;
using CMS.Persistence.Contexts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Concrete.ConAppointment
{
    public class AppointmentReadRepository : ReadRepository<Appointment>, IAppointmentReadRepository
    {
        public AppointmentReadRepository(CmsDbContext context) : base(context)
        {
        }
    }
}
