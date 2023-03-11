using Application.Features.GetAllDoctors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService (this IServiceCollection service)
        {
           
            service.AddMediatR(typeof(ServiceRegistration));
        }
    }
}
