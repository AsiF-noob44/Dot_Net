﻿using System;
using System.ComponentModel.DataAnnotations;

public class DateOfBirthValidator
{
    public static ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dob)
        {
            int age = DateTime.Today.Year - dob.Year;
            if (dob > DateTime.Today.AddYears(-age)) age--;

            return age >= 18 ? ValidationResult.Success : new ValidationResult("Age must be greater than 18.");
        }
        return new ValidationResult("Invalid date of birth.");
    }
}
