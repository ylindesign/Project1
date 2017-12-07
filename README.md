# Project1 - Login/Registration w/ Validations
Built a C#/.NET Core web page application that only allows users to register or login. The main focus of this project was to experiment with asp-for error message handling and using custom attributes.


# General Features
1. Login & Registration w/ Error Validations
   - Cannot leave any fields blank
   - First and Last Name must be at least 2 characters long
   - Password must have 1 special character, 8 characters long, and 1 number
   - Passwords must match
   - Email must be a valid email (EmailAddressAttribute)
  
  
# Screenshots

**Home Page**
![Home Page](screenshots/Validations_0_Home_1275x665.png?raw=true "Home Page")

**Blank Submit**
![Blank Submit](screenshots/Validations_1_1275x665_BlankSubmit.png?raw=true "Blank Submit")

**Single Letter Submit**
![Single Letter Submit](screenshots/Validations_2_1275x665_SingleLetterSubmit.png?raw=true "Single Letter Submit")

**Password Errors**
![Password Errors](screenshots/Validations_3_1275x665_PasswordErrors.png?raw=true "Password Errors")

**Success**
![Success](screenshots/Validations_4_1275x665_Success.png?raw=true "Success")

**Success Refresh**
![Success Refresh](screenshots/Validations_5_1275x665_SuccessRefresh.png?raw=true "Success Refresh")


# Room for Improvement
1. After extensive research, I kept the EmailAddressAttribute to validate the email address input even though it can pass entries such as "email@email" because my findings concluded it was better to NOT have too strict of email regex.
2. Will explore ways for password field to validate as user types versus seeing the error messages on submit.
