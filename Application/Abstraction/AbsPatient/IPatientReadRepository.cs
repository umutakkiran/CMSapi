﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.AbsPatient
{
    public interface IPatientReadRepository : IReadRepository<Patient>
    {
    }
}
