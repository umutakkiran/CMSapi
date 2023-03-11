using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class AddDoctorValidator : AbstractValidator<Doctor>
    {
        public AddDoctorValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Lütfen isim alanını doldurunuz");
            RuleFor(p => p.Surname).NotEmpty().NotNull().WithMessage("Lütfen soyisim alanını doldurunuz");

        }
    }
   
}
