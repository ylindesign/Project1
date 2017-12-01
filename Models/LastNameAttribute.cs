using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace project1.Models {
    public class LastNameAttribute : ValidationAttribute, IClientModelValidator {
        public void AddValidation(ClientModelValidationContext context) {
            // throw new NotImplementedException();
        }

        protected override ValidationResult IsValid(object value, ValidationContext context) {
            string error = String.Empty;
            string LastName = value == null ? String.Empty : value.ToString();

            if (String.IsNullOrEmpty(LastName) || LastName.Length < 2) {
                error = "Last Name must be at least 2 characters long.\n";
            }

            Regex reNum = new Regex("[0-9]+");            
            if (reNum.IsMatch(LastName)) {
                error += "Last Name should not contain numbers.";
            } 

            if (error.Length == 0) {
                return ValidationResult.Success;
            } else {
                return new ValidationResult(error.Replace(@"\n", "<br />"));
            }
        }
    }
}