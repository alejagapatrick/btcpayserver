﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BTCPayServer.Validation
{
    //from https://stackoverflow.com/a/47196738/275504
    public class UriAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Uri uri;
            bool valid = Uri.TryCreate(Convert.ToString(value, CultureInfo.InvariantCulture), UriKind.Absolute, out uri);

            if (!valid)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}