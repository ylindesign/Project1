using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace project1.Models {
    public class FirstNameAttribute : ValidationAttribute, IClientModelValidator {
        public void AddValidation(ClientModelValidationContext context) {
            // throw new NotImplementedException();
        }

        protected override ValidationResult IsValid(object value, ValidationContext context) {
            string error = String.Empty;
            string FirstName = value == null ? String.Empty : value.ToString();

            if (String.IsNullOrEmpty(FirstName) || FirstName.Length < 2) {
                error = "First Name must be at least 2 characters long.\n";
            }

            Regex reNum = new Regex("[0-9]+");            
            if (reNum.IsMatch(FirstName)) {
                error += "First Name should not contain numbers.";
            } 

            if (error.Length == 0) {
                return ValidationResult.Success;
            } else {
                return new ValidationResult(error.Replace(@"\n", "<br />"));
            }
        }
    }
}