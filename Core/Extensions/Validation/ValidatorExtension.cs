using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions.Validation
{
    public static class ValidatorExtension
    {
        public static IResult ThrowIfExeption(this FluentValidation.Results.ValidationResult validationResult) 
        {
            if (validationResult.IsValid) return new SuccessResult();

            return new ErrorResult(String.Join(',', validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }
}
