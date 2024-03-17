
using ZR.CodingExample.SecureCoding.Functions;
using ZR.CodingExamples.SecureCodeing.Functions;
 

Console.WriteLine("Ziggy Rafiq Test Consonsole App!");
string username = "JohnDoe";
string password = "pa$$w0rd";
string email = "johndoe@example.com";

bool isValidRegistration = User.ValidateRegistrationForm(username, password, email);

if (isValidRegistration)
{
    Console.WriteLine("Registration form is valid.");
}
else
{
    Console.WriteLine("Registration form is not valid.");
}


string emailToValidate = "example@example.com";

bool isValidEmail = User.IsValidEmail(emailToValidate);


if (isValidEmail)
{
    Console.WriteLine("Email is valid.");
}
else
{
    Console.WriteLine("Email is not valid.");
}

 
Console.WriteLine(Passwords.HashPassword("Testing123456YouGoFree"));

string userInput = "<script>alert('XSS attack');</script>";
string sanitizedUserInput =  WebFormsExample.SanitizeInput(userInput);

Console.WriteLine("Original Input: " + userInput);
Console.WriteLine("Sanitized Input: " + sanitizedUserInput);


Console.ReadLine();

