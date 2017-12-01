using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace project1.Models {
    public class PasswordAttribute : ValidationAttribute, IClientModelValidator {
        public void AddValidation(ClientModelValidationContext context) {
            // throw new NotImplementedException();
        }

        protected override ValidationResult IsValid(object value, ValidationContext context) {
            string error = String.Empty;
            string Password = value == null ? String.Empty : value.ToString();
            
            if (String.IsNullOrEmpty(Password) || Password.Length < 8) {
                error = "Password must be at least 8 characters long.\n";
            } 
            
            Regex reSymbol = new Regex("[^a-zA-Z0-9]");
            if (!reSymbol.IsMatch(Password)) {
                error += "Password must contain at least 1 symbol character.\n";
            }
            
            Regex reNum = new Regex("[0-9]+");            
            if (!reNum.IsMatch(Password)) {
                error += "Password must contain at least 1 number.\n";
            } 
            
            if (error.Length == 0) {
                return ValidationResult.Success;
            } else {
                return new ValidationResult(error.Replace(@"\n", "<br />"));
            }
        }
    }
}