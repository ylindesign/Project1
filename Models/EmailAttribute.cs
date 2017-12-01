using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace project1.Models
{
    public class EmailAttribute : ValidationAttribute, IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            // throw new NotImplementedException();
        }

        protected override ValidationResult IsValid(object value, ValidationContext context) 
        {
            string error = String.Empty;
            string Email = value == null ? String.Empty : value.ToString();

            // if (String.IsNullOrEmpty(Email) || Email.Length < 2) {
            //     error = "First Name must be at least 2 characters long.\n";
            // }

            Regex reEmail = new Regex("[0-9]+");            
            if (reEmail.IsMatch(Email)) {
                error += "First Name should not contain numbers.";
            } 

            // if (error.Length == 0) {
            //     return ValidationResult.Success;
            // } else {
            //     return new ValidationResult(error.Replace(@"\n", "<br />"));
            // }

            EmailAddressAttribute e = new EmailAddressAttribute();
            if (e.IsValid(Email)) {
                return ValidationResult.Success;
            } else { 
                error += "Test test test.";
                return new ValidationResult(error.Replace(@"\n", "<br />"));
            }
        } 
    }
}