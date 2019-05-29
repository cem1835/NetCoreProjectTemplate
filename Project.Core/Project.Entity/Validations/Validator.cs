using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entity.Validations
{
    public class Validator
    {
        public static void Validate(IValidator validator,object obj)
        {
            var res = validator.Validate(obj);

            if (res.Errors.Count > 0)
            {
                throw new ValidationException(res.Errors);
            }
        }
    }
}
