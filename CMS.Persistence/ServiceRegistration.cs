﻿using Application.Abstraction;
using Application.Abstraction.AbsAppointment;
using Application.Abstraction.AbsContent;
using Application.Abstraction.AbsDoctor;
using Application.Abstraction.AbsPatient;
using CMS.Persistence.Concrete;
using CMS.Persistence.Concrete.ConAppointment;
using CMS.Persistence.Concrete.ConContent;
using CMS.Persistence.Concrete.ConDoctor;
using CMS.Persistence.Concrete.ConPatient;
using CMS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence
{
    public static class ServiceRegistration
    {
         public static void AddPersistenceServices(this IServiceCollection service)
        {
            //alttaki 3 satırda extensions.configuration ve extensions.configuration.json kütüphanelerini kullanarak appsettings.json ın dosya yoluna ulaşıp oradaki connectionstring i kullanmaya hazır hale getiririz.
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CMS.Presentation"));
            configurationManager.AddJsonFile("appsettings.json");
            service.AddDbContext<CmsDbContext>(options => options.UseNpgsql(configurationManager.GetConnectionString("DefaultConnection")));

            service.AddScoped<IAppointmentReadRepository, AppointmentReadRepository>();
            service.AddScoped<IAppointmentWriteRepository, AppointmentWriteRepository>();

            service.AddScoped<IDoctorReadRepository, DoctorReadRepository>();
            service.AddScoped<IDoctorWriteRepository, DoctorWriteRepository>();

            service.AddScoped<IPatientReadRepository, PatientReadRepository>();
            service.AddScoped<IPatientWriteRepository, PatientWriteRepository>();

            service.AddScoped<IContentReadRepository, ContentReadRepository>();
            service.AddScoped<IContentWriteRepository, ContentWriteRepository>();

        }
    }
}
