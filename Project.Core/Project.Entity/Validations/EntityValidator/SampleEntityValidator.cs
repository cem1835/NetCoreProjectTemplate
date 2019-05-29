using FluentValidation;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entity.Validations
{
    public class SampleEntityValidator:AbstractValidator<SampleEntity>
    {
        public SampleEntityValidator()
        {
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Doğum Tarihi Girilmelidir..");
            RuleFor(x => x.Name).Length(3, 15);
            RuleFor(x => x.Name).Length(3).When(p => p.Id == -1);
        }
        
    }
}
