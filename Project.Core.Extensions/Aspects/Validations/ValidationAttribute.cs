using FluentValidation;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Project.Extensions.Aspects.Validations
{
    [Serializable]
    public class ValidationAttribute:OnMethodBoundaryAspect
    {

        Type _validator;

        private ValidationAttribute()
        {

        }
        public ValidationAttribute(Type validator)
        {
            _validator = validator;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validator);
            var entityType = _validator.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                var res = validator.Validate(entity);

                if (res.Errors.Count > 0)
                    throw new ValidationException(res.Errors);
                // TODO : LOG
            }
        }
    }
}
